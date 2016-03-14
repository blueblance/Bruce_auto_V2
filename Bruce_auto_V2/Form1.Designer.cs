namespace Bruce_auto_V2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_hsa = new System.Windows.Forms.TextBox();
            this.textBox_hbp = new System.Windows.Forms.TextBox();
            this.textBox_hactive = new System.Windows.Forms.TextBox();
            this.textBox_hfp = new System.Windows.Forms.TextBox();
            this.textBox_vactive = new System.Windows.Forms.TextBox();
            this.textBox_vfp = new System.Windows.Forms.TextBox();
            this.textBox_vbp = new System.Windows.Forms.TextBox();
            this.textBox_vsa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(682, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(373, 434);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(278, 245);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(268, 324);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 3;
            // 
            // textBox_hsa
            // 
            this.textBox_hsa.Location = new System.Drawing.Point(166, 30);
            this.textBox_hsa.Name = "textBox_hsa";
            this.textBox_hsa.Size = new System.Drawing.Size(72, 22);
            this.textBox_hsa.TabIndex = 4;
            // 
            // textBox_hbp
            // 
            this.textBox_hbp.Location = new System.Drawing.Point(278, 30);
            this.textBox_hbp.Name = "textBox_hbp";
            this.textBox_hbp.Size = new System.Drawing.Size(72, 22);
            this.textBox_hbp.TabIndex = 6;
            // 
            // textBox_hactive
            // 
            this.textBox_hactive.Location = new System.Drawing.Point(502, 30);
            this.textBox_hactive.Name = "textBox_hactive";
            this.textBox_hactive.Size = new System.Drawing.Size(72, 22);
            this.textBox_hactive.TabIndex = 10;
            // 
            // textBox_hfp
            // 
            this.textBox_hfp.Location = new System.Drawing.Point(390, 30);
            this.textBox_hfp.Name = "textBox_hfp";
            this.textBox_hfp.Size = new System.Drawing.Size(72, 22);
            this.textBox_hfp.TabIndex = 8;
            // 
            // textBox_vactive
            // 
            this.textBox_vactive.Location = new System.Drawing.Point(502, 58);
            this.textBox_vactive.Name = "textBox_vactive";
            this.textBox_vactive.Size = new System.Drawing.Size(72, 22);
            this.textBox_vactive.TabIndex = 14;
            // 
            // textBox_vfp
            // 
            this.textBox_vfp.Location = new System.Drawing.Point(390, 58);
            this.textBox_vfp.Name = "textBox_vfp";
            this.textBox_vfp.Size = new System.Drawing.Size(72, 22);
            this.textBox_vfp.TabIndex = 13;
            // 
            // textBox_vbp
            // 
            this.textBox_vbp.Location = new System.Drawing.Point(278, 58);
            this.textBox_vbp.Name = "textBox_vbp";
            this.textBox_vbp.Size = new System.Drawing.Size(72, 22);
            this.textBox_vbp.TabIndex = 12;
            // 
            // textBox_vsa
            // 
            this.textBox_vsa.Location = new System.Drawing.Point(166, 58);
            this.textBox_vsa.Name = "textBox_vsa";
            this.textBox_vsa.Size = new System.Drawing.Size(72, 22);
            this.textBox_vsa.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 618);
            this.Controls.Add(this.textBox_vactive);
            this.Controls.Add(this.textBox_vfp);
            this.Controls.Add(this.textBox_vbp);
            this.Controls.Add(this.textBox_vsa);
            this.Controls.Add(this.textBox_hactive);
            this.Controls.Add(this.textBox_hfp);
            this.Controls.Add(this.textBox_hbp);
            this.Controls.Add(this.textBox_hsa);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox_hsa;
        private System.Windows.Forms.TextBox textBox_hbp;
        private System.Windows.Forms.TextBox textBox_hactive;
        private System.Windows.Forms.TextBox textBox_hfp;
        private System.Windows.Forms.TextBox textBox_vactive;
        private System.Windows.Forms.TextBox textBox_vfp;
        private System.Windows.Forms.TextBox textBox_vbp;
        private System.Windows.Forms.TextBox textBox_vsa;
    }
}

