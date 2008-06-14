Imports DAO
Imports DTO

Public Class KhoiBUS
    Private khoidao As New KhoiDAO

    Public Sub Close()
        khoidao.Close()
    End Sub

    Public Function LayBang() As DataTable
        Return khoidao.LayBang()
    End Function

    Public Function LayDanhSach() As IList
        Return khoidao.LayDanhSach()
    End Function
End Class