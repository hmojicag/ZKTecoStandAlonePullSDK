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
        //Connect the device via the virtual serial port created by USBClient
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

        #endregion

        /********************************************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.                               *
        * This part is for demonstrating the operations of the device information, status, options and other Frequently used  functions.*
        * In this part, there are lots of parameters involved, please refer to development manual first.                                *
        * *******************************************************************************************************************************/
        #region Device Management

        //Set the time length that the device will be Unavailable
        //Here we set the device to be Unavailable for 5 seconds.
        private void btnDisableDeviceWithTimeOut_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            if (axCZKEM1.DisableDeviceWithTimeOut(iMachineNumber,5))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("The device will under working state for 5 seconds!", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
        }

        //Get device's data storage status.For example,the count of administrators, count of users, etc
        //Please refer to our development manual to look over detailed parameters.
        private void btnGetDeviceStatus_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbStatus.Text.Trim() == "" || cbStatus.Text == "Status Type")
            {
                MessageBox.Show("Please choose the corresponding Status number ", "Error");
                return;
            }
            int idwErrorCode = 0;

            int idwValue=0;
            int idwStatus;//1-12
            string sdwStatus = cbStatus.Text.Trim();
            for (idwStatus = 12; idwStatus >0; idwStatus--)
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
                MessageBox.Show("Successfully set the device information","Success");
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

        //Obtain the device' current time.
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

        //Get the date of device's manufacture
        //The function "GetDeviceStrInfo" is different from "GetDeviceInfo".
        private void btnGetDeviceStrInfo_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            int idwInfo=1;//the only possible value
            string sValue="";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetDeviceStrInfo(iMachineNumber,idwInfo,out sValue))
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

        //Get the model of the device.
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

        //Get the Firmware version of the device.
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

        //Get the version of the SDK you are using .
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

        //Get the IP Address of the device.
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

        //Get the MAC Address of the device.
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

        //Get the name of the manufacturer.
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

        //Get the platform of the device.
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

        //Set IP address of the device.
        //You can set a device's IP address by the device's keyboard or the function "SetDeviceIP"
        private void btnSetDeviceIP_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (txtSet.Text.Trim() == "")
            {
                MessageBox.Show("Please input the IP address first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sIP =txtSet.Text.Trim();

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetDeviceIP(iMachineNumber,sIP))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Successfully set IP address! IP=" + sIP, "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Set the MAC address of the device.
        //You can set a device's MAC address by the device's keyboard or the function "SetDeviceMAC"
        private void btnSetDeviceMAC_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (txtSet.Text.Trim() == "")
            {
                MessageBox.Show("Please input the MAC address first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sMAC = txtSet.Text.Trim();

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetDeviceMAC(iMachineNumber,sMAC))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Successfully set MAC address! MAC=" + sMAC, "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Set the password(device terminal) for communication.
        //Only PC terminal' password is the same as device terminal's ,you can connect the device.
        //You can set PC terminal's communication password by the function "SetCommPassword"
        private void btnSetDeviceCommPwd_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (txtSet.Text.Trim() == "")
            {
                MessageBox.Show("Please input the Device communication password first", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iCommKey =Convert.ToInt32(txtSet.Text.Trim());

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetDeviceCommPwd(iMachineNumber,iCommKey))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Successfully set commKey! commKey=" + iCommKey.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Set the password(PC terminal) for communication.
        //Only PC terminal' password is the same as device terminal's,you can connect the device.
        //You can set device terminal's communication password by the function "SetDeviceCommPwd"
        private void btnSetCommPassword_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (txtSet.Text.Trim() == "")
            {
                MessageBox.Show("Please input the computer communication password first", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iCommKey = Convert.ToInt32(txtSet.Text.Trim());

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetCommPassword(iCommKey))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Successfully set computer's commKey! commKey=" + iCommKey.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Set the options' parameters in the device .
        private void btnSetSysOption_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            string sOption = "~PIN2Width";
            string sValue = txtSet.Text.Trim();

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetSysOption(iMachineNumber,sOption,sValue))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Successfully set " + sOption + " ! value=" + sValue, "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Play the specified number of continuous voice.
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

        //Play voice file according to its index.
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

        //Set the beginning and ending of the daylight saving time,when you enable this fuction.
        private void btnSetDaylight_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbSupport.Text.Trim() == "" || txtBeginTime.Text.Trim() == "" || txtEndTime.Text.Trim() == "")
            {
                MessageBox.Show("Support,BeginTime,EndTIme cannnot be null","Error");
                return;
            }
            int idwErrorCode = 0;

            int iSupport=Convert.ToInt32(cbSupport.Text.Trim());
            string sBeginTime = txtBeginTime.Text.Trim();
            string sEndTime = txtEndTime.Text.Trim();

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SetDaylight(iMachineNumber,iSupport,sBeginTime,sEndTime))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("SetDaylight! ", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the information of daylight saving time.
        private void btnGetDaylight_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iSupport = 0;
            string sBeginTime = "";
            string sEndTime = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetDaylight(iMachineNumber,ref iSupport,ref sBeginTime,ref sEndTime))
            {
                cbSupport.Text = iSupport.ToString();
                txtBeginTime.Text = sBeginTime;
                txtEndTime.Text = sEndTime;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Set the holiday.
        //Please refer to development manual to look over detailed parameters.
        private void btnSSR_SetHoliday_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbHolidayID.Text.Trim()==""||cbTZID.Text.Trim()==""||cbBM.Text.Trim()==""||cbBD.Text.Trim()==""||cbEM.Text.Trim()==""||cbED.Text.Trim()=="")
            {
                MessageBox.Show("Please input all the arguments!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iHolidayID = Convert.ToInt32(cbHolidayID.Text.Trim());
            int iTZID = Convert.ToInt32(cbTZID.Text.Trim());//the timezone of the holiday using
            int iBM = Convert.ToInt32(cbBM.Text.Trim());//begin month
            int iBD = Convert.ToInt32(cbBD.Text.Trim());//begin day
            int iEM = Convert.ToInt32(cbEM.Text.Trim());//end month
            int iED = Convert.ToInt32(cbED.Text.Trim());//end day

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SSR_SetHoliday(iMachineNumber, iHolidayID, iBM, iBD, iEM, iED, iTZID))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("SSR_SetHoliday! ", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the holiday according to its id.
        private void btnSSR_GetHoliday_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbHolidayID.Text.Trim() == "" )
            {
                MessageBox.Show("Please input the HolidayID!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iHolidayID = Convert.ToInt32(cbHolidayID.Text.Trim());
            int iTZID = 0;//the timezone of the holiday using
            int iBM = 0;//begining month
            int iBD = 0;//begining day
            int iEM = 0;//ending month
            int iED = 0;//ending day

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SSR_GetHoliday(iMachineNumber, iHolidayID, ref iBM, ref iBD, ref iEM, ref iED, ref iTZID))
            {
                cbTZID.Text = iTZID.ToString();
                cbBM.Text = iBM.ToString();
                cbBD.Text = iBD.ToString();
                cbEM.Text = iEM.ToString();
                cbED.Text = iED.ToString();
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Set the workcode specified Name.
        private void btnSSR_SetWorkCode_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbAWorkCodeID.Text.Trim() == "" || txtName.Text.Trim()=="")
            {
                MessageBox.Show("Please input two corresponding param!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iAWorkCodeID = Convert.ToInt32(cbAWorkCodeID.Text.Trim());
            string sName = txtName.Text.Trim();

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SSR_SetWorkCode(iAWorkCodeID,sName))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("SetWorkCode!Name="+sName, "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the workcode according to its id.
        private void btnSSR_GetWorkCode_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbAWorkCodeID.Text.Trim() == "")
            {
                MessageBox.Show("Please input the WorkCodeID!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iAWorkCodeID = Convert.ToInt32(cbAWorkCodeID.Text.Trim());
            string sName = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SSR_GetWorkCode(iAWorkCodeID,out sName))
            {
                txtName.Text=sName;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Delete the workcode by specified id.
        private void btnSSR_DeleteWorkCode_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbAWorkCodeID.Text.Trim() == "")
            {
                MessageBox.Show("Please input the WorkCodeID!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iAWorkCodeID = Convert.ToInt32(cbAWorkCodeID.Text.Trim());

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SSR_DeleteWorkCode(iAWorkCodeID))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("DeleteWorkCode! ID=" + iAWorkCodeID.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Clear all the workcode in the device.
        private void btnSSR_ClearWorkCode_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SSR_ClearWorkCode())
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("Clear all WorkCode! ", "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Get the configeration of a certain function key.
        //Please refer to development manual to look over detailed parameters.
        private void btnSSR_GetShortkey_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbShortKeyID.Text.Trim()=="")
            {
                MessageBox.Show("Please input ShortKeyID ! ", "Error");
            }
            int idwErrorCode = 0;

            int iShortKeyID = Convert.ToInt32(cbShortKeyID.Text.Trim());
            int iFun = 0;
            int iStateCode = 0;
            string sStateName = "";
            int iAutoChange =0;
            string sTime = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.SSR_GetShortkey(iShortKeyID,ref iFun,ref iStateCode,ref sStateName,ref iAutoChange,ref sTime))
            {
                cbShortKeyFun.Text = iFun.ToString();
                if (iFun == 1)
                {
                    cbStateCode.Text = iStateCode.ToString();
                    txtStateName.Text = sStateName;
                    cbStateAutoChange.Text = iAutoChange.ToString();
                    txtStateAutoChangeTime.Text = sTime;
                }
                else
                {
                    cbStateCode.Text = "";
                    txtStateName.Text = "";
                    cbStateAutoChange.Text = "";
                    txtStateAutoChangeTime.Text = "";
                }
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //when you are setting short key, while the parameter is "ShortKeyFun",it will deal with the data as follows.
        private void cbShortKeyFun_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iFun = Convert.ToInt32(cbShortKeyFun.Text.Trim());

            if (iFun != 1)
            {
                cbStateCode.Enabled = false;
                cbStateAutoChange.Enabled = false;
                txtStateName.Enabled = false;
                txtStateAutoChangeTime.Enabled = false;
            }
            else
            {
                cbStateCode.Enabled = true;
                cbStateAutoChange.Enabled = true;
                txtStateName.Enabled = true;
                txtStateAutoChangeTime.Enabled = true;
            }
            
        }

        //Set a certain function key's configeration.
        //Please refer to development manual to look over detailed parameters.
        private void btnSSR_SetShortkey_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

            if (cbShortKeyID.Text.Trim() == "" || cbShortKeyFun.Text.Trim() == "")
            {
                MessageBox.Show("Please input ShortKeyID and ShortKeyFun ! ", "Error");
                return;
            }
            int idwErrorCode = 0;

            if (cbShortKeyFun.Text.Trim() == "1")
            {
                if (cbStateCode.Text.Trim() == "" || txtStateName.Text.Trim() == "" || cbStateAutoChange.Text.Trim() == "" || txtStateAutoChangeTime.Text.Trim() == "")
                {
                    MessageBox.Show("Please input the following four parameters ");
                    return;
                }
            }

            int iShortKeyID = Convert.ToInt32(cbShortKeyID.Text.Trim());
            int iFun = Convert.ToInt32(cbShortKeyFun.Text.Trim());

            Cursor = Cursors.WaitCursor;
            if (iFun == 1)//if the function key is status key.
            {
                int iStateCode = Convert.ToInt32(cbStateCode.Text.Trim());
                string sStateName = txtStateName.Text.Trim();
                int iAutoChange = Convert.ToInt32(cbStateAutoChange.Text.Trim());
                string sTime = txtStateAutoChangeTime.Text.Trim();
                if (axCZKEM1.SSR_SetShortkey(iShortKeyID, iFun, iStateCode, sStateName, iAutoChange, sTime))
                {
                    axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                    MessageBox.Show("SetShortkey! ShortKeyID="+iShortKeyID.ToString(), "Success");
                }
                else
                {
                    MessageBox.Show("Operation failed!", "Error");
                }
            }
            else
            {
                int iStateCode =0;
                string sStateName = "";
                int iAutoChange = 0;
                string sTime = "";

                if (axCZKEM1.SSR_SetShortkey(iShortKeyID, iFun, iStateCode, sStateName, iAutoChange, sTime))
                {
                    axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                    MessageBox.Show("SetShortkey! ShortKeyID=" + iShortKeyID.ToString(), "Success");
                }
                else
                {
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
                }
            }
            
            Cursor = Cursors.Default;
        }
       
        //Restart the device .
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

        //Power off the device.
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