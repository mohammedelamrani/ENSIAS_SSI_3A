using System.Linq;
using System.Threading.Tasks;
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
        private string HexString2Ascii(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }
        public static sm_mifare_lib.mifare sm132 = new sm_mifare_lib.mifare();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port_name in ports)
            {
                comboBox1.Items.Add(port_name);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            //sm_mifare_lib.mifare sm132 = new sm_mifare_lib.mifare();
            //sm132.InitPort();

            if (sm132.OpenPort(comboBox1.Text, 19200))
            {
                richTextBox1.Text += "Port is initialized and opened\n";
                timer1.Enabled = true;

                //sm_mifare_lib.mifare sm132 = new sm_mifare_lib.mifare();

                //select tag begin
                byte TagType;
                byte[] TagSerial = new byte[4];
                byte ReturnCode = 0;
                byte i;


                if (sm132.CMD_SelectTag(out TagType, out TagSerial, out ReturnCode))
                {
                    richTextBox1.Text += "Tag Type:" + TagType.ToString() + "\n";
                    richTextBox1.Text += "Tag Serial: ";

                    for (i = 0; i < 4; i++)
                        richTextBox1.Text += TagSerial[i].ToString("X2");

                    //auth begin
                    byte AuthSource = 0xFF;
                    byte BlockNo;
                    //byte ReturnCode;
                    byte[] Key = new byte[6];

                    BlockNo = byte.Parse("1");

                    //Mifare Default Key
                        AuthSource = (byte)sm_mifare_lib.ASource.KeyMifareDefault;

                    //Authenticate
                    if (sm132.CMD_Authenticate(AuthSource, Key, BlockNo, out ReturnCode))
                    {
                        richTextBox1.Text += "\nAuthentication Success Bloc: " + BlockNo +"\n";
                        //textBox_S.Text = textBox1.Text;

                        byte BlockLogin = 1;
                        byte BlockPwd = 2;
                        byte[] BlockDataLogin = new byte[16];
                        byte[] BlockDataPwd = new byte[16];
                        string login_rfid = "";
                        string pwd_rfid = "";

                        if (sm132.CMD_ReadBlock(BlockLogin, out BlockDataLogin, out ReturnCode))
                        {
                            richTextBox1.Text += "Read Successfull\n";

                            login_rfid =  BlockDataLogin[0].ToString("X2");
                            login_rfid += BlockDataLogin[1].ToString("X2");
                            login_rfid += BlockDataLogin[2].ToString("X2");
                            login_rfid += BlockDataLogin[3].ToString("X2");
                            login_rfid += BlockDataLogin[4].ToString("X2");
                            login_rfid += BlockDataLogin[5].ToString("X2");
                            login_rfid += BlockDataLogin[6].ToString("X2");
                            login_rfid += BlockDataLogin[7].ToString("X2");
                            login_rfid += BlockDataLogin[8].ToString("X2");
                            login_rfid += BlockDataLogin[9].ToString("X2");
                            login_rfid += BlockDataLogin[10].ToString("X2");
                            login_rfid += BlockDataLogin[11].ToString("X2");
                            login_rfid += BlockDataLogin[12].ToString("X2");
                            login_rfid += BlockDataLogin[13].ToString("X2");
                            login_rfid += BlockDataLogin[14].ToString("X2");
                            login_rfid += BlockDataLogin[15].ToString("X2");
                        }
                        else //Read not successful
                        {
                            if (ReturnCode == 0x4E) //'N'
                                richTextBox2.Text = "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                            else if (ReturnCode == 0x46) //'F'
                                richTextBox2.Text = "Read Failed:" + ReturnCode.ToString("X2");
                            else
                                richTextBox2.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                        }

                        if (sm132.CMD_ReadBlock(BlockPwd, out BlockDataPwd, out ReturnCode))
                        {
                            pwd_rfid = BlockDataPwd[0].ToString("X2");
                            pwd_rfid += BlockDataPwd[1].ToString("X2");
                            pwd_rfid += BlockDataPwd[2].ToString("X2");
                            pwd_rfid += BlockDataPwd[3].ToString("X2");
                            pwd_rfid += BlockDataPwd[4].ToString("X2");
                            pwd_rfid += BlockDataPwd[5].ToString("X2");
                            pwd_rfid += BlockDataPwd[6].ToString("X2");
                            pwd_rfid += BlockDataPwd[7].ToString("X2");
                            pwd_rfid += BlockDataPwd[8].ToString("X2");
                            pwd_rfid += BlockDataPwd[9].ToString("X2");
                            pwd_rfid += BlockDataPwd[10].ToString("X2");
                            pwd_rfid += BlockDataPwd[11].ToString("X2");
                            pwd_rfid += BlockDataPwd[12].ToString("X2");
                            pwd_rfid += BlockDataPwd[13].ToString("X2");
                            pwd_rfid += BlockDataPwd[14].ToString("X2");
                            pwd_rfid += BlockDataPwd[15].ToString("X2");
                            //richTextBox1.Text += HexString2Ascii(pwd_rfid) + "\n";

                            if (string.Compare(textBox1.Text,HexString2Ascii(login_rfid))==0 && string.Compare(textBox2.Text,HexString2Ascii(pwd_rfid))==0)
                            {
                                richTextBox1.Text += "BIENVENUE\n";

                                byte BlockFlouss = 5;
                                long Value = 0;
                                if (sm132.CMD_Authenticate(AuthSource, Key, BlockFlouss, out ReturnCode))
                                {
                                    if (sm132.CMD_ReadValue(BlockFlouss, out Value, out ReturnCode))
                                    {
                                        label8.Visible = true;
                                        textBox3.Visible = true;
                                        groupBox2.Visible = true;
                                        button5.Visible = true;
                                        
                                        button1.Visible = false;
                                        textBox1.Enabled = false;
                                        label2.Visible = false;
                                        textBox2.Text = "";
                                        textBox2.Visible = false;
                                        comboBox1.Enabled = false;
  
                                        textBox3.Text = Value.ToString();
                                    }
                                    else //ReadValue not successful
                                    {
                                        if (ReturnCode == 0x4E) //'N'
                                            richTextBox2.Text = "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                                        else if (ReturnCode == 0x46) //'F'
                                            richTextBox2.Text = "Read Failed. Error Code:" + ReturnCode.ToString("X2");
                                        else if (ReturnCode == 0x49) //'I'
                                            richTextBox2.Text = "Invalid Value Block. Error Code:" + ReturnCode.ToString("X2");
                                        else
                                            richTextBox2.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                                    }
                                }
                            }
                            else richTextBox1.Text += "LOGIN/MDP INCORRECT(S)\n";
                        }
                        else //Read not successful
                        {
                            if (ReturnCode == 0x4E) //'N'
                                richTextBox2.Text = "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                            else if (ReturnCode == 0x46) //'F'
                                richTextBox2.Text = "Read Failed:" + ReturnCode.ToString("X2");
                            else
                                richTextBox2.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");
                        }
                    }
                    else
                    {

                        if (ReturnCode == 0x4E) //'N'
                            richTextBox2.Text += "No Tag or Login failed. Error Code:" + ReturnCode.ToString("X2") + "\n";
                        else if (ReturnCode == 0x55)
                            richTextBox2.Text += "Login failed. Error Code:" + ReturnCode.ToString("X2") + "\n";
                        else if (ReturnCode == 0x45)
                            richTextBox2.Text += "Invalid Key Format. Error Code:" + ReturnCode.ToString("X2") + "\n";
                        else if (ReturnCode == 0)
                            richTextBox2.Text += "Communication Error. Error Code:" + ReturnCode.ToString("X2") + "\n";
                        else
                            richTextBox2.Text += "Unknown Error. Error Code:" + ReturnCode.ToString("X2") + "\n";
                    }

                    //auth end

                }
                else //Select not successful
                {
                    if (ReturnCode == 0x4E) //'N'
                        richTextBox2.Text += "No Tag found. Error Code:" + ReturnCode.ToString("X2") + "\n";
                    else if (ReturnCode == 0x55) //'U'
                        richTextBox2.Text += "RF Field is off. Error Code:" + ReturnCode.ToString("X2") + "\n";
                    else
                        richTextBox2.Text += "Communication Error. Error Code:" + ReturnCode.ToString("X2") + "\n";
                
                }
                //select tag end

                
            }
            else
                richTextBox2.Text += "Port could not be opened\n";  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte BlockNo = 5;
            long IncValue = 0;
            long NewValue = 0;
            byte ReturnCode = 0;

            IncValue = (long)numericUpDown1.Value;

            if (sm132.CMD_IncrementValue(BlockNo, IncValue, out NewValue, out ReturnCode))
            {
                richTextBox1.Text += "Montant crédité: " + NewValue +". Opération au bloc " + BlockNo + "\n";

                textBox3.Text = NewValue.ToString();

            }
            else //Increment Value not successful
            {
                if (ReturnCode == 0x4E) //'N'
                    richTextBox2.Text = "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x46) //'F'
                    richTextBox2.Text = "Read Failed during verification. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x49) //'I'
                    richTextBox2.Text = "Invalid Value Block. Error Code:" + ReturnCode.ToString("X2");
                else
                    richTextBox2.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte BlockNo = 5;
            long DecValue = 0;
            long NewValue = 0;
            byte ReturnCode = 0;

            DecValue = (long)numericUpDown2.Value;

            if (sm132.CMD_DecrementValue(BlockNo, DecValue, out NewValue, out ReturnCode))
            {
                richTextBox1.Text += "Montant débité: " + NewValue + ". Opération au bloc " + BlockNo + "\n";

                textBox3.Text = NewValue.ToString();

            }
            else //Increment Value not successful
            {
                if (ReturnCode == 0x4E) //'N'
                    richTextBox2.Text = "No Tag found. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x46) //'F'
                    richTextBox2.Text = "Read Failed during verification. Error Code:" + ReturnCode.ToString("X2");
                else if (ReturnCode == 0x49) //'I'
                    richTextBox2.Text = "Invalid Value Block. Error Code:" + ReturnCode.ToString("X2");
                else
                    richTextBox2.Text = "Communication Error. Error Code:" + ReturnCode.ToString("X2");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sm132.ClosePort();

            label8.Visible = false;
            textBox3.Visible = false;
            groupBox2.Visible = false;
            button5.Visible = false;

            button1.Visible = true;
            textBox1.Enabled = true;
            label2.Visible = true;
            textBox2.Visible = true;
            comboBox1.Enabled = true;

            richTextBox1.Text += "Déconnexion\n";
        }
    }
}
