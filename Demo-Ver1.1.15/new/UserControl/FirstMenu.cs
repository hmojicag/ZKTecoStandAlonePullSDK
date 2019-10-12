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
    public partial class FirstMenu :UserControl
    {
        public delegate void MouseSelectedEventHandler(object sender, EventArgs e);
        public event MouseSelectedEventHandler MouseSelected;

        private bool a_Selected = false;

        private Color activeColor = Color.White;
        private Color defaultColor = Color.Transparent;
        private Image mouseEnterImage = Properties.Resources.FirstMenuM;
        private Color defaultForeColor = Color.Black;

        public FirstMenu()
        {
            InitializeComponent();
            label1.Text = this.Name;
        }

        /// <summary>
        /// background color when selected
        /// </summary>
        public Color ActiveColor
        {
            get { return activeColor; }
            set { activeColor = value; }
        }

        /// <summary>
        /// default background color
        /// </summary>
        public Color DefaultColor
        {
            get { return defaultColor; }
            set { defaultColor = value; }
        }

        /// <summary>
        /// menu caption
        /// </summary>
        public string Caption
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }

        /// <summary>
        /// menu font
        /// </summary>
        public Font TextFont
        {
            get
            {
                return label1.Font;
            }
            set
            {
                label1.Font = value;
            }
        }

        public Color TextColor
        {
            set
            {
                label1.ForeColor = value;
            }
        }

        /// <summary>
        /// set background color when menu selected
        /// </summary>
        [DefaultValue(false)]
        public bool Selected
        {
            get
            {
                return a_Selected;
            }
            set
            {
                a_Selected = value;
                if (!a_Selected)
                {
                    this.BackColor = defaultColor;
                }
                else
                {
                    this.BackColor = activeColor;
                }
            }
        }

        public void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Selected = true;
                this.BackColor = activeColor;
                if (MouseSelected != null)
                    MouseSelected(this, new EventArgs());
            }
            
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = mouseEnterImage;
        }

        public void label1_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
