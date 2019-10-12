<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Device
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.tabPage1 = New System.Windows.Forms.TabPage
        Me.txtIP = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.btnConnect = New System.Windows.Forms.Button
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.tabPage2 = New System.Windows.Forms.TabPage
        Me.groupBox5 = New System.Windows.Forms.GroupBox
        Me.cbBaudRate = New System.Windows.Forms.ComboBox
        Me.label5 = New System.Windows.Forms.Label
        Me.txtMachineSN = New System.Windows.Forms.TextBox
        Me.cbPort = New System.Windows.Forms.ComboBox
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.btnRsConnect = New System.Windows.Forms.Button
        Me.tabPage3 = New System.Windows.Forms.TabPage
        Me.groupBox4 = New System.Windows.Forms.GroupBox
        Me.rbVUSB = New System.Windows.Forms.RadioButton
        Me.label11 = New System.Windows.Forms.Label
        Me.txtMachineSN2 = New System.Windows.Forms.TextBox
        Me.btnUSBConnect = New System.Windows.Forms.Button
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.rbUSB = New System.Windows.Forms.RadioButton
        Me.lblState = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.tabControl6 = New System.Windows.Forms.TabControl
        Me.tabPage4 = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnGetPlatform = New System.Windows.Forms.Button
        Me.btnGetDeviceStrInfo = New System.Windows.Forms.Button
        Me.btnGetSerialNumber = New System.Windows.Forms.Button
        Me.btnGetCardFun = New System.Windows.Forms.Button
        Me.btnGetDeviceIP = New System.Windows.Forms.Button
        Me.btnQueryState = New System.Windows.Forms.Button
        Me.btnGetVendor = New System.Windows.Forms.Button
        Me.txtShow = New System.Windows.Forms.TextBox
        Me.btnGetFirmwareVersion = New System.Windows.Forms.Button
        Me.btnGetProductCode = New System.Windows.Forms.Button
        Me.btnGetDeviceMAC = New System.Windows.Forms.Button
        Me.btnGetSysOption = New System.Windows.Forms.Button
        Me.btnGetSDKVersion = New System.Windows.Forms.Button
        Me.tabPage5 = New System.Windows.Forms.TabPage
        Me.label12 = New System.Windows.Forms.Label
        Me.label13 = New System.Windows.Forms.Label
        Me.btnSetSysOption = New System.Windows.Forms.Button
        Me.btnSetDeviceCommPwd = New System.Windows.Forms.Button
        Me.btnSetDeviceMAC = New System.Windows.Forms.Button
        Me.txtSet = New System.Windows.Forms.TextBox
        Me.btnSetCommPassword = New System.Windows.Forms.Button
        Me.btnSetDeviceIP = New System.Windows.Forms.Button
        Me.tabPage6 = New System.Windows.Forms.TabPage
        Me.label18 = New System.Windows.Forms.Label
        Me.label17 = New System.Windows.Forms.Label
        Me.cbSetDeviceInfo = New System.Windows.Forms.ComboBox
        Me.cbStatus = New System.Windows.Forms.ComboBox
        Me.txtGetDeviceStatus = New System.Windows.Forms.TextBox
        Me.btnGetDeviceStatus = New System.Windows.Forms.Button
        Me.cbInfo2 = New System.Windows.Forms.ComboBox
        Me.txtGetDeviceInfo = New System.Windows.Forms.TextBox
        Me.cbInfo1 = New System.Windows.Forms.ComboBox
        Me.btnSetDeviceInfo = New System.Windows.Forms.Button
        Me.btnGetDeviceInfo = New System.Windows.Forms.Button
        Me.tabPage7 = New System.Windows.Forms.TabPage
        Me.label33 = New System.Windows.Forms.Label
        Me.label32 = New System.Windows.Forms.Label
        Me.btnPowerOffDevice = New System.Windows.Forms.Button
        Me.btnDisableDeviceWithTimeOut = New System.Windows.Forms.Button
        Me.btnRestartDevice = New System.Windows.Forms.Button
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.tabControl4 = New System.Windows.Forms.TabControl
        Me.tabPage8 = New System.Windows.Forms.TabPage
        Me.label19 = New System.Windows.Forms.Label
        Me.btnGetDeviceTime = New System.Windows.Forms.Button
        Me.btnSetDeviceTime = New System.Windows.Forms.Button
        Me.cbSecond = New System.Windows.Forms.ComboBox
        Me.cbMonth = New System.Windows.Forms.ComboBox
        Me.cbMinute = New System.Windows.Forms.ComboBox
        Me.btnSetDeviceTime2 = New System.Windows.Forms.Button
        Me.txtGetDeviceTime = New System.Windows.Forms.TextBox
        Me.cbDay = New System.Windows.Forms.ComboBox
        Me.cbHour = New System.Windows.Forms.ComboBox
        Me.cbYear = New System.Windows.Forms.ComboBox
        Me.tabPage9 = New System.Windows.Forms.TabPage
        Me.label20 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbIndex = New System.Windows.Forms.ComboBox
        Me.label29 = New System.Windows.Forms.Label
        Me.cbPosition = New System.Windows.Forms.ComboBox
        Me.cbLength = New System.Windows.Forms.ComboBox
        Me.btnPlayVoice = New System.Windows.Forms.Button
        Me.btnPlayVoiceByIndex = New System.Windows.Forms.Button
        Me.label30 = New System.Windows.Forms.Label
        Me.tabPage10 = New System.Windows.Forms.TabPage
        Me.label21 = New System.Windows.Forms.Label
        Me.cbRow = New System.Windows.Forms.ComboBox
        Me.cbCol = New System.Windows.Forms.ComboBox
        Me.btnWriteLCD = New System.Windows.Forms.Button
        Me.btnClearLCD = New System.Windows.Forms.Button
        Me.label25 = New System.Windows.Forms.Label
        Me.label27 = New System.Windows.Forms.Label
        Me.label26 = New System.Windows.Forms.Label
        Me.txtText = New System.Windows.Forms.TextBox
        Me.tabPage11 = New System.Windows.Forms.TabPage
        Me.label22 = New System.Windows.Forms.Label
        Me.label37 = New System.Windows.Forms.Label
        Me.label38 = New System.Windows.Forms.Label
        Me.label39 = New System.Windows.Forms.Label
        Me.txtEndTime = New System.Windows.Forms.TextBox
        Me.btnSetDaylight = New System.Windows.Forms.Button
        Me.cbSupport = New System.Windows.Forms.ComboBox
        Me.txtBeginTime = New System.Windows.Forms.TextBox
        Me.btnGetDaylight = New System.Windows.Forms.Button
        Me.tabControl3 = New System.Windows.Forms.TabControl
        Me.tabPage12 = New System.Windows.Forms.TabPage
        Me.label49 = New System.Windows.Forms.Label
        Me.label23 = New System.Windows.Forms.Label
        Me.label48 = New System.Windows.Forms.Label
        Me.btnGetWorkCode = New System.Windows.Forms.Button
        Me.btnSetWorkCode = New System.Windows.Forms.Button
        Me.cbAWorkCode = New System.Windows.Forms.ComboBox
        Me.btnClearWorkCode = New System.Windows.Forms.Button
        Me.btnDeleteWorkCode = New System.Windows.Forms.Button
        Me.cbWorkCodeID = New System.Windows.Forms.ComboBox
        Me.tabPage13 = New System.Windows.Forms.TabPage
        Me.label31 = New System.Windows.Forms.Label
        Me.label24 = New System.Windows.Forms.Label
        Me.txtHoliday = New System.Windows.Forms.TextBox
        Me.btnGetHoliday = New System.Windows.Forms.Button
        Me.btnSetHoliday = New System.Windows.Forms.Button
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.groupBox2.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.tabControl6.SuspendLayout()
        Me.tabPage4.SuspendLayout()
        Me.tabPage5.SuspendLayout()
        Me.tabPage6.SuspendLayout()
        Me.tabPage7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.tabControl4.SuspendLayout()
        Me.tabPage8.SuspendLayout()
        Me.tabPage9.SuspendLayout()
        Me.tabPage10.SuspendLayout()
        Me.tabPage11.SuspendLayout()
        Me.tabControl3.SuspendLayout()
        Me.tabPage12.SuspendLayout()
        Me.tabPage13.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.tabControl1)
        Me.groupBox2.Controls.Add(Me.lblState)
        Me.groupBox2.Location = New System.Drawing.Point(8, 41)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(461, 146)
        Me.groupBox2.TabIndex = 9
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Communication with Device"
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Location = New System.Drawing.Point(6, 20)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(449, 102)
        Me.tabControl1.TabIndex = 7
        '
        'tabPage1
        '
        Me.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tabPage1.Controls.Add(Me.txtIP)
        Me.tabPage1.Controls.Add(Me.label2)
        Me.tabPage1.Controls.Add(Me.btnConnect)
        Me.tabPage1.Controls.Add(Me.txtPort)
        Me.tabPage1.Controls.Add(Me.label1)
        Me.tabPage1.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPage1.ForeColor = System.Drawing.Color.DarkBlue
        Me.tabPage1.Location = New System.Drawing.Point(4, 21)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(441, 77)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "TCP/IP"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(118, 14)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(95, 21)
        Me.txtIP.TabIndex = 6
        Me.txtIP.Text = "192.168.1.201"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(257, 18)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(29, 12)
        Me.label2.TabIndex = 9
        Me.label2.Text = "Port"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(183, 47)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 4
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(300, 14)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(53, 21)
        Me.txtPort.TabIndex = 7
        Me.txtPort.Text = "4370"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(87, 18)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(17, 12)
        Me.label1.TabIndex = 8
        Me.label1.Text = "IP"
        '
        'tabPage2
        '
        Me.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tabPage2.Controls.Add(Me.groupBox5)
        Me.tabPage2.Controls.Add(Me.btnRsConnect)
        Me.tabPage2.ForeColor = System.Drawing.Color.DarkBlue
        Me.tabPage2.Location = New System.Drawing.Point(4, 21)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(441, 77)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "RS232/485"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.cbBaudRate)
        Me.groupBox5.Controls.Add(Me.label5)
        Me.groupBox5.Controls.Add(Me.txtMachineSN)
        Me.groupBox5.Controls.Add(Me.cbPort)
        Me.groupBox5.Controls.Add(Me.label7)
        Me.groupBox5.Controls.Add(Me.label6)
        Me.groupBox5.Location = New System.Drawing.Point(17, -1)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(406, 40)
        Me.groupBox5.TabIndex = 12
        Me.groupBox5.TabStop = False
        '
        'cbBaudRate
        '
        Me.cbBaudRate.FormattingEnabled = True
        Me.cbBaudRate.Items.AddRange(New Object() {"1200", "2400", "4800", "9600", "19200", "38400", "115200"})
        Me.cbBaudRate.Location = New System.Drawing.Point(187, 14)
        Me.cbBaudRate.Name = "cbBaudRate"
        Me.cbBaudRate.Size = New System.Drawing.Size(65, 20)
        Me.cbBaudRate.TabIndex = 6
        Me.cbBaudRate.Text = "115200"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(10, 18)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(29, 12)
        Me.label5.TabIndex = 7
        Me.label5.Text = "Port"
        '
        'txtMachineSN
        '
        Me.txtMachineSN.Location = New System.Drawing.Point(337, 14)
        Me.txtMachineSN.Name = "txtMachineSN"
        Me.txtMachineSN.Size = New System.Drawing.Size(56, 21)
        Me.txtMachineSN.TabIndex = 10
        Me.txtMachineSN.Text = "1"
        '
        'cbPort
        '
        Me.cbPort.FormattingEnabled = True
        Me.cbPort.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9"})
        Me.cbPort.Location = New System.Drawing.Point(52, 14)
        Me.cbPort.Name = "cbPort"
        Me.cbPort.Size = New System.Drawing.Size(56, 20)
        Me.cbPort.TabIndex = 5
        Me.cbPort.Text = "COM1"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(265, 18)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(59, 12)
        Me.label7.TabIndex = 9
        Me.label7.Text = "MachineSN"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(121, 18)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(53, 12)
        Me.label6.TabIndex = 8
        Me.label6.Text = "BaudRate"
        '
        'btnRsConnect
        '
        Me.btnRsConnect.Location = New System.Drawing.Point(183, 47)
        Me.btnRsConnect.Name = "btnRsConnect"
        Me.btnRsConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnRsConnect.TabIndex = 11
        Me.btnRsConnect.Text = "Connect"
        Me.btnRsConnect.UseVisualStyleBackColor = True
        '
        'tabPage3
        '
        Me.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tabPage3.Controls.Add(Me.groupBox4)
        Me.tabPage3.Controls.Add(Me.btnUSBConnect)
        Me.tabPage3.Controls.Add(Me.groupBox3)
        Me.tabPage3.ForeColor = System.Drawing.Color.DarkBlue
        Me.tabPage3.Location = New System.Drawing.Point(4, 21)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Size = New System.Drawing.Size(441, 77)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "USBClient"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.rbVUSB)
        Me.groupBox4.Controls.Add(Me.label11)
        Me.groupBox4.Controls.Add(Me.txtMachineSN2)
        Me.groupBox4.Location = New System.Drawing.Point(23, -1)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(235, 38)
        Me.groupBox4.TabIndex = 7
        Me.groupBox4.TabStop = False
        '
        'rbVUSB
        '
        Me.rbVUSB.AutoSize = True
        Me.rbVUSB.Checked = True
        Me.rbVUSB.Location = New System.Drawing.Point(8, 15)
        Me.rbVUSB.Name = "rbVUSB"
        Me.rbVUSB.Size = New System.Drawing.Size(125, 16)
        Me.rbVUSB.TabIndex = 3
        Me.rbVUSB.TabStop = True
        Me.rbVUSB.Text = "Virtual USBClient"
        Me.rbVUSB.UseVisualStyleBackColor = True
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(138, 17)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(59, 12)
        Me.label11.TabIndex = 5
        Me.label11.Text = "MachineSN"
        '
        'txtMachineSN2
        '
        Me.txtMachineSN2.BackColor = System.Drawing.Color.AliceBlue
        Me.txtMachineSN2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMachineSN2.Location = New System.Drawing.Point(199, 12)
        Me.txtMachineSN2.Name = "txtMachineSN2"
        Me.txtMachineSN2.Size = New System.Drawing.Size(27, 21)
        Me.txtMachineSN2.TabIndex = 4
        Me.txtMachineSN2.Text = "1"
        '
        'btnUSBConnect
        '
        Me.btnUSBConnect.Location = New System.Drawing.Point(183, 47)
        Me.btnUSBConnect.Name = "btnUSBConnect"
        Me.btnUSBConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnUSBConnect.TabIndex = 0
        Me.btnUSBConnect.Text = "Connect"
        Me.btnUSBConnect.UseVisualStyleBackColor = True
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.rbUSB)
        Me.groupBox3.Location = New System.Drawing.Point(24, 37)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(89, 31)
        Me.groupBox3.TabIndex = 6
        Me.groupBox3.TabStop = False
        '
        'rbUSB
        '
        Me.rbUSB.AutoSize = True
        Me.rbUSB.Location = New System.Drawing.Point(7, 11)
        Me.rbUSB.Name = "rbUSB"
        Me.rbUSB.Size = New System.Drawing.Size(77, 16)
        Me.rbUSB.TabIndex = 2
        Me.rbUSB.Text = "USBClient"
        Me.rbUSB.UseVisualStyleBackColor = True
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.ForeColor = System.Drawing.Color.Crimson
        Me.lblState.Location = New System.Drawing.Point(150, 125)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(161, 12)
        Me.lblState.TabIndex = 2
        Me.lblState.Text = "Current State:Disconnected"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.tabControl6)
        Me.groupBox1.Location = New System.Drawing.Point(8, 193)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(461, 214)
        Me.groupBox1.TabIndex = 74
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Get or Set Options and Status of all Devices"
        '
        'tabControl6
        '
        Me.tabControl6.Controls.Add(Me.tabPage4)
        Me.tabControl6.Controls.Add(Me.tabPage5)
        Me.tabControl6.Controls.Add(Me.tabPage6)
        Me.tabControl6.Controls.Add(Me.tabPage7)
        Me.tabControl6.Location = New System.Drawing.Point(6, 21)
        Me.tabControl6.Name = "tabControl6"
        Me.tabControl6.SelectedIndex = 0
        Me.tabControl6.Size = New System.Drawing.Size(452, 185)
        Me.tabControl6.TabIndex = 72
        '
        'tabPage4
        '
        Me.tabPage4.Controls.Add(Me.Label3)
        Me.tabPage4.Controls.Add(Me.btnGetPlatform)
        Me.tabPage4.Controls.Add(Me.btnGetDeviceStrInfo)
        Me.tabPage4.Controls.Add(Me.btnGetSerialNumber)
        Me.tabPage4.Controls.Add(Me.btnGetCardFun)
        Me.tabPage4.Controls.Add(Me.btnGetDeviceIP)
        Me.tabPage4.Controls.Add(Me.btnQueryState)
        Me.tabPage4.Controls.Add(Me.btnGetVendor)
        Me.tabPage4.Controls.Add(Me.txtShow)
        Me.tabPage4.Controls.Add(Me.btnGetFirmwareVersion)
        Me.tabPage4.Controls.Add(Me.btnGetProductCode)
        Me.tabPage4.Controls.Add(Me.btnGetDeviceMAC)
        Me.tabPage4.Controls.Add(Me.btnGetSysOption)
        Me.tabPage4.Controls.Add(Me.btnGetSDKVersion)
        Me.tabPage4.Location = New System.Drawing.Point(4, 21)
        Me.tabPage4.Name = "tabPage4"
        Me.tabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage4.Size = New System.Drawing.Size(444, 160)
        Me.tabPage4.TabIndex = 0
        Me.tabPage4.Text = "GetOptions"
        Me.tabPage4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(15, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(161, 12)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Get the device parameters."
        '
        'btnGetPlatform
        '
        Me.btnGetPlatform.Location = New System.Drawing.Point(247, 68)
        Me.btnGetPlatform.Name = "btnGetPlatform"
        Me.btnGetPlatform.Size = New System.Drawing.Size(92, 23)
        Me.btnGetPlatform.TabIndex = 10
        Me.btnGetPlatform.Text = "GetPlatform"
        Me.btnGetPlatform.UseVisualStyleBackColor = True
        '
        'btnGetDeviceStrInfo
        '
        Me.btnGetDeviceStrInfo.Location = New System.Drawing.Point(14, 39)
        Me.btnGetDeviceStrInfo.Name = "btnGetDeviceStrInfo"
        Me.btnGetDeviceStrInfo.Size = New System.Drawing.Size(121, 23)
        Me.btnGetDeviceStrInfo.TabIndex = 0
        Me.btnGetDeviceStrInfo.Text = "GetDeviceStrInfo"
        Me.btnGetDeviceStrInfo.UseVisualStyleBackColor = True
        '
        'btnGetSerialNumber
        '
        Me.btnGetSerialNumber.Location = New System.Drawing.Point(14, 97)
        Me.btnGetSerialNumber.Name = "btnGetSerialNumber"
        Me.btnGetSerialNumber.Size = New System.Drawing.Size(122, 23)
        Me.btnGetSerialNumber.TabIndex = 1
        Me.btnGetSerialNumber.Text = "GetSerialNumber"
        Me.btnGetSerialNumber.UseVisualStyleBackColor = True
        '
        'btnGetCardFun
        '
        Me.btnGetCardFun.Location = New System.Drawing.Point(346, 68)
        Me.btnGetCardFun.Name = "btnGetCardFun"
        Me.btnGetCardFun.Size = New System.Drawing.Size(79, 23)
        Me.btnGetCardFun.TabIndex = 7
        Me.btnGetCardFun.Text = "GetCardFun"
        Me.btnGetCardFun.UseVisualStyleBackColor = True
        '
        'btnGetDeviceIP
        '
        Me.btnGetDeviceIP.Location = New System.Drawing.Point(142, 97)
        Me.btnGetDeviceIP.Name = "btnGetDeviceIP"
        Me.btnGetDeviceIP.Size = New System.Drawing.Size(98, 23)
        Me.btnGetDeviceIP.TabIndex = 9
        Me.btnGetDeviceIP.Text = "GetDeviceIP"
        Me.btnGetDeviceIP.UseVisualStyleBackColor = True
        '
        'btnQueryState
        '
        Me.btnQueryState.Location = New System.Drawing.Point(346, 97)
        Me.btnQueryState.Name = "btnQueryState"
        Me.btnQueryState.Size = New System.Drawing.Size(79, 23)
        Me.btnQueryState.TabIndex = 8
        Me.btnQueryState.Text = "QueryState"
        Me.btnQueryState.UseVisualStyleBackColor = True
        '
        'btnGetVendor
        '
        Me.btnGetVendor.Location = New System.Drawing.Point(346, 39)
        Me.btnGetVendor.Name = "btnGetVendor"
        Me.btnGetVendor.Size = New System.Drawing.Size(79, 23)
        Me.btnGetVendor.TabIndex = 11
        Me.btnGetVendor.Text = "GetVendor"
        Me.btnGetVendor.UseVisualStyleBackColor = True
        '
        'txtShow
        '
        Me.txtShow.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtShow.ForeColor = System.Drawing.Color.Red
        Me.txtShow.Location = New System.Drawing.Point(14, 126)
        Me.txtShow.Name = "txtShow"
        Me.txtShow.ReadOnly = True
        Me.txtShow.Size = New System.Drawing.Size(409, 21)
        Me.txtShow.TabIndex = 13
        Me.txtShow.Text = "return value"
        Me.txtShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnGetFirmwareVersion
        '
        Me.btnGetFirmwareVersion.Location = New System.Drawing.Point(14, 68)
        Me.btnGetFirmwareVersion.Name = "btnGetFirmwareVersion"
        Me.btnGetFirmwareVersion.Size = New System.Drawing.Size(122, 23)
        Me.btnGetFirmwareVersion.TabIndex = 4
        Me.btnGetFirmwareVersion.Text = "GetFirmwareVersion"
        Me.btnGetFirmwareVersion.UseVisualStyleBackColor = True
        '
        'btnGetProductCode
        '
        Me.btnGetProductCode.Location = New System.Drawing.Point(142, 68)
        Me.btnGetProductCode.Name = "btnGetProductCode"
        Me.btnGetProductCode.Size = New System.Drawing.Size(98, 23)
        Me.btnGetProductCode.TabIndex = 5
        Me.btnGetProductCode.Text = "GetProductCode"
        Me.btnGetProductCode.UseVisualStyleBackColor = True
        '
        'btnGetDeviceMAC
        '
        Me.btnGetDeviceMAC.Location = New System.Drawing.Point(247, 39)
        Me.btnGetDeviceMAC.Name = "btnGetDeviceMAC"
        Me.btnGetDeviceMAC.Size = New System.Drawing.Size(92, 23)
        Me.btnGetDeviceMAC.TabIndex = 2
        Me.btnGetDeviceMAC.Text = "GetDeviceMAC"
        Me.btnGetDeviceMAC.UseVisualStyleBackColor = True
        '
        'btnGetSysOption
        '
        Me.btnGetSysOption.Location = New System.Drawing.Point(142, 39)
        Me.btnGetSysOption.Name = "btnGetSysOption"
        Me.btnGetSysOption.Size = New System.Drawing.Size(98, 23)
        Me.btnGetSysOption.TabIndex = 12
        Me.btnGetSysOption.Text = "GetSysOption"
        Me.btnGetSysOption.UseVisualStyleBackColor = True
        '
        'btnGetSDKVersion
        '
        Me.btnGetSDKVersion.Location = New System.Drawing.Point(247, 97)
        Me.btnGetSDKVersion.Name = "btnGetSDKVersion"
        Me.btnGetSDKVersion.Size = New System.Drawing.Size(92, 23)
        Me.btnGetSDKVersion.TabIndex = 3
        Me.btnGetSDKVersion.Text = "GetSDKVersion"
        Me.btnGetSDKVersion.UseVisualStyleBackColor = True
        '
        'tabPage5
        '
        Me.tabPage5.Controls.Add(Me.label12)
        Me.tabPage5.Controls.Add(Me.label13)
        Me.tabPage5.Controls.Add(Me.btnSetSysOption)
        Me.tabPage5.Controls.Add(Me.btnSetDeviceCommPwd)
        Me.tabPage5.Controls.Add(Me.btnSetDeviceMAC)
        Me.tabPage5.Controls.Add(Me.txtSet)
        Me.tabPage5.Controls.Add(Me.btnSetCommPassword)
        Me.tabPage5.Controls.Add(Me.btnSetDeviceIP)
        Me.tabPage5.Location = New System.Drawing.Point(4, 21)
        Me.tabPage5.Name = "tabPage5"
        Me.tabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage5.Size = New System.Drawing.Size(444, 160)
        Me.tabPage5.TabIndex = 1
        Me.tabPage5.Text = "SetOptions"
        Me.tabPage5.UseVisualStyleBackColor = True
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.ForeColor = System.Drawing.Color.Red
        Me.label12.Location = New System.Drawing.Point(15, 13)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(185, 12)
        Me.label12.TabIndex = 74
        Me.label12.Text = "Set the Options of the device."
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.ForeColor = System.Drawing.Color.Red
        Me.label13.Location = New System.Drawing.Point(14, 122)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(125, 12)
        Me.label13.TabIndex = 8
        Me.label13.Text = "Input the value here"
        '
        'btnSetSysOption
        '
        Me.btnSetSysOption.Location = New System.Drawing.Point(340, 39)
        Me.btnSetSysOption.Name = "btnSetSysOption"
        Me.btnSetSysOption.Size = New System.Drawing.Size(90, 23)
        Me.btnSetSysOption.TabIndex = 4
        Me.btnSetSysOption.Text = "SetSysOption"
        Me.btnSetSysOption.UseVisualStyleBackColor = True
        '
        'btnSetDeviceCommPwd
        '
        Me.btnSetDeviceCommPwd.Location = New System.Drawing.Point(15, 78)
        Me.btnSetDeviceCommPwd.Name = "btnSetDeviceCommPwd"
        Me.btnSetDeviceCommPwd.Size = New System.Drawing.Size(124, 23)
        Me.btnSetDeviceCommPwd.TabIndex = 5
        Me.btnSetDeviceCommPwd.Text = "SetDeviceCommPwd"
        Me.btnSetDeviceCommPwd.UseVisualStyleBackColor = True
        '
        'btnSetDeviceMAC
        '
        Me.btnSetDeviceMAC.Location = New System.Drawing.Point(178, 41)
        Me.btnSetDeviceMAC.Name = "btnSetDeviceMAC"
        Me.btnSetDeviceMAC.Size = New System.Drawing.Size(94, 23)
        Me.btnSetDeviceMAC.TabIndex = 2
        Me.btnSetDeviceMAC.Text = "SetDeviceMAC"
        Me.btnSetDeviceMAC.UseVisualStyleBackColor = True
        '
        'txtSet
        '
        Me.txtSet.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtSet.ForeColor = System.Drawing.Color.Red
        Me.txtSet.Location = New System.Drawing.Point(141, 119)
        Me.txtSet.Name = "txtSet"
        Me.txtSet.Size = New System.Drawing.Size(131, 21)
        Me.txtSet.TabIndex = 0
        Me.txtSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSetCommPassword
        '
        Me.btnSetCommPassword.Location = New System.Drawing.Point(15, 41)
        Me.btnSetCommPassword.Name = "btnSetCommPassword"
        Me.btnSetCommPassword.Size = New System.Drawing.Size(124, 23)
        Me.btnSetCommPassword.TabIndex = 6
        Me.btnSetCommPassword.Text = "SetCommPassword"
        Me.btnSetCommPassword.UseVisualStyleBackColor = True
        '
        'btnSetDeviceIP
        '
        Me.btnSetDeviceIP.Location = New System.Drawing.Point(177, 78)
        Me.btnSetDeviceIP.Name = "btnSetDeviceIP"
        Me.btnSetDeviceIP.Size = New System.Drawing.Size(95, 23)
        Me.btnSetDeviceIP.TabIndex = 1
        Me.btnSetDeviceIP.Text = "SetDeviceIP"
        Me.btnSetDeviceIP.UseVisualStyleBackColor = True
        '
        'tabPage6
        '
        Me.tabPage6.Controls.Add(Me.label18)
        Me.tabPage6.Controls.Add(Me.label17)
        Me.tabPage6.Controls.Add(Me.cbSetDeviceInfo)
        Me.tabPage6.Controls.Add(Me.cbStatus)
        Me.tabPage6.Controls.Add(Me.txtGetDeviceStatus)
        Me.tabPage6.Controls.Add(Me.btnGetDeviceStatus)
        Me.tabPage6.Controls.Add(Me.cbInfo2)
        Me.tabPage6.Controls.Add(Me.txtGetDeviceInfo)
        Me.tabPage6.Controls.Add(Me.cbInfo1)
        Me.tabPage6.Controls.Add(Me.btnSetDeviceInfo)
        Me.tabPage6.Controls.Add(Me.btnGetDeviceInfo)
        Me.tabPage6.Location = New System.Drawing.Point(4, 21)
        Me.tabPage6.Name = "tabPage6"
        Me.tabPage6.Size = New System.Drawing.Size(444, 160)
        Me.tabPage6.TabIndex = 2
        Me.tabPage6.Text = "Status"
        Me.tabPage6.UseVisualStyleBackColor = True
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.ForeColor = System.Drawing.Color.Red
        Me.label18.Location = New System.Drawing.Point(15, 129)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(389, 12)
        Me.label18.TabIndex = 76
        Me.label18.Text = "More details for parameters,pls refer to the development manual."
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.ForeColor = System.Drawing.Color.Red
        Me.label17.Location = New System.Drawing.Point(15, 13)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(221, 12)
        Me.label17.TabIndex = 75
        Me.label17.Text = "Get or Set the Status of the device."
        '
        'cbSetDeviceInfo
        '
        Me.cbSetDeviceInfo.FormattingEnabled = True
        Me.cbSetDeviceInfo.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "500"})
        Me.cbSetDeviceInfo.Location = New System.Drawing.Point(235, 93)
        Me.cbSetDeviceInfo.Name = "cbSetDeviceInfo"
        Me.cbSetDeviceInfo.Size = New System.Drawing.Size(75, 20)
        Me.cbSetDeviceInfo.TabIndex = 25
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6.", "7.", "8.", "9.", "10.", "11.", "12."})
        Me.cbStatus.Location = New System.Drawing.Point(9, 37)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(217, 20)
        Me.cbStatus.TabIndex = 18
        Me.cbStatus.Text = "Status Type"
        '
        'txtGetDeviceStatus
        '
        Me.txtGetDeviceStatus.Location = New System.Drawing.Point(346, 37)
        Me.txtGetDeviceStatus.Name = "txtGetDeviceStatus"
        Me.txtGetDeviceStatus.ReadOnly = True
        Me.txtGetDeviceStatus.Size = New System.Drawing.Size(88, 21)
        Me.txtGetDeviceStatus.TabIndex = 20
        '
        'btnGetDeviceStatus
        '
        Me.btnGetDeviceStatus.Location = New System.Drawing.Point(234, 37)
        Me.btnGetDeviceStatus.Name = "btnGetDeviceStatus"
        Me.btnGetDeviceStatus.Size = New System.Drawing.Size(106, 23)
        Me.btnGetDeviceStatus.TabIndex = 19
        Me.btnGetDeviceStatus.Text = "GetDeviceStatus"
        Me.btnGetDeviceStatus.UseVisualStyleBackColor = True
        '
        'cbInfo2
        '
        Me.cbInfo2.FormattingEnabled = True
        Me.cbInfo2.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6.", "7.", "8.", "9.", "10.", "11.", "12.", "13.", "14..", "15.", "16.", "17.", "18..", "19.", "20."})
        Me.cbInfo2.Location = New System.Drawing.Point(9, 93)
        Me.cbInfo2.Name = "cbInfo2"
        Me.cbInfo2.Size = New System.Drawing.Size(217, 20)
        Me.cbInfo2.TabIndex = 24
        Me.cbInfo2.Text = "Info Type"
        '
        'txtGetDeviceInfo
        '
        Me.txtGetDeviceInfo.Location = New System.Drawing.Point(346, 65)
        Me.txtGetDeviceInfo.Name = "txtGetDeviceInfo"
        Me.txtGetDeviceInfo.ReadOnly = True
        Me.txtGetDeviceInfo.Size = New System.Drawing.Size(88, 21)
        Me.txtGetDeviceInfo.TabIndex = 23
        '
        'cbInfo1
        '
        Me.cbInfo1.FormattingEnabled = True
        Me.cbInfo1.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6.", "7.", "8.", "9.", "10.", "11.", "12.", "13.", "14..", "15.", "16.", "17.", "18..", "19.", "20.", "21.", "22.", "23...", "24.", "25.", "26.", "27....", "28.", "29.", "30.", "31.", "32.", "33.", "34.", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "66", "67", "68"})
        Me.cbInfo1.Location = New System.Drawing.Point(9, 65)
        Me.cbInfo1.Name = "cbInfo1"
        Me.cbInfo1.Size = New System.Drawing.Size(217, 20)
        Me.cbInfo1.TabIndex = 21
        Me.cbInfo1.Text = "Info Type"
        '
        'btnSetDeviceInfo
        '
        Me.btnSetDeviceInfo.Location = New System.Drawing.Point(317, 93)
        Me.btnSetDeviceInfo.Name = "btnSetDeviceInfo"
        Me.btnSetDeviceInfo.Size = New System.Drawing.Size(119, 23)
        Me.btnSetDeviceInfo.TabIndex = 26
        Me.btnSetDeviceInfo.Text = "SetDeviceInfo"
        Me.btnSetDeviceInfo.UseVisualStyleBackColor = True
        '
        'btnGetDeviceInfo
        '
        Me.btnGetDeviceInfo.Location = New System.Drawing.Point(235, 65)
        Me.btnGetDeviceInfo.Name = "btnGetDeviceInfo"
        Me.btnGetDeviceInfo.Size = New System.Drawing.Size(105, 23)
        Me.btnGetDeviceInfo.TabIndex = 22
        Me.btnGetDeviceInfo.Text = "GetDeviceInfo"
        Me.btnGetDeviceInfo.UseVisualStyleBackColor = True
        '
        'tabPage7
        '
        Me.tabPage7.Controls.Add(Me.label33)
        Me.tabPage7.Controls.Add(Me.label32)
        Me.tabPage7.Controls.Add(Me.btnPowerOffDevice)
        Me.tabPage7.Controls.Add(Me.btnDisableDeviceWithTimeOut)
        Me.tabPage7.Controls.Add(Me.btnRestartDevice)
        Me.tabPage7.Location = New System.Drawing.Point(4, 21)
        Me.tabPage7.Name = "tabPage7"
        Me.tabPage7.Size = New System.Drawing.Size(444, 160)
        Me.tabPage7.TabIndex = 3
        Me.tabPage7.Text = "Control"
        Me.tabPage7.UseVisualStyleBackColor = True
        '
        'label33
        '
        Me.label33.AutoSize = True
        Me.label33.ForeColor = System.Drawing.Color.Red
        Me.label33.Location = New System.Drawing.Point(15, 70)
        Me.label33.Name = "label33"
        Me.label33.Size = New System.Drawing.Size(191, 12)
        Me.label33.TabIndex = 77
        Me.label33.Text = "Restart or Poweroff the device."
        '
        'label32
        '
        Me.label32.AutoSize = True
        Me.label32.ForeColor = System.Drawing.Color.Red
        Me.label32.Location = New System.Drawing.Point(15, 13)
        Me.label32.Name = "label32"
        Me.label32.Size = New System.Drawing.Size(245, 12)
        Me.label32.TabIndex = 76
        Me.label32.Text = "Disable the Device for a period of time."
        '
        'btnPowerOffDevice
        '
        Me.btnPowerOffDevice.Location = New System.Drawing.Point(135, 93)
        Me.btnPowerOffDevice.Name = "btnPowerOffDevice"
        Me.btnPowerOffDevice.Size = New System.Drawing.Size(97, 23)
        Me.btnPowerOffDevice.TabIndex = 6
        Me.btnPowerOffDevice.Text = "PowerOffDevice"
        Me.btnPowerOffDevice.UseVisualStyleBackColor = True
        '
        'btnDisableDeviceWithTimeOut
        '
        Me.btnDisableDeviceWithTimeOut.Location = New System.Drawing.Point(15, 36)
        Me.btnDisableDeviceWithTimeOut.Name = "btnDisableDeviceWithTimeOut"
        Me.btnDisableDeviceWithTimeOut.Size = New System.Drawing.Size(158, 23)
        Me.btnDisableDeviceWithTimeOut.TabIndex = 4
        Me.btnDisableDeviceWithTimeOut.Text = "DisableDeviceWithTimeOut"
        Me.btnDisableDeviceWithTimeOut.UseVisualStyleBackColor = True
        '
        'btnRestartDevice
        '
        Me.btnRestartDevice.Location = New System.Drawing.Point(15, 93)
        Me.btnRestartDevice.Name = "btnRestartDevice"
        Me.btnRestartDevice.Size = New System.Drawing.Size(94, 23)
        Me.btnRestartDevice.TabIndex = 3
        Me.btnRestartDevice.Text = "RestartDevice"
        Me.btnRestartDevice.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.tabControl4)
        Me.GroupBox6.Controls.Add(Me.tabControl3)
        Me.GroupBox6.Location = New System.Drawing.Point(475, 41)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(467, 368)
        Me.GroupBox6.TabIndex = 75
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Get or Set the device's Common Configurations"
        '
        'tabControl4
        '
        Me.tabControl4.Controls.Add(Me.tabPage8)
        Me.tabControl4.Controls.Add(Me.tabPage9)
        Me.tabControl4.Controls.Add(Me.tabPage10)
        Me.tabControl4.Controls.Add(Me.tabPage11)
        Me.tabControl4.Location = New System.Drawing.Point(9, 22)
        Me.tabControl4.Name = "tabControl4"
        Me.tabControl4.SelectedIndex = 0
        Me.tabControl4.Size = New System.Drawing.Size(448, 151)
        Me.tabControl4.TabIndex = 0
        '
        'tabPage8
        '
        Me.tabPage8.Controls.Add(Me.label19)
        Me.tabPage8.Controls.Add(Me.btnGetDeviceTime)
        Me.tabPage8.Controls.Add(Me.btnSetDeviceTime)
        Me.tabPage8.Controls.Add(Me.cbSecond)
        Me.tabPage8.Controls.Add(Me.cbMonth)
        Me.tabPage8.Controls.Add(Me.cbMinute)
        Me.tabPage8.Controls.Add(Me.btnSetDeviceTime2)
        Me.tabPage8.Controls.Add(Me.txtGetDeviceTime)
        Me.tabPage8.Controls.Add(Me.cbDay)
        Me.tabPage8.Controls.Add(Me.cbHour)
        Me.tabPage8.Controls.Add(Me.cbYear)
        Me.tabPage8.Location = New System.Drawing.Point(4, 21)
        Me.tabPage8.Name = "tabPage8"
        Me.tabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage8.Size = New System.Drawing.Size(440, 126)
        Me.tabPage8.TabIndex = 0
        Me.tabPage8.Text = "DeviceTime"
        Me.tabPage8.UseVisualStyleBackColor = True
        '
        'label19
        '
        Me.label19.AutoSize = True
        Me.label19.ForeColor = System.Drawing.Color.Red
        Me.label19.Location = New System.Drawing.Point(12, 13)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(209, 12)
        Me.label19.TabIndex = 75
        Me.label19.Text = "Get or set the time of the device."
        '
        'btnGetDeviceTime
        '
        Me.btnGetDeviceTime.Location = New System.Drawing.Point(151, 44)
        Me.btnGetDeviceTime.Name = "btnGetDeviceTime"
        Me.btnGetDeviceTime.Size = New System.Drawing.Size(95, 23)
        Me.btnGetDeviceTime.TabIndex = 1
        Me.btnGetDeviceTime.Text = "GetDeviceTime"
        Me.btnGetDeviceTime.UseVisualStyleBackColor = True
        '
        'btnSetDeviceTime
        '
        Me.btnSetDeviceTime.Location = New System.Drawing.Point(8, 43)
        Me.btnSetDeviceTime.Name = "btnSetDeviceTime"
        Me.btnSetDeviceTime.Size = New System.Drawing.Size(95, 23)
        Me.btnSetDeviceTime.TabIndex = 0
        Me.btnSetDeviceTime.Text = "SetDeviceTime"
        Me.btnSetDeviceTime.UseVisualStyleBackColor = True
        '
        'cbSecond
        '
        Me.cbSecond.FormattingEnabled = True
        Me.cbSecond.Items.AddRange(New Object() {"1", "..", "59"})
        Me.cbSecond.Location = New System.Drawing.Point(273, 85)
        Me.cbSecond.Name = "cbSecond"
        Me.cbSecond.Size = New System.Drawing.Size(41, 20)
        Me.cbSecond.TabIndex = 8
        Me.cbSecond.Text = "8"
        '
        'cbMonth
        '
        Me.cbMonth.DisplayMember = "Month"
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cbMonth.Location = New System.Drawing.Point(77, 84)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(41, 20)
        Me.cbMonth.TabIndex = 4
        Me.cbMonth.Text = "12"
        '
        'cbMinute
        '
        Me.cbMinute.FormattingEnabled = True
        Me.cbMinute.Items.AddRange(New Object() {"1", "..", "59"})
        Me.cbMinute.Location = New System.Drawing.Point(224, 85)
        Me.cbMinute.Name = "cbMinute"
        Me.cbMinute.Size = New System.Drawing.Size(41, 20)
        Me.cbMinute.TabIndex = 7
        Me.cbMinute.Text = "8"
        '
        'btnSetDeviceTime2
        '
        Me.btnSetDeviceTime2.Location = New System.Drawing.Point(322, 83)
        Me.btnSetDeviceTime2.Name = "btnSetDeviceTime2"
        Me.btnSetDeviceTime2.Size = New System.Drawing.Size(114, 23)
        Me.btnSetDeviceTime2.TabIndex = 9
        Me.btnSetDeviceTime2.Text = "SetDeviceTime2"
        Me.btnSetDeviceTime2.UseVisualStyleBackColor = True
        '
        'txtGetDeviceTime
        '
        Me.txtGetDeviceTime.Location = New System.Drawing.Point(277, 43)
        Me.txtGetDeviceTime.Name = "txtGetDeviceTime"
        Me.txtGetDeviceTime.ReadOnly = True
        Me.txtGetDeviceTime.Size = New System.Drawing.Size(156, 21)
        Me.txtGetDeviceTime.TabIndex = 2
        '
        'cbDay
        '
        Me.cbDay.FormattingEnabled = True
        Me.cbDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "..", "30"})
        Me.cbDay.Location = New System.Drawing.Point(126, 84)
        Me.cbDay.Name = "cbDay"
        Me.cbDay.Size = New System.Drawing.Size(41, 20)
        Me.cbDay.TabIndex = 5
        Me.cbDay.Text = "31"
        '
        'cbHour
        '
        Me.cbHour.FormattingEnabled = True
        Me.cbHour.Items.AddRange(New Object() {"1", "..", "59"})
        Me.cbHour.Location = New System.Drawing.Point(175, 85)
        Me.cbHour.Name = "cbHour"
        Me.cbHour.Size = New System.Drawing.Size(41, 20)
        Me.cbHour.TabIndex = 6
        Me.cbHour.Text = "8"
        '
        'cbYear
        '
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Items.AddRange(New Object() {"2009", "2010", "2011", "2012"})
        Me.cbYear.Location = New System.Drawing.Point(9, 84)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(60, 20)
        Me.cbYear.TabIndex = 3
        Me.cbYear.Text = "2009"
        '
        'tabPage9
        '
        Me.tabPage9.Controls.Add(Me.label20)
        Me.tabPage9.Controls.Add(Me.Label4)
        Me.tabPage9.Controls.Add(Me.cbIndex)
        Me.tabPage9.Controls.Add(Me.label29)
        Me.tabPage9.Controls.Add(Me.cbPosition)
        Me.tabPage9.Controls.Add(Me.cbLength)
        Me.tabPage9.Controls.Add(Me.btnPlayVoice)
        Me.tabPage9.Controls.Add(Me.btnPlayVoiceByIndex)
        Me.tabPage9.Controls.Add(Me.label30)
        Me.tabPage9.Location = New System.Drawing.Point(4, 21)
        Me.tabPage9.Name = "tabPage9"
        Me.tabPage9.Size = New System.Drawing.Size(440, 126)
        Me.tabPage9.TabIndex = 1
        Me.tabPage9.Text = "Voice"
        Me.tabPage9.UseVisualStyleBackColor = True
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.ForeColor = System.Drawing.Color.Red
        Me.label20.Location = New System.Drawing.Point(12, 13)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(233, 12)
        Me.label20.TabIndex = 76
        Me.label20.Text = "Play a series of wav or play by index."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Index"
        '
        'cbIndex
        '
        Me.cbIndex.FormattingEnabled = True
        Me.cbIndex.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"})
        Me.cbIndex.Location = New System.Drawing.Point(73, 41)
        Me.cbIndex.Name = "cbIndex"
        Me.cbIndex.Size = New System.Drawing.Size(46, 20)
        Me.cbIndex.TabIndex = 23
        '
        'label29
        '
        Me.label29.AutoSize = True
        Me.label29.Location = New System.Drawing.Point(12, 81)
        Me.label29.Name = "label29"
        Me.label29.Size = New System.Drawing.Size(53, 12)
        Me.label29.TabIndex = 21
        Me.label29.Text = "Position"
        '
        'cbPosition
        '
        Me.cbPosition.FormattingEnabled = True
        Me.cbPosition.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"})
        Me.cbPosition.Location = New System.Drawing.Point(73, 78)
        Me.cbPosition.Name = "cbPosition"
        Me.cbPosition.Size = New System.Drawing.Size(46, 20)
        Me.cbPosition.TabIndex = 9
        '
        'cbLength
        '
        Me.cbLength.FormattingEnabled = True
        Me.cbLength.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"})
        Me.cbLength.Location = New System.Drawing.Point(182, 77)
        Me.cbLength.Name = "cbLength"
        Me.cbLength.Size = New System.Drawing.Size(46, 20)
        Me.cbLength.TabIndex = 19
        '
        'btnPlayVoice
        '
        Me.btnPlayVoice.Location = New System.Drawing.Point(243, 76)
        Me.btnPlayVoice.Name = "btnPlayVoice"
        Me.btnPlayVoice.Size = New System.Drawing.Size(75, 23)
        Me.btnPlayVoice.TabIndex = 17
        Me.btnPlayVoice.Text = "PlayVoice"
        Me.btnPlayVoice.UseVisualStyleBackColor = True
        '
        'btnPlayVoiceByIndex
        '
        Me.btnPlayVoiceByIndex.Location = New System.Drawing.Point(136, 41)
        Me.btnPlayVoiceByIndex.Name = "btnPlayVoiceByIndex"
        Me.btnPlayVoiceByIndex.Size = New System.Drawing.Size(125, 23)
        Me.btnPlayVoiceByIndex.TabIndex = 18
        Me.btnPlayVoiceByIndex.Text = "PlayVoiceByIndex"
        Me.btnPlayVoiceByIndex.UseVisualStyleBackColor = True
        '
        'label30
        '
        Me.label30.AutoSize = True
        Me.label30.Location = New System.Drawing.Point(134, 81)
        Me.label30.Name = "label30"
        Me.label30.Size = New System.Drawing.Size(41, 12)
        Me.label30.TabIndex = 22
        Me.label30.Text = "Length"
        '
        'tabPage10
        '
        Me.tabPage10.Controls.Add(Me.label21)
        Me.tabPage10.Controls.Add(Me.cbRow)
        Me.tabPage10.Controls.Add(Me.cbCol)
        Me.tabPage10.Controls.Add(Me.btnWriteLCD)
        Me.tabPage10.Controls.Add(Me.btnClearLCD)
        Me.tabPage10.Controls.Add(Me.label25)
        Me.tabPage10.Controls.Add(Me.label27)
        Me.tabPage10.Controls.Add(Me.label26)
        Me.tabPage10.Controls.Add(Me.txtText)
        Me.tabPage10.Location = New System.Drawing.Point(4, 21)
        Me.tabPage10.Name = "tabPage10"
        Me.tabPage10.Size = New System.Drawing.Size(440, 126)
        Me.tabPage10.TabIndex = 2
        Me.tabPage10.Text = "LCD"
        Me.tabPage10.UseVisualStyleBackColor = True
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.ForeColor = System.Drawing.Color.Red
        Me.label21.Location = New System.Drawing.Point(12, 13)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(227, 12)
        Me.label21.TabIndex = 77
        Me.label21.Text = "Write or clear the LCD of the device."
        '
        'cbRow
        '
        Me.cbRow.FormattingEnabled = True
        Me.cbRow.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6"})
        Me.cbRow.Location = New System.Drawing.Point(44, 41)
        Me.cbRow.Name = "cbRow"
        Me.cbRow.Size = New System.Drawing.Size(52, 20)
        Me.cbRow.TabIndex = 10
        Me.cbRow.Text = "0"
        '
        'cbCol
        '
        Me.cbCol.FormattingEnabled = True
        Me.cbCol.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6"})
        Me.cbCol.Location = New System.Drawing.Point(137, 41)
        Me.cbCol.Name = "cbCol"
        Me.cbCol.Size = New System.Drawing.Size(46, 20)
        Me.cbCol.TabIndex = 11
        Me.cbCol.Text = "0"
        '
        'btnWriteLCD
        '
        Me.btnWriteLCD.Location = New System.Drawing.Point(13, 74)
        Me.btnWriteLCD.Name = "btnWriteLCD"
        Me.btnWriteLCD.Size = New System.Drawing.Size(63, 23)
        Me.btnWriteLCD.TabIndex = 3
        Me.btnWriteLCD.Text = "WriteLCD"
        Me.btnWriteLCD.UseVisualStyleBackColor = True
        '
        'btnClearLCD
        '
        Me.btnClearLCD.Location = New System.Drawing.Point(87, 74)
        Me.btnClearLCD.Name = "btnClearLCD"
        Me.btnClearLCD.Size = New System.Drawing.Size(62, 23)
        Me.btnClearLCD.TabIndex = 16
        Me.btnClearLCD.Text = "ClearLCD"
        Me.btnClearLCD.UseVisualStyleBackColor = True
        '
        'label25
        '
        Me.label25.AutoSize = True
        Me.label25.Location = New System.Drawing.Point(12, 45)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(23, 12)
        Me.label25.TabIndex = 8
        Me.label25.Text = "Row"
        '
        'label27
        '
        Me.label27.AutoSize = True
        Me.label27.Location = New System.Drawing.Point(192, 45)
        Me.label27.Name = "label27"
        Me.label27.Size = New System.Drawing.Size(29, 12)
        Me.label27.TabIndex = 14
        Me.label27.Text = "Text"
        '
        'label26
        '
        Me.label26.AutoSize = True
        Me.label26.Location = New System.Drawing.Point(105, 45)
        Me.label26.Name = "label26"
        Me.label26.Size = New System.Drawing.Size(23, 12)
        Me.label26.TabIndex = 13
        Me.label26.Text = "Col"
        '
        'txtText
        '
        Me.txtText.Location = New System.Drawing.Point(230, 41)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(102, 21)
        Me.txtText.TabIndex = 12
        Me.txtText.Text = "ZKSoftware"
        '
        'tabPage11
        '
        Me.tabPage11.Controls.Add(Me.label22)
        Me.tabPage11.Controls.Add(Me.label37)
        Me.tabPage11.Controls.Add(Me.label38)
        Me.tabPage11.Controls.Add(Me.label39)
        Me.tabPage11.Controls.Add(Me.txtEndTime)
        Me.tabPage11.Controls.Add(Me.btnSetDaylight)
        Me.tabPage11.Controls.Add(Me.cbSupport)
        Me.tabPage11.Controls.Add(Me.txtBeginTime)
        Me.tabPage11.Controls.Add(Me.btnGetDaylight)
        Me.tabPage11.Location = New System.Drawing.Point(4, 21)
        Me.tabPage11.Name = "tabPage11"
        Me.tabPage11.Size = New System.Drawing.Size(440, 126)
        Me.tabPage11.TabIndex = 3
        Me.tabPage11.Text = "DayLight"
        Me.tabPage11.UseVisualStyleBackColor = True
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.ForeColor = System.Drawing.Color.Red
        Me.label22.Location = New System.Drawing.Point(12, 13)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(203, 12)
        Me.label22.TabIndex = 78
        Me.label22.Text = "Get or set the Daylight settings."
        '
        'label37
        '
        Me.label37.AutoSize = True
        Me.label37.Location = New System.Drawing.Point(12, 44)
        Me.label37.Name = "label37"
        Me.label37.Size = New System.Drawing.Size(47, 12)
        Me.label37.TabIndex = 44
        Me.label37.Text = "Support"
        '
        'label38
        '
        Me.label38.AutoSize = True
        Me.label38.Location = New System.Drawing.Point(112, 44)
        Me.label38.Name = "label38"
        Me.label38.Size = New System.Drawing.Size(59, 12)
        Me.label38.TabIndex = 47
        Me.label38.Text = "BeginTime"
        '
        'label39
        '
        Me.label39.AutoSize = True
        Me.label39.Location = New System.Drawing.Point(281, 44)
        Me.label39.Name = "label39"
        Me.label39.Size = New System.Drawing.Size(47, 12)
        Me.label39.TabIndex = 0
        Me.label39.Text = "EndTime"
        '
        'txtEndTime
        '
        Me.txtEndTime.Location = New System.Drawing.Point(329, 40)
        Me.txtEndTime.Name = "txtEndTime"
        Me.txtEndTime.Size = New System.Drawing.Size(100, 21)
        Me.txtEndTime.TabIndex = 2
        '
        'btnSetDaylight
        '
        Me.btnSetDaylight.Location = New System.Drawing.Point(12, 71)
        Me.btnSetDaylight.Name = "btnSetDaylight"
        Me.btnSetDaylight.Size = New System.Drawing.Size(83, 23)
        Me.btnSetDaylight.TabIndex = 3
        Me.btnSetDaylight.Text = "SetDaylight"
        Me.btnSetDaylight.UseVisualStyleBackColor = True
        '
        'cbSupport
        '
        Me.cbSupport.FormattingEnabled = True
        Me.cbSupport.Items.AddRange(New Object() {"0", "1"})
        Me.cbSupport.Location = New System.Drawing.Point(61, 40)
        Me.cbSupport.Name = "cbSupport"
        Me.cbSupport.Size = New System.Drawing.Size(39, 20)
        Me.cbSupport.TabIndex = 0
        Me.cbSupport.Text = "1"
        '
        'txtBeginTime
        '
        Me.txtBeginTime.Location = New System.Drawing.Point(172, 40)
        Me.txtBeginTime.Name = "txtBeginTime"
        Me.txtBeginTime.Size = New System.Drawing.Size(100, 21)
        Me.txtBeginTime.TabIndex = 1
        '
        'btnGetDaylight
        '
        Me.btnGetDaylight.Location = New System.Drawing.Point(113, 71)
        Me.btnGetDaylight.Name = "btnGetDaylight"
        Me.btnGetDaylight.Size = New System.Drawing.Size(80, 23)
        Me.btnGetDaylight.TabIndex = 4
        Me.btnGetDaylight.Text = "GetDaylight"
        Me.btnGetDaylight.UseVisualStyleBackColor = True
        '
        'tabControl3
        '
        Me.tabControl3.Controls.Add(Me.tabPage12)
        Me.tabControl3.Controls.Add(Me.tabPage13)
        Me.tabControl3.Location = New System.Drawing.Point(9, 196)
        Me.tabControl3.Name = "tabControl3"
        Me.tabControl3.SelectedIndex = 0
        Me.tabControl3.Size = New System.Drawing.Size(448, 162)
        Me.tabControl3.TabIndex = 68
        '
        'tabPage12
        '
        Me.tabPage12.Controls.Add(Me.label49)
        Me.tabPage12.Controls.Add(Me.label23)
        Me.tabPage12.Controls.Add(Me.label48)
        Me.tabPage12.Controls.Add(Me.btnGetWorkCode)
        Me.tabPage12.Controls.Add(Me.btnSetWorkCode)
        Me.tabPage12.Controls.Add(Me.cbAWorkCode)
        Me.tabPage12.Controls.Add(Me.btnClearWorkCode)
        Me.tabPage12.Controls.Add(Me.btnDeleteWorkCode)
        Me.tabPage12.Controls.Add(Me.cbWorkCodeID)
        Me.tabPage12.Location = New System.Drawing.Point(4, 21)
        Me.tabPage12.Name = "tabPage12"
        Me.tabPage12.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage12.Size = New System.Drawing.Size(440, 137)
        Me.tabPage12.TabIndex = 0
        Me.tabPage12.Text = "WorkCode"
        Me.tabPage12.UseVisualStyleBackColor = True
        '
        'label49
        '
        Me.label49.AutoSize = True
        Me.label49.Location = New System.Drawing.Point(12, 77)
        Me.label49.Name = "label49"
        Me.label49.Size = New System.Drawing.Size(59, 12)
        Me.label49.TabIndex = 10
        Me.label49.Text = "AWorkCode"
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.ForeColor = System.Drawing.Color.Red
        Me.label23.Location = New System.Drawing.Point(12, 13)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(233, 12)
        Me.label23.TabIndex = 79
        Me.label23.Text = "Set or Get the Workcode of the device."
        '
        'label48
        '
        Me.label48.AutoSize = True
        Me.label48.Location = New System.Drawing.Point(12, 47)
        Me.label48.Name = "label48"
        Me.label48.Size = New System.Drawing.Size(65, 12)
        Me.label48.TabIndex = 9
        Me.label48.Text = "WorkCodeID"
        '
        'btnGetWorkCode
        '
        Me.btnGetWorkCode.Location = New System.Drawing.Point(260, 42)
        Me.btnGetWorkCode.Name = "btnGetWorkCode"
        Me.btnGetWorkCode.Size = New System.Drawing.Size(95, 23)
        Me.btnGetWorkCode.TabIndex = 3
        Me.btnGetWorkCode.Text = "GetWorkCode"
        Me.btnGetWorkCode.UseVisualStyleBackColor = True
        '
        'btnSetWorkCode
        '
        Me.btnSetWorkCode.Location = New System.Drawing.Point(145, 42)
        Me.btnSetWorkCode.Name = "btnSetWorkCode"
        Me.btnSetWorkCode.Size = New System.Drawing.Size(102, 23)
        Me.btnSetWorkCode.TabIndex = 2
        Me.btnSetWorkCode.Text = "SetWorkCode"
        Me.btnSetWorkCode.UseVisualStyleBackColor = True
        '
        'cbAWorkCode
        '
        Me.cbAWorkCode.FormattingEnabled = True
        Me.cbAWorkCode.Location = New System.Drawing.Point(81, 73)
        Me.cbAWorkCode.Name = "cbAWorkCode"
        Me.cbAWorkCode.Size = New System.Drawing.Size(48, 20)
        Me.cbAWorkCode.TabIndex = 1
        '
        'btnClearWorkCode
        '
        Me.btnClearWorkCode.Location = New System.Drawing.Point(260, 72)
        Me.btnClearWorkCode.Name = "btnClearWorkCode"
        Me.btnClearWorkCode.Size = New System.Drawing.Size(95, 23)
        Me.btnClearWorkCode.TabIndex = 5
        Me.btnClearWorkCode.Text = "ClearWorkCode"
        Me.btnClearWorkCode.UseVisualStyleBackColor = True
        '
        'btnDeleteWorkCode
        '
        Me.btnDeleteWorkCode.Location = New System.Drawing.Point(145, 72)
        Me.btnDeleteWorkCode.Name = "btnDeleteWorkCode"
        Me.btnDeleteWorkCode.Size = New System.Drawing.Size(102, 23)
        Me.btnDeleteWorkCode.TabIndex = 4
        Me.btnDeleteWorkCode.Text = "DeleteWorkCode"
        Me.btnDeleteWorkCode.UseVisualStyleBackColor = True
        '
        'cbWorkCodeID
        '
        Me.cbWorkCodeID.FormattingEnabled = True
        Me.cbWorkCodeID.Location = New System.Drawing.Point(81, 44)
        Me.cbWorkCodeID.Name = "cbWorkCodeID"
        Me.cbWorkCodeID.Size = New System.Drawing.Size(47, 20)
        Me.cbWorkCodeID.TabIndex = 0
        '
        'tabPage13
        '
        Me.tabPage13.Controls.Add(Me.label31)
        Me.tabPage13.Controls.Add(Me.label24)
        Me.tabPage13.Controls.Add(Me.txtHoliday)
        Me.tabPage13.Controls.Add(Me.btnGetHoliday)
        Me.tabPage13.Controls.Add(Me.btnSetHoliday)
        Me.tabPage13.Location = New System.Drawing.Point(4, 21)
        Me.tabPage13.Name = "tabPage13"
        Me.tabPage13.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage13.Size = New System.Drawing.Size(440, 137)
        Me.tabPage13.TabIndex = 1
        Me.tabPage13.Text = "Holiday"
        Me.tabPage13.UseVisualStyleBackColor = True
        '
        'label31
        '
        Me.label31.AutoSize = True
        Me.label31.Location = New System.Drawing.Point(13, 50)
        Me.label31.Name = "label31"
        Me.label31.Size = New System.Drawing.Size(47, 12)
        Me.label31.TabIndex = 3
        Me.label31.Text = "Holiday"
        '
        'label24
        '
        Me.label24.AutoSize = True
        Me.label24.ForeColor = System.Drawing.Color.Red
        Me.label24.Location = New System.Drawing.Point(12, 13)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(227, 12)
        Me.label24.TabIndex = 80
        Me.label24.Text = "Set or get the Holiday of the device."
        '
        'txtHoliday
        '
        Me.txtHoliday.Location = New System.Drawing.Point(81, 46)
        Me.txtHoliday.Name = "txtHoliday"
        Me.txtHoliday.Size = New System.Drawing.Size(92, 21)
        Me.txtHoliday.TabIndex = 0
        Me.txtHoliday.Text = "04140511"
        '
        'btnGetHoliday
        '
        Me.btnGetHoliday.Location = New System.Drawing.Point(290, 45)
        Me.btnGetHoliday.Name = "btnGetHoliday"
        Me.btnGetHoliday.Size = New System.Drawing.Size(79, 23)
        Me.btnGetHoliday.TabIndex = 2
        Me.btnGetHoliday.Text = "GetHoliday"
        Me.btnGetHoliday.UseVisualStyleBackColor = True
        '
        'btnSetHoliday
        '
        Me.btnSetHoliday.Location = New System.Drawing.Point(194, 45)
        Me.btnSetHoliday.Name = "btnSetHoliday"
        Me.btnSetHoliday.Size = New System.Drawing.Size(75, 23)
        Me.btnSetHoliday.TabIndex = 1
        Me.btnSetHoliday.Text = "SetHoliday"
        Me.btnSetHoliday.UseVisualStyleBackColor = True
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = Global.Device.My.Resources.Resources.top955
        Me.pictureBox1.Location = New System.Drawing.Point(-1, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(952, 30)
        Me.pictureBox1.TabIndex = 10
        Me.pictureBox1.TabStop = False
        '
        'Device
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(951, 415)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.MinimizeBox = False
        Me.Name = "Device"
        Me.Text = "Device Management"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.tabPage3.ResumeLayout(False)
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.tabControl6.ResumeLayout(False)
        Me.tabPage4.ResumeLayout(False)
        Me.tabPage4.PerformLayout()
        Me.tabPage5.ResumeLayout(False)
        Me.tabPage5.PerformLayout()
        Me.tabPage6.ResumeLayout(False)
        Me.tabPage6.PerformLayout()
        Me.tabPage7.ResumeLayout(False)
        Me.tabPage7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.tabControl4.ResumeLayout(False)
        Me.tabPage8.ResumeLayout(False)
        Me.tabPage8.PerformLayout()
        Me.tabPage9.ResumeLayout(False)
        Me.tabPage9.PerformLayout()
        Me.tabPage10.ResumeLayout(False)
        Me.tabPage10.PerformLayout()
        Me.tabPage11.ResumeLayout(False)
        Me.tabPage11.PerformLayout()
        Me.tabControl3.ResumeLayout(False)
        Me.tabPage12.ResumeLayout(False)
        Me.tabPage12.PerformLayout()
        Me.tabPage13.ResumeLayout(False)
        Me.tabPage13.PerformLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents txtIP As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents btnConnect As System.Windows.Forms.Button
    Private WithEvents txtPort As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents cbBaudRate As System.Windows.Forms.ComboBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtMachineSN As System.Windows.Forms.TextBox
    Private WithEvents cbPort As System.Windows.Forms.ComboBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents btnRsConnect As System.Windows.Forms.Button
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents rbVUSB As System.Windows.Forms.RadioButton
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents txtMachineSN2 As System.Windows.Forms.TextBox
    Private WithEvents btnUSBConnect As System.Windows.Forms.Button
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents rbUSB As System.Windows.Forms.RadioButton
    Private WithEvents lblState As System.Windows.Forms.Label
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents tabControl6 As System.Windows.Forms.TabControl
    Private WithEvents tabPage4 As System.Windows.Forms.TabPage
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents btnGetPlatform As System.Windows.Forms.Button
    Private WithEvents btnGetDeviceStrInfo As System.Windows.Forms.Button
    Private WithEvents btnGetSerialNumber As System.Windows.Forms.Button
    Private WithEvents btnGetCardFun As System.Windows.Forms.Button
    Private WithEvents btnGetDeviceIP As System.Windows.Forms.Button
    Private WithEvents btnQueryState As System.Windows.Forms.Button
    Private WithEvents btnGetVendor As System.Windows.Forms.Button
    Private WithEvents txtShow As System.Windows.Forms.TextBox
    Private WithEvents btnGetFirmwareVersion As System.Windows.Forms.Button
    Private WithEvents btnGetProductCode As System.Windows.Forms.Button
    Private WithEvents btnGetDeviceMAC As System.Windows.Forms.Button
    Private WithEvents btnGetSysOption As System.Windows.Forms.Button
    Private WithEvents btnGetSDKVersion As System.Windows.Forms.Button
    Private WithEvents tabPage5 As System.Windows.Forms.TabPage
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents btnSetSysOption As System.Windows.Forms.Button
    Private WithEvents btnSetDeviceCommPwd As System.Windows.Forms.Button
    Private WithEvents btnSetDeviceMAC As System.Windows.Forms.Button
    Private WithEvents txtSet As System.Windows.Forms.TextBox
    Private WithEvents btnSetCommPassword As System.Windows.Forms.Button
    Private WithEvents btnSetDeviceIP As System.Windows.Forms.Button
    Private WithEvents tabPage6 As System.Windows.Forms.TabPage
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents cbSetDeviceInfo As System.Windows.Forms.ComboBox
    Private WithEvents cbStatus As System.Windows.Forms.ComboBox
    Private WithEvents txtGetDeviceStatus As System.Windows.Forms.TextBox
    Private WithEvents btnGetDeviceStatus As System.Windows.Forms.Button
    Private WithEvents cbInfo2 As System.Windows.Forms.ComboBox
    Private WithEvents txtGetDeviceInfo As System.Windows.Forms.TextBox
    Private WithEvents cbInfo1 As System.Windows.Forms.ComboBox
    Private WithEvents btnSetDeviceInfo As System.Windows.Forms.Button
    Private WithEvents btnGetDeviceInfo As System.Windows.Forms.Button
    Private WithEvents tabPage7 As System.Windows.Forms.TabPage
    Private WithEvents label33 As System.Windows.Forms.Label
    Private WithEvents label32 As System.Windows.Forms.Label
    Private WithEvents btnPowerOffDevice As System.Windows.Forms.Button
    Private WithEvents btnDisableDeviceWithTimeOut As System.Windows.Forms.Button
    Private WithEvents btnRestartDevice As System.Windows.Forms.Button
    Private WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Private WithEvents tabControl4 As System.Windows.Forms.TabControl
    Private WithEvents tabPage8 As System.Windows.Forms.TabPage
    Private WithEvents label19 As System.Windows.Forms.Label
    Private WithEvents btnGetDeviceTime As System.Windows.Forms.Button
    Private WithEvents btnSetDeviceTime As System.Windows.Forms.Button
    Private WithEvents cbSecond As System.Windows.Forms.ComboBox
    Private WithEvents cbMonth As System.Windows.Forms.ComboBox
    Private WithEvents cbMinute As System.Windows.Forms.ComboBox
    Private WithEvents btnSetDeviceTime2 As System.Windows.Forms.Button
    Private WithEvents txtGetDeviceTime As System.Windows.Forms.TextBox
    Private WithEvents cbDay As System.Windows.Forms.ComboBox
    Private WithEvents cbHour As System.Windows.Forms.ComboBox
    Private WithEvents cbYear As System.Windows.Forms.ComboBox
    Private WithEvents tabPage9 As System.Windows.Forms.TabPage
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents cbIndex As System.Windows.Forms.ComboBox
    Private WithEvents label29 As System.Windows.Forms.Label
    Private WithEvents cbPosition As System.Windows.Forms.ComboBox
    Private WithEvents cbLength As System.Windows.Forms.ComboBox
    Private WithEvents btnPlayVoice As System.Windows.Forms.Button
    Private WithEvents btnPlayVoiceByIndex As System.Windows.Forms.Button
    Private WithEvents label30 As System.Windows.Forms.Label
    Private WithEvents tabPage10 As System.Windows.Forms.TabPage
    Private WithEvents label21 As System.Windows.Forms.Label
    Private WithEvents cbRow As System.Windows.Forms.ComboBox
    Private WithEvents cbCol As System.Windows.Forms.ComboBox
    Private WithEvents btnWriteLCD As System.Windows.Forms.Button
    Private WithEvents btnClearLCD As System.Windows.Forms.Button
    Private WithEvents label25 As System.Windows.Forms.Label
    Private WithEvents label27 As System.Windows.Forms.Label
    Private WithEvents label26 As System.Windows.Forms.Label
    Private WithEvents txtText As System.Windows.Forms.TextBox
    Private WithEvents tabPage11 As System.Windows.Forms.TabPage
    Private WithEvents label22 As System.Windows.Forms.Label
    Private WithEvents label37 As System.Windows.Forms.Label
    Private WithEvents label38 As System.Windows.Forms.Label
    Private WithEvents label39 As System.Windows.Forms.Label
    Private WithEvents txtEndTime As System.Windows.Forms.TextBox
    Private WithEvents btnSetDaylight As System.Windows.Forms.Button
    Private WithEvents cbSupport As System.Windows.Forms.ComboBox
    Private WithEvents txtBeginTime As System.Windows.Forms.TextBox
    Private WithEvents btnGetDaylight As System.Windows.Forms.Button
    Private WithEvents tabControl3 As System.Windows.Forms.TabControl
    Private WithEvents tabPage12 As System.Windows.Forms.TabPage
    Private WithEvents label49 As System.Windows.Forms.Label
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents label48 As System.Windows.Forms.Label
    Private WithEvents btnGetWorkCode As System.Windows.Forms.Button
    Private WithEvents btnSetWorkCode As System.Windows.Forms.Button
    Private WithEvents cbAWorkCode As System.Windows.Forms.ComboBox
    Private WithEvents btnClearWorkCode As System.Windows.Forms.Button
    Private WithEvents btnDeleteWorkCode As System.Windows.Forms.Button
    Private WithEvents cbWorkCodeID As System.Windows.Forms.ComboBox
    Private WithEvents tabPage13 As System.Windows.Forms.TabPage
    Private WithEvents label31 As System.Windows.Forms.Label
    Private WithEvents label24 As System.Windows.Forms.Label
    Private WithEvents txtHoliday As System.Windows.Forms.TextBox
    Private WithEvents btnGetHoliday As System.Windows.Forms.Button
    Private WithEvents btnSetHoliday As System.Windows.Forms.Button

End Class
