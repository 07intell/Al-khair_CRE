
Module Module2

#Region "Member Variables"

    Const strConnectionString As String = "data source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind;"

    Private strFormat As StringFormat
    'Used to format the grid rows.
    Private arrColumnLefts As New ArrayList()
    'Used to save left coordinates of columns
    Private arrColumnWidths As New ArrayList()
    'Used to save column widths
    Private iCellHeight As Integer = 0
    'Used to get/set the datagridview cell height
    Private iTotalWidth As Integer = 0
    '
    Private iRows As Integer = 0
    'Used as counter
    Private iEndRow As Integer = 0
    'Used as counter
    Private bFirstPage As Boolean = False
    'Used to check whether we are printing first page
    Private bNewPage As Boolean = False
    ' Used to check whether we are printing a new page
    Private iHeaderHeight As Integer = 0
    'Used for the header height
    Public maxPage As Integer

    Public maxrow As Integer

    Public grid(50)

    Public frompages As Integer

    Public topages As Integer

    Public printstart As Boolean

    Public pagesremain As Boolean

#End Region

    Public Sub SheetPrintBegin(ByVal Dgview1 As DataGridView)
        Try
            strFormat = New StringFormat()
            strFormat.Alignment = StringAlignment.Near
            strFormat.LineAlignment = StringAlignment.Center
            strFormat.Trimming = StringTrimming.EllipsisCharacter
            arrColumnLefts.Clear()
            arrColumnWidths.Clear()

            iCellHeight = 0
            bFirstPage = True
            bNewPage = True
            pagesremain = False
            If Print_Preview.cb_pages.SelectedItem.Text.Contains("Print All Pages") Then
                frompages = 0
                topages = pagescount
            ElseIf Print_Preview.cb_pages.SelectedItem.Text.Contains("Print Current Page") Then
                frompages = CInt(Print_Preview.nud_pages.Text) - 1
                topages = CInt(Print_Preview.nud_pages.Text)
            ElseIf Print_Preview.cb_pages.SelectedItem.Text.Contains("Custom Print") Then
                frompages = CInt(Print_Preview.tb_from.Text) - 1
                topages = CInt(Print_Preview.tb_to.Text)
            End If
            For i As Integer = 0 To grid.Count
                If i = frompages Then
                    iRows = grid.GetValue(i)
                End If
                If i = topages Then
                    maxrow = grid.GetValue(i)
                    maxrow -= 1
                    Exit For
                End If
            Next
            ' Calculating Total Widths
            iTotalWidth = 0
            For Each dgvGridCol As DataGridViewColumn In Dgview1.Columns
                iTotalWidth += dgvGridCol.Width
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub


    Public Sub SheetPrint(ByVal sender As System.Object, _
                          ByVal e As System.Drawing.Printing.PrintPageEventArgs, _
                          ByVal Dgview1 As DataGridView, _
                          ByVal Lhead As String, _
                          ByVal Rhead As String, _
                          ByVal CellHeight As Integer)

        Try
            'Set the left margin
            Dim iLeftMargin As Integer = e.MarginBounds.Left
            'Set the top margin
            Dim iTopMargin As Integer = e.MarginBounds.Top
            'Whether more pages have to print or not
            Dim bMorePagesToPrint As Boolean = False
            Dim iTmpWidth As Integer = 0

            'For the first page to print set the cell width and header height
            If bFirstPage Then
                For Each GridCol As DataGridViewColumn In Dgview1.Columns
                    iTmpWidth = CInt(Math.Floor(CDbl(CDbl(GridCol.Width) / CDbl(iTotalWidth) * CDbl(iTotalWidth) * (CDbl(e.MarginBounds.Width) / CDbl(iTotalWidth)))))

                    iHeaderHeight = CInt(e.Graphics.MeasureString(GridCol.HeaderText, GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11

                    ' Save width and height of headres
                    arrColumnLefts.Add(iLeftMargin)
                    arrColumnWidths.Add(iTmpWidth)
                    iLeftMargin += iTmpWidth
                Next
            End If
            'Loop till all the grid rows not get printed
            While iRows <= maxrow
                Dim GridRow As DataGridViewRow = Dgview1.Rows(iRows)
                'Set the cell height
                iCellHeight = GridRow.Height + CellHeight
                Dim iCount As Integer = 0
                'Check whether the current page settings allo more rows to print
                If iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then
                    bNewPage = True
                    bFirstPage = False
                    bMorePagesToPrint = True
                    Exit While
                Else
                    If bNewPage Then
                        'Draw Header
                        e.Graphics.DrawString(Lhead, New Font(Dgview1.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(Lhead, New Font(Dgview1.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 13)

                        Dim strDate As [String] = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString()
                        'Draw Date
                        e.Graphics.DrawString(Rhead, New Font(Dgview1.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(strDate, New Font(Dgview1.Font, FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top - e.Graphics.MeasureString(actype & " Loan Report", New Font(New Font(Dgview1.Font, FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13)

                        'Draw Columns                 
                        iTopMargin = e.MarginBounds.Top
                        For Each GridCol As DataGridViewColumn In Dgview1.Columns
                            e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), _
                                                     New Rectangle(CInt(arrColumnLefts(iCount)), _
                                                                   iTopMargin, _
                                                                   CInt(arrColumnWidths(iCount)), _
                                                                   iHeaderHeight))

                            e.Graphics.DrawRectangle(Pens.Black, _
                                                     New Rectangle(CInt(arrColumnLefts(iCount)), _
                                                                               iTopMargin, _
                                                                               CInt(arrColumnWidths(iCount)), _
                                                                               iHeaderHeight))

                            e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font, _
                                                  New SolidBrush(GridCol.InheritedStyle.ForeColor), _
                                                  New RectangleF(CInt(arrColumnLefts(iCount)), _
                                                                 iTopMargin, _
                                                                 CInt(arrColumnWidths(iCount)), _
                                                                 iHeaderHeight), strFormat)
                            iCount += 1
                        Next
                        bNewPage = False
                        iTopMargin += iHeaderHeight
                    End If
                    iCount = 0
                    'Draw Columns Contents                
                    For Each Cel As DataGridViewCell In GridRow.Cells
                        If Cel.Value IsNot Nothing Then
                            e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font, _
                                                  New SolidBrush(Cel.InheritedStyle.ForeColor), _
                                                  New RectangleF(CInt(arrColumnLefts(iCount)), _
                                                                 CSng(iTopMargin), CInt(arrColumnWidths(iCount)), _
                                                                 CSng(iCellHeight)), strFormat)
                        End If
                        'Drawing Cells Borders 
                        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(CInt(arrColumnLefts(iCount)), _
                                                                           iTopMargin, CInt(arrColumnWidths(iCount)), iCellHeight))

                        iCount += 1
                    Next
                End If
                iRows += 1
                iTopMargin += iCellHeight
            End While
            'If more lines exist, print another page.
            If bMorePagesToPrint Then
                e.HasMorePages = True
                pagesremain = True
            Else
                e.HasMorePages = False
                pagesremain = False
            End If
        Catch exc As Exception
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

End Module