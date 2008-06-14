Imports DAO
Imports DTO

Public Class GiaoVienBUS
    Private giaoviendao As New GiaoVienDAO

    Public Sub Close()
        giaoviendao.Close()
    End Sub
    Public Function LayBang() As DataTable
        Return giaoviendao.LayBang()
    End Function

    Public Function LayDanhSach() As IList
        Return giaoviendao.LayDanhSach()
    End Function

    Public Function LayMaGiaoVienCoTen(ByVal tengiaovien As String) As IList
        Return giaoviendao.LayMaGiaoVienCoTen(tengiaovien)
    End Function

    Public Function LayGiaoVienCoMa(ByVal MaGiaoVien As String) As GiaoVienDTO
        Return giaoviendao.LayGiaoVienCoMa(MaGiaoVien)
    End Function
    ' Khuong
    Public Function LayThongTinGiaoVien(ByVal maGV As String) As GiaoVienDTO
        'Kiem tra Business Rule neu co
        Dim gvDto As GiaoVienDTO
        Dim gvDao As New GiaoVienDAO()
        gvDto = gvDao.LayThongTinGiaoVien(maGV)
        Return gvDto
    End Function

    Public Sub Them(ByVal gvDto As GiaoVienDTO)
        Dim gvDao As New GiaoVienDAO()
        gvDao.Them(gvDto)
    End Sub

    Public Sub Xoa(ByVal maGV As String)
        Dim gvDao As New GiaoVienDAO()
        gvDao.Xoa(maGV)
    End Sub

    Public Sub Sua(ByVal gvDto As GiaoVienDTO)
        Dim gvDao As New GiaoVienDAO()
        gvDao.Sua(gvDto)
    End Sub
    Public Function LaySoLuong() As Integer
        Return New GiaoVienDAO().LaySoLuong()
    End Function

End Class
