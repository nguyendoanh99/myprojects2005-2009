namespace SanChungKhoanAo
{
    partial class frmDatLenh
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            this.txtMaCP = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.butHuyBo = new System.Windows.Forms.Button();
            this.butDongY = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Khách Hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã Cổ Phiếu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loại giao dịch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số lượng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Giá";
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(122, 14);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.ReadOnly = true;
            this.txtMaPhieu.Size = new System.Drawing.Size(156, 20);
            this.txtMaPhieu.TabIndex = 6;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(122, 38);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(156, 20);
            this.txtMaKH.TabIndex = 7;
            this.txtMaKH.TextChanged += new System.EventHandler(this.txtMaKH_TextChanged);
            // 
            // cmbLoai
            // 
            this.cmbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoai.FormattingEnabled = true;
            this.cmbLoai.Items.AddRange(new object[] {
            "Mua",
            "Bán"});
            this.cmbLoai.Location = new System.Drawing.Point(122, 63);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(156, 21);
            this.cmbLoai.TabIndex = 8;
            this.cmbLoai.SelectedIndexChanged += new System.EventHandler(this.cmbLoai_SelectedIndexChanged);
            // 
            // txtMaCP
            // 
            this.txtMaCP.Location = new System.Drawing.Point(122, 90);
            this.txtMaCP.Name = "txtMaCP";
            this.txtMaCP.Size = new System.Drawing.Size(156, 20);
            this.txtMaCP.TabIndex = 9;
            this.txtMaCP.TextChanged += new System.EventHandler(this.txtMaCP_TextChanged);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(122, 116);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(156, 20);
            this.txtSoLuong.TabIndex = 10;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(122, 142);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(156, 20);
            this.txtGia.TabIndex = 11;
            this.txtGia.TextChanged += new System.EventHandler(this.txtGia_TextChanged);
            // 
            // butHuyBo
            // 
            this.butHuyBo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butHuyBo.Location = new System.Drawing.Point(313, 38);
            this.butHuyBo.Name = "butHuyBo";
            this.butHuyBo.Size = new System.Drawing.Size(117, 26);
            this.butHuyBo.TabIndex = 13;
            this.butHuyBo.Text = "&Hủy bỏ";
            this.butHuyBo.UseVisualStyleBackColor = true;
            this.butHuyBo.Click += new System.EventHandler(this.butHuyBo_Click);
            // 
            // butDongY
            // 
            this.butDongY.Location = new System.Drawing.Point(313, 10);
            this.butDongY.Name = "butDongY";
            this.butDongY.Size = new System.Drawing.Size(117, 26);
            this.butDongY.TabIndex = 12;
            this.butDongY.Text = "Đồ&ng ý";
            this.butDongY.UseVisualStyleBackColor = true;
            this.butDongY.Click += new System.EventHandler(this.butDongY_Click);
            // 
            // frmDatLenh
            // 
            this.AcceptButton = this.butDongY;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butHuyBo;
            this.ClientSize = new System.Drawing.Size(435, 169);
            this.Controls.Add(this.butHuyBo);
            this.Controls.Add(this.butDongY);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtMaCP);
            this.Controls.Add(this.cmbLoai);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.txtMaPhieu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatLenh";
            this.Text = "Dat lenh";
            this.Load += new System.EventHandler(this.frmDatLenh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butHuyBo;
        private System.Windows.Forms.Button butDongY;
        public System.Windows.Forms.TextBox txtMaPhieu;
        public System.Windows.Forms.TextBox txtMaKH;
        public System.Windows.Forms.ComboBox cmbLoai;
        public System.Windows.Forms.TextBox txtMaCP;
        public System.Windows.Forms.TextBox txtSoLuong;
        public System.Windows.Forms.TextBox txtGia;
    }
}