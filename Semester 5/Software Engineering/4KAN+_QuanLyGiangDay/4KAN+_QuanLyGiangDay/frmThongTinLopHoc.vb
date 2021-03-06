Imports BUS
Imports DTO

Public Class frmThongTinLopHoc

    Dim flag_taolophoc As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lhBus As New LopHocBUS()
        Dim DSLH As IList

        DSLH = lhBus.LayDanhSach()

        With Me.gridDSLopHoc
            .ColumnCount = 4
            'Canh lề giữa
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).Name = "gird_column_STT"
            .Columns(0).HeaderText = "STT"
            .Columns(0).Width = 80
            .Columns(0).ReadOnly = True
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns(1).Name = "grid_column_MaLopHoc"
            .Columns(1).HeaderText = "Mã Lớp Học"
            .Columns(1).ReadOnly = True
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable


            .Columns(2).Name = "grid_column_TenLopHoc"
            .Columns(2).HeaderText = "Tên Lớp Học"
            .Columns(2).ReadOnly = False
            '.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns(3).Name = "grid_column_MaKhoi"
            .Columns(3).HeaderText = "Mã Khối"
            .Columns(3).Visible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With
        rd_Checked_Changed("KTất cả")
        'rdAll_Khoi_CheckedChanged(sender, e)
        Me.gridDSLopHoc.ClearSelection()
        'Me.gridDSLopHoc.SelectedRows.Clear()
        'Me.gridDSLopHoc.CurrentCell.Selected = False

        Init_LichRanh()
        gridDSLopHoc.ClearSelection()
    End Sub

    Private Sub Init_LichRanh()
        Dim thamsoBus As New ThamSoBUS()
        Dim thamsoDto As ThamSoDTO = thamsoBus.LayThamSo()
        Dim SoTietToiDaTrongNgay As Byte = thamsoDto.SoTietToiDaTrongNgay()
        Dim TietGay As Byte = thamsoDto.TietGay()
        'Columns
        With Me.gridLichRanh
            .ColumnCount = 8
            'Canh lề giữa
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim Thu() As String = {"Tiết", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy", "Chủ nhật"}
            Dim Name() As String = {"Tiet", "Thuhai", "Thuba", "Thutu", "Thunam", "Thusau", "Thubay", "Chunhat"}
            For i As Integer = 0 To 7
                .Columns(i).Name = "grid_conlumn_" + Name(i)
                .Columns(i).HeaderText = Thu(i)
                .Columns(i).Width = 75
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
            .Columns(0).Width = 55
            .Columns(0).ReadOnly = True
        End With
        'Rows
        With Me.gridLichRanh
            Dim cot As Byte = .Columns.Count()
            For i As Integer = 0 To SoTietToiDaTrongNgay - 1
                .Rows.Add()
                .Rows(i).Cells(0).Value = i + 1
                For j As Integer = 1 To cot - 1
                    .Rows(i).Cells(j).Value = ""
                Next
            Next i
            .CurrentCell.Selected = False
        End With
        SetColor_GridLichRanh()
        SetEnabled(Me.gb_ThongTinMonHoc, False)
        SetEnabled_Label(Me.gb_ThongTinMonHoc, True)
        SetEnabled(Me.gb_LichRanh, False)
        Me.btnTaoLopHocMoi.Enabled = True
        Me.btnXuatRaTapTin.Enabled = True
        Me.pn_Khoi.Enabled = True
    End Sub
    Private Sub SetLichRanh()

        'Rows
        With Me.gridLichRanh
            Dim cot As Byte = .Columns.Count()
            Dim dong As Byte = .Rows.Count()
            For i As Integer = 0 To dong - 1
                For j As Integer = 1 To cot - 2
                    .Rows(i).Cells(j).Value = "Rảnh"
                Next
                .Rows(i).Cells(cot - 1).Value = "Bận"
            Next i
            '.CurrentCell.Selected = False
        End With
    End Sub
    Private Sub SetColor_GridDSLopHoc()
        With Me.gridDSLopHoc
            For i As Integer = 1 To .Rows.Count()
                .Rows(i - 1).Cells(0).Style.ForeColor = Color.Red

                .Rows(i - 1).Cells(0).Style.BackColor = Color.LightSkyBlue
                .Rows(i - 1).Cells(1).Style.BackColor = Color.PaleTurquoise
            Next i
        End With
    End Sub
    Private Sub SetColor_GridLichRanh()
        With Me.gridLichRanh
            Dim thamsoBus As New ThamSoBUS()
            Dim thamsoDto As ThamSoDTO = thamsoBus.LayThamSo()
            Dim SoTietToiDaTrongNgay As Byte = thamsoDto.SoTietToiDaTrongNgay()
            Dim TietGay As Byte = thamsoDto.TietGay()
            Dim cot As Byte = .Columns.Count()
            For i As Integer = 0 To SoTietToiDaTrongNgay - 1
                .Rows(i).Cells(0).Style.ForeColor = Color.Red
                .Rows(i).Cells(0).Style.BackColor = Color.LightSkyBlue
                For j As Integer = 1 To cot - 2
                    If i < TietGay Then
                        .Rows(i).Cells(j).Style.BackColor = Color.PaleTurquoise
                    End If
                Next
                .Rows(i).Cells(cot - 1).Style.BackColor = Color.Red
            Next i
            .CurrentCell.Selected = False
        End With
    End Sub
    Private Sub rdAll_Khoi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdAll_Khoi.CheckedChanged
        If Me.rdAll_Khoi.Checked = False Then
            Return
        End If
        rd_Checked_Changed("KTất cả")
        'Me.gridDSLopHoc.ClearSelection()
    End Sub
    Private Sub rd_Checked_Changed(ByVal i_Khoi As String)
        Dim lhBus As New LopHocBUS()
        Dim DSLH As IList
        DSLH = lhBus.LayDanhSach()

        With Me.gridDSLopHoc
            If .RowCount() <> 0 Then
                .Rows.Clear()
            End If
            Dim dem As Integer = 1
            If i_Khoi = "KTất cả" Then
                Try
                    For i As Integer = 0 To DSLH.Count() - 1
                        Dim LopHoc As LopHocDTO
                        LopHoc = DSLH(i)
                        .Rows.Add()
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = LopHoc.MaLopHoc()
                        .Rows(i).Cells(2).Value = LopHoc.TenLopHoc()
                        .Rows(i).Cells(3).Value = LopHoc.MaKhoi()
                    Next i
                Catch ex As Exception

                End Try
                SetColor_GridDSLopHoc()
                .ClearSelection()

                Return
            End If
            For i As Integer = 1 To DSLH.Count()
                Dim LopHoc As LopHocDTO
                LopHoc = DSLH(i - 1)
                If LopHoc.MaKhoi() = i_Khoi Then
                    .Rows.Add()
                    .Rows(dem - 1).Cells(0).Value = dem
                    .Rows(dem - 1).Cells(1).Value = LopHoc.MaLopHoc()
                    .Rows(dem - 1).Cells(2).Value = LopHoc.TenLopHoc()
                    dem = dem + 1
                End If
            Next i
            SetColor_GridDSLopHoc()
            .ClearSelection()
            '.SelectedRows.Clear()
            '.CurrentCell.Selected = False
        End With

    End Sub
    Private Sub rdKhoi12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKhoi12.CheckedChanged
        If Me.rdKhoi12.Checked = False Then
            Return
        End If
        rd_Checked_Changed("K12")
        'Me.gridDSLopHoc.ClearSelection()
    End Sub
    Private Sub rdKhoi11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKhoi11.CheckedChanged
        If Me.rdKhoi11.Checked = False Then
            Return
        End If
        rd_Checked_Changed("K11")
        'Me.gridDSLopHoc.ClearSelection()
    End Sub
    Private Sub rdKhoi10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKhoi10.CheckedChanged
        If Me.rdKhoi10.Checked = False Then
            Return
        End If
        rd_Checked_Changed("K10")
        'Me.gridDSLopHoc.ClearSelection()
    End Sub

    Private Sub btnTrangThai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrangThai.Click

        Dim TrangThai() As String = {"Bận", "Rảnh"}
        Dim flag As Integer = 0
        With Me.gridLichRanh
            If btnTrangThai.Text = "Bận Hết" Then
                btnTrangThai.Text = "Rảnh Hết"
            Else
                btnTrangThai.Text = "Bận Hết"
                flag = 1
            End If
            For i As Integer = 0 To 9
                For j As Integer = 1 To 6
                    .Rows(i).Cells(j).Value = TrangThai(flag)
                Next
            Next i
        End With
        Me.btnCapNhatDuLieu.Enabled = True

    End Sub


    Private Sub gridLichRanh_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridLichRanh.CellClick
        Dim TrangThai() As String = {"Rảnh", "Bận", "BBXếp"}
        Dim flag As Integer
        With Me.gridLichRanh
            '.Columns(1).ReadOnly = True

            Dim cot As Integer = e.ColumnIndex
            Dim dong As Integer = e.RowIndex
            Try

                If cot <> 0 And dong <> -1 Then
                    Me.btnCapNhatDuLieu.Enabled = True
                    Dim temp As String = .Rows(dong).Cells(cot).Value
                    If .Rows(dong).Cells(cot).Value = "Rảnh" Then
                        flag = 1
                    Else
                        If .Rows(dong).Cells(cot).Value = "Bận" Then
                            flag = 2
                        Else
                            flag = 0
                        End If
                    End If
                    .Rows(dong).Cells(cot).Value = TrangThai(flag)
                Else
                    If cot = 0 And dong <> -1 Then
                        Me.btnCapNhatDuLieu.Enabled = True
                        For i As Integer = 1 To .Columns.Count()
                            If .Rows(dong).Cells(i).Value = "Rảnh" Then
                                .Rows(dong).Cells(i).Value = "Bận"
                            Else
                                If .Rows(dong).Cells(i).Value = "Bận" Then
                                    .Rows(dong).Cells(i).Value = "Rảnh"
                                End If
                            End If
                        Next
                    End If
                    If dong = -1 And cot <> 0 Then
                        Me.btnCapNhatDuLieu.Enabled = True
                        For i As Integer = 0 To .Rows.Count() - 1
                            If .Rows(i).Cells(cot).Value = "Rảnh" Then
                                .Rows(i).Cells(cot).Value = "Bận"
                            Else
                                If .Rows(i).Cells(cot).Value = "Bận" Then
                                    .Rows(i).Cells(cot).Value = "Rảnh"
                                End If
                            End If
                        Next
                    End If
                End If

            Catch ex As Exception

            End Try
        End With
    End Sub

    Private Sub gridDSLopHoc_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridDSLopHoc.SelectionChanged
        With Me.gridDSLopHoc
            Dim i_TenLopHoc As String
            Dim i_MaLopHoc As String
            Dim iVitri As Integer

            'MessageBox.Show("SelecttionChanged")
            If gridDSLopHoc.Rows(0).Cells(0).Value = Nothing Then
                Return
            End If
            If .CurrentCell.Selected = False Then
                Return
            End If
            i_MaLopHoc = .SelectedCells(1).Value
            i_TenLopHoc = .SelectedCells(2).Value
            iVitri = .SelectedCells(0).Value

            If Me.flag_taolophoc = True Then
                Dim result As DialogResult
                result = MessageBox.Show("Ban muon cap nhat lop vua tao", "kien", MessageBoxButtons.YesNoCancel)
                If result = Windows.Forms.DialogResult.Yes Then
                    CapNhatDuLieu()
                    .Rows(iVitri - 1).Selected = True
                Else
                    If result = Windows.Forms.DialogResult.Cancel Then
                        .ClearSelection()
                        Return
                    End If
                    Me.flag_taolophoc = False
                    Me.rdAll_Khoi.Visible = True
                    Me.btnCapNhatDuLieu.Enabled = False
                End If
            End If




            'i_MaLopHoc = .SelectedCells(1).Value
            'i_TenLopHoc = .SelectedCells(2).Value
            'iVitri = .SelectedCells(0).Value

            Me.txtMaLophoc.Text = i_MaLopHoc
            'Me.txtMaLophoc.Enabled = True
            Me.txtMaLophoc.ReadOnly = True
            Me.txtMaLophoc.ForeColor = Color.Black
            Me.txtMaLophoc.BackColor = Color.PaleTurquoise
            Me.txtMaLophoc.TextAlign = HorizontalAlignment.Center
            Dim rangbuoclophocBus As New RangBuocLopHocBUS()
            Dim DSRB As ArrayList
            DSRB = rangbuoclophocBus.LayDanhSach(i_MaLopHoc)
            Load_LichRanh(DSRB)


            Me.txtTenLophoc.Enabled = True
            Me.txtTenLophoc.Text = i_TenLopHoc
            Me.txtTenLophoc.TextAlign = HorizontalAlignment.Center

            Me.btnCapNhatDuLieu.Enabled = False
            Me.btnXoaLopHocNay.Enabled = True

        End With
        'SelectChanged()

    End Sub

    Private Sub Load_LichRanh(ByVal i_DSRB As ArrayList)
        Me.btnXoaLopHocNay.Enabled = True
        SetEnabled(Me.gb_LichRanh, True)
        With Me.gridLichRanh
            Dim dong_DSRB = i_DSRB.Count()
            Dim rangbuoclophocDto As RangBuocLopHocDTO
            Dim TrangThai() As String = {"Rảnh", "Bận", "BBXếp"}

            SetLichRanh()

            For i As Integer = 0 To dong_DSRB - 1

                rangbuoclophocDto = i_DSRB(i)
                Dim tiethoc As Byte = rangbuoclophocDto.TietHoc()
                Dim thu As Byte = rangbuoclophocDto.Thu()
                Dim trthai As Byte = rangbuoclophocDto.TrangThai()
                .Rows(tiethoc - 1).Cells(thu - 1).Value = TrangThai(trthai)
                '.Rows(rangbuoclophocDto.TietHoc() - 1).Cells(rangbuoclophocDto.Thu() - 1).Value = TrangThai(rangbuoclophocDto.TrangThai())
            Next i

            '.CurrentCell.Selected = False
        End With

    End Sub
    Private Sub gridDSLopHoc_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridDSLopHoc.CellMouseClick
        ' MessageBox.Show("CellMouseClick")
    End Sub

    Private Sub gridDSLopHoc_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridDSLopHoc.CellClick
        'MessageBox.Show("CellClick")
    End Sub

    Private Sub gridDSLopHoc_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridDSLopHoc.ColumnHeaderMouseClick
        'MessageBox.Show("ColumnHeaderMouseClick")
        'gridDSLopHoc.Columns(e.ColumnIndex).SortMode = DataGridViewColumnSortMode.Automatic
    End Sub


    Private Sub btnTaoLopHocMoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaoLopHocMoi.Click
        'Tao moi mot gia tri
        Me.flag_taolophoc = True
        Me.btnTrangThai.Text = "Bận Hết"
        Me.gridDSLopHoc.ClearSelection()
        Dim dulieuBus As New DuLieuBUS()

        Dim tempkhoi As RadioButton = Check_RadioButton(Me.pn_Khoi)
        If tempkhoi.Name() = Me.rdAll_Khoi.Name() Then
            Me.rdKhoi10.Checked = True
        End If

        'Me.rdAll_Khoi.Enabled = False
        Me.rdAll_Khoi.Visible = False
        Me.btnXoaLopHocNay.Enabled = False
        Me.btnCapNhatDuLieu.Enabled = True

        Me.txtMaLophoc.Text = dulieuBus.TaoMaLopHoc()
        Me.txtMaLophoc.BackColor = Color.PaleTurquoise
        Me.txtMaLophoc.TextAlign = HorizontalAlignment.Center

        Me.txtTenLophoc.Enabled = True
        Me.txtTenLophoc.Clear()
        Me.txtTenLophoc.TextAlign = HorizontalAlignment.Center
        Me.txtTenLophoc.Focus()
        SetEnabled(Me.gb_LichRanh, True)

        SetLichRanh()
    End Sub
    Private Sub btnCapNhatDuLieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhatDuLieu.Click
        Dim te As String = Me.txtTenLophoc.Text().Trim()
        Me.txtTenLophoc.Text = Me.txtTenLophoc.Text().Trim()
        If Me.txtTenLophoc.Text() = "" Then
            MessageBox.Show("Ban chua nhap ten")
            Me.txtTenLophoc.Clear()
            Me.txtTenLophoc.Focus()
            Return
        End If
        Try
            Dim iVitri As Byte = Me.gridDSLopHoc.SelectedCells(0).Value() - 1


            CapNhatDuLieu()
            Me.gridDSLopHoc.Rows(iVitri).Selected = True
            SelectChanged()

        Catch ex As Exception

            CapNhatDuLieu()
            Dim iVitri As Byte = Me.gridDSLopHoc.Rows.Count() - 1
            Me.gridDSLopHoc.Rows(iVitri).Selected = True
            SelectChanged()

        End Try

    End Sub
    Private Sub btnXoaLopHocNay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaLopHocNay.Click
        Dim iVitri As Byte = Me.gridDSLopHoc.SelectedCells(0).Value() - 1
        Dim lophocBus As New LopHocBUS()
        lophocBus.Xoa(Me.txtMaLophoc.Text())
        Dim i_makhoi As RadioButton = Check_RadioButton(Me.pn_Khoi)
        rd_Checked_Changed("K" + i_makhoi.Text())
        Try
            If Me.gridDSLopHoc.Rows.Count() = iVitri Then
                iVitri = iVitri - 1
            End If
            Me.gridDSLopHoc.Rows(iVitri).Selected = True
            SelectChanged()
        Catch ex As Exception
            SetEnabled(gb_LichRanh, False)
            Me.txtMaLophoc.Clear()
            Me.txtTenLophoc.Clear()
            Me.txtTenLophoc.Enabled = False
            Me.btnXoaLopHocNay.Enabled = False
        End Try

        'MessageBox.Show("Xoa thanh cong")
    End Sub
    Private Sub SetEnabled(ByVal gb As GroupBox, ByVal b As Boolean)
        For Each t As Control In gb.Controls
            Try
                t.Enabled = b
            Catch ex As Exception
            End Try
        Next
    End Sub
    Private Sub SetEnabled_nUD(ByVal gb As GroupBox, ByVal b As Boolean)
        For Each t As Control In gb.Controls
            Try
                Dim temp As NumericUpDown = t
                temp.Enabled = b
            Catch ex As Exception
            End Try
        Next
    End Sub
    Private Sub SetEnabled_btn(ByVal gb As GroupBox, ByVal b As Boolean)
        For Each t As Control In gb.Controls
            Try
                Dim temp As Button = t
                temp.Enabled = b
            Catch ex As Exception
            End Try
        Next
    End Sub
    Private Sub SetEnabled_Label(ByVal gb As GroupBox, ByVal b As Boolean)
        For Each t As Control In gb.Controls
            Try
                Dim temp As Label = t
                temp.Enabled = b
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Function Check_RadioButton1(ByVal pn As Panel) As String
        Dim kq As String = Nothing
        For Each ct As Control In pn.Controls
            Try
                Dim temp As RadioButton = ct
                If temp.Checked = True Then
                    kq = temp.Name()
                End If
            Catch ex As Exception

            End Try
        Next
        Return kq
    End Function
    Private Function Check_RadioButton(ByVal pn As Panel) As RadioButton
        Dim kq As New RadioButton()
        For Each ct As Control In pn.Controls
            Try
                Dim temp As RadioButton = ct
                If temp.Checked = True Then
                    kq = temp
                End If
            Catch ex As Exception

            End Try
        Next
        Return kq
    End Function

    Private Function LayTrangThai(ByVal tt As String) As Byte
        If tt = "Rảnh" Then
            Return 0
        End If
        If tt = "Bận" Then
            Return 1
        End If
        If tt = "BBXếp" Then
            Return 2
        End If
    End Function



    Private Sub CapNhatDuLieu()
        Dim lophocBus As New LopHocBUS()
        Dim lophocDto As New LopHocDTO()

        Dim rangbuoclophocBus As New RangBuocLopHocBUS()
        Dim array_rangbuoclophoc As New ArrayList()

        Dim i_makhoi As RadioButton = Check_RadioButton(Me.pn_Khoi)
        With lophocDto
            .MaKhoi = "K" + i_makhoi.Text()
            .MaLopHoc = Me.txtMaLophoc.Text()
            .TenLopHoc = Me.txtTenLophoc.Text()
        End With
        Dim dong As Byte = Me.gridLichRanh.Rows.Count()
        Dim cot As Byte = Me.gridLichRanh.Columns.Count()


        Dim dulieuBus As New DuLieuBUS()

        If Me.flag_taolophoc = True Then
            lophocBus.Them(lophocDto)
            For i As Byte = 1 To cot - 1
                For j As Byte = 0 To dong - 1
                    Dim rangbuoclophocDto As New RangBuocLopHocDTO()

                    rangbuoclophocDto.MaRangBuocLopHoc = dulieuBus.TaoMaRangBuocLopHoc()
                    rangbuoclophocDto.MaLopHoc = Me.txtMaLophoc.Text()
                    rangbuoclophocDto.Thu = i + 1
                    rangbuoclophocDto.TietHoc = j + 1
                    rangbuoclophocDto.TrangThai = LayTrangThai(Me.gridLichRanh.Rows(j).Cells(i).Value())
                    rangbuoclophocBus.Them(rangbuoclophocDto)
                Next
            Next
            Me.flag_taolophoc = False
        Else
            lophocBus.Sua(lophocDto)
            For i As Byte = 1 To cot - 1
                For j As Byte = 0 To dong - 1
                    Dim rangbuoclophocDto As New RangBuocLopHocDTO()

                    rangbuoclophocDto.MaLopHoc = Me.txtMaLophoc.Text()
                    rangbuoclophocDto.Thu = i + 1
                    rangbuoclophocDto.TietHoc = j + 1
                    rangbuoclophocDto.TrangThai = LayTrangThai(Me.gridLichRanh.Rows(j).Cells(i).Value())
                    rangbuoclophocBus.Sua(rangbuoclophocDto)
                Next
            Next

        End If
        i_makhoi.Checked = True
        rd_Checked_Changed("K" + i_makhoi.Text)
        Me.btnCapNhatDuLieu.Enabled = False
        Me.gridLichRanh.ClearSelection()
        MessageBox.Show("Cap nhat thanh cong")
        Me.rdAll_Khoi.Visible = True
        'Me.rdAll_Khoi.Enabled = True

    End Sub

    Private Sub SelectChanged()
        With Me.gridDSLopHoc
            Dim i_TenLopHoc As String = .SelectedCells(2).Value
            Dim i_MaLopHoc As String = .SelectedCells(1).Value
            Dim iVitri As Integer = .SelectedCells(0).Value

            Me.flag_taolophoc = False
            Me.btnCapNhatDuLieu.Enabled = False
            Me.txtMaLophoc.Text = i_MaLopHoc
            ' Me.txtMaLophoc.Enabled = True
            'Me.txtMaLophoc.ReadOnly = True
            Me.txtMaLophoc.ForeColor = Color.Red
            Me.txtMaLophoc.BackColor = Color.PaleTurquoise
            Me.txtMaLophoc.TextAlign = HorizontalAlignment.Center
            Dim rangbuoclophocBus As New RangBuocLopHocBUS()
            Dim DSRB As ArrayList
            DSRB = rangbuoclophocBus.LayDanhSach(i_MaLopHoc)
            Load_LichRanh(DSRB)


            '           Dim i_TenLopHoc As String = .SelectedCells(2).Value
            Me.txtTenLophoc.Enabled = True
            Me.txtTenLophoc.Text = i_TenLopHoc
            Me.txtTenLophoc.TextAlign = HorizontalAlignment.Center

            Me.btnCapNhatDuLieu.Enabled = False
            Me.btnXoaLopHocNay.Enabled = True

        End With
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
        If (gridDSLopHoc Is Nothing) Then
            Throw New ArgumentNullException("No DataGridView was provided for export")
        End If

        Using saveFileDialog As SaveFileDialog = GetExcelSaveFileDialog()
            If (saveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                Dim fileName As String = saveFileDialog.FileName
                ExcelGenerator.Generate(gridDSLopHoc).Save(fileName)
                Process.Start(fileName)
            End If
        End Using
    End Sub


End Class
