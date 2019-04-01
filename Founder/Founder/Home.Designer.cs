namespace Founder
{
    partial class Home
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
            this.button1 = new System.Windows.Forms.Button();
            this.rbOn = new System.Windows.Forms.RadioButton();
            this.rbOff = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbOn
            // 
            this.rbOn.AutoSize = true;
            this.rbOn.Location = new System.Drawing.Point(6, 21);
            this.rbOn.Name = "rbOn";
            this.rbOn.Size = new System.Drawing.Size(35, 16);
            this.rbOn.TabIndex = 1;
            this.rbOn.TabStop = true;
            this.rbOn.Text = "开";
            this.rbOn.UseVisualStyleBackColor = true;
            this.rbOn.CheckedChanged += new System.EventHandler(this.rbOn_CheckedChanged);
            // 
            // rbOff
            // 
            this.rbOff.AutoSize = true;
            this.rbOff.Location = new System.Drawing.Point(66, 21);
            this.rbOff.Name = "rbOff";
            this.rbOff.Size = new System.Drawing.Size(35, 16);
            this.rbOff.TabIndex = 2;
            this.rbOff.TabStop = true;
            this.rbOff.Text = "关";
            this.rbOff.UseVisualStyleBackColor = true;
            this.rbOff.CheckedChanged += new System.EventHandler(this.rbOff_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOn);
            this.groupBox1.Controls.Add(this.rbOff);
            this.groupBox1.Location = new System.Drawing.Point(84, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(103, 49);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 221);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Home_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbOn;
        private System.Windows.Forms.RadioButton rbOff;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

