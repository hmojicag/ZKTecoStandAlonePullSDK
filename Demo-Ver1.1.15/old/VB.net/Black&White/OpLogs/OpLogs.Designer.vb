<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpLogs
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
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label3 = New System.Windows.Forms.Label
        Me.lvLogs = New System.Windows.Forms.ListView
        Me.lvLogsch1 = New System.Windows.Forms.ColumnHeader
        Me.lvLogsch2 = New System.Windows.Forms.ColumnHeader
        Me.lvLogsch3 = New System.Windows.Forms.ColumnHeader
        Me.lvLogsch4 = New System.Windows.Forms.ColumnHeader
        Me.lvLogsch5 = New System.Windows.Forms.ColumnHeader
        Me.lvLogsch6 = New System.Windows.Forms.ColumnHeader
        Me.lvLogsch7 = New System.Windows.Forms.ColumnHeader
        Me.lvLogsch8 = New System.Windows.Forms.ColumnHeader
        Me.lvLogsch9 = New System.Windows.Forms.ColumnHeader
        Me.btnGetSuperLogData = New System.Windows.Forms.Button
        Me.btnClearSLog = New System.Windows.Forms.Button
        Me.groupBox2.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.tabControl1)
        Me.groupBox2.Controls.Add(Me.lblState)
        Me.groupBox2.Location = New System.Drawing.Point(10, 41)
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
        Me.pictureBox1.Image = Global.OpLogs.My.Resources.Resources.top550
        Me.pictureBox1.Location = New System.Drawing.Point(-2, -1)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(483, 30)
        Me.pictureBox1.TabIndex = 10
        Me.pictureBox1.TabStop = False
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.lvLogs)
        Me.groupBox1.Controls.Add(Me.btnGetSuperLogData)
        Me.groupBox1.Controls.Add(Me.btnClearSLog)
        Me.groupBox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.groupBox1.Location = New System.Drawing.Point(10, 193)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(461, 345)
        Me.groupBox1.TabIndex = 12
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Download or Clear Super Records from Device"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.ForeColor = System.Drawing.Color.Red
        Me.label3.Location = New System.Drawing.Point(96, 292)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(269, 12)
        Me.label3.TabIndex = 8
        Me.label3.Text = "(For Black&&White screen devices temporarily)"
        '
        'lvLogs
        '
        Me.lvLogs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvLogsch1, Me.lvLogsch2, Me.lvLogsch3, Me.lvLogsch4, Me.lvLogsch5, Me.lvLogsch6, Me.lvLogsch7, Me.lvLogsch8, Me.lvLogsch9})
        Me.lvLogs.GridLines = True
        Me.lvLogs.Location = New System.Drawing.Point(7, 17)
        Me.lvLogs.Name = "lvLogs"
        Me.lvLogs.Size = New System.Drawing.Size(446, 258)
        Me.lvLogs.TabIndex = 0
        Me.lvLogs.UseCompatibleStateImageBehavior = False
        Me.lvLogs.View = System.Windows.Forms.View.Details
        '
        'lvLogsch1
        '
        Me.lvLogsch1.Text = "Count"
        Me.lvLogsch1.Width = 45
        '
        'lvLogsch2
        '
        Me.lvLogsch2.Text = "TMachineNumber"
        Me.lvLogsch2.Width = 47
        '
        'lvLogsch3
        '
        Me.lvLogsch3.Text = "SEnrollNumber"
        Me.lvLogsch3.Width = 47
        '
        'lvLogsch4
        '
        Me.lvLogsch4.Text = "Params4"
        Me.lvLogsch4.Width = 29
        '
        'lvLogsch5
        '
        Me.lvLogsch5.Text = "Params1"
        Me.lvLogsch5.Width = 31
        '
        'lvLogsch6
        '
        Me.lvLogsch6.Text = "Params2"
        Me.lvLogsch6.Width = 33
        '
        'lvLogsch7
        '
        Me.lvLogsch7.Text = "Manipulation"
        Me.lvLogsch7.Width = 53
        '
        'lvLogsch8
        '
        Me.lvLogsch8.Text = "Params3"
        Me.lvLogsch8.Width = 42
        '
        'lvLogsch9
        '
        Me.lvLogsch9.Text = "Time"
        Me.lvLogsch9.Width = 75
        '
        'btnGetSuperLogData
        '
        Me.btnGetSuperLogData.Location = New System.Drawing.Point(122, 314)
        Me.btnGetSuperLogData.Name = "btnGetSuperLogData"
        Me.btnGetSuperLogData.Size = New System.Drawing.Size(117, 23)
        Me.btnGetSuperLogData.TabIndex = 2
        Me.btnGetSuperLogData.Text = "GetSuperLogData"
        Me.btnGetSuperLogData.UseVisualStyleBackColor = True
        '
        'btnClearSLog
        '
        Me.btnClearSLog.Location = New System.Drawing.Point(263, 314)
        Me.btnClearSLog.Name = "btnClearSLog"
        Me.btnClearSLog.Size = New System.Drawing.Size(75, 23)
        Me.btnClearSLog.TabIndex = 7
        Me.btnClearSLog.Text = "ClearSLog"
        Me.btnClearSLog.UseVisualStyleBackColor = True
        '
        'OpLogs
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(481, 548)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.MinimizeBox = False
        Me.Name = "OpLogs"
        Me.Text = "OpLogs"
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
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
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
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents lvLogs As System.Windows.Forms.ListView
    Private WithEvents lvLogsch1 As System.Windows.Forms.ColumnHeader
    Private WithEvents lvLogsch2 As System.Windows.Forms.ColumnHeader
    Private WithEvents lvLogsch3 As System.Windows.Forms.ColumnHeader
    Private WithEvents lvLogsch4 As System.Windows.Forms.ColumnHeader
    Private WithEvents lvLogsch5 As System.Windows.Forms.ColumnHeader
    Private WithEvents lvLogsch6 As System.Windows.Forms.ColumnHeader
    Private WithEvents lvLogsch7 As System.Windows.Forms.ColumnHeader
    Private WithEvents lvLogsch8 As System.Windows.Forms.ColumnHeader
    Private WithEvents lvLogsch9 As System.Windows.Forms.ColumnHeader
    Private WithEvents btnGetSuperLogData As System.Windows.Forms.Button
    Private WithEvents btnClearSLog As System.Windows.Forms.Button

End Class
