
Public Class frmChinh


    Private Sub bQuyDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bQuyDinh.Click
        Dim frm As New frmQuiDinh
        frm.ShowDialog()

    End Sub

    Private Sub bLopHoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLopHoc.Click

    End Sub

    Private Sub frmChinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        panelLopHoc.Controls.Add(New frmThongTinLopHoc)
        panelTKBLH.Controls.Add(New frmTKBLH)
        panelLichDayGiaoVien.Controls.Add(New frmTKBGV)
        panelGiaoVien.Controls.Add(New frmThongTinGiaoVien)
        panelPCTheoBoMon.Controls.Add(New frmPCTheoBoMon)
        panelPCTheoLopHoc.Controls.Add(New frmPCTheoLopHoc)
        panelMonHoc.Controls.Add(New frmThongTinMonHoc)
        panelTKBToanTruong.Controls.Add(New frmTKBToanTruong)
    End Sub


    Private Sub RadioLop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioLop.CheckedChanged
        Dim ra As RadioButton = sender
        If ra.Checked = True Then
            panelPCTheoLopHoc.Visible = True
            panelPCTheoBoMon.Visible = False
        End If
    End Sub

    Private Sub RadioMon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioMon.CheckedChanged
        Dim ra As RadioButton = sender
        If ra.Checked = True Then
            panelPCTheoLopHoc.Visible = False
            panelPCTheoBoMon.Visible = True
        End If
    End Sub
End Class