namespace _2_Doi_Ngoai_Te
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
            this.lsVBangTiGia = new System.Windows.Forms.ListView();
            this.columnKyHieu = new System.Windows.Forms.ColumnHeader();
            this.columnTeniNgoaiTe = new System.Windows.Forms.ColumnHeader();
            this.columnMuaVao = new System.Windows.Forms.ColumnHeader();
            this.columnChuyenKhoan = new System.Windows.Forms.ColumnHeader();
            this.columnBanRa = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSoTienSauKhiDoi = new System.Windows.Forms.Label();
            this.butDoi = new System.Windows.Forms.Button();
            this.cmbHinhThucDoi = new System.Windows.Forms.ComboBox();
            this.cmbLoaiNgoaiTe = new System.Windows.Forms.ComboBox();
            this.txtSoTienCanDoi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đổi ngoại tệ";
            // 
            // lsVBangTiGia
            // 
            this.lsVBangTiGia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnKyHieu,
            this.columnTeniNgoaiTe,
            this.columnMuaVao,
            this.columnChuyenKhoan,
            this.columnBanRa});
            this.lsVBangTiGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsVBangTiGia.FullRowSelect = true;
            this.lsVBangTiGia.GridLines = true;
            this.lsVBangTiGia.HideSelection = false;
            this.lsVBangTiGia.Location = new System.Drawing.Point(12, 93);
            this.lsVBangTiGia.MultiSelect = false;
            this.lsVBangTiGia.Name = "lsVBangTiGia";
            this.lsVBangTiGia.Size = new System.Drawing.Size(476, 342);
            this.lsVBangTiGia.TabIndex = 1;
            this.lsVBangTiGia.UseCompatibleStateImageBehavior = false;
            this.lsVBangTiGia.View = System.Windows.Forms.View.Details;
            this.lsVBangTiGia.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lsVBangTiGia_ItemSelectionChanged);
            // 
            // columnKyHieu
            // 
            this.columnKyHieu.Text = "Ký hiệu";
            this.columnKyHieu.Width = 69;
            // 
            // columnTeniNgoaiTe
            // 
            this.columnTeniNgoaiTe.Text = "Tên ngoại tệ";
            this.columnTeniNgoaiTe.Width = 105;
            // 
            // columnMuaVao
            // 
            this.columnMuaVao.Text = "Mua vào";
            this.columnMuaVao.Width = 77;
            // 
            // columnChuyenKhoan
            // 
            this.columnChuyenKhoan.Text = "Chuyển khoản";
            this.columnChuyenKhoan.Width = 122;
            // 
            // columnBanRa
            // 
            this.columnBanRa.Text = "Bán ra";
            this.columnBanRa.Width = 97;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bảng tỉ giá";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSoTienSauKhiDoi);
            this.groupBox1.Controls.Add(this.butDoi);
            this.groupBox1.Controls.Add(this.cmbHinhThucDoi);
            this.groupBox1.Controls.Add(this.cmbLoaiNgoaiTe);
            this.groupBox1.Controls.Add(this.txtSoTienCanDoi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(504, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 244);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblSoTienSauKhiDoi
            // 
            this.lblSoTienSauKhiDoi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSoTienSauKhiDoi.Location = new System.Drawing.Point(13, 171);
            this.lblSoTienSauKhiDoi.Name = "lblSoTienSauKhiDoi";
            this.lblSoTienSauKhiDoi.Size = new System.Drawing.Size(277, 56);
            this.lblSoTienSauKhiDoi.TabIndex = 7;
            // 
            // butDoi
            // 
            this.butDoi.Location = new System.Drawing.Point(100, 130);
            this.butDoi.Name = "butDoi";
            this.butDoi.Size = new System.Drawing.Size(97, 36);
            this.butDoi.TabIndex = 6;
            this.butDoi.Text = "Qui đổi";
            this.butDoi.UseVisualStyleBackColor = true;
            this.butDoi.Click += new System.EventHandler(this.butDoi_Click);
            // 
            // cmbHinhThucDoi
            // 
            this.cmbHinhThucDoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHinhThucDoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHinhThucDoi.FormattingEnabled = true;
            this.cmbHinhThucDoi.Items.AddRange(new object[] {
            "Mua vào",
            "Chuyển khoản",
            "Bán ra"});
            this.cmbHinhThucDoi.Location = new System.Drawing.Point(126, 96);
            this.cmbHinhThucDoi.Name = "cmbHinhThucDoi";
            this.cmbHinhThucDoi.Size = new System.Drawing.Size(164, 26);
            this.cmbHinhThucDoi.TabIndex = 5;
            // 
            // cmbLoaiNgoaiTe
            // 
            this.cmbLoaiNgoaiTe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaiNgoaiTe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiNgoaiTe.FormattingEnabled = true;
            this.cmbLoaiNgoaiTe.Location = new System.Drawing.Point(126, 59);
            this.cmbLoaiNgoaiTe.Name = "cmbLoaiNgoaiTe";
            this.cmbLoaiNgoaiTe.Size = new System.Drawing.Size(164, 26);
            this.cmbLoaiNgoaiTe.TabIndex = 4;
            this.cmbLoaiNgoaiTe.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiNgoaiTe_SelectedIndexChanged);
            // 
            // txtSoTienCanDoi
            // 
            this.txtSoTienCanDoi.Location = new System.Drawing.Point(126, 17);
            this.txtSoTienCanDoi.Name = "txtSoTienCanDoi";
            this.txtSoTienCanDoi.Size = new System.Drawing.Size(164, 26);
            this.txtSoTienCanDoi.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Hình thức đổi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Loại ngoại tệ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số tiền cần đổi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 445);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsVBangTiGia);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Doi ngoai te";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsVBangTiGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSoTienSauKhiDoi;
        private System.Windows.Forms.Button butDoi;
        private System.Windows.Forms.ComboBox cmbHinhThucDoi;
        private System.Windows.Forms.ComboBox cmbLoaiNgoaiTe;
        private System.Windows.Forms.TextBox txtSoTienCanDoi;
        private System.Windows.Forms.ColumnHeader columnKyHieu;
        private System.Windows.Forms.ColumnHeader columnTeniNgoaiTe;
        private System.Windows.Forms.ColumnHeader columnMuaVao;
        private System.Windows.Forms.ColumnHeader columnChuyenKhoan;
        private System.Windows.Forms.ColumnHeader columnBanRa;
    }
}

