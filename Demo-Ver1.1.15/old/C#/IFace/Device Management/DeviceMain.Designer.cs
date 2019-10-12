namespace Device
{
    partial class DeviceMain
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
            this.lblState = new System.Windows.Forms.Label();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl6 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.btnGetPlatform = new System.Windows.Forms.Button();
            this.btnGetSerialNumber = new System.Windows.Forms.Button();
            this.btnGetCardFun = new System.Windows.Forms.Button();
            this.btnGetDeviceIP = new System.Windows.Forms.Button();
            this.btnQueryState = new System.Windows.Forms.Button();
            this.btnGetVendor = new System.Windows.Forms.Button();
            this.txtShow = new System.Windows.Forms.TextBox();
            this.btnGetFirmwareVersion = new System.Windows.Forms.Button();
            this.btnGetProductCode = new System.Windows.Forms.Button();
            this.btnGetDeviceMAC = new System.Windows.Forms.Button();
            this.btnGetSysOption = new System.Windows.Forms.Button();
            this.btnGetSDKVersion = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbSetDeviceInfo = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.txtGetDeviceStatus = new System.Windows.Forms.TextBox();
            this.btnGetDeviceStatus = new System.Windows.Forms.Button();
            this.cbInfo2 = new System.Windows.Forms.ComboBox();
            this.txtGetDeviceInfo = new System.Windows.Forms.TextBox();
            this.cbInfo1 = new System.Windows.Forms.ComboBox();
            this.btnSetDeviceInfo = new System.Windows.Forms.Button();
            this.btnGetDeviceInfo = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.btnGetDeviceTime = new System.Windows.Forms.Button();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.btnSetDeviceTime = new System.Windows.Forms.Button();
            this.cbHour = new System.Windows.Forms.ComboBox();
            this.cbSecond = new System.Windows.Forms.ComboBox();
            this.cbDay = new System.Windows.Forms.ComboBox();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.txtGetDeviceTime = new System.Windows.Forms.TextBox();
            this.cbMinute = new System.Windows.Forms.ComboBox();
            this.btnSetDeviceTime2 = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.cbIndex = new System.Windows.Forms.ComboBox();
            this.btnPlayVoiceByIndex = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.btnPlayVoice = new System.Windows.Forms.Button();
            this.cbPosition = new System.Windows.Forms.ComboBox();
            this.cbLength = new System.Windows.Forms.ComboBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.label33 = new System.Windows.Forms.Label();
            this.btnPowerOffDevice = new System.Windows.Forms.Button();
            this.btnRestartDevice = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Controls.Add(this.lblState);
            this.groupBox2.Location = new System.Drawing.Point(5, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 146);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Communication with Device";
            // 
            // tabControl6
            // 
            this.tabControl6.Controls.Add(this.tabPage3);
            this.tabControl6.Controls.Add(this.tabPage5);
            this.tabControl6.Controls.Add(this.tabPage6);
            this.tabControl6.Controls.Add(this.tabPage7);
            this.tabControl6.Controls.Add(this.tabPage8);
            this.tabControl6.Location = new System.Drawing.Point(6, 14);
            this.tabControl6.Name = "tabControl6";
            this.tabControl6.SelectedIndex = 0;
            this.tabControl6.Size = new System.Drawing.Size(452, 185);
            this.tabControl6.TabIndex = 72;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.btnGetPlatform);
            this.tabPage3.Controls.Add(this.btnGetSerialNumber);
            this.tabPage3.Controls.Add(this.btnGetCardFun);
            this.tabPage3.Controls.Add(this.btnGetDeviceIP);
            this.tabPage3.Controls.Add(this.btnQueryState);
            this.tabPage3.Controls.Add(this.btnGetVendor);
            this.tabPage3.Controls.Add(this.txtShow);
            this.tabPage3.Controls.Add(this.btnGetFirmwareVersion);
            this.tabPage3.Controls.Add(this.btnGetProductCode);
            this.tabPage3.Controls.Add(this.btnGetDeviceMAC);
            this.tabPage3.Controls.Add(this.btnGetSysOption);
            this.tabPage3.Controls.Add(this.btnGetSDKVersion);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(444, 160);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "GetOptions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(15, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 12);
            this.label11.TabIndex = 73;
            this.label11.Text = "Get the device parameters.";
            // 
            // btnGetPlatform
            // 
            this.btnGetPlatform.Location = new System.Drawing.Point(247, 68);
            this.btnGetPlatform.Name = "btnGetPlatform";
            this.btnGetPlatform.Size = new System.Drawing.Size(92, 23);
            this.btnGetPlatform.TabIndex = 10;
            this.btnGetPlatform.Text = "GetPlatform";
            this.btnGetPlatform.UseVisualStyleBackColor = true;
            this.btnGetPlatform.Click += new System.EventHandler(this.btnGetPlatform_Click);
            // 
            // btnGetSerialNumber
            // 
            this.btnGetSerialNumber.Location = new System.Drawing.Point(14, 67);
            this.btnGetSerialNumber.Name = "btnGetSerialNumber";
            this.btnGetSerialNumber.Size = new System.Drawing.Size(122, 23);
            this.btnGetSerialNumber.TabIndex = 1;
            this.btnGetSerialNumber.Text = "GetSerialNumber";
            this.btnGetSerialNumber.UseVisualStyleBackColor = true;
            this.btnGetSerialNumber.Click += new System.EventHandler(this.btnGetSerialNumber_Click);
            // 
            // btnGetCardFun
            // 
            this.btnGetCardFun.Location = new System.Drawing.Point(346, 68);
            this.btnGetCardFun.Name = "btnGetCardFun";
            this.btnGetCardFun.Size = new System.Drawing.Size(79, 23);
            this.btnGetCardFun.TabIndex = 7;
            this.btnGetCardFun.Text = "GetCardFun";
            this.btnGetCardFun.UseVisualStyleBackColor = true;
            this.btnGetCardFun.Click += new System.EventHandler(this.btnGetCardFun_Click);
            // 
            // btnGetDeviceIP
            // 
            this.btnGetDeviceIP.Location = new System.Drawing.Point(14, 97);
            this.btnGetDeviceIP.Name = "btnGetDeviceIP";
            this.btnGetDeviceIP.Size = new System.Drawing.Size(122, 23);
            this.btnGetDeviceIP.TabIndex = 9;
            this.btnGetDeviceIP.Text = "GetDeviceIP";
            this.btnGetDeviceIP.UseVisualStyleBackColor = true;
            this.btnGetDeviceIP.Click += new System.EventHandler(this.btnGetDeviceIP_Click);
            // 
            // btnQueryState
            // 
            this.btnQueryState.Location = new System.Drawing.Point(247, 97);
            this.btnQueryState.Name = "btnQueryState";
            this.btnQueryState.Size = new System.Drawing.Size(92, 23);
            this.btnQueryState.TabIndex = 8;
            this.btnQueryState.Text = "QueryState";
            this.btnQueryState.UseVisualStyleBackColor = true;
            this.btnQueryState.Click += new System.EventHandler(this.btnQueryState_Click);
            // 
            // btnGetVendor
            // 
            this.btnGetVendor.Location = new System.Drawing.Point(346, 39);
            this.btnGetVendor.Name = "btnGetVendor";
            this.btnGetVendor.Size = new System.Drawing.Size(79, 23);
            this.btnGetVendor.TabIndex = 11;
            this.btnGetVendor.Text = "GetVendor";
            this.btnGetVendor.UseVisualStyleBackColor = true;
            this.btnGetVendor.Click += new System.EventHandler(this.btnGetVendor_Click);
            // 
            // txtShow
            // 
            this.txtShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtShow.ForeColor = System.Drawing.Color.Red;
            this.txtShow.Location = new System.Drawing.Point(14, 126);
            this.txtShow.Name = "txtShow";
            this.txtShow.ReadOnly = true;
            this.txtShow.Size = new System.Drawing.Size(409, 21);
            this.txtShow.TabIndex = 13;
            this.txtShow.Text = "return value";
            this.txtShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGetFirmwareVersion
            // 
            this.btnGetFirmwareVersion.Location = new System.Drawing.Point(14, 39);
            this.btnGetFirmwareVersion.Name = "btnGetFirmwareVersion";
            this.btnGetFirmwareVersion.Size = new System.Drawing.Size(122, 23);
            this.btnGetFirmwareVersion.TabIndex = 4;
            this.btnGetFirmwareVersion.Text = "GetFirmwareVersion";
            this.btnGetFirmwareVersion.UseVisualStyleBackColor = true;
            this.btnGetFirmwareVersion.Click += new System.EventHandler(this.btnGetFirmwareVersion_Click);
            // 
            // btnGetProductCode
            // 
            this.btnGetProductCode.Location = new System.Drawing.Point(142, 68);
            this.btnGetProductCode.Name = "btnGetProductCode";
            this.btnGetProductCode.Size = new System.Drawing.Size(98, 23);
            this.btnGetProductCode.TabIndex = 5;
            this.btnGetProductCode.Text = "GetProductCode";
            this.btnGetProductCode.UseVisualStyleBackColor = true;
            this.btnGetProductCode.Click += new System.EventHandler(this.btnGetProductCode_Click);
            // 
            // btnGetDeviceMAC
            // 
            this.btnGetDeviceMAC.Location = new System.Drawing.Point(247, 39);
            this.btnGetDeviceMAC.Name = "btnGetDeviceMAC";
            this.btnGetDeviceMAC.Size = new System.Drawing.Size(92, 23);
            this.btnGetDeviceMAC.TabIndex = 2;
            this.btnGetDeviceMAC.Text = "GetDeviceMAC";
            this.btnGetDeviceMAC.UseVisualStyleBackColor = true;
            this.btnGetDeviceMAC.Click += new System.EventHandler(this.btnGetDeviceMAC_Click);
            // 
            // btnGetSysOption
            // 
            this.btnGetSysOption.Location = new System.Drawing.Point(142, 39);
            this.btnGetSysOption.Name = "btnGetSysOption";
            this.btnGetSysOption.Size = new System.Drawing.Size(98, 23);
            this.btnGetSysOption.TabIndex = 12;
            this.btnGetSysOption.Text = "GetSysOption";
            this.btnGetSysOption.UseVisualStyleBackColor = true;
            this.btnGetSysOption.Click += new System.EventHandler(this.btnGetSysOption_Click);
            // 
            // btnGetSDKVersion
            // 
            this.btnGetSDKVersion.Location = new System.Drawing.Point(142, 97);
            this.btnGetSDKVersion.Name = "btnGetSDKVersion";
            this.btnGetSDKVersion.Size = new System.Drawing.Size(98, 23);
            this.btnGetSDKVersion.TabIndex = 3;
            this.btnGetSDKVersion.Text = "GetSDKVersion";
            this.btnGetSDKVersion.UseVisualStyleBackColor = true;
            this.btnGetSDKVersion.Click += new System.EventHandler(this.btnGetSDKVersion_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label18);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.cbSetDeviceInfo);
            this.tabPage5.Controls.Add(this.cbStatus);
            this.tabPage5.Controls.Add(this.txtGetDeviceStatus);
            this.tabPage5.Controls.Add(this.btnGetDeviceStatus);
            this.tabPage5.Controls.Add(this.cbInfo2);
            this.tabPage5.Controls.Add(this.txtGetDeviceInfo);
            this.tabPage5.Controls.Add(this.cbInfo1);
            this.tabPage5.Controls.Add(this.btnSetDeviceInfo);
            this.tabPage5.Controls.Add(this.btnGetDeviceInfo);
            this.tabPage5.Location = new System.Drawing.Point(4, 21);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(444, 160);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Status";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(15, 129);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(389, 12);
            this.label18.TabIndex = 76;
            this.label18.Text = "More details for parameters,pls refer to the development manual.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(15, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(221, 12);
            this.label17.TabIndex = 75;
            this.label17.Text = "Get or Set the Status of the device.";
            // 
            // cbSetDeviceInfo
            // 
            this.cbSetDeviceInfo.FormattingEnabled = true;
            this.cbSetDeviceInfo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "500"});
            this.cbSetDeviceInfo.Location = new System.Drawing.Point(235, 93);
            this.cbSetDeviceInfo.Name = "cbSetDeviceInfo";
            this.cbSetDeviceInfo.Size = new System.Drawing.Size(75, 20);
            this.cbSetDeviceInfo.TabIndex = 25;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "1.",
            "2.",
            "3.",
            "4.",
            "5.",
            "6.",
            "7.",
            "8.",
            "9.",
            "10.",
            "11.",
            "12.",
            "21.",
            "22."});
            this.cbStatus.Location = new System.Drawing.Point(9, 37);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(217, 20);
            this.cbStatus.TabIndex = 18;
            this.cbStatus.Text = "Status Type";
            // 
            // txtGetDeviceStatus
            // 
            this.txtGetDeviceStatus.Location = new System.Drawing.Point(346, 37);
            this.txtGetDeviceStatus.Name = "txtGetDeviceStatus";
            this.txtGetDeviceStatus.ReadOnly = true;
            this.txtGetDeviceStatus.Size = new System.Drawing.Size(88, 21);
            this.txtGetDeviceStatus.TabIndex = 20;
            // 
            // btnGetDeviceStatus
            // 
            this.btnGetDeviceStatus.Location = new System.Drawing.Point(234, 37);
            this.btnGetDeviceStatus.Name = "btnGetDeviceStatus";
            this.btnGetDeviceStatus.Size = new System.Drawing.Size(106, 23);
            this.btnGetDeviceStatus.TabIndex = 19;
            this.btnGetDeviceStatus.Text = "GetDeviceStatus";
            this.btnGetDeviceStatus.UseVisualStyleBackColor = true;
            this.btnGetDeviceStatus.Click += new System.EventHandler(this.btnGetDeviceStatus_Click);
            // 
            // cbInfo2
            // 
            this.cbInfo2.FormattingEnabled = true;
            this.cbInfo2.Items.AddRange(new object[] {
            "1.",
            "2.",
            "3.",
            "4.",
            "5.",
            "6.",
            "7.",
            "8.",
            "9.",
            "10.",
            "11.",
            "12.",
            "13.",
            "14..",
            "15.",
            "16.",
            "17.",
            "18..",
            "19.",
            "20."});
            this.cbInfo2.Location = new System.Drawing.Point(9, 93);
            this.cbInfo2.Name = "cbInfo2";
            this.cbInfo2.Size = new System.Drawing.Size(217, 20);
            this.cbInfo2.TabIndex = 24;
            this.cbInfo2.Text = "Info Type";
            // 
            // txtGetDeviceInfo
            // 
            this.txtGetDeviceInfo.Location = new System.Drawing.Point(346, 65);
            this.txtGetDeviceInfo.Name = "txtGetDeviceInfo";
            this.txtGetDeviceInfo.ReadOnly = true;
            this.txtGetDeviceInfo.Size = new System.Drawing.Size(88, 21);
            this.txtGetDeviceInfo.TabIndex = 23;
            // 
            // cbInfo1
            // 
            this.cbInfo1.FormattingEnabled = true;
            this.cbInfo1.Items.AddRange(new object[] {
            "1.",
            "2.",
            "3.",
            "4.",
            "5.",
            "6.",
            "7.",
            "8.",
            "9.",
            "10.",
            "11.",
            "12.",
            "13.",
            "14..",
            "15.",
            "16.",
            "17.",
            "18..",
            "19.",
            "20.",
            "21.",
            "22.",
            "23...",
            "24.",
            "25.",
            "26.",
            "27....",
            "28.",
            "29.",
            "30.",
            "31.",
            "32.",
            "33.",
            "34.",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "66",
            "67",
            "68"});
            this.cbInfo1.Location = new System.Drawing.Point(9, 65);
            this.cbInfo1.Name = "cbInfo1";
            this.cbInfo1.Size = new System.Drawing.Size(217, 20);
            this.cbInfo1.TabIndex = 21;
            this.cbInfo1.Text = "Info Type";
            // 
            // btnSetDeviceInfo
            // 
            this.btnSetDeviceInfo.Location = new System.Drawing.Point(317, 93);
            this.btnSetDeviceInfo.Name = "btnSetDeviceInfo";
            this.btnSetDeviceInfo.Size = new System.Drawing.Size(119, 23);
            this.btnSetDeviceInfo.TabIndex = 26;
            this.btnSetDeviceInfo.Text = "SetDeviceInfo";
            this.btnSetDeviceInfo.UseVisualStyleBackColor = true;
            this.btnSetDeviceInfo.Click += new System.EventHandler(this.btnSetDeviceInfo_Click);
            // 
            // btnGetDeviceInfo
            // 
            this.btnGetDeviceInfo.Location = new System.Drawing.Point(235, 65);
            this.btnGetDeviceInfo.Name = "btnGetDeviceInfo";
            this.btnGetDeviceInfo.Size = new System.Drawing.Size(105, 23);
            this.btnGetDeviceInfo.TabIndex = 22;
            this.btnGetDeviceInfo.Text = "GetDeviceInfo";
            this.btnGetDeviceInfo.UseVisualStyleBackColor = true;
            this.btnGetDeviceInfo.Click += new System.EventHandler(this.btnGetDeviceInfo_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label19);
            this.tabPage6.Controls.Add(this.btnGetDeviceTime);
            this.tabPage6.Controls.Add(this.cbYear);
            this.tabPage6.Controls.Add(this.btnSetDeviceTime);
            this.tabPage6.Controls.Add(this.cbHour);
            this.tabPage6.Controls.Add(this.cbSecond);
            this.tabPage6.Controls.Add(this.cbDay);
            this.tabPage6.Controls.Add(this.cbMonth);
            this.tabPage6.Controls.Add(this.txtGetDeviceTime);
            this.tabPage6.Controls.Add(this.cbMinute);
            this.tabPage6.Controls.Add(this.btnSetDeviceTime2);
            this.tabPage6.Location = new System.Drawing.Point(4, 21);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(444, 160);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "DeviceTime";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(15, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(209, 12);
            this.label19.TabIndex = 75;
            this.label19.Text = "Get or set the time of the device.";
            // 
            // btnGetDeviceTime
            // 
            this.btnGetDeviceTime.Location = new System.Drawing.Point(151, 43);
            this.btnGetDeviceTime.Name = "btnGetDeviceTime";
            this.btnGetDeviceTime.Size = new System.Drawing.Size(95, 23);
            this.btnGetDeviceTime.TabIndex = 1;
            this.btnGetDeviceTime.Text = "GetDeviceTime";
            this.btnGetDeviceTime.UseVisualStyleBackColor = true;
            this.btnGetDeviceTime.Click += new System.EventHandler(this.btnGetDeviceTime_Click);
            // 
            // cbYear
            // 
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Items.AddRange(new object[] {
            "2009",
            "2010",
            "2011",
            "2012"});
            this.cbYear.Location = new System.Drawing.Point(9, 80);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(60, 20);
            this.cbYear.TabIndex = 3;
            this.cbYear.Text = "2009";
            // 
            // btnSetDeviceTime
            // 
            this.btnSetDeviceTime.Location = new System.Drawing.Point(8, 42);
            this.btnSetDeviceTime.Name = "btnSetDeviceTime";
            this.btnSetDeviceTime.Size = new System.Drawing.Size(95, 23);
            this.btnSetDeviceTime.TabIndex = 0;
            this.btnSetDeviceTime.Text = "SetDeviceTime";
            this.btnSetDeviceTime.UseVisualStyleBackColor = true;
            this.btnSetDeviceTime.Click += new System.EventHandler(this.btnSetDeviceTime_Click);
            // 
            // cbHour
            // 
            this.cbHour.FormattingEnabled = true;
            this.cbHour.Items.AddRange(new object[] {
            "1",
            "..",
            "59"});
            this.cbHour.Location = new System.Drawing.Point(175, 81);
            this.cbHour.Name = "cbHour";
            this.cbHour.Size = new System.Drawing.Size(41, 20);
            this.cbHour.TabIndex = 6;
            this.cbHour.Text = "8";
            // 
            // cbSecond
            // 
            this.cbSecond.FormattingEnabled = true;
            this.cbSecond.Items.AddRange(new object[] {
            "1",
            "..",
            "59"});
            this.cbSecond.Location = new System.Drawing.Point(273, 81);
            this.cbSecond.Name = "cbSecond";
            this.cbSecond.Size = new System.Drawing.Size(41, 20);
            this.cbSecond.TabIndex = 8;
            this.cbSecond.Text = "8";
            // 
            // cbDay
            // 
            this.cbDay.FormattingEnabled = true;
            this.cbDay.Items.AddRange(new object[] {
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
            "..",
            "30"});
            this.cbDay.Location = new System.Drawing.Point(126, 80);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new System.Drawing.Size(41, 20);
            this.cbDay.TabIndex = 5;
            this.cbDay.Text = "31";
            // 
            // cbMonth
            // 
            this.cbMonth.DisplayMember = "Month";
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] {
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
            this.cbMonth.Location = new System.Drawing.Point(77, 80);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(41, 20);
            this.cbMonth.TabIndex = 4;
            this.cbMonth.Text = "12";
            // 
            // txtGetDeviceTime
            // 
            this.txtGetDeviceTime.Location = new System.Drawing.Point(277, 42);
            this.txtGetDeviceTime.Name = "txtGetDeviceTime";
            this.txtGetDeviceTime.ReadOnly = true;
            this.txtGetDeviceTime.Size = new System.Drawing.Size(156, 21);
            this.txtGetDeviceTime.TabIndex = 2;
            // 
            // cbMinute
            // 
            this.cbMinute.FormattingEnabled = true;
            this.cbMinute.Items.AddRange(new object[] {
            "1",
            "..",
            "59"});
            this.cbMinute.Location = new System.Drawing.Point(224, 81);
            this.cbMinute.Name = "cbMinute";
            this.cbMinute.Size = new System.Drawing.Size(41, 20);
            this.cbMinute.TabIndex = 7;
            this.cbMinute.Text = "8";
            // 
            // btnSetDeviceTime2
            // 
            this.btnSetDeviceTime2.Location = new System.Drawing.Point(322, 79);
            this.btnSetDeviceTime2.Name = "btnSetDeviceTime2";
            this.btnSetDeviceTime2.Size = new System.Drawing.Size(114, 23);
            this.btnSetDeviceTime2.TabIndex = 9;
            this.btnSetDeviceTime2.Text = "SetDeviceTime2";
            this.btnSetDeviceTime2.UseVisualStyleBackColor = true;
            this.btnSetDeviceTime2.Click += new System.EventHandler(this.btnSetDeviceTime2_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label20);
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Controls.Add(this.label30);
            this.tabPage7.Controls.Add(this.cbIndex);
            this.tabPage7.Controls.Add(this.btnPlayVoiceByIndex);
            this.tabPage7.Controls.Add(this.label29);
            this.tabPage7.Controls.Add(this.btnPlayVoice);
            this.tabPage7.Controls.Add(this.cbPosition);
            this.tabPage7.Controls.Add(this.cbLength);
            this.tabPage7.Location = new System.Drawing.Point(4, 21);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(444, 160);
            this.tabPage7.TabIndex = 5;
            this.tabPage7.Text = "Voice";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(15, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(233, 12);
            this.label20.TabIndex = 76;
            this.label20.Text = "Play a series of wav or play by index.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "Index";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(139, 79);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 12);
            this.label30.TabIndex = 22;
            this.label30.Text = "Length";
            // 
            // cbIndex
            // 
            this.cbIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIndex.FormattingEnabled = true;
            this.cbIndex.Items.AddRange(new object[] {
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
            "11"});
            this.cbIndex.Location = new System.Drawing.Point(80, 41);
            this.cbIndex.Name = "cbIndex";
            this.cbIndex.Size = new System.Drawing.Size(44, 20);
            this.cbIndex.TabIndex = 23;
            // 
            // btnPlayVoiceByIndex
            // 
            this.btnPlayVoiceByIndex.Location = new System.Drawing.Point(141, 40);
            this.btnPlayVoiceByIndex.Name = "btnPlayVoiceByIndex";
            this.btnPlayVoiceByIndex.Size = new System.Drawing.Size(125, 23);
            this.btnPlayVoiceByIndex.TabIndex = 18;
            this.btnPlayVoiceByIndex.Text = "PlayVoiceByIndex";
            this.btnPlayVoiceByIndex.UseVisualStyleBackColor = true;
            this.btnPlayVoiceByIndex.Click += new System.EventHandler(this.btnPlayVoiceByIndex_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(17, 79);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 12);
            this.label29.TabIndex = 21;
            this.label29.Text = "Position";
            // 
            // btnPlayVoice
            // 
            this.btnPlayVoice.Location = new System.Drawing.Point(248, 74);
            this.btnPlayVoice.Name = "btnPlayVoice";
            this.btnPlayVoice.Size = new System.Drawing.Size(75, 23);
            this.btnPlayVoice.TabIndex = 17;
            this.btnPlayVoice.Text = "PlayVoice";
            this.btnPlayVoice.UseVisualStyleBackColor = true;
            this.btnPlayVoice.Click += new System.EventHandler(this.btnPlayVoice_Click);
            // 
            // cbPosition
            // 
            this.cbPosition.FormattingEnabled = true;
            this.cbPosition.Items.AddRange(new object[] {
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
            "11"});
            this.cbPosition.Location = new System.Drawing.Point(78, 76);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(46, 20);
            this.cbPosition.TabIndex = 9;
            // 
            // cbLength
            // 
            this.cbLength.FormattingEnabled = true;
            this.cbLength.Items.AddRange(new object[] {
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
            "11"});
            this.cbLength.Location = new System.Drawing.Point(187, 75);
            this.cbLength.Name = "cbLength";
            this.cbLength.Size = new System.Drawing.Size(46, 20);
            this.cbLength.TabIndex = 19;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.label33);
            this.tabPage8.Controls.Add(this.btnPowerOffDevice);
            this.tabPage8.Controls.Add(this.btnRestartDevice);
            this.tabPage8.Location = new System.Drawing.Point(4, 21);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(444, 160);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "Control";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ForeColor = System.Drawing.Color.Red;
            this.label33.Location = new System.Drawing.Point(15, 13);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(191, 12);
            this.label33.TabIndex = 77;
            this.label33.Text = "Restart or Poweroff the device.";
            // 
            // btnPowerOffDevice
            // 
            this.btnPowerOffDevice.Location = new System.Drawing.Point(182, 40);
            this.btnPowerOffDevice.Name = "btnPowerOffDevice";
            this.btnPowerOffDevice.Size = new System.Drawing.Size(97, 23);
            this.btnPowerOffDevice.TabIndex = 6;
            this.btnPowerOffDevice.Text = "PowerOffDevice";
            this.btnPowerOffDevice.UseVisualStyleBackColor = true;
            this.btnPowerOffDevice.Click += new System.EventHandler(this.btnPowerOffDevice_Click);
            // 
            // btnRestartDevice
            // 
            this.btnRestartDevice.Location = new System.Drawing.Point(16, 40);
            this.btnRestartDevice.Name = "btnRestartDevice";
            this.btnRestartDevice.Size = new System.Drawing.Size(94, 23);
            this.btnRestartDevice.TabIndex = 3;
            this.btnRestartDevice.Text = "RestartDevice";
            this.btnRestartDevice.UseVisualStyleBackColor = true;
            this.btnRestartDevice.Click += new System.EventHandler(this.btnRestartDevice_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl6);
            this.groupBox1.Location = new System.Drawing.Point(5, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 208);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Device.Properties.Resources.top485;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(472, 30);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // DeviceMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(472, 399);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DeviceMain";
            this.Text = "Device Management";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl6.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblState;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnGetPlatform;
        private System.Windows.Forms.Button btnGetSerialNumber;
        private System.Windows.Forms.Button btnGetCardFun;
        private System.Windows.Forms.Button btnGetDeviceIP;
        private System.Windows.Forms.Button btnQueryState;
        private System.Windows.Forms.Button btnGetVendor;
        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.Button btnGetFirmwareVersion;
        private System.Windows.Forms.Button btnGetProductCode;
        private System.Windows.Forms.Button btnGetDeviceMAC;
        private System.Windows.Forms.Button btnGetSysOption;
        private System.Windows.Forms.Button btnGetSDKVersion;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbSetDeviceInfo;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox txtGetDeviceStatus;
        private System.Windows.Forms.Button btnGetDeviceStatus;
        private System.Windows.Forms.ComboBox cbInfo2;
        private System.Windows.Forms.TextBox txtGetDeviceInfo;
        private System.Windows.Forms.ComboBox cbInfo1;
        private System.Windows.Forms.Button btnSetDeviceInfo;
        private System.Windows.Forms.Button btnGetDeviceInfo;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnPowerOffDevice;
        private System.Windows.Forms.Button btnRestartDevice;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnGetDeviceTime;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Button btnSetDeviceTime;
        private System.Windows.Forms.ComboBox cbHour;
        private System.Windows.Forms.ComboBox cbSecond;
        private System.Windows.Forms.ComboBox cbDay;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.TextBox txtGetDeviceTime;
        private System.Windows.Forms.ComboBox cbMinute;
        private System.Windows.Forms.Button btnSetDeviceTime2;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cbIndex;
        private System.Windows.Forms.Button btnPlayVoiceByIndex;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnPlayVoice;
        private System.Windows.Forms.ComboBox cbPosition;
        private System.Windows.Forms.ComboBox cbLength;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

