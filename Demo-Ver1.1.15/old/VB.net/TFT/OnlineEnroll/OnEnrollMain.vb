'**********************************************************
'* Demo for Standalone SDK.Created by Darcy on Dec.15 2009*
'**********************************************************

Public Class OnEnrollMain

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
    'If your device supports the USBCLient, you can refer to this.
    'Not all series devices can support this kind of connection.Please make sure your device supports USBClient.
    'Connect the device via the virtual serial port created by USBClient
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

        Dim sCom As String = ""
        Dim bSearch As Boolean
        Dim usbcom As New SearchforUSBCom 'new
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

        If bIsConnected = True Then
            btnUSBConnect.Text = "Disconnect"
            btnUSBConnect.Refresh()
            lblState.Text = "Current State:Connected"
            AxCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want 
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
#End Region

    '***********************************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.                     *
    '* This part is for demonstrating how to enroll your fingerprint online and save the templates(binary) to the database.*
    '* *********************************************************************************************************************
#Region "OnlineEnroll"
    'Make sure you have enrolled the fingerprint templates you will save.
    Dim iCanSaveTmp As String = 0
    'Enroll a certain user's specified fingerprint template online.
    'Only TFT screen devices with firmware version Ver 6.60 version later support duress fingerprint.
    'While you are using 9.0 fingerprint arithmetic and your device's firmware version is under ver6.60,you should set 
    'the paremeter flag of function "StartEnrollEx" as an integer 1.
    Private Sub btnStartEnroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartEnroll.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If txtUserID.Text.Trim() = "" Or cbFingerIndex.Text.Trim() = "" Or cbFlag.Text.Trim = "" Then
            MsgBox("UserID,FingerIndex must be inputted first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iUserID As String = Convert.ToInt32(txtUserID.Text.Trim())
        Dim sUserID = txtUserID.Text.Trim()
        Dim iFingerIndex = Convert.ToInt32(cbFingerIndex.Text.Trim())
        Dim iFlag As Integer = Convert.ToInt32(cbFlag.Text.Trim())

        AxCZKEM1.CancelOperation()
        AxCZKEM1.SSR_DelUserTmpExt(iMachineNumber, sUserID, iFingerIndex)
        If AxCZKEM1.StartEnrollEx(sUserID, iFingerIndex, iFlag) = True Then
            MsgBox("Start to Enroll a new User,UserID=" + sUserID + " FingerID=" + iFingerIndex.ToString() + " Flag=" + iFlag.ToString(), MsgBoxStyle.Information, "Start")
            iCanSaveTmp = 1
            AxCZKEM1.StartIdentify() 'After enrolling templates,you should let the device into the 1:N verification condition
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub
#End Region

#Region "Save Enrolled FingerPrint Templates to the DataBase(in binary)"
    'Save the tempaltes data you have just enrolled.
    'Here we mainly demonstrate how you can get the binary fingerprint templates from the device and save them into the databuse.
    'If you want to save the templates in strings to the database,you can modify the followding codes.
    'Only TFT screen devices with firmware version Ver 6.60 version later support function "GetUserTmpExStr" and "GetUserTmpEx".
    'While you are using 9.0 fingerprint arithmetic and your device's firmware version is under ver6.60,you should use the functions "SSR_GetUserTmp" or 
    '"SSR_GetUserTmpStr" instead of "GetUserTmpExStr" or "GetUserTmpEx" in order to download the fingerprint templates.
    Private Sub btnSaveEnrolledTmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveEnrolledTmp.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If iCanSaveTmp = 0 Then 'You haven't enrolled the templates.
            MsgBox("Please enroll the fingerprint templates first!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        Dim connString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\data\Templates.mdb"
        Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(connString)

        Dim idwFingerIndex As Double = Convert.ToDouble(cbFingerIndex.Text.Trim())
        Dim iTmpLength As Double
        Dim sdwEnrollNumber As String = txtUserID.Text.Trim()
        Dim iFlag As Integer
        Dim byTmpData(2000) As Byte
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False

        AxCZKEM1.EnableDevice(iMachineNumber, False)
        Cursor = Cursors.WaitCursor
        AxCZKEM1.ReadAllTemplate(iMachineNumber)

        While AxCZKEM1.SSR_GetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True
            If AxCZKEM1.GetUserTmpEx(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, byTmpData(0), iTmpLength) = True Then
                ' If you need to select or delete the data in the database ,you can just define the sql sentences by youself
                Dim sql As String
                sql = "insert into Template(UserID,FingerID,Template,TmpLen,Flag) values('" & sdwEnrollNumber & "','" & idwFingerIndex & "','" & byTmpData(0) & "','" & iTmpLength & "','" & iFlag & "')"
                Dim cmd As OleDb.OleDbCommand = New OleDb.OleDbCommand(sql, conn)
                conn.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Successfully save templates to database ! ", MsgBoxStyle.Information, "Success")
            Else
                MsgBox("Saving templates to database failed ! ", MsgBoxStyle.Information, "Error")
            End If
        End While
        AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        AxCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
    End Sub
#End Region
End Class
