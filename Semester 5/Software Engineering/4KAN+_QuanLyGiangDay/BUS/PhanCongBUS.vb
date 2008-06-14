Imports DAO
Imports DTO

Public Class PhanCongBUS
    Private phancongdao As New PhanCongDAO

    Public Sub Close()
        phancongdao.Close()
    End Sub

    Public Function LayBang() As DataTable
        Return phancongdao.LayBang()
    End Function

    Public Function LayDanhSach() As IList
        Return phancongdao.LayDanhSach()
    End Function

    Public Function LayDanhSachLopHocCoHocMonHoc(ByVal mytable As DataTable, _
                                                    ByVal mamonhoc As String) As ArrayList
        Return phancongdao.LayDanhSachLopHocCoHocMonHoc(mytable, mamonhoc)
    End Function

    Public Function LayBangTheoMaMonHoc(ByVal mamonhoc As String) As DataTable
        Return phancongdao.LayBangTheoMaMonHoc(mamonhoc)
    End Function

    Public Function LayBangTheoMaGiaoVien(ByVal magiaovien As String) As DataTable
        Return phancongdao.LayBangTheoMaGiaoVien(magiaovien)
    End Function

    Public Function LayDanhSachGiaoVienCoDayMonHoc(ByVal mamonhoc As String) As DataTable
        Return phancongdao.LayDanhSachGiaoVienCoDayMonHoc(mamonhoc)
    End Function

    Public Function LayDanhSachLopHocMaGiaoVienDay(ByVal magiaovien As String) As ArrayList
        Return phancongdao.LayDanhSachLopHocMaGiaoVienDay(magiaovien)
    End Function

    Public Sub CapNhatDong(ByVal phancong As PhanCongDTO)
        phancongdao.CapNhatDong(phancong)
    End Sub

    Public Sub ThemDong(ByVal phancong As PhanCongDTO)
        phancongdao.ThemDong(phancong)
    End Sub

    Public Sub XoaDong(ByVal maphancong As String)
        phancongdao.XoaDong(maphancong)
    End Sub

    Public Function LayDanhSachCoMaLopHoc(ByVal MaLopHoc As String) As IList
        Return phancongdao.LayDanhSachCoMaLopHoc(MaLopHoc)
    End Function

    Public Function LayPhanCongCoMa(ByVal MaPhanCong As String) As PhanCongDTO
        Return phancongdao.LayPhanCongCoMa(MaPhanCong)
    End Function

    ' be A
    Public Function LayBangTheoLopHoc(ByVal _maLopHoc As String) As DataTable
        Return (New PhanCongDAO).LayBangTheoLopHoc(_maLopHoc)
    End Function

    Public Function LayBangTheoLopHocVaGiaoVien(ByVal _maLopHoc As String, ByVal _maGiaoVien As String) As DataTable
        Return (New PhanCongDAO).LayBangTheoLopHocVaGiaoVien(_maLopHoc, _maGiaoVien)
    End Function
    ' Kim
    Public Function LayDanhSachTheoMaLopHoc(ByVal malophoc As String) As IList
        Return (New PhanCongDAO).LayDanhSachTheoMaLopHoc(malophoc)
    End Function

    Public Function LayDanhSachChiTietMonHocCuaLop(ByVal malophoc As String) As DataTable
        Return (New PhanCongDAO).LayDanhSachChiTietMonHocCuaLop(malophoc)
    End Function

    Public Function LayDanhSachTheoMaGiaoVien(ByVal magiaovien As String) As IList
        Return (New PhanCongDAO).LayDanhSachTheoMaGiaoVien(magiaovien)
    End Function
    ' Khuong
    Public Sub Sua(ByVal phancong As PhanCongDTO)
        Dim pc As New PhanCongDAO
        pc.CapNhatDong(phancong)
    End Sub

    Public Sub Them(ByVal phancong As PhanCongDTO)
        Dim pc As New PhanCongDAO
        pc.ThemDong(phancong)
    End Sub

    Public Sub Xoa(ByVal maphancong As String)
        Dim pc As New PhanCongDAO
        pc.XoaDong(maphancong)
    End Sub

    Public Sub XoaGiaoVien(ByVal maGV As String)
        Dim pc As New PhanCongDAO
        pc.XoaGiaoVien(maGV)
    End Sub
End Class