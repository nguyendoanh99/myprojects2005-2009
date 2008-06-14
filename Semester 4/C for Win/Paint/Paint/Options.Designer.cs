namespace Paint
{
    partial class Options
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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.cmbWidth = new System.Windows.Forms.ComboBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtR = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Style";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbStyle);
            this.groupBox1.Controls.Add(this.cmbWidth);
            this.groupBox1.Controls.Add(this.txtB);
            this.groupBox1.Controls.Add(this.txtG);
            this.groupBox1.Controls.Add(this.txtR);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 122);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(202, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "...";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbStyle
            // 
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Items.AddRange(new object[] {
            "PS_SOLID",
            "PS_DASH",
            "PS_DOT",
            "PS_DASHDOT",
            "PS_DASHDOTDOT"});
            this.cmbStyle.Location = new System.Drawing.Point(80, 49);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(183, 26);
            this.cmbStyle.TabIndex = 7;
            // 
            // cmbWidth
            // 
            this.cmbWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWidth.FormattingEnabled = true;
            this.cmbWidth.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbWidth.Location = new System.Drawing.Point(80, 83);
            this.cmbWidth.Name = "cmbWidth";
            this.cmbWidth.Size = new System.Drawing.Size(183, 26);
            this.cmbWidth.TabIndex = 6;
            // 
            // txtB
            // 
            this.txtB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB.ForeColor = System.Drawing.Color.Blue;
            this.txtB.Location = new System.Drawing.Point(156, 19);
            this.txtB.Name = "txtB";
            this.txtB.ReadOnly = true;
            this.txtB.Size = new System.Drawing.Size(32, 24);
            this.txtB.TabIndex = 5;
            this.txtB.Text = "0";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtG
            // 
            this.txtG.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtG.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtG.ForeColor = System.Drawing.Color.Green;
            this.txtG.Location = new System.Drawing.Point(118, 19);
            this.txtG.Name = "txtG";
            this.txtG.ReadOnly = true;
            this.txtG.Size = new System.Drawing.Size(32, 24);
            this.txtG.TabIndex = 4;
            this.txtG.Text = "0";
            this.txtG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtR
            // 
            this.txtR.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtR.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtR.ForeColor = System.Drawing.Color.Red;
            this.txtR.Location = new System.Drawing.Point(80, 19);
            this.txtR.Name = "txtR";
            this.txtR.ReadOnly = true;
            this.txtR.Size = new System.Drawing.Size(32, 24);
            this.txtR.TabIndex = 3;
            this.txtR.Text = "0";
            this.txtR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butCancel);
            this.groupBox2.Controls.Add(this.butOK);
            this.groupBox2.Location = new System.Drawing.Point(325, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(98, 85);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(8, 45);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(78, 27);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butOK
            // 
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOK.Location = new System.Drawing.Point(6, 14);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(81, 25);
            this.butOK.TabIndex = 0;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(435, 144);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Option";
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        public System.Windows.Forms.TextBox txtB;
        public System.Windows.Forms.TextBox txtG;
        public System.Windows.Forms.TextBox txtR;
        public System.Windows.Forms.ComboBox cmbStyle;
        public System.Windows.Forms.ComboBox cmbWidth;
    }
}