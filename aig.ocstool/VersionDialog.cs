using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aig.ocstool
{
    public partial class VersionDialog : Form
    {
        public VersionDialog() : this("AIG General Insurance Company,Ltd.", "", "Create by Felix")
        {
            InitializeComponent();
        }

        public VersionDialog(string appName, string appVersion, string appInfo)
        {
            InitializeComponent();

            this.infoTextBox1.Text = appName;
            this.infoTextBox2.Text = appVersion;
            this.infoTextBox3.Text = appInfo;
        }

        private void VersionDialog_Load(object sender, EventArgs e)
        {
            // 親フォーム中央
            int left, top;
            left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.DesktopLocation = new Point(left, top);
        }

    }
}
