Imports DAO
Imports DTO

Public Class LopHocBUS
    Private lophocdao As New LopHocDAO()

    Public Sub Close()
        lophocdao.Close()
    End Sub

    Public Function LayBang() As DataTable
        Return lophocdao.LayBang()
    End Function

    Public Function LayDanhSach() As IList
        Return lophocdao.LayDanhSach()
    End Function

    Public Function LayDanhSachMaLop() As IList
        Return lophocdao.LayDanhSachMaLop()
    End Function

    Public Function LayMaLopCoTen(ByVal tenlop As String) As IList
        Return lophocdao.LayMaLopCoTen(tenlop)
    End Function
    Public Function LayDanhSachCoMaKhoi(ByVal MaKhoi As String) As IList
        Return lophocdao.LayDanhSachCoMaKhoi(MaKhoi)
    End Function
    ' Be A
    Public Function LayDanhSachTheoKhoi(ByVal _maKhoi As String) As DataTable
        Return (New LopHocDAO).LayDanhSachTheoKhoi(_maKhoi)
    End Function
    'Kien
    'Xoa
    Public Sub Xoa(ByVal malophoc As String)
        'Kiem tra Business Rule neu co
        Dim lophocDao As New LopHocDAO()
        lophocDao.Xoa(malophoc)
    End Sub
    'Them
    Public Sub Them(ByVal lophocDto As LopHocDTO)
        'Kiem tra Business Rule neu co
        If lophocDto.TenLopHoc() = "" Then
            'Throw New Exception("Ten chua")
            Return
        End If
        Dim lophocDao As New LopHocDAO()
        lophocDao.Them(lophocDto)
    End Sub
    'Sua
    Public Sub Sua(ByVal lophocDto As LopHocDTO)
        'Kiem tra Business Rule neu co
        Dim lophocDao As New LopHocDAO()
        lophocDao.Sua(lophocDto)
    End Sub
    ' Kim
    Public Function LayDanhSachLopKhoi10() As IList
        Return (New LopHocDAO).LayDanhSachLopKhoi10
    End Function

    Public Function LayDanhSachLopKhoi11() As IList
        Return (New LopHocDAO).LayDanhSachLopKhoi11
    End Function

    Public Function LayDanhSachLopKhoi12() As IList
        Return (New LopHocDAO).LayDanhSachLopKhoi12
    End Function
End Class