namespace MainForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_init = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_closeport = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            this.btn_SeekForTag = new System.Windows.Forms.Button();
            this.btn_auth = new System.Windows.Forms.Button();
            this.rdb_MDefault = new System.Windows.Forms.RadioButton();
            this.rdb_PKey = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_E2promBlockNo = new System.Windows.Forms.ComboBox();
            this.rdb_E2prom = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdb_KeyB = new System.Windows.Forms.RadioButton();
            this.rdb_KeyA = new System.Windows.Forms.RadioButton();
            this.cmb_AuthBlockNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Halt = new System.Windows.Forms.Button();
            this.t_K1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.t_K2 = new System.Windows.Forms.TextBox();
            this.t_K4 = new System.Windows.Forms.TextBox();
            this.t_K3 = new System.Windows.Forms.TextBox();
            this.t_K6 = new System.Windows.Forms.TextBox();
            this.t_K5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_RWBlockNo = new System.Windows.Forms.ComboBox();
            this.btn_Read = new System.Windows.Forms.Button();
            this.t_B6 = new System.Windows.Forms.TextBox();
            this.t_B5 = new System.Windows.Forms.TextBox();
            this.t_B4 = new System.Windows.Forms.TextBox();
            this.t_B3 = new System.Windows.Forms.TextBox();
            this.t_B2 = new System.Windows.Forms.TextBox();
            this.t_B1 = new System.Windows.Forms.TextBox();
            this.t_B12 = new System.Windows.Forms.TextBox();
            this.t_B11 = new System.Windows.Forms.TextBox();
            this.t_B10 = new System.Windows.Forms.TextBox();
            this.t_B9 = new System.Windows.Forms.TextBox();
            this.t_B8 = new System.Windows.Forms.TextBox();
            this.t_B7 = new System.Windows.Forms.TextBox();
            this.t_B16 = new System.Windows.Forms.TextBox();
            this.t_B15 = new System.Windows.Forms.TextBox();
            this.t_B14 = new System.Windows.Forms.TextBox();
            this.t_B13 = new System.Windows.Forms.TextBox();
            this.btn_Write = new System.Windows.Forms.Button();
            this.btn_WriteV = new System.Windows.Forms.Button();
            this.btn_ReadV = new System.Windows.Forms.Button();
            this.t_ReadValue = new System.Windows.Forms.TextBox();
            this.t_WriteValue = new System.Windows.Forms.TextBox();
            this.textBox_S = new System.Windows.Forms.TextBox();
            this.t_IncDec = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_Inc = new System.Windows.Forms.Button();
            this.btn_Dec = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_SwitchOffRF = new System.Windows.Forms.Button();
            this.btn_SwitchOnRF = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_init
            // 
            this.btn_init.Location = new System.Drawing.Point(75, 32);
            this.btn_init.Name = "btn_init";
            this.btn_init.Size = new System.Drawing.Size(115, 21);
            this.btn_init.TabIndex = 0;
            this.btn_init.Text = "Open Port";
            this.btn_init.Click += new System.EventHandler(this.btn_init_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(304, 23);
            this.textBox1.TabIndex = 1;
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(196, 72);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(111, 21);
            this.btn_reset.TabIndex = 2;
            this.btn_reset.Text = "Reset Device";
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(3, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(66, 23);
            this.comboBox1.TabIndex = 3;
            // 
            // btn_closeport
            // 
            this.btn_closeport.Location = new System.Drawing.Point(196, 32);
            this.btn_closeport.Name = "btn_closeport";
            this.btn_closeport.Size = new System.Drawing.Size(111, 20);
            this.btn_closeport.TabIndex = 4;
            this.btn_closeport.Text = "Close Port";
            this.btn_closeport.Click += new System.EventHandler(this.btn_closeport_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(3, 72);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(101, 20);
            this.btn_Select.TabIndex = 6;
            this.btn_Select.Text = "Select Tag";
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_SeekForTag
            // 
            this.btn_SeekForTag.Location = new System.Drawing.Point(3, 98);
            this.btn_SeekForTag.Name = "btn_SeekForTag";
            this.btn_SeekForTag.Size = new System.Drawing.Size(101, 20);
            this.btn_SeekForTag.TabIndex = 7;
            this.btn_SeekForTag.Text = "Seek For Tag";
            this.btn_SeekForTag.Click += new System.EventHandler(this.btn_SeekForTag_Click);
            // 
            // btn_auth
            // 
            this.btn_auth.Location = new System.Drawing.Point(165, 258);
            this.btn_auth.Name = "btn_auth";
            this.btn_auth.Size = new System.Drawing.Size(84, 20);
            this.btn_auth.TabIndex = 8;
            this.btn_auth.Text = "Authenticate";
            this.btn_auth.Click += new System.EventHandler(this.btn_auth_Click);
            // 
            // rdb_MDefault
            // 
            this.rdb_MDefault.Checked = true;
            this.rdb_MDefault.Location = new System.Drawing.Point(3, 3);
            this.rdb_MDefault.Name = "rdb_MDefault";
            this.rdb_MDefault.Size = new System.Drawing.Size(200, 20);
            this.rdb_MDefault.TabIndex = 9;
            this.rdb_MDefault.Text = "Mifare Default (TypeA, 0xFF)";
            this.rdb_MDefault.CheckedChanged += new System.EventHandler(this.rdb_MDefault_CheckedChanged);
            // 
            // rdb_PKey
            // 
            this.rdb_PKey.Location = new System.Drawing.Point(3, 23);
            this.rdb_PKey.Name = "rdb_PKey";
            this.rdb_PKey.Size = new System.Drawing.Size(187, 20);
            this.rdb_PKey.TabIndex = 10;
            this.rdb_PKey.TabStop = false;
            this.rdb_PKey.Text = "Provided Key below";
            this.rdb_PKey.CheckedChanged += new System.EventHandler(this.rdb_PKey_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmb_E2promBlockNo);
            this.panel1.Controls.Add(this.rdb_E2prom);
            this.panel1.Controls.Add(this.rdb_MDefault);
            this.panel1.Controls.Add(this.rdb_PKey);
            this.panel1.Location = new System.Drawing.Point(0, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 62);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(236, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.Text = "(E2prom Block No)";
            // 
            // cmb_E2promBlockNo
            // 
            this.cmb_E2promBlockNo.Enabled = false;
            this.cmb_E2promBlockNo.Items.Add("0");
            this.cmb_E2promBlockNo.Items.Add("1");
            this.cmb_E2promBlockNo.Items.Add("2");
            this.cmb_E2promBlockNo.Items.Add("3");
            this.cmb_E2promBlockNo.Items.Add("4");
            this.cmb_E2promBlockNo.Items.Add("5");
            this.cmb_E2promBlockNo.Items.Add("6");
            this.cmb_E2promBlockNo.Items.Add("7");
            this.cmb_E2promBlockNo.Items.Add("8");
            this.cmb_E2promBlockNo.Items.Add("9");
            this.cmb_E2promBlockNo.Items.Add("10");
            this.cmb_E2promBlockNo.Items.Add("11");
            this.cmb_E2promBlockNo.Items.Add("12");
            this.cmb_E2promBlockNo.Items.Add("13");
            this.cmb_E2promBlockNo.Items.Add("14");
            this.cmb_E2promBlockNo.Items.Add("15");
            this.cmb_E2promBlockNo.Location = new System.Drawing.Point(183, 37);
            this.cmb_E2promBlockNo.Name = "cmb_E2promBlockNo";
            this.cmb_E2promBlockNo.Size = new System.Drawing.Size(49, 23);
            this.cmb_E2promBlockNo.TabIndex = 14;
            // 
            // rdb_E2prom
            // 
            this.rdb_E2prom.Location = new System.Drawing.Point(3, 40);
            this.rdb_E2prom.Name = "rdb_E2prom";
            this.rdb_E2prom.Size = new System.Drawing.Size(200, 20);
            this.rdb_E2prom.TabIndex = 13;
            this.rdb_E2prom.TabStop = false;
            this.rdb_E2prom.Text = "EE2PROM (Internal Source)";
            this.rdb_E2prom.CheckedChanged += new System.EventHandler(this.rdb_E2prom_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdb_KeyB);
            this.panel2.Controls.Add(this.rdb_KeyA);
            this.panel2.Location = new System.Drawing.Point(0, 207);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(97, 47);
            // 
            // rdb_KeyB
            // 
            this.rdb_KeyB.Enabled = false;
            this.rdb_KeyB.Location = new System.Drawing.Point(3, 20);
            this.rdb_KeyB.Name = "rdb_KeyB";
            this.rdb_KeyB.Size = new System.Drawing.Size(85, 20);
            this.rdb_KeyB.TabIndex = 1;
            this.rdb_KeyB.TabStop = false;
            this.rdb_KeyB.Text = "KeyTypeB";
            // 
            // rdb_KeyA
            // 
            this.rdb_KeyA.Checked = true;
            this.rdb_KeyA.Enabled = false;
            this.rdb_KeyA.Location = new System.Drawing.Point(3, 3);
            this.rdb_KeyA.Name = "rdb_KeyA";
            this.rdb_KeyA.Size = new System.Drawing.Size(88, 20);
            this.rdb_KeyA.TabIndex = 0;
            this.rdb_KeyA.Text = "KeyTypeA";
            // 
            // cmb_AuthBlockNo
            // 
            this.cmb_AuthBlockNo.Location = new System.Drawing.Point(110, 254);
            this.cmb_AuthBlockNo.Name = "cmb_AuthBlockNo";
            this.cmb_AuthBlockNo.Size = new System.Drawing.Size(49, 23);
            this.cmb_AuthBlockNo.TabIndex = 15;
            this.cmb_AuthBlockNo.SelectedIndexChanged += new System.EventHandler(this.cmb_AuthBlockNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.Text = "Mifare Block No";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 615);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(359, 17);
            this.label3.Text = "AUTHENTICATION >------------------------------------------------";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(360, 17);
            this.label4.Text = "< AUTHENTICATION------------------------------------------";
            // 
            // btn_Halt
            // 
            this.btn_Halt.Location = new System.Drawing.Point(110, 72);
            this.btn_Halt.Name = "btn_Halt";
            this.btn_Halt.Size = new System.Drawing.Size(72, 20);
            this.btn_Halt.TabIndex = 22;
            this.btn_Halt.Text = "Halt";
            this.btn_Halt.Click += new System.EventHandler(this.btn_Halt_Click);
            // 
            // t_K1
            // 
            this.t_K1.Enabled = false;
            this.t_K1.Location = new System.Drawing.Point(110, 225);
            this.t_K1.MaxLength = 2;
            this.t_K1.Name = "t_K1";
            this.t_K1.Size = new System.Drawing.Size(21, 23);
            this.t_K1.TabIndex = 23;
            this.t_K1.Text = "FF";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(109, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.Text = "Key";
            // 
            // t_K2
            // 
            this.t_K2.Enabled = false;
            this.t_K2.Location = new System.Drawing.Point(132, 225);
            this.t_K2.MaxLength = 2;
            this.t_K2.Name = "t_K2";
            this.t_K2.Size = new System.Drawing.Size(21, 23);
            this.t_K2.TabIndex = 26;
            this.t_K2.Text = "FF";
            // 
            // t_K4
            // 
            this.t_K4.Enabled = false;
            this.t_K4.Location = new System.Drawing.Point(176, 225);
            this.t_K4.MaxLength = 2;
            this.t_K4.Name = "t_K4";
            this.t_K4.Size = new System.Drawing.Size(21, 23);
            this.t_K4.TabIndex = 28;
            this.t_K4.Text = "FF";
            // 
            // t_K3
            // 
            this.t_K3.Enabled = false;
            this.t_K3.Location = new System.Drawing.Point(154, 225);
            this.t_K3.MaxLength = 2;
            this.t_K3.Name = "t_K3";
            this.t_K3.Size = new System.Drawing.Size(21, 23);
            this.t_K3.TabIndex = 27;
            this.t_K3.Text = "FF";
            // 
            // t_K6
            // 
            this.t_K6.Enabled = false;
            this.t_K6.Location = new System.Drawing.Point(220, 225);
            this.t_K6.MaxLength = 2;
            this.t_K6.Name = "t_K6";
            this.t_K6.Size = new System.Drawing.Size(21, 23);
            this.t_K6.TabIndex = 30;
            this.t_K6.Text = "FF";
            // 
            // t_K5
            // 
            this.t_K5.Enabled = false;
            this.t_K5.Location = new System.Drawing.Point(198, 225);
            this.t_K5.MaxLength = 2;
            this.t_K5.Name = "t_K5";
            this.t_K5.Size = new System.Drawing.Size(21, 23);
            this.t_K5.TabIndex = 29;
            this.t_K5.Text = "FF";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(354, 17);
            this.label6.Text = "READ/WRITE OPERATIONS >--------------------------------------";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 539);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(369, 17);
            this.label7.Text = "< READ/WRITE OPERATIONS --------------------------------------";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.Text = "Mifare Block No";
            // 
            // cmb_RWBlockNo
            // 
            this.cmb_RWBlockNo.Location = new System.Drawing.Point(108, 360);
            this.cmb_RWBlockNo.Name = "cmb_RWBlockNo";
            this.cmb_RWBlockNo.Size = new System.Drawing.Size(49, 23);
            this.cmb_RWBlockNo.TabIndex = 37;
            this.cmb_RWBlockNo.SelectedIndexChanged += new System.EventHandler(this.cmb_RWBlockNo_SelectedIndexChanged);
            // 
            // btn_Read
            // 
            this.btn_Read.Location = new System.Drawing.Point(5, 386);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(80, 20);
            this.btn_Read.TabIndex = 38;
            this.btn_Read.Text = "Read Block";
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // t_B6
            // 
            this.t_B6.Location = new System.Drawing.Point(113, 331);
            this.t_B6.MaxLength = 2;
            this.t_B6.Name = "t_B6";
            this.t_B6.Size = new System.Drawing.Size(21, 23);
            this.t_B6.TabIndex = 44;
            this.t_B6.Text = "05";
            // 
            // t_B5
            // 
            this.t_B5.Location = new System.Drawing.Point(91, 331);
            this.t_B5.MaxLength = 2;
            this.t_B5.Name = "t_B5";
            this.t_B5.Size = new System.Drawing.Size(21, 23);
            this.t_B5.TabIndex = 43;
            this.t_B5.Text = "04";
            // 
            // t_B4
            // 
            this.t_B4.Location = new System.Drawing.Point(69, 331);
            this.t_B4.MaxLength = 2;
            this.t_B4.Name = "t_B4";
            this.t_B4.Size = new System.Drawing.Size(21, 23);
            this.t_B4.TabIndex = 42;
            this.t_B4.Text = "03";
            // 
            // t_B3
            // 
            this.t_B3.Location = new System.Drawing.Point(47, 331);
            this.t_B3.MaxLength = 2;
            this.t_B3.Name = "t_B3";
            this.t_B3.Size = new System.Drawing.Size(21, 23);
            this.t_B3.TabIndex = 41;
            this.t_B3.Text = "02";
            // 
            // t_B2
            // 
            this.t_B2.Location = new System.Drawing.Point(25, 331);
            this.t_B2.MaxLength = 2;
            this.t_B2.Name = "t_B2";
            this.t_B2.Size = new System.Drawing.Size(21, 23);
            this.t_B2.TabIndex = 40;
            this.t_B2.Text = "01";
            // 
            // t_B1
            // 
            this.t_B1.Location = new System.Drawing.Point(3, 331);
            this.t_B1.MaxLength = 2;
            this.t_B1.Name = "t_B1";
            this.t_B1.Size = new System.Drawing.Size(21, 23);
            this.t_B1.TabIndex = 39;
            this.t_B1.Text = "00";
            // 
            // t_B12
            // 
            this.t_B12.Location = new System.Drawing.Point(246, 331);
            this.t_B12.MaxLength = 2;
            this.t_B12.Name = "t_B12";
            this.t_B12.Size = new System.Drawing.Size(21, 23);
            this.t_B12.TabIndex = 50;
            this.t_B12.Text = "0B";
            // 
            // t_B11
            // 
            this.t_B11.Location = new System.Drawing.Point(224, 331);
            this.t_B11.MaxLength = 2;
            this.t_B11.Name = "t_B11";
            this.t_B11.Size = new System.Drawing.Size(21, 23);
            this.t_B11.TabIndex = 49;
            this.t_B11.Text = "0A";
            // 
            // t_B10
            // 
            this.t_B10.Location = new System.Drawing.Point(202, 331);
            this.t_B10.MaxLength = 2;
            this.t_B10.Name = "t_B10";
            this.t_B10.Size = new System.Drawing.Size(21, 23);
            this.t_B10.TabIndex = 48;
            this.t_B10.Text = "09";
            // 
            // t_B9
            // 
            this.t_B9.Location = new System.Drawing.Point(180, 331);
            this.t_B9.MaxLength = 2;
            this.t_B9.Name = "t_B9";
            this.t_B9.Size = new System.Drawing.Size(21, 23);
            this.t_B9.TabIndex = 47;
            this.t_B9.Text = "08";
            // 
            // t_B8
            // 
            this.t_B8.Location = new System.Drawing.Point(158, 331);
            this.t_B8.MaxLength = 2;
            this.t_B8.Name = "t_B8";
            this.t_B8.Size = new System.Drawing.Size(21, 23);
            this.t_B8.TabIndex = 46;
            this.t_B8.Text = "07";
            // 
            // t_B7
            // 
            this.t_B7.Location = new System.Drawing.Point(136, 331);
            this.t_B7.MaxLength = 2;
            this.t_B7.Name = "t_B7";
            this.t_B7.Size = new System.Drawing.Size(21, 23);
            this.t_B7.TabIndex = 45;
            this.t_B7.Text = "06";
            // 
            // t_B16
            // 
            this.t_B16.Location = new System.Drawing.Point(334, 331);
            this.t_B16.MaxLength = 2;
            this.t_B16.Name = "t_B16";
            this.t_B16.Size = new System.Drawing.Size(21, 23);
            this.t_B16.TabIndex = 54;
            this.t_B16.Text = "0F";
            // 
            // t_B15
            // 
            this.t_B15.Location = new System.Drawing.Point(312, 331);
            this.t_B15.MaxLength = 2;
            this.t_B15.Name = "t_B15";
            this.t_B15.Size = new System.Drawing.Size(21, 23);
            this.t_B15.TabIndex = 53;
            this.t_B15.Text = "0E";
            // 
            // t_B14
            // 
            this.t_B14.Location = new System.Drawing.Point(290, 331);
            this.t_B14.MaxLength = 2;
            this.t_B14.Name = "t_B14";
            this.t_B14.Size = new System.Drawing.Size(21, 23);
            this.t_B14.TabIndex = 52;
            this.t_B14.Text = "0D";
            // 
            // t_B13
            // 
            this.t_B13.Location = new System.Drawing.Point(268, 331);
            this.t_B13.MaxLength = 2;
            this.t_B13.Name = "t_B13";
            this.t_B13.Size = new System.Drawing.Size(21, 23);
            this.t_B13.TabIndex = 51;
            this.t_B13.Text = "0C";
            // 
            // btn_Write
            // 
            this.btn_Write.Location = new System.Drawing.Point(4, 409);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(80, 20);
            this.btn_Write.TabIndex = 55;
            this.btn_Write.Text = "Write Block";
            this.btn_Write.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // btn_WriteV
            // 
            this.btn_WriteV.Location = new System.Drawing.Point(3, 456);
            this.btn_WriteV.Name = "btn_WriteV";
            this.btn_WriteV.Size = new System.Drawing.Size(80, 20);
            this.btn_WriteV.TabIndex = 56;
            this.btn_WriteV.Text = "Write Value";
            this.btn_WriteV.Click += new System.EventHandler(this.btn_WriteV_Click);
            // 
            // btn_ReadV
            // 
            this.btn_ReadV.Location = new System.Drawing.Point(4, 432);
            this.btn_ReadV.Name = "btn_ReadV";
            this.btn_ReadV.Size = new System.Drawing.Size(80, 20);
            this.btn_ReadV.TabIndex = 57;
            this.btn_ReadV.Text = "Read Value";
            this.btn_ReadV.Click += new System.EventHandler(this.btn_ReadV_Click);
            // 
            // t_ReadValue
            // 
            this.t_ReadValue.Location = new System.Drawing.Point(97, 429);
            this.t_ReadValue.Name = "t_ReadValue";
            this.t_ReadValue.Size = new System.Drawing.Size(62, 23);
            this.t_ReadValue.TabIndex = 68;
            // 
            // t_WriteValue
            // 
            this.t_WriteValue.Location = new System.Drawing.Point(97, 458);
            this.t_WriteValue.Name = "t_WriteValue";
            this.t_WriteValue.Size = new System.Drawing.Size(62, 23);
            this.t_WriteValue.TabIndex = 69;
            // 
            // textBox_S
            // 
            this.textBox_S.Location = new System.Drawing.Point(3, 562);
            this.textBox_S.Name = "textBox_S";
            this.textBox_S.Size = new System.Drawing.Size(304, 23);
            this.textBox_S.TabIndex = 71;
            // 
            // t_IncDec
            // 
            this.t_IncDec.Location = new System.Drawing.Point(97, 487);
            this.t_IncDec.Name = "t_IncDec";
            this.t_IncDec.Size = new System.Drawing.Size(62, 23);
            this.t_IncDec.TabIndex = 82;
            this.t_IncDec.Text = "1";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(5, 490);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 20);
            this.label9.Text = "Inc/Dec Value";
            // 
            // btn_Inc
            // 
            this.btn_Inc.Location = new System.Drawing.Point(9, 516);
            this.btn_Inc.Name = "btn_Inc";
            this.btn_Inc.Size = new System.Drawing.Size(72, 20);
            this.btn_Inc.TabIndex = 84;
            this.btn_Inc.Text = "Inc";
            this.btn_Inc.Click += new System.EventHandler(this.btn_Inc_Click);
            // 
            // btn_Dec
            // 
            this.btn_Dec.Location = new System.Drawing.Point(91, 516);
            this.btn_Dec.Name = "btn_Dec";
            this.btn_Dec.Size = new System.Drawing.Size(72, 20);
            this.btn_Dec.TabIndex = 85;
            this.btn_Dec.Text = "Dec";
            this.btn_Dec.Click += new System.EventHandler(this.btn_Dec_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(167, 471);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 20);
            this.label10.Text = "(As decimal)";
            // 
            // btn_SwitchOffRF
            // 
            this.btn_SwitchOffRF.Location = new System.Drawing.Point(113, 98);
            this.btn_SwitchOffRF.Name = "btn_SwitchOffRF";
            this.btn_SwitchOffRF.Size = new System.Drawing.Size(111, 21);
            this.btn_SwitchOffRF.TabIndex = 97;
            this.btn_SwitchOffRF.Text = "Switch RF Off";
            this.btn_SwitchOffRF.Click += new System.EventHandler(this.btn_SwitchOffRF_Click);
            // 
            // btn_SwitchOnRF
            // 
            this.btn_SwitchOnRF.Location = new System.Drawing.Point(230, 98);
            this.btn_SwitchOnRF.Name = "btn_SwitchOnRF";
            this.btn_SwitchOnRF.Size = new System.Drawing.Size(111, 21);
            this.btn_SwitchOnRF.TabIndex = 98;
            this.btn_SwitchOnRF.Text = "Switch RF On";
            this.btn_SwitchOnRF.Click += new System.EventHandler(this.btn_SwitchOnRF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(371, 615);
            this.Controls.Add(this.btn_SwitchOnRF);
            this.Controls.Add(this.btn_SwitchOffRF);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_Dec);
            this.Controls.Add(this.btn_Inc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.t_IncDec);
            this.Controls.Add(this.textBox_S);
            this.Controls.Add(this.t_WriteValue);
            this.Controls.Add(this.t_ReadValue);
            this.Controls.Add(this.btn_ReadV);
            this.Controls.Add(this.btn_WriteV);
            this.Controls.Add(this.btn_Write);
            this.Controls.Add(this.t_B16);
            this.Controls.Add(this.t_B15);
            this.Controls.Add(this.t_B14);
            this.Controls.Add(this.t_B13);
            this.Controls.Add(this.t_B12);
            this.Controls.Add(this.t_B11);
            this.Controls.Add(this.t_B10);
            this.Controls.Add(this.t_B9);
            this.Controls.Add(this.t_B8);
            this.Controls.Add(this.t_B7);
            this.Controls.Add(this.t_B6);
            this.Controls.Add(this.t_B5);
            this.Controls.Add(this.t_B4);
            this.Controls.Add(this.t_B3);
            this.Controls.Add(this.t_B2);
            this.Controls.Add(this.t_B1);
            this.Controls.Add(this.btn_Read);
            this.Controls.Add(this.cmb_RWBlockNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.t_K6);
            this.Controls.Add(this.t_K5);
            this.Controls.Add(this.t_K4);
            this.Controls.Add(this.t_K3);
            this.Controls.Add(this.t_K2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.t_K1);
            this.Controls.Add(this.btn_Halt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_AuthBlockNo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_auth);
            this.Controls.Add(this.btn_SeekForTag);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.btn_closeport);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_init);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_init;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_closeport;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_SeekForTag;
        private System.Windows.Forms.Button btn_auth;
        private System.Windows.Forms.RadioButton rdb_MDefault;
        private System.Windows.Forms.RadioButton rdb_PKey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdb_E2prom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdb_KeyB;
        private System.Windows.Forms.RadioButton rdb_KeyA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_E2promBlockNo;
        private System.Windows.Forms.ComboBox cmb_AuthBlockNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Halt;
        private System.Windows.Forms.TextBox t_K1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t_K2;
        private System.Windows.Forms.TextBox t_K4;
        private System.Windows.Forms.TextBox t_K3;
        private System.Windows.Forms.TextBox t_K6;
        private System.Windows.Forms.TextBox t_K5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_RWBlockNo;
        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.TextBox t_B6;
        private System.Windows.Forms.TextBox t_B5;
        private System.Windows.Forms.TextBox t_B4;
        private System.Windows.Forms.TextBox t_B3;
        private System.Windows.Forms.TextBox t_B2;
        private System.Windows.Forms.TextBox t_B1;
        private System.Windows.Forms.TextBox t_B12;
        private System.Windows.Forms.TextBox t_B11;
        private System.Windows.Forms.TextBox t_B10;
        private System.Windows.Forms.TextBox t_B9;
        private System.Windows.Forms.TextBox t_B8;
        private System.Windows.Forms.TextBox t_B7;
        private System.Windows.Forms.TextBox t_B16;
        private System.Windows.Forms.TextBox t_B15;
        private System.Windows.Forms.TextBox t_B14;
        private System.Windows.Forms.TextBox t_B13;
        private System.Windows.Forms.Button btn_Write;
        private System.Windows.Forms.Button btn_WriteV;
        private System.Windows.Forms.Button btn_ReadV;
        private System.Windows.Forms.TextBox t_ReadValue;
        private System.Windows.Forms.TextBox t_WriteValue;
        private System.Windows.Forms.TextBox textBox_S;
        private System.Windows.Forms.TextBox t_IncDec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Inc;
        private System.Windows.Forms.Button btn_Dec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_SwitchOffRF;
        private System.Windows.Forms.Button btn_SwitchOnRF;
    }
}

