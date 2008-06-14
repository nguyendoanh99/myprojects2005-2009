Imports DAO
Imports DTO

Public Class PhuTrachBUS
    Private phutrachdao As New PhuTrachDAO

    Public Sub Close()
        phutrachdao.Close()
    End Sub

    Public Function LayBang() As DataTable
        Return phutrachdao.LayBang()
    End Function

    Public Function LayDanhSach() As IList
        Return phutrachdao.LayDanhSach()
    End Function

    Public Function LayMonHocGiaoVienDay(ByVal magiaovien As String) As IList
        Return (New PhuTrachDAO).LayMonHocGiaoVienPhuTrach(magiaovien)
    End Function
    ' Khuong 
    Public Function LayDanhSachMonHoc(ByVal maGiaoVien As String) As IList
        Return New PhuTrachDAO().LayDanhSachMonHoc(maGiaoVien)
    End Function

    Public Function LaySoLuongMonHoc(ByVal maGiaoVien As String) As Integer
        Return New PhuTrachDAO().LaySoLuongMonHoc(maGiaoVien)
    End Function

    Public Sub Them(ByVal ptDto As PhuTrachDTO)
        Dim ptDao As New PhuTrachDAO
        ptDao.Them(ptDto)
    End Sub
    Public Sub Xoa(ByVal maPT As String)
        Dim ptDao As New PhuTrachDAO
        ptDao.Xoa(maPT)
    End Sub

    Public Sub Xoa(ByVal maGV As String, ByVal maMH As String)
        Dim ptDao As New PhuTrachDAO
        ptDao.Xoa(maGV, maMH)
    End Sub

    Public Sub XoaGiaoVien(ByVal maGV As String)
        Dim ptDao As New PhuTrachDAO
        ptDao.XoaGiaoVien(maGV)
    End Sub
    'Luan

    Public Function LayDanhSachGiaoVien(ByVal mamonhoc As String) As IList
        Return New PhuTrachDAO().LayDanhSachGiaoVien(mamonhoc)
    End Function
End Class