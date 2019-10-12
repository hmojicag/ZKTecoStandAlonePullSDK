Imports System.Runtime.InteropServices
Imports System.Globalization
Imports System.Diagnostics
Imports UdiskData
Public Class Structs
    'The data is stored in the little endian strorage mode and in accordance with a byte-aligned

    'User information of Black&White screen device(Fixed-length data format-28 bytes in all)
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Class User
        Public PIN As UShort
        Public Privilege As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Public Password(4) As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Public Name(7) As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Public Card(4) As Byte
        Public Group As Byte
        Public TimeZones As UShort
        Public PIN2 As UInt32
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
    'the short message struct of Black&White screen devices(Fixed-length data format-72 bytes in all)
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Class SMS
        Public Tag As Byte
        Public ID As UShort
        Public ValidMinutes As UShort
        Public Reserved As UShort
        Public StartTime As UInt32
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=UDisk.MAX_SMS_CONTENT_SIZE + 1)> Public Content(UDisk.MAX_SMS_CONTENT_SIZE) As Byte
    End Class
    'the struct showing the relation between the user id and its short message
    'For Black&White screen devices-Fixed-length data format-4 bytes in all
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Class UData
        Public PIN As UShort '0 stands for invalid log
        Public SmsID As UShort
    End Class

    Class UDisk
        Public Const MAX_SMS_CONTENT_SIZE As Integer = 60 'the max length of short message in the Black&White screen devices

        '****************************************************************************************************************************
        '* FunctionName:GetUserInfoFromDat
        '* Parameters In:PDataBuf
        '* Parameters Out:PIN,Privilege,Password,Name,Card,Group,TimeZones,PIN2
        '* Return Value:void
        '* Device Used:user.dat in Black&White screen Device
        '* Function:To parse the bytes arrays from user.dat according to the class User and get out the independent parameters 
        '* Auther:Darcy
        '* Date:Dec.15, 2009
        '*****************************************************************************************************************************
        Public Function GetUserInfoFromDat(ByVal DataBuf() As Byte, ByRef PIN As Integer, ByRef Privilege As Integer, ByRef Password As String, ByRef Name As String, ByRef Card As Integer, ByRef Group As Integer, ByRef TimeZones As Integer, ByRef PIN2 As Integer)
            Dim PasswordBuf(5) As Byte
            Dim NameBuf(8) As Byte
            Dim user As New User

            user = CType(Raw.RawDeserialize(DataBuf, user.GetType()), User)

            PIN = user.PIN
            Privilege = user.Privilege

            Array.Copy(DataBuf, 3, PasswordBuf, 0, 5)
            Password = System.Text.Encoding.Default.GetString(PasswordBuf) '"default" is to read the system's current ANSI code page encoding

            Array.Copy(DataBuf, 8, NameBuf, 0, 8)
            Name = System.Text.Encoding.Default.GetString(NameBuf)

            Card = 0
            Dim i As Integer
            For i = 0 To 20
                Card += Convert.ToInt32(DataBuf(i) * (System.Math.Pow(16, 2 * (i - 16))))
            Next

            Group = user.Group
            TimeZones = user.TimeZones
            PIN2 = Convert.ToInt32(user.PIN2)

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
        '* Date:Oct.23, 2009
        '*****************************************************************************************************************************
        Public Function SetUserInfoToDat(ByRef DataBuf() As Byte, ByVal PIN As Integer, ByVal Privilege As Integer, ByVal Password As String, ByVal Name As String, ByVal Card As Integer, ByVal Group As Integer, ByVal TimeZone As Integer, ByVal PIN2 As Integer)
            ReDim DataBuf(27)
            Dim PasswordBuf(4) As Byte
            Dim NameBuf(7) As Byte
            Dim CardBuf(4) As Byte

            Dim user As New User

            user.PIN = Convert.ToUInt16(PIN)
            user.Privilege = Convert.ToByte(Privilege)

            PasswordBuf = System.Text.Encoding.Default.GetBytes(Password)
            Array.Copy(PasswordBuf, user.Password, 5)

            NameBuf = System.Text.Encoding.Default.GetBytes(Name)
            Array.Copy(NameBuf, user.Name, 8)

            CardBuf = BitConverter.GetBytes(Card)
            Array.Copy(CardBuf, user.Card, 4) 'Although we have defined 5 bytes to store the card number,but in fact 4bytes is enough(an integer data)

            user.Group = Convert.ToByte(Group)

            TimeZone = user.TimeZones

            user.PIN2 = Convert.ToUInt16(PIN2)

            Array.Copy(Raw.RawSerialize(user), 0, DataBuf, 0, 28)
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
        '* Date:Oct.23, 2009
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
        '* Date:Oct.23, 2009
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
        '* Date:Oct.23, 2009
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
        '* FunctionName:GetSMSFromDat
        '* Parameters In:DataBuf
        '* Parameters Out:Tag,ID,ValidMinutes,Reserved,StartTime,Content
        '* Return Value:void
        '* Device Used:Just for Black&White screen devices.sms.dat
        '* Function:To parse the short messages byte array to independent parameters
        '* Auther:Darcy
        '* Date:Oct.23, 2009
        '*****************************************************************************************************************************
        Public Function GetSMSFromDat(ByVal DataBuf() As Byte, ByRef Tag As Integer, ByRef ID As Integer, ByRef ValidMinutes As Integer, ByRef Reserved As Integer, ByRef StartTime As String, ByRef Content As String)
            Dim ContentBuf(UDisk.MAX_SMS_CONTENT_SIZE) As Byte

            Dim sms As New SMS
            sms = CType(Raw.RawDeserialize(DataBuf, sms.GetType()), SMS)

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

            Array.Copy(DataBuf, 11, ContentBuf, 0, UDisk.MAX_SMS_CONTENT_SIZE + 1)

            Content = System.Text.Encoding.Default.GetString(ContentBuf)

            Return Nothing
        End Function
        '****************************************************************************************************************************
        '* FunctionName:SetSMSToDat
        '* Parameters In:Tag,ID,ValidMinutes,Reserved,StartTime,Content
        '* Parameters Out:DataBuf
        '* Return Value:void
        '* Device Used:Just for Black&White screen devices.sms.dat
        '* Function:To convert the parameters to the byte array stored short messages
        '* Auther:Darcy
        '* Date:Oct.23, 2009
        '*****************************************************************************************************************************
        Public Function SetSMSToDat(ByRef DataBuf() As Byte, ByVal Tag As Integer, ByVal ID As Integer, ByVal ValidMinutes As Integer, ByVal Reserved As Integer, ByVal StartTime As String, ByVal Content As String)
            ReDim DataBuf(71)
            Dim ContentBuf(UDisk.MAX_SMS_CONTENT_SIZE) As Byte
            Dim TempBuf() As Byte = Nothing

            Dim sms As New SMS

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
        '* Date:Oct.23, 2009
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
        '* Date:Oct.23, 2009
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
