namespace RSAApp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butSavePriKey = new System.Windows.Forms.Button();
            this.butSavePubKey = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.cmbKeySize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butPerform = new System.Windows.Forms.Button();
            this.chkEncrypt = new System.Windows.Forms.CheckBox();
            this.butBrowseKey = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.butBrowseOutput = new System.Windows.Forms.Button();
            this.butBrowseInput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butSavePriKey);
            this.groupBox1.Controls.Add(this.butSavePubKey);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtPrivateKey);
            this.groupBox1.Controls.Add(this.txtPublicKey);
            this.groupBox1.Controls.Add(this.cmbKeySize);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tạo khóa";
            // 
            // butSavePriKey
            // 
            this.butSavePriKey.Enabled = false;
            this.butSavePriKey.Location = new System.Drawing.Point(210, 108);
            this.butSavePriKey.Name = "butSavePriKey";
            this.butSavePriKey.Size = new System.Drawing.Size(75, 42);
            this.butSavePriKey.TabIndex = 8;
            this.butSavePriKey.Text = "Lưu khóa riêng";
            this.butSavePriKey.UseVisualStyleBackColor = true;
            this.butSavePriKey.Click += new System.EventHandler(this.butSavePriKey_Click);
            // 
            // butSavePubKey
            // 
            this.butSavePubKey.Enabled = false;
            this.butSavePubKey.Location = new System.Drawing.Point(210, 63);
            this.butSavePubKey.Name = "butSavePubKey";
            this.butSavePubKey.Size = new System.Drawing.Size(75, 42);
            this.butSavePubKey.TabIndex = 7;
            this.butSavePubKey.Text = "Lưu khóa công khai";
            this.butSavePubKey.UseVisualStyleBackColor = true;
            this.butSavePubKey.Click += new System.EventHandler(this.butSavePubKey_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Khóa riêng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Khóa công khai";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "Tạo khóa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Location = new System.Drawing.Point(291, 63);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.ReadOnly = true;
            this.txtPrivateKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPrivateKey.Size = new System.Drawing.Size(193, 87);
            this.txtPrivateKey.TabIndex = 3;
            this.txtPrivateKey.TextChanged += new System.EventHandler(this.txtPrivateKey_TextChanged);
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Location = new System.Drawing.Point(11, 63);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.ReadOnly = true;
            this.txtPublicKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPublicKey.Size = new System.Drawing.Size(193, 87);
            this.txtPublicKey.TabIndex = 2;
            this.txtPublicKey.TextChanged += new System.EventHandler(this.txtPublicKey_TextChanged);
            // 
            // cmbKeySize
            // 
            this.cmbKeySize.FormattingEnabled = true;
            this.cmbKeySize.Location = new System.Drawing.Point(104, 17);
            this.cmbKeySize.Name = "cmbKeySize";
            this.cmbKeySize.Size = new System.Drawing.Size(229, 21);
            this.cmbKeySize.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kích thước khóa";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butPerform);
            this.groupBox2.Controls.Add(this.chkEncrypt);
            this.groupBox2.Controls.Add(this.butBrowseKey);
            this.groupBox2.Controls.Add(this.txtKey);
            this.groupBox2.Controls.Add(this.lblKey);
            this.groupBox2.Controls.Add(this.butBrowseOutput);
            this.groupBox2.Controls.Add(this.butBrowseInput);
            this.groupBox2.Controls.Add(this.txtOutput);
            this.groupBox2.Controls.Add(this.txtInput);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(1, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 159);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mã hóa";
            // 
            // butPerform
            // 
            this.butPerform.Location = new System.Drawing.Point(213, 127);
            this.butPerform.Name = "butPerform";
            this.butPerform.Size = new System.Drawing.Size(83, 23);
            this.butPerform.TabIndex = 21;
            this.butPerform.Text = "Mã hóa";
            this.butPerform.UseVisualStyleBackColor = true;
            this.butPerform.Click += new System.EventHandler(this.butPerform_Click);
            // 
            // chkEncrypt
            // 
            this.chkEncrypt.AutoSize = true;
            this.chkEncrypt.Checked = true;
            this.chkEncrypt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEncrypt.Location = new System.Drawing.Point(11, 19);
            this.chkEncrypt.Name = "chkEncrypt";
            this.chkEncrypt.Size = new System.Drawing.Size(62, 17);
            this.chkEncrypt.TabIndex = 14;
            this.chkEncrypt.Text = "Mã hóa";
            this.chkEncrypt.UseVisualStyleBackColor = true;
            this.chkEncrypt.CheckedChanged += new System.EventHandler(this.txtEncrypt_CheckedChanged);
            // 
            // butBrowseKey
            // 
            this.butBrowseKey.Location = new System.Drawing.Point(267, 48);
            this.butBrowseKey.Name = "butBrowseKey";
            this.butBrowseKey.Size = new System.Drawing.Size(29, 20);
            this.butBrowseKey.TabIndex = 16;
            this.butBrowseKey.Text = "...";
            this.butBrowseKey.UseVisualStyleBackColor = true;
            this.butBrowseKey.Click += new System.EventHandler(this.butBrowseKey_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(87, 49);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(170, 20);
            this.txtKey.TabIndex = 15;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(6, 52);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(82, 13);
            this.lblKey.TabIndex = 14;
            this.lblKey.Text = "Khóa công khai";
            // 
            // butBrowseOutput
            // 
            this.butBrowseOutput.Location = new System.Drawing.Point(267, 100);
            this.butBrowseOutput.Name = "butBrowseOutput";
            this.butBrowseOutput.Size = new System.Drawing.Size(29, 20);
            this.butBrowseOutput.TabIndex = 20;
            this.butBrowseOutput.Text = "...";
            this.butBrowseOutput.UseVisualStyleBackColor = true;
            this.butBrowseOutput.Click += new System.EventHandler(this.butBrowseOutput_Click);
            // 
            // butBrowseInput
            // 
            this.butBrowseInput.Location = new System.Drawing.Point(267, 74);
            this.butBrowseInput.Name = "butBrowseInput";
            this.butBrowseInput.Size = new System.Drawing.Size(29, 20);
            this.butBrowseInput.TabIndex = 18;
            this.butBrowseInput.Text = "...";
            this.butBrowseInput.UseVisualStyleBackColor = true;
            this.butBrowseInput.Click += new System.EventHandler(this.butBrowseInput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(87, 101);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(170, 20);
            this.txtOutput.TabIndex = 19;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(87, 75);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(170, 20);
            this.txtInput.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tập tin đích";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tập tin nguồn";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 328);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RSAApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKeySize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.Button butSavePriKey;
        private System.Windows.Forms.Button butSavePubKey;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button butBrowseKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button butBrowseOutput;
        private System.Windows.Forms.Button butBrowseInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkEncrypt;
        private System.Windows.Forms.Button butPerform;
    }
}

