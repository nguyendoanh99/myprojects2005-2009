Imports DAO
Public Class DuLieuBUS
    Private dulieudao As New DuLieuDAO
    
    ' Sinh ma giao vien moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaGiaoVien() As String
        Return dulieudao.TaoMaGiaoVien()
    End Function
    ' Sinh ma lich lop hoc moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaLichLopHoc() As String
        Return dulieudao.TaoMaLichLopHoc()
    End Function
    ' Sinh ma lop hoc moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaLopHoc() As String
        Return dulieudao.TaoMaLopHoc()
    End Function
    ' Sinh ma mon hoc moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaMonHoc() As String
        Return dulieudao.TaoMaMonHoc()
    End Function
    ' Sinh ma phan cong moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaPhanCong() As String
        Return dulieudao.TaoMaPhanCong()
    End Function
    ' Sinh ma phu trach moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaPhuTrach() As String
        Return dulieudao.TaoMaPhuTrach()
    End Function
    ' Sinh ma rang buoc giao vien moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaRangBuocGiaoVien() As String
        Return dulieudao.TaoMaRangBuocGiaoVien()
    End Function
    ' Sinh ma rang buoc lop hoc moi
    ' Neu khong the tao ra ma moi thi tra ve chuoi rong
    ' Nguoc lai tra ve ma moi
    Public Function TaoMaRangBuocLopHoc() As String
        Return dulieudao.TaoMaRangBuocLopHoc()
    End Function
End Class
