Imports BUS
Imports DTO
Imports DAO

Public Class frmThongTinMonHoc

    Public Shared flag As Boolean = False

    Private Sub frmThongTinMonHoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatDataGridView_DSMonHoc()
        gridDSGiaoVien_Load()
        gridDSMonHoc_Load()

        setEnableForm(Me, False)
        btnCapNhatDuLieu.Enabled = False
        btnXoaMonHoc.Enabled = False
    End Sub

#Region "XU LY CAC DATAGRIDVIEW"

    Private Sub gridDSMonHoc_Load()
        LoadData_MonHoc()

        Dim monhocbus As New MonHocBUS()
        Dim dsmonhoc As ArrayList
        Dim soluongmonhoc As Integer

        dsmonhoc = monhocbus.LayDanhSach()
        soluongmonhoc = dsmonhoc.Count

        'gridDSMonHoc.Columns(0).HeaderText = "Mã Môn Học"
        gridDSMonHoc.Columns("TenMonHoc").HeaderText = "Tên Môn Học"
        gridDSMonHoc.Columns("QuiDinhSoTietHocLienTiepToiThieu").HeaderText = "QĐSTHLTTT"
        gridDSMonHoc.Columns("QuiDinhSoTietHocLienTiepToiDa").HeaderText = "QĐSTHLTTĐ"

        gridDSMonHoc.Columns("clSTT").DisplayIndex = 0
        gridDSMonHoc.RowHeadersVisible = False
        ' gridDSMonHoc.Columns("MaMonHoc").Visible = False

        gridDSMonHoc.ClearSelection()
    End Sub

    Private Sub gridDSGiaoVien_Load()

        gridDSGiaoVien.Columns.Add("clSTT", "STT")
        gridDSGiaoVien.Columns.Add("clHoTenGiaoVien", "Họ Tên Giáo Viên")
        gridDSGiaoVien.Columns.Add("clTenTat", "Tên Tắt")
        gridDSGiaoVien.Columns.Add("clCacLopHocPhuTrach", "Các Lớp Học Phụ Trách")

        gridDSGiaoVien.RowHeadersVisible = False

    End Sub

    Private Sub gridDSMonHoc_Default()
        gridDSGiaoVien.ClearSelection()
    End Sub

    Private Sub gridDSMonHoc_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridDSMonHoc.SelectionChanged
        gbThongTinMonHoc_default()
        gridDSGiaoVien_Default()

        If gridDSMonHoc.SelectedRows.Count > 0 Then
            'Enable cac groupBox
            gbDanhSachGiaoVien.Enabled = True
            gbDanhSachMonHoc.Enabled = True
            gbThongTinMonHoc.Enabled = True

            ' Load các thông tin lên gridDSMonHoc.
            Dim mamonhoc As String = gridDSMonHoc.SelectedRows(0).Cells("MaMonHoc").Value
            Dim monhocbus As New MonHocBUS()
            Dim monhocdto As New MonHocDTO()

            monhocdto = monhocbus.Tim(mamonhoc)

            txtMaMonHoc.Text = monhocdto.MaMonHoc
            txtTenMonHoc.Text = monhocdto.TenMonHoc
            txtQDSoTHLienTiepToiThieu.Text = monhocdto.QuyDinhSoTietHocLienTiepToiThieu.ToString
            txtQDSoTHLienTiepToiDa.Text = monhocdto.QuyDinhSoTietHocLienTiepToiDa.ToString

            ' Load các thông tin lên gridDSGiaoVien.
            Dim phutrachbus As New PhuTrachBUS()
            Dim phancongbus As New PhanCongBUS()
            Dim danhsachlophoc As ArrayList
            Dim danhsachgiaovien As ArrayList
            Dim giaoviendto As New GiaoVienDTO()
            Dim lophocdto As New LopHocDTO()

            danhsachgiaovien = phutrachbus.LayDanhSachGiaoVien(mamonhoc)

            Dim soluonggiaovien As Integer = danhsachgiaovien.Count

            gridDSGiaoVien.Rows.Clear()

            For i As Integer = 0 To soluonggiaovien - 1

                giaoviendto = danhsachgiaovien(i)

                gridDSGiaoVien.Rows.Add()
                gridDSGiaoVien.Rows(i).Cells("clSTT").Value = i + 1
                gridDSGiaoVien.Rows(i).Cells("clHoTenGiaoVien").Value = giaoviendto.HoTenGiaoVien
                gridDSGiaoVien.Rows(i).Cells("clTenTat").Value = giaoviendto.TenTat

                danhsachlophoc = phancongbus.LayDanhSachLopHocMaGiaoVienDay(giaoviendto.MaGiaoVien)

                For j As Integer = 0 To danhsachlophoc.Count - 1
                    gridDSGiaoVien.Rows(i).Cells("clCacLopHocPhuTrach").Value &= danhsachlophoc(j) & "   "
                Next
            Next

            btnXoaMonHoc.Enabled = True

        Else
            btnXoaMonHoc.Enabled = False

        End If

    End Sub

    Private Sub gridDSMonHoc_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridDSMonHoc.Sorted

        Dim SoLuongMH As Integer
        Dim i As Integer
        Dim mhBus As New MonHocBUS()
        Dim dsmh As IList

        dsmh = mhBus.LayDanhSach()
        SoLuongMH = dsmh.Count

        'Them gia tri cho column STT
        With gridDSMonHoc
            For i = 0 To SoLuongMH - 1
                .Rows(i).Cells("clSTT").Style.ForeColor = Color.Red

                If .SortOrder = SortOrder.Ascending Then
                    .Rows(i).Cells("clSTT").Value = i + 1
                ElseIf .SortOrder = SortOrder.Descending Then
                    .Rows(i).Cells("clSTT").Value = SoLuongMH - i
                End If
            Next
        End With

    End Sub

    

#End Region

#Region "XU LY CAC BUTTON"

    Private Sub btnTaoMonHocMoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaoMonHocMoi.Click

        Dim mamonhoc As String
        Dim dulieubus As New DuLieuBUS()

        gridDSGiaoVien.Rows.Clear()

        'Enable cac groupBox
        gbDanhSachGiaoVien.Enabled = True
        gbDanhSachMonHoc.Enabled = True
        gbThongTinMonHoc.Enabled = True

        mamonhoc = dulieubus.TaoMaMonHoc()
        txtMaMonHoc.Text = mamonhoc
        txtTenMonHoc.Text = ""
        txtQDSoTHLienTiepToiThieu.Text = 1
        txtQDSoTHLienTiepToiDa.Text = 1
        btnCapNhatDuLieu.Enabled = True

    End Sub

    Private Sub btnCapNhatDuLieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhatDuLieu.Click

        Dim monhocbus As New MonHocBUS()
        Dim soluongmonhoc As Integer
        Dim i As Integer
        Dim temp As Integer = 0

        soluongmonhoc = monhocbus.LayDanhSach().Count

        For i = 0 To soluongmonhoc - 1
            If (gridDSMonHoc.Rows(i).Cells(1).Value = txtMaMonHoc.Text.ToString) Then
                temp = temp + 1
            End If
        Next

       

        If (temp <> 0) Then
            CapNhatDuLieu()
        Else
            TaoMonHocMoi()
        End If

    End Sub

    Private Sub btnXoaMonHoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaMonHoc.Click

        If gridDSMonHoc.SelectedRows.Count > 0 Then
            Dim mamonhoc As String = gridDSMonHoc.SelectedRows(0).Cells("MaMonHoc").Value
            Dim monhocbus As New MonHocBUS()

            monhocbus.Xoa(mamonhoc)

            MessageBox.Show("Xóa môn học thành công !")
            LoadData_MonHoc()

            ' Cập nhật lại số thứ tự.
            Dim i As Integer
            Dim danhsachmonhoc As ArrayList
            Dim soluongmonhoc As Integer

            danhsachmonhoc = monhocbus.LayDanhSach()
            soluongmonhoc = danhsachmonhoc.Count

            For i = 0 To soluongmonhoc - 1
                gridDSMonHoc.Rows(i).Cells(0).Value = i + 1
            Next

        End If

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
    Private Sub btnXuatRaTapTin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuatRaTapTin.Click
        If (gridDSMonHoc Is Nothing) Then
            Throw New ArgumentNullException("No DataGridView was provided for export")
        End If

        Using saveFileDialog As SaveFileDialog = GetExcelSaveFileDialog()
            If (saveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                Dim fileName As String = saveFileDialog.FileName
                ExcelGenerator.Generate(gridDSMonHoc).Save(fileName)
                Process.Start(fileName)
            End If
        End Using
    End Sub

#End Region
    
#Region "CAC HAM HO TRO"

    Private Sub FormatDataGridView_DSMonHoc()
        
        With gridDSMonHoc
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .AllowUserToDeleteRows = False

        End With

        With gridDSMonHoc.RowsDefaultCellStyle
            .BackColor = Color.LightSkyBlue
        End With

        With gridDSMonHoc.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Blue
            .ForeColor = Color.Black
            .Font = New Font(gridDSMonHoc.Font, FontStyle.Bold)
        End With

    End Sub

    Public Sub LoadData_MonHoc()

        Dim monhocbus As New MonHocBUS()
        Dim dt As DataTable

        dt = monhocbus.LayBang()
        gridDSMonHoc.DataSource = dt

        gridDSMonHoc.Columns.Add("clSTT", "STT")
        ' gridDSMonHoc.Columns("clSTT").DisplayIndex = 0

        gridDSMonHoc.Sort(gridDSMonHoc.Columns("TenMonHoc"), System.ComponentModel.ListSortDirection.Ascending)

    End Sub

    Public Sub CapNhatDuLieu()

        If gridDSMonHoc.SelectedRows.Count > 0 Then
            Dim monhocdto As New MonHocDTO()

            monhocdto.MaMonHoc = txtMaMonHoc.Text
            monhocdto.TenMonHoc = txtTenMonHoc.Text
            monhocdto.QuyDinhSoTietHocLienTiepToiThieu = txtQDSoTHLienTiepToiThieu.Text
            monhocdto.QuyDinhSoTietHocLienTiepToiDa = txtQDSoTHLienTiepToiDa.Text

            Dim monhocbus As New MonHocBUS()

            monhocbus.Sua(monhocdto)

            MessageBox.Show("Cập nhật thông tin thành công !")
            LoadData_MonHoc()

            ' Cập nhật lại số thứ tự.
            Dim i As Integer
            Dim danhsachmonhoc As ArrayList
            Dim soluongmonhoc As Integer

            danhsachmonhoc = monhocbus.LayDanhSach()
            soluongmonhoc = danhsachmonhoc.Count

            For i = 0 To soluongmonhoc - 1
                gridDSMonHoc.Rows(i).Cells(0).Value = i + 1
            Next

        End If

    End Sub

    Public Sub TaoMonHocMoi()
        Dim tsBus As New ThamSoBUS()
        Dim tsDto As ThamSoDTO = tsBus.LayThamSo()
        Dim monhocdto As New MonHocDTO()

        monhocdto.MaMonHoc = txtMaMonHoc.Text.ToString
        monhocdto.TenMonHoc = txtTenMonHoc.Text.ToString
        monhocdto.QuyDinhSoTietHocLienTiepToiThieu = Integer.Parse(txtQDSoTHLienTiepToiThieu.Text)
        monhocdto.QuyDinhSoTietHocLienTiepToiDa = Integer.Parse(txtQDSoTHLienTiepToiDa.Text)

        Dim monhocbus As New MonHocBUS()

        If Integer.Parse(txtQDSoTHLienTiepToiThieu.Text) > tsDto.SoTietToiDaDuocHocTrongNgay Then
            MessageBox.Show("Qui định số tiết học liên tiếp tối thiểu không được lớn hơn Số tiết tối đa được học trong ngày")

        ElseIf (Not String.IsNullOrEmpty(txtQDSoTHLienTiepToiDa.Text) And Integer.Parse(txtQDSoTHLienTiepToiDa.Text) < Integer.Parse(txtQDSoTHLienTiepToiThieu.Text)) Then
            MessageBox.Show("Qui định số tiết học liên tiếp tối thiểu không được lớn hơn Qui định số tiết học liên tiếp tối đa")

        ElseIf Integer.Parse(txtQDSoTHLienTiepToiDa.Text) > tsDto.SoTietToiDaDuocHocTrongNgay Then
            MessageBox.Show("Qui định số tiết học liên tiếp tối đa không được lớn hơn Số tiết tối đa được học trong ngày")

        ElseIf (Not String.IsNullOrEmpty(txtQDSoTHLienTiepToiThieu.Text) And Integer.Parse(txtQDSoTHLienTiepToiDa.Text) < Integer.Parse(txtQDSoTHLienTiepToiThieu.Text)) Then
            MessageBox.Show("Qui định số tiết học liên tiếp tối đa không được nhỏ hơn Qui định số tiết học liên tiếp tối thiểu")

        ElseIf String.IsNullOrEmpty(monhocdto.TenMonHoc) Then
            MessageBox.Show("Phải nhập Tên Môn Học")
        Else
            monhocbus.Them(monhocdto)

            MessageBox.Show("Thêm môn học thành công !")
            LoadData_MonHoc()

            ' Cập nhật lại số thứ tự.
            Dim i As Integer
            Dim danhsachmonhoc As ArrayList
            Dim soluongmonhoc As Integer

            danhsachmonhoc = monhocbus.LayDanhSach()
            soluongmonhoc = danhsachmonhoc.Count

            For i = 0 To soluongmonhoc - 1
                gridDSMonHoc.Rows("MaMonHoc").Cells(0).Value = i + 1
            Next

        End If


    End Sub

    Private Sub txtTenMonHoc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTenMonHoc.KeyPress
        If (Not Char.IsLetter(e.KeyChar) And Not Char.IsWhiteSpace(e.KeyChar)) Then
            e.Handled = True
        End If
        If (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        End If

        btnCapNhatDuLieu.Enabled = True
    End Sub

    Private Sub txtQDSoTHLienTiepToiThieu_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQDSoTHLienTiepToiThieu.KeyPress
        
        If (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
        If (Char.IsControl(e.KeyChar)) Then
            e.Handled = False

            
        End If

        btnCapNhatDuLieu.Enabled = True
    End Sub

    Private Sub txtQDSoTHLienTiepToiDa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQDSoTHLienTiepToiDa.KeyPress
        If (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
        If (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        End If

        btnCapNhatDuLieu.Enabled = True
    End Sub

    Private Sub setTextDefault(ByVal gb As GroupBox, ByVal strFill As String)
        'Try
        '    For Each t As TextBox In gb.Controls
        '        t.Text = strFill
        '    Next
        'Catch ex As Exception
        '    For Each t As TextBox In gb.Controls
        '        t.Text = strFill
        '    Next
        'End Try

        txtMaMonHoc.Text = ""
        txtTenMonHoc.Text = ""
        txtQDSoTHLienTiepToiDa.Text = ""
        txtQDSoTHLienTiepToiThieu.Text = ""
    End Sub

    Private Sub gbThongTinMonHoc_default()
        setTextDefault(gbThongTinMonHoc, "")

        txtMaMonHoc.BackColor = Color.AliceBlue
    End Sub

    Private Sub gridDSGiaoVien_Default()
        gridDSGiaoVien.Rows.Clear()
        ''Duyet tung cell cua grid va doi gia tri
        'Dim iSoDong As Integer = gridDSGiaoVien.Rows.Count
        'Dim iSocot As Integer = gridDSGiaoVien.Columns.Count

        'For i As Integer = 0 To (iSoDong - 1)
        '    For j As Integer = 1 To (iSocot - 1)
        '        gridDSGiaoVien.Rows(i).Cells(j).Value = ""
        '    Next
        'Next

        'gridDSGiaoVien.ClearSelection()
    End Sub

    Private Sub setEnableForm(ByVal frm As UserControl, ByVal enable As Boolean)
        Try
            'For Each t As GroupBox In frm.Controls
            't.Enabled = enable
            'Next
            gbThongTinMonHoc.Enabled = False
            gbDanhSachGiaoVien.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class