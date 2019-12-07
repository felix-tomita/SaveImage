namespace aig.ocstool
{
    partial class ControlViewer
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
            this.dgvControl = new System.Windows.Forms.DataGridView();
            this.gp_io = new System.Windows.Forms.GroupBox();
            this.cob_ctrl_name = new System.Windows.Forms.ComboBox();
            this.btn_exec = new System.Windows.Forms.Button();
            this.txt_input_value = new System.Windows.Forms.TextBox();
            this.lbl_ctrl_name = new System.Windows.Forms.Label();
            this.lbl_input_value = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvControl)).BeginInit();
            this.gp_io.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvControl
            // 
            this.dgvControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvControl.Location = new System.Drawing.Point(2, 75);
            this.dgvControl.Name = "dgvControl";
            this.dgvControl.RowTemplate.Height = 23;
            this.dgvControl.Size = new System.Drawing.Size(651, 203);
            this.dgvControl.TabIndex = 0;
            // 
            // gp_io
            // 
            this.gp_io.Controls.Add(this.lbl_input_value);
            this.gp_io.Controls.Add(this.lbl_ctrl_name);
            this.gp_io.Controls.Add(this.txt_input_value);
            this.gp_io.Controls.Add(this.btn_exec);
            this.gp_io.Controls.Add(this.cob_ctrl_name);
            this.gp_io.Location = new System.Drawing.Point(2, -8);
            this.gp_io.Name = "gp_io";
            this.gp_io.Size = new System.Drawing.Size(651, 80);
            this.gp_io.TabIndex = 1;
            this.gp_io.TabStop = false;
            // 
            // cob_ctrl_name
            // 
            this.cob_ctrl_name.FormattingEnabled = true;
            this.cob_ctrl_name.Location = new System.Drawing.Point(105, 19);
            this.cob_ctrl_name.Name = "cob_ctrl_name";
            this.cob_ctrl_name.Size = new System.Drawing.Size(145, 26);
            this.cob_ctrl_name.TabIndex = 0;
            // 
            // btn_exec
            // 
            this.btn_exec.Location = new System.Drawing.Point(560, 20);
            this.btn_exec.Name = "btn_exec";
            this.btn_exec.Size = new System.Drawing.Size(82, 25);
            this.btn_exec.TabIndex = 1;
            this.btn_exec.Text = "Exection";
            this.btn_exec.UseVisualStyleBackColor = true;
            this.btn_exec.Click += new System.EventHandler(this.btn_exec_Click);
            // 
            // txt_input_value
            // 
            this.txt_input_value.Location = new System.Drawing.Point(360, 19);
            this.txt_input_value.Name = "txt_input_value";
            this.txt_input_value.Size = new System.Drawing.Size(139, 25);
            this.txt_input_value.TabIndex = 2;
            // 
            // lbl_ctrl_name
            // 
            this.lbl_ctrl_name.AutoSize = true;
            this.lbl_ctrl_name.Location = new System.Drawing.Point(10, 22);
            this.lbl_ctrl_name.Name = "lbl_ctrl_name";
            this.lbl_ctrl_name.Size = new System.Drawing.Size(89, 18);
            this.lbl_ctrl_name.TabIndex = 3;
            this.lbl_ctrl_name.Text = "Control Name";
            // 
            // lbl_input_value
            // 
            this.lbl_input_value.AutoSize = true;
            this.lbl_input_value.Location = new System.Drawing.Point(280, 22);
            this.lbl_input_value.Name = "lbl_input_value";
            this.lbl_input_value.Size = new System.Drawing.Size(74, 18);
            this.lbl_input_value.TabIndex = 4;
            this.lbl_input_value.Text = "Input Value";
            // 
            // ControlViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 280);
            this.Controls.Add(this.gp_io);
            this.Controls.Add(this.dgvControl);
            this.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ControlViewer";
            this.Text = "Control Panel";
            this.Load += new System.EventHandler(this.ControlViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvControl)).EndInit();
            this.gp_io.ResumeLayout(false);
            this.gp_io.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvControl;
        private System.Windows.Forms.GroupBox gp_io;
        private System.Windows.Forms.ComboBox cob_ctrl_name;
        private System.Windows.Forms.Button btn_exec;
        private System.Windows.Forms.Label lbl_input_value;
        private System.Windows.Forms.Label lbl_ctrl_name;
        private System.Windows.Forms.TextBox txt_input_value;
    }
}

