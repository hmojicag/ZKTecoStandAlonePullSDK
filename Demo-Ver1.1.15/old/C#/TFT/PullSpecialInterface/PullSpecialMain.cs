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

namespace PullSpecial
{
    public partial class PullSpecialMain : Form
    {
        public PullSpecialMain()
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

        public string devtablename = "";
        private void cmbdevtable_DropDownClosed(object sender, EventArgs e)
        {
            //string devtablename = "";
            if (devtablename == "")
            {
                devtablename = this.cmbdevtable.Items[0].ToString();
            }
            else
            {
                devtablename = this.cmbdevtable.SelectedItem.ToString();
            }
            if (string.Equals(devtablename, "user"))
            {
                this.txtdevdata.Text = "CardNo\tPin\tPassword\tGroup\tStartTime\tEndTime";
                this.cmbfil.Items.Clear();
                this.cmbfil.Items.Add("CardNo");
                this.cmbfil.Items.Add("Pin");
                this.cmbfil.Items.Add("Password");
                this.cmbfil.Items.Add("Group");
                this.cmbfil.Items.Add("StartTime");
                this.cmbfil.Items.Add("EndTime");
                this.cmbfil.SelectedIndex = 0;
                this.txtfilval.Text = "1";
            }
            else if (string.Equals(devtablename, "userauthorize"))
            {
                this.txtdevdata.Text = "Pin\tAuthorizeTimezoneId\tAuthorizeDoorId";
                this.cmbfil.Items.Clear();
                this.cmbfil.Items.Add("Pin");
                this.cmbfil.Items.Add("AuthorizeTimezoneId");
                this.cmbfil.Items.Add("AuthorizeDoorId");
                this.cmbfil.SelectedIndex = 0;
                this.txtfilval.Text = "1";
            }
            else if (string.Equals(devtablename, "holiday"))
            {
                this.txtdevdata.Text = "Holiday\tHolidayType\tLoop";
                this.cmbfil.Items.Clear();
                this.cmbfil.Items.Add("Holiday");
                this.cmbfil.Items.Add("HolidayType");
                this.cmbfil.Items.Add("Loop");
                this.cmbfil.SelectedIndex = 0;
                this.txtfilval.Text = "20110101";
            }
            else if (string.Equals(devtablename, "timezone"))
            {
                this.txtdevdata.Text = "TimezoneId\tSunTime1\tSunTime2\tSunTime3\tMonTime1\tMonTime2\tMonTime3\tTueTime1\tTueTime2\tTueTime3\tWedTime1\tWedTime2\tWedTime3\tThuTime1\tThuTime2\tThuTime3\tFriTime1\tFriTime2\tFriTime3\tSatTime1\tSatTime2\tSatTime3\tHol1Time1\tHol1Time2\tHol1Time3\tHol2Time1\tHol2Time2\tHol2Time3\tHol3Time1\tHol3Time2\tHol3Time3";
                this.cmbfil.Items.Clear();
                this.cmbfil.Items.Add("TimezoneId");
                this.cmbfil.Items.Add("SunTime1");
                this.cmbfil.Items.Add("SunTime2");
                this.cmbfil.Items.Add("SunTime3");
                this.cmbfil.Items.Add("MonTime1");
                this.cmbfil.Items.Add("MonTime2");
                this.cmbfil.Items.Add("MonTime3");
                this.cmbfil.Items.Add("TueTime1");
                this.cmbfil.Items.Add("TueTime2");
                this.cmbfil.Items.Add("TueTime3");
                this.cmbfil.Items.Add("WedTime1");
                this.cmbfil.Items.Add("WedTime2");
                this.cmbfil.Items.Add("WedTime3");
                this.cmbfil.Items.Add("ThuTime1");
                this.cmbfil.Items.Add("ThuTime2");
                this.cmbfil.Items.Add("ThuTime3");
                this.cmbfil.Items.Add("FriTime1");
                this.cmbfil.Items.Add("FriTime2");
                this.cmbfil.Items.Add("FriTime3");
                this.cmbfil.Items.Add("SatTime1");
                this.cmbfil.Items.Add("SatTime2");
                this.cmbfil.Items.Add("SatTime3");
                this.cmbfil.Items.Add("Hol1Time1");
                this.cmbfil.Items.Add("Hol1Time2");
                this.cmbfil.Items.Add("Hol1Time3");
                this.cmbfil.Items.Add("Hol2Time1");
                this.cmbfil.Items.Add("Hol2Time2");
                this.cmbfil.Items.Add("Hol2Time3");
                this.cmbfil.Items.Add("Hol3Time1");
                this.cmbfil.Items.Add("Hol3Time2");
                this.cmbfil.Items.Add("Hol3Time3");
                this.cmbfil.SelectedIndex = 0;
                this.txtfilval.Text = "1";
            }
            else if (string.Equals(devtablename, "transaction"))
            {
                this.txtdevdata.Text = "Cardno\tPin\tVerified\tDoorID\tEventType\tInOutState\tTime_second";
                this.cmbfil.Items.Clear();
                this.cmbfil.Items.Add("Cardno");
                this.cmbfil.Items.Add("Pin");
                this.cmbfil.Items.Add("Verified");
                this.cmbfil.Items.Add("DoorID");
                this.cmbfil.Items.Add("EventType");
                this.cmbfil.Items.Add("InOutState");
                this.cmbfil.Items.Add("Time_second");
                this.cmbfil.SelectedIndex = 0;
                this.txtfilval.Text = "1";
            }
            else if (string.Equals(devtablename, "firstcard"))
            {
                this.txtdevdata.Text = "Pin\tDoorID\tTimezoneID";
                this.cmbfil.Items.Clear();
                this.cmbfil.Items.Add("Pin");
                this.cmbfil.Items.Add("DoorID");
                this.cmbfil.Items.Add("TimezoneID");
                this.cmbfil.SelectedIndex = 0;
                this.txtfilval.Text = "1";
            }
            else if (string.Equals(devtablename, "multimcard"))
            {
                this.txtdevdata.Text = "Index\tDoorId\tGroup1\tGroup2\tGroup3\tGroup4\tGroup5";
                this.cmbfil.Items.Clear();
                this.cmbfil.Items.Add("Index");
                this.cmbfil.Items.Add("DoorId");
                this.cmbfil.Items.Add("Group1");
                this.cmbfil.Items.Add("Group2");
                this.cmbfil.Items.Add("Group3");
                this.cmbfil.Items.Add("Group4");
                this.cmbfil.Items.Add("Group5");
                this.cmbfil.SelectedIndex = 0;
                this.txtfilval.Text = "1";
            }
            else if (string.Equals(devtablename, "inoutfun"))
            {
                this.txtdevdata.Text = "Index\tEventType\tInAddr\tOutType\tOutAddr\tOutTime\tReserved";
                this.cmbfil.Items.Clear();
                this.cmbfil.Items.Add("Index");
                this.cmbfil.Items.Add("EventType");
                this.cmbfil.Items.Add("InAddr");
                this.cmbfil.Items.Add("OutType");
                this.cmbfil.Items.Add("OutAddr");
                this.cmbfil.Items.Add("OutTime");
                this.cmbfil.Items.Add("Reserved");
                this.cmbfil.SelectedIndex = 0;
                this.txtfilval.Text = "1";
            }
            else if (string.Equals(devtablename, "templatev10"))
            {
                this.txtdevdata.Text = "Size\tUID\tPin\tFingerID\tValid\tTemplate\tResverd\tEndTag";
                this.cmbfil.Items.Clear();
                this.cmbfil.Items.Add("Size");
                this.cmbfil.Items.Add("UID");
                this.cmbfil.Items.Add("Pin");
                this.cmbfil.Items.Add("FingerID");
                this.cmbfil.Items.Add("Valid");
                this.cmbfil.Items.Add("Template");
                this.cmbfil.Items.Add("Resverd");
                this.cmbfil.Items.Add("EndTag");
                this.cmbfil.SelectedIndex = 0;
                this.txtfilval.Text = "1";
            }
            else
            {
                this.txtdevdata.Text = "*";
                
            }

            //device data Tab
            cmbdevtable.Enabled = true;
            btngetdat.Enabled = true;
            btnsetdat.Enabled = true;

            btnfil.Enabled = true;
            btnclefil.Enabled = true;
        }
        public string devdatfilter = "";
        private void btnfil_Click(object sender, EventArgs e)
        {
            if (devdatfilter == "")
            {
                this.txtfil.Clear();
                devdatfilter = this.cmbfil.SelectedItem.ToString() + "=" + this.txtfilval.Text;
                this.txtfil.Text = devdatfilter;
            }
            else
            {
                this.txtfil.Clear();
                devdatfilter = devdatfilter + "," + this.cmbfil.SelectedItem.ToString() + "=" + this.txtfilval.Text;
                this.txtfil.Text = devdatfilter;
            }
        }

        private void btnclefil_Click(object sender, EventArgs e)
        {
            this.txtfil.Clear();
            devdatfilter = "";
        }

        string strcount = "";    
        private void btngetdat_Click(object sender, EventArgs e)
        {
            bool ret = false;
            string str = this.txtdevdata.Text;
            int BUFFERSIZE = 10 * 1024 * 1024;
            //byte[] buffer = new byte[BUFFERSIZE];
            string buffer = "";
            string options = "";
            bool opt = this.chkdatopt.Checked;
            if (str == "")
                this.txtdevdata.Text = "\r\n \r\n Please select tablename above the frame!";
            if (opt)
                options = "NewRecord";
            if (bIsConnected  != false)
            {
                //ret = GetDeviceData(h, ref buffer[0], BUFFERSIZE, devtablename, str, devdatfilter, options);
                ret = axCZKEM1.SSR_GetDeviceData(iMachineNumber, out buffer, BUFFERSIZE, devtablename, str, devdatfilter, options);
            }
            else
            {
                MessageBox.Show("Connect device failed!");
                return;
            }
            //MessageBox.Show(str);
            MessageBox.Show("ret=" + ret);
            if (ret )
            {
                this.txtgetdata.Text = buffer;// Encoding.Default.GetString(buffer);
                strcount = buffer;// Encoding.Default.GetString(buffer);
            }
            this.txtdevdata.Clear();
        }

        private void btnsetdat_Click(object sender, EventArgs e)
        {
            bool ret = false;
            string data = this.txtdevdata.Text;
            string options = "";
            if (data == "")
            {
                this.txtdevdata.Text = "\r\n \r\n Please input set data in here!";
                this.txtgetdata.Clear();
            }
            else
            {
                if (bIsConnected != false)
                {
                    //ret = SetDeviceData(h, devtablename, data, options);
                    ret = axCZKEM1.SSR_SetDeviceData(iMachineNumber, devtablename, data, options);
                    if (ret)
                    {
                        MessageBox.Show("SetDeviceData operation is successful!");
                        return;
                    }
                    else
                        MessageBox.Show("SetDeviceData operation is failed!");
                }
                else
                {
                    MessageBox.Show("Connect device failed!");
                    return;
                }
            }
        }

      

        /*************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.*
        * This part is for demonstrating operations with(read/get/clear) the attendance records.         *
        * ************************************************************************************************/
        #region PullSpecial

        //Download the attendance records from the device(For both IFace and TFT screen devices).

      
        #endregion
    }
} 