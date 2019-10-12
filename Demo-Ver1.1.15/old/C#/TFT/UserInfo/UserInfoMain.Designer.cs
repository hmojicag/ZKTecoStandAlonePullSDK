namespace UserInfo
{
    partial class UserInfoMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lvDownload = new System.Windows.Forms.ListView();
            this.ch1 = new System.Windows.Forms.ColumnHeader();
            this.ch2 = new System.Windows.Forms.ColumnHeader();
            this.ch3 = new System.Windows.Forms.ColumnHeader();
            this.ch4 = new System.Windows.Forms.ColumnHeader();
            this.ch5 = new System.Windows.Forms.ColumnHeader();
            this.ch6 = new System.Windows.Forms.ColumnHeader();
            this.ch7 = new System.Windows.Forms.ColumnHeader();
            this.ch8 = new System.Windows.Forms.ColumnHeader();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpload9 = new System.Windows.Forms.Button();
            this.btnDownloadTmp = new System.Windows.Forms.Button();
            this.btnBatchUpdate = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cbUserIDDE = new System.Windows.Forms.ComboBox();
            this.btnDeleteEnrollData = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.cbBackupDE = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSSR_DelUserTmpExt = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbFingerIndex = new System.Windows.Forms.ComboBox();
            this.cbUserIDTmp = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClearAdministrators = new System.Windows.Forms.Button();
            this.btnClearDataTmps = new System.Windows.Forms.Button();
            this.btnClearDataUserInfo = new System.Windows.Forms.Button();
            this.UserIDTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnEnableUser = new System.Windows.Forms.Button();
            this.cbEnable = new System.Windows.Forms.ComboBox();
            this.cbEnableUserID = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UserInfo.Properties.Resources.top;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(981, 30);
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Controls.Add(this.lblState);
            this.groupBox2.Location = new System.Drawing.Point(4, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 146);
            this.groupBox2.TabIndex = 82;
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
            this.tabPage1.Size = new System.Drawing.Size(441, 77);
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
            this.tabPage2.Size = new System.Drawing.Size(441, 77);
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
            this.tabPage3.Size = new System.Drawing.Size(441, 77);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "USBClient";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(233, 17);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(59, 12);
            this.label29.TabIndex = 10;
            this.label29.Text = "MachineSN";
            // 
            // txtMachineSN2
            // 
            this.txtMachineSN2.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMachineSN2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMachineSN2.Location = new System.Drawing.Point(294, 12);
            this.txtMachineSN2.Name = "txtMachineSN2";
            this.txtMachineSN2.Size = new System.Drawing.Size(27, 21);
            this.txtMachineSN2.TabIndex = 9;
            this.txtMachineSN2.Text = "1";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Crimson;
            this.label18.Location = new System.Drawing.Point(120, 17);
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
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lvDownload);
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Location = new System.Drawing.Point(472, 35);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(502, 425);
            this.groupBox6.TabIndex = 81;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Download or Upload Fingerprint Templates";
            // 
            // lvDownload
            // 
            this.lvDownload.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch1,
            this.ch2,
            this.ch3,
            this.ch4,
            this.ch5,
            this.ch6,
            this.ch7,
            this.ch8});
            this.lvDownload.GridLines = true;
            this.lvDownload.Location = new System.Drawing.Point(12, 20);
            this.lvDownload.Name = "lvDownload";
            this.lvDownload.Size = new System.Drawing.Size(480, 294);
            this.lvDownload.TabIndex = 0;
            this.lvDownload.UseCompatibleStateImageBehavior = false;
            this.lvDownload.View = System.Windows.Forms.View.Details;
            // 
            // ch1
            // 
            this.ch1.Text = "UserID";
            this.ch1.Width = 54;
            // 
            // ch2
            // 
            this.ch2.Text = "Name";
            this.ch2.Width = 41;
            // 
            // ch3
            // 
            this.ch3.Text = "FingerIndex";
            this.ch3.Width = 52;
            // 
            // ch4
            // 
            this.ch4.Text = "tmpData";
            this.ch4.Width = 72;
            // 
            // ch5
            // 
            this.ch5.Text = "Privilege";
            this.ch5.Width = 77;
            // 
            // ch6
            // 
            this.ch6.Text = "Password";
            this.ch6.Width = 40;
            // 
            // ch7
            // 
            this.ch7.Text = "Ennabled";
            this.ch7.Width = 81;
            // 
            // ch8
            // 
            this.ch8.Text = "Flag";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnUpload9);
            this.groupBox4.Controls.Add(this.btnDownloadTmp);
            this.groupBox4.Controls.Add(this.btnBatchUpdate);
            this.groupBox4.Location = new System.Drawing.Point(15, 316);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(477, 103);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fingerprint Templates of 9.0&&10.0 Arithmetic";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Crimson;
            this.label10.Location = new System.Drawing.Point(149, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(239, 12);
            this.label10.TabIndex = 76;
            this.label10.Text = "Upload Fingerprint Templates one by one";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Crimson;
            this.label8.Location = new System.Drawing.Point(148, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(245, 12);
            this.label8.TabIndex = 75;
            this.label8.Text = "Upload Fingerprint Templates in batches.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(113, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 12);
            this.label3.TabIndex = 74;
            this.label3.Text = "Download Fingerprint Templates one by one.";
            // 
            // btnUpload9
            // 
            this.btnUpload9.Location = new System.Drawing.Point(7, 72);
            this.btnUpload9.Name = "btnUpload9";
            this.btnUpload9.Size = new System.Drawing.Size(134, 23);
            this.btnUpload9.TabIndex = 73;
            this.btnUpload9.Text = "UploadFPTmp(common)";
            this.btnUpload9.UseVisualStyleBackColor = true;
            this.btnUpload9.Click += new System.EventHandler(this.btnUploadTmp_Click);
            // 
            // btnDownloadTmp
            // 
            this.btnDownloadTmp.Location = new System.Drawing.Point(7, 20);
            this.btnDownloadTmp.Name = "btnDownloadTmp";
            this.btnDownloadTmp.Size = new System.Drawing.Size(94, 23);
            this.btnDownloadTmp.TabIndex = 2;
            this.btnDownloadTmp.Text = "DownloadFPTmp";
            this.btnDownloadTmp.UseVisualStyleBackColor = true;
            this.btnDownloadTmp.Click += new System.EventHandler(this.btnDownloadTmp_Click);
            // 
            // btnBatchUpdate
            // 
            this.btnBatchUpdate.Location = new System.Drawing.Point(7, 46);
            this.btnBatchUpdate.Name = "btnBatchUpdate";
            this.btnBatchUpdate.Size = new System.Drawing.Size(134, 23);
            this.btnBatchUpdate.TabIndex = 5;
            this.btnBatchUpdate.Text = "UploadFPTmp(batch)";
            this.btnBatchUpdate.UseVisualStyleBackColor = true;
            this.btnBatchUpdate.Click += new System.EventHandler(this.btnBatchUpdate_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox11);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Location = new System.Drawing.Point(4, 180);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(461, 329);
            this.groupBox5.TabIndex = 80;
            this.groupBox5.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.cbUserIDDE);
            this.groupBox7.Controls.Add(this.btnDeleteEnrollData);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.cbBackupDE);
            this.groupBox7.Location = new System.Drawing.Point(7, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(444, 88);
            this.groupBox7.TabIndex = 78;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Delete Enrolled Data";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Crimson;
            this.label14.Location = new System.Drawing.Point(9, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(287, 12);
            this.label14.TabIndex = 76;
            this.label14.Text = "Delete enrolled data according to bakcupnumber.";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(9, 56);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 12);
            this.label25.TabIndex = 18;
            this.label25.Text = "UserID";
            // 
            // cbUserIDDE
            // 
            this.cbUserIDDE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserIDDE.FormattingEnabled = true;
            this.cbUserIDDE.Location = new System.Drawing.Point(58, 52);
            this.cbUserIDDE.Name = "cbUserIDDE";
            this.cbUserIDDE.Size = new System.Drawing.Size(61, 20);
            this.cbUserIDDE.TabIndex = 16;
            // 
            // btnDeleteEnrollData
            // 
            this.btnDeleteEnrollData.Location = new System.Drawing.Point(279, 51);
            this.btnDeleteEnrollData.Name = "btnDeleteEnrollData";
            this.btnDeleteEnrollData.Size = new System.Drawing.Size(141, 23);
            this.btnDeleteEnrollData.TabIndex = 15;
            this.btnDeleteEnrollData.Text = "SSR_DeleteEnrollData";
            this.btnDeleteEnrollData.UseVisualStyleBackColor = true;
            this.btnDeleteEnrollData.Click += new System.EventHandler(this.btnDeleteEnrollData_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(127, 56);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 12);
            this.label24.TabIndex = 19;
            this.label24.Text = "BackupNumber";
            // 
            // cbBackupDE
            // 
            this.cbBackupDE.FormattingEnabled = true;
            this.cbBackupDE.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbBackupDE.Location = new System.Drawing.Point(208, 52);
            this.cbBackupDE.Name = "cbBackupDE";
            this.cbBackupDE.Size = new System.Drawing.Size(48, 20);
            this.cbBackupDE.TabIndex = 17;
            this.cbBackupDE.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSSR_DelUserTmpExt);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbFingerIndex);
            this.groupBox1.Controls.Add(this.cbUserIDTmp);
            this.groupBox1.Location = new System.Drawing.Point(7, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 80);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delete User\'s Fingerprint Templates";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "UserID";
            // 
            // btnSSR_DelUserTmpExt
            // 
            this.btnSSR_DelUserTmpExt.Location = new System.Drawing.Point(279, 33);
            this.btnSSR_DelUserTmpExt.Name = "btnSSR_DelUserTmpExt";
            this.btnSSR_DelUserTmpExt.Size = new System.Drawing.Size(115, 23);
            this.btnSSR_DelUserTmpExt.TabIndex = 33;
            this.btnSSR_DelUserTmpExt.Text = "SSR_DelUserTmpExt";
            this.btnSSR_DelUserTmpExt.UseVisualStyleBackColor = true;
            this.btnSSR_DelUserTmpExt.Click += new System.EventHandler(this.btnSSR_DelUserTmpExt_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(124, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "FingerIndex";
            // 
            // cbFingerIndex
            // 
            this.cbFingerIndex.FormattingEnabled = true;
            this.cbFingerIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "13"});
            this.cbFingerIndex.Location = new System.Drawing.Point(208, 34);
            this.cbFingerIndex.Name = "cbFingerIndex";
            this.cbFingerIndex.Size = new System.Drawing.Size(48, 20);
            this.cbFingerIndex.TabIndex = 29;
            // 
            // cbUserIDTmp
            // 
            this.cbUserIDTmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserIDTmp.Location = new System.Drawing.Point(58, 34);
            this.cbUserIDTmp.Name = "cbUserIDTmp";
            this.cbUserIDTmp.Size = new System.Drawing.Size(61, 20);
            this.cbUserIDTmp.TabIndex = 21;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClearAdministrators);
            this.groupBox3.Controls.Add(this.btnClearDataTmps);
            this.groupBox3.Controls.Add(this.btnClearDataUserInfo);
            this.groupBox3.Location = new System.Drawing.Point(8, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(443, 64);
            this.groupBox3.TabIndex = 65;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Clear Templates/UsersInfo/Administrator Privilege";
            // 
            // btnClearAdministrators
            // 
            this.btnClearAdministrators.Location = new System.Drawing.Point(279, 24);
            this.btnClearAdministrators.Name = "btnClearAdministrators";
            this.btnClearAdministrators.Size = new System.Drawing.Size(131, 23);
            this.btnClearAdministrators.TabIndex = 72;
            this.btnClearAdministrators.Text = "ClearAdministrators";
            this.btnClearAdministrators.UseVisualStyleBackColor = true;
            this.btnClearAdministrators.Click += new System.EventHandler(this.btnClearAdministrators_Click);
            // 
            // btnClearDataTmps
            // 
            this.btnClearDataTmps.Location = new System.Drawing.Point(10, 24);
            this.btnClearDataTmps.Name = "btnClearDataTmps";
            this.btnClearDataTmps.Size = new System.Drawing.Size(99, 23);
            this.btnClearDataTmps.TabIndex = 64;
            this.btnClearDataTmps.Text = "ClearTmpsData";
            this.btnClearDataTmps.UseVisualStyleBackColor = true;
            this.btnClearDataTmps.Click += new System.EventHandler(this.btnClearDataTmps_Click);
            // 
            // btnClearDataUserInfo
            // 
            this.btnClearDataUserInfo.Location = new System.Drawing.Point(135, 24);
            this.btnClearDataUserInfo.Name = "btnClearDataUserInfo";
            this.btnClearDataUserInfo.Size = new System.Drawing.Size(121, 23);
            this.btnClearDataUserInfo.TabIndex = 63;
            this.btnClearDataUserInfo.Text = "ClearUserInfoData";
            this.btnClearDataUserInfo.UseVisualStyleBackColor = true;
            this.btnClearDataUserInfo.Click += new System.EventHandler(this.btnClearDataUserInfo_Click);
            // 
            // UserIDTimer
            // 
            this.UserIDTimer.Enabled = true;
            this.UserIDTimer.Tick += new System.EventHandler(this.UserIDTimer_Tick);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label13);
            this.groupBox11.Controls.Add(this.label15);
            this.groupBox11.Controls.Add(this.btnEnableUser);
            this.groupBox11.Controls.Add(this.cbEnable);
            this.groupBox11.Controls.Add(this.cbEnableUserID);
            this.groupBox11.Location = new System.Drawing.Point(7, 199);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(444, 60);
            this.groupBox11.TabIndex = 79;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Set Whether a User\'s Enabled";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 16;
            this.label13.Text = "UserID";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(184, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 23;
            this.label15.Text = "Flag";
            // 
            // btnEnableUser
            // 
            this.btnEnableUser.Location = new System.Drawing.Point(287, 18);
            this.btnEnableUser.Name = "btnEnableUser";
            this.btnEnableUser.Size = new System.Drawing.Size(107, 23);
            this.btnEnableUser.TabIndex = 28;
            this.btnEnableUser.Text = "SSR_EnableUser";
            this.btnEnableUser.UseVisualStyleBackColor = true;
            this.btnEnableUser.Click += new System.EventHandler(this.btnEnableUser_Click);
            // 
            // cbEnable
            // 
            this.cbEnable.FormattingEnabled = true;
            this.cbEnable.Items.AddRange(new object[] {
            "true",
            "false"});
            this.cbEnable.Location = new System.Drawing.Point(220, 19);
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.Size = new System.Drawing.Size(48, 20);
            this.cbEnable.TabIndex = 29;
            this.cbEnable.Text = "true";
            // 
            // cbEnableUserID
            // 
            this.cbEnableUserID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEnableUserID.Location = new System.Drawing.Point(75, 19);
            this.cbEnableUserID.Name = "cbEnableUserID";
            this.cbEnableUserID.Size = new System.Drawing.Size(61, 20);
            this.cbEnableUserID.TabIndex = 21;
            // 
            // UserInfoMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(979, 521);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UserInfoMain";
            this.Text = "UserInfo";
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
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
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
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtMachineSN2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnUSBConnect;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView lvDownload;
        private System.Windows.Forms.ColumnHeader ch1;
        private System.Windows.Forms.ColumnHeader ch2;
        private System.Windows.Forms.ColumnHeader ch3;
        private System.Windows.Forms.ColumnHeader ch4;
        private System.Windows.Forms.ColumnHeader ch5;
        private System.Windows.Forms.ColumnHeader ch6;
        private System.Windows.Forms.ColumnHeader ch7;
        private System.Windows.Forms.ColumnHeader ch8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpload9;
        private System.Windows.Forms.Button btnDownloadTmp;
        private System.Windows.Forms.Button btnBatchUpdate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cbUserIDDE;
        private System.Windows.Forms.Button btnDeleteEnrollData;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cbBackupDE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSSR_DelUserTmpExt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbFingerIndex;
        private System.Windows.Forms.ComboBox cbUserIDTmp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClearAdministrators;
        private System.Windows.Forms.Button btnClearDataTmps;
        private System.Windows.Forms.Button btnClearDataUserInfo;
        private System.Windows.Forms.Timer UserIDTimer;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnEnableUser;
        private System.Windows.Forms.ComboBox cbEnable;
        private System.Windows.Forms.ComboBox cbEnableUserID;
    }
}

