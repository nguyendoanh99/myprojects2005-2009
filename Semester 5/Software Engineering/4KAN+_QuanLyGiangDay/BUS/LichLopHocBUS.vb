Imports DAO
Imports DTO

Public Class LichLopHocBUS
    Private lichlophocdao As New LichLopHocDAO

    Public Sub Close()
        lichlophocdao.Close()
    End Sub

    Public Function LayBang() As DataTable
        Return lichlophocdao.LayBang()
    End Function

    Public Function LayDanhSach() As IList
        Return lichlophocdao.LayDanhSach()
    End Function

    Public Function LayDanhSachCoMaPhanCong(ByVal MaPhanCong As String) As IList
        Return lichlophocdao.LayDanhSachCoMaPhanCong(MaPhanCong)
    End Function
    ' Kim
    Public Function LayLichDayGiaoVien(ByVal magiaovien As String) As IList
        Return (New LichLopHocDAO).LayLichDayGiaoVien(magiaovien)
    End Function

    Public Function LayLichLopHoc(ByVal malophoc As String) As IList
        Return (New LichLopHocDAO).LayLichLopHoc(malophoc)
    End Function
End Class
