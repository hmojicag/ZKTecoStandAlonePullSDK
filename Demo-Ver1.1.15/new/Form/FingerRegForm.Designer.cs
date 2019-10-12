namespace StandaloneSDKDemo
{
    partial class FingerRegForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmsRereshUserID = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RefreshUserIDMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmUserID = new System.Windows.Forms.Timer(this.components);
            this.cmsRereshUserID.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsRereshUserID
            // 
            this.cmsRereshUserID.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshUserIDMenuItem});
            this.cmsRereshUserID.Name = "cmsRereshUserID";
            this.cmsRereshUserID.Size = new System.Drawing.Size(113, 26);
            // 
            // RefreshUserIDMenuItem
            // 
            this.RefreshUserIDMenuItem.Name = "RefreshUserIDMenuItem";
            this.RefreshUserIDMenuItem.ShowShortcutKeys = false;
            this.RefreshUserIDMenuItem.Size = new System.Drawing.Size(112, 22);
            this.RefreshUserIDMenuItem.Text = "Refresh";
            this.RefreshUserIDMenuItem.Click += new System.EventHandler(this.RefreshUserIDMenuItem_Click);
            // 
            // tmUserID
            // 
            this.tmUserID.Enabled = true;
            this.tmUserID.Interval = 1000;
            this.tmUserID.Tick += new System.EventHandler(this.tmUserID_Tick);
            // 
            // FingerRegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 392);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FingerRegForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enrolling Finger";
            this.cmsRereshUserID.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmUserID;
        private System.Windows.Forms.ContextMenuStrip cmsRereshUserID;
        private System.Windows.Forms.ToolStripMenuItem RefreshUserIDMenuItem;

    }
}