<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserInfo
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
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.UserIDTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.groupBox7 = New System.Windows.Forms.GroupBox
        Me.label14 = New System.Windows.Forms.Label
        Me.label25 = New System.Windows.Forms.Label
        Me.cbUserIDDE = New System.Windows.Forms.ComboBox
        Me.btnDeleteEnrollData = New System.Windows.Forms.Button
        Me.label24 = New System.Windows.Forms.Label
        Me.cbBackupDE = New System.Windows.Forms.ComboBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.btnDelUserTmp = New System.Windows.Forms.Button
        Me.cbFingerIndex = New System.Windows.Forms.ComboBox
        Me.cbUserIDTmp = New System.Windows.Forms.ComboBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.btnClearAdministrators = New System.Windows.Forms.Button
        Me.btnClearDataTmps = New System.Windows.Forms.Button
        Me.btnClearDataUserInfo = New System.Windows.Forms.Button
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.lvDownload = New System.Windows.Forms.ListView
        Me.ch1 = New System.Windows.Forms.ColumnHeader
        Me.ch2 = New System.Windows.Forms.ColumnHeader
        Me.ch3 = New System.Windows.Forms.ColumnHeader
        Me.ch4 = New System.Windows.Forms.ColumnHeader
        Me.ch5 = New System.Windows.Forms.ColumnHeader
        Me.ch6 = New System.Windows.Forms.ColumnHeader
        Me.ch7 = New System.Windows.Forms.ColumnHeader
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.label12 = New System.Windows.Forms.Label
        Me.btnDownloadTmpBatch9 = New System.Windows.Forms.Button
        Me.label10 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.btnUpload9 = New System.Windows.Forms.Button
        Me.btnDownloadTmp9 = New System.Windows.Forms.Button
        Me.btnBatchUpdate = New System.Windows.Forms.Button
        Me.groupBox2.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.groupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.tabControl1)
        Me.groupBox2.Controls.Add(Me.lblState)
        Me.groupBox2.Location = New System.Drawing.Point(5, 41)
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
        'pictureBox1
        '
        Me.pictureBox1.Image = Global.UserInfo.My.Resources.Resources.top
        Me.pictureBox1.Location = New System.Drawing.Point(-1, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(980, 30)
        Me.pictureBox1.TabIndex = 10
        Me.pictureBox1.TabStop = False
        '
        'UserIDTimer
        '
        Me.UserIDTimer.Enabled = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.groupBox7)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox8)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 188)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(461, 254)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        '
        'groupBox7
        '
        Me.groupBox7.Controls.Add(Me.label14)
        Me.groupBox7.Controls.Add(Me.label25)
        Me.groupBox7.Controls.Add(Me.cbUserIDDE)
        Me.groupBox7.Controls.Add(Me.btnDeleteEnrollData)
        Me.groupBox7.Controls.Add(Me.label24)
        Me.groupBox7.Controls.Add(Me.cbBackupDE)
        Me.groupBox7.Location = New System.Drawing.Point(7, 15)
        Me.groupBox7.Name = "groupBox7"
        Me.groupBox7.Size = New System.Drawing.Size(443, 87)
        Me.groupBox7.TabIndex = 78
        Me.groupBox7.TabStop = False
        Me.groupBox7.Text = "Delete Enrolled Data"
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.ForeColor = System.Drawing.Color.Crimson
        Me.label14.Location = New System.Drawing.Point(28, 27)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(287, 12)
        Me.label14.TabIndex = 76
        Me.label14.Text = "Delete enrolled data according to backupnumber."
        '
        'label25
        '
        Me.label25.AutoSize = True
        Me.label25.Location = New System.Drawing.Point(27, 55)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(41, 12)
        Me.label25.TabIndex = 18
        Me.label25.Text = "UserID"
        '
        'cbUserIDDE
        '
        Me.cbUserIDDE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUserIDDE.FormattingEnabled = True
        Me.cbUserIDDE.Location = New System.Drawing.Point(75, 51)
        Me.cbUserIDDE.Name = "cbUserIDDE"
        Me.cbUserIDDE.Size = New System.Drawing.Size(61, 20)
        Me.cbUserIDDE.TabIndex = 16
        '
        'btnDeleteEnrollData
        '
        Me.btnDeleteEnrollData.Location = New System.Drawing.Point(287, 50)
        Me.btnDeleteEnrollData.Name = "btnDeleteEnrollData"
        Me.btnDeleteEnrollData.Size = New System.Drawing.Size(109, 23)
        Me.btnDeleteEnrollData.TabIndex = 15
        Me.btnDeleteEnrollData.Text = "DeleteEnrollData"
        Me.btnDeleteEnrollData.UseVisualStyleBackColor = True
        '
        'label24
        '
        Me.label24.AutoSize = True
        Me.label24.Location = New System.Drawing.Point(140, 55)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(77, 12)
        Me.label24.TabIndex = 19
        Me.label24.Text = "BackupNumber"
        '
        'cbBackupDE
        '
        Me.cbBackupDE.FormattingEnabled = True
        Me.cbBackupDE.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cbBackupDE.Location = New System.Drawing.Point(221, 52)
        Me.cbBackupDE.Name = "cbBackupDE"
        Me.cbBackupDE.Size = New System.Drawing.Size(48, 20)
        Me.cbBackupDE.TabIndex = 17
        Me.cbBackupDE.Text = "0"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.label4)
        Me.GroupBox6.Controls.Add(Me.label9)
        Me.GroupBox6.Controls.Add(Me.btnDelUserTmp)
        Me.GroupBox6.Controls.Add(Me.cbFingerIndex)
        Me.GroupBox6.Controls.Add(Me.cbUserIDTmp)
        Me.GroupBox6.Location = New System.Drawing.Point(7, 111)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(444, 60)
        Me.GroupBox6.TabIndex = 77
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Delete User's Fingerprint Templates"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(28, 22)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(41, 12)
        Me.label4.TabIndex = 16
        Me.label4.Text = "UserID"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(142, 23)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(71, 12)
        Me.label9.TabIndex = 23
        Me.label9.Text = "FingerIndex"
        '
        'btnDelUserTmp
        '
        Me.btnDelUserTmp.Location = New System.Drawing.Point(287, 18)
        Me.btnDelUserTmp.Name = "btnDelUserTmp"
        Me.btnDelUserTmp.Size = New System.Drawing.Size(75, 23)
        Me.btnDelUserTmp.TabIndex = 28
        Me.btnDelUserTmp.Text = "DelUserTmp"
        Me.btnDelUserTmp.UseVisualStyleBackColor = True
        '
        'cbFingerIndex
        '
        Me.cbFingerIndex.FormattingEnabled = True
        Me.cbFingerIndex.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "13", "15"})
        Me.cbFingerIndex.Location = New System.Drawing.Point(220, 19)
        Me.cbFingerIndex.Name = "cbFingerIndex"
        Me.cbFingerIndex.Size = New System.Drawing.Size(48, 20)
        Me.cbFingerIndex.TabIndex = 29
        Me.cbFingerIndex.Text = "0"
        '
        'cbUserIDTmp
        '
        Me.cbUserIDTmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUserIDTmp.Location = New System.Drawing.Point(75, 19)
        Me.cbUserIDTmp.Name = "cbUserIDTmp"
        Me.cbUserIDTmp.Size = New System.Drawing.Size(61, 20)
        Me.cbUserIDTmp.TabIndex = 21
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btnClearAdministrators)
        Me.GroupBox8.Controls.Add(Me.btnClearDataTmps)
        Me.GroupBox8.Controls.Add(Me.btnClearDataUserInfo)
        Me.GroupBox8.Location = New System.Drawing.Point(7, 181)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(443, 64)
        Me.GroupBox8.TabIndex = 65
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Clear Templates/UsersInfo/Administrator Privilege"
        '
        'btnClearAdministrators
        '
        Me.btnClearAdministrators.Location = New System.Drawing.Point(287, 24)
        Me.btnClearAdministrators.Name = "btnClearAdministrators"
        Me.btnClearAdministrators.Size = New System.Drawing.Size(131, 23)
        Me.btnClearAdministrators.TabIndex = 72
        Me.btnClearAdministrators.Text = "ClearAdministrators"
        Me.btnClearAdministrators.UseVisualStyleBackColor = True
        '
        'btnClearDataTmps
        '
        Me.btnClearDataTmps.Location = New System.Drawing.Point(28, 24)
        Me.btnClearDataTmps.Name = "btnClearDataTmps"
        Me.btnClearDataTmps.Size = New System.Drawing.Size(99, 23)
        Me.btnClearDataTmps.TabIndex = 64
        Me.btnClearDataTmps.Text = "ClearTmpsData"
        Me.btnClearDataTmps.UseVisualStyleBackColor = True
        '
        'btnClearDataUserInfo
        '
        Me.btnClearDataUserInfo.Location = New System.Drawing.Point(148, 24)
        Me.btnClearDataUserInfo.Name = "btnClearDataUserInfo"
        Me.btnClearDataUserInfo.Size = New System.Drawing.Size(121, 23)
        Me.btnClearDataUserInfo.TabIndex = 63
        Me.btnClearDataUserInfo.Text = "ClearUserInfoData"
        Me.btnClearDataUserInfo.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.lvDownload)
        Me.GroupBox9.Controls.Add(Me.GroupBox10)
        Me.GroupBox9.Location = New System.Drawing.Point(472, 43)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(502, 399)
        Me.GroupBox9.TabIndex = 79
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Download or Upload Fingerprint Templates"
        '
        'lvDownload
        '
        Me.lvDownload.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch1, Me.ch2, Me.ch3, Me.ch4, Me.ch5, Me.ch6, Me.ch7})
        Me.lvDownload.GridLines = True
        Me.lvDownload.Location = New System.Drawing.Point(6, 20)
        Me.lvDownload.Name = "lvDownload"
        Me.lvDownload.Size = New System.Drawing.Size(489, 212)
        Me.lvDownload.TabIndex = 0
        Me.lvDownload.UseCompatibleStateImageBehavior = False
        Me.lvDownload.View = System.Windows.Forms.View.Details
        '
        'ch1
        '
        Me.ch1.Text = "UserID"
        Me.ch1.Width = 54
        '
        'ch2
        '
        Me.ch2.Text = "Name"
        Me.ch2.Width = 41
        '
        'ch3
        '
        Me.ch3.Text = "FingerIndex"
        Me.ch3.Width = 52
        '
        'ch4
        '
        Me.ch4.Text = "tmpData"
        Me.ch4.Width = 72
        '
        'ch5
        '
        Me.ch5.Text = "Privilege"
        Me.ch5.Width = 77
        '
        'ch6
        '
        Me.ch6.Text = "Password"
        Me.ch6.Width = 40
        '
        'ch7
        '
        Me.ch7.Text = "Ennabled"
        Me.ch7.Width = 81
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.label12)
        Me.GroupBox10.Controls.Add(Me.btnDownloadTmpBatch9)
        Me.GroupBox10.Controls.Add(Me.label10)
        Me.GroupBox10.Controls.Add(Me.label8)
        Me.GroupBox10.Controls.Add(Me.label3)
        Me.GroupBox10.Controls.Add(Me.btnUpload9)
        Me.GroupBox10.Controls.Add(Me.btnDownloadTmp9)
        Me.GroupBox10.Controls.Add(Me.btnBatchUpdate)
        Me.GroupBox10.Location = New System.Drawing.Point(6, 258)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(489, 133)
        Me.GroupBox10.TabIndex = 7
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Fingerprint Templates of  9.0 Arithmetic"
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.ForeColor = System.Drawing.Color.Crimson
        Me.label12.Location = New System.Drawing.Point(160, 27)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(257, 12)
        Me.label12.TabIndex = 78
        Me.label12.Text = "Download Fingerprint Templates in batches."
        '
        'btnDownloadTmpBatch9
        '
        Me.btnDownloadTmpBatch9.Location = New System.Drawing.Point(7, 21)
        Me.btnDownloadTmpBatch9.Name = "btnDownloadTmpBatch9"
        Me.btnDownloadTmpBatch9.Size = New System.Drawing.Size(144, 23)
        Me.btnDownloadTmpBatch9.TabIndex = 77
        Me.btnDownloadTmpBatch9.Text = "DownloadFPTmp(Batch)"
        Me.btnDownloadTmpBatch9.UseVisualStyleBackColor = True
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.ForeColor = System.Drawing.Color.Crimson
        Me.label10.Location = New System.Drawing.Point(161, 107)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(239, 12)
        Me.label10.TabIndex = 76
        Me.label10.Text = "Upload Fingerprint Templates one by one"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.ForeColor = System.Drawing.Color.Crimson
        Me.label8.Location = New System.Drawing.Point(160, 80)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(245, 12)
        Me.label8.TabIndex = 75
        Me.label8.Text = "Upload Fingerprint Templates in batches."
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.ForeColor = System.Drawing.Color.Crimson
        Me.label3.Location = New System.Drawing.Point(161, 53)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(257, 12)
        Me.label3.TabIndex = 74
        Me.label3.Text = "Download Fingerprint Templates one by one."
        '
        'btnUpload9
        '
        Me.btnUpload9.Location = New System.Drawing.Point(7, 101)
        Me.btnUpload9.Name = "btnUpload9"
        Me.btnUpload9.Size = New System.Drawing.Size(144, 23)
        Me.btnUpload9.TabIndex = 73
        Me.btnUpload9.Text = "UploadFPTmp(common)"
        Me.btnUpload9.UseVisualStyleBackColor = True
        '
        'btnDownloadTmp9
        '
        Me.btnDownloadTmp9.Location = New System.Drawing.Point(7, 48)
        Me.btnDownloadTmp9.Name = "btnDownloadTmp9"
        Me.btnDownloadTmp9.Size = New System.Drawing.Size(144, 23)
        Me.btnDownloadTmp9.TabIndex = 2
        Me.btnDownloadTmp9.Text = "DownloadFPTmp(Common)"
        Me.btnDownloadTmp9.UseVisualStyleBackColor = True
        '
        'btnBatchUpdate
        '
        Me.btnBatchUpdate.Location = New System.Drawing.Point(7, 75)
        Me.btnBatchUpdate.Name = "btnBatchUpdate"
        Me.btnBatchUpdate.Size = New System.Drawing.Size(144, 23)
        Me.btnBatchUpdate.TabIndex = 5
        Me.btnBatchUpdate.Text = "UploadFPTmp(batch)"
        Me.btnBatchUpdate.UseVisualStyleBackColor = True
        '
        'UserInfo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(979, 452)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.MinimizeBox = False
        Me.Name = "UserInfo"
        Me.Text = "UserInfo"
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
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.groupBox7.ResumeLayout(False)
        Me.groupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
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
    Private WithEvents UserIDTimer As System.Windows.Forms.Timer
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents groupBox7 As System.Windows.Forms.GroupBox
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents label25 As System.Windows.Forms.Label
    Private WithEvents cbUserIDDE As System.Windows.Forms.ComboBox
    Private WithEvents btnDeleteEnrollData As System.Windows.Forms.Button
    Private WithEvents label24 As System.Windows.Forms.Label
    Private WithEvents cbBackupDE As System.Windows.Forms.ComboBox
    Private WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents btnDelUserTmp As System.Windows.Forms.Button
    Private WithEvents cbFingerIndex As System.Windows.Forms.ComboBox
    Private WithEvents cbUserIDTmp As System.Windows.Forms.ComboBox
    Private WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Private WithEvents btnClearAdministrators As System.Windows.Forms.Button
    Private WithEvents btnClearDataTmps As System.Windows.Forms.Button
    Private WithEvents btnClearDataUserInfo As System.Windows.Forms.Button
    Private WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Private WithEvents lvDownload As System.Windows.Forms.ListView
    Private WithEvents ch1 As System.Windows.Forms.ColumnHeader
    Private WithEvents ch2 As System.Windows.Forms.ColumnHeader
    Private WithEvents ch3 As System.Windows.Forms.ColumnHeader
    Private WithEvents ch4 As System.Windows.Forms.ColumnHeader
    Private WithEvents ch5 As System.Windows.Forms.ColumnHeader
    Private WithEvents ch6 As System.Windows.Forms.ColumnHeader
    Private WithEvents ch7 As System.Windows.Forms.ColumnHeader
    Private WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents btnDownloadTmpBatch9 As System.Windows.Forms.Button
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents btnUpload9 As System.Windows.Forms.Button
    Private WithEvents btnDownloadTmp9 As System.Windows.Forms.Button
    Private WithEvents btnBatchUpdate As System.Windows.Forms.Button

End Class
