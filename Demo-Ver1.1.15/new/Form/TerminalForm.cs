using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using System.Data.SQLite;
using System.Threading;
using System.Management;

namespace StandaloneSDKDemo
{
    public partial class TerminalForm : Form
    {
        public TerminalForm(Main Parent)
        {
            InitializeComponent();
            Terminal = Parent;
        }

        private Main Terminal;

        #region ConnetDevice
        /********************************************************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.                                           *
        * This part is for demonstrating the communication with your device.There are 3 communication ways: "TCP/IP","Serial Port" and "USB Client".*
        * The communication way which you can use during to the model of the device.                                                                 *
        * *******************************************************************************************************************************************/

        //If your device supports the TCP/IP communications, you can refer to this.
        //when you are using the TCP/IP communication,you can distinguish different devices by their IP address.

        private void getDeviceInfo()
        {
            string sFirmver = "";
            string sMac = "";
            string sPlatform = "";
            string sSN = "";
            string sProductTime = "";
            string sDeviceName = "";
            int iFPAlg = 0;
            int iFaceAlg = 0;
            string sProducter = "";

            Terminal.SDK.sta_GetDeviceInfo(Terminal.lbSysOutputInfo, out sFirmver, out sMac, out sPlatform, out sSN, out sProductTime, out sDeviceName, out iFPAlg, out iFaceAlg, out sProducter);
            txtFirmwareVer.Text = sFirmver;
            txtMac.Text = sMac;
            txtSerialNumber.Text = sSN;
            txtPlatForm.Text = sPlatform;
            txtDeviceName.Text = sDeviceName;
            txtFPAlg.Text = iFPAlg.ToString().Trim();
            txtFaceAlg.Text = iFaceAlg.ToString().Trim();
            txtManufacturer.Text = sProducter;
            txtManufactureTime.Text = sProductTime;
        }

        private void getCapacityInfo()
        {
            int adminCnt = 0;
            int userCount = 0;
            int fpCnt = 0;
            int recordCnt = 0;
            int pwdCnt = 0;
            int oplogCnt = 0;
            int faceCnt = 0;
            Terminal.SDK.sta_GetCapacityInfo(Terminal.lbSysOutputInfo, out adminCnt, out userCount, out fpCnt, out recordCnt, out pwdCnt, out oplogCnt, out faceCnt);

            txtAdminCnt.Text = adminCnt.ToString();
            txtUserCnt.Text = userCount.ToString();
            txtFPCnt.Text = fpCnt.ToString();
            txtAttLogCnt.Text = recordCnt.ToString();
            txtPWDCnt.Text = pwdCnt.ToString();
            txtOpLogCnt.Text = oplogCnt.ToString();
            txtFaceCnt.Text = faceCnt.ToString();
        }

        private void btnTCPConnect_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int ret = Terminal.SDK.sta_ConnectTCP(Terminal.lbSysOutputInfo, txtIP.Text.Trim(), txtPort.Text.Trim(), txtCommKey1.Text.Trim());

            if (Terminal.SDK.GetConnectState())
            {
                Terminal.SDK.sta_getBiometricType();
            }
            if (ret == 1)
            {        
                this.txtIP.ReadOnly = true;
                this.txtPort.ReadOnly = true;
                this.txtCommKey1.ReadOnly = true;

                this.btnRSConnect.Enabled = false;
                this.btnUSBConnect.Enabled = false;

                this.btnGetSystemInfo.Enabled = true;
                this.btnGetDataInfo.Enabled = true;

                getCapacityInfo();
                getDeviceInfo();

                btnTCPConnect.Text = "DisConnect";
                btnTCPConnect.Refresh();
               
            }
            else if (ret == -2)
            {
                btnTCPConnect.Text = "Connect";
                btnTCPConnect.Refresh();
                this.txtDeviceID1.ReadOnly = false;
                this.txtIP.ReadOnly = false;
                this.txtPort.ReadOnly = false;
                this.txtCommKey1.ReadOnly = false;

                this.btnRSConnect.Enabled = true;
                this.btnUSBConnect.Enabled = true;

                this.btnGetSystemInfo.Enabled = false;
                this.btnGetDataInfo.Enabled = false;
            }
            Cursor = Cursors.Default;
        }

        private void btnRSConnect_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int ret = Terminal.SDK.sta_ConnectRS(Terminal.lbSysOutputInfo, txtDeviceID1.Text.Trim(), cbSerialPort.Text.Trim(), cbBaudRate.Text.Trim(), txtCommKey2.Text.Trim());
            if (ret == 1)
            {
                this.txtDeviceID1.ReadOnly = true;
                this.txtCommKey2.ReadOnly = true;
                this.cbSerialPort.Enabled = false;
                this.cbBaudRate.Enabled = false;

                this.btnTCPConnect.Enabled = false;
                this.btnUSBConnect.Enabled = false;

                this.btnGetSystemInfo.Enabled = true;
                this.btnGetDataInfo.Enabled = true;

                getCapacityInfo();
                getDeviceInfo();

                btnRSConnect.Text = "DisConnect";
                btnRSConnect.Refresh();
            }
            else if (ret == -2)
            {
                btnRSConnect.Text = "Connect";
                btnRSConnect.Refresh();
                this.txtDeviceID1.ReadOnly = false;
                this.txtCommKey2.ReadOnly = false;
                this.cbSerialPort.Enabled = true;
                this.cbBaudRate.Enabled = true;

                this.btnTCPConnect.Enabled = true;
                this.btnUSBConnect.Enabled = true;

                this.btnGetSystemInfo.Enabled = false;
                this.btnGetDataInfo.Enabled = false;
            }
            Cursor = Cursors.Default;
        }

        private void btnUSBConnect_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int ret = Terminal.SDK.sta_ConnectUSB(Terminal.lbSysOutputInfo, txtDeviceID2.Text.Trim(), txtCommKey3.Text.Trim());
            if (ret == 1)
            {
                this.txtDeviceID2.ReadOnly = true;
                this.txtCommKey3.ReadOnly = true;

                this.btnTCPConnect.Enabled = false;
                this.btnRSConnect.Enabled = false;

                this.btnGetSystemInfo.Enabled = true;
                this.btnGetDataInfo.Enabled = true;

                getCapacityInfo();
                getDeviceInfo();

                btnUSBConnect.Text = "DisConnect";
                btnUSBConnect.Refresh();
            }
            else if (ret == -2)
            {
                btnUSBConnect.Text = "Connect";
                btnUSBConnect.Refresh();
                this.txtDeviceID2.ReadOnly = false;
                this.txtCommKey3.ReadOnly = false;

                this.btnTCPConnect.Enabled = true;
                this.btnRSConnect.Enabled = true;

                this.btnGetSystemInfo.Enabled = false;
                this.btnGetDataInfo.Enabled = false;
            }
            Cursor = Cursors.Default;
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCommKey1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDeviceID1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCommKey2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDeviceID2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCommKey3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        private void btnGetSystemInfo_Click(object sender, EventArgs e)
        {
            getDeviceInfo();
        }

        private void btnGetDataInfo_Click(object sender, EventArgs e)
        {
            getCapacityInfo();
        }

    }
}
