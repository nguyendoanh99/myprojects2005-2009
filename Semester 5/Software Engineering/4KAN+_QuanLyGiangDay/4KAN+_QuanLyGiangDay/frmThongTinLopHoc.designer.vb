<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongTinLopHoc
    Inherits System.Windows.Forms.UserControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gbDanhSachLopHoc = New System.Windows.Forms.GroupBox
        Me.gridDSLopHoc = New System.Windows.Forms.DataGridView
        Me.btnTaoLopHocMoi = New System.Windows.Forms.Button
        Me.btnCapNhatDuLieu = New System.Windows.Forms.Button
        Me.btnXoaLopHocNay = New System.Windows.Forms.Button
        Me.btnXuatRaTapTin = New System.Windows.Forms.Button
        Me.gb_LichRanh = New System.Windows.Forms.GroupBox
        Me.gridLichRanh = New System.Windows.Forms.DataGridView
        Me.btnTrangThai = New System.Windows.Forms.Button
        Me.gb_ThongTinMonHoc = New System.Windows.Forms.GroupBox
        Me.txtMaLophoc = New System.Windows.Forms.TextBox
        Me.txtTenLophoc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Khối = New System.Windows.Forms.Label
        Me.pn_Khoi = New System.Windows.Forms.Panel
        Me.rdAll_Khoi = New System.Windows.Forms.RadioButton
        Me.rdKhoi12 = New System.Windows.Forms.RadioButton
        Me.rdKhoi11 = New System.Windows.Forms.RadioButton
        Me.rdKhoi10 = New System.Windows.Forms.RadioButton
        Me.gbDanhSachLopHoc.SuspendLayout()
        CType(Me.gridDSLopHoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_LichRanh.SuspendLayout()
        CType(Me.gridLichRanh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_ThongTinMonHoc.SuspendLayout()
        Me.pn_Khoi.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDanhSachLopHoc
        '
        Me.gbDanhSachLopHoc.Controls.Add(Me.gridDSLopHoc)
        Me.gbDanhSachLopHoc.Location = New System.Drawing.Point(704, 3)
        Me.gbDanhSachLopHoc.Name = "gbDanhSachLopHoc"
        Me.gbDanhSachLopHoc.Size = New System.Drawing.Size(290, 475)
        Me.gbDanhSachLopHoc.TabIndex = 1
        Me.gbDanhSachLopHoc.TabStop = False
        Me.gbDanhSachLopHoc.Text = "Danh sách lớp học"
        '
        'gridDSLopHoc
        '
        Me.gridDSLopHoc.AllowUserToAddRows = False
        Me.gridDSLopHoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.gridDSLopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDSLopHoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDSLopHoc.GridColor = System.Drawing.SystemColors.Control
        Me.gridDSLopHoc.Location = New System.Drawing.Point(3, 16)
        Me.gridDSLopHoc.Name = "gridDSLopHoc"
        Me.gridDSLopHoc.RowHeadersVisible = False
        Me.gridDSLopHoc.Size = New System.Drawing.Size(284, 456)
        Me.gridDSLopHoc.TabIndex = 0
        '
        'btnTaoLopHocMoi
        '
        Me.btnTaoLopHocMoi.Location = New System.Drawing.Point(17, 486)
        Me.btnTaoLopHocMoi.Name = "btnTaoLopHocMoi"
        Me.btnTaoLopHocMoi.Size = New System.Drawing.Size(120, 23)
        Me.btnTaoLopHocMoi.TabIndex = 6
        Me.btnTaoLopHocMoi.Text = "Tạo Lớp Học Mới"
        Me.btnTaoLopHocMoi.UseVisualStyleBackColor = True
        '
        'btnCapNhatDuLieu
        '
        Me.btnCapNhatDuLieu.Location = New System.Drawing.Point(245, 486)
        Me.btnCapNhatDuLieu.Name = "btnCapNhatDuLieu"
        Me.btnCapNhatDuLieu.Size = New System.Drawing.Size(120, 23)
        Me.btnCapNhatDuLieu.TabIndex = 5
        Me.btnCapNhatDuLieu.Text = "Cập Nhật Dữ Liệu"
        Me.btnCapNhatDuLieu.UseVisualStyleBackColor = True
        '
        'btnXoaLopHocNay
        '
        Me.btnXoaLopHocNay.Location = New System.Drawing.Point(472, 486)
        Me.btnXoaLopHocNay.Name = "btnXoaLopHocNay"
        Me.btnXoaLopHocNay.Size = New System.Drawing.Size(120, 23)
        Me.btnXoaLopHocNay.TabIndex = 4
        Me.btnXoaLopHocNay.Text = "Xoá Lớp Học Này"
        Me.btnXoaLopHocNay.UseVisualStyleBackColor = True
        '
        'btnXuatRaTapTin
        '
        Me.btnXuatRaTapTin.Location = New System.Drawing.Point(740, 486)
        Me.btnXuatRaTapTin.Name = "btnXuatRaTapTin"
        Me.btnXuatRaTapTin.Size = New System.Drawing.Size(117, 23)
        Me.btnXuatRaTapTin.TabIndex = 3
        Me.btnXuatRaTapTin.Text = "Xuất ra tập tin"
        Me.btnXuatRaTapTin.UseVisualStyleBackColor = True
        '
        'gb_LichRanh
        '
        Me.gb_LichRanh.Controls.Add(Me.gridLichRanh)
        Me.gb_LichRanh.Controls.Add(Me.btnTrangThai)
        Me.gb_LichRanh.Location = New System.Drawing.Point(3, 170)
        Me.gb_LichRanh.Name = "gb_LichRanh"
        Me.gb_LichRanh.Size = New System.Drawing.Size(686, 308)
        Me.gb_LichRanh.TabIndex = 2
        Me.gb_LichRanh.TabStop = False
        Me.gb_LichRanh.Text = "Lịch rảnh"
        '
        'gridLichRanh
        '
        Me.gridLichRanh.AllowUserToAddRows = False
        Me.gridLichRanh.AllowUserToDeleteRows = False
        Me.gridLichRanh.AllowUserToResizeColumns = False
        Me.gridLichRanh.AllowUserToResizeRows = False
        Me.gridLichRanh.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridLichRanh.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridLichRanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridLichRanh.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridLichRanh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gridLichRanh.GridColor = System.Drawing.Color.White
        Me.gridLichRanh.Location = New System.Drawing.Point(3, 48)
        Me.gridLichRanh.Name = "gridLichRanh"
        Me.gridLichRanh.ReadOnly = True
        Me.gridLichRanh.RowHeadersVisible = False
        Me.gridLichRanh.Size = New System.Drawing.Size(680, 257)
        Me.gridLichRanh.TabIndex = 1
        '
        'btnTrangThai
        '
        Me.btnTrangThai.Location = New System.Drawing.Point(592, 19)
        Me.btnTrangThai.Name = "btnTrangThai"
        Me.btnTrangThai.Size = New System.Drawing.Size(75, 23)
        Me.btnTrangThai.TabIndex = 0
        Me.btnTrangThai.Text = "Bận Hết"
        Me.btnTrangThai.UseVisualStyleBackColor = True
        '
        'gb_ThongTinMonHoc
        '
        Me.gb_ThongTinMonHoc.Controls.Add(Me.txtMaLophoc)
        Me.gb_ThongTinMonHoc.Controls.Add(Me.txtTenLophoc)
        Me.gb_ThongTinMonHoc.Controls.Add(Me.Label4)
        Me.gb_ThongTinMonHoc.Controls.Add(Me.Label3)
        Me.gb_ThongTinMonHoc.Controls.Add(Me.Khối)
        Me.gb_ThongTinMonHoc.Controls.Add(Me.pn_Khoi)
        Me.gb_ThongTinMonHoc.Location = New System.Drawing.Point(3, 3)
        Me.gb_ThongTinMonHoc.Name = "gb_ThongTinMonHoc"
        Me.gb_ThongTinMonHoc.Size = New System.Drawing.Size(680, 161)
        Me.gb_ThongTinMonHoc.TabIndex = 1
        Me.gb_ThongTinMonHoc.TabStop = False
        Me.gb_ThongTinMonHoc.Text = "Thông tin lớp học"
        '
        'txtMaLophoc
        '
        Me.txtMaLophoc.BackColor = System.Drawing.Color.PaleTurquoise
        Me.txtMaLophoc.Enabled = False
        Me.txtMaLophoc.Location = New System.Drawing.Point(251, 78)
        Me.txtMaLophoc.Name = "txtMaLophoc"
        Me.txtMaLophoc.Size = New System.Drawing.Size(261, 20)
        Me.txtMaLophoc.TabIndex = 7
        '
        'txtTenLophoc
        '
        Me.txtTenLophoc.HideSelection = False
        Me.txtTenLophoc.Location = New System.Drawing.Point(251, 118)
        Me.txtTenLophoc.Name = "txtTenLophoc"
        Me.txtTenLophoc.Size = New System.Drawing.Size(261, 20)
        Me.txtTenLophoc.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(149, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Tên lớp học"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(149, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Mã lớp học"
        '
        'Khối
        '
        Me.Khối.AutoSize = True
        Me.Khối.Location = New System.Drawing.Point(149, 29)
        Me.Khối.Name = "Khối"
        Me.Khối.Size = New System.Drawing.Size(28, 13)
        Me.Khối.TabIndex = 3
        Me.Khối.Text = "Khối"
        '
        'pn_Khoi
        '
        Me.pn_Khoi.Controls.Add(Me.rdAll_Khoi)
        Me.pn_Khoi.Controls.Add(Me.rdKhoi12)
        Me.pn_Khoi.Controls.Add(Me.rdKhoi11)
        Me.pn_Khoi.Controls.Add(Me.rdKhoi10)
        Me.pn_Khoi.Location = New System.Drawing.Point(251, 16)
        Me.pn_Khoi.Name = "pn_Khoi"
        Me.pn_Khoi.Size = New System.Drawing.Size(261, 34)
        Me.pn_Khoi.TabIndex = 2
        '
        'rdAll_Khoi
        '
        Me.rdAll_Khoi.AutoSize = True
        Me.rdAll_Khoi.Checked = True
        Me.rdAll_Khoi.Location = New System.Drawing.Point(184, 11)
        Me.rdAll_Khoi.Name = "rdAll_Khoi"
        Me.rdAll_Khoi.Size = New System.Drawing.Size(56, 17)
        Me.rdAll_Khoi.TabIndex = 3
        Me.rdAll_Khoi.TabStop = True
        Me.rdAll_Khoi.Text = "Tất cả"
        Me.rdAll_Khoi.UseVisualStyleBackColor = True
        '
        'rdKhoi12
        '
        Me.rdKhoi12.AutoSize = True
        Me.rdKhoi12.Location = New System.Drawing.Point(127, 11)
        Me.rdKhoi12.Name = "rdKhoi12"
        Me.rdKhoi12.Size = New System.Drawing.Size(37, 17)
        Me.rdKhoi12.TabIndex = 2
        Me.rdKhoi12.TabStop = True
        Me.rdKhoi12.Text = "12"
        Me.rdKhoi12.UseVisualStyleBackColor = True
        '
        'rdKhoi11
        '
        Me.rdKhoi11.AutoSize = True
        Me.rdKhoi11.Location = New System.Drawing.Point(65, 11)
        Me.rdKhoi11.Name = "rdKhoi11"
        Me.rdKhoi11.Size = New System.Drawing.Size(37, 17)
        Me.rdKhoi11.TabIndex = 1
        Me.rdKhoi11.TabStop = True
        Me.rdKhoi11.Text = "11"
        Me.rdKhoi11.UseVisualStyleBackColor = True
        '
        'rdKhoi10
        '
        Me.rdKhoi10.AutoSize = True
        Me.rdKhoi10.Location = New System.Drawing.Point(3, 11)
        Me.rdKhoi10.Name = "rdKhoi10"
        Me.rdKhoi10.Size = New System.Drawing.Size(37, 17)
        Me.rdKhoi10.TabIndex = 0
        Me.rdKhoi10.TabStop = True
        Me.rdKhoi10.Text = "10"
        Me.rdKhoi10.UseVisualStyleBackColor = True
        '
        'frmThongTinLopHoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbDanhSachLopHoc)
        Me.Controls.Add(Me.btnTaoLopHocMoi)
        Me.Controls.Add(Me.btnCapNhatDuLieu)
        Me.Controls.Add(Me.gb_ThongTinMonHoc)
        Me.Controls.Add(Me.btnXoaLopHocNay)
        Me.Controls.Add(Me.gb_LichRanh)
        Me.Controls.Add(Me.btnXuatRaTapTin)
        Me.Name = "frmThongTinLopHoc"
        Me.Size = New System.Drawing.Size(997, 523)
        Me.gbDanhSachLopHoc.ResumeLayout(False)
        CType(Me.gridDSLopHoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_LichRanh.ResumeLayout(False)
        CType(Me.gridLichRanh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_ThongTinMonHoc.ResumeLayout(False)
        Me.gb_ThongTinMonHoc.PerformLayout()
        Me.pn_Khoi.ResumeLayout(False)
        Me.pn_Khoi.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_ThongTinMonHoc As System.Windows.Forms.GroupBox
    Friend WithEvents pn_Khoi As System.Windows.Forms.Panel
    Friend WithEvents rdAll_Khoi As System.Windows.Forms.RadioButton
    Friend WithEvents rdKhoi12 As System.Windows.Forms.RadioButton
    Friend WithEvents rdKhoi11 As System.Windows.Forms.RadioButton
    Friend WithEvents rdKhoi10 As System.Windows.Forms.RadioButton
    Friend WithEvents txtMaLophoc As System.Windows.Forms.TextBox
    Friend WithEvents txtTenLophoc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Khối As System.Windows.Forms.Label
    Friend WithEvents btnTaoLopHocMoi As System.Windows.Forms.Button
    Friend WithEvents btnCapNhatDuLieu As System.Windows.Forms.Button
    Friend WithEvents btnXoaLopHocNay As System.Windows.Forms.Button
    Friend WithEvents btnXuatRaTapTin As System.Windows.Forms.Button
    Friend WithEvents gb_LichRanh As System.Windows.Forms.GroupBox
    Friend WithEvents btnTrangThai As System.Windows.Forms.Button
    Friend WithEvents gridLichRanh As System.Windows.Forms.DataGridView
    Friend WithEvents gbDanhSachLopHoc As System.Windows.Forms.GroupBox
    Friend WithEvents gridDSLopHoc As System.Windows.Forms.DataGridView

End Class
