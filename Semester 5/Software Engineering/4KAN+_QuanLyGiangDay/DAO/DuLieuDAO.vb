Imports system.Data.OleDb
Imports System.Xml
Public Class DuLieuDAO
    Inherits AbstractDAO
    Private TaiLieu As XmlDocument = KetNoiXML()

    ' Ghi gia tri cua Node xuong xml
    Private Sub GhiDuLieu(ByVal TenNode As String, ByVal GiaTri As Integer)
        
        ' Lay thong tin cua node co ten la TenNode
        Dim node As XmlNode = TaiLieu.GetElementsByTagName(TenNode)(0)
        Dim node1 As XmlNode = node.Clone()
        node1.FirstChild.Value = GiaTri
        TaiLieu.DocumentElement.ReplaceChild(node1, node)
        TaiLieu.Save(TaiLieu.BaseURI.ToString().Replace("file:///", ""))
    End Sub

    Private Sub LayThongTinNode(ByVal TenNode As String, ByRef Chuoi As String, _
        ByRef ChieuDai As Integer, ByRef GiaTri As Integer)
        'Dim TaiLieu As XmlDocument

        'TaiLieu = KetNoiXML()
        ' Lay thong tin cua node co ten la TenNode
        Dim node As XmlNode = TaiLieu.GetElementsByTagName(TenNode)(0)
        Chuoi = node.Attributes("Chuoi").Value
        ChieuDai = node.Attributes("ChieuDai").Value
        GiaTri = node.FirstChild.Value
    End Sub

    'Lay so lon nhat co n chu so
    Private Function SoLonNhat(ByVal n As Integer) As Integer
        Dim KetQua As Integer = 1
        For i As Integer = 1 To n
            KetQua *= 10
        Next
        Return KetQua - 1
    End Function
    ' Sinh ma moi, ma do la ma strMa trong bang strBang
    Private Function TaoMa(ByVal strMa As String, ByVal strBang As String) As String
        Dim KetQua As String = ""
        Dim Chuoi As String = ""
        Dim ChieuDai As Integer
        Dim GiaTri As Integer
        LayThongTinNode(strMa, Chuoi, ChieuDai, GiaTri)
        Dim ChieuDaiChuoiSo As Integer = ChieuDai - Chuoi.Length()
        Dim Max As Integer = SoLonNhat(ChieuDaiChuoiSo)
        Dim format As String
        'Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim GiaTriCu As Integer = GiaTri - 1 ' Luu lai gia tri vua moi doc

        If (GiaTriCu < 0) Then
            GiaTriCu = Max
        End If

        While GiaTriCu <> GiaTri
            format = Chuoi & "{0," & ChieuDaiChuoiSo.ToString() & ":D}"
            KetQua = String.Format(format, GiaTri)
            KetQua = KetQua.Replace(" ", "0")

            Dim strSQL As String
            strSQL = "select count(*) from " & strBang & " where " _
                        & strMa & "='" & KetQua & "'"
            Dim cmd As New OleDbCommand(strSQL, cn)

            Dim gt As Integer = cmd.ExecuteScalar()
            If gt = 0 Then ' Ma nay chua co trong csdl
                Exit While
            End If

            GiaTri += 1
            If GiaTri > Max Then
                GiaTri = 0
            End If
        End While

        If (GiaTri = GiaTriCu) Then
            KetQua = ""
        Else
            GhiDuLieu(strMa, GiaTri)
            Console.WriteLine(GiaTri)
        End If

        Return KetQua
    End Function
    ' Sinh ma giao vien moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaGiaoVien() As String
        Return TaoMa("MaGiaoVien", "GiaoVien")
    End Function
    ' Sinh ma lich lop hoc moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaLichLopHoc() As String
        Return TaoMa("MaLichLopHoc", "LichLopHoc")
    End Function
    ' Sinh ma lop hoc moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaLopHoc() As String
        Return TaoMa("MaLopHoc", "LopHoc")
    End Function
    ' Sinh ma mon hoc moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaMonHoc() As String
        Return TaoMa("MaMonHoc", "MonHoc")
    End Function
    ' Sinh ma phan cong moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaPhanCong() As String
        Return TaoMa("MaPhanCong", "PhanCong")
    End Function
    ' Sinh ma phu trach moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaPhuTrach() As String
        Return TaoMa("MaPhuTrach", "PhuTrach")
    End Function
    ' Sinh ma rang buoc giao vien moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaRangBuocGiaoVien() As String
        Return TaoMa("MaRangBuocGiaoVien", "RangBuocGiaoVien")
    End Function
    ' Sinh ma rang buoc lop hoc moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaRangBuocLopHoc() As String
        Return TaoMa("MaRangBuocLopHoc", "RangBuocLopHoc")
    End Function

    ' Ghi ma giao vien xuong xml
    Public Function GhiMaGiaoVien(ByVal Ma As Integer) As Boolean
        GhiDuLieu("MaGiaoVien", Ma)
        Return True
    End Function
    ' Ghi ma Lich lop hoc xuong xml
    Public Function GhiMaLichLopHoc(ByVal Ma As Integer) As Boolean
        GhiDuLieu("MaLichLopHoc", Ma)
        Return True
    End Function
    ' Ghi ma Lop hoc xuong xml
    Public Function GhiMaLopHoc(ByVal Ma As Integer) As Boolean
        GhiDuLieu("MaLopHoc", Ma)
        Return True
    End Function
    ' Ghi ma Mon hoc xuong xml
    Public Function GhiMaMonHoc(ByVal Ma As Integer) As Boolean
        GhiDuLieu("MaMonHoc", Ma)
        Return True
    End Function
    ' Ghi ma Phan cong xuong xml
    Public Function GhiMaPhanCong(ByVal Ma As Integer) As Boolean
        GhiDuLieu("MaPhanCong", Ma)
        Return True
    End Function
    ' Ghi ma Phu trach xuong xml
    Public Function GhiMaPhuTrach(ByVal Ma As Integer) As Boolean
        GhiDuLieu("MaPhuTrach", Ma)
        Return True
    End Function
    ' Ghi ma Rang buoc giao vien xuong xml
    Public Function GhiMaRangBuocGiaoVien(ByVal Ma As Integer) As Boolean
        GhiDuLieu("MaRangBuocGiaoVien", Ma)
        Return True
    End Function
    ' Ghi ma Rang buoc lop hoc xuong xml
    Public Function GhiMaRangBuocLopHoc(ByVal Ma As Integer) As Boolean
        GhiDuLieu("MaRangBuocLopHoc", Ma)
        Return True
    End Function
End Class
