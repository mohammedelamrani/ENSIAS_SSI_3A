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
    public partial class Form2 : Form
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
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (sm132.OpenPort(comboBox1.Text, 19200))
            {
                button5.Visible = true;
                timer1.Enabled = true;
                //sm_mifare_lib.mifare sm132 = new sm_mifare_lib.mifare();
                //select tag begin
                byte TagType;
                byte[] TagSerial = new byte[4];
                byte ReturnCode = 0;
                if (sm132.CMD_SelectTag(out TagType, out TagSerial, out ReturnCode))
                {//auth begin
                    byte AuthSource = 0xFF;
                    byte BlockNo;
                    byte[] Key = new byte[6];
                    BlockNo = byte.Parse("20");
                    //Mifare Default Key
                    AuthSource = (byte)sm_mifare_lib.ASource.KeyMifareDefault;
                    //Authenticate
                    if (sm132.CMD_Authenticate(AuthSource, Key, BlockNo, out ReturnCode))    
                    {
                        checkedListBox1.SetItemChecked(0,true);
                        MessageBox.Show("Authentification réussit");
                        groupBox1.Enabled = false;
                        groupBox2.Enabled = true;
                    }
                    else
                    {

                        if (ReturnCode == 0x4E) //'N'
                            MessageBox.Show("No Tag or Login failed. Error Code:" + ReturnCode.ToString("X2") + "\n");
                        else if (ReturnCode == 0x55)
                            MessageBox.Show("Login failed. Error Code:" + ReturnCode.ToString("X2") + "\n");
                        else if (ReturnCode == 0x45)
                            MessageBox.Show("Invalid Key Format. Error Code:" + ReturnCode.ToString("X2") + "\n");
                        else if (ReturnCode == 0)
                            MessageBox.Show("Communication Error. Error Code:" + ReturnCode.ToString("X2") + "\n");
                        else
                            MessageBox.Show("Unknown Error. Error Code:" + ReturnCode.ToString("X2") + "\n");
                    }
                    //auth end
                }
                else //Select not successful
                {
                    if (ReturnCode == 0x4E) //'N'
                        MessageBox.Show("No Tag found. Error Code:" + ReturnCode.ToString("X2") + "\n");
                    else if (ReturnCode == 0x55) //'U'
                        MessageBox.Show("RF Field is off. Error Code:" + ReturnCode.ToString("X2") + "\n");
                    else
                        MessageBox.Show("Communication Error. Error Code:" + ReturnCode.ToString("X2") + "\n");

                }
                //select tag end
            }
            else
                MessageBox.Show("Port could not be opened\n");  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port_name in ports)
            {
                comboBox1.Items.Add(port_name);
            }
            comboBox1.SelectedIndex = 0;

            button4.Enabled = false;
            groupBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte ReturnCode = 0;
            byte BlockLogin = 20;
            byte BlockPwd = 21;
            byte[] BlockDataLogin = new byte[16];
            byte[] BlockDataPwd = new byte[16];
            string login_rfid = "";
            string pwd_rfid = "";

            if (sm132.CMD_ReadBlock(BlockLogin, out BlockDataLogin, out ReturnCode))
            {
                login_rfid = BlockDataLogin[0].ToString("X2");
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
                    MessageBox.Show("No Tag found. Error Code:" + ReturnCode.ToString("X2"));
                else if (ReturnCode == 0x46) //'F'
                    MessageBox.Show("Read Failed:" + ReturnCode.ToString("X2"));
                else
                    MessageBox.Show("Communication Error. Error Code:" + ReturnCode.ToString("X2"));
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
            }
            else //Read not successful
            {
                if (ReturnCode == 0x4E) //'N'
                    MessageBox.Show("No Tag found. Error Code:" + ReturnCode.ToString("X2"));
                else if (ReturnCode == 0x46) //'F'
                    MessageBox.Show("Read Failed:" + ReturnCode.ToString("X2"));
                else
                    MessageBox.Show("Communication Error. Error Code:" + ReturnCode.ToString("X2"));
            }
            if (string.Compare(textBox1.Text, HexString2Ascii(login_rfid)) == 0 && string.Compare(textBox2.Text, HexString2Ascii(pwd_rfid)) == 0)
            {
                checkedListBox1.SetItemChecked(1, true);
                MessageBox.Show("Authentification login/mdp réussit");
                groupBox2.Enabled = false;
                groupBox4.Visible = true;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Firmware;
            sm132.CMD_ResetDevice(out Firmware);
            sm132.ClosePort();

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox4.Visible = false;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            button4.Enabled = true;
            button5.Visible = false;
            checkedListBox1.SetItemChecked(0, false);
            checkedListBox1.SetItemChecked(1, false);
        }

        static byte[] StringToByteArray(string str, int length)
        {
            return Encoding.ASCII.GetBytes(str.PadRight(length,'\x00'));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte BlockNo = 21;
            byte ReturnCode = 0;

            if (string.Compare(textBox3.Text, textBox4.Text) == 0)
            {
                byte[] BlockData = new byte[16];
                BlockData = StringToByteArray(textBox3.Text, 16);
                if (sm132.CMD_WriteBlock(BlockNo, BlockData, out ReturnCode))
                {
                    MessageBox.Show("Mot de passe modifié");
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    if (ReturnCode == 0x4E) //'N'
                        MessageBox.Show("No Tag found. Error Code:" + ReturnCode.ToString("X2"));
                    else if (ReturnCode == 0x46) //'F'
                        MessageBox.Show("Write Failed:" + ReturnCode.ToString("X2"));
                    else if (ReturnCode == 0x55) //'U'
                        MessageBox.Show("Read after write Failed:" + ReturnCode.ToString("X2"));
                    else if (ReturnCode == 0x58) //'X'
                        MessageBox.Show("Unable to read after write" + ReturnCode.ToString("X2"));
                    else if (ReturnCode == 0x01) //
                        MessageBox.Show("Writing to Sector Trailer is not allowed with this function" + ReturnCode.ToString("X2"));
                    else
                        MessageBox.Show("Communication Error. Error Code:" + ReturnCode.ToString("X2"));
                }
            }
            else
            {
                MessageBox.Show("Erreur de comparaison des Mots de passe");
            }
        }
    }
}
