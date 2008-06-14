Imports DAO
Imports DTO

Public Class ThamSoBUS
    Private thamsodao As New ThamSoDAO

    Public Sub Close()
        thamsodao.Close()
    End Sub

    Public Function LayBang() As DataTable
        Return thamsodao.LayBang()
    End Function

    Public Function LayThamSo() As ThamSoDTO
        Return thamsodao.LayThamSo()
    End Function
    Public Sub CapNhat(ByVal thamso As ThamSoDTO)
        Dim ts As New ThamSoDAO
        ts.CapNhat(thamso)
    End Sub
End Class