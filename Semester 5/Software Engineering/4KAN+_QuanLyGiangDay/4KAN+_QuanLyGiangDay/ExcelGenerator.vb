Imports CarlosAg.ExcelXmlWriter
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class ExcelGenerator
    Public Shared Function Generate(ByVal dataGridView As DataGridView) As Workbook
        Dim workbook As New Workbook
        Dim worksheet As Worksheet = workbook.Worksheets.Add("Sheet 1")
        Dim worksheetRow As New WorksheetRow
        Dim dataGridViewColumn As DataGridViewColumn
        For Each dataGridViewColumn In dataGridView.Columns
            ' thêm
            If dataGridViewColumn.Visible = True Then
                worksheet.Table.Columns.Add(New WorksheetColumn(dataGridViewColumn.Width))
                worksheetRow.Cells.Add(New WorksheetCell(dataGridViewColumn.HeaderText))
            End If

        Next
        worksheet.Table.Rows.Insert(0, worksheetRow)
        Dim worksheetDefaultStyle As WorksheetStyle = ExcelGenerator.GetWorksheetStyle(dataGridView.DefaultCellStyle, "Default")
        workbook.Styles.Add(worksheetDefaultStyle)
        Dim rowIndex As Integer
        For rowIndex = 0 To dataGridView.RowCount - 1
            worksheetRow = worksheet.Table.Rows.Add
            Dim columnIndex As Integer
            For columnIndex = 0 To dataGridView.ColumnCount - 1
                Dim cell As DataGridViewCell = dataGridView.Item(columnIndex, rowIndex)

                'thêm
                If cell.Visible = False Then
                    Continue For
                End If

                Dim cellStyle As WorksheetStyle = ExcelGenerator.GetWorksheetStyle(cell.InheritedStyle, String.Concat(New Object() {"column", columnIndex, "row", rowIndex}))
                If (Not cellStyle Is Nothing) Then
                    workbook.Styles.Add(cellStyle)
                Else
                    cellStyle = worksheetDefaultStyle
                End If
                Dim dataType As DataType = ExcelGenerator.GetDataType(cell.ValueType)
                worksheetRow.Cells.Add(cell.FormattedValue.ToString, dataType, cellStyle.ID)
            Next columnIndex
        Next rowIndex
        Return workbook
    End Function

    Private Shared Function GetColorName(ByVal color As Color) As String
        Return ("#" & color.ToArgb.ToString("X").Substring(2))
    End Function

    Private Shared Function GetDataType(ByVal valueType As Type) As DataType
        If (Not valueType Is GetType(DateTime)) Then
            If (valueType Is GetType(String)) Then
                Return DataType.String
            End If
            If ((((((valueType Is GetType(SByte)) OrElse (valueType Is GetType(Byte))) OrElse ((valueType Is GetType(Short)) OrElse (valueType Is GetType(UInt16)))) OrElse (((valueType Is GetType(Integer)) OrElse (valueType Is GetType(UInt32))) OrElse ((valueType Is GetType(Long)) OrElse (valueType Is GetType(UInt64))))) OrElse ((valueType Is GetType(Single)) OrElse (valueType Is GetType(Double)))) OrElse (valueType Is GetType(Decimal))) Then
                Return DataType.Number
            End If
        End If
        Return DataType.String
    End Function

    Private Shared Function GetWorksheetStyle(ByVal dataGridViewCellStyle As DataGridViewCellStyle, ByVal id As String) As WorksheetStyle
        Dim worksheetStyle As WorksheetStyle = Nothing
        If (Not dataGridViewCellStyle Is Nothing) Then
            worksheetStyle = New WorksheetStyle(id)
            If Not dataGridViewCellStyle.BackColor.IsEmpty Then
                worksheetStyle.Interior.Color = ExcelGenerator.GetColorName(dataGridViewCellStyle.BackColor)
                worksheetStyle.Interior.Pattern = StyleInteriorPattern.Solid
            End If
            If Not dataGridViewCellStyle.ForeColor.IsEmpty Then
                worksheetStyle.Font.Color = ExcelGenerator.GetColorName(dataGridViewCellStyle.ForeColor)
            End If
            If (Not dataGridViewCellStyle.Font Is Nothing) Then
                worksheetStyle.Font.Bold = dataGridViewCellStyle.Font.Bold
                worksheetStyle.Font.FontName = dataGridViewCellStyle.Font.Name
                worksheetStyle.Font.Italic = dataGridViewCellStyle.Font.Italic
                worksheetStyle.Font.Size = CInt(dataGridViewCellStyle.Font.Size)
                worksheetStyle.Font.Strikethrough = dataGridViewCellStyle.Font.Strikeout
                worksheetStyle.Font.Underline = IIf(dataGridViewCellStyle.Font.Underline, UnderlineStyle.Single, UnderlineStyle.None)
            End If
            worksheetStyle.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "Black")
            worksheetStyle.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "Black")
            worksheetStyle.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "Black")
            worksheetStyle.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "Black")
        End If
        Return worksheetStyle
    End Function
End Class
