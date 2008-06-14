Imports BUS
Imports DTO
Imports System.Windows.Forms



Public Class frmPCTheoLopHoc

    Dim SoLoi As Integer = 0
    Dim strLoi As String = "<unknown>"
    Dim colorLoi As Color = Color.Red
    Dim colorXoa As Color = Color.Pink
    Dim colorCapNhat As Color = Color.Green
    Dim colorThem As Color = Color.Blue

    Dim delta As Integer = 0    'cho phép thêm dellta = 1, ngược lại delta = 0





    'LOAD FORM
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCheckBoxListMonHoc()
        LoadDanhSachGiaoVien()
        ckblistMonHoc.Enabled = False
    End Sub

    Private Sub LoadCheckBoxListMonHoc()
        Dim arrMonHoc As ArrayList
        arrMonHoc = (New MonHocBUS).LayDanhSach()

        For i As Integer = 0 To arrMonHoc.Count - 1
            Dim mh As New MonHocDTO
            mh = arrMonHoc.Item(i)
            ckblistMonHoc.Items.Add(mh)
        Next
    End Sub

    Private Sub LoadDanhSachGiaoVien()
        Dim _gvBus As New GiaoVienBUS
        Dim _gvDanhSach As ArrayList = _gvBus.LayDanhSach()

        For i As Integer = 0 To _gvDanhSach.Count - 1
            Dim gv As GiaoVienDTO = _gvDanhSach.Item(i)
            gridDSGiaoVien.Rows.Add()
            gridDSGiaoVien.Rows(i).Cells("colSTT").Value = i + 1
            gridDSGiaoVien.Rows(i).Cells("colMaGiaoVien").Value = gv.MaGiaoVien
            gridDSGiaoVien.Rows(i).Cells("colHoTen").Value = gv.HoTenGiaoVien
            gridDSGiaoVien.Rows(i).Cells("colTenTat").Value = gv.TenTat
        Next
    End Sub

    Private Sub gridDSGiaoVien_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridDSGiaoVien.SelectionChanged
        If gridDSGiaoVien.SelectedRows.Count = 0 Then
            Return
        End If

        'kiểm tra cờ cập nhật
        If FLAG.CoCapNhat = True Then
            If (MessageBox.Show("Bạn có muốn cập nhật lại dữ liệu không?", _
                "Đồng bào chú ý!", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                CapNhat()
            End If
        End If
        FLAG.CoCapNhat = False
        'Xoa thong tin 
        gridBangPhanCong.Rows.Clear()

        'Lay bang phan cong theo ma lop hoc 
        Dim _pcBus As New PhanCongBUS()
        Dim _maLop As String = txtMaLH.Text
        Dim _selectedRow As DataGridViewRow = gridDSGiaoVien.SelectedRows(0)
        Dim _maGiaoVien As String = _selectedRow.Cells("colMaGiaoVien").Value

        If _maGiaoVien Is Nothing Then
            Return
        End If

        Dim _pcBang As DataTable = _pcBus.LayBangTheoLopHocVaGiaoVien(_maLop, _maGiaoVien)

        'Hien thi bang phan cong va check vao checkbox list
        LoadBangPhanCongVaCheckboxList(_pcBang)
        SoLoi = 0
    End Sub

    'BIEN CO 1 : chon khoi 10
    Private Sub rb10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb10.CheckedChanged

        'kiểm tra cờ cập nhật
        If FLAG.CoCapNhat = True Then
            If (MessageBox.Show("Bạn có muốn cập nhật lại dữ liệu không?", _
                "Đồng bào chú ý!", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                CapNhat()
            End If
        End If
        FLAG.CoCapNhat = False

        ckblistMonHoc.Enabled = False     'disabled list môn học

        'Xoa thong tin cu
        txtMaLH.Text = ""
        For i As Integer = 0 To ckblistMonHoc.Items.Count - 1
            ckblistMonHoc.SetItemChecked(i, False)
        Next
        gridBangPhanCong.Rows.Clear()

        'Hien thi lai
        Dim _lhBus As New LopHocBUS()
        Dim _maKhoi As String = "K10"
        Dim _ds As DataTable = _lhBus.LayDanhSachTheoKhoi(_maKhoi)
        cbTenLH.DataSource = _ds
        cbTenLH.ValueMember = "MaLopHoc"
        cbTenLH.DisplayMember = "TenLopHoc"
    End Sub

    'BIEN CO 2 : chon khoi 11
    Private Sub rb11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb11.CheckedChanged
        'kiểm tra cờ cập nhật
        If FLAG.CoCapNhat = True Then
            If (MessageBox.Show("Bạn có muốn cập nhật lại dữ liệu không?", _
                "Đồng bào chú ý!", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                CapNhat()
            End If
        End If
        FLAG.CoCapNhat = False

        ckblistMonHoc.Enabled = False     'disabled list môn học

        'Xoa thong tin cu
        txtMaLH.Text = ""
        For i As Integer = 0 To ckblistMonHoc.Items.Count - 1
            ckblistMonHoc.SetItemChecked(i, False)
        Next
        gridBangPhanCong.Rows.Clear()

        'Hien thi lai
        Dim _lhBus As New LopHocBUS()
        Dim _maKhoi As String = "K11"
        Dim _ds As DataTable = _lhBus.LayDanhSachTheoKhoi(_maKhoi)
        cbTenLH.DataSource = _ds
        cbTenLH.ValueMember = "MaLopHoc"
        cbTenLH.DisplayMember = "TenLopHoc"
    End Sub

    'BIEN CO 3 : chon khoi 12
    Private Sub rd12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rd12.CheckedChanged
        'kiểm tra cờ cập nhật
        If FLAG.CoCapNhat = True Then
            If (MessageBox.Show("Bạn có muốn cập nhật lại dữ liệu không?", _
                "Đồng bào chú ý!", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                CapNhat()
            End If
        End If
        FLAG.CoCapNhat = False

        ckblistMonHoc.Enabled = False     'disabled list môn học

        'Xoa thong tin cu
        txtMaLH.Text = ""
        For i As Integer = 0 To ckblistMonHoc.Items.Count - 1
            ckblistMonHoc.SetItemChecked(i, False)
        Next
        gridBangPhanCong.Rows.Clear()

        'Hien thi lai
        Dim _lhBus As New LopHocBUS()
        Dim _maKhoi As String = "K12"
        Dim _ds As DataTable = _lhBus.LayDanhSachTheoKhoi(_maKhoi)
        cbTenLH.DataSource = _ds
        cbTenLH.ValueMember = "MaLopHoc"
        cbTenLH.DisplayMember = "TenLopHoc"
    End Sub

    'BIEN CO 4 : chọn tất cả
    Private Sub rbTatCa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTatCa.CheckedChanged
        'kiểm tra cờ cập nhật
        If FLAG.CoCapNhat = True Then
            If (MessageBox.Show("Bạn có muốn cập nhật lại dữ liệu không?", _
                "Đồng bào chú ý!", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                CapNhat()
            End If
        End If
        FLAG.CoCapNhat = False

        ckblistMonHoc.Enabled = False     'disabled list môn học

        'Xoa thong tin cu
        txtMaLH.Text = ""
        For i As Integer = 0 To ckblistMonHoc.Items.Count - 1
            ckblistMonHoc.SetItemChecked(i, False)
        Next
        gridBangPhanCong.Rows.Clear()

        'Hien thi lai
        Dim _lhBus As New LopHocBUS()
        Dim _ds As DataTable = _lhBus.LayBang()
        cbTenLH.DataSource = _ds
        cbTenLH.ValueMember = "MaLopHoc"
        cbTenLH.DisplayMember = "TenLopHoc"
    End Sub

    'BIEN CO 5 : chon mot lop hoc
    Private Sub cbTenLH_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTenLH.DropDownClosed

        'kiểm tra cờ cập nhật
        If FLAG.CoCapNhat = True Then
            If (MessageBox.Show("Bạn có muốn cập nhật lại dữ liệu không?", _
                "Đồng bào chú ý!", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                CapNhat()
            End If
        End If
        FLAG.CoCapNhat = False
        SoLoi = 0

        ckblistMonHoc.Enabled = True    'enabled lại list môn học

        'Xoa thong tin 
        txtMaLH.Text = ""
        For i As Integer = 0 To ckblistMonHoc.Items.Count - 1
            ckblistMonHoc.SetItemChecked(i, False)
        Next
        gridBangPhanCong.Rows.Clear()

        'Hien thi thong tin moi
        HienThiThongTinTheoLopHoc() 'lop hoc duoc chon trong combobox
    End Sub



    'BIEN CO 7 : nhan nut lop hoc ke truoc 
    Private Sub butLHKeTruoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butLHKeTruoc.Click

        'kiểm tra cờ cập nhật
        If coCapNhat = True Then
            If (MessageBox.Show("Bạn có muốn cập nhật lại dữ liệu không?", _
                "Đồng bào chú ý!", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                CapNhat()
            End If
        End If
        coCapNhat = False

        'Xoa thong tin 
        txtMaLH.Text = ""
        For i As Integer = 0 To ckblistMonHoc.Items.Count - 1
            ckblistMonHoc.SetItemChecked(i, False)
        Next
        gridBangPhanCong.Rows.Clear()

        'Load lop hoc moi len combobox
        If (cbTenLH.SelectedIndex = 0) Then
            cbTenLH.SelectedIndex = cbTenLH.Items.Count - 1
        Else
            cbTenLH.SelectedIndex = cbTenLH.SelectedIndex - 1
        End If

        HienThiThongTinTheoLopHoc() 'lop hoc duoc chon trong combobox
    End Sub

    'BIEN CO 8 : nhan nut lop hoc tiep theo
    Private Sub butLHTiepTheo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butLHTiepTheo.Click

        'kiểm tra cờ cập nhật
        If coCapNhat = True Then
            If (MessageBox.Show("Bạn có muốn cập nhật lại dữ liệu không?", _
                "Đồng bào chú ý!", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                CapNhat()
            End If
        End If
        coCapNhat = False

        'Xoa thong tin 
        txtMaLH.Text = ""
        For i As Integer = 0 To ckblistMonHoc.Items.Count - 1
            ckblistMonHoc.SetItemChecked(i, False)
        Next
        gridBangPhanCong.Rows.Clear()

        'Load lop hoc moi len combobox
        If (cbTenLH.SelectedIndex = cbTenLH.Items.Count - 1) Then
            cbTenLH.SelectedIndex = 0
        Else
            cbTenLH.SelectedIndex = cbTenLH.SelectedIndex + 1
        End If

        HienThiThongTinTheoLopHoc() 'lop hoc duoc chon trong combobox
    End Sub

    'BIEN CO 9 : Nhấn nút cập nhật
    Private Sub butCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCapNhat.Click
        CapNhat()

        'Xoa thong tin 
        ' txtMaLH.Text = ""
        'For i As Integer = 0 To ckblistMonHoc.Items.Count - 1
        'ckblistMonHoc.SetItemChecked(i, False)
        'Next

        coCapNhat = False
        'gridBangPhanCong.Rows.Clear()
        'HienThiThongTinTheoLopHoc()
    End Sub

    'BIEN CO 10 : Người dùng thêm, xoá môn học cho một lớp
    Private Sub ckblistMonHoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckblistMonHoc.SelectedIndexChanged
        coCapNhat = True    ' đánh dấu đã có sự thay đổi dữ liệu

        Dim _MHDto As MonHocDTO = ckblistMonHoc.SelectedItem()

        'Load lên các bảng PHUTRACH, LICHLOPHOC, 
        If ckblistMonHoc.GetItemChecked(ckblistMonHoc.SelectedIndex) = False Then   'Xóa phan cong
            Dim i As Integer = 0
            Dim nextorder As Integer = 1
            While i < gridBangPhanCong.Rows.Count - delta
                Dim row As DataGridViewRow = gridBangPhanCong.Rows(i)
                If row.Cells("colMaMonHoc").Value = _MHDto.MaMonHoc Then
                    If row.Cells("colSTT1").Value.ToString() <> "Thêm" Then
                        row.Cells("colSTT1").Value = "Xóa"
                        row.Cells("colSTT1").Style.BackColor = colorXoa
                        row.ReadOnly = True

                    Else
                        gridBangPhanCong.Rows.Remove(row)
                        CapNhatSoLoi(row)
                        Continue While
                    End If
                End If

                i += 1
            End While

        Else 'Thêm phan cong cho lop hoc

            Dim flag As Boolean = False

            With gridBangPhanCong
                For i As Integer = 0 To .Rows.Count - 2
                    Dim row As DataGridViewRow = gridBangPhanCong.Rows(i)
                    If row.Cells("colMaMonHoc").Value = _MHDto.MaMonHoc Then
                        If row.Cells("colSTT1").Value.ToString() = "Xóa" Then
                            row.Cells("colSTT1").Value = "Cập nhật"
                            row.Cells("colSTT1").Style.BackColor = colorCapNhat
                            row.ReadOnly = False
                            flag = True
                            Exit For
                        End If
                    End If
                Next

                If flag = False Then
                    Dim index As Integer = .Rows.Count - delta
                    .Rows.Add()

                    .Rows(index).Cells("colGiaoVien").Value = strLoi
                    .Rows(index).Cells("colTongSoTiet").Value = strLoi

                    Dim monhoc As MonHocDTO = (New MonHocBUS).LayThongTinCoMa(_MHDto.MaMonHoc)
                    .Rows(index).Cells("colSTHLTTT").Value = monhoc.QuyDinhSoTietHocLienTiepToiThieu
                    .Rows(index).Cells("colSTHLTTD").Value = monhoc.QuyDinhSoTietHocLienTiepToiDa

                    .Rows(index).Cells("colSBHTT").Value = strLoi
                    .Rows(index).Cells("colSBHTD").Value = strLoi


                    .Rows(index).Cells("colGiaoVien").Style.BackColor = colorLoi
                    .Rows(index).Cells("colTongSoTiet").Style.BackColor = colorLoi

                    .Rows(index).Cells("colSBHTT").Style.BackColor = colorLoi
                    .Rows(index).Cells("colSBHTD").Style.BackColor = colorLoi

                    SoLoi += 4

                    '.Rows(index).Cells("STT").Value = index + 1
                    .Rows(index).Cells("colSTT1").Value = "Thêm"
                    .Rows(index).Cells("colSTT1").Style.BackColor = colorThem

                    .Rows(index).Cells("colMaLopHoc").Value = cbTenLH.SelectedValue
                    .Rows(index).Cells("colLopHoc").Value = cbTenLH.Text
                    .Rows(index).Cells("colMaMonHoc").Value = _MHDto.MaMonHoc
                    .Rows(index).Cells("colMonHoc").Value = _MHDto.TenMonHoc
                End If

            End With
            ' Next
        End If
        gridBangPhanCong.Columns("colSTT1").SortMode = DataGridViewColumnSortMode.NotSortable


    End Sub

    'BIEN CO 11 : 
    Private Sub gridBangPhanCong_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBangPhanCong.CellEndEdit
        coCapNhat = True

        With gridBangPhanCong
            Dim row As DataGridViewRow = .Rows(e.RowIndex)

            Select Case .Columns(e.ColumnIndex).Name


                Case "colGiaoVien"
                    Dim tengiaovien As String = row.Cells("colGiaoVien").Value

                    If String.IsNullOrEmpty(tengiaovien) Then
                        If row.Cells("colGiaoVien").Style.BackColor = colorLoi Then
                            row.Cells("colLopHoc").Value = strLoi
                        Else
                            row.Cells("colGiaoVien").Style.BackColor = colorLoi
                            row.Cells("colGiaoVien").Value = strLoi
                            SoLoi += 1
                        End If
                    Else
                        Dim arrMaGiaoVien As ArrayList = (New GiaoVienBUS).LayMaGiaoVienCoTen(tengiaovien)
                        If arrMaGiaoVien.Count = 0 Then 'Ko có lớp học nào có tên như zị
                            If row.Cells("colGiaoVien").Style.BackColor = colorLoi Then
                            Else
                                row.Cells("colGiaoVien").Style.BackColor = colorLoi
                                row.Cells("colGiaoVien").Value = strLoi
                                SoLoi += 1
                            End If
                        Else
                            'Gán giá trị cho cell MaLopHoc
                            row.Cells("colMaGV").Value = arrMaGiaoVien(0)

                            Dim arrMH As ArrayList = (New PhuTrachBUS).LayMonHocGiaoVienDay(row.Cells("colMaGV").Value)
                            Dim flag As Boolean = False
                            For Each mh As String In arrMH
                                If mh = row.Cells("colMaMonHoc").Value Then
                                    flag = True
                                    Exit For
                                End If
                            Next
                            If flag = False Then
                                MessageBox.Show("Giáo viên " + tengiaovien + " không phụ phụ trách môn học " _
                                        + row.Cells("colMonHoc").Value)
                                Return


                            End If


                            'Báo hiệu dữ liệu có thay đổi -> đánh dấu 'cập nhật"
                            If row.Cells("colSTT1").Value.ToString() <> "Thêm" And _
                                row.Cells("colSTT1").Value.ToString() <> "Cập nhật" Then
                                row.Cells("colSTT1").Value = "Cập nhật"
                                row.Cells("colSTT1").Style.BackColor = colorCapNhat
                            End If

                            If row.Cells("colGiaoVien").Style.BackColor = colorLoi Then
                                row.Cells("colGiaoVien").Style.BackColor = Color.White
                                SoLoi -= 1
                            End If
                        End If
                    End If



                Case "colTongSoTiet"
                    Dim giatri As Byte = 0
                    If Not Byte.TryParse(row.Cells(e.ColumnIndex).Value, giatri) Then
                        If row.Cells(e.ColumnIndex).Style.BackColor = colorLoi Then
                            row.Cells("colLopHoc").Value = strLoi
                        Else
                            row.Cells(e.ColumnIndex).Style.BackColor = colorLoi
                            row.Cells(e.ColumnIndex).Value = strLoi
                            SoLoi += 1
                        End If
                    Else
                        row.Cells("colSBHTT").Value = Math.Round(row.Cells("colTongSoTiet").Value / row.Cells("colSTHLTTD").Value + 0.5, 0)
                        row.Cells("colSBHTD").Value = Math.Round(row.Cells("colTongSoTiet").Value / row.Cells("colSTHLTTT").Value + 0.5, 0)

                        row.Cells("colSBHTT").Style.BackColor = Color.White
                        row.Cells("colSBHTD").Style.BackColor = Color.White

                        SoLoi -= 2

                        'Báo hiệu dữ liệu có thay đổi -> đánh dấu 'cập nhật"
                        If row.Cells("colSTT1").Value.ToString() <> "Thêm" And _
                                 row.Cells("colSTT1").Value.ToString() <> "Cập nhật" Then
                            row.Cells("colSTT1").Value = "Cập nhật"
                            row.Cells("colSTT1").Style.BackColor = colorCapNhat
                        End If

                        If row.Cells(e.ColumnIndex).Style.BackColor = colorLoi Then
                            row.Cells(e.ColumnIndex).Style.BackColor = Color.White
                            SoLoi -= 1
                        End If
                    End If


            End Select


        End With

    End Sub

    'BIEN CO 12 : Nhấn nút xuất ra file
    Private Sub butXuatFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butXuatFile.Click

        'kiểm tra cờ cập nhật
        If coCapNhat = True Then
            If (MessageBox.Show("Bạn có muốn cập nhật lại dữ liệu không?", _
                "Đồng bào chú ý!", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                CapNhat()
            End If
        End If
        coCapNhat = False

        If (gridBangPhanCong Is Nothing) Then
            Throw New ArgumentNullException("No DataGridView was provided for export")
        End If

        Using saveFileDialog As SaveFileDialog = GetExcelSaveFileDialog()
            If (saveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                Dim fileName As String = saveFileDialog.FileName
                ExcelGenerator.Generate(gridBangPhanCong).Save(fileName)
                Process.Start(fileName)
            End If
        End Using
    End Sub




    'HAM HO TRO
    Private Sub HienThiThongTinTheoLopHoc()
        'Hien thi ma lop hoc
        txtMaLH.Text = cbTenLH.SelectedValue()

        'Lay bang phan cong theo ma lop hoc 
        Dim _pcBus As New PhanCongBUS()
        Dim _maLop As String = txtMaLH.Text
        Dim _pcBang As DataTable = _pcBus.LayBangTheoLopHoc(_maLop)

        'Hien thi bang phan cong va check vao checkbox list
        LoadBangPhanCongVaCheckboxList(_pcBang)

    End Sub

    Private Sub LoadBangPhanCongVaCheckboxList(ByVal _pcBang As DataTable)
        Dim i As Integer = 0
        For Each _row As DataRow In _pcBang.Rows

            gridBangPhanCong.Rows.Add()
            gridBangPhanCong.Rows(i).Cells(0).Value = Integer.Parse(i + 1)  'STT
            For j As Integer = 0 To _pcBang.Columns.Count - 1    'bỏ cột mã lớp học                        
                gridBangPhanCong.Rows(i).Cells(j + 1).Value = _row(j)
            Next

            For k As Integer = 0 To ckblistMonHoc.Items.Count - 1
                Dim _mhDto As MonHocDTO = ckblistMonHoc.Items.Item(k)
                If gridBangPhanCong.Rows(i).Cells("colMaMonHoc").Value = _mhDto.MaMonHoc Then
                    ckblistMonHoc.SetItemChecked(k, True)
                End If
            Next

            i += 1

        Next
    End Sub

    'Cập nhật số lỗi trên bảng phân công
    Private Sub CapNhatSoLoi(ByVal row As DataGridViewRow)
        For Each cell As DataGridViewCell In row.Cells
            If cell.Style.BackColor = colorLoi Then
                SoLoi -= 1
            End If
        Next
    End Sub

    'Tạo dialog xuất file exel
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

    'Cập nhật
    Private Sub CapNhat()
        If SoLoi <> 0 Then
            MessageBox.Show("Không thể cập nhật, do lỗi trên bảng phân công" + vbCrLf + "Số lỗi : " + SoLoi.ToString())
            Return
        End If

        With gridBangPhanCong
            For i As Integer = 0 To .Rows.Count - delta - 1
                Dim row As DataGridViewRow = .Rows(i)

                Dim pc As New PhanCongDTO
                pc.MaLopHoc = row.Cells("colMaLopHoc").Value
                pc.MaMonHoc = row.Cells("colMaMonHoc").Value
                pc.MaGiaoVien = row.Cells("colMaGV").Value
                pc.SoTietHocTuan = row.Cells("colTongSoTiet").Value
                pc.SoTietHocLienTiepToiThieu = row.Cells("colSTHLTTT").Value
                pc.SoTietHocLienTiepToiDa = row.Cells("colSTHLTTD").Value
                pc.SoBuoiHocToiThieu = row.Cells("colSBHTT").Value
                pc.SoBuoiHocToiDa = row.Cells("colSBHTD").Value

                Dim phancongbus As New PhanCongBUS

                If row.Cells("colSTT1").Value.ToString() = "Thêm" Then  'Them moi
                    pc.MaPhanCong = (New DuLieuBUS).TaoMaPhanCong()
                    phancongbus.ThemDong(pc)

                ElseIf row.Cells("colSTT1").Value.ToString() = "Cập nhật" Then 'CapNhat
                    If String.IsNullOrEmpty(pc.MaPhanCong) Then 'Dùng cho trường hợp ng dùng tự tạo thêm dòng mới trong grid phân công
                        pc.MaPhanCong = (New DuLieuBUS).TaoMaPhanCong()
                    End If
                    pc.MaPhanCong = row.Cells("colMaPC").Value
                    phancongbus.CapNhatDong(pc)

                ElseIf row.Cells("colSTT1").Value.ToString() = "Xóa" Then 'Xóa
                    pc.MaPhanCong = row.Cells("colMaPC").Value
                    phancongbus.XoaDong(pc.MaPhanCong)
                End If

            Next
        End With
        MessageBox.Show("Cập nhật thành công")

        gridBangPhanCong.Rows.Clear()
        HienThiThongTinTheoLopHoc()
    End Sub


End Class
