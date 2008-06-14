Imports system.Data.OleDb
Imports DTO

Public Class RangBuocLopHocDAO
    Inherits AbstractDAO

    Public Function LayBang() As DataTable
        'Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from RangBuocLopHoc"
        Dim da As New OleDbDataAdapter(strSQL, cn)
        Dim dt As New DataTable

        da.Fill(dt)
        'cn.Close()

        Return dt
    End Function

    Public Function LayDanhSach() As IList
        Dim dt As DataTable = LayBang()
        Dim Kq As New ArrayList

        For Each row As DataRow In dt.Rows
            Dim rblh As New RangBuocLopHocDTO

            rblh.MaRangBuocLopHoc = row("MaRangBuocLopHoc")
            rblh.MaLopHoc = row("MaLopHoc")
            rblh.Thu = row("Thu")
            rblh.TietHoc = row("TietHoc")
            rblh.TrangThai = row("TrangThai")

            Kq.Add(rblh)
        Next

        Return Kq
    End Function
    'Kien
    Public Sub Them(ByVal rangbuoclophocDto As RangBuocLopHocDTO)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Me.KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Insert into RangBuocLopHoc(MaRangBuocLopHoc, MaLopHoc, Thu, TietHoc, TrangThai) values (?, ?, ?, ?, ?)"

        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaRangBuocLopHoc", OleDbType.WChar)
        cmd.Parameters.Add("@MaLopHoc", OleDbType.WChar)
        cmd.Parameters.Add("@Thu", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@TietHoc", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@TrangThai", OleDbType.UnsignedTinyInt)


        cmd.Parameters("@MaRangBuocLopHoc").Value = rangbuoclophocDto.MaRangBuocLopHoc()
        cmd.Parameters("@MaLopHoc").Value = rangbuoclophocDto.MaLopHoc()
        cmd.Parameters("@Thu").Value = rangbuoclophocDto.Thu()
        cmd.Parameters("@TietHoc").Value = rangbuoclophocDto.TietHoc()
        cmd.Parameters("@TrangThai").Value = rangbuoclophocDto.TrangThai()

        cmd.ExecuteNonQuery()

        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub
    Public Sub Sua(ByVal rangbuoclophocDto As RangBuocLopHocDTO)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Me.KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Update RangBuocLopHoc Set TrangThai = ? Where MaLopHoc = ? and Thu = ? and TietHoc= ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        'cmd.Parameters.Add("@MaRangBuocLopHoc", OleDbType.WChar)
        cmd.Parameters.Add("@TrangThai", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@MaLopHoc", OleDbType.WChar)
        cmd.Parameters.Add("@Thu", OleDbType.UnsignedTinyInt)
        cmd.Parameters.Add("@TietHoc", OleDbType.UnsignedTinyInt)


        cmd.Parameters("@TrangThai").Value = rangbuoclophocDto.TrangThai()
        cmd.Parameters("@MaLopHoc").Value = rangbuoclophocDto.MaLopHoc()
        cmd.Parameters("@Thu").Value = rangbuoclophocDto.Thu()
        cmd.Parameters("@TietHoc").Value = rangbuoclophocDto.TietHoc()

        'cmd.Parameters("@MaRangBuocLopHoc").Value = rangbuoclophocDto.MaRangBuocLopHoc()

        cmd.ExecuteNonQuery()

        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub
    Public Sub Xoa(ByVal malophoc As String)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Me.KetNoiCoSoDuLieu()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Delete From RangBuocLopHoc Where MaLopHoc = ? "
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaLopHoc", OleDbType.WChar)

        cmd.Parameters("@MaLopHoc").Value = malophoc

        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub
    Public Function LayDanhSach(ByVal i_malophoc As String) As IList
        Dim dt As DataTable = LayBang()
        Dim Kq As New ArrayList


        For Each row As DataRow In dt.Rows
            Dim rblh As New RangBuocLopHocDTO()
            If row.Item("MaLopHoc") = i_malophoc Then
                rblh.MaRangBuocLopHoc = row("MaRangBuocLopHoc")
                rblh.MaLopHoc = row("MaLopHoc")
                rblh.Thu = row("Thu")
                rblh.TietHoc = row("TietHoc")
                rblh.TrangThai = row("TrangThai")

                Kq.Add(rblh)
            End If
        Next
        Return Kq
    End Function
    ' Kim
    Public Function LayRBLHLop(ByVal malophoc As String) As IList
        Dim Kq As New ArrayList
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from RangBuocLopHoc where MaLopHoc = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaLopHoc", OleDbType.WChar)
        cmd.Parameters("@MaLopHoc").Value = malophoc

        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        cn.Close()

        For Each row As DataRow In dt.Rows
            Dim rblh As New RangBuocLopHocDTO

            rblh.MaRangBuocLopHoc = row("MaRangBuocLopHoc")
            rblh.MaLopHoc = row("MaLopHoc")
            rblh.Thu = row("Thu")
            rblh.TietHoc = row("TietHoc")
            rblh.TrangThai = row("TrangThai")

            Kq.Add(rblh)
        Next

        Return Kq
    End Function


End Class
