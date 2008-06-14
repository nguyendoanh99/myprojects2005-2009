Imports system.Data.OleDb
Imports DTO

Public Class MonHocDAO
    Inherits AbstractDAO

    Public Function LayBang() As DataTable
        'Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL = "select * from MonHoc"
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
            Dim mh As New MonHocDTO

            mh.MaMonHoc = row("MaMonHoc")
            mh.TenMonHoc = row("TenMonHoc")
            mh.QuyDinhSoTietHocLienTiepToiThieu = row("QuiDinhSoTietHocLienTiepToiThieu")
            mh.QuyDinhSoTietHocLienTiepToiDa = row("QuiDinhSoTietHocLienTiepToiDa")

            Kq.Add(mh)
        Next

        Return Kq
    End Function

    Public Function LayMaMonHocCoTen(ByVal tenmonhoc As String) As IList
        Dim Kq As New ArrayList
        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL As String = "select MaMonHoc from MonHoc where TenMonHoc = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@tenmonhoc", OleDbType.WChar)
        cmd.Parameters("@tenmonhoc").Value = tenmonhoc

        Dim rd As OleDbDataReader = cmd.ExecuteReader()

        While rd.Read()
            If Not IsDBNull(rd.GetString(0)) Then
                Kq.Add(rd.GetString(0))
            End If
        End While
        rd.Close()
        'cn.Close()
        Return Kq
    End Function

    Public Function LayMonHocCoMa(ByVal MaMonHoc As String) As MonHocDTO
        Dim Kq As MonHocDTO = Nothing
        'Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL As String = "select * from MonHoc where MaMonHoc = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaMonHoc", OleDbType.WChar)
        cmd.Parameters("@MaMonHoc").Value = MaMonHoc

        Dim rd As OleDbDataReader = cmd.ExecuteReader()

        While rd.Read()
            Kq = New MonHocDTO()
            Kq.MaMonHoc = MaMonHoc
            Kq.TenMonHoc = rd("TenMonHoc").ToString()
            Kq.QuyDinhSoTietHocLienTiepToiDa = Byte.Parse(rd("QuiDinhSoTietHocLienTiepToiDa"))
            Kq.QuyDinhSoTietHocLienTiepToiThieu = Byte.Parse(rd("QuiDinhSoTietHocLienTiepToiThieu"))
        End While
        rd.Close()
        'cn.Close()
        Return Kq
    End Function
    Public Function LayThongTinCoMa(ByVal mamonhoc As String) As MonHocDTO
        Dim cn As OleDbConnection = Me.KetNoiCoSoDuLieu()
        Dim strSQL As String = "select * from MonHoc where MaMonHoc = ?"

        Dim da As New OleDbDataAdapter
        da.SelectCommand = New OleDbCommand(strSQL, cn)
        da.SelectCommand.Parameters.Add("@mamonhoc", OleDbType.WChar)
        da.SelectCommand.Parameters("@mamonhoc").Value = mamonhoc

        Dim dt As New DataTable
        da.Fill(dt)

        If dt.Rows.Count = 1 Then
            Dim Kq As New MonHocDTO
            Kq.MaMonHoc = dt.Rows(0).Item("MaMonHoc")
            Kq.TenMonHoc = dt.Rows(0).Item("TenMonHoc")
            Kq.QuyDinhSoTietHocLienTiepToiThieu = dt.Rows(0).Item("QuiDinhSoTietHocLienTiepToiThieu")
            Kq.QuyDinhSoTietHocLienTiepToiDa = dt.Rows(0).Item("QuiDinhSoTietHocLienTiepToiDa")
            Return Kq
        End If

        Return Nothing
    End Function
    ' Luan

    Public Sub Them(ByVal monhocdto As MonHocDTO)
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL As String
        strSQL = "Insert into MonHoc(MaMonHoc,TenMonHoc,QuiDinhSoTietHocLienTiepToiThieu,QuiDinhSoTietHocLienTiepToiDa) values ( ?,?,?,?)"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaMonHoc", OleDbType.WChar)
        cmd.Parameters.Add("@TenMonHoc", OleDbType.WChar)
        cmd.Parameters.Add("@QuiDinhSoTietHocLienTiepToiThieu", OleDbType.Integer)
        cmd.Parameters.Add("@QuiDinhSoTietHocLienTiepToiDa", OleDbType.Integer)

        cmd.Parameters("@MaMonHoc").Value = monhocdto.MaMonHoc
        cmd.Parameters("@TenMonHoc").Value = monhocdto.TenMonHoc
        cmd.Parameters("@QuiDinhSoTietHocLienTiepToiThieu").Value = monhocdto.QuyDinhSoTietHocLienTiepToiThieu
        cmd.Parameters("@QuiDinhSoTietHocLienTiepToiDa").Value = monhocdto.QuyDinhSoTietHocLienTiepToiDa
        cmd.ExecuteNonQuery()

        strSQL = "select @@IDENTITY"
        cmd = New OleDbCommand(strSQL, cn)
        monhocdto.MaMonHoc = cmd.ExecuteScalar()
        cn.Close()
    End Sub

    Public Sub Xoa(ByVal mamonhocdto As String)
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL As String
        strSQL = "delete from MonHoc where MaMonHoc = ?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@MaMonHoc", OleDbType.WChar)

        cmd.Parameters("@MaMonHoc").Value = mamonhocdto
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub Sua(ByVal monhocdto As MonHocDTO)
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL As String
        strSQL = "update MonHoc set TenMonHoc = ?,QuiDinhSoTietHocLienTiepToiThieu = ?,QuiDinhSoTietHocLienTiepToiDa = ? where MaMonHoc = ?"

        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@TenMonHoc", OleDbType.WChar)
        cmd.Parameters.Add("@QuiDinhSoTietHocLienTiepToiThieu", OleDbType.Integer)
        cmd.Parameters.Add("@QuiDinhSoTietHocLienTiepToiDa", OleDbType.Integer)
        cmd.Parameters.Add("@MaMonHoc", OleDbType.WChar)

        cmd.Parameters("@TenMonHoc").Value = monhocdto.TenMonHoc.ToString()
        cmd.Parameters("@QuiDinhSoTietHocLienTiepToiThieu").Value = monhocdto.QuyDinhSoTietHocLienTiepToiThieu
        cmd.Parameters("@QuiDinhSoTietHocLienTiepToiDa").Value = monhocdto.QuyDinhSoTietHocLienTiepToiDa
        cmd.Parameters("@MaMonHoc").Value = monhocdto.MaMonHoc.ToString()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Function Tim(ByVal mamonhoc As String) As MonHocDTO
        Dim monhocdto As New MonHocDTO()
        Dim cn As OleDbConnection = KetNoiCoSoDuLieu()
        Dim strSQL As String
        strSQL = "select * from MonHoc where MaMonHoc = ?"
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@MaMonHoc", OleDbType.WChar)
        cmd.Parameters("@MaMonHoc").Value = mamonhoc
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()
        While (dr.Read())
            monhocdto.MaMonHoc = dr("MaMonHoc")
            monhocdto.TenMonHoc = dr("TenMonHoc")
            monhocdto.QuyDinhSoTietHocLienTiepToiThieu = dr("QuiDinhSoTietHocLienTiepToiThieu")
            monhocdto.QuyDinhSoTietHocLienTiepToiDa = dr("QuiDinhSoTietHocLienTiepToiDa")
        End While
        cn.Close()
        Return monhocdto
    End Function
End Class