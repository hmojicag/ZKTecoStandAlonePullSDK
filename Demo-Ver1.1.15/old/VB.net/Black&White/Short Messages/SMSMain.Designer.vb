<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShortMessages
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
        Me.components = New System.ComponentModel.Container
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
        Me.groupBox9 = New System.Windows.Forms.GroupBox
        Me.cbUserID2 = New System.Windows.Forms.ComboBox
        Me.label20 = New System.Windows.Forms.Label
        Me.cbID2 = New System.Windows.Forms.ComboBox
        Me.btnDeleteUserSMS = New System.Windows.Forms.Button
        Me.label21 = New System.Windows.Forms.Label
        Me.btnDeleteSMS = New System.Windows.Forms.Button
        Me.groupBox11 = New System.Windows.Forms.GroupBox
        Me.cbSMSID = New System.Windows.Forms.ComboBox
        Me.cbTag = New System.Windows.Forms.ComboBox
        Me.label16 = New System.Windows.Forms.Label
        Me.label15 = New System.Windows.Forms.Label
        Me.btnGetSMS = New System.Windows.Forms.Button
        Me.label17 = New System.Windows.Forms.Label
        Me.btnSetSMS = New System.Windows.Forms.Button
        Me.label14 = New System.Windows.Forms.Label
        Me.label18 = New System.Windows.Forms.Label
        Me.txtValidMins = New System.Windows.Forms.TextBox
        Me.txtContent = New System.Windows.Forms.TextBox
        Me.txtStartTime = New System.Windows.Forms.TextBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.cbUserID = New System.Windows.Forms.ComboBox
        Me.btnSetUserSMS = New System.Windows.Forms.Button
        Me.label23 = New System.Windows.Forms.Label
        Me.label22 = New System.Windows.Forms.Label
        Me.cbID = New System.Windows.Forms.ComboBox
        Me.groupBox10 = New System.Windows.Forms.GroupBox
        Me.btnClearSMS = New System.Windows.Forms.Button
        Me.btnClearUserSMS = New System.Windows.Forms.Button
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.UserIDTimer = New System.Windows.Forms.Timer(Me.components)
        Me.groupBox2.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox9.SuspendLayout()
        Me.groupBox11.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox10.SuspendLayout()
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
        'groupBox9
        '
        Me.groupBox9.Controls.Add(Me.cbUserID2)
        Me.groupBox9.Controls.Add(Me.label20)
        Me.groupBox9.Controls.Add(Me.cbID2)
        Me.groupBox9.Controls.Add(Me.btnDeleteUserSMS)
        Me.groupBox9.Controls.Add(Me.label21)
        Me.groupBox9.Controls.Add(Me.btnDeleteSMS)
        Me.groupBox9.Location = New System.Drawing.Point(8, 193)
        Me.groupBox9.Name = "groupBox9"
        Me.groupBox9.Size = New System.Drawing.Size(461, 60)
        Me.groupBox9.TabIndex = 45
        Me.groupBox9.TabStop = False
        Me.groupBox9.Text = "Delete SMS or User's SMS"
        '
        'cbUserID2
        '
        Me.cbUserID2.FormattingEnabled = True
        Me.cbUserID2.Location = New System.Drawing.Point(191, 23)
        Me.cbUserID2.Name = "cbUserID2"
        Me.cbUserID2.Size = New System.Drawing.Size(70, 20)
        Me.cbUserID2.TabIndex = 40
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Location = New System.Drawing.Point(9, 27)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(35, 12)
        Me.label20.TabIndex = 10
        Me.label20.Text = "SMSID"
        '
        'cbID2
        '
        Me.cbID2.FormattingEnabled = True
        Me.cbID2.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cbID2.Location = New System.Drawing.Point(50, 23)
        Me.cbID2.Name = "cbID2"
        Me.cbID2.Size = New System.Drawing.Size(52, 20)
        Me.cbID2.TabIndex = 5
        '
        'btnDeleteUserSMS
        '
        Me.btnDeleteUserSMS.Location = New System.Drawing.Point(348, 22)
        Me.btnDeleteUserSMS.Name = "btnDeleteUserSMS"
        Me.btnDeleteUserSMS.Size = New System.Drawing.Size(99, 23)
        Me.btnDeleteUserSMS.TabIndex = 6
        Me.btnDeleteUserSMS.Text = "DeleteUserSMS"
        Me.btnDeleteUserSMS.UseVisualStyleBackColor = True
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Location = New System.Drawing.Point(108, 27)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(77, 12)
        Me.label21.TabIndex = 39
        Me.label21.Text = "EnrollNumber"
        '
        'btnDeleteSMS
        '
        Me.btnDeleteSMS.Location = New System.Drawing.Point(267, 22)
        Me.btnDeleteSMS.Name = "btnDeleteSMS"
        Me.btnDeleteSMS.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteSMS.TabIndex = 7
        Me.btnDeleteSMS.Text = "DeleteSMS"
        Me.btnDeleteSMS.UseVisualStyleBackColor = True
        '
        'groupBox11
        '
        Me.groupBox11.Controls.Add(Me.cbSMSID)
        Me.groupBox11.Controls.Add(Me.cbTag)
        Me.groupBox11.Controls.Add(Me.label16)
        Me.groupBox11.Controls.Add(Me.label15)
        Me.groupBox11.Controls.Add(Me.btnGetSMS)
        Me.groupBox11.Controls.Add(Me.label17)
        Me.groupBox11.Controls.Add(Me.btnSetSMS)
        Me.groupBox11.Controls.Add(Me.label14)
        Me.groupBox11.Controls.Add(Me.label18)
        Me.groupBox11.Controls.Add(Me.txtValidMins)
        Me.groupBox11.Controls.Add(Me.txtContent)
        Me.groupBox11.Controls.Add(Me.txtStartTime)
        Me.groupBox11.Location = New System.Drawing.Point(480, 40)
        Me.groupBox11.Name = "groupBox11"
        Me.groupBox11.Size = New System.Drawing.Size(388, 105)
        Me.groupBox11.TabIndex = 47
        Me.groupBox11.TabStop = False
        Me.groupBox11.Text = "Get or Set Short Messages"
        '
        'cbSMSID
        '
        Me.cbSMSID.FormattingEnabled = True
        Me.cbSMSID.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cbSMSID.Location = New System.Drawing.Point(59, 19)
        Me.cbSMSID.Name = "cbSMSID"
        Me.cbSMSID.Size = New System.Drawing.Size(39, 20)
        Me.cbSMSID.TabIndex = 13
        Me.cbSMSID.Text = "1"
        '
        'cbTag
        '
        Me.cbTag.FormattingEnabled = True
        Me.cbTag.Items.AddRange(New Object() {"253.Public", "254.Personal", "255.Reserved"})
        Me.cbTag.Location = New System.Drawing.Point(133, 20)
        Me.cbTag.Name = "cbTag"
        Me.cbTag.Size = New System.Drawing.Size(88, 20)
        Me.cbTag.TabIndex = 12
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(21, 24)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(35, 12)
        Me.label16.TabIndex = 9
        Me.label16.Text = "SMSID"
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Location = New System.Drawing.Point(104, 22)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(23, 12)
        Me.label15.TabIndex = 8
        Me.label15.Text = "Tag"
        '
        'btnGetSMS
        '
        Me.btnGetSMS.Location = New System.Drawing.Point(305, 75)
        Me.btnGetSMS.Name = "btnGetSMS"
        Me.btnGetSMS.Size = New System.Drawing.Size(62, 23)
        Me.btnGetSMS.TabIndex = 2
        Me.btnGetSMS.Text = "GetSMS"
        Me.btnGetSMS.UseVisualStyleBackColor = True
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Location = New System.Drawing.Point(21, 51)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(59, 12)
        Me.label17.TabIndex = 10
        Me.label17.Text = "StartTime"
        '
        'btnSetSMS
        '
        Me.btnSetSMS.Location = New System.Drawing.Point(306, 45)
        Me.btnSetSMS.Name = "btnSetSMS"
        Me.btnSetSMS.Size = New System.Drawing.Size(61, 23)
        Me.btnSetSMS.TabIndex = 0
        Me.btnSetSMS.Text = "SetSMS"
        Me.btnSetSMS.UseVisualStyleBackColor = True
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Location = New System.Drawing.Point(227, 24)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(77, 12)
        Me.label14.TabIndex = 7
        Me.label14.Text = "ValidMinutes"
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Location = New System.Drawing.Point(22, 78)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(47, 12)
        Me.label18.TabIndex = 11
        Me.label18.Text = "Content"
        '
        'txtValidMins
        '
        Me.txtValidMins.Location = New System.Drawing.Point(316, 19)
        Me.txtValidMins.Name = "txtValidMins"
        Me.txtValidMins.Size = New System.Drawing.Size(51, 21)
        Me.txtValidMins.TabIndex = 4
        Me.txtValidMins.Text = "1"
        '
        'txtContent
        '
        Me.txtContent.Location = New System.Drawing.Point(87, 75)
        Me.txtContent.Name = "txtContent"
        Me.txtContent.Size = New System.Drawing.Size(182, 21)
        Me.txtContent.TabIndex = 6
        '
        'txtStartTime
        '
        Me.txtStartTime.Location = New System.Drawing.Point(87, 46)
        Me.txtStartTime.Name = "txtStartTime"
        Me.txtStartTime.Size = New System.Drawing.Size(181, 21)
        Me.txtStartTime.TabIndex = 5
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.cbUserID)
        Me.groupBox1.Controls.Add(Me.btnSetUserSMS)
        Me.groupBox1.Controls.Add(Me.label23)
        Me.groupBox1.Controls.Add(Me.label22)
        Me.groupBox1.Controls.Add(Me.cbID)
        Me.groupBox1.Location = New System.Drawing.Point(480, 193)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(388, 60)
        Me.groupBox1.TabIndex = 49
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Set Users' Short Messages"
        '
        'cbUserID
        '
        Me.cbUserID.FormattingEnabled = True
        Me.cbUserID.Location = New System.Drawing.Point(185, 22)
        Me.cbUserID.Name = "cbUserID"
        Me.cbUserID.Size = New System.Drawing.Size(84, 20)
        Me.cbUserID.TabIndex = 44
        '
        'btnSetUserSMS
        '
        Me.btnSetUserSMS.Location = New System.Drawing.Point(290, 21)
        Me.btnSetUserSMS.Name = "btnSetUserSMS"
        Me.btnSetUserSMS.Size = New System.Drawing.Size(77, 23)
        Me.btnSetUserSMS.TabIndex = 1
        Me.btnSetUserSMS.Text = "SetUserSMS"
        Me.btnSetUserSMS.UseVisualStyleBackColor = True
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Location = New System.Drawing.Point(105, 26)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(77, 12)
        Me.label23.TabIndex = 38
        Me.label23.Text = "EnrollNumber"
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.Location = New System.Drawing.Point(17, 26)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(35, 12)
        Me.label22.TabIndex = 39
        Me.label22.Text = "SMSID"
        '
        'cbID
        '
        Me.cbID.FormattingEnabled = True
        Me.cbID.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.cbID.Location = New System.Drawing.Point(59, 22)
        Me.cbID.Name = "cbID"
        Me.cbID.Size = New System.Drawing.Size(39, 20)
        Me.cbID.TabIndex = 43
        '
        'groupBox10
        '
        Me.groupBox10.Controls.Add(Me.btnClearSMS)
        Me.groupBox10.Controls.Add(Me.btnClearUserSMS)
        Me.groupBox10.Location = New System.Drawing.Point(480, 147)
        Me.groupBox10.Name = "groupBox10"
        Me.groupBox10.Size = New System.Drawing.Size(388, 43)
        Me.groupBox10.TabIndex = 48
        Me.groupBox10.TabStop = False
        Me.groupBox10.Text = "Clear"
        '
        'btnClearSMS
        '
        Me.btnClearSMS.Location = New System.Drawing.Point(23, 15)
        Me.btnClearSMS.Name = "btnClearSMS"
        Me.btnClearSMS.Size = New System.Drawing.Size(74, 23)
        Me.btnClearSMS.TabIndex = 9
        Me.btnClearSMS.Text = "ClearSMS"
        Me.btnClearSMS.UseVisualStyleBackColor = True
        '
        'btnClearUserSMS
        '
        Me.btnClearUserSMS.Location = New System.Drawing.Point(175, 15)
        Me.btnClearUserSMS.Name = "btnClearUserSMS"
        Me.btnClearUserSMS.Size = New System.Drawing.Size(94, 23)
        Me.btnClearUserSMS.TabIndex = 8
        Me.btnClearUserSMS.Text = "ClearUserSMS"
        Me.btnClearUserSMS.UseVisualStyleBackColor = True
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = Global.ShortMessages.My.Resources.Resources.top
        Me.pictureBox1.Location = New System.Drawing.Point(-1, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(875, 30)
        Me.pictureBox1.TabIndex = 10
        Me.pictureBox1.TabStop = False
        '
        'UserIDTimer
        '
        Me.UserIDTimer.Enabled = True
        '
        'ShortMessages
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(874, 263)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.groupBox10)
        Me.Controls.Add(Me.groupBox11)
        Me.Controls.Add(Me.groupBox9)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.MinimizeBox = False
        Me.Name = "ShortMessages"
        Me.Text = "Short Messages"
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
        Me.groupBox9.ResumeLayout(False)
        Me.groupBox9.PerformLayout()
        Me.groupBox11.ResumeLayout(False)
        Me.groupBox11.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox10.ResumeLayout(False)
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
    Private WithEvents groupBox9 As System.Windows.Forms.GroupBox
    Private WithEvents cbUserID2 As System.Windows.Forms.ComboBox
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents cbID2 As System.Windows.Forms.ComboBox
    Private WithEvents btnDeleteUserSMS As System.Windows.Forms.Button
    Private WithEvents label21 As System.Windows.Forms.Label
    Private WithEvents btnDeleteSMS As System.Windows.Forms.Button
    Private WithEvents groupBox11 As System.Windows.Forms.GroupBox
    Private WithEvents cbSMSID As System.Windows.Forms.ComboBox
    Private WithEvents cbTag As System.Windows.Forms.ComboBox
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents btnGetSMS As System.Windows.Forms.Button
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents btnSetSMS As System.Windows.Forms.Button
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents txtValidMins As System.Windows.Forms.TextBox
    Private WithEvents txtContent As System.Windows.Forms.TextBox
    Private WithEvents txtStartTime As System.Windows.Forms.TextBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents cbUserID As System.Windows.Forms.ComboBox
    Private WithEvents btnSetUserSMS As System.Windows.Forms.Button
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents label22 As System.Windows.Forms.Label
    Private WithEvents cbID As System.Windows.Forms.ComboBox
    Private WithEvents groupBox10 As System.Windows.Forms.GroupBox
    Private WithEvents btnClearSMS As System.Windows.Forms.Button
    Private WithEvents btnClearUserSMS As System.Windows.Forms.Button
    Private WithEvents UserIDTimer As System.Windows.Forms.Timer

End Class
