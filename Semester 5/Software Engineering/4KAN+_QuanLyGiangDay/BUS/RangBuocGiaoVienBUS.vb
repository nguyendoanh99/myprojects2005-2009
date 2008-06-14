Imports DAO
Imports DTO

Public Class RangBuocGiaoVienBUS
    Private rangbuocgiaviendao As New RangBuocGiaoVienDAO
    Public Sub Close()
        rangbuocgiaviendao.Close()
    End Sub
    Public Function LayBang() As DataTable
        Return rangbuocgiaviendao.LayBang()
    End Function

    Public Function LayDanhSach() As IList
        Return rangbuocgiaviendao.LayDanhSach()
    End Function
    ' Kim
    Public Function LayDanhSachTheoMaGiaoVien(ByVal magiaovien As String) As IList
        Return (New RangBuocGiaoVienDAO).LayDanhSachTheoMaGiaoVien(magiaovien)
    End Function
    ' Khuong


    Public Function LayDanhSachRBGV(ByVal maGV As String) As IList
        Dim rbgvDao As New RangBuocGiaoVienDAO()
        Return rbgvDao.LayDanhSachRBGV(maGV)
    End Function

    Public Sub Sua(ByVal rbgvDto As RangBuocGiaoVienDTO)
        Dim rbgvDao As New RangBuocGiaoVienDAO()
        rbgvDao.Sua(rbgvDto)
    End Sub

    Public Sub Them(ByVal rbgvDto As RangBuocGiaoVienDTO)
        Dim rbgvDao As New RangBuocGiaoVienDAO()
        rbgvDao.Them(rbgvDto)
    End Sub

    Public Sub XoaGiaoVien(ByVal maGV As String)
        Dim rbgvDao As New RangBuocGiaoVienDAO()
        rbgvDao.XoaGiaoVien(maGV)
    End Sub

End Class