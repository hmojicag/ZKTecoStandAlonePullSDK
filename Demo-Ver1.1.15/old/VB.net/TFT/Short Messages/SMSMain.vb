'**********************************************************
'* Demo for Standalone SDK.Created by Darcy on Dec.15 2009*
'**********************************************************

Public Class ShortMessages

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

    '****************************************************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.                                      *
    '* The operations include setting or getting the short messages/users short messages,deleting short messages/messages of a certain user,*
    '* clearing all the short messages/the relationship between users and short messages                                                    *
    '****************************************************************************************************************************************
#Region "Short Messages"

    'When the form is loaded,add the current time to the textbox as the start tiem to be edited.
    Private Sub ShortMessages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As Date = DateAndTime.Now
        txtStartTime.Text = String.Format("{0:g}", dt)
    End Sub
    'Delete the short message by its id.
    'You should input the id of the short message that you want to delete
    Private Sub btnDeleteSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteSMS.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iSMSID As Integer = Convert.ToInt32(cbID2.Text.Trim())
        Dim iTag As Integer
        Dim iValidMins As Integer
        Dim sStartTime As String = ""
        Dim sContent As String = ""

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetSMS(iMachineNumber, iSMSID, iTag, iValidMins, sStartTime, sContent) = False Then
            MsgBox("The SMS doesn't exist! ", MsgBoxStyle.Exclamation, "Error")
            Cursor = Cursors.Default
            Return
        End If

        iSMSID = Convert.ToInt32(cbID2.Text.Trim()) 'the appoited short message id to be deleted
        If AxCZKEM1.DeleteSMS(iMachineNumber, iSMSID) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'After you have delete the short message,you should refresh the data of the device
            MsgBox("Successfully Delete corresponding SMS!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Delete relativity between the appoited user and the short message relating with the user.
    'You should input the user's id and the short message id relating with the user.
    Private Sub btnDeleteUserSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteUserSMS.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbID2.Text.Trim() = "" Or cbUserID2.Text.Trim() = "" Then
            MsgBox("Please input the user'id and sms id first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iSMSID As Integer = Convert.ToInt32(cbID2.Text.Trim())
        Dim sEnrollNumber As String = cbUserID2.Text.Trim()

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SSR_DeleteUserSMS(iMachineNumber, sEnrollNumber, iSMSID) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'After you have delete the short message,you should refresh the data of the device
            MsgBox("Successfully Delete user SMS!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set short messages. 
    'You should input the five parameters:Short Message ID,the tag of the message,the Valid Minutes,the Start Time and the Short Messages Content.
    'If you want to set personal message, you should use function SetUserSMS to establish the correlation between users and short messages.
    Private Sub btnSetSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetSMS.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iSMSID As Integer = Convert.ToInt32(cbSMSID.Text.Trim())
        Dim iTag As Integer
        Dim iValidMins As Integer
        Dim sStartTime As String = ""
        Dim sContent As String = ""

        Cursor = Cursors.WaitCursor

        If AxCZKEM1.GetSMS(iMachineNumber, iSMSID, iTag, iValidMins, sStartTime, sContent) = True Then
            MsgBox("The ID has existed!Pls change it! ", MsgBoxStyle.Exclamation, "Error")
            Cursor = Cursors.Default
            Return
        End If

        iSMSID = Convert.ToInt32(cbSMSID.Text.Trim())
        iValidMins = Convert.ToInt32(txtValidMins.Text.Trim())
        sStartTime = txtStartTime.Text.Trim()
        sContent = txtContent.Text.Trim()

        Dim sTag As String = cbTag.Text.Trim()
        For iTag = 253 To 255
            If sTag.IndexOf(iTag.ToString()) > -1 Then
                Exit For
            End If
        Next

        If AxCZKEM1.SetSMS(iMachineNumber, iSMSID, iTag, iValidMins, sStartTime, sContent) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Successfully set SMS! SMSType=" + iTag.ToString(), MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get short messages through the Short Message ID .
    'The returned values of the Short Message includes the tag of the message,the valid time, the start time and its content.
    Private Sub btnGetSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetSMS.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbSMSID.Text.Trim() = "" Then
            MsgBox("Please input the ID first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iSMSID As Integer = Convert.ToInt32(cbSMSID.Text.Trim())
        Dim iTag As Integer
        Dim iValidMins As Integer
        Dim sStartTime As String = ""
        Dim sContent As String = ""

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetSMS(iMachineNumber, iSMSID, iTag, iValidMins, sStartTime, sContent) = True Then
            cbSMSID.Text = iSMSID.ToString()
            cbTag.Text = iTag.ToString()
            txtValidMins.Text = iValidMins.ToString()
            Dim dt As Date
            dt = Convert.ToDateTime(sStartTime)
            txtStartTime.Text = String.Format("{0:g}", dt) 'Here show the time for you to edit.(Seconds is not necessary)
            txtContent.Text = sContent
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Clear all the short messages in the device
    Private Sub btnClearSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSMS.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.ClearSMS(iMachineNumber) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Successfully Clear all the SMSs!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Delete relativity between  users and short messages.(It wont delete the short messages themselves)
    Private Sub btnClearUserSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearUserSMS.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.ClearUserSMS(iMachineNumber) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Successfully Clear all the UserSMS!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set a certain user's corresponding short message 
    'You should input the two parameters: the user's enrollnumber(ID) and the short message's ID.
    Private Sub btnSetUserSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetUserSMS.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbID.Text.Trim() = "" Or cbUserID.Text.Trim() = "" Then
            MsgBox("Please input the UserID and SMSID first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iSMSID As Integer = Convert.ToInt32(cbID.Text.Trim())
        Dim iTag As Integer
        Dim iValidMins As Integer
        Dim sStartTime As String = ""
        Dim sContent As String = ""

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetSMS(iMachineNumber, iSMSID, iTag, iValidMins, sStartTime, sContent) = False Then
            MsgBox("The SMSID doesn't exist!", MsgBoxStyle.Exclamation, "Error")
            Cursor = Cursors.Default
            Return
        End If

        Dim sEnrollNumber As String = cbUserID.Text.Trim()
        If AxCZKEM1.SSR_SetUserSMS(iMachineNumber, sEnrollNumber, iSMSID) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Successfully Set user SMS!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Add the existed userid to DropDownLists.
    Dim bAddControl As Boolean = True
    Private Sub UserIDTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserIDTimer.Tick
        If bIsConnected = False Then
            cbUserID.Items.Clear()
            cbUserID2.Items.Clear()
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
                    cbUserID.Items.Add(sEnrollNumber)
                    cbUserID2.Items.Add(sEnrollNumber)
                End While

                bAddControl = False
                AxCZKEM1.EnableDevice(iMachineNumber, True)
            End If
            Return
        End If
    End Sub
#End Region
End Class
