'**********************************************************
'* Demo for Standalone SDK.Created by Darcy on Dec.15 2009*
'**********************************************************

Public Class UserInfo

    'Create Standalone SDK class dynamicly.
    Public axCZKEM1 As New zkemkeeper.CZKEM

    '*********************************************************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.                                           *
    '* This part is for demonstrating the communication with your device.There are 3 communication ways: "TCP/IP","Serial Port" and "USB Client".*
    '* The communication way which you can use duing to the model of the device.                                                                 *
    '* *******************************************************************************************************************************************
#Region "Communication"
    Private bIsConnected = False 'the boolean value identifies whether the device is connected
    Private iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.

    'If your device supports the TCP/IP communications, you can refer to this.
    'when you are using the tcp/ip communication,you can distinguish different devices by their IP address.
    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        If txtIP.Text.Trim() = "" Or txtPort.Text.Trim() = "" Then
            MsgBox("IP and Port cannot be null", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer
        Cursor = Cursors.WaitCursor
        If btnConnect.Text = "Disconnect" Then
            AxCZKEM1.Disconnect()
            bIsConnected = False
            btnConnect.Text = "Connect"
            lblState.Text = "Current State:Disconnected"
            Cursor = Cursors.Default
            Return
        End If

        bIsConnected = AxCZKEM1.Connect_Net(txtIP.Text.Trim(), Convert.ToInt32(txtPort.Text.Trim()))
        If bIsConnected = True Then
            btnConnect.Text = "Disconnect"
            btnConnect.Refresh()
            lblState.Text = "Current State:Connected"
            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            AxCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'If your device supports the SerialPort communications, you can refer to this.
    Private Sub btnRsConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRsConnect.Click
        If cbPort.Text.Trim() = "" Or cbBaudRate.Text.Trim() = "" Or txtMachineSN.Text.Trim() = "" Then
            MsgBox("Port,BaudRate and MachineSN cannot be null", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        'accept serialport number from string like "COMi"
        Dim iPort As Integer
        'Dim sPort = cbPort.Text.Trim()
        Dim sPort As String = cbPort.Text.Trim()
        For iPort = 1 To 9
            If sPort.IndexOf(iPort.ToString()) > -1 Then
                Exit For
            End If
        Next

        Cursor = Cursors.WaitCursor
        If btnRsConnect.Text = "Disconnect" Then
            AxCZKEM1.Disconnect()
            bIsConnected = False
            btnRsConnect.Text = "Connect"
            lblState.Text = "Current State:Disconnected"
            Cursor = Cursors.Default
            Return
        End If

        iMachineNumber = Convert.ToInt32(txtMachineSN.Text.Trim()) '//when you are using the serial port communication,you can distinguish different devices by their serial port number.
        bIsConnected = AxCZKEM1.Connect_Com(iPort, iMachineNumber, Convert.ToInt32(cbBaudRate.Text.Trim()))

        If bIsConnected = True Then
            btnRsConnect.Text = "Disconnect"
            btnRsConnect.Refresh()
            lblState.Text = "Current State:Connected"
            AxCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'If your device supports the USBCLient, you can refer to this.
    'Not all series devices can support this kind of connection.Please make sure your device supports USBClient.
    Private Sub btnUSBConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUSBConnect.Click
        Dim idwErrorCode As Integer

        Cursor = Cursors.WaitCursor
        If btnUSBConnect.Text = "Disconnect" Then
            AxCZKEM1.Disconnect()
            bIsConnected = False
            btnUSBConnect.Text = "Connect"
            lblState.Text = "Current State:Disconnected"
            Cursor = Cursors.Default
            Return
        End If

        If rbUSB.Checked = True Then 'the common USBClient
            iMachineNumber = 1 'In fact,when you are using common USBClient communication,parameter Machinenumber will be ignored,that is any integer will all right.Here we use 1.
            bIsConnected = AxCZKEM1.Connect_USB(iMachineNumber)
        Else
            If rbVUSB.Checked = True Then 'connect the device via the virtual serial port created by USB
                Dim sCom As String = ""
                Dim bSearch As Boolean
                Dim usbcom As New SearchforUSBCom
                bSearch = usbcom.SearchforCom(sCom)

                If bSearch = False Then
                    MsgBox("Can not find the virtual serial port that can be used", MsgBoxStyle.Exclamation, "Error")
                    Cursor = Cursors.Default
                    Return
                End If

                Dim iPort As Integer
                For iPort = 1 To 9
                    If sCom.IndexOf(iPort.ToString()) > -1 Then
                        Exit For
                    End If
                Next

                iMachineNumber = Convert.ToInt32(txtMachineSN2.Text.Trim())
                If iMachineNumber = 0 Or iMachineNumber > 255 Then
                    MsgBox("The Machine Number is invalid!", MsgBoxStyle.Exclamation, "Error")
                    Cursor = Cursors.Default
                    Return
                End If

                Dim iBaudRate = 115200 '115200 is one possible baudrate value(its value cannot be 0)
                bIsConnected = AxCZKEM1.Connect_Com(iPort, iMachineNumber, iBaudRate)
            End If

        End If

        If bIsConnected = True Then
            btnUSBConnect.Text = "Disconnect"
            btnUSBConnect.Refresh()
            lblState.Text = "Current State:Connected"
            AxCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want 
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub rbVUSB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbVUSB.CheckedChanged
        If rbVUSB.Checked = True Then
            If bIsConnected = True Then
                MsgBox("Invalid Operation!", MsgBoxStyle.Exclamation, "Error")
                rbVUSB.Checked = False
                Return
            End If
            rbUSB.Checked = False
            txtMachineSN2.Enabled = True
        End If
    End Sub

    Private Sub rbUSB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUSB.CheckedChanged
        If rbUSB.Checked = True Then
            If bIsConnected = True Then
                MsgBox("Invalid Operation!", MsgBoxStyle.Exclamation, "Error")
                rbUSB.Checked = False
                Return
            End If
            rbVUSB.Checked = False
            txtMachineSN2.Enabled = False
        End If
    End Sub
#End Region

    '**************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.*
    '* This part is for demonstrating operations with user(download/upload/delete/clear/modify).      *
    '* ************************************************************************************************
#Region "UserInfo"
    'Delete a kind of data that some user has enrolled
    'The range of the Backup Number is from 0 to 9 and the specific meaning of Backup number is described in the development manual,pls refer to it.
    Private Sub btnDeleteEnrollData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteEnrollData.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbUserIDDE.Text.Trim() = "" Or cbBackupDE.Text.Trim() = "" Then
            MsgBox("Please input the UserID and BackupNumber first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iUserID As Integer = Convert.ToInt32(cbUserIDDE.Text.Trim())
        Dim iBackupNumber As Integer = Convert.ToInt32(cbBackupDE.Text.Trim())

        Cursor = Cursors.WaitCursor
        AxCZKEM1.EnableDevice(iMachineNumber, False)
        If AxCZKEM1.DeleteEnrollData(iMachineNumber, iUserID, 1, iBackupNumber) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("DeleteEnrollData,UserID=" + iUserID.ToString() + " BackupNumber=" + iBackupNumber.ToString(), MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnDelUserTmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelUserTmp.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbUserIDTmp.Text.Trim() = "" Or cbFingerIndex.Text.Trim() = "" Then
            MsgBox("Please input the UserID and FingerIndex first!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iUserID As Integer = Convert.ToInt32(cbUserIDTmp.Text.Trim())
        Dim iFingerIndex As Integer = Convert.ToInt32(cbFingerIndex.Text.Trim())

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.DelUserTmp(iMachineNumber, iUserID, iFingerIndex) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("DelUserTmp,UserID:" + iUserID.ToString() + " FingerIndex:" + iFingerIndex.ToString(), MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    ''Clear all the fingerprint templates in the device(While the parameter DataFlag  of the Function "ClearData" is 2 )
    Private Sub btnClearDataTmps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDataTmps.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iDataFlag As Integer = 2
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.ClearData(iMachineNumber, iDataFlag) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Clear all the fingerprint templates!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Delete all the user information in the device,while the related fingerprint templates will be deleted either. 
    '(While the parameter DataFlag  of the Function "ClearData" is 5 )
    Private Sub btnClearDataUserInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDataUserInfo.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iDataFlag As Integer = 5
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.ClearData(iMachineNumber, iDataFlag) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Clear all the UserInfo data!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Clear all the administrator privilege(not clear the administrators themselves)
    Private Sub btnClearAdministrators_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAdministrators.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.ClearAdministrators(iMachineNumber) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Successfully clear administrator privilege from teiminal!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Download user's 9.0 arithmetic fingerprint template in batches.(in strings)
    Private Sub btnDownloadTmpBatch9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownloadTmpBatch9.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        'judge whether the device supports 9.0 fingerprint arithmetic
        Dim sOption As String = "~ZKFPVersion"
        Dim sValue As String = ""
        If AxCZKEM1.GetSysOption(iMachineNumber, sOption, sValue) = True Then
            If sValue = "10" Then
                MsgBox("Your device is not using 9.0 arithmetic!", MsgBoxStyle.Exclamation, "Error")
                Return
            End If
        End If

        Dim idwEnrollNumber As Integer
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim iTmpLength As Integer

        Dim lvItem As New ListViewItem("Items", 0)

        lvDownload.Items.Clear()
        lvDownload.BeginUpdate()
        AxCZKEM1.EnableDevice(iMachineNumber, False)

        Cursor = Cursors.WaitCursor
        AxCZKEM1.BeginBatchUpdate(iMachineNumber, 1) 'create memory space for batching data
        AxCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        AxCZKEM1.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory

        While AxCZKEM1.GetAllUserInfo(iMachineNumber, idwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            For idwFingerIndex = 0 To 9
                If AxCZKEM1.GetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFingerIndex, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory
                    lvItem = lvDownload.Items.Add(idwEnrollNumber.ToString())
                    lvItem.SubItems.Add(sName)
                    lvItem.SubItems.Add(idwFingerIndex.ToString())
                    lvItem.SubItems.Add(sTmpData)
                    lvItem.SubItems.Add(iPrivilege.ToString())
                    lvItem.SubItems.Add(sPassword)
                    If bEnabled = True Then
                        lvItem.SubItems.Add("true")
                    Else
                        lvItem.SubItems.Add("false")
                    End If
                End If
            Next
        End While
        lvDownload.EndUpdate()
        AxCZKEM1.BatchUpdate(iMachineNumber) 'download all the information in the memory
        AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        AxCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
    End Sub
    'Download user's 9.0 arithmetic fingerprint template(in strings)¡¡
    Private Sub btnDownloadTmp9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownloadTmp9.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        'judge whether the device supports 9.0 fingerprint arithmetic
        Dim sOption As String = "~ZKFPVersion"
        Dim sValue As String = ""
        If AxCZKEM1.GetSysOption(iMachineNumber, sOption, sValue) = True Then
            If sValue = "10" Then
                MsgBox("Your device is not using 9.0 arithmetic!", MsgBoxStyle.Exclamation, "Error")
                Return
            End If
        End If

        Dim idwEnrollNumber As Integer
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim iTmpLength As Integer

        Dim lvItem As New ListViewItem("Items", 0)

        lvDownload.Items.Clear()
        lvDownload.BeginUpdate()
        AxCZKEM1.EnableDevice(iMachineNumber, False)

        Cursor = Cursors.WaitCursor
        AxCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        AxCZKEM1.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory

        While AxCZKEM1.GetAllUserInfo(iMachineNumber, idwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            For idwFingerIndex = 0 To 9
                If AxCZKEM1.GetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFingerIndex, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory
                    lvItem = lvDownload.Items.Add(idwEnrollNumber.ToString())
                    lvItem.SubItems.Add(sName)
                    lvItem.SubItems.Add(idwFingerIndex.ToString())
                    lvItem.SubItems.Add(sTmpData)
                    lvItem.SubItems.Add(iPrivilege.ToString())
                    lvItem.SubItems.Add(sPassword)
                    If bEnabled = True Then
                        lvItem.SubItems.Add("true")
                    Else
                        lvItem.SubItems.Add("false")
                    End If
                End If
            Next
        End While
        lvDownload.EndUpdate()
        AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        AxCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
    End Sub
    'Upload the 9.0 fingerprint arithmetic templates to the device(in strings) in batches
    Private Sub btnBatchUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatchUpdate.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If lvDownload.Items.Count = 0 Then
            MsgBox("There is no data to upload!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim idwEnrollNumber As Integer
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim sEnabled As String = ""
        Dim bEnabled As Boolean = False

        Dim iUpdateFlag As Integer = 1
        Dim lvItem As New ListViewItem

        Cursor = Cursors.WaitCursor
        AxCZKEM1.EnableDevice(iMachineNumber, False)

        If AxCZKEM1.BeginBatchUpdate(iMachineNumber, iUpdateFlag) Then 'create memory space for batching data
            Dim iLastEnrollNumber As Integer = 0 'the former enrollnumber you have upload(define original value as 0)
            For Each lvItem In lvDownload.Items
                idwEnrollNumber = Convert.ToInt32(lvItem.SubItems(0).Text.Trim())
                sName = lvItem.SubItems(1).Text.Trim()
                idwFingerIndex = Convert.ToInt32(lvItem.SubItems(2).Text.Trim())
                sTmpData = lvItem.SubItems(3).Text.Trim()
                iPrivilege = Convert.ToInt32(lvItem.SubItems(4).Text.Trim())
                sPassword = lvItem.SubItems(5).Text.Trim()
                sEnabled = lvItem.SubItems(6).Text.Trim()

                If sEnabled = True Then
                    bEnabled = True
                Else
                    bEnabled = False
                End If

                If idwEnrollNumber <> iLastEnrollNumber Then 'identify whether the user information(except fingerprint templates) has been uploaded
                    If AxCZKEM1.SetUserInfo(iMachineNumber, idwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                        AxCZKEM1.SetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFingerIndex, sTmpData) 'upload templates information to the device
                    Else
                        AxCZKEM1.GetLastError(idwErrorCode)
                        MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
                        Cursor = Cursors.Default
                        AxCZKEM1.EnableDevice(iMachineNumber, True)
                        Return
                    End If
                Else 'the current fingerprint and the former one belongs the same user,that is ,one user has more than one template
                    AxCZKEM1.SetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFingerIndex, sTmpData) 'upload tempates information to the memory
                End If
                iLastEnrollNumber = idwEnrollNumber 'change the value of iLastEnrollNumber dynamicly
            Next
        End If
       
        AxCZKEM1.BatchUpdate(iMachineNumber) 'upload all the information in the memory
        AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        AxCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
        MsgBox("Successfully upload fingerprint templates in batches , " + "total:" + lvDownload.Items.Count.ToString(), MsgBoxStyle.Information, "Success")
    End Sub
    'Upload the 9.0 fingerprint arithmetic templates one by one(in strings)
    Private Sub btnUpload9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload9.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If lvDownload.Items.Count = 0 Then
            MsgBox("There is no data to upload!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim idwEnrollNumber As Integer
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim sEnabled As String = ""
        Dim bEnabled As Boolean = False

        Cursor = Cursors.WaitCursor
        AxCZKEM1.EnableDevice(iMachineNumber, False)

        Dim lvItem As New ListViewItem

        For Each lvItem In lvDownload.Items
            idwEnrollNumber = Convert.ToInt32(lvItem.SubItems(0).Text.Trim())
            sName = lvItem.SubItems(1).Text.Trim()
            idwFingerIndex = Convert.ToInt32(lvItem.SubItems(2).Text.Trim())
            sTmpData = lvItem.SubItems(3).Text.Trim()
            iPrivilege = Convert.ToInt32(lvItem.SubItems(4).Text.Trim())
            sPassword = lvItem.SubItems(5).Text.Trim()
            sEnabled = lvItem.SubItems(6).Text.Trim()

            If sEnabled = True Then
                bEnabled = True
            Else
                bEnabled = False
            End If

            If AxCZKEM1.SetUserInfo(iMachineNumber, idwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                AxCZKEM1.SetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFingerIndex, sTmpData) 'upload templates information to the device
            Else
                AxCZKEM1.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
                AxCZKEM1.EnableDevice(iMachineNumber, True)
                Cursor = Cursors.Default
                Return
            End If
        Next

        AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        AxCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
        MsgBox("Successfully Upload fingerprint templates, " + "total:" + lvDownload.Items.Count.ToString(), MsgBoxStyle.Information, "Success")
    End Sub
    ''Add the existed userid to DropDownLists.
    Dim bAddControl As Boolean = True
    Private Sub UserIDTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserIDTimer.Tick
        If bIsConnected = False Then
            cbUserIDDE.Items.Clear()
            cbUserIDTmp.Items.Clear()
            bAddControl = True
            Return
        Else
            If bAddControl = True Then
                Dim iEnrollNumber As Integer
                Dim iEMachineNumber As Integer
                Dim iBackupNumber As Integer
                Dim iPrivilege As Integer
                Dim ienabled As Integer

                AxCZKEM1.EnableDevice(iMachineNumber, False)
                AxCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
                While AxCZKEM1.GetAllUserID(iMachineNumber, iEnrollNumber, iEMachineNumber, iBackupNumber, iPrivilege, ienabled) = True
                    cbUserIDDE.Items.Add(iEnrollNumber)
                    cbUserIDTmp.Items.Add(iEnrollNumber)
                End While

                bAddControl = False
                AxCZKEM1.EnableDevice(iMachineNumber, True)
            End If
            Return
        End If
    End Sub
#End Region
   
End Class
