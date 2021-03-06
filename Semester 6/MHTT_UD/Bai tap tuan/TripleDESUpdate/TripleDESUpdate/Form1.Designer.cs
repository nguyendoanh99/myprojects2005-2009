namespace TripleDESUpdate
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
            this.butBrowseInput = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.butEncrypt = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.rB128 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.butDecrypt = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rb192 = new System.Windows.Forms.RadioButton();
            this.butBrowseOutput = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPaddingMode = new System.Windows.Forms.ComboBox();
            this.cmbModeofOperation = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butBrowseInput
            // 
            this.butBrowseInput.Location = new System.Drawing.Point(264, 11);
            this.butBrowseInput.Name = "butBrowseInput";
            this.butBrowseInput.Size = new System.Drawing.Size(29, 20);
            this.butBrowseInput.TabIndex = 19;
            this.butBrowseInput.Text = "...";
            this.butBrowseInput.UseVisualStyleBackColor = true;
            this.butBrowseInput.Click += new System.EventHandler(this.butBrowseInput_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(84, 64);
            this.txtPassword.MaxLength = 24;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(170, 20);
            this.txtPassword.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Mật khẩu";
            // 
            // butEncrypt
            // 
            this.butEncrypt.Location = new System.Drawing.Point(117, 205);
            this.butEncrypt.Name = "butEncrypt";
            this.butEncrypt.Size = new System.Drawing.Size(88, 25);
            this.butEncrypt.TabIndex = 21;
            this.butEncrypt.Text = "Mã hóa";
            this.butEncrypt.UseVisualStyleBackColor = true;
            this.butEncrypt.Click += new System.EventHandler(this.butEncrypt_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(84, 38);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(170, 20);
            this.txtOutput.TabIndex = 16;
            // 
            // rB128
            // 
            this.rB128.AutoSize = true;
            this.rB128.Location = new System.Drawing.Point(117, 171);
            this.rB128.Name = "rB128";
            this.rB128.Size = new System.Drawing.Size(57, 17);
            this.rB128.TabIndex = 24;
            this.rB128.Text = "128 bit";
            this.rB128.UseVisualStyleBackColor = true;
            this.rB128.CheckedChanged += new System.EventHandler(this.rB128_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Kích thước khóa";
            // 
            // butDecrypt
            // 
            this.butDecrypt.Location = new System.Drawing.Point(211, 205);
            this.butDecrypt.Name = "butDecrypt";
            this.butDecrypt.Size = new System.Drawing.Size(88, 25);
            this.butDecrypt.TabIndex = 22;
            this.butDecrypt.Text = "Giải mã";
            this.butDecrypt.UseVisualStyleBackColor = true;
            this.butDecrypt.Click += new System.EventHandler(this.butDecrypt_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // rb192
            // 
            this.rb192.AutoSize = true;
            this.rb192.Checked = true;
            this.rb192.Location = new System.Drawing.Point(196, 171);
            this.rb192.Name = "rb192";
            this.rb192.Size = new System.Drawing.Size(57, 17);
            this.rb192.TabIndex = 25;
            this.rb192.TabStop = true;
            this.rb192.Text = "192 bit";
            this.rb192.UseVisualStyleBackColor = true;
            this.rb192.CheckedChanged += new System.EventHandler(this.rb192_CheckedChanged);
            // 
            // butBrowseOutput
            // 
            this.butBrowseOutput.Location = new System.Drawing.Point(264, 37);
            this.butBrowseOutput.Name = "butBrowseOutput";
            this.butBrowseOutput.Size = new System.Drawing.Size(29, 20);
            this.butBrowseOutput.TabIndex = 20;
            this.butBrowseOutput.Text = "...";
            this.butBrowseOutput.UseVisualStyleBackColor = true;
            this.butBrowseOutput.Click += new System.EventHandler(this.butBrowseOutput_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(84, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(170, 20);
            this.txtInput.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tập tin đích";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tập tin nguồn";
            // 
            // txtIV
            // 
            this.txtIV.Location = new System.Drawing.Point(84, 90);
            this.txtIV.MaxLength = 8;
            this.txtIV.Name = "txtIV";
            this.txtIV.Size = new System.Drawing.Size(170, 20);
            this.txtIV.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "IV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Padding mode";
            // 
            // cmbPaddingMode
            // 
            this.cmbPaddingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaddingMode.FormattingEnabled = true;
            this.cmbPaddingMode.Location = new System.Drawing.Point(86, 117);
            this.cmbPaddingMode.Name = "cmbPaddingMode";
            this.cmbPaddingMode.Size = new System.Drawing.Size(167, 21);
            this.cmbPaddingMode.TabIndex = 29;
            this.cmbPaddingMode.SelectedIndexChanged += new System.EventHandler(this.cmbPaddingMode_SelectedIndexChanged);
            // 
            // cmbModeofOperation
            // 
            this.cmbModeofOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModeofOperation.FormattingEnabled = true;
            this.cmbModeofOperation.Location = new System.Drawing.Point(105, 144);
            this.cmbModeofOperation.Name = "cmbModeofOperation";
            this.cmbModeofOperation.Size = new System.Drawing.Size(149, 21);
            this.cmbModeofOperation.TabIndex = 31;
            this.cmbModeofOperation.SelectedIndexChanged += new System.EventHandler(this.cmbModeofOperation_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Mode of Operation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 249);
            this.Controls.Add(this.cmbModeofOperation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbPaddingMode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butBrowseInput);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butEncrypt);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.rB128);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butDecrypt);
            this.Controls.Add(this.rb192);
            this.Controls.Add(this.butBrowseOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TripleDES";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butBrowseInput;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butEncrypt;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.RadioButton rB128;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butDecrypt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton rb192;
        private System.Windows.Forms.Button butBrowseOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPaddingMode;
        private System.Windows.Forms.ComboBox cmbModeofOperation;
        private System.Windows.Forms.Label label7;
    }
}

