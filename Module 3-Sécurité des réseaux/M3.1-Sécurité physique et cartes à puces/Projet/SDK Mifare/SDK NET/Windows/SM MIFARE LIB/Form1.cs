using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace MainForm
{
    
    public partial class Form1 : Form
    {

        


        //static SerialPort _serialPort;
        //private SerialPort port = new SerialPort("COM1", 19200, Parity.None, 8, StopBits.One);    
        public static sm_mifare_lib.mifare sm132 = new sm_mifare_lib.mifare();
            
        public Form1()
        {
            InitializeComponent();
                      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i = 0;
            string[] ports = SerialPort.GetPortNames();


            foreach (string port_name in ports)
            {
                comboBox1.Items.Add(port_name);

            }
            comboBox1.SelectedIndex = 0;

            cmb_E2promBlockNo.SelectedIndex = 0;

            for (i = 0; i <= 255; i++)
            {
                cmb_AuthBlockNo.Items.Add(i.ToString());
                cmb_RWBlockNo.Items.Add(i.ToString());

            }

            cmb_AuthBlockNo.SelectedIndex = 1;
            cmb_RWBlockNo.SelectedIndex = 1;

        }





        private void btn_init_Click(object sender, EventArgs e)
        {

            //sm_mifare_lib.mifare sm132 = new sm_mifare_lib.mifare();
            //sm132.InitPort();

            if (sm132.OpenPort(comboBox1.Text, 19200))
            {
                textBox1.Text = "Port is initialized and opened";
                timer1.Enabled = true;
            }
            else
            textBox1.Text = "Port could not be opened";
            
            
        }

        private void btn_closeport_Click(object sender, EventArgs e)
        {

            //sm_mifare_lib.mifare sm132 = new sm_mifare_lib.mifare();
            sm132.ClosePort();
                       
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {

            //sm_mifare_lib.mifare sm132 = new sm_mifare_lib.mifare();
            string Firmware;

            if (sm132.CMD_ResetDevice(out Firmware))
                textBox1.Text = Firmware;
            else
                textBox1.Text = "Error. Expecting Firmware Version";

        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            //sm_mifare_lib.mifare sm132 = new sm_mifare_lib.mifare();
            
            byte TagType;
            byte[] TagSerial = new byte[4];
            byte ReturnCode = 0;
            byte i;


            if (sm132.CMD_SelectTag(out TagType, out TagSerial, out ReturnCode))
            {
                textBox1.Text = "Tag Type:" + TagType.ToString() + " ";
                textBox1.Text += " Tag Serial: ";


                for (i = 0; i < 4; i++)
                    textBox1.Text += TagSerial[i].ToString("X2");

            }
            else //Select not successful
            {
                if (ReturnCode==0x4E) //'N'
                textBox1.Text = "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode==0x55) //'U'
                textBox1.Text = "RF Field is off. Error Code:" + ReturnCode.ToString("X2");
                else
                textBox1.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");

            }




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Here you can get a response as soon as a tag enters into RF Field if SeekForTag command was executed previously. ( Response_Type=2)
            //Also, you can get a response here, if module resets or power-Off/ON. That's the firmware version sent when module resets. (Response_Type=1)

            byte[] TagSerial = new byte[4];
            string Firmware = "";
            byte Response_Type = 0;
            byte TagType = 0;
            int buffercount = 0;
            byte i = 0;

            //Check if incoming data packet is ready in the buffer?

            if (sm_mifare_lib.mifare.port.IsOpen)
            buffercount = sm_mifare_lib.mifare.port.BytesToRead;
            
            if (buffercount != 0)
            {
                //There are bytes need to be read in the serial port buffer
                //This event occurs, if Mifare device sends data to PC at any time that PC is not expecting a response to a command.
                //Response Type = 1 This situation can occur, if Mifare device resets(i.e power off/on), it sends firmware version information
                //Response Type = 2 This situation can occur, if CMD_SeekForTag command is executed, and whenever a tag enters into the field, device sends its serial number information.
                sm132.ParseIncoming(out Response_Type, out TagType, out TagSerial,out  Firmware);

                if (Response_Type == 1)
                {
                    textBox1.Text = "Reset Message arrived: Firmware:" + Firmware;
                }
                else if (Response_Type == 2) //A Tag entered into the RF Field.
                {
                    timer1.Enabled = false; //optional
                    //Do neccessary operations below>>
                    
                    textBox1.Text = "Tag Type:" + TagType.ToString() + " ";
                    textBox1.Text += " Tag Serial: ";


                    for (i = 0; i < 4; i++)
                        textBox1.Text += TagSerial[i].ToString("X2");

                    
                    //<<Do neccessary operations above
                    
                    timer1.Enabled = true; //optional

                }
                else
                {
                    textBox1.Text = " Unrecognized Response";

                }

                

            }


        }

        private void btn_SeekForTag_Click(object sender, EventArgs e)
        {

            //sm_mifare_lib.mifare sm132 = new sm_mifare_lib.mifare();

            byte ReturnCode = 0;

            if (sm132.CMD_SeekForTag(out ReturnCode))
                textBox1.Text = "Seeking For Tag";          //If a tag enters into field, it will be processed in Timer Event.
            else //SeekForTag Command is not successful
            {
                if (ReturnCode == 0x55) //'N'
                    textBox1.Text = "RF Field is off. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode==0)
                    textBox1.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                else 
                    textBox1.Text = "Unknown Error. Error Code:" + ReturnCode.ToString("X2");

            }

            
        }

        private void rdb_MDefault_CheckedChanged(object sender, EventArgs e)
        {
            cmb_E2promBlockNo.Enabled = false;
            rdb_KeyA.Enabled = false;
            rdb_KeyB.Enabled = false;
            t_K1.Enabled = false;
            t_K2.Enabled = false;
            t_K3.Enabled = false;
            t_K4.Enabled = false;
            t_K5.Enabled = false;
            t_K6.Enabled = false;

        }

        private void rdb_PKey_CheckedChanged(object sender, EventArgs e)
        {
            cmb_E2promBlockNo.Enabled = false;
            rdb_KeyA.Enabled = true;
            rdb_KeyB.Enabled = true;

            t_K1.Enabled = true;
            t_K2.Enabled = true;
            t_K3.Enabled = true;
            t_K4.Enabled = true;
            t_K5.Enabled = true;
            t_K6.Enabled = true;

        }

        private void rdb_E2prom_CheckedChanged(object sender, EventArgs e)
        {

            cmb_E2promBlockNo.Enabled = true;
            rdb_KeyB.Enabled = true;
            rdb_KeyA.Enabled = true;

            t_K1.Enabled = false;
            t_K2.Enabled = false;
            t_K3.Enabled = false;
            t_K4.Enabled = false;
            t_K5.Enabled = false;
            t_K6.Enabled = false;


        }

        private void cmb_AuthBlockNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_RWBlockNo.SelectedIndex = cmb_AuthBlockNo.SelectedIndex;

        }

        private void cmb_RWBlockNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_AuthBlockNo.SelectedIndex = cmb_RWBlockNo.SelectedIndex;

        }

        private void btn_auth_Click(object sender, EventArgs e)
        {
            byte AuthSource = 0xFF;
            byte BlockNo;
            byte ReturnCode;
            byte[] Key = new byte[6];

            
             
            BlockNo = byte.Parse(cmb_AuthBlockNo.Text);

            //The following Key will be used only if Provided Key option is selected.
            Key[0] = byte.Parse(t_K1.Text, System.Globalization.NumberStyles.HexNumber);
            Key[1] = byte.Parse(t_K2.Text, System.Globalization.NumberStyles.HexNumber);
            Key[2] = byte.Parse(t_K3.Text, System.Globalization.NumberStyles.HexNumber);
            Key[3] = byte.Parse(t_K4.Text, System.Globalization.NumberStyles.HexNumber);
            Key[4] = byte.Parse(t_K5.Text, System.Globalization.NumberStyles.HexNumber);
            Key[5] = byte.Parse(t_K6.Text, System.Globalization.NumberStyles.HexNumber);


            //Mifare Default Key?
            if (rdb_MDefault.Checked == true)
            {
                AuthSource = (byte)sm_mifare_lib.ASource.KeyMifareDefault;
            }

            //Provided Key?
            if (rdb_PKey.Checked == true)
            {

                if (rdb_KeyA.Checked == true)
                    AuthSource = (byte)sm_mifare_lib.ASource.KeyTypeA;
                if (rdb_KeyB.Checked == true)
                    AuthSource = (byte)sm_mifare_lib.ASource.KeyTypeB;
                
                //Keys were previosly loaded above.

            }

             

            //E2Prom Key (Internal SOurce) ?

           
              
            if (rdb_E2prom.Checked == true)
            {

                if (rdb_KeyA.Checked==true)
                AuthSource = sm_mifare_lib.mifare.E2promKeyA[cmb_E2promBlockNo.SelectedIndex];
                else if (rdb_KeyB.Checked ==true)
                AuthSource = sm_mifare_lib.mifare.E2promKeyB[cmb_E2promBlockNo.SelectedIndex];
 
           
            }
        


            //Authenticate
            if (sm132.CMD_Authenticate(AuthSource, Key, BlockNo, out ReturnCode)) 
            {
                textBox1.Text = " Authentication Success ";
                textBox_S.Text = textBox1.Text;

            }
            else
            {
                
                if (ReturnCode == 0x4E) //'N'
                textBox1.Text = "No Tag or Login failed. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x55)
                textBox1.Text = "Login failed. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x45)
                textBox1.Text = "Invalid Key Format. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0)
                textBox1.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                else
                textBox1.Text = "Unknown Error. Error Code:" + ReturnCode.ToString("X2");
                

                textBox_S.Text = textBox1.Text;

            }

            


        }

        private void btn_Halt_Click(object sender, EventArgs e)
        {

            byte ReturnCode = 0;
         

            if (sm132.CMD_Halt(out ReturnCode))
                textBox1.Text = "Halt successfull";
            else //Halt not successful
            {
                if (ReturnCode == 0x55) //'U'
                    textBox1.Text = "Halt not successfull. Error Code:" + ReturnCode.ToString("X2");
                else
                    textBox1.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");

            }


        }

        private void btn_Read_Click(object sender, EventArgs e)
        {

            byte BlockNo = 0;
            byte[] BlockData = new byte[16];
            byte ReturnCode = 0;
            
            BlockNo = byte.Parse(cmb_RWBlockNo.Text);


            if (sm132.CMD_ReadBlock(BlockNo,out BlockData,out ReturnCode))
            {
                textBox1.Text = "Read Successfull";
                textBox_S.Text = textBox1.Text;

                t_B1.Text = BlockData[0].ToString("X2");
                t_B2.Text = BlockData[1].ToString("X2");
                t_B3.Text = BlockData[2].ToString("X2");
                t_B4.Text = BlockData[3].ToString("X2");
                t_B5.Text = BlockData[4].ToString("X2");
                t_B6.Text = BlockData[5].ToString("X2");
                t_B7.Text = BlockData[6].ToString("X2");
                t_B8.Text = BlockData[7].ToString("X2");
                t_B9.Text = BlockData[8].ToString("X2");
                t_B10.Text = BlockData[9].ToString("X2");
                t_B11.Text = BlockData[10].ToString("X2");
                t_B12.Text = BlockData[11].ToString("X2");
                t_B13.Text = BlockData[12].ToString("X2");
                t_B14.Text = BlockData[13].ToString("X2");
                t_B15.Text = BlockData[14].ToString("X2");
                t_B16.Text = BlockData[15].ToString("X2");
             

            }
            else //Read not successful
            {
                if (ReturnCode == 0x4E) //'N'
                    textBox1.Text = "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x46) //'F'
                    textBox1.Text = "Read Failed:" + ReturnCode.ToString("X2");
                else
                    textBox1.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");

                textBox_S.Text = textBox1.Text;

            }


        }

        private void btn_Write_Click(object sender, EventArgs e)
        {

            byte BlockNo = 0;
            byte[] BlockData = new byte[16];
            byte ReturnCode = 0;

            BlockNo = byte.Parse(cmb_RWBlockNo.Text);
            BlockData[0] = byte.Parse(t_B1.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[1] = byte.Parse(t_B2.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[2] = byte.Parse(t_B3.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[3] = byte.Parse(t_B4.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[4] = byte.Parse(t_B5.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[5] = byte.Parse(t_B6.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[6] = byte.Parse(t_B7.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[7] = byte.Parse(t_B8.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[8] = byte.Parse(t_B9.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[9] = byte.Parse(t_B10.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[10] = byte.Parse(t_B11.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[11] = byte.Parse(t_B12.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[12] = byte.Parse(t_B13.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[13] = byte.Parse(t_B14.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[14] = byte.Parse(t_B15.Text, System.Globalization.NumberStyles.HexNumber);
            BlockData[15] = byte.Parse(t_B16.Text, System.Globalization.NumberStyles.HexNumber);
            
            if (sm132.CMD_WriteBlock(BlockNo,BlockData, out ReturnCode))
            {
                textBox1.Text = "Write is Successfull";
                textBox_S.Text = textBox1.Text;

            }
            else //Write not successful
            {
                if (ReturnCode == 0x4E) //'N'
                    textBox1.Text = "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x46) //'F'
                    textBox1.Text = "Write Failed:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x55) //'U'
                    textBox1.Text = "Read after write Failed:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x58) //'X'
                    textBox1.Text = "Unable to read after write" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x01) //
                    textBox1.Text = "Writing to Sector Trailer is not allowed with this function" + ReturnCode.ToString("X2");
                else
                    textBox1.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");

                textBox_S.Text = textBox1.Text;

            }




            
            
              

        }

        private void btn_ReadV_Click(object sender, EventArgs e)
        {

            byte BlockNo = 0;
            long Value = 0;
            byte ReturnCode = 0;

            BlockNo = byte.Parse(cmb_RWBlockNo.Text);


            if (sm132.CMD_ReadValue(BlockNo, out Value, out ReturnCode))
            {
                textBox1.Text = "Value Read Successfull";
                textBox_S.Text = textBox1.Text;

                t_ReadValue.Text = Value.ToString();
                

            }
            else //ReadValue not successful
            {
                if (ReturnCode == 0x4E) //'N'
                    textBox1.Text = "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x46) //'F'
                    textBox1.Text = "Read Failed. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x49) //'I'
                    textBox1.Text = "Invalid Value Block. Error Code:" + ReturnCode.ToString("X2");
                else
                    textBox1.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");

                textBox_S.Text = textBox1.Text;

            }



        }

        private void btn_WriteV_Click(object sender, EventArgs e)
        {


            byte BlockNo = 0;
            long Value = 0;
            byte ReturnCode = 0;

            BlockNo = byte.Parse(cmb_RWBlockNo.Text);
            Value = Int32.Parse(t_WriteValue.Text);

            if (sm132.CMD_WriteValue(BlockNo,Value, out ReturnCode))
            {
                textBox1.Text = "Write Value is Successfull";
                textBox_S.Text = textBox1.Text;

                t_ReadValue.Text = Value.ToString();

            }
            else //WriteValue not successful
            {
                if (ReturnCode == 0x4E) //'N'
                    textBox1.Text = "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x46) //'F'
                    textBox1.Text = "Write Failed. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x58) //'X'
                    textBox1.Text = "Unable to read after write. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x55) //'U'
                    textBox1.Text = "Read after write failed. Error Code:" + ReturnCode.ToString("X2");
                else
                    textBox1.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");

                textBox_S.Text = textBox1.Text;

            }



        }

        private void btn_Inc_Click(object sender, EventArgs e)
        {

            byte BlockNo = 0;
            long IncValue = 0;
            long NewValue = 0;
            byte ReturnCode = 0;

            BlockNo = byte.Parse(cmb_RWBlockNo.Text);
            IncValue = Int32.Parse(t_IncDec.Text);

            if (sm132.CMD_IncrementValue(BlockNo, IncValue, out NewValue,out ReturnCode))
            {
                textBox1.Text = "Increment is successfull";
                textBox_S.Text = textBox1.Text;

                t_ReadValue.Text = NewValue.ToString();

            }
            else //Increment Value not successful
            {
                if (ReturnCode == 0x4E) //'N'
                    textBox1.Text = "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x46) //'F'
                    textBox1.Text = "Read Failed during verification. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x49) //'I'
                    textBox1.Text = "Invalid Value Block. Error Code:" + ReturnCode.ToString("X2");
                else
                    textBox1.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");

                textBox_S.Text = textBox1.Text;

            }





        }

        private void btn_Dec_Click(object sender, EventArgs e)
        {

            byte BlockNo = 0;
            long DecValue = 0;
            long NewValue = 0;
            byte ReturnCode = 0;

            BlockNo = byte.Parse(cmb_RWBlockNo.Text);
            DecValue = Int32.Parse(t_IncDec.Text);

            if (sm132.CMD_DecrementValue(BlockNo, DecValue, out NewValue, out ReturnCode))
            {
                textBox1.Text = "Decrement is successfull";
                textBox_S.Text = textBox1.Text;

                t_ReadValue.Text = NewValue.ToString();

            }
            else //Decrement Value not successful
            {
                if (ReturnCode == 0x4E) //'N'
                    textBox1.Text = "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x46) //'F'
                    textBox1.Text = "Read Failed during verification. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x49) //'I'
                    textBox1.Text = "Invalid Value Block. Error Code:" + ReturnCode.ToString("X2");
                else
                    textBox1.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");

                textBox_S.Text = textBox1.Text;

            }






        }

        private void btn_SwitchOffRF_Click(object sender, EventArgs e)
        {
            byte ReturnCode = 0;

            if (sm132.CMD_SwitchRF(false, out ReturnCode))
            {
                textBox1.Text = " RF Switched off";
            }
            else
            {
                textBox1.Text = "Switch Off. Error Code:" + ReturnCode.ToString("X2");

            }


        }

        private void btn_SwitchOnRF_Click(object sender, EventArgs e)
        {
            byte ReturnCode = 0;

            if (sm132.CMD_SwitchRF(true, out ReturnCode))
            {
                textBox1.Text = " RF Switched On";
            }
            else
            {
                textBox1.Text = "Switch On. Error Code:" + ReturnCode.ToString("X2");

            }
        }

        


       
    }
}