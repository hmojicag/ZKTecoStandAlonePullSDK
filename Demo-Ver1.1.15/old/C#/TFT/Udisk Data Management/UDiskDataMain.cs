/**********************************************************
 * Demo for Standalone SDK.Created by Darcy on Oct.15 2009*
***********************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//namespaces needed to add 
using System.IO;//used for Class FileStream
using System.Runtime.InteropServices;//used for Class Marshal

namespace UdiskData
{
    public partial class UDiskDataMain : Form
    {
        public UDiskDataMain()
        {
            InitializeComponent();
        }
        /***************************************************************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.                                                  *
        * This part is for demonstrating the operations of  Udisk data management.Including getting data from Udisk & writing data to files to be uploaded.*
        * No need to connect the device,just need to plug in the usb disk.                                                                                 *
        ****************************************************************************************************************************************************/

        #region SSR_User(TFT)

        //To read the user information of the TFT screen devices,Filename:user.dat
        private void btnSSR_UserRead_Click(object sender, EventArgs e)
        { 
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;
            int iCount;//count of users

            int iPIN = 0;
            int iPrivilege = 0;
            string sName = "";
            string sPassword = "";
            int iCard = 0;
            int iGroup = 0;
            string sTimeZones = "";
            string sPIN2 = "";

            lvSSRUser.Items.Clear();
            openFileDialog1.Filter = "user(*.dat)|*.dat";
            openFileDialog1.FileName = "user.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);
               
                iLength = Convert.ToInt32(stream.Length);
                if (iLength % 72 != 0)
                {
                    MessageBox.Show("Data Error!Please check whether you have chosen the right file!", "Error", MessageBoxButtons.OK);
                    return;
                }
                iCount = iLength / 72;

                for (int j = 0; j < iCount; j++)//loop to deal with all the users
                {
                    byte[] byUserInfo = new byte[72];
                    for (int i = 0; i < 72; i++)//loop to deal with every user's information
                    {
                        byUserInfo[i] = byDataBuf[j * 72 + i];
                    }
                    udisk.GetSSRUserInfoFromDat(byUserInfo, out iPIN, out iPrivilege, out sPassword, out sName, out iCard, out iGroup, out sTimeZones, out sPIN2);

                    ListViewItem list = new ListViewItem();
                    list.Text = sPIN2;
                    list.SubItems.Add(sName);
                    list.SubItems.Add(iCard.ToString());
                    list.SubItems.Add(iPrivilege.ToString());
                    list.SubItems.Add(sPassword);
                    list.SubItems.Add(iGroup.ToString());
                    list.SubItems.Add(sTimeZones);
                    list.SubItems.Add(iPIN.ToString());
                    lvSSRUser.Items.Add(list);

                    byUserInfo = null;
                }
                stream.Close();
            }
        }

        //To write the user information of the TFT screen devices,Filename:user.dat
        private void btnSSR_UserWrite_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            saveFileDialog1.Filter = "user(*.dat)|*.dat";
            saveFileDialog1.FileName = "user.dat";
            int iCount = lvSSRUser.Items.Count;
            byte[] byDataBuf = new byte[iCount * 72];
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int iDataBufIndex = 0;
                for (int i = 0; i < iCount; i++)
                {
                    string sPIN2 = lvSSRUser.Items[i].SubItems[0].Text.Trim();
                    string sName = lvSSRUser.Items[i].SubItems[1].Text.Trim();
                    int iCard = Convert.ToInt32(lvSSRUser.Items[i].SubItems[2].Text.Trim());
                    int iPrivilege = Convert.ToInt32(lvSSRUser.Items[i].SubItems[3].Text.Trim());
                    string sPassword = lvSSRUser.Items[i].SubItems[4].Text.Trim();
                    int iGroup = Convert.ToInt32(lvSSRUser.Items[i].SubItems[5].Text.Trim());
                    string sTimeZones = lvSSRUser.Items[i].SubItems[6].Text.Trim();
                    int iPIN = Convert.ToInt32(lvSSRUser.Items[i].SubItems[7].Text.Trim());

                    byte[] byUserInfo = new byte[72];
                    udisk.SetSSRUserInfoToDat(out byUserInfo, iPIN, iPrivilege, sPassword, sName, iCard, iGroup, sTimeZones, sPIN2);
                    Array.Copy(byUserInfo, 0, byDataBuf, iDataBufIndex, 72);
                    byUserInfo = null;
                    iDataBufIndex += 72;
                }
            }
            File.WriteAllBytes(saveFileDialog1.FileName, byDataBuf);
        }
        
        #endregion

        #region Template(9.0 10.0)

        //To read the fingerprint template information of 9.0 arithmetic,Filename:template.dat
        private void btnTmpRead_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;
            int iCount;

            int iSize = 0;
            int iPIN = 0;
            int iFingerID = 0;
            int iValid = 0;
            string sTemplate = "";

            lvTmp.Items.Clear();
            openFileDialog1.Filter = "template(*.dat)|*.dat";
            openFileDialog1.FileName = "template.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);

                iLength = Convert.ToInt32(stream.Length);
                if (iLength % 608 != 0)
                {
                    MessageBox.Show("Data Error!", "Error", MessageBoxButtons.OK);
                    return;
                }
                iCount = iLength / 608;

                for (int j = 0; j < iCount; j++)//loop to deal with all the templates
                {
                    byte[] byTmpInfo = new byte[608];
                    for (int i = 0; i < 608; i++)//loop to deal with every template
                    {
                        byTmpInfo[i] = byDataBuf[j * 608 + i];
                    }
                    udisk.GetTemplateFromDat(byTmpInfo, out iSize, out iPIN, out iFingerID, out iValid, out sTemplate);

                    ListViewItem list = new ListViewItem();
                    list.Text = iSize.ToString();
                    list.SubItems.Add(iPIN.ToString());
                    list.SubItems.Add(iFingerID.ToString());
                    list.SubItems.Add(iValid.ToString());
                    list.SubItems.Add(sTemplate);
                    lvTmp.Items.Add(list);

                    byTmpInfo = null;
                }
                stream.Close();
            }
        }

        //To write the fingerprint template information of 9.0 arithmetic,Filename:template.dat
        private void btnTmpWrite_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            int iCount = lvTmp.Items.Count;
            byte[] byDataBuf = new byte[iCount * 608];

            saveFileDialog1.Filter = "template(*.dat)|*.dat";
            saveFileDialog1.FileName = "template.dat";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int iDataBufIndex = 0;
                for (int i = 0; i < iCount; i++)
                {
                    int iSize = Convert.ToInt32(lvTmp.Items[i].SubItems[0].Text.Trim());
                    int iPIN = Convert.ToInt32(lvTmp.Items[i].SubItems[1].Text.Trim());
                    int iFingerIndex = Convert.ToInt32(lvTmp.Items[i].SubItems[2].Text.Trim());
                    int iValid = Convert.ToInt32(lvTmp.Items[i].SubItems[3].Text.Trim());
                    string sTemplate = lvTmp.Items[i].SubItems[4].Text.Trim();

                    byte[] byTmpInfo = null;
                    udisk.SetTemplateToDat(out byTmpInfo, iSize, iPIN, iFingerIndex, iValid, sTemplate);
                    Array.Copy(byTmpInfo, 0, byDataBuf, iDataBufIndex, 608);
                    iDataBufIndex += 608;
                }
            }
            File.WriteAllBytes(saveFileDialog1.FileName, byDataBuf);
        }

        //To read the fingerprint template information of 10.0 arithmetic,Filename:template.fp10.1
        private void btnTmp10Read_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;
            int iStartIndex;

            int iSize = 0;
            int iPIN = 0;
            int iFingerID = 0;
            int iValid = 0;
            string sTemplate = "";

            lvTmp10.Items.Clear();
            openFileDialog1.Filter = "template(*.fp10.1)|*.fp10.1";
            openFileDialog1.FileName = "template.fp10.1";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);

                iLength = Convert.ToInt32(stream.Length);

                iStartIndex = 0;
                for (int i = 0; i < iLength; i++)
                {
                    iSize = byDataBuf[i] + byDataBuf[i + 1] * 256;//the variable length of the 10.0 arithmetic template
                    byte[] byTmpInfo = new byte[iSize];

                    Array.Copy(byDataBuf, iStartIndex, byTmpInfo, 0, iSize);

                    iStartIndex += iSize;
                    i = iStartIndex - 1;

                    udisk.GetTmp10FromFp10(byTmpInfo, iSize, out iPIN, out iFingerID, out iValid, out sTemplate);

                    ListViewItem list = new ListViewItem();
                    list.Text = iSize.ToString();
                    list.SubItems.Add(iPIN.ToString());
                    list.SubItems.Add(iFingerID.ToString());
                    list.SubItems.Add(iValid.ToString());
                    list.SubItems.Add(sTemplate);
                    lvTmp10.Items.Add(list);

                    byTmpInfo = null;
                }
                stream.Close();
            }
        }

        //To write the fingerprint template information of 10.0 arithmetic,Filename:template.fp10.1
        private void btnTmp10Write_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            int iLength = 0;
            int iCount = lvTmp10.Items.Count;
            byte[] byTempBuf = new byte[iCount * 16 * 1024];//the max value

            saveFileDialog1.Filter = "template(*.fp10.1)|*.fp10.1";
            saveFileDialog1.FileName = "template.fp10.1";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int iDataBufIndex = 0;
                for (int i = 0; i < iCount; i++)
                {
                    int iSize = Convert.ToInt32(lvTmp10.Items[i].SubItems[0].Text.Trim());
                    int iPIN = Convert.ToInt32(lvTmp10.Items[i].SubItems[1].Text.Trim());
                    int iFingerIndex = Convert.ToInt32(lvTmp10.Items[i].SubItems[2].Text.Trim());
                    int iValid = Convert.ToInt32(lvTmp10.Items[i].SubItems[3].Text.Trim());
                    string sTemplate = lvTmp10.Items[i].SubItems[4].Text.Trim();

                    byte[] byTmpInfo = null;
                    udisk.SetTmp10ToFp10(out byTmpInfo, iSize, iPIN, iFingerIndex, iValid, sTemplate);
                    Array.Copy(byTmpInfo, 0, byTempBuf, iDataBufIndex, iSize);
                    iDataBufIndex += iSize;
                    iLength += iSize;
                }
            }
            byte[] byDataBuf = new byte[iLength];
            Array.Copy(byTempBuf, byDataBuf, iLength);
            File.WriteAllBytes(saveFileDialog1.FileName, byDataBuf);
        }
        #endregion

        #region AttLogs(TFT)
        //To read the attendence logs (For TFT screen devices,Filename:DeviceID_attolog.dat)
        private void btnSSRAttLogRead_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;//length of the bytes to get from the data

            string sPIN2 = "";
            string sVerified = "";
            string sTime_second = "";
            string sDeviceID = "";
            string sStatus = "";
            string sWorkcode = "";

            openFileDialog1.Filter = "1_attlog(*.dat)|*.dat";
            openFileDialog1.FileName = "1_attlog.dat";//1 stands for one possible deviceid
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);
                iLength = Convert.ToInt32(stream.Length);

                lvSSRAttLog.Items.Clear();
                int iStartIndex = 0;
                int iOneLogLength;//the length of one line of attendence log
                for (int i = iStartIndex; i < iLength-2; i++)//modify by darcy on Dec.4 2009
                {
                    if (byDataBuf[i] == 13 && byDataBuf[i + 1] == 10)
                    {
                        iOneLogLength = (i + 1) + 1 - iStartIndex;
                        byte[] bySSRAttLog = new byte[iOneLogLength];
                        Array.Copy(byDataBuf, iStartIndex, bySSRAttLog, 0, iOneLogLength);

                        udisk.GetAttLogFromDat(bySSRAttLog, iOneLogLength, out sPIN2, out sTime_second, out sDeviceID, out sStatus, out sVerified, out sWorkcode);

                        ListViewItem list = new ListViewItem();
                        list.Text = sPIN2;
                        list.SubItems.Add(sTime_second);
                        list.SubItems.Add(sDeviceID);
                        list.SubItems.Add(sStatus);
                        list.SubItems.Add(sVerified);
                        list.SubItems.Add(sWorkcode);
                        lvSSRAttLog.Items.Add(list);

                        bySSRAttLog = null;
                        iStartIndex += iOneLogLength;
                        iOneLogLength = 0;
                    }
                }
                stream.Close();
            }
        }

        //To write the attendence logs (For TFT,Filename:DeviceID_attolog.dat)
        private void btnSSRAttLogWrite_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            int iCount = lvSSRAttLog.Items.Count;
            int iLength = 0;
            byte[] byTemporaryBuf = new byte[1024 * 1024 * 40];

            saveFileDialog1.Filter = "1_attlog(*.dat)|*.dat";
            saveFileDialog1.FileName = "1_attlog.dat";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int iTemBufIndex = 0;
                for (int i = 0; i < iCount; i++)
                {
                    string sPIN2 = lvSSRAttLog.Items[i].SubItems[0].Text;//don't default he space,otherwise the data will be wrong
                    string sTime_second = lvSSRAttLog.Items[i].SubItems[1].Text;
                    string sDeviceID = lvSSRAttLog.Items[i].SubItems[2].Text;
                    string sStatus = lvSSRAttLog.Items[i].SubItems[3].Text;
                    string sVerified = lvSSRAttLog.Items[i].SubItems[4].Text;
                    string sWorkcode = lvSSRAttLog.Items[i].SubItems[5].Text;
                    byte[] bySSRAttInfo = null;

                    int iOneLogLength = 0;
                    udisk.SetAttLogToDat(out bySSRAttInfo, out iOneLogLength, sPIN2, sTime_second, sDeviceID, sStatus, sVerified, sWorkcode);
                    Array.Copy(bySSRAttInfo, 0, byTemporaryBuf, iTemBufIndex, iOneLogLength);
                    iTemBufIndex += iOneLogLength;
                    iLength += iOneLogLength;
                }
            }
            byte[] byDataBuf = new byte[iLength];
            Array.Copy(byTemporaryBuf, byDataBuf, iLength);
            File.WriteAllBytes(saveFileDialog1.FileName, byDataBuf);
        }
        #endregion

        #region Short Messages(TFT)

        //To read the short messages in the TFT screen devices (Filename:sms.dat)
        private void btnSSRSMSRead_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;
            int iCount;//count of short messages

            int iTag = 0;
            int iID = 0;
            int iValidMinutes = 0;
            int iReserved = 0;
            string sStartTime = "";
            string sContent = "";

            lvSSRSMS.Items.Clear();
            openFileDialog1.Filter = "sms(*.dat)|*.dat";
            openFileDialog1.FileName = "sms.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);

                iLength = Convert.ToInt32(stream.Length);
                if (iLength % 332 != 0)
                {
                    MessageBox.Show("Data Error!", "Error", MessageBoxButtons.OK);
                    return;
                }
                iCount = iLength / 332;

                for (int j = 0; j < iCount; j++)//loop
                {
                    byte[] bySMSInfo = new byte[332];
                    for (int i = 0; i < 332; i++)
                    {
                        bySMSInfo[i] = byDataBuf[j * 332 + i];
                    }
                    udisk.GetSSRSMSFromDat(bySMSInfo, out iTag, out iID, out iValidMinutes, out iReserved, out sStartTime, out sContent);

                    ListViewItem list = new ListViewItem();
                    list.Text = iTag.ToString();
                    list.SubItems.Add(iID.ToString());
                    list.SubItems.Add(iValidMinutes.ToString());
                    list.SubItems.Add(iReserved.ToString());
                    list.SubItems.Add(sStartTime);
                    list.SubItems.Add(sContent);
                    lvSSRSMS.Items.Add(list);

                    bySMSInfo = null;
                }
                stream.Close();
            }
        }

        //To write the short messages in the TFT screen devices (Filename:sms.dat)
        private void btnSSRSMSWrite_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            int iCount = lvSSRSMS.Items.Count;
            byte[] byDataBuf = new byte[iCount * 332];

            saveFileDialog1.Filter = "sms(*.dat)|*.dat";
            saveFileDialog1.FileName = "sms.dat";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int iDataBufIndex = 0;
                for (int i = 0; i < iCount; i++)
                {
                    int iTag = Convert.ToInt32(lvSSRSMS.Items[i].SubItems[0].Text.Trim());
                    int iID = Convert.ToInt32(lvSSRSMS.Items[i].SubItems[1].Text.Trim());
                    int iValidMinutes = Convert.ToInt32(lvSSRSMS.Items[i].SubItems[2].Text.Trim());
                    int iReserved = Convert.ToInt32(lvSSRSMS.Items[i].SubItems[3].Text.Trim());
                    string sStartTime = lvSSRSMS.Items[i].SubItems[4].Text.Trim();
                    string sContent = lvSSRSMS.Items[i].SubItems[5].Text;

                    byte[] bySMSInfo = null;
                    udisk.SetSSRSMSToDat(out bySMSInfo, iTag, iID, iValidMinutes, iReserved, sStartTime, sContent);
                    Array.Copy(bySMSInfo, 0, byDataBuf, iDataBufIndex, 332);
                    iDataBufIndex += 332;
                }
            }
            File.WriteAllBytes(saveFileDialog1.FileName, byDataBuf);
        }

        //Read the relation between user pin and short message id(For Both Black&White and TFT screen devices.FileName:udata.dat)
        private void btnUDataRead_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            byte[] byDataBuf = null;
            int iLength;
            int iCount;

            int iPIN = 0;
            int iSmsID = 0;

            lvUData.Items.Clear();
            openFileDialog1.Filter = "udata(*.dat)|*.dat";
            openFileDialog1.FileName = "udata.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                byDataBuf = File.ReadAllBytes(openFileDialog1.FileName);

                iLength = Convert.ToInt32(stream.Length);
                if (iLength % 4 != 0)
                {
                    MessageBox.Show("Data Error!", "Error", MessageBoxButtons.OK);
                    return;
                }
                iCount = iLength / 4;

                for (int j = 0; j < iCount; j++)
                {
                    byte[] byUDataInfo = new byte[4];
                    for (int i = 0; i < 4; i++)
                    {
                        byUDataInfo[i] = byDataBuf[j * 4 + i];
                    }
                    udisk.GetUDataFromDat(byUDataInfo, out iPIN, out iSmsID);

                    ListViewItem list = new ListViewItem();
                    list.Text = iPIN.ToString();
                    list.SubItems.Add(iSmsID.ToString());
                    lvUData.Items.Add(list);

                    byUDataInfo = null;
                }
                stream.Close();
            }
        }

        //Write the relation between user pin and short message id(For Both Black&White and TFT screen devices.FileName:udata.dat)
        private void btnUDataWrite_Click(object sender, EventArgs e)
        {
            UDisk udisk = new UDisk();

            int iCount = lvUData.Items.Count;
            byte[] byDataBuf = new byte[iCount * 4];

            saveFileDialog1.Filter = "udata(*.dat)|*.dat";
            saveFileDialog1.FileName = "udata.dat";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int iDataBufIndex = 0;
                for (int i = 0; i < iCount; i++)
                {
                    int iPIN = Convert.ToInt32(lvUData.Items[i].SubItems[0].Text.Trim());
                    int iSmsID = Convert.ToInt32(lvUData.Items[i].SubItems[1].Text.Trim());

                    byte[] byUDataInfo = null;
                    udisk.SetUDataToDat(out byUDataInfo, iPIN, iSmsID);
                    Array.Copy(byUDataInfo, 0, byDataBuf, iDataBufIndex, 4);
                    iDataBufIndex += 4;
                }
            }
            File.WriteAllBytes(saveFileDialog1.FileName, byDataBuf);
        }
        #endregion
    }
}

    
