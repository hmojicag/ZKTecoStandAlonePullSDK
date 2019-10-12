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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.tabPage1 = New System.Windows.Forms.TabPage
        Me.label2 = New System.Windows.Forms.Label
        Me.btnSSR_UserWrite = New System.Windows.Forms.Button
        Me.btnSSR_UserRead = New System.Windows.Forms.Button
        Me.lvSSRUser = New System.Windows.Forms.ListView
        Me.columnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.tabPage2 = New System.Windows.Forms.TabPage
        Me.label4 = New System.Windows.Forms.Label
        Me.lvSSRAttLog = New System.Windows.Forms.ListView
        Me.columnHeader22 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader23 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader24 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader31 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader32 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader33 = New System.Windows.Forms.ColumnHeader
        Me.btnSSRAttLogRead = New System.Windows.Forms.Button
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
        Me.tabPage4 = New System.Windows.Forms.TabPage
        Me.label6 = New System.Windows.Forms.Label
        Me.lvTmp10 = New System.Windows.Forms.ListView
        Me.columnHeader42 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader43 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader44 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader45 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader46 = New System.Windows.Forms.ColumnHeader
        Me.btnTmp10Write = New System.Windows.Forms.Button
        Me.btnTmp10Read = New System.Windows.Forms.Button
        Me.tabPage5 = New System.Windows.Forms.TabPage
        Me.label9 = New System.Windows.Forms.Label
        Me.btnSSRSMSWrite = New System.Windows.Forms.Button
        Me.btnSSRSMSRead = New System.Windows.Forms.Button
        Me.lvSSRSMS = New System.Windows.Forms.ListView
        Me.columnHeader55 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader56 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader57 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader58 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader59 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader60 = New System.Windows.Forms.ColumnHeader
        Me.tabPage6 = New System.Windows.Forms.TabPage
        Me.label10 = New System.Windows.Forms.Label
        Me.btnUDataWrite = New System.Windows.Forms.Button
        Me.btnUDataRead = New System.Windows.Forms.Button
        Me.lvUData = New System.Windows.Forms.ListView
        Me.columnHeader53 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader54 = New System.Windows.Forms.ColumnHeader
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.tabPage4.SuspendLayout()
        Me.tabPage5.SuspendLayout()
        Me.tabPage6.SuspendLayout()
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.tabControl1)
        Me.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.groupBox1.Location = New System.Drawing.Point(14, 41)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(713, 425)
        Me.groupBox1.TabIndex = 3
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Udisk Data"
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Controls.Add(Me.tabPage4)
        Me.tabControl1.Controls.Add(Me.tabPage5)
        Me.tabControl1.Controls.Add(Me.tabPage6)
        Me.tabControl1.Location = New System.Drawing.Point(12, 21)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(688, 395)
        Me.tabControl1.TabIndex = 4
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.label2)
        Me.tabPage1.Controls.Add(Me.btnSSR_UserWrite)
        Me.tabPage1.Controls.Add(Me.btnSSR_UserRead)
        Me.tabPage1.Controls.Add(Me.lvSSRUser)
        Me.tabPage1.Location = New System.Drawing.Point(4, 21)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(680, 370)
        Me.tabPage1.TabIndex = 1
        Me.tabPage1.Text = "SSR_User(TFT)"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.ForeColor = System.Drawing.Color.Red
        Me.label2.Location = New System.Drawing.Point(194, 302)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(293, 12)
        Me.label2.TabIndex = 13
        Me.label2.Text = "It is for user information management(user.dat)."
        '
        'btnSSR_UserWrite
        '
        Me.btnSSR_UserWrite.Location = New System.Drawing.Point(351, 329)
        Me.btnSSR_UserWrite.Name = "btnSSR_UserWrite"
        Me.btnSSR_UserWrite.Size = New System.Drawing.Size(106, 23)
        Me.btnSSR_UserWrite.TabIndex = 12
        Me.btnSSR_UserWrite.Text = "WriteDataToFile"
        Me.btnSSR_UserWrite.UseVisualStyleBackColor = True
        '
        'btnSSR_UserRead
        '
        Me.btnSSR_UserRead.Location = New System.Drawing.Point(215, 329)
        Me.btnSSR_UserRead.Name = "btnSSR_UserRead"
        Me.btnSSR_UserRead.Size = New System.Drawing.Size(88, 23)
        Me.btnSSR_UserRead.TabIndex = 11
        Me.btnSSR_UserRead.Text = "ReadDataToPC"
        Me.btnSSR_UserRead.UseVisualStyleBackColor = True
        '
        'lvSSRUser
        '
        Me.lvSSRUser.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader9, Me.columnHeader10, Me.columnHeader11, Me.columnHeader12, Me.columnHeader13, Me.columnHeader14, Me.columnHeader15, Me.columnHeader16})
        Me.lvSSRUser.GridLines = True
        Me.lvSSRUser.Location = New System.Drawing.Point(6, 6)
        Me.lvSSRUser.Name = "lvSSRUser"
        Me.lvSSRUser.Size = New System.Drawing.Size(669, 280)
        Me.lvSSRUser.TabIndex = 1
        Me.lvSSRUser.UseCompatibleStateImageBehavior = False
        Me.lvSSRUser.View = System.Windows.Forms.View.Details
        '
        'columnHeader9
        '
        Me.columnHeader9.Text = "PIN2"
        Me.columnHeader9.Width = 53
        '
        'columnHeader10
        '
        Me.columnHeader10.Text = "Name"
        Me.columnHeader10.Width = 47
        '
        'columnHeader11
        '
        Me.columnHeader11.Text = "Card"
        Me.columnHeader11.Width = 55
        '
        'columnHeader12
        '
        Me.columnHeader12.Text = "Privilege"
        '
        'columnHeader13
        '
        Me.columnHeader13.Text = "Password"
        Me.columnHeader13.Width = 77
        '
        'columnHeader14
        '
        Me.columnHeader14.Text = "Group"
        Me.columnHeader14.Width = 69
        '
        'columnHeader15
        '
        Me.columnHeader15.Text = "TimeZones"
        Me.columnHeader15.Width = 74
        '
        'columnHeader16
        '
        Me.columnHeader16.Text = "PIN"
        Me.columnHeader16.Width = 68
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.label4)
        Me.tabPage2.Controls.Add(Me.lvSSRAttLog)
        Me.tabPage2.Controls.Add(Me.btnSSRAttLogRead)
        Me.tabPage2.Location = New System.Drawing.Point(4, 21)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Size = New System.Drawing.Size(680, 370)
        Me.tabPage2.TabIndex = 4
        Me.tabPage2.Text = "AttLogs(TFT)"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.ForeColor = System.Drawing.Color.Red
        Me.label4.Location = New System.Drawing.Point(227, 302)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(227, 12)
        Me.label4.TabIndex = 26
        Me.label4.Text = "It is for attendance logs management."
        '
        'lvSSRAttLog
        '
        Me.lvSSRAttLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader22, Me.columnHeader23, Me.columnHeader24, Me.columnHeader31, Me.columnHeader32, Me.columnHeader33})
        Me.lvSSRAttLog.GridLines = True
        Me.lvSSRAttLog.Location = New System.Drawing.Point(6, 6)
        Me.lvSSRAttLog.Name = "lvSSRAttLog"
        Me.lvSSRAttLog.Size = New System.Drawing.Size(669, 280)
        Me.lvSSRAttLog.TabIndex = 24
        Me.lvSSRAttLog.UseCompatibleStateImageBehavior = False
        Me.lvSSRAttLog.View = System.Windows.Forms.View.Details
        '
        'columnHeader22
        '
        Me.columnHeader22.Text = "PIN"
        Me.columnHeader22.Width = 129
        '
        'columnHeader23
        '
        Me.columnHeader23.Text = "Time"
        Me.columnHeader23.Width = 182
        '
        'columnHeader24
        '
        Me.columnHeader24.Text = "DeviceID"
        Me.columnHeader24.Width = 68
        '
        'columnHeader31
        '
        Me.columnHeader31.Text = "Status"
        Me.columnHeader31.Width = 54
        '
        'columnHeader32
        '
        Me.columnHeader32.Text = "Verified"
        Me.columnHeader32.Width = 65
        '
        'columnHeader33
        '
        Me.columnHeader33.Text = "Workcode"
        Me.columnHeader33.Width = 69
        '
        'btnSSRAttLogRead
        '
        Me.btnSSRAttLogRead.Location = New System.Drawing.Point(296, 329)
        Me.btnSSRAttLogRead.Name = "btnSSRAttLogRead"
        Me.btnSSRAttLogRead.Size = New System.Drawing.Size(88, 23)
        Me.btnSSRAttLogRead.TabIndex = 21
        Me.btnSSRAttLogRead.Text = "ReadDataToPC"
        Me.btnSSRAttLogRead.UseVisualStyleBackColor = True
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
        Me.label5.Size = New System.Drawing.Size(491, 12)
        Me.label5.TabIndex = 27
        Me.label5.Text = "It is for fingerprint templates management.(For devices with 9.0 arithmetic only)" & _
            ""
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
        'tabPage4
        '
        Me.tabPage4.Controls.Add(Me.label6)
        Me.tabPage4.Controls.Add(Me.lvTmp10)
        Me.tabPage4.Controls.Add(Me.btnTmp10Write)
        Me.tabPage4.Controls.Add(Me.btnTmp10Read)
        Me.tabPage4.Location = New System.Drawing.Point(4, 21)
        Me.tabPage4.Name = "tabPage4"
        Me.tabPage4.Size = New System.Drawing.Size(680, 370)
        Me.tabPage4.TabIndex = 6
        Me.tabPage4.Text = "Tmp10.0"
        Me.tabPage4.UseVisualStyleBackColor = True
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.ForeColor = System.Drawing.Color.Red
        Me.label6.Location = New System.Drawing.Point(95, 302)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(497, 12)
        Me.label6.TabIndex = 27
        Me.label6.Text = "It is for fingerprint templates management.(For devices with 10.0 arithmetic only" & _
            ")"
        '
        'lvTmp10
        '
        Me.lvTmp10.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader42, Me.columnHeader43, Me.columnHeader44, Me.columnHeader45, Me.columnHeader46})
        Me.lvTmp10.GridLines = True
        Me.lvTmp10.Location = New System.Drawing.Point(6, 6)
        Me.lvTmp10.Name = "lvTmp10"
        Me.lvTmp10.Size = New System.Drawing.Size(669, 280)
        Me.lvTmp10.TabIndex = 13
        Me.lvTmp10.UseCompatibleStateImageBehavior = False
        Me.lvTmp10.View = System.Windows.Forms.View.Details
        '
        'columnHeader42
        '
        Me.columnHeader42.Text = "Size"
        Me.columnHeader42.Width = 53
        '
        'columnHeader43
        '
        Me.columnHeader43.Text = "PIN"
        Me.columnHeader43.Width = 45
        '
        'columnHeader44
        '
        Me.columnHeader44.Text = "FingerID"
        Me.columnHeader44.Width = 72
        '
        'columnHeader45
        '
        Me.columnHeader45.Text = "Valid"
        Me.columnHeader45.Width = 87
        '
        'columnHeader46
        '
        Me.columnHeader46.Text = "Template"
        Me.columnHeader46.Width = 320
        '
        'btnTmp10Write
        '
        Me.btnTmp10Write.Location = New System.Drawing.Point(351, 329)
        Me.btnTmp10Write.Name = "btnTmp10Write"
        Me.btnTmp10Write.Size = New System.Drawing.Size(106, 23)
        Me.btnTmp10Write.TabIndex = 12
        Me.btnTmp10Write.Text = "WriteDataToFile"
        Me.btnTmp10Write.UseVisualStyleBackColor = True
        '
        'btnTmp10Read
        '
        Me.btnTmp10Read.Location = New System.Drawing.Point(215, 329)
        Me.btnTmp10Read.Name = "btnTmp10Read"
        Me.btnTmp10Read.Size = New System.Drawing.Size(88, 23)
        Me.btnTmp10Read.TabIndex = 11
        Me.btnTmp10Read.Text = "ReadDataToPC"
        Me.btnTmp10Read.UseVisualStyleBackColor = True
        '
        'tabPage5
        '
        Me.tabPage5.Controls.Add(Me.label9)
        Me.tabPage5.Controls.Add(Me.btnSSRSMSWrite)
        Me.tabPage5.Controls.Add(Me.btnSSRSMSRead)
        Me.tabPage5.Controls.Add(Me.lvSSRSMS)
        Me.tabPage5.Location = New System.Drawing.Point(4, 21)
        Me.tabPage5.Name = "tabPage5"
        Me.tabPage5.Size = New System.Drawing.Size(680, 370)
        Me.tabPage5.TabIndex = 8
        Me.tabPage5.Text = "SMS(TFT)"
        Me.tabPage5.UseVisualStyleBackColor = True
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.ForeColor = System.Drawing.Color.Red
        Me.label9.Location = New System.Drawing.Point(230, 302)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(221, 12)
        Me.label9.TabIndex = 34
        Me.label9.Text = "It is for short messages management."
        '
        'btnSSRSMSWrite
        '
        Me.btnSSRSMSWrite.Location = New System.Drawing.Point(351, 329)
        Me.btnSSRSMSWrite.Name = "btnSSRSMSWrite"
        Me.btnSSRSMSWrite.Size = New System.Drawing.Size(106, 23)
        Me.btnSSRSMSWrite.TabIndex = 33
        Me.btnSSRSMSWrite.Text = "WriteDataToFile"
        Me.btnSSRSMSWrite.UseVisualStyleBackColor = True
        '
        'btnSSRSMSRead
        '
        Me.btnSSRSMSRead.Location = New System.Drawing.Point(215, 329)
        Me.btnSSRSMSRead.Name = "btnSSRSMSRead"
        Me.btnSSRSMSRead.Size = New System.Drawing.Size(88, 23)
        Me.btnSSRSMSRead.TabIndex = 32
        Me.btnSSRSMSRead.Text = "ReadDataToPC"
        Me.btnSSRSMSRead.UseVisualStyleBackColor = True
        '
        'lvSSRSMS
        '
        Me.lvSSRSMS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader55, Me.columnHeader56, Me.columnHeader57, Me.columnHeader58, Me.columnHeader59, Me.columnHeader60})
        Me.lvSSRSMS.GridLines = True
        Me.lvSSRSMS.Location = New System.Drawing.Point(6, 6)
        Me.lvSSRSMS.Name = "lvSSRSMS"
        Me.lvSSRSMS.Size = New System.Drawing.Size(669, 280)
        Me.lvSSRSMS.TabIndex = 29
        Me.lvSSRSMS.UseCompatibleStateImageBehavior = False
        Me.lvSSRSMS.View = System.Windows.Forms.View.Details
        '
        'columnHeader55
        '
        Me.columnHeader55.Text = "Tag"
        Me.columnHeader55.Width = 55
        '
        'columnHeader56
        '
        Me.columnHeader56.Text = "ID"
        Me.columnHeader56.Width = 44
        '
        'columnHeader57
        '
        Me.columnHeader57.Text = "ValidMinutes"
        Me.columnHeader57.Width = 97
        '
        'columnHeader58
        '
        Me.columnHeader58.Text = "Reserved"
        Me.columnHeader58.Width = 82
        '
        'columnHeader59
        '
        Me.columnHeader59.Text = "StartTime"
        Me.columnHeader59.Width = 139
        '
        'columnHeader60
        '
        Me.columnHeader60.Text = "Content"
        Me.columnHeader60.Width = 224
        '
        'tabPage6
        '
        Me.tabPage6.Controls.Add(Me.label10)
        Me.tabPage6.Controls.Add(Me.btnUDataWrite)
        Me.tabPage6.Controls.Add(Me.btnUDataRead)
        Me.tabPage6.Controls.Add(Me.lvUData)
        Me.tabPage6.Location = New System.Drawing.Point(4, 21)
        Me.tabPage6.Name = "tabPage6"
        Me.tabPage6.Size = New System.Drawing.Size(680, 370)
        Me.tabPage6.TabIndex = 9
        Me.tabPage6.Text = "UData"
        Me.tabPage6.UseVisualStyleBackColor = True
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.ForeColor = System.Drawing.Color.Red
        Me.label10.Location = New System.Drawing.Point(140, 302)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(401, 12)
        Me.label10.TabIndex = 36
        Me.label10.Text = "It is for relationship management between short message and users."
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
        Me.tabPage2.ResumeLayout(False)
        Me.tabPage2.PerformLayout()
        Me.tabPage3.ResumeLayout(False)
        Me.tabPage3.PerformLayout()
        Me.tabPage4.ResumeLayout(False)
        Me.tabPage4.PerformLayout()
        Me.tabPage5.ResumeLayout(False)
        Me.tabPage5.PerformLayout()
        Me.tabPage6.ResumeLayout(False)
        Me.tabPage6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents btnSSR_UserWrite As System.Windows.Forms.Button
    Private WithEvents btnSSR_UserRead As System.Windows.Forms.Button
    Private WithEvents lvSSRUser As System.Windows.Forms.ListView
    Private WithEvents columnHeader9 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader10 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader11 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader12 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader13 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader14 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader15 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader16 As System.Windows.Forms.ColumnHeader
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents lvSSRAttLog As System.Windows.Forms.ListView
    Private WithEvents columnHeader22 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader23 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader24 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader31 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader32 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader33 As System.Windows.Forms.ColumnHeader
    Private WithEvents btnSSRAttLogRead As System.Windows.Forms.Button
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
    Private WithEvents tabPage4 As System.Windows.Forms.TabPage
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents lvTmp10 As System.Windows.Forms.ListView
    Private WithEvents columnHeader42 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader43 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader44 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader45 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader46 As System.Windows.Forms.ColumnHeader
    Private WithEvents btnTmp10Write As System.Windows.Forms.Button
    Private WithEvents btnTmp10Read As System.Windows.Forms.Button
    Private WithEvents tabPage5 As System.Windows.Forms.TabPage
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents btnSSRSMSWrite As System.Windows.Forms.Button
    Private WithEvents btnSSRSMSRead As System.Windows.Forms.Button
    Private WithEvents lvSSRSMS As System.Windows.Forms.ListView
    Private WithEvents columnHeader55 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader56 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader57 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader58 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader59 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader60 As System.Windows.Forms.ColumnHeader
    Private WithEvents tabPage6 As System.Windows.Forms.TabPage
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents btnUDataWrite As System.Windows.Forms.Button
    Private WithEvents btnUDataRead As System.Windows.Forms.Button
    Private WithEvents lvUData As System.Windows.Forms.ListView
    Private WithEvents columnHeader53 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader54 As System.Windows.Forms.ColumnHeader

End Class
