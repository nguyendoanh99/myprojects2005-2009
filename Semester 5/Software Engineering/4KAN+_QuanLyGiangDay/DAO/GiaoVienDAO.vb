Imports system.Data.OleDb
Imports DTO

Public Class GiaoVienDAO
    Inherits AbstractDAO

    Public Function LayBang() As DataTable
        'Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from GiaoVien"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        Dim dt As New DataTable

        da.Fill(dt)
        'cn.Close()
        da.Dispose()
        Return dt
    End Function

    Public Function LayDanhSach() As IList
        Dim dt As DataTable = LayBang()
        Dim Kq As New ArrayList

        For Each row As DataRow In dt.Rows
            Dim gv As New GiaoVienDTO
            gv.MaGiaoVien = row("MaGiaoVien")
            gv.HoTenGiaoVien = row("HoTenGiaoVien")
            gv.TenTat = row("TenTat")
            gv.DiaChi = row("DiaChi")
            gv.DienThoai = row("DienThoai")

            Kq.Add(gv)
        Next
        dt.Clear()

        Return Kq
    End Function

    Public Function LayMaGiaoVienCoTen(ByVal tengiaovien As String) As IList
        Dim Kq As New ArrayList
        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL As String = "select MaGiaoVien from GiaoVien where HoTenGiaoVien = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@tengiaovien", OleDbType.WChar)
        cmd.Parameters("@tengiaovien").Value = tengiaovien

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

    Public Function LayGiaoVienCoMa(ByVal MaGiaoVien As String) As GiaoVienDTO
        Dim Kq As GiaoVienDTO = Nothing
        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL As String = "select * from GiaoVien where MaGiaoVien = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters("@MaGiaoVien").Value = MaGiaoVien

        Dim rd As OleDbDataReader = cmd.ExecuteReader()

        While rd.Read()
            Kq = New GiaoVienDTO
            Kq.MaGiaoVien = MaGiaoVien
            Kq.HoTenGiaoVien = rd("HoTenGiaoVien").ToString()
            Kq.TenTat = rd("TenTat").ToString()
            Kq.DiaChi = rd("DiaChi").ToString()
            Kq.DienThoai = rd("DienThoai").ToString()
        End While
        rd.Close()
        'cn.Close()
        Return Kq
    End Function
    Public Function LayThongTinGiaoVien(ByVal maGiaoVien As String) As GiaoVienDTO
        Dim gvDto As New GiaoVienDTO()
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Select * From GiaoVien Where MaGiaoVien = ?"

        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters("@MaGiaoVien").Value = maGiaoVien

        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()
        While (dr.Read())
            gvDto.MaGiaoVien = dr("MaGiaoVien")
            gvDto.HoTenGiaoVien = dr("HoTenGiaoVien")
            gvDto.TenTat = dr("TenTat")
            gvDto.DiaChi = dr("DiaChi")
            gvDto.DienThoai = dr("DienThoai")
        End While
        'B5: Dong ket noi CSDL
        dr.Close()
        cn.Close()
        Return gvDto
    End Function

    Public Sub Them(ByVal gvDto As GiaoVienDTO)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Insert into GiaoVien(MaGiaoVien, HoTenGiaoVien, TenTat, DiaChi, DienThoai) values (?, ?, ?, ?, ?)"

        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters.Add("@HoTenGiaoVien", OleDbType.WChar)
        cmd.Parameters.Add("@TenTat", OleDbType.WChar)
        cmd.Parameters.Add("@DiaChi", OleDbType.WChar)
        cmd.Parameters.Add("@DienThoai", OleDbType.WChar)

        cmd.Parameters("@MaGiaoVien").Value = gvDto.MaGiaoVien
        cmd.Parameters("@HoTenGiaoVien").Value = gvDto.HoTenGiaoVien
        cmd.Parameters("@TenTat").Value = gvDto.TenTat
        cmd.Parameters("@DiaChi").Value = gvDto.DiaChi
        cmd.Parameters("@DienThoai").Value = gvDto.DienThoai

        cmd.ExecuteNonQuery()

        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Sub Xoa(ByVal maGV As String)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Delete From GiaoVien Where MaGiaoVien = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)

        cmd.Parameters("@MaGiaoVien").Value = maGV

        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Sub Sua(ByVal gvDto As GiaoVienDTO)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = _
        "Update GiaoVien Set HoTenGiaoVien = ?, TenTat = ?, DiaChi = ?, DienThoai = ? where MaGiaoVien = ?"
        '"Update GiaoVien Set HoTenGiaoVien = ? and TenTat = ? and DiaChi = ? and DienThoai = ? where MaGiaoVien = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@HoTenGiaoVien", OleDbType.WChar)
        cmd.Parameters.Add("@TenTat", OleDbType.WChar)
        cmd.Parameters.Add("@DiaChi", OleDbType.WChar)
        cmd.Parameters.Add("@DienThoai", OleDbType.WChar)
        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)

        cmd.Parameters("@HoTenGiaoVien").Value = gvDto.HoTenGiaoVien
        cmd.Parameters("@TenTat").Value = gvDto.TenTat
        cmd.Parameters("@DiaChi").Value = gvDto.DiaChi
        cmd.Parameters("@DienThoai").Value = gvDto.DienThoai
        cmd.Parameters("@MaGiaoVien").Value = gvDto.MaGiaoVien
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            '            MessageBox.Show(ex.Message)
        End Try

        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Function LaySoLuong() As Integer
        Dim dt As DataTable = LayBang()
        Return dt.Rows.Count
    End Function
    'Luan

    Public Function Tim(ByVal magiaovien As String) As GiaoVienDTO
        Dim giaoviendto As New GiaoVienDTO()
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL As String
        strSQL = "select * from GiaoVien where MaGiaoVien = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaGiaoVien", OleDbType.WChar)
        cmd.Parameters("@MaGiaoVien").Value = magiaovien
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()
        While (dr.Read())
            giaoviendto.MaGiaoVien = dr("MaGiaoVien")
            giaoviendto.HoTenGiaoVien = dr("HoTenGiaoVien")
            giaoviendto.TenTat = dr("TenTat")
            giaoviendto.DiaChi = dr("DiaChi")
            giaoviendto.DienThoai = dr("DienThoai")
        End While
        cn.Close()
        Return giaoviendto
    End Function

End Class
