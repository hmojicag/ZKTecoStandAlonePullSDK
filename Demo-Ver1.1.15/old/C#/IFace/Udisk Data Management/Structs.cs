using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;//structlayout,marshalas
using System.Globalization;//NumberStyles
using System.Windows.Forms;//Messagebox


namespace UdiskData
{
    //The data is stored in the little endian strorage mode and in accordance with a byte-aligned

    //User information of TFT screen device(Fixed-length data format-72 bytes in all)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class SSR_User
    {
        public ushort PIN;
        public byte Privilege;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Password = new byte[8];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] Name = new byte[24];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Card = new byte[4];
        public byte Group;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] TimeZones = new ushort[4];//the timezones that the user can use
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] PIN2 = new byte[24];
    }

    //fingerprint templates information of 9.0 arithmetic(Fixed-length data format-608 bytes in all)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class Templates9
    {
        public ushort Size;
        public ushort PIN;
        public byte FingerID;
        public byte Valid;
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=602)]
        public byte[] Template=new byte[602];//the max value is 602 bytes 
     }

    //fingerprint templates information of 10.0 arithmetic(Variable-length data format)
    //The max length of one template is 16 kb, that is, one template's length is less than 16kb.
    //The following is the fixed-length part of the data struct which is 6 bytes long.
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class Tmp10Header
    {
        public ushort Size;
        public ushort PIN;
        public byte FingerID;
        public byte Valid;
    }

    //the face templates information of IFace series(Fixed-length data format-2576 bytes in all)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class FaceTmp
    {
        public ushort Size;//face template size
        public ushort PIN;//user ID
        public byte FaceID;//Face ID
        public byte Valid;//flag
        public ushort Reserve;//reserve
        public uint ActiveTime;
        public uint VfCount;//Verify Count
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024 * 2 + 512)]//FACE_TMP_MAXSIZE=1024*2+512
        public byte[] Face = new byte[1024 * 2 + 512];//2560-the max template length
    }

    //the short message struct of TFT screen devices(Fixed-length data format-332 bytes in all)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class SSR_SMS
    {
        public byte Tag;//type of short message
        public ushort ID;//the tag of the data,zero means that the log is invalid.
        public ushort ValidMinutes;// zero stands for forever
        public ushort Reserved;
        public uint StartTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = UDisk.MAX_SSR_SMS_CONTENT_SIZE * 2 + 1)]
        public byte[] Content = new byte[UDisk.MAX_SSR_SMS_CONTENT_SIZE * 2 + 1];//the content of the short message
    }

    //the struct showing the relation between the user id and its short message
    //For TFT screen devices-Fixed-length data format-4 bytes in all
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class UData
    {
        public ushort PIN;//0 stands for invalid log
        public ushort SmsID;
    }


   

    class UDisk
    {
        public const int MAX_SSR_SMS_CONTENT_SIZE = 160;//the max length of short message in the TFT screen devices

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
           out string Name, out int Card, out int Group, out string TimeZone, out string PIN2)
        {
            byte[] PasswordBuf = new byte[8];
            byte[] NameBuf = new byte[24];
            byte[] TimeZoneBuf = new byte[8];
            byte[] PIN2Buf = new byte[24];
            SSR_User ssruser = new SSR_User();
            ssruser = (SSR_User)Raw.RawDeserialize(DataBuf, typeof(SSR_User));
            PIN = ssruser.PIN;
            Privilege = ssruser.Privilege;
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

            Array.Copy(DataBuf, 40, TimeZoneBuf, 0, 8);
            TimeZone = System.Text.Encoding.Default.GetString(TimeZoneBuf);

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
            Array.Copy(PasswordBuf, ssruser.Password, 8);

            NameBuf = System.Text.Encoding.Default.GetBytes(Name);
            Array.Copy(NameBuf, ssruser.Name, 24);

            CardBuf = BitConverter.GetBytes(Card);
            Array.Copy(CardBuf, ssruser.Card, 4);

            ssruser.Group = (byte)Group;

            TimeZonesBuf = System.Text.Encoding.Default.GetBytes(TimeZones);
            ssruser.TimeZones[0] = (ushort)TimeZonesBuf[0];//whether to use timezones or not (0 stands for yes,1 stands for defining by yourself)
            ssruser.TimeZones[1] = (ushort)TimeZonesBuf[1];//(if you use the timezones)timezoune1
            ssruser.TimeZones[2] = (ushort)TimeZonesBuf[2];//timezone2
            ssruser.TimeZones[3] = (ushort)TimeZonesBuf[3];//timezone3

            PIN2Buf = System.Text.Encoding.Default.GetBytes(PIN2);
            Array.Copy(PIN2Buf, ssruser.PIN2, 24);

            Array.Copy(Raw.RawSerialize(ssruser), DataBuf,72);
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
            Template = BitConverter.ToString(TemplateBuf).Replace("-", "");//Str to Hex
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
        public void SetTemplateToDat(out byte[] DataBuf,int Size, int PIN, int FingerID, int Valid, string Template)
        {
            DataBuf=new byte[608];
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
            string TemplateFromHex=ASCIIEncoding.Default.GetString(TemplateBytes);
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
            Template = BitConverter.ToString(TemplateBuf).Replace("-", "");//Str to Hex
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
            byte[] TemplateBuf = new byte[Size-6];

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

            Array.Copy(TemplateBuf,0,DataBuf,6, TemplateFromHex.Length);

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
            VfCount =(int) face.VfCount;

            Array.Copy(DataBuf, 16, FaceBuf, 0, 2560);
            Face = BitConverter.ToString(FaceBuf).Replace("-", "");//Str to Hex
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
            face.Reserve =(ushort) Reserve;
            face.ActiveTime = (uint)ActiveTime;
            face.VfCount =(uint) VfCount;

            Face = Face.Replace(" ", "");
            if (Face.Length <= 0)
            {
                Face = "";
            }
            byte[] FaceBytes = new byte[Face.Length / 2];
            for (int i = 0; i < Face.Length; i += 2)
            {
                if (!byte.TryParse(Face.Substring(i, 2), NumberStyles.HexNumber, null, out FaceBytes[i / 2]))
                {
                    FaceBytes[i / 2] = 0;
                }
            }
            string FaceFromHex = ASCIIEncoding.Default.GetString(FaceBytes);
            FaceBuf = System.Text.Encoding.Default.GetBytes(FaceFromHex);

            Array.Copy(FaceBuf, face.Face, FaceFromHex.Length);

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

            for (i = Index+1; i < OneLogLength; i++)
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

            for (i = Index+1; i < OneLogLength; i++)
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
                if ( DataBuf[i] == 13)//the sixth tab key
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
        public void SetAttLogToDat(out byte[] DataBuf,out int OneLogLength , string PIN2, string Time_second, string DeviceID,
            string Status, string Verified, string Workcode)
        {
            string AttLogExt = PIN2 + "\t" + Time_second + "\t" + DeviceID + "\t" + Status + "\t" + Verified + "\t" + Workcode + "\r\n";
            DataBuf = System.Text.Encoding.Default.GetBytes(AttLogExt);
            OneLogLength = AttLogExt.Length;
        }
    }
}
