'**********************************************************
'* Demo for Standalone SDK.Created by Darcy on Dec.15 2009*
'**********************************************************

Public Class UserInfo

    'Create Standalone SDK class dynamicly.
    Public axCZKEM1 As New zkemkeeper.CZKEM

    '****************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.  *
    '* This part is for demonstrating the communication with your device.                               *
    '* **************************************************************************************************
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
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
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
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
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

        Dim sUserID As String = cbUserIDDE.Text.Trim()
        Dim iBackupNumber As Integer = Convert.ToInt32(cbBackupDE.Text.Trim())

        Cursor = Cursors.WaitCursor
        AxCZKEM1.EnableDevice(iMachineNumber, False)
        If AxCZKEM1.SSR_DeleteEnrollData(iMachineNumber, sUserID, iBackupNumber) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("DeleteEnrollData,UserID=" + sUserID + " BackupNumber=" + iBackupNumber.ToString(), MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Delete a certain user's fingerprint template of specified index
    'You shuold input the the user id and the fingerprint index you will delete
    'The difference between the two functions "SSR_DelUserTmpExt" and "SSR_DelUserTmp" is that the former supports 24 bits' user id.
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

        Dim sUserID As String = cbUserIDTmp.Text.Trim()
        Dim iFingerIndex As Integer = Convert.ToInt32(cbFingerIndex.Text.Trim())

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SSR_DelUserTmpExt(iMachineNumber, sUserID, iFingerIndex) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("SSR_DelUserTmpExt,UserID:" + sUserID + " FingerIndex:" + iFingerIndex.ToString(), MsgBoxStyle.Information, "Success")
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
    'Download user's 9.0 or 10.0 arithmetic fingerprint templates(in strings)
    'Only TFT screen devices with firmware version Ver 6.60 version later support function "GetUserTmpExStr" and "GetUserTmpEx".
    'While you are using 9.0 fingerprint arithmetic and your device's firmware version is under ver6.60,you should use the functions "SSR_GetUserTmp" or 
    '"SSR_GetUserTmpStr" instead of "GetUserTmpExStr" or "GetUserTmpEx" in order to download the fingerprint templates.
    Private Sub btnDownloadTmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownloadTmp9.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        Dim sdwEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim iTmpLength As Integer
        Dim iFlag As Integer

        Dim lvItem As New ListViewItem("Items", 0)

        lvDownload.Items.Clear()
        lvDownload.BeginUpdate()
        AxCZKEM1.EnableDevice(iMachineNumber, False)

        Cursor = Cursors.WaitCursor
        AxCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        AxCZKEM1.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory

        While AxCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            For idwFingerIndex = 0 To 9
                If AxCZKEM1.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory
                    lvItem = lvDownload.Items.Add(sdwEnrollNumber.ToString())
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
                    lvItem.SubItems.Add(iFlag.ToString())
                End If
            Next
        End While
        lvDownload.EndUpdate()
        AxCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
    End Sub
    'Upload the 9.0 or 10.0 fingerprint arithmetic templates to the device(in strings) in batches.
    'Only TFT screen devices with firmware version Ver 6.60 version later support function "SetUserTmpExStr" and "SetUserTmpEx".
    'While you are using 9.0 fingerprint arithmetic and your device's firmware version is under ver6.60,you should use the functions "SSR_SetUserTmp" or 
    '"SSR_SetUserTmpStr" instead of "SetUserTmpExStr" or "SetUserTmpEx" in order to upload the fingerprint templates.
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

        Dim sdwEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim sEnabled As String = ""
        Dim bEnabled As Boolean = False
        Dim iflag As Integer

        Dim iUpdateFlag As Integer = 1
        Dim lvItem As New ListViewItem

        Cursor = Cursors.WaitCursor
        AxCZKEM1.EnableDevice(iMachineNumber, False)

        If AxCZKEM1.BeginBatchUpdate(iMachineNumber, iUpdateFlag) Then 'create memory space for batching data
            Dim iLastEnrollNumber As Integer = 0 'the former enrollnumber you have upload(define original value as 0)
            For Each lvItem In lvDownload.Items
                sdwEnrollNumber = Convert.ToInt32(lvItem.SubItems(0).Text.Trim())
                sName = lvItem.SubItems(1).Text.Trim()
                idwFingerIndex = Convert.ToInt32(lvItem.SubItems(2).Text.Trim())
                sTmpData = lvItem.SubItems(3).Text.Trim()
                iPrivilege = Convert.ToInt32(lvItem.SubItems(4).Text.Trim())
                sPassword = lvItem.SubItems(5).Text.Trim()
                sEnabled = lvItem.SubItems(6).Text.Trim()
                iflag = Convert.ToInt32(lvItem.SubItems(7).Text.Trim())

                If sEnabled = "true" Then
                    bEnabled = True
                Else
                    bEnabled = False
                End If

                If sdwEnrollNumber <> iLastEnrollNumber Then 'identify whether the user information(except fingerprint templates) has been uploaded
                    If AxCZKEM1.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                        AxCZKEM1.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iflag, sTmpData) 'upload templates information to the device
                    Else
                        AxCZKEM1.GetLastError(idwErrorCode)
                        MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
                        Cursor = Cursors.Default
                        AxCZKEM1.EnableDevice(iMachineNumber, True)
                        Return
                    End If
                Else 'the current fingerprint and the former one belongs the same user,that is ,one user has more than one template
                    AxCZKEM1.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iflag, sTmpData) 'upload tempates information to the memory
                End If
                iLastEnrollNumber = sdwEnrollNumber 'change the value of iLastEnrollNumber dynamicly
            Next
        End If

        AxCZKEM1.BatchUpdate(iMachineNumber) 'upload all the information in the memory
        AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        AxCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
        MsgBox("Successfully upload fingerprint templates in batches , " + "total:" + lvDownload.Items.Count.ToString(), MsgBoxStyle.Information, "Success")
    End Sub
    'Upload the 9.0 or 10.0 fingerprint arithmetic templates one by one(in strings)
    ' Only TFT screen devices with firmware version Ver 6.60 version later support function "SetUserTmpExStr" and "SetUserTmpEx".
    'While you are using 9.0 fingerprint arithmetic and your device's firmware version is under ver6.60,you should use the functions "SSR_SetUserTmp" or 
    '"SSR_SetUserTmpStr" instead of "SetUserTmpExStr" or "SetUserTmpEx" in order to upload the fingerprint templates.
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload9.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If lvDownload.Items.Count = 0 Then
            MsgBox("There is no data to upload!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sdwEnrollNumber As String
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim sEnabled As String = ""
        Dim bEnabled As Boolean = False
        Dim iflag As Integer

        Cursor = Cursors.WaitCursor
        AxCZKEM1.EnableDevice(iMachineNumber, False)

        Dim lvItem As New ListViewItem

        For Each lvItem In lvDownload.Items
            sdwEnrollNumber = Convert.ToInt32(lvItem.SubItems(0).Text.Trim())
            sName = lvItem.SubItems(1).Text.Trim()
            idwFingerIndex = Convert.ToInt32(lvItem.SubItems(2).Text.Trim())
            sTmpData = lvItem.SubItems(3).Text.Trim()
            iPrivilege = Convert.ToInt32(lvItem.SubItems(4).Text.Trim())
            sPassword = lvItem.SubItems(5).Text.Trim()
            sEnabled = lvItem.SubItems(6).Text.Trim()
            iflag = Convert.ToInt32(lvItem.SubItems(7).Text.Trim())

            If sEnabled = "true" Then
                bEnabled = True
            Else
                bEnabled = False
            End If

            If AxCZKEM1.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                AxCZKEM1.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iflag, sTmpData) 'upload templates information to the device
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
    'Download users' face templates(in strings)(For TFT screen IFace series devices only)
    Private Sub btnDownLoadFace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownLoadFace.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        Dim sUserID As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False

        Dim iFaceIndex As Integer = 50 'the only possible parameter value
        Dim sTmpData As String = ""
        Dim iLength As Integer

        lvFace.Items.Clear()
        lvFace.BeginUpdate()

        Dim lvItem As New ListViewItem("Items", 0)

        Cursor = Cursors.WaitCursor
        AxCZKEM1.EnableDevice(iMachineNumber, False)
        AxCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory

        While AxCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sUserID, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            If AxCZKEM1.GetUserFaceStr(iMachineNumber, sUserID, iFaceIndex, sTmpData, iLength) = True Then 'get the face templates from the memory
                lvItem = lvFace.Items.Add(sUserID)
                lvItem.SubItems.Add(sName)
                lvItem.SubItems.Add(sPassword)
                lvItem.SubItems.Add(iPrivilege.ToString())
                lvItem.SubItems.Add(iFaceIndex.ToString())
                lvItem.SubItems.Add(sTmpData)
                lvItem.SubItems.Add(iLength.ToString())
                If bEnabled = True Then
                    lvItem.SubItems.Add("true")
                Else
                    lvItem.SubItems.Add("false")
                End If
            End If
        End While
        lvFace.EndUpdate()
        AxCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
    End Sub
    'Upload users' face template(in strings)(For TFT screen IFace series devices only)
    'Uploading the face templates in batches is not supported temporarily.
    Private Sub btnUploadFace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadFace.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sUserID As String = ""
        Dim sName As String = ""
        Dim iFaceIndex As Integer
        Dim iLength As Integer
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim sTmpData As String = ""
        Dim sEnabled As String = ""
        Dim bEnabled As Boolean = False

        Cursor = Cursors.WaitCursor
        AxCZKEM1.EnableDevice(iMachineNumber, False)

        Dim lvItem As New ListViewItem

        For Each lvItem In lvFace.Items
            sUserID = lvItem.SubItems(0).Text.Trim()
            sName = lvItem.SubItems(1).Text.Trim()
            sPassword = lvItem.SubItems(2).Text.Trim()
            iPrivilege = Convert.ToInt32(lvItem.SubItems(3).Text.Trim())
            iFaceIndex = Convert.ToInt32(lvItem.SubItems(4).Text.Trim())
            sTmpData = lvItem.SubItems(5).Text.Trim()
            iLength = Convert.ToInt32(lvItem.SubItems(6).Text.Trim())

            If sEnabled = "true" Then
                bEnabled = True
            Else
                bEnabled = False
            End If

            If AxCZKEM1.SSR_SetUserInfo(iMachineNumber, sUserID, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                AxCZKEM1.SetUserFaceStr(iMachineNumber, sUserID, iFaceIndex, sTmpData, iLength) 'upload face templates information to the device
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
        MsgBox("Successfully Upload the face templates, " + "total:" + lvFace.Items.Count.ToString(), MsgBoxStyle.Information, "Success")
    End Sub
    'Delete a certain user's face template according to its id
    Private Sub btnDelUserFace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelUserFace.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbUserID3.Text.Trim() = "" Then
            MsgBox("Please input the UserID first!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sUserID As String = cbUserID3.Text.Trim()
        Dim iFaceIndex As Integer = 50

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.DelUserFace(iMachineNumber, sUserID, iFaceIndex) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("DelUserFace,UserID=" + sUserID, MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Download specified user's face template (in bytes array)    
    'You can refer to the part of "Udisk data Management" to learn how to manage the user's binary template(Get or Set)
    Private Sub btnGetUserFace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetUserFace.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbUserID3.Text.Trim() = "" Then
            MsgBox("Please input the UserID first!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sUserID As String = cbUserID3.Text.Trim()
        Dim iFaceIndex As Integer = 50 'the only possible parameter value
        Dim iLength As Integer = 128 * 1024 'initialize the length(cannot be zero)
        Dim byTmpData(iLength) As Byte

        Cursor = Cursors.WaitCursor
        AxCZKEM1.EnableDevice(iMachineNumber, False)

        If AxCZKEM1.GetUserFace(iMachineNumber, sUserID, iFaceIndex, byTmpData(0), iLength) = True Then
            'Here you can manage the information of the face templates according to your request.(for example,you can sava them to the database)
            MsgBox("GetUserFace,the  length of the bytes array byTmpData is " + iLength.ToString(), MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        AxCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
    End Sub
    'Add the existed userid to DropDownLists.
    Dim bAddControl As Boolean = True
    Private Sub UserIDTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserIDTimer.Tick
        If bIsConnected = False Then
            cbUserIDDE.Items.Clear()
            cbUserIDTmp.Items.Clear()
            cbUserID3.Items.Clear()
            bAddControl = True
            Return
        Else
            If bAddControl = True Then
                Dim sEnrollNumber As String = ""
                Dim sName As String = ""
                Dim sPassword As String = ""
                Dim iPrivilege As Integer
                Dim bEnabled As Boolean = False

                AxCZKEM1.EnableDevice(iMachineNumber, False)
                AxCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
                While AxCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True
                    cbUserIDDE.Items.Add(sEnrollNumber)
                    cbUserIDTmp.Items.Add(sEnrollNumber)
                    cbUserID3.Items.Add(sEnrollNumber)
                End While

                bAddControl = False
                AxCZKEM1.EnableDevice(iMachineNumber, True)
            End If
            Return
        End If
    End Sub
#End Region
End Class

