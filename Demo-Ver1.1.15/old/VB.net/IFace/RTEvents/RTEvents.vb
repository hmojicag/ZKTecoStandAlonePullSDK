'**********************************************************
'* Demo for Standalone SDK.Created by Darcy on Dec.15 2009*
'**********************************************************

Public Class RTEvents

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
            axCZKEM1.Disconnect()

            RemoveHandler axCZKEM1.OnFinger, AddressOf AxCZKEM1_OnFinger
            RemoveHandler axCZKEM1.OnFingerFeature, AddressOf AxCZKEM1_OnFingerFeature
            RemoveHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
            RemoveHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
            RemoveHandler axCZKEM1.OnEnrollFingerEx, AddressOf AxCZKEM1_OnEnrollFingerEx
            RemoveHandler axCZKEM1.OnDeleteTemplate, AddressOf AxCZKEM1_OnDeleteTemplate
            RemoveHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
            RemoveHandler axCZKEM1.OnAlarm, AddressOf AxCZKEM1_OnAlarm
            RemoveHandler axCZKEM1.OnDoor, AddressOf AxCZKEM1_OnDoor
            RemoveHandler axCZKEM1.OnWriteCard, AddressOf AxCZKEM1_OnWriteCard
            RemoveHandler axCZKEM1.OnEmptyCard, AddressOf AxCZKEM1_OnEmptyCard
            RemoveHandler axCZKEM1.OnHIDNum, AddressOf AxCZKEM1_OnHIDNum

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

            If axCZKEM1.RegEvent(iMachineNumber, 65535) = True Then 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

                AddHandler axCZKEM1.OnFinger, AddressOf AxCZKEM1_OnFinger
                AddHandler axCZKEM1.OnFingerFeature, AddressOf AxCZKEM1_OnFingerFeature
                AddHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
                AddHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
                AddHandler axCZKEM1.OnEnrollFingerEx, AddressOf AxCZKEM1_OnEnrollFingerEx
                AddHandler axCZKEM1.OnDeleteTemplate, AddressOf AxCZKEM1_OnDeleteTemplate
                AddHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
                AddHandler axCZKEM1.OnAlarm, AddressOf AxCZKEM1_OnAlarm
                AddHandler axCZKEM1.OnDoor, AddressOf AxCZKEM1_OnDoor
                AddHandler axCZKEM1.OnWriteCard, AddressOf AxCZKEM1_OnWriteCard
                AddHandler axCZKEM1.OnEmptyCard, AddressOf AxCZKEM1_OnEmptyCard
                AddHandler axCZKEM1.OnHIDNum, AddressOf AxCZKEM1_OnHIDNum
            End If
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
            axCZKEM1.Disconnect()

            RemoveHandler axCZKEM1.OnFinger, AddressOf AxCZKEM1_OnFinger
            RemoveHandler axCZKEM1.OnFingerFeature, AddressOf AxCZKEM1_OnFingerFeature
            RemoveHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
            RemoveHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
            RemoveHandler axCZKEM1.OnEnrollFingerEx, AddressOf AxCZKEM1_OnEnrollFingerEx
            RemoveHandler axCZKEM1.OnDeleteTemplate, AddressOf AxCZKEM1_OnDeleteTemplate
            RemoveHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
            RemoveHandler axCZKEM1.OnAlarm, AddressOf AxCZKEM1_OnAlarm
            RemoveHandler axCZKEM1.OnDoor, AddressOf AxCZKEM1_OnDoor
            RemoveHandler axCZKEM1.OnWriteCard, AddressOf AxCZKEM1_OnWriteCard
            RemoveHandler axCZKEM1.OnEmptyCard, AddressOf AxCZKEM1_OnEmptyCard
            RemoveHandler axCZKEM1.OnHIDNum, AddressOf AxCZKEM1_OnHIDNum

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

            If axCZKEM1.RegEvent(iMachineNumber, 65535) = True Then 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

                AddHandler axCZKEM1.OnFinger, AddressOf AxCZKEM1_OnFinger
                AddHandler axCZKEM1.OnFingerFeature, AddressOf AxCZKEM1_OnFingerFeature
                AddHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
                AddHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
                AddHandler axCZKEM1.OnEnrollFingerEx, AddressOf AxCZKEM1_OnEnrollFingerEx
                AddHandler axCZKEM1.OnDeleteTemplate, AddressOf AxCZKEM1_OnDeleteTemplate
                AddHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
                AddHandler axCZKEM1.OnAlarm, AddressOf AxCZKEM1_OnAlarm
                AddHandler axCZKEM1.OnDoor, AddressOf AxCZKEM1_OnDoor
                AddHandler axCZKEM1.OnWriteCard, AddressOf AxCZKEM1_OnWriteCard
                AddHandler axCZKEM1.OnEmptyCard, AddressOf AxCZKEM1_OnEmptyCard
                AddHandler axCZKEM1.OnHIDNum, AddressOf AxCZKEM1_OnHIDNum

            End If
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
#End Region

    '**************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.*
    '* This part is for demonstrating the RealTime Events that triggered  by your operations          *
    '**************************************************************************************************
#Region "RealTime Events"
    'After you have connected the device,this event will be triggered.
    Private Sub AxCZKEM1_OnFinger()
        lbRTShow.Items.Add("RTEvent OnFinger Has been Triggered")
    End Sub
    'After you have placed your finger on the sensor(or swipe your card to the device),this event will be triggered.
    'If you passes the verification,the returned value userid will be the user enrollnumber,or else the value will be -1;
    Private Sub AxCZKEM1_OnVerify(ByVal iUserID As Integer)
        lbRTShow.Items.Add("RTEvent OnVerify Has been Triggered,Verifying...")
        If iUserID <> -1 Then
            lbRTShow.Items.Add("Verified OK,the UserID is " & iUserID.ToString())
        Else
            lbRTShow.Items.Add("Verified Failed... ")
        End If
    End Sub
    'If your fingerprint(or your card) passes the verification,this event will be triggered
    Private Sub AxCZKEM1_OnAttTransactionEx(ByVal sEnrollNumber As String, ByVal iIsInValid As Integer, ByVal iAttState As Integer, ByVal iVerifyMethod As Integer, _
                      ByVal iYear As Integer, ByVal iMonth As Integer, ByVal iDay As Integer, ByVal iHour As Integer, ByVal iMinute As Integer, ByVal iSecond As Integer, ByVal iWorkCode As Integer)
        lbRTShow.Items.Add("RTEvent OnAttTrasactionEx Has been Triggered,Verified OK")
        lbRTShow.Items.Add("...UserID:" & sEnrollNumber)
        lbRTShow.Items.Add("...isInvalid:" & iIsInValid.ToString())
        lbRTShow.Items.Add("...attState:" & iAttState.ToString())
        lbRTShow.Items.Add("...VerifyMethod:" & iVerifyMethod.ToString())
        lbRTShow.Items.Add("...Workcode:" & iWorkCode.ToString()) 'the difference between the event OnAttTransaction and OnAttTransactionEx
        lbRTShow.Items.Add("...Time:" & iYear.ToString() & "-" & iMonth.ToString() & "-" & iDay.ToString() & " " & iHour.ToString() & ":" & iMinute.ToString() & ":" & iSecond.ToString())
    End Sub
    'When you have enrolled your finger,this event will be triggered and return the quality of the fingerprint you have enrolled
    Private Sub AxCZKEM1_OnFingerFeature(ByVal iScore As Integer)
        If iScore < 0 Then
            lbRTShow.Items.Add("The quality of your fingerprint is poor")
        Else
            lbRTShow.Items.Add("RTEvent OnFingerFeature Has been Triggered...Score:" & iScore.ToString())
        End If
    End Sub
    'When you have deleted one one fingerprint template,this event will be triggered.
    Private Sub AxCZKEM1_OnDeleteTemplate(ByVal iEnrollNumber As Integer, ByVal iFingerIndex As Integer)
        lbRTShow.Items.Add("RTEvent OnDeleteTemplate Has been Triggered...")
        lbRTShow.Items.Add("...UserID=" & iEnrollNumber.ToString() & " FingerIndex=" & iFingerIndex.ToString())
    End Sub
    'When you have enrolled a new user,this event will be triggered.
    Private Sub AxCZKEM1_OnNewUser(ByVal iEnrollNumber As Integer)
        lbRTShow.Items.Add("RTEvent OnNewUser Has been Triggered...")
        lbRTShow.Items.Add("...NewUserID=" & iEnrollNumber.ToString())
    End Sub
    'When you swipe a card to the device, this event will be triggered to show you the card number.
    Private Sub AxCZKEM1_OnHIDNum(ByVal iCardNumber As Integer)
        lbRTShow.Items.Add("RTEvent OnHIDNum Has been Triggered...")
        lbRTShow.Items.Add("...Cardnumber=" & iCardNumber.ToString())
    End Sub
    'When you are enrolling your finger,this event will be triggered.
    Private Sub AxCZKEM1_OnEnrollFingerEx(ByVal sEnrollNumber As String, ByVal iFingerIndex As Integer, ByVal iActionResult As Integer, ByVal iTemplateLength As Integer)
        If iActionResult = 0 Then
            lbRTShow.Items.Add("RTEvent OnEnrollFigerEx Has been Triggered....")
            lbRTShow.Items.Add(".....UserID: " & sEnrollNumber & " Index: " & iFingerIndex.ToString() & " tmpLen: " & iTemplateLength.ToString())
        Else
            lbRTShow.Items.Add("RTEvent OnEnrollFigerEx Has been Triggered Error,actionResult=" + iActionResult.ToString())
        End If
    End Sub
    '/When the dismantling machine or duress alarm occurs, trigger this event.
    Private Sub AxCZKEM1_OnAlarm(ByVal iAlarmType As Integer, ByVal iEnrollNumber As Integer, ByVal iVerified As Integer)
        lbRTShow.Items.Add("RTEvnet OnAlarm Has been Triggered...")
        lbRTShow.Items.Add("...alarmType=" & iAlarmType.ToString())
        lbRTShow.Items.Add("...enrollNumber=" & iEnrollNumber.ToString())
        lbRTShow.Items.Add("...verified=" & iVerified.ToString())
    End Sub
    'Door sensor event
    Private Sub AxCZKEM1_OnDoor(ByVal iEventType As Integer)
        lbRTShow.Items.Add("RTEvent Ondoor Has been Triggered...")
        lbRTShow.Items.Add("...EventType=" & iEventType.ToString())
    End Sub
    'When you have emptyed the Mifare card,this event will be triggered.
    Private Sub AxCZKEM1_OnEmptyCard(ByVal iActionResult As Integer)
        lbRTShow.Items.Add("RTEvent OnEmptyCard Has been Triggered...")
        If iActionResult = 0 Then
            lbRTShow.Items.Add("...Empty Mifare Card OK")
        Else
            lbRTShow.Items.Add("...Empty Failed")
        End If
    End Sub
    'When you have written into the Mifare card ,this event will be triggered.
    Private Sub AxCZKEM1_OnWriteCard(ByVal iEnrollNumber As Integer, ByVal iActionResult As Integer, ByVal iLength As Integer)
        lbRTShow.Items.Add("RTEvent OnWriteCard Has been Triggered...")
        If iActionResult = 0 Then
            lbRTShow.Items.Add("...Write Mifare Card OK")
            lbRTShow.Items.Add("...EnrollNumber=" & iEnrollNumber.ToString())
            lbRTShow.Items.Add("...TmpLength=" & iLength.ToString())
        Else
            lbRTShow.Items.Add("...Write Failed")
        End If
    End Sub
#End Region
End Class
