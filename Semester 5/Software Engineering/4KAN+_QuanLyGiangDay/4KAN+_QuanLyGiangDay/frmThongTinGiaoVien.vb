Imports System.Type
Imports system.Data.OleDb
Imports BUS
Imports DTO
Public Class frmThongTinGiaoVien
    
#Region "Khai bao bien: Bien dung chung cho frmThongTinGiaoVien"
    Dim bTaoGiaoVien As Boolean
    Dim bThongTinThayDoi As Boolean
    Dim strThayDoiKhoiTao = "Bạn vừa thay đổi:"
    Dim strThayDoiKetThuc = " Cập nhật thông tin ?"
    Dim strThayDoi As String

    Dim chophepgiugiatri As Boolean
    Dim icurrent As Integer

    Dim gvBus As New GiaoVienBUS()
    Dim ptBus As New PhuTrachBUS()
    Dim rbGVBus As New RangBuocGiaoVienBUS()
    Dim tsBus As New ThamSoBUS()
    Dim mhBus As New MonHocBUS()
    Dim dlBus As New DuLieuBUS()
    Dim pcBus As New PhanCongBUS()

    Dim rbGVDto As RangBuocGiaoVienDTO
    Dim gvDto As GiaoVienDTO
    Dim mhDto As MonHocDTO
#End Region


#Region "Xu Ly frmThongTinGiaoVien"
    Private Sub frmThongTinGiaoVien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bTaoGiaoVien = False
        bThongTinThayDoi = False
        strThayDoi = strThayDoiKhoiTao

        chophepgiugiatri = True

        'Load Cac mon hoc phu trach
        chklibxCacMonHocPhuTrach_Load()

        'Load lich ranh len gridLichRanh
        gridLichRanh_Load()

        'Load danh sach giao vien len gridDSGiaoVien
        gridDSGiaoVien_Load()

        FormatgridDSGiaoVien()
        FormatgridLichRanh()

        'Disable cac control
        setEnableForm(Me, False)

        btnCapNhatDuLieu.Enabled = False
        btnXoaGiaoVien.Enabled = False

        'Set color
        Me.BackColor = Color.AliceBlue

        chklbxMonHoc.BackColor = Color.AliceBlue
        chklbxMonHoc.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub setEnableForm(ByVal frm As UserControl, ByVal enable As Boolean)
        Try
            'For Each t As GroupBox In frm.Controls
            't.Enabled = enable
            'Next
            gbCacMonHocPhuTrach.Enabled = False
            gbThongTinGiaoVien.Enabled = False
            gbLichRanh.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub FormatgridDSGiaoVien()
        With gridDSGiaoVien
            ' Change the Border and Gridline Styles in the Windows Forms DataGridView Control 
            '.GridColor = Color.Blue
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .AllowUserToDeleteRows = False

        End With

        With gridDSGiaoVien.RowsDefaultCellStyle
            .BackColor = Color.LightSkyBlue
        End With

        With gridDSGiaoVien.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Blue
            .ForeColor = Color.Black
            .Font = New Font(gridDSGiaoVien.Font, FontStyle.Bold)
        End With

    End Sub
    Private Sub FormatgridLichRanh()
        With gridLichRanh
            ' Change the Border and Gridline Styles in the Windows Forms DataGridView Control 
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .AllowUserToDeleteRows = False
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

        End With

    End Sub
#Region "Xu Ly gridDSGiaoVien"
    Private Sub LoadData()
        Dim dt As New DataTable
        Dim gvBus As New GiaoVienBUS()

        'Them column STT
        gridDSGiaoVien.Columns.Add("STT", "STT")

        dt = gvBus.LayBang()
        gridDSGiaoVien.DataSource = dt

        gridDSGiaoVien.Sort(gridDSGiaoVien.Columns("HoTenGiaoVien"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub
    Private Sub gridDSGiaoVien_Load()
        Dim dsGV As IList = gvBus.LayDanhSach()
        LoadData()

        With gridDSGiaoVien
            'Doi ten columns
            .Columns("HoTenGiaoVien").HeaderText = "Họ tên giáo viên"
            .Columns("TenTat").HeaderText = "Tên tắt"
            .Columns("DiaChi").HeaderText = "Địa chỉ"
            .Columns("DienThoai").HeaderText = "Điện thoại"
            .Columns("MaGiaoVien").HeaderText = "Mã giáo viên"

            'Sap xep lai vi tri hien thi cua tung column
            .Columns("STT").DisplayIndex = 0

            .RowHeadersVisible = False
            .Columns("MaGiaoVien").Visible = False

            .ClearSelection()
        End With
    End Sub
    Private Sub gridDSGiaoVien_Default()
        gridDSGiaoVien.ClearSelection()
    End Sub

    Private Sub gridDSGiaoVien_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridDSGiaoVien.SelectionChanged
        bTaoGiaoVien = False

        'Neu thay doi cac thong tin ma khong bam btnCapNhatDuLieu
        Dim result As DialogResult
        If bThongTinThayDoi = True Then
            Dim caption As String = "Cập nhật thông tin"
            Dim text As String = strThayDoi + vbNewLine + strThayDoiKetThuc
            result = MessageBox.Show(text, caption, MessageBoxButtons.YesNoCancel)
        End If

        'Neu dong y thi tien hanh cap nhat
        If result = Windows.Forms.DialogResult.Yes Then
            tienhanhCapNhat()
        End If

        If result = Windows.Forms.DialogResult.Cancel Then

        End If

        'Dua Danh sach mon hoc ve mac dinh.
        chklibxCacMonHocPhuTrach_Default()
        'Dua Bang lich ranh ve mac dinh
        gridLichRanh_Default()
        'Dua Thong tin giao vien ve mac dinh
        gbThongTinGiaoVien_Default()

        If gridDSGiaoVien.SelectedRows.Count > 0 Then
            'Enable cac groupBox
            gbCacMonHocPhuTrach.Enabled = True
            gbThongTinGiaoVien.Enabled = True
            gbLichRanh.Enabled = True

            Dim maGV As String = gridDSGiaoVien.SelectedRows(0).Cells("MaGiaoVien").Value

            Dim soluongMonHocPhuTrach As Integer
            Dim dsMonHoc As IList
            Dim dsRbGV As IList

            gvDto = gvBus.LayThongTinGiaoVien(maGV)
            dsMonHoc = ptBus.LayDanhSachMonHoc(maGV)
            dsRbGV = rbGVBus.LayDanhSachRBGV(maGV)

            'Nap thong tin giao vien len cac control tren form
            txtMaGiaoVien.Text = gvDto.MaGiaoVien
            txtHoTenGiaoVien.Text = gvDto.HoTenGiaoVien
            txtTenTat.Text = gvDto.TenTat
            txtDiaChi.Text = gvDto.DiaChi
            txtDienThoai.Text = gvDto.DienThoai

            'Nap mon hoc cua giao vien do len control tren form
            soluongMonHocPhuTrach = ptBus.LaySoLuongMonHoc(maGV)
            For i As Integer = 0 To soluongMonHocPhuTrach - 1
                For j As Integer = 0 To chklbxMonHoc.Items.Count - 1
                    mhDto = dsMonHoc(i)
                    If mhDto.TenMonHoc = chklbxMonHoc.Items.Item(j) Then
                        chklbxMonHoc.SetItemChecked(j, True)
                    End If
                Next
            Next

            'Nap bang lich ranh cua giao vien len gridLichRanh
            For i As Integer = 0 To dsRbGV.Count - 1
                rbGVDto = dsRbGV(i)
                If rbGVDto.TrangThai = 0 Then
                    gridLichRanh.Rows(rbGVDto.TietHoc - 1).Cells(rbGVDto.Thu - 1).Value = "Rảnh"
                ElseIf rbGVDto.TrangThai = 1 Then
                    gridLichRanh.Rows(rbGVDto.TietHoc - 1).Cells(rbGVDto.Thu - 1).Value = "Bận"
                End If
            Next

            'Hien thi nut Xoa Giao Vien len
            btnXoaGiaoVien.Enabled = True
            'btnCapNhatDuLieu.Enabled = True
            btnTaoGiaoVienMoi.Enabled = True

        Else
            '    btnXoaGiaoVien.Enabled = False
            '   btnCapNhatDuLieu.Enabled = False
        End If

        bThongTinThayDoi = False
        strThayDoi = strThayDoiKhoiTao
    End Sub
    Private Sub gridDSGiaoVien_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridDSGiaoVien.Sorted
        Dim SoLuongGV As Integer
        Dim i As Integer

        SoLuongGV = gvBus.LaySoLuong()

        'Them gia tri cho column STT
        With gridDSGiaoVien
            For i = 0 To SoLuongGV - 1
                .Rows(i).Cells("STT").Style.ForeColor = Color.Red

                If .SortOrder = SortOrder.Ascending Then
                    .Rows(i).Cells("STT").Value = i + 1
                ElseIf .SortOrder = SortOrder.Descending Then
                    .Rows(i).Cells("STT").Value = SoLuongGV - i
                End If
            Next
        End With
    End Sub
#End Region

#Region "Xu Ly gridLichRanh"
    Private Sub gridLichRanh_Load()
        Dim dsRBGV As IList
        Dim dsThamSo As DTO.ThamSoDTO

        dsRBGV = rbGVBus.LayDanhSach()
        dsThamSo = tsBus.LayThamSo()

        With gridLichRanh
            'Add column vao gridLichRanh
            .Columns.Add("clTiet", "Tiết")
            .Columns.Add("clThuHai", "Thứ hai")
            .Columns.Add("clThuBa", "Thứ ba")
            .Columns.Add("clThuTu", "Thứ tư")
            .Columns.Add("clThuNam", "Thứ năm")
            .Columns.Add("clThuSau", "Thứ sáu")
            .Columns.Add("clThuBay", "Thứ bảy")
            .Columns.Add("clChuNhat", "Chủ nhật")

            'Add row vao gridLichRanh
            For i As Integer = 0 To dsThamSo.SoTietToiDaTrongNgay - 1
                .Rows.Add()
                .Rows(i).Cells(0).Value = i + 1
                .Rows(i).Cells("clChuNhat").Style.BackColor = Color.Red
            Next

            'Khong cho sort tren cac cot cua gridLichRanh
            For i As Integer = 0 To gridLichRanh.ColumnCount - 1
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            .RowHeadersVisible = False
            .ClearSelection()
        End With
    End Sub
    Private Sub gridLichRanh_Default()
        'Duyet tung cell cua grid va doi gia tri
        Dim iSoDong As Integer = gridLichRanh.Rows.Count
        Dim iSocot As Integer = gridLichRanh.Columns.Count

        For i As Integer = 0 To (iSoDong - 1)
            For j As Integer = 1 To (iSocot - 1)
                If j = iSocot - 1 Then
                    gridLichRanh.Rows(i).Cells(j).Value = "Bận"
                Else
                    gridLichRanh.Rows(i).Cells(j).Value = "Rảnh"
                End If
            Next
        Next

        gridLichRanh.ClearSelection()
    End Sub
    Private Sub gridLichRanh_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridLichRanh.Leave
        gridLichRanh.ClearSelection()
    End Sub

    Private Sub gridLichRanh_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridLichRanh.CellContentClick
        If e.RowIndex = -1 And e.ColumnIndex > 0 Then 'Neu click vao header
            DoiGiaTri1Cot(e.ColumnIndex + 1)
        End If

        If gridLichRanh.SelectedCells.Count > 0 Then
            Dim strCellValue As String
            strCellValue = gridLichRanh.SelectedCells(0).Value

            If e.RowIndex >= 0 Then
                If e.ColumnIndex > 0 Then 'Neu click vao gia tri
                    DoiGia1Cell(strCellValue)
                Else 'Neu click vao gia tri trong cot STT 'If e.ColumnIndex = 0 Then 
                    DoiGiaTri1Dong(Integer.Parse(strCellValue))
                End If
            End If
        End If

        If strThayDoi.IndexOf(" Bảng lịch rảnh") = -1 Then
            strThayDoi += " Bảng lịch rảnh"
        End If
        bThongTinThayDoi = True

        btnCapNhatDuLieu.Enabled = True
    End Sub

    Private Sub DoiGiaTri1Dong(ByVal sttDong As Integer)
        Dim strCellOfRow As String

        For i As Integer = 1 To gridLichRanh.Columns.Count - 1
            strCellOfRow = gridLichRanh.Rows(sttDong - 1).Cells(i).Value
            If strCellOfRow = "Bận" Then
                gridLichRanh.Rows(sttDong - 1).Cells(i).Value = "Rảnh"
            Else
                gridLichRanh.Rows(sttDong - 1).Cells(i).Value = "Bận"
            End If
        Next
    End Sub
    Private Sub DoiGiaTri1Cot(ByVal sttCot As Integer)
        Dim strCellOfRow As String

        For i As Integer = 0 To gridLichRanh.RowCount - 1
            strCellOfRow = gridLichRanh.Rows(i).Cells(sttCot - 1).Value
            If strCellOfRow = "Bận" Then
                gridLichRanh.Rows(i).Cells(sttCot - 1).Value = "Rảnh"
            Else
                gridLichRanh.Rows(i).Cells(sttCot - 1).Value = "Bận"
            End If
        Next
    End Sub
    Private Sub DoiGia1Cell(ByVal strCellValue As String)
        If strCellValue.CompareTo("Rảnh") = 0 Then
            gridLichRanh.SelectedCells(0).Value = "Bận"
        ElseIf strCellValue.CompareTo("Bận") = 0 Then
            gridLichRanh.SelectedCells(0).Value = "Rảnh"
        End If
    End Sub

#End Region

#Region "Xu Ly CheckedListBox"
    Private Sub chklibxCacMonHocPhuTrach_Default()
        For i As Integer = 0 To chklbxMonHoc.Items.Count - 1
            chklbxMonHoc.SetItemChecked(i, False)
        Next
    End Sub
    Private Sub chklibxCacMonHocPhuTrach_Load()
        chklbxMonHoc.Tag = New ArrayList()
        Dim dsMonHoc As IList = mhBus.LayDanhSach()

        For i As Integer = 0 To dsMonHoc.Count - 1
            mhDto = dsMonHoc(i)
            chklbxMonHoc.Items.Add(mhDto.TenMonHoc)
            chklbxMonHoc.Tag.Add(mhDto)
        Next

    End Sub
    Private Sub chklbxMonHoc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklbxMonHoc.Leave
        chklbxMonHoc.ClearSelected()
    End Sub

    Private Sub chklbxMonHoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklbxMonHoc.SelectedIndexChanged
        If strThayDoi.IndexOf(" Các môn học phụ trách") = -1 Then
            strThayDoi += " Các môn học phụ trách"
        End If
        bThongTinThayDoi = True
    End Sub
    Private Sub chklbxMonHoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklbxMonHoc.Click
        btnCapNhatDuLieu.Enabled = True
    End Sub

    Private Function LayMaMonHoc(ByVal TenMH As String) As String
        Dim iLen As Integer = chklbxMonHoc.Tag.Count
        For i As Integer = 0 To iLen
            If TenMH = chklbxMonHoc.Tag(i).TenMonHoc Then
                Return chklbxMonHoc.Tag(i).MaMonHoc
            End If
        Next
        Return Nothing
    End Function

    Private Sub XoaMonPhuTrachHienTai(ByVal maGV As String)
        Dim dsMonHoc As IList

        'Lay cac mon hoc do giao vien do phu trach hien tai
        dsMonHoc = ptBus.LayDanhSachMonHoc(maGV)

        'Xoa cac phu trach hien tai nay di
        For i As Integer = 0 To dsMonHoc.Count - 1
            mhDto = dsMonHoc(i)
            ptBus.Xoa(maGV, mhDto.MaMonHoc)
        Next
    End Sub
    Private Sub CapNhatMonPhuTrachMoi(ByVal maGV As String)
        Dim maMH As String
        Dim maPT As String
        Dim checkItems As CheckedListBox.CheckedItemCollection

        checkItems = chklbxMonHoc.CheckedItems

        For i As Integer = 0 To chklbxMonHoc.CheckedItems.Count - 1
            maMH = LayMaMonHoc(checkItems(i).ToString())
            maPT = dlBus.TaoMaPhuTrach()
            Dim ptDto As New PhuTrachDTO(maPT, maGV, maMH)
            ptBus.Them(ptDto)
        Next
    End Sub

#End Region
#Region "Xu Ly gbThongTinGiaoVien"
    Private Sub setEnable(ByVal gb As GroupBox, ByVal enable As Boolean)
        Try
            For Each t As TextBox In gb.Controls
                t.Enabled = enable
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub setTextDefault(ByVal gb As GroupBox, ByVal strFill As String)
        Try
            For Each t As TextBox In gb.Controls
                t.Text = strFill
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gbThongTinGiaoVien_Default()
        'setEnable(gbThongTinGiaoVien, False)
        setTextDefault(gbThongTinGiaoVien, "")

        txtMaGiaoVien.BackColor = Color.AliceBlue
    End Sub
#End Region

#Region "Xu Ly Button"
    Private Sub btnTaoGiaoVienMoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaoGiaoVienMoi.Click
        gbThongTinGiaoVien_Default()
        gridDSGiaoVien_Default()
        gridLichRanh_Default()
        chklibxCacMonHocPhuTrach_Default()

        Dim maGV As String
        maGV = dlBus.TaoMaGiaoVien()
        txtMaGiaoVien.Text = maGV

        'Hien thi nut CapNhatDuLieu len
        btnCapNhatDuLieu.Enabled = True
        btnTaoGiaoVienMoi.Enabled = False
        btnXoaGiaoVien.Enabled = False

        'Enable cac groupBox
        gbCacMonHocPhuTrach.Enabled = True
        gbThongTinGiaoVien.Enabled = True
        gbLichRanh.Enabled = True

        bTaoGiaoVien = True
    End Sub

    Private Sub tienhanhCapNhat()
        Dim gvDto As New GiaoVienDTO(txtMaGiaoVien.Text, txtHoTenGiaoVien.Text, _
                txtTenTat.Text, txtDiaChi.Text, txtDienThoai.Text)

        If String.IsNullOrEmpty(gvDto.HoTenGiaoVien) Then
            MessageBox.Show("Phải nhập Họ tên giáo viên")

        ElseIf String.IsNullOrEmpty(gvDto.TenTat) Then
            MessageBox.Show("Phải nhập Tên tắt")

        ElseIf chklbxMonHoc.CheckedItems.Count = 0 Then
            MessageBox.Show("Phải nhập môn phụ trách", "Warning")
        Else
            'Cap Nhat Thong Tin Giao Vien
            If bTaoGiaoVien = False Then
                gvBus.Sua(gvDto)
            Else
                gvBus.Them(gvDto)
            End If

            'Cap Nhat Thong Tin Phu Trach
            XoaMonPhuTrachHienTai(txtMaGiaoVien.Text)
            CapNhatMonPhuTrachMoi(txtMaGiaoVien.Text)

            'Cap Nhat Thong Tin Lich Ranh
            'Duyet tung cell cua grid va cap nhat lai gia tri
            Dim iSoDong As Integer = gridLichRanh.Rows.Count
            Dim iSocot As Integer = gridLichRanh.Columns.Count
            rbGVDto.MaGiaoVien = txtMaGiaoVien.Text

            For i As Integer = 0 To (iSoDong - 1)
                rbGVDto.TietHoc = i + 1

                For j As Integer = 1 To (iSocot - 1)
                    rbGVDto.Thu = j + 1
                    If gridLichRanh.Rows(i).Cells(j).Value = "Rảnh" Then
                        rbGVDto.TrangThai = 0
                    Else 'If gridLichRanh.Rows(i).Cells(j).Value = "Bận" Then
                        rbGVDto.TrangThai = 1
                    End If

                    rbGVDto.MaRangBuocGiaovien = dlBus.TaoMaRangBuocGiaoVien()
                    If bTaoGiaoVien = False Then
                        rbGVBus.Sua(rbGVDto)
                    Else
                        rbGVBus.Them(rbGVDto)
                    End If
                Next
            Next

            bTaoGiaoVien = False
            btnCapNhatDuLieu.Enabled = False

            bThongTinThayDoi = False
            LoadData()

            MessageBox.Show("Cập nhật thành công")
        End If
    End Sub
    Private Sub btnCapNhatDuLieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhatDuLieu.Click
        tienhanhCapNhat()
    End Sub

    Private Sub btnTrangThai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrangThai.Click
        'Duyet tung cell cua grid va doi gia tri
        Dim iSoDong As Integer = gridLichRanh.Rows.Count
        Dim iSocot As Integer = gridLichRanh.Columns.Count

        For i As Integer = 0 To (iSoDong - 1)
            For j As Integer = 1 To (iSocot - 1)
                If (gridLichRanh.Rows(i).Cells(j).Value = "Bận") Then
                    gridLichRanh.Rows(i).Cells(j).Value = "Rảnh"
                Else
                    gridLichRanh.Rows(i).Cells(j).Value = "Bận"
                End If
            Next
        Next
    End Sub

    Private Sub btnXuatRaTapTin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuatRaTapTin.Click
        If (gridDSGiaoVien Is Nothing) Then
            Throw New ArgumentNullException("No DataGridView was provided for export")
        End If

        Using saveFileDialog As SaveFileDialog = GetExcelSaveFileDialog()
            If (saveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                Dim fileName As String = saveFileDialog.FileName
                ExcelGenerator.Generate(gridDSGiaoVien).Save(fileName)
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
        saveFileDialog.RestoreDirectory = True
        saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        saveFileDialog.DefaultExt = ".xls"
        saveFileDialog.Filter = "Microsoft Excel Workbook (*.xls)|*.xls"
        Return saveFileDialog
    End Function


    Private Sub btnXoaGiaoVien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaGiaoVien.Click
        Dim maGV As String = txtMaGiaoVien.Text
        Dim gvBus As New GiaoVienBUS()
        Dim rbgvBus As New RangBuocGiaoVienBUS()
        Dim ptBus As New PhuTrachBUS()

        gvBus.Xoa(maGV)
        'rbgvBus.XoaGiaoVien(maGV)
        'ptBus.XoaGiaoVien(maGV)
        'pcBus.XoaGiaoVien(maGV)

        LoadData()
        MessageBox.Show("Xóa thành công")
    End Sub
#End Region

#Region "Kiem tra du lieu nhap vao gbThongTinGiaoVien"
    Private Sub txtHoTenGiaoVien_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoTenGiaoVien.KeyPress
        If (Not Char.IsLetter(e.KeyChar) And Not Char.IsWhiteSpace(e.KeyChar)) Then
            e.Handled = True
        End If
        If (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        End If

        If strThayDoi.IndexOf(" Thông tin lớp học") = -1 Then
            strThayDoi += " Thông tin lớp học"
        End If
        bThongTinThayDoi = True

        btnCapNhatDuLieu.Enabled = True
    End Sub
    Private Sub txtTenTat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTenTat.KeyPress
        If (Not Char.IsLetter(e.KeyChar) And Not Char.IsWhiteSpace(e.KeyChar)) Then
            e.Handled = True
        End If
        If (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        End If

        If strThayDoi.IndexOf(" Thông tin lớp học") = -1 Then
            strThayDoi += " Thông tin lớp học"
        End If
        bThongTinThayDoi = True

        btnCapNhatDuLieu.Enabled = True
    End Sub
    Private Sub txtDienThoai_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDienThoai.KeyPress
        If (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
        If (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        End If

        If strThayDoi.IndexOf(" Thông tin lớp học") = -1 Then
            strThayDoi += " Thông tin lớp học"
        End If
        bThongTinThayDoi = True

        btnCapNhatDuLieu.Enabled = True
    End Sub

    Private Sub txtDiaChi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiaChi.KeyPress
        If strThayDoi.IndexOf(" Thông tin lớp học") = -1 Then
            strThayDoi += " Thông tin lớp học"
        End If
        bThongTinThayDoi = True

        btnCapNhatDuLieu.Enabled = True
    End Sub
#End Region

    
End Class