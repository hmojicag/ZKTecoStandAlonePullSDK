using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace StandaloneSDKDemo
{
    public partial class PersonalizeMngForm : Form
    {
        public PersonalizeMngForm(Main Parent)
        {
            InitializeComponent();
            PersonalizeMng = Parent;

            comb_waveIndex.SelectedIndex = 0;
            comb_bellType.SelectedIndex = 0;
        }
        private Main PersonalizeMng;

        #region BellInfo MNG
        private void btn_getAllBell_Click(object sender, EventArgs e)
        {
            DataTable dt_allBell = new DataTable("dt_allBell");
            gv_BellInfo.AutoGenerateColumns = true;
            gv_BellInfo.Columns.Clear();
            dt_allBell.Columns.Add("ID", System.Type.GetType("System.String"));
            dt_allBell.Columns.Add("Enable", System.Type.GetType("System.Int32"));
            dt_allBell.Columns.Add("Time", System.Type.GetType("System.String"));
            dt_allBell.Columns.Add("WaveIndex", System.Type.GetType("System.Int32"));
            dt_allBell.Columns.Add("BellType", System.Type.GetType("System.Int32"));
            dt_allBell.Columns.Add("InerDelay", System.Type.GetType("System.Int32"));
            dt_allBell.Columns.Add("ExtDelay", System.Type.GetType("System.Int32"));
            dt_allBell.Columns.Add("Mon", System.Type.GetType("System.Int32"));
            dt_allBell.Columns.Add("Tue", System.Type.GetType("System.Int32"));
            dt_allBell.Columns.Add("Wed", System.Type.GetType("System.Int32"));
            dt_allBell.Columns.Add("Thu", System.Type.GetType("System.Int32"));
            dt_allBell.Columns.Add("Fri", System.Type.GetType("System.Int32"));
            dt_allBell.Columns.Add("Sat", System.Type.GetType("System.Int32"));
            dt_allBell.Columns.Add("Sun", System.Type.GetType("System.Int32"));

            gv_BellInfo.DataSource = dt_allBell;
            for (int i = 0; i < gv_BellInfo.Columns.Count; i++)
                gv_BellInfo.Columns[i].Width = 60;

            Cursor = Cursors.WaitCursor;
            PersonalizeMng.SDK.sta_GetAllBellData(PersonalizeMng.lbSysOutputInfo, dt_allBell);
            Cursor = Cursors.Default;
        }

        private void btn_addEditBell_Click(object sender, EventArgs e)
        {
            int bellID = 0, status = 0, hour = 0, min = 0, waveIndex = 0, bellType = 0, inerDelay = 0, extDelay = 0, weekday = 0;
            int bitValue = 0;


            if (tb_bellID.Text == "" || tb_bellID.Text == "0")
            {
                PersonalizeMng.lbSysOutputInfo.Items.Add("*BellID can't be null or 0");
                return;
            }

            DateTime dtBellTime = DateTime.Parse(dt_time.Text);
            hour = dtBellTime.Hour;
            min = dtBellTime.Minute;
            bellID = Convert.ToInt32(tb_bellID.Text.Trim());
            status = Convert.ToInt32(cb_status.Checked);
            waveIndex = comb_waveIndex.SelectedIndex + 1;
            bellType = comb_bellType.SelectedIndex;

            switch (bellType)
            {
                case 0:
                    if (tb_InerDelay.Text.Trim() == "")
                    {
                        PersonalizeMng.lbSysOutputInfo.Items.Add("*Iner delay can not be null.");
                        return;
                    }

                    inerDelay = Convert.ToInt32(tb_InerDelay.Text.Trim());
                    if (inerDelay < 1 || inerDelay > 999)
                    {
                        PersonalizeMng.lbSysOutputInfo.Items.Add("*Internal delay is error.");
                        return;
                    }
                    extDelay = 0;
                    break;
                case 1:

                    if (tb_ExtDelay.Text.Trim() == "")
                    {
                        PersonalizeMng.lbSysOutputInfo.Items.Add("*External delay can not be null.");
                        return;
                    }

                    extDelay = Convert.ToInt32(tb_ExtDelay.Text.Trim());
                    if (extDelay < 1 || extDelay > 999)
                    {
                        PersonalizeMng.lbSysOutputInfo.Items.Add("*External delay is error.");
                        return;
                    }

                    inerDelay = 0;
                    break;
                case 2: 

                    if (tb_ExtDelay.Text.Trim() == "" || tb_InerDelay.Text.Trim() == "")
                    {
                        PersonalizeMng.lbSysOutputInfo.Items.Add("*Internal or External delay can not be null.");
                        return;
                    }

                    inerDelay = Convert.ToInt32(tb_InerDelay.Text.Trim());
                    extDelay = Convert.ToInt32(tb_ExtDelay.Text.Trim());
                    if (extDelay < 1 || extDelay > 999 || inerDelay < 1 || inerDelay > 999)
                    {
                        PersonalizeMng.lbSysOutputInfo.Items.Add("*Internal or External delay is error.");
                        return;
                    }
                    break;
            }

            //Bell Repeat
            bitValue = cb_Sun.Checked ? 1 : 0;
            weekday |= (bitValue << 6);

            bitValue = cb_Mon.Checked ? 1 : 0;
            weekday |= (bitValue << 0);

            bitValue = cb_Tue.Checked ? 1 : 0;
            weekday |= (bitValue << 1);

            bitValue = cb_Wed.Checked ? 1 : 0;
            weekday |= (bitValue << 2);

            bitValue = cb_Thu.Checked ? 1 : 0;
            weekday |= (bitValue << 3);

            bitValue = cb_Fri.Checked ? 1 : 0;
            weekday |= (bitValue << 4);

            bitValue = cb_Sat.Checked ? 1 : 0;
            weekday |= (bitValue << 5);

            Cursor = Cursors.WaitCursor;
            PersonalizeMng.SDK.sta_setBellInfo(PersonalizeMng.lbSysOutputInfo, weekday, bellID, status, hour, min, waveIndex, bellType, inerDelay, extDelay);
            Cursor = Cursors.Default;
        }
        #endregion


        ///
        /// Read jpg to memory stream as a copy
        ///
        /// 
        /// 
        private MemoryStream ReadFile(string path)
        {
            if (!File.Exists(path))
                return null;

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                byte[] b = new byte[file.Length];
                file.Read(b, 0, b.Length);

                MemoryStream stream = new MemoryStream(b);
                return stream;
            }
        }

        ///
        /// Format memory copy to jpg.
        ///
        /// 
        /// 
        private Image GetImageFile(string path)
        {
            MemoryStream stream = ReadFile(path);
            long size = stream.Length;
            return stream == null ? null : Image.FromStream(stream);
        }


        #region Advertise Picture MNG
        private string adPictureFile = "";
        private void btn_adpictureFIle_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "Please select a picture.";
            fileDialog.Filter = "Picture|*.png";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                tb_adpicName.Text = fileDialog.FileName;
                this.pictureBoxAd.Image = GetImageFile(fileDialog.FileName);

                if (cb_adpic.Text == "")
                    cb_adpic.SelectedIndex = 0;
                //adPictureFile = fileDialog.FileName.Replace(fileDialog.SafeFileName, cb_adpic.Text);
                adPictureFile = tb_adpicName.Text;
            }
        }

        private void btn_uploadAdvertise_Click(object sender, EventArgs e)
        {
            if (adPictureFile == "")
            {
                PersonalizeMng.lbSysOutputInfo.Items.Add("*Please select a 320*218 picture first!");
                return;
            }

            Cursor = Cursors.WaitCursor;
            PersonalizeMng.SDK.sta_uploadAdvertisePicture(PersonalizeMng.lbSysOutputInfo, adPictureFile, cb_adpic.Text);
            Cursor = Cursors.Default;
        }
        #endregion


        #region Wallpaper MNG
        private string wallPaperFile = "";
        private void btn_wallPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "Please select a picture.";
            fileDialog.Filter = "Picture|*.png";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
               
                this.tb_wallName.Text = fileDialog.FileName;
                this.pictureBoxWall.Image = GetImageFile(fileDialog.FileName);

                if (cb_wallpaper.Text == "")
                    cb_wallpaper.SelectedIndex = 0;
                //wallPaperFile = fileDialog.FileName.Replace(fileDialog.SafeFileName, cb_wallpaper.Text);
                wallPaperFile = tb_wallName.Text;
            }
        }

        private void btn_uploadwallpaper_Click(object sender, EventArgs e)
        {
            if (wallPaperFile == "")
            {
                PersonalizeMng.lbSysOutputInfo.Items.Add("*Please select a png picture first!");
                return;
            }

            Cursor = Cursors.WaitCursor;
            PersonalizeMng.SDK.sta_uploadWallpaper(PersonalizeMng.lbSysOutputInfo, wallPaperFile, cb_wallpaper.Text);
            Cursor = Cursors.Default;
        }
        #endregion

        #region  ShortcutKey MNG
        private void cb_function_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_function.SelectedIndex == 0)
            {
                panel_punchStateConf.Visible = true;
            }
            else
                panel_punchStateConf.Visible = false;
        }

        public ComboBox getcb_stkeyName()
        {
            ComboBox cb_stkey = this.cb_stkeyName;
            return cb_stkey;
        }

        public ComboBox getcb_function()
        {
            ComboBox cb_func = this.cb_function;
            return cb_func;
        }

        private void cb_stkeyName_MouseClick(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            PersonalizeMng.SDK.sta_getAllShortkeyFunctionName(PersonalizeMng.lbSysOutputInfo, getcb_stkeyName(), getcb_function());

            Cursor = Cursors.Default;
        }

        private void stateCheckboxClear()
        {
            checkBox_Mon.Checked = false;
            checkBox_Tue.Checked = false;
            checkBox_Wed.Checked = false;
            checkBox_Thu.Checked = false;
            checkBox_Fri.Checked = false;
            checkBox_Sat.Checked = false;
            checkBox_Sun.Checked = false;

            dt_Mon.Text = "00:00";
            dt_Tue.Text = "00:00";
            dt_Wed.Text = "00:00";
            dt_Thu.Text = "00:00";
            dt_Fri.Text = "00:00";
            dt_Sat.Text = "00:00";
            dt_Sun.Text = "00:00";
        }

        private void showStateAtuoChangeTime(string strAutoChangeTime)
        {
            string timeMon = "";
            string timeTue = "";
            string timeWed = "";
            string timeThur = "";
            string timeFri = "";
            string timeSat = "";
            string timeSun = "";
            int index = 0;

            stateCheckboxClear();

            index = strAutoChangeTime.IndexOf(";", 1);
            timeMon = strAutoChangeTime.Substring(0, index);
            if (timeMon != "2400")
            {
                checkBox_Mon.Checked =  true;
                dt_Mon.Text = timeMon.Substring(0, 2) + ":" + timeMon.Substring(2, 2);
            }
            
            strAutoChangeTime = strAutoChangeTime.Substring(index + 1);
            index = strAutoChangeTime.IndexOf(";", 1);
            timeTue = strAutoChangeTime.Substring(0, index);
            if (timeTue != "2400")
            {
                checkBox_Tue.Checked = true;
                dt_Tue.Text = timeTue.Substring(0, 2) + ":" + timeTue.Substring(2, 2);
                
            }

            strAutoChangeTime = strAutoChangeTime.Substring(index + 1);
            index = strAutoChangeTime.IndexOf(";", 1);
            timeWed = strAutoChangeTime.Substring(0, index);
            if (timeWed != "2400")
            {
                checkBox_Wed.Checked = true;
                dt_Wed.Text = timeWed.Substring(0, 2) + ":" + timeWed.Substring(2, 2);
             
            }

            strAutoChangeTime = strAutoChangeTime.Substring(index + 1);
            index = strAutoChangeTime.IndexOf(";", 1);
            timeThur = strAutoChangeTime.Substring(0, index);
            if (timeThur != "2400")
            {
                checkBox_Thu.Checked = true;
                dt_Thu.Text = timeThur.Substring(0, 2) + ":" + timeThur.Substring(2, 2);
                
            }

            strAutoChangeTime = strAutoChangeTime.Substring(index + 1);
            index = strAutoChangeTime.IndexOf(";", 1);
            timeFri = strAutoChangeTime.Substring(0, index);
            if (timeFri != "2400")
            {
                checkBox_Fri.Checked = true;
                dt_Fri.Text = timeFri.Substring(0, 2) + ":" + timeFri.Substring(2, 2);
                
            }

            strAutoChangeTime = strAutoChangeTime.Substring(index + 1);
            index = strAutoChangeTime.IndexOf(";", 1);
            timeSat = strAutoChangeTime.Substring(0, index);
            if (timeSat != "2400")
            {
                checkBox_Sat.Checked = true;
                dt_Sat.Text = timeSat.Substring(0, 2) + ":" + timeSat.Substring(2, 2);
                
            }
            
            strAutoChangeTime = strAutoChangeTime.Substring(index + 1);
            timeSun = strAutoChangeTime;

            if (timeSun != "2400")
            {
                checkBox_Sun.Checked = true;
                dt_Sun.Text = timeSun.Substring(0, 2) + ":" + timeSun.Substring(2, 2);
                
            }
            
        }

        private void btn_GetShortkey_Click(object sender, EventArgs e)
        {
            if (cb_stkeyName.SelectedIndex < 0)
            {
                PersonalizeMng.lbSysOutputInfo.Items.Add("*Please select shortkey name!");
                return;
            }
            Cursor = Cursors.WaitCursor;

            string shortkeyName = "";   //F1,...F8, Up, Down, Left, Right,...
            string functionName = "";   //If function key, adduser....  If state key, the same with stateName
            int shortkeyFunID = 0;      //Funtion. 1 means state key. 0 means function key.
            int stateCode = 0;          //Punch State Value
            string stateName = "";      //"state"+stateCode.  state0
            string description = "";    //Key name. Check in or user define.
            int intAutoChange = 0;
            string strAutoChangeTime = "";  //2400;2400;2400;2400;2400;2400;2400 means AutoChange = 0
            int shortkeyID = 0;
            int ret = 0;

            shortkeyID = Convert.ToInt32(cb_stkeyName.Text.Substring(0, cb_stkeyName.Text.IndexOf(",", 1)));
            ret = PersonalizeMng.SDK.sta_getShortkeyByID(PersonalizeMng.lbSysOutputInfo, shortkeyID, ref shortkeyName, ref functionName, ref shortkeyFunID, ref stateCode, ref stateName, ref description, ref intAutoChange, ref strAutoChangeTime);
            PersonalizeMng.lbSysOutputInfo.Items.Add("shortkeyFunID" + shortkeyFunID.ToString());
            if (ret < 0)
            {
                cb_function.Items.Add("Undefine");
                cb_function.Text = "Undefine";
            }
            else if (shortkeyFunID == 1)
            {
                cb_function.SelectedIndex = 0;
                tb_statekeyValue.Text = stateCode.ToString();
                tb_statekeyName.Text = description != "" ? description : functionName;
                showStateAtuoChangeTime(strAutoChangeTime);
            }
            else if (ret == 0)
            {
                cb_function.Text = functionName;
            }
                
            Cursor = Cursors.Default;
        }


        private void tb_statekeyValue_TextChanged(object sender, EventArgs e)
        {
            int index = 0;
            foreach (char ch in ((TextBox)sender).Text)
            {
                if (char.IsDigit(ch))
                {
                    index++;
                }
                else
                {
                    tb_statekeyValue.Text = ((TextBox)sender).Text.Remove(index);
                    break;
                }
            }
            tb_statekeyValue.SelectionStart = tb_statekeyValue.TextLength;
        }

        private void btn_setShortKey_Click(object sender, EventArgs e)
        {
            if (cb_stkeyName.SelectedIndex < 0)
            {
                PersonalizeMng.lbSysOutputInfo.Items.Add("*Please select shortkey name!");
                return;
            }

            if (cb_function.SelectedIndex < 0)
            {
                PersonalizeMng.lbSysOutputInfo.Items.Add("*Please select function!");
                return;
            }

            string shortkeyName = "";   //F1,...F8, Up, Down, Left, Right,...
            string functionName = "";   //If function key, adduser....  If state key, the same with stateName
            int shortkeyFunID = 0;      //Funtion. 1 means state key. 0 means function key.
            int stateCode = 0;          //Punch State Value
            string stateName = "";      //"state"+stateCode.  state0
            string description = "";    //Key name. Check in or user define.
            int intAutoChange = 0;
            string strAutoChangeTime = "";  //2400;2400;2400;2400;2400;2400;2400 means AutoChange = 0
            int shortkeyID = 0;
            string defTime = "2400";
            string timeMon = "";
            string timeTue = "";
            string timeWed = "";
            string timeThur = "";
            string timeFri = "";
            string timeSat = "";
            string timeSun = "";

            shortkeyName = cb_stkeyName.Text.Substring(cb_stkeyName.Text.IndexOf(",") + 1);
            shortkeyID = Convert.ToInt32(cb_stkeyName.Text.Substring(0, cb_stkeyName.Text.IndexOf(",", 1)));

            if (cb_function.Text == "Undefine")
                return;

            if (cb_function.Text == "state key")
            {
                if (tb_statekeyValue.Text.Trim() == "")
                {
                    PersonalizeMng.lbSysOutputInfo.Items.Add("*Please input Punch State Value.");
                    return;
                }
                shortkeyFunID = 1;
                stateCode = Convert.ToInt32(tb_statekeyValue.Text.Trim());
                stateName = "state" + stateCode.ToString();
                description = tb_statekeyName.Text.Trim();
                functionName = stateName;
                if (stateCode > 250)
                {
                    PersonalizeMng.lbSysOutputInfo.Items.Add("* Invalid Puch State Value.");
                    return;
                }

                DateTime dtMON = DateTime.Parse(dt_Mon.Text);
                DateTime dtTUE = DateTime.Parse(dt_Tue.Text);
                DateTime dtWEN = DateTime.Parse(dt_Wed.Text);
                DateTime dtTHU = DateTime.Parse(dt_Thu.Text);
                DateTime dtFRI = DateTime.Parse(dt_Fri.Text);
                DateTime dtSAT = DateTime.Parse(dt_Sat.Text);
                DateTime dtSUN = DateTime.Parse(dt_Sun.Text);

                timeMon = dtMON.Hour.ToString("00") + dtMON.Minute.ToString("00");
                timeTue = dtTUE.Hour.ToString("00") + dtTUE.Minute.ToString("00");
                timeWed = dtWEN.Hour.ToString("00") + dtWEN.Minute.ToString("00");
                timeThur = dtTHU.Hour.ToString("00") + dtTHU.Minute.ToString("00");
                timeFri = dtFRI.Hour.ToString("00") + dtFRI.Minute.ToString("00");
                timeSat = dtSAT.Hour.ToString("00") + dtSAT.Minute.ToString("00");
                timeSun = dtSUN.Hour.ToString("00") + dtSUN.Minute.ToString("00");

                strAutoChangeTime = (checkBox_Mon.Checked ? timeMon : "2400") + ";"
                    + (checkBox_Tue.Checked ? timeTue : "2400") + ";"
                    + (checkBox_Wed.Checked ? timeWed : "2400") + ";"
                    + (checkBox_Thu.Checked ? timeThur : "2400") + ";"
                    + (checkBox_Fri.Checked ? timeFri : "2400") + ";"
                    + (checkBox_Sat.Checked ? timeSat : "2400") + ";"
                    + (checkBox_Sun.Checked ? timeSun : "2400");
            }
            else
            {
                shortkeyFunID = 0;
                functionName = cb_function.Text;
            }

            Cursor = Cursors.WaitCursor;
            PersonalizeMng.SDK.sta_setShortkey(PersonalizeMng.lbSysOutputInfo, shortkeyID, shortkeyName, functionName, shortkeyFunID, stateCode, stateName, description, intAutoChange, strAutoChangeTime);
            Cursor = Cursors.Default;
        }
        #endregion

        private void tb_bellID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_InerDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_ExtDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       

     

    }
}
