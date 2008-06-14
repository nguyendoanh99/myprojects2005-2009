Imports system.Data.OleDb
Imports DTO

Public Class KhoiDAO
    Inherits AbstractDAO
    Public Function LayBang() As DataTable
        'Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from Khoi"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        Dim dt As New DataTable

        da.Fill(dt)
        'cn.Close()

        Return dt
    End Function

    Public Function LayDanhSach() As IList
        Dim dt As DataTable = LayBang()
        Dim Kq As New ArrayList

        For Each row As DataRow In dt.Rows
            Dim kh As New KhoiDTO

            kh.MaKhoi = row("MaKhoi")
            kh.TenKhoi = row("TenKhoi")

            Kq.Add(kh)
        Next

        Return Kq
    End Function



End Class