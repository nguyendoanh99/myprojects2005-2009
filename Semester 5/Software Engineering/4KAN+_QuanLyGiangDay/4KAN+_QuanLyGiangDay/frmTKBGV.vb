Imports BUS
Imports DTO


Public Class frmTKBGV


    Private Class LopHoc
        Public lh As LopHocDTO
        Public mh As MonHocDTO
        Public pc As PhanCongDTO


        Public Sub New()
            mh = Nothing
            lh = Nothing
            pc = Nothing

        End Sub

        Public Overrides Function ToString() As String
            Return lh.TenLopHoc & " (" & mh.TenMonHoc & ")"
        End Function
    End Class

    Private ThamSo As ThamSoDTO

    ' danh saìch tâìt caÒ môn hoòc
    Private dsTatCaMonHoc As ArrayList
    ' danh saìch tâìt caÒ lõìp hoòc
    Private dsLopHoc As ArrayList
    ' danh saìch lõìp maÌ giaìo viên phuò traìch
    Private dsLopPhuTrach As ArrayList

    Private Sub frmTKBGV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '         lâìy tham sôì
        ThamSo = (New ThamSoBUS).LayThamSo()
        '       lâìy ds môn hoòc
        dsTatCaMonHoc = (New MonHocBUS).LayDanhSach()
        '      lâìy ds tâìt caÒ lõìp hoòc
        dsLopHoc = (New LopHocBUS).LayDanhSach()

        '      khõÒi taòo caìc datagrid
        TaoGridDsGV()
        TaoGridLichDay()

        LoadDsGiaoVien()
    End Sub
    Private Sub TaoGridLichDay()
        With gridLichDay
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = False
            .RowHeadersVisible = False
            .ReadOnly = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            .Columns.Add("Tiet", "Tiết")
            .Columns(0).Width = 40
            .Columns(0).DefaultCellStyle.BackColor = Color.SkyBlue

            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(0).ReadOnly = True

            .Columns.Add("ThuHai", "Thứ hai")
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add("ThuBa", "Thứ ba")
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add("ThuTu", "Thứ tư")
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add("ThuNam", "Thứ năm")
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add("ThuSau", "Thứ sáu")
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add("ThuBay", "Thứ bảy")
            .Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add("ChuNhat", "Chủ Nhật")
            .Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable

            For i As Integer = 1 To ThamSo.SoTietToiDaTrongNgay
                .Rows.Add(i.ToString())
            Next


        End With
    End Sub

    Private Sub LoadLichRanh()
        Dim LichRanh As ArrayList = (New RangBuocGiaoVienBUS).LayDanhSachTheoMaGiaoVien(txtMaGiaoVien.Text)


        For Each rblh As RangBuocGiaoVienDTO In LichRanh
            Dim i As Integer = rblh.Thu - 1
            Dim j As Integer = rblh.TietHoc - 1
            Dim cell As DataGridViewCell = gridLichDay(i, j)

            cell.Value = Nothing

            If (rblh.TrangThai = 1) Then
                cell.Style.BackColor = Color.Red
            ElseIf rblh.TrangThai = 0 Then
                If (j < ThamSo.TietGay) Then
                    cell.Style.BackColor = Color.PaleTurquoise
                Else
                    cell.Style.BackColor = Color.White
                End If
            ElseIf rblh.TrangThai = 2 Then
                cell.Style.BackColor = Color.Gray
            End If
        Next

    End Sub

    Private Sub LoadThongTinGiaoVien()
        Dim tongSoTietDay As Integer = 0

        Dim monPhuTrach As New List(Of String)()

        Dim ThongTin As ArrayList = (New PhanCongBUS).LayDanhSachTheoMaGiaoVien(txtMaGiaoVien.Text)

        dsLopPhuTrach = New ArrayList()
        txtMonPhuTrach.Text = ""

        For Each pc As PhanCongDTO In ThongTin
            Dim lop As New LopHoc()
            lop.pc = pc

            For Each mh As MonHocDTO In dsTatCaMonHoc
                If (mh.MaMonHoc = pc.MaMonHoc) Then
                    lop.mh = mh
                    Exit For
                End If
            Next

            For Each lh As LopHocDTO In dsLopHoc
                If (lh.MaLopHoc = pc.MaLopHoc) Then
                    lop.lh = lh
                    Exit For
                End If
            Next
            dsLopPhuTrach.Add(lop)

            tongSoTietDay += pc.SoTietHocTuan
            If (monPhuTrach.Contains(pc.MaMonHoc) = False) Then
                monPhuTrach.Add(pc.MaMonHoc)

                txtMonPhuTrach.Text += lop.mh.TenMonHoc & ","

            End If
        Next

        txtTongSoTietDay.Text = tongSoTietDay.ToString()

    End Sub

    Private Sub LoadLichDay()
        Dim LichDay As ArrayList = (New LichLopHocBUS).LayLichDayGiaoVien(txtMaGiaoVien.Text)

        ' load thõÌi khoìa biêÒu cuÒa lõìp ðang choòn
        For Each lh As LichLopHocDTO In LichDay
            For Each lop As LopHoc In dsLopPhuTrach
                If (lop.pc.MaPhanCong = lh.MaPhanCong) Then
                    Dim col As Integer = lh.Thu - 1
                    Dim row As Integer = lh.TietHocBatDau - 1
                    Dim cell As DataGridViewCell = gridLichDay(col, row)

                    cell.Value = lop.ToString()

                    If (lh.SoTietHoc > 1) Then
                        For i As Integer = 1 To lh.SoTietHoc - 1
                            gridLichDay(col, row + i).Value = lop.ToString()
                        Next
                    End If

                    Exit For

                End If
            Next
        Next
    End Sub

    Private Sub TaoGridDsGV()
        With gridDsGiaoVien
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = False
            .RowHeadersVisible = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            .Columns.Add("STT", "STT")
            .Columns(0).Width = 40
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).DefaultCellStyle.BackColor = Color.SkyBlue
            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add("MaGiaoVien", "Mã giáo viên")
            .Columns(1).Visible = False

            .Columns.Add("HoTenGiaoVien", "Họ tên giáo viên")
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add("TenTat", "Tên tắt")
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable


        End With
    End Sub

    Private Sub LoadDsGiaoVien()
        Dim dsGiaoVien As ArrayList = (New GiaoVienBUS).LayDanhSach()

        For i As Integer = 0 To dsGiaoVien.Count - 1
            Dim gv As GiaoVienDTO = dsGiaoVien(i)
            cmbTenGiaoVien.Items.Add(gv)
            gridDsGiaoVien.Rows.Add((i + 1), gv.MaGiaoVien, gv.HoTenGiaoVien, gv.TenTat)

        Next

    End Sub

    Private Sub gridDsGiaoVien_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridDsGiaoVien.SelectionChanged
        If (gridDsGiaoVien.SelectedRows.Count <> 0) Then
            Dim selectRow As DataGridViewRow = gridDsGiaoVien.SelectedRows(0)
            txtMaGiaoVien.Text = selectRow.Cells("MaGiaoVien").Value
            txtTenTat.Text = selectRow.Cells("TenTat").Value

            cmbTenGiaoVien.SelectedIndex = selectRow.Index

            LoadLichRanh()
            LoadThongTinGiaoVien()
            LoadLichDay()
        End If

    End Sub


    Private Sub cmbTenGiaoVien_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTenGiaoVien.SelectedIndexChanged
        gridDsGiaoVien.Rows(cmbTenGiaoVien.SelectedIndex).Selected = True

    End Sub

    Private Sub btnGvtruoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGvtruoc.Click
        Dim index As Integer = gridDsGiaoVien.SelectedRows(0).Index
        If (index > 0) Then
            gridDsGiaoVien.Rows(index - 1).Selected = True
        End If

    End Sub

    Private Sub btnGvsau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGvsau.Click
        Dim index As Integer = gridDsGiaoVien.SelectedRows(0).Index
        If (index < gridDsGiaoVien.Rows.Count - 1) Then
            gridDsGiaoVien.Rows(index + 1).Selected = True
        End If

    End Sub


    Private Sub btnXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuat.Click
        CoCapNhat = False

        If (gridLichDay Is Nothing) Then
            Throw New ArgumentNullException("No DataGridView was provided for export")
        End If

        Using saveFileDialog As SaveFileDialog = GetExcelSaveFileDialog()
            If (saveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                Dim fileName As String = saveFileDialog.FileName
                ExcelGenerator.Generate(gridLichDay).Save(fileName)
                Process.Start(fileName)
            End If
        End Using
    End Sub
    ' TẠO DIALOG XUẤT FILE EXCEL
    Private Function GetExcelSaveFileDialog() As SaveFileDialog
        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.CheckPathExists = True
        saveFileDialog.AddExtension = True
        saveFileDialog.ValidateNames = True
        saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        saveFileDialog.DefaultExt = ".xls"
        saveFileDialog.Filter = "Microsoft Excel Workbook (*.xls)|*.xls"
        saveFileDialog.RestoreDirectory = True
        Return saveFileDialog
    End Function
End Class