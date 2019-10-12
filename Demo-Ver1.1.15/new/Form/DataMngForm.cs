using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace StandaloneSDKDemo
{
    public partial class DataMngForm : Form
    {
        public DataMngForm(Main Parent)
        {
            InitializeComponent();
            DataMng = Parent;
            udisk = new UDisk();
            LoadUDiskFile();
        }
        private Main DataMng;

        private List<DiskFileInfo> diskFileList = new List<DiskFileInfo>();
        private string uDiskDriver = string.Empty;
        private UDisk udisk;
        private List<DiskFileInfo> template10FileList = new List<DiskFileInfo>();
        private List<DiskFileInfo> template9FileList = new List<DiskFileInfo>();

        private List<DiskFileInfo> faceFileList = new List<DiskFileInfo>();
        private List<DiskFileInfo> attFileList = new List<DiskFileInfo>();

        #region AttMng
        private void checkBox_timePeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_timePeriod.Checked == true)
            {
                stime_log.Enabled = true;
                etime_log.Enabled = true;
                btn_deloldlog.Enabled = true;
            }
            else
            {
                stime_log.Enabled = false;
                etime_log.Enabled = false;
                btn_deloldlog.Enabled = false;
            }
        }

        private void btn_readAttLog_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (checkBox_timePeriod.Checked == true)
            {
                string fromTime = stime_log.Text.Trim().ToString();
                string toTime = etime_log.Text.Trim().ToString();

                DataTable dt_periodLog = new DataTable("dt_periodLog");
                gv_Attlog.AutoGenerateColumns = true;
                gv_Attlog.Columns.Clear();
                dt_periodLog.Columns.Add("User ID", System.Type.GetType("System.String"));
                dt_periodLog.Columns.Add("Verify Date", System.Type.GetType("System.String"));
                dt_periodLog.Columns.Add("Verify Type", System.Type.GetType("System.Int32"));
                dt_periodLog.Columns.Add("Verify State", System.Type.GetType("System.Int32"));
                dt_periodLog.Columns.Add("WorkCode", System.Type.GetType("System.Int32"));
                gv_Attlog.DataSource = dt_periodLog;

                DataMng.SDK.sta_readLogByPeriod(DataMng.lbSysOutputInfo, dt_periodLog, fromTime, toTime);
            }
            else
            {
                DataTable dt_period = new DataTable("dt_period");
                gv_Attlog.AutoGenerateColumns = true;
                gv_Attlog.Columns.Clear();
                dt_period.Columns.Add("User ID", System.Type.GetType("System.String"));
                dt_period.Columns.Add("Verify Date", System.Type.GetType("System.String"));
                dt_period.Columns.Add("Verify Type", System.Type.GetType("System.Int32"));
                dt_period.Columns.Add("Verify State", System.Type.GetType("System.Int32"));
                dt_period.Columns.Add("WorkCode", System.Type.GetType("System.Int32"));
                gv_Attlog.DataSource = dt_period;

                DataMng.SDK.sta_readAttLog(DataMng.lbSysOutputInfo, dt_period);
            }
            Cursor = Cursors.Default;
        }

        private void btn_delAttLog_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (checkBox_timePeriod.Checked == true)
            {
                string fromTime = stime_log.Text.Trim().ToString();
                string toTime = etime_log.Text.Trim().ToString();

                DataMng.SDK.sta_DeleteAttLogByPeriod(DataMng.lbSysOutputInfo, fromTime, toTime);
            }
            else
            {
                DataMng.SDK.sta_DeleteAttLog(DataMng.lbSysOutputInfo);
            }
            Cursor = Cursors.Default;
        }

        private void btn_readnewlog_Click(object sender, EventArgs e)
        {
            DataTable dt_newLog = new DataTable("dt_periodLog");
            gv_Attlog.AutoGenerateColumns = true;
            gv_Attlog.Columns.Clear();
            dt_newLog.Columns.Add("User ID", System.Type.GetType("System.String"));
            dt_newLog.Columns.Add("Verify Date", System.Type.GetType("System.String"));
            dt_newLog.Columns.Add("Verify Type", System.Type.GetType("System.Int32"));
            dt_newLog.Columns.Add("Verify State", System.Type.GetType("System.Int32"));
            dt_newLog.Columns.Add("WorkCode", System.Type.GetType("System.Int32"));
            gv_Attlog.DataSource = dt_newLog;

            Cursor = Cursors.WaitCursor;
            DataMng.SDK.sta_ReadNewAttLog(DataMng.lbSysOutputInfo, dt_newLog);
            Cursor = Cursors.Default;
        }

        private void btn_deloldlog_Click(object sender, EventArgs e)
        {
            string fromTime = stime_log.Text.Trim().ToString();

            Cursor = Cursors.WaitCursor;
            DataMng.SDK.sta_DelOldAttLogFromTime(DataMng.lbSysOutputInfo, fromTime);
            Cursor = Cursors.Default;
        }
        #endregion

        #region AttPicture

        private void checkBox_timePeriodPic_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_timePeriodPic.Checked == true)
            {
                datetime_from.Enabled = true;
                datetime_to.Enabled = true;
            }
            else
            {
                datetime_from.Enabled = false;
                datetime_to.Enabled = false;
            }
        }

        private string attPhotoPath = "";
        private void btn_attphotopath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (DialogResult.OK == fbd.ShowDialog())
            {
                tb_attphotopath.Text = fbd.SelectedPath;

                if (!fbd.SelectedPath.EndsWith("\\"))
                {
                    tb_attphotopath.Text += "\\";
                }
                attPhotoPath = this.tb_attphotopath.Text.Trim();
            }
        }


        private void btn_GetAllAttPhoto_Click(object sender, EventArgs e)
        {
            if (attPhotoPath == "")
            {
                DataMng.lbSysOutputInfo.Items.Add("*Select photo path first.");
                return;
            }

            Cursor = Cursors.WaitCursor;
            if (checkBox_timePeriodPic.Checked == true)
            {
                string fromTime = datetime_from.Text.ToString();    //format must be yy-MM-dd HH:mm:ss
                string toTime = datetime_to.Text.ToString();        //format must be yy-MM-dd HH:mm:ss

                DataMng.SDK.sta_GetAllAttPhotoByTimePeriod(DataMng.lbSysOutputInfo, attPhotoPath, fromTime, toTime);
            }
            else
            {
                DataMng.SDK.sta_GetAllAttPhoto(DataMng.lbSysOutputInfo, attPhotoPath);
            }
            Cursor = Cursors.Default;
        }

        private void btn_GetAllPassPhoto_Click(object sender, EventArgs e)
        {
            if (attPhotoPath == "")
            {
                DataMng.lbSysOutputInfo.Items.Add("*Select photo path first.");
                return;
            }

            Cursor = Cursors.WaitCursor;
            if (checkBox_timePeriodPic.Checked == true)
            {
                string fromTime = datetime_from.Text.ToString();    //format must be yy-MM-dd HH:mm:ss
                string toTime = datetime_to.Text.ToString();        //format must be yy-MM-dd HH:mm:ss

                
                DataMng.SDK.sta_GetPassPhotoByTimePeriod(DataMng.lbSysOutputInfo, attPhotoPath, fromTime, toTime);
                
            }
            else
            {
                DataMng.SDK.sta_GetAllPassPhoto(DataMng.lbSysOutputInfo, attPhotoPath);
            }
            Cursor = Cursors.Default;
        }

        private void btn_GetAllBadPhoto_Click(object sender, EventArgs e)
        {
            if (attPhotoPath == "")
            {
                DataMng.lbSysOutputInfo.Items.Add("*Select photo path first.");
                return;
            }

            Cursor = Cursors.WaitCursor;
            if (checkBox_timePeriodPic.Checked == true)
            {
                string fromTime = datetime_from.Text.ToString();    //format must be yy-MM-dd HH:mm:ss
                string toTime = datetime_to.Text.ToString();        //format must be yy-MM-dd HH:mm:ss

                DataMng.SDK.sta_GetBadPhotoByTimePeriod(DataMng.lbSysOutputInfo, attPhotoPath, fromTime, toTime);
            }
            else
            {
                DataMng.SDK.sta_GetAllBadPhoto(DataMng.lbSysOutputInfo, attPhotoPath);
            }
            Cursor = Cursors.Default;
        }

        private void btnClearAllAttPhoto_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int picFlag = 0;
            if (checkBox_timePeriodPic.Checked)
            {
                picFlag = 1;	//Only over time zone
            }
            else
            {
                picFlag = 0;	//All capture pictures
            }

            string fromTime = datetime_from.Text.ToString();    //format must be yy-MM-dd HH:mm:ss
            string toTime = datetime_to.Text.ToString();        //format must be yy-MM-dd HH:mm:ss

            DataMng.SDK.sta_ClearAllAttPhoto(DataMng.lbSysOutputInfo, picFlag, fromTime, toTime);
            
            Cursor = Cursors.Default;
        }
        #endregion


        #region Oplog
        private void btn_GetOpLog_Click(object sender, EventArgs e)
        {
            DataTable dt_opLog = new DataTable("dt_opLog");
            dgv_OpLog.AutoGenerateColumns = true;
            dgv_OpLog.Columns.Clear();
            dt_opLog.Columns.Add("Count", System.Type.GetType("System.Int32"));
            dt_opLog.Columns.Add("MachineNumber", System.Type.GetType("System.Int32"));
            dt_opLog.Columns.Add("Admin", System.Type.GetType("System.String"));
            //dt_opLog.Columns.Add("UserPIN2", System.Type.GetType("System.String"));
            dt_opLog.Columns.Add("Operation", System.Type.GetType("System.Int32"));
            dt_opLog.Columns.Add("DateTime", System.Type.GetType("System.String"));
            dt_opLog.Columns.Add("Param1", System.Type.GetType("System.Int32"));
            dt_opLog.Columns.Add("param2", System.Type.GetType("System.Int32"));
            dt_opLog.Columns.Add("Param3", System.Type.GetType("System.Int32"));
            dt_opLog.Columns.Add("Param4", System.Type.GetType("System.Int32"));
            dgv_OpLog.DataSource = dt_opLog;

            Cursor = Cursors.WaitCursor;
            DataMng.SDK.sta_GetOplog(DataMng.lbSysOutputInfo, dt_opLog);
            Cursor = Cursors.Default;
        }

        private void btn_ClearOplog_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DataMng.SDK.sta_ClearOplog(DataMng.lbSysOutputInfo);
            Cursor = Cursors.Default;
        }
        #endregion


        #region ClearData
        private void btn_clearAdmin_Click(object sender, EventArgs e)
        {
            //ClearAdministrators 
            Cursor = Cursors.WaitCursor;
            DataMng.SDK.sta_ClearAdmin(DataMng.lbSysOutputInfo);
            Cursor = Cursors.Default;
        }

        private void btn_clearAllLogs_Click(object sender, EventArgs e)
        {
            //ClearData 1
            Cursor = Cursors.WaitCursor;
            DataMng.SDK.sta_ClearAllLogs(DataMng.lbSysOutputInfo);
            Cursor = Cursors.Default;
        }

        private void btn_clearAllFp_Click(object sender, EventArgs e)
        {
            //ClearData 2
            Cursor = Cursors.WaitCursor;
            DataMng.SDK.sta_ClearAllFps(DataMng.lbSysOutputInfo);
            Cursor = Cursors.Default;
        }

        private void btn_clearAllUser_Click(object sender, EventArgs e)
        {
            //ClearData 5
            Cursor = Cursors.WaitCursor;
            DataMng.SDK.sta_ClearAllUsers(DataMng.lbSysOutputInfo);
            Cursor = Cursors.Default;
        }

        private void btn_clearAllData_Click(object sender, EventArgs e)
        {
            //ClearKeeperData 
            Cursor = Cursors.WaitCursor;
            DataMng.SDK.sta_ClearAllData(DataMng.lbSysOutputInfo);
            Cursor = Cursors.Default;
        }
        #endregion

        #region Import User Data From Udisk
        bool isAlgorithm10 = true;
        private void btn_importEmployee_Click(object sender, EventArgs e)
        {
            bool isTFT = true;          //Reserve

            try
            {
                List<UserInfo> list_users = ImportEmployeeInfo(isTFT, isAlgorithm10);
                if (list_users.Count > 0)
                {
                    dataGridView_UserInfo.Rows.Clear();
                    
                    for (int si = 0; si < list_users.Count; si++)
                    {
                        int index = dataGridView_UserInfo.Rows.Add();
                        dataGridView_UserInfo.Rows[index].Cells[0].Value = list_users[si].Pin2;
                        if (list_users[si].privilege == 5)
                        {
                            dataGridView_UserInfo.Rows[index].Cells[1].Value = "false";
                            list_users[si].privilege = 0;
                        }
                        else
                        {
                            dataGridView_UserInfo.Rows[index].Cells[1].Value = "ture";
                        }
                        dataGridView_UserInfo.Rows[index].Cells[2].Value = list_users[si].userNo;
                        dataGridView_UserInfo.Rows[index].Cells[3].Value = list_users[si].userName;
                        dataGridView_UserInfo.Rows[index].Cells[4].Value = list_users[si].cardNo;                    
                        dataGridView_UserInfo.Rows[index].Cells[5].Value = list_users[si].privilege;

                        dataGridView_UserInfo.Rows[index].Cells[6].Value = list_users[si].userPwd;
                        dataGridView_UserInfo.Rows[index].Cells[7].Value = list_users[si].Group;

                        //dataGridView_UserInfo.Rows[index].Cells[8].Value = (Convert.ToUInt32(list_users[si].timeZones)) >> 0;
                        //dataGridView_UserInfo.Rows[index].Cells[9].Value = (Convert.ToUInt32(list_users[si].timeZones)) >> 8;
                        //dataGridView_UserInfo.Rows[index].Cells[10].Value = (Convert.ToUInt32(list_users[si].timeZones)) >> 16;
                        //dataGridView_UserInfo.Rows[index].Cells[11].Value = (Convert.ToUInt32(list_users[si].timeZones)) >> 24;

                        dataGridView_UserInfo.Rows[index].Cells[8].Value = list_users[si].timeZones[0];
                        dataGridView_UserInfo.Rows[index].Cells[9].Value = list_users[si].timeZones[1];
                        dataGridView_UserInfo.Rows[index].Cells[10].Value = list_users[si].timeZones[2];
                        dataGridView_UserInfo.Rows[index].Cells[11].Value = list_users[si].timeZones[3];
                        //index = dataGridView_UserInfo.Rows.Add();
                    }
                    DataMng.lbSysOutputInfo.Items.Add("Import " + list_users.Count.ToString() +" user.");


                    //Read template dat files.
                    template10FileList = GetTemplate10FileFromUDisk();
                    template9FileList = GetTemplate9FileFromUDisk();
                    if (template10FileList.Count > 0)
                    {
                        label_algorithm.Text = "10.0";
                        isAlgorithm10 = true;
                        ImportTemplate(list_users, isAlgorithm10);
                    }
                    else if (template9FileList.Count > 0)
                    {
                        label_algorithm.Text = "9.0";
                        isAlgorithm10 = false;
                        ImportTemplate(list_users, isAlgorithm10);
                    }
                    else
                        DataMng.lbSysOutputInfo.Items.Add("No Templates.");
                }
                else
                    DataMng.lbSysOutputInfo.Items.Add("No User Data.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        

        //读U盘中用户的数据，并转成List
        private List<UserInfo> ImportEmployeeInfo(bool isTFT, bool isAlgorithm10)
        {
            //int saveUserCount = 0;
            //sb = new StringBuilder();
            List<UserInfo> list_users = new List<UserInfo>();
            List<DiskFileInfo> selectedFileList = GetSelectedFile();
            if (selectedFileList.Count == 0)
            {
                //sb.AppendLine(("SelectedImportFile") + "\n");
            }
            else
            {
                foreach (DiskFileInfo diskFile in selectedFileList)
                {
                    list_users.AddRange(GetEmployeeInfoFromFile(diskFile.FileName, isTFT));
                }
                //bool limited = false;
                // List<Entities.HR.Employee> employeeList = ZKTimeNet.BLL.Terminal.TerminalData.ConvertToEmployee(list_users);
                //bool save_ret = ZKTimeNet.BLL.Terminal.TerminalData.SaveEmployees(employeeList, true, out limited);
                //sb.AppendLine(string.Format(("ImportUserInfoNotify"), saveUserCount) + "\n");
            }
            return list_users;
        }
        //导入用户数据
        private List<UserInfo> GetEmployeeInfoFromFile(FileInfo fi, bool isTFT)
        {
            List<UserInfo> listUi = new List<UserInfo>();

            FileStream fs = fi.Open(FileMode.Open, FileAccess.ReadWrite);
            //default using Black/White user struct.
            int userStructLength = 28;
            if (isTFT)
            {
                userStructLength = 72;
            }

            int iPIN = 0;
            int iPrivilege = 0;
            string sName = "";
            string sPassword = "";
            int iCard = 0;
            int iGroup = 0;
            string sTimeZones = "";
            ushort[] timezones = new ushort[4];
            int iTimeZones = 0;
            string sPIN2 = "";
            int iPIN2 = 0;

            int j = userStructLength;
            byte[] bytes = new byte[j];
            
            while (j > 0)
            {
                Array.Clear(bytes, 0, bytes.Length);
                j = fs.Read(bytes, 0, j);
                //judge the bytes is a user strcut.
                if (j == userStructLength)
                {
                    UserInfo ba = new UserInfo();
                    if (isTFT)
                    {
                        udisk.GetSSRUserInfoFromDat(bytes, out iPIN, out iPrivilege, out sPassword, out sName, out iCard, out iGroup, ref timezones, out sPIN2);
                        ba.Pin2 = sPIN2;
                        //ba.timeZones = ToInt(sTimeZones);

                        ba.timeZones[0] = timezones[0];
                        ba.timeZones[1] = timezones[1];
                        ba.timeZones[2] = timezones[2];
                        ba.timeZones[3] = timezones[3];
                    }
                    //else
                    //{
                    //    udisk.GetUserInfoFromDat(bytes, out iPIN, out iPrivilege, out sPassword, out sName, out iCard, out iGroup, out iTimeZones, out iPIN2);
                    //    ba.timeZones = iTimeZones;
                    //    ba.Pin2 = iPIN2.ToString();
                    //}
                    ba.userName = sName;
                    ba.userPwd = sPassword;
                    ba.Group = iGroup;
                    ba.cardNo = (uint)iCard;
                    ba.userNo = iPIN;
                    ba.privilege = iPrivilege;

                    listUi.Add(ba);
                }
            }
            fs.Close();
            return listUi;
        }

        //得到所有的文件
        private List<DiskFileInfo> GetSelectedFile()
        {
            List<DiskFileInfo> selectedFileList = (List<DiskFileInfo>)gridControlDiskFile.DataSource;
            return selectedFileList;
        }

        private List<DiskFileInfo> GetEmployeeFileFromUDisk()
        {
            List<FileInfo> employeeFiles = GetFilesByName(uDiskDriver, "user.dat");
            return ConvertToDiskFile(employeeFiles);
        }

        private List<FileInfo> GetFilesByName(string uDisk, string fileName)
        {
            List<FileInfo> list_files = new List<FileInfo>();
            if (string.IsNullOrEmpty(uDiskDriver)) return list_files;

            DirectoryInfo di = new DirectoryInfo(uDiskDriver);
            //*_attlog.dat/user.data/template.fp10
            FileInfo[] fis;
            try
            {
                fis = di.GetFiles(fileName);
                for (int i = 0; i < fis.Length; i++)
                {
                    list_files.Add(fis[i]);
                }
            }
            catch (Exception ex)
            {
                //Log.LogHelper.Error(ex.Message, ex);
            }

            return list_files;
        }
        private List<DiskFileInfo> ConvertToDiskFile(List<FileInfo> fileList)
        {
            List<DiskFileInfo> diskFileList = new List<DiskFileInfo>();
            DiskFileInfo diskFileInfo;
            int terminaNumber = 1;
            int index = uDiskDriver.IndexOf("_");
            if (index > 0)
            {
                //terminaNumber = uDiskDriver.Substring(index - 1, 1).ToInt();
            }
            foreach (FileInfo fileinfo in fileList)
            {
                diskFileInfo = new DiskFileInfo();
                diskFileInfo.TerminalNumber = terminaNumber;
                diskFileInfo.DownloadTime = fileinfo.CreationTime;
                diskFileInfo.FileSize = fileinfo.Length;
                diskFileInfo.FileName = fileinfo;
                diskFileList.Add(diskFileInfo);
            }
            return diskFileList;
        }
        #endregion

        #region Import Templates

        private StringBuilder ImportTemplate(List<UserInfo> list_users, bool isAlgorithm10)
        {
            string template_type = string.Empty;
            StringBuilder sb = new StringBuilder();
            List<TemplateInfo> list_template = new List<TemplateInfo>();

            if (isAlgorithm10)
            {
                template_type = "10";
                foreach (DiskFileInfo diskFile in template10FileList)
                {
                    list_template.AddRange(GetTemplateInfoFromFile(diskFile.FileName, isAlgorithm10));
                }
            }
            else
            {
                template_type = "9";
                foreach (DiskFileInfo diskFile in template9FileList)
                {
                    list_template.AddRange(GetTemplateInfoFromFile(diskFile.FileName, isAlgorithm10));
                }
            }


            //sb.AppendLine(string.Format(crm.GetString("ImportTempInfoNotify"), saveTmpCount) + "\n");

            return sb;
        }
        private List<TemplateInfo> GetTemplateInfoFromFile(FileInfo fi, bool isAlgorithm10)
        {
            int j = 0;
            List<TemplateInfo> listTI = new List<TemplateInfo>();
            FileStream fs = fi.Open(FileMode.Open, FileAccess.ReadWrite);

            if (isAlgorithm10)
            {
                byte[] bts = new byte[fi.Length];
                fs.Read(bts, 0, Convert.ToInt32(fi.Length));
                TemplateInfo ti = new TemplateInfo();
                byte[] oneTmpStr;
                for (long i = 0; i < fi.Length; i = i + j)
                {
                    j = BitConverter.ToUInt16(bts, Convert.ToInt32(i));

                    oneTmpStr = new byte[j];
                    Array.Copy(bts, i, oneTmpStr, 0, j);
                    if (ByteArrayToTemplate10(oneTmpStr, out ti, j))
                    {
                        listTI.Add(ti);
                    }
                }
            }
            else
            {
                j = 608;
                byte[] singleTemplate = new byte[j];
                TemplateInfo ti = new TemplateInfo();
                while (j > 0)
                {
                    j = fs.Read(singleTemplate, 0, j);
                    if (j == 608)
                    {
                        if (ByteArrayToTemplate(singleTemplate, out ti))
                        {
                            //将单个指纹信息保存到结构列表
                            listTI.Add(ti);
                        }
                    }
                }
            }
            fs.Close();
            if (listTI.Count > 0)
            {
                dataGridView_Templates.Rows.Clear();
                for (int sit = 0; sit < listTI.Count; sit++)
                {
                    int indexc = dataGridView_Templates.Rows.Add();
                    dataGridView_Templates.Rows[indexc].Cells[0].Value = listTI[sit].Pin;
                    dataGridView_Templates.Rows[indexc].Cells[1].Value = listTI[sit].fingerID;
                    dataGridView_Templates.Rows[indexc].Cells[2].Value = listTI[sit].Size;
                    dataGridView_Templates.Rows[indexc].Cells[3].Value = listTI[sit].Valid;
                    dataGridView_Templates.Rows[indexc].Cells[4].Value = listTI[sit].TemplateStr;
                }

            }
            return listTI;
        }

            #region  10.0
            private List<DiskFileInfo> GetTemplate10FileFromUDisk()
            {
                List<FileInfo> templateFiles = GetFilesByName(uDiskDriver, "template.fp10.1");

                return ConvertToDiskFile(templateFiles);
            }

            private bool ByteArrayToTemplate10(byte[] bytes, out TemplateInfo ti, int tmpLength)
            {
                ti = new TemplateInfo();
                try
                {
                    //Size
                    byte[] sizebyt = new byte[4];
                    sizebyt[0] = bytes[0];
                    sizebyt[1] = bytes[1];
                    sizebyt[2] = 0;
                    sizebyt[3] = 0;
                    ti.Size = BitConverter.ToInt32(sizebyt, 0);
                    //Pin
                    byte[] Pinbyt = new byte[4];
                    Pinbyt[0] = bytes[2];
                    Pinbyt[1] = bytes[3];
                    Pinbyt[2] = 0;
                    Pinbyt[3] = 0;
                    ti.Pin = BitConverter.ToInt32(Pinbyt, 0);
                    //FingerID
                    byte[] FingerIDByt = new byte[4];
                    FingerIDByt[0] = bytes[4];
                    FingerIDByt[1] = 0;
                    FingerIDByt[2] = 0;
                    FingerIDByt[3] = 0;
                    ti.fingerID = BitConverter.ToInt32(FingerIDByt, 0);
                    //Valid
                    byte[] validByt = new byte[4];
                    validByt[0] = bytes[5];
                    validByt[1] = 0;
                    validByt[2] = 0;
                    validByt[3] = 0;
                    ti.Valid = BitConverter.ToInt32(validByt, 0);
                    byte[] tempByt = new byte[tmpLength - 6];
                    for (int i = 0; i < tempByt.Length; i++)
                    {
                        tempByt[i] = bytes[i + 6];
                    }
                    ti.TemplateStr = Convert.ToBase64String(tempByt);
                }
                catch
                {
                    return false;
                }
                return true;
            }

            #endregion

            #region 9.0

            private List<DiskFileInfo> GetTemplate9FileFromUDisk()
            {
                List<FileInfo> templateFiles = GetFilesByName(uDiskDriver, "template.dat");
                return ConvertToDiskFile(templateFiles);
            }

             /// <summary>
            /// //将指纹字节数据转换为指纹模板
            /// </summary>
            /// <param name="bytes">//指纹模板的字节数据</param>
            /// <param name="ti">//指纹模板的结构信息</param>
            /// <returns>//转换成功返回真</returns>
            private bool ByteArrayToTemplate(byte[] bytes, out TemplateInfo ti)
            {
                //Size:Word;
                //PIN:Word;
                //FingerID:Byte;
                //Valid:Byte;
                //Template :array[1..602] of byte;
                ti = new TemplateInfo();
                try
                {
                    //Size
                    byte[] sizebyt = new byte[4];
                    sizebyt[0] = bytes[0];
                    sizebyt[1] = bytes[1];
                    sizebyt[2] = 0;
                    sizebyt[3] = 0;
                    ti.Size = BitConverter.ToInt32(sizebyt, 0);
                    //Pin
                    byte[] Pinbyt = new byte[4];
                    Pinbyt[0] = bytes[2];
                    Pinbyt[1] = bytes[3];
                    Pinbyt[2] = 0;
                    Pinbyt[3] = 0;
                    ti.Pin = BitConverter.ToInt32(Pinbyt, 0);
                    //FingerID
                    byte[] FingerIDByt = new byte[4];
                    FingerIDByt[0] = bytes[4];
                    FingerIDByt[1] = 0;
                    FingerIDByt[2] = 0;
                    FingerIDByt[3] = 0;
                    ti.fingerID = BitConverter.ToInt32(FingerIDByt, 0);
                    //Valid
                    byte[] validByt = new byte[4];
                    validByt[0] = bytes[5];
                    validByt[1] = 0;
                    validByt[2] = 0;
                    validByt[3] = 0;
                    ti.Valid = BitConverter.ToInt32(validByt, 0);
                    byte[] tempByt = new byte[602];
                    for (int i = 0; i < tempByt.Length; i++)
                    {
                        tempByt[i] = bytes[i + 6];
                    }
                    ti.TemplateStr = Convert.ToBase64String(tempByt);
                }
                catch
                {
                    return false;
                }
                return true;
            }

            #endregion
        
        #endregion

        [DllImport("kernel32.dll ", CharSet = CharSet.Auto)]
        private static extern int GetDriveType(string driveinfo);

        private bool IsUSBDisk(string driveInfo)
        {
            if (driveInfo == null || driveInfo == " ")
                return false;
            if (GetDriveType(driveInfo) == (int)DriveType.Removable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void LoadUDiskFile()
        {
            string str = string.Empty;
            String[] strDrivers = Environment.GetLogicalDrives();
            int i = strDrivers.Length - 1;
            //uDiskDriver = strDrivers[i];

            while (i >= 0)
            {
                if (IsUSBDisk(strDrivers[i]))
                {
                    uDiskDriver = strDrivers[i];
                }
                i--;
            }

            if (tabControlUDisk.SelectedIndex == 0)
            {
                //Get user data files info on udisk
                diskFileList = GetEmployeeFileFromUDisk();
                gridControlDiskFile.DataSource = diskFileList;
                gridControlDiskFile.Refresh();
                if (gridControlDiskFile.Rows.Count == 0)
                {
                    btn_importEmployee.Text = "NotExistUserInfoFiles";
                    btn_importEmployee.Enabled = false;
                }
                else
                {
                    btn_importEmployee.Text = "Import Employee Info";
                    btn_importEmployee.Enabled = true;
                }

            }
            else if (tabControlUDisk.SelectedIndex == 1)
            {
                //Get attlog data files info on udisk
                attFileList = GetAttlogFileFromUDisk();
                dataGridView_diskFiles.DataSource = attFileList;
                dataGridView_diskFiles.Refresh();
                if (dataGridView_diskFiles.Rows.Count == 0)
                {
                    btn_importRecords.Enabled = false;
                }
                else
                {
                    btn_importRecords.Enabled = true;
                }
            }
        }


        private void tabControlUDisk_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUDiskFile();
        }

        public class DiskFileInfo
        {
            public int TerminalNumber { get; set; }
            public DateTime DownloadTime { get; set; }
            public long FileSize { get; set; }

            public FileInfo FileName { get; set; }
        }

        public static int ToInt(string str)
        {
            int ret = 0;
            try
            {
                ret = int.Parse(str);
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        #region Import Records From Udisk
        private void btn_importRecords_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ImportPunchesFromFile();
            }
            catch (Exception ex)
            {
                //XtraMessageBoxHelper.Error(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private List<DiskFileInfo> GetAttlogFileFromUDisk()
        {
            List<FileInfo> attLogFiles = GetFilesByName(uDiskDriver, "*_attlog.dat");
            attLogFiles.AddRange(GetFilesByName(uDiskDriver, "*AttEncryptLog.dat"));
            return ConvertToDiskFile(attLogFiles);
        }
        private void ImportPunchesFromFile()
        {

            List<Punches> punchesList = new List<Punches>();

            StringBuilder sb = new StringBuilder();
            List<DiskFileInfo> selectedFileList = GetAttlogFileFromUDisk();
            if (selectedFileList.Count == 0)
            {
               DataMng.lbSysOutputInfo.Items.Add("*Pls Selected ImportFile.");
            }
            else
            {
                foreach (DiskFileInfo attFileList in selectedFileList)
                {
                    if (attFileList.FileName.Name.IndexOf("AttEncryptLog") >= 0)
                    {
                        punchesList.AddRange(GetEntryPunches(attFileList.FileName));
                    }
                    else
                    {
                        punchesList.AddRange(GetPunches(attFileList.FileName));
                    }
                }

                if (punchesList.Count > 0 )
                {
                    dataGridView_Records.Rows.Clear();
                    int inx = 0;
                    for (int si = 0; si < punchesList.Count; si++)
                    {
                        inx = dataGridView_Records.Rows.Add();
                        dataGridView_Records.Rows[inx].Cells[0].Value = punchesList[si].pin;
                        dataGridView_Records.Rows[inx].Cells[1].Value = punchesList[si].punch_time;
                        dataGridView_Records.Rows[inx].Cells[2].Value = punchesList[si].workstate;
                        dataGridView_Records.Rows[inx].Cells[3].Value = punchesList[si].verifycode;
                    }
                    DataMng.lbSysOutputInfo.Items.Add("Import " + punchesList.Count.ToString() + " Records.");
                }
                else
                    DataMng.lbSysOutputInfo.Items.Add("No Records.");
            
            }
        }
        private List<Punches> GetEntryPunches(FileInfo fi)
        {
            List<Punches> lst_punches = new List<Punches>();

            List<string> spunchesList = ReadEntryFile(fi);
            string[] data_split;
            Punches punch;
            string pin = string.Empty;
            int terminalNum = 0;
          
            foreach (string spunch in spunchesList)
            {
                data_split = spunch.Split('\t');

                if (data_split.Length < 3) continue;

                pin = data_split[0].Trim();
               
                if (data_split.Length >= 6)
                {
                    punch = new Punches
                    {
                        pin = pin,
                        punch_time = Convert.ToDateTime(data_split[1].Trim()),
                        //terminal = terminal,
                        workstate = ToInt(data_split[3].Trim()),
                        verifycode = data_split[4].Trim(),
                        punch_type = "0",
                        workcode = Convert.ToInt32(data_split[5].Trim())
                    };
                    lst_punches.Add(punch);
                }
                else if (data_split.Length >= 5)
                {
                    punch = new Punches
                    {
                        pin = pin,
                        punch_time = Convert.ToDateTime(data_split[1].Trim()),
                        //terminal = terminal,
                        workstate = ToInt(data_split[3].Trim()),
                        verifycode = data_split[4].Trim(),
                        punch_type = "0",
                        workcode = Convert.ToInt32(data_split[5].Trim())
                    };
                    lst_punches.Add(punch);
                }
            }
            return lst_punches;
        }
        //读文本文件
        private List<string> ReadEntryFile(FileInfo fi)
        {
            int count;
            List<string> punches = new List<string>();
            byte[] buffer = new byte[256];
            FileStream fs = fi.Open(FileMode.Open, FileAccess.ReadWrite);
            while (fs.Read(buffer, 0, 256) > 0)
            {

                count = Decrypt(buffer);
                if (count < 30)
                {
                    if (count < 1)
                        continue;
                }

                char[] punchesChr = new char[256];
                for (int k = 0; k < 256; k++)
                {
                    punchesChr[k] = Convert.ToChar(buffer[k]);
                    if (punchesChr[k] == '\0')
                        break;
                }

                string punch = new string(punchesChr);
                int index = punch.IndexOf("\0");
                if (index > 0)
                {
                    punches.Add(punch.Substring(0, index));
                }
                buffer = new byte[256];
            }
            return punches;
        }
        public static int Decrypt(byte[] pSrc)
        {
            byte high, low;
            byte c, d;
            int i, j, len;
            int count;
            len = pSrc.Length;
            if (len % 2 > 0)
            {
                return -1;
            }
            i = 0;
            count = 0;
            for (j = 0; j < len; j += 2)
            {
                c = pSrc[j];
                d = pSrc[j + 1];
                high = Convert.ToByte((c - 'x') > 0 ? (c - 'x') : 0);
                low = Convert.ToByte((d - 'z') > 0 ? (d - 'z') : 0);
                pSrc[i] = Convert.ToByte((high << 4) + low);
                if (pSrc[i] != 0)
                    count++;
                i++;
            }
            pSrc[count] = 13;
            return count;
        }
        private List<Punches> GetPunches(FileInfo fi)
        {
            List<Punches> lst_punches = new List<Punches>();
            StreamReader sr = fi.OpenText();
            string aLine = string.Empty;
            string[] data_split;

            Punches punch;
            string pin = string.Empty;
            int terminalNum = 0;

            
            while ((aLine = sr.ReadLine()) != null)
            {
                //for the encrypt dataformat 'attlog.dat'.
                if (aLine.IndexOf("SN=") >= 0 || aLine.IndexOf("CHECKSUM") >= 0)
                {
                    continue;
                }
                data_split = aLine.Split('\t');

                if (data_split.Length < 3) continue;

                pin = data_split[0].Trim();
                if (data_split.Length >= 6)
                {
                    punch = new Punches
                    {
                        pin = pin,
                        punch_time = Convert.ToDateTime(data_split[1].Trim()),
                        workstate = ToInt(data_split[3].Trim()),
                        verifycode = data_split[4].Trim(),
                        punch_type = "0",
                        workcode = Convert.ToInt32(data_split[5].Trim())
                    };
                    lst_punches.Add(punch);
                }
                else if (data_split.Length >= 5)
                {
                    punch = new Punches
                    {
                        pin = pin,
                        punch_time = Convert.ToDateTime(data_split[1].Trim()),
                        workstate = ToInt(data_split[3].Trim()),
                        verifycode = data_split[4].Trim(),
                        punch_type = "0",
                        workcode = 0
                    };
                    lst_punches.Add(punch);
                }
            }
            return lst_punches;
        }
        #endregion

        #region Export Employee

        private void btn_ExportEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uDiskDriver))
            {
                DataMng.lbSysOutputInfo.Items.Add("*Not Exists UDisk");
                return;
            }

            if (dataGridView_UserInfo.RowCount == 0)
            {
                DataMng.lbSysOutputInfo.Items.Add("*No Employee Selected");
                return;
            }

            bool isTFT = true; //Reserve
            List<UserInfo> List_Use = new List<UserInfo>();
            //UserInfo Useris = new UserInfo();
            List<TemplateInfo> List_Template = new List<TemplateInfo>();
            TemplateInfo Templatei;
            int iCount = 0;
            int iPrivilege = 0;

            //Export User.dat
            iCount = dataGridView_UserInfo.RowCount;
            for (int i = 0; i < iCount; i++)
            {
                UserInfo Useris = new UserInfo();

                if (dataGridView_UserInfo.Rows[i].Cells[1].Value.ToString().Trim() == "false")
                {
                    iPrivilege = 5;
                }
                else
                {
                    iPrivilege = ToInt(dataGridView_UserInfo.Rows[i].Cells[5].Value.ToString().Trim());
                }

                //timeZones = dataGridView_UserInfo.Rows[i].Cells[8].Value << 8 | dataGridView_UserInfo.Rows[i].Cells[9].Value << 6 | dataGridView_UserInfo.Rows[i].Cells[10].Value << 4 | dataGridView_UserInfo.Rows[i].Cells[11].Value << 2;

                //Useris = new UserInfo
                //{
                //    Pin2 = dataGridView_UserInfo.Rows[i].Cells[0].Value.ToString().Trim(),
                //    userNo = ToInt(dataGridView_UserInfo.Rows[i].Cells[2].Value.ToString().Trim()),
                //    userName = dataGridView_UserInfo.Rows[i].Cells[3].Value.ToString().Trim(),
                //    cardNo = (uint)ToInt(dataGridView_UserInfo.Rows[i].Cells[4].Value.ToString()),
                //    privilege = iPrivilege,
                //    userPwd = dataGridView_UserInfo.Rows[i].Cells[6].Value.ToString(),
                //    Group = ToInt(dataGridView_UserInfo.Rows[i].Cells[7].Value.ToString()),
                //    //timeZones = dataGridView_UserInfo.Rows[i].Cells[8].Value.ToString().PadLeft(2, '0') + dataGridView_UserInfo.Rows[i].Cells[9].Value.ToString().PadLeft(2, '0') + dataGridView_UserInfo.Rows[i].Cells[10].Value.ToString().PadLeft(2, '0') + dataGridView_UserInfo.Rows[i].Cells[11].Value.ToString().PadLeft(2, '0')
                //    new[0] timeZones[0] = Convert.ToUInt16(dataGridView_UserInfo.Rows[i].Cells[8].Value.ToString()),
                //    timeZones[1] = Convert.ToUInt16(dataGridView_UserInfo.Rows[i].Cells[9].Value.ToString()),
                //    timeZones[2] = Convert.ToUInt16(dataGridView_UserInfo.Rows[i].Cells[10].Value.ToString()),
                //    timeZones[3] = Convert.ToUInt16(dataGridView_UserInfo.Rows[i].Cells[11].Value.ToString())
                //};

                Useris.Pin2 = dataGridView_UserInfo.Rows[i].Cells[0].Value.ToString().Trim();
                Useris.userNo = ToInt(dataGridView_UserInfo.Rows[i].Cells[2].Value.ToString().Trim());
                Useris.userName = dataGridView_UserInfo.Rows[i].Cells[3].Value.ToString().Trim();
                Useris.cardNo = (uint)ToInt(dataGridView_UserInfo.Rows[i].Cells[4].Value.ToString());
                Useris.privilege = iPrivilege;
                Useris.userPwd = dataGridView_UserInfo.Rows[i].Cells[6].Value.ToString();
                Useris.Group = ToInt(dataGridView_UserInfo.Rows[i].Cells[7].Value.ToString());
                Useris.timeZones[0] = Convert.ToUInt16(dataGridView_UserInfo.Rows[i].Cells[8].Value.ToString());
                Useris.timeZones[1] = Convert.ToUInt16(dataGridView_UserInfo.Rows[i].Cells[9].Value.ToString());
                Useris.timeZones[2] = Convert.ToUInt16(dataGridView_UserInfo.Rows[i].Cells[10].Value.ToString());
                Useris.timeZones[3] = Convert.ToUInt16(dataGridView_UserInfo.Rows[i].Cells[11].Value.ToString());

                List_Use.Add(Useris);
            }
            DataMng.lbSysOutputInfo.Items.Add("Export user success. Count:" + iCount);

            //Export Template
            iCount = dataGridView_Templates.Rows.Count;
            for (int i = 0; i < iCount; i++)
            {
                Templatei = new TemplateInfo
                {
                    Pin = ToInt(dataGridView_Templates.Rows[i].Cells[0].Value.ToString().Trim()),
                    fingerID = ToInt(dataGridView_Templates.Rows[i].Cells[1].Value.ToString().Trim()),
                    Size = ToInt(dataGridView_Templates.Rows[i].Cells[2].Value.ToString().Trim()),
                    Valid = ToInt(dataGridView_Templates.Rows[i].Cells[3].Value.ToString().Trim()),
                    TemplateStr = dataGridView_Templates.Rows[i].Cells[4].Value.ToString().Trim()
                };
                List_Template.Add(Templatei);
            }
            DataMng.lbSysOutputInfo.Items.Add("Export template success. Count:" + iCount);

            udisk.ExportUserInfo(isTFT, isAlgorithm10, uDiskDriver, List_Use, List_Template);
        }

        #endregion

    }
}
