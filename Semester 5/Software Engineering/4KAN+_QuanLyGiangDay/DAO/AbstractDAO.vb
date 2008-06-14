Imports System.Data.OleDb
Imports DTO
Imports System.Xml

Public Class AbstractDAO
    Protected cn As OleDbConnection
    Public Sub New()
        cn = KetNoiCoSoDuLieu()
    End Sub

    Public Function KetNoiCoSoDuLieu() As OleDbConnection
        Dim strConnection As String
        strConnection = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = PTNK.mdb"

        Dim cn As New OleDbConnection(strConnection)
        cn.Open()

        Return cn
    End Function

    Public Sub Close()
        cn.Close()
    End Sub
    Public Function KetNoiXML() As XmlDocument
        ' Cau truc cua file Dulieu.xml
        ' Gom 9 dong, luu lai thong tin cua ma cua cac bang, vi du: MaGiaoVien, MaMonHoc...
        ' Thong tin cua ma gom co 2 thuoc tinh
        ' Chuoi: Luu dang cua ma, vi du: MaGiaoVien Chuoi = "GV"
        ' ChieuDai: Luu chieu dai toi da cua ma, vi du MaGiaoVien ChieuDai = 4
        ' Ma co gia tri value: cho biet hien tai ma da phat sinh den so nao
        Dim KetQua As New XmlDocument
        KetQua.Load("DuLieu.xml")
        Return KetQua
    End Function
End Class
