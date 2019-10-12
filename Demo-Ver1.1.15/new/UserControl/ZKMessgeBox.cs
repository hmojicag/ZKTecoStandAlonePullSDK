using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace StandaloneSDKDemo
{
    public partial class ZKMessgeBox :Form
    {
        public ZKMessgeBox()
        {
            InitializeComponent();
        }

        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //private static extern bool MessageBeep(uint type);
        //[DllImport("Shell32.dll")]
        //public extern static int ExtractIconEx(string libName, int iconIndex, IntPtr[] largeIcon, IntPtr[] smallIcon, int nIcons);
        //static private IntPtr[] largeIcon;
        //static private IntPtr[] smallIcon;
        static private ZKMessgeBox newMessageBox;
        static private Label frmTitle;
        static private Label frmMessage;
        //static private PictureBox pIcon;
        static private FlowLayoutPanel flpButtons;
        //static private Icon frmIcon;
        static private Button btnOK;
        static private Button btnAbort;
        static private Button btnRetry;
        static private Button btnIgnore;
        static private Button btnCancel;
        static private Button btnYes;
        static private Button btnNo;
        static private DialogResult I8ReturnButton;
        public enum I8Icon
        {
            Error,
            Explorer,
            Find,
            Information,
            Mail,
            Media,
            Print,
            Question,
            RecycleBinEmpty,
            RecycleBinFull,
            Stop,
            User,
            Warning
        }
        public enum I8Buttons
        {
            AbortRetryIgnore,
            OK,
            OKCancel,
            RetryCancel,
            YesNo,
            YesNoCancel
        }
        static private void BuildMessageBox(string title)
        {
            newMessageBox = new ZKMessgeBox();
            newMessageBox.Text = title;
            newMessageBox.Size = new System.Drawing.Size(400, 200);
            newMessageBox.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            newMessageBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            newMessageBox.Paint += new PaintEventHandler(newMessageBox_Paint);
            newMessageBox.BackColor = System.Drawing.Color.White;

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.RowCount = 3;
            tlp.ColumnCount = 0;
            tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50));
            tlp.BackColor = System.Drawing.Color.Transparent;
            tlp.Padding = new Padding(2, 5, 2, 2);

            frmTitle = new Label();
            frmTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            frmTitle.BackColor = System.Drawing.Color.Transparent;
            frmTitle.ForeColor = System.Drawing.Color.White;
            frmTitle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //frmTitle.Click += new EventHandler(frmTitle_Click);
            frmTitle.MouseDown += new MouseEventHandler(frmTitle_MouseDown);
            frmTitle.MouseMove += new MouseEventHandler(frmTitle_MouseMove);
            frmTitle.MouseUp += new MouseEventHandler(frmTitle_MouseUp);

            frmMessage = new Label();
            frmMessage.AutoSize = true;
            frmMessage.Size = new Size(300,100);
            frmMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            frmMessage.BackColor = System.Drawing.Color.White;
            frmMessage.Font = new Font("Tahoma", 12, FontStyle.Regular);
            frmMessage.Text = "hiii";
            frmMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            //largeIcon = new IntPtr[250];
            //smallIcon = new IntPtr[250];
            //pIcon = new PictureBox();
            //ExtractIconEx("shell32.dll", 0, largeIcon, smallIcon, 250);
            flpButtons = new FlowLayoutPanel();
            flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flpButtons.Padding = new Padding(0, 5, 5, 0);
            flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            //flpButtons.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            flpButtons.BackColor = System.Drawing.Color.White;
            TableLayoutPanel tlpMessagePanel = new TableLayoutPanel();
            tlpMessagePanel.BackColor = System.Drawing.Color.White;
            tlpMessagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpMessagePanel.ColumnCount = 0;
            tlpMessagePanel.RowCount = 0;
            tlpMessagePanel.Padding = new Padding(4, 5, 4, 4);
            //tlpMessagePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50));
            tlpMessagePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //tlpMessagePanel.Controls.Add(pIcon);
            tlpMessagePanel.Controls.Add(frmMessage);
            tlp.Controls.Add(frmTitle);
            tlp.Controls.Add(tlpMessagePanel);
            tlp.Controls.Add(flpButtons);
            newMessageBox.Controls.Add(tlp);
        }

        static Point mouseOffset;
        static Point FormLocation;
        static bool isMouseDown;
        static void frmTitle_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        static void frmTitle_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;
                newMessageBox.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }
        }

        static void frmTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = newMessageBox.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        
        /// <summary>
        /// Message: Text to display in the message box.
        /// </summary>
        static public DialogResult Show(string Message)
        {
            BuildMessageBox("");
            frmMessage.Text = Message;
            ShowOKButton();
            newMessageBox.ShowDialog();
            return I8ReturnButton;
        }
        /// <summary>
        /// Title: Text to display in the title bar of the messagebox.
        /// </summary>
        static public DialogResult Show(string Message, string Title)
        {
            BuildMessageBox(Title);
            frmTitle.Text = Title;
            frmMessage.Text = Message;
            ShowOKButton();
            newMessageBox.ShowDialog();
            return I8ReturnButton;
        }
        /// <summary>
        /// MButtons: Display I8Buttons on the message box.
        /// </summary>
        static public DialogResult Show(string Message, string Title, I8Buttons MButtons)
        {
            BuildMessageBox(Title); // BuildMessageBox method, responsible for creating the MessageBox
            frmTitle.Text = Title; // Set the title of the MessageBox
            frmMessage.Text = Message; //Set the text of the MessageBox
            int xlocation = (newMessageBox.Width-frmMessage.Width)/2;
            frmMessage.Location = new Point(xlocation, 150);
            ButtonStatements(MButtons); // ButtonStatements method is responsible for showing the appropreiate buttons
            newMessageBox.ShowDialog(); // Show the MessageBox as a Dialog.
            return I8ReturnButton; // Return the button click as an Enumerator
        }
        /// <summary>
        /// MIcon: Display I8Icon on the message box.
        /// </summary>
        static public DialogResult Show(string Message, string Title, I8Buttons MButtons, I8Icon MIcon)
        {
            BuildMessageBox(Title);
            frmTitle.Text = Title;
            frmMessage.Text = Message;
            ButtonStatements(MButtons);
            //IconStatements(MIcon);
            //Image imageIcon = new Bitmap(frmIcon.ToBitmap(), 38, 38);
            //pIcon.Image = imageIcon;
            newMessageBox.ShowDialog();
            
            return I8ReturnButton;
        }

        static void btnOK_Click(object sender, EventArgs e)
        {
            I8ReturnButton = DialogResult.OK;
            newMessageBox.Dispose();
        }
        static void btnAbort_Click(object sender, EventArgs e)
        {
            I8ReturnButton = DialogResult.Abort;
            newMessageBox.Dispose();
        }
        static void btnRetry_Click(object sender, EventArgs e)
        {
            I8ReturnButton = DialogResult.Retry;
            newMessageBox.Dispose();
        }
        static void btnIgnore_Click(object sender, EventArgs e)
        {
            I8ReturnButton = DialogResult.Ignore;
            newMessageBox.Dispose();
        }
        static void btnCancel_Click(object sender, EventArgs e)
        {

            I8ReturnButton = DialogResult.Cancel;

            if (newMessageBox.components != null)
                newMessageBox.components.Dispose();
            newMessageBox.Dispose();
        }
        static void btnYes_Click(object sender, EventArgs e)
        {
            I8ReturnButton = DialogResult.Yes;
            newMessageBox.Dispose();
        }
        static void btnNo_Click(object sender, EventArgs e)
        {
            I8ReturnButton = DialogResult.No;
            newMessageBox.Dispose();
        }
        static private void ShowOKButton()
        {
            btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Size = new System.Drawing.Size(80, 25);
            btnOK.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            btnOK.Font = new Font("Tahoma", 8, FontStyle.Regular);
            btnOK.Click += new EventHandler(btnOK_Click);
            flpButtons.Controls.Add(btnOK);
        }
        static private void ShowAbortButton()
        {
            btnAbort = new Button();
            btnAbort.Text = "Abort";
            btnAbort.Size = new System.Drawing.Size(80, 25);
            btnAbort.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            btnAbort.Font = new Font("Tahoma", 8, FontStyle.Regular);
            btnAbort.Click += new EventHandler(btnAbort_Click);
            flpButtons.Controls.Add(btnAbort);
        }
        static private void ShowRetryButton()
        {
            btnRetry = new Button();
            btnRetry.Text = "Retry";
            btnRetry.Size = new System.Drawing.Size(80, 25);
            btnRetry.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            btnRetry.Font = new Font("Tahoma", 8, FontStyle.Regular);
            btnRetry.Click += new EventHandler(btnRetry_Click);
            flpButtons.Controls.Add(btnRetry);
        }
        static private void ShowIgnoreButton()
        {
            btnIgnore = new Button();
            btnIgnore.Text = "Ignore";
            btnIgnore.Size = new System.Drawing.Size(80, 25);
            btnIgnore.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            btnIgnore.Font = new Font("Tahoma", 8, FontStyle.Regular);
            btnIgnore.Click += new EventHandler(btnIgnore_Click);
            flpButtons.Controls.Add(btnIgnore);
        }
        static private void ShowCancelButton()
        {
            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Size = new System.Drawing.Size(80, 25);
            btnCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            btnCancel.Font = new Font("Tahoma", 8, FontStyle.Regular);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            flpButtons.Controls.Add(btnCancel);
        }
        static private void ShowYesButton()
        {
            btnYes = new Button();
            btnYes.Text = "Yes";
            btnYes.Size = new System.Drawing.Size(80, 25);
            btnYes.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            btnYes.Font = new Font("Tahoma", 8, FontStyle.Regular);
            btnYes.Click += new EventHandler(btnYes_Click);
            flpButtons.Controls.Add(btnYes);
        }
        static private void ShowNoButton()
        {
            btnNo = new Button();
            btnNo.Text = "No";
            btnNo.Size = new System.Drawing.Size(80, 25);
            btnNo.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            btnNo.Font = new Font("Tahoma", 8, FontStyle.Regular);
            btnNo.Click += new EventHandler(btnNo_Click);
            flpButtons.Controls.Add(btnNo);
        }
        static private void ButtonStatements(I8Buttons MButtons)
        {
            if (MButtons == I8Buttons.AbortRetryIgnore)
            {
                ShowIgnoreButton();
                ShowRetryButton();
                ShowAbortButton();
            }
            if (MButtons == I8Buttons.OK)
            {
                ShowOKButton();
            }
            if (MButtons == I8Buttons.OKCancel)
            {
                ShowCancelButton();
                ShowOKButton();
            }
            if (MButtons == I8Buttons.RetryCancel)
            {
                ShowCancelButton();
                ShowRetryButton();
            }
            if (MButtons == I8Buttons.YesNo)
            {
                ShowNoButton();
                ShowYesButton();
            }
            if (MButtons == I8Buttons.YesNoCancel)
            {
                ShowCancelButton();
                ShowNoButton();
                ShowYesButton();
            }
        }
        //static private void IconStatements(I8Icon MIcon)
        //{
        //    if (MIcon == I8Icon.Error)
        //    {
        //        MessageBeep(30);
        //        frmIcon = Icon.FromHandle(largeIcon[109]);
        //    }
        //    if (MIcon == I8Icon.Explorer)
        //    {
        //        MessageBeep(0);
        //        frmIcon = Icon.FromHandle(largeIcon[220]);
        //    }
        //    if (MIcon == I8Icon.Find)
        //    {
        //        MessageBeep(0);
        //        frmIcon = Icon.FromHandle(largeIcon[22]);
        //    }
        //    if (MIcon == I8Icon.Information)
        //    {
        //        MessageBeep(0);
        //        frmIcon = Icon.FromHandle(largeIcon[221]);
        //    }
        //    if (MIcon == I8Icon.Mail)
        //    {
        //        MessageBeep(0);
        //        frmIcon = Icon.FromHandle(largeIcon[156]);
        //    }
        //    if (MIcon == I8Icon.Media)
        //    {
        //        MessageBeep(0);
        //        frmIcon = Icon.FromHandle(largeIcon[116]);
        //    }
        //    if (MIcon == I8Icon.Print)
        //    {
        //        MessageBeep(0);
        //        frmIcon = Icon.FromHandle(largeIcon[136]);
        //    }
        //    if (MIcon == I8Icon.Question)
        //    {
        //        MessageBeep(0);
        //        frmIcon = Icon.FromHandle(largeIcon[23]);
        //    }
        //    if (MIcon == I8Icon.RecycleBinEmpty)
        //    {
        //        MessageBeep(0);
        //        frmIcon = Icon.FromHandle(largeIcon[31]);
        //    }
        //    if (MIcon == I8Icon.RecycleBinFull)
        //    {
        //        MessageBeep(0);
        //        frmIcon = Icon.FromHandle(largeIcon[32]);
        //    }
        //    if (MIcon == I8Icon.Stop)
        //    {
        //        MessageBeep(0);
        //        frmIcon = Icon.FromHandle(largeIcon[27]);
        //    }
        //    if (MIcon == I8Icon.User)
        //    {
        //        MessageBeep(0);
        //        frmIcon = Icon.FromHandle(largeIcon[170]);
        //    }
        //    if (MIcon == I8Icon.Warning)
        //    {
        //        MessageBeep(30);
        //        frmIcon = Icon.FromHandle(largeIcon[217]);
        //    }
        //}
        static void newMessageBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle frmTitleL = new Rectangle(0, 0, (newMessageBox.Width / 2), 22);
            Rectangle frmTitleR = new Rectangle((newMessageBox.Width / 2), 0, (newMessageBox.Width / 2), 22);
            Rectangle frmMessageBox = new Rectangle(0, 0, (newMessageBox.Width - 1), (newMessageBox.Height - 1));
            //LinearGradientBrush frmLGBL = new LinearGradientBrush(frmTitleL, Color.FromArgb(87, 148, 160), Color.FromArgb(209, 230, 243), LinearGradientMode.Horizontal);
            //LinearGradientBrush frmLGBR = new LinearGradientBrush(frmTitleR, Color.FromArgb(209, 230, 243), Color.FromArgb(87, 148, 160), LinearGradientMode.Horizontal);
            LinearGradientBrush frmLGBL = new LinearGradientBrush(frmTitleL, Color.FromArgb(122, 193, 67), Color.FromArgb(122, 193, 67), LinearGradientMode.Horizontal);
            LinearGradientBrush frmLGBR = new LinearGradientBrush(frmTitleR, Color.FromArgb(122, 193, 67), Color.FromArgb(122, 193, 67), LinearGradientMode.Horizontal);
            Pen frmPen = new Pen(Color.FromArgb(122, 193, 67), 1);
            g.FillRectangle(frmLGBL, frmTitleL);
            g.FillRectangle(frmLGBR, frmTitleR);
            g.DrawRectangle(frmPen, frmMessageBox);
        }
    }
}
