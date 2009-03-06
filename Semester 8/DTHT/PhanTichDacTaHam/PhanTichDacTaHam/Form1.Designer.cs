namespace PhanTichDacTaHam
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
            this.txtText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lsvParameters = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.lblFunctionName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblResultName = new System.Windows.Forms.Label();
            this.lblResultType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(61, 15);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(484, 22);
            this.txtText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Function Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Parameters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Result Name";
            // 
            // lsvParameters
            // 
            this.lsvParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType});
            this.lsvParameters.Location = new System.Drawing.Point(112, 91);
            this.lsvParameters.Name = "lsvParameters";
            this.lsvParameters.Size = new System.Drawing.Size(301, 319);
            this.lsvParameters.TabIndex = 5;
            this.lsvParameters.UseCompatibleStateImageBehavior = false;
            this.lsvParameters.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 137;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 157;
            // 
            // lblFunctionName
            // 
            this.lblFunctionName.AutoSize = true;
            this.lblFunctionName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFunctionName.Location = new System.Drawing.Point(108, 55);
            this.lblFunctionName.Name = "lblFunctionName";
            this.lblFunctionName.Size = new System.Drawing.Size(0, 19);
            this.lblFunctionName.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(571, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Result Type";
            // 
            // lblResultName
            // 
            this.lblResultName.AutoSize = true;
            this.lblResultName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultName.Location = new System.Drawing.Point(341, 55);
            this.lblResultName.Name = "lblResultName";
            this.lblResultName.Size = new System.Drawing.Size(0, 19);
            this.lblResultName.TabIndex = 9;
            // 
            // lblResultType
            // 
            this.lblResultType.AutoSize = true;
            this.lblResultType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultType.Location = new System.Drawing.Point(551, 58);
            this.lblResultType.Name = "lblResultType";
            this.lblResultType.Size = new System.Drawing.Size(0, 19);
            this.lblResultType.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 422);
            this.Controls.Add(this.lblResultType);
            this.Controls.Add(this.lblResultName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblFunctionName);
            this.Controls.Add(this.lsvParameters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lsvParameters;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.Label lblFunctionName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblResultName;
        private System.Windows.Forms.Label lblResultType;
    }
}

