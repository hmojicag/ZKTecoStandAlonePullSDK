using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StandaloneSDKDemo
{
    public partial class OtherMngForm : Form
    {
        public OtherMngForm(Main parent)
        {
            InitializeComponent();
            OtherMng = parent;
        }
        private Main OtherMng;

        # region SYNCTime
        private void btnSYNCTime_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            OtherMng.SDK.sta_SYNCTime(OtherMng.lbSysOutputInfo, lbDeviceTime);

            Cursor = Cursors.Default;
        }

        private void btnGetDeviceTime_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            OtherMng.SDK.sta_GetDeviceTime(OtherMng.lbSysOutputInfo, lbDeviceTime);

            Cursor = Cursors.Default;
        }

        private void btnSetDeviceTime_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            OtherMng.SDK.sta_SetDeviceTime(OtherMng.lbSysOutputInfo, dtDeviceTime);

            Cursor = Cursors.Default;
        }
        #endregion

        #region wav
        private void btnPlayWavByIndex_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            OtherMng.SDK.sta_btnPlayWavByIndex(OtherMng.lbSysOutputInfo, cbWavIndex);

            Cursor = Cursors.Default;
        }
        #endregion

        #region control

        private void btnRestartDevice_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            OtherMng.SDK.sta_btnRestartDevice(OtherMng.lbSysOutputInfo);

            Cursor = Cursors.Default;
        }

        private void btnPowerOffDevice_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            OtherMng.SDK.sta_btnPowerOffDevice(OtherMng.lbSysOutputInfo);

            Cursor = Cursors.Default;
        }
        #endregion

        #region update
        private void btnBrowser1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            openFileDialog1.FileName = "Your File";
            openFileDialog1.Filter = "emfw.cfg|emfw.cfg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFirmwareFile.Text = openFileDialog1.FileName;
            }
            Cursor = Cursors.Default;
        }

        private void btnUpdateFirmware_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            OtherMng.SDK.sta_btnUpdateFirmware(OtherMng.lbSysOutputInfo, txtFirmwareFile);

            Cursor = Cursors.Default;
        }
        #endregion

        #region R/W file
        private void btnBrowser2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            openFileDialog1.FileName = "Your File";
            openFileDialog1.Filter = "*.*|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSendFileName.Text = openFileDialog1.FileName;
            }
            Cursor = Cursors.Default;
        }


        private void btnSendFile_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            OtherMng.SDK.sta_btnSendFile(OtherMng.lbSysOutputInfo, txtSendFileName);

            Cursor = Cursors.Default;
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            OtherMng.SDK.sta_btnReadFile(OtherMng.lbSysOutputInfo, txtReadFileName, txtFilePath);

            Cursor = Cursors.Default;
        }
        #endregion

        private void txtTimeOutDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
