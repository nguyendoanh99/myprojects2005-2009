namespace EquationClientSocketPPC
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.butGiaiPT = new System.Windows.Forms.Button();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIPServer = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(18, 24);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(32, 21);
            this.txtA.TabIndex = 0;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(79, 24);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(32, 21);
            this.txtB.TabIndex = 1;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(141, 24);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(32, 21);
            this.txtC.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(50, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 20);
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(58, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.Text = "2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(114, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.Text = "x +";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(178, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.Text = "= 0";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(66, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 20);
            this.label5.Text = "+";
            // 
            // butGiaiPT
            // 
            this.butGiaiPT.Location = new System.Drawing.Point(18, 61);
            this.butGiaiPT.Name = "butGiaiPT";
            this.butGiaiPT.Size = new System.Drawing.Size(119, 20);
            this.butGiaiPT.TabIndex = 12;
            this.butGiaiPT.Text = "Giai phuong trinh";
            this.butGiaiPT.Click += new System.EventHandler(this.butGiaiPT_Click);
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(18, 114);
            this.txtKetQua.Multiline = true;
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.Size = new System.Drawing.Size(192, 97);
            this.txtKetQua.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(18, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.Text = "Ket qua";
            // 
            // txtIPServer
            // 
            this.txtIPServer.Location = new System.Drawing.Point(18, 236);
            this.txtIPServer.Name = "txtIPServer";
            this.txtIPServer.Size = new System.Drawing.Size(119, 21);
            this.txtIPServer.TabIndex = 16;
            this.txtIPServer.Text = "192.168.2.10";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(153, 236);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(57, 21);
            this.txtPort.TabIndex = 17;
            this.txtPort.Text = "8999";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(18, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 19);
            this.label7.Text = "IP (Server)";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(153, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 19);
            this.label8.Text = "Port";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIPServer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.butGiaiPT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtA);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button butGiaiPT;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIPServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

