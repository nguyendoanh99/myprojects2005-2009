<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTKBToanTruong
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
        Me.gbKhoi = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvTKB = New System.Windows.Forms.DataGridView
        Me.btnXuat = New System.Windows.Forms.Button
        Me.gbKhoi.SuspendLayout()
        CType(Me.dgvTKB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbKhoi
        '
        Me.gbKhoi.Controls.Add(Me.Label1)
        Me.gbKhoi.Location = New System.Drawing.Point(676, 8)
        Me.gbKhoi.Name = "gbKhoi"
        Me.gbKhoi.Size = New System.Drawing.Size(309, 36)
        Me.gbKhoi.TabIndex = 0
        Me.gbKhoi.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Khối:"
        '
        'dgvTKB
        '
        Me.dgvTKB.AllowUserToAddRows = False
        Me.dgvTKB.AllowUserToDeleteRows = False
        Me.dgvTKB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTKB.Location = New System.Drawing.Point(2, 61)
        Me.dgvTKB.Name = "dgvTKB"
        Me.dgvTKB.Size = New System.Drawing.Size(992, 400)
        Me.dgvTKB.TabIndex = 1
        '
        'btnXuat
        '
        Me.btnXuat.Location = New System.Drawing.Point(813, 475)
        Me.btnXuat.Name = "btnXuat"
        Me.btnXuat.Size = New System.Drawing.Size(103, 36)
        Me.btnXuat.TabIndex = 5
        Me.btnXuat.Text = "Xuất ra tập tin"
        Me.btnXuat.UseVisualStyleBackColor = True
        '
        'frmTKBToanTruong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnXuat)
        Me.Controls.Add(Me.dgvTKB)
        Me.Controls.Add(Me.gbKhoi)
        Me.Name = "frmTKBToanTruong"
        Me.Size = New System.Drawing.Size(997, 523)
        Me.gbKhoi.ResumeLayout(False)
        Me.gbKhoi.PerformLayout()
        CType(Me.dgvTKB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbKhoi As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvTKB As System.Windows.Forms.DataGridView
    Friend WithEvents btnXuat As System.Windows.Forms.Button
End Class
