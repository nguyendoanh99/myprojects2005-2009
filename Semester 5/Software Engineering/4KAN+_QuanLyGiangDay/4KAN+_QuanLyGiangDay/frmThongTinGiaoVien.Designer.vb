<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongTinGiaoVien
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
        Me.gbThongTinGiaoVien = New System.Windows.Forms.GroupBox
        Me.txtDienThoai = New System.Windows.Forms.TextBox
        Me.txtTenTat = New System.Windows.Forms.TextBox
        Me.txtDiaChi = New System.Windows.Forms.TextBox
        Me.txtMaGiaoVien = New System.Windows.Forms.TextBox
        Me.txtHoTenGiaoVien = New System.Windows.Forms.TextBox
        Me.lblTenTat = New System.Windows.Forms.Label
        Me.lblDienThoai = New System.Windows.Forms.Label
        Me.lblHoTenGiaoVien = New System.Windows.Forms.Label
        Me.lblDiaChi = New System.Windows.Forms.Label
        Me.lblMaGiaoVien = New System.Windows.Forms.Label
        Me.gbLichRanh = New System.Windows.Forms.GroupBox
        Me.gridLichRanh = New System.Windows.Forms.DataGridView
        Me.btnTrangThai = New System.Windows.Forms.Button
        Me.btnTaoGiaoVienMoi = New System.Windows.Forms.Button
        Me.btnCapNhatDuLieu = New System.Windows.Forms.Button
        Me.btnXoaGiaoVien = New System.Windows.Forms.Button
        Me.btnXuatRaTapTin = New System.Windows.Forms.Button
        Me.gbDanhSachGiaoVien = New System.Windows.Forms.GroupBox
        Me.gridDSGiaoVien = New System.Windows.Forms.DataGridView
        Me.chklbxMonHoc = New System.Windows.Forms.CheckedListBox
        Me.gbCacMonHocPhuTrach = New System.Windows.Forms.GroupBox
        Me.gbThongTinGiaoVien.SuspendLayout()
        Me.gbLichRanh.SuspendLayout()
        CType(Me.gridLichRanh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDanhSachGiaoVien.SuspendLayout()
        CType(Me.gridDSGiaoVien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCacMonHocPhuTrach.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbThongTinGiaoVien
        '
        Me.gbThongTinGiaoVien.Controls.Add(Me.txtDienThoai)
        Me.gbThongTinGiaoVien.Controls.Add(Me.txtTenTat)
        Me.gbThongTinGiaoVien.Controls.Add(Me.txtDiaChi)
        Me.gbThongTinGiaoVien.Controls.Add(Me.txtMaGiaoVien)
        Me.gbThongTinGiaoVien.Controls.Add(Me.txtHoTenGiaoVien)
        Me.gbThongTinGiaoVien.Controls.Add(Me.lblTenTat)
        Me.gbThongTinGiaoVien.Controls.Add(Me.lblDienThoai)
        Me.gbThongTinGiaoVien.Controls.Add(Me.lblHoTenGiaoVien)
        Me.gbThongTinGiaoVien.Controls.Add(Me.lblDiaChi)
        Me.gbThongTinGiaoVien.Controls.Add(Me.lblMaGiaoVien)
        Me.gbThongTinGiaoVien.Location = New System.Drawing.Point(2, 3)
        Me.gbThongTinGiaoVien.Name = "gbThongTinGiaoVien"
        Me.gbThongTinGiaoVien.Size = New System.Drawing.Size(535, 119)
        Me.gbThongTinGiaoVien.TabIndex = 1
        Me.gbThongTinGiaoVien.TabStop = False
        Me.gbThongTinGiaoVien.Text = "Thông tin giáo viên"
        '
        'txtDienThoai
        '
        Me.txtDienThoai.Location = New System.Drawing.Point(404, 87)
        Me.txtDienThoai.Name = "txtDienThoai"
        Me.txtDienThoai.Size = New System.Drawing.Size(125, 20)
        Me.txtDienThoai.TabIndex = 10
        '
        'txtTenTat
        '
        Me.txtTenTat.Location = New System.Drawing.Point(404, 59)
        Me.txtTenTat.Name = "txtTenTat"
        Me.txtTenTat.Size = New System.Drawing.Size(125, 20)
        Me.txtTenTat.TabIndex = 9
        '
        'txtDiaChi
        '
        Me.txtDiaChi.Location = New System.Drawing.Point(102, 86)
        Me.txtDiaChi.Name = "txtDiaChi"
        Me.txtDiaChi.Size = New System.Drawing.Size(174, 20)
        Me.txtDiaChi.TabIndex = 7
        '
        'txtMaGiaoVien
        '
        Me.txtMaGiaoVien.Enabled = False
        Me.txtMaGiaoVien.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMaGiaoVien.Location = New System.Drawing.Point(102, 33)
        Me.txtMaGiaoVien.Name = "txtMaGiaoVien"
        Me.txtMaGiaoVien.Size = New System.Drawing.Size(174, 20)
        Me.txtMaGiaoVien.TabIndex = 6
        '
        'txtHoTenGiaoVien
        '
        Me.txtHoTenGiaoVien.Location = New System.Drawing.Point(102, 59)
        Me.txtHoTenGiaoVien.Name = "txtHoTenGiaoVien"
        Me.txtHoTenGiaoVien.Size = New System.Drawing.Size(174, 20)
        Me.txtHoTenGiaoVien.TabIndex = 5
        '
        'lblTenTat
        '
        Me.lblTenTat.AutoSize = True
        Me.lblTenTat.Location = New System.Drawing.Point(329, 62)
        Me.lblTenTat.Name = "lblTenTat"
        Me.lblTenTat.Size = New System.Drawing.Size(47, 13)
        Me.lblTenTat.TabIndex = 4
        Me.lblTenTat.Text = "Tên tắt: "
        '
        'lblDienThoai
        '
        Me.lblDienThoai.AutoSize = True
        Me.lblDienThoai.Location = New System.Drawing.Point(329, 90)
        Me.lblDienThoai.Name = "lblDienThoai"
        Me.lblDienThoai.Size = New System.Drawing.Size(61, 13)
        Me.lblDienThoai.TabIndex = 3
        Me.lblDienThoai.Text = "Điện thoại: "
        '
        'lblHoTenGiaoVien
        '
        Me.lblHoTenGiaoVien.AutoSize = True
        Me.lblHoTenGiaoVien.Location = New System.Drawing.Point(6, 62)
        Me.lblHoTenGiaoVien.Name = "lblHoTenGiaoVien"
        Me.lblHoTenGiaoVien.Size = New System.Drawing.Size(91, 13)
        Me.lblHoTenGiaoVien.TabIndex = 2
        Me.lblHoTenGiaoVien.Text = "Họ tên giáo viên: "
        '
        'lblDiaChi
        '
        Me.lblDiaChi.AutoSize = True
        Me.lblDiaChi.Location = New System.Drawing.Point(6, 90)
        Me.lblDiaChi.Name = "lblDiaChi"
        Me.lblDiaChi.Size = New System.Drawing.Size(46, 13)
        Me.lblDiaChi.TabIndex = 1
        Me.lblDiaChi.Text = "Địa chỉ: "
        '
        'lblMaGiaoVien
        '
        Me.lblMaGiaoVien.AutoSize = True
        Me.lblMaGiaoVien.Location = New System.Drawing.Point(6, 35)
        Me.lblMaGiaoVien.Name = "lblMaGiaoVien"
        Me.lblMaGiaoVien.Size = New System.Drawing.Size(74, 13)
        Me.lblMaGiaoVien.TabIndex = 0
        Me.lblMaGiaoVien.Text = "Mã giáo viên: "
        '
        'gbLichRanh
        '
        Me.gbLichRanh.Controls.Add(Me.gridLichRanh)
        Me.gbLichRanh.Controls.Add(Me.btnTrangThai)
        Me.gbLichRanh.Location = New System.Drawing.Point(5, 275)
        Me.gbLichRanh.Name = "gbLichRanh"
        Me.gbLichRanh.Size = New System.Drawing.Size(532, 237)
        Me.gbLichRanh.TabIndex = 3
        Me.gbLichRanh.TabStop = False
        Me.gbLichRanh.Text = "Lịch rảnh"
        '
        'gridLichRanh
        '
        Me.gridLichRanh.AllowUserToAddRows = False
        Me.gridLichRanh.AllowUserToDeleteRows = False
        Me.gridLichRanh.AllowUserToResizeColumns = False
        Me.gridLichRanh.AllowUserToResizeRows = False
        Me.gridLichRanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.gridLichRanh.BackgroundColor = System.Drawing.SystemColors.Control
        Me.gridLichRanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridLichRanh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gridLichRanh.Location = New System.Drawing.Point(3, 38)
        Me.gridLichRanh.MultiSelect = False
        Me.gridLichRanh.Name = "gridLichRanh"
        Me.gridLichRanh.ReadOnly = True
        Me.gridLichRanh.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.gridLichRanh.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.gridLichRanh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridLichRanh.Size = New System.Drawing.Size(526, 196)
        Me.gridLichRanh.TabIndex = 1
        '
        'btnTrangThai
        '
        Me.btnTrangThai.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTrangThai.Location = New System.Drawing.Point(451, 9)
        Me.btnTrangThai.Name = "btnTrangThai"
        Me.btnTrangThai.Size = New System.Drawing.Size(75, 23)
        Me.btnTrangThai.TabIndex = 0
        Me.btnTrangThai.Text = "Bận hết"
        Me.btnTrangThai.UseVisualStyleBackColor = True
        '
        'btnTaoGiaoVienMoi
        '
        Me.btnTaoGiaoVienMoi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTaoGiaoVienMoi.Location = New System.Drawing.Point(11, 518)
        Me.btnTaoGiaoVienMoi.Name = "btnTaoGiaoVienMoi"
        Me.btnTaoGiaoVienMoi.Size = New System.Drawing.Size(100, 23)
        Me.btnTaoGiaoVienMoi.TabIndex = 3
        Me.btnTaoGiaoVienMoi.Text = "Tạo giáo viên mới"
        Me.btnTaoGiaoVienMoi.UseVisualStyleBackColor = True
        '
        'btnCapNhatDuLieu
        '
        Me.btnCapNhatDuLieu.Enabled = False
        Me.btnCapNhatDuLieu.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCapNhatDuLieu.Location = New System.Drawing.Point(141, 518)
        Me.btnCapNhatDuLieu.Name = "btnCapNhatDuLieu"
        Me.btnCapNhatDuLieu.Size = New System.Drawing.Size(100, 23)
        Me.btnCapNhatDuLieu.TabIndex = 4
        Me.btnCapNhatDuLieu.Text = "Cập nhật dữ liệu"
        Me.btnCapNhatDuLieu.UseVisualStyleBackColor = True
        '
        'btnXoaGiaoVien
        '
        Me.btnXoaGiaoVien.Enabled = False
        Me.btnXoaGiaoVien.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnXoaGiaoVien.Location = New System.Drawing.Point(287, 518)
        Me.btnXoaGiaoVien.Name = "btnXoaGiaoVien"
        Me.btnXoaGiaoVien.Size = New System.Drawing.Size(100, 23)
        Me.btnXoaGiaoVien.TabIndex = 5
        Me.btnXoaGiaoVien.Text = "Xóa giáo viên này"
        Me.btnXoaGiaoVien.UseVisualStyleBackColor = True
        '
        'btnXuatRaTapTin
        '
        Me.btnXuatRaTapTin.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnXuatRaTapTin.Location = New System.Drawing.Point(437, 518)
        Me.btnXuatRaTapTin.Name = "btnXuatRaTapTin"
        Me.btnXuatRaTapTin.Size = New System.Drawing.Size(100, 23)
        Me.btnXuatRaTapTin.TabIndex = 6
        Me.btnXuatRaTapTin.Text = "Xuất ra tập tin"
        Me.btnXuatRaTapTin.UseVisualStyleBackColor = True
        '
        'gbDanhSachGiaoVien
        '
        Me.gbDanhSachGiaoVien.Controls.Add(Me.gridDSGiaoVien)
        Me.gbDanhSachGiaoVien.Location = New System.Drawing.Point(558, 3)
        Me.gbDanhSachGiaoVien.Name = "gbDanhSachGiaoVien"
        Me.gbDanhSachGiaoVien.Size = New System.Drawing.Size(436, 509)
        Me.gbDanhSachGiaoVien.TabIndex = 7
        Me.gbDanhSachGiaoVien.TabStop = False
        Me.gbDanhSachGiaoVien.Text = "Danh sách giáo viên"
        '
        'gridDSGiaoVien
        '
        Me.gridDSGiaoVien.AllowUserToAddRows = False
        Me.gridDSGiaoVien.AllowUserToOrderColumns = True
        Me.gridDSGiaoVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.gridDSGiaoVien.BackgroundColor = System.Drawing.SystemColors.Control
        Me.gridDSGiaoVien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDSGiaoVien.Location = New System.Drawing.Point(3, 16)
        Me.gridDSGiaoVien.MultiSelect = False
        Me.gridDSGiaoVien.Name = "gridDSGiaoVien"
        Me.gridDSGiaoVien.ReadOnly = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridDSGiaoVien.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridDSGiaoVien.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.gridDSGiaoVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridDSGiaoVien.Size = New System.Drawing.Size(430, 490)
        Me.gridDSGiaoVien.TabIndex = 0
        Me.gridDSGiaoVien.Tag = ""
        '
        'chklbxMonHoc
        '
        Me.chklbxMonHoc.CheckOnClick = True
        Me.chklbxMonHoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chklbxMonHoc.FormattingEnabled = True
        Me.chklbxMonHoc.Location = New System.Drawing.Point(3, 16)
        Me.chklbxMonHoc.MultiColumn = True
        Me.chklbxMonHoc.Name = "chklbxMonHoc"
        Me.chklbxMonHoc.Size = New System.Drawing.Size(529, 109)
        Me.chklbxMonHoc.TabIndex = 20
        Me.chklbxMonHoc.Tag = "ArrayList"
        '
        'gbCacMonHocPhuTrach
        '
        Me.gbCacMonHocPhuTrach.Controls.Add(Me.chklbxMonHoc)
        Me.gbCacMonHocPhuTrach.Location = New System.Drawing.Point(2, 128)
        Me.gbCacMonHocPhuTrach.Name = "gbCacMonHocPhuTrach"
        Me.gbCacMonHocPhuTrach.Size = New System.Drawing.Size(535, 134)
        Me.gbCacMonHocPhuTrach.TabIndex = 21
        Me.gbCacMonHocPhuTrach.TabStop = False
        Me.gbCacMonHocPhuTrach.Text = "Các môn học phụ trách"
        '
        'frmThongTinGiaoVien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbCacMonHocPhuTrach)
        Me.Controls.Add(Me.gbDanhSachGiaoVien)
        Me.Controls.Add(Me.btnXuatRaTapTin)
        Me.Controls.Add(Me.gbLichRanh)
        Me.Controls.Add(Me.btnCapNhatDuLieu)
        Me.Controls.Add(Me.gbThongTinGiaoVien)
        Me.Controls.Add(Me.btnXoaGiaoVien)
        Me.Controls.Add(Me.btnTaoGiaoVienMoi)
        Me.Name = "frmThongTinGiaoVien"
        Me.Size = New System.Drawing.Size(997, 554)
        Me.gbThongTinGiaoVien.ResumeLayout(False)
        Me.gbThongTinGiaoVien.PerformLayout()
        Me.gbLichRanh.ResumeLayout(False)
        CType(Me.gridLichRanh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDanhSachGiaoVien.ResumeLayout(False)
        CType(Me.gridDSGiaoVien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCacMonHocPhuTrach.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbThongTinGiaoVien As System.Windows.Forms.GroupBox
    Friend WithEvents lblMaGiaoVien As System.Windows.Forms.Label
    Friend WithEvents txtMaGiaoVien As System.Windows.Forms.TextBox
    Friend WithEvents txtHoTenGiaoVien As System.Windows.Forms.TextBox
    Friend WithEvents lblTenTat As System.Windows.Forms.Label
    Friend WithEvents lblDienThoai As System.Windows.Forms.Label
    Friend WithEvents lblHoTenGiaoVien As System.Windows.Forms.Label
    Friend WithEvents lblDiaChi As System.Windows.Forms.Label
    Friend WithEvents txtDienThoai As System.Windows.Forms.TextBox
    Friend WithEvents txtDiaChi As System.Windows.Forms.TextBox
    Friend WithEvents gbLichRanh As System.Windows.Forms.GroupBox
    Friend WithEvents gridLichRanh As System.Windows.Forms.DataGridView
    Friend WithEvents btnTrangThai As System.Windows.Forms.Button
    Friend WithEvents btnTaoGiaoVienMoi As System.Windows.Forms.Button
    Friend WithEvents btnCapNhatDuLieu As System.Windows.Forms.Button
    Friend WithEvents btnXoaGiaoVien As System.Windows.Forms.Button
    Friend WithEvents btnXuatRaTapTin As System.Windows.Forms.Button
    Friend WithEvents gbDanhSachGiaoVien As System.Windows.Forms.GroupBox
    Friend WithEvents gridDSGiaoVien As System.Windows.Forms.DataGridView
    Friend WithEvents txtTenTat As System.Windows.Forms.TextBox
    Friend WithEvents chklbxMonHoc As System.Windows.Forms.CheckedListBox
    Friend WithEvents gbCacMonHocPhuTrach As System.Windows.Forms.GroupBox
End Class
