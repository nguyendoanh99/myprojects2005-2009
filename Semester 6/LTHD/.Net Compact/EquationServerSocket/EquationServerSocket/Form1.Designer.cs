using System.Net.Sockets;
namespace EquationServerSocket
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
            this.butListen = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butListen
            // 
            this.butListen.Location = new System.Drawing.Point(0, 9);
            this.butListen.Name = "butListen";
            this.butListen.Size = new System.Drawing.Size(93, 26);
            this.butListen.TabIndex = 0;
            this.butListen.Text = "Bắt đầu";
            this.butListen.UseVisualStyleBackColor = true;
            this.butListen.Click += new System.EventHandler(this.butListen_Click);
            // 
            // txtNote
            // 
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtNote.Location = new System.Drawing.Point(0, 41);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNote.Size = new System.Drawing.Size(439, 223);
            this.txtNote.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 264);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.butListen);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butListen;
        private System.Windows.Forms.TextBox txtNote;
    }
}

