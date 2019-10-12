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

namespace UserInfo
{
    public partial class UserInfoMain : Form
    {
        public UserInfoMain()
        {
            InitializeComponent();
        }

        //Create Standalone SDK class dynamicly.
        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();

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

        /*************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.*
        * This part is for demonstrating operations with user(download/upload/delete/clear/modify).      *
        * ************************************************************************************************/
        #region UserInfo

        //Download user's 9.0 arithmetic fingerprint template(in strings)　
        private void btnDownloadTmp9_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            //judge whether the device supports 9.0 fingerprint arithmetic
            string sOption = "~ZKFPVersion";
            string sValue = "";
            if (axCZKEM1.GetSysOption(iMachineNumber, sOption, out sValue))
            {
                if (sValue == "10")
                {
                    MessageBox.Show("Your device is not using 9.0 arithmetic!", "Error");
                    return;
                }
            }

            int idwEnrollNumber = 0;
            string sName = "";
            string sPassword = "";
            int iPrivilege = 0;
            bool bEnabled = false;
           
            int idwFingerIndex;
            string sTmpData = "";
            int iTmpLength = 0;

            lvDownload.Items.Clear();
            lvDownload.BeginUpdate();
            axCZKEM1.EnableDevice(iMachineNumber, false);
            Cursor = Cursors.WaitCursor;

            axCZKEM1.ReadAllUserID(iMachineNumber);//read all the user information to the memory
            axCZKEM1.ReadAllTemplate(iMachineNumber);//read all the users' fingerprint templates to the memory
            while (axCZKEM1.GetAllUserInfo(iMachineNumber, ref idwEnrollNumber, ref sName, ref sPassword, ref iPrivilege, ref bEnabled))//get all the users' information from the memory
            {
                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (axCZKEM1.GetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFingerIndex, ref sTmpData, ref iTmpLength))//get the corresponding templates string and length from the memory
                    {
                        ListViewItem list = new ListViewItem();
                        list.Text = idwEnrollNumber.ToString();
                        list.SubItems.Add(sName);
                        list.SubItems.Add(idwFingerIndex.ToString());
                        list.SubItems.Add(sTmpData);
                        list.SubItems.Add(iPrivilege.ToString());
                        list.SubItems.Add(sPassword);
                        if (bEnabled == true)
                        {
                            list.SubItems.Add("true");
                        }
                        else
                        {
                            list.SubItems.Add("false");
                        }
                        lvDownload.Items.Add(list);
                    }
                }
            }
            lvDownload.EndUpdate();
            axCZKEM1.EnableDevice(iMachineNumber, true);
            Cursor = Cursors.Default;
        }

        //Upload the 9.0 fingerprint arithmetic templates to the device(in strings) in batches.　
        private void btnBatchUpdate_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (lvDownload.Items.Count == 0)
            {
                MessageBox.Show("There is no data to upload!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int idwEnrollNumber = 0;
            string sName = "";
            int idwFingerIndex = 0;
            string sTmpData = "";
            int iPrivilege = 0;
            string sPassword = "";
            string sEnabled = "";
            bool bEnabled = false;

            int iUpdateFlag = 1;

            Cursor = Cursors.WaitCursor;
            axCZKEM1.EnableDevice(iMachineNumber, false);
            if (axCZKEM1.BeginBatchUpdate(iMachineNumber, iUpdateFlag))//create memory space for batching data
            {
                int iLastEnrollNumber = 0;//the former enrollnumber you have upload(define original value as 0)
                for (int i = 0; i < lvDownload.Items.Count; i++)
                {
                    idwEnrollNumber = Convert.ToInt32(lvDownload.Items[i].SubItems[0].Text.Trim());
                    sName = lvDownload.Items[i].SubItems[1].Text.Trim();
                    idwFingerIndex = Convert.ToInt32(lvDownload.Items[i].SubItems[2].Text.Trim());
                    sTmpData = lvDownload.Items[i].SubItems[3].Text.Trim();
                    iPrivilege = Convert.ToInt32(lvDownload.Items[i].SubItems[4].Text.Trim());
                    sPassword = lvDownload.Items[i].SubItems[5].Text.Trim();

                    sEnabled = lvDownload.Items[i].SubItems[6].Text.Trim();

                    if (sEnabled == "true")
                    {
                        bEnabled = true;
                    }
                    else
                    {
                        bEnabled = false;
                    }

                    if (idwEnrollNumber != iLastEnrollNumber)//identify whether the user information(except fingerprint templates) has been uploaded
                    {
                        if (axCZKEM1.SetUserInfo(iMachineNumber, idwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload user information to the memory
                        {
                            axCZKEM1.SetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFingerIndex, sTmpData);//upload templates information to the memory
                        }
                        else
                        {
                            axCZKEM1.GetLastError(ref idwErrorCode);
                            axCZKEM1.EnableDevice(iMachineNumber, true);
                            Cursor = Cursors.Default;
                            MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
                            return;
                        }
                    }
                    else//the current fingerprint and the former one belongs the same user,that is ,one user has more than one template
                    {
                        axCZKEM1.SetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFingerIndex, sTmpData);//upload tempates information to the memory
                    }
                    iLastEnrollNumber = idwEnrollNumber;//change the value of iLastEnrollNumber dynamicly
                }
            }
            axCZKEM1.BatchUpdate(iMachineNumber);//upload all the information in the memory
            axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
            Cursor = Cursors.Default;
            axCZKEM1.EnableDevice(iMachineNumber, true);
            MessageBox.Show("Successfully upload fingerprint templates in batches , " + "total:" + lvDownload.Items.Count.ToString(), "Success");
        }

        //Upload the 9.0 fingerprint arithmetic templates one by one(in strings)　
        private void btnUpload9_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (lvDownload.Items.Count == 0)
            {
                MessageBox.Show("There is no data to upload!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int idwEnrollNumber = 0;
            string sName = "";
            int idwFingerIndex = 0;
            string sTmpData = "";
            int iPrivilege = 0;
            string sPassword = "";
            string sEnabled = "";
            bool bEnabled = false;

            Cursor = Cursors.WaitCursor;

            axCZKEM1.EnableDevice(iMachineNumber, false);
            for (int i = 0; i < lvDownload.Items.Count; i++)
            {
                idwEnrollNumber = Convert.ToInt32(lvDownload.Items[i].SubItems[0].Text.Trim());
                sName = lvDownload.Items[i].SubItems[1].Text.Trim();
                idwFingerIndex = Convert.ToInt32(lvDownload.Items[i].SubItems[2].Text.Trim());
                sTmpData = lvDownload.Items[i].SubItems[3].Text.Trim();
                iPrivilege = Convert.ToInt32(lvDownload.Items[i].SubItems[4].Text.Trim());
                sPassword = lvDownload.Items[i].SubItems[5].Text.Trim();

                sEnabled = lvDownload.Items[i].SubItems[6].Text.Trim();

                if (sEnabled == "true")
                {
                    bEnabled = true;
                }
                else
                {
                    bEnabled = false;
                }

                if (axCZKEM1.SetUserInfo(iMachineNumber, idwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload user information to the device
                {
                    axCZKEM1.SetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFingerIndex, sTmpData);//upload templates information to the device
                }
                else
                {
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    Cursor = Cursors.Default;
                    axCZKEM1.EnableDevice(iMachineNumber, true);
                    MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
                    return;
                }
            }

            axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
            Cursor = Cursors.Default;
            axCZKEM1.EnableDevice(iMachineNumber, true);
            MessageBox.Show("Successfully Upload fingerprint templates, " + "total:" + lvDownload.Items.Count.ToString(), "Success");
        }

        //Delete a certain user's fingerprint template of specified fingerprint index
        //You shuold input the the user id and fingerprint index you will delete
        private void btnDelUserTmp_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbUserIDTmp.Text.Trim()==""||cbFingerIndex.Text.Trim()=="")
            {
                MessageBox.Show("Please input the UserID and FingerIndex first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iUserID = Convert.ToInt32(cbUserIDTmp.Text.Trim());
            int iFingerIndex = Convert.ToInt32(cbFingerIndex.Text.Trim());

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.DelUserTmp(iMachineNumber,iUserID,iFingerIndex))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("DelUserTmp,UserID:" +iUserID.ToString() + " FingerIndex:" + iFingerIndex.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Clear all the fingerprint templates in the device(While the parameter DataFlag  of the Function "ClearData" is 2 )
        private void btnClearDataTmps_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iDataFlag = 2;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.ClearData(iMachineNumber,iDataFlag))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Clear all the fingerprint templates!" , "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }
  
        //Delete all the user information in the device,while the related fingerprint templates will be deleted either. 
        //(While the parameter DataFlag  of the Function "ClearData" is 5 )
        private void btnClearDataUserInfo_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iDataFlag = 5;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.ClearData(iMachineNumber, iDataFlag))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Clear all the UserInfo data!", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Delete a kind of data that some user has enrolled
        //The range of the Backup Number is from 0 to 9 and the specific meaning of Backup number is described in the development manual,pls refer to it.
        private void btnDeleteEnrollData_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbUserIDDE.Text.Trim() == "" || cbBackupDE.Text.Trim() == "")
            {
                MessageBox.Show("Please input the UserID and BackupNumber first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iUserID = Convert.ToInt32(cbUserIDDE.Text.Trim());
            int iBackupNumber = Convert.ToInt32(cbBackupDE.Text.Trim());

            Cursor = Cursors.WaitCursor;
            axCZKEM1.EnableDevice(iMachineNumber, false);
            if (axCZKEM1.DeleteEnrollData(iMachineNumber, iUserID, 1, iBackupNumber))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("DeleteEnrollData,UserID=" + iUserID.ToString() + " BackupNumber=" + iBackupNumber.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);
            Cursor = Cursors.Default;
        }

        //Clear all the administrator privilege(not clear the administrators themselves)
        private void btnClearAdministrators_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.ClearAdministrators(iMachineNumber))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Successfully clear administrator privilege from teiminal!", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //add by Darcy on Nov.23 2009
        //Download user's 9.0 arithmetic fingerprint template in batches.(in strings)　
        private void btnDownloadTmpBatch9_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            //judge whether the device supports 9.0 fingerprint arithmetic
            string sOption = "~ZKFPVersion";
            string sValue = "";
            //if (axCZKEM1.GetSysOption(iMachineNumber, sOption, out sValue))
            //{
            //    if (sValue == "10")
            //    {
            //        MessageBox.Show("Your device is not using 9.0 arithmetic!", "Error");
            //        return;
            //    }
            //}

            int idwEnrollNumber = 0;
            string sName = "";
            string sPassword = "";
            int iPrivilege = 0;
            bool bEnabled = false;

            int idwFigerIndex;
            string sTmpData = "";
            int iTmpLength = 0;
            int iUpdateFlag = 1;

            lvDownload.Items.Clear();
            lvDownload.BeginUpdate();
            axCZKEM1.EnableDevice(iMachineNumber, false);
            Cursor = Cursors.WaitCursor;
            axCZKEM1.BeginBatchUpdate(iMachineNumber, 1);//create memory space for batching data
            axCZKEM1.ReadAllUserID(iMachineNumber);//read all the user information to the memory
            axCZKEM1.ReadAllTemplate(iMachineNumber);//read all the users' fingerprint templates to the memory
            while (axCZKEM1.GetAllUserInfo(iMachineNumber, ref idwEnrollNumber, ref sName, ref sPassword, ref iPrivilege, ref bEnabled))//get all the users' information from the memory
            {
                for (idwFigerIndex = 0; idwFigerIndex < 10; idwFigerIndex++)
                {
                    if (axCZKEM1.GetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFigerIndex, ref sTmpData, ref iTmpLength))//get the corresponding templates string and length from the memory
                    {
                        ListViewItem list = new ListViewItem();
                        list.Text = idwEnrollNumber.ToString();
                        list.SubItems.Add(sName);
                        list.SubItems.Add(idwFigerIndex.ToString());
                        list.SubItems.Add(sTmpData);
                        list.SubItems.Add(iPrivilege.ToString());
                        list.SubItems.Add(sPassword);
                        if (bEnabled == true)
                        {
                            list.SubItems.Add("true");
                        }
                        else
                        {
                            list.SubItems.Add("false");
                        }
                        lvDownload.Items.Add(list);
                    }
                }
            }
            lvDownload.EndUpdate();
            axCZKEM1.BatchUpdate(iMachineNumber);//download all the information in the memory
            axCZKEM1.EnableDevice(iMachineNumber, true);
            Cursor = Cursors.Default;
        }


        //add by Darcy on Nov.23 2009
        //Add the exsited userid to DropDownLists.
        bool bAddControl = true;
        private void UserIDTimer_Tick(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                cbUserIDDE.Items.Clear();
                cbUserIDTmp.Items.Clear();
                cbEnableUserID.Items.Clear();
                cbModifyPrivilegeUserID.Items.Clear();
                cbGetEnrollDataUserID.Items.Clear();

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
                        cbUserIDDE.Items.Add(iEnrollNumber);
                        cbUserIDTmp.Items.Add(iEnrollNumber);
                        cbEnableUserID.Items.Add(iEnrollNumber);
                        cbModifyPrivilegeUserID.Items.Add(iEnrollNumber);
                        cbGetEnrollDataUserID.Items.Add(iEnrollNumber);
                    }
                    bAddControl = false;
                    axCZKEM1.EnableDevice(iMachineNumber, true);
                }
                return;
            }
        }
        #endregion

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void UserInfoMain_Load(object sender, EventArgs e)
        {

        }

        private void btnEnableUser_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbEnableUserID.Text.Trim() == "" || this.cbEnable.Text.Trim() == "")
            {
                MessageBox.Show("Please input the UserID and Flag first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iUserID = Convert.ToInt32(cbEnableUserID.Text.Trim());
            bool iFlag = this.cbEnable.Text.Equals("true") ? true : false;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.EnableUser(iMachineNumber, iUserID, 0,0,iFlag))
            {

                MessageBox.Show("EnableUser,UserID:" + iUserID.ToString() + " iFlag:" + iFlag.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        private void btModifyPrivilege_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbModifyPrivilegeUserID.Text.Trim() == "" || this.cbPrivilegeFlag.Text.Trim() == "")
            {
                MessageBox.Show("Please input the UserID and Flag first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iUserID = Convert.ToInt32(cbModifyPrivilegeUserID.Text.Trim());
            int iFlag = Convert.ToInt32(cbPrivilegeFlag.Text.Trim());

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.ModifyPrivilege(iMachineNumber, iUserID, 0, 0, iFlag))
            {

                MessageBox.Show("ModifyPrivilege,UserID:" + iUserID.ToString() + " iFlag:" + iFlag.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        int sPassword = 0;
        int iPrivilege = 0;
        string sTmpData = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbGetEnrollDataUserID.Text.Trim() == "" || this.cbGetEnrollDataFingerindex.Text.Trim() == "")
            {
                MessageBox.Show("Please input the UserID and Fingerindex first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iUserID = Convert.ToInt32(cbGetEnrollDataUserID.Text.Trim());
            int iFlag = Convert.ToInt32(cbGetEnrollDataFingerindex.Text.Trim());

            Cursor = Cursors.WaitCursor;
            lvDownload.Items.Clear();
            if (axCZKEM1.GetEnrollDataStr(iMachineNumber, iUserID, iMachineNumber, iFlag, ref iPrivilege, ref sTmpData, ref sPassword))
            {
                ListViewItem list = new ListViewItem();
                list.Text = iUserID.ToString();
                list.SubItems.Add("");
                list.SubItems.Add(iFlag.ToString());
                list.SubItems.Add(sTmpData);
                list.SubItems.Add(iPrivilege.ToString());
                list.SubItems.Add(sPassword.ToString());
                list.SubItems.Add("");
               
                lvDownload.Items.Add(list);
                //MessageBox.Show("ModifyPrivilege,UserID:" + iUserID.ToString() + " iFlag:" + iFlag.ToString(), "Success");

                this.btSetEnrollDataStr.Enabled = true;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        private void btSetEnrollDataStr_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbGetEnrollDataUserID.Text.Trim() == "" || this.cbGetEnrollDataFingerindex.Text.Trim() == "")
            {
                MessageBox.Show("Please input the UserID and Fingerindex first!", "Error");
                return;
            }
            int idwErrorCode = 0;
            

            int iUserID = Convert.ToInt32(cbGetEnrollDataUserID.Text.Trim());
            int iFlag = Convert.ToInt32(cbGetEnrollDataFingerindex.Text.Trim());

            Cursor = Cursors.WaitCursor;
            lvDownload.Items.Clear();
            if (axCZKEM1.SetEnrollDataStr(iMachineNumber, iUserID, iMachineNumber, iFlag,  iPrivilege,  sTmpData,  sPassword))
            {

                MessageBox.Show("SetEnrollDataStr,UserID:" + iUserID.ToString() + " iFlag:" + iFlag.ToString(), "Success");

                this.btSetEnrollDataStr.Enabled = true;
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