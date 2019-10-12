//  *******************************************************************************************
//
//  Description: UDisk Data Struct
//  Author: Mice
//  Create Date: 2014/07/15
//  Memo:
//
//  *******************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace StandaloneSDKDemo
{
    /// <summary>
    /// //用户结构
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// //工号
        /// </summary>
        public int userNo;
        /// <summary>
        /// //设备权限
        /// </summary>
        public int privilege;
        /// <summary>
        /// //密码
        /// </summary>
        public string userPwd;
        /// <summary>
        /// //姓名
        /// </summary>
        public string userName;
        /// <summary>
        /// //卡号
        /// </summary>
        public uint cardNo;
        /// <summary>
        /// //组别
        /// </summary>
        public int Group;
        /// <summary>
        /// //时区
        /// </summary>
        public ushort[] timeZones = new ushort[4];
        /// <summary>
        /// //备用登记号
        /// </summary>
        public string Pin2;
    }

    /// <summary>
    /// //指纹模板信息
    /// </summary>
    public class TemplateInfo
    {
        /// <summary>
        /// //模板长度
        /// </summary>
        public int Size;
        /// <summary>
        /// 用户Pin
        /// </summary>
        public int Pin;
        /// <summary>
        /// 手指头编号
        /// </summary>
        public int fingerID;
        /// <summary>
        /// 是否启用
        /// </summary>
        public int Valid;
        /// <summary>
        /// Base64字符串编码
        /// </summary>
        public string TemplateStr;
        /// <summary>
        /// template type.
        /// </summary>
        public string TemplateType;
    }

    public class FaceInfo
    { 
        public int Size;	                  //face template size   2Byte
        public int Pin;                       //user ID              2Byte   
        public int FaceID;                    //Face id              1Byte
        public int Valid;                     // flag                1Byte
        public int Reserve;	                  //Reserve              2Byte   
        public int ActiveTime;                //Last active time     4Byte
        public int VfCount;                   // Verify Count        4Bype
        public string Face;                   //maximize template length   1024 * 2 + 512
    }

    /// <summary>
    /// sms info
    /// </summary>
    //public class SMSInfo
    //{ 
    //    int Tag;
    //    int Id;
    //    int ValidMinutes;
    //    int reserved;
    //    DateTime StartTime;
    //    string Content;
    //}

    //User information of Black&White screen device(Fixed-length data format-28 bytes in all)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class User
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

    //The data is stored in the little endian strorage mode and in accordance with a byte-aligned

    //User information of TFT screen device(Fixed-length data format-72 bytes in all)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SSR_User
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
    public class Templates9
    {
        public ushort Size;
        public ushort PIN;
        public byte FingerID;
        public byte Valid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 602)]
        public byte[] Template = new byte[602];//the max value is 602 bytes 
    }

    //fingerprint templates information of 10.0 arithmetic(Variable-length data format)
    //The max length of one template is 16 kb, that is, one template's length is less than 16kb.
    //The following is the fixed-length part of the data struct which is 6 bytes long.
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Tmp10Header
    {
        public ushort Size;
        public ushort PIN;
        public byte FingerID;
        public byte Valid;
    }

    //the face templates information of IFace series(Fixed-length data format-2576 bytes in all)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class FaceTmp
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

    //the short message struct of Black&White screen devices(Fixed-length data format-72 bytes in all)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SMS
    {
        public byte Tag;
        public ushort ID;
        public ushort ValidMinutes;
        public ushort Reserved;
        public uint StartTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60 + 1)]
        public byte[] Content = new byte[60 + 1];
    }

    //the short message struct of TFT screen devices(Fixed-length data format-332 bytes in all)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SSR_SMS
    {
        public byte Tag;//type of short message
        public ushort ID;//the tag of the data,zero means that the log is invalid.
        public ushort ValidMinutes;// zero stands for forever
        public ushort Reserved;
        public uint StartTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 160 * 2 + 1)]
        public byte[] Content = new byte[160 * 2 + 1];//the content of the short message
    }

    //the struct showing the relation between the user id and its short message
    //For Black&White screen devices-Fixed-length data format-4 bytes in all
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class UData
    {
        public ushort PIN;//0 stands for invalid log
        public ushort SmsID;
    }
}
