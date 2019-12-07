namespace aig.ocstool
{
    partial class UrlExclusionDialog
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
            this.txt_edit = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.lst_url_exclustion = new System.Windows.Forms.ListBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_default = new System.Windows.Forms.Button();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_edit
            // 
            this.txt_edit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txt_edit.Location = new System.Drawing.Point(26, 77);
            this.txt_edit.Margin = new System.Windows.Forms.Padding(4);
            this.txt_edit.Name = "txt_edit";
            this.txt_edit.Size = new System.Drawing.Size(396, 25);
            this.txt_edit.TabIndex = 0;
            this.txt_edit.Text = "*siteminderagent/formsja/loginandpwchange*";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(430, 77);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(106, 25);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "追加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lst_url_exclustion
            // 
            this.lst_url_exclustion.FormattingEnabled = true;
            this.lst_url_exclustion.ItemHeight = 18;
            this.lst_url_exclustion.Location = new System.Drawing.Point(26, 124);
            this.lst_url_exclustion.Margin = new System.Windows.Forms.Padding(4);
            this.lst_url_exclustion.Name = "lst_url_exclustion";
            this.lst_url_exclustion.Size = new System.Drawing.Size(396, 166);
            this.lst_url_exclustion.TabIndex = 3;
            this.lst_url_exclustion.SelectedIndexChanged += new System.EventHandler(this.lst_url_exclustion_SelectedIndexChanged);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(430, 124);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(4);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(106, 25);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "削除";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_default
            // 
            this.btn_default.Location = new System.Drawing.Point(430, 158);
            this.btn_default.Margin = new System.Windows.Forms.Padding(4);
            this.btn_default.Name = "btn_default";
            this.btn_default.Size = new System.Drawing.Size(106, 25);
            this.btn_default.TabIndex = 5;
            this.btn_default.Text = "初期化";
            this.btn_default.UseVisualStyleBackColor = true;
            this.btn_default.Click += new System.EventHandler(this.btn_default_Click);
            // 
            // txt_msg
            // 
            this.txt_msg.BackColor = System.Drawing.SystemColors.Control;
            this.txt_msg.Location = new System.Drawing.Point(26, 16);
            this.txt_msg.Margin = new System.Windows.Forms.Padding(4);
            this.txt_msg.Multiline = true;
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(510, 48);
            this.txt_msg.TabIndex = 6;
            this.txt_msg.TabStop = false;
            this.txt_msg.Text = "記憶しないWebサイトのアドレス（キーワード）\r\n※Default：*siteminderagent/formsja/loginandpwchange*";
            // 
            // UrlExclusionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 339);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.btn_default);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.lst_url_exclustion);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_edit);
            this.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "UrlExclusionDialog";
            this.Text = "Url Exclusion Dialog";
            this.Closed += new System.EventHandler(this.UrlExclusionDialog_Closed);
            this.Load += new System.EventHandler(this.UrlExclusionDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_edit;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ListBox lst_url_exclustion;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_default;
        private System.Windows.Forms.TextBox txt_msg;
    }
}

