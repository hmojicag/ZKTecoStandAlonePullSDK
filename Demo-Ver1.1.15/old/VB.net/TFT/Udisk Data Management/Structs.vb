Imports System.Runtime.InteropServices
Imports System.Globalization
Imports System.Diagnostics
Imports UdiskData
Public Class Structs
    'The data is stored in the little endian strorage mode and in accordance with a byte-aligned

    'User information of TFT screen device(Fixed-length data format-72 bytes in all)
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Class SSR_User
        Public PIN As UShort
        Public Privilege As Byte

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Public Password(7) As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=24)> Public Name(23) As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Public Card(3) As Byte
        Public Group As Byte

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Public TimeZones(3) As UShort 'the timezones that the user can use
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=24)> Public PIN2(23) As Byte
    End Class

    'fingerprint templates information of 9.0 arithmetic(Fixed-length data format-608 bytes in all)
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Class Templates9
        Public Size As UShort
        Public PIN As UShort
        Public FingerID As Byte
        Public Valid As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=602)> Public Template(601) As Byte 'the max value is 602 bytes 
    End Class
    'fingerprint templates information of 10.0 arithmetic(Variable-length data format)
    'The max length of one template is 16 kb, that is, one template's length is less than 16kb.
    'The following is the fixed-length part of the data struct which is 6 bytes long.
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Class Tmp10Header
        Public Size As UShort
        Public PIN As UShort
        Public FingerID As Byte
        Public Valid As Byte
    End Class

    'the short message struct of TFT screen devices(Fixed-length data format-332 bytes in all)
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Class SSR_SMS
        Public Tag As Byte 'type of short message
        Public ID As UShort 'the tag of the data,zero means that the log is invalid.
        Public ValidMinutes As UShort ' zero stands for forever
        Public Reserved As UShort
        Public StartTime As UShort
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=UDisk.MAX_SSR_SMS_CONTENT_SIZE * 2 + 1)> _
        Public Content(UDisk.MAX_SSR_SMS_CONTENT_SIZE * 2 + 1) As Byte 'the content of the short message
    End Class

    'the struct showing the relation between the user id and its short message
    '/For both Black&White and TFT screen devices-Fixed-length data format-4 bytes in all
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Class UData
        Public PIN As UShort '0 stands for invalid log
        Public SmsID As UShort
    End Class

Class UDisk
        Public Const MAX_SSR_SMS_CONTENT_SIZE As Integer = 160 'the max length of short message in the TFT screen devices 

        '****************************************************************************************************************************
        '* FunctionName:GetSSRUserInfoFromDat
        '* Parameters In:PDataBuf
        '* Parameters Out:PIN,Privilege,Password,Name,Card,Group,TimeZones(string),PIN2(string)
        '* Return Value:void
        '* Device Used:user.dat in TFT screen Device
        '* Function:To parse the bytes arrays from user.dat according to the class SSR_User and get out the independent parameters
        '* Auther:Darcy
        '* Date:Dec.4, 2009
        '*****************************************************************************************************************************/
        Public Function GetSSRUserInfoFromDat(ByVal DataBuf() As Byte, ByRef PIN As Integer, ByRef Privilege As Integer, ByRef Password As String, ByRef Name As String, ByRef Card As Integer, ByRef Group As Integer, ByRef TimeZone As String, ByRef PIN2 As String)
            Dim PasswordBuf(7) As Byte
            Dim NameBuf(23) As Byte
            Dim TimeZoneBuf(7) As Byte
            dim PIN2Buf(23) as Byte 

            Dim ssruser As New SSR_User
            ssruser = CType(Raw.RawDeserialize(DataBuf, ssruser.GetType()), SSR_User)
            Dim length As Integer = Marshal.SizeOf(ssruser)
            PIN = ssruser.PIN
            Privilege = ssruser.Privilege
            Array.Copy(DataBuf, 3, PasswordBuf, 0, 8)
            Password = System.Text.Encoding.Default.GetString(PasswordBuf) '"default" is to read the system's current ANSI code page encoding

            Array.Copy(DataBuf, 11, NameBuf, 0, 24)
            Name = System.Text.Encoding.Default.GetString(NameBuf)

            Card = 0
            For i As Integer = 35 To 38
                Card += Convert.ToInt32(DataBuf(i) * System.Math.Pow(16, 2 * (i - 35)))
            Next

            Group = ssruser.Group

            Array.Copy(DataBuf, 40, TimeZoneBuf, 0, 8)
            TimeZone = System.Text.Encoding.Default.GetString(TimeZoneBuf)

            Array.Copy(DataBuf, 48, PIN2Buf, 0, 24)
            PIN2 = System.Text.Encoding.Default.GetString(PIN2Buf)

            Return Nothing
        End Function
    '****************************************************************************************************************************
    '* FunctionName:SetUserInfoToDat
    '* Parameters In:PIN,Privilege,Password,Name,Card,Group,TimeZones,PIN2
    '* Parameters Out:DataBuf
    '* Return Value:void
    '* Device Used:user.dat in Black&White screen Device
    '* Function:To convert the independent parameters to bytes arrays DataBuf according to the class User
    '* Auther:Darcy
    '* Date:Dec.15, 2009
    '*****************************************************************************************************************************
        Public Function SetSSRUserInfoToDat(ByRef DataBuf() As Byte, ByVal PIN As Integer, ByVal Privilege As Integer, ByVal Password As String, ByVal Name As String, ByVal Card As Integer, ByVal Group As Integer, ByVal TimeZones As String, ByVal PIN2 As Integer)
            ReDim DataBuf(71)

            Dim PasswordBuf(7) As Byte
            Dim NameBuf(24) As Byte
            Dim CardBuf(3) As Byte
            Dim TimeZonesBuf(7) As Byte
            Dim PIN2Buf() As Byte

            Dim ssruser As New SSR_User

            ssruser.PIN = Convert.ToUInt16(PIN)
            ssruser.Privilege = Convert.ToByte(Privilege)

            PasswordBuf = System.Text.Encoding.Default.GetBytes(Password)
            Array.Copy(PasswordBuf, ssruser.Password, 8)

            NameBuf = System.Text.Encoding.Default.GetBytes(Name)
            Array.Copy(NameBuf, ssruser.Name, 24)

            CardBuf = BitConverter.GetBytes(Card)
            Array.Copy(CardBuf, ssruser.Card, 4)

            ssruser.Group = Convert.ToByte(Group)

            TimeZonesBuf = System.Text.Encoding.Default.GetBytes(TimeZones)
            ssruser.TimeZones(0) = Convert.ToUInt16(TimeZonesBuf(0)) 'whether to use timezones or not (0 stands for yes,1 stands for defining by yourself)
            ssruser.TimeZones(1) = Convert.ToUInt16(TimeZonesBuf(1)) '(if you use the timezones)timezoune1
            ssruser.TimeZones(2) = Convert.ToUInt16(TimeZonesBuf(2)) 'timezone2
            ssruser.TimeZones(3) = Convert.ToUInt16(TimeZonesBuf(3)) 'timezone3

            PIN2Buf = System.Text.Encoding.Default.GetBytes(PIN2)
            ReDim Preserve PIN2Buf(23)
            Array.Copy(PIN2Buf, ssruser.PIN2, 24)

            Array.Copy(Raw.RawSerialize(ssruser), DataBuf, 72)
            Return Nothing
        End Function
    '****************************************************************************************************************************
    '* FunctionName:GetAttLogFromDat
    '* Parameters In:DataBuf,OneLogLength
    '* Parameters Out:PIN2,Time_second,DeviceID,Status,Verified,Workcode
    '* Return Value:void
    '* Device Used:(For Black&White screen devices).i_attlog.dat(i is the Device ID)
    '* Function:To parse the attendence logs byte arrays to independent parameters
    '* Explanation:The SerialNumber(SN) and the CheckSum are not dealed with by this function.
    '* Auther:Darcy
    '* Date:Dec.15, 2009
    '*****************************************************************************************************************************
    Public Function GetAttLogFromDat(ByVal DataBuf() As Byte, ByVal OneLogLength As Integer, ByRef PIN2 As String, ByRef Time_second As String, ByRef DeviceID As String, ByRef Status As String, ByRef Verified As String, ByRef Workcode As String)
        Dim i As Integer
        Dim Index As Integer

        For i = Index To OneLogLength - 1
            If DataBuf(i) = 9 Then 'Ascii code 9 stands for the tab key on your keyboard.
                Dim PIN2Buf(i - 1) As Byte
                Array.Copy(DataBuf, 0, PIN2Buf, 0, i)
                PIN2 = System.Text.Encoding.Default.GetString(PIN2Buf)
                Index = i
                Exit For
            End If
        Next

        For i = Index + 1 To OneLogLength - 1
            If DataBuf(i) = 9 Then 'the second tab key
                Dim TimeBuf(i - Index - 2) As Byte
                Array.Copy(DataBuf, Index + 1, TimeBuf, 0, i - Index - 1)
                Time_second = System.Text.Encoding.Default.GetString(TimeBuf)
                Index = i
                Exit For
            End If
        Next

        For i = Index + 1 To OneLogLength - 1
            If DataBuf(i) = 9 Then 'the third tab key
                Dim DeviceIDBuf(i - Index - 2) As Byte
                Array.Copy(DataBuf, Index + 1, DeviceIDBuf, 0, i - Index - 1)
                DeviceID = System.Text.Encoding.Default.GetString(DeviceIDBuf)
                Index = i
                Exit For
            End If
        Next

        For i = Index + 1 To OneLogLength - 1
            If DataBuf(i) = 9 Then 'the fourth tab key
                Dim StatusBuf(i - Index - 2) As Byte
                Array.Copy(DataBuf, Index + 1, StatusBuf, 0, i - Index - 1)
                Status = System.Text.Encoding.Default.GetString(StatusBuf)
                Index = i
                Exit For
            End If
        Next

        For i = Index + 1 To OneLogLength - 1
            If DataBuf(i) = 9 Then 'the fifth tab key
                Dim VerifiedBuf(i - Index - 2) As Byte
                Array.Copy(DataBuf, Index + 1, VerifiedBuf, 0, i - Index - 1)
                Verified = System.Text.Encoding.Default.GetString(VerifiedBuf)
                Index = i
                Exit For
            End If
        Next

        For i = Index + 1 To OneLogLength
            If DataBuf(i) = 13 Then 'the sixth tab key
                Dim WorkcodeBuf(i - Index - 1) As Byte
                Array.Copy(DataBuf, Index + 1, WorkcodeBuf, 0, i - Index - 1)
                Workcode = System.Text.Encoding.Default.GetString(WorkcodeBuf)
                Exit For
            End If
        Next

        Return Nothing
    End Function
    '****************************************************************************************************************************
    '* FunctionName:GetTemplateFromDat
    '* Parameters In:DataBuf
    '* Parameters Out:Size,PIN,FingerID,Valid,Template
    '* Return Value:void
    '* Device Used:template.dat in Black&White screen devices using 9.0 arithmetic 
    '* Function:To parse the bytes arrays from template.dat according to the class Template and get out the independent parameters
    '* Explanation:To parse according to the max finger templage 602bytes
    '* Auther:Darcy
    '* Date:Dec.15, 2009
    '*****************************************************************************************************************************
    Public Function GetTemplateFromDat(ByVal DataBuf() As Byte, ByRef Size As Integer, ByRef PIN As Integer, ByRef FingerID As Integer, ByRef Valid As Integer, ByRef Template As String)
        Dim TemplateBuf(601) As Byte

        Dim tmp As New Templates9
        tmp = CType(Raw.RawDeserialize(DataBuf, tmp.GetType()), Templates9)

        Size = tmp.Size
        PIN = tmp.PIN
        FingerID = tmp.FingerID
        Valid = tmp.Valid

        Array.Copy(DataBuf, 6, TemplateBuf, 0, 602)
        Template = BitConverter.ToString(TemplateBuf).Replace("-", "") 'Str to Hex

        Return Nothing
    End Function
    '****************************************************************************************************************************
    '* FunctionName:SetTemplateToDat
    '* Parameters In:Size,PIN,FingerID,Valid,Template
    '* Parameters Out:DataBuf
    '* Return Value:void
    '* Device Used:template.dat in Black&White screen devices using 9.0 arithmetic
    '* Function:To convert the independent parameters to bytes arrays DataBuf according to the class Template
    '* Explanation:To write according to the max finger templage 602bytes
    '* Auther:Darcy
    '* Date:Dec.15, 2009
    '*****************************************************************************************************************************
    Public Function SetTemplateToDat(ByRef DataBuf() As Byte, ByVal Size As Integer, ByVal PIN As Integer, ByVal FingerID As Integer, ByVal Valid As Integer, ByVal Template As String)
        ReDim DataBuf(607)
        Dim TemplateBuf(601) As Byte

        Dim tmp As New Templates9

        tmp.Size = Convert.ToUInt16(Size)
        tmp.PIN = Convert.ToUInt16(PIN)
        tmp.FingerID = Convert.ToByte(FingerID)
        tmp.Valid = Convert.ToByte(Valid)

        Template = Template.Replace(" ", "")
        If Template.Length <= 0 Then
            Template = ""
        End If

        Dim TemplateBytes(Template.Length / 2 - 1) As Byte
        For i As Integer = 0 To Template.Length - 1 Step +2
            If Byte.TryParse(Template.Substring(i, 2), NumberStyles.HexNumber, Nothing, TemplateBytes(i / 2)) = False Then
                TemplateBytes(i / 2) = 0
            End If
        Next
        Dim TemplateFromHex As String = System.Text.ASCIIEncoding.Default.GetString(TemplateBytes)
        TemplateBuf = System.Text.Encoding.Default.GetBytes(TemplateFromHex)

        Array.Copy(TemplateBuf, tmp.Template, TemplateFromHex.Length)

        Array.Copy(Raw.RawSerialize(tmp), DataBuf, 608)

        Return Nothing
        End Function
        '****************************************************************************************************************************
        '* FunctionName:GetTmp10FromFp10
        '* Parameters In:DataBuf
        '* Parameters Out:Size,PIN,FingerID,Valid,Template
        '* Return Value:void
        '* Device Used:template.fp10.1 coming from devices using 10.0 arithmetic
        '* Function:To parse the bytes arrays from template.fp10.1 according to the class Tmp10Header and get out the independent parameters
        '* Explanation:the length of the finger templates is variable 
        '* Auther:Darcy
        '* Date:Dec.4, 2009
        '*****************************************************************************************************************************
        Public Function GetTmp10FromFp10(ByVal DataBuf() As Byte, ByVal Size As Integer, ByRef PIN As Integer, ByRef FingerID As Integer, ByRef Valid As Integer, ByRef Template As String)
            Dim TemplateBuf(Size - 17) As Byte

            PIN = DataBuf(2) + DataBuf(3) * 256
            FingerID = DataBuf(4)
            Valid = DataBuf(5)
            Array.Copy(DataBuf, 6, TemplateBuf, 0, Size - 16)
            Template = BitConverter.ToString(TemplateBuf).Replace("-", "") 'Str to Hex

            Return Nothing
        End Function
        '****************************************************************************************************************************
        '* FunctionName:SetTmp10ToFp10
        '* Parameters In:Size,PIN,FingerID,Valid,Template
        '* Parameters Out:DataBuf
        '* Return Value:void
        '* Device Used:template.fp10.1 coming from devices using 10.0 arithmetic
        '* Function:To convert the independent parameters to bytes arrays DataBuf according to the class Template
        '* Explanation:he length of the finger templates is variable 
        '* Auther:Darcy
        '* Date:Dec.4, 2009
        '*****************************************************************************************************************************
        Public Function SetTmp10ToFp10(ByRef DataBuf() As Byte, ByVal Size As Integer, ByVal PIN As Integer, ByVal FingerID As Integer, ByVal Valid As Integer, ByVal Template As String)
            ReDim DataBuf(Size - 1)
            Dim TemplateBuf(Size - 7) As Byte

            Dim tmp10 As New Tmp10Header

            tmp10.Size = Convert.ToUInt16(Size)
            tmp10.PIN = Convert.ToUInt16(PIN)
            tmp10.FingerID = Convert.ToByte(FingerID)
            tmp10.Valid = Convert.ToByte(Valid)

            Array.Copy(Raw.RawSerialize(tmp10), DataBuf, 6)

            Template = Template.Replace(" ", "")
            If Template.Length <= 0 Then
                Template = ""
            End If

            Dim TemplateBytes(Template.Length \ 2) As Byte

            For i As Integer = 0 To Template.Length - 1 Step +2
                If Byte.TryParse(Template.Substring(i, 2), NumberStyles.HexNumber, Nothing, TemplateBytes(i / 2)) = False Then
                    TemplateBytes(i \ 2) = 0
                End If
            Next
           
            Dim TemplateFromHex As String = System.Text.ASCIIEncoding.Default.GetString(TemplateBytes)
            TemplateBuf = System.Text.Encoding.Default.GetBytes(TemplateFromHex)

            Array.Copy(TemplateBuf, 0, DataBuf, 6, TemplateFromHex.Length)

            Return Nothing
        End Function
        '****************************************************************************************************************************
        '* FunctionName:GetSSRSMSFromDat
        '* Parameters In:DataBuf
        '* Parameters Out:Tag,ID,ValidMinutes,Reserved,StartTime,Content
        '* Return Value:void
        '* Device Used:Just for TFT screen devices.sms.dat
        '* Function:To parse the short messages byte array to independent parameters
        '* Auther:Darcy
        '* Date:Dec.4, 2009
        '*****************************************************************************************************************************
        Public Function GetSSRSMSFromDat(ByVal DataBuf() As Byte, ByRef Tag As Integer, ByRef ID As Integer, ByRef ValidMinutes As Integer, ByRef Reserved As Integer, ByRef StartTime As String, ByRef Content As String)
            Dim ContentBuf(UDisk.MAX_SSR_SMS_CONTENT_SIZE * 2) As Byte
            Dim sms As New SSR_SMS
            sms = CType(Raw.RawDeserialize(DataBuf, sms.GetType()), SSR_SMS)

            Tag = sms.Tag
            ID = sms.ID
            ValidMinutes = sms.ValidMinutes
            Reserved = sms.Reserved

            'decode time from uint value type to string value type
            Dim Time As Integer = Convert.ToInt32(sms.StartTime)
            Dim Year, Month, Day, Hour, Minute, Second As Integer
            Second = Time Mod 60
            Time \= 60
            Minute = Time Mod 60
            Time \= 60
            Hour = Time Mod 24
            Time \= 24
            Day = Time Mod 31 + 1
            Time \= 31
            Month = Time Mod 12 + 1
            Time \= 12
            Year = Time + 2000
            Dim dt As Date
            dt = New DateTime(Convert.ToInt32(Year), Convert.ToInt32(Month), Convert.ToInt32(Day), Convert.ToInt32(Hour), Convert.ToInt32(Minute), Convert.ToInt32(Second))

            StartTime = dt.ToString()

            Array.Copy(DataBuf, 11, ContentBuf, 0, UDisk.MAX_SSR_SMS_CONTENT_SIZE * 2 + 1)
            Content = System.Text.Encoding.Default.GetString(ContentBuf)

            Return Nothing
        End Function
        '****************************************************************************************************************************
        '* FunctionName:SetSSRSMSToDat
        '* Parameters In:Tag,ID,ValidMinutes,Reserved,StartTime,Content
        '* Parameters Out:DataBuf
        '* Return Value:void
        '* Device Used:Just for TFT screen devices.sms.dat
        '* Function:To convert the parameters to the byte array stored short messages
        '* Auther:Darcy
        '* Date:Dec.4, 2009
        '*****************************************************************************************************************************/
        Public Function SetSSRSMSToDat(ByRef DataBuf() As Byte, ByVal Tag As Integer, ByVal ID As Integer, ByVal ValidMinutes As Integer, ByVal Reserved As Integer, ByVal StartTime As String, ByVal Content As String)
            ReDim DataBuf(331)
            Dim ContentBuf(UDisk.MAX_SSR_SMS_CONTENT_SIZE * 2) As Byte
            Dim TempBuf() As Byte = Nothing

            Dim sms As New SSR_SMS

            sms.Tag = Convert.ToByte(Tag)
            sms.ID = Convert.ToUInt16(ID)
            sms.ValidMinutes = Convert.ToUInt16(ValidMinutes)
            sms.Reserved = Convert.ToUInt16(Reserved)

            'Encode time from string value type to unit value type
            Dim dt As Date
            dt = Convert.ToDateTime(StartTime)

            Dim Time As Integer
            Time = ((dt.Year Mod 100) * 12 * 31 + ((dt.Month - 1) * 31) + dt.Day - 1) * (24 * 60 * 60) + (dt.Hour * 60 + dt.Minute) * 60 + dt.Second
            sms.StartTime = Convert.ToUInt32(Time)

            TempBuf = System.Text.Encoding.Default.GetBytes(Content)
            Array.Copy(TempBuf, sms.Content, TempBuf.Length)

            Array.Copy(Raw.RawSerialize(sms), DataBuf, Marshal.SizeOf(sms))

            Return Nothing
        End Function
        '****************************************************************************************************************************
        '* FunctionName:GetUDataFromDat
        '* Parameters In:DataBuf
        '* Parameters Out:PIN,SmsID
        '* Return Value:void
        '* Device Used:For Black&White screen devices.udata.dat
        '* Function:To parse the attendence logs byte arrays to independent parameters
        '* Auther:Darcy
        '* Date:Dec.15, 2009
        '*****************************************************************************************************************************
        Public Function GetUDataFromDat(ByVal DataBuf() As Byte, ByRef PIN As Integer, ByRef SmsID As Integer)
            Dim udata As New UData
            udata = CType(Raw.RawDeserialize(DataBuf, udata.GetType()), UData)

            PIN = udata.PIN
            SmsID = udata.SmsID

            Return Nothing
        End Function
        '****************************************************************************************************************************
        '* FunctionName:SetUDataToDat
        '* Parameters In:PIN,SmsID
        '* Parameters Out:DataBuf
        '* Return Value:void
        '* Device Used:For Black&White screen devices. udata.dat
        '* Function:To convert imported parameters to the byte array 
        '* Auther:Darcy
        '* Date:Dec.15, 2009
        '*****************************************************************************************************************************
        Public Function SetUDataToDat(ByRef DataBuf() As Byte, ByVal PIN As Integer, ByVal SmsID As Integer)
            ReDim DataBuf(3)
            Dim udata As New UData

            udata.PIN = Convert.ToUInt16(PIN)
            udata.SmsID = Convert.ToUInt16(SmsID)
            Array.Copy(Raw.RawSerialize(udata), DataBuf, 4)

            Return Nothing
        End Function
    End Class
End Class
