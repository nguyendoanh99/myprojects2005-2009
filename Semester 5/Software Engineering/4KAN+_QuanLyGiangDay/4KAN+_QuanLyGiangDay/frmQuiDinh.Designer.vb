<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuiDinh
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuiDinh))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtSoTietToiDaDuocHocTrongNgay = New System.Windows.Forms.TextBox
        Me.txtTietGay = New System.Windows.Forms.TextBox
        Me.txtSoTietToiDaTrongNgay = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.bDongY = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(503, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Quy định toàn trường"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtSoTietToiDaDuocHocTrongNgay)
        Me.Panel1.Controls.Add(Me.txtTietGay)
        Me.Panel1.Controls.Add(Me.txtSoTietToiDaTrongNgay)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(5, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(498, 122)
        Me.Panel1.TabIndex = 1
        '
        'txtSoTietToiDaDuocHocTrongNgay
        '
        Me.txtSoTietToiDaDuocHocTrongNgay.Location = New System.Drawing.Point(249, 80)
        Me.txtSoTietToiDaDuocHocTrongNgay.Name = "txtSoTietToiDaDuocHocTrongNgay"
        Me.txtSoTietToiDaDuocHocTrongNgay.Size = New System.Drawing.Size(176, 20)
        Me.txtSoTietToiDaDuocHocTrongNgay.TabIndex = 1
        '
        'txtTietGay
        '
        Me.txtTietGay.Location = New System.Drawing.Point(249, 50)
        Me.txtTietGay.Name = "txtTietGay"
        Me.txtTietGay.Size = New System.Drawing.Size(176, 20)
        Me.txtTietGay.TabIndex = 1
        '
        'txtSoTietToiDaTrongNgay
        '
        Me.txtSoTietToiDaTrongNgay.Location = New System.Drawing.Point(249, 20)
        Me.txtSoTietToiDaTrongNgay.Name = "txtSoTietToiDaTrongNgay"
        Me.txtSoTietToiDaTrongNgay.Size = New System.Drawing.Size(176, 20)
        Me.txtSoTietToiDaTrongNgay.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Số tiết tối đa được học trong ngày"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tiết gãy"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Số tiết tối đa trong ngày"
        '
        'bDongY
        '
        Me.bDongY.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.bDongY.Image = CType(resources.GetObject("bDongY.Image"), System.Drawing.Image)
        Me.bDongY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bDongY.Location = New System.Drawing.Point(209, 174)
        Me.bDongY.Name = "bDongY"
        Me.bDongY.Size = New System.Drawing.Size(76, 30)
        Me.bDongY.TabIndex = 6
        Me.bDongY.Text = "Đồng ý"
        Me.bDongY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bDongY.UseVisualStyleBackColor = True
        '
        'frmQuiDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 241)
        Me.Controls.Add(Me.bDongY)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmQuiDinh"
        Me.Text = "frmQuiDinh"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtSoTietToiDaDuocHocTrongNgay As System.Windows.Forms.TextBox
    Friend WithEvents txtTietGay As System.Windows.Forms.TextBox
    Friend WithEvents txtSoTietToiDaTrongNgay As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bDongY As System.Windows.Forms.Button
End Class
