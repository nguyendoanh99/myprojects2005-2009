namespace EquationClientSoket
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
            this.butReceive = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butReceive
            // 
            this.butReceive.Location = new System.Drawing.Point(67, 36);
            this.butReceive.Name = "butReceive";
            this.butReceive.Size = new System.Drawing.Size(75, 23);
            this.butReceive.TabIndex = 0;
            this.butReceive.Text = "Receive";
            this.butReceive.UseVisualStyleBackColor = true;
            this.butReceive.Click += new System.EventHandler(this.butReceive_Click);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(13, 69);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(263, 185);
            this.txtNote.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.butReceive);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butReceive;
        private System.Windows.Forms.TextBox txtNote;
    }
}

