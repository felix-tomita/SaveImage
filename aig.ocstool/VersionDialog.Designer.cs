namespace aig.ocstool
{
    partial class VersionDialog
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
            this.infoTextBox1 = new System.Windows.Forms.TextBox();
            this.infoTextBox2 = new System.Windows.Forms.TextBox();
            this.infoTextBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // infoTextBox1
            // 
            this.infoTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoTextBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.infoTextBox1.Location = new System.Drawing.Point(14, 18);
            this.infoTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.infoTextBox1.Name = "infoTextBox1";
            this.infoTextBox1.ReadOnly = true;
            this.infoTextBox1.Size = new System.Drawing.Size(336, 18);
            this.infoTextBox1.TabIndex = 0;
            this.infoTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoTextBox2
            // 
            this.infoTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoTextBox2.Font = new System.Drawing.Font("メイリオ", 9F);
            this.infoTextBox2.Location = new System.Drawing.Point(14, 44);
            this.infoTextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.infoTextBox2.Name = "infoTextBox2";
            this.infoTextBox2.ReadOnly = true;
            this.infoTextBox2.Size = new System.Drawing.Size(336, 18);
            this.infoTextBox2.TabIndex = 1;
            this.infoTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoTextBox3
            // 
            this.infoTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoTextBox3.Font = new System.Drawing.Font("メイリオ", 9F);
            this.infoTextBox3.Location = new System.Drawing.Point(14, 70);
            this.infoTextBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.infoTextBox3.Multiline = true;
            this.infoTextBox3.Name = "infoTextBox3";
            this.infoTextBox3.ReadOnly = true;
            this.infoTextBox3.Size = new System.Drawing.Size(336, 70);
            this.infoTextBox3.TabIndex = 2;
            this.infoTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VersionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 153);
            this.Controls.Add(this.infoTextBox3);
            this.Controls.Add(this.infoTextBox2);
            this.Controls.Add(this.infoTextBox1);
            this.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(371, 191);
            this.Name = "VersionDialog";
            this.Text = "VersionDialog";
            this.Load += new System.EventHandler(this.VersionDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox infoTextBox1;
        private System.Windows.Forms.TextBox infoTextBox2;
        private System.Windows.Forms.TextBox infoTextBox3;
    }
}