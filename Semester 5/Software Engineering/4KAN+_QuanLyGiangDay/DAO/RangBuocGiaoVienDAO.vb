Imports system.Data.OleDb
Imports DTO

Public Class RangBuocGiaoVienDAO
    Inherits AbstractDAO

    Public Function LayBang() As DataTable
        'Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from RangBuocGiaoVien"
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
            Dim rbgv As New RangBuocGiaoVienDTO

            rbgv.MaRangBuocGiaovien = row("MaRangBuocGiaovien")
            rbgv.MaGiaoVien = row("MaGiaoVien")
            rbgv.Thu = row("Thu")
            rbgv.TietHoc = row("TietHoc")
            rbgv.TrangThai = row("TrangThai")

            Kq.Add(rbgv)
        Next

        Return Kq
    End Function
    ' Kim
    Public Function LayDanhSachTheoMaGiaoVien(ByVal magiaovien As String) As IList
        Dim Kq As New ArrayList()
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from RangBuocGiaoVien where MaGiaoVien = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters("@MaGiaoVien").Value = magiaovien

        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)


        For Each row As DataRow In dt.Rows
            Dim rbgv As New RangBuocGiaoVienDTO

            rbgv.MaRangBuocGiaovien = row("MaRangBuocGiaovien")
            rbgv.MaGiaoVien = row("MaGiaoVien")
            rbgv.Thu = row("Thu")
            rbgv.TietHoc = row("TietHoc")
            rbgv.TrangThai = row("TrangThai")

            Kq.Add(rbgv)
        Next

        cn.Close()
        Return Kq

    End Function

    ' Khuong 

    Public Function LayDanhSachRBGV(ByVal maGiaoVien As String) As IList

        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim Kq As New ArrayList
        Dim rbGVDao As New RangBuocGiaoVienDAO

        Dim strSQL = "select * from RangBuocGiaoVien where MaGiaoVien = ?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters("@MaGiaoVien").Value = maGiaoVien

        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()

        While (dr.Read())
            Dim rbGVDto As New RangBuocGiaoVienDTO
            rbGVDto.MaRangBuocGiaovien = dr("MaRangBuocGiaoVien")
            rbGVDto.MaGiaoVien = dr("MaGiaoVien")
            rbGVDto.Thu = dr("Thu")
            rbGVDto.TietHoc = dr("TietHoc")
            rbGVDto.TrangThai = dr("TrangThai")
            Kq.Add(rbGVDto)
        End While

        'Dong ket noi csdl
        dr.Close()
        cn.Close()

        Return Kq
    End Function

    Public Sub Them(ByVal rbgvDto As RangBuocGiaoVienDTO)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Insert into RangBuocGiaoVien(MaRangBuocGiaoVien, MaGiaoVien, Thu, TietHoc, TrangThai) values (?, ?, ?, ?, ?)"

        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaRangBuocGiaoVien", OleDbType.WChar)
        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters.Add("@Thu", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@TietHoc", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@TrangThai", OleDbType.UnsignedTinyInt)

        cmd.Parameters("@MaRangBuocGiaoVien").Value = rbgvDto.MaRangBuocGiaovien
        cmd.Parameters("@MaGiaoVien").Value = rbgvDto.MaGiaoVien
        cmd.Parameters("@Thu").Value = rbgvDto.Thu
        cmd.Parameters("@TietHoc").Value = rbgvDto.TietHoc
        cmd.Parameters("@TrangThai").Value = rbgvDto.TrangThai

        cmd.ExecuteNonQuery()

        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Sub Sua(ByVal rbgvDto As RangBuocGiaoVienDTO)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = _
        "Update RangBuocGiaoVien Set TrangThai = ? where MaGiaoVien = ? and Thu = ? and TietHoc = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@TrangThai", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters.Add("@Thu", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@TietHoc", OleDbType.UnsignedTinyInt)

        cmd.Parameters("@TrangThai").Value = rbgvDto.TrangThai
        cmd.Parameters("@MaGiaoVien").Value = rbgvDto.MaGiaoVien
        cmd.Parameters("@Thu").Value = rbgvDto.Thu
        cmd.Parameters("@TietHoc").Value = rbgvDto.TietHoc
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try

        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Sub XoaGiaoVien(ByVal maGV As String)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Delete From RangBuocGiaoVien Where MaGiaoVien = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)

        cmd.Parameters("@MaGiaoVien").Value = maGV

        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

End Class
