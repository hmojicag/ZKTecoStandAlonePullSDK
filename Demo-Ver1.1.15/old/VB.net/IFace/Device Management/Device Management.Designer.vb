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
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.tabControl6 = New System.Windows.Forms.TabControl
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.label11 = New System.Windows.Forms.Label
        Me.btnGetPlatform = New System.Windows.Forms.Button
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
        Me.TabPage6 = New System.Windows.Forms.TabPage
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
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.label19 = New System.Windows.Forms.Label
        Me.btnGetDeviceTime = New System.Windows.Forms.Button
        Me.cbYear = New System.Windows.Forms.ComboBox
        Me.btnSetDeviceTime = New System.Windows.Forms.Button
        Me.cbHour = New System.Windows.Forms.ComboBox
        Me.cbSecond = New System.Windows.Forms.ComboBox
        Me.cbDay = New System.Windows.Forms.ComboBox
        Me.cbMonth = New System.Windows.Forms.ComboBox
        Me.txtGetDeviceTime = New System.Windows.Forms.TextBox
        Me.cbMinute = New System.Windows.Forms.ComboBox
        Me.btnSetDeviceTime2 = New System.Windows.Forms.Button
        Me.TabPage8 = New System.Windows.Forms.TabPage
        Me.label20 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label30 = New System.Windows.Forms.Label
        Me.cbIndex = New System.Windows.Forms.ComboBox
        Me.btnPlayVoiceByIndex = New System.Windows.Forms.Button
        Me.label29 = New System.Windows.Forms.Label
        Me.btnPlayVoice = New System.Windows.Forms.Button
        Me.cbPosition = New System.Windows.Forms.ComboBox
        Me.cbLength = New System.Windows.Forms.ComboBox
        Me.TabPage9 = New System.Windows.Forms.TabPage
        Me.label33 = New System.Windows.Forms.Label
        Me.btnPowerOffDevice = New System.Windows.Forms.Button
        Me.btnRestartDevice = New System.Windows.Forms.Button
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
        Me.lblState = New System.Windows.Forms.Label
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.tabControl6.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = Global.Device.My.Resources.Resources.top485
        Me.pictureBox1.Location = New System.Drawing.Point(-1, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(486, 30)
        Me.pictureBox1.TabIndex = 10
        Me.pictureBox1.TabStop = False
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.tabControl6)
        Me.groupBox1.Location = New System.Drawing.Point(12, 192)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(461, 208)
        Me.groupBox1.TabIndex = 74
        Me.groupBox1.TabStop = False
        '
        'tabControl6
        '
        Me.tabControl6.Controls.Add(Me.TabPage4)
        Me.tabControl6.Controls.Add(Me.TabPage6)
        Me.tabControl6.Controls.Add(Me.TabPage7)
        Me.tabControl6.Controls.Add(Me.TabPage8)
        Me.tabControl6.Controls.Add(Me.TabPage9)
        Me.tabControl6.Location = New System.Drawing.Point(6, 14)
        Me.tabControl6.Name = "tabControl6"
        Me.tabControl6.SelectedIndex = 0
        Me.tabControl6.Size = New System.Drawing.Size(452, 185)
        Me.tabControl6.TabIndex = 72
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.label11)
        Me.TabPage4.Controls.Add(Me.btnGetPlatform)
        Me.TabPage4.Controls.Add(Me.btnGetSerialNumber)
        Me.TabPage4.Controls.Add(Me.btnGetCardFun)
        Me.TabPage4.Controls.Add(Me.btnGetDeviceIP)
        Me.TabPage4.Controls.Add(Me.btnQueryState)
        Me.TabPage4.Controls.Add(Me.btnGetVendor)
        Me.TabPage4.Controls.Add(Me.txtShow)
        Me.TabPage4.Controls.Add(Me.btnGetFirmwareVersion)
        Me.TabPage4.Controls.Add(Me.btnGetProductCode)
        Me.TabPage4.Controls.Add(Me.btnGetDeviceMAC)
        Me.TabPage4.Controls.Add(Me.btnGetSysOption)
        Me.TabPage4.Controls.Add(Me.btnGetSDKVersion)
        Me.TabPage4.Location = New System.Drawing.Point(4, 21)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(444, 160)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "GetOptions"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.ForeColor = System.Drawing.Color.Red
        Me.label11.Location = New System.Drawing.Point(15, 13)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(161, 12)
        Me.label11.TabIndex = 73
        Me.label11.Text = "Get the device parameters."
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
        'btnGetSerialNumber
        '
        Me.btnGetSerialNumber.Location = New System.Drawing.Point(14, 67)
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
        Me.btnGetDeviceIP.Location = New System.Drawing.Point(14, 97)
        Me.btnGetDeviceIP.Name = "btnGetDeviceIP"
        Me.btnGetDeviceIP.Size = New System.Drawing.Size(122, 23)
        Me.btnGetDeviceIP.TabIndex = 9
        Me.btnGetDeviceIP.Text = "GetDeviceIP"
        Me.btnGetDeviceIP.UseVisualStyleBackColor = True
        '
        'btnQueryState
        '
        Me.btnQueryState.Location = New System.Drawing.Point(247, 97)
        Me.btnQueryState.Name = "btnQueryState"
        Me.btnQueryState.Size = New System.Drawing.Size(92, 23)
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
        Me.btnGetFirmwareVersion.Location = New System.Drawing.Point(14, 39)
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
        Me.btnGetSDKVersion.Location = New System.Drawing.Point(142, 97)
        Me.btnGetSDKVersion.Name = "btnGetSDKVersion"
        Me.btnGetSDKVersion.Size = New System.Drawing.Size(98, 23)
        Me.btnGetSDKVersion.TabIndex = 3
        Me.btnGetSDKVersion.Text = "GetSDKVersion"
        Me.btnGetSDKVersion.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.label18)
        Me.TabPage6.Controls.Add(Me.label17)
        Me.TabPage6.Controls.Add(Me.cbSetDeviceInfo)
        Me.TabPage6.Controls.Add(Me.cbStatus)
        Me.TabPage6.Controls.Add(Me.txtGetDeviceStatus)
        Me.TabPage6.Controls.Add(Me.btnGetDeviceStatus)
        Me.TabPage6.Controls.Add(Me.cbInfo2)
        Me.TabPage6.Controls.Add(Me.txtGetDeviceInfo)
        Me.TabPage6.Controls.Add(Me.cbInfo1)
        Me.TabPage6.Controls.Add(Me.btnSetDeviceInfo)
        Me.TabPage6.Controls.Add(Me.btnGetDeviceInfo)
        Me.TabPage6.Location = New System.Drawing.Point(4, 21)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(444, 160)
        Me.TabPage6.TabIndex = 2
        Me.TabPage6.Text = "Status"
        Me.TabPage6.UseVisualStyleBackColor = True
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
        Me.cbSetDeviceInfo.Location = New System.Drawing.Point(235, 93)
        Me.cbSetDeviceInfo.Name = "cbSetDeviceInfo"
        Me.cbSetDeviceInfo.Size = New System.Drawing.Size(75, 20)
        Me.cbSetDeviceInfo.TabIndex = 25
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
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
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.label19)
        Me.TabPage7.Controls.Add(Me.btnGetDeviceTime)
        Me.TabPage7.Controls.Add(Me.cbYear)
        Me.TabPage7.Controls.Add(Me.btnSetDeviceTime)
        Me.TabPage7.Controls.Add(Me.cbHour)
        Me.TabPage7.Controls.Add(Me.cbSecond)
        Me.TabPage7.Controls.Add(Me.cbDay)
        Me.TabPage7.Controls.Add(Me.cbMonth)
        Me.TabPage7.Controls.Add(Me.txtGetDeviceTime)
        Me.TabPage7.Controls.Add(Me.cbMinute)
        Me.TabPage7.Controls.Add(Me.btnSetDeviceTime2)
        Me.TabPage7.Location = New System.Drawing.Point(4, 21)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(444, 160)
        Me.TabPage7.TabIndex = 4
        Me.TabPage7.Text = "DeviceTime"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'label19
        '
        Me.label19.AutoSize = True
        Me.label19.ForeColor = System.Drawing.Color.Red
        Me.label19.Location = New System.Drawing.Point(15, 13)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(209, 12)
        Me.label19.TabIndex = 75
        Me.label19.Text = "Get or set the time of the device."
        '
        'btnGetDeviceTime
        '
        Me.btnGetDeviceTime.Location = New System.Drawing.Point(151, 43)
        Me.btnGetDeviceTime.Name = "btnGetDeviceTime"
        Me.btnGetDeviceTime.Size = New System.Drawing.Size(95, 23)
        Me.btnGetDeviceTime.TabIndex = 1
        Me.btnGetDeviceTime.Text = "GetDeviceTime"
        Me.btnGetDeviceTime.UseVisualStyleBackColor = True
        '
        'cbYear
        '
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(9, 80)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(60, 20)
        Me.cbYear.TabIndex = 3
        Me.cbYear.Text = "2009"
        '
        'btnSetDeviceTime
        '
        Me.btnSetDeviceTime.Location = New System.Drawing.Point(8, 42)
        Me.btnSetDeviceTime.Name = "btnSetDeviceTime"
        Me.btnSetDeviceTime.Size = New System.Drawing.Size(95, 23)
        Me.btnSetDeviceTime.TabIndex = 0
        Me.btnSetDeviceTime.Text = "SetDeviceTime"
        Me.btnSetDeviceTime.UseVisualStyleBackColor = True
        '
        'cbHour
        '
        Me.cbHour.FormattingEnabled = True
        Me.cbHour.Location = New System.Drawing.Point(175, 81)
        Me.cbHour.Name = "cbHour"
        Me.cbHour.Size = New System.Drawing.Size(41, 20)
        Me.cbHour.TabIndex = 6
        Me.cbHour.Text = "8"
        '
        'cbSecond
        '
        Me.cbSecond.FormattingEnabled = True
        Me.cbSecond.Location = New System.Drawing.Point(273, 81)
        Me.cbSecond.Name = "cbSecond"
        Me.cbSecond.Size = New System.Drawing.Size(41, 20)
        Me.cbSecond.TabIndex = 8
        Me.cbSecond.Text = "8"
        '
        'cbDay
        '
        Me.cbDay.FormattingEnabled = True
        Me.cbDay.Location = New System.Drawing.Point(126, 80)
        Me.cbDay.Name = "cbDay"
        Me.cbDay.Size = New System.Drawing.Size(41, 20)
        Me.cbDay.TabIndex = 5
        Me.cbDay.Text = "31"
        '
        'cbMonth
        '
        Me.cbMonth.DisplayMember = "Month"
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(77, 80)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(41, 20)
        Me.cbMonth.TabIndex = 4
        Me.cbMonth.Text = "12"
        '
        'txtGetDeviceTime
        '
        Me.txtGetDeviceTime.Location = New System.Drawing.Point(277, 42)
        Me.txtGetDeviceTime.Name = "txtGetDeviceTime"
        Me.txtGetDeviceTime.ReadOnly = True
        Me.txtGetDeviceTime.Size = New System.Drawing.Size(156, 21)
        Me.txtGetDeviceTime.TabIndex = 2
        '
        'cbMinute
        '
        Me.cbMinute.FormattingEnabled = True
        Me.cbMinute.Location = New System.Drawing.Point(224, 81)
        Me.cbMinute.Name = "cbMinute"
        Me.cbMinute.Size = New System.Drawing.Size(41, 20)
        Me.cbMinute.TabIndex = 7
        Me.cbMinute.Text = "8"
        '
        'btnSetDeviceTime2
        '
        Me.btnSetDeviceTime2.Location = New System.Drawing.Point(322, 79)
        Me.btnSetDeviceTime2.Name = "btnSetDeviceTime2"
        Me.btnSetDeviceTime2.Size = New System.Drawing.Size(114, 23)
        Me.btnSetDeviceTime2.TabIndex = 9
        Me.btnSetDeviceTime2.Text = "SetDeviceTime2"
        Me.btnSetDeviceTime2.UseVisualStyleBackColor = True
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.label20)
        Me.TabPage8.Controls.Add(Me.label3)
        Me.TabPage8.Controls.Add(Me.label30)
        Me.TabPage8.Controls.Add(Me.cbIndex)
        Me.TabPage8.Controls.Add(Me.btnPlayVoiceByIndex)
        Me.TabPage8.Controls.Add(Me.label29)
        Me.TabPage8.Controls.Add(Me.btnPlayVoice)
        Me.TabPage8.Controls.Add(Me.cbPosition)
        Me.TabPage8.Controls.Add(Me.cbLength)
        Me.TabPage8.Location = New System.Drawing.Point(4, 21)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(444, 160)
        Me.TabPage8.TabIndex = 5
        Me.TabPage8.Text = "Voice"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.ForeColor = System.Drawing.Color.Red
        Me.label20.Location = New System.Drawing.Point(15, 13)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(233, 12)
        Me.label20.TabIndex = 76
        Me.label20.Text = "Play a series of wav or play by index."
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(25, 45)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(35, 12)
        Me.label3.TabIndex = 24
        Me.label3.Text = "Index"
        '
        'label30
        '
        Me.label30.AutoSize = True
        Me.label30.Location = New System.Drawing.Point(139, 79)
        Me.label30.Name = "label30"
        Me.label30.Size = New System.Drawing.Size(41, 12)
        Me.label30.TabIndex = 22
        Me.label30.Text = "Length"
        '
        'cbIndex
        '
        Me.cbIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbIndex.FormattingEnabled = True
        Me.cbIndex.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"})
        Me.cbIndex.Location = New System.Drawing.Point(80, 41)
        Me.cbIndex.Name = "cbIndex"
        Me.cbIndex.Size = New System.Drawing.Size(44, 20)
        Me.cbIndex.TabIndex = 23
        '
        'btnPlayVoiceByIndex
        '
        Me.btnPlayVoiceByIndex.Location = New System.Drawing.Point(141, 40)
        Me.btnPlayVoiceByIndex.Name = "btnPlayVoiceByIndex"
        Me.btnPlayVoiceByIndex.Size = New System.Drawing.Size(125, 23)
        Me.btnPlayVoiceByIndex.TabIndex = 18
        Me.btnPlayVoiceByIndex.Text = "PlayVoiceByIndex"
        Me.btnPlayVoiceByIndex.UseVisualStyleBackColor = True
        '
        'label29
        '
        Me.label29.AutoSize = True
        Me.label29.Location = New System.Drawing.Point(17, 79)
        Me.label29.Name = "label29"
        Me.label29.Size = New System.Drawing.Size(53, 12)
        Me.label29.TabIndex = 21
        Me.label29.Text = "Position"
        '
        'btnPlayVoice
        '
        Me.btnPlayVoice.Location = New System.Drawing.Point(248, 74)
        Me.btnPlayVoice.Name = "btnPlayVoice"
        Me.btnPlayVoice.Size = New System.Drawing.Size(75, 23)
        Me.btnPlayVoice.TabIndex = 17
        Me.btnPlayVoice.Text = "PlayVoice"
        Me.btnPlayVoice.UseVisualStyleBackColor = True
        '
        'cbPosition
        '
        Me.cbPosition.FormattingEnabled = True
        Me.cbPosition.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"})
        Me.cbPosition.Location = New System.Drawing.Point(78, 76)
        Me.cbPosition.Name = "cbPosition"
        Me.cbPosition.Size = New System.Drawing.Size(46, 20)
        Me.cbPosition.TabIndex = 9
        '
        'cbLength
        '
        Me.cbLength.FormattingEnabled = True
        Me.cbLength.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"})
        Me.cbLength.Location = New System.Drawing.Point(187, 75)
        Me.cbLength.Name = "cbLength"
        Me.cbLength.Size = New System.Drawing.Size(46, 20)
        Me.cbLength.TabIndex = 19
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.label33)
        Me.TabPage9.Controls.Add(Me.btnPowerOffDevice)
        Me.TabPage9.Controls.Add(Me.btnRestartDevice)
        Me.TabPage9.Location = New System.Drawing.Point(4, 21)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(444, 160)
        Me.TabPage9.TabIndex = 3
        Me.TabPage9.Text = "Control"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'label33
        '
        Me.label33.AutoSize = True
        Me.label33.ForeColor = System.Drawing.Color.Red
        Me.label33.Location = New System.Drawing.Point(15, 13)
        Me.label33.Name = "label33"
        Me.label33.Size = New System.Drawing.Size(191, 12)
        Me.label33.TabIndex = 77
        Me.label33.Text = "Restart or Poweroff the device."
        '
        'btnPowerOffDevice
        '
        Me.btnPowerOffDevice.Location = New System.Drawing.Point(182, 40)
        Me.btnPowerOffDevice.Name = "btnPowerOffDevice"
        Me.btnPowerOffDevice.Size = New System.Drawing.Size(97, 23)
        Me.btnPowerOffDevice.TabIndex = 6
        Me.btnPowerOffDevice.Text = "PowerOffDevice"
        Me.btnPowerOffDevice.UseVisualStyleBackColor = True
        '
        'btnRestartDevice
        '
        Me.btnRestartDevice.Location = New System.Drawing.Point(16, 40)
        Me.btnRestartDevice.Name = "btnRestartDevice"
        Me.btnRestartDevice.Size = New System.Drawing.Size(94, 23)
        Me.btnRestartDevice.TabIndex = 3
        Me.btnRestartDevice.Text = "RestartDevice"
        Me.btnRestartDevice.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.tabControl1)
        Me.groupBox2.Controls.Add(Me.lblState)
        Me.groupBox2.Location = New System.Drawing.Point(12, 40)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(461, 146)
        Me.groupBox2.TabIndex = 73
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Communication with Device"
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
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
        'Device
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(485, 410)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.pictureBox1)
        Me.MinimizeBox = False
        Me.Name = "Device"
        Me.Text = "Device Management"
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.tabControl6.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage9.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents tabControl6 As System.Windows.Forms.TabControl
    Private WithEvents TabPage4 As System.Windows.Forms.TabPage
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents btnGetPlatform As System.Windows.Forms.Button
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
    Private WithEvents TabPage6 As System.Windows.Forms.TabPage
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
    Private WithEvents TabPage7 As System.Windows.Forms.TabPage
    Private WithEvents label19 As System.Windows.Forms.Label
    Private WithEvents btnGetDeviceTime As System.Windows.Forms.Button
    Private WithEvents cbYear As System.Windows.Forms.ComboBox
    Private WithEvents btnSetDeviceTime As System.Windows.Forms.Button
    Private WithEvents cbHour As System.Windows.Forms.ComboBox
    Private WithEvents cbSecond As System.Windows.Forms.ComboBox
    Private WithEvents cbDay As System.Windows.Forms.ComboBox
    Private WithEvents cbMonth As System.Windows.Forms.ComboBox
    Private WithEvents txtGetDeviceTime As System.Windows.Forms.TextBox
    Private WithEvents cbMinute As System.Windows.Forms.ComboBox
    Private WithEvents btnSetDeviceTime2 As System.Windows.Forms.Button
    Private WithEvents TabPage8 As System.Windows.Forms.TabPage
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label30 As System.Windows.Forms.Label
    Private WithEvents cbIndex As System.Windows.Forms.ComboBox
    Private WithEvents btnPlayVoiceByIndex As System.Windows.Forms.Button
    Private WithEvents label29 As System.Windows.Forms.Label
    Private WithEvents btnPlayVoice As System.Windows.Forms.Button
    Private WithEvents cbPosition As System.Windows.Forms.ComboBox
    Private WithEvents cbLength As System.Windows.Forms.ComboBox
    Private WithEvents TabPage9 As System.Windows.Forms.TabPage
    Private WithEvents label33 As System.Windows.Forms.Label
    Private WithEvents btnPowerOffDevice As System.Windows.Forms.Button
    Private WithEvents btnRestartDevice As System.Windows.Forms.Button
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
    Private WithEvents lblState As System.Windows.Forms.Label

End Class
