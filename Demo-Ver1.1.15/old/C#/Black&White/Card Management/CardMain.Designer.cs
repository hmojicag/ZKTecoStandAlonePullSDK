namespace Card
{
    partial class CardMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Timer rtTimer;
            this.lbRTShow = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lvCard = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.btnGetStrCardNumber = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.chbEnabled = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSetStrCardNumber = new System.Windows.Forms.Button();
            this.label89 = new System.Windows.Forms.Label();
            this.cbPrivilege = new System.Windows.Forms.ComboBox();
            this.txtCardnumber = new System.Windows.Forms.TextBox();
            this.Privilege = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnGetHIDEventCardNumAsStr = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbUserID = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTmpToWrite = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btnWriteCard = new System.Windows.Forms.Button();
            this.btnEmptyCard = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMachineSN = new System.Windows.Forms.TextBox();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRsConnect = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rbVUSB = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMachineSN2 = new System.Windows.Forms.TextBox();
            this.btnUSBConnect = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.rbUSB = new System.Windows.Forms.RadioButton();
            this.lblState = new System.Windows.Forms.Label();
            this.UserIDTimer = new System.Windows.Forms.Timer(this.components);
            rtTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtTimer
            // 
            rtTimer.Interval = 800;
            rtTimer.Tick += new System.EventHandler(this.rtTimer_Tick);
            // 
            // lbRTShow
            // 
            this.lbRTShow.FormattingEnabled = true;
            this.lbRTShow.ItemHeight = 12;
            this.lbRTShow.Location = new System.Drawing.Point(8, 16);
            this.lbRTShow.Name = "lbRTShow";
            this.lbRTShow.Size = new System.Drawing.Size(445, 124);
            this.lbRTShow.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbRTShow);
            this.groupBox3.Location = new System.Drawing.Point(7, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(461, 147);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Show the RealTime Events Related with the Card";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Location = new System.Drawing.Point(479, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 353);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download or Upload Card Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(371, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "Please make sure your device has an optional ID card module. ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lvCard);
            this.groupBox4.Controls.Add(this.btnGetStrCardNumber);
            this.groupBox4.Location = new System.Drawing.Point(6, 52);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(479, 178);
            this.groupBox4.TabIndex = 43;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Download the Card Number(A property of user information)";
            // 
            // lvCard
            // 
            this.lvCard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvCard.GridLines = true;
            this.lvCard.Location = new System.Drawing.Point(6, 16);
            this.lvCard.Name = "lvCard";
            this.lvCard.Size = new System.Drawing.Size(467, 119);
            this.lvCard.TabIndex = 45;
            this.lvCard.UseCompatibleStateImageBehavior = false;
            this.lvCard.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "UserID";
            this.columnHeader1.Width = 54;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 41;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Cardnumber";
            this.columnHeader3.Width = 78;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Privilege";
            this.columnHeader4.Width = 92;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Password";
            this.columnHeader5.Width = 76;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Enabled";
            this.columnHeader6.Width = 84;
            // 
            // btnGetStrCardNumber
            // 
            this.btnGetStrCardNumber.Location = new System.Drawing.Point(181, 147);
            this.btnGetStrCardNumber.Name = "btnGetStrCardNumber";
            this.btnGetStrCardNumber.Size = new System.Drawing.Size(117, 23);
            this.btnGetStrCardNumber.TabIndex = 1;
            this.btnGetStrCardNumber.Text = "GetStrCardNumber";
            this.btnGetStrCardNumber.UseVisualStyleBackColor = true;
            this.btnGetStrCardNumber.Click += new System.EventHandler(this.btnGetStrCardNumber_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtUserID);
            this.groupBox5.Controls.Add(this.txtName);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.chbEnabled);
            this.groupBox5.Controls.Add(this.txtPassword);
            this.groupBox5.Controls.Add(this.btnSetStrCardNumber);
            this.groupBox5.Controls.Add(this.label89);
            this.groupBox5.Controls.Add(this.cbPrivilege);
            this.groupBox5.Controls.Add(this.txtCardnumber);
            this.groupBox5.Controls.Add(this.Privilege);
            this.groupBox5.Controls.Add(this.label55);
            this.groupBox5.Controls.Add(this.label90);
            this.groupBox5.Location = new System.Drawing.Point(6, 236);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(479, 111);
            this.groupBox5.TabIndex = 44;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Upload the Card Number(part of users information)";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(90, 15);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(69, 21);
            this.txtUserID.TabIndex = 56;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(238, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(76, 21);
            this.txtName.TabIndex = 57;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(40, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 18);
            this.label16.TabIndex = 63;
            this.label16.Text = "User ID";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(208, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 17);
            this.label15.TabIndex = 64;
            this.label15.Text = "Name";
            // 
            // chbEnabled
            // 
            this.chbEnabled.AutoSize = true;
            this.chbEnabled.Location = new System.Drawing.Point(383, 50);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Size = new System.Drawing.Size(15, 14);
            this.chbEnabled.TabIndex = 69;
            this.chbEnabled.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(383, 15);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(67, 21);
            this.txtPassword.TabIndex = 58;
            // 
            // btnSetStrCardNumber
            // 
            this.btnSetStrCardNumber.Location = new System.Drawing.Point(181, 80);
            this.btnSetStrCardNumber.Name = "btnSetStrCardNumber";
            this.btnSetStrCardNumber.Size = new System.Drawing.Size(117, 23);
            this.btnSetStrCardNumber.TabIndex = 0;
            this.btnSetStrCardNumber.Text = "SetStrCardNumber";
            this.btnSetStrCardNumber.UseVisualStyleBackColor = true;
            this.btnSetStrCardNumber.Click += new System.EventHandler(this.btnSetStrCardNumber_Click);
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(332, 51);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(59, 12);
            this.label89.TabIndex = 67;
            this.label89.Text = "Enabled  ";
            // 
            // cbPrivilege
            // 
            this.cbPrivilege.FormattingEnabled = true;
            this.cbPrivilege.Location = new System.Drawing.Point(90, 47);
            this.cbPrivilege.Name = "cbPrivilege";
            this.cbPrivilege.Size = new System.Drawing.Size(69, 20);
            this.cbPrivilege.TabIndex = 59;
            // 
            // txtCardnumber
            // 
            this.txtCardnumber.Location = new System.Drawing.Point(238, 47);
            this.txtCardnumber.Name = "txtCardnumber";
            this.txtCardnumber.Size = new System.Drawing.Size(76, 21);
            this.txtCardnumber.TabIndex = 61;
            // 
            // Privilege
            // 
            this.Privilege.Location = new System.Drawing.Point(30, 50);
            this.Privilege.Name = "Privilege";
            this.Privilege.Size = new System.Drawing.Size(61, 19);
            this.Privilege.TabIndex = 65;
            this.Privilege.Text = "Privilege";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(174, 51);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(65, 12);
            this.label55.TabIndex = 66;
            this.label55.Text = "CardNumber";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(327, 20);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(53, 12);
            this.label90.TabIndex = 68;
            this.label90.Text = "Password";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnGetHIDEventCardNumAsStr);
            this.groupBox6.Location = new System.Drawing.Point(479, 398);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(491, 64);
            this.groupBox6.TabIndex = 45;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Get the Latest HID Cardnumber after you have swiped the card";
            // 
            // btnGetHIDEventCardNumAsStr
            // 
            this.btnGetHIDEventCardNumAsStr.Location = new System.Drawing.Point(164, 25);
            this.btnGetHIDEventCardNumAsStr.Name = "btnGetHIDEventCardNumAsStr";
            this.btnGetHIDEventCardNumAsStr.Size = new System.Drawing.Size(163, 23);
            this.btnGetHIDEventCardNumAsStr.TabIndex = 42;
            this.btnGetHIDEventCardNumAsStr.Text = "GetHIDEventCardNumAsStr";
            this.btnGetHIDEventCardNumAsStr.UseVisualStyleBackColor = true;
            this.btnGetHIDEventCardNumAsStr.Click += new System.EventHandler(this.btnGetHIDEventCardNumAsStr_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbUserID);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.cbTmpToWrite);
            this.groupBox7.Controls.Add(this.label28);
            this.groupBox7.Controls.Add(this.btnWriteCard);
            this.groupBox7.Controls.Add(this.btnEmptyCard);
            this.groupBox7.Controls.Add(this.label31);
            this.groupBox7.Location = new System.Drawing.Point(6, 345);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(462, 117);
            this.groupBox7.TabIndex = 41;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Write data into Mifare Card or Empty It";
            // 
            // cbUserID
            // 
            this.cbUserID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserID.FormattingEnabled = true;
            this.cbUserID.Location = new System.Drawing.Point(55, 37);
            this.cbUserID.Name = "cbUserID";
            this.cbUserID.Size = new System.Drawing.Size(87, 20);
            this.cbUserID.TabIndex = 49;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Crimson;
            this.label8.Location = new System.Drawing.Point(11, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(389, 12);
            this.label8.TabIndex = 48;
            this.label8.Text = "Please make sure your device has an optional mifare card module.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "Count";
            // 
            // cbTmpToWrite
            // 
            this.cbTmpToWrite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTmpToWrite.FormattingEnabled = true;
            this.cbTmpToWrite.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbTmpToWrite.Location = new System.Drawing.Point(55, 64);
            this.cbTmpToWrite.Name = "cbTmpToWrite";
            this.cbTmpToWrite.Size = new System.Drawing.Size(54, 20);
            this.cbTmpToWrite.TabIndex = 32;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(11, 40);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 12);
            this.label28.TabIndex = 15;
            this.label28.Text = "UserID";
            // 
            // btnWriteCard
            // 
            this.btnWriteCard.Location = new System.Drawing.Point(130, 86);
            this.btnWriteCard.Name = "btnWriteCard";
            this.btnWriteCard.Size = new System.Drawing.Size(75, 23);
            this.btnWriteCard.TabIndex = 23;
            this.btnWriteCard.Text = "WriteCard";
            this.btnWriteCard.UseVisualStyleBackColor = true;
            this.btnWriteCard.Click += new System.EventHandler(this.btnWriteCard_Click);
            // 
            // btnEmptyCard
            // 
            this.btnEmptyCard.Location = new System.Drawing.Point(230, 86);
            this.btnEmptyCard.Name = "btnEmptyCard";
            this.btnEmptyCard.Size = new System.Drawing.Size(75, 23);
            this.btnEmptyCard.TabIndex = 24;
            this.btnEmptyCard.Text = "EmptyCard";
            this.btnEmptyCard.UseVisualStyleBackColor = true;
            this.btnEmptyCard.Click += new System.EventHandler(this.btnEmptyCard_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.ForeColor = System.Drawing.Color.Crimson;
            this.label31.Location = new System.Drawing.Point(108, 67);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(353, 12);
            this.label31.TabIndex = 26;
            this.label31.Text = "(Count of Fingerprint Templates to Write into Mifare Card)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Card.Properties.Resources.top;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(979, 30);
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Controls.Add(this.lblState);
            this.groupBox2.Location = new System.Drawing.Point(8, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 146);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Communication with Device";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(449, 102);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.txtIP);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnConnect);
            this.tabPage1.Controls.Add(this.txtPort);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.ForeColor = System.Drawing.Color.DarkBlue;
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(441, 77);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TCP/IP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(118, 14);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(95, 21);
            this.txtIP.TabIndex = 6;
            this.txtIP.Text = "192.168.1.201";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(183, 47);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(300, 14);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(53, 21);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "4370";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Controls.Add(this.btnRsConnect);
            this.tabPage2.ForeColor = System.Drawing.Color.DarkBlue;
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(441, 77);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RS232/485";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbBaudRate);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.txtMachineSN);
            this.groupBox8.Controls.Add(this.cbPort);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Location = new System.Drawing.Point(17, -1);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(406, 40);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "115200"});
            this.cbBaudRate.Location = new System.Drawing.Point(187, 14);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(65, 20);
            this.cbBaudRate.TabIndex = 6;
            this.cbBaudRate.Text = "115200";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Port";
            // 
            // txtMachineSN
            // 
            this.txtMachineSN.Location = new System.Drawing.Point(337, 14);
            this.txtMachineSN.Name = "txtMachineSN";
            this.txtMachineSN.Size = new System.Drawing.Size(56, 21);
            this.txtMachineSN.TabIndex = 10;
            this.txtMachineSN.Text = "1";
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.cbPort.Location = new System.Drawing.Point(52, 14);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(56, 20);
            this.cbPort.TabIndex = 5;
            this.cbPort.Text = "COM1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "MachineSN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "BaudRate";
            // 
            // btnRsConnect
            // 
            this.btnRsConnect.Location = new System.Drawing.Point(183, 47);
            this.btnRsConnect.Name = "btnRsConnect";
            this.btnRsConnect.Size = new System.Drawing.Size(75, 23);
            this.btnRsConnect.TabIndex = 11;
            this.btnRsConnect.Text = "Connect";
            this.btnRsConnect.UseVisualStyleBackColor = true;
            this.btnRsConnect.Click += new System.EventHandler(this.btnRsConnect_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.groupBox9);
            this.tabPage3.Controls.Add(this.btnUSBConnect);
            this.tabPage3.Controls.Add(this.groupBox10);
            this.tabPage3.ForeColor = System.Drawing.Color.DarkBlue;
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(441, 77);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "USBClient";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rbVUSB);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Controls.Add(this.txtMachineSN2);
            this.groupBox9.Location = new System.Drawing.Point(23, -1);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(235, 38);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            // 
            // rbVUSB
            // 
            this.rbVUSB.AutoSize = true;
            this.rbVUSB.Checked = true;
            this.rbVUSB.Location = new System.Drawing.Point(8, 15);
            this.rbVUSB.Name = "rbVUSB";
            this.rbVUSB.Size = new System.Drawing.Size(125, 16);
            this.rbVUSB.TabIndex = 3;
            this.rbVUSB.TabStop = true;
            this.rbVUSB.Text = "Virtual USBClient";
            this.rbVUSB.UseVisualStyleBackColor = true;
            this.rbVUSB.Click += new System.EventHandler(this.rbVUSB_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(138, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "MachineSN";
            // 
            // txtMachineSN2
            // 
            this.txtMachineSN2.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMachineSN2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMachineSN2.Location = new System.Drawing.Point(199, 12);
            this.txtMachineSN2.Name = "txtMachineSN2";
            this.txtMachineSN2.Size = new System.Drawing.Size(27, 21);
            this.txtMachineSN2.TabIndex = 4;
            this.txtMachineSN2.Text = "1";
            // 
            // btnUSBConnect
            // 
            this.btnUSBConnect.Location = new System.Drawing.Point(183, 47);
            this.btnUSBConnect.Name = "btnUSBConnect";
            this.btnUSBConnect.Size = new System.Drawing.Size(75, 23);
            this.btnUSBConnect.TabIndex = 0;
            this.btnUSBConnect.Text = "Connect";
            this.btnUSBConnect.UseVisualStyleBackColor = true;
            this.btnUSBConnect.Click += new System.EventHandler(this.btnUSBConnect_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.rbUSB);
            this.groupBox10.Location = new System.Drawing.Point(24, 37);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(89, 31);
            this.groupBox10.TabIndex = 6;
            this.groupBox10.TabStop = false;
            // 
            // rbUSB
            // 
            this.rbUSB.AutoSize = true;
            this.rbUSB.Location = new System.Drawing.Point(7, 11);
            this.rbUSB.Name = "rbUSB";
            this.rbUSB.Size = new System.Drawing.Size(77, 16);
            this.rbUSB.TabIndex = 2;
            this.rbUSB.Text = "USBClient";
            this.rbUSB.UseVisualStyleBackColor = true;
            this.rbUSB.Click += new System.EventHandler(this.rbUSB_CheckedChanged);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.Color.Crimson;
            this.lblState.Location = new System.Drawing.Point(150, 125);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(161, 12);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "Current State:Disconnected";
            // 
            // UserIDTimer
            // 
            this.UserIDTimer.Enabled = true;
            this.UserIDTimer.Tick += new System.EventHandler(this.UserIDTimer_Tick);
            // 
            // CardMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(978, 479);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CardMain";
            this.Text = "Card Management";
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbRTShow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnWriteCard;
        private System.Windows.Forms.Button btnEmptyCard;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btnGetHIDEventCardNumAsStr;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGetStrCardNumber;
        private System.Windows.Forms.Button btnSetStrCardNumber;
        private System.Windows.Forms.ListView lvCard;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chbEnabled;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.ComboBox cbPrivilege;
        private System.Windows.Forms.TextBox txtCardnumber;
        private System.Windows.Forms.Label Privilege;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbTmpToWrite;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMachineSN;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRsConnect;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rbVUSB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMachineSN2;
        private System.Windows.Forms.Button btnUSBConnect;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RadioButton rbUSB;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Timer UserIDTimer;
        private System.Windows.Forms.ComboBox cbUserID;
    }
}

