Imports System.Data.OleDb
Imports DTO

Public Class PhanCongDAO
    Inherits AbstractDAO

    Public Function LayBang() As DataTable
        'Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from PhanCong"
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
            Dim pc As New PhanCongDTO
            pc.MaPhanCong = row("MaPhanCong")
            pc.MaLopHoc = row("MaLopHoc")
            pc.MaMonHoc = row("MaMonHoc")
            pc.MaGiaoVien = row("MaGiaoVien")
            pc.SoTietHocTuan = row("SoTietHocTuan")
            pc.SoTietHocLienTiepToiThieu = row("SoTietHocLienTiepToiThieu")
            pc.SoTietHocLienTiepToiDa = row("SoTietHocLienTiepToiDa")
            pc.SoBuoiHocToiThieu = row("SoBuoiHocToiThieu")
            pc.SoBuoiHocToiDa = row("SoBuoiHocToiDa")

            Kq.Add(pc)
        Next

        Return Kq
    End Function

   
    Public Function LayDanhSachLopHocCoHocMonHoc(ByVal mytable As DataTable, _
                                            ByVal mamonhoc As String) As ArrayList
        Dim Kq As New ArrayList

        Dim strSQL As String = "MaMonHoc = '" + mamonhoc + "'"
        Dim row() As DataRow = mytable.Select(strSQL)

        For i As Integer = 0 To row.Length - 1
            Kq.Add(row(i).Item("MaLopHoc"))
        Next

        Return Kq
    End Function

    
    Public Function LayBangTheoMaMonHoc(ByVal mamonhoc As String) As DataTable
        Dim Kq As New DataTable
        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL As String = "select pc.MaPhanCong as MaPhanCong, pc.MaLopHoc as MaLopHoc, pc.MaMonHoc as MaMonHoc, pc.MaGiaoVien as MaGiaoVien,"
        strSQL += " lh.TenLopHoc, mh.TenMonHoc, gv.HoTenGiaoVien, pc.SoTietHocTuan, "
        strSQL += " pc.SoTietHocLienTiepToiThieu, pc.SoTietHocLienTiepToiDa, pc.SoBuoiHocToiThieu, pc.SoBuoiHocToiDa"
        strSQL += " from PhanCong pc, MonHoc mh, LopHoc lh, GiaoVien gv"
        strSQL += " where pc.MaMonHoc = ?"
        strSQL += " and pc.MaMonHoc = mh.MaMonHoc"
        strSQL += " and pc.MaLopHoc = lh.MaLopHoc"
        strSQL += " and pc.MaGiaoVien = gv.MaGiaoVien"

        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.SelectCommand = New OleDbCommand(strSQL, cn)
        da.SelectCommand.Parameters.Add("@mamonhoc", OleDbType.WChar)
        da.SelectCommand.Parameters("@mamonhoc").Value = mamonhoc

        da.Fill(Kq)
        'cn.Close()
        Return Kq
    End Function

    Public Function LayBangTheoMaGiaoVien(ByVal magiaovien As String) As DataTable
        Dim Kq As New DataTable
        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL As String = "select pc.MaPhanCong as MaPhanCong, pc.MaLopHoc as MaLopHoc, pc.MaMonHoc as MaMonHoc, pc.MaGiaoVien as MaGiaoVien,"
        strSQL += " lh.TenLopHoc, mh.TenMonHoc, gv.HoTenGiaoVien, pc.SoTietHocTuan, "
        strSQL += " pc.SoTietHocLienTiepToiThieu, pc.SoTietHocLienTiepToiDa, pc.SoBuoiHocToiThieu, pc.SoBuoiHocToiDa"
        strSQL += " from PhanCong pc, MonHoc mh, LopHoc lh, GiaoVien gv"
        strSQL += " where pc.MaGiaoVien = ?"
        strSQL += " and pc.MaMonHoc = mh.MaMonHoc"
        strSQL += " and pc.MaLopHoc = lh.MaLopHoc"
        strSQL += " and pc.MaGiaoVien = gv.MaGiaoVien"

        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.SelectCommand = New OleDbCommand(strSQL, cn)
        da.SelectCommand.Parameters.Add("@magiaovien", OleDbType.WChar)
        da.SelectCommand.Parameters("@magiaovien").Value = magiaovien
        da.Fill(Kq)

        'cn.Close()
        Return Kq
    End Function

    Public Function LayDanhSachGiaoVienCoDayMonHoc(ByVal mamonhoc As String) As DataTable
        Dim Kq As New DataTable
        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL = "select pc.MaGiaoVien as MaGiaoVien, gv.HoTenGiaoVien as HoTenGiaoVien"
        strSQL += " from PhanCong pc, GiaoVien gv"
        strSQL += " where pc.MaGiaoVien = gv.MaGiaoVien"
        strSQL += " and pc.MaMonHoc = ?"

        Dim da As New OleDbDataAdapter
        da.SelectCommand = New OleDbCommand(strSQL, cn)
        da.SelectCommand.Parameters.Add("@mamonhoc", OleDbType.WChar)
        da.SelectCommand.Parameters("@mamonhoc").Value = mamonhoc

        da.Fill(Kq)
        'cn.Close()
        Return Kq
    End Function

    Public Function LayDanhSachLopHocMaGiaoVienDay(ByVal magiaovien As String) As ArrayList
        Dim Kq As New ArrayList

        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL = "select lh.TenLopHoc"
        strSQL += " from PhanCong pc, LopHoc lh"
        strSQL += " where pc.MaLopHoc = lh.MaLopHoc"
        strSQL += " and pc.MaGiaoVien = ?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@magiaovien", OleDbType.WChar)
        cmd.Parameters("@magiaovien").Value = magiaovien

        Dim rd As OleDbDataReader = cmd.ExecuteReader()
        While rd.Read()
            Kq.Add(rd.GetString(0))
        End While
        rd.Close()
        'cn.Close()
        Return Kq
    End Function

    Public Function LayDanhSachCoMaLopHoc(ByVal MaLopHoc As String) As IList
        Dim kq As New ArrayList()

        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL = "select * from PhanCong where MaLopHoc=?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaLopHoc", OleDbType.WChar)
        cmd.Parameters("@MaLopHoc").Value = MaLopHoc

        Dim rd As OleDbDataReader = cmd.ExecuteReader()
        While rd.Read()
            Dim phancong As New PhanCongDTO()
            With phancong
                .MaPhanCong = rd("MaPhanCong").ToString()
                .MaLopHoc = MaLopHoc
                .MaMonHoc = rd("MaMonHoc").ToString()
                .MaGiaoVien = rd("MaGiaoVien").ToString()
                .SoTietHocTuan = Integer.Parse(rd("SoTietHocTuan"))
                .SoTietHocLienTiepToiThieu = Integer.Parse(rd("SoTietHocLienTiepToiThieu"))
                .SoTietHocLienTiepToiDa = Integer.Parse(rd("SoTietHocLienTiepToiDa"))
                .SoBuoiHocToiThieu = Integer.Parse(rd("SoBuoiHocToiThieu"))
                .SoBuoiHocToiDa = Integer.Parse(rd("SoBuoiHocToiDa"))
            End With
            kq.Add(phancong)
        End While
        rd.Close()

        'cn.Close()

        Return kq
    End Function

    Public Function LayPhanCongCoMa(ByVal MaPhanCong As String) As PhanCongDTO
        Dim kq As New PhanCongDTO

        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL = "select * from PhanCong where MaPhanCong=?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaPhanCong", OleDbType.WChar)
        cmd.Parameters("@MaPhanCong").Value = MaPhanCong

        Dim rd As OleDbDataReader = cmd.ExecuteReader()
        While rd.Read()

            With kq
                .MaPhanCong = MaPhanCong
                .MaLopHoc = rd("MaLopHoc").ToString()
                .MaMonHoc = rd("MaMonHoc").ToString()
                .MaGiaoVien = rd("MaGiaoVien").ToString()
                .SoTietHocTuan = Integer.Parse(rd("SoTietHocTuan"))
                .SoTietHocLienTiepToiThieu = Integer.Parse(rd("SoTietHocLienTiepToiThieu"))
                .SoTietHocLienTiepToiDa = Integer.Parse(rd("SoTietHocLienTiepToiDa"))
                .SoBuoiHocToiThieu = Integer.Parse(rd("SoBuoiHocToiThieu"))
                .SoBuoiHocToiDa = Integer.Parse(rd("SoBuoiHocToiDa"))
            End With

        End While
        rd.Close()

        'cn.Close()

        Return kq
    End Function
    ' Be A
    Public Function LayBangTheoLopHoc(ByVal _maLopHoc As String) As DataTable
        Dim Kq As New DataTable
        Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL As String = "select pc.MaPhanCong as MaPhanCong, pc.MaLopHoc as MaLopHoc, pc.MaMonHoc as MaMonHoc, pc.MaGiaoVien as MaGiaoVien,"
        strSQL += " lh.TenLopHoc, mh.TenMonHoc, gv.HoTenGiaoVien, pc.SoTietHocTuan, "
        strSQL += " pc.SoTietHocLienTiepToiThieu, pc.SoTietHocLienTiepToiDa, pc.SoBuoiHocToiThieu, pc.SoBuoiHocToiDa"
        strSQL += " from PhanCong pc, MonHoc mh, LopHoc lh, GiaoVien gv"
        strSQL += " where pc.MaLopHoc = ?"
        strSQL += " and pc.MaMonHoc = mh.MaMonHoc"
        strSQL += " and pc.MaLopHoc = lh.MaLopHoc"
        strSQL += " and pc.MaGiaoVien = gv.MaGiaoVien"

        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.SelectCommand = New OleDbCommand(strSQL, cn)
        da.SelectCommand.Parameters.Add("@malophoc", OleDbType.WChar)
        da.SelectCommand.Parameters("@malophoc").Value = _maLopHoc

        da.Fill(Kq)
        cn.Close()
        Return Kq
    End Function

    Public Function LayBangTheoLopHocVaGiaoVien(ByVal _maLopHoc As String, ByVal _maGiaoVien As String) As DataTable
        Dim Kq As New DataTable
        Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL As String = "select pc.MaPhanCong as MaPhanCong, pc.MaLopHoc as MaLopHoc, pc.MaMonHoc as MaMonHoc, pc.MaGiaoVien as MaGiaoVien,"
        strSQL += " lh.TenLopHoc, mh.TenMonHoc, gv.HoTenGiaoVien, pc.SoTietHocTuan, "
        strSQL += " pc.SoTietHocLienTiepToiThieu, pc.SoTietHocLienTiepToiDa, pc.SoBuoiHocToiThieu, pc.SoBuoiHocToiDa"
        strSQL += " from PhanCong pc, MonHoc mh, LopHoc lh, GiaoVien gv"
        strSQL += " where pc.MaLopHoc = ?"
        strSQL += " and pc.maGiaoVien = ?"
        strSQL += " and pc.MaMonHoc = mh.MaMonHoc"
        strSQL += " and pc.MaLopHoc = lh.MaLopHoc"
        strSQL += " and pc.MaGiaoVien = gv.MaGiaoVien"

        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.SelectCommand = New OleDbCommand(strSQL, cn)
        da.SelectCommand.Parameters.Add("@malophoc", OleDbType.WChar)
        da.SelectCommand.Parameters.Add("@magiaovien", OleDbType.WChar)
        da.SelectCommand.Parameters("@malophoc").Value = _maLopHoc
        da.SelectCommand.Parameters("@magiaovien").Value = _maGiaoVien

        da.Fill(Kq)
        cn.Close()
        Return Kq
    End Function
    'Kim
    Public Function LayDanhSachTheoMaLopHoc(ByVal malophoc As String) As IList
        Dim Kq As New ArrayList()
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from PhanCong where MaLopHoc = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaLopHoc", OleDbType.WChar)
        cmd.Parameters("@MaLopHoc").Value = malophoc
        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        cn.Close()

        For Each row As DataRow In dt.Rows
            Dim pc As New PhanCongDTO
            pc.MaPhanCong = row("MaPhanCong")
            pc.MaLopHoc = row("MaLopHoc")
            pc.MaMonHoc = row("MaMonHoc")
            pc.MaGiaoVien = row("MaGiaoVien")
            pc.SoTietHocTuan = row("SoTietHocTuan")
            pc.SoTietHocLienTiepToiThieu = row("SoTietHocLienTiepToiThieu")
            pc.SoTietHocLienTiepToiDa = row("SoTietHocLienTiepToiDa")
            pc.SoBuoiHocToiThieu = row("SoBuoiHocToiThieu")
            pc.SoBuoiHocToiDa = row("SoBuoiHocToiDa")

            Kq.Add(pc)
        Next


        Return Kq
    End Function


    Public Function LayDanhSachTheoMaGiaoVien(ByVal magiaovien As String) As IList
        Dim Kq As New ArrayList()
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from PhanCong where MaGiaoVien = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters("@MaGiaoVien").Value = magiaovien
        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        cn.Close()

        For Each row As DataRow In dt.Rows
            Dim pc As New PhanCongDTO
            pc.MaPhanCong = row("MaPhanCong")
            pc.MaLopHoc = row("MaLopHoc")
            pc.MaMonHoc = row("MaMonHoc")
            pc.MaGiaoVien = row("MaGiaoVien")
            pc.SoTietHocTuan = row("SoTietHocTuan")
            pc.SoTietHocLienTiepToiThieu = row("SoTietHocLienTiepToiThieu")
            pc.SoTietHocLienTiepToiDa = row("SoTietHocLienTiepToiDa")
            pc.SoBuoiHocToiThieu = row("SoBuoiHocToiThieu")
            pc.SoBuoiHocToiDa = row("SoBuoiHocToiDa")

            Kq.Add(pc)
        Next


        Return Kq
    End Function

    Public Function LayDanhSachChiTietMonHocCuaLop(ByVal malophoc As String) As DataTable
        Dim Kq As New DataTable()

        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select P.MaPhanCong, P.MaMonHoc, M.TenMonHoc, P.MaGiaoVien, G.TenTat, P.SoTietHocTuan, P.SoTietHocLienTiepToiThieu, P.SoTietHocLienTiepToiDa, P.SoBuoiHocToiThieu, P.SoBuoiHocToiDa"
        strSQL += " from PhanCong P, MonHoc M, GiaoVien G"
        strSQL += " where P.MaMonHoc = M.MaMonHoc and P.MaGiaoVien = G.MaGiaoVien and P.MaLopHoc = ?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaLopHoc", OleDbType.WChar)
        cmd.Parameters("@MaLopHoc").Value = malophoc
        Dim da As New OleDbDataAdapter(cmd)
        'Dim da As New OleDbDataAdapter(strSQL, cn)
        'Dim dt As New DataTable

        da.Fill(Kq)

        cn.Close()
        Return Kq
    End Function
    ' Khuong
    Public Sub CapNhatDong(ByVal phancong As PhanCongDTO)
        Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL = "update PhanCong"

        strSQL += " set MaLopHoc = ?"
        strSQL += " , MaMonHoc = ?"
        strSQL += " , MaGiaoVien = ?"

        strSQL += " , SoTietHocTuan = ?"
        strSQL += " , SoTietHocLienTiepToiThieu = ?"
        strSQL += " , SoTietHocLienTiepToiDa = ?"
        strSQL += " , SoBuoiHocToiThieu = ?"
        strSQL += " , SoBuoiHocToiDa = ?"
        strSQL += " where MaPhanCong = ?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@malophoc", OleDbType.WChar)
        cmd.Parameters.Add("@mamonhoc", OleDbType.WChar)
        cmd.Parameters.Add("@magiaovien", OleDbType.WChar)
        cmd.Parameters.Add("@sotiethoctuan", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@sotiethoclientieptoithieu", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@sotiethoclientieptoida", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@sobuoihoctoithieu", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@sobuoihoctoida", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@maphancong", OleDbType.WChar)

        cmd.Parameters("@malophoc").Value = phancong.MaLopHoc
        cmd.Parameters("@mamonhoc").Value = phancong.MaMonHoc
        cmd.Parameters("@magiaovien").Value = phancong.MaGiaoVien
        cmd.Parameters("@sotiethoctuan").Value = phancong.SoTietHocTuan
        cmd.Parameters("@sotiethoclientieptoithieu").Value = phancong.SoTietHocLienTiepToiThieu
        cmd.Parameters("@sotiethoclientieptoida").Value = phancong.SoTietHocLienTiepToiDa
        cmd.Parameters("@sobuoihoctoithieu").Value = phancong.SoBuoiHocToiThieu
        cmd.Parameters("@sobuoihoctoida").Value = phancong.SoBuoiHocToiDa
        cmd.Parameters("@maphancong").Value = phancong.MaPhanCong

        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub ThemDong(ByVal phancong As PhanCongDTO)
        Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL = "insert into PhanCong(MaPhanCong, MaLopHoc, MaMonHoc, MaGiaoVien, SoTietHocTuan, SoTietHocLienTiepToiThieu, SoTietHocLienTiepToiDa, SoBuoiHocToiThieu, SoBuoiHocToiDa)"
        strSQL += " values(?, ?, ?, ?, ?, ?, ?, ?, ?)"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@maphancong", OleDbType.WChar)
        cmd.Parameters.Add("@malophoc", OleDbType.WChar)
        cmd.Parameters.Add("@mamonhoc", OleDbType.WChar)
        cmd.Parameters.Add("@magiaovien", OleDbType.WChar)
        cmd.Parameters.Add("@sotiethoctuan", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@sotiethoclientieptoithieu", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@sotiethoclientieptoida", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@sobuoihoctoithieu", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@sobuoihoctoida", OleDbType.UnsignedTinyInt)

        cmd.Parameters("@maphancong").Value = phancong.MaPhanCong
        cmd.Parameters("@malophoc").Value = phancong.MaLopHoc
        cmd.Parameters("@mamonhoc").Value = phancong.MaMonHoc
        cmd.Parameters("@magiaovien").Value = phancong.MaGiaoVien
        cmd.Parameters("@sotiethoctuan").Value = phancong.SoTietHocTuan
        cmd.Parameters("@sotiethoclientieptoithieu").Value = phancong.SoTietHocLienTiepToiThieu
        cmd.Parameters("@sotiethoclientieptoida").Value = phancong.SoTietHocLienTiepToiDa
        cmd.Parameters("@sobuoihoctoithieu").Value = phancong.SoBuoiHocToiThieu
        cmd.Parameters("@sobuoihoctoida").Value = phancong.SoBuoiHocToiDa

        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub XoaDong(ByVal maphancong As String)
        Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL As String = "delete from PhanCong where MaPhanCong = ?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@maphancong", OleDbType.WChar)
        cmd.Parameters("@maphancong").Value = maphancong

        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub XoaGiaoVien(ByVal maGV As String)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Delete From PhanCong Where MaGiaoVien = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)

        cmd.Parameters("@MaGiaoVien").Value = maGV

        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub
End Class
