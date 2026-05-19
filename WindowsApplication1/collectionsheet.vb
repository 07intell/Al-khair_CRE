Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Threading

Public Class collectionsheet

    Private pages As Dictionary(Of Integer, pageDetails)
    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer
    Private Delegate Sub SetTextDelegate(ByVal text As String)
    Private syncContext As SynchronizationContext
    Dim ppd As New PrintPreviewDialog
    Dim pptb As ToolBar
    Dim WithEvents butt1 As Button
    Dim CollectorName As String

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
#End Region

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ppdtoolbar()
        pptb = DirectCast(ppd.Controls(0), ToolBar)
        butt1.Text = "My button"
        pptb.Controls.Add(butt1)
    End Sub

    Private Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure

    Private Sub collectionsheet_FormClosing1(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Me.Dispose()
    End Sub

    Private Sub collectionsheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        collector_id.Focus()
    End Sub

    Private Sub printprivew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printprivew.Click
        Print_Preview.PrintPreviewControl1.Document = DirectCast(PrintDocument1, Printing.PrintDocument)
        Print_Preview.nud_zoom.Value = 100
        Print_Preview.WindowState = FormWindowState.Maximized
        Print_Preview.ShowDialog()
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
        End Try

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If printstart Then
            Module2.SheetPrint(sender, e, Dgview1, _
                               CollectorName & " -> " & actype & " Collection Sheet -> " & pagescount, _
                               "Printing Date -> " & DateTime.Now.Date(), 7)
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
                    iCellHeight = GridRow.Height + 7
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
                            e.Graphics.DrawString(CollectorName & " -> " & actype & " Collection Sheet -> " & pagescount + 1, New Font(Dgview1.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(CollectorName & " -> " & actype & " Collection Sheet -> " & pagescount + 1, New Font(Dgview1.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 13)

                            Dim strDate As [String] = "Printing Date -> " & DateTime.Now.Date()
                            'Draw Date
                            e.Graphics.DrawString(strDate, New Font(Dgview1.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(strDate, New Font(Dgview1.Font, FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top - e.Graphics.MeasureString(CollectorName & " -> " & actype & " Collection Sheet -> " & pagescount, New Font(New Font(Dgview1.Font, FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13)

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
                'If more lines exist, print another page.
                If bMorePagesToPrint Then
                    e.HasMorePages = True
                Else
                    e.HasMorePages = False
                End If
            Catch exc As Exception
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        End If

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

    Private Sub Btn_collection_sheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_collection_sheet.Click
        Try
            collid = Me.collector_id.Text

            For b As Integer = 0 To dsalbank.Tables("collector_id").Rows.Count - 1
                If dsalbank.Tables("collector_id").Rows(b).Item("Account id") = Val(collid) Then actype = dsalbank.Tables("collector_id").Rows(b).Item("groups")
                If dsalbank.Tables("collector_id").Rows(b).Item("Account id") = Val(collid) Then CollectorName = dsalbank.Tables("collector_id").Rows(b).Item("Collector Name")
                'If dsalbank.Tables("collector_id").Rows(b).Item("Account id") = Val(collid) Then collector_id.Text = dsalbank.Tables("collector_id").Rows(b).Item("Collector Name")
            Next
            printtofilename = CollectorName & " " & actype
            'Form1.Colltype.Text = actype
            rdate = mydate(day)
            If Datatable_ac_list IsNot Nothing Then Datatable_ac_list.Reset()
            Datatable_ac_list.Columns.Add("Sl_No")
            Datatable_ac_list.Columns.Add("A/C_holder")
            Datatable_ac_list.Columns.Add("Account_no")

            If actype = "DD" Then

                sql = "Select me.account_number,md.app_name_one,me.join_date from membership me,membership_details md" & _
                      " where me.id=md.membership_tableid and me.account_close_status='0' and me.colector_collection_id='" & Val(collid) & _
                      "' and join_date between '" & branchopendate & "' and '" & rdate & "'order by me.account_number"
                Tableload(dsalbank, sql, Conalbank, "Collectors_ac_list")

                With dsalbank.Tables("Collectors_ac_list")
                    For a As Integer = 0 To .Rows.Count - 1
                        Datatable_ac_list.Rows.Add(a + 1, .Rows(a).Item(1), .Rows(a).Item(0))
                    Next
                End With

                If dsalbank.Tables("Collectors_ac_list") IsNot Nothing Then dsalbank.Tables("Collectors_ac_list").Reset()
                releaseObject(dsalbank.Tables("Collectors_ac_list"))

            Else

                Datatable_ac_list.Columns.Add("id")
                Datatable_ac_list.Columns.Add("gen_id")
                Datatable_ac_list.Columns.Add("Loan_amount")
                Datatable_ac_list.Columns.Add("Returned_amount")
                Datatable_ac_list.Columns.Add("Installment")

                If actype = "DL" Then
                    loantablename = "demand"
                ElseIf actype = "ML" Then
                    loantablename = "morabiya"
                ElseIf actype = "MTBL" Then
                    loantablename = "mtbl"
                ElseIf actype = "STBL" Then
                    loantablename = "stbl"
                End If

                sql = "select lo.id,lo.gen_loan_id,lo.loan_type,lo.oldAcNo,gt.id,gt.id_by_name,me.applicant_name," & _
                             "de.loan_inst_amt from albank.loan_id lo,albank.genrate_total_id gt, albank." & loantablename & "_loan de," & _
                             "alkhairnew.membership me where lo.loan_type='" & actype & "' and lo.colector_id='" & Val(collid) & "' and " & _
                             "lo.id=de.loanid and lo.loan_dateid between '" & loanbropendateid & "' and '" & daycloseid & "' and " & _
                             "gt.genrated_id=lo.id and gt.tableid=lo.id and gt.type_of_user='LO' and gt.tableid=lo.id" & _
                             " and gt.groups='CA' and de.loan_sgmno=me.fullmemshipid order by lo.gen_loan_id"

                Tableload(dsalbank, sql, Conalbank, "Collectors_loan_ac_list_Name")

                sql = "select lo.id,lo.gen_loan_id,lo.loan_type,lo.oldAcNo,gt.id,gt.id_by_name,de.loan_inst_amt,de.loan_amount from loan_id lo,genrate_total_id gt," &
                      "albank." & loantablename & "_loan de where lo.loan_type='" & actype & "' and lo.colector_id='" & Val(collid) & "' and lo.loan_dateid between '" &
                      loanbropendateid & "' and '" & daycloseid & "' and gt.genrated_id=lo.id and gt.tableid=lo.id and gt.type_of_user='LO'" &
                      " and gt.tableid=lo.id and gt.groups='CA' and lo.id=de.loanid order by lo.gen_loan_id"

                Tableload(dsalbank, sql, Conalbank, "Collectors_loan_ac_list")

                Dim newappname As String
                With dsalbank.Tables("Collectors_loan_ac_list")

                    For a As Integer = 0 To .Rows.Count - 1
                        For b As Integer = 0 To dsalbank.Tables("Collectors_loan_ac_list_Name").Rows.Count - 1
                            If dsalbank.Tables("Collectors_loan_ac_list_Name").Rows(b).Item("gen_loan_id") = dsalbank.Tables("Collectors_loan_ac_list").Rows(a).Item("gen_loan_id") Then
                                newappname = dsalbank.Tables("Collectors_loan_ac_list_Name").Rows(b).Item("applicant_name")
                                Datatable_ac_list.Rows.Add(a + 1, newappname, .Rows(a).Item("gen_loan_id").ToString,
                                                           .Rows(a).Item("id").ToString,
                                                           .Rows(a).Item("id1").ToString, 0, 0,
                                                           .Rows(a).Item("loan_inst_amt").ToString)
                            End If
                        Next
                    Next

                End With

                Dim gen_loanid As Integer
                Dim loan_type As String
                Dim j As Integer = Datatable_ac_list.Rows.Count - 1
                For a As Integer = 0 To j
                    gen_loanid = Datatable_ac_list.Rows(a).Item("gen_id")
                    loan_type = actype

                    sql = "select vou_id,drparticular,crparticular,drcramount,cramount,date_id,groups,id from daybook where (drparticular='" & _
                        gen_loanid & "' or crparticular='" & gen_loanid & "') order by id"

                    If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
                    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)

                    da.Fill(Dtloantemp)
                    Conalbank.Close()

                    With Datatable_ac_list.Rows(a)

                        For b As Integer = 0 To Dtloantemp.Rows.Count - 1
                            If Dtloantemp.Rows(b).Item("drparticular") = .Item("gen_id") _
                                And Dtloantemp.Rows(b).Item("groups") = loan_type _
                                Or Dtloantemp.Rows(b).Item("groups") = "ITEX" & loan_type _
                                Or Dtloantemp.Rows(b).Item("groups") = "OWC" & loan_type Then
                                .Item("Loan_amount") += Dtloantemp.Rows(b).Item("drcramount")
                            End If
                            If Dtloantemp.Rows(b).Item("crparticular") = .Item("gen_id") _
                                And Dtloantemp.Rows(b).Item("groups") = "C" & loan_type _
                                Or Dtloantemp.Rows(b).Item("groups") = "RI" & loan_type _
                                Or Dtloantemp.Rows(b).Item("groups") = "IT" & loan_type _
                                Or Dtloantemp.Rows(b).Item("groups") = "BCE" & loan_type _
                                Or Dtloantemp.Rows(b).Item("groups") = "WC" & loan_type Then
                                .Item("Returned_amount") += Dtloantemp.Rows(b).Item("cramount")
                            End If
                        Next

                        Dim roundamount As Integer
                        roundamount = Math.Round(CInt(Datatable_ac_list.Rows(a).Item("Loan_amount")))
                        Datatable_ac_list.Rows(a).Item("Loan_amount") = roundamount

                        If .Item("Loan_amount") = .Item("Returned_amount") And .Item("Loan_amount") IsNot DBNull.Value _
                            And .Item("Returned_amount") IsNot DBNull.Value Then

                            sql = "INSERT INTO Coll_Ac_order (Coll_id, New_serial_no, Ac_holder_name, Account_no) VALUES('0', 'C', '" & _
                                loan_type & "', '" & .Item("Account_no") & "')"
                            If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
                            daaccess.InsertCommand = Conaccess.CreateCommand
                            daaccess.InsertCommand.CommandText = sql
                            daaccess.InsertCommand.ExecuteNonQuery()
                            Conaccess.Close()

                            .Delete()
                            Datatable_ac_list.AcceptChanges()
                            j -= 1
                            a -= 1

                        End If

                    End With

                    Dtloantemp.Reset()

                    If a = j Then Exit For
                Next

            End If

            datatabletemp = Datatable_ac_list.Copy()
            Datatable_ac_list.Rows.Clear()

            sql = "select * from Coll_Ac_order where Coll_id='" & collid & "'"
            Tableload(dsalbank, sql, Conaccess, "Coll_Ac_order")
            Dim l As Integer = datatabletemp.Rows.Count - 1

            If datatabletemp.Rows.Count > 0 Then
                For b As Integer = 0 To l
                    If actype = "DD" Then
                        Datatable_ac_list.Rows.Add(datatabletemp.Rows(b).Item(0),
                                                   datatabletemp.Rows(b).Item(1),
                                                   datatabletemp.Rows(b).Item(2))
                    Else
                        Datatable_ac_list.Rows.Add(datatabletemp.Rows(b).Item(0),
                                                   datatabletemp.Rows(b).Item(1),
                                                   datatabletemp.Rows(b).Item(2),
                                                   datatabletemp.Rows(b).Item(5) & " / " & _
                                                   datatabletemp.Rows(b).Item(5) - datatabletemp.Rows(b).Item(6) & _
                                                   " / " & CInt(datatabletemp.Rows(b).Item(7)))
                    End If
                    If l = 0 Then Exit For
                    datatabletemp.Rows(b).Delete()
                    datatabletemp.Rows(b).AcceptChanges()
                    l = l - 1
                    b = b - 1
                Next
            End If

            Dim dataView As New DataView(Datatable_ac_list)
            dataView.Sort = "Account_no ASC"
            Datatable_ac_list = dataView.ToTable
            l = Datatable_ac_list.Rows.Count - 1
            If actype = "DD" Then
                If dsalbank.Tables("Coll_Ac_order").Rows.Count - 1 > 0 Then
                    For a As Integer = 0 To dsalbank.Tables("Coll_Ac_order").Rows.Count - 1
                        For b As Integer = 0 To l
                            If dsalbank.Tables("Coll_Ac_order").Rows(a).Item("Account_No") = Datatable_ac_list.Rows(b).Item("Account_no") Then
                                Datatable_ac_list.Rows(b).Delete()
                                Datatable_ac_list.AcceptChanges()
                                l = l - 1
                                b = b - 1
                            End If
                            If l = b Then Exit For
                        Next
                    Next
                End If
            End If

            For a As Integer = 0 To Datatable_ac_list.Rows.Count - 1
                Datatable_ac_list.Rows(a).Item(0) = a + 1
            Next

            Dgview1.MultiSelect = False

            If Dgview1.Rows.Count > 0 Then Dgview1.Rows.Clear()
            If Dgview1.Columns.Count > 0 Then Dgview1.Columns.Clear()

            If actype = "DD" Then
                With Me.Dgview1.Columns
                    .Add("Sl_No", "Sl.No")
                    .Add("A/C_holder", "A/C Holder")
                    .Add("Account_no", "A/C Number")
                    .Add("devide", "----")
                    .Add("Sl_No1", "Sl.No")
                    .Add("A/C_holder1", "A/C Holder")
                    .Add("Account_no1", "A/C Number")
                End With

                With Dgview1
                    .Columns(0).Width = 40
                    .Columns(1).Width = 180
                    .Columns(2).Width = 100
                    .Columns(3).Width = 50
                    .Columns(4).Width = 40
                    .Columns(5).Width = 180
                    .Columns(6).Width = 100
                    .Columns(0).ReadOnly = True
                    .Columns(1).ReadOnly = True
                    .Columns(2).ReadOnly = True
                    .Columns(3).ReadOnly = True
                    .Columns(4).ReadOnly = True
                    .Columns(5).ReadOnly = True
                    .Columns(6).ReadOnly = True
                End With
            Else
                With Me.Dgview1.Columns
                    .Add("Sl_No", "Sl.No")
                    .Add("A/C_holder", "A/C Holder")
                    .Add("Account_no", "A/C Number")
                    .Add("Amt_Install", "Amt/Bal/Inst")
                    .Add("Sl_No1", "Sl.No")
                    .Add("A/C_holder1", "A/C Holder")
                    .Add("Account_no1", "A/C Number")
                    .Add("Amt_Install1", "Amt/Bal/Inst")
                End With

                With Dgview1
                    .Columns(0).Width = 30
                    .Columns(1).Width = 150
                    .Columns(2).Width = 90
                    .Columns(3).Width = 90
                    .Columns(4).Width = 30
                    .Columns(5).Width = 150
                    .Columns(6).Width = 90
                    .Columns(7).Width = 90
                    .Columns(0).ReadOnly = True
                    .Columns(1).ReadOnly = True
                    .Columns(2).ReadOnly = True
                    .Columns(3).ReadOnly = True
                    .Columns(4).ReadOnly = True
                    .Columns(5).ReadOnly = True
                    .Columns(6).ReadOnly = True
                    .Columns(7).ReadOnly = True
                End With
            End If

            Dgview1.AllowUserToAddRows = False
            Dgview1.EditMode = DataGridViewEditMode.EditOnEnter
            Dgview1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            Dim c29 As Integer = -1
            Dim n As Integer = 0

            With Datatable_ac_list
                For A As Integer = 0 To Datatable_ac_list.Rows.Count - 1

                    If A Mod 29 = 0 Then
                        c29 += 1
                    End If
                    If actype = "DD" Then
                        If c29 Mod 2 = 0 Then
                            Dgview1.Rows.Add(.Rows(A).Item("Sl_No"), .Rows(A).Item("A/C_holder"), .Rows(A).Item("Account_no"))

                            n = 0
                        ElseIf c29 Mod 2 <> 0 Then
                            Dgview1.Rows(Dgview1.Rows.Count - 29 + n).Cells("Sl_No1").Value = .Rows(A).Item("Sl_No")
                            Dgview1.Rows(Dgview1.Rows.Count - 29 + n).Cells("A/C_holder1").Value = .Rows(A).Item("A/C_holder")
                            Dgview1.Rows(Dgview1.Rows.Count - 29 + n).Cells("Account_no1").Value = .Rows(A).Item("Account_no")
                            n = n + 1
                        End If
                    Else
                        If c29 Mod 2 = 0 Then
                            Dgview1.Rows.Add(.Rows(A).Item("Sl_No"), .Rows(A).Item("A/C_holder"), .Rows(A).Item("Account_no"), .Rows(A).Item("id"))

                            n = 0
                        ElseIf c29 Mod 2 <> 0 Then
                            Dgview1.Rows(Dgview1.Rows.Count - 29 + n).Cells("Sl_No1").Value = .Rows(A).Item("Sl_No")
                            Dgview1.Rows(Dgview1.Rows.Count - 29 + n).Cells("A/C_holder1").Value = .Rows(A).Item("A/C_holder")
                            Dgview1.Rows(Dgview1.Rows.Count - 29 + n).Cells("Account_no1").Value = .Rows(A).Item("Account_no")
                            Dgview1.Rows(Dgview1.Rows.Count - 29 + n).Cells("Amt_Install1").Value = .Rows(A).Item("id")
                            n = n + 1
                        End If
                    End If
                Next
            End With

            Dim k As Integer = 0

            For b As Integer = 0 To Dgview1.Rows.Count - 1
                If b <> 0 Then
                    If b Mod 29 = 0 Then
                        Dgview1.Rows.Insert(b + k, 1)
                        k = k + 1
                    End If
                End If
            Next

            Datatable_ac_list.Reset()

        Catch ex As Exception
            Error_handle("Get collectors account List Error", ex)
        End Try

    End Sub

    Private Sub collector_id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles collector_id.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Btn_collection_sheet.PerformClick()
        End If
    End Sub

End Class