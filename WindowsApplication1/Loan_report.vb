Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO


Public Class Loans_report

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
    Private iRow As Integer = 0
    'Used as counter
    Private bFirstPage As Boolean = False
    'Used to check whether we are printing first page
    Private bNewPage As Boolean = False
    ' Used to check whether we are printing a new page
    Private iHeaderHeight As Integer = 0
    'Used for the header height
    Private pages As Dictionary(Of Integer, pageDetails)

    Dim maxPagesWide As Integer

    Dim maxPagesTall As Integer

    Dim CollectorName As String

#End Region

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure

    Private Sub Loans_report_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
        Form1.Enabled = True
        loan_report = 0
    End Sub

    Private Sub Loans_report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Left = Panel1.Left / 2
        collector_id.Focus()
    End Sub

    Private Sub printprivew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printprivew.Click
        Print_Preview.PrintPreviewControl1.Document = PrintDocument1
        Print_Preview.PrintPreviewControl1.Zoom = 100
        Print_Preview.nud_zoom.Value = 100

        Print_Preview.WindowState = FormWindowState.Maximized
        Print_Preview.ShowDialog()
    End Sub

    Private Sub Btn_loan_report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_loan_report.Click
        System.IO.File.WriteAllText(Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath) & "\Message_log.txt", "")
        Excessprofitgst = False
        If Dgview1.Columns.Count > 0 Then Dgview1.Columns.Clear()
        editpreviousreceipt = False
        Dim collector_loan_id As String
        collector_loan_id = collector_id.Text
        Dgview1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText

        For a As Integer = 0 To dsalbank.Tables("collector_id").Rows.Count - 1
            If collector_loan_id = dsalbank.Tables("collector_id").Rows(a).Item("Account Id") Then
                actype = dsalbank.Tables("collector_id").Rows(a).Item("groups")
                actype1 = dsalbank.Tables("collector_id").Rows(a).Item("groups")
                CollectorName = dsalbank.Tables("collector_id").Rows(a).Item("Collector Name")
                Exit For
            End If
        Next

        If actype = "DD" Then
            MsgBox("Error", MsgBoxStyle.OkOnly, "Enterd ID is Daily Deposit Account ID")
            Exit Sub
        End If

        receiptdate = day
        loan_report = 1

        Module1.Collector_Ac_list()
        Form1.manual_number = 0
        With Dgview1
            .Columns.Add("Sl_no", "Sl.No")
            .Columns(0).Width = 40
            .Columns.Add("Account_number", "Account Number")
            .Columns(1).Width = 100
            .Columns.Add("Account_holder_name", "Account Holder Name")
            .Columns(2).Width = 150
            .Columns.Add("Disburse_date", "Disburse Date")
            .Columns(3).Width = 90
            .Columns.Add("Loan_amount", "Loan Amount")
            .Columns(4).Width = 60
            .Columns.Add("Returned_amount", "Returned Amount")
            .Columns(5).Width = 70
            .Columns.Add("Balance_amount", "Balance Amount")
            .Columns(6).Width = 70
            .Columns.Add("last_month_deposit", "Last Month Deposit")
            .Columns(7).Width = 80
            .Columns.Add("Month_request", "Loan Duration")
            .Columns(8).Width = 80
            .Columns.Add("Installment_Amount", "Inst Amount")
            .Columns(8).Width = 60
            .RowHeadersWidth = 30
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .AllowDrop = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeColumns = False
        End With

        For Each column In Dgview1.Columns
            column.SortMode = DataGridViewColumnSortMode.Automatic
        Next

        ' last_month_deposit()

        Dim loanee_name As String

        Try
            For A As Integer = 0 To datatable.Rows.Count - 1
                With datatable.Rows(A)
                    If actype = "DL" Or actype = "ML" Then
                        loanee_name = .Item("id_by_name").ToString.Substring(0, .Item("id_by_name").ToString.Length - 10)
                    Else
                        loanee_name = .Item("id_by_name").ToString.Substring(0, .Item("id_by_name").ToString.Length - 12)
                    End If
                    Dgview1.Rows.Add(A + 1, .Item("account_number"), loanee_name, .Item("Disburse_date"), .Item("Loan_amount"),
                                     .Item("Returned_amount"), (.Item("Loan_amount") - .Item("Returned_amount")),
                                     .Item("last_month_deposit"), .Item("Month_request"), .Item("Installment"))
                End With
            Next

        Catch ex As Exception
            Error_handle("Dgview Data insert or Total Row Adding in OneSheet_without_total Error", ex)
        End Try

    End Sub

    Public Sub last_month_deposit(ByVal account_number As String)

        'dat = #12/31/2014#
        'last_date = dat.AddMonths(Today.Month - 1).ToString("d")
        'Dim lastday As String = last_date.Year.ToString & "-" & last_date.Month.ToString & "-" & "01"

        'last_month_day1 = mydate(lastday)
        'last_month_lastday = mydate(last_date)

        'Dim newmonth As String = ""

        'dat = Today.Date
        'last_date = CDate(dat.AddMonths(Today.Month - 2).ToString("d"))
        'If last_date.Month = 12 Then newmonth = CStr(12) Else newmonth = CStr(last_date.Month - 1)
        'Dim lastday As String = last_date.Year.ToString & "-" & newmonth & "-" & "01"

        'last_month_day1 = mydate(CDate(lastday))
        'last_month_lastday = CDate(lastday).Year & "/" & CDate(lastday).Month & "/" & Date.DaysInMonth(CDate(lastday).Year, CDate(lastday).Month)

        last_month_day1 = mydate(DTPSdate.Value.Date)
        last_month_lastday = mydate(DTPEdate.Value.Date)

        sql = "select * from day_clese where cur_date between '" & last_month_day1 & "' and '" & last_month_lastday & "'"
        Tableload(dsalkhairnew, sql, Conalkhairnew, "last_month_id")

        last_month_day1 = dsalkhairnew.Tables("last_month_id").Rows(0).Item("id")
        last_month_lastday = dsalkhairnew.Tables("last_month_id").Rows(dsalkhairnew.Tables("last_month_id").Rows.Count - 1).Item("id")

        If actype = "DL" Then
            loantablename = "demand"
        ElseIf actype = "ML" Then
            loantablename = "morabiya"
        ElseIf actype = "MTBL" Then
            loantablename = "mtbl"
        ElseIf actype = "STBL" Then
            loantablename = "stbl"
        End If

        sql = "SELECT li.loan_dateid,dc.cur_date,lt.loan_no_of_inst,lt.loan_inst_amt FROM " & _
            "alkhairnew.day_clese dc, albank.loan_id li, albank." & loantablename & "_loan lt WHERE " & _
            "lt.loanid = li.id and li.gen_loan_id='" & account_number & "' and dc.id=li.loan_dateid"
        Tableload(dsalbank, sql, Conalbank, "loan_date_Inst")

    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        If printstart Then
            Module2.SheetPrintBegin(Dgview1)
            Exit Sub
        End If
        Try
            strFormat = New StringFormat()
            strFormat.Alignment = StringAlignment.Near
            strFormat.LineAlignment = StringAlignment.Center
            strFormat.Trimming = StringTrimming.EllipsisCharacter

            arrColumnLefts.Clear()
            arrColumnWidths.Clear()
            iCellHeight = 0
            iRow = 0
            bFirstPage = True
            bNewPage = True
            pagescount = 0
            ' Calculating Total Widths
            iTotalWidth = 0
            For Each dgvGridCol As DataGridViewColumn In Dgview1.Columns
                iTotalWidth += dgvGridCol.Width
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            printstart = False
        End Try

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If printstart Then
            Module2.SheetPrint(sender, e, Dgview1, _
                               CollectorName & " -> " & actype & " Collection Sheet -> " & pagescount & " Label ", _
                               "Printing Date -> " & DateTime.Now.Date(), 5)
            If pagesremain = False Then
                printstart = False
                Exit Sub
            End If
        Else
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
                While iRow <= Dgview1.Rows.Count - 1
                    Dim GridRow As DataGridViewRow = Dgview1.Rows(iRow)
                    'Set the cell height
                    iCellHeight = GridRow.Height + 5
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
                            e.Graphics.DrawString(CollectorName & " -> " & actype & " Loan Report as on - " & DTPEdate.Value.Date, New Font(Dgview1.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(CollectorName & " -> " & actype & " Loan Report as on - " & DTPEdate.Value.Date, New Font(Dgview1.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 13)

                            Dim strDate As [String] = "Printing Date -> " & DateTime.Now.Date()
                            'Draw Date
                            e.Graphics.DrawString(strDate, New Font(Dgview1.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(strDate, New Font(Dgview1.Font, FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top - e.Graphics.MeasureString(CollectorName & " -> " & actype & " Loan Report", New Font(New Font(Dgview1.Font, FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13)

                            'Draw Columns                 
                            iTopMargin = e.MarginBounds.Top
                            For Each GridCol As DataGridViewColumn In Dgview1.Columns
                                e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(CInt(arrColumnLefts(iCount)), iTopMargin, CInt(arrColumnWidths(iCount)), iHeaderHeight))

                                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(CInt(arrColumnLefts(iCount)), iTopMargin, CInt(arrColumnWidths(iCount)), iHeaderHeight))

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font, New SolidBrush(GridCol.InheritedStyle.ForeColor), New RectangleF(CInt(arrColumnLefts(iCount)), iTopMargin, CInt(arrColumnWidths(iCount)), iHeaderHeight), strFormat)
                                iCount += 1
                            Next
                            bNewPage = False
                            iTopMargin += iHeaderHeight
                        End If
                        iCount = 0
                        'Draw Columns Contents                
                        For Each Cel As DataGridViewCell In GridRow.Cells
                            If Cel.Value IsNot Nothing Then
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font, New SolidBrush(Cel.InheritedStyle.ForeColor), New RectangleF(CInt(arrColumnLefts(iCount)), CSng(iTopMargin), CInt(arrColumnWidths(iCount)), CSng(iCellHeight)), strFormat)
                            End If
                            'Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(CInt(arrColumnLefts(iCount)), iTopMargin, CInt(arrColumnWidths(iCount)), iCellHeight))

                            iCount += 1
                        Next
                    End If
                    iRow += 1
                    iTopMargin += iCellHeight

                End While
                pagescount += 1
                grid.SetValue(iRow, pagescount)
                Print_Preview.Label7.Text = "Page :            " & pagescount
                If bMorePagesToPrint Then
                    e.HasMorePages = True
                Else
                    e.HasMorePages = False
                End If
            Catch exc As Exception
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                printstart = False
            End Try
        End If

    End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        Form1.Enabled = True
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        If Me.Dgview1.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
            Try
                ' Add the selection to the clipboard.
                Clipboard.SetDataObject(Me.Dgview1.GetClipboardContent())
            Catch ex As System.Runtime.InteropServices.ExternalException
                MsgBox("Datagrid copy error" & ex.ToString, vbOKOnly)
            End Try
        End If
    End Sub

    Private Sub PrintPriviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPriviewToolStripMenuItem.Click
        printprivew.PerformClick()
    End Sub

    Private Sub collector_id_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles collector_id.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Btn_loan_report.PerformClick()
        End If
    End Sub

End Class