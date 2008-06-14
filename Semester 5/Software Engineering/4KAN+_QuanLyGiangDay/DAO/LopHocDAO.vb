Imports system.Data.OleDb
Imports DTO

Public Class LopHocDAO
    Inherits AbstractDAO
 
    Public Function LayBang() As DataTable
        'Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from LopHoc"
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
            Dim lop As New LopHocDTO

            lop.MaLopHoc = row("MaLopHoc")
            lop.TenLopHoc = row("TenLopHoc")
            lop.MaKhoi = row("MaKhoi")

            Kq.Add(lop)
        Next

        Return Kq
    End Function

    Public Function LayDanhSachMaLop() As IList
        Dim dt As DataTable = LayBang()
        Dim Kq As New ArrayList

        For Each row As DataRow In dt.Rows
            Kq.Add(row.Item("MaLopHoc"))
        Next

        Return Kq
    End Function

    Public Function LayMaLopCoTen(ByVal tenlop As String) As IList
        Dim Kq As New ArrayList
        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL As String = "select MaLopHoc from LopHoc where TenLopHoc = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@tenlophoc", OleDbType.WChar)
        cmd.Parameters("@tenlophoc").Value = tenlop

        Dim rd As OleDbDataReader = cmd.ExecuteReader()

        While rd.Read()
            If Not IsDBNull(rd.GetString(0)) Then
                Kq.Add(rd.GetString(0))
            End If
        End While
        rd.Close()
        'cn.Close()
        Return Kq
    End Function

    Public Function LayDanhSachCoMaKhoi(ByVal MaKhoi As String) As IList
        Dim Kq As New ArrayList
        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL As String = "select * from LopHoc where MaKhoi = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaKhoi", OleDbType.WChar)
        cmd.Parameters("@MaKhoi").Value = MaKhoi

        Dim rd As OleDbDataReader = cmd.ExecuteReader()

        While rd.Read()
            Dim lop As New LopHocDTO()
            lop.MaKhoi = MaKhoi
            lop.MaLopHoc = rd("MaLopHoc").ToString()
            lop.TenLopHoc = rd("TenLopHoc").ToString()

            Kq.Add(lop)
        End While
        rd.Close()
        'cn.Close()
        Return Kq
    End Function
    ' Be A
    Public Function LayDanhSachTheoKhoi(ByVal _maKhoi As String) As DataTable
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim _kq As New DataTable()

        Dim strSQL = "select * from LopHoc"
        strSQL += " where MaKhoi = '" + _maKhoi + "'"
        Dim da As New OleDbDataAdapter(strSQL, cn)

        da.Fill(_kq)
        cn.Close()

        Return _kq
    End Function
    'Kien 
    Public Sub Them(ByVal lophoc As LopHocDTO)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Me.KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Insert into LopHoc(MaLopHoc, TenLopHoc, MaKhoi) values (?, ?, ?)"

        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaLopHoc", OleDbType.WChar)
        cmd.Parameters.Add("@TenLopHoc", OleDbType.WChar)
        cmd.Parameters.Add("@MaKhoi", OleDbType.WChar)


        cmd.Parameters("@MaLopHoc").Value = lophoc.MaLopHoc()
        cmd.Parameters("@TenLopHoc").Value = lophoc.TenLopHoc
        cmd.Parameters("@MaKhoi").Value = lophoc.MaKhoi

        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub
    Public Sub Sua(ByVal lophoc As LopHocDTO)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Me.KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = _
            "Update LopHoc Set TenLopHoc = ? Where MaLopHoc = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)


        cmd.Parameters.Add("@TenLopHoc", OleDbType.WChar)
        cmd.Parameters.Add("@MaLopHoc", OleDbType.WChar)

        cmd.Parameters("@TenLopHoc").Value = lophoc.TenLopHoc()
        cmd.Parameters("@MaLopHoc").Value = lophoc.MaLopHoc()

        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub
    Public Sub Xoa(ByVal malophoc As String)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Me.KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Delete From LopHoc Where MaLopHoc = ? "
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaLopHoc", OleDbType.WChar)

        cmd.Parameters("@MaLopHoc").Value = malophoc

        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub
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
    Public Function LayDanhSachLopKhoi10() As IList
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from LopHoc where MaKhoi = 'K10'"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        Dim dt As New DataTable

        da.Fill(dt)
        cn.Close()

        Dim Kq As New ArrayList


        For Each row As DataRow In dt.Rows
            Dim lop As New LopHocDTO

            lop.MaLopHoc = row("MaLopHoc")
            lop.TenLopHoc = row("TenLopHoc")
            lop.MaKhoi = row("MaKhoi")

            Kq.Add(lop)
        Next

        Return Kq
    End Function

    Public Function LayDanhSachLopKhoi11() As IList
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from LopHoc where MaKhoi = 'K11'"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        Dim dt As New DataTable

        da.Fill(dt)
        cn.Close()

        Dim Kq As New ArrayList


        For Each row As DataRow In dt.Rows
            Dim lop As New LopHocDTO

            lop.MaLopHoc = row("MaLopHoc")
            lop.TenLopHoc = row("TenLopHoc")
            lop.MaKhoi = row("MaKhoi")

            Kq.Add(lop)
        Next

        Return Kq
    End Function

    Public Function LayDanhSachLopKhoi12() As IList
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from LopHoc where MaKhoi = 'K12'"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        Dim dt As New DataTable

        da.Fill(dt)
        cn.Close()

        Dim Kq As New ArrayList


        For Each row As DataRow In dt.Rows
            Dim lop As New LopHocDTO

            lop.MaLopHoc = row("MaLopHoc")
            lop.TenLopHoc = row("TenLopHoc")
            lop.MaKhoi = row("MaKhoi")

            Kq.Add(lop)
        Next

        Return Kq
    End Function
End Class
