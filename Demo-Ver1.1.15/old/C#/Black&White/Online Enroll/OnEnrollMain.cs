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
using System.Data.OleDb;

namespace OnlineEnroll
{
    public partial class OnEnrollMain : Form
    {
        public OnEnrollMain()
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

        /**********************************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.                     *
        * This part is for demonstrating how to enroll your fingerprint online and save the templates(binary) to the database.*
        * *********************************************************************************************************************/
        #region OnlineEnroll

        //Make sure you have enrolled the fingerprint templates you will save.
        private int iCanSaveTmp = 0;

        //Enroll a certain user's specified fingerprint template online.
        //It only supports 9.0 fingerprint arithmetic at present.
        private void btnStartEnroll_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (txtUserID.Text.Trim() == "" || cbFingerIndex.Text.Trim() == "")
            {
                MessageBox.Show("UserID,FingerIndex must be inputted first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iUserID = Convert.ToInt32(txtUserID.Text.Trim());
            string sUserID = txtUserID.Text.Trim();
            int iFingerIndex = Convert.ToInt32(cbFingerIndex.Text.Trim());

            axCZKEM1.CancelOperation();
            axCZKEM1.DelUserTmp(iMachineNumber, iUserID, iFingerIndex);
            if (axCZKEM1.StartEnroll(iUserID, iFingerIndex))
            {
                MessageBox.Show("Start to Enroll a new User,UserID=" + iUserID.ToString() + " FingerID=" + iFingerIndex.ToString(), "Start");
                iCanSaveTmp = 1;
                axCZKEM1.StartIdentify();//After enrolling templates,you should let the device into the 1:N verification condition
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }

        }
        #endregion

        #region Save Enrolled FingerPrint Templates to the DataBase(in binary)

        //Save the tempaltes data you have just enrolled.At present,10.0 fingerprint arithmetic is not supported.
        //Here we mainly demonstrate how you can get the binary fingerprint templates from the device and save them into the databuse.
        //If you want to save the templates in strings to the database,you can modify the followding codes.
        private void btnSaveEnrolledTmp_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (iCanSaveTmp == 0)//You haven't enrolled the templates.
            {
                MessageBox.Show("Please enroll the fingerprint templates first!", "Error");
                return;
            }

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

            String connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\data\Templates.mdb";
            OleDbConnection conn = new OleDbConnection(connString);

            int idwFingerIndex=Convert.ToInt32(cbFingerIndex.Text.Trim());
            int idwEnrollNumber = Convert.ToInt32(txtUserID.Text.Trim());
            int iTmpLength = 0;
            string sdwEnrollNumber = txtUserID.Text.Trim();
            byte[] byTmpData=new byte[700];

            axCZKEM1.EnableDevice(iMachineNumber, false);
            Cursor = Cursors.WaitCursor;
            axCZKEM1.ReadAllTemplate(iMachineNumber);
            if (axCZKEM1.GetUserTmp(iMachineNumber, idwEnrollNumber, idwFingerIndex, ref byTmpData[0], ref iTmpLength))
            {
                //If you need to select or delete the data in the database ,you can just define the sql sentences by youself
                string sql = "insert into Template(UserID,FingerID,Template,TmpLen) values('" + idwEnrollNumber + "','" + idwFingerIndex + "','" + byTmpData + "','" + iTmpLength + "')";//自动编号的templateid？
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully save templates to database ! ", "Success");
            }
            else
            {
                MessageBox.Show("Saving templates to database failed !","Error");
            }
            axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
            axCZKEM1.EnableDevice(iMachineNumber, true);
            Cursor = Cursors.Default;
        }
        #endregion

       

    }
} 