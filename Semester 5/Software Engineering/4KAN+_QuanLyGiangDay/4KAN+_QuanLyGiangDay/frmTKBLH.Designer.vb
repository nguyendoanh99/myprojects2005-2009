<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTKBLH
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
        Me.txtMaLopHoc = New System.Windows.Forms.TextBox
        Me.cmbTenLopHoc = New System.Windows.Forms.ComboBox
        Me.rdTatCa = New System.Windows.Forms.RadioButton
        Me.rd12 = New System.Windows.Forms.RadioButton
        Me.rd11 = New System.Windows.Forms.RadioButton
        Me.rd10 = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gridTKBLH = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnXuat = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridTKBLH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMaLopHoc)
        Me.GroupBox1.Controls.Add(Me.cmbTenLopHoc)
        Me.GroupBox1.Controls.Add(Me.rdTatCa)
        Me.GroupBox1.Controls.Add(Me.rd12)
        Me.GroupBox1.Controls.Add(Me.rd11)
        Me.GroupBox1.Controls.Add(Me.rd10)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(997, 150)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin lớp học"
        '
        'txtMaLopHoc
        '
        Me.txtMaLopHoc.Enabled = False
        Me.txtMaLopHoc.Location = New System.Drawing.Point(173, 106)
        Me.txtMaLopHoc.Name = "txtMaLopHoc"
        Me.txtMaLopHoc.Size = New System.Drawing.Size(190, 20)
        Me.txtMaLopHoc.TabIndex = 3
        '
        'cmbTenLopHoc
        '
        Me.cmbTenLopHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTenLopHoc.FormattingEnabled = True
        Me.cmbTenLopHoc.Location = New System.Drawing.Point(172, 68)
        Me.cmbTenLopHoc.Name = "cmbTenLopHoc"
        Me.cmbTenLopHoc.Size = New System.Drawing.Size(191, 21)
        Me.cmbTenLopHoc.TabIndex = 2
        '
        'rdTatCa
        '
        Me.rdTatCa.AutoSize = True
        Me.rdTatCa.Location = New System.Drawing.Point(308, 34)
        Me.rdTatCa.Name = "rdTatCa"
        Me.rdTatCa.Size = New System.Drawing.Size(56, 17)
        Me.rdTatCa.TabIndex = 1
        Me.rdTatCa.Text = "Tất cả"
        Me.rdTatCa.UseVisualStyleBackColor = True
        '
        'rd12
        '
        Me.rd12.AutoSize = True
        Me.rd12.Location = New System.Drawing.Point(265, 34)
        Me.rd12.Name = "rd12"
        Me.rd12.Size = New System.Drawing.Size(37, 17)
        Me.rd12.TabIndex = 1
        Me.rd12.Text = "12"
        Me.rd12.UseVisualStyleBackColor = True
        '
        'rd11
        '
        Me.rd11.AutoSize = True
        Me.rd11.Location = New System.Drawing.Point(222, 34)
        Me.rd11.Name = "rd11"
        Me.rd11.Size = New System.Drawing.Size(37, 17)
        Me.rd11.TabIndex = 1
        Me.rd11.Text = "11"
        Me.rd11.UseVisualStyleBackColor = True
        '
        'rd10
        '
        Me.rd10.AutoSize = True
        Me.rd10.Location = New System.Drawing.Point(179, 34)
        Me.rd10.Name = "rd10"
        Me.rd10.Size = New System.Drawing.Size(37, 17)
        Me.rd10.TabIndex = 1
        Me.rd10.Text = "10"
        Me.rd10.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(72, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Mã lớp học"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mã"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Khối"
        '
        'gridTKBLH
        '
        Me.gridTKBLH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridTKBLH.Location = New System.Drawing.Point(19, 32)
        Me.gridTKBLH.Name = "gridTKBLH"
        Me.gridTKBLH.Size = New System.Drawing.Size(950, 294)
        Me.gridTKBLH.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gridTKBLH)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 156)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(991, 343)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Thời khóa biểu lớp học"
        '
        'btnXuat
        '
        Me.btnXuat.Location = New System.Drawing.Point(825, 505)
        Me.btnXuat.Name = "btnXuat"
        Me.btnXuat.Size = New System.Drawing.Size(103, 36)
        Me.btnXuat.TabIndex = 4
        Me.btnXuat.Text = "Xuất ra tập tin"
        Me.btnXuat.UseVisualStyleBackColor = True
        '
        'frmTKBLH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnXuat)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmTKBLH"
        Me.Size = New System.Drawing.Size(997, 554)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridTKBLH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdTatCa As System.Windows.Forms.RadioButton
    Friend WithEvents rd12 As System.Windows.Forms.RadioButton
    Friend WithEvents rd11 As System.Windows.Forms.RadioButton
    Friend WithEvents rd10 As System.Windows.Forms.RadioButton
    Friend WithEvents cmbTenLopHoc As System.Windows.Forms.ComboBox
    Friend WithEvents gridTKBLH As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaLopHoc As System.Windows.Forms.TextBox
    Friend WithEvents btnXuat As System.Windows.Forms.Button
End Class
