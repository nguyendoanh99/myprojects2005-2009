<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPCTheoLopHoc
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
        Me.gbThongTinLopHoc = New System.Windows.Forms.GroupBox
        Me.cbTenLH = New System.Windows.Forms.ComboBox
        Me.labKhoi = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rbTatCa = New System.Windows.Forms.RadioButton
        Me.rd12 = New System.Windows.Forms.RadioButton
        Me.rb11 = New System.Windows.Forms.RadioButton
        Me.rb10 = New System.Windows.Forms.RadioButton
        Me.txtMaLH = New System.Windows.Forms.TextBox
        Me.cbTenLopHoc = New System.Windows.Forms.Label
        Me.txtMaLopHoc = New System.Windows.Forms.Label
        Me.gbDSMonHoc = New System.Windows.Forms.GroupBox
        Me.ckblistMonHoc = New System.Windows.Forms.CheckedListBox
        Me.gbBangPhanCong = New System.Windows.Forms.GroupBox
        Me.gridBangPhanCong = New System.Windows.Forms.DataGridView
        Me.colSTT1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMaPC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMaLopHoc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMaMonHoc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMaGV = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLopHoc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMonHoc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colGiaoVien = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTongSoTiet = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSTHLTTT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSTHLTTD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSBHTT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSBHTD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gridDSGiaoVien = New System.Windows.Forms.DataGridView
        Me.colSTT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMaGiaoVien = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colHoTen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTenTat = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.butLHKeTruoc = New System.Windows.Forms.Button
        Me.butLHTiepTheo = New System.Windows.Forms.Button
        Me.butCapNhat = New System.Windows.Forms.Button
        Me.gbDSGVPhuTrach = New System.Windows.Forms.GroupBox
        Me.butXuatFile = New System.Windows.Forms.Button
        Me.gbThongTinLopHoc.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gbDSMonHoc.SuspendLayout()
        Me.gbBangPhanCong.SuspendLayout()
        CType(Me.gridBangPhanCong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridDSGiaoVien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDSGVPhuTrach.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbThongTinLopHoc
        '
        Me.gbThongTinLopHoc.Controls.Add(Me.cbTenLH)
        Me.gbThongTinLopHoc.Controls.Add(Me.labKhoi)
        Me.gbThongTinLopHoc.Controls.Add(Me.Panel2)
        Me.gbThongTinLopHoc.Controls.Add(Me.txtMaLH)
        Me.gbThongTinLopHoc.Controls.Add(Me.cbTenLopHoc)
        Me.gbThongTinLopHoc.Controls.Add(Me.txtMaLopHoc)
        Me.gbThongTinLopHoc.Location = New System.Drawing.Point(0, 0)
        Me.gbThongTinLopHoc.Name = "gbThongTinLopHoc"
        Me.gbThongTinLopHoc.Size = New System.Drawing.Size(671, 137)
        Me.gbThongTinLopHoc.TabIndex = 2
        Me.gbThongTinLopHoc.TabStop = False
        Me.gbThongTinLopHoc.Text = "Thông tin lớp học"
        '
        'cbTenLH
        '
        Me.cbTenLH.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.cbTenLH.FormattingEnabled = True
        Me.cbTenLH.Location = New System.Drawing.Point(185, 71)
        Me.cbTenLH.Name = "cbTenLH"
        Me.cbTenLH.Size = New System.Drawing.Size(174, 21)
        Me.cbTenLH.TabIndex = 7
        '
        'labKhoi
        '
        Me.labKhoi.AutoSize = True
        Me.labKhoi.Location = New System.Drawing.Point(76, 33)
        Me.labKhoi.Name = "labKhoi"
        Me.labKhoi.Size = New System.Drawing.Size(28, 13)
        Me.labKhoi.TabIndex = 6
        Me.labKhoi.Text = "Khối"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.rbTatCa)
        Me.Panel2.Controls.Add(Me.rd12)
        Me.Panel2.Controls.Add(Me.rb11)
        Me.Panel2.Controls.Add(Me.rb10)
        Me.Panel2.Location = New System.Drawing.Point(185, 19)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(258, 39)
        Me.Panel2.TabIndex = 5
        '
        'rbTatCa
        '
        Me.rbTatCa.AutoSize = True
        Me.rbTatCa.Location = New System.Drawing.Point(197, 15)
        Me.rbTatCa.Name = "rbTatCa"
        Me.rbTatCa.Size = New System.Drawing.Size(56, 17)
        Me.rbTatCa.TabIndex = 2
        Me.rbTatCa.Text = "Tất cả"
        Me.rbTatCa.UseVisualStyleBackColor = True
        '
        'rd12
        '
        Me.rd12.AutoSize = True
        Me.rd12.Location = New System.Drawing.Point(136, 15)
        Me.rd12.Name = "rd12"
        Me.rd12.Size = New System.Drawing.Size(37, 17)
        Me.rd12.TabIndex = 1
        Me.rd12.Text = "12"
        Me.rd12.UseVisualStyleBackColor = True
        '
        'rb11
        '
        Me.rb11.AutoSize = True
        Me.rb11.Location = New System.Drawing.Point(70, 15)
        Me.rb11.Name = "rb11"
        Me.rb11.Size = New System.Drawing.Size(37, 17)
        Me.rb11.TabIndex = 0
        Me.rb11.Text = "11"
        Me.rb11.UseVisualStyleBackColor = True
        '
        'rb10
        '
        Me.rb10.AutoSize = True
        Me.rb10.Location = New System.Drawing.Point(12, 15)
        Me.rb10.Name = "rb10"
        Me.rb10.Size = New System.Drawing.Size(37, 17)
        Me.rb10.TabIndex = 0
        Me.rb10.Text = "10"
        Me.rb10.UseVisualStyleBackColor = True
        '
        'txtMaLH
        '
        Me.txtMaLH.Enabled = False
        Me.txtMaLH.Location = New System.Drawing.Point(185, 107)
        Me.txtMaLH.Name = "txtMaLH"
        Me.txtMaLH.Size = New System.Drawing.Size(174, 20)
        Me.txtMaLH.TabIndex = 4
        '
        'cbTenLopHoc
        '
        Me.cbTenLopHoc.AutoSize = True
        Me.cbTenLopHoc.Location = New System.Drawing.Point(76, 74)
        Me.cbTenLopHoc.Name = "cbTenLopHoc"
        Me.cbTenLopHoc.Size = New System.Drawing.Size(64, 13)
        Me.cbTenLopHoc.TabIndex = 3
        Me.cbTenLopHoc.Text = "Tên lớp học"
        '
        'txtMaLopHoc
        '
        Me.txtMaLopHoc.AutoSize = True
        Me.txtMaLopHoc.Location = New System.Drawing.Point(76, 114)
        Me.txtMaLopHoc.Name = "txtMaLopHoc"
        Me.txtMaLopHoc.Size = New System.Drawing.Size(60, 13)
        Me.txtMaLopHoc.TabIndex = 3
        Me.txtMaLopHoc.Text = "Mã lớp học"
        '
        'gbDSMonHoc
        '
        Me.gbDSMonHoc.Controls.Add(Me.ckblistMonHoc)
        Me.gbDSMonHoc.Location = New System.Drawing.Point(3, 146)
        Me.gbDSMonHoc.Name = "gbDSMonHoc"
        Me.gbDSMonHoc.Size = New System.Drawing.Size(671, 107)
        Me.gbDSMonHoc.TabIndex = 3
        Me.gbDSMonHoc.TabStop = False
        Me.gbDSMonHoc.Text = "Danh sách môn học"
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
        Me.ckblistMonHoc.Size = New System.Drawing.Size(665, 79)
        Me.ckblistMonHoc.TabIndex = 0
        '
        'gbBangPhanCong
        '
        Me.gbBangPhanCong.Controls.Add(Me.gridBangPhanCong)
        Me.gbBangPhanCong.Location = New System.Drawing.Point(3, 259)
        Me.gbBangPhanCong.Name = "gbBangPhanCong"
        Me.gbBangPhanCong.Size = New System.Drawing.Size(675, 221)
        Me.gbBangPhanCong.TabIndex = 4
        Me.gbBangPhanCong.TabStop = False
        Me.gbBangPhanCong.Text = "Bảng phân công"
        '
        'gridBangPhanCong
        '
        Me.gridBangPhanCong.AllowUserToAddRows = False
        Me.gridBangPhanCong.BackgroundColor = System.Drawing.Color.White
        Me.gridBangPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBangPhanCong.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSTT1, Me.colMaPC, Me.colMaLopHoc, Me.colMaMonHoc, Me.colMaGV, Me.colLopHoc, Me.colMonHoc, Me.colGiaoVien, Me.colTongSoTiet, Me.colSTHLTTT, Me.colSTHLTTD, Me.colSBHTT, Me.colSBHTD})
        Me.gridBangPhanCong.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.gridBangPhanCong.Location = New System.Drawing.Point(6, 19)
        Me.gridBangPhanCong.Name = "gridBangPhanCong"
        Me.gridBangPhanCong.RowHeadersVisible = False
        Me.gridBangPhanCong.Size = New System.Drawing.Size(657, 196)
        Me.gridBangPhanCong.TabIndex = 0
        '
        'colSTT1
        '
        Me.colSTT1.HeaderText = "STT"
        Me.colSTT1.Name = "colSTT1"
        Me.colSTT1.ReadOnly = True
        '
        'colMaPC
        '
        Me.colMaPC.HeaderText = "Mã Phân Công"
        Me.colMaPC.Name = "colMaPC"
        Me.colMaPC.Visible = False
        '
        'colMaLopHoc
        '
        Me.colMaLopHoc.HeaderText = "Mã Lớp Học"
        Me.colMaLopHoc.Name = "colMaLopHoc"
        Me.colMaLopHoc.Visible = False
        '
        'colMaMonHoc
        '
        Me.colMaMonHoc.HeaderText = "Mã Môn Học"
        Me.colMaMonHoc.Name = "colMaMonHoc"
        Me.colMaMonHoc.Visible = False
        '
        'colMaGV
        '
        Me.colMaGV.HeaderText = "Mã Giáo Viên"
        Me.colMaGV.Name = "colMaGV"
        Me.colMaGV.Visible = False
        '
        'colLopHoc
        '
        Me.colLopHoc.HeaderText = "Lớp Học"
        Me.colLopHoc.Name = "colLopHoc"
        Me.colLopHoc.ReadOnly = True
        '
        'colMonHoc
        '
        Me.colMonHoc.HeaderText = "Môn Học"
        Me.colMonHoc.Name = "colMonHoc"
        Me.colMonHoc.ReadOnly = True
        '
        'colGiaoVien
        '
        Me.colGiaoVien.HeaderText = "Giáo Viên"
        Me.colGiaoVien.Name = "colGiaoVien"
        '
        'colTongSoTiet
        '
        Me.colTongSoTiet.HeaderText = "Tổng Số Tiết/Tuần"
        Me.colTongSoTiet.Name = "colTongSoTiet"
        '
        'colSTHLTTT
        '
        Me.colSTHLTTT.HeaderText = "STHLTTT"
        Me.colSTHLTTT.Name = "colSTHLTTT"
        Me.colSTHLTTT.ReadOnly = True
        '
        'colSTHLTTD
        '
        Me.colSTHLTTD.HeaderText = "STTLTTD"
        Me.colSTHLTTD.Name = "colSTHLTTD"
        Me.colSTHLTTD.ReadOnly = True
        '
        'colSBHTT
        '
        Me.colSBHTT.HeaderText = "SBHTT"
        Me.colSBHTT.Name = "colSBHTT"
        Me.colSBHTT.ReadOnly = True
        '
        'colSBHTD
        '
        Me.colSBHTD.HeaderText = "SBHTT"
        Me.colSBHTD.Name = "colSBHTD"
        Me.colSBHTD.ReadOnly = True
        '
        'gridDSGiaoVien
        '
        Me.gridDSGiaoVien.AllowUserToAddRows = False
        Me.gridDSGiaoVien.AllowUserToDeleteRows = False
        Me.gridDSGiaoVien.BackgroundColor = System.Drawing.Color.White
        Me.gridDSGiaoVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDSGiaoVien.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSTT, Me.colMaGiaoVien, Me.colHoTen, Me.colTenTat})
        Me.gridDSGiaoVien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDSGiaoVien.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridDSGiaoVien.Location = New System.Drawing.Point(3, 16)
        Me.gridDSGiaoVien.Name = "gridDSGiaoVien"
        Me.gridDSGiaoVien.ReadOnly = True
        Me.gridDSGiaoVien.RowHeadersVisible = False
        Me.gridDSGiaoVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridDSGiaoVien.Size = New System.Drawing.Size(309, 458)
        Me.gridDSGiaoVien.TabIndex = 5
        '
        'colSTT
        '
        Me.colSTT.HeaderText = "STT"
        Me.colSTT.Name = "colSTT"
        Me.colSTT.ReadOnly = True
        '
        'colMaGiaoVien
        '
        Me.colMaGiaoVien.HeaderText = "Mã Giáo Viên"
        Me.colMaGiaoVien.Name = "colMaGiaoVien"
        Me.colMaGiaoVien.ReadOnly = True
        Me.colMaGiaoVien.Visible = False
        '
        'colHoTen
        '
        Me.colHoTen.HeaderText = "Họ Tên Giáo Viên"
        Me.colHoTen.Name = "colHoTen"
        Me.colHoTen.ReadOnly = True
        '
        'colTenTat
        '
        Me.colTenTat.HeaderText = "Tên Tắt"
        Me.colTenTat.Name = "colTenTat"
        Me.colTenTat.ReadOnly = True
        '
        'butLHKeTruoc
        '
        Me.butLHKeTruoc.Location = New System.Drawing.Point(96, 486)
        Me.butLHKeTruoc.Name = "butLHKeTruoc"
        Me.butLHKeTruoc.Size = New System.Drawing.Size(105, 23)
        Me.butLHKeTruoc.TabIndex = 7
        Me.butLHKeTruoc.Text = "Lớp học kế trước"
        Me.butLHKeTruoc.UseVisualStyleBackColor = True
        '
        'butLHTiepTheo
        '
        Me.butLHTiepTheo.Location = New System.Drawing.Point(218, 486)
        Me.butLHTiepTheo.Name = "butLHTiepTheo"
        Me.butLHTiepTheo.Size = New System.Drawing.Size(105, 23)
        Me.butLHTiepTheo.TabIndex = 7
        Me.butLHTiepTheo.Text = "Lớp học tiếp theo"
        Me.butLHTiepTheo.UseVisualStyleBackColor = True
        '
        'butCapNhat
        '
        Me.butCapNhat.Location = New System.Drawing.Point(329, 486)
        Me.butCapNhat.Name = "butCapNhat"
        Me.butCapNhat.Size = New System.Drawing.Size(105, 23)
        Me.butCapNhat.TabIndex = 7
        Me.butCapNhat.Text = "Cập nhật dữ liệu"
        Me.butCapNhat.UseVisualStyleBackColor = True
        '
        'gbDSGVPhuTrach
        '
        Me.gbDSGVPhuTrach.Controls.Add(Me.gridDSGiaoVien)
        Me.gbDSGVPhuTrach.Location = New System.Drawing.Point(677, 0)
        Me.gbDSGVPhuTrach.Name = "gbDSGVPhuTrach"
        Me.gbDSGVPhuTrach.Size = New System.Drawing.Size(315, 477)
        Me.gbDSGVPhuTrach.TabIndex = 8
        Me.gbDSGVPhuTrach.TabStop = False
        Me.gbDSGVPhuTrach.Text = "Danh sách giáo viên"
        '
        'butXuatFile
        '
        Me.butXuatFile.Location = New System.Drawing.Point(457, 486)
        Me.butXuatFile.Name = "butXuatFile"
        Me.butXuatFile.Size = New System.Drawing.Size(130, 23)
        Me.butXuatFile.TabIndex = 9
        Me.butXuatFile.Text = "Xuất ra tập tin"
        Me.butXuatFile.UseVisualStyleBackColor = True
        '
        'frmPCTheoLopHoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.butXuatFile)
        Me.Controls.Add(Me.gbDSGVPhuTrach)
        Me.Controls.Add(Me.butLHTiepTheo)
        Me.Controls.Add(Me.butCapNhat)
        Me.Controls.Add(Me.butLHKeTruoc)
        Me.Controls.Add(Me.gbBangPhanCong)
        Me.Controls.Add(Me.gbDSMonHoc)
        Me.Controls.Add(Me.gbThongTinLopHoc)
        Me.Name = "frmPCTheoLopHoc"
        Me.Size = New System.Drawing.Size(997, 523)
        Me.gbThongTinLopHoc.ResumeLayout(False)
        Me.gbThongTinLopHoc.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.gbDSMonHoc.ResumeLayout(False)
        Me.gbBangPhanCong.ResumeLayout(False)
        CType(Me.gridBangPhanCong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridDSGiaoVien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDSGVPhuTrach.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbThongTinLopHoc As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaLH As System.Windows.Forms.TextBox
    Friend WithEvents cbTenLopHoc As System.Windows.Forms.Label
    Friend WithEvents txtMaLopHoc As System.Windows.Forms.Label
    Friend WithEvents gbDSMonHoc As System.Windows.Forms.GroupBox
    Friend WithEvents ckblistMonHoc As System.Windows.Forms.CheckedListBox
    Friend WithEvents gbBangPhanCong As System.Windows.Forms.GroupBox
    Friend WithEvents gridBangPhanCong As System.Windows.Forms.DataGridView
    Friend WithEvents butLHKeTruoc As System.Windows.Forms.Button
    Friend WithEvents butLHTiepTheo As System.Windows.Forms.Button
    Friend WithEvents butCapNhat As System.Windows.Forms.Button
    Friend WithEvents gridDSGiaoVien As System.Windows.Forms.DataGridView
    Friend WithEvents gbDSGVPhuTrach As System.Windows.Forms.GroupBox
    Friend WithEvents butXuatFile As System.Windows.Forms.Button
    Friend WithEvents labKhoi As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rd12 As System.Windows.Forms.RadioButton
    Friend WithEvents rb11 As System.Windows.Forms.RadioButton
    Friend WithEvents rb10 As System.Windows.Forms.RadioButton
    Friend WithEvents rbTatCa As System.Windows.Forms.RadioButton
    Friend WithEvents cbTenLH As System.Windows.Forms.ComboBox
    Friend WithEvents colSTT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMaGiaoVien As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHoTen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTenTat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSTT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMaPC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMaLopHoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMaMonHoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMaGV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLopHoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMonHoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGiaoVien As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTongSoTiet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSTHLTTT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSTHLTTD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSBHTT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSBHTD As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
