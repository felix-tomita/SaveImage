namespace aig.ocstool
{
    partial class SaveImageForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveImageForm));
            this.MyToolStrip = new System.Windows.Forms.ToolStrip();
            this.tsb_GoBack = new System.Windows.Forms.ToolStripButton();
            this.tsb_GoAhead = new System.Windows.Forms.ToolStripButton();
            this.tsb_Stop = new System.Windows.Forms.ToolStripButton();
            this.tsb_Refresh = new System.Windows.Forms.ToolStripButton();
            this.tsb_GoHome = new System.Windows.Forms.ToolStripButton();
            this.tsb_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_SaveImage = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsb_SaveImageToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_sep11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_SetImageFileType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_ImageFile_ExtList = new System.Windows.Forms.ToolStripComboBox();
            this.tsb_SetVerticalScrollSize = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_SetVerticalScrollSize = new System.Windows.Forms.ToolStripTextBox();
            this.tsb_SaveToClipboard = new System.Windows.Forms.ToolStripButton();
            this.tsb_sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Option = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsb_Setting_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_ctrl_panel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_sep3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Opt_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.UrlTimer = new System.Windows.Forms.Timer(this.components);
            this.lbl_address = new System.Windows.Forms.Label();
            this.TargetWebBrowser = new System.Windows.Forms.WebBrowser();
            this.cob_url = new System.Windows.Forms.ComboBox();
            this.MyStatusBar = new System.Windows.Forms.StatusStrip();
            this.tsl_msg = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.MyToolStrip.SuspendLayout();
            this.MyStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyToolStrip
            // 
            this.MyToolStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.MyToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_GoBack,
            this.tsb_GoAhead,
            this.tsb_Stop,
            this.tsb_Refresh,
            this.tsb_GoHome,
            this.tsb_sep1,
            this.tsb_SaveImage,
            this.tsb_SaveToClipboard,
            this.tsb_sep2,
            this.tsb_Option});
            this.MyToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MyToolStrip.Name = "MyToolStrip";
            this.MyToolStrip.Size = new System.Drawing.Size(584, 32);
            this.MyToolStrip.TabIndex = 0;
            this.MyToolStrip.Text = "toolStrip1";
            // 
            // tsb_GoBack
            // 
            this.tsb_GoBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_GoBack.Image = ((System.Drawing.Image)(resources.GetObject("tsb_GoBack.Image")));
            this.tsb_GoBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_GoBack.Name = "tsb_GoBack";
            this.tsb_GoBack.Size = new System.Drawing.Size(29, 29);
            this.tsb_GoBack.Text = "GoBack";
            this.tsb_GoBack.Click += new System.EventHandler(this.tsb_GoBack_Click);
            // 
            // tsb_GoAhead
            // 
            this.tsb_GoAhead.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_GoAhead.Image = ((System.Drawing.Image)(resources.GetObject("tsb_GoAhead.Image")));
            this.tsb_GoAhead.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_GoAhead.Name = "tsb_GoAhead";
            this.tsb_GoAhead.Size = new System.Drawing.Size(29, 29);
            this.tsb_GoAhead.Text = "GoAhead";
            this.tsb_GoAhead.Click += new System.EventHandler(this.tsb_GoAhead_Click);
            // 
            // tsb_Stop
            // 
            this.tsb_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Stop.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Stop.Image")));
            this.tsb_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Stop.Name = "tsb_Stop";
            this.tsb_Stop.Size = new System.Drawing.Size(29, 29);
            this.tsb_Stop.Text = "Stop";
            this.tsb_Stop.Click += new System.EventHandler(this.tsb_Stop_Click);
            // 
            // tsb_Refresh
            // 
            this.tsb_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Refresh.Image")));
            this.tsb_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Refresh.Name = "tsb_Refresh";
            this.tsb_Refresh.Size = new System.Drawing.Size(29, 29);
            this.tsb_Refresh.Text = "Refresh";
            this.tsb_Refresh.Click += new System.EventHandler(this.tsb_Refresh_Click);
            // 
            // tsb_GoHome
            // 
            this.tsb_GoHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_GoHome.Image = ((System.Drawing.Image)(resources.GetObject("tsb_GoHome.Image")));
            this.tsb_GoHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_GoHome.Name = "tsb_GoHome";
            this.tsb_GoHome.Size = new System.Drawing.Size(29, 29);
            this.tsb_GoHome.Text = "GoHome";
            this.tsb_GoHome.Click += new System.EventHandler(this.tsb_GoHome_Click);
            // 
            // tsb_sep1
            // 
            this.tsb_sep1.Name = "tsb_sep1";
            this.tsb_sep1.Size = new System.Drawing.Size(6, 32);
            // 
            // tsb_SaveImage
            // 
            this.tsb_SaveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_SaveImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_SaveImageToFile,
            this.tsb_sep11,
            this.tsb_SetImageFileType,
            this.tsb_SetVerticalScrollSize});
            this.tsb_SaveImage.Image = ((System.Drawing.Image)(resources.GetObject("tsb_SaveImage.Image")));
            this.tsb_SaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_SaveImage.Name = "tsb_SaveImage";
            this.tsb_SaveImage.Size = new System.Drawing.Size(38, 29);
            this.tsb_SaveImage.Text = "Save Image";
            // 
            // tsb_SaveImageToFile
            // 
            this.tsb_SaveImageToFile.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.tsb_SaveImageToFile.Image = ((System.Drawing.Image)(resources.GetObject("tsb_SaveImageToFile.Image")));
            this.tsb_SaveImageToFile.Name = "tsb_SaveImageToFile";
            this.tsb_SaveImageToFile.Size = new System.Drawing.Size(295, 32);
            this.tsb_SaveImageToFile.Text = "Save Image to File [Shift + D]";
            this.tsb_SaveImageToFile.ToolTipText = "Save Image to File [Shift + D]";
            this.tsb_SaveImageToFile.Click += new System.EventHandler(this.tsb_SaveImageToFile_Click);
            // 
            // tsb_sep11
            // 
            this.tsb_sep11.Name = "tsb_sep11";
            this.tsb_sep11.Size = new System.Drawing.Size(292, 6);
            // 
            // tsb_SetImageFileType
            // 
            this.tsb_SetImageFileType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_ImageFile_ExtList});
            this.tsb_SetImageFileType.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.tsb_SetImageFileType.Image = ((System.Drawing.Image)(resources.GetObject("tsb_SetImageFileType.Image")));
            this.tsb_SetImageFileType.Name = "tsb_SetImageFileType";
            this.tsb_SetImageFileType.Size = new System.Drawing.Size(295, 32);
            this.tsb_SetImageFileType.Text = "Select File Type";
            this.tsb_SetImageFileType.ToolTipText = "Select the Image File Type";
            // 
            // tsb_ImageFile_ExtList
            // 
            this.tsb_ImageFile_ExtList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsb_ImageFile_ExtList.Font = new System.Drawing.Font("メイリオ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tsb_ImageFile_ExtList.Name = "tsb_ImageFile_ExtList";
            this.tsb_ImageFile_ExtList.Size = new System.Drawing.Size(121, 29);
            this.tsb_ImageFile_ExtList.SelectedIndexChanged += new System.EventHandler(this.tsb_ImageFile_ExtList_SelectedIndexChanged);
            // 
            // tsb_SetVerticalScrollSize
            // 
            this.tsb_SetVerticalScrollSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txt_SetVerticalScrollSize});
            this.tsb_SetVerticalScrollSize.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.tsb_SetVerticalScrollSize.Image = ((System.Drawing.Image)(resources.GetObject("tsb_SetVerticalScrollSize.Image")));
            this.tsb_SetVerticalScrollSize.Name = "tsb_SetVerticalScrollSize";
            this.tsb_SetVerticalScrollSize.Size = new System.Drawing.Size(295, 32);
            this.tsb_SetVerticalScrollSize.Text = "Vertical Division Size";
            this.tsb_SetVerticalScrollSize.ToolTipText = "The size which split the vertiacl scroll";
            // 
            // txt_SetVerticalScrollSize
            // 
            this.txt_SetVerticalScrollSize.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.txt_SetVerticalScrollSize.MaxLength = 4;
            this.txt_SetVerticalScrollSize.Name = "txt_SetVerticalScrollSize";
            this.txt_SetVerticalScrollSize.Size = new System.Drawing.Size(100, 28);
            this.txt_SetVerticalScrollSize.LostFocus += new System.EventHandler(this.txt_SetVerticalScrollSize_LostFocus);
            this.txt_SetVerticalScrollSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SetVerticalScrollSize_KeyPress);
            // 
            // tsb_SaveToClipboard
            // 
            this.tsb_SaveToClipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_SaveToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("tsb_SaveToClipboard.Image")));
            this.tsb_SaveToClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_SaveToClipboard.Name = "tsb_SaveToClipboard";
            this.tsb_SaveToClipboard.Size = new System.Drawing.Size(29, 29);
            this.tsb_SaveToClipboard.Text = "Save Image to Clipboard [Shift + C]";
            this.tsb_SaveToClipboard.Click += new System.EventHandler(this.tsb_SaveToClipboard_Click);
            // 
            // tsb_sep2
            // 
            this.tsb_sep2.Name = "tsb_sep2";
            this.tsb_sep2.Size = new System.Drawing.Size(6, 32);
            // 
            // tsb_Option
            // 
            this.tsb_Option.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Option.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Setting_Info,
            this.tsb_ctrl_panel,
            this.tsb_sep3,
            this.tsb_Opt_Info});
            this.tsb_Option.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Option.Image")));
            this.tsb_Option.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Option.Name = "tsb_Option";
            this.tsb_Option.Size = new System.Drawing.Size(38, 29);
            this.tsb_Option.Text = "Option";
            // 
            // tsb_Setting_Info
            // 
            this.tsb_Setting_Info.Font = new System.Drawing.Font("メイリオ", 10F);
            this.tsb_Setting_Info.Name = "tsb_Setting_Info";
            this.tsb_Setting_Info.Size = new System.Drawing.Size(194, 26);
            this.tsb_Setting_Info.Text = "&Tool Option (T)";
            this.tsb_Setting_Info.ToolTipText = "Tool Option";
            this.tsb_Setting_Info.Click += new System.EventHandler(this.tsb_Setting_Info_Click);
            // 
            // tsb_ctrl_panel
            // 
            this.tsb_ctrl_panel.Font = new System.Drawing.Font("メイリオ", 10F);
            this.tsb_ctrl_panel.Name = "tsb_ctrl_panel";
            this.tsb_ctrl_panel.Size = new System.Drawing.Size(194, 26);
            this.tsb_ctrl_panel.Text = "Control &Panel (P)";
            this.tsb_ctrl_panel.ToolTipText = "Control Panel";
            this.tsb_ctrl_panel.Click += new System.EventHandler(this.tsb_ctrl_panel_Click);
            // 
            // tsb_sep3
            // 
            this.tsb_sep3.Name = "tsb_sep3";
            this.tsb_sep3.Size = new System.Drawing.Size(191, 6);
            // 
            // tsb_Opt_Info
            // 
            this.tsb_Opt_Info.Font = new System.Drawing.Font("メイリオ", 10F);
            this.tsb_Opt_Info.Name = "tsb_Opt_Info";
            this.tsb_Opt_Info.Size = new System.Drawing.Size(194, 26);
            this.tsb_Opt_Info.Text = "&About Tool (A)";
            this.tsb_Opt_Info.ToolTipText = "About SaveImage";
            this.tsb_Opt_Info.Click += new System.EventHandler(this.tsb_Opt_Info_Click);
            // 
            // UrlTimer
            // 
            this.UrlTimer.Interval = 300;
            this.UrlTimer.Tick += new System.EventHandler(this.UrlTimer_Tick);
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.Font = new System.Drawing.Font("Arial Unicode MS", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_address.Location = new System.Drawing.Point(12, 37);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(61, 19);
            this.lbl_address.TabIndex = 1;
            this.lbl_address.Text = "Address";
            this.lbl_address.DoubleClick += new System.EventHandler(this.lbl_address_Info_DoubleClick);
            // 
            // TargetWebBrowser
            // 
            this.TargetWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetWebBrowser.Location = new System.Drawing.Point(5, 65);
            this.TargetWebBrowser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TargetWebBrowser.MinimumSize = new System.Drawing.Size(23, 30);
            this.TargetWebBrowser.Name = "TargetWebBrowser";
            this.TargetWebBrowser.ScriptErrorsSuppressed = true;
            this.TargetWebBrowser.Size = new System.Drawing.Size(573, 269);
            this.TargetWebBrowser.TabIndex = 3;
            this.TargetWebBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.TargetWebBrowser_Navigated);
            this.TargetWebBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.TargetWebBrowser_Navigating);
            this.TargetWebBrowser.NewWindow += new System.ComponentModel.CancelEventHandler(this.TargetWebBrowser_NewWindow);
            this.TargetWebBrowser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TargetWebBrowser_PreviewKeyDown);
            // 
            // cob_url
            // 
            this.cob_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cob_url.Font = new System.Drawing.Font("Arial Unicode MS", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cob_url.FormattingEnabled = true;
            this.cob_url.Location = new System.Drawing.Point(90, 33);
            this.cob_url.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cob_url.Name = "cob_url";
            this.cob_url.Size = new System.Drawing.Size(480, 27);
            this.cob_url.TabIndex = 4;
            this.cob_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cob_url_KeyDown);
            this.cob_url.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cob_url_KeyPress);
            this.cob_url.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cob_url_KeyUp);
            // 
            // MyStatusBar
            // 
            this.MyStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl_msg});
            this.MyStatusBar.Location = new System.Drawing.Point(0, 340);
            this.MyStatusBar.Name = "MyStatusBar";
            this.MyStatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.MyStatusBar.Size = new System.Drawing.Size(584, 22);
            this.MyStatusBar.TabIndex = 5;
            this.MyStatusBar.Text = "statusStrip1";
            // 
            // tsl_msg
            // 
            this.tsl_msg.Name = "tsl_msg";
            this.tsl_msg.Size = new System.Drawing.Size(0, 17);
            // 
            // StatusTimer
            // 
            this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // SaveImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.MyStatusBar);
            this.Controls.Add(this.cob_url);
            this.Controls.Add(this.TargetWebBrowser);
            this.Controls.Add(this.lbl_address);
            this.Controls.Add(this.MyToolStrip);
            this.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SaveImageForm";
            this.Closed += new System.EventHandler(this.SaveImageForm_Closed);
            this.Load += new System.EventHandler(this.SaveImageForm_Load);
            this.MyToolStrip.ResumeLayout(false);
            this.MyToolStrip.PerformLayout();
            this.MyStatusBar.ResumeLayout(false);
            this.MyStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MyToolStrip;
        private System.Windows.Forms.Timer UrlTimer;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.WebBrowser TargetWebBrowser;
        private System.Windows.Forms.ComboBox cob_url;
        private System.Windows.Forms.ToolStripButton tsb_GoBack;
        private System.Windows.Forms.ToolStripButton tsb_GoAhead;
        private System.Windows.Forms.ToolStripButton tsb_Stop;
        private System.Windows.Forms.ToolStripButton tsb_Refresh;
        private System.Windows.Forms.ToolStripButton tsb_GoHome;
        private System.Windows.Forms.ToolStripButton tsb_SaveToClipboard;
        private System.Windows.Forms.StatusStrip MyStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel tsl_msg;
        private System.Windows.Forms.Timer StatusTimer;
        private System.Windows.Forms.ToolStripSeparator tsb_sep1;
        private System.Windows.Forms.ToolStripSeparator tsb_sep2;
        private System.Windows.Forms.ToolStripDropDownButton tsb_Option;
        private System.Windows.Forms.ToolStripSeparator tsb_sep3;
        private System.Windows.Forms.ToolStripMenuItem tsb_Opt_Info;
        private System.Windows.Forms.ToolStripDropDownButton tsb_SaveImage;
        private System.Windows.Forms.ToolStripMenuItem tsb_SaveImageToFile;
        private System.Windows.Forms.ToolStripMenuItem tsb_SetVerticalScrollSize;
        private System.Windows.Forms.ToolStripTextBox txt_SetVerticalScrollSize;
        private System.Windows.Forms.ToolStripMenuItem tsb_SetImageFileType;
        private System.Windows.Forms.ToolStripComboBox tsb_ImageFile_ExtList;
        private System.Windows.Forms.ToolStripSeparator tsb_sep11;
        private System.Windows.Forms.ToolStripMenuItem tsb_Setting_Info;
        private System.Windows.Forms.ToolStripMenuItem tsb_ctrl_panel;
    }
}

