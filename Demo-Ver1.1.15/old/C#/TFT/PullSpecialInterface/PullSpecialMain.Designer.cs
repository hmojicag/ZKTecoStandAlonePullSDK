namespace PullSpecial
{
    partial class PullSpecialMain
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRsConnect = new System.Windows.Forms.Button();
            this.txtMachineSN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label29 = new System.Windows.Forms.Label();
            this.txtMachineSN2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnUSBConnect = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.device_data = new System.Windows.Forms.TabPage();
            this.txtgetdata = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnclefil = new System.Windows.Forms.Button();
            this.chkdatopt = new System.Windows.Forms.CheckBox();
            this.txtfilval = new System.Windows.Forms.TextBox();
            this.txtfil = new System.Windows.Forms.TextBox();
            this.btnfil = new System.Windows.Forms.Button();
            this.cmbfil = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btngetdat = new System.Windows.Forms.Button();
            this.btnsetdat = new System.Windows.Forms.Button();
            this.txtdevdata = new System.Windows.Forms.TextBox();
            this.cmbdevtable = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.device_file = new System.Windows.Forms.TabPage();
            this.btntarfile = new System.Windows.Forms.Button();
            this.txttarfile = new System.Windows.Forms.TextBox();
            this.btnsetdevfile = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.btngetdevfile = new System.Windows.Forms.Button();
            this.txtgetdevfile = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.device_data.SuspendLayout();
            this.device_file.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PullSpecial.Properties.Resources.top550;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(692, 30);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Controls.Add(this.lblState);
            this.groupBox2.Location = new System.Drawing.Point(8, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(682, 146);
            this.groupBox2.TabIndex = 66;
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
            this.tabControl1.Size = new System.Drawing.Size(659, 102);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtPort);
            this.tabPage1.Controls.Add(this.txtIP);
            this.tabPage1.Controls.Add(this.btnConnect);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.ForeColor = System.Drawing.Color.DarkBlue;
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(651, 77);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TCP/IP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(300, 11);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(53, 21);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "4370";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(118, 11);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(95, 21);
            this.txtIP.TabIndex = 6;
            this.txtIP.Text = "192.168.1.201";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(181, 42);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(78, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.btnRsConnect);
            this.tabPage2.Controls.Add(this.txtMachineSN);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cbBaudRate);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cbPort);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.ForeColor = System.Drawing.Color.DarkBlue;
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(651, 77);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RS232/485";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRsConnect
            // 
            this.btnRsConnect.Location = new System.Drawing.Point(183, 43);
            this.btnRsConnect.Name = "btnRsConnect";
            this.btnRsConnect.Size = new System.Drawing.Size(75, 23);
            this.btnRsConnect.TabIndex = 11;
            this.btnRsConnect.Text = "Connect";
            this.btnRsConnect.UseVisualStyleBackColor = true;
            this.btnRsConnect.Click += new System.EventHandler(this.btnRsConnect_Click);
            // 
            // txtMachineSN
            // 
            this.txtMachineSN.Location = new System.Drawing.Point(356, 10);
            this.txtMachineSN.Name = "txtMachineSN";
            this.txtMachineSN.Size = new System.Drawing.Size(56, 21);
            this.txtMachineSN.TabIndex = 10;
            this.txtMachineSN.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "MachineSN";
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
            this.cbBaudRate.Location = new System.Drawing.Point(206, 10);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(65, 20);
            this.cbBaudRate.TabIndex = 6;
            this.cbBaudRate.Text = "115200";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "BaudRate";
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
            this.cbPort.Location = new System.Drawing.Point(71, 10);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(56, 20);
            this.cbPort.TabIndex = 5;
            this.cbPort.Text = "COM1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Port";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.label29);
            this.tabPage3.Controls.Add(this.txtMachineSN2);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.btnUSBConnect);
            this.tabPage3.ForeColor = System.Drawing.Color.DarkBlue;
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(651, 77);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "USBClient";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(233, 18);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(59, 12);
            this.label29.TabIndex = 10;
            this.label29.Text = "MachineSN";
            // 
            // txtMachineSN2
            // 
            this.txtMachineSN2.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMachineSN2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMachineSN2.Location = new System.Drawing.Point(294, 13);
            this.txtMachineSN2.Name = "txtMachineSN2";
            this.txtMachineSN2.Size = new System.Drawing.Size(27, 21);
            this.txtMachineSN2.TabIndex = 9;
            this.txtMachineSN2.Text = "1";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Crimson;
            this.label18.Location = new System.Drawing.Point(120, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 12);
            this.label18.TabIndex = 8;
            this.label18.Text = "Virtual USBClient";
            // 
            // btnUSBConnect
            // 
            this.btnUSBConnect.Location = new System.Drawing.Point(183, 42);
            this.btnUSBConnect.Name = "btnUSBConnect";
            this.btnUSBConnect.Size = new System.Drawing.Size(75, 23);
            this.btnUSBConnect.TabIndex = 0;
            this.btnUSBConnect.Text = "Connect";
            this.btnUSBConnect.UseVisualStyleBackColor = true;
            this.btnUSBConnect.Click += new System.EventHandler(this.btnUSBConnect_Click);
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
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl2);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(7, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 342);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download or Clear Attendance Records";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.device_data);
            this.tabControl2.Controls.Add(this.device_file);
            this.tabControl2.Location = new System.Drawing.Point(14, 17);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(655, 309);
            this.tabControl2.TabIndex = 2;
            // 
            // device_data
            // 
            this.device_data.Controls.Add(this.txtgetdata);
            this.device_data.Controls.Add(this.label17);
            this.device_data.Controls.Add(this.btnclefil);
            this.device_data.Controls.Add(this.chkdatopt);
            this.device_data.Controls.Add(this.txtfilval);
            this.device_data.Controls.Add(this.txtfil);
            this.device_data.Controls.Add(this.btnfil);
            this.device_data.Controls.Add(this.cmbfil);
            this.device_data.Controls.Add(this.label19);
            this.device_data.Controls.Add(this.label20);
            this.device_data.Controls.Add(this.label21);
            this.device_data.Controls.Add(this.btngetdat);
            this.device_data.Controls.Add(this.btnsetdat);
            this.device_data.Controls.Add(this.txtdevdata);
            this.device_data.Controls.Add(this.cmbdevtable);
            this.device_data.Controls.Add(this.label22);
            this.device_data.Location = new System.Drawing.Point(4, 21);
            this.device_data.Name = "device_data";
            this.device_data.Padding = new System.Windows.Forms.Padding(3);
            this.device_data.Size = new System.Drawing.Size(647, 284);
            this.device_data.TabIndex = 2;
            this.device_data.Text = "Devie Data";
            this.device_data.UseVisualStyleBackColor = true;
            // 
            // txtgetdata
            // 
            this.txtgetdata.AcceptsReturn = true;
            this.txtgetdata.AcceptsTab = true;
            this.txtgetdata.Location = new System.Drawing.Point(345, 38);
            this.txtgetdata.Multiline = true;
            this.txtgetdata.Name = "txtgetdata";
            this.txtgetdata.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtgetdata.Size = new System.Drawing.Size(284, 203);
            this.txtgetdata.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(343, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(179, 12);
            this.label17.TabIndex = 16;
            this.label17.Text = "The result of GetDeviceData :";
            // 
            // btnclefil
            // 
            this.btnclefil.Location = new System.Drawing.Point(278, 149);
            this.btnclefil.Name = "btnclefil";
            this.btnclefil.Size = new System.Drawing.Size(44, 23);
            this.btnclefil.TabIndex = 15;
            this.btnclefil.Text = "Clear";
            this.btnclefil.UseVisualStyleBackColor = true;
            this.btnclefil.Click += new System.EventHandler(this.btnclefil_Click);
            // 
            // chkdatopt
            // 
            this.chkdatopt.AutoSize = true;
            this.chkdatopt.Location = new System.Drawing.Point(82, 248);
            this.chkdatopt.Name = "chkdatopt";
            this.chkdatopt.Size = new System.Drawing.Size(78, 16);
            this.chkdatopt.TabIndex = 14;
            this.chkdatopt.Text = "NewRecord";
            this.chkdatopt.UseVisualStyleBackColor = true;
            // 
            // txtfilval
            // 
            this.txtfilval.Location = new System.Drawing.Point(176, 151);
            this.txtfilval.Name = "txtfilval";
            this.txtfilval.Size = new System.Drawing.Size(56, 21);
            this.txtfilval.TabIndex = 13;
            // 
            // txtfil
            // 
            this.txtfil.Location = new System.Drawing.Point(40, 176);
            this.txtfil.Multiline = true;
            this.txtfil.Name = "txtfil";
            this.txtfil.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtfil.Size = new System.Drawing.Size(287, 65);
            this.txtfil.TabIndex = 11;
            // 
            // btnfil
            // 
            this.btnfil.Location = new System.Drawing.Point(236, 149);
            this.btnfil.Name = "btnfil";
            this.btnfil.Size = new System.Drawing.Size(40, 23);
            this.btnfil.TabIndex = 10;
            this.btnfil.Text = "Add";
            this.btnfil.UseVisualStyleBackColor = true;
            this.btnfil.Click += new System.EventHandler(this.btnfil_Click);
            // 
            // cmbfil
            // 
            this.cmbfil.FormattingEnabled = true;
            this.cmbfil.Location = new System.Drawing.Point(67, 151);
            this.cmbfil.Name = "cmbfil";
            this.cmbfil.Size = new System.Drawing.Size(103, 20);
            this.cmbfil.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 248);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 8;
            this.label19.Text = "Options:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 155);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 12);
            this.label20.TabIndex = 7;
            this.label20.Text = "Add Filter:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(5, 35);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 12);
            this.label21.TabIndex = 6;
            this.label21.Text = "Data:";
            // 
            // btngetdat
            // 
            this.btngetdat.Location = new System.Drawing.Point(321, 248);
            this.btngetdat.Name = "btngetdat";
            this.btngetdat.Size = new System.Drawing.Size(75, 23);
            this.btngetdat.TabIndex = 5;
            this.btngetdat.Text = "Get";
            this.btngetdat.UseVisualStyleBackColor = true;
            this.btngetdat.Click += new System.EventHandler(this.btngetdat_Click);
            // 
            // btnsetdat
            // 
            this.btnsetdat.Location = new System.Drawing.Point(402, 248);
            this.btnsetdat.Name = "btnsetdat";
            this.btnsetdat.Size = new System.Drawing.Size(75, 23);
            this.btnsetdat.TabIndex = 4;
            this.btnsetdat.Text = "Set";
            this.btnsetdat.UseVisualStyleBackColor = true;
            this.btnsetdat.Click += new System.EventHandler(this.btnsetdat_Click);
            // 
            // txtdevdata
            // 
            this.txtdevdata.AcceptsReturn = true;
            this.txtdevdata.AcceptsTab = true;
            this.txtdevdata.Location = new System.Drawing.Point(40, 38);
            this.txtdevdata.Multiline = true;
            this.txtdevdata.Name = "txtdevdata";
            this.txtdevdata.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtdevdata.Size = new System.Drawing.Size(287, 105);
            this.txtdevdata.TabIndex = 2;
            // 
            // cmbdevtable
            // 
            this.cmbdevtable.FormattingEnabled = true;
            this.cmbdevtable.Items.AddRange(new object[] {
            "user",
            "userauthorize",
            "holiday",
            "timezone",
            "transaction",
            "firstcard",
            "multimcard",
            "inoutfun",
            "templatev10",
            "-----------------",
            "user",
            "transaction",
            "templatev10",
            "fptemplate09",
            "workcode",
            "sms",
            "usersms",
            "funclist",
            "keyfunc",
            "statekey",
            "statelist",
            "statetimezone",
            "realtimelog",
            "accgroup",
            "accholiday",
            "accunlockcomb",
            "acctimezone",
            "HID_FORMAT",
            "oplogs"});
            this.cmbdevtable.Location = new System.Drawing.Point(87, 12);
            this.cmbdevtable.Name = "cmbdevtable";
            this.cmbdevtable.Size = new System.Drawing.Size(121, 20);
            this.cmbdevtable.TabIndex = 1;
            this.cmbdevtable.DropDownClosed += new System.EventHandler(this.cmbdevtable_DropDownClosed);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 15);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 12);
            this.label22.TabIndex = 0;
            this.label22.Text = "Table Name:";
            // 
            // device_file
            // 
            this.device_file.Controls.Add(this.btntarfile);
            this.device_file.Controls.Add(this.txttarfile);
            this.device_file.Controls.Add(this.btnsetdevfile);
            this.device_file.Controls.Add(this.label26);
            this.device_file.Controls.Add(this.btngetdevfile);
            this.device_file.Controls.Add(this.txtgetdevfile);
            this.device_file.Controls.Add(this.label27);
            this.device_file.Location = new System.Drawing.Point(4, 21);
            this.device_file.Name = "device_file";
            this.device_file.Padding = new System.Windows.Forms.Padding(3);
            this.device_file.Size = new System.Drawing.Size(647, 284);
            this.device_file.TabIndex = 5;
            this.device_file.Text = "Device File";
            this.device_file.UseVisualStyleBackColor = true;
            // 
            // btntarfile
            // 
            this.btntarfile.Location = new System.Drawing.Point(277, 159);
            this.btntarfile.Name = "btntarfile";
            this.btntarfile.Size = new System.Drawing.Size(119, 23);
            this.btntarfile.TabIndex = 6;
            this.btntarfile.Text = "Target File";
            this.btntarfile.UseVisualStyleBackColor = true;
            // 
            // txttarfile
            // 
            this.txttarfile.Location = new System.Drawing.Point(162, 161);
            this.txttarfile.Name = "txttarfile";
            this.txttarfile.Size = new System.Drawing.Size(100, 21);
            this.txttarfile.TabIndex = 5;
            // 
            // btnsetdevfile
            // 
            this.btnsetdevfile.Location = new System.Drawing.Point(277, 192);
            this.btnsetdevfile.Name = "btnsetdevfile";
            this.btnsetdevfile.Size = new System.Drawing.Size(119, 23);
            this.btnsetdevfile.TabIndex = 4;
            this.btnsetdevfile.Text = "SetDeviceFileData";
            this.btnsetdevfile.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(41, 136);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(221, 12);
            this.label26.TabIndex = 3;
            this.label26.Text = "Please select a filepath to save it:";
            // 
            // btngetdevfile
            // 
            this.btngetdevfile.Location = new System.Drawing.Point(277, 63);
            this.btngetdevfile.Name = "btngetdevfile";
            this.btngetdevfile.Size = new System.Drawing.Size(119, 23);
            this.btngetdevfile.TabIndex = 2;
            this.btngetdevfile.Text = "GetDeviceFileData";
            this.btngetdevfile.UseVisualStyleBackColor = true;
            // 
            // txtgetdevfile
            // 
            this.txtgetdevfile.Location = new System.Drawing.Point(162, 65);
            this.txtgetdevfile.Name = "txtgetdevfile";
            this.txtgetdevfile.Size = new System.Drawing.Size(100, 21);
            this.txtgetdevfile.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(35, 37);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(227, 12);
            this.label27.TabIndex = 0;
            this.label27.Text = "Please input a file name from device:";
            // 
            // PullSpecialMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(698, 532);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PullSpecialMain";
            this.Text = "PullSpecial";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.device_data.ResumeLayout(false);
            this.device_data.PerformLayout();
            this.device_file.ResumeLayout(false);
            this.device_file.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRsConnect;
        private System.Windows.Forms.TextBox txtMachineSN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnUSBConnect;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtMachineSN2;
        private System.Windows.Forms.Label label18;
       
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage device_data;
        private System.Windows.Forms.TextBox txtgetdata;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnclefil;
        private System.Windows.Forms.CheckBox chkdatopt;
        private System.Windows.Forms.TextBox txtfilval;
        private System.Windows.Forms.TextBox txtfil;
        private System.Windows.Forms.Button btnfil;
        private System.Windows.Forms.ComboBox cmbfil;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btngetdat;
        private System.Windows.Forms.Button btnsetdat;
        private System.Windows.Forms.TextBox txtdevdata;
        private System.Windows.Forms.ComboBox cmbdevtable;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage device_file;
        private System.Windows.Forms.Button btntarfile;
        private System.Windows.Forms.TextBox txttarfile;
        private System.Windows.Forms.Button btnsetdevfile;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btngetdevfile;
        private System.Windows.Forms.TextBox txtgetdevfile;
        private System.Windows.Forms.Label label27;
    }
}

