<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTKBGV
    Inherits System.Windows.Forms.UserControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtMonPhuTrach = New System.Windows.Forms.TextBox
        Me.txtTongSoTietDay = New System.Windows.Forms.TextBox
        Me.cmbTenGiaoVien = New System.Windows.Forms.ComboBox
        Me.txtTenTat = New System.Windows.Forms.TextBox
        Me.txtMaGiaoVien = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.gridDsGiaoVien = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.gridLichDay = New System.Windows.Forms.DataGridView
        Me.btnGvtruoc = New System.Windows.Forms.Button
        Me.btnGvsau = New System.Windows.Forms.Button
        Me.btnXuat = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridDsGiaoVien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.gridLichDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMonPhuTrach)
        Me.GroupBox1.Controls.Add(Me.txtTongSoTietDay)
        Me.GroupBox1.Controls.Add(Me.cmbTenGiaoVien)
        Me.GroupBox1.Controls.Add(Me.txtTenTat)
        Me.GroupBox1.Controls.Add(Me.txtMaGiaoVien)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(609, 160)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin giáo viên"
        '
        'txtMonPhuTrach
        '
        Me.txtMonPhuTrach.Location = New System.Drawing.Point(128, 121)
        Me.txtMonPhuTrach.Name = "txtMonPhuTrach"
        Me.txtMonPhuTrach.Size = New System.Drawing.Size(175, 20)
        Me.txtMonPhuTrach.TabIndex = 3
        '
        'txtTongSoTietDay
        '
        Me.txtTongSoTietDay.Location = New System.Drawing.Point(128, 91)
        Me.txtTongSoTietDay.Name = "txtTongSoTietDay"
        Me.txtTongSoTietDay.Size = New System.Drawing.Size(67, 20)
        Me.txtTongSoTietDay.TabIndex = 3
        Me.txtTongSoTietDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbTenGiaoVien
        '
        Me.cmbTenGiaoVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTenGiaoVien.FormattingEnabled = True
        Me.cmbTenGiaoVien.Location = New System.Drawing.Point(128, 57)
        Me.cmbTenGiaoVien.Name = "cmbTenGiaoVien"
        Me.cmbTenGiaoVien.Size = New System.Drawing.Size(153, 21)
        Me.cmbTenGiaoVien.TabIndex = 2
        '
        'txtTenTat
        '
        Me.txtTenTat.Enabled = False
        Me.txtTenTat.Location = New System.Drawing.Point(422, 27)
        Me.txtTenTat.Name = "txtTenTat"
        Me.txtTenTat.Size = New System.Drawing.Size(126, 20)
        Me.txtTenTat.TabIndex = 1
        Me.txtTenTat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMaGiaoVien
        '
        Me.txtMaGiaoVien.Enabled = False
        Me.txtMaGiaoVien.Location = New System.Drawing.Point(129, 27)
        Me.txtMaGiaoVien.Name = "txtMaGiaoVien"
        Me.txtMaGiaoVien.Size = New System.Drawing.Size(152, 20)
        Me.txtMaGiaoVien.TabIndex = 1
        Me.txtMaGiaoVien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Môn phụ trách"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Tổng số tiết dạy"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tên giáo viên"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(342, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Tên tắt"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mã giáo viên"
        '
        'gridDsGiaoVien
        '
        Me.gridDsGiaoVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDsGiaoVien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDsGiaoVien.Location = New System.Drawing.Point(3, 16)
        Me.gridDsGiaoVien.Name = "gridDsGiaoVien"
        Me.gridDsGiaoVien.Size = New System.Drawing.Size(328, 458)
        Me.gridDsGiaoVien.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.gridDsGiaoVien)
        Me.GroupBox3.Location = New System.Drawing.Point(619, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(334, 477)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Danh sách giáo viên"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.gridLichDay)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 169)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(608, 311)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Bảng lịch dạy"
        '
        'gridLichDay
        '
        Me.gridLichDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridLichDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridLichDay.Location = New System.Drawing.Point(3, 16)
        Me.gridLichDay.Name = "gridLichDay"
        Me.gridLichDay.Size = New System.Drawing.Size(602, 292)
        Me.gridLichDay.TabIndex = 0
        '
        'btnGvtruoc
        '
        Me.btnGvtruoc.Location = New System.Drawing.Point(111, 499)
        Me.btnGvtruoc.Name = "btnGvtruoc"
        Me.btnGvtruoc.Size = New System.Drawing.Size(108, 28)
        Me.btnGvtruoc.TabIndex = 4
        Me.btnGvtruoc.Text = "Giáo viên kế trước"
        Me.btnGvtruoc.UseVisualStyleBackColor = True
        '
        'btnGvsau
        '
        Me.btnGvsau.Location = New System.Drawing.Point(327, 499)
        Me.btnGvsau.Name = "btnGvsau"
        Me.btnGvsau.Size = New System.Drawing.Size(108, 28)
        Me.btnGvsau.TabIndex = 4
        Me.btnGvsau.Text = "Giáo viên tiếp theo"
        Me.btnGvsau.UseVisualStyleBackColor = True
        '
        'btnXuat
        '
        Me.btnXuat.Location = New System.Drawing.Point(585, 499)
        Me.btnXuat.Name = "btnXuat"
        Me.btnXuat.Size = New System.Drawing.Size(108, 28)
        Me.btnXuat.TabIndex = 5
        Me.btnXuat.Text = "Xuất ra tập tin"
        Me.btnXuat.UseVisualStyleBackColor = True
        '
        'frmTKBGV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnXuat)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnGvsau)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnGvtruoc)
        Me.Name = "frmTKBGV"
        Me.Size = New System.Drawing.Size(997, 554)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridDsGiaoVien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.gridLichDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTongSoTietDay As System.Windows.Forms.TextBox
    Friend WithEvents cmbTenGiaoVien As System.Windows.Forms.ComboBox
    Friend WithEvents txtMaGiaoVien As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMonPhuTrach As System.Windows.Forms.TextBox
    Friend WithEvents gridDsGiaoVien As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents gridLichDay As System.Windows.Forms.DataGridView
    Friend WithEvents txtTenTat As System.Windows.Forms.TextBox
    Friend WithEvents btnGvtruoc As System.Windows.Forms.Button
    Friend WithEvents btnGvsau As System.Windows.Forms.Button
    Friend WithEvents btnXuat As System.Windows.Forms.Button
End Class
