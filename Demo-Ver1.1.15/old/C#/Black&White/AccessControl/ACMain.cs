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
using Microsoft.Win32;

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

        const int NOGroupIndex = 101; // Normally Open
        const int NCGroupIndex = 102; // Normally Close        

        /********************************************************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.                                           *
        * This part is for demonstrating the communication with your device.There are 3 communication ways: "TCP/IP","Serial Port" and "USB Client".*
        * The communication way which you can use duing to the model of the device.                                                                 *
        * *******************************************************************************************************************************************/
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

        //If your device supports the USBCLient, you can refer to this.
        //Not all series devices can support this kind of connection.Please make sure your device supports USBClient.
        private void btnUSBConnect_Click(object sender, EventArgs e)
        {
            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;

            if (btnUSBConnect.Text == "Disconnect")
            {
                axCZKEM1.Disconnect();
                bIsConnected = false;
                btnUSBConnect.Text = "Connect";
                btnUSBConnect.Refresh();
                lblState.Text = "Current State:Disconnected";
                Cursor = Cursors.Default;
                return;
            }

            if (rbUSB.Checked == true)//the common USBClient
            {
                iMachineNumber = 1;//In fact,when you are using common USBClient communication,parameter Machinenumber will be ignored,that is any integer will all right.Here we use 1.
                bIsConnected = axCZKEM1.Connect_USB(iMachineNumber);
            }
            else
                if (rbVUSB.Checked == true)//connect the device via the virtual serial port created by USB
                {
                    SearchforUSBCom usbcom = new SearchforUSBCom();
                    string sCom = "";
                    bool bSearch = usbcom.SearchforCom(ref sCom);//modify by Darcy on Nov.26 2009
                    if (bSearch == false)//modify by Darcy on Nov.26 2009
                    {
                        MessageBox.Show("Can not find the virtual serial port that can be used", "Error");
                        Cursor = Cursors.Default;
                        return;
                    }

                    int iPort;
                    for (iPort = 1; iPort < 10; iPort++)
                    {
                        if (sCom.IndexOf(iPort.ToString()) > -1)
                        {
                            break;
                        }
                    }

                    iMachineNumber = Convert.ToInt32(txtMachineSN2.Text.Trim());
                    if (iMachineNumber == 0 || iMachineNumber > 255)
                    {
                        MessageBox.Show("The Machine Number is invalid!", "Error");
                        Cursor = Cursors.Default;
                        return;
                    }

                    int iBaudRate = 115200;//115200 is one possible baudrate value(its value cannot be 0)
                    bIsConnected = axCZKEM1.Connect_Com(iPort, iMachineNumber, iBaudRate);
                }

            if (bIsConnected == true)
            {
                btnUSBConnect.Text = "Disconnect";
                btnUSBConnect.Refresh();
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

        private void rbVUSB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVUSB.Checked == true)
            {
                if (bIsConnected == true)
                {
                    MessageBox.Show("Invalid Operation!", "Error");
                    rbVUSB.Checked = false;
                    return;
                }
                rbUSB.Checked = false;
                txtMachineSN2.Enabled = true;
            }
        }

        private void rbUSB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUSB.Checked == true)
            {
                if (bIsConnected == true)
                {
                    MessageBox.Show("Invalid Operation!", "Error");
                    rbUSB.Checked = false;
                    return;
                }
                rbVUSB.Checked = false;
                txtMachineSN2.Enabled = false;
            }
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
                MessageBox.Show("SetUserGroup,UserID:" + iUserID.ToString()+" UserGrp:"+iUserGrp.ToString(), "Success");
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
        private void btnGetUnlockGroups_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }
            int idwErrorCode = 0;
            string sGroups = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetUnlockGroups(iMachineNumber,ref sGroups))
            {
                txtGroups.Text = sGroups;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Set the unlock groups combination information.　
        private void btnSetUnlockGroups_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (txtGroups.Text.Trim()=="")
            {
                MessageBox.Show("Please input the UnlockGroups first!", "Error");
                return;
            }
            int idwErrorCode = 0;
            string sGroups = txtGroups.Text.Trim();

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetUnlockGroups(iMachineNumber,sGroups))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("SetUnlockGroups, Groups:" + sGroups, "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the time zones used by specified group　
        private void btnGetGroupTZStr_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbGroupIndex.Text.Trim() == "")
            {
                MessageBox.Show("Please input the GroupIndex first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iGroupIndex = Convert.ToInt32(cbGroupIndex.Text.Trim());
            string sTZs = "";
            string sVerifyStyle = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetGroupTZStr(iMachineNumber,iGroupIndex,ref sTZs))//Parameter sTZs is in strings.
            {
                txtTZs.Text = sTZs;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }

            if (axCZKEM1.GetSysOption(iMachineNumber, "GVS" + iGroupIndex.ToString(), out sVerifyStyle))
            {
                cbVerifyStyle.Text = sVerifyStyle;
            }

            Cursor = Cursors.Default;
        }

        //Set the time zones used by specified group　
        private void btnSetGroupTZStr_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbGroupIndex.Text.Trim() == "" || txtTZs.Text.Trim() == "")
            {
                MessageBox.Show("Please input the GroupIndex and TZs first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iGroupIndex = Convert.ToInt32(cbGroupIndex.Text.Trim());
            string sTZs = txtTZs.Text.Trim();//refer to the development manual to learn the format of the time zone(in strings )
            string sVerifyStyle = cbVerifyStyle.Text.Trim();

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetGroupTZStr(iMachineNumber,iGroupIndex,sTZs))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("SetGroupTZStr, GroupIndex:" + iGroupIndex.ToString() + " TZs:" + sTZs, "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }

            // Set Group VerifyStyle
            axCZKEM1.SetSysOption(iMachineNumber, "GVS"+iGroupIndex.ToString(), sVerifyStyle);


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
            if (axCZKEM1.GetUserTZStr(iMachineNumber,iUserID,ref sTZs))//TZs is in strings.
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
            if (txtSet.Text.Trim() == "" || txtSet.Text.Trim() == "set value")
            {
                MessageBox.Show("Please intput the value of wiegand format!","Error");
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
                    int iEnrollNumber = 0;
                    int iEMachineNumber = 0;
                    int iBackupNumber = 0;
                    int iPrivilege = 0;
                    int iEnabled = 0;

                    axCZKEM1.EnableDevice(iMachineNumber, false);
                    axCZKEM1.ReadAllUserID(iMachineNumber);//read all the user information to the memory
                    while (axCZKEM1.GetAllUserID(iMachineNumber, ref iEnrollNumber, ref iEMachineNumber, ref iBackupNumber, ref iPrivilege, ref iEnabled))
                    {
                        cbUserIDGroup.Items.Add(iEnrollNumber);
                        cbUserIDTZ.Items.Add(iEnrollNumber);
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

        private void btnNO_Click(object sender, EventArgs e)
        {
            string Valuestr;
            string sTZ = "00002359000023590000235900002359000023590000235900002359";
            int idwErrorCode = 0;
            if (!bIsConnected)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (axCZKEM1.GetSysOption(iMachineNumber, "~LockFunOn", out Valuestr))
            {
                // Open Advanced Access Control function
                if (Valuestr != "15")
                {
                    axCZKEM1.SetSysOption(iMachineNumber, "~LockFunOn", "15");
                }
            }

            // Set Timezone info as normally open timezone, TZIndex can choose 1-50
            if (axCZKEM1.SetTZInfo(iMachineNumber, 50, sTZ))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }

            string NCTZStr = "50"; // 
            // Set NO
            axCZKEM1.SetGroupTZStr(iMachineNumber, NOGroupIndex, NCTZStr);
            // Close NC
            axCZKEM1.SetGroupTZStr(iMachineNumber, NCGroupIndex, "0");
            MessageBox.Show("Operation success");
        }

        private void btnNC_Click(object sender, EventArgs e)
        {
            string Valuestr;
            string sTZ = "00002359000023590000235900002359000023590000235900002359";
            int idwErrorCode = 0;
            if (!bIsConnected)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (axCZKEM1.GetSysOption(iMachineNumber, "~LockFunOn", out Valuestr))
            {
                // Open Advanced Access Control function
                if (Valuestr != "15")
                {
                    axCZKEM1.SetSysOption(iMachineNumber, "~LockFunOn", "15");
                }
            }

            // Set Timezone info as normally close timezone, TZIndex can choose 1-50
            if (axCZKEM1.SetTZInfo(iMachineNumber, 50, sTZ))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }

            string NCTZStr = "50"; // 
            // Set NC
            axCZKEM1.SetGroupTZStr(iMachineNumber, NCGroupIndex, NCTZStr);
            // Close NO
            axCZKEM1.SetGroupTZStr(iMachineNumber, NOGroupIndex, "0");
            MessageBox.Show("Operation success");
        }

        private void tabPage13_Click(object sender, EventArgs e)
        {

        }

        private void btDeleteUserInfoEx_Click(object sender, EventArgs e)
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

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.DeleteUserInfoEx(iMachineNumber, iUserID))
            {
                MessageBox.Show("DeleteUserInfoEx,UserID:" + iUserID.ToString(), "Success");
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