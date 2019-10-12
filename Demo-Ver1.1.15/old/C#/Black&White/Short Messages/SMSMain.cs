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

namespace ShortMessages
{
    public partial class SMSMain : Form
    {
        public SMSMain()
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

        /***************************************************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.                                      *
        * The operations include setting or getting the short messages/users short messages,deleting short messages/messages of a certain user,*
        * clearing all the short messages/the relationship between users and short messages                                                    *
        * **************************************************************************************************************************************/
        #region Short Messages

        //When the form is loaded,add the current time to the textbox as the start tiem to be edited.
        private void SMSMain_Load(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            txtStartTime.Text = string.Format("{0:g}", dt);
        }

        //Set short messages. 
        //You should input the five parameters:Short Message ID,the tag of the message,the Valid Minutes,the Start Time and the Short Messages Content.
        //If you want to set personal message, you should use function SetUserSMS to establish the correlation between users and short messages.
        private void btnSetSMS_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iSMSID = Convert.ToInt32(cbSMSID.Text.Trim());
            int iTag = 0;
            int iValidMins = 0;
            string sStartTime = "";
            string sContent = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetSMS(iMachineNumber, iSMSID, ref iTag, ref iValidMins, ref sStartTime, ref sContent) == true)
            {
                MessageBox.Show("The ID has existed!Pls change it!", "Error");
                Cursor = Cursors.Default;
                return;
            }

            iSMSID = Convert.ToInt32(cbSMSID.Text.Trim());
            iValidMins = Convert.ToInt32(txtValidMins.Text.Trim());
            sStartTime = txtStartTime.Text.Trim();
            sContent = txtContent.Text.Trim();

            string sTag = cbTag.Text.Trim();
            for (iTag = 253; iTag <= 255; iTag++)
            {
                if (sTag.IndexOf(iTag.ToString()) > -1)
                {
                    break;
                }
            }

            if (axCZKEM1.SetSMS(iMachineNumber, iSMSID, iTag, iValidMins, sStartTime, sContent))
            {
                axCZKEM1.RefreshData(iMachineNumber);//After you have set the short message,you should refresh the data of the device
                MessageBox.Show("Successfully set SMS! SMSType=" + iTag.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" +idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get short messages through the Short Message ID .
        //The returned values of the Short Message includes the tag of the message,the valid time, the start time and its content.
        private void btnGetSMS_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbSMSID.Text.Trim() == "")
            {
                MessageBox.Show("Please input the ID first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iSMSID = Convert.ToInt32(cbSMSID.Text.Trim());
            int iTag = 0;
            int iValidMins = 0;
            string sStartTime = "";
            string sContent = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetSMS(iMachineNumber, iSMSID, ref iTag, ref iValidMins, ref sStartTime, ref sContent))
            {
                cbSMSID.Text = iSMSID.ToString();
                cbTag.Text = iTag.ToString();
                txtValidMins.Text = iValidMins.ToString();

                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(sStartTime);

                txtStartTime.Text = string.Format("{0:g}", dt);//Here show the time for you to edit.(Seconds is not necessary)
                txtContent.Text = sContent;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Set a certain user's corresponding short message 
        //You should input the two parameters: the user's enrollnumber(ID) and the short message's ID.
        private void btnSetUserSMS_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbID.Text.Trim() == "" || cbUserID.Text.Trim() == "")
            {
                MessageBox.Show("Please input the UserID and SMSID first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iSMSID = Convert.ToInt32(cbID.Text.Trim());
            int iTag = 0;
            int iValidMins = 0;
            string sStartTime = "";
            string sContent = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetSMS(iMachineNumber, iSMSID, ref iTag, ref iValidMins, ref sStartTime, ref sContent) == false)
            {
                MessageBox.Show("The SMSID doesn't exist!!", "Error");
                Cursor = Cursors.Default;
                return;
            }

            int iEnrollNumber = Convert.ToInt32(cbUserID.Text.Trim());

            if (axCZKEM1.SetUserSMS(iMachineNumber, iEnrollNumber, iSMSID))
            {
                axCZKEM1.RefreshData(iMachineNumber);//After you have set user short message,you should refresh the data of the device
                MessageBox.Show("Successfully Set user SMS! ", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Delete the short message by its id.
        //You should input the id of the short message that you want to delete
        private void btnDeleteSMS_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iSMSID = Convert.ToInt32(cbID2.Text.Trim());//modify by darcy on Nov. 30 2009
            int iTag = 0;
            int iValidMins = 0;
            string sStartTime = "";
            string sContent = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetSMS(iMachineNumber, iSMSID, ref iTag, ref iValidMins, ref sStartTime, ref sContent) == false)
            {
                MessageBox.Show("The SMS doesn't exist!", "Error");
                Cursor = Cursors.Default;
                return;
            }

            iSMSID = Convert.ToInt32(cbID2.Text.Trim());//the appoited short message id to be deleted

            if (axCZKEM1.DeleteSMS(iMachineNumber, iSMSID))
            {
                axCZKEM1.RefreshData(iMachineNumber);//After you have delete the short message,you should refresh the data of the device
                MessageBox.Show("Successfully Delete corresponding SMS! ", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Delete relativity between the appoited user and the short message relating with the user.
        //You should input the user's id and the short message id relating with the user.
        private void btnDeleteUserSMS_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbID2.Text.Trim() == "" || cbUserID2.Text.Trim() == "")
            {
                MessageBox.Show("Please input the user'id and sms id first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iSMSID = Convert.ToInt32(cbID2.Text.Trim());
            int iEnrollNumber = Convert.ToInt32(cbUserID2.Text.Trim());//modify by Darcy on Nov.23 2009

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.DeleteUserSMS(iMachineNumber, iEnrollNumber, iSMSID))//modify by Darcy on Nov.23 2009
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Successfully Delete user SMS! ", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Clear all the short messages in the device
        private void btnClearSMS_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.ClearSMS(iMachineNumber))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Successfully Clear all the SMSs! ", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Delete relativity between  users and short messages.(It wont delete the short messages themselves)
         private void btnClearUserSMS_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.ClearUserSMS(iMachineNumber))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Successfully Clear all the UserSMS! ", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //add by Darcy on Nov. 23 2009
        //Add the existed userid to DropDownLists.
        bool bAddControl = true;
        private void UserIDTimer_Tick(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                cbUserID.Items.Clear();
                cbUserID2.Items.Clear();
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
                        cbUserID.Items.Add(iEnrollNumber);
                        cbUserID2.Items.Add(iEnrollNumber);
                    }
                    bAddControl = false;
                    axCZKEM1.EnableDevice(iMachineNumber, true);
                }
                return;
            }
        }

        #endregion
      
    }
} 