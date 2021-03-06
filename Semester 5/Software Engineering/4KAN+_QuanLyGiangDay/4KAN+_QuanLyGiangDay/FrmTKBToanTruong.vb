Imports DTO
Imports BUS

Public Class frmTKBToanTruong

#Region "HÀM PHỤ"
#Region "TẠO DATAGRIDVIEW THỜI KHÓA BIỂU"

    Private Sub KhoiTaoDataGridView(ByVal dgvTKB As DataGridView)
        Dim thamsodto As ThamSoDTO
        Dim thamsobus As New ThamSoBUS
        thamsodto = thamsobus.LayThamSo()

        With dgvTKB

            .Columns.Add("STT", "STT")
            .Columns(0).DefaultCellStyle.BackColor = Color.SkyBlue
            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(0).ReadOnly = True
            .Columns.Add("LopHoc", "Lớp học")
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            ' Thêm các cột Thứ i - T j
            Dim i As Integer = 2
            For thu As Integer = 2 To 7
                For tiet As Integer = 1 To thamsodto.SoTietToiDaTrongNgay
                    Dim Name As String = "Thu" + thu.ToString() + "T" + tiet.ToString()
                    Dim HeaderText As String = "Thứ " + thu.ToString() + " - T" + tiet.ToString()
                    .Columns.Add(Name, HeaderText)
                    .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    i += 1
                Next
            Next

            .Columns("STT").Width = 40
            .Columns("LopHoc").Width = 100
            .RowHeadersVisible = False
        End With
    End Sub
#End Region
#Region "TẠO GROUPBOX KHỐI"
    Private Sub KhoiTaoGroupBoxKhoi(ByVal gb As GroupBox)
        Dim khoibus As New KhoiBUS()
        Dim arr As IList = khoibus.LayDanhSach()
        Dim strText As String
        Dim strName As String
        Dim rb As RadioButton
        Dim i As Integer

        For i = 0 To arr.Count - 1
            Dim khoidto As KhoiDTO = arr(i)
            rb = New RadioButton()

            strText = khoidto.TenKhoi.Replace("Khoi ", "")
            strName = "rbKhoi" + strText

            ' Tao radio button tuong ung voi mot khoi
            rb = TaoRadioButton( _
                    New Point(68 + i * 50, 14), _
                    strName, _
                    i + 1, _
                    strText, _
                    khoidto.MaKhoi, _
                    AddressOf RadioButton_CheckedChanged _
                )
            gb.Controls.Add(rb)
        Next
        ' Them RadioButton "Tất cả"
        i = arr.Count
        rb = New RadioButton()
        strText = "Tất cả"
        strName = "rbTatCa"

        ' Tao radio button tuong ung voi mot khoi
        rb = TaoRadioButton( _
                New Point(68 + i * 50, 14), _
                strName, _
                i + 1, _
                strText, _
                Nothing, _
                AddressOf RadioButton_CheckedChanged _
            )
        gb.Controls.Add(rb)
        gb.Size = New Size(rb.Location.X + rb.Width + 10, rb.Height + 20)
    End Sub
    ' Tạo RadioButton với các tham số cho trước
    Private Function TaoRadioButton(ByVal Location As Point, ByVal Name As String, _
        ByVal TabIndex As Integer, ByVal Text As String, _
        ByVal Tag As Object, ByVal eh As EventHandler) As RadioButton

        Dim rb As New RadioButton

        rb.AutoSize = True
        rb.Location = Location
        rb.Name = Name
        rb.TabIndex = TabIndex
        rb.TabStop = True
        rb.Text = Text
        rb.Tag = Tag
        rb.UseVisualStyleBackColor = True
        AddHandler rb.CheckedChanged, eh

        Return rb
    End Function
    ' Sự kiện CheckChanged dùng chung cho các radiobutton nằm trong GroupBox gbKhoi
    Private Sub RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim obj As RadioButton = sender
        If (obj.Checked = True) Then
            Dim arrLopHoc As IList
            Dim thamso As ThamSoDTO
            Dim lophoc As LopHocDTO
            Dim phancong As PhanCongDTO

            Dim lophocbus As New LopHocBUS
            Dim thamsobus As New ThamSoBUS
            Dim phancongbus As New PhanCongBUS
            Dim lichlophocbus As New LichLopHocBUS
            Dim giaovienbus As New GiaoVienBUS
            Dim monhocbus As New MonHocBUS

            thamso = thamsobus.LayThamSo()

            dgvTKB.Rows.Clear()

            If (obj.Tag = Nothing) Then
                arrLopHoc = lophocbus.LayDanhSach()
            Else
                Dim strMaKhoi As String = obj.Tag
                arrLopHoc = lophocbus.LayDanhSachCoMaKhoi(strMaKhoi)
            End If

            dgvTKB.Rows.Add(arrLopHoc.Count)
            For i As Integer = 0 To arrLopHoc.Count - 1
                lophoc = arrLopHoc(i)

                dgvTKB.Rows(i).Cells("STT").Value = i + 1
                dgvTKB.Rows(i).Cells("LopHoc").Value = lophoc.TenLopHoc


                Dim arrPhanCong As IList = phancongbus.LayDanhSachCoMaLopHoc(lophoc.MaLopHoc)
                Dim arr As New ArrayList
                arr.Add(New ItemOfComboBox("", ""))
                For iphancong As Integer = 0 To arrPhanCong.Count - 1
                    phancong = arrPhanCong(iphancong)
                    Dim giaovien As GiaoVienDTO = giaovienbus.LayGiaoVienCoMa(phancong.MaGiaoVien)
                    Dim monhoc As MonHocDTO = monhocbus.LayMonHocCoMa(phancong.MaMonHoc)
                    Dim str As String

                    str = monhoc.TenMonHoc + " (" + giaovien.TenTat + ")"
                    arr.Add(New ItemOfComboBox(str, phancong.MaPhanCong))

                    Dim arrLichLopHoc As IList = lichlophocbus.LayDanhSachCoMaPhanCong(phancong.MaPhanCong)
                    For ilichlophoc As Integer = 0 To arrLichLopHoc.Count - 1
                        giaovien = giaovienbus.LayGiaoVienCoMa(phancong.MaGiaoVien)
                        monhoc = monhocbus.LayMonHocCoMa(phancong.MaMonHoc)
                        Dim lichlophoc As LichLopHocDTO = arrLichLopHoc(ilichlophoc)
                        str = monhoc.TenMonHoc + " (" + giaovien.TenTat + ")"

                        For j As Integer = 0 To lichlophoc.SoTietHoc - 1
                            Dim Name = "Thu" + lichlophoc.Thu.ToString() + "T" + (lichlophoc.TietHocBatDau + j).ToString()
                            dgvTKB.Rows(i).Cells(Name).value = str
                        Next
                    Next
                Next


                'Dim dgvCBC As New DataGridViewComboBoxCell
                'dgvCBC.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                'dgvCBC.DataSource = arr
                'dgvCBC.DisplayMember = "Chuoi"
                'dgvCBC.ValueMember = "MaPhanCong"
                'dgvCBC.Tag = New TagOfCell
                'For j As Integer = 2 To dgvTKB.Columns.Count - 1
                '    row.Cells.Add(dgvCBC.Clone())
                'Next
                'dgvTKB.Rows.Add(row)
            Next

            lophocbus.Close()
            thamsobus.Close()
            phancongbus.Close()
            lichlophocbus.Close()
            giaovienbus.Close()
            monhocbus.Close()
        End If
    End Sub
#End Region
#End Region
    Private Sub FrmTKBToanTruong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KhoiTaoGroupBoxKhoi(gbKhoi)
        KhoiTaoDataGridView(dgvTKB)
    End Sub


    Private Sub dgvTKB_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvTKB.CellBeginEdit
        'Dim dgv As DataGridView = sender
        'Dim cbc As DataGridViewComboBoxCell = dgv.Rows(e.RowIndex).Cells(e.ColumnIndex)


    End Sub

    Private Sub dgvTKB_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTKB.CellEndEdit
        'Dim dgv As DataGridView = sender
        'Dim rowIndex As Integer = e.RowIndex
        'Dim columnIndex As Integer = e.ColumnIndex
        'Dim cell As DataGridViewComboBoxCell = dgv.Rows(rowIndex).Cells(columnIndex)

        'Dim i As Integer = 1
        '' Bo nhung o cua mon hoc duoc chon truoc do
        'While (columnIndex + i < dgv.Columns.Count And dgvTKB.Rows(rowIndex).Cells(columnIndex + i).ReadOnly = True)
        '    dgvTKB.Rows(rowIndex).Cells(columnIndex + i).ReadOnly = False
        '    dgvTKB.Rows(rowIndex).Cells(columnIndex + i).Value = ""
        '    i += 1
        'End While

        'If cell.Value = "" Then
        '    Return
        'End If

        'Dim tagofcell As TagOfCell = cell.Tag
        'tagofcell.MaPhanCong = cell.Value

        'Dim phancongbus As New PhanCongBUS
        'Dim phancong As PhanCongDTO = phancongbus.LayPhanCongCoMa(tagofcell.MaPhanCong)
        ''Chi them cung mon hoc neu o truoc do khong phai mon hoc dang duoc chon
        'If dgvTKB.Rows(rowIndex).Cells(columnIndex - 1).Value <> cell.Value Then
        '    For j As Integer = 1 To phancong.SoTietHocLienTiepToiThieu - 1
        '        dgvTKB.Rows(rowIndex).Cells(columnIndex + j).Value = cell.Value
        '        dgvTKB.Rows(rowIndex).Cells(columnIndex + j).ReadOnly = True
        '    Next
        'End If
        'phancongbus.Close()
    End Sub

    Private Sub btnXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuat.Click
        If (dgvTKB Is Nothing) Then
            Throw New ArgumentNullException("No DataGridView was provided for export")
        End If

        Using saveFileDialog As SaveFileDialog = GetExcelSaveFileDialog()
            If (saveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                Dim fileName As String = saveFileDialog.FileName
                ExcelGenerator.Generate(dgvTKB).Save(fileName)
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