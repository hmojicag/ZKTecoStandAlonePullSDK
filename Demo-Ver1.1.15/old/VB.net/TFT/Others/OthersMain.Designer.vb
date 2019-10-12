<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Others
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
        Me.label29 = New System.Windows.Forms.Label
        Me.txtMachineSN2 = New System.Windows.Forms.TextBox
        Me.label18 = New System.Windows.Forms.Label
        Me.btnUSBConnect = New System.Windows.Forms.Button
        Me.lblState = New System.Windows.Forms.Label
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.groupBox7 = New System.Windows.Forms.GroupBox
        Me.btnBrowser3 = New System.Windows.Forms.Button
        Me.txtFirmwareFile = New System.Windows.Forms.TextBox
        Me.label12 = New System.Windows.Forms.Label
        Me.btnUpdateFirmware = New System.Windows.Forms.Button
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtGetDataName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.btnGetDataFile = New System.Windows.Forms.Button
        Me.cbDataFlag = New System.Windows.Forms.ComboBox
        Me.btnBrowser2 = New System.Windows.Forms.Button
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.btnSendFile = New System.Windows.Forms.Button
        Me.btnBrowser1 = New System.Windows.Forms.Button
        Me.label4 = New System.Windows.Forms.Label
        Me.txtSendFileName = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.groupBox2.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.tabControl1)
        Me.groupBox2.Controls.Add(Me.lblState)
        Me.groupBox2.Location = New System.Drawing.Point(8, 35)
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
        Me.tabPage3.Controls.Add(Me.label29)
        Me.tabPage3.Controls.Add(Me.txtMachineSN2)
        Me.tabPage3.Controls.Add(Me.label18)
        Me.tabPage3.Controls.Add(Me.btnUSBConnect)
        Me.tabPage3.ForeColor = System.Drawing.Color.DarkBlue
        Me.tabPage3.Location = New System.Drawing.Point(4, 21)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Size = New System.Drawing.Size(441, 77)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "USBClient"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'label29
        '
        Me.label29.AutoSize = True
        Me.label29.Location = New System.Drawing.Point(233, 18)
        Me.label29.Name = "label29"
        Me.label29.Size = New System.Drawing.Size(59, 12)
        Me.label29.TabIndex = 18
        Me.label29.Text = "MachineSN"
        '
        'txtMachineSN2
        '
        Me.txtMachineSN2.BackColor = System.Drawing.Color.AliceBlue
        Me.txtMachineSN2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMachineSN2.Location = New System.Drawing.Point(294, 13)
        Me.txtMachineSN2.Name = "txtMachineSN2"
        Me.txtMachineSN2.Size = New System.Drawing.Size(27, 21)
        Me.txtMachineSN2.TabIndex = 17
        Me.txtMachineSN2.Text = "1"
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.ForeColor = System.Drawing.Color.Crimson
        Me.label18.Location = New System.Drawing.Point(120, 18)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(107, 12)
        Me.label18.TabIndex = 16
        Me.label18.Text = "Virtual USBClient"
        '
        'btnUSBConnect
        '
        Me.btnUSBConnect.Location = New System.Drawing.Point(183, 40)
        Me.btnUSBConnect.Name = "btnUSBConnect"
        Me.btnUSBConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnUSBConnect.TabIndex = 15
        Me.btnUSBConnect.Text = "Connect"
        Me.btnUSBConnect.UseVisualStyleBackColor = True
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
        Me.pictureBox1.Image = Global.Others.My.Resources.Resources.top
        Me.pictureBox1.Location = New System.Drawing.Point(-1, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(806, 30)
        Me.pictureBox1.TabIndex = 10
        Me.pictureBox1.TabStop = False
        '
        'groupBox7
        '
        Me.groupBox7.Controls.Add(Me.btnBrowser3)
        Me.groupBox7.Controls.Add(Me.txtFirmwareFile)
        Me.groupBox7.Controls.Add(Me.label12)
        Me.groupBox7.Controls.Add(Me.btnUpdateFirmware)
        Me.groupBox7.Location = New System.Drawing.Point(8, 12)
        Me.groupBox7.Name = "groupBox7"
        Me.groupBox7.Size = New System.Drawing.Size(304, 84)
        Me.groupBox7.TabIndex = 21
        Me.groupBox7.TabStop = False
        Me.groupBox7.Text = "Update Firmware"
        '
        'btnBrowser3
        '
        Me.btnBrowser3.ForeColor = System.Drawing.Color.DarkCyan
        Me.btnBrowser3.Location = New System.Drawing.Point(217, 18)
        Me.btnBrowser3.Name = "btnBrowser3"
        Me.btnBrowser3.Size = New System.Drawing.Size(55, 23)
        Me.btnBrowser3.TabIndex = 23
        Me.btnBrowser3.Text = "Browse"
        Me.btnBrowser3.UseVisualStyleBackColor = True
        '
        'txtFirmwareFile
        '
        Me.txtFirmwareFile.Location = New System.Drawing.Point(99, 20)
        Me.txtFirmwareFile.Name = "txtFirmwareFile"
        Me.txtFirmwareFile.Size = New System.Drawing.Size(100, 21)
        Me.txtFirmwareFile.TabIndex = 22
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(6, 25)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(77, 12)
        Me.label12.TabIndex = 21
        Me.label12.Text = "FirmwareFile"
        '
        'btnUpdateFirmware
        '
        Me.btnUpdateFirmware.Location = New System.Drawing.Point(7, 50)
        Me.btnUpdateFirmware.Name = "btnUpdateFirmware"
        Me.btnUpdateFirmware.Size = New System.Drawing.Size(101, 23)
        Me.btnUpdateFirmware.TabIndex = 20
        Me.btnUpdateFirmware.Text = "UpdateFirmware"
        Me.btnUpdateFirmware.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtGetDataName)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.label10)
        Me.GroupBox6.Controls.Add(Me.btnGetDataFile)
        Me.GroupBox6.Controls.Add(Me.cbDataFlag)
        Me.GroupBox6.Controls.Add(Me.btnBrowser2)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 103)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(306, 103)
        Me.GroupBox6.TabIndex = 16
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Get Data File from Device"
        '
        'txtGetDataName
        '
        Me.txtGetDataName.Location = New System.Drawing.Point(66, 47)
        Me.txtGetDataName.Name = "txtGetDataName"
        Me.txtGetDataName.Size = New System.Drawing.Size(135, 21)
        Me.txtGetDataName.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "FileName"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(6, 25)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(53, 12)
        Me.label10.TabIndex = 4
        Me.label10.Text = "DataFlag"
        '
        'btnGetDataFile
        '
        Me.btnGetDataFile.Location = New System.Drawing.Point(6, 74)
        Me.btnGetDataFile.Name = "btnGetDataFile"
        Me.btnGetDataFile.Size = New System.Drawing.Size(79, 23)
        Me.btnGetDataFile.TabIndex = 10
        Me.btnGetDataFile.Text = "GetDataFile"
        Me.btnGetDataFile.UseVisualStyleBackColor = True
        '
        'cbDataFlag
        '
        Me.cbDataFlag.FormattingEnabled = True
        Me.cbDataFlag.Location = New System.Drawing.Point(65, 21)
        Me.cbDataFlag.Name = "cbDataFlag"
        Me.cbDataFlag.Size = New System.Drawing.Size(45, 20)
        Me.cbDataFlag.TabIndex = 13
        '
        'btnBrowser2
        '
        Me.btnBrowser2.ForeColor = System.Drawing.Color.DarkCyan
        Me.btnBrowser2.Location = New System.Drawing.Point(219, 45)
        Me.btnBrowser2.Name = "btnBrowser2"
        Me.btnBrowser2.Size = New System.Drawing.Size(55, 23)
        Me.btnBrowser2.TabIndex = 11
        Me.btnBrowser2.Text = "Browse"
        Me.btnBrowser2.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btnSendFile)
        Me.GroupBox8.Controls.Add(Me.btnBrowser1)
        Me.GroupBox8.Controls.Add(Me.label4)
        Me.GroupBox8.Controls.Add(Me.txtSendFileName)
        Me.GroupBox8.Location = New System.Drawing.Point(8, 186)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(461, 63)
        Me.GroupBox8.TabIndex = 0
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Send File to Device "
        '
        'btnSendFile
        '
        Me.btnSendFile.Location = New System.Drawing.Point(364, 23)
        Me.btnSendFile.Name = "btnSendFile"
        Me.btnSendFile.Size = New System.Drawing.Size(75, 23)
        Me.btnSendFile.TabIndex = 8
        Me.btnSendFile.Text = "SendFile"
        Me.btnSendFile.UseVisualStyleBackColor = True
        '
        'btnBrowser1
        '
        Me.btnBrowser1.ForeColor = System.Drawing.Color.DarkCyan
        Me.btnBrowser1.Location = New System.Drawing.Point(281, 24)
        Me.btnBrowser1.Name = "btnBrowser1"
        Me.btnBrowser1.Size = New System.Drawing.Size(60, 23)
        Me.btnBrowser1.TabIndex = 7
        Me.btnBrowser1.Text = "Browse"
        Me.btnBrowser1.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(10, 29)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(53, 12)
        Me.label4.TabIndex = 1
        Me.label4.Text = "FileName"
        '
        'txtSendFileName
        '
        Me.txtSendFileName.Location = New System.Drawing.Point(69, 25)
        Me.txtSendFileName.Name = "txtSendFileName"
        Me.txtSendFileName.Size = New System.Drawing.Size(194, 21)
        Me.txtSendFileName.TabIndex = 5
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.groupBox7)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Location = New System.Drawing.Point(475, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 215)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Others
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(805, 258)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.MinimizeBox = False
        Me.Name = "Others"
        Me.Text = "Others"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.tabPage3.ResumeLayout(False)
        Me.tabPage3.PerformLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox7.ResumeLayout(False)
        Me.groupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
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
    Private WithEvents lblState As System.Windows.Forms.Label
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents groupBox7 As System.Windows.Forms.GroupBox
    Private WithEvents btnBrowser3 As System.Windows.Forms.Button
    Private WithEvents txtFirmwareFile As System.Windows.Forms.TextBox
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents btnUpdateFirmware As System.Windows.Forms.Button
    Private WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Private WithEvents txtGetDataName As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents btnGetDataFile As System.Windows.Forms.Button
    Private WithEvents cbDataFlag As System.Windows.Forms.ComboBox
    Private WithEvents btnBrowser2 As System.Windows.Forms.Button
    Private WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Private WithEvents btnSendFile As System.Windows.Forms.Button
    Private WithEvents btnBrowser1 As System.Windows.Forms.Button
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents txtSendFileName As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents label29 As System.Windows.Forms.Label
    Private WithEvents txtMachineSN2 As System.Windows.Forms.TextBox
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents btnUSBConnect As System.Windows.Forms.Button
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
