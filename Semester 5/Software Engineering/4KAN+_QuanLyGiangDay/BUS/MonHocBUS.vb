Imports DAO
Imports DTO

Public Class MonHocBUS
    Private monhocdao As New MonHocDAO

    Public Sub Close()
        monhocdao.Close()
    End Sub

    Public Function LayBang() As DataTable
        Return monhocdao.LayBang()
    End Function

    Public Function LayDanhSach() As IList
        Return monhocdao.LayDanhSach()
    End Function

    Public Function LayMaMonHocCoTen(ByVal tenmonhoc As String) As IList
        Return monhocdao.LayMaMonHocCoTen(tenmonhoc)
    End Function

    Public Function LayMonHocCoMa(ByVal MaMonHoc As String) As MonHocDTO
        Return monhocdao.LayMonHocCoMa(MaMonHoc)
    End Function

    Public Function LayThongTinCoMa(ByVal mamonhoc As String) As MonHocDTO
        Return (New MonHocDAO).LayThongTinCoMa(mamonhoc)
    End Function
    ' Luan
    Public Sub Them(ByVal monhocdto As MonHocDTO)
        Dim monhocdao As New MonHocDAO()
        monhocdao.Them(monhocdto)
    End Sub

    Public Sub Xoa(ByVal mamonhoc As String)
        Dim monhocdao As New MonHocDAO()
        monhocdao.Xoa(mamonhoc)
    End Sub

    Public Sub Sua(ByVal monhocdto As MonHocDTO)
        Dim monhocdao As New MonHocDAO()
        monhocdao.Sua(monhocdto)
    End Sub

    Public Function Tim(ByVal mamonhoc As String) As MonHocDTO
        Dim monhocdao As New MonHocDAO()
        Dim monhocdto As New MonHocDTO()
        monhocdto = monhocdao.Tim(mamonhoc)
        Return monhocdto
    End Function
End Class