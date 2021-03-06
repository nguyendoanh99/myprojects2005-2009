namespace TripleDES
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.butBrowseInput = new System.Windows.Forms.Button();
            this.butBrowseOutput = new System.Windows.Forms.Button();
            this.butEncrypt = new System.Windows.Forms.Button();
            this.butDecrypt = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.rB128 = new System.Windows.Forms.RadioButton();
            this.rb192 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tập tin nguồn";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tập tin đích";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(93, 13);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(170, 20);
            this.txtInput.TabIndex = 2;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(93, 39);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(170, 20);
            this.txtOutput.TabIndex = 3;
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(93, 65);
            this.txtPassword.MaxLength = 24;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(170, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // butBrowseInput
            // 
            this.butBrowseInput.Location = new System.Drawing.Point(273, 12);
            this.butBrowseInput.Name = "butBrowseInput";
            this.butBrowseInput.Size = new System.Drawing.Size(29, 20);
            this.butBrowseInput.TabIndex = 6;
            this.butBrowseInput.Text = "...";
            this.butBrowseInput.UseVisualStyleBackColor = true;
            this.butBrowseInput.Click += new System.EventHandler(this.butBrowseInput_Click);
            // 
            // butBrowseOutput
            // 
            this.butBrowseOutput.Location = new System.Drawing.Point(273, 38);
            this.butBrowseOutput.Name = "butBrowseOutput";
            this.butBrowseOutput.Size = new System.Drawing.Size(29, 20);
            this.butBrowseOutput.TabIndex = 7;
            this.butBrowseOutput.Text = "...";
            this.butBrowseOutput.UseVisualStyleBackColor = true;
            this.butBrowseOutput.Click += new System.EventHandler(this.butBrowseOutput_Click);
            // 
            // butEncrypt
            // 
            this.butEncrypt.Location = new System.Drawing.Point(127, 130);
            this.butEncrypt.Name = "butEncrypt";
            this.butEncrypt.Size = new System.Drawing.Size(88, 25);
            this.butEncrypt.TabIndex = 8;
            this.butEncrypt.Text = "Mã hóa";
            this.butEncrypt.UseVisualStyleBackColor = true;
            this.butEncrypt.Click += new System.EventHandler(this.butEncrypt_Click);
            // 
            // butDecrypt
            // 
            this.butDecrypt.Location = new System.Drawing.Point(221, 130);
            this.butDecrypt.Name = "butDecrypt";
            this.butDecrypt.Size = new System.Drawing.Size(88, 25);
            this.butDecrypt.TabIndex = 9;
            this.butDecrypt.Text = "Giải mã";
            this.butDecrypt.UseVisualStyleBackColor = true;
            this.butDecrypt.Click += new System.EventHandler(this.butDecrypt_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Kích thước khóa";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // rB128
            // 
            this.rB128.AutoSize = true;
            this.rB128.Location = new System.Drawing.Point(127, 96);
            this.rB128.Name = "rB128";
            this.rB128.Size = new System.Drawing.Size(57, 17);
            this.rB128.TabIndex = 11;
            this.rB128.Text = "128 bit";
            this.rB128.UseVisualStyleBackColor = true;
            this.rB128.CheckedChanged += new System.EventHandler(this.rB128_CheckedChanged);
            // 
            // rb192
            // 
            this.rb192.AutoSize = true;
            this.rb192.Checked = true;
            this.rb192.Location = new System.Drawing.Point(206, 96);
            this.rb192.Name = "rb192";
            this.rb192.Size = new System.Drawing.Size(57, 17);
            this.rb192.TabIndex = 12;
            this.rb192.TabStop = true;
            this.rb192.Text = "192 bit";
            this.rb192.UseVisualStyleBackColor = true;
            this.rb192.CheckedChanged += new System.EventHandler(this.rb192_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 176);
            this.Controls.Add(this.rb192);
            this.Controls.Add(this.rB128);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butDecrypt);
            this.Controls.Add(this.butEncrypt);
            this.Controls.Add(this.butBrowseOutput);
            this.Controls.Add(this.butBrowseInput);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Triple DES";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butBrowseInput;
        private System.Windows.Forms.Button butBrowseOutput;
        private System.Windows.Forms.Button butEncrypt;
        private System.Windows.Forms.Button butDecrypt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rB128;
        private System.Windows.Forms.RadioButton rb192;
    }
}

