<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPCTheoBoMon
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
        Me.gbThongTinGiaoVien = New System.Windows.Forms.GroupBox
        Me.txtTenTat = New System.Windows.Forms.TextBox
        Me.txtHoTenGV = New System.Windows.Forms.TextBox
        Me.lblTenTat = New System.Windows.Forms.Label
        Me.lblHoTenGV = New System.Windows.Forms.Label
        Me.gbDSMonHoc = New System.Windows.Forms.GroupBox
        Me.ckblistMonHoc = New System.Windows.Forms.CheckedListBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ckblistLopHoc = New System.Windows.Forms.CheckedListBox
        Me.gbBangPhanCong = New System.Windows.Forms.GroupBox
        Me.gridBangPhanCong = New System.Windows.Forms.DataGridView
        Me.gridDSGiaoVien = New System.Windows.Forms.DataGridView
        Me.bGVKeTruoc = New System.Windows.Forms.Button
        Me.bGVTiepTheo = New System.Windows.Forms.Button
        Me.bCapNhat = New System.Windows.Forms.Button
        Me.gbDSGVPhuTrach = New System.Windows.Forms.GroupBox
        Me.bXuatFile = New System.Windows.Forms.Button
        Me.gbThongTinGiaoVien.SuspendLayout()
        Me.gbDSMonHoc.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbBangPhanCong.SuspendLayout()
        CType(Me.gridBangPhanCong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridDSGiaoVien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDSGVPhuTrach.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbThongTinGiaoVien
        '
        Me.gbThongTinGiaoVien.Controls.Add(Me.txtTenTat)
        Me.gbThongTinGiaoVien.Controls.Add(Me.txtHoTenGV)
        Me.gbThongTinGiaoVien.Controls.Add(Me.lblTenTat)
        Me.gbThongTinGiaoVien.Controls.Add(Me.lblHoTenGV)
        Me.gbThongTinGiaoVien.Location = New System.Drawing.Point(3, 0)
        Me.gbThongTinGiaoVien.Name = "gbThongTinGiaoVien"
        Me.gbThongTinGiaoVien.Size = New System.Drawing.Size(623, 53)
        Me.gbThongTinGiaoVien.TabIndex = 2
        Me.gbThongTinGiaoVien.TabStop = False
        Me.gbThongTinGiaoVien.Text = "Thông tin giáo viên"
        '
        'txtTenTat
        '
        Me.txtTenTat.Location = New System.Drawing.Point(345, 25)
        Me.txtTenTat.Name = "txtTenTat"
        Me.txtTenTat.Size = New System.Drawing.Size(146, 20)
        Me.txtTenTat.TabIndex = 5
        '
        'txtHoTenGV
        '
        Me.txtHoTenGV.Location = New System.Drawing.Point(108, 25)
        Me.txtHoTenGV.Name = "txtHoTenGV"
        Me.txtHoTenGV.Size = New System.Drawing.Size(174, 20)
        Me.txtHoTenGV.TabIndex = 4
        '
        'lblTenTat
        '
        Me.lblTenTat.AutoSize = True
        Me.lblTenTat.Location = New System.Drawing.Point(297, 30)
        Me.lblTenTat.Name = "lblTenTat"
        Me.lblTenTat.Size = New System.Drawing.Size(41, 13)
        Me.lblTenTat.TabIndex = 3
        Me.lblTenTat.Text = "Tên tắt"
        '
        'lblHoTenGV
        '
        Me.lblHoTenGV.AutoSize = True
        Me.lblHoTenGV.Location = New System.Drawing.Point(17, 28)
        Me.lblHoTenGV.Name = "lblHoTenGV"
        Me.lblHoTenGV.Size = New System.Drawing.Size(85, 13)
        Me.lblHoTenGV.TabIndex = 3
        Me.lblHoTenGV.Text = "Họ tên giáo viên"
        '
        'gbDSMonHoc
        '
        Me.gbDSMonHoc.Controls.Add(Me.ckblistMonHoc)
        Me.gbDSMonHoc.Location = New System.Drawing.Point(5, 59)
        Me.gbDSMonHoc.Name = "gbDSMonHoc"
        Me.gbDSMonHoc.Size = New System.Drawing.Size(621, 116)
        Me.gbDSMonHoc.TabIndex = 3
        Me.gbDSMonHoc.TabStop = False
        Me.gbDSMonHoc.Text = "Danh sách môn học"
        '
        'ckblistMonHoc
        '
        Me.ckblistMonHoc.CheckOnClick = True
        Me.ckblistMonHoc.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ckblistMonHoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckblistMonHoc.FormattingEnabled = True
        Me.ckblistMonHoc.Location = New System.Drawing.Point(3, 16)
        Me.ckblistMonHoc.MultiColumn = True
        Me.ckblistMonHoc.Name = "ckblistMonHoc"
        Me.ckblistMonHoc.Size = New System.Drawing.Size(615, 94)
        Me.ckblistMonHoc.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckblistLopHoc)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 181)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(620, 112)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Danh sách lớp học"
        '
        'ckblistLopHoc
        '
        Me.ckblistLopHoc.CheckOnClick = True
        Me.ckblistLopHoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckblistLopHoc.FormattingEnabled = True
        Me.ckblistLopHoc.Location = New System.Drawing.Point(3, 16)
        Me.ckblistLopHoc.MultiColumn = True
        Me.ckblistLopHoc.Name = "ckblistLopHoc"
        Me.ckblistLopHoc.Size = New System.Drawing.Size(614, 79)
        Me.ckblistLopHoc.TabIndex = 0
        '
        'gbBangPhanCong
        '
        Me.gbBangPhanCong.Controls.Add(Me.gridBangPhanCong)
        Me.gbBangPhanCong.Location = New System.Drawing.Point(5, 299)
        Me.gbBangPhanCong.Name = "gbBangPhanCong"
        Me.gbBangPhanCong.Size = New System.Drawing.Size(615, 193)
        Me.gbBangPhanCong.TabIndex = 4
        Me.gbBangPhanCong.TabStop = False
        Me.gbBangPhanCong.Text = "Bảng phân công"
        '
        'gridBangPhanCong
        '
        Me.gridBangPhanCong.AllowUserToAddRows = False
        Me.gridBangPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBangPhanCong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridBangPhanCong.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.gridBangPhanCong.Location = New System.Drawing.Point(3, 16)
        Me.gridBangPhanCong.Name = "gridBangPhanCong"
        Me.gridBangPhanCong.Size = New System.Drawing.Size(609, 174)
        Me.gridBangPhanCong.TabIndex = 0
        '
        'gridDSGiaoVien
        '
        Me.gridDSGiaoVien.AllowUserToAddRows = False
        Me.gridDSGiaoVien.AllowUserToDeleteRows = False
        Me.gridDSGiaoVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDSGiaoVien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDSGiaoVien.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridDSGiaoVien.Location = New System.Drawing.Point(3, 16)
        Me.gridDSGiaoVien.Name = "gridDSGiaoVien"
        Me.gridDSGiaoVien.ReadOnly = True
        Me.gridDSGiaoVien.Size = New System.Drawing.Size(341, 467)
        Me.gridDSGiaoVien.TabIndex = 5
        '
        'bGVKeTruoc
        '
        Me.bGVKeTruoc.Location = New System.Drawing.Point(23, 495)
        Me.bGVKeTruoc.Name = "bGVKeTruoc"
        Me.bGVKeTruoc.Size = New System.Drawing.Size(105, 23)
        Me.bGVKeTruoc.TabIndex = 7
        Me.bGVKeTruoc.Text = "Giáo viên kế trước"
        Me.bGVKeTruoc.UseVisualStyleBackColor = True
        '
        'bGVTiepTheo
        '
        Me.bGVTiepTheo.Location = New System.Drawing.Point(167, 495)
        Me.bGVTiepTheo.Name = "bGVTiepTheo"
        Me.bGVTiepTheo.Size = New System.Drawing.Size(105, 23)
        Me.bGVTiepTheo.TabIndex = 7
        Me.bGVTiepTheo.Text = "Giáo viên tiếp theo"
        Me.bGVTiepTheo.UseVisualStyleBackColor = True
        '
        'bCapNhat
        '
        Me.bCapNhat.Location = New System.Drawing.Point(321, 495)
        Me.bCapNhat.Name = "bCapNhat"
        Me.bCapNhat.Size = New System.Drawing.Size(105, 23)
        Me.bCapNhat.TabIndex = 7
        Me.bCapNhat.Text = "Cập nhật dữ liệu"
        Me.bCapNhat.UseVisualStyleBackColor = True
        '
        'gbDSGVPhuTrach
        '
        Me.gbDSGVPhuTrach.Controls.Add(Me.gridDSGiaoVien)
        Me.gbDSGVPhuTrach.Location = New System.Drawing.Point(645, 0)
        Me.gbDSGVPhuTrach.Name = "gbDSGVPhuTrach"
        Me.gbDSGVPhuTrach.Size = New System.Drawing.Size(347, 486)
        Me.gbDSGVPhuTrach.TabIndex = 8
        Me.gbDSGVPhuTrach.TabStop = False
        Me.gbDSGVPhuTrach.Text = "Danh sách giáo viên phụ trách"
        '
        'bXuatFile
        '
        Me.bXuatFile.Location = New System.Drawing.Point(496, 495)
        Me.bXuatFile.Name = "bXuatFile"
        Me.bXuatFile.Size = New System.Drawing.Size(130, 23)
        Me.bXuatFile.TabIndex = 9
        Me.bXuatFile.Text = "Xuất ra tập tin"
        Me.bXuatFile.UseVisualStyleBackColor = True
        '
        'frmPCTheoBoMon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.bXuatFile)
        Me.Controls.Add(Me.gbDSGVPhuTrach)
        Me.Controls.Add(Me.bGVTiepTheo)
        Me.Controls.Add(Me.bCapNhat)
        Me.Controls.Add(Me.bGVKeTruoc)
        Me.Controls.Add(Me.gbBangPhanCong)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbDSMonHoc)
        Me.Controls.Add(Me.gbThongTinGiaoVien)
        Me.Name = "frmPCTheoBoMon"
        Me.Size = New System.Drawing.Size(997, 523)
        Me.gbThongTinGiaoVien.ResumeLayout(False)
        Me.gbThongTinGiaoVien.PerformLayout()
        Me.gbDSMonHoc.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.gbBangPhanCong.ResumeLayout(False)
        CType(Me.gridBangPhanCong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridDSGiaoVien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDSGVPhuTrach.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbThongTinGiaoVien As System.Windows.Forms.GroupBox
    Friend WithEvents txtTenTat As System.Windows.Forms.TextBox
    Friend WithEvents txtHoTenGV As System.Windows.Forms.TextBox
    Friend WithEvents lblTenTat As System.Windows.Forms.Label
    Friend WithEvents lblHoTenGV As System.Windows.Forms.Label
    Friend WithEvents gbDSMonHoc As System.Windows.Forms.GroupBox
    Friend WithEvents ckblistMonHoc As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ckblistLopHoc As System.Windows.Forms.CheckedListBox
    Friend WithEvents gbBangPhanCong As System.Windows.Forms.GroupBox
    Friend WithEvents gridBangPhanCong As System.Windows.Forms.DataGridView
    Friend WithEvents bGVKeTruoc As System.Windows.Forms.Button
    Friend WithEvents bGVTiepTheo As System.Windows.Forms.Button
    Friend WithEvents bCapNhat As System.Windows.Forms.Button
    Friend WithEvents gridDSGiaoVien As System.Windows.Forms.DataGridView
    Friend WithEvents gbDSGVPhuTrach As System.Windows.Forms.GroupBox
    Friend WithEvents bXuatFile As System.Windows.Forms.Button

End Class
