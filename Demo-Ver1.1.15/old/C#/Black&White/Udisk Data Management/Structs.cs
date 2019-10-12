using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;//structlayout,marshalas
using System.Globalization;//NumberStyles
using System.Windows.Forms;//Messagebox


namespace UdiskData
{
    //The data is stored in the little endian strorage mode and in accordance with a byte-aligned

    //User information of Black&White screen device(Fixed-length data format-28 bytes in all)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class User
    {
        public ushort PIN;
        public byte Privilege;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] Password = new byte[5];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Name = new byte[8];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] Card = new byte[5];
        public byte Group;
        public ushort TimeZones;
        public uint PIN2;
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

    //the short message struct of Black&White screen devices(Fixed-length data format-72 bytes in all)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class SMS
    {
        public byte Tag;
        public ushort ID;
        public ushort ValidMinutes;
        public ushort Reserved;
        public uint StartTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = UDisk.MAX_SMS_CONTENT_SIZE + 1)]
        public byte[] Content=new byte[UDisk.MAX_SMS_CONTENT_SIZE+1];
    }

    //the struct showing the relation between the user id and its short message
    //For Black&White screen devices-Fixed-length data format-4 bytes in all
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class UData
    {
        public ushort PIN;//0 stands for invalid log
        public ushort SmsID;
    }


    class UDisk
    {
        public const int MAX_SMS_CONTENT_SIZE=60;//the max length of short message in the Black&White screen devices

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
        public void GetUserInfoFromDat(byte[] DataBuf,out int PIN,out int Privilege,out string Password,
           out string Name,out int Card,out int Group,out int TimeZones,out int PIN2)
        {
            byte[] PasswordBuf = new byte[5];
            byte[] NameBuf = new byte[8];
                       
            User user = new User();
            user = (User)Raw.RawDeserialize(DataBuf, typeof(User));
            
            PIN = user.PIN;
            Privilege = user.Privilege;

            Array.Copy(DataBuf, 3, PasswordBuf, 0, 5);
            Password = System.Text.Encoding.Default.GetString(PasswordBuf);//"default" is to read the system's current ANSI code page encoding
            
            Array.Copy(DataBuf,8,NameBuf,0,8);
            Name = System.Text.Encoding.Default.GetString(NameBuf);

            Card = 0;
            for(int i=16;i<=20;i++)
            {
                Card+=Convert.ToInt32(DataBuf[i]* System.Math.Pow(16,2*(i-16)));
            }

            Group = user.Group;
            TimeZones = user.TimeZones;
            PIN2 =Convert.ToInt32( user.PIN2);
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
           
            user.PIN=(ushort)PIN;
            user.Privilege=(byte)Privilege;

            PasswordBuf = System.Text.Encoding.Default.GetBytes(Password);
            Array.Copy(PasswordBuf, user.Password, 5);

            NameBuf = System.Text.Encoding.Default.GetBytes(Name);
            Array.Copy(NameBuf,user.Name,8);

            CardBuf = BitConverter.GetBytes(Card);
            Array.Copy(CardBuf, user.Card, 4);//Although we have defined 5 bytes to store the card number,but in fact 4bytes is enough(an integer data)

            user.Group = (byte)Group;
           
            TimeZone = user.TimeZones;
      
            user.PIN2 = (ushort)PIN2;

            Array.Copy(Raw.RawSerialize(user),0,DataBuf,0,28);
        }

        /****************************************************************************************************************************
        * FunctionName:GetTemplateFromDat
        * Parameters In:DataBuf
        * Parameters Out:Size,PIN,FingerID,Valid,Template
        * Return Value:void
        * Device Used:template.dat in Black&White screen devices using 9.0 arithmetic 
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
        * Device Used:template.dat in Black&White screen devices using 9.0 arithmetic
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
        * FunctionName:GetAttLogFromDat
        * Parameters In:DataBuf,OneLogLength
        * Parameters Out:PIN2,Time_second,DeviceID,Status,Verified,Workcode
        * Return Value:void
        * Device Used:(For Black&White screen devices).i_attlog.dat(i is the Device ID)
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
        * Device Used:For Black&White screen devices.i_attlog.dat(i is the Device ID)
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
        public void GetSMSFromDat(byte[] DataBuf,out int Tag, out int ID, out int ValidMinutes, out int Reserved,
            out string StartTime, out string Content)
        {
            byte[] ContentBuf = new byte[UDisk.MAX_SMS_CONTENT_SIZE+1];

            SMS sms = new SMS();
            sms=(SMS)Raw.RawDeserialize(DataBuf,typeof(SMS));
           
            Tag = sms.Tag;
            ID = sms.ID;
            ValidMinutes = sms.ValidMinutes;
            Reserved = sms.Reserved;

            //decode time from uint value type to string value type
            int Time=(int)sms.StartTime;
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
                dt= new DateTime((int)Year, (int)Month, (int)Day, (int)Hour, (int)Minute, (int)Second);
            }
            catch (Exception e)
            {
                dt = new DateTime(1970, 1, 1, 1, 1, 1);
                MessageBox.Show(e.ToString(), "Error");
            }
            StartTime = dt.ToString();

            Array.Copy(DataBuf, 11, ContentBuf, 0, UDisk.MAX_SMS_CONTENT_SIZE + 1);

            Content = System.Text.Encoding.Default.GetString(ContentBuf);
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
            byte[] ContentBuf = new byte[UDisk.MAX_SMS_CONTENT_SIZE+1];
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
            udata=(UData)Raw.RawDeserialize(DataBuf,typeof(UData));

            PIN=udata.PIN;
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
        public void SetUDataToDat(out byte[] DataBuf,int PIN,int SmsID)
        {
            DataBuf = new byte[4];

            UData udata = new UData();

            udata.PIN =(ushort) PIN;
            udata.SmsID = (ushort)SmsID;
            Array.Copy(Raw.RawSerialize(udata), DataBuf, 4);
        }

    }
}
