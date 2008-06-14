Imports system.Data.OleDb
Imports DTO

Public Class ThamSoDAO
    Inherits AbstractDAO

    Public Function LayBang() As DataTable
        'Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from ThamSo"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        Dim dt As New DataTable

        da.Fill(dt)
        'cn.Close()

        Return dt
    End Function

    Public Function LayThamSo() As ThamSoDTO
        Dim dt As DataTable = LayBang()

        Dim ts As New ThamSoDTO
        ts.SoTietToiDaTrongNgay = dt.Rows(0).Item("SoTietToiDaTrongNgay")
        ts.TietGay = dt.Rows(0).Item("TietGay")
        ts.SoTietToiDaDuocHocTrongNgay = dt.Rows(0).Item("SoTietToiDaDuocHocTrongNgay")

        Return ts
    End Function
    ' Be N
    Public Sub CapNhat(ByVal thamso As ThamSoDTO)
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "update ThamSo set SoTietToiDaTrongNgay = ?"
        strSQL += ", TietGay = ?, SoTietToiDaDuocHocTrongNgay = ?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@sotiettoidatrongngay", OleDbType.TinyInt)
        cmd.Parameters.Add("@tietgay", OleDbType.TinyInt)
        cmd.Parameters.Add("@sotiettoidaduochoctrongngay", OleDbType.TinyInt)

        cmd.Parameters("@sotiettoidatrongngay").Value = thamso.SoTietToiDaTrongNgay
        cmd.Parameters("@tietgay").Value = thamso.TietGay
        cmd.Parameters("@sotiettoidaduochoctrongngay").Value = thamso.SoTietToiDaDuocHocTrongNgay

        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
End Class
