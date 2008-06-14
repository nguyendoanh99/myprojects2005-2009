Imports DAO
Imports DTO

Public Class RangBuocLopHocBUS
    Private rangbuoclophocdao As New RangBuocLopHocDAO

    Public Sub Close()
        rangbuoclophocdao.Close()
    End Sub
    Public Function LayBang() As DataTable
        Return rangbuoclophocdao.LayBang()
    End Function

    Public Function LayDanhSach() As IList
        Return rangbuoclophocdao.LayDanhSach()
    End Function
    'Kien
    'Them
    Public Sub Them(ByVal rangbuoclophocDto As RangBuocLopHocDTO)
        'Kiem tra Business Rule neu co
        'New RangBuocLopHocDAO().Them(array_rangbuoclophoc)
        Dim rangbuoclophocDao As New RangBuocLopHocDAO()
        rangbuoclophocDao.Them(rangbuoclophocDto)
    End Sub
    Public Sub Sua(ByVal rangbuoclophocDto As RangBuocLopHocDTO)
        'Kiem tra Business Rule neu co
        'New RangBuocLopHocDAO().Them(array_rangbuoclophoc)
        Dim rangbuoclophocDao As New RangBuocLopHocDAO()
        rangbuoclophocDao.Sua(rangbuoclophocDto)
    End Sub
    Public Sub Xoa(ByVal malophoc As String)
        'Kiem tra Business Rule neu co
        Dim rangbuoclophocDao As New RangBuocLopHocDAO()
        rangbuoclophocDao.Xoa(malophoc)
    End Sub
    Public Function LayDanhSach(ByVal i_malophoc As String) As IList
        Return New RangBuocLopHocDAO().LayDanhSach(i_malophoc)
    End Function
    ' Kim
    Public Function LayRBLHLop(ByVal malophoc As String) As IList
        Return (New RangBuocLopHocDAO).LayRBLHLop(malophoc)
    End Function
End Class