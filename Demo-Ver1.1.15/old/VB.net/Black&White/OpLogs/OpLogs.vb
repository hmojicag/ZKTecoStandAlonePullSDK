'**********************************************************
'* Demo for Standalone SDK.Created by Darcy on Dec.15 2009*
'**********************************************************

Public Class OpLogs

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
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
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

    '***************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first. *
    '* This part is for demonstrating how to download, upload or clear the super management logs.      *
    '* *************************************************************************************************
#Region "OpLogs"
    'Download the super operation logs from the device.
    Private Sub btnGetSuperLogData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetSuperLogData.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iSuperLogCount As Integer
        Dim lvItem As New ListViewItem("Items", 0)

        lvLogs.Items.Clear()
        Cursor = Cursors.WaitCursor
        If AxCZKEM1.ReadSuperLogData(iMachineNumber) = True Then 'read the logs from the memory.(the same as axCZKEM1.ReadAllGLogData(iMachineNumber))
            Dim idwTMachineNumber As Integer
            Dim idwSEnrollNumber As Integer
            Dim iParams4 As Integer
            Dim iParams1 As Integer
            Dim iParams2 As Integer
            Dim idwManipulation As Integer
            Dim iParams3 As Integer
            Dim idwYear As Integer
            Dim idwMonth As Integer
            Dim idwDay As Integer
            Dim idwHour As Integer
            Dim idwMinute As Integer
            Dim idwSencond As Integer

            While AxCZKEM1.GetSuperLogData2(iMachineNumber, idwTMachineNumber, idwSEnrollNumber, iParams4, iParams1, iParams2, idwManipulation, iParams3, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSencond) = True
                iSuperLogCount += 1
                lvItem = lvLogs.Items.Add(iSuperLogCount.ToString())
                lvItem.SubItems.Add(idwTMachineNumber.ToString())
                lvItem.SubItems.Add(idwSEnrollNumber.ToString())
                lvItem.SubItems.Add(iParams4.ToString())
                lvItem.SubItems.Add(iParams1.ToString())
                lvItem.SubItems.Add(iParams2.ToString())
                lvItem.SubItems.Add(idwManipulation.ToString())
                lvItem.SubItems.Add(iParams3.ToString())
                lvItem.SubItems.Add(idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSencond.ToString())
            End While
        Else
            Cursor = Cursors.Default
            AxCZKEM1.GetLastError(idwErrorCode)

            If idwErrorCode <> 0 Then
                MsgBox("Reading data from terminal failed,ErrorCode:" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
                Return
            Else
                MsgBox("No data from terminal returns!", MsgBoxStyle.Exclamation, "Error")
                Return
            End If
        End If
        Cursor = Cursors.Default
    End Sub
    'Clear all the operation logs in the device.
    Private Sub btnClearSLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSLog.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        If AxCZKEM1.ClearSLog(iMachineNumber) = True Then
            AxCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("All operation logs have been cleared from teiminal!", MsgBoxStyle.Information, "Success")
        Else
            AxCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub
#End Region
End Class
