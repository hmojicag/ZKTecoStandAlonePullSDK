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

using System.Threading;

namespace AccessControl
{
    public partial class ACMain : Form
    {
        public ACMain()
        {
            InitializeComponent();
        }

        //Create Standalone SDK class dynamicly.
        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();

        /*************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.*
        * This part is for demonstrating the communication with your device.                             *
        * ************************************************************************************************/
        #region Communication
        private bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.

        //If your device supports the TCP/IP communications, you can refer to this.
        //when you are using the tcp/ip communication,you can distinguish different devices by their IP address.
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtIP.Text.Trim() == "" || txtPort.Text.Trim() == "")
            {
                MessageBox.Show("IP and Port cannot be null", "Error");
                return;
            }
            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (btnConnect.Text == "DisConnect")
            {
                axCZKEM1.Disconnect();
                bIsConnected = false;
                btnConnect.Text = "Connect";
                lblState.Text = "Current State:DisConnected";
                Cursor = Cursors.Default;
                return;
            }

            bIsConnected = axCZKEM1.Connect_Net(txtIP.Text, Convert.ToInt32(txtPort.Text));
            if (bIsConnected == true)
            {
                btnConnect.Text = "DisConnect";
                btnConnect.Refresh();
                lblState.Text = "Current State:Connected";
                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //If your device supports the SerialPort communications, you can refer to this.
        private void btnRsConnect_Click(object sender, EventArgs e)
        {
            if (cbPort.Text.Trim() == "" || cbBaudRate.Text.Trim() == "" || txtMachineSN.Text.Trim() == "")
            {
                MessageBox.Show("Port,BaudRate and MachineSN cannot be null", "Error");
                return;
            }
            int idwErrorCode = 0;
            //accept serialport number from string like "COMi"
            int iPort;
            string sPort = cbPort.Text.Trim();
            for (iPort = 1; iPort < 10; iPort++)
            {
                if (sPort.IndexOf(iPort.ToString()) > -1)
                {
                    break;
                }
            }

            Cursor = Cursors.WaitCursor;
            if (btnRsConnect.Text == "Disconnect")
            {
                axCZKEM1.Disconnect();
                bIsConnected = false;
                btnRsConnect.Text = "Connect";
                btnRsConnect.Refresh();
                lblState.Text = "Current State:Disconnected";
                Cursor = Cursors.Default;
                return;
            }

            iMachineNumber = Convert.ToInt32(txtMachineSN.Text.Trim());//when you are using the serial port communication,you can distinguish different devices by their serial port number.
            bIsConnected = axCZKEM1.Connect_Com(iPort, iMachineNumber, Convert.ToInt32(cbBaudRate.Text.Trim()));

            if (bIsConnected == true)
            {
                btnRsConnect.Text = "Disconnect";
                btnRsConnect.Refresh();
                lblState.Text = "Current State:Connected";

                axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }

            Cursor = Cursors.Default;
        }

        #endregion

        /**********************************************************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.                                             *
        * This part is for demonstrating the operations of the access control.You should be clear about some terms ,such as “time zone,unlock groups,*
        * wiegand format,user group,user's time zone”.Also,you can refer to the manual.                                                              *
        * *********************************************************************************************************************************************/
        #region Access Control

        //Get the group number the specified user belongs to. 
        private void btnGetUserGroup_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbUserIDGroup.Text.Trim()=="")
            {
                MessageBox.Show("Please input the UserID first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iUserID = Convert.ToInt32(cbUserIDGroup.Text.Trim());
            int iUserGrp = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetUserGroup(iMachineNumber,iUserID,ref iUserGrp))
            {
                cbUserGrp.Text = iUserGrp.ToString();
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Set the group number by the specified user.
        private void btnSetUserGroup_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbUserIDGroup.Text.Trim() == ""||cbUserGrp.Text.Trim()=="")
            {
                MessageBox.Show("Please input the UserID and UserGrp first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iUserID = Convert.ToInt32(cbUserIDGroup.Text.Trim());
            int iUserGrp = Convert.ToInt32(cbUserGrp.Text.Trim());

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetUserGroup(iMachineNumber,iUserID,iUserGrp))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("SetUserGroup, UserID:" + iUserID.ToString()+" UserGrp:"+iUserGrp.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the timezone information by the specified timezone number
        private void btnGetTZInfo_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbTZIndex.Text.Trim()=="")
            {
                MessageBox.Show("Please input the TZIndex first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iTZIndex = Convert.ToInt32(cbTZIndex.Text.Trim());
            string sTZ = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetTZInfo(iMachineNumber,iTZIndex,ref sTZ))
            {
                txtTZ.Text = sTZ;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Set the timezone information and its number 
        private void btnSetTZInfo_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbTZIndex.Text.Trim()==""||txtTZ.Text.Trim()=="")
            {
                MessageBox.Show("Please input the TZIndex and TZ first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iTZIndex = Convert.ToInt32(cbTZIndex.Text.Trim());
            string sTZ = txtTZ.Text.Trim();

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetTZInfo(iMachineNumber,iTZIndex,sTZ))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("SetTZInfo, cbTZIndex:" + iTZIndex.ToString() + " TimeZone:" + sTZ, "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the unlock groups combination information.
        private void btnSSR_GetUnLockGroup_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbComNo.Text.Trim() == "")
            {
                MessageBox.Show("Please input the ComNo first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iComNo = Convert.ToInt32(cbComNo.Text.Trim());
            int iGroup1 = 0;
            int iGroup2 = 0;
            int iGroup3 = 0;
            int iGroup4 = 0;
            int iGroup5 = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SSR_GetUnLockGroup(iMachineNumber,iComNo,ref iGroup1,ref iGroup2,ref iGroup3,ref iGroup4,ref iGroup5))
            {
                cbGroup1.Text = iGroup1.ToString();
                cbGroup2.Text = iGroup2.ToString();
                cbGroup3.Text = iGroup3.ToString();
                cbGroup4.Text = iGroup4.ToString();
                cbGroup5.Text = iGroup5.ToString();
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Set the unlock groups combination information.
        private void btnSSR_SetUnLockGroup_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbComNo.Text.Trim() == ""||cbGroup1.Text.Trim()==""||cbGroup2.Text.Trim()==""||cbGroup3.Text.Trim()==""||cbGroup4.Text.Trim()==""||cbGroup5.Text.Trim()=="")
            {
                MessageBox.Show("Please input the five groups first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iComNo = Convert.ToInt32(cbComNo.Text.Trim());
            int iGroup1 = Convert.ToInt32(cbGroup1.Text.Trim());
            int iGroup2 = Convert.ToInt32(cbGroup2.Text.Trim());
            int iGroup3 = Convert.ToInt32(cbGroup3.Text.Trim());
            int iGroup4 = Convert.ToInt32(cbGroup4.Text.Trim());
            int iGroup5 = Convert.ToInt32(cbGroup5.Text.Trim());

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SSR_SetUnLockGroup(iMachineNumber,iComNo,iGroup1,iGroup2,iGroup3,iGroup4,iGroup5))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("SetUnlockGroups, Groups:"+iGroup1.ToString()+":"+iGroup2.ToString()+":"+iGroup3.ToString()+":"+iGroup4.ToString()+":"+iGroup5.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the time zones used by specified group and other interrelated information.
        private void btnSSR_GetGroupTZ_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbGroupNo.Text.Trim()=="")
            {
                MessageBox.Show("Please input the GroupNo first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iGroupNo = Convert.ToInt32(cbGroupNo.Text.Trim());
            int iValidHoliday=0;
            int iVerifyStyle=0;
            int iTZ1 = 0;
            int iTZ2 = 0;
            int iTZ3 = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SSR_GetGroupTZ(iMachineNumber,iGroupNo,ref iTZ1,ref iTZ2,ref iTZ3,ref iValidHoliday,ref iVerifyStyle))
            {
                cbGroupNo.Text = iGroupNo.ToString();
                cbTZ1.Text = iTZ1.ToString();
                cbTZ2.Text = iTZ2.ToString();
                cbTZ3.Text = iTZ3.ToString();
                cbValidHoliday.Text = iValidHoliday.ToString();
                cbVerifyStyle.Text = iVerifyStyle.ToString();
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Set the time zones used by specified group and other interrelated information.
        private void btnSSR_SetGroupTZ_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbGroupNo.Text.Trim() == ""||cbTZ1.Text.Trim()==""||cbTZ2.Text.Trim()==""||cbTZ3.Text.Trim()==""||cbValidHoliday.Text.Trim()==""||cbVerifyStyle.Text.Trim()=="")
            {
                MessageBox.Show("Please input the params first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iGroupNo = Convert.ToInt32(cbGroupNo.Text.Trim());
            int iValidHoliday = Convert.ToInt32(cbValidHoliday.Text.Trim());
            int iVerifyStyle = Convert.ToInt32(cbVerifyStyle.Text.Trim());
            int iTZ1 = Convert.ToInt32(cbTZ1.Text.Trim());
            int iTZ2 = Convert.ToInt32(cbTZ2.Text.Trim());
            int iTZ3 = Convert.ToInt32(cbTZ3.Text.Trim());

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SSR_SetGroupTZ(iMachineNumber,iGroupNo,iTZ1,iTZ2,iTZ3,iValidHoliday,iVerifyStyle))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("SSR_SetGroupTZ, GroupNo:" + iGroupNo.ToString() + " VerifyStyle:" + iVerifyStyle.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the timezone by the user's id.
        //The detailed meaning of the parameter is mentioned in the development manual.
        private void btnGetUserTZStr_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbUserIDTZ.Text.Trim()=="")
            {
                MessageBox.Show("Please input the UserID first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iUserID=Convert.ToInt32(cbUserIDTZ.Text.Trim());
            string sTZs="";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetUserTZStr(iMachineNumber,iUserID,ref sTZs))//TZs is in the form of string.
            {
                txtUserTZs.Text=sTZs;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Establish the relation between users and timezones.
        //The detailed meaning of the parameter is mentioned in the development manual.
        private void btnSetUserTZStr_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbUserIDTZ.Text.Trim()==""||txtUserTZs.Text.Trim()=="")
            {
                MessageBox.Show("Please input the UserID and TimeZones first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iUserID=Convert.ToInt32(cbUserIDTZ.Text.Trim());
            string sTZs=txtUserTZs.Text.Trim();

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetUserTZStr(iMachineNumber, iUserID, sTZs))//TZs is in strings.
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("SetUserTZStr, UserID:"+iUserID.ToString()+" TimeZones:"+sTZs,"Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Make the controller to export a electric-level to open door
        private void btnACUnlock_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (txtDelay.Text.Trim()=="")
            {
                MessageBox.Show("Please input the Delay seconds first!", "Error");
                return;
            }
            int idwErrorCode = 0;
            int iDelay = Convert.ToInt32(txtDelay.Text.Trim());//time to delay

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.ACUnlock(iMachineNumber,iDelay))
            {
                MessageBox.Show("ACUnlock, Dalay Seconds:" +iDelay.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Judge whether the device supports access control function. 
        //Black&White and TFT screen devices have different parameters meaning,please refer to the manual first.
        private void btnGetACFun_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }
            int idwErrorCode = 0;
            int iACFun=0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetACFun(ref iACFun))
            {
                MessageBox.Show("GetACFun, ACFun:" +iACFun.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Judge whether the door is open now. 
        private void btnGetDoorState_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }
            int idwErrorCode = 0;
            int iState = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetDoorState(iMachineNumber,ref iState))
            {
                if (iState == 1)
                {
                    lblDoorState.Text = "The door is open now!";
                }
                else
                {
                    lblDoorState.Text = "The door is close now!";
                }
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Judge whether the user is using group time zone.
        private void btnUseGroupTimeZone_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbUserIDTZ.Text.Trim() == "")
            {
                MessageBox.Show("Please input the UserID first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iUserID = Convert.ToInt32(cbUserIDTZ.Text.Trim());
            string sTZs = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetUserTZStr(iMachineNumber, iUserID, ref sTZs))
            {
                txtUserTZs.Text = sTZs;
                if (axCZKEM1.UseGroupTimeZone())
                {
                    MessageBox.Show("Using Group TimeZone", "Yes");
                }
                else
                {
                    MessageBox.Show("Not Using Group TimeZone", "No");
                }
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the format of wiegand. 
        private void btnGetWiegandFmt_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sWiegandFmt = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetWiegandFmt(iMachineNumber, ref sWiegandFmt))
            {
                txtShow.Text = sWiegandFmt;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }
        //Set the format of wiegand.
        private void btnSetWiegandFmt_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sWiegandFmt = txtSet.Text.Trim();

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetWiegandFmt(iMachineNumber, sWiegandFmt))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Setting WiegandFmt address succeeded! WiegandFmt=" + sWiegandFmt, "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //add by Darcy on Nov.23 2009
        //Add the esxited userid to DropDownLists.
        bool bAddControl = true;
        private void UserIDTimer_Tick(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                cbUserIDGroup.Items.Clear();
                cbUserIDTZ.Items.Clear();
                bAddControl = true;
                return;
            }
            else
            {
                if (bAddControl == true)
                {
                    string sEnrollNumber = "";
                    string sName = "";
                    string sPassword = "";
                    int iPrivilege = 0;
                    bool bEnabled = false;

                    axCZKEM1.EnableDevice(iMachineNumber, false);
                    axCZKEM1.ReadAllUserID(iMachineNumber);//read all the user information to the memory
                    while (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out sEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
                    {
                        cbUserIDGroup.Items.Add(sEnrollNumber);
                        cbUserIDTZ.Items.Add(sEnrollNumber);
                    }
                    bAddControl = false;
                    axCZKEM1.EnableDevice(iMachineNumber, true);
                }
                return;
            }
        }
        #endregion

        private void btnSetUserInfoEx_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbUserIDGroup.Text.Trim() == "" || cbUserVerify.Text.Trim() == "")
            {
                MessageBox.Show("Please input the UserID and VerifyStyle first!", "Error");
                return;
            }

            int idwErrorCode = 0;

            int iUserID = Convert.ToInt32(cbUserIDGroup.Text.Trim());
            int iVerifyStyle = Convert.ToInt32(cbUserVerify.Text.Trim());
            byte iReserved = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetUserInfoEx(iMachineNumber, iUserID, iVerifyStyle, ref iReserved))
            {
                MessageBox.Show("SetUserInfoEx,UserID:" + iUserID.ToString() + " VerifyStyle:" + iVerifyStyle.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        private void btnGetUserInfoEx_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbUserIDGroup.Text.Trim() == "")
            {
                MessageBox.Show("Please input the UserID first!", "Error");
                return;
            }

            int idwErrorCode = 0;

            int iUserID = Convert.ToInt32(cbUserIDGroup.Text.Trim());
            int iVerifyStyle = 0;
            byte iReserved = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetUserInfoEx(iMachineNumber, iUserID, out iVerifyStyle, out iReserved))
            {
                cbUserVerify.Text = iVerifyStyle.ToString();
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

    }

} 