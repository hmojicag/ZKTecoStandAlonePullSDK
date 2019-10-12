'**********************************************************
'* Demo for Standalone SDK.Created by Darcy on Dec.15 2009*
'**********************************************************

Public Class Device

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

    '*********************************************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.                               *
    '* This part is for demonstrating the operations of the device information, status, options and other Frequently used  functions.*
    '* In this part, there are lots of parameters involved, please refer to development manual first.                                *
    '* *******************************************************************************************************************************
#Region "Device Management"
    'Get the date of device's manufacture
    'The function "GetDeviceStrInfo" is different from "GetDeviceInfo".
    Private Sub btnGetDeviceStrInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDeviceStrInfo.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim idwInfo As Integer = 1
        Dim sValue As String = ""
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetDeviceStrInfo(iMachineNumber, idwInfo, sValue) = True Then
            txtShow.Text = sValue
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
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
    'Set the password(PC terminal) for communication.
    'Only PC terminal' password is the same as device terminal's,you can connect the device.
    'You can set device terminal's communication password by the function "SetDeviceCommPwd"
    Private Sub btnSetCommPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetCommPassword.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If txtSet.Text.Trim() = "" Then
            MsgBox("Please input the computer communication password first", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iCommKey As Integer = Convert.ToInt32(txtSet.Text.Trim())
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SetCommPassword(iCommKey) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Successfully set computer's commKey! commKey=" & iCommKey.ToString(), MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set the password(device terminal) for communication.
    'Only PC terminal' password is the same as device terminal's ,you can connect the device.
    'You can set PC terminal's communication password by the function "SetCommPassword"
    Private Sub btnSetDeviceCommPwd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDeviceCommPwd.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If txtSet.Text.Trim() = "" Then
            MsgBox("Please input the Device communication password first", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iCommKey As Integer = Convert.ToInt32(txtSet.Text.Trim())
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SetDeviceCommPwd(iMachineNumber, iCommKey) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Successfully set computer's commKey! commKey=" & iCommKey, MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set the MAC address of the device.
    'You can set a device's MAC address by the device's keyboard or the function "SetDeviceMAC"
    Private Sub btnSetDeviceMAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDeviceMAC.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If txtSet.Text.Trim() = "" Then
            MsgBox("Please input the MAC address first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sMAC As String = txtSet.Text.Trim()
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SetDeviceMAC(iMachineNumber, sMAC) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Successfully set MAC address! MAC=" & sMAC, MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set IP address of the device.
    'You can set a device's IP address by the device's keyboard or the function "SetDeviceIP"
    Private Sub btnSetDeviceIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDeviceIP.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If txtSet.Text.Trim() = "" Then
            MsgBox("Please input the IP address first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sIP As String = txtSet.Text.Trim()
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SetDeviceIP(iMachineNumber, sIP) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Successfully set IP address! IP=" & sIP, MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set the options' parameters in the device 
    Private Sub btnSetSysOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetSysOption.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sOption As String = "~PIN2Width" 'You should input this parameter by yourself.
        Dim sValue As String = txtSet.Text.Trim()
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SetSysOption(iMachineNumber, sOption, sValue) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Successfully set " & sOption & " ! value=" & sValue, MsgBoxStyle.Information, "Success")
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
    'Set the time length that the device will be Unavailable
    'Here we set the device to be Unavailable for 5 seconds.
    Private Sub btnDisableDeviceWithTimeOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisableDeviceWithTimeOut.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.DisableDeviceWithTimeOut(iMachineNumber, 5) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("The device will under working state for 5 seconds!", MsgBoxStyle.Information, "Success")
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
    'Set the beginning and ending of the daylight saving time,when you enable this fuction.
    Private Sub btnSetDaylight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDaylight.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbSupport.Text.Trim() = "" Or txtBeginTime.Text.Trim() = "" Or txtEndTime.Text.Trim() = "" Then
            MsgBox("Support,BeginTime,EndTIme cannnot be null", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iSupport As Integer = Convert.ToInt32(cbSupport.Text.Trim())
        Dim sBeginTime As String = txtBeginTime.Text.Trim()
        Dim sEndTime As String = txtEndTime.Text.Trim()

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SetDaylight(iMachineNumber, iSupport, sBeginTime, sEndTime) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("SetDaylight", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the information of daylight saving time.
    Private Sub btnGetDaylight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDaylight.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iSupport As Integer
        Dim sBeginTime As String = ""
        Dim sEndTime As String = ""

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.GetDaylight(iMachineNumber, iSupport, sBeginTime, sEndTime) = True Then
            cbSupport.Text = iSupport.ToString()
            txtBeginTime.Text = sBeginTime
            txtEndTime.Text = sEndTime
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set the workcode specified id.
    Private Sub btnSetWorkCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_SetWorkCode.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbAWorkCodeID.Text.Trim() = "" Or txtName.Text.Trim() = "" Then
            MsgBox("Please input two corresponding params!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iAWorkCodeID As Integer = Convert.ToInt32(cbAWorkCodeID.Text.Trim())
        Dim sName As String = txtName.Text.Trim()

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SSR_SetWorkCode(iAWorkCodeID, sName) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("SetWorkCode!Name=" + sName, MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the workcode by its id.
    Private Sub btnGetWorkCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_GetWorkCode.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbAWorkCodeID.Text.Trim() = "" Then
            MsgBox("Please input the WorkCodeID!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iAWorkCodeID As Integer = Convert.ToInt32(cbAWorkCodeID.Text.Trim())
        Dim sName As String = ""

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SSR_GetWorkCode(iAWorkCodeID, sName) = True Then
            txtName.Text = sName
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Delete the workcode by specified id.
    Private Sub btnDeleteWorkCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_DeleteWorkCode.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbAWorkCodeID.Text.Trim() = "" Then
            MsgBox("Please input the WorkCodeID!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iAWorkCodeID As Integer = Convert.ToInt32(cbAWorkCodeID.Text.Trim())

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SSR_DeleteWorkCode(iAWorkCodeID) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("DeleteWorkCode! ID=" + iAWorkCodeID.ToString(), MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Clear all the workcode in the device.
    Private Sub btnClearWorkCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_ClearWorkCode.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer


        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SSR_ClearWorkCode() = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Clear all WorkCode!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set the holiday.
    'Please refer to development manual to look over detailed parameters.
    Private Sub btnSetHoliday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_SetHoliday.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbHolidayID.Text.Trim() = "" Or cbTZID.Text.Trim() = "" Or cbBM.Text.Trim() = "" Or cbBD.Text.Trim() = "" Or cbEM.Text.Trim() = "" Or cbED.Text.Trim() = "" Then
            MsgBox("Please input all the arguments!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iHolidayID As Integer = Convert.ToInt32(cbHolidayID.Text.Trim())
        Dim iTZID As Integer = Convert.ToInt32(cbTZID.Text.Trim()) 'the timezone of the holiday using
        Dim iBM As Integer = Convert.ToInt32(cbBM.Text.Trim()) 'begining month
        Dim iBD As Integer = Convert.ToInt32(cbBD.Text.Trim()) 'begining day
        Dim iEM As Integer = Convert.ToInt32(cbEM.Text.Trim()) 'ending month
        Dim iED As Integer = Convert.ToInt32(cbED.Text.Trim()) 'ending day

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SSR_SetHoliday(iMachineNumber, iHolidayID, iBM, iBD, iEM, iED, iTZID) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("SSR_SetHoliday!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the holiday according to its id.
    Private Sub btnGetHoliday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_GetHoliday.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbHolidayID.Text.Trim() = "" Then
            MsgBox("Please input the HolidayID!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iHolidayID As Integer = Convert.ToInt32(cbHolidayID.Text.Trim()) 'the timezone of the holiday using
        Dim iTZID As Integer
        Dim iBM As Integer 'begining month
        Dim iBD As Integer 'begining day
        Dim iEM As Integer 'ending month
        Dim iED As Integer 'ending day

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SSR_GetHoliday(iMachineNumber, iHolidayID, iBM, iBD, iEM, iED, iTZID) = True Then
            cbTZID.Text = iTZID.ToString()
            cbBM.Text = iBM.ToString()
            cbBD.Text = iBD.ToString()
            cbEM.Text = iEM.ToString()
            cbED.Text = iED.ToString()
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the configeration of a certain function key.
    'Please refer to development manual to look over detailed parameters.
    Private Sub btnSSR_GetShortkey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_GetShortkey.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbShortKeyID.Text.Trim() = "" Then
            MsgBox("Please input ShortKeyID !", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iShortKeyID As Integer = Convert.ToInt32(cbShortKeyID.Text.Trim())
        Dim iFun As Integer
        Dim iStateCode As Integer
        Dim sStateName As String = ""
        Dim iAutoChange As Integer
        Dim sTime As String = ""

        Cursor = Cursors.WaitCursor
        If AxCZKEM1.SSR_GetShortkey(iShortKeyID, iFun, iStateCode, sStateName, iAutoChange, sTime) = True Then
            cbShortKeyFun.Text = iFun.ToString()
            If iFun = 1 Then
                cbStateCode.Text = iStateCode.ToString()
                txtStateName.Text = sStateName
                cbStateAutoChange.Text = iAutoChange.ToString()
                txtStateAutoChangeTime.Text = sTime
            Else
                cbStateCode.Text = ""
                txtStateName.Text = ""
                cbStateAutoChange.Text = ""
                txtStateAutoChangeTime.Text = ""
            End If
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set a certain function key's configeration.
    'Please refer to development manual to look over detailed parameters.
    Private Sub btnSSR_SetShortkey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_SetShortkey.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbShortKeyID.Text.Trim() = "" Or cbShortKeyFun.Text.Trim() = "" Then
            MsgBox("Please input ShortKeyID and ShortKeyFun !", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        If cbShortKeyFun.Text.Trim() = "1" Then
            If (cbStateCode.Text.Trim() = "" Or txtStateName.Text.Trim() = "" Or cbStateAutoChange.Text.Trim() = "" Or txtStateAutoChangeTime.Text.Trim() = "") Then
                MsgBox("Please input the following four parameters !", MsgBoxStyle.Information, "Error")
                Return
            End If
        End If

        Dim iShortKeyID As Integer = Convert.ToInt32(cbShortKeyID.Text.Trim())
        Dim iFun As Integer = Convert.ToInt32(cbShortKeyFun.Text.Trim())


        Cursor = Cursors.WaitCursor
        If iFun = 1 Then
            Dim iStateCode As Integer = Convert.ToInt32(cbStateCode.Text.Trim())
            Dim sStateName As String = txtStateName.Text.Trim()
            Dim iAutoChange As Integer = Convert.ToInt32(cbStateAutoChange.Text.Trim())
            Dim sTime As String = txtStateAutoChangeTime.Text.Trim()

            If AxCZKEM1.SSR_SetShortkey(iShortKeyID, iFun, iStateCode, sStateName, iAutoChange, sTime) = True Then
                AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
                MsgBox("SetShortkey! ShortKeyID=" + iShortKeyID.ToString(), MsgBoxStyle.Information, "Success")
            Else
                AxCZKEM1.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
            End If
        Else
            Dim iStateCode As Integer
            Dim sStateName As String = ""
            Dim iAutoChange As Integer
            Dim sTime As String = ""

            If AxCZKEM1.SSR_SetShortkey(iShortKeyID, iFun, iStateCode, sStateName, iAutoChange, sTime) = True Then
                AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
                MsgBox("SetShortkey! ShortKeyID=" + iShortKeyID.ToString(), MsgBoxStyle.Information, "Success")
            Else
                AxCZKEM1.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
            End If
        End If
        Cursor = Cursors.Default
    End Sub
#End Region
   
End Class
