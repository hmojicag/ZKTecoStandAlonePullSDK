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

namespace Device
{
    public partial class DeviceMain : Form
    {
        public DeviceMain()
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

        /********************************************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.                               *
        * This part is for demonstrating the operations of the device information, status, options and other Frequently used  functions.*
        * In this part, there are lots of parameters involved, please refer to development manual first.                                *
        * *******************************************************************************************************************************/
        #region Device Management

        //Get device's data storage status.For example,the count of administrators, count of users, etc
        //Please refer to our development manual to look over detailed parameters.
        private void btnGetDeviceStatus_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbStatus.Text.Trim() == "" || cbStatus.Text== "Status Type")
            {
                MessageBox.Show("Please choose the corresponding Status number ", "Error");
                return;
            }
            int idwErrorCode = 0;

            int idwValue=0;
            int idwStatus;//1-12,21,22
            string sdwStatus = cbStatus.Text.Trim();
            for (idwStatus = 22; idwStatus > 0; idwStatus--)////modify by Darcy on Nov.24 2009
            {
                if (sdwStatus.IndexOf(idwStatus.ToString()) > -1)
                {
                    break;
                }
            }

            if (axCZKEM1.GetDeviceStatus(iMachineNumber, idwStatus, ref idwValue))
            {
                txtGetDeviceStatus.Text = idwValue.ToString();
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
        }

        //Get the device parameters
        private void btnGetDeviceInfo_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbInfo1.Text.Trim() == "" || cbInfo1.Text == "Info Type")
            {
                MessageBox.Show("Please choose the corresponding Info number ","Error");
                return;
            }
            int idwErrorCode = 0;

            int ivalue=0;
            int idwInfo;
            string sdwInfo = cbInfo1.Text.Trim();
            for (idwInfo = 68; idwInfo > 0; idwInfo--)
            {
                if (sdwInfo.IndexOf(idwInfo.ToString()) > -1)
                {
                    break;
                }
            }

            if (axCZKEM1.GetDeviceInfo(iMachineNumber,idwInfo,ref ivalue))
            {
                txtGetDeviceInfo.Text = ivalue.ToString();
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
        }

        //Set the device parameters
        private void btnSetDeviceInfo_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbInfo2.Text.Trim() == "" || cbSetDeviceInfo.Text.Trim() == "" || cbInfo2.Text == "Info Type")
            {
                MessageBox.Show("Please choose the corresponding Info number and its value ", "Error");
                return;
            }
            int idwErrorCode = 0;

            int idwValue = 0;
            int idwInfo;
            string sdwInfo = cbInfo2.Text.Trim();
            for (idwInfo = 20; idwInfo > 0; idwInfo--)
            {
                if (sdwInfo.IndexOf(idwInfo.ToString()) > -1)
                {
                    break;
                }
            }
            idwValue =Convert.ToInt32(cbSetDeviceInfo.Text.Trim());
            if (axCZKEM1.SetDeviceInfo(iMachineNumber,idwInfo,idwValue))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Successfully set the device information", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
        }

        //Synchronize the device time as the computer's.
        private void btnSetDeviceTime_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            Cursor=Cursors.WaitCursor;
            if (axCZKEM1.SetDeviceTime(iMachineNumber))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Successfully set the time of the machine and the terminal to sync PC!", "Success");
                int idwYear = 0;
                int idwMonth = 0;
                int idwDay = 0;
                int idwHour = 0;
                int idwMinute = 0;
                int idwSecond = 0;
                if (axCZKEM1.GetDeviceTime(iMachineNumber, ref idwYear, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute, ref idwSecond))//show the time
                {
                    txtGetDeviceTime.Text = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString();
                }
             }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor=Cursors.Default;
        }

        //Custumize device's time as you want.
        private void btnSetDeviceTime2_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            int idwYear=Convert.ToInt32(cbYear.Text.Trim());
            int idwMonth=Convert.ToInt32(cbMonth.Text.Trim());
            int idwDay=Convert.ToInt32(cbDay.Text.Trim());
            int idwHour=Convert.ToInt32(cbHour.Text.Trim());
            int idwMinute=Convert.ToInt32(cbMinute.Text.Trim());
            int idwSecond=Convert.ToInt32(cbSecond.Text.Trim());

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetDeviceTime2(iMachineNumber,idwYear,idwMonth,idwDay,idwHour,idwMinute,idwSecond))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Successfully set the time of the machine as you have set!", "Error");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Obtain the device' current time
        private void btnGetDeviceTime_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            int idwYear=0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetDeviceTime(iMachineNumber,ref idwYear,ref idwMonth,ref idwDay,ref idwHour,ref idwMinute,ref idwSecond))
            {
                txtGetDeviceTime.Text = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString();
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the device's serial number
        private void btnGetSerialNumber_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sdwSerialNumber = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetSerialNumber(iMachineNumber,out sdwSerialNumber))
            {
                txtShow.Text = sdwSerialNumber;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the model of the device
        private void btnGetProductCode_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;
            
            string sProductCode = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetProductCode(iMachineNumber,out sProductCode))
            {
                txtShow.Text = sProductCode;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the Firmware version of the device
        private void btnGetFirmwareVersion_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sVersion= "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetFirmwareVersion(iMachineNumber,ref sVersion))
            {
                txtShow.Text = sVersion;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the version of the SDK you are using 
        private void btnGetSDKVersion_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sVersion = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetSDKVersion(ref sVersion))
            {
                txtShow.Text = sVersion;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the IP Address of the device
        private void btnGetDeviceIP_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sIP = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetDeviceIP(iMachineNumber,ref sIP))
            {
                txtShow.Text = sIP;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the MAC Address of the device
        private void btnGetDeviceMAC_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sMAC = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetDeviceMAC(iMachineNumber,ref sMAC))
            {
                txtShow.Text = sMAC;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Make sure whether the machine supports the RF card function.
        private void btnGetCardFun_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iCardFun=0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetCardFun(iMachineNumber,ref iCardFun))
            {
                txtShow.Text = iCardFun.ToString();
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Query the device's current state
        //Please refer to our development manual for more detailed parameters information.
        private void btnQueryState_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iState = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.QueryState(ref iState))
            {
                txtShow.Text = iState.ToString();
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the name of the manufacturer
        private void btnGetVendor_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sVendor="";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetVendor(ref sVendor))
            {
                txtShow.Text = sVendor;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the platform of the device
        private void btnGetPlatform_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sPlatform = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetPlatform(iMachineNumber,ref sPlatform))
            {
                txtShow.Text = sPlatform;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the parameters of the device's options.
        private void btnGetSysOption_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sOption = "~PIN2Width";//You should input this parameter by yourself . 
            string sValue="";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetSysOption(iMachineNumber,sOption,out sValue))
            {
                txtShow.Text = sValue;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Play the specified number of continuous voice
        private void btnPlayVoice_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbPosition.Text.Trim() == "" || cbLength.Text.Trim()=="")
            {
                MessageBox.Show("Position and Length cannot be null!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iPosition = Convert.ToInt32(cbPosition.Text.Trim());
            int iLength = Convert.ToInt32(cbLength.Text.Trim());

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.PlayVoice(iPosition,iLength))
            {
                MessageBox.Show("Play Voice from "+iPosition.ToString()+" to "+iLength.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Play voice file according to its index
        private void btnPlayVoiceByIndex_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbIndex.Text.Trim() == "")
            {
                MessageBox.Show("Position(Voice Index) cannot be null!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iIndex = Convert.ToInt32(cbIndex.Text.Trim());
            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.PlayVoiceByIndex(iIndex))
            {
                MessageBox.Show("PlayVoiceByIndex " + iIndex.ToString() , "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Restart the device 
        private void btnRestartDevice_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.RestartDevice(iMachineNumber) == true)
            {
                MessageBox.Show("The device will restart!", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;

        }

        //Power off the device
        private void btnPowerOffDevice_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.PowerOffDevice(iMachineNumber))
            {
                MessageBox.Show("PowerOffDevice", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }
        #endregion

    }
} 