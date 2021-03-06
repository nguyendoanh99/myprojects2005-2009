Imports BUS
Imports DTO
Imports System.Windows.Forms

Public Class frmTKBLH

    Private Class MonHoc
        Public mh As MonHocDTO
        Public gv As GiaoVienDTO
        Public pc As PhanCongDTO

        Public Sub New()
            mh = Nothing
            gv = Nothing
            pc = Nothing

        End Sub

        Public Overrides Function ToString() As String
            Return mh.TenMonHoc & " (" & gv.TenTat & ")"
        End Function
    End Class

    'tham sôì duÌng trong chýõng triÌnh
    Private ThamSo As ThamSoDTO
    ' danh saìch tâìt caÒ môn hoòc
    Private dsTatCaMonHoc As ArrayList
    ' danh saìch tâìt caÒ giaìo viên
    Private dsGiaoVien As ArrayList

    Private Sub frmThoiKhoaBieuLopHoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' lâìy tham sôì
        ThamSo = (New ThamSoBUS).LayThamSo()
        'lâìy ds môn hoòc
        dsTatCaMonHoc = (New MonHocBUS).LayDanhSach()
        'lâìy ds giaìo viên
        dsGiaoVien = (New GiaoVienBUS).LayDanhSach()
        ' khõÒi taòo cho datagridview TKBLH
        TaoGridTKBLH()
        ' mãòc ðiònh choòn tâìt caÒ caìc lõìp hoòc
        rdTatCa.Checked = True
    End Sub

    Private Sub rdTatCa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTatCa.CheckedChanged
        If (rdTatCa.Checked = True) Then
            LoadComboboxTenLopHoc()
        End If

    End Sub

    Private Sub rd12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rd12.CheckedChanged
        If (rd12.Checked = True) Then
            LoadComboboxTenLopHoc()
        End If
    End Sub

    Private Sub rd11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rd11.CheckedChanged
        If (rd11.Checked = True) Then
            LoadComboboxTenLopHoc()
        End If
    End Sub

    Private Sub rd10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rd10.CheckedChanged
        If (rd10.Checked = True) Then
            LoadComboboxTenLopHoc()
        End If
    End Sub

    ' khi choòn lõìp hoòc
    Private Sub cmbTenLopHoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTenLopHoc.SelectedIndexChanged
        If (cmbTenLopHoc.SelectedIndex > -1) Then
            Dim lop As LopHocDTO = cmbTenLopHoc.Items.Item(cmbTenLopHoc.SelectedIndex)
            txtMaLopHoc.Text = lop.MaLopHoc
        End If

    End Sub

    ' khi lõìp hoòc thay ðôÒi
    ' load laòi liòch týõng ýìng võìi môn hoòc ðoì
    Private Sub txtMaLopHoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaLopHoc.TextChanged
        LoadLichRanh(txtMaLopHoc.Text)
        LoadLichHoc(txtMaLopHoc.Text)
    End Sub

    Private Sub TaoGridTKBLH()
        With gridTKBLH
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True

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

            .RowHeadersVisible = False

            For i As Integer = 1 To ThamSo.SoTietToiDaTrongNgay
                .Rows.Add(i.ToString())
            Next

            .ClearSelection()
        End With
    End Sub

    Private Sub LoadComboboxTenLopHoc()
        Dim dsLop As New ArrayList
        Dim bsLop As New LopHocBUS
        If (rdTatCa.Checked = True) Then
            dsLop = bsLop.LayDanhSach()
        ElseIf rd10.Checked = True Then
            dsLop = bsLop.LayDanhSachLopKhoi10()
        ElseIf rd11.Checked = True Then
            dsLop = bsLop.LayDanhSachLopKhoi11()
        ElseIf rd12.Checked = True Then
            dsLop = bsLop.LayDanhSachLopKhoi12()
        End If

        cmbTenLopHoc.Items.Clear()
        cmbTenLopHoc.Items.AddRange(dsLop.ToArray())
        cmbTenLopHoc.SelectedIndex = 0

    End Sub

    Private Sub LoadLichRanh(ByVal malophoc As String)
        ' lâìy liòch raÒnh cuÒa lõìp ðýõòc choòn
        ' ðôÌng thõÌi xoìa giaì triò cuÞ cuÒa caìc ô trong datagridview
        Dim LichRanh As ArrayList = (New RangBuocLopHocBUS).LayRBLHLop(malophoc)

        For Each rblh As RangBuocLopHocDTO In LichRanh
            Dim i As Integer = rblh.Thu - 1
            Dim j As Integer = rblh.TietHoc - 1
            Dim cell As DataGridViewCell = gridTKBLH(i, j)

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

    Private Sub LoadLichHoc(ByVal malophoc As String)
        Dim tkbLopHoc As ArrayList = (New LichLopHocBUS).LayLichLopHoc(malophoc)
        Dim dsPhanCong As ArrayList = (New PhanCongBUS).LayDanhSachTheoMaLopHoc(malophoc)

        ' load ds môn hoòc vaÌ giaìo viên daòy týõng ýìng cuÒa môn ðoì cho lõìp hoòc ðang choòn
        Dim dsMonHoc As New ArrayList()
        For Each pc As PhanCongDTO In dsPhanCong
            Dim mon As New MonHoc()
            mon.pc = pc

            For Each mh As MonHocDTO In dsTatCaMonHoc
                If (mh.MaMonHoc = pc.MaMonHoc) Then
                    mon.mh = mh
                    Exit For
                End If
            Next

            For Each gv As GiaoVienDTO In dsGiaoVien
                If (gv.MaGiaoVien = pc.MaGiaoVien) Then
                    mon.gv = gv
                    Exit For
                End If
            Next
            dsMonHoc.Add(mon)
        Next

        ' load thõÌi khoìa biêÒu cuÒa lõìp ðang choòn
        For Each lh As LichLopHocDTO In tkbLopHoc
            For Each mon As MonHoc In dsMonHoc
                If (mon.pc.MaPhanCong = lh.MaPhanCong) Then
                    Dim col As Integer = lh.Thu - 1
                    Dim row As Integer = lh.TietHocBatDau - 1
                    Dim cell As DataGridViewCell = gridTKBLH(col, row)

                    cell.Value = mon.ToString()

                    If (lh.SoTietHoc > 1) Then
                        For i As Integer = 1 To lh.SoTietHoc - 1
                            gridTKBLH(col, row + i).Value = mon.ToString()
                        Next
                    End If

                    Exit For

                End If
            Next
        Next

    End Sub

    Private Sub btnXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuat.Click
        CoCapNhat = False

        If (gridTKBLH Is Nothing) Then
            Throw New ArgumentNullException("No DataGridView was provided for export")
        End If

        Using saveFileDialog As SaveFileDialog = GetExcelSaveFileDialog()
            If (saveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                Dim fileName As String = saveFileDialog.FileName
                ExcelGenerator.Generate(gridTKBLH).Save(fileName)
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