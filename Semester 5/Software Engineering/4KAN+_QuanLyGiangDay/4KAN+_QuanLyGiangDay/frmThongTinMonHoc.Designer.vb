<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongTinMonHoc
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
        Me.gbThongTinMonHoc = New System.Windows.Forms.GroupBox
        Me.txtQDSoTHLienTiepToiDa = New System.Windows.Forms.TextBox
        Me.txtQDSoTHLienTiepToiThieu = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTenMonHoc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMaMonHoc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.gbDanhSachMonHoc = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.gridDSMonHoc = New System.Windows.Forms.DataGridView
        Me.gbDanhSachGiaoVien = New System.Windows.Forms.GroupBox
        Me.gridDSGiaoVien = New System.Windows.Forms.DataGridView
        Me.btnTaoMonHocMoi = New System.Windows.Forms.Button
        Me.btnCapNhatDuLieu = New System.Windows.Forms.Button
        Me.btnXoaMonHoc = New System.Windows.Forms.Button
        Me.btnXuatRaTapTin = New System.Windows.Forms.Button
        Me.gbThongTinMonHoc.SuspendLayout()
        Me.gbDanhSachMonHoc.SuspendLayout()
        CType(Me.gridDSMonHoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDanhSachGiaoVien.SuspendLayout()
        CType(Me.gridDSGiaoVien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbThongTinMonHoc
        '
        Me.gbThongTinMonHoc.Controls.Add(Me.txtQDSoTHLienTiepToiDa)
        Me.gbThongTinMonHoc.Controls.Add(Me.txtQDSoTHLienTiepToiThieu)
        Me.gbThongTinMonHoc.Controls.Add(Me.Label5)
        Me.gbThongTinMonHoc.Controls.Add(Me.txtTenMonHoc)
        Me.gbThongTinMonHoc.Controls.Add(Me.Label4)
        Me.gbThongTinMonHoc.Controls.Add(Me.txtMaMonHoc)
        Me.gbThongTinMonHoc.Controls.Add(Me.Label3)
        Me.gbThongTinMonHoc.Controls.Add(Me.Label2)
        Me.gbThongTinMonHoc.Location = New System.Drawing.Point(3, 3)
        Me.gbThongTinMonHoc.Name = "gbThongTinMonHoc"
        Me.gbThongTinMonHoc.Size = New System.Drawing.Size(546, 173)
        Me.gbThongTinMonHoc.TabIndex = 1
        Me.gbThongTinMonHoc.TabStop = False
        Me.gbThongTinMonHoc.Text = "Thông tin môn học"
        '
        'txtQDSoTHLienTiepToiDa
        '
        Me.txtQDSoTHLienTiepToiDa.Location = New System.Drawing.Point(228, 146)
        Me.txtQDSoTHLienTiepToiDa.Name = "txtQDSoTHLienTiepToiDa"
        Me.txtQDSoTHLienTiepToiDa.Size = New System.Drawing.Size(300, 20)
        Me.txtQDSoTHLienTiepToiDa.TabIndex = 2
        '
        'txtQDSoTHLienTiepToiThieu
        '
        Me.txtQDSoTHLienTiepToiThieu.Location = New System.Drawing.Point(228, 107)
        Me.txtQDSoTHLienTiepToiThieu.Name = "txtQDSoTHLienTiepToiThieu"
        Me.txtQDSoTHLienTiepToiThieu.Size = New System.Drawing.Size(300, 20)
        Me.txtQDSoTHLienTiepToiThieu.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(171, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Qui định số tiết học liên tiếp tối đa:"
        '
        'txtTenMonHoc
        '
        Me.txtTenMonHoc.Location = New System.Drawing.Point(228, 64)
        Me.txtTenMonHoc.Name = "txtTenMonHoc"
        Me.txtTenMonHoc.Size = New System.Drawing.Size(300, 20)
        Me.txtTenMonHoc.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(181, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Qui định số tiết học liên tiếp tối thiểu:"
        '
        'txtMaMonHoc
        '
        Me.txtMaMonHoc.Location = New System.Drawing.Point(228, 25)
        Me.txtMaMonHoc.Name = "txtMaMonHoc"
        Me.txtMaMonHoc.ReadOnly = True
        Me.txtMaMonHoc.Size = New System.Drawing.Size(300, 20)
        Me.txtMaMonHoc.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Tên môn học:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mã môn học:"
        '
        'gbDanhSachMonHoc
        '
        Me.gbDanhSachMonHoc.Controls.Add(Me.Label7)
        Me.gbDanhSachMonHoc.Controls.Add(Me.Label6)
        Me.gbDanhSachMonHoc.Controls.Add(Me.gridDSMonHoc)
        Me.gbDanhSachMonHoc.Location = New System.Drawing.Point(558, 3)
        Me.gbDanhSachMonHoc.Name = "gbDanhSachMonHoc"
        Me.gbDanhSachMonHoc.Size = New System.Drawing.Size(431, 469)
        Me.gbDanhSachMonHoc.TabIndex = 2
        Me.gbDanhSachMonHoc.TabStop = False
        Me.gbDanhSachMonHoc.Text = "Danh sách các môn hoc"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(63, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(240, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "QĐSTHLTTĐ: Qui định số tiết học liên tiếp tối đa"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(63, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(249, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "QĐSTHLTTT: Qui định số tiết học liên tiếp tối thiểu"
        '
        'gridDSMonHoc
        '
        Me.gridDSMonHoc.AllowUserToAddRows = False
        Me.gridDSMonHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.gridDSMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDSMonHoc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gridDSMonHoc.Location = New System.Drawing.Point(3, 48)
        Me.gridDSMonHoc.Name = "gridDSMonHoc"
        Me.gridDSMonHoc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.gridDSMonHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridDSMonHoc.Size = New System.Drawing.Size(425, 418)
        Me.gridDSMonHoc.TabIndex = 0
        '
        'gbDanhSachGiaoVien
        '
        Me.gbDanhSachGiaoVien.Controls.Add(Me.gridDSGiaoVien)
        Me.gbDanhSachGiaoVien.Location = New System.Drawing.Point(3, 182)
        Me.gbDanhSachGiaoVien.Name = "gbDanhSachGiaoVien"
        Me.gbDanhSachGiaoVien.Size = New System.Drawing.Size(546, 293)
        Me.gbDanhSachGiaoVien.TabIndex = 3
        Me.gbDanhSachGiaoVien.TabStop = False
        Me.gbDanhSachGiaoVien.Text = "Danh sách giáo viên phụ trách"
        '
        'gridDSGiaoVien
        '
        Me.gridDSGiaoVien.AllowUserToAddRows = False
        Me.gridDSGiaoVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.gridDSGiaoVien.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gridDSGiaoVien.Location = New System.Drawing.Point(3, 19)
        Me.gridDSGiaoVien.Name = "gridDSGiaoVien"
        Me.gridDSGiaoVien.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.gridDSGiaoVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridDSGiaoVien.Size = New System.Drawing.Size(540, 271)
        Me.gridDSGiaoVien.TabIndex = 0
        '
        'btnTaoMonHocMoi
        '
        Me.btnTaoMonHocMoi.Location = New System.Drawing.Point(10, 481)
        Me.btnTaoMonHocMoi.Name = "btnTaoMonHocMoi"
        Me.btnTaoMonHocMoi.Size = New System.Drawing.Size(128, 23)
        Me.btnTaoMonHocMoi.TabIndex = 4
        Me.btnTaoMonHocMoi.Text = "Tạo Môn Học Mới"
        Me.btnTaoMonHocMoi.UseVisualStyleBackColor = True
        '
        'btnCapNhatDuLieu
        '
        Me.btnCapNhatDuLieu.Enabled = False
        Me.btnCapNhatDuLieu.Location = New System.Drawing.Point(229, 481)
        Me.btnCapNhatDuLieu.Name = "btnCapNhatDuLieu"
        Me.btnCapNhatDuLieu.Size = New System.Drawing.Size(122, 23)
        Me.btnCapNhatDuLieu.TabIndex = 5
        Me.btnCapNhatDuLieu.Text = "Cập Nhật Dữ Liệu"
        Me.btnCapNhatDuLieu.UseVisualStyleBackColor = True
        '
        'btnXoaMonHoc
        '
        Me.btnXoaMonHoc.Enabled = False
        Me.btnXoaMonHoc.Location = New System.Drawing.Point(420, 481)
        Me.btnXoaMonHoc.Name = "btnXoaMonHoc"
        Me.btnXoaMonHoc.Size = New System.Drawing.Size(127, 23)
        Me.btnXoaMonHoc.TabIndex = 6
        Me.btnXoaMonHoc.Text = "Xóa Môn Học Này"
        Me.btnXoaMonHoc.UseVisualStyleBackColor = True
        '
        'btnXuatRaTapTin
        '
        Me.btnXuatRaTapTin.Location = New System.Drawing.Point(624, 481)
        Me.btnXuatRaTapTin.Name = "btnXuatRaTapTin"
        Me.btnXuatRaTapTin.Size = New System.Drawing.Size(119, 23)
        Me.btnXuatRaTapTin.TabIndex = 7
        Me.btnXuatRaTapTin.Text = "Xuất Ra Tập Tin"
        Me.btnXuatRaTapTin.UseVisualStyleBackColor = True
        '
        'frmThongTinMonHoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnXuatRaTapTin)
        Me.Controls.Add(Me.btnXoaMonHoc)
        Me.Controls.Add(Me.btnCapNhatDuLieu)
        Me.Controls.Add(Me.btnTaoMonHocMoi)
        Me.Controls.Add(Me.gbDanhSachGiaoVien)
        Me.Controls.Add(Me.gbDanhSachMonHoc)
        Me.Controls.Add(Me.gbThongTinMonHoc)
        Me.Name = "frmThongTinMonHoc"
        Me.Size = New System.Drawing.Size(997, 523)
        Me.gbThongTinMonHoc.ResumeLayout(False)
        Me.gbThongTinMonHoc.PerformLayout()
        Me.gbDanhSachMonHoc.ResumeLayout(False)
        Me.gbDanhSachMonHoc.PerformLayout()
        CType(Me.gridDSMonHoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDanhSachGiaoVien.ResumeLayout(False)
        CType(Me.gridDSGiaoVien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbThongTinMonHoc As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaMonHoc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTenMonHoc As System.Windows.Forms.TextBox
    Friend WithEvents txtQDSoTHLienTiepToiDa As System.Windows.Forms.TextBox
    Friend WithEvents txtQDSoTHLienTiepToiThieu As System.Windows.Forms.TextBox
    Friend WithEvents gbDanhSachMonHoc As System.Windows.Forms.GroupBox
    Friend WithEvents gbDanhSachGiaoVien As System.Windows.Forms.GroupBox
    Friend WithEvents gridDSMonHoc As System.Windows.Forms.DataGridView
    Friend WithEvents gridDSGiaoVien As System.Windows.Forms.DataGridView
    Friend WithEvents btnTaoMonHocMoi As System.Windows.Forms.Button
    Friend WithEvents btnCapNhatDuLieu As System.Windows.Forms.Button
    Friend WithEvents btnXoaMonHoc As System.Windows.Forms.Button
    Friend WithEvents btnXuatRaTapTin As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
