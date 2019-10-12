'**********************************************************
'* Demo for Standalone SDK.Created by Darcy on Dec.15 2009*
'**********************************************************
Imports System.Windows.Forms
Imports UdiskData
Imports System.IO

Public Class UDiskDataMain

    '****************************************************************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.                                                  *
    '* This part is for demonstrating the operations of  Udisk data management.Including getting data from Udisk & writing data to files to be uploaded.*
    '* No need to connect the device,just need to plug in the usb disk.                                                                                 *
    '****************************************************************************************************************************************************

#Region "SSR_User(TFT)"
    'To read the user information of the TFT screen devices,Filename:user.dat
    Private Sub btnSSR_UserRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_UserRead.Click
        Dim udisk As New Structs.UDisk

        Dim byDataBuf() As Byte
        Dim iLength As Integer
        Dim iCount As Integer 'count of users

        Dim iPIN As Integer
        Dim iPrivilege As Integer
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iCard As Integer
        Dim iGroup As Integer
        Dim sTimeZones As String = ""
        Dim sPIN2 As String = ""

        lvSSRUser.Items.Clear()
        OpenFileDialog1.Filter = "user(*.dat)|*.dat"
        OpenFileDialog1.FileName = "user.dat"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim stream As FileStream
            stream = New FileStream(OpenFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read)
            byDataBuf = File.ReadAllBytes(OpenFileDialog1.FileName)
            iLength = Convert.ToInt32(stream.Length)

            If iLength Mod 72 <> 0 Then
                MsgBox("Data Error!Please check whether you have chosen the right file!", MsgBoxStyle.Exclamation, "Error")
                Return
            End If
            iCount = iLength \ 72

            Dim lvItem As New ListViewItem()
            Dim j As Integer
            Dim i As Integer
            For j = 0 To iCount - 1 'loop to manage all the users
                Dim byUserInfo(71) As Byte 'loop to manage every user's information
                For i = 0 To 71
                    byUserInfo(i) = byDataBuf(j * 72 + i)
                Next
                udisk.GetSSRUserInfoFromDat(byUserInfo, iPIN, iPrivilege, sPassword, sName, iCard, iGroup, sTimeZones, sPIN2)
                lvItem = lvSSRUser.Items.Add(sPIN2)
                lvItem.SubItems.Add(sName)
                lvItem.SubItems.Add(iCard.ToString())
                lvItem.SubItems.Add(iPrivilege.ToString())
                lvItem.SubItems.Add(sPassword)
                lvItem.SubItems.Add(iGroup.ToString())
                lvItem.SubItems.Add(sTimeZones.ToString())
                lvItem.SubItems.Add(iPIN.ToString())

                byUserInfo = Nothing
            Next

            stream.Close()
        End If
    End Sub
    'To write the user information of the TFT screen devices,Filename:user.dat
    Private Sub btnSSR_UserWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSR_UserWrite.Click
        Dim udisk As New Structs.UDisk

        Dim lvItem As ListViewItem
        SaveFileDialog1.Filter = "user(*.dat)|*.dat"
        SaveFileDialog1.FileName = "user.dat"
        Dim iCount As Integer = lvSSRUser.Items.Count
        Dim byDataBuf(iCount * 72 - 1) As Byte

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim iDataBufIndex As Integer = 0
            For Each lvItem In lvSSRUser.Items

                Dim sPIN2 As String = lvItem.SubItems(0).Text.Trim()
                Dim sName As String = lvItem.SubItems(1).Text.Trim()
                Dim iCard As Integer = Convert.ToInt32(lvItem.SubItems(2).Text.Trim())
                Dim iPrivilege As Integer = Convert.ToInt32(lvItem.SubItems(3).Text.Trim())
                Dim sPassword As String = lvItem.SubItems(4).Text.Trim()
                Dim iGroup As Integer = Convert.ToInt32(lvItem.SubItems(5).Text.Trim())
                Dim sTimeZones As String = lvItem.SubItems(6).Text.Trim()
                Dim iPIN As Integer = Convert.ToInt32(lvItem.SubItems(7).Text.Trim())

                Dim byUserInfo(71) As Byte
                udisk.SetSSRUserInfoToDat(byUserInfo, iPIN, iPrivilege, sPassword, sName, iCard, iGroup, sTimeZones, sPIN2)
                Array.Copy(byUserInfo, 0, byDataBuf, iDataBufIndex, 72)
                byUserInfo = Nothing
                iDataBufIndex += 72

            Next
        End If
        File.WriteAllBytes(SaveFileDialog1.FileName, byDataBuf)
    End Sub
#End Region

#Region "AttLogs(TFT)"
    'To read the attendence logs (For TFT screen devices,Filename:DeviceID_attolog.dat)
    Private Sub btnSSRAttLogRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSRAttLogRead.Click
        Dim udisk As New Structs.UDisk

        Dim byDataBuf() As Byte = Nothing
        Dim iLength As Integer 'length of the bytes to get from the data

        Dim sPIN2 As String = ""
        Dim sVerified As String = ""
        Dim sTime_second As String = ""
        Dim sDeviceID As String = ""
        Dim sStatus As String = ""
        Dim sWorkcode As String = ""

        OpenFileDialog1.Filter = "1_attlog(*.dat)|*.dat"
        OpenFileDialog1.FileName = "1_attlog.dat" '1 stands for one possible deviceid
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim stream As FileStream
            stream = New FileStream(OpenFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read)
            byDataBuf = File.ReadAllBytes(OpenFileDialog1.FileName)
            iLength = Convert.ToInt32(stream.Length)

            lvSSRAttLog.Items.Clear()
            Dim lvItem As New ListViewItem
            Dim iStartIndex As Integer = 0
            Dim iOneLogLength As Integer 'the length of one line of attendence log
            For i As Integer = iStartIndex To iLength - 2

                If byDataBuf(i) = 13 And byDataBuf(i + 1) = 10 Then

                    iOneLogLength = (i + 1) + 1 - iStartIndex
                    Dim bySSRAttLog(iOneLogLength - 1) As Byte
                    Array.Copy(byDataBuf, iStartIndex, bySSRAttLog, 0, iOneLogLength)

                    udisk.GetAttLogFromDat(bySSRAttLog, iOneLogLength, sPIN2, sTime_second, sDeviceID, sStatus, sVerified, sWorkcode)
                    lvItem = lvSSRAttLog.Items.Add(sPIN2)
                    lvItem.SubItems.Add(sTime_second)
                    lvItem.SubItems.Add(sDeviceID)
                    lvItem.SubItems.Add(sStatus)
                    lvItem.SubItems.Add(sVerified)
                    lvItem.SubItems.Add(sWorkcode)

                    bySSRAttLog = Nothing
                    iStartIndex += iOneLogLength
                    iOneLogLength = 0
                End If

            Next
            stream.Close()
        End If

    End Sub
#End Region

#Region "Template(9.0 10.0)"
    'To read the fingerprint template information of 9.0 arithmetic,Filename:template.dat
    Private Sub btnTmpRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTmpRead.Click
        Dim udisk As New Structs.UDisk

        Dim byDataBuf() As Byte
        Dim iLength As Integer
        Dim iCount As Integer

        Dim iSize As Integer
        Dim iPIN As Integer
        Dim iFingerID As Integer
        Dim iValid As Integer
        Dim sTemplate As String = ""

        lvTmp.Items.Clear()
        Dim lvItem As New ListViewItem
        OpenFileDialog1.Filter = "template(*.dat)|*.dat"
        OpenFileDialog1.FileName = "template.dat"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim stream As FileStream
            stream = New FileStream(OpenFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read)
            byDataBuf = File.ReadAllBytes(OpenFileDialog1.FileName)

            iLength = Convert.ToInt32(stream.Length)
            If iLength Mod 608 <> 0 Then
                MsgBox("Data Error!", MsgBoxStyle.Exclamation, "Error")
                Return
            End If
            iCount = iLength \ 608

            For j As Integer = 0 To iCount - 1 'loop to manage all the templates
                Dim byTmpInfo(607) As Byte
                For i As Integer = 0 To 607 'loop to manage every template
                    byTmpInfo(i) = byDataBuf(j * 608 + i)
                Next
                udisk.GetTemplateFromDat(byTmpInfo, iSize, iPIN, iFingerID, iValid, sTemplate)

                lvItem = lvTmp.Items.Add(iSize.ToString())
                lvItem.SubItems.Add(iPIN.ToString())
                lvItem.SubItems.Add(iFingerID.ToString())
                lvItem.SubItems.Add(iValid.ToString())
                lvItem.SubItems.Add(sTemplate)

                byTmpInfo = Nothing
            Next
            stream.Close()
        End If
    End Sub
    'To write the fingerprint template information of 9.0 arithmetic,Filename:template.dat
    Private Sub btnTmpWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTmpWrite.Click
        Dim udisk As New Structs.UDisk

        Dim iCount As Integer = lvTmp.Items.Count
        Dim byDataBuf(iCount * 608 - 1) As Byte

        Dim lvItem As New ListViewItem
        SaveFileDialog1.Filter = "template(*.dat)|*.dat"
        SaveFileDialog1.FileName = "template.dat"

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim iDataBufIndex As Integer = 0
            For Each lvItem In lvTmp.Items
                Dim iSize As Integer = Convert.ToInt32(lvItem.SubItems(0).Text.Trim())
                Dim iPIN As Integer = Convert.ToInt32(lvItem.SubItems(1).Text.Trim())
                Dim iFingerIndex As Integer = Convert.ToInt32(lvItem.SubItems(2).Text.Trim())
                Dim iValid As Integer = Convert.ToInt32(lvItem.SubItems(3).Text.Trim())
                Dim sTemplate As String = lvItem.SubItems(4).Text.Trim()

                Dim byTmpInfo() As Byte = Nothing
                udisk.SetTemplateToDat(byTmpInfo, iSize, iPIN, iFingerIndex, iValid, sTemplate)
                Array.Copy(byTmpInfo, 0, byDataBuf, iDataBufIndex, 608)
                iDataBufIndex += 608
            Next
        End If

        File.WriteAllBytes(SaveFileDialog1.FileName, byDataBuf)
    End Sub
    'To read the fingerprint template information of 10.0 arithmetic,Filename:template.fp10.1
    Private Sub btnTmp10Read_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTmp10Read.Click
        Dim udisk As New Structs.UDisk

        Dim byDataBuf() As Byte = Nothing
        Dim iLength As Integer
        Dim iStartIndex As Integer
        Dim iSize As Integer
        Dim iPIN As Integer
        Dim iFingerID As Integer
        Dim iValid As Integer
        Dim sTemplate As String = ""

        lvTmp10.Items.Clear()
        Dim lvItem As ListViewItem
        OpenFileDialog1.Filter = "template(*.fp10.1)|*.fp10.1"
        OpenFileDialog1.FileName = "template.fp10.1"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim stream As FileStream
            stream = New FileStream(OpenFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read)
            byDataBuf = File.ReadAllBytes(OpenFileDialog1.FileName)
            iLength = Convert.ToInt32(stream.Length)

            iStartIndex = 0
            For i As Integer = 0 To iLength - 1
                iSize = byDataBuf(i) + byDataBuf(i + 1) * 256 'the variable length of the 1.0 arithmetic template
                Dim byTmpInfo(iSize - 1) As Byte

                Array.Copy(byDataBuf, iStartIndex, byTmpInfo, 0, iSize)

                iStartIndex += iSize
                i = iStartIndex - 1

                udisk.GetTmp10FromFp10(byTmpInfo, iSize, iPIN, iFingerID, iValid, sTemplate)

                lvItem = lvTmp10.Items.Add(iSize.ToString())
                lvItem.SubItems.Add(iPIN.ToString())
                lvItem.SubItems.Add(iFingerID.ToString())
                lvItem.SubItems.Add(iValid.ToString())
                lvItem.SubItems.Add(sTemplate)

                byTmpInfo = Nothing
            Next
            stream.Close()
        End If
    End Sub
    'To write the fingerprint template information of 10.0 arithmetic,Filename:template.fp10.1
    Private Sub btnTmp10Write_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTmp10Write.Click
        Dim udisk As New Structs.UDisk

        Dim iLength As Integer
        Dim iCount As Integer = lvTmp10.Items.Count
        Dim byTempBuf(iCount * 16 * 1024 - 1) 'the max value

        SaveFileDialog1.Filter = "template(*.fp10.1)|*.fp10.1"
        SaveFileDialog1.FileName = "template.fp10.1"
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim iDataBufIndex As Integer = 0
            Dim lvItem As New ListViewItem

            For Each lvItem In lvTmp10.Items
                Dim iSize As Integer = Convert.ToInt32(lvItem.SubItems(0).Text.Trim())
                Dim iPIN As Integer = Convert.ToInt32(lvItem.SubItems(1).Text.Trim())
                Dim iFingerIndex As Integer = Convert.ToInt32(lvItem.SubItems(2).Text.Trim())
                Dim iValid As Integer = Convert.ToInt32(lvItem.SubItems(3).Text.Trim())
                Dim sTemplate As String = lvItem.SubItems(4).Text.Trim()

                Dim byTmpInfo() As Byte = Nothing
                udisk.SetTmp10ToFp10(byTmpInfo, iSize, iPIN, iFingerIndex, iValid, sTemplate)
                Array.Copy(byTmpInfo, 0, byTempBuf, iDataBufIndex, iSize)
                iDataBufIndex += iSize
                iLength += iSize
            Next
        End If
        Dim byDataBuf(iLength - 1) As Byte
        Array.Copy(byTempBuf, byDataBuf, iLength)
        File.WriteAllBytes(SaveFileDialog1.FileName, byDataBuf)
    End Sub
#End Region

#Region "Short Messages(TFT)"
    'To read the short messages in the TFT screen devices (Filename:sms.dat)
    Private Sub btnSSRSMSRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSRSMSRead.Click
        Dim udisk As New Structs.UDisk

        Dim byDataBuf() As Byte = Nothing
        Dim iLength As Integer
        Dim iCount As Integer 'count of short messages

        Dim iTag As Integer
        Dim iID As Integer
        Dim iValidMinutes As Integer
        Dim iReserved As Integer
        Dim sStartTime As String = ""
        Dim sContent As String = ""

        lvSSRSMS.Items.Clear()
        Dim lvItem As New ListViewItem
        OpenFileDialog1.Filter = "sms(*.dat)|*.dat"
        OpenFileDialog1.FileName = "sms.dat"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim stream As FileStream
            stream = New FileStream(OpenFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read)
            byDataBuf = File.ReadAllBytes(OpenFileDialog1.FileName)
            iLength = Convert.ToInt32(stream.Length)

            If iLength Mod 332 <> 0 Then
                MsgBox("Data Error!", MsgBoxStyle.Exclamation, "Error")
                Return
            End If

            iCount = iLength \ 332

            For j As Integer = 0 To iCount - 1 'loop
                Dim bySMSInfo(331) As Byte
                For i As Integer = 0 To 331
                    bySMSInfo(i) = byDataBuf(j * 332 + i)
                Next

                udisk.GetSSRSMSFromDat(bySMSInfo, iTag, iID, iValidMinutes, iReserved, sStartTime, sContent)

                lvItem = lvSSRSMS.Items.Add(iTag.ToString())
                lvItem.SubItems.Add(iID.ToString())
                lvItem.SubItems.Add(iValidMinutes.ToString())
                lvItem.SubItems.Add(iReserved.ToString())
                lvItem.SubItems.Add(sStartTime)
                lvItem.SubItems.Add(sContent)

                bySMSInfo = Nothing
            Next

            stream.Close()
        End If

    End Sub
    'To write the short messages in the TFT screen devices (Filename:sms.dat)
    Private Sub btnSSRSMSWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSRSMSWrite.Click
        Dim udisk As New Structs.UDisk

        Dim iCount As Integer = lvSSRSMS.Items.Count
        Dim byDataBuf(iCount * 332 - 1) As Byte

        Dim lvItem As New ListViewItem
        SaveFileDialog1.Filter = "sms(*.dat)|*.dat"
        SaveFileDialog1.FileName = "sms.dat"
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim iDataBufIndex As Integer = 0
            For Each lvItem In lvSSRSMS.Items
                Dim iTag As Integer = Convert.ToInt32(lvItem.SubItems(0).Text.Trim())
                Dim iID As Integer = Convert.ToInt32(lvItem.SubItems(1).Text.Trim())
                Dim iValidMinutes As Integer = Convert.ToInt32(lvItem.SubItems(2).Text.Trim())
                Dim iReserved As Integer = Convert.ToInt32(lvItem.SubItems(3).Text.Trim())
                Dim sStartTime As String = lvItem.SubItems(4).Text.Trim()
                Dim sContent As String = lvItem.SubItems(5).Text

                Dim bySMSInfo() As Byte = Nothing
                udisk.SetSSRSMSToDat(bySMSInfo, iTag, iID, iValidMinutes, iReserved, sStartTime, sContent)
                Array.Copy(bySMSInfo, 0, byDataBuf, iDataBufIndex, 332)
                iDataBufIndex += 332
            Next
        End If

        File.WriteAllBytes(SaveFileDialog1.FileName, byDataBuf)
    End Sub
    'Read the relation between user pin and short message id(FileName:udata.dat)
    Private Sub btnUDataRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUDataRead.Click
        Dim udisk As New Structs.UDisk

        Dim byDataBuf() As Byte
        Dim iLength As Integer
        Dim iCount As Integer

        Dim iPIN As Integer
        Dim iSmsID As Integer

        lvUData.Items.Clear()
        Dim lvItem As ListViewItem
        OpenFileDialog1.Filter = "udata(*.dat)|*.dat"
        OpenFileDialog1.FileName = "udata.dat"
        If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Dim stream As FileStream
            stream = New FileStream(OpenFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read)
            byDataBuf = File.ReadAllBytes(OpenFileDialog1.FileName)

            iLength = Convert.ToInt32(stream.Length)
            If iLength Mod 4 <> 0 Then
                MsgBox("Data Error!", MsgBoxStyle.Exclamation, "Error")
                Return
            End If
            iCount = iLength \ 4

            For j As Integer = 0 To iCount - 1
                Dim byUDataInfo(3) As Byte
                For i As Integer = 0 To 3
                    byUDataInfo(i) = byDataBuf(j * 4 + i)
                Next

                udisk.GetUDataFromDat(byUDataInfo, iPIN, iSmsID)

                lvItem = lvUData.Items.Add(iPIN.ToString())
                lvItem.SubItems.Add(iSmsID.ToString())

                byUDataInfo = Nothing
            Next
            stream.Close()
        End If
    End Sub
    'Write the relation between user pin and short message id(FileName:udata.dat)
    Private Sub btnUDataWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUDataWrite.Click
        Dim udisk As New Structs.UDisk

        Dim iCount As Integer = lvUData.Items.Count
        Dim byDataBuf(iCount * 4 - 1) As Byte

        Dim lvItem As New ListViewItem
        SaveFileDialog1.Filter = "udata(*.dat)|*.dat"
        SaveFileDialog1.FileName = "udata.dat"
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim iDataBufIndex As Integer
            For Each lvItem In lvUData.Items
                Dim iPIN As Integer = Convert.ToInt32(lvItem.SubItems(0).Text.Trim())
                Dim iSmsID As Integer = Convert.ToInt32(lvItem.SubItems(1).Text.Trim())

                Dim byUDataInfo() As Byte = Nothing
                udisk.SetUDataToDat(byUDataInfo, iPIN, iSmsID)
                Array.Copy(byUDataInfo, 0, byDataBuf, iDataBufIndex, 4)
                iDataBufIndex += 4
            Next
        End If
        File.WriteAllBytes(SaveFileDialog1.FileName, byDataBuf)
    End Sub
#End Region

End Class
