<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UDiskDataMain
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
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.tabPage1 = New System.Windows.Forms.TabPage
        Me.label1 = New System.Windows.Forms.Label
        Me.btnUserWrite = New System.Windows.Forms.Button
        Me.btnUserRead = New System.Windows.Forms.Button
        Me.lvUser = New System.Windows.Forms.ListView
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.tabPage4 = New System.Windows.Forms.TabPage
        Me.txtCheckSum = New System.Windows.Forms.TextBox
        Me.txtSN = New System.Windows.Forms.TextBox
        Me.btnAttLogExtRead = New System.Windows.Forms.Button
        Me.lvAttLog = New System.Windows.Forms.ListView
        Me.columnHeader25 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader26 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader27 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader28 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader29 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader30 = New System.Windows.Forms.ColumnHeader
        Me.tabPage3 = New System.Windows.Forms.TabPage
        Me.label5 = New System.Windows.Forms.Label
        Me.btnTmpWrite = New System.Windows.Forms.Button
        Me.btnTmpRead = New System.Windows.Forms.Button
        Me.lvTmp = New System.Windows.Forms.ListView
        Me.columnHeader17 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader18 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader19 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader20 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader21 = New System.Windows.Forms.ColumnHeader
        Me.tabPage8 = New System.Windows.Forms.TabPage
        Me.label8 = New System.Windows.Forms.Label
        Me.btnSMSWrite = New System.Windows.Forms.Button
        Me.btnSMSRead = New System.Windows.Forms.Button
        Me.lvSMS = New System.Windows.Forms.ListView
        Me.columnHeader47 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader48 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader49 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader50 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader51 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader52 = New System.Windows.Forms.ColumnHeader
        Me.tabPage10 = New System.Windows.Forms.TabPage
        Me.label10 = New System.Windows.Forms.Label
        Me.btnUDataWrite = New System.Windows.Forms.Button
        Me.btnUDataRead = New System.Windows.Forms.Button
        Me.lvUData = New System.Windows.Forms.ListView
        Me.columnHeader53 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader54 = New System.Windows.Forms.ColumnHeader
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage4.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.tabPage8.SuspendLayout()
        Me.tabPage10.SuspendLayout()
        Me.SuspendLayout()
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = Global.UdiskData.My.Resources.Resources.top750
        Me.pictureBox1.Location = New System.Drawing.Point(-1, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(743, 30)
        Me.pictureBox1.TabIndex = 2
        Me.pictureBox1.TabStop = False
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.tabControl1)
        Me.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.groupBox1.Location = New System.Drawing.Point(15, 36)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(713, 425)
        Me.groupBox1.TabIndex = 3
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Udisk Data"
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage4)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Controls.Add(Me.tabPage8)
        Me.tabControl1.Controls.Add(Me.tabPage10)
        Me.tabControl1.Location = New System.Drawing.Point(12, 21)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(688, 395)
        Me.tabControl1.TabIndex = 4
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.label1)
        Me.tabPage1.Controls.Add(Me.btnUserWrite)
        Me.tabPage1.Controls.Add(Me.btnUserRead)
        Me.tabPage1.Controls.Add(Me.lvUser)
        Me.tabPage1.Location = New System.Drawing.Point(4, 21)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(680, 370)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "User(B&W)"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.ForeColor = System.Drawing.Color.Red
        Me.label1.Location = New System.Drawing.Point(86, 302)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(509, 12)
        Me.label1.TabIndex = 10
        Me.label1.Text = "It is for user information management(user.dat).(For Black&&White screen device o" & _
            "nly)"
        '
        'btnUserWrite
        '
        Me.btnUserWrite.Location = New System.Drawing.Point(351, 329)
        Me.btnUserWrite.Name = "btnUserWrite"
        Me.btnUserWrite.Size = New System.Drawing.Size(106, 23)
        Me.btnUserWrite.TabIndex = 9
        Me.btnUserWrite.Text = "WriteDataToFile"
        Me.btnUserWrite.UseVisualStyleBackColor = True
        '
        'btnUserRead
        '
        Me.btnUserRead.Location = New System.Drawing.Point(215, 329)
        Me.btnUserRead.Name = "btnUserRead"
        Me.btnUserRead.Size = New System.Drawing.Size(88, 23)
        Me.btnUserRead.TabIndex = 8
        Me.btnUserRead.Text = "ReadDataToPC"
        Me.btnUserRead.UseVisualStyleBackColor = True
        '
        'lvUser
        '
        Me.lvUser.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4, Me.columnHeader5, Me.columnHeader6, Me.columnHeader7, Me.columnHeader8})
        Me.lvUser.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lvUser.GridLines = True
        Me.lvUser.Location = New System.Drawing.Point(6, 6)
        Me.lvUser.Name = "lvUser"
        Me.lvUser.Size = New System.Drawing.Size(669, 280)
        Me.lvUser.TabIndex = 0
        Me.lvUser.UseCompatibleStateImageBehavior = False
        Me.lvUser.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "PIN2"
        Me.columnHeader1.Width = 53
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Name"
        Me.columnHeader2.Width = 47
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "Card"
        Me.columnHeader3.Width = 55
        '
        'columnHeader4
        '
        Me.columnHeader4.Text = "Privilege"
        Me.columnHeader4.Width = 77
        '
        'columnHeader5
        '
        Me.columnHeader5.Text = "Password"
        Me.columnHeader5.Width = 77
        '
        'columnHeader6
        '
        Me.columnHeader6.Text = "Group"
        Me.columnHeader6.Width = 69
        '
        'columnHeader7
        '
        Me.columnHeader7.Text = "TimeZones"
        Me.columnHeader7.Width = 74
        '
        'columnHeader8
        '
        Me.columnHeader8.Text = "PIN"
        Me.columnHeader8.Width = 68
        '
        'tabPage4
        '
        Me.tabPage4.Controls.Add(Me.Label2)
        Me.tabPage4.Controls.Add(Me.txtCheckSum)
        Me.tabPage4.Controls.Add(Me.txtSN)
        Me.tabPage4.Controls.Add(Me.btnAttLogExtRead)
        Me.tabPage4.Controls.Add(Me.lvAttLog)
        Me.tabPage4.Location = New System.Drawing.Point(4, 21)
        Me.tabPage4.Name = "tabPage4"
        Me.tabPage4.Size = New System.Drawing.Size(680, 370)
        Me.tabPage4.TabIndex = 3
        Me.tabPage4.Text = "Attlogs(B&W)"
        Me.tabPage4.UseVisualStyleBackColor = True
        '
        'txtCheckSum
        '
        Me.txtCheckSum.Location = New System.Drawing.Point(351, 261)
        Me.txtCheckSum.Name = "txtCheckSum"
        Me.txtCheckSum.ReadOnly = True
        Me.txtCheckSum.Size = New System.Drawing.Size(151, 21)
        Me.txtCheckSum.TabIndex = 24
        '
        'txtSN
        '
        Me.txtSN.Location = New System.Drawing.Point(179, 261)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.ReadOnly = True
        Me.txtSN.Size = New System.Drawing.Size(151, 21)
        Me.txtSN.TabIndex = 23
        '
        'btnAttLogExtRead
        '
        Me.btnAttLogExtRead.Location = New System.Drawing.Point(296, 329)
        Me.btnAttLogExtRead.Name = "btnAttLogExtRead"
        Me.btnAttLogExtRead.Size = New System.Drawing.Size(88, 23)
        Me.btnAttLogExtRead.TabIndex = 20
        Me.btnAttLogExtRead.Text = "ReadDataToPC"
        Me.btnAttLogExtRead.UseVisualStyleBackColor = True
        '
        'lvAttLog
        '
        Me.lvAttLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader25, Me.columnHeader26, Me.columnHeader27, Me.columnHeader28, Me.columnHeader29, Me.columnHeader30})
        Me.lvAttLog.GridLines = True
        Me.lvAttLog.Location = New System.Drawing.Point(6, 6)
        Me.lvAttLog.Name = "lvAttLog"
        Me.lvAttLog.Size = New System.Drawing.Size(669, 236)
        Me.lvAttLog.TabIndex = 1
        Me.lvAttLog.UseCompatibleStateImageBehavior = False
        Me.lvAttLog.View = System.Windows.Forms.View.Details
        '
        'columnHeader25
        '
        Me.columnHeader25.Text = "PIN"
        Me.columnHeader25.Width = 129
        '
        'columnHeader26
        '
        Me.columnHeader26.Text = "Time"
        Me.columnHeader26.Width = 182
        '
        'columnHeader27
        '
        Me.columnHeader27.Text = "DeviceID"
        Me.columnHeader27.Width = 68
        '
        'columnHeader28
        '
        Me.columnHeader28.Text = "Status"
        Me.columnHeader28.Width = 54
        '
        'columnHeader29
        '
        Me.columnHeader29.Text = "Verified"
        Me.columnHeader29.Width = 65
        '
        'columnHeader30
        '
        Me.columnHeader30.Text = "Workcode"
        Me.columnHeader30.Width = 69
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.label5)
        Me.tabPage3.Controls.Add(Me.btnTmpWrite)
        Me.tabPage3.Controls.Add(Me.btnTmpRead)
        Me.tabPage3.Controls.Add(Me.lvTmp)
        Me.tabPage3.Location = New System.Drawing.Point(4, 21)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Size = New System.Drawing.Size(680, 370)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "Tmp9.0"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.ForeColor = System.Drawing.Color.Red
        Me.label5.Location = New System.Drawing.Point(98, 302)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(485, 12)
        Me.label5.TabIndex = 27
        Me.label5.Text = "It is for fingerprint templates management.(For device with 9.0 arithmetic only)"
        '
        'btnTmpWrite
        '
        Me.btnTmpWrite.Location = New System.Drawing.Point(351, 329)
        Me.btnTmpWrite.Name = "btnTmpWrite"
        Me.btnTmpWrite.Size = New System.Drawing.Size(106, 23)
        Me.btnTmpWrite.TabIndex = 15
        Me.btnTmpWrite.Text = "WriteDataToFile"
        Me.btnTmpWrite.UseVisualStyleBackColor = True
        '
        'btnTmpRead
        '
        Me.btnTmpRead.Location = New System.Drawing.Point(215, 329)
        Me.btnTmpRead.Name = "btnTmpRead"
        Me.btnTmpRead.Size = New System.Drawing.Size(88, 23)
        Me.btnTmpRead.TabIndex = 14
        Me.btnTmpRead.Text = "ReadDataToPC"
        Me.btnTmpRead.UseVisualStyleBackColor = True
        '
        'lvTmp
        '
        Me.lvTmp.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader17, Me.columnHeader18, Me.columnHeader19, Me.columnHeader20, Me.columnHeader21})
        Me.lvTmp.GridLines = True
        Me.lvTmp.Location = New System.Drawing.Point(6, 6)
        Me.lvTmp.Name = "lvTmp"
        Me.lvTmp.Size = New System.Drawing.Size(669, 280)
        Me.lvTmp.TabIndex = 1
        Me.lvTmp.UseCompatibleStateImageBehavior = False
        Me.lvTmp.View = System.Windows.Forms.View.Details
        '
        'columnHeader17
        '
        Me.columnHeader17.Text = "Size"
        Me.columnHeader17.Width = 53
        '
        'columnHeader18
        '
        Me.columnHeader18.Text = "PIN"
        Me.columnHeader18.Width = 45
        '
        'columnHeader19
        '
        Me.columnHeader19.Text = "FingerID"
        Me.columnHeader19.Width = 72
        '
        'columnHeader20
        '
        Me.columnHeader20.Text = "Valid"
        Me.columnHeader20.Width = 87
        '
        'columnHeader21
        '
        Me.columnHeader21.Text = "Template"
        Me.columnHeader21.Width = 111
        '
        'tabPage8
        '
        Me.tabPage8.Controls.Add(Me.label8)
        Me.tabPage8.Controls.Add(Me.btnSMSWrite)
        Me.tabPage8.Controls.Add(Me.btnSMSRead)
        Me.tabPage8.Controls.Add(Me.lvSMS)
        Me.tabPage8.Location = New System.Drawing.Point(4, 21)
        Me.tabPage8.Name = "tabPage8"
        Me.tabPage8.Size = New System.Drawing.Size(680, 370)
        Me.tabPage8.TabIndex = 7
        Me.tabPage8.Text = "SMS(B&W)"
        Me.tabPage8.UseVisualStyleBackColor = True
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.ForeColor = System.Drawing.Color.Red
        Me.label8.Location = New System.Drawing.Point(119, 302)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(443, 12)
        Me.label8.TabIndex = 32
        Me.label8.Text = "It is for short messages management. (For Black&&White screen device only)"
        '
        'btnSMSWrite
        '
        Me.btnSMSWrite.Location = New System.Drawing.Point(351, 329)
        Me.btnSMSWrite.Name = "btnSMSWrite"
        Me.btnSMSWrite.Size = New System.Drawing.Size(106, 23)
        Me.btnSMSWrite.TabIndex = 31
        Me.btnSMSWrite.Text = "WriteDataToFile"
        Me.btnSMSWrite.UseVisualStyleBackColor = True
        '
        'btnSMSRead
        '
        Me.btnSMSRead.Location = New System.Drawing.Point(215, 329)
        Me.btnSMSRead.Name = "btnSMSRead"
        Me.btnSMSRead.Size = New System.Drawing.Size(88, 23)
        Me.btnSMSRead.TabIndex = 30
        Me.btnSMSRead.Text = "ReadDataToPC"
        Me.btnSMSRead.UseVisualStyleBackColor = True
        '
        'lvSMS
        '
        Me.lvSMS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader47, Me.columnHeader48, Me.columnHeader49, Me.columnHeader50, Me.columnHeader51, Me.columnHeader52})
        Me.lvSMS.GridLines = True
        Me.lvSMS.Location = New System.Drawing.Point(6, 6)
        Me.lvSMS.Name = "lvSMS"
        Me.lvSMS.Size = New System.Drawing.Size(669, 280)
        Me.lvSMS.TabIndex = 28
        Me.lvSMS.UseCompatibleStateImageBehavior = False
        Me.lvSMS.View = System.Windows.Forms.View.Details
        '
        'columnHeader47
        '
        Me.columnHeader47.Text = "Tag"
        Me.columnHeader47.Width = 55
        '
        'columnHeader48
        '
        Me.columnHeader48.Text = "ID"
        Me.columnHeader48.Width = 44
        '
        'columnHeader49
        '
        Me.columnHeader49.Text = "ValidMinutes"
        Me.columnHeader49.Width = 97
        '
        'columnHeader50
        '
        Me.columnHeader50.Text = "Reserved"
        Me.columnHeader50.Width = 82
        '
        'columnHeader51
        '
        Me.columnHeader51.Text = "StartTime"
        Me.columnHeader51.Width = 139
        '
        'columnHeader52
        '
        Me.columnHeader52.Text = "Content"
        Me.columnHeader52.Width = 224
        '
        'tabPage10
        '
        Me.tabPage10.Controls.Add(Me.label10)
        Me.tabPage10.Controls.Add(Me.btnUDataWrite)
        Me.tabPage10.Controls.Add(Me.btnUDataRead)
        Me.tabPage10.Controls.Add(Me.lvUData)
        Me.tabPage10.Location = New System.Drawing.Point(4, 21)
        Me.tabPage10.Name = "tabPage10"
        Me.tabPage10.Size = New System.Drawing.Size(680, 370)
        Me.tabPage10.TabIndex = 9
        Me.tabPage10.Text = "UData"
        Me.tabPage10.UseVisualStyleBackColor = True
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.ForeColor = System.Drawing.Color.Red
        Me.label10.Location = New System.Drawing.Point(138, 302)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(407, 12)
        Me.label10.TabIndex = 36
        Me.label10.Text = "It is for relationship management between short message and users. "
        '
        'btnUDataWrite
        '
        Me.btnUDataWrite.Location = New System.Drawing.Point(351, 329)
        Me.btnUDataWrite.Name = "btnUDataWrite"
        Me.btnUDataWrite.Size = New System.Drawing.Size(106, 23)
        Me.btnUDataWrite.TabIndex = 35
        Me.btnUDataWrite.Text = "WriteDataToFile"
        Me.btnUDataWrite.UseVisualStyleBackColor = True
        '
        'btnUDataRead
        '
        Me.btnUDataRead.Location = New System.Drawing.Point(215, 329)
        Me.btnUDataRead.Name = "btnUDataRead"
        Me.btnUDataRead.Size = New System.Drawing.Size(88, 23)
        Me.btnUDataRead.TabIndex = 34
        Me.btnUDataRead.Text = "ReadDataToPC"
        Me.btnUDataRead.UseVisualStyleBackColor = True
        '
        'lvUData
        '
        Me.lvUData.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader53, Me.columnHeader54})
        Me.lvUData.GridLines = True
        Me.lvUData.Location = New System.Drawing.Point(206, 6)
        Me.lvUData.Name = "lvUData"
        Me.lvUData.Size = New System.Drawing.Size(265, 280)
        Me.lvUData.TabIndex = 30
        Me.lvUData.UseCompatibleStateImageBehavior = False
        Me.lvUData.View = System.Windows.Forms.View.Details
        '
        'columnHeader53
        '
        Me.columnHeader53.Text = "PIN"
        Me.columnHeader53.Width = 69
        '
        'columnHeader54
        '
        Me.columnHeader54.Text = "SmsID"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(188, 300)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(305, 12)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "It is for the extended attendence logs management."
        '
        'UDiskDataMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 475)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.pictureBox1)
        Me.Name = "UDiskDataMain"
        Me.Text = "UDisk Data Management"
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        Me.tabPage4.ResumeLayout(False)
        Me.tabPage4.PerformLayout()
        Me.tabPage3.ResumeLayout(False)
        Me.tabPage3.PerformLayout()
        Me.tabPage8.ResumeLayout(False)
        Me.tabPage8.PerformLayout()
        Me.tabPage10.ResumeLayout(False)
        Me.tabPage10.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnUserWrite As System.Windows.Forms.Button
    Private WithEvents btnUserRead As System.Windows.Forms.Button
    Private WithEvents lvUser As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader5 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader6 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader7 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader8 As System.Windows.Forms.ColumnHeader
    Private WithEvents tabPage4 As System.Windows.Forms.TabPage
    Private WithEvents txtCheckSum As System.Windows.Forms.TextBox
    Private WithEvents txtSN As System.Windows.Forms.TextBox
    Private WithEvents btnAttLogExtRead As System.Windows.Forms.Button
    Private WithEvents lvAttLog As System.Windows.Forms.ListView
    Private WithEvents columnHeader25 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader26 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader27 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader28 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader29 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader30 As System.Windows.Forms.ColumnHeader
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents btnTmpWrite As System.Windows.Forms.Button
    Private WithEvents btnTmpRead As System.Windows.Forms.Button
    Private WithEvents lvTmp As System.Windows.Forms.ListView
    Private WithEvents columnHeader17 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader18 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader19 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader20 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader21 As System.Windows.Forms.ColumnHeader
    Private WithEvents tabPage8 As System.Windows.Forms.TabPage
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents btnSMSWrite As System.Windows.Forms.Button
    Private WithEvents btnSMSRead As System.Windows.Forms.Button
    Private WithEvents lvSMS As System.Windows.Forms.ListView
    Private WithEvents columnHeader47 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader48 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader49 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader50 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader51 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader52 As System.Windows.Forms.ColumnHeader
    Private WithEvents tabPage10 As System.Windows.Forms.TabPage
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents btnUDataWrite As System.Windows.Forms.Button
    Private WithEvents btnUDataRead As System.Windows.Forms.Button
    Private WithEvents lvUData As System.Windows.Forms.ListView
    Private WithEvents columnHeader53 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader54 As System.Windows.Forms.ColumnHeader
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents Label2 As System.Windows.Forms.Label

End Class
