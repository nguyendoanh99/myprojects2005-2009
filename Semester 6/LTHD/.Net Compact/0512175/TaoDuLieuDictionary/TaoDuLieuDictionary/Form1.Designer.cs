namespace TaoDuLieuDictionary
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
            this.butInput = new System.Windows.Forms.Button();
            this.butOutput = new System.Windows.Forms.Button();
            this.butCreate = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dữ liệu nguồn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dữ liệu đích";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(85, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(145, 20);
            this.txtInput.TabIndex = 2;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(85, 38);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(145, 20);
            this.txtOutput.TabIndex = 4;
            // 
            // butInput
            // 
            this.butInput.Location = new System.Drawing.Point(236, 12);
            this.butInput.Name = "butInput";
            this.butInput.Size = new System.Drawing.Size(28, 19);
            this.butInput.TabIndex = 3;
            this.butInput.Text = "...";
            this.butInput.UseVisualStyleBackColor = true;
            this.butInput.Click += new System.EventHandler(this.butInput_Click);
            // 
            // butOutput
            // 
            this.butOutput.Location = new System.Drawing.Point(236, 40);
            this.butOutput.Name = "butOutput";
            this.butOutput.Size = new System.Drawing.Size(28, 19);
            this.butOutput.TabIndex = 5;
            this.butOutput.Text = "...";
            this.butOutput.UseVisualStyleBackColor = true;
            this.butOutput.Click += new System.EventHandler(this.butOutput_Click);
            // 
            // butCreate
            // 
            this.butCreate.Location = new System.Drawing.Point(144, 64);
            this.butCreate.Name = "butCreate";
            this.butCreate.Size = new System.Drawing.Size(120, 23);
            this.butCreate.TabIndex = 6;
            this.butCreate.Text = "Tạo dữ liệu";
            this.butCreate.UseVisualStyleBackColor = true;
            this.butCreate.Click += new System.EventHandler(this.butCreate_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XML files|*.xml";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 103);
            this.Controls.Add(this.butCreate);
            this.Controls.Add(this.butOutput);
            this.Controls.Add(this.butInput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button butInput;
        private System.Windows.Forms.Button butOutput;
        private System.Windows.Forms.Button butCreate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;


    }
}

