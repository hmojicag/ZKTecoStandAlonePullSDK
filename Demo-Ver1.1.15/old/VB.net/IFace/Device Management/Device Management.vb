'**********************************************************
'* Demo for Standalone SDK.Created by Darcy on Dec.15 2009*
'**********************************************************

Public Class Device

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

    '*********************************************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.                               *
    '* This part is for demonstrating the operations of the device information, status, options and other Frequently used  functions.*
    '* In this part, there are lots of parameters involved, please refer to development manual first.                                *
    '* *******************************************************************************************************************************
#Region "Device Management"
    'Get the parameters of the device's options.
    Private Sub btnGetSysOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetSysOption.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sOption As String = "~PIN2Width" 'You should input this parameter by yourself.
        Dim sValue As String = ""
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetSysOption(iMachineNumber, sOption, sValue) = True Then
            txtShow.Text = sValue
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the MAC Address of the device
    Private Sub btnGetDeviceMAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDeviceMAC.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sMAC As String = ""
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetDeviceMAC(iMachineNumber, sMAC) = True Then
            txtShow.Text = sMAC
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the name of the manufacturer
    Private Sub btnGetVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetVendor.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sVendor As String = ""
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetVendor(sVendor) = True Then
            txtShow.Text = sVendor
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the Firmware version of the device
    Private Sub btnGetFirmwareVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetFirmwareVersion.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sVersion As String = ""
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetFirmwareVersion(iMachineNumber, sVersion) = True Then
            txtShow.Text = sVersion
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the model of the device
    Private Sub btnGetProductCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetProductCode.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sProductCode As String = ""
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetProductCode(iMachineNumber, sProductCode) = True Then
            txtShow.Text = sProductCode
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the platform of the device
    Private Sub btnGetPlatform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPlatform.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sPlatform As String = ""
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetPlatform(iMachineNumber, sPlatform) = True Then
            txtShow.Text = sPlatform
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Make sure whether the machine supports the RF card function.
    Private Sub btnGetCardFun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCardFun.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iCardFun As Integer
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetCardFun(iMachineNumber, iCardFun) = True Then
            txtShow.Text = iCardFun.ToString()
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the device's serial number
    Private Sub btnGetSerialNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetSerialNumber.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sdwSerialNumber As String = ""
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetSerialNumber(iMachineNumber, sdwSerialNumber) = True Then
            txtShow.Text = sdwSerialNumber
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the IP Address of the device
    Private Sub btnGetDeviceIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDeviceIP.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sIP As String = ""
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetDeviceIP(iMachineNumber, sIP) = True Then
            txtShow.Text = sIP
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the version of the SDK you are using 
    Private Sub btnGetSDKVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetSDKVersion.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sVersion As String = ""
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetSDKVersion(sVersion) = True Then
            txtShow.Text = sVersion
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Query the device's current state
    'Please refer to our development manual for more detailed parameters information.
    Private Sub btnQueryState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQueryState.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iState As Integer
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.QueryState(iState) = True Then
            txtShow.Text = iState.ToString()
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub

    'Get device's data storage status.For example,the count of administrators, count of users, etc
    'Please refer to our development manual to look over detailed parameters.
    Private Sub btnGetDeviceStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDeviceStatus.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbStatus.Text.Trim() = "" Or cbStatus.Text = "Status Type" Then
            MsgBox("Please choose the corresponding Status number!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim idwValue As Integer
        Dim idwStatus As Integer
        Dim sdwStatus As String = cbStatus.Text.Trim()

        Cursor = Cursors.WaitCursor
        For idwStatus = 12 To 1
            If sdwStatus.IndexOf(idwStatus.ToString()) > -1 Then
                Exit For
            End If
        Next

        If AxCZKEM1.GetDeviceStatus(iMachineNumber, idwStatus, idwValue) = True Then
            txtGetDeviceStatus.Text = idwValue.ToString()
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the device parameters
    Private Sub btnGetDeviceInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDeviceInfo.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbInfo1.Text.Trim() = "" Or cbInfo1.Text = "Info Type" Then
            MsgBox("Please choose the corresponding Info number!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iValue As Integer
        Dim idwInfo As Integer
        Dim sdwInfo As String = cbInfo1.Text.Trim()

        Cursor = Cursors.WaitCursor
        For idwInfo = 68 To 1
            If sdwInfo.IndexOf(idwInfo.ToString()) > -1 Then
                Exit For
            End If
        Next

        If AxCZKEM1.GetDeviceInfo(iMachineNumber, idwInfo, iValue) = True Then
            txtGetDeviceInfo.Text = iValue.ToString()
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set the device parameters
    Private Sub btnSetDeviceInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDeviceInfo.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbInfo2.Text.Trim() = "" Or cbSetDeviceInfo.Text.Trim() = "" Or cbInfo2.Text = "Info Type" Then
            MsgBox("Please choose the corresponding Info number and its value!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim idwValue As Integer
        Dim idwInfo As Integer
        Dim sdwInfo As String = cbInfo2.Text.Trim()

        Cursor = Cursors.WaitCursor
        For idwInfo = 20 To 1
            If sdwInfo.IndexOf(idwInfo.ToString()) > -1 Then
                Exit For
            End If
        Next

        idwValue = Convert.ToInt32(cbSetDeviceInfo.Text.Trim())
        If AxCZKEM1.SetDeviceInfo(iMachineNumber, idwInfo, idwValue) = True Then
            txtGetDeviceInfo.Text = idwValue.ToString()
            MsgBox("Successfully set the device information", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Restart the device
    Private Sub btnRestartDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestartDevice.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.RestartDevice(iMachineNumber) = True Then
            MsgBox("The device will restart!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Power off the device
    Private Sub btnPowerOffDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerOffDevice.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.PowerOffDevice(iMachineNumber) = True Then
            MsgBox("PowerOffDevice", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Synchronize the device time as the computer's.
    Private Sub btnSetDeviceTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDeviceTime.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SetDeviceTime(iMachineNumber) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Successfully set the time of the machine and the terminal to sync PC!", MsgBoxStyle.Information, "Success")
            Dim idwYear As Integer
            Dim idwMonth As Integer
            Dim idwDay As Integer
            Dim idwHour As Integer
            Dim idwMinute As Integer
            Dim idwSecond As Integer
            If AxCZKEM1.GetDeviceTime(iMachineNumber, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond) Then 'show the time
                txtGetDeviceTime.Text = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString()
            End If
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Obtain the device' current time.
    Private Sub btnGetDeviceTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDeviceTime.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer
        Dim idwSecond As Integer

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetDeviceTime(iMachineNumber, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            txtGetDeviceTime.Text = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString()
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Custumize device's time as you want. 
    Private Sub btnSetDeviceTime2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDeviceTime2.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim idwYear As Integer = Convert.ToInt32(cbYear.Text.Trim())
        Dim idwMonth As Integer = Convert.ToInt32(cbMonth.Text.Trim())
        Dim idwDay As Integer = Convert.ToInt32(cbDay.Text.Trim())
        Dim idwHour As Integer = Convert.ToInt32(cbHour.Text.Trim())
        Dim idwMinute As Integer = Convert.ToInt32(cbMinute.Text.Trim())
        Dim idwSecond As Integer = Convert.ToInt32(cbSecond.Text.Trim())

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SetDeviceTime2(iMachineNumber, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Successfully set the time of the machine as you have set!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Play voice file according to its index.
    Private Sub btnPlayVoiceByIndex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlayVoiceByIndex.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbIndex.Text.Trim() = "" Then
            MsgBox("Position(Voice Index) cannot be null!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iIndex As Integer = Convert.ToInt32(cbIndex.Text.Trim())
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.PlayVoiceByIndex(iIndex) = True Then
            MsgBox("PlayVoiceByIndex " + iIndex.ToString(), MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Play the specified number of continuous voice.
    Private Sub btnPlayVoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlayVoice.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbPosition.Text.Trim() = "" Or cbLength.Text.Trim() = "" Then
            MsgBox("Position and Length cannot be null!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iPosition As Integer = Convert.ToInt32(cbPosition.Text.Trim())
        Dim iLength As Integer = Convert.ToInt32(cbLength.Text.Trim())

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.PlayVoice(iPosition, iLength) = True Then
            MsgBox("Play Voice from " + iPosition.ToString() + " to " + iLength.ToString(), MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
#End Region

End Class
