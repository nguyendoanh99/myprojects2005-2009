Imports BUS
Imports DTO

Public Class frmQuiDinh

    Private Sub frmQuiDinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim thamso As ThamSoDTO = (New ThamSoBUS).LayThamSo()

        txtSoTietToiDaTrongNgay.Text = thamso.SoTietToiDaTrongNgay
        txtTietGay.Text = thamso.TietGay
        txtSoTietToiDaDuocHocTrongNgay.Text = thamso.SoTietToiDaDuocHocTrongNgay

    End Sub

    Private Sub bDongY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bDongY.Click
        Dim sotiettoida As Byte = 0
        Dim tietgay As Byte = 0
        Dim sotiettoidaduochoc As Byte = 0
        Dim thongbao As String = ""

        If Not Byte.TryParse(txtSoTietToiDaTrongNgay.Text, sotiettoida) Then

            thongbao += "Sôì tiêìt tôìi ða trong ngaÌy phaÒi laÌ sôì nguyên dýõng týÌ 0 ðêìn 20"
        Else
            If sotiettoida > 20 Then
                thongbao += "Sôì tiêìt tôìi ða trong ngaÌy phaÒi laÌ sôì nguyên dýõng týÌ 0 ðêìn 20"
            End If
        End If

        If Not Byte.TryParse(txtTietGay.Text, tietgay) Then
            thongbao += vbCrLf + "Tiêìt gaÞy phaÒi laÌ sôì nguyên dýõng týÌ 0 ðêìn 20"
        Else
            If tietgay > 20 Then
                thongbao += vbCrLf + "Tiêìt gaÞy phaÒi laÌ sôì nguyên dýõng týÌ 0 ðêìn 20"
            End If
        End If

        If Not Byte.TryParse(txtSoTietToiDaDuocHocTrongNgay.Text, sotiettoidaduochoc) Then
            thongbao += vbCrLf + "Sôì tiêìt tôìi ða ðýõòc hoòc trong ngaÌy phaÒi laÌ sôì nguyên dýõng týÌ 0 ðêìn 20"
        Else
            If sotiettoidaduochoc > 20 Then
                thongbao += vbCrLf + "Sôì tiêìt tôìi ða ðýõòc hoòc trong ngaÌy phaÒi laÌ sôì nguyên dýõng týÌ 0 ðêìn 20"
            End If
        End If

        If thongbao = "" Then
            Dim thamso As New ThamSoDTO
            thamso.SoTietToiDaTrongNgay = sotiettoida
            thamso.TietGay = tietgay
            thamso.SoTietToiDaDuocHocTrongNgay = sotiettoidaduochoc

            Dim thamsobus As New ThamSoBUS
            thamsobus.CapNhat(thamso)
            Me.Close()
        Else
            MessageBox.Show(thongbao)
        End If
    End Sub
End Class