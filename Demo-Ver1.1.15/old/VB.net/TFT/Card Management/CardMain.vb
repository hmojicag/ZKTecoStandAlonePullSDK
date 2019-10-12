'**********************************************************
'* Demo for Standalone SDK.Created by Darcy on Dec.15 2009*
'**********************************************************

Public Class Card

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
            axCZKEM1.Disconnect()

            RemoveHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
            RemoveHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
            RemoveHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
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

                AddHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
                AddHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
                AddHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
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

            RemoveHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
            RemoveHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
            RemoveHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
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

                AddHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
                AddHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
                AddHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
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
    'If your device supports the USBCLient, you can refer to this.
    'Not all series devices can support this kind of connection.Please make sure your device supports USBClient.
    'Connect the device via the virtual serial port created by USBClient
    Private Sub btnUSBConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUSBConnect.Click
        Dim idwErrorCode As Integer

        Cursor = Cursors.WaitCursor
        If btnUSBConnect.Text = "Disconnect" Then
            axCZKEM1.Disconnect()

            RemoveHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
            RemoveHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
            RemoveHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
            RemoveHandler axCZKEM1.OnWriteCard, AddressOf AxCZKEM1_OnWriteCard
            RemoveHandler axCZKEM1.OnEmptyCard, AddressOf AxCZKEM1_OnEmptyCard
            RemoveHandler axCZKEM1.OnHIDNum, AddressOf AxCZKEM1_OnHIDNum

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

            If axCZKEM1.RegEvent(iMachineNumber, 65535) = True Then 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

                AddHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
                AddHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
                AddHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
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

    '***************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first. *
    '* This part is for demonstrating the RealTime Events triggered by your operations on the device.  *
    '* Here is part of the real time events, more pls refer to the RTEvents demo                       *
    '* *************************************************************************************************
#Region "RealTime Events"

    'After you swipe your card to the device,this event will be triggered.
    'If your card passes the verification,the return value  will be user id, or else the value will be -1
    Private Sub AxCZKEM1_OnVerify(ByVal iUserID As Integer)
        lbRTShow.Items.Add("RTEvent OnVerify Has been Triggered,Verifying...")
        If iUserID <> -1 Then
            lbRTShow.Items.Add("Verified OK,the UserID is " & iUserID.ToString())
        Else
            lbRTShow.Items.Add("Verified Failed... ")
        End If
    End Sub
    'If your card passes the verification,this event will be triggered
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
    'When you have enrolled a new user,this event will be triggered.
    Private Sub AxCZKEM1_OnNewUser(ByVal iEnrollNumber As Integer)
        lbRTShow.Items.Add("RTEvent OnNewUser Has been Triggered...")
        lbRTShow.Items.Add("...NewUserID=" & iEnrollNumber.ToString())
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
    'When you swipe a card to the device, this event will be triggered to show you the card number.
    Private Sub AxCZKEM1_OnHIDNum(ByVal iCardNumber As Integer)
        lbRTShow.Items.Add("RTEvent OnHIDNum Has been Triggered...")
        lbRTShow.Items.Add("...Cardnumber=" & iCardNumber.ToString())
    End Sub

#End Region

    '***************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first. *
    '* This part is for demonstrating  operations on card(ID card and HID card) device.                *
    '* It shows how to get or set card number,how to write data to Mifare card or empty it, etc.       *
    '* *************************************************************************************************
#Region "Card Operation"
    'Write someone' fingerprint templates into Mifare card, after performing this order, the prompt to slip card will appear on the device LCD
    Private Sub btnWriteCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteCard.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbUserID.Text.Trim() = "" Or cbTmpToWrite.Text.Trim() = "" Then
            MsgBox("UserID and The Count of Tmp to Write cannot be null!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False
        Dim idwFingerIndex As Integer
        Dim iTmpLength As Integer

        Dim sdwEnrollNumber As Integer = cbUserID.Text.Trim()
        Dim iTmpToWrite As Integer = Convert.ToInt32(cbTmpToWrite.Text.Trim()) 'the possible values 1,2,3,4
        Dim iTmpCount = 0 'the count of the fingerprint templates to be written in
        Dim byTmpData0(700) As Byte '9.0 fingerprint arithmetic templates
        Dim byTmpData1(700) As Byte
        Dim byTmpData2(700) As Byte
        Dim byTmpData3(700) As Byte

        Cursor = Cursors.WaitCursor
        axCZKEM1.ReadAllTemplate(iMachineNumber) 'it's nesessary to read the templates to the memory
        If axCZKEM1.SSR_GetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True Then
            'Here we write at most 4 fingerprint templates(the user's first four ones) in the Mifare card.
            'If you want to write other indexs of the templates,you can write your own code to achive.
            For idwFingerIndex = 0 To iTmpToWrite - 1
                Dim byTmpData(700) As Byte
                If axCZKEM1.SSR_GetUserTmp(iMachineNumber, sdwEnrollNumber, idwFingerIndex, byTmpData(0), iTmpLength) Then
                    iTmpCount += 1
                    Select Case iTmpCount
                        Case 1
                            Array.Copy(byTmpData, byTmpData0, iTmpLength)
                            Exit Select
                        Case 2
                            Array.Copy(byTmpData, byTmpData1, iTmpLength)
                            Exit Select
                        Case 3
                            Array.Copy(byTmpData, byTmpData2, iTmpLength)
                            Exit Select
                        Case 4
                            Array.Copy(byTmpData, byTmpData3, iTmpLength)
                            Exit Select
                    End Select
                End If
                byTmpData = Nothing
            Next
        End If

        If axCZKEM1.WriteCard(iMachineNumber, sdwEnrollNumber, 0, byTmpData0(0), 1, byTmpData1(0), 2, byTmpData2(0), 3, byTmpData3(0)) = True Then 'write templates into card
            MsgBox("WriteCard(Mifare)!", MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Empty the Mifare Card.
    Private Sub btnEmptyCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmptyCard.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Cursor = Cursors.WaitCursor
        If axCZKEM1.EmptyCard(iMachineNumber) = True Then
            MsgBox("EmptyCard(Mifare)! ", MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'It is mainly for demonstrating how to download the cardnumber from the device.¡¡
    'Card number is part of the user information.
    Private Sub btnGetStrCardNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetStrCardNumber.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        Dim sdwEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False
        Dim sCardnumber As String = ""

        lvCard.Items.Clear()
        lvCard.BeginUpdate()
        Cursor = Cursors.WaitCursor
        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True 'get user information from memory
            If axCZKEM1.GetStrCardNumber(sCardnumber) = True Then 'get the card number from the memory
                Dim list As New ListViewItem
                list.Text = sdwEnrollNumber.ToString()
                list.SubItems.Add(sName)
                list.SubItems.Add(sCardnumber)
                list.SubItems.Add(iPrivilege.ToString())
                list.SubItems.Add(sPassword)
                If bEnabled = True Then
                    list.SubItems.Add("true")
                Else
                    list.SubItems.Add("false")
                End If
                lvCard.Items.Add(list)
            End If
        End While

        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
        lvCard.EndUpdate()
        Cursor = Cursors.Default
    End Sub
    'Upload the cardnumber as part of the user information¡¡
    Private Sub btnSetStrCardNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetStrCardNumber.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If txtUserID.Text.Trim() = "" Or cbPrivilege.Text.Trim() = "" Or txtCardnumber.Text.Trim() = "" Then
            MsgBox("UserID,Privilege,Cardnumber must be inputted first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim bEnabled As Boolean
        If chbEnabled.Checked = True Then
            bEnabled = True
        Else
            bEnabled = False
        End If

        Dim sdwEnrollNumber As Integer = txtUserID.Text.Trim()
        Dim sName As String = txtName.Text.Trim()
        Dim sPassword As String = txtPassword.Text.Trim()
        Dim iPrivilege As Integer = Convert.ToInt32(cbPrivilege.Text.Trim())
        Dim sCardnumber As String = txtCardnumber.Text.Trim()

        Cursor = Cursors.WaitCursor
        axCZKEM1.EnableDevice(iMachineNumber, False)
        axCZKEM1.SetStrCardNumber(sCardnumber) 'Before you using function SetUserInfo,set the card number to make sure you can upload it to the device
        If axCZKEM1.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True Then 'upload the user's information(card number included)
            MsgBox("SetUserInfo,UserID:" + sdwEnrollNumber.ToString() + " Privilege:" + iPrivilege.ToString() + " Cardnumber:" + sCardnumber + " Enabled:" + bEnabled.ToString(), MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        axCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
    End Sub
    'Get the latest Cardnumber after you have swiped the card.
    Private Sub btnGetHIDEventCardNumAsStr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetHIDEventCardNumAsStr.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sStrHIDEventCardNum As String = ""
        Cursor = Cursors.WaitCursor
        If axCZKEM1.GetHIDEventCardNumAsStr(sStrHIDEventCardNum) = True Then
            MsgBox("GetHIDEventCardNumAsStr!HIDCardNum=" + sStrHIDEventCardNum.ToString(), MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Add the existed userid to DropDownLists.
    Dim bAddControl As Boolean = True
    Private Sub UserIDTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserIDTimer.Tick
        If bIsConnected = False Then
            cbUserID.Items.Clear()
            bAddControl = True
            Return
        Else
            If bAddControl = True Then
                Dim sEnrollNumber As String = ""
                Dim sName As String = ""
                Dim sPassword As String = ""
                Dim iPrivilege As Integer
                Dim bEnabled As Boolean = False

                axCZKEM1.EnableDevice(iMachineNumber, False)
                axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
                While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True
                    cbUserID.Items.Add(sEnrollNumber)
                End While

                bAddControl = False
                axCZKEM1.EnableDevice(iMachineNumber, True)
            End If
            Return
        End If
    End Sub
#End Region

End Class
