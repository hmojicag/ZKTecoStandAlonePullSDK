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
using System.IO;
using System.Drawing.Imaging;

namespace UserPhoto
{
    public partial class UserPhotoMain : Form
    {
        public UserPhotoMain()
        {
            InitializeComponent();
            this.tbEndTime.Text = System.DateTime.Now.ToString();
            this.tbStartTime.Text = System.DateTime.Now.AddHours(-1).ToString();
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

        /*************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.*
        * This part is for demonstrating operations with(read/get/clear) the attendance records.         *
        * ************************************************************************************************/
        #region UserPhoto



        private void btnGetPhotoCount_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbGetPhotoCount.Text.Trim() == "" )
            {
                MessageBox.Show("Please input the UserID and Flag first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iFlag = Convert.ToInt32(cbGetPhotoCount.Text);

            int phtoCount = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetPhotoCount(iMachineNumber,out phtoCount, iFlag))
            {

                MessageBox.Show("GetPhotoCoun,phtoCount:" + phtoCount.ToString() , "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        

        private void btnClearPhotoByTime_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbGetPhotoCount.Text.Trim() == "" || tbStartTime.Text.Trim() == "" || tbEndTime.Text.Trim() == "")
            {
                MessageBox.Show("Please input the Flag first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iFlag = Convert.ToInt32(cbGetPhotoCount.Text);
            if (iFlag.Equals(2))
            {
                MessageBox.Show("Please enter the legal iFlag values of 0 or 1!", "Error");
                return;
            }
            string startTime= tbStartTime.Text.ToString();
            string endTime= tbEndTime.Text.ToString();
            int phtoCount = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.ClearPhotoByTime(iMachineNumber, iFlag, startTime, endTime))
            {

                MessageBox.Show("ClearPhotoByTime,iFlag:" + iFlag.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        

        private void btnGetPhotoNamesByTime_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbGetPhotoCount.Text.Trim() == "" || tbStartTime.Text.Trim() == "" || tbEndTime.Text.Trim() == "")
            {
                MessageBox.Show("Please input the Flag first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            int iFlag = Convert.ToInt32(cbGetPhotoCount.Text);
            if (iFlag.Equals(2))
            {
                MessageBox.Show("Please enter the legal iFlag values of 0 or 1!", "Error");
                return;
            }
            string startTime = tbStartTime.Text.ToString();
            string endTime = tbEndTime.Text.ToString();
            int phtoCount = 0;
            string allPhotoName = "";

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetPhotoNamesByTime(iMachineNumber, iFlag, startTime, endTime, out allPhotoName))
            {
                cbPhtoName.Items.Clear();
                
                string[] allPhtoNameTmp = allPhotoName.Split('\n');
                if (allPhtoNameTmp.Length > 0)
                {
                    if (allPhtoNameTmp.Length >= 1)
                    {
                        string[] allPhtoNameTrue = allPhtoNameTmp[0].Split('\t');
                        for (int i = 0; i < allPhtoNameTrue.Length-1; i++)
                        {
                            this.cbPhtoName.Items.Add(allPhtoNameTrue[i]);
                        }
                        this.cbPhtoName.Text = allPhtoNameTrue[0];
                    }
                    if (allPhtoNameTmp.Length == 2)
                    {
                        string[] allPhtoNameFalse = allPhtoNameTmp[1].Split('\t');
                        for (int i = 0; i < allPhtoNameFalse.Length-1; i++)
                        {
                            this.cbPhtoName.Items.Add(allPhtoNameFalse[i]);
                        }
                    }
                }

                MessageBox.Show("GetPhotoNamesByTime,iFlag:" + iFlag.ToString() + "PhtoNameCount:" + cbPhtoName.Items.Count.ToString(), "Success");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        //Download the UserPhoto  from the device(For  TFT screen devices).
        private void btnGetPhotoByName_Click(object sender, EventArgs e)
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (cbPhtoName.Text.Trim() == "")
            {
                MessageBox.Show("Please input the PhtoName first!", "Error");
                return;
            }
            int idwErrorCode = 0;

            string phtoName = cbPhtoName.Text.Trim() + ".jpg";

            byte[] PhotoData = new byte[1024 * 60];
            int phtoSize = 0;

            Cursor = Cursors.WaitCursor;
            if (axCZKEM1.GetPhotoByName(iMachineNumber, phtoName, out PhotoData[0], out phtoSize))
            {

                using (MemoryStream msCamera = new MemoryStream(PhotoData, 0, phtoSize))
                {
                    using (Bitmap bt = new Bitmap(msCamera))
                    {
                        if (bt != null)
                        {

                            FileStream fs = new FileStream(@"Photo\\" + phtoName + ".jpg", FileMode.OpenOrCreate);
                            msCamera.WriteTo(fs);
                            fs.Close();

                            Bitmap Pic = new Bitmap(msCamera);
                            this.pb_Photo.Image = Pic;
                            
                        }
                        
                    }
                }
                MessageBox.Show("GetPhotoByName,phtoName:" + phtoName.ToString() + "phtoSize:" + phtoSize.ToString(), "Success");

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