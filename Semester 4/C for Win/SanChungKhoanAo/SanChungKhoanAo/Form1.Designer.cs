namespace SanChungKhoanAo
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
            this.components = new System.ComponentModel.Container();
            this.butTaoKH = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.butDatLenh = new System.Windows.Forms.Button();
            this.butKQLGD = new System.Windows.Forms.Button();
            this.butThongTinTaiKhoan = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.lblPhien = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.butDongY = new System.Windows.Forms.Button();
            this.dtpNgayGD = new System.Windows.Forms.DateTimePicker();
            this.cmbPhien = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butTaoKH
            // 
            this.butTaoKH.Location = new System.Drawing.Point(12, 47);
            this.butTaoKH.Name = "butTaoKH";
            this.butTaoKH.Size = new System.Drawing.Size(107, 27);
            this.butTaoKH.TabIndex = 0;
            this.butTaoKH.Text = "Tạo khách hàng";
            this.butTaoKH.UseVisualStyleBackColor = true;
            this.butTaoKH.Click += new System.EventHandler(this.butTaoKH_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Xóa khách hàng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butDatLenh
            // 
            this.butDatLenh.Enabled = false;
            this.butDatLenh.Location = new System.Drawing.Point(12, 113);
            this.butDatLenh.Name = "butDatLenh";
            this.butDatLenh.Size = new System.Drawing.Size(107, 27);
            this.butDatLenh.TabIndex = 3;
            this.butDatLenh.Text = "Đặt lệnh";
            this.butDatLenh.UseVisualStyleBackColor = true;
            this.butDatLenh.Click += new System.EventHandler(this.butDatLenh_Click);
            // 
            // butKQLGD
            // 
            this.butKQLGD.Location = new System.Drawing.Point(12, 146);
            this.butKQLGD.Name = "butKQLGD";
            this.butKQLGD.Size = new System.Drawing.Size(107, 41);
            this.butKQLGD.TabIndex = 4;
            this.butKQLGD.Text = "Kết quả lệnh giao dịch";
            this.butKQLGD.UseVisualStyleBackColor = true;
            this.butKQLGD.Click += new System.EventHandler(this.button2_Click);
            // 
            // butThongTinTaiKhoan
            // 
            this.butThongTinTaiKhoan.Location = new System.Drawing.Point(12, 193);
            this.butThongTinTaiKhoan.Name = "butThongTinTaiKhoan";
            this.butThongTinTaiKhoan.Size = new System.Drawing.Size(107, 27);
            this.butThongTinTaiKhoan.TabIndex = 6;
            this.butThongTinTaiKhoan.Text = "Thông tin tài khoản";
            this.butThongTinTaiKhoan.UseVisualStyleBackColor = true;
            this.butThongTinTaiKhoan.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd/MM/yyyy - HH:mm:ss";
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(345, 12);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(196, 20);
            this.dtp.TabIndex = 8;
            this.dtp.Value = new System.DateTime(2007, 6, 15, 12, 0, 0, 0);
            this.dtp.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // lblPhien
            // 
            this.lblPhien.AutoSize = true;
            this.lblPhien.Location = new System.Drawing.Point(183, 19);
            this.lblPhien.Name = "lblPhien";
            this.lblPhien.Size = new System.Drawing.Size(83, 13);
            this.lblPhien.TabIndex = 9;
            this.lblPhien.Text = "Phiên giao dịch:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.butDongY);
            this.groupBox1.Controls.Add(this.dtpNgayGD);
            this.groupBox1.Controls.Add(this.cmbPhien);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(137, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 329);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng báo giá cổ phiếu";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(21, 71);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(527, 252);
            this.listView1.TabIndex = 45;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã cổ phiếu";
            this.columnHeader1.Width = 187;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Giá khớp lệnh";
            this.columnHeader2.Width = 213;
            // 
            // butDongY
            // 
            this.butDongY.Location = new System.Drawing.Point(342, 11);
            this.butDongY.Name = "butDongY";
            this.butDongY.Size = new System.Drawing.Size(117, 26);
            this.butDongY.TabIndex = 43;
            this.butDongY.Text = "&Xem";
            this.butDongY.UseVisualStyleBackColor = true;
            this.butDongY.Click += new System.EventHandler(this.butDongY_Click);
            // 
            // dtpNgayGD
            // 
            this.dtpNgayGD.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayGD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayGD.Location = new System.Drawing.Point(128, 18);
            this.dtpNgayGD.Name = "dtpNgayGD";
            this.dtpNgayGD.Size = new System.Drawing.Size(156, 20);
            this.dtpNgayGD.TabIndex = 42;
            this.dtpNgayGD.Value = new System.DateTime(2007, 6, 15, 0, 0, 0, 0);
            // 
            // cmbPhien
            // 
            this.cmbPhien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhien.FormattingEnabled = true;
            this.cmbPhien.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbPhien.Location = new System.Drawing.Point(128, 44);
            this.cmbPhien.Name = "cmbPhien";
            this.cmbPhien.Size = new System.Drawing.Size(156, 21);
            this.cmbPhien.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Phiên giao dịch";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Ngày giao dịch";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 388);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPhien);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.butThongTinTaiKhoan);
            this.Controls.Add(this.butKQLGD);
            this.Controls.Add(this.butDatLenh);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.butTaoKH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "San chung khoan ao";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butTaoKH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button butDatLenh;
        private System.Windows.Forms.Button butKQLGD;
        private System.Windows.Forms.Button butThongTinTaiKhoan;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPhien;
        public System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button butDongY;
        private System.Windows.Forms.DateTimePicker dtpNgayGD;
        public System.Windows.Forms.ComboBox cmbPhien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

