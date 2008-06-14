Imports system.Data.OleDb
Imports DTO

Public Class LichLopHocDAO
    Inherits AbstractDAO
   
    Public Function LayBang() As DataTable
        'Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from LichLopHoc"
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
            Dim lich As New LichLopHocDTO

            lich.MaLichLopHoc = row("MaLichLopHoc")
            lich.MaPhanCong = row("MaPhanCong")
            lich.Thu = row("Thu")
            lich.TietHocBatDau = row("TietHocBatDau")
            lich.SoTietHoc = row("SoTietHoc")
        Next

        Return Kq
    End Function

    Public Function LayDanhSachCoMaPhanCong(ByVal MaPhanCong As String) As IList
        Dim kq As New ArrayList()

        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL = "select * from LichLopHoc where MaPhanCong=?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaPhanCong", OleDbType.WChar)
        cmd.Parameters("@MaPhanCong").Value = MaPhanCong

        Dim rd As OleDbDataReader = cmd.ExecuteReader()
        While rd.Read()
            Dim lichlophoc As New LichLopHocDTO()
            With lichlophoc
                .MaLichLopHoc = rd("MaLichLopHoc").ToString()
                .MaPhanCong = MaPhanCong
                .Thu = Integer.Parse(rd("Thu"))
                .TietHocBatDau = Integer.Parse(rd("TietHocBatDau"))
                .SoTietHoc = Integer.Parse(rd("SoTietHoc"))
            End With
            kq.Add(lichlophoc)
        End While
        rd.Close()
        'cn.Close()

        Return kq
    End Function
    ' Kim
    Public Function LayLichLopHoc(ByVal malophoc As String) As IList
        Dim Kq As New ArrayList
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select L.* from LichLopHoc L, PhanCong P where L.MaPhanCong = P.MaPhanCong and P.MaLopHoc = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaLopHoc", OleDbType.WChar)
        cmd.Parameters("@MaLopHoc").Value = malophoc

        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        cn.Close()

        For Each row As DataRow In dt.Rows
            Dim lich As New LichLopHocDTO

            lich.MaLichLopHoc = row("MaLichLopHoc")
            lich.MaPhanCong = row("MaPhanCong")
            lich.Thu = row("Thu")
            lich.TietHocBatDau = row("TietHocBatDau")
            lich.SoTietHoc = row("SoTietHoc")

            Kq.Add(lich)
        Next

        Return Kq
    End Function

    Public Function LayLichDayGiaoVien(ByVal magiaovien As String) As IList
        Dim Kq As New ArrayList
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select L.* from LichLopHoc L, PhanCong P where L.MaPhanCong = P.MaPhanCong and P.MaGiaoVien = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters("@MaGiaoVien").Value = magiaovien

        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        cn.Close()

        For Each row As DataRow In dt.Rows
            Dim lich As New LichLopHocDTO

            lich.MaLichLopHoc = row("MaLichLopHoc")
            lich.MaPhanCong = row("MaPhanCong")
            lich.Thu = row("Thu")
            lich.TietHocBatDau = row("TietHocBatDau")
            lich.SoTietHoc = row("SoTietHoc")

            Kq.Add(lich)
        Next

        Return Kq
    End Function
End Class