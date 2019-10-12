<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Card
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbRTShow = New System.Windows.Forms.ListBox
        Me.groupBox7 = New System.Windows.Forms.GroupBox
        Me.cbUserID = New System.Windows.Forms.ComboBox
        Me.label8 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.cbTmpToWrite = New System.Windows.Forms.ComboBox
        Me.label28 = New System.Windows.Forms.Label
        Me.btnWriteCard = New System.Windows.Forms.Button
        Me.btnEmptyCard = New System.Windows.Forms.Button
        Me.label31 = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.label4 = New System.Windows.Forms.Label
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.lvCard = New System.Windows.Forms.ListView
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.btnGetStrCardNumber = New System.Windows.Forms.Button
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.label16 = New System.Windows.Forms.Label
        Me.label15 = New System.Windows.Forms.Label
        Me.chbEnabled = New System.Windows.Forms.CheckBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.btnSetStrCardNumber = New System.Windows.Forms.Button
        Me.label89 = New System.Windows.Forms.Label
        Me.cbPrivilege = New System.Windows.Forms.ComboBox
        Me.txtCardnumber = New System.Windows.Forms.TextBox
        Me.Privilege = New System.Windows.Forms.Label
        Me.label55 = New System.Windows.Forms.Label
        Me.label90 = New System.Windows.Forms.Label
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.rtTimer = New System.Windows.Forms.Timer(Me.components)
        Me.UserIDTimer = New System.Windows.Forms.Timer(Me.components)
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
        Me.GroupBox1.SuspendLayout()
        Me.groupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbRTShow)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 193)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(461, 147)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Show the RealTime Events Related with the Card"
        '
        'lbRTShow
        '
        Me.lbRTShow.FormattingEnabled = True
        Me.lbRTShow.ItemHeight = 12
        Me.lbRTShow.Location = New System.Drawing.Point(8, 16)
        Me.lbRTShow.Name = "lbRTShow"
        Me.lbRTShow.Size = New System.Drawing.Size(445, 124)
        Me.lbRTShow.TabIndex = 4
        '
        'groupBox7
        '
        Me.groupBox7.Controls.Add(Me.cbUserID)
        Me.groupBox7.Controls.Add(Me.label8)
        Me.groupBox7.Controls.Add(Me.label3)
        Me.groupBox7.Controls.Add(Me.cbTmpToWrite)
        Me.groupBox7.Controls.Add(Me.label28)
        Me.groupBox7.Controls.Add(Me.btnWriteCard)
        Me.groupBox7.Controls.Add(Me.btnEmptyCard)
        Me.groupBox7.Controls.Add(Me.label31)
        Me.groupBox7.Location = New System.Drawing.Point(7, 348)
        Me.groupBox7.Name = "groupBox7"
        Me.groupBox7.Size = New System.Drawing.Size(462, 117)
        Me.groupBox7.TabIndex = 43
        Me.groupBox7.TabStop = False
        Me.groupBox7.Text = "Write data into Mifare Card or Empty It"
        '
        'cbUserID
        '
        Me.cbUserID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUserID.FormattingEnabled = True
        Me.cbUserID.Location = New System.Drawing.Point(55, 37)
        Me.cbUserID.Name = "cbUserID"
        Me.cbUserID.Size = New System.Drawing.Size(87, 20)
        Me.cbUserID.TabIndex = 49
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.ForeColor = System.Drawing.Color.Crimson
        Me.label8.Location = New System.Drawing.Point(11, 16)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(389, 12)
        Me.label8.TabIndex = 48
        Me.label8.Text = "Please make sure your device has an optional mifare card module."
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(11, 67)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(35, 12)
        Me.label3.TabIndex = 33
        Me.label3.Text = "Count"
        '
        'cbTmpToWrite
        '
        Me.cbTmpToWrite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTmpToWrite.FormattingEnabled = True
        Me.cbTmpToWrite.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cbTmpToWrite.Location = New System.Drawing.Point(55, 64)
        Me.cbTmpToWrite.Name = "cbTmpToWrite"
        Me.cbTmpToWrite.Size = New System.Drawing.Size(54, 20)
        Me.cbTmpToWrite.TabIndex = 32
        '
        'label28
        '
        Me.label28.AutoSize = True
        Me.label28.Location = New System.Drawing.Point(11, 40)
        Me.label28.Name = "label28"
        Me.label28.Size = New System.Drawing.Size(41, 12)
        Me.label28.TabIndex = 15
        Me.label28.Text = "UserID"
        '
        'btnWriteCard
        '
        Me.btnWriteCard.Location = New System.Drawing.Point(130, 86)
        Me.btnWriteCard.Name = "btnWriteCard"
        Me.btnWriteCard.Size = New System.Drawing.Size(75, 23)
        Me.btnWriteCard.TabIndex = 23
        Me.btnWriteCard.Text = "WriteCard"
        Me.btnWriteCard.UseVisualStyleBackColor = True
        '
        'btnEmptyCard
        '
        Me.btnEmptyCard.Location = New System.Drawing.Point(230, 86)
        Me.btnEmptyCard.Name = "btnEmptyCard"
        Me.btnEmptyCard.Size = New System.Drawing.Size(75, 23)
        Me.btnEmptyCard.TabIndex = 24
        Me.btnEmptyCard.Text = "EmptyCard"
        Me.btnEmptyCard.UseVisualStyleBackColor = True
        '
        'label31
        '
        Me.label31.AutoSize = True
        Me.label31.ForeColor = System.Drawing.Color.Crimson
        Me.label31.Location = New System.Drawing.Point(108, 67)
        Me.label31.Name = "label31"
        Me.label31.Size = New System.Drawing.Size(353, 12)
        Me.label31.TabIndex = 26
        Me.label31.Text = "(Count of Fingerprint Templates to Write into Mifare Card)"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.label4)
        Me.GroupBox8.Controls.Add(Me.GroupBox9)
        Me.GroupBox8.Controls.Add(Me.GroupBox10)
        Me.GroupBox8.Location = New System.Drawing.Point(475, 41)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(491, 424)
        Me.GroupBox8.TabIndex = 46
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Download or Upload Card Number"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.ForeColor = System.Drawing.Color.Crimson
        Me.label4.Location = New System.Drawing.Point(12, 26)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(371, 12)
        Me.label4.TabIndex = 46
        Me.label4.Text = "Please make sure your device has an optional ID card module. "
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.lvCard)
        Me.GroupBox9.Controls.Add(Me.btnGetStrCardNumber)
        Me.GroupBox9.Location = New System.Drawing.Point(6, 52)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(479, 246)
        Me.GroupBox9.TabIndex = 43
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Download the Card Number(A property of user information)"
        '
        'lvCard
        '
        Me.lvCard.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4, Me.columnHeader5, Me.columnHeader6})
        Me.lvCard.GridLines = True
        Me.lvCard.Location = New System.Drawing.Point(6, 16)
        Me.lvCard.Name = "lvCard"
        Me.lvCard.Size = New System.Drawing.Size(467, 192)
        Me.lvCard.TabIndex = 45
        Me.lvCard.UseCompatibleStateImageBehavior = False
        Me.lvCard.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "UserID"
        Me.columnHeader1.Width = 54
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Name"
        Me.columnHeader2.Width = 41
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "Cardnumber"
        Me.columnHeader3.Width = 78
        '
        'columnHeader4
        '
        Me.columnHeader4.Text = "Privilege"
        Me.columnHeader4.Width = 92
        '
        'columnHeader5
        '
        Me.columnHeader5.Text = "Password"
        Me.columnHeader5.Width = 76
        '
        'columnHeader6
        '
        Me.columnHeader6.Text = "Enabled"
        Me.columnHeader6.Width = 84
        '
        'btnGetStrCardNumber
        '
        Me.btnGetStrCardNumber.Location = New System.Drawing.Point(181, 214)
        Me.btnGetStrCardNumber.Name = "btnGetStrCardNumber"
        Me.btnGetStrCardNumber.Size = New System.Drawing.Size(117, 23)
        Me.btnGetStrCardNumber.TabIndex = 1
        Me.btnGetStrCardNumber.Text = "GetStrCardNumber"
        Me.btnGetStrCardNumber.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.txtUserID)
        Me.GroupBox10.Controls.Add(Me.txtName)
        Me.GroupBox10.Controls.Add(Me.label16)
        Me.GroupBox10.Controls.Add(Me.label15)
        Me.GroupBox10.Controls.Add(Me.chbEnabled)
        Me.GroupBox10.Controls.Add(Me.txtPassword)
        Me.GroupBox10.Controls.Add(Me.btnSetStrCardNumber)
        Me.GroupBox10.Controls.Add(Me.label89)
        Me.GroupBox10.Controls.Add(Me.cbPrivilege)
        Me.GroupBox10.Controls.Add(Me.txtCardnumber)
        Me.GroupBox10.Controls.Add(Me.Privilege)
        Me.GroupBox10.Controls.Add(Me.label55)
        Me.GroupBox10.Controls.Add(Me.label90)
        Me.GroupBox10.Location = New System.Drawing.Point(6, 304)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(479, 111)
        Me.GroupBox10.TabIndex = 44
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Upload the Card Number(part of users information)"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(90, 15)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(69, 21)
        Me.txtUserID.TabIndex = 56
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(238, 15)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(76, 21)
        Me.txtName.TabIndex = 57
        '
        'label16
        '
        Me.label16.Location = New System.Drawing.Point(40, 19)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(62, 18)
        Me.label16.TabIndex = 63
        Me.label16.Text = "User ID"
        '
        'label15
        '
        Me.label15.Location = New System.Drawing.Point(208, 20)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(36, 17)
        Me.label15.TabIndex = 64
        Me.label15.Text = "Name"
        '
        'chbEnabled
        '
        Me.chbEnabled.AutoSize = True
        Me.chbEnabled.Location = New System.Drawing.Point(383, 50)
        Me.chbEnabled.Name = "chbEnabled"
        Me.chbEnabled.Size = New System.Drawing.Size(15, 14)
        Me.chbEnabled.TabIndex = 69
        Me.chbEnabled.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(383, 15)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(67, 21)
        Me.txtPassword.TabIndex = 58
        '
        'btnSetStrCardNumber
        '
        Me.btnSetStrCardNumber.Location = New System.Drawing.Point(181, 80)
        Me.btnSetStrCardNumber.Name = "btnSetStrCardNumber"
        Me.btnSetStrCardNumber.Size = New System.Drawing.Size(117, 23)
        Me.btnSetStrCardNumber.TabIndex = 0
        Me.btnSetStrCardNumber.Text = "SetStrCardNumber"
        Me.btnSetStrCardNumber.UseVisualStyleBackColor = True
        '
        'label89
        '
        Me.label89.AutoSize = True
        Me.label89.Location = New System.Drawing.Point(332, 51)
        Me.label89.Name = "label89"
        Me.label89.Size = New System.Drawing.Size(59, 12)
        Me.label89.TabIndex = 67
        Me.label89.Text = "Enabled  "
        '
        'cbPrivilege
        '
        Me.cbPrivilege.FormattingEnabled = True
        Me.cbPrivilege.Location = New System.Drawing.Point(90, 47)
        Me.cbPrivilege.Name = "cbPrivilege"
        Me.cbPrivilege.Size = New System.Drawing.Size(69, 20)
        Me.cbPrivilege.TabIndex = 59
        '
        'txtCardnumber
        '
        Me.txtCardnumber.Location = New System.Drawing.Point(238, 47)
        Me.txtCardnumber.Name = "txtCardnumber"
        Me.txtCardnumber.Size = New System.Drawing.Size(76, 21)
        Me.txtCardnumber.TabIndex = 61
        '
        'Privilege
        '
        Me.Privilege.Location = New System.Drawing.Point(30, 50)
        Me.Privilege.Name = "Privilege"
        Me.Privilege.Size = New System.Drawing.Size(61, 19)
        Me.Privilege.TabIndex = 65
        Me.Privilege.Text = "Privilege"
        '
        'label55
        '
        Me.label55.AutoSize = True
        Me.label55.Location = New System.Drawing.Point(174, 51)
        Me.label55.Name = "label55"
        Me.label55.Size = New System.Drawing.Size(65, 12)
        Me.label55.TabIndex = 66
        Me.label55.Text = "CardNumber"
        '
        'label90
        '
        Me.label90.AutoSize = True
        Me.label90.Location = New System.Drawing.Point(327, 20)
        Me.label90.Name = "label90"
        Me.label90.Size = New System.Drawing.Size(53, 12)
        Me.label90.TabIndex = 68
        Me.label90.Text = "Password"
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = Global.Card.My.Resources.Resources.top
        Me.pictureBox1.Location = New System.Drawing.Point(-1, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(975, 30)
        Me.pictureBox1.TabIndex = 10
        Me.pictureBox1.TabStop = False
        '
        'rtTimer
        '
        Me.rtTimer.Enabled = True
        Me.rtTimer.Interval = 800
        '
        'UserIDTimer
        '
        Me.UserIDTimer.Enabled = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.tabControl1)
        Me.groupBox2.Controls.Add(Me.lblState)
        Me.groupBox2.Location = New System.Drawing.Point(8, 41)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(461, 146)
        Me.groupBox2.TabIndex = 48
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
        'Card
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(974, 474)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.groupBox7)
        Me.Controls.Add(Me.pictureBox1)
        Me.MinimizeBox = False
        Me.Name = "Card"
        Me.Text = "Card Management"
        Me.GroupBox1.ResumeLayout(False)
        Me.groupBox7.ResumeLayout(False)
        Me.groupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents lbRTShow As System.Windows.Forms.ListBox
    Private WithEvents groupBox7 As System.Windows.Forms.GroupBox
    Private WithEvents cbUserID As System.Windows.Forms.ComboBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents cbTmpToWrite As System.Windows.Forms.ComboBox
    Private WithEvents label28 As System.Windows.Forms.Label
    Private WithEvents btnWriteCard As System.Windows.Forms.Button
    Private WithEvents btnEmptyCard As System.Windows.Forms.Button
    Private WithEvents label31 As System.Windows.Forms.Label
    Private WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Private WithEvents lvCard As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader5 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader6 As System.Windows.Forms.ColumnHeader
    Private WithEvents btnGetStrCardNumber As System.Windows.Forms.Button
    Private WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Private WithEvents txtUserID As System.Windows.Forms.TextBox
    Private WithEvents txtName As System.Windows.Forms.TextBox
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents chbEnabled As System.Windows.Forms.CheckBox
    Private WithEvents txtPassword As System.Windows.Forms.TextBox
    Private WithEvents btnSetStrCardNumber As System.Windows.Forms.Button
    Private WithEvents label89 As System.Windows.Forms.Label
    Private WithEvents cbPrivilege As System.Windows.Forms.ComboBox
    Private WithEvents txtCardnumber As System.Windows.Forms.TextBox
    Private WithEvents Privilege As System.Windows.Forms.Label
    Private WithEvents label55 As System.Windows.Forms.Label
    Private WithEvents label90 As System.Windows.Forms.Label
    Private WithEvents rtTimer As System.Windows.Forms.Timer
    Private WithEvents UserIDTimer As System.Windows.Forms.Timer
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
