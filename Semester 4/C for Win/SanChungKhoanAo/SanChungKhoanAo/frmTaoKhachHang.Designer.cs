namespace SanChungKhoanAo
{
    partial class frmTaoKhachHang
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.butDongY = new System.Windows.Forms.Button();
            this.butHuyBo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Khách Hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "CMND";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tổng tiền mặt";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(124, 21);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(194, 20);
            this.txtMaKH.TabIndex = 4;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(124, 49);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(194, 20);
            this.txtTenKH.TabIndex = 5;
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(124, 78);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(194, 20);
            this.txtCMND.TabIndex = 6;
            this.txtCMND.TextChanged += new System.EventHandler(this.txtCMND_TextChanged);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(124, 105);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(194, 20);
            this.txtSoTien.TabIndex = 7;
            this.txtSoTien.TextChanged += new System.EventHandler(this.txtSoTien_TextChanged);
            // 
            // butDongY
            // 
            this.butDongY.Enabled = false;
            this.butDongY.Location = new System.Drawing.Point(365, 15);
            this.butDongY.Name = "butDongY";
            this.butDongY.Size = new System.Drawing.Size(117, 26);
            this.butDongY.TabIndex = 8;
            this.butDongY.Text = "&Tạo";
            this.butDongY.UseVisualStyleBackColor = true;
            this.butDongY.Click += new System.EventHandler(this.butDongY_Click);
            // 
            // butHuyBo
            // 
            this.butHuyBo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butHuyBo.Location = new System.Drawing.Point(365, 43);
            this.butHuyBo.Name = "butHuyBo";
            this.butHuyBo.Size = new System.Drawing.Size(117, 26);
            this.butHuyBo.TabIndex = 9;
            this.butHuyBo.Text = "T&hoát";
            this.butHuyBo.UseVisualStyleBackColor = true;
            // 
            // frmTaoKhachHang
            // 
            this.AcceptButton = this.butDongY;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butHuyBo;
            this.ClientSize = new System.Drawing.Size(494, 146);
            this.Controls.Add(this.butHuyBo);
            this.Controls.Add(this.butDongY);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaoKhachHang";
            this.Text = "Tao khach hang";
            this.Load += new System.EventHandler(this.frmTaoKhachHang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butDongY;
        private System.Windows.Forms.Button butHuyBo;
        public System.Windows.Forms.TextBox txtMaKH;
        public System.Windows.Forms.TextBox txtTenKH;
        public System.Windows.Forms.TextBox txtCMND;
        public System.Windows.Forms.TextBox txtSoTien;
    }
}