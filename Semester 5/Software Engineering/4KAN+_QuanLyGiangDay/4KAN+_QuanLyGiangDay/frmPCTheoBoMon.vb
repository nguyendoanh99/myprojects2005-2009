Imports BUS
Imports DTO
Imports System.Windows.Forms


Public Class frmPCTheoBoMon

    Dim SoLoi As Integer = 0
    Dim strLoi As String = "<unknown>"
    Dim colorLoi As Color = Color.Red
    Dim colorXoa As Color = Color.Pink
    Dim colorCapNhat As Color = Color.Green
    Dim colorThem As Color = Color.Blue

    Dim delta As Integer = 0 'nếu cho phép người dùng add row mới thì delta = 1, ngược lại = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCheckBoxListMonHoc()
        LoadCheckBoxListLopHoc()
        TaoGridDSGiaoVien()
        TaoGridBangPhanCong()
    End Sub


#Region "KHỞI TẠO CÁC CONTROL"

    Private Sub LoadCheckBoxListMonHoc()
        Dim arrMonHoc As ArrayList
        arrMonHoc = (New MonHocBUS).LayDanhSach()

        For i As Integer = 0 To arrMonHoc.Count - 1
            Dim mh As New MonHocDTO
            mh = arrMonHoc.Item(i)
            ckblistMonHoc.Items.Add(mh)
        Next
    End Sub

    Private Sub LoadCheckBoxListLopHoc()
        Dim arrLopHoc As ArrayList
        arrLopHoc = (New LopHocBUS).LayDanhSach()

        For i As Integer = 0 To arrLopHoc.Count - 1
            Dim lh As New LopHocDTO
            lh = arrLopHoc.Item(i)
            ckblistLopHoc.Items.Add(lh)
        Next
    End Sub

    Private Sub TaoGridDSGiaoVien()
        With gridDSGiaoVien
            .Columns.Add("STT", "STT")

            'Cột ẩn
            .Columns.Add("MaGiaoVien", "Mã giáo viên")
            .Columns("MaGiaoVien").Visible = False

            'Cột được hiển thị
            .Columns.Add("HoTenGiaoVien", "Họ tên giáo viên")
            .Columns.Add("TenTat", "Tên tắt")

            .Columns("STT").Width = 50
            .Columns("HoTenGiaoVien").Width = 150
            .Columns("TenTat").Width = 100

            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            Dim arrGiaoVien As ArrayList
            arrGiaoVien = (New GiaoVienBUS).LayDanhSach()

            For i As Integer = 0 To arrGiaoVien.Count - 1
                Dim gv As GiaoVienDTO = arrGiaoVien.Item(i)
                .Rows.Add()
                .Rows(i).Cells("STT").Value = i + 1
                .Rows(i).Cells("MaGiaoVien").Value = gv.MaGiaoVien
                .Rows(i).Cells("HoTenGiaoVien").Value = gv.HoTenGiaoVien
                .Rows(i).Cells("TenTat").Value = gv.TenTat
                'Dim row As String() = {Integer.Parse(i + 1), gv.MaGiaoVien, gv.HoTenGiaoVien, gv.TenTat}
                '.Rows.Add(row)
            Next
        End With
    End Sub

    Private Sub TaoGridBangPhanCong()
        With gridBangPhanCong

            .Columns.Add("STT", "STT")

            'Các cột ẩn
            .Columns.Add("MaPhanCong", "Mã phân công")
            .Columns.Add("MaLopHoc", "Mã lớp học")
            .Columns.Add("MaMonHoc", "Mã môn học")
            .Columns.Add("MaGiaoVien", "Mã giáo viên")

            .Columns("MaPhanCong").Visible = False
            .Columns("MaLopHoc").Visible = False
            .Columns("MaMonHoc").Visible = False
            .Columns("MaGiaoVien").Visible = False

            'Các cột được hiển thị ra
            .Columns.Add("LopHoc", "Lớp Học")
            .Columns.Add("MonHoc", "Môn Học")

            .Columns.Add("GiaoVien", "Giáo viên")
            'Dim cbCol As New DataGridViewComboBoxColumn
            'cbCol.Name = "GiaoVien"
            'cbCol.HeaderText = "Giáo viên"
            '.Columns.Add(cbCol)

            .Columns.Add("SoTietHocTuan", "Tổng Số Tiết/Tuần")
            .Columns.Add("STHLTTT", "STHLTTT")
            .Columns.Add("STHLTTD", "STHLTTĐ")
            .Columns.Add("SBHTT", "SBHTT")
            .Columns.Add("SBHTD", "SBHTD")

            .RowHeadersVisible = False
            .Columns("STT").Width = 50
            .Columns("STT").ReadOnly = True
            .Columns("STHLTTT").ReadOnly = True
            .Columns("STHLTTD").ReadOnly = True
            .Columns("SBHTT").ReadOnly = True
            .Columns("SBHTD").ReadOnly = True
            .Columns("MonHoc").ReadOnly = True
            .Columns("LopHoc").ReadOnly = True
            '....................

            'Load combobox columns
            'Dim arrGV As ArrayList = (New GiaoVienBUS).LayDanhSach
            'For Each gv As GiaoVienDTO In arrGV
            'cbCol.Items.Add(gv)
            'Next


        End With
    End Sub

#End Region

#Region "XỬ LÝ CHO SỰ KIỆN CLICK VÀO DANH SÁCH CÁC MÔN HỌC"

    'HIỂN THỊ THÔNG TIN VỀ CÁC MÔN HỌC ĐƯỢC CHỌN LÊN DANH SÁCH LỚP HỌC VÀ BẢNG PHÂN CÔNG
    Private Sub ckblistMonHoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckblistMonHoc.SelectedIndexChanged
        txtHoTenGV.Text = ""
        txtTenTat.Text = ""


        If FLAG.CoCapNhat = True Then
            HienThiThongBaoCapNhat()
        End If
        SoLoi = 0
        gridBangPhanCong.Columns("STT").SortMode = DataGridViewColumnSortMode.Automatic
        HienThiCheckListLopHocTheoMonHoc()
        HienThiBangPhanCongTheoMonHocVaLopHoc()
    End Sub

    'HIỂN THỊ DANH SÁCH CÁC LỚP CÓ HỌC CÁC MÔN HỌC ĐƯỢC CHỌN
    Private Sub HienThiCheckListLopHocTheoMonHoc()

        For i As Integer = 0 To ckblistLopHoc.Items.Count - 1
            ckblistLopHoc.SetItemChecked(i, False)
        Next

        Dim checked_MHitems As CheckedListBox.CheckedItemCollection = ckblistMonHoc.CheckedItems
        If checked_MHitems.Count = 0 Then
            Return
        End If

        Dim mytable As DataTable = (New PhanCongBUS).LayBang()
        Dim arrLop As ArrayList = (New LopHocBUS).LayDanhSachMaLop()
        'Dim arrLop As New ArrayList

        For Each item As Object In checked_MHitems
            Dim mh As MonHocDTO = item
            Dim arr As ArrayList = New PhanCongBUS().LayDanhSachLopHocCoHocMonHoc(mytable, mh.MaMonHoc)

            'If (arrLop.Count = 0) Then
            'arrLop = arr
            'Continue For
            'End If


            ' so sánh ma trong arrLop với malophoc trong arr
            ' nếu ma có tồn tại trong malophoc của arr thì jữ phần tử đó (thóat khỏi vòng lặp)
            ' ngược lại chạy hết vòng lặp thì xóa bỏ phần tử đó
            Dim flag As Boolean = False

            Dim i As Integer = 0
            While i < arrLop.Count
                Dim ma As String = arrLop(i)

                For Each masosanh As String In arr
                    If ma = masosanh Then
                        flag = True
                        Exit For
                    End If
                Next

                If flag = False Then
                    arrLop.RemoveAt(i)
                Else
                    flag = False
                    i += 1
                End If
            End While


        Next


        For i As Integer = 0 To ckblistLopHoc.Items.Count - 1
            Dim lh As LopHocDTO = ckblistLopHoc.Items.Item(i)

            For Each ma As String In arrLop
                If lh.MaLopHoc = ma Then
                    ckblistLopHoc.SetItemChecked(i, True)
                End If
            Next
        Next
    End Sub

    'HIỂN THỊ THÔNG TIN LÊN BẢNG PHÂN CÔNG THEO CÁC MÔN HỌC ĐƯỢC CHỌN
    Private Sub HienThiBangPhanCongTheoMonHocVaLopHoc()
        'Xóa bảng phân công
        gridBangPhanCong.Rows.Clear()

        'Lấy danh sách các môn học đc chọn
        Dim checked_MHitems As CheckedListBox.CheckedItemCollection = ckblistMonHoc.CheckedItems
        If checked_MHitems.Count = 0 Then
            Return
        End If

        'Lấy danh sách các lớp học có học các môn được chọn
        Dim checked_LHitems As CheckedListBox.CheckedItemCollection = ckblistLopHoc.CheckedItems
        If checked_LHitems.Count = 0 Then
            Return
        End If


        For Each item As Object In checked_MHitems
            Dim mh As MonHocDTO = item
            Dim dt As DataTable = (New PhanCongBUS).LayBangTheoMaMonHoc(mh.MaMonHoc)

            Dim nextindex = gridBangPhanCong.Rows.Count - delta  'chỉ số dòng kế tiếp trong grid

            For Each row As DataRow In dt.Rows
                ' Kiểm tra nếu mã lớp học có trên danh sách các lớp học đc chọn thì add vào grid
                For Each lhItem As Object In checked_LHitems

                    Dim lh As LopHocDTO = lhItem
                    If lh.MaLopHoc = row("MaLopHoc") Then
                        gridBangPhanCong.Rows.Add()
                        gridBangPhanCong.Rows(nextindex).Cells(0).Value = Integer.Parse(nextindex + 1)
                        For i As Integer = 0 To dt.Columns.Count - 1    'bỏ cột mã lớp học trong dt                       
                            gridBangPhanCong.Rows(nextindex).Cells(i + 1).Value = row(i)
                        Next

                        nextindex += 1
                    End If
                Next
            Next
        Next



    End Sub

#End Region

#Region "XỬ LÝ CHO SỰ KIỆN CLICK VÀO DANH SÁCH CÁC LỚP HỌC"

    ' THÊM HOẶC XÓA PHÂN CÔNG LỚP HỌC VÀO MÔN HỌC ĐANG ĐƯỢC CHỌN TRÊN DANH SÁCH MÔN HỌC
    Private Sub ckblistLopHoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckblistLopHoc.SelectedIndexChanged
        FLAG.CoCapNhat = True

        If ckblistLopHoc.SelectedIndex = -1 Then
            Return
        End If

        Dim checked_MHItems As CheckedListBox.CheckedItemCollection = ckblistMonHoc.CheckedItems
        If checked_MHItems.Count = 0 Then
            Return
        End If

        Dim lh As LopHocDTO = ckblistLopHoc.SelectedItem
        'check vào item của list lớp học
        'nếu là check : phân công các môn học đc chọn cho lớp học này
        'nếu là uncheck : xóa phân công các môn học của lớp học

        If ckblistLopHoc.GetItemChecked(ckblistLopHoc.SelectedIndex) = False Then   'Xóa phan cong
            Dim i As Integer = 0
            Dim nextorder As Integer = 1
            While i < gridBangPhanCong.Rows.Count - delta
                Dim row As DataGridViewRow = gridBangPhanCong.Rows(i)
                If row.Cells("MaLopHoc").Value = lh.MaLopHoc Then
                    If row.Cells("STT").Value.ToString() <> "Thêm" Then
                        row.Cells("STT").Value = "Xóa"
                        row.Cells("STT").Style.BackColor = colorXoa
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
            For Each item As Object In checked_MHItems
                Dim mh As MonHocDTO = item
                Dim dulieu As New DuLieuBUS

                Dim flag As Boolean = False

                With gridBangPhanCong
                    For i As Integer = 0 To .Rows.Count - 2
                        Dim row As DataGridViewRow = gridBangPhanCong.Rows(i)
                        If row.Cells("MaLopHoc").Value = lh.MaLopHoc And row.Cells("MaMonHoc").Value = mh.MaMonHoc Then
                            If row.Cells("STT").Value.ToString() = "Xóa" Then
                                row.Cells("STT").Value = "Cập nhật"
                                row.Cells("STT").Style.BackColor = colorCapNhat

                                flag = True
                                Exit For
                            End If
                        End If
                    Next

                    If flag = False Then
                        Dim index As Integer = .Rows.Count - delta
                        .Rows.Add()

                        .Rows(index).Cells("GiaoVien").Value = strLoi
                        .Rows(index).Cells("SoTietHocTuan").Value = strLoi

                        Dim monhoc As MonHocDTO = (New MonHocBUS).LayThongTinCoMa(mh.MaMonHoc)
                        .Rows(index).Cells("STHLTTT").Value = monhoc.QuyDinhSoTietHocLienTiepToiThieu
                        .Rows(index).Cells("STHLTTD").Value = monhoc.QuyDinhSoTietHocLienTiepToiDa

                        .Rows(index).Cells("SBHTT").Value = strLoi
                        .Rows(index).Cells("SBHTD").Value = strLoi


                        .Rows(index).Cells("GiaoVien").Style.BackColor = colorLoi
                        .Rows(index).Cells("SoTietHocTuan").Style.BackColor = colorLoi

                        '.Rows(index).Cells("STHLTTT").Style.BackColor = colorLoi
                        '.Rows(index).Cells("STHLTTD").Style.BackColor = colorLoi
                        .Rows(index).Cells("SBHTT").Style.BackColor = colorLoi
                        .Rows(index).Cells("SBHTD").Style.BackColor = colorLoi

                        SoLoi += 4

                        '.Rows(index).Cells("STT").Value = index + 1
                        .Rows(index).Cells("STT").Value = "Thêm"
                        .Rows(index).Cells("STT").Style.BackColor = colorThem

                        .Rows(index).Cells("MaLopHoc").Value = lh.MaLopHoc
                        .Rows(index).Cells("LopHoc").Value = lh.TenLopHoc
                        .Rows(index).Cells("MaMonHoc").Value = mh.MaMonHoc
                        .Rows(index).Cells("MonHoc").Value = mh.TenMonHoc
                    End If

                End With
            Next
        End If
        gridBangPhanCong.Columns("STT").SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub

#End Region

#Region "XỬ LÝ CHO SỰ KIỆN CLICK VÀO GRID DANH SÁCH GIÁO VIEN"

    'HIỂN THỊ THÔNG TIN VỀ GIÁO VIÊN LÊN DANH SÁCH MÔN HỌC, LỚP HỌC, BẢNG PHÂN CÔNG
    Private Sub HienThiThongTinTheoGiaoVien()
        gridBangPhanCong.Rows.Clear()

        For i As Integer = 0 To ckblistMonHoc.Items.Count - 1
            ckblistMonHoc.SetItemChecked(i, False)
        Next

        For i As Integer = 0 To ckblistLopHoc.Items.Count - 1
            ckblistLopHoc.SetItemChecked(i, False)
        Next

        If gridDSGiaoVien.SelectedRows.Count = 0 Then
            Return
        End If

        Dim selectedrow As DataGridViewRow = gridDSGiaoVien.SelectedRows(0)
        Dim magiaovien As String = selectedrow.Cells("MaGiaoVien").Value

        Dim dt As DataTable = (New PhanCongBUS).LayBangTheoMaGiaoVien(magiaovien)
        Dim nextindex As Integer = 0

        'Load họ tên giáo viên lên textbox
        txtHoTenGV.Text = selectedrow.Cells("HoTenGiaoVien").Value

        'Load tên tắt giáo viên lên textbox
        txtTenTat.Text = selectedrow.Cells("TenTat").Value

        For Each row As DataRow In dt.Rows
            gridBangPhanCong.Rows.Add()
            gridBangPhanCong.Rows(nextindex).Cells(0).Value = nextindex + 1
            For i As Integer = 0 To dt.Columns.Count - 1    'bỏ cột mã lớp học trong dt
                gridBangPhanCong.Rows(nextindex).Cells(i + 1).Value = row(i)
            Next



            'Load các môn học tương ứng lên checklist môn học
            For i As Integer = 0 To ckblistMonHoc.Items.Count - 1
                Dim mh As MonHocDTO = ckblistMonHoc.Items.Item(i)
                If gridBangPhanCong.Rows(nextindex).Cells("MaMonHoc").Value = mh.MaMonHoc Then
                    ckblistMonHoc.SetItemChecked(i, True)
                End If
            Next

            'Load các lớp học tương ứng lên checklist lớp học
            For i As Integer = 0 To ckblistLopHoc.Items.Count - 1
                Dim lh As LopHocDTO = ckblistLopHoc.Items.Item(i)
                If gridBangPhanCong.Rows(nextindex).Cells("MaLopHoc").Value = lh.MaLopHoc Then
                    ckblistLopHoc.SetItemChecked(i, True)
                End If
            Next

            nextindex += 1
        Next
        gridBangPhanCong.Columns("STT").SortMode = DataGridViewColumnSortMode.Automatic
    End Sub

    Private Sub gridDSGiaoVien_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridDSGiaoVien.SelectionChanged
        If FLAG.CoCapNhat = True Then
            HienThiThongBaoCapNhat()
            HienThiThongTinTheoGiaoVien()
        Else
            If gridDSGiaoVien.SelectedRows.Count = 0 Then
                Return
            End If

            Dim selectedrow As DataGridViewRow = gridDSGiaoVien.SelectedRows(0)
            Dim magiaovien As String = selectedrow.Cells("MaGiaoVien").Value

            If magiaovien IsNot Nothing Then
                HienThiThongTinTheoGiaoVien()

            End If
            SoLoi = 0
        End If
    End Sub
#End Region

#Region "XỬ LÝ CHO SỰ KIỆN CLICK VÀO GRID BẢNG PHÂN CÔNG"

    ' BẮT LỖI TRÊN BẢNG PHÂN CÔNG
    Private Sub gridBangPhanCong_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBangPhanCong.CellEndEdit
        With gridBangPhanCong
            Dim row As DataGridViewRow = .Rows(e.RowIndex)

            Select Case .Columns(e.ColumnIndex).Name

                Case "GiaoVien"
                    FLAG.CoCapNhat = True

                    Dim tengiaovien As String = row.Cells("GiaoVien").Value

                    If String.IsNullOrEmpty(tengiaovien) Then
                        If row.Cells("GiaoVien").Style.BackColor = colorLoi Then
                            row.Cells("GiaoVien").Value = strLoi
                        Else
                            row.Cells("GiaoVien").Style.BackColor = colorLoi
                            row.Cells("GiaoVien").Value = strLoi
                            SoLoi += 1
                        End If
                    Else
                        Dim arrMaGiaoVien As ArrayList = (New GiaoVienBUS).LayMaGiaoVienCoTen(tengiaovien)
                        If arrMaGiaoVien.Count = 0 Then 'Ko có lớp học nào có tên như zị
                            If row.Cells("GiaoVien").Style.BackColor = colorLoi Then
                            Else
                                row.Cells("GiaoVien").Style.BackColor = colorLoi
                                row.Cells("GiaoVien").Value = strLoi
                                SoLoi += 1
                            End If
                        Else
                            'Gán giá trị cho cell MaLopHoc
                            row.Cells("MaGiaoVien").Value = arrMaGiaoVien(0)

                            Dim arrMH As ArrayList = (New PhuTrachBUS).LayMonHocGiaoVienDay(row.Cells("MaGiaoVien").Value)
                            Dim flag As Boolean = False
                            For Each mh As String In arrMH
                                If mh = row.Cells("MaMonHoc").Value Then
                                    flag = True
                                    Exit For
                                End If
                            Next
                            If flag = False Then
                                MessageBox.Show("Giáo viên " + tengiaovien + " không phụ phụ trách môn học " _
                                        + row.Cells("MonHoc").Value)
                                Return
                            End If

                            'Báo hiệu dữ liệu có thay đổi -> đánh dấu 'cập nhật"
                            If row.Cells("STT").Value.ToString() <> "Thêm" And _
                                row.Cells("STT").Value.ToString() <> "Cập nhật" Then
                                row.Cells("STT").Value = "Cập nhật"
                                row.Cells("STT").Style.BackColor = colorCapNhat
                            End If

                            If row.Cells("GiaoVien").Style.BackColor = colorLoi Then
                                row.Cells("GiaoVien").Style.BackColor = Color.White
                                SoLoi -= 1
                            End If
                        End If
                    End If



                Case "SoTietHocTuan"
                    FLAG.CoCapNhat = True

                    Dim giatri As Byte = 0
                    If Not Byte.TryParse(row.Cells(e.ColumnIndex).Value, giatri) Then
                        If row.Cells(e.ColumnIndex).Style.BackColor = colorLoi Then
                            row.Cells("LopHoc").Value = strLoi
                        Else
                            row.Cells(e.ColumnIndex).Style.BackColor = colorLoi
                            row.Cells(e.ColumnIndex).Value = strLoi
                            SoLoi += 1
                        End If
                    Else
                        row.Cells("SBHTT").Value = Math.Round(row.Cells("SoTietHocTuan").Value / row.Cells("STHLTTD").Value + 0.5, 0)
                        row.Cells("SBHTD").Value = Math.Round(row.Cells("SoTietHocTuan").Value / row.Cells("STHLTTT").Value + 0.5, 0)

                        row.Cells("SBHTT").Style.BackColor = Color.White
                        row.Cells("SBHTD").Style.BackColor = Color.White

                        SoLoi -= 2


                        'Báo hiệu dữ liệu có thay đổi -> đánh dấu 'cập nhật"
                        If row.Cells("STT").Value.ToString() <> "Thêm" And _
                                 row.Cells("STT").Value.ToString() <> "Cập nhật" Then
                            row.Cells("STT").Value = "Cập nhật"
                            row.Cells("STT").Style.BackColor = colorCapNhat


                        End If

                        If row.Cells(e.ColumnIndex).Style.BackColor = colorLoi Then
                            row.Cells(e.ColumnIndex).Style.BackColor = Color.White
                            SoLoi -= 1
                        End If
                    End If


            End Select


        End With

    End Sub

#End Region

#Region "XỬ LÝ CHO SỰ KIỆN CLICK VÀO CÁC BUTTON"

    ' XEM THÔNG TIN GIÁO VIÊN TIẾP THEO
    Private Sub bGVTiepTheo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGVTiepTheo.Click
        If FLAG.CoCapNhat = True Then
            HienThiThongBaoCapNhat()
            Return
        End If

        If (gridDSGiaoVien.SelectedRows.Count = 0) Then
            Return
        End If

        Dim selectedrow As DataGridViewRow = gridDSGiaoVien.SelectedRows(0)
        Dim index As Integer = selectedrow.Index
        gridDSGiaoVien.ClearSelection()

        If (index >= gridDSGiaoVien.Rows.Count - delta - 1) Then
            index = -1
        End If

        gridDSGiaoVien.Rows(index + 1).Selected() = True
        Dim selectingrow As DataGridViewRow = gridDSGiaoVien.SelectedRows(0)
        Dim magiaovien As String = selectingrow.Cells("MaGiaoVien").Value
        HienThiThongTinTheoGiaoVien()
    End Sub

    ' XEM THÔNG TIN GIÁO VIÊN KẾ TRƯỚC
    Private Sub bGVKeTruoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGVKeTruoc.Click
        If FLAG.CoCapNhat = True Then
            HienThiThongBaoCapNhat()
            Return
        End If

        If (gridDSGiaoVien.SelectedRows.Count = 0) Then
            Return
        End If

        Dim selectedrow As DataGridViewRow = gridDSGiaoVien.SelectedRows(0)
        Dim index As Integer = selectedrow.Index
        gridDSGiaoVien.ClearSelection()

        If (index <= 0) Then
            index = gridDSGiaoVien.Rows.Count - delta
        End If

        gridDSGiaoVien.Rows(index - 1).Selected() = True
        Dim selectingrow As DataGridViewRow = gridDSGiaoVien.SelectedRows(0)
        Dim magiaovien As String = selectingrow.Cells("MaGiaoVien").Value

        HienThiThongTinTheoGiaoVien()
    End Sub

    ' CẬP NHẬT BẢNG PHÂN CÔNG VÀO CSDL
    Private Sub bCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCapNhat.Click
        CapNhat()
        FLAG.CoCapNhat = False
    End Sub

    Private Sub CapNhat()
        If SoLoi <> 0 Then
            MessageBox.Show("Không thể cập nhật, do lỗi trên bảng phân công" + vbCrLf + "Số lỗi : " + SoLoi.ToString())
            Return
        End If

        With gridBangPhanCong
            For i As Integer = 0 To .Rows.Count - delta - 1
                Dim row As DataGridViewRow = .Rows(i)

                Dim pc As New PhanCongDTO
                pc.MaLopHoc = row.Cells("MaLopHoc").Value
                pc.MaMonHoc = row.Cells("MaMonHoc").Value
                pc.MaGiaoVien = row.Cells("MaGiaoVien").Value
                pc.SoTietHocTuan = row.Cells("SoTietHocTuan").Value
                pc.SoTietHocLienTiepToiThieu = row.Cells("STHLTTT").Value
                pc.SoTietHocLienTiepToiDa = row.Cells("STHLTTD").Value
                pc.SoBuoiHocToiThieu = row.Cells("SBHTT").Value
                pc.SoBuoiHocToiDa = row.Cells("SBHTD").Value

                Dim phancongbus As New PhanCongBUS

                If row.Cells("STT").Value.ToString() = "Thêm" Then  'Them moi
                    pc.MaPhanCong = (New DuLieuBUS).TaoMaPhanCong()
                    phancongbus.ThemDong(pc)

                ElseIf row.Cells("STT").Value.ToString() = "Cập nhật" Then 'CapNhat
                    If String.IsNullOrEmpty(pc.MaPhanCong) Then 'Dùng cho trường hợp ng dùng tự tạo thêm dòng mới trong grid phân công
                        pc.MaPhanCong = (New DuLieuBUS).TaoMaPhanCong()
                    End If
                    pc.MaPhanCong = row.Cells("MaPhanCong").Value
                    phancongbus.CapNhatDong(pc)

                ElseIf row.Cells("STT").Value.ToString() = "Xóa" Then 'Xóa
                    pc.MaPhanCong = row.Cells("MaPhanCong").Value
                    phancongbus.XoaDong(pc.MaPhanCong)
                End If

            Next
        End With
        MessageBox.Show("Cập nhật thành công")

        If txtTenTat.Text = "" Then
            HienThiCheckListLopHocTheoMonHoc()
            HienThiBangPhanCongTheoMonHocVaLopHoc()
        Else
            HienThiThongTinTheoGiaoVien()
        End If
        gridBangPhanCong.Columns("STT").ReadOnly = False
    End Sub

    ' XUẤT BẢNG PHÂN CÔNG RA FILE EXCEL
    Private Sub bXuatFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bXuatFile.Click
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

#End Region

#Region "CÁC SỰ KIỆN PHỤ"

    Private Sub gridDSGiaoVien_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridDSGiaoVien.MouseUp
        'If FLAG.cocapnhat = True Then
        'HienThiThongBaoCapNhat()
        'Else
        'HienThiThongTinTheoGiaoVien()
        'SoLoi = 0
        'End If
    End Sub

    Private Sub ckblistMonHoc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckblistMonHoc.Leave
        ckblistMonHoc.ClearSelected()
    End Sub

    Private Sub ckblistLopHoc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckblistLopHoc.Leave
        ckblistLopHoc.ClearSelected()
    End Sub

    Private Sub gridBangPhanCong_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridBangPhanCong.Leave
        gridBangPhanCong.ClearSelection()
    End Sub

#End Region

#Region "CÁC HÀM PHỤ"

    ' CẬP NHẬT LẠI SỐ LỖI TRÊN BẢNG PHÂN CÔNG
    Private Sub CapNhatSoLoi(ByVal row As DataGridViewRow)
        For Each cell As DataGridViewCell In row.Cells
            If cell.Style.BackColor = colorLoi Then
                SoLoi -= 1
            End If
        Next
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

    Private Sub HienThiThongBaoCapNhat()
        If (MessageBox.Show("Bạn có muốn cập nhật lại dữ liệu trên bảng phân công ?", _
                "Đồng bào chú ý!", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            CapNhat()
        End If
        FLAG.CoCapNhat = False
    End Sub

#End Region



End Class
