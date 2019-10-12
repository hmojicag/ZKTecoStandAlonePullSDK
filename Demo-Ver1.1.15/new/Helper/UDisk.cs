using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;//structlayout,marshalas

namespace StandaloneSDKDemo
{
    public class UDisk
    {
        public const int MAX_SSR_SMS_CONTENT_SIZE = 160;//the max length of short message in the TFT screen devices
        public const int MAX_SMS_CONTENT_SIZE = 60; //the max length of short message in the Black&White screen devices

        /****************************************************************************************************************************
        * FunctionName:GetSSRUserInfoFromDat
        * Parameters In:PDataBuf
        * Parameters Out:PIN,Privilege,Password,Name,Card,Group,TimeZones(string),PIN2(string)
        * Return Value:void
        * Device Used:user.dat in TFT screen Device
        * Function:To parse the bytes arrays from user.dat according to the class SSR_User and get out the independent parameters
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void GetSSRUserInfoFromDat(byte[] DataBuf, out int PIN, out int Privilege, out string Password,
           out string Name, out int Card, out int Group, ref ushort[] TimeZone, out string PIN2)
        {
            byte[] PasswordBuf = new byte[8];
            byte[] NameBuf = new byte[24];
            byte[] TimeZoneBuf = new byte[2];
            byte[] PIN2Buf = new byte[24];
            SSR_User ssruser = new SSR_User();
            ssruser = (SSR_User)Raw.RawDeserialize(DataBuf, typeof(SSR_User));
            PIN = ssruser.PIN;

            if (ssruser.Privilege == 14)
            {
                Privilege = 3;
            }
            else if (ssruser.Privilege == 10)
            {
                Privilege = 4;
            }
            else if (ssruser.Privilege == 6)
            {
                Privilege = 2;
            }
            else if (ssruser.Privilege == 2)
            {
                Privilege = 1;
            }
            else if (ssruser.Privilege == 1)
            {
                Privilege = 5;//Invaid User
            }
            else
            {
                Privilege = 0;
            }
            
            Array.Copy(DataBuf, 3, PasswordBuf, 0, 8);
            Password = System.Text.Encoding.Default.GetString(PasswordBuf);//"default" is to read the system's current ANSI code page encoding

            Array.Copy(DataBuf, 11, NameBuf, 0, 24);
            Name = System.Text.Encoding.Default.GetString(NameBuf);

            Card = 0;
            for (int i = 35; i <= 38; i++)
            {
                Card += Convert.ToInt32(DataBuf[i] * System.Math.Pow(16, 2 * (i - 35)));
            }
            Group = ssruser.Group;

            TimeZone[0] = ssruser.TimeZones[0];
            TimeZone[1] = ssruser.TimeZones[1];
            TimeZone[2] = ssruser.TimeZones[2];
            TimeZone[3] = ssruser.TimeZones[3];

            Array.Copy(DataBuf, 48, PIN2Buf, 0, 24);
            PIN2 = System.Text.Encoding.Default.GetString(PIN2Buf);
        }

        /****************************************************************************************************************************
        * FunctionName:SetSSRUserInfoToDat
        * Parameters In:PIN,Privilege,Password,Name,Card,Group,TimeZones(string),PIN2(string)
        * Parameters Out:DataBuf
        * Return Value:void
        * Device Used:user.dat in TFT screen Device
        * Function:To convert the independent parameters to bytes arrays DataBuf according to the class SSR_User
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void SetSSRUserInfoToDat(out byte[] DataBuf, int PIN, int Privilege, string Password,
            string Name, int Card, int Group, string TimeZones, string PIN2)
        {
            DataBuf = new byte[72];
            byte[] PasswordBuf = new byte[8];
            byte[] NameBuf = new byte[24];
            byte[] CardBuf = new byte[4];
            byte[] TimeZonesBuf = new byte[8];
            byte[] PIN2Buf = new byte[24];

            SSR_User ssruser = new SSR_User();

            ssruser.PIN = (ushort)PIN;
            ssruser.Privilege = (byte)Privilege;

            PasswordBuf = System.Text.Encoding.Default.GetBytes(Password);
            Array.Copy(PasswordBuf, ssruser.Password, PasswordBuf.Length);

            NameBuf = System.Text.Encoding.Default.GetBytes(Name);
            Array.Copy(NameBuf, ssruser.Name, NameBuf.Length);

            CardBuf = BitConverter.GetBytes(Card);
            Array.Copy(CardBuf, ssruser.Card, CardBuf.Length);

            ssruser.Group = (byte)Group;

            TimeZonesBuf = System.Text.Encoding.Default.GetBytes(TimeZones);
            ssruser.TimeZones[0] = (ushort)TimeZonesBuf[0];//whether to use timezones or not (0 stands for yes,1 stands for defining by yourself)
            ssruser.TimeZones[1] = (ushort)TimeZonesBuf[1];//(if you use the timezones)timezoune1
            ssruser.TimeZones[2] = (ushort)TimeZonesBuf[2];//timezone2
            ssruser.TimeZones[3] = (ushort)TimeZonesBuf[3];//timezone3

            PIN2Buf = System.Text.Encoding.Default.GetBytes(PIN2);
            Array.Copy(PIN2Buf, ssruser.PIN2, PIN2Buf.Length);

            Array.Copy(Raw.RawSerialize(ssruser), DataBuf, 72);
        }

        /****************************************************************************************************************************
        * FunctionName:GetUserInfoFromDat
        * Parameters In:PDataBuf
        * Parameters Out:PIN,Privilege,Password,Name,Card,Group,TimeZones,PIN2
        * Return Value:void
        * Device Used:user.dat in Black&White screen Device
        * Function:To parse the bytes arrays from user.dat according to the class User and get out the independent parameters 
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void GetUserInfoFromDat(byte[] DataBuf, out int PIN, out int Privilege, out string Password,
           out string Name, out int Card, out int Group, out int TimeZones, out int PIN2)
        {
            byte[] PasswordBuf = new byte[5];
            byte[] NameBuf = new byte[8];

            User user = new User();
            user = (User)Raw.RawDeserialize(DataBuf, typeof(User));

            PIN = user.PIN;
            Privilege = user.Privilege;

            Array.Copy(DataBuf, 3, PasswordBuf, 0, 5);
            Password = System.Text.Encoding.Default.GetString(PasswordBuf);//"default" is to read the system's current ANSI code page encoding

            Array.Copy(DataBuf, 8, NameBuf, 0, 8);
            Name = System.Text.Encoding.Default.GetString(NameBuf);

            Card = 0;
            for (int i = 16; i <= 20; i++)
            {
                Card += Convert.ToInt32(DataBuf[i] * System.Math.Pow(16, 2 * (i - 16)));
            }

            Group = user.Group;
            TimeZones = user.TimeZones;
            PIN2 = Convert.ToInt32(user.PIN2);
        }

        /****************************************************************************************************************************
        * FunctionName:SetUserInfoToDat
        * Parameters In:PIN,Privilege,Password,Name,Card,Group,TimeZones,PIN2
        * Parameters Out:DataBuf
        * Return Value:void
        * Device Used:user.dat in Black&White screen Device
        * Function:To convert the independent parameters to bytes arrays DataBuf according to the class User
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void SetUserInfoToDat(out byte[] DataBuf, int PIN, int Privilege, string Password,
            string Name, int Card, int Group, int TimeZone, int PIN2)
        {
            DataBuf = new byte[28];
            byte[] PasswordBuf = new byte[5];
            byte[] NameBuf = new byte[8];
            byte[] CardBuf = new byte[5];

            User user = new User();

            user.PIN = (ushort)PIN;
            user.Privilege = (byte)Privilege;

            PasswordBuf = System.Text.Encoding.Default.GetBytes(Password);
            Array.Copy(PasswordBuf, user.Password, 5);

            NameBuf = System.Text.Encoding.Default.GetBytes(Name);
            Array.Copy(NameBuf, user.Name, 8);

            CardBuf = BitConverter.GetBytes(Card);
            Array.Copy(CardBuf, user.Card, 4);//Although we have defined 5 bytes to store the card number,but in fact 4bytes is enough(an integer data)

            user.Group = (byte)Group;

            TimeZone = user.TimeZones;

            user.PIN2 = (ushort)PIN2;

            Array.Copy(Raw.RawSerialize(user), 0, DataBuf, 0, 28);
        }

        /****************************************************************************************************************************
        * FunctionName:GetTemplateFromDat
        * Parameters In:DataBuf
        * Parameters Out:Size,PIN,FingerID,Valid,Template
        * Return Value:void
        * Device Used:template.dat in TFT screen devices using 9.0 arithmetic 
        * Function:To parse the bytes arrays from template.dat according to the class Template and get out the independent parameters
        * Explanation:To parse according to the max finger templage 602bytes
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void GetTemplateFromDat(byte[] DataBuf, out int Size, out int PIN, out int FingerID, out int Valid, out string Template)
        {
            byte[] TemplateBuf = new byte[602];

            Templates9 tmp = new Templates9();
            tmp = (Templates9)Raw.RawDeserialize(DataBuf, typeof(Templates9));

            Size = tmp.Size;
            PIN = tmp.PIN;
            FingerID = tmp.FingerID;
            Valid = tmp.Valid;

            Array.Copy(DataBuf, 6, TemplateBuf, 0, 602);
            Template = Convert.ToBase64String(TemplateBuf).Replace("-", "");// BitConverter.ToString(TemplateBuf).Replace("-", "");//Str to Hex
        }

        /****************************************************************************************************************************
        * FunctionName:SetTemplateToDat
        * Parameters In:Size,PIN,FingerID,Valid,Template
        * Parameters Out:DataBuf
        * Return Value:void
        * Device Used:template.dat in  TFT screen devices using 9.0 arithmetic
        * Function:To convert the independent parameters to bytes arrays DataBuf according to the class Template
        * Explanation:To write according to the max finger templage 602bytes
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void SetTemplateToDat(out byte[] DataBuf, int Size, int PIN, int FingerID, int Valid, string Template)
        {
            DataBuf = new byte[608];
            byte[] TemplateBuf = new byte[602];

            Templates9 tmp = new Templates9();

            tmp.Size = (ushort)Size;
            tmp.PIN = (ushort)PIN;
            tmp.FingerID = (byte)FingerID;
            tmp.Valid = (byte)Valid;

            Template = Template.Replace(" ", "");
            if (Template.Length <= 0)
            {
                Template = "";
            }
            byte[] TemplateBytes = new byte[Template.Length / 2];
            for (int i = 0; i < Template.Length; i += 2)
            {
                if (!byte.TryParse(Template.Substring(i, 2), NumberStyles.HexNumber, null, out TemplateBytes[i / 2]))
                {
                    TemplateBytes[i / 2] = 0;
                }
            }
            string TemplateFromHex = ASCIIEncoding.Default.GetString(TemplateBytes);
            TemplateBuf = System.Text.Encoding.Default.GetBytes(TemplateFromHex);

            Array.Copy(TemplateBuf, tmp.Template, TemplateFromHex.Length);

            Array.Copy(Raw.RawSerialize(tmp), DataBuf, 608);

        }

        /****************************************************************************************************************************
        * FunctionName:GetTmp10FromFp10
        * Parameters In:DataBuf
        * Parameters Out:Size,PIN,FingerID,Valid,Template
        * Return Value:void
        * Device Used:template.fp10.1 coming from devices using 10.0 arithmetic
        * Function:To parse the bytes arrays from template.fp10.1 according to the class Tmp10Header and get out the independent parameters
        * Explanation:the length of the finger templates is variable 
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void GetTmp10FromFp10(byte[] DataBuf, int Size, out int PIN, out int FingerID, out int Valid, out string Template)
        {
            byte[] TemplateBuf = new byte[Size - 16];

            PIN = DataBuf[2] + DataBuf[3] * 256;
            FingerID = DataBuf[4];
            Valid = DataBuf[5];
            Array.Copy(DataBuf, 6, TemplateBuf, 0, Size - 16);
            Template = Convert.ToBase64String(TemplateBuf).Replace("-", ""); // BitConverter.ToString(TemplateBuf).Replace("-", "");//Str to Hex
        }

        /****************************************************************************************************************************
        * FunctionName:SetTmp10ToFp10
        * Parameters In:Size,PIN,FingerID,Valid,Template
        * Parameters Out:DataBuf
        * Return Value:void
        * Device Used:template.fp10.1 coming from devices using 10.0 arithmetic
        * Function:To convert the independent parameters to bytes arrays DataBuf according to the class Template
        * Explanation:he length of the finger templates is variable 
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void SetTmp10ToFp10(out byte[] DataBuf, int Size, int PIN, int FingerID, int Valid, string Template)
        {
            DataBuf = new byte[Size];
            byte[] TemplateBuf = new byte[Size - 6];

            Tmp10Header tmp10 = new Tmp10Header();

            tmp10.Size = (ushort)Size;
            tmp10.PIN = (ushort)PIN;
            tmp10.FingerID = (byte)FingerID;
            tmp10.Valid = (byte)Valid;

            Array.Copy(Raw.RawSerialize(tmp10), DataBuf, 6);

            Template = Template.Replace(" ", "");
            if (Template.Length <= 0)
            {
                Template = "";
            }
            byte[] TemplateBytes = new byte[Template.Length / 2];
            for (int i = 0; i < Template.Length; i += 2)
            {
                if (!byte.TryParse(Template.Substring(i, 2), NumberStyles.HexNumber, null, out TemplateBytes[i / 2]))
                {
                    TemplateBytes[i / 2] = 0;
                }
            }
            string TemplateFromHex = ASCIIEncoding.Default.GetString(TemplateBytes);
            TemplateBuf = System.Text.Encoding.Default.GetBytes(TemplateFromHex);

            Array.Copy(TemplateBuf, 0, DataBuf, 6, TemplateFromHex.Length);

        }

        /****************************************************************************************************************************
        * FunctionName: GetFaceFromDat
        * Parameters In:DataBuf
        * Parameters Out: Size,PIN,FaceID,Valid,Reserve,ActiveTime,VfCount,Face
        * Return Value:void
        * Device Used:devices supporting faces registering
        * Function:To parse the bytes arrays from ssrface.dat according to the class FaceTmp and get out the independent parameters
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void GetFaceFromDat(byte[] DataBuf, out int Size, out int PIN, out int FaceID, out int Valid,
            out int Reserve, out int ActiveTime, out int VfCount, out string Face)
        {
            byte[] FaceBuf = new byte[2560];

            FaceTmp face = new FaceTmp();
            face = (FaceTmp)Raw.RawDeserialize(DataBuf, typeof(FaceTmp));

            Size = face.Size;
            PIN = face.PIN;
            FaceID = face.FaceID;
            Valid = face.Valid;
            Reserve = face.Reserve;
            ActiveTime = (int)face.ActiveTime;
            VfCount = (int)face.VfCount;

            Array.Copy(DataBuf, 16, FaceBuf, 0, 2560);
            Face =  Convert.ToBase64String(FaceBuf).Replace("-", "");//BitConverter.ToString(FaceBuf).Replace("-", "");//Str to Hex 
        }

        /****************************************************************************************************************************
        * FunctionName: SetFaceToDat
        * Parameters In:Size,PIN,FaceID,Valid,Reserve,ActiveTime,VfCount,Face
        * Parameters Out:DataBuf 
        * Return Value:void
        * Device Used:devices supporting faces registering
        * Function:To convert the independent parameters to bytes arrays DataBuf according to the class Template
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void SetFaceToDat(out byte[] DataBuf, int Size, int PIN, int FaceID, int Valid, int Reserve, int ActiveTime, int VfCount, string Face)
        {
            DataBuf = new byte[2576];
            byte[] FaceBuf = new byte[2560];

            FaceTmp face = new FaceTmp();

            face.Size = (ushort)Size;
            face.PIN = (ushort)PIN;
            face.FaceID = (byte)FaceID;
            face.Valid = (byte)Valid;
            face.Reserve = (ushort)Reserve;
            face.ActiveTime = (uint)ActiveTime;
            face.VfCount = (uint)VfCount;

            Face = Face.Replace(" ", "");
            if (Face.Length <= 0)
            {
                Face = "";
            }

            //byte[] FaceBytes = new byte[Face.Length / 2];
            //for (int i = 0; i < Face.Length; i += 2)
            //{
            //    if (!byte.TryParse(Face.Substring(i, 2), NumberStyles.HexNumber, null, out FaceBytes[i / 2]))
            //    {
            //        FaceBytes[i / 2] = 0;
            //    }
            //}
            //string FaceFromHex = ASCIIEncoding.Default.GetString(FaceBytes);
            //FaceBuf = System.Text.Encoding.Default.GetBytes(FaceFromHex);
            FaceBuf = Convert.FromBase64String(Face);

            Array.Copy(FaceBuf, face.Face, FaceBuf.Length);

            Array.Copy(Raw.RawSerialize(face), DataBuf, 2576);
        }

        /****************************************************************************************************************************
        * FunctionName:GetAttLogFromDat
        * Parameters In:DataBuf,OneLogLength
        * Parameters Out:PIN2,Time_second,DeviceID,Status,Verified,Workcode
        * Return Value:void
        * Device Used:(For TFT screen devices).i_attlog.dat(i is the Device ID)
        * Function:To parse the attendence logs byte arrays to independent parameters
        * Explanation:The SerialNumber(SN) and the CheckSum are not dealed with by this function.
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void GetAttLogFromDat(byte[] DataBuf, int OneLogLength, out string PIN2, out string Time_second, out string DeviceID,
            out string Status, out string Verified, out string Workcode)
        {
            int i;
            int Index = 0;

            PIN2 = "";
            Time_second = "";
            DeviceID = "";
            Status = "";
            Verified = "";
            Workcode = "";

            for (i = Index; i < OneLogLength; i++)
            {
                if (DataBuf[i] == 9)//Ascii code 9 stands for the tab key on your keyboard.
                {
                    byte[] PIN2Buf = new byte[i];
                    Array.Copy(DataBuf, 0, PIN2Buf, 0, i);
                    PIN2 = System.Text.Encoding.Default.GetString(PIN2Buf);
                    Index = i;
                    break;
                }
            }

            for (i = Index + 1; i < OneLogLength; i++)
            {
                if (DataBuf[i] == 9)//the second tab key
                {
                    byte[] TimeBuf = new byte[i - Index - 1];
                    Array.Copy(DataBuf, Index + 1, TimeBuf, 0, i - Index - 1);
                    Time_second = System.Text.Encoding.Default.GetString(TimeBuf);
                    Index = i;
                    break;
                }
            }

            for (i = Index + 1; i < OneLogLength; i++)
            {
                if (DataBuf[i] == 9)//the third tab key
                {
                    byte[] DeviceIDBuf = new byte[i - Index - 1];
                    Array.Copy(DataBuf, Index + 1, DeviceIDBuf, 0, i - Index - 1);
                    DeviceID = System.Text.Encoding.Default.GetString(DeviceIDBuf);
                    Index = i;
                    break;
                }
            }

            for (i = Index + 1; i < OneLogLength; i++)
            {
                if (DataBuf[i] == 9)//the fourth tab key
                {
                    byte[] StatusBuf = new byte[i - Index - 1];
                    Array.Copy(DataBuf, Index + 1, StatusBuf, 0, i - Index - 1);
                    Status = System.Text.Encoding.Default.GetString(StatusBuf);
                    Index = i;
                    break;
                }
            }

            for (i = Index + 1; i < OneLogLength; i++)
            {
                if (DataBuf[i] == 9)//the fifth tab key
                {
                    byte[] VerifiedBuf = new byte[i - Index - 1];
                    Array.Copy(DataBuf, Index + 1, VerifiedBuf, 0, i - Index - 1);
                    Verified = System.Text.Encoding.Default.GetString(VerifiedBuf);
                    Index = i;
                    break;
                }
            }

            for (i = Index + 1; i < OneLogLength; i++)
            {
                if (DataBuf[i] == 13)//the sixth tab key
                {
                    byte[] WorkcodeBuf = new byte[i - Index - 1];
                    Array.Copy(DataBuf, Index + 1, WorkcodeBuf, 0, i - Index - 1);
                    Workcode = System.Text.Encoding.Default.GetString(WorkcodeBuf);
                    break;

                }
            }
        }

        /****************************************************************************************************************************
        * FunctionName:SetAttLogToDat
        * Parameters In:PIN2,Time_second,DeviceID,Status,Verified,Workcode
        * Parameters Out:DataBuf OneLogLength
        * Return Value:void
        * Device Used:For TFT screen devices.i_attlog.dat(i is the Device ID)
        * Function:To convet the loacal strings  to its Ascii codes and write to the array bytes
        * Explanation:It is mainly the transaction between strings and its Ascii codes
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void SetAttLogToDat(out byte[] DataBuf, out int OneLogLength, string PIN2, string Time_second, string DeviceID,
            string Status, string Verified, string Workcode)
        {
            string AttLogExt = PIN2 + "\t" + Time_second + "\t" + DeviceID + "\t" + Status + "\t" + Verified + "\t" + Workcode + "\r\n";
            DataBuf = System.Text.Encoding.Default.GetBytes(AttLogExt);
            OneLogLength = AttLogExt.Length;
        }

        /****************************************************************************************************************************
        * FunctionName:GetSSRSMSFromDat
        * Parameters In:DataBuf
        * Parameters Out:Tag,ID,ValidMinutes,Reserved,StartTime,Content
        * Return Value:void
        * Device Used:Just for Black&White screen devices.sms.dat
        * Function:To parse the short messages byte array to independent parameters
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void GetSSRSMSFromDat(byte[] DataBuf, out int Tag, out int ID, out int ValidMinutes, out int Reserved,
            out string StartTime, out string Content)
        {
            byte[] ContentBuf = new byte[UDisk.MAX_SSR_SMS_CONTENT_SIZE + 1];

            SSR_SMS sms = new SSR_SMS();
            sms = (SSR_SMS)Raw.RawDeserialize(DataBuf, typeof(SSR_SMS));

            Tag = sms.Tag;
            ID = sms.ID;
            ValidMinutes = sms.ValidMinutes;
            Reserved = sms.Reserved;

            //decode time from uint value type to string value type
            int Time = (int)sms.StartTime;
            int Year, Month, Day, Hour, Minute, Second;
            Second = Time % 60;
            Time /= 60;
            Minute = Time % 60;
            Time /= 60;
            Hour = Time % 24;
            Time /= 24;
            Day = Time % 31 + 1;
            Time /= 31;
            Month = Time % 12 + 1;
            Time /= 12;
            Year = Time + 2000;
            DateTime dt;
            try
            {
                dt = new DateTime((int)Year, (int)Month, (int)Day, (int)Hour, (int)Minute, (int)Second);
            }
            catch 
            {
                dt = new DateTime(1970, 1, 1, 1, 1, 1);
            }
            StartTime = dt.ToString();

            Array.Copy(DataBuf, 11, ContentBuf, 0, UDisk.MAX_SSR_SMS_CONTENT_SIZE + 1);

            Content = System.Text.Encoding.Default.GetString(ContentBuf);
        }

        /****************************************************************************************************************************
        * FunctionName:GetSMSFromDat
        * Parameters In:DataBuf
        * Parameters Out:Tag,ID,ValidMinutes,Reserved,StartTime,Content
        * Return Value:void
        * Device Used:Just for Black&White screen devices.sms.dat
        * Function:To parse the short messages byte array to independent parameters
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void GetSMSFromDat(byte[] DataBuf, out int Tag, out int ID, out int ValidMinutes, out int Reserved,
            out string StartTime, out string Content)
        {
            byte[] ContentBuf = new byte[UDisk.MAX_SMS_CONTENT_SIZE + 1];

            SMS sms = new SMS();
            sms = (SMS)Raw.RawDeserialize(DataBuf, typeof(SMS));

            Tag = sms.Tag;
            ID = sms.ID;
            ValidMinutes = sms.ValidMinutes;
            Reserved = sms.Reserved;

            //decode time from uint value type to string value type
            int Time = (int)sms.StartTime;
            int Year, Month, Day, Hour, Minute, Second;
            Second = Time % 60;
            Time /= 60;
            Minute = Time % 60;
            Time /= 60;
            Hour = Time % 24;
            Time /= 24;
            Day = Time % 31 + 1;
            Time /= 31;
            Month = Time % 12 + 1;
            Time /= 12;
            Year = Time + 2000;
            DateTime dt;
            try
            {
                dt = new DateTime((int)Year, (int)Month, (int)Day, (int)Hour, (int)Minute, (int)Second);
            }
            catch
            {
                dt = new DateTime(1970, 1, 1, 1, 1, 1);
            }
            StartTime = dt.ToString();

            Array.Copy(DataBuf, 11, ContentBuf, 0, UDisk.MAX_SMS_CONTENT_SIZE + 1);

            Content = System.Text.Encoding.Default.GetString(ContentBuf);
        }

        /****************************************************************************************************************************
        * FunctionName:SetSSRSMSToDat
        * Parameters In:Tag,ID,ValidMinutes,Reserved,StartTime,Content
        * Parameters Out:DataBuf
        * Return Value:void
        * Device Used:Just for Black&White screen devices.sms.dat
        * Function:To convert the parameters to the byte array stored short messages
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void SetSSRSMSToDat(out byte[] DataBuf, int Tag, int ID, int ValidMinutes, int Reserved, string StartTime, string Content)
        {
            DataBuf = new byte[72];
            byte[] ContentBuf = new byte[UDisk.MAX_SSR_SMS_CONTENT_SIZE + 1];
            byte[] TempBuf = null;

            SSR_SMS sms = new SSR_SMS();

            sms.Tag = (byte)Tag;
            sms.ID = (ushort)ID;
            sms.ValidMinutes = (ushort)ValidMinutes;
            sms.Reserved = (ushort)Reserved;

            //Encode time from string value type to unit value type
            DateTime dt = new DateTime();
            dt = Convert.ToDateTime(StartTime);
            int Time = ((dt.Year % 100) * 12 * 31 + ((dt.Month - 1) * 31) + dt.Day - 1) * (24 * 60 * 60) + (dt.Hour * 60 + dt.Minute) * 60 + dt.Second;
            sms.StartTime = (uint)Time;

            TempBuf = System.Text.Encoding.Default.GetBytes(Content);
            Array.Copy(TempBuf, sms.Content, TempBuf.Length);

            Array.Copy(Raw.RawSerialize(sms), DataBuf, Marshal.SizeOf(sms));
        }

        /****************************************************************************************************************************
        * FunctionName:SetSMSToDat
        * Parameters In:Tag,ID,ValidMinutes,Reserved,StartTime,Content
        * Parameters Out:DataBuf
        * Return Value:void
        * Device Used:Just for Black&White screen devices.sms.dat
        * Function:To convert the parameters to the byte array stored short messages
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void SetSMSToDat(out byte[] DataBuf, int Tag, int ID, int ValidMinutes, int Reserved, string StartTime, string Content)
        {
            DataBuf = new byte[72];
            byte[] ContentBuf = new byte[UDisk.MAX_SMS_CONTENT_SIZE + 1];
            byte[] TempBuf = null;

            SMS sms = new SMS();

            sms.Tag = (byte)Tag;
            sms.ID = (ushort)ID;
            sms.ValidMinutes = (ushort)ValidMinutes;
            sms.Reserved = (ushort)Reserved;

            //Encode time from string value type to unit value type
            DateTime dt = new DateTime();
            dt = Convert.ToDateTime(StartTime);
            int Time = ((dt.Year % 100) * 12 * 31 + ((dt.Month - 1) * 31) + dt.Day - 1) * (24 * 60 * 60) + (dt.Hour * 60 + dt.Minute) * 60 + dt.Second;
            sms.StartTime = (uint)Time;

            TempBuf = System.Text.Encoding.Default.GetBytes(Content);
            Array.Copy(TempBuf, sms.Content, TempBuf.Length);

            Array.Copy(Raw.RawSerialize(sms), DataBuf, Marshal.SizeOf(sms));
        }

        /****************************************************************************************************************************
        * FunctionName:GetUDataFromDat
        * Parameters In:DataBuf
        * Parameters Out:PIN,SmsID
        * Return Value:void
        * Device Used:For Black&White screen devices.udata.dat
        * Function:To parse the attendence logs byte arrays to independent parameters
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void GetUDataFromDat(byte[] DataBuf, out int PIN, out int SmsID)
        {

            UData udata = new UData();
            udata = (UData)Raw.RawDeserialize(DataBuf, typeof(UData));

            PIN = udata.PIN;
            SmsID = udata.SmsID;
        }

        /****************************************************************************************************************************
        * FunctionName:SetUDataToDat
        * Parameters In:PIN,SmsID
        * Parameters Out:DataBuf
        * Return Value:void
        * Device Used:For Black&White screen devices. udata.dat
        * Function:To convert imported parameters to the byte array 
        * Auther:Darcy
        * Date:Oct.23, 2009
        *****************************************************************************************************************************/
        public void SetUDataToDat(out byte[] DataBuf, int PIN, int SmsID)
        {
            DataBuf = new byte[4];

            UData udata = new UData();

            udata.PIN = (ushort)PIN;
            udata.SmsID = (ushort)SmsID;
            Array.Copy(Raw.RawSerialize(udata), DataBuf, 4);
        }
        //写入U盘文本文档
        delegate bool TemplateInfo2Bytes(List<TemplateInfo> list_TI, out byte[] bytes);
        TemplateInfo2Bytes ti2b;
        public void ExportUserInfo(bool isTFT, bool isAlgorithm10, string uDiskDriver, List<UserInfo> list_Users, List<TemplateInfo> list_Templ)
        {
            List<UserInfo> listui = new List<UserInfo>();
            List<TemplateInfo> listti = new List<TemplateInfo>();
            //提示信息字符串
            string usertmp = string.Empty;
            StringBuilder sb = new StringBuilder();
            string userNo = string.Empty;

            #region "写用户信息文件"
            listui = list_Users;

            //写文件到U盘
            byte[] bytes;
            try
            {
                int kindA = 0;
                if (isTFT)
                {
                    kindA = 72;
                }
                else
                {
                    kindA = 28;
                }
                UserInfoToByteArray(listui, out bytes, kindA);

                if (WriteFile(bytes, uDiskDriver + "user.dat"))
                {
                    //MessageBox.show("");
                }
                // else
                //usertmp = ExportUserInfoFailed;
            }
            catch
            {
                //usertmp = ExportUserInfoFailed;
            }
            sb.AppendLine(usertmp + "\n");
            #endregion

            //转换指纹模板到列表
            // List<Template> list_temps = tempBLL.GetTempByEmplst(list_Users);
            // List<Template> fingerprints = list_temps.FindAll(a => a.template_type == 9 || a.template_type == 10);
            // List<Template> faces = list_temps.FindAll(a => a.template_type == CommonString.FACE_TEMPLATETYPE.ToInt());

            #region "写指纹模板文件"
            // if (fingerprints.Count > 0)
            {
                string template_type = string.Empty;
                string file_name = string.Empty;
                if (isAlgorithm10)
                {
                    ti2b = Template10InfoToByteArray;
                    template_type = "10";
                    file_name = "template.fp10.1";
                }
                else
                {
                    ti2b = TemplateInfoToByteArray;
                    template_type = "9";
                    file_name = "template.dat";
                }

                listti = list_Templ;
                //写指纹模板文件到U盘
                byte[] bytes1;
                try
                {
                    ti2b(listti, out bytes1);
                    if (WriteFile(bytes1, uDiskDriver + file_name))
                    {
                        // usertmp = string.Format(ExportFPsInfoSuccess, fingerprints.Count);
                    }
                    // else
                    {
                        //   usertmp = ExportFPsInfoFailed;
                    }
                }
                catch
                {
                    // usertmp = ExportFPsInfoFailed;
                }

                sb.AppendLine(usertmp + "\n");
            }
            #endregion

            #region "写面部模板文件"
            // if (faces.Count > 0)
            {
                //int iCount = faces.Count;
                //byte[] byFaceInfo = new byte[2576 * 12];

                //byte[] bytes2 = new byte[iCount * 2576 * 12];
                //int iDataBufIndex = 0;
                //foreach (Template face in faces)
                {
                    //string sFace = face.template_str;
                    // byFaceInfo = Convert.FromBase64String(sFace);

                    //Array.Copy(byFaceInfo, 0, bytes2, iDataBufIndex, 2576 * 12);
                    // iDataBufIndex += 2576 * 12;
                }
                //if (WriteFile(bytes2, uDiskDriver + CommonString.FaceFileName))
                {
                    //usertmp = string.Format(ExportFaceInfoSuccess, faces.Count);
                }
                //else
                {
                    // usertmp = ExportFaceInfoFailed;
                }
                //sb.AppendLine(usertmp);
            }
            #endregion

            //XtraMessageBoxHelper.Information(sb.ToString());
        }
        private bool UserInfoToByteArray(List<UserInfo> listUi, out byte[] bytes, int kind)
        {
            bool ret = false;
            //根据用户个数决定分配多大的字节数据
            int byteCount = kind * listUi.Count;
            byte[] bts = new byte[byteCount];
            if (listUi.Count <= 0)
            {
                ret = false;
            }
            else
            {
                int count = kind;

                if (kind == 28)
                {
                    try
                    {
                        #region "黑白屏用户信息的转换"
                        for (int i = 0; i < listUi.Count; i++)
                        {
                            switch (listUi[i].privilege)
                            {
                                case 0:
                                    listUi[i].privilege = 0;
                                    break;
                                case 1:
                                    listUi[i].privilege = 2;
                                    break;
                                case 2:
                                    listUi[i].privilege = 6;
                                    break;
                                case 3:
                                    listUi[i].privilege = 14;
                                    break;
                                default:
                                    listUi[i].privilege = 0;
                                    break;
                            }

                            count = kind * i;
                            //Pin1
                            bts[count + 0] = (byte)((Convert.ToUInt16(listUi[i].Pin2)) >> 0);
                            bts[count + 1] = (byte)((Convert.ToUInt16(listUi[i].Pin2)) >> 8);
                            //权限
                            bts[count + 2] = (byte)((listUi[i].privilege) >> 0);
                            //密码
                            char[] pwdChr = new char[5];
                            if (listUi[i].userPwd == null)
                            {
                                listUi[i].userPwd = string.Empty;
                            }
                            char[] pwdTemp = listUi[i].userPwd.ToCharArray();
                            int temp1 = pwdTemp.Length;
                            if (temp1 > 5) temp1 = 5;
                            for (int k = 0; k < temp1; k++)
                            {
                                bts[count + k + 3] = Convert.ToByte(pwdTemp[k]);
                            }
                            //姓名
                            //char[] name = new char[8];
                            //char[] nameTemp = listUi[i].Name.ToCharArray();
                            byte[] nameByte = System.Text.UTF8Encoding.Default.GetBytes(listUi[i].userName.ToCharArray());
                            int j = nameByte.Length;
                            if (j > 8) j = 8;
                            for (int k = 0; k < j; k++)
                            {
                                bts[count + k + 8] = Convert.ToByte(nameByte[k]);
                            }
                            //卡号                    
                            bts[count + 16] = (byte)((Convert.ToUInt32(listUi[i].cardNo)) >> 0);
                            bts[count + 17] = (byte)((Convert.ToUInt32(listUi[i].cardNo)) >> 8);
                            bts[count + 18] = (byte)((Convert.ToUInt32(listUi[i].cardNo)) >> 16);
                            bts[count + 19] = (byte)((Convert.ToUInt32(listUi[i].cardNo)) >> 24);
                            bts[count + 20] = 0;
                            //Group
                            bts[count + 21] = (byte)((Convert.ToUInt32(listUi[i].Group)) >> 0);
                            //TimeZone
                            bts[count + 22] = (byte)((Convert.ToUInt16(listUi[i].timeZones)) >> 0);
                            bts[count + 23] = (byte)((Convert.ToUInt16(listUi[i].timeZones)) >> 8);
                            //Pin2
                            bts[count + 24] = (byte)((Convert.ToUInt32(listUi[i].userNo)) >> 0);
                            bts[count + 25] = (byte)((Convert.ToUInt32(listUi[i].userNo)) >> 8);
                            bts[count + 26] = (byte)((Convert.ToUInt32(listUi[i].userNo)) >> 16);
                            bts[count + 27] = (byte)((Convert.ToUInt32(listUi[i].userNo)) >> 24);
                        }
                        #endregion
                        ret = true;
                    }
                    catch (Exception ex)
                    {
                        //Log.LogHelper.Error(ex.Message);
                        ret = false;
                    }
                }
                else
                {
                    try
                    {
                        #region "彩屏用户信息的转换"
                        for (int i = 0; i < listUi.Count; i++)
                        {
                            switch (listUi[i].privilege)
                            {
                                case 0:
                                    listUi[i].privilege = 0;
                                    break;
                                case 1:
                                    listUi[i].privilege = 2;
                                    break;
                                case 2:
                                    listUi[i].privilege = 6;
                                    break;
                                case 3:
                                    listUi[i].privilege = 14;
                                    break;
                                case 4:
                                    listUi[i].privilege = 10;
                                    break;
                                case 5:
                                    listUi[i].privilege = 1;
                                    break;
                                default:
                                    listUi[i].privilege = 0;
                                    break;
                            }

                            count = kind * i;
                            //Pin1
                            bts[count + 0] = (byte)((Convert.ToUInt16(listUi[i].userNo)) >> 0);
                            bts[count + 1] = (byte)((Convert.ToUInt16(listUi[i].userNo)) >> 8);
                            //权限
                            bts[count + 2] = (byte)((listUi[i].privilege) >> 0);
                            //bts[count + 2] = (byte)((Convert.ToUInt32(listUi[i].privilege)) >> 0);
                            //密码
                            char[] pwdChr = new char[8];
                            if (listUi[i].userPwd == null)
                            {
                                listUi[i].userPwd = string.Empty;
                            }
                            char[] pwdTemp = listUi[i].userPwd.ToCharArray();
                            int temp1 = pwdTemp.Length;
                            if (temp1 > 8) temp1 = 8;
                            for (int k = 0; k < temp1; k++)
                            {
                                bts[count + k + 3] = Convert.ToByte(pwdTemp[k]);
                            }
                            //姓名
                            //char[] name = new char[24];
                            //char[] nameTemp = listUi[i].Name.ToCharArray();
                            byte[] nameByte = System.Text.UTF8Encoding.Default.GetBytes(listUi[i].userName.ToCharArray());
                            int j = nameByte.Length;
                            if (j > 24) j = 24;
                            for (int k = 0; k < j; k++)
                            {
                                bts[count + k + 11] = Convert.ToByte(nameByte[k]);
                            }
                            //卡号                    
                            bts[count + 35] = (byte)((Convert.ToUInt32(listUi[i].cardNo)) >> 0);
                            bts[count + 36] = (byte)((Convert.ToUInt32(listUi[i].cardNo)) >> 8);
                            bts[count + 37] = (byte)((Convert.ToUInt32(listUi[i].cardNo)) >> 16);
                            bts[count + 38] = (byte)((Convert.ToUInt32(listUi[i].cardNo)) >> 24);
                            //bts[count + 39] = 0;
                            //Group
                            bts[count + 39] = (byte)((Convert.ToUInt32(listUi[i].Group)) >> 0);
                            //TimeZone
                            bts[count + 40] = (byte)((Convert.ToUInt64(listUi[i].timeZones[0])) >> 0);
                            bts[count + 41] = (byte)((Convert.ToUInt64(listUi[i].timeZones[0])) >> 8);
                            bts[count + 42] = (byte)((Convert.ToUInt64(listUi[i].timeZones[1])) >> 0);
                            bts[count + 43] = (byte)((Convert.ToUInt64(listUi[i].timeZones[1])) >> 8);
                            bts[count + 44] = (byte)((Convert.ToUInt64(listUi[i].timeZones[2])) >> 0);
                            bts[count + 45] = (byte)((Convert.ToUInt64(listUi[i].timeZones[2])) >> 8);
                            bts[count + 46] = (byte)((Convert.ToUInt64(listUi[i].timeZones[3])) >> 0);
                            bts[count + 47] = (byte)((Convert.ToUInt64(listUi[i].timeZones[3])) >> 8);

                            //Pin2
                            //char[] pin2Chrs = new char[8];
                            char[] pin2Chrs = listUi[i].Pin2.ToCharArray();
                            int h = pin2Chrs.Length;
                            if (h > 24) h = 24;
                            for (int k = 0; k < h; k++)
                            {
                                bts[count + k + 48] = Convert.ToByte(pin2Chrs[k]);
                            }
                            //bts[count + 48] = (byte)((Convert.ToUInt32(listUi[i].Pin2)) >> 0);
                            //bts[count + 49] = (byte)((Convert.ToUInt32(listUi[i].Pin2)) >> 8);
                            //bts[count + 50] = (byte)((Convert.ToUInt32(listUi[i].Pin2)) >> 16);
                            //bts[count + 51] = (byte)((Convert.ToUInt32(listUi[i].Pin2)) >> 24);
                        }
                        #endregion
                        ret = true;
                    }
                    catch (Exception ex)
                    {
                        //Log.LogHelper.Error(ex.Message);
                        ret = false;
                    }
                }
            }
            bytes = bts;
            return ret;
        }
        
        private bool WriteFile(byte[] bs, string filename)
        {
            try
            {
                FileInfo fi = new FileInfo(filename);
                if (fi.Exists)
                    fi.Delete();
                FileStream fs = fi.OpenWrite();

                fs.Write(bs, 0, bs.Length);
                fs.Flush();
                fs.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 将用户的指纹模板10.0转换为字节数组
        /// </summary>
        /// <param name="listTi">包含多个指纹信息</param>
        /// <param name="bytes">字节数组</param>
        /// <returns>成功转换为真，否则为假</returns>
        private bool Template10InfoToByteArray(List<TemplateInfo> listTi, out byte[] bytes)
        {
            bool ret = false;
            //int lengths = 608;
            int bytecount = 0;
            for (int tt = 0; tt < listTi.Count; tt++)
            {
                bytecount += listTi[tt].Size;
            }
            byte[] bts = new byte[bytecount];
            int count = 0;

            if (listTi.Count <= 0)
                ret = false;
            else
            {
                #region "指纹模板转换为字节数组"
                try
                {
                    for (int i = 0; i < listTi.Count; i++)
                    {
                        bts[count] = (byte)((Convert.ToUInt16(listTi[i].Size)) >> 0);
                        bts[count + 1] = (byte)((Convert.ToUInt16(listTi[i].Size)) >> 8);
                        bts[count + 2] = (byte)((Convert.ToUInt16(listTi[i].Pin)) >> 0);
                        bts[count + 3] = (byte)((Convert.ToUInt16(listTi[i].Pin)) >> 8);
                        bts[count + 4] = (byte)(listTi[i].fingerID >> 0);
                        bts[count + 5] = (byte)(listTi[i].Valid >> 0);

                        byte[] tempB = Convert.FromBase64String(listTi[i].TemplateStr);
                        int j = tempB.Length;
                        if (tempB.Length > listTi[i].Size) j = listTi[i].Size;
                        Array.Copy(tempB, 0, bts, count + 6, j);
                        count += listTi[i].Size;
                    }
                    ret = true;
                }
                catch
                {
                    ret = false;
                }
                #endregion
            }
            bytes = bts;
            return ret;
        }

        /// <summary>
        /// 将用户的指纹模板信息转换为字节数组
        /// </summary>
        /// <param name="listTi">包含多个指纹信息</param>
        /// <param name="bytes">字节数组</param>
        /// <returns>成功转换为真，否则为假</returns>
        private bool TemplateInfoToByteArray(List<TemplateInfo> listTi, out byte[] bytes)
        {
            bool ret = false;
            int lengths = 608;
            int bytecount = lengths * listTi.Count;
            int count = 0;
            byte[] bts = new byte[bytecount];
            if (listTi.Count <= 0)
                ret = false;
            else
            {
                #region "指纹模板转换为字节数组"
                try
                {
                    for (int i = 0; i < listTi.Count; i++)
                    {
                        count = lengths * i;
                        bts[count] = (byte)((Convert.ToUInt16(listTi[i].Size)) >> 0);
                        bts[count + 1] = (byte)((Convert.ToUInt16(listTi[i].Size)) >> 8);
                        bts[count + 2] = (byte)((Convert.ToUInt16(listTi[i].Pin)) >> 0);
                        bts[count + 3] = (byte)((Convert.ToUInt16(listTi[i].Pin)) >> 8);
                        bts[count + 4] = (byte)(listTi[i].fingerID >> 0);
                        bts[count + 5] = (byte)(listTi[i].Valid >> 0);

                        byte[] tempB = Convert.FromBase64String(listTi[i].TemplateStr);
                        int j = tempB.Length;
                        if (tempB.Length > 602) j = 602;
                        for (int k = 0; k < j; k++)
                        {
                            bts[count + k + 6] = tempB[k];
                        }
                    }
                    ret = true;
                }
                catch
                {
                    ret = false;
                }
                #endregion
            }
            bytes = bts;
            return ret;
        }
       
    }
}
