namespace HashApp
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.butBrowseInput = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbHashAlgorithm = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAlgorithm = new System.Windows.Forms.TextBox();
            this.txtHashFile = new System.Windows.Forms.TextBox();
            this.butBrowseOutput = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.butTest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.butBrowseInputTest = new System.Windows.Forms.Button();
            this.txtInputTest = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butCreate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.butBrowseInput);
            this.groupBox1.Controls.Add(this.txtInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbHashAlgorithm);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 115);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tạo hash";
            // 
            // butCreate
            // 
            this.butCreate.Location = new System.Drawing.Point(237, 81);
            this.butCreate.Name = "butCreate";
            this.butCreate.Size = new System.Drawing.Size(65, 25);
            this.butCreate.TabIndex = 30;
            this.butCreate.Text = "Tạo hash";
            this.butCreate.UseVisualStyleBackColor = true;
            this.butCreate.Click += new System.EventHandler(this.butCreate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Thuật toán";
            // 
            // butBrowseInput
            // 
            this.butBrowseInput.Location = new System.Drawing.Point(275, 18);
            this.butBrowseInput.Name = "butBrowseInput";
            this.butBrowseInput.Size = new System.Drawing.Size(29, 20);
            this.butBrowseInput.TabIndex = 28;
            this.butBrowseInput.Text = "...";
            this.butBrowseInput.UseVisualStyleBackColor = true;
            this.butBrowseInput.Click += new System.EventHandler(this.butBrowseInput_Click_1);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(95, 19);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(170, 20);
            this.txtInput.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Tập tin nguồn";
            // 
            // cmbHashAlgorithm
            // 
            this.cmbHashAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHashAlgorithm.FormattingEnabled = true;
            this.cmbHashAlgorithm.Location = new System.Drawing.Point(95, 45);
            this.cmbHashAlgorithm.Name = "cmbHashAlgorithm";
            this.cmbHashAlgorithm.Size = new System.Drawing.Size(170, 21);
            this.cmbHashAlgorithm.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAlgorithm);
            this.groupBox2.Controls.Add(this.txtHashFile);
            this.groupBox2.Controls.Add(this.butBrowseOutput);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.butTest);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.butBrowseInputTest);
            this.groupBox2.Controls.Add(this.txtInputTest);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(4, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 133);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kiểm tra hash";
            // 
            // txtAlgorithm
            // 
            this.txtAlgorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlgorithm.Location = new System.Drawing.Point(94, 72);
            this.txtAlgorithm.Name = "txtAlgorithm";
            this.txtAlgorithm.ReadOnly = true;
            this.txtAlgorithm.Size = new System.Drawing.Size(169, 20);
            this.txtAlgorithm.TabIndex = 40;
            // 
            // txtHashFile
            // 
            this.txtHashFile.Location = new System.Drawing.Point(93, 46);
            this.txtHashFile.Name = "txtHashFile";
            this.txtHashFile.Size = new System.Drawing.Size(170, 20);
            this.txtHashFile.TabIndex = 38;
            this.txtHashFile.TextChanged += new System.EventHandler(this.txtHashFile_TextChanged);
            // 
            // butBrowseOutput
            // 
            this.butBrowseOutput.Location = new System.Drawing.Point(273, 45);
            this.butBrowseOutput.Name = "butBrowseOutput";
            this.butBrowseOutput.Size = new System.Drawing.Size(29, 20);
            this.butBrowseOutput.TabIndex = 39;
            this.butBrowseOutput.Text = "...";
            this.butBrowseOutput.UseVisualStyleBackColor = true;
            this.butBrowseOutput.Click += new System.EventHandler(this.butBrowseOutput_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Tập tin hash";
            // 
            // butTest
            // 
            this.butTest.Location = new System.Drawing.Point(237, 98);
            this.butTest.Name = "butTest";
            this.butTest.Size = new System.Drawing.Size(65, 25);
            this.butTest.TabIndex = 36;
            this.butTest.Text = "Kiểm tra";
            this.butTest.UseVisualStyleBackColor = true;
            this.butTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Thuật toán";
            // 
            // butBrowseInputTest
            // 
            this.butBrowseInputTest.Location = new System.Drawing.Point(273, 19);
            this.butBrowseInputTest.Name = "butBrowseInputTest";
            this.butBrowseInputTest.Size = new System.Drawing.Size(29, 20);
            this.butBrowseInputTest.TabIndex = 34;
            this.butBrowseInputTest.Text = "...";
            this.butBrowseInputTest.UseVisualStyleBackColor = true;
            this.butBrowseInputTest.Click += new System.EventHandler(this.butBrowseInputTest_Click);
            // 
            // txtInputTest
            // 
            this.txtInputTest.Location = new System.Drawing.Point(93, 20);
            this.txtInputTest.Name = "txtInputTest";
            this.txtInputTest.Size = new System.Drawing.Size(170, 20);
            this.txtInputTest.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Tập tin nguồn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 263);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "HashApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butBrowseInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHashAlgorithm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtHashFile;
        private System.Windows.Forms.Button butBrowseOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button butTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butBrowseInputTest;
        private System.Windows.Forms.TextBox txtInputTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAlgorithm;

    }
}

