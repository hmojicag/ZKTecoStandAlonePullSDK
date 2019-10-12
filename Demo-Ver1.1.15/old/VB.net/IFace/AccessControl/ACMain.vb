'**********************************************************
'* Demo for Standalone SDK.Created by Darcy on Dec.15 2009*
'**********************************************************

Public Class AccessControl

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
            bIsConnected = False
            btnConnect.Text = "Connect"
            lblState.Text = "Current State:Disconnected"
            Cursor = Cursors.Default
            Return
        End If

        bIsConnected = axCZKEM1.Connect_Net(txtIP.Text.Trim(), Convert.ToInt32(txtPort.Text.Trim()))
        If bIsConnected = True Then
            btnConnect.Text = "Disconnect"
            btnConnect.Refresh()
            lblState.Text = "Current State:Connected"
            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            axCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
        Else
            axCZKEM1.GetLastError(idwErrorCode)
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
            bIsConnected = False
            btnRsConnect.Text = "Connect"
            lblState.Text = "Current State:Disconnected"
            Cursor = Cursors.Default
            Return
        End If

        iMachineNumber = Convert.ToInt32(txtMachineSN.Text.Trim()) '//when you are using the serial port communication,you can distinguish different devices by their serial port number.
        bIsConnected = axCZKEM1.Connect_Com(iPort, iMachineNumber, Convert.ToInt32(cbBaudRate.Text.Trim()))

        If bIsConnected = True Then
            btnRsConnect.Text = "Disconnect"
            btnRsConnect.Refresh()
            lblState.Text = "Current State:Connected"
            axCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
#End Region

    '***********************************************************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.                                             *
    '* This part is for demonstrating the operations of the access control.You should be clear about some terms ,such as ＾time zone,unlock groups,*
    '* wiegand format,user group,user's time zone￣.Also,you can refer to the manual.                                                              *
    '* *********************************************************************************************************************************************
#Region "Access Control"
    'Get the format of wiegand.
    Private Sub btnGetWiegandFmt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetWiegandFmt.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sWiegandFmt As String = ""

        Cursor = Cursors.WaitCursor
        If axCZKEM1.GetWiegandFmt(iMachineNumber, sWiegandFmt) = True Then
            txtShow.Text = sWiegandFmt
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set the format of wiegand.
    Private Sub btnSetWiegandFmt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetWiegandFmt.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If txtSet.Text.Trim() = "" Or txtSet.Text.Trim() = "set value" Then
            MsgBox("Please intput the value of wiegand format!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim sWiegandFmt As String = txtSet.Text.Trim()

        Cursor = Cursors.WaitCursor
        If axCZKEM1.SetWiegandFmt(iMachineNumber, sWiegandFmt) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("Setting WiegandFmt address succeeded! WiegandFmt=" + sWiegandFmt, MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Judge whether the door is open now.　
    Private Sub btnGetDoorState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDoorState.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iState As Integer

        Cursor = Cursors.WaitCursor
        If axCZKEM1.GetDoorState(iMachineNumber, iState) = True Then
            If iState = 1 Then
                lblDoorState.Text = "The door is open now!"
            Else
                lblDoorState.Text = "The door is close now!"
            End If
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Judge whether the device supports access control function.
    Private Sub btnGetACFun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetACFun.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iACFun As Integer

        Cursor = Cursors.WaitCursor
        If axCZKEM1.GetACFun(iACFun) = True Then
            MsgBox("GetACFun, ACFun:" + iACFun.ToString(), MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the timezone information by the specified timezone number　
    Private Sub btnGetTZInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetTZInfo.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbTZIndex.Text.Trim() = "" Then
            MsgBox("Please input the TZIndex first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iTZIndex As Integer = Convert.ToInt32(cbTZIndex.Text.Trim())
        Dim sTZ As String = ""

        Cursor = Cursors.WaitCursor
        If axCZKEM1.GetTZInfo(iMachineNumber, iTZIndex, sTZ) = True Then
            txtTZ.Text = sTZ
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set the timezone information and its number　
    Private Sub btnSetTZInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetTZInfo.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbTZIndex.Text.Trim() = "" Or txtTZ.Text.Trim() = "" Then
            MsgBox("Please input the TZIndex and TZ first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iTZIndex As Integer = Convert.ToInt32(cbTZIndex.Text.Trim())
        Dim sTZ As String = txtTZ.Text.Trim()

        Cursor = Cursors.WaitCursor
        If axCZKEM1.SetTZInfo(iMachineNumber, iTZIndex, sTZ) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("SetTZInfo, cbTZIndex:" + iTZIndex.ToString() + " TimeZone:" + sTZ, MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set the group number by the specified user.
    Private Sub btnSetUserGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetUserGroup.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbUserIDGroup.Text.Trim() = "" Or cbUserGrp.Text.Trim() = "" Then
            MsgBox("Please input the UserID and UserGrp first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iUserID As Integer = Convert.ToInt32(cbUserIDGroup.Text.Trim())
        Dim iUserGrp As Integer = Convert.ToInt32(cbUserGrp.Text.Trim())

        Cursor = Cursors.WaitCursor
        If axCZKEM1.SetUserGroup(iMachineNumber, iUserID, iUserGrp) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("SetUserGroup,UserID:" + iUserID.ToString() + " UserGrp:" + iUserGrp.ToString(), MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the group number the specified user belongs to.　
    Private Sub btnGetUserGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetUserGroup.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbUserIDGroup.Text.Trim() = "" Then
            MsgBox("Please input the UserID first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iUserID As Integer = Convert.ToInt32(cbUserIDGroup.Text.Trim())
        Dim iUserGrp As Integer

        Cursor = Cursors.WaitCursor
        If axCZKEM1.GetUserGroup(iMachineNumber, iUserID, iUserGrp) = True Then
            cbUserGrp.Text = iUserGrp.ToString()
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Establish the relation between users and timezones.　
    'The detailed meaning of the parameter is mentioned in the development manual.
    Private Sub btnSetUserTZStr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetUserTZStr.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbUserIDTZ.Text.Trim() = "" Or txtUserTZs.Text.Trim() = "" Then
            MsgBox("Please input the UserID and TimeZones first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iUserID As Integer = Convert.ToInt32(cbUserIDTZ.Text.Trim())
        Dim sTZs As String = txtUserTZs.Text.Trim()

        Cursor = Cursors.WaitCursor
        If axCZKEM1.SetUserTZStr(iMachineNumber, iUserID, sTZs) = True Then 'TZs is in strings.
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("SetUserTZStr, UserID:" + iUserID.ToString() + " TimeZones:" + sTZs, MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the timezone by the user's id.　
    'The detailed meaning of the parameter is mentioned in the development manual.
    Private Sub btnGetUserTZStr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetUserTZStr.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbUserIDTZ.Text.Trim() = "" Then
            MsgBox("Please input the UserID first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iUserID As Integer = Convert.ToInt32(cbUserIDTZ.Text.Trim())
        Dim sTZs As String = ""

        Cursor = Cursors.WaitCursor
        If axCZKEM1.GetUserTZStr(iMachineNumber, iUserID, sTZs) = True Then 'TZs is in strings.
            txtUserTZs.Text = sTZs
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Judge whether the user is using group time zone.　
    Private Sub btnUseGroupTimeZone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUseGroupTimeZone.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbUserIDTZ.Text.Trim() = "" Then
            MsgBox("Please input the UserID first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iUserID As Integer = Convert.ToInt32(cbUserIDTZ.Text.Trim())
        Dim sTZs As String = ""

        Cursor = Cursors.WaitCursor
        If axCZKEM1.GetUserTZStr(iMachineNumber, iUserID, sTZs) = True Then 'TZs is in strings.
            txtUserTZs.Text = sTZs
            If axCZKEM1.UseGroupTimeZone() = True Then
                MsgBox("Using Group TimeZone", MsgBoxStyle.Information, "Yes")
            Else
                MsgBox("Not Using Group TimeZone", MsgBoxStyle.Information, "No")
            End If
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Make the controller to export a electric-level to open door　
    Private Sub btnACUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnACUnlock.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If txtDelay.Text.Trim() = "" Then
            MsgBox("Please input the Delay seconds first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iDelay As Integer = Convert.ToInt32(txtDelay.Text.Trim()) 'time to delay

        Cursor = Cursors.WaitCursor
        If axCZKEM1.ACUnlock(iMachineNumber, iDelay) = True Then
            MsgBox("ACUnlock, Dalay Seconds:" + iDelay.ToString(), MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the time zones used by specified group and other interrelated information.
    Private Sub btnSSR_GetGroupTZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_GetGroupTZ.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbGroupNo.Text.Trim() = "" Then
            MsgBox("Please input the GroupNo first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iGroupNo As Integer = Convert.ToInt32(cbGroupNo.Text.Trim())
        Dim iValidHoliday As Integer
        Dim iVerifyStyle As Integer
        Dim iTZ1 As Integer
        Dim iTZ2 As Integer
        Dim iTZ3 As Integer

        Cursor = Cursors.WaitCursor
        If axCZKEM1.SSR_GetGroupTZ(iMachineNumber, iGroupNo, iTZ1, iTZ2, iTZ3, iValidHoliday, iVerifyStyle) = True Then
            cbGroupNo.Text = iGroupNo.ToString()
            cbTZ1.Text = iTZ1.ToString()
            cbTZ2.Text = iTZ2.ToString()
            cbTZ3.Text = iTZ3.ToString()
            cbValidHoliday.Text = iValidHoliday.ToString()
            cbVerifyStyle.Text = iVerifyStyle.ToString()
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set the time zones used by specified group and other interrelated information.
    Private Sub btnSSR_SetGroupTZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_SetGroupTZ.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbGroupNo.Text.Trim() = "" Or cbTZ1.Text.Trim() = "" Or cbTZ2.Text.Trim() = "" Or cbTZ3.Text.Trim() = "" Or cbValidHoliday.Text.Trim() = "" Or cbVerifyStyle.Text.Trim() = "" Then
            MsgBox("Please input the params first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iGroupNo As Integer = Convert.ToInt32(cbGroupNo.Text.Trim())
        Dim iValidHoliday As Integer = Convert.ToInt32(cbValidHoliday.Text.Trim())
        Dim iVerifyStyle As Integer = Convert.ToInt32(cbVerifyStyle.Text.Trim())
        Dim iTZ1 As Integer = Convert.ToInt32(cbTZ1.Text.Trim())
        Dim iTZ2 As Integer = Convert.ToInt32(cbTZ2.Text.Trim())
        Dim iTZ3 As Integer = Convert.ToInt32(cbTZ3.Text.Trim())

        Cursor = Cursors.WaitCursor
        If axCZKEM1.SSR_SetGroupTZ(iMachineNumber, iGroupNo, iTZ1, iTZ2, iTZ3, iValidHoliday, iVerifyStyle) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("SSR_SetGroupTZ, GroupNo:" + iGroupNo.ToString() + " VerifyStyle:" + iVerifyStyle.ToString(), MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Get the unlock groups combination information.
    Private Sub btnSSR_GetUnLockGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_GetUnLockGroup.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbComNo.Text.Trim() = "" Then
            MsgBox("Please input the ComNo first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iComNo As Integer = Convert.ToInt32(cbComNo.Text.Trim())
        Dim iGroup1 As Integer
        Dim iGroup2 As Integer
        Dim iGroup3 As Integer
        Dim iGroup4 As Integer
        Dim iGroup5 As Integer

        Cursor = Cursors.WaitCursor
        If axCZKEM1.SSR_GetUnLockGroup(iMachineNumber, iComNo, iGroup1, iGroup2, iGroup3, iGroup4, iGroup5) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("SetUnlockGroups, Groups:" + iGroup1.ToString() + ":" + iGroup2.ToString() + ":" + iGroup3.ToString() + ":" + iGroup4.ToString() + ":" + iGroup5.ToString(), MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    'Set the unlock groups combination information.
    Private Sub btnSSR_SetUnLockGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_SetUnLockGroup.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If cbComNo.Text.Trim() = "" Or cbGroup1.Text.Trim() = "" Or cbGroup2.Text.Trim() = "" Or cbGroup3.Text.Trim() = "" Or cbGroup4.Text.Trim() = "" Or cbGroup5.Text.Trim() = "" Then
            MsgBox("Please input the five groups first!", MsgBoxStyle.Information, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim iComNo As Integer = Convert.ToInt32(cbComNo.Text.Trim())
        Dim iGroup1 As Integer = Convert.ToInt32(cbGroup1.Text.Trim())
        Dim iGroup2 As Integer = Convert.ToInt32(cbGroup2.Text.Trim())
        Dim iGroup3 As Integer = Convert.ToInt32(cbGroup3.Text.Trim())
        Dim iGroup4 As Integer = Convert.ToInt32(cbGroup4.Text.Trim())
        Dim iGroup5 As Integer = Convert.ToInt32(cbGroup5.Text.Trim())

        Cursor = Cursors.WaitCursor
        If axCZKEM1.SSR_SetUnLockGroup(iMachineNumber, iComNo, iGroup1, iGroup2, iGroup3, iGroup4, iGroup5) = True Then
            cbGroup1.Text = iGroup1.ToString()
            cbGroup2.Text = iGroup2.ToString()
            cbGroup3.Text = iGroup3.ToString()
            cbGroup4.Text = iGroup4.ToString()
            cbGroup5.Text = iGroup5.ToString()
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
            cbUserIDGroup.Items.Clear()
            cbUserIDTZ.Items.Clear()
            bAddControl = True
            Return
        Else
            If bAddControl = True Then
                Dim iEnrollNumber As Integer
                Dim iEMachineNumber As Integer
                Dim iBackupNumber As Integer
                Dim iPrivilege As Integer
                Dim ienabled As Integer

                axCZKEM1.EnableDevice(iMachineNumber, False)
                axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
                While axCZKEM1.GetAllUserID(iMachineNumber, iEnrollNumber, iEMachineNumber, iBackupNumber, iPrivilege, ienabled) = True
                    cbUserIDGroup.Items.Add(iEnrollNumber)
                    cbUserIDTZ.Items.Add(iEnrollNumber)
                End While

                bAddControl = False
                axCZKEM1.EnableDevice(iMachineNumber, True)
            End If
            Return
        End If
    End Sub
#End Region

End Class
