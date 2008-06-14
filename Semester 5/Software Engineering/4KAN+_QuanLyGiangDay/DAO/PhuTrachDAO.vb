Imports system.Data.OleDb
Imports DTO

Public Class PhuTrachDAO
    Inherits AbstractDAO

    Public Function LayBang() As DataTable
        'Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from PhuTrach"
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
            Dim pt As New PhuTrachDTO

            pt.MaPhuTrach = row("MaPhuTrach")
            pt.MaGiaoVien = row("MaGiaoVien")
            pt.MaMonHoc = row("MaMonHoc")

            Kq.Add(pt)
        Next

        Return Kq
    End Function

    Public Function LayMonHocGiaoVienPhuTrach(ByVal magiaovien As String) As IList
        Dim Kq As New ArrayList

        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from PhuTrach where MaGiaoVien = ?"

        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.SelectCommand = New OleDbCommand(strSQL, cn)
        da.SelectCommand.Parameters.Add("@magiaovien", OleDbType.WChar)
        da.SelectCommand.Parameters("@magiaovien").Value = magiaovien

        Dim dt As New DataTable
        da.Fill(dt)

        For Each row As DataRow In dt.Rows
            Kq.Add(row("MaMonHoc"))
        Next

        cn.Close()
        Return Kq

    End Function
    ' Khuong
    Public Function LayDanhSachMonHoc(ByVal maGiaoVien As String) As IList

        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim Kq As New ArrayList
        Dim monhocDto As New MonHocDTO
        Dim monhocDao As New MonHocDAO

        Dim strSQL = "select * from PhuTrach where MaGiaoVien = ?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters("@MaGiaoVien").Value = maGiaoVien

        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()

        While (dr.Read())
            monhocDto = monhocDao.Tim(dr("MaMonHoc"))
            Kq.Add(monhocDto)
        End While

        'Dong ket noi csdl
        dr.Close()
        cn.Close()

        Return Kq
    End Function

    Public Sub Them(ByVal ptDto As PhuTrachDTO)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Insert into PhuTrach(MaPhuTrach, MaGiaoVien, MaMonHoc) values (?, ?, ?)"

        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaPhuTrach", OleDbType.WChar)
        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters.Add("@MaMonHoc", OleDbType.WChar)

        cmd.Parameters("@MaPhuTrach").Value = ptDto.MaPhuTrach
        cmd.Parameters("@MaGiaoVien").Value = ptDto.MaGiaoVien
        cmd.Parameters("@MaMonHoc").Value = ptDto.MaMonHoc

        cmd.ExecuteNonQuery()

        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Sub Xoa(ByVal maPT As String)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Delete From PhuTrach Where MaPhuTrach = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaPhuTrach", OleDbType.WChar)

        cmd.Parameters("@MaPhuTrach").Value = maPT

        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Sub Xoa(ByVal maGV As String, ByVal maMH As String)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Delete From PhuTrach Where MaGiaoVien = ? and MaMonHoc = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters.Add("@MaMonHoc", OleDbType.WChar)

        cmd.Parameters("@MaGiaoVien").Value = maGV
        cmd.Parameters("@MaMonHoc").Value = maMH

        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Sub XoaGiaoVien(ByVal maGV As String)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Delete From PhuTrach Where MaGiaoVien = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)

        cmd.Parameters("@MaGiaoVien").Value = maGV

        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Function LaySoLuongMonHoc(ByVal maGV As String) As Integer
        Dim dsMonHoc As IList
        dsMonHoc = LayDanhSachMonHoc(maGV)

        Return dsMonHoc.Count
    End Function
    ' Luan

    Public Function LayDanhSachGiaoVien(ByVal mamonhoc As String) As IList

        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim Kq As New ArrayList
        Dim giaoviendto As New GiaoVienDTO
        Dim giaoviendao As New GiaoVienDAO

        Dim strSQL = "select * from PhuTrach where MaMonHoc = ?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaMonHoc", OleDbType.WChar)
        cmd.Parameters("@MaMonHoc").Value = mamonhoc

        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()

        While (dr.Read())
            giaoviendto = giaoviendao.Tim(dr("MaGiaoVien"))
            Kq.Add(giaoviendto)
        End While

        'Dong ket noi csdl
        dr.Close()
        cn.Close()
        Return Kq

    End Function

End Class
