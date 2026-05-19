Imports System.Data
Imports System.Data.Odbc
Imports System.IO
Imports System.ComponentModel.AsyncOperationManager
Imports System.Threading
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports Microsoft.Win32
Imports MySql.Data.MySqlClient


Public Class Form1

    Dim findtext As String
    Dim cmd As New OdbcCommand
    Public Dgview As DataGridView
    Public WithEvents Dgviews As DataGridView = New DataGridView
    Public WithEvents Dgviewrect As DataGridView
    Public dgview_online As DataGridView
    Dim sheetvalchange, daycloseidcheck As Integer
    Public manual_number As Integer = 0
    Dim currentrow As Integer = 0
    Dim valcheck As Integer = 0
    Dim paths As String = ""
    Dim rowss As Integer
    Dim currentDate As DateTime = DateTime.Now
    Public WithEvents Dgcompare As DataGridView
    Private Delegate Sub delegate_progressbarupdate(ByVal value As Integer, ByVal maximum As Integer)
    Private Delegate Sub SetTextDelegate(ByVal text As String)
    Shared randomgenerator As Random
    Shared localslot As LocalDataStoreSlot
    Private syncContext As SynchronizationContext

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        labelentry.ReadOnly = True
        labelentry.Hide()
        Label14.Hide()

        ProgressBar1.Width = Panel1.Width

        collid = ""

        sum = 0
        x = 1

        Try
            '------Getting software current date ------

            sql = "select * from branch_heading"
            Tableload(dsalbank, sql, Conalbank, "Branchinfo")

            Me.Text = "Alkhair Cooperative Credit Society Ltd - " & dsalbank.Tables("Branchinfo").Rows(0).Item("branch_name")

            sql = "select * from day_clese where status=0"
            Tableload(dsalkhairnew, sql, Conalkhairnew, "day_clese")

            daycloseid = dsalkhairnew.Tables("day_clese").Rows(0).Item("id")
            daycloseidcheck = daycloseid
            day = dsalkhairnew.Tables("day_clese").Rows(0).Item("cur_date").ToString

        Catch ex As Exception
            Error_handle("Software Current Date Finding Error", ex)
        End Try

        Try

            Dgview = TabControl1.SelectedTab.Controls.Item(0)

            RadioButton3.Checked = True

            If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
            '-------- Loading Collectors ID List ------
            'sql = "select id,id_by_name,groups,branch_codeid from genrate_total_id where type_of_user='COLL' and branch_codeid ='" & Branch_Code.Text & "' order by id_by_name"
            'sql = "select id,id_by_name,groups,branch_codeid from genrate_total_id where type_of_user='COLL' and branch_codeid ='7' order by id_by_name"
            sql = "select id,id_by_name,groups,branch_codeid from genrate_total_id where type_of_user='COLL' order by id_by_name"
            Tableload(dsalbank, sql, Conalbank, "collector_id")

            dsalbank.Tables("collector_id").Columns(0).ColumnName = "Account Id"
            dsalbank.Tables("collector_id").Columns(1).ColumnName = "Collector Name"
            dsalbank.Tables("collector_id").Columns.Add("Colltype_id")

            For a As Integer = 0 To dsalbank.Tables("collector_id").Rows.Count - 1

                With dsalbank.Tables("collector_id").Rows(a)

                    If .Item("groups") = "DD" Then
                        .Item("Colltype_id") = 1
                    ElseIf .Item("groups") = "SD" Then
                        .Item("Colltype_id") = 2
                    ElseIf .Item("groups") = "DL" Then
                        .Item("Colltype_id") = 3
                    ElseIf .Item("groups") = "ML" Then
                        .Item("Colltype_id") = 4
                    ElseIf .Item("groups") = "STBL" Then
                        .Item("Colltype_id") = 5
                    ElseIf .Item("groups") = "MTBL" Then
                        .Item("Colltype_id") = 6
                    End If

                End With

            Next

        Catch ex As Exception
            Error_handle("CollectorList Load Error", ex)
        End Try

        Try
            For a As Integer = 0 To dsalbank.Tables("collector_id").Rows.Count - 1

                DGviewcoll.Rows.Add()
                DGviewcoll.Rows(a).Cells(0).Value = dsalbank.Tables("collector_id").Rows(a).Item(1)
                DGviewcoll.Rows(a).Cells(1).Value = dsalbank.Tables("collector_id").Rows(a).Item(2)
                DGviewcoll.Rows(a).Cells(2).Value = dsalbank.Tables("collector_id").Rows(a).Item(0)
                DGviewcoll.Rows(a).Visible = False
            Next

            For Each column In DGviewcoll.Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next

        Catch ex As Exception
            Error_handle("DataGridView Selection or DataGridView CollectorList Insert Error", ex)
        End Try

        Try                     '-------Branch Open Date ID -------

            sql = "select id,cur_date from day_clese where id='1'"
            Tableload(dsalkhairnew, sql, Conalkhairnew, "opendate")

            branchopendate = dsalkhairnew.Tables("opendate").Rows(0).Item("cur_date").ToString
            loanbropendateid = dsalkhairnew.Tables("opendate").Rows(0).Item("id")

        Catch ex As Exception
            Error_handle("Branch Id Finding Error", ex)
        End Try

        dateofsoftware.Text = day
        Dtprectdate.Value = day

        Branch_Code.Text = brncode
        todate = day

        If todate.Month < 10 Then
            fromdate = String.Concat(todate.Year, "-", "0" & todate.Month, "-", "01")
        Else
            fromdate = String.Concat(todate.Year, "-", todate.Month, "-", "01")
        End If

        month_first_date = fromdate

        Dtprectdate.MaxDate = dateofsoftware.Text

        Dtprectdate.MinDate = month_first_date

        Try '-----Date ID of First Day of Month -------

            If Conalkhairnew.State = ConnectionState.Closed Then Conalkhairnew.Open()

            sql = "select id,cur_date from day_clese where cur_date='" & fromdate & "'"
            Tableload(dsalkhairnew, sql, Conalkhairnew, "monthday1")

            If dsalkhairnew.Tables("monthday1").Rows.Count = 0 Then monthday1id = 0 Else monthday1id = dsalkhairnew.Tables("monthday1").Rows(0).Item("id")

        Catch ex As Exception
            Error_handle("Month Day 1 ID Load Error", ex)
        End Try

        ' balance_amount.PerformClick()

    End Sub

    Shared Sub New()
        randomgenerator = New Random
        localslot = Thread.AllocateDataSlot()
    End Sub

    Private Sub datagrid_inv()
        Dgview = TabControl1.SelectedTab.Controls.Item(0)
        Dgviews = Dgview
    End Sub

    Private Sub dgviewcoll_inv()
        DGviewcoll.Rows(rowss).Visible = True
    End Sub

    Private Sub dgviewcoll_inve()
        DGviewcoll.Rows(rowss).Visible = False
    End Sub

    Private Sub Form1_Shown1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        For a As Integer = 0 To 1000
        Next
        syncContext = System.ComponentModel.AsyncOperationManager.SynchronizationContext
        balance_amount.PerformClick()
    End Sub

    Protected Friend Sub InvokeTodaydeposit()
        Dim cramount, dramount As Integer
        With dsalbank.Tables("coll_voucher_entry")
            If .Rows(0).Item("sum(cramount)") IsNot DBNull.Value Then cramount = Int(.Rows(0).Item("sum(cramount)"))
            If .Rows(0).Item("sum(drcramount)") IsNot DBNull.Value Then dramount = Int(.Rows(1).Item("sum(drcramount)"))
            Me.Todaydeposit.Text = cramount - dramount
        End With
    End Sub

    Public Sub InvokeTotaldeposit()
        Me.Totaldeposit.Text = Monthtotaldeposit
    End Sub

    Private Sub InvokeBalanceamount()
        Me.Balanceamount.Text = balanceofmonth
    End Sub

    Private Sub Invokelalbel10(ByVal text As String)
        If Label10.InvokeRequired Then
            Dim md As New SetTextDelegate(AddressOf Invokelalbel10)
            Me.Invoke(md, text)
        Else
            Me.Label10.Text = text
        End If
    End Sub

    Private Sub InvokeTabcontrol1()
        If TabControl1.TabPages.Count > 0 Then
            Dim tbpg As TabPage

            For d As Integer = 1 To TabControl1.TabPages.Count - 1
                tabremove += 1
                tbpg = TabControl1.SelectedTab
                tbpg.Name = "TabPage" & d
                TabControl1.Controls.Remove(tbpg)
            Next

            tbpg = TabControl1.SelectedTab
            tbpg.Name = "TabPage1"
            tbpg.Text = "Sheet1"
            Dgview = TabControl1.SelectedTab.Controls.Item(0)
            Dgview.Rows.Clear()
            Dgview.Columns.Clear()
            Dgview.Name = "Dgview" & 0
            Dgview.DataSource = Nothing
            tabremove = 0
        End If
    End Sub

    Public Sub SetProgress_instanceSafe(ByVal paramvalue As Integer, ByVal parammaximum As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New delegate_progressbarupdate(AddressOf Me.SetProgress_instanceSafe), paramvalue, parammaximum)
        Else
            Me.ProgressBar1.Visible = True
            Me.ProgressBar1.Maximum = parammaximum
            Me.ProgressBar1.Value = paramvalue
            Me.ProgressBar1.Update()

        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
        login.Close()
        End
    End Sub

    Private Sub Getdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Getdata.Click

        If Form2.Visible = True And editpreviousreceipt = True Then
            Form2.Close()
            Dtprectdate.Value = Today.Date
        ElseIf Form3.Visible = True And Get_old_aclist = 1 Then
            Form3.Close()
        ElseIf Find.Visible = True Then
            Find.Close()
        ElseIf Changerecieptdate.Visible = True Then
            Changerecieptdate.Close()
        ElseIf viewrectbydate.Visible = True Then
            viewrectbydate.Close()
        End If

        If BackgroundWorker1.IsBusy Or BackgroundWorker2.IsBusy Then
            MsgBox("Just Wait Another Process is going on" & Environment.NewLine & "Click after Few second")
            Exit Sub
        ElseIf collector_id.Text = "" Then
            MsgBox("Please Enter collector Id")
            Exit Sub
        End If
        Excessprofitgst = False
        editpreviousreceipt = False
        Reload.Enabled = True
        '------ Load Receipt date ID --------
        ProgressBar1.Visible = True
        savelist.Enabled = False
        btn_manual.Enabled = False
        manual_number = 0
        loan_report = 0
        ddmanualentry = 0
        Dgviews = Nothing
        labelentry.Hide()
        Label14.Hide()
        change_rect_date.Visible = False
        accesstablefound = 0
        indivisualac = 0
        Ac_odr_collid = collector_id.Text
        receiptdate = Dtprectdate.Value
        dateofentryid = daycloseid
        If dateofentryid <> daycloseidcheck Then dateofentryid = daycloseidcheck
        Dgcompare = Nothing
        Loaddata()
        curcell = 0
        savelist.Enabled = False
        savelist.Text = "Save Collectors Ac Order"

        If TabControl1.Name = "Tabctrl_Reciept" Then TabControl1.Name = "TabControl1"
        ProgressBar1.Visible = False
        Dgview = TabControl1.SelectedTab.Controls.Item(0)
        If Colltype.Text = "DD" Then Dgviews = TabControl1.SelectedTab.Controls.Item(0)

        If CheckBox1.Checked = True Then
            Dgview = Nothing
            Dgviews = Nothing
            online_collection_load()
        End If
    End Sub

    Public Sub Loaddata()
        Me.Dgviewrect = Nothing
        'If Dgviewrect.ColumnCount > 0 Then Dgviewrect.Columns.Clear()
        Me.Dgcompare = Nothing
        Me.Dgview = TabControl1.SelectedTab.Controls.Item(0)
        Dgview.Rows.Clear()
        Dgview.Columns.Clear()
        Me.Dgview.MultiSelect = False

        If refreshdata > 0 Then GoTo Mrefresh

        If collector_id.Text <> collid Or datecheck <> Dtprectdate.Value Then
mrefresh:   Try
                manual_number = 0
                refreshdata = 0
                If (Dtloantemp.Rows.Count - 1) >= 0 Then Dtloantemp.Clear()
                If (datatable.Rows.Count - 1) >= 0 Then datatable.Clear()
                If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()

            Catch ex As Exception
                Error_handle("datatable resetting Error", ex)
            End Try
            loan_report = 0
            Module1.Collector_Ac_list()
        Else
            For a As Integer = 0 To DGviewcoll.Rows.Count - 1
                If collector_id.Text = DGviewcoll.Rows(a).Cells("coll_id").Value Then
                    GoTo mrefresh
                ElseIf a = DGviewcoll.Rows.Count - 1 Then
                    Me.Tab_remove()
                    Me.Dgview.Rows.Clear()
                    Me.Dgview.Columns.Clear()
                    MsgBox("Collector ID is not Found", MsgBoxStyle.Information)
                End If
            Next
        End If
        Dgview = TabControl1.TabPages(0).Controls.Item(0)
        If Dgview.RowCount > 1 Then Label10.Text = Dgview.Rows(Dgview.RowCount - 1).Cells("Amount").Value
        collid = collector_id.Text
        datecheck = receiptdate
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If BackgroundWorker1.IsBusy Or BackgroundWorker2.IsBusy Then
            Exit Sub
        End If
        Tabselect_action()
    End Sub

    Public Sub Todays_deposited_amount_total()
        Try '-------Total amount of collector's deposited and distributed as per reciept --------
            sql = "select sum(amount) from coll_depo_amount where colle_id='" & collector_id.Text & _
                "' and depo_date='" & daycloseid & "'"
            Tableload(dsalbank, sql, Conalbank, "Today_total_amount")
            If dsalbank.Tables("Today_total_amount").Rows(0).Item("sum(amount)") IsNot DBNull.Value Then Balanceamount.Text = Val(Todaydeposit.Text) - Val(dsalbank.Tables("Today_total_amount").Rows(0).Item("sum(amount)"))
        Catch ex As Exception
            Error_handle("Today's Deposited Amount Total Query Error", ex)
        End Try
    End Sub

    Private Sub Dgviews_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

        Dgviews.CurrentCell.ReadOnly = False
        Dgviews.CurrentCell.Selected = True

    End Sub

    Private Sub Dgviews_CellValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgviews.CellValueChanged
        curcell = 0

        If Dgviews.CurrentRow Is Nothing Or nweballoanamt <> balanceloanamt Then
            nweballoanamt = 0
            balanceloanamt = 0
            Exit Sub
        End If

        If Dgviews.CurrentRow.Index < 0 Then
            val2 = 0
        Else
            val2 = Dgviews.CurrentRow.Index
        End If

        If Dgviews.Rows(val2).Cells("Amount").Value Is Nothing Then Dgviews.Rows(val2).Cells("Amount").Value = 0

        Dim pattern As String = "^*[0-9]$"
        Dim values As Match = Regex.Match(Dgviews.Rows(val2).Cells("Amount").Value, pattern)

        If values.Success = False Then Dgviews.Rows(val2).Cells("Amount").Value = 0
        'If firsttimeloading = "1" Then Exit Sub

        Try         '------Calculating Sheet Total ------
            Dim newvalue, oldvalue, rowno As Integer

            If currentrow = Dgviews.Rows.Count - 1 Then Exit Sub
            If Dgviews IsNot Nothing Then

                sum = 0
                For a As Integer = 0 To datatable.Rows.Count - 1

                    If datatable.Rows(a).Item("account_number").ToString = Dgviews.Rows(val2).Cells("Account Number").Value.ToString Then

                        If datatable.Rows(a).Item("Amount") <> Dgviews.Rows(val2).Cells("Amount").Value Then

                            oldvalue = datatable.Rows(a).Item("Amount")
                            newvalue = Dgviews.Rows(val2).Cells("Amount").Value
                            rowno = a
                            sheetvalchange += 1

                        End If

                    End If

                Next
                '-------Amount validation---------
                With Dgviews.Rows(val2)
                    If Colltype.Text <> "DD" Then
                        If indivisualac = 1 Then
                            GoTo mark1
                        End If

                        If Val(.Cells("Loan Amount").Value) <= Val(.Cells("Returned Amount").Value) Then
                            If oldvalue > 0 And newvalue = 0 And Val(.Cells("Balance Amount").Value) = 0 Then
                                .Cells("Amount").Value = newvalue
                                .Cells("Returned Amount").Value = Val(.Cells("Loan Amount").Value) - oldvalue
                                GoTo mark1
                            End If
                            progress.Text = "Loan is cleared No installment is remain."
                            .Cells("Amount").Value = oldvalue
                            Exit Try
                        ElseIf Val(.Cells("Loan Amount").Value) = Val(.Cells("Returned Amount").Value) + Val(.Cells("Amount").Value) Then
                            .DefaultCellStyle.ForeColor = Color.Red
                            progress.Text = "Loan is cleared."
                        ElseIf Val(.Cells("Loan Amount").Value) < Val(.Cells("Returned Amount").Value) + Val(.Cells("Amount").Value) Then
                            .Cells("Amount").Value = .Cells("Loan Amount").Value - .Cells("Returned Amount").Value
                            Exit Sub

                        ElseIf Val(.Cells("Loan Amount").Value) > Val(.Cells("Returned Amount").Value) And Val(.Cells("Balance Amount").Value) <> 0 Then
                            .DefaultCellStyle.ForeColor = Color.Black
                            If Val(.Cells("Balance Amount").Value) <= (Val(.Cells("Amount").Value) * 3) Then MsgBox("Only one or two installment is remain", MsgBoxStyle.Information, "Information")
                        End If

                    End If
                End With

                If ddmanualentry = 0 Then

mark1:              balanceamt = Balanceamount.Text

                    If Balanceamount.Text = 0 Then

                        If newvalue > oldvalue Then

                            MsgBox("Enterd amount is more then Balance amount" & Environment.NewLine & "Please Enter correct amount", vbOKOnly)
                            Dgviews.Rows(val2).Cells("Amount").Value = oldvalue

                        ElseIf newvalue < oldvalue Then

                            datatable.Rows(rowno).Item("Amount") = newvalue
                            Branch.Submit_data()

                        End If

                    ElseIf Val(Balanceamount.Text) > 0 And newvalue <= (oldvalue + Val(Balanceamount.Text)) Then

                        datatable.Rows(rowno).Item("Amount") = newvalue
                        Branch.Submit_data()

                    ElseIf Val(Balanceamount.Text) > 0 And newvalue > (oldvalue + Val(Balanceamount.Text)) Then

                        MsgBox("Enterd amount is more then Balance amount" & Environment.NewLine & "Please Enter correct amount", vbOKOnly)
                        Dgviews.Rows(val2).Cells("Amount").Value = oldvalue

                    Else

                        datatable.Rows(rowno).Item("Amount") = newvalue
                        Branch.Submit_data()

                    End If

                    For a As Integer = 0 To datatable.Rows.Count - 1
                        If datatable.Rows(a).Item("Amount") Is DBNull.Value Then sum += 0 Else sum += datatable.Rows(a).Item("Amount")
                    Next

                    '------ collector Grid Row colour-------

                    For a As Integer = 0 To DGviewcoll.Rows.Count - 1
                        With DGviewcoll.Rows(a)

                            If .Cells(2).Value.ToString = collector_id.Text Then

                                .Cells(1).Value = Colltype.Text & " ---> " & Balanceamount.Text

                                If Balanceamount.Text = 0 Then

                                    .DefaultCellStyle.BackColor = Color.WhiteSmoke
                                    .DefaultCellStyle.ForeColor = Color.Black

                                    If DGviewcoll.InvokeRequired Then
                                        syncContext.Post(New SendOrPostCallback(AddressOf dgviewcoll_inve), Nothing)
                                    Else
                                        DGviewcoll.Rows(a).Visible = False
                                    End If

                                Else

                                    .DefaultCellStyle.BackColor = Color.FromArgb(0, 64, 0)
                                    .DefaultCellStyle.ForeColor = Color.White

                                    If DGviewcoll.InvokeRequired Then
                                        syncContext.Post(New SendOrPostCallback(AddressOf dgviewcoll_inv), Nothing)
                                    Else
                                        DGviewcoll.Rows(a).Visible = True
                                    End If

                                End If
                            End If
                        End With
                    Next
                ElseIf ddmanualentry = 1 Then
                    Branch.Submit_data()
                End If

                '----------Totaling Indivisual Datagrid-----------
                For y As Integer = 0 To Dgviews.Rows.Count - 1

                    Dim rectcounter As Integer

                    If Colltype.Text <> "DD" And indivisualac <> 1 Then
                        If Dgviews.Rows(y).Cells("Loan Amount").Value = Dgviews.Rows(y).Cells("Returned Amount").Value And y <> Dgviews.Rows.Count - 1 Then
                            Dgviews.Rows(y).DefaultCellStyle.ForeColor = Color.Red
                        End If
                    End If

                    If y = Dgviews.Rows.Count - 1 Then

                        currentrow = y
                        Label10.Text = curcell
                        Dgviews.Rows(y).Cells("Amount").Value = curcell
                        Dgviews.Rows(y).Cells("Account Number").Value = rectcounter
                        rectcounter = 0
                        currentrow = 0
                        curcell = 0
                    Else
                        If Dgviews.Rows(y).Cells("Amount").Value IsNot DBNull.Value Then
                            curcell += Dgviews.Rows(y).Cells("Amount").Value
                            If Dgviews.Rows(y).Cells("Amount").Value > 0 Then rectcounter += 1
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
            Error_handle("Dgview Amount Totaling Error", ex)
        Finally
            nweballoanamt = 0
            balanceloanamt = 0
        End Try

    End Sub

    Private Sub Manual_Entry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.TabControl1.Name = "Tabctrl_Reciept" Then
            If manual_number = 0 Then
                Me.Dgcompare = Nothing
                'Manual_Entry.Image = My.Resources.on2
                manual_number = 1
            ElseIf manual_number = 1 Then
                Me.Dgcompare = Me.Dgviewrect
                'Manual_Entry.Image = My.Resources.off3
                manual_number = 0
            End If
        Else

            If ddmanualentry = 0 Then
                ddmanualentry = 1
                'Manual_Entry.Image = My.Resources.on2
                savelist.Enabled = True
                savelist.Text = "Save Collectors Deposit"
            ElseIf ddmanualentry = 1 Then
                ddmanualentry = 0
                'Manual_Entry.Image = My.Resources.off3
                savelist.Text = "Save Collectors Ac Order"
                savelist.Enabled = False
            End If

        End If

    End Sub

    Public Sub collamountdeposit()

        Dim Newbalance As Integer
        Try
            For a As Integer = 0 To TabControl1.TabCount - 1
                curcell = 0
                Dgview = TabControl1.TabPages(a).Controls.Item(0)

                For y As Integer = 0 To Dgview.Rows.Count - 1

                    If y = Dgview.Rows.Count - 1 Then

                        Dgview.Rows(y).Cells("Amount").Value = curcell
                        Newbalance += curcell
                        curcell = 0
                    Else

                        If Dgview.Rows(y).Cells("Amount").Value > 0 Then
                            curcell += Dgview.Rows(y).Cells("Amount").Value
                        End If

                    End If
                Next
            Next

            Dim voucherno, cmonth As Integer
            Dim printyear, Naration, groups As String
            groups = ""
            cmonth = day.Month
            If cmonth > 3 Then
                printyear = String.Concat(day.Year, "-", Val(day.Year) + 1)
            Else
                printyear = String.Concat(Val(day.Year) - 1, "-", day.Year)
            End If

            Naration = String.Concat(Colltype.Text, " ", Collname.Text)

            If Colltype.Text = "DD" Then
                groups = "CDDD"
            ElseIf Colltype.Text = "DL" Then
                groups = "RDL"
            ElseIf Colltype.Text = "STBL" Then
                groups = "RSTBL"
            ElseIf Colltype.Text = "MTBL" Then
                groups = "RMTBL"
            End If

            sql = "select max(voucher_no) from voucher_no where voucher_year='" & printyear & "' and branch_code='" & brncode & "'"
            If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)
            da.Fill(dsalbank, "Last_voucher_no")
            Conalbank.Close()

            voucherno += dsalbank.Tables("Last_voucher_no").Rows(0).Item(0)

            sql = "insert into voucher_no(voucher_no,voucher_year,branch_code,voucher_date_id,user_login_id,user_login_date_time) " & _
                  "values('" & voucherno & "','" & printyear & "','" & brncode & "','" & daycloseid & "','" & loginid & "','" & Now() & "')"

            Insert(sql)

            sql = "Insert into coll_voucher_entry(collid,Amount,voucherid,branch_code,verify_status,acstatus,narration)" & _
                 " values('" & collector_id.Text & "','" & Newbalance & "','" & voucherno & "','" & brncode & "','0','0','" & Naration & "')"

            Insert(sql)

            sql = "insert into daybook(vou_id,drparticular,crparticular,drcramount,cramount,date_id,branch_code,narration,groups)" & _
                    "values('" & voucherno & "','" & 68 & "','" & collector_id.Text & "','" & Newbalance & "','" & Newbalance & _
                    "','" & daycloseid & "','" & brncode & "','" & Naration & "','" & groups & "')"

            Insert(sql)

        Catch ex As Exception
            Error_handle("Dgview Sheet Totaling Error", ex)
        End Try

    End Sub

    Public Sub autometiccellvalue()


    End Sub

    Public Sub sheet_total()                                   '------First time Sheet Total -------
        Dim rectcounter As Integer

        Try
            For a As Integer = 0 To TabControl1.TabCount - 1
                curcell = 0
                rectcounter = 0

                Dgview = TabControl1.TabPages(a).Controls.Item(0)

                For y As Integer = 0 To Dgview.Rows.Count - 1

                    If y = Dgview.Rows.Count - 1 Then

                        Dgview.Rows(y).Cells("Amount").Value = curcell
                        Dgview.Rows(y).Cells("Account Number").Value = rectcounter
                        Label10.Text = curcell
                        rectcounter = 0
                        curcell = 0
                    Else

                        If Dgview.Rows(y).Cells("Amount").Value > 0 Then
                            curcell += Dgview.Rows(y).Cells("Amount").Value
                            rectcounter += 1
                        End If

                    End If
                Next
            Next


        Catch ex As Exception
            Error_handle("Dgview Sheet Totaling Error", ex)
        End Try

    End Sub

    Public Sub Dgdesign()                                     '-----Datagridview column creation -----
        Try
            If Dgview.Rows.Count > 0 Then Dgview.Rows.Clear()
            If Dgview.Columns.Count > 0 Then Dgview.Columns.Clear()

            If Dgview.Columns.Count = 0 Then
                'If CheckBox1.Checked = True Then
                '    Dgview.Columns.Add("receipt no", "s.no")
                '    Dgview.Columns("receipt no").Width = 20
                '    Dgview.Columns.Add("account number", "a/c.no")
                '    Dgview.Columns("account number").Width = 50
                '    Dgview.Columns.Add("account holder name", "name")
                '    Dgview.Columns("account holder name").Width = 130
                '    If Colltype.Text = "dd" Then
                '        For r = 1 To currentDate.Day
                '            Dgview.Columns.Add(r, r)
                '            Dgview.Columns(r).Width = 30
                '        Next
                '        Dgview.Columns.Add("total amount", "total")
                '        Dgview.Columns("total amount").Width = 40
                '    Else
                '        Dgview.Columns.Add("loan amount", " loan_amt")
                '        Dgview.Columns("loan amount").Width = 40
                '        Dgview.Columns.Add("returned amount", "ret_amt")
                '        Dgview.Columns("returned amount").Width = 40
                '        For r = 1 To currentDate.Day
                '            Dgview.Columns.Add(r, r)
                '            Dgview.Columns(r).Width = 30
                '        Next
                '        Dgview.Columns.Add("amount", "total")
                '        Dgview.Columns("amount").Width = 40
                '        Dgview.Columns.Add("balance amount", "balance amount")
                '        Dgview.Columns("balance amount").Width = 40
                '    End If
                'Else
                Dgview.Columns.Add("Receipt No", "Receipt No")
                Dgview.Columns.Add("Account Number", "Account Number")
                Dgview.Columns.Add("Account Holder Name", "Account Holder Name")

                If Colltype.Text <> "DD" Then Dgview.Columns.Add("Loan Amount", " Loan Amount")
                If Colltype.Text <> "DD" Then Dgview.Columns.Add("Returned Amount", "Returned Amount")


                If loan_report <> 1 Then Dgview.Columns.Add("Amount", "Amount")
                If Colltype.Text <> "DD" Then Dgview.Columns.Add("Balance Amount", "Balance Amount")
                If loan_report = 1 Then Dgview.Columns.Add("Last_Month_Depo", "Last Month Deposit")

                If indivisualac = 1 Then
                    If Colltype.Text <> "DD" Then Dgview.Columns.Remove("Loan Amount")
                    If Colltype.Text <> "DD" Then Dgview.Columns.Remove("Returned Amount")
                    If Colltype.Text <> "DD" Then Dgview.Columns.Remove("Balance Amount")
                    Dgview.Columns.Add("Receipt_Date", "Receipt_Date")
                    Dgview.Columns.Add("Deposit_Date", "Deposit_Date")
                End If

                If Colltype.Text = "DD" Then
                    Dgview.Columns(0).Width = 80
                    Dgview.Columns(1).Width = 130
                    Dgview.Columns(2).Width = 180
                    Dgview.Columns("Amount").Width = 80

                Else
                    Dgview.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgview.Columns(0).FillWeight = 11
                    Dgview.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgview.Columns(1).FillWeight = 15
                    Dgview.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgview.Columns(2).FillWeight = 20
                    Dgview.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgview.Columns(3).FillWeight = 13
                    Dgview.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgview.Columns(4).FillWeight = 16
                    Dgview.Columns("Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgview.Columns("Amount").FillWeight = 10
                    If indivisualac = 0 Then Dgview.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    If indivisualac = 0 Then Dgview.Columns(6).FillWeight = 15
                End If
            End If

            'End If
        Catch ex As Exception
            Error_handle("Dgview Designing Error", ex)
        End Try
    End Sub

    Public Sub Dgproperty_set()                              '-----Datagridview property setting for Application------
        Try
            With Dgview

                .RowHeadersWidth = 30
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False

                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToResizeRows = False

                .AllowDrop = False
                .AllowUserToOrderColumns = False
                .AllowUserToResizeColumns = False

                .EditMode = DataGridViewEditMode.EditOnEnter

                For b As Integer = 0 To Dgview.Columns.Count - 1
                    If .Columns(b).Name = "Receipt No" Then .Columns("Receipt No").ReadOnly = True
                    If .Columns(b).Name = "Account Number" Then .Columns("Account Number").ReadOnly = True
                    If .Columns(b).Name = "Account Holder Name" Then .Columns("Account Holder Name").ReadOnly = True
                    If .Columns(b).Name = "Loan Amount" Then .Columns("Loan Amount").ReadOnly = True
                    If .Columns(b).Name = "Returned Amount" Then .Columns("Returned Amount").ReadOnly = True
                    If .Columns(b).Name = "Amount" Then .Columns("Amount").ReadOnly = False
                    If .Columns(b).Name = "Balance Amount" Then .Columns("Balance Amount").ReadOnly = True
                    If .Columns(b).Name = "Receipt_Date" Then .Columns("Receipt_Date").ReadOnly = True
                    If .Columns(b).Name = "Deposit_Date" Then .Columns("Deposit_Date").ReadOnly = True
                Next

            End With
            Dgview.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            Dgview.ContextMenuStrip = ContextMenuStrip1
            For Each column In Dgview.Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next

        Catch ex As Exception
            Error_handle("Dgview Property Setting Error", ex)
        End Try

    End Sub

    Public Sub Multisheet()                                  '-----Multisheet view with total------

        Tab_remove()

        Dgdesign()
        m = 0
        n = 0
        x = 1
        o = 0
        Try
            For A As Integer = 0 To datatable.Rows.Count - 1
                n += 1

                If n = (29 * x) + 1 Then                               '------ Adding New Tab and datagridview for multiple sheet -------

                    TabControl1.Controls.Add(New TabPage)
                    TabControl1.TabPages(TabControl1.TabCount - 1).Name = "Tabpage" & TabControl1.TabCount
                    TabControl1.TabPages(TabControl1.TabCount - 1).Text = "Sheet " & TabControl1.TabCount
                    TabControl1.TabPages(TabControl1.TabCount - 1).Controls.Add(New DataGridView)
                    Dgview = TabControl1.TabPages(TabControl1.TabCount - 1).Controls.Item(0)
                    Dgview.Name = "Dgview" & x
                    Dgview.Dock = DockStyle.Fill
                    Dgdesign()
                End If

                While A / 30 = x
                    x = x + 1
                End While

                datatableto_dgview(A)

            Next

            Dim tbpg As TabPage

            For s As Integer = 0 To TabControl1.TabPages.Count - 1

                tbpg = TabControl1.TabPages(s)
                Dgview = tbpg.Controls.Item(0)

                For a As Integer = 0 To Dgview.Rows.Count - 1

                    If Colltype.Text <> "DD" Then
                        If Dgview.Rows(a).Cells("Loan Amount").Value <= Dgview.Rows(a).Cells("Returned Amount").Value And a <> Dgview.Rows.Count - 1 Then
                            Dgview.Rows(a).DefaultCellStyle.ForeColor = Color.Red
                        End If
                    End If

                    If a = Dgview.Rows.Count - 1 Then

                        Dgview.Rows.Add("R.Count", 0, "Total", 0)
                        Dgview.Rows(Dgview.Rows.Count - 1).Cells("Amount").Value = curcell
                        Dgview.Rows(Dgview.Rows.Count - 1).ReadOnly = True
                        Dgproperty_set()

                    End If
                Next
                If Dgview.Rows.Count - 1 > 1 Then Dgview.Rows(Dgview.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(0, 64, 0)
                If Dgview.Rows.Count - 1 > 1 Then Dgview.Rows(Dgview.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.White
                If Dgview.Rows.Count - 1 > 1 Then Dgview.Rows(Dgview.Rows.Count - 1).ReadOnly = True
            Next

        Catch ex As Exception
            Error_handle("Dgview Data insert or Total Row Adding or New Tab Creating in Multisheet_View Error", ex)
        End Try

        Dgproperty_set()
        TabControl1.SelectedIndex = 0
        If Colltype.Text = "DD" Then sheet_total()

    End Sub

    Private Sub datatableto_dgview(ByVal a As Integer)    '------ Inserting data from datatable to datagridview --------


        Dim receipt As Integer
        Dim acno As String
        Dim amounts As Decimal
        Dim bamount As Integer
        Dim names As String
        Dim loanamount As Decimal
        Dim retunedamount As Decimal

        With datatable.Rows(a)
            If Colltype.Text = "DD" Then

                receipt = .Item("Receipt_No")
                acno = .Item("account_number")
                names = .Item("app_name_one")
                amounts = .Item("Amount")

                Dgview.Rows.Add(receipt, acno, names, amounts)
            Else

                If Colltype.Text = "DL" Then

                    receipt = a + 1
                    acno = .Item("account_number")
                    names = .Item("id_by_name").ToString.Substring(0, .Item("id_by_name").ToString.Length - 10)
                    loanamount = .Item("Loan_amount")
                    retunedamount = .Item("Returned_amount")
                    amounts = .Item("Amount")
                    bamount = .Item("Loan_amount") - .Item("Returned_amount")

                    Dgview.Rows.Add(receipt, acno, names, loanamount, retunedamount, amounts, bamount)
                Else

                    receipt = a + 1
                    acno = .Item("account_number")
                    names = .Item("id_by_name").ToString.Substring(0, .Item("id_by_name").ToString.Length - 12)
                    loanamount = .Item("Loan_amount")
                    retunedamount = .Item("Returned_amount")
                    amounts = .Item("Amount")
                    bamount = .Item("Loan_amount") - .Item("Returned_amount")

                    Dgview.Rows.Add(receipt, acno, names, loanamount, retunedamount, amounts, bamount)

                End If
            End If
        End With
    End Sub

    Public Sub Tab_remove()          '------- Removing extra Tab-----------
        Try
            If TabControl1.InvokeRequired Then
                syncContext.Post(New SendOrPostCallback(AddressOf InvokeTabcontrol1), Nothing)
            Else
                If TabControl1.TabPages.Count > 0 Then
                    Dim tbpg As TabPage

                    For d As Integer = 1 To TabControl1.TabPages.Count - 1
                        tabremove += 1
                        tbpg = TabControl1.SelectedTab
                        tbpg.Name = "TabPage" & d
                        TabControl1.Controls.Remove(tbpg)
                    Next

                    tbpg = TabControl1.SelectedTab
                    tbpg.Name = "TabPage1"
                    tbpg.Text = "Sheet1"
                    Dgview = TabControl1.SelectedTab.Controls.Item(0)
                    Dgview.Rows.Clear()
                    Dgview.Columns.Clear()
                    Dgview.Name = "Dgview" & 0
                    Dgview.DataSource = Nothing
                    tabremove = 0
                End If
            End If
        Catch ex As Exception
            Error_handle("Tab Control Tabpage Remove Error", ex)
        End Try
    End Sub

    Public Sub OneSheet_Without_Total()                    '------Single Sheet with only one total at the end-----

        Tab_remove()

        Dgdesign()
        Try
            For A As Integer = 0 To datatable.Rows.Count - 1

                If indivisualac <> 1 Then
                    datatableto_dgview(A)
                Else
                    With datatable.Rows(A)
                        Dgview.Rows.Add(A + 1, .Item("account_number"), .Item("app_name_one"), .Item("Amount"), .Item("Receipt_Date"), .Item("Depo_Date"))
                    End With
                End If

                If A = datatable.Rows.Count - 1 Then
                    Dgview.Rows.Add("R.Count", 0, "Total", 0)
                    Dgview.Rows(A + 1).ReadOnly = True
                    Dgview.Rows(A + 1).DefaultCellStyle.BackColor = Color.FromArgb(0, 64, 0)
                    Dgview.Rows(A + 1).DefaultCellStyle.ForeColor = Color.White
                    Dgview.Rows(A + 1).Cells("Amount").Value = curcell
                End If

            Next
        Catch ex As Exception
            Error_handle("Dgview Data insert or Total Row Adding in OneSheet_without_total Error", ex)
        End Try
        Dgproperty_set()

        If Colltype.Text = "DD" Then
            sheet_total()
        Else
            If indivisualac = 1 Then sheet_total()
        End If

    End Sub

    Public Sub Tabselect_action()                   '-------Tab Selection Change----------
        If tabremove = 0 Then
            Try
                If Dgview IsNot Nothing Then

                    For s As Integer = 0 To TabControl1.SelectedTab.Controls.Count - 1

                        Dgview = TabControl1.SelectedTab.Controls.Item(s)
                        Dgviews = TabControl1.SelectedTab.Controls.Item(s)
                        For a As Integer = 0 To Dgview.Rows.Count - 1

                            If a = Dgview.Rows.Count - 1 Then

                                Dgview.Rows(a).ReadOnly = True
                                Dgview.Rows(a).DefaultCellStyle.BackColor = Color.FromArgb(0, 64, 0)
                                Dgview.Rows(a).DefaultCellStyle.ForeColor = Color.White

                            End If
                        Next
                    Next
                    Dgview.CurrentCell = Dgview.Rows(0).Cells("Amount")
                    Label10.Text = Dgview.Rows(Dgview.RowCount - 1).Cells("Amount").Value
                End If
            Catch ex As Exception
                Error_handle("Tabselect change Error", ex)
            End Try
            tabremove = 0
        End If
    End Sub

    Private Sub DGviewcoll_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGviewcoll.MouseClick

        balanceamt = balanceofmonth - Val(Todaydeposit.Text)

        Try

            If DGviewcoll.CurrentCell.ColumnIndex <> 2 Then

                Exit Sub

            End If

            Dim crcell As String

            crcell = DGviewcoll.CurrentCell.Value

            collector_id.Text = crcell

            Branch_Code.Text = brncode

            For a As Integer = 0 To dsalbank.Tables("collector_id").Rows.Count - 1

                If dsalbank.Tables("collector_id").Rows(a).Item(0) = crcell Then

                    colltypeId = dsalbank.Tables("collector_id").Rows(a).Item("Colltype_id")
                    'Branch_Code.Text = dsalbank.Tables("collector_id").Rows(a).Item("branch_codeid")

                End If

            Next

            Getdata.PerformClick()

        Catch ex As Exception

            Error_handle("Collector List DataGridView Data Insert or Mouse Click Event Error", ex)

        End Try

    End Sub

    Private Sub Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit.Click
        Reload.Enabled = False
        curcell = 0
        'Me.Enabled = False
        'Manual_Entry.Visible = False
        Form2.Show()
    End Sub

    Private Sub balance_amount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles balance_amount.Click
        If BackgroundWorker1.IsBusy Or BackgroundWorker2.IsBusy Then
            MsgBox("Just Wait Another Process is going on" & Environment.NewLine & "Click after Few second")
            Exit Sub
        End If
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        totalbalanceamount = 1
        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Public Sub total_balance_amount()

        Thread.SetData(localslot, randomgenerator.Next(1, 20))

        Try '-------- Loading Collectors Todays Amount --------

            Dim collacname As String
            Dim colltdamt, collrtamt As Integer
            Dim mydate As String = Module1.mydate(day)

            For a As Integer = 0 To DGviewcoll.Rows.Count - 1
                SetProgress_instanceSafe(a, DGviewcoll.Rows.Count - 1)
                colltdamt = 0
                collrtamt = 0
                rowss = a
                '----- Month total deposit by collector ------
                sql = "SELECT db.crparticular,sum(db.cramount) FROM albank.daybook db,alkhairnew.day_clese dc WHERE db.crparticular='" &
                       DGviewcoll.Rows(a).Cells(2).Value & "' and db.date_id=dc.id and dc.cur_date between '" & fromdate & "'and'" & mydate & "'"
                'sql = "SELECT crparticular.db as crparticular,sum(cramount).db as sum(cramount),id.dc FROM daybook db,day_clese dc WHERE crparticular.db='" &
                '     DGviewcoll.Rows(a).Cells(2).Value & "' and cur_date between '" & fromdate & "' and '" & day & "'"

                Tableload(dsalbank, sql, Conalbank, "coll_Total_voucher_entry")

                'sql = "SELECT drparticular,sum(drcramount) FROM daybook WHERE drparticular='" & DGviewcoll.Rows(a).Cells(2).Value & "' and date_id>='" & monthday1id & "'"
                sql = "SELECT db.drparticular,sum(db.drcramount) FROM albank.daybook db,alkhairnew.day_clese dc WHERE db.drparticular='" &
                       DGviewcoll.Rows(a).Cells(2).Value & "' and db.date_id= dc.id and dc.cur_date between '" & fromdate & "' and '" & mydate & "'"

                If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()

                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)
                da.Fill(dsalbank, "coll_Total_voucher_entry")

                Conalbank.Close()

                '-------Total amount of collector deposited and distributed as per reciept --------
                sql = "select sum(amount) from coll_depo_amount where depo_date>" & monthday1id & " and colle_id='" & DGviewcoll.Rows(a).Cells(2).Value & "' and returnType=1"
                Tableload(dsalbank, sql, Conalbank, "coll_total_trfr_amount")

                Dim cramount, dramount As Integer
                With dsalbank.Tables("coll_Total_voucher_entry")

                    If .Rows(0).Item("sum(db.cramount)") IsNot DBNull.Value Then cramount = Int(.Rows(0).Item("sum(db.cramount)"))
                    If .Rows(0).Item("sum(db.drcramount)") IsNot DBNull.Value Then dramount = Int(.Rows(1).Item("sum(db.drcramount)"))

                    If cramount > 0 Then
                        Monthtotaldeposit = cramount - dramount
                    Else
                        Monthtotaldeposit = 0
                    End If

                End With

                If dsalbank.Tables("coll_total_trfr_amount").Rows(0).Item("sum(amount)") IsNot DBNull.Value Then

                    Totalrecieptamt = dsalbank.Tables("coll_total_trfr_amount").Rows(0).Item("sum(amount)")
                Else
                    Totalrecieptamt = 0
                End If

                balanceofmonth = Monthtotaldeposit - Totalrecieptamt

                collacname = dsalbank.Tables("collector_id").Rows(a).Item("groups")
                DGviewcoll.Rows(a).Cells(1).Value = collacname & " ---> " & balanceofmonth

                If balanceofmonth > 0 Then

                    DGviewcoll.Rows(a).DefaultCellStyle.BackColor = Color.FromArgb(0, 64, 0)
                    DGviewcoll.Rows(a).DefaultCellStyle.ForeColor = Color.White

                    If DGviewcoll.InvokeRequired Then
                        syncContext.Post(New SendOrPostCallback(AddressOf dgviewcoll_inv), Nothing)
                    Else
                        DGviewcoll.Rows(a).Visible = True
                    End If

                Else

                    DGviewcoll.Rows(a).DefaultCellStyle.BackColor = Color.WhiteSmoke
                    DGviewcoll.Rows(a).DefaultCellStyle.ForeColor = Color.Black

                    If DGviewcoll.InvokeRequired Then
                        syncContext.Post(New SendOrPostCallback(AddressOf dgviewcoll_inve), Nothing)
                    Else
                        DGviewcoll.Rows(a).Visible = False
                    End If

                End If

                dramount = 0
                cramount = 0
                dsalbank.Tables("coll_Total_voucher_entry").Reset()

            Next

            SetProgress_instanceSafe(0, 1000)
            BackgroundWorker1.Dispose()
            releaseObject(BackgroundWorker1)

        Catch ex As Exception
            Error_handle("Collectors Total Deposit Amount Load Error", ex)
        End Try

    End Sub

    Private Sub todays_deposit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles todays_deposit.Click
        If BackgroundWorker1.IsBusy Or BackgroundWorker2.IsBusy Then
            MsgBox("Just Wait Another Process is going on" & Environment.NewLine & "Click after Few second")
            Exit Sub
        End If
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        todaysdepositamount = 1
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Public Sub todays_deposit_amount()

        Thread.SetData(localslot, randomgenerator.Next(1, 20))

        Try
            '-------- Loading Collectors Todays Amount --------
            Dim collacname, collbalance As String
            Dim colltdamt, collrtamt As Integer
            Dim cramount, dramount As Integer

            For a As Integer = 0 To DGviewcoll.Rows.Count - 1
                SetProgress_instanceSafe(a, DGviewcoll.Rows.Count - 1)
                colltdamt = 0
                collrtamt = 0
                'If CheckBox1.Checked = True Then
                'Else
                sql = "SELECT crparticular,sum(cramount) FROM daybook WHERE crparticular='" & DGviewcoll.Rows(a).Cells(2).Value & "'  and date_id='" & daycloseid & "'"
                Tableload(dsalbank, sql, Conalbank, "coll_voucher_entry")

                sql = "SELECT drparticular,sum(drcramount) FROM daybook WHERE drparticular='" & DGviewcoll.Rows(a).Cells(2).Value & "' and date_id='" & daycloseid & "'"
                If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)
                da.Fill(dsalbank, "coll_voucher_entry")
                Conalbank.Close()

                sql = "select Sum(amount) from coll_depo_amount where confstatus=0 and colle_id='" & DGviewcoll.Rows(a).Cells(2).Value & _
                    "' and returnType=1 and depo_date='" & dateofentryid & "' and rectDateid='" & rectdateid & "'"
                Tableload(dsalbank, sql, Conalbank, "coll_depo_amount")
                With dsalbank.Tables("coll_voucher_entry")
                    If .Rows(0).Item("sum(cramount)") IsNot DBNull.Value Then cramount = Int(.Rows(0).Item("sum(cramount)"))
                    If .Rows(0).Item("sum(drcramount)") IsNot DBNull.Value Then dramount = Int(.Rows(1).Item("sum(drcramount)"))
                    If cramount > 0 Then
                        colltdamt = cramount - dramount
                    Else
                        colltdamt = 0
                    End If
                End With

                If dsalbank.Tables("coll_depo_amount").Rows(0).Item("Sum(amount)") IsNot DBNull.Value Then collrtamt = dsalbank.Tables("coll_depo_amount").Rows(0).Item("Sum(amount)")
                collbalance = (colltdamt - collrtamt).ToString
                collacname = dsalbank.Tables("collector_id").Rows(a).Item("groups")
                'End If

                DGviewcoll.Rows(a).Cells(1).Value = collacname & " ---> " & collbalance

                If collbalance > 0 Then

                    DGviewcoll.Rows(a).DefaultCellStyle.BackColor = Color.FromArgb(0, 64, 0)
                    DGviewcoll.Rows(a).DefaultCellStyle.ForeColor = Color.White
                    DGviewcoll.Rows(a).Visible = True

                Else

                    DGviewcoll.Rows(a).DefaultCellStyle.BackColor = Color.WhiteSmoke
                    DGviewcoll.Rows(a).DefaultCellStyle.ForeColor = Color.Black
                    DGviewcoll.Rows(a).Visible = False

                End If

                dramount = 0
                cramount = 0
                dsalbank.Tables("coll_Total_voucher_entry").Reset()

            Next
         
        Catch ex As Exception
            Error_handle("Collector Todays Balance Amount Load Error", ex)
        Finally
            SetProgress_instanceSafe(0, 1000)
            BackgroundWorker1.Dispose()
            releaseObject(BackgroundWorker1)
        End Try

    End Sub

    Private Sub Btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_exit.Click
        Me.Close()
        End
    End Sub

    Private Sub collector_id_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles collector_id.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Getdata.PerformClick()
        End If
    End Sub

    Private Sub collector_id_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles collector_id.KeyUp

        Dim pattern As String = "^*[0-9]$"
        Dim values As Match = Regex.Match(collector_id.Text, pattern)
        If values.Success = False Then collector_id.Text = ""

    End Sub

    Private Sub viewreciept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles viewreciept.Click
        Reload.Enabled = False
        curcell = 0
        'Me.Enabled = False
        viewrectbydate.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_find.Click
        Find.Show()
    End Sub

    Private Sub Create_bfs_ac_list_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Create_bfs_ac_list.Click
        Form3.Show()
        'collectionsheet.ShowDialog()
    End Sub

    Private Sub savelist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savelist.Click
        If savelist.Text = "Save Collectors Ac Order" Then
            savelist.Enabled = False
            Ac_odr_collid = collid
            Module1.Access_database_insert()
        Else
            collamountdeposit()
        End If

    End Sub

    Private Sub Dgcompare_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgcompare.CellValueChanged

        Try

            val2 = Dgcompare.CurrentRow.Index
            If Dgcompare.Rows.Count - 1 = val2 Then Exit Sub

            If Dgcompare.Rows(val2).Cells("New_serial_no").Value Is Nothing Or Dgcompare.Rows(val2).Cells("New_serial_no").Value = "0" Then Dgcompare.Rows(val2).Cells("New_serial_no").Value = "L"
            Dim pattern As String = "^*[0-9lLdD]$"

            Dim values As Match = Regex.Match(Dgcompare.Rows(val2).Cells("New_serial_no").Value, pattern)
            If values.Success = False Then Dgcompare.Rows(val2).Cells("New_serial_no").Value = "L"

            Dim newval As Integer
            If val2 > 0 Then
                'newval = Dgviewrectrow

                pattern = "^[dDlL]$"
                values = Regex.Match(Dgcompare.Rows(val2 - 1).Cells("New_serial_no").Value, pattern)

                If values.Success = True Then
                    Dgviewrectrow = Dgcompare.Rows(val2 + 1).Cells("New_serial_no").Value - 1
                Else
                    Dgviewrectrow = Dgcompare.Rows(val2 - 1).Cells("New_serial_no").Value
                End If

                pattern = "^[dDlL]$"
                values = Regex.Match(Dgcompare.Rows(val2).Cells("New_serial_no").Value, pattern)

                If values.Success = True Then
                    newval = Dgviewrectrow
                ElseIf Dgcompare.Rows(val2).Cells("New_serial_no").Value = Dgviewrectrow + 1 Then
                    newval = Dgviewrectrow + 1
                End If

                With Dgcompare
                    For a As Integer = val2 + 1 To .RowCount - 1
                        newval += 1
                        Dgcompare.Rows(a).Cells("New_serial_no").Value = newval
                    Next
                End With

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub change_rect_date_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles change_rect_date.Click
        Me.Enabled = False
        Changerecieptdate.ShowDialog()
    End Sub

    Private Sub Dtprectdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dtprectdate.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Getdata.PerformClick()
        End If
    End Sub

    Private Sub Txtfind_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            btn_find.PerformClick()
        End If
    End Sub

    Private Sub Dgviews_SelectionChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        If indivisualac = 1 Then
            Dtprectdate.Value = Dgviews.CurrentRow.Cells("Receipt_Date").Value.ToString
        End If
    End Sub

    Private Sub Reload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reload.Click
        refreshdata = 1
        Getdata.PerformClick()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        If todaysdepositamount = 1 Then
            todays_deposit_amount()
            todaysdepositamount = 0
        ElseIf totalbalanceamount = 1 Then
            total_balance_amount()
            totalbalanceamount = 0
        End If
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Thread.SetData(localslot, randomgenerator.Next(1, 20))

        Adding_Loan_Current_month_total()

        Todays_entry_check()

        Collector_info()

        Loan_sheet_total_check()

    End Sub

    Public Sub Adding_Loan_Current_month_total()

        Try '----- Adding courrent Months Total to Last transfer amount --------
            For b As Integer = 0 To datatable.Rows.Count - 1
                SetProgress_instanceSafe(b, datatable.Rows.Count - 1)
                If datatable.Rows(b).Item("Loan_amount") <> datatable.Rows(b).Item("Returned_amount") Then
                    '  Exit For
                    'Else
                    sql = "select sum(amount) as amount from coll_depo_amount where confstatus=0 and colle_id='" & collector_id.Text & _
                        "' and returnType=1 and accountid='" & datatable.Rows(b).Item("account_number").ToString & "'"
                    Tableload(dsalbank, sql, Conalbank, "Loan_CMonth_Deposit")
                    datatable.Rows(b).Item("Returned_amount") += dsalbank.Tables("Loan_CMonth_Deposit").Rows(0).Item("amount")
                End If
            Next
        Catch exth As Threading.ThreadStateException
            MsgBox(exth.ToString)
        Catch ex As Exception
            Error_handle("Loan Current Month Deposit Load Error", ex)
        End Try
        SetProgress_instanceSafe(0, 100)


    End Sub

    Public Sub Month_total_deposit()
        Dim mydate As String = Module1.mydate(day)

        Try '----- Month total deposit by collector ------

            sql = "SELECT sum(db.cramount) FROM albank.daybook db,alkhairnew.day_clese dc WHERE db.crparticular='" &
            collector_id.Text & "' and db.date_id= dc.id and dc.cur_date between '" & fromdate & "' and '" & mydate & "'"
            'sql = "select sum(cramount) from daybook where crparticular='" & collector_id.Text & "' and date_id >='" & fromdate & "'"
            Tableload(dsalbank, sql, Conalbank, "coll_Total_voucher_entry")
            If dsalbank.Tables("coll_Total_voucher_entry").Rows(0).Item("sum(db.cramount)") IsNot DBNull.Value Then
                Monthtotaldeposit = dsalbank.Tables("coll_Total_voucher_entry").Rows(0).Item("sum(db.cramount)")
            Else
                Monthtotaldeposit = 0
            End If
            If Totaldeposit.InvokeRequired Then
                syncContext.Post(New SendOrPostCallback(AddressOf InvokeTotaldeposit), Nothing)
            Else
                Totaldeposit.Text = Monthtotaldeposit
            End If
        Catch exth As Threading.ThreadStateException
            MsgBox(exth.ToString)
        Catch ex As Exception
            Error_handle("Collectors Total Deposit Amount Load Error", ex)
        End Try

    End Sub

    Public Sub Todays_entry_check()

        Try '------ Load Receipt date ID --------
            If Conalkhairnew.State = ConnectionState.Closed Then Conalkhairnew.Open()
            sql = "select id,cur_date from day_clese where cur_date='" & rdate & "'"
            Tableload(dsalkhairnew, sql, Conalkhairnew, "rectdate")
            rectdateid = dsalkhairnew.Tables("rectdate").Rows(0).Item("id")
        Catch exth As Threading.ThreadStateException
            MsgBox(exth.ToString)
        Catch ex As Exception
            Error_handle("Receipt Date Id Load Error", ex)
        End Try

        Try '------ Load receipt Amount -------
            sql = "select id,accountid,amount,voucher_no,receiptno,collectionTYpe,rectDateid from coll_depo_amount where " & _
       "confstatus=0 and colle_id='" & collector_id.Text & "' and returnType=1 and depo_date='" & dateofentryid & "' and rectDateid='" & rectdateid & "' order by id"

            Tableload(dsalbank, sql, Conalbank, "coll_depo_amount")
            val3 = 0
            Dim rowcount As Integer = dsalbank.Tables("coll_depo_amount").Rows.Count
            If rowcount > 0 Then
                For a As Integer = 0 To dsalbank.Tables("coll_depo_amount").Rows.Count - 1
                    For b As Integer = 0 To datatable.Rows.Count - 1
                        If datatable.Rows(b).Item("account_number") = dsalbank.Tables("coll_depo_amount").Rows(a).Item("accountid") Then
                            datatable.Rows(b).Item("Amount") = dsalbank.Tables("coll_depo_amount").Rows(a).Item("amount")
                            If dsalbank.Tables("coll_depo_amount").Rows(a).Item("amount") > 0 Then
                                val3 += Val(dsalbank.Tables("coll_depo_amount").Rows(a).Item("amount"))
                            End If
                        End If
                    Next
                Next
            End If

            For b As Integer = 0 To datatable.Rows.Count - 1
                If datatable.Rows(b).Item("amount") Is DBNull.Value Then
                    datatable.Rows(b).Item("amount") = 0
                End If
            Next

        Catch exth As Threading.ThreadStateException
            MsgBox(exth.ToString)
        Catch ex As Exception
            Error_handle("Receipt Amount Load Error", ex)
        End Try

    End Sub

    Public Sub Collector_info()      '----- Load Collector ID list -------

        Month_total_deposit()

        Collectors_total_reciept()
        Dim colltdamt, collrtamt As Integer
        Try '------Today deposit amount by collector ------
            colltdamt = 0
            collrtamt = 0

            If editpreviousreceipt = True Then

                sql = "SELECT crparticular,sum(cramount) FROM daybook WHERE crparticular='" & collector_id.Text & "'  and date_id='" & daycloseid & "'"

                Tableload(dsalbank, sql, Conalbank, "coll_voucher_entry")

                sql = "SELECT drparticular,sum(drcramount) FROM daybook WHERE drparticular='" & collector_id.Text & "' and date_id='" & daycloseid & "'"

                If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()

                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)
                da.Fill(dsalbank, "coll_voucher_entry")

                Conalbank.Close()

            Else
                sql = "SELECT crparticular,sum(cramount) FROM daybook WHERE crparticular='" & collector_id.Text & "'  and date_id='" & dateofentryid & "'"

                Tableload(dsalbank, sql, Conalbank, "coll_voucher_entry")

                sql = "SELECT drparticular,sum(drcramount) FROM daybook WHERE drparticular='" & collector_id.Text & "' and date_id='" & dateofentryid & "'"

                If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()

                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)
                da.Fill(dsalbank, "coll_voucher_entry")

                Conalbank.Close()

            End If

            sql = "select Sum(amount) from coll_depo_amount where confstatus=0 and colle_id='" & collector_id.Text & _
                   "' and returnType=1 and depo_date='" & dateofentryid & "' and rectDateid='" & rectdateid & "'"
            Tableload(dsalbank, sql, Conalbank, "coll_depo_amount")

            Dim cramount, dramount As Integer
            With dsalbank.Tables("coll_voucher_entry")

                If .Rows(0).Item("sum(cramount)") IsNot DBNull.Value Then cramount = Int(.Rows(0).Item("sum(cramount)"))
                If .Rows(1).Item("sum(drcramount)") IsNot DBNull.Value Then dramount = Int(.Rows(1).Item("sum(drcramount)"))

                If cramount > 0 Then
                    colltdamt = cramount - dramount
                Else
                    colltdamt = 0
                End If

            End With

            If dsalbank.Tables("coll_depo_amount").Rows(0).Item("Sum(amount)") IsNot DBNull.Value Then collrtamt = dsalbank.Tables("coll_depo_amount").Rows(0).Item("Sum(amount)")

            If Todaydeposit.InvokeRequired Then
                syncContext.Post(New SendOrPostCallback(AddressOf InvokeTodaydeposit), Nothing)
            Else
                Todaydeposit.Text = colltdamt
            End If

            dramount = 0
            cramount = 0
            dsalbank.Tables("coll_Total_voucher_entry").Reset()

        Catch exth As Threading.ThreadStateException
            MsgBox(exth.ToString)
        Catch ex As Exception
            Error_handle("Today Deposit Amount Load Error", ex)
        End Try

        If dsalbank.Tables("coll_total_trfr_amount").Rows(0).Item("sum(amount)") IsNot DBNull.Value Then
            Totalrecieptamt = dsalbank.Tables("coll_total_trfr_amount").Rows(0).Item("sum(amount)")
        Else
            Totalrecieptamt = 0
        End If
        balanceofmonth = Monthtotaldeposit - Totalrecieptamt
        If Balanceamount.InvokeRequired Then
            syncContext.Post(New SendOrPostCallback(AddressOf InvokeBalanceamount), Nothing)
        Else
            Balanceamount.Text = balanceofmonth
        End If

    End Sub

    Public Sub Loan_sheet_total_check()
        Dim rectcounter As Integer
        Dim datatablerowcounter As Integer = 0
        If loan_report = 1 Then Exit Sub
        Try

            If datatable.Rows.Count = 0 Then
                Tab_remove()
                MsgBox("No Accounts are alloted to the selected collector ID")
            Else
                For a As Integer = 0 To TabControl1.TabCount - 1
                    curcell = 0
                    rectcounter = 0
                    SetProgress_instanceSafe(a, datatable.Rows.Count - 1)
                    Dgview = TabControl1.TabPages(a).Controls.Item(0)

                    For y As Integer = 0 To Dgview.Rows.Count - 1

                        For c As Integer = 0 To datatable.Rows.Count - 1
                            'SetProgress_instanceSafe(c, datatable.Rows.Count - 1)

                            If y = Dgview.Rows.Count - 1 Then

                                Invokelalbel10(curcell)
                                Dgview.Rows(y).Cells("Amount").Value = curcell
                                Dgview.Rows(y).Cells("Account Number").Value = rectcounter
                                rectcounter = 0
                                curcell = 0
                                Exit For

                            Else
                                With datatable.Rows(datatablerowcounter)
                                    Dgview.Rows(y).Cells("Loan Amount").Value = .Item("Loan_amount")
                                    Dgview.Rows(y).Cells("Returned Amount").Value = .Item("Returned_amount")
                                    Dgview.Rows(y).Cells("Balance Amount").Value = .Item("Loan_amount") - .Item("Returned_amount")
                                    Dgview.Rows(y).Cells("Amount").Value = .Item("Amount")
                                End With

                                If Dgview.Rows(y).Cells("Amount").Value > 0 Then
                                    curcell += Dgview.Rows(y).Cells("Amount").Value
                                    rectcounter += 1
                                End If

                                If Val(datatable.Rows(datatablerowcounter).Item("Loan_amount")) <= Val(datatable.Rows(datatablerowcounter).Item("Returned_amount")) And y <> datatable.Rows.Count - 1 Then
                                    Dgview.Rows(y).DefaultCellStyle.ForeColor = Color.Red
                                ElseIf y <> datatable.Rows.Count - 1 Then
                                    Dgview.Rows(y).DefaultCellStyle.ForeColor = Color.Black
                                ElseIf y <> datatable.Rows.Count - 1 Then
                                    Dgview.Rows(y).DefaultCellStyle.ForeColor = Color.White
                                End If
                                If datatable.Rows.Count - 1 <> datatablerowcounter Then
                                    datatablerowcounter += 1
                                End If
                            End If
                            Exit For
                        Next
                    Next
                Next
            End If

            SetProgress_instanceSafe(0, 100)

            BackgroundWorker2.Dispose()
            releaseObject(BackgroundWorker2)
        Catch exth As Threading.ThreadStateException
            MsgBox(exth.ToString)
        Catch ex As Exception
            Error_handle("Dgview Loan Sheet Totaling Error", ex)
        End Try

        If Dgview.InvokeRequired Then
            syncContext.Post(New SendOrPostCallback(AddressOf datagrid_inv), Nothing)
        Else
            Dgview = TabControl1.SelectedTab.Controls.Item(0)
            Dgviews = Dgview
        End If

    End Sub

    Public Sub Collectors_total_reciept()

        Dim mydate As String = Module1.mydate(day)

        Try '-------Total amount of collector's deposited and distributed as per reciept --------
            sql = "SELECT sum(cd.amount) FROM albank.coll_depo_amount cd,alkhairnew.day_clese dc WHERE cd.colle_id='" &
                     collector_id.Text & "' and cd.rectDateid= dc.id and dc.cur_date between '" & fromdate & "' and '" & mydate & "'"

            Tableload(dsalbank, sql, Conalbank, "coll_total_trfr_amount")
            dsalbank.Tables("coll_total_trfr_amount").Columns.Item(0).ColumnName = "sum(amount)"
        Catch exth As Threading.ThreadStateException
            MsgBox(exth.ToString)
        Catch ex As Exception
            Error_handle("Month Total Deposit Amount Load Error", ex)
        End Try

    End Sub

    Private Sub Gurantor_history_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gurantor_history.Click
        Dim guarantor_msno As Integer
        Try
            guarantor_msno = CInt(InputBox("Enter Guarantor Membership No", "Guarantor Info", ""))
        Catch ex As Exception
            Exit Sub
        End Try

        Try
            If guarantor_msno.ToString = "" Or guarantor_msno = 0 Then Exit Sub

            sql = "SELECT loan_sgmno,gua_sgmno,loanid,oldloanid FROM demand_loan WHERE gua_sgmno='" & guarantor_msno & "'"
            Tableload(dsalbank, sql, Conalbank, "Guaranteedacdetais")
            dsalbank.Tables("Guaranteedacdetais").Columns.Add("loan_type")

            For a As Integer = 0 To dsalbank.Tables("Guaranteedacdetais").Rows.Count - 1
                If dsalbank.Tables("Guaranteedacdetais").Rows(a).Item("loan_type") Is DBNull.Value Then dsalbank.Tables("Guaranteedacdetais").Rows(a).Item("loan_type") = "DL"
            Next

            sql = "SELECT loan_sgmno,gua_sgmno,loanid,oldloanid FROM stbl_loan WHERE gua_sgmno='" & guarantor_msno & "'"
            If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)
            da.Fill(dsalbank, "Guaranteedacdetais")
            Conalbank.Close()

            For a As Integer = 0 To dsalbank.Tables("Guaranteedacdetais").Rows.Count - 1
                If dsalbank.Tables("Guaranteedacdetais").Rows(a).Item("loan_type") Is DBNull.Value Then dsalbank.Tables("Guaranteedacdetais").Rows(a).Item("loan_type") = "STBL"
            Next

            sql = "SELECT loan_sgmno,gua_sgmno,loanid,oldloanid FROM mtbl_loan WHERE gua_sgmno='" & guarantor_msno & "'"
            If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)
            da.Fill(dsalbank, "Guaranteedacdetais")
            Conalbank.Close()

            If dsalbank.Tables("Guaranteedacdetais").Rows.Count = 0 Then
                MsgBox("This Member is not Guarantor of Any Account", MsgBoxStyle.Information)
                Exit Sub
            End If

            For a As Integer = 0 To dsalbank.Tables("Guaranteedacdetais").Rows.Count - 1
                If dsalbank.Tables("Guaranteedacdetais").Rows(a).Item("loan_type") Is DBNull.Value Then dsalbank.Tables("Guaranteedacdetais").Rows(a).Item("loan_type") = "MTBL"
            Next

            If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()

            For a As Integer = 0 To dsalbank.Tables("Guaranteedacdetais").Rows.Count - 1
                sql = "SELECT id as gen_id,genrated_id,id_by_name FROM genrate_total_id WHERE genrated_id='" & dsalbank.Tables("Guaranteedacdetais").Rows(a).Item("loanid") & _
                      "' and type_of_user='LO' and groups='CA' and tableid='" & dsalbank.Tables("Guaranteedacdetais").Rows(a).Item("loanid") & "'"
                Tableload(dsalbank, sql, Conalbank, "Gua_loan_details")
                'da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)
                'da.Fill(dsalbank, "Gua_loan_details")
            Next

            dsalbank.Tables("Gua_loan_details").Columns.Add("Loan_Number")
            dsalbank.Tables("Gua_loan_details").Columns.Add("loan_type")
            dsalbank.Tables("Gua_loan_details").Columns.Add("Name")
            dsalbank.Tables("Gua_loan_details").Columns.Add("Loan_amount")
            dsalbank.Tables("Gua_loan_details").Columns.Add("Returned_amount")


            For a As Integer = 0 To dsalbank.Tables("Guaranteedacdetais").Rows.Count - 1
                For b As Integer = 0 To dsalbank.Tables("Gua_loan_details").Rows.Count - 1
                    If dsalbank.Tables("Guaranteedacdetais").Rows(a).Item("loanid") = dsalbank.Tables("Gua_loan_details").Rows(b).Item("genrated_id") Then
                        dsalbank.Tables("Gua_loan_details").Rows(b).Item("loan_type") = dsalbank.Tables("Guaranteedacdetais").Rows(a).Item("loan_type")
                        dsalbank.Tables("Gua_loan_details").Rows(b).Item("Loan_amount") = 0
                        dsalbank.Tables("Gua_loan_details").Rows(b).Item("Returned_amount") = 0

                    End If
                Next
            Next
            Conalbank.Close()

            Dim gen_loanid As Integer

            For a As Integer = 0 To dsalbank.Tables("Gua_loan_details").Rows.Count - 1

                gen_loanid = dsalbank.Tables("Gua_loan_details").Rows(a).Item("gen_id")

                sql = "select vou_id,drparticular,crparticular,drcramount,cramount,date_id,groups,id from daybook where (drparticular='" & gen_loanid & "' or crparticular='" & gen_loanid & "') order by id"

                If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)
                da.Fill(dsalbank, "Gua_loan_daybook")
                Conalbank.Close()

                With dsalbank.Tables("Gua_loan_details").Rows(a)

                    For b As Integer = 0 To dsalbank.Tables("Gua_loan_daybook").Rows.Count - 1

                        If dsalbank.Tables("Gua_loan_daybook").Rows(b).Item("drparticular") = .Item("gen_id") And dsalbank.Tables("Gua_loan_daybook").Rows(b).Item("groups") = .Item("loan_type") Then
                            .Item("Loan_amount") += dsalbank.Tables("Gua_loan_daybook").Rows(b).Item("drcramount")
                        End If
                        If dsalbank.Tables("Gua_loan_daybook").Rows(b).Item("crparticular") = .Item("gen_id") And dsalbank.Tables("Gua_loan_daybook").Rows(b).Item("groups") = "C" & .Item("loan_type") Then
                            .Item("Returned_amount") += dsalbank.Tables("Gua_loan_daybook").Rows(b).Item("cramount")
                        End If
                        If dsalbank.Tables("Gua_loan_daybook").Rows(b).Item("crparticular") = .Item("gen_id") And dsalbank.Tables("Gua_loan_daybook").Rows(b).Item("groups") = "RI" & .Item("loan_type") Then
                            .Item("Returned_amount") += dsalbank.Tables("Gua_loan_daybook").Rows(b).Item("cramount")
                        End If
                        If dsalbank.Tables("Gua_loan_daybook").Rows(b).Item("crparticular") = .Item("gen_id") And dsalbank.Tables("Gua_loan_daybook").Rows(b).Item("groups") = "IT" & .Item("loan_type") Then
                            .Item("Returned_amount") += dsalbank.Tables("Gua_loan_daybook").Rows(b).Item("cramount")
                        End If

                    Next

                End With

            Next

            Dim clear_loan_count As Integer = 0
            Dim unclear_loan_count As Integer = 0
            Dim No_of_loan As Integer = 0
            With dsalbank.Tables("Gua_loan_details")
                For a As Integer = 0 To .Rows.Count - 1
                    Dim loannumber As String
                    Dim loaneename As String
                    Dim idbyname As String
                    Dim newidbyname As String
                    idbyname = .Rows(a).Item("id_by_name").ToString
                    Dim lenidbyname As Integer = Len(idbyname)
                    newidbyname = idbyname
                    If .Rows(a).Item("loan_type").ToString = "DL" Then
                        loaneename = idbyname.Remove((lenidbyname - 11), 11)
                        loannumber = idbyname.Remove(0, Len(loaneename) + 2)
                        .Rows(a).Item("Name") = loaneename
                        .Rows(a).Item("Loan_Number") = loannumber.Remove((Len(loannumber) - 1), 1)
                    ElseIf .Rows(a).Item("loan_type").ToString = "STBL" Then
                        loaneename = idbyname.Remove((lenidbyname - 13), 13)
                        loannumber = idbyname.Remove(0, Len(loaneename) + 2)
                        .Rows(a).Item("Name") = loaneename
                        .Rows(a).Item("Loan_Number") = loannumber.Remove((Len(loannumber) - 1), 1)
                    End If
                    If .Rows(a).Item("Loan_amount") = .Rows(a).Item("Returned_amount") Then
                        clear_loan_count += 1
                    Else
                        unclear_loan_count += 1
                    End If
                Next
            End With
            No_of_loan = dsalbank.Tables("Gua_loan_details").Rows.Count

            If clear_loan_count > 0 And unclear_loan_count > 0 Then
                MsgBox("This Member is Guarantor of " & No_of_loan & Environment.NewLine & _
                       "---> " & clear_loan_count & " Loan is clear. " + Environment.NewLine & _
                       "---> " & unclear_loan_count & " Loan is not clear. ", MsgBoxStyle.Information, "Guarantor Info")

            ElseIf clear_loan_count > 0 Then
                MsgBox("This Member is Guarantor of " & No_of_loan & Environment.NewLine & _
                       "---> " & clear_loan_count & " Loans - All loans clear. ", MsgBoxStyle.Information, "Guarantor Info")

            ElseIf unclear_loan_count > 0 Then
                MsgBox("This Member is Guarantor of " & No_of_loan & Environment.NewLine & _
                       "---> " & unclear_loan_count & " Loans - All Loans not clear. ", MsgBoxStyle.Information, "Guarantor Info")

            End If

            dsalbank.Tables("Guaranteedacdetais").Reset()
            dsalbank.Tables("Gua_loan_details").Reset()
            dsalbank.Tables("Gua_loan_daybook").Reset()

        Catch ex As Exception
            Error_handle("Guarantor History Serach Error", ex)
        End Try

    End Sub

    Private Sub btn_manual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_manual.Click
        If manual_number = 0 Then
            Me.Dgcompare = Nothing
            manual_number = 1
            btn_manual.Text = "Autometic Numbering"
        ElseIf manual_number = 1 Then
            Me.Dgcompare = TabControl1.SelectedTab.Controls.Item(0)
            manual_number = 0
            btn_manual.Text = "Manual Numbering"
        End If
    End Sub

    Private Sub serversetting_Click(sender As System.Object, e As System.EventArgs) Handles serversetting.Click
        Me.Enabled = False
        Config.ShowDialog()
    End Sub

    Private Sub Btn_loan_report_Click(sender As System.Object, e As System.EventArgs) Handles Btn_loan_report.Click
        Me.Enabled = False
        Loans_report.ShowDialog()
    End Sub

    Private Sub Dgviews_DoubleClick(sender As Object, e As EventArgs) Handles Dgviews.CellContentDoubleClick

        If Form2.Visible = True Then
            Form2.Close()
        ElseIf Form3.Visible = True Then
            Form3.Close()
        ElseIf Find.Visible = True Then
            Find.Close()
        ElseIf Changerecieptdate.Visible = True Then
            Changerecieptdate.Close()
        ElseIf viewrectbydate.Visible = True Then
            viewrectbydate.Close()
        End If

        Dim datatable1 As DataTable = New Data.DataTable

        If Dgviews.CurrentRow.Index <> Dgviews.RowCount - 1 Or Dgviews.CurrentRow.Index <> 0 Then

            sql = "select id,accountid,colle_id,amount,receiptno,collectionTYpe,rectDateid,depo_date from coll_depo_amount " & _
                  "where accountid='" & Dgviews.CurrentCell.Value.ToString & "' and confstatus='0' order by rectDateid"
            Tableload(dsalbank, sql, Conalbank, "Account_reciept")

            If dsalbank.Tables("Account_reciept").Rows.Count > 0 Then
                collector_id.Text = dsalbank.Tables("Account_reciept").Rows(0).Item("colle_id")
            Else
                progress.Text = Dgviews.CurrentCell.Value.ToString + " No Reciept Entry Found"
                Exit Sub
                Me.Close()
            End If

            sql = "select id_by_name,groups from genrate_total_id where id = '" & collector_id.Text & "' and type_of_user='COLL'"
            Tableload(dsalbank, sql, Conalbank, "genrate_total_id")

            With dsalbank.Tables("genrate_total_id")
                If .Rows.Count > 0 Then Colltype.Text = .Rows(0).Item("groups").ToString
                If .Rows.Count > 0 Then Collname.Text = .Rows(0).Item("id_by_name").ToString
            End With


            If Colltype.Text = "DD" Then

                sql = "select m.id,m.account_number,d.membership_tableid,d.app_name_one from membership_details as d, membership as m where m.account_number='" & _
                    dsalbank.Tables("Account_reciept").Rows(0).Item("accountid") & "' and m.id = d.membership_tableid"

                Tableload(dsalbank, sql, Conalbank, "Ac_holder_name")

            Else

                sql = "select l.gen_loan_id,g.id_by_name from loan_id l, genrate_total_id g where g.genrated_id=l.id and l.gen_loan_id ='" & _
                    dsalbank.Tables("Account_reciept").Rows(0).Item("accountid") & "' and g.groups='CA' and g.type_of_user='LO'"

                Tableload(dsalbank, sql, Conalbank, "Ac_holder_name")

            End If

            Dim ac_name As String
            With datatable1
                .Columns.Add("Receipt_No")
                .Columns.Add("app_name_one")
                .Columns.Add("account_number")
                .Columns.Add("Receipt_Date")
                .Columns.Add("Depo_Date")
                .Columns.Add("Amount")
                .Columns("Amount").DefaultValue = 0
            End With
            Dim depo_date As String

            For a As Integer = 0 To dsalbank.Tables("Account_reciept").Rows.Count - 1

                With dsalbank.Tables("Account_reciept").Rows(a)

                    sql = "select * from day_clese where id='" & .Item("rectDateid") & "'"
                    Tableload(dsalkhairnew, sql, Conalkhairnew, "recieptdate")

                    rdate = dsalkhairnew.Tables("recieptdate").Rows(0).Item("cur_date").ToString

                    sql = "select * from day_clese where id='" & .Item("depo_date") & "'"
                    Tableload(dsalkhairnew, sql, Conalkhairnew, "recieptdate")

                    depo_date = dsalkhairnew.Tables("recieptdate").Rows(0).Item("cur_date").ToString

                    If Colltype.Text = "DD" Then

                        ac_name = dsalbank.Tables("Ac_holder_name").Rows(0).Item("app_name_one")

                    Else
                        Dim appname As String = dsalbank.Tables("Ac_holder_name").Rows(0).Item("id_by_name")

                        If actype = "DL" Then
                            ac_name = appname.Substring(0, appname.Length - 8)
                        Else
                            ac_name = appname.Substring(0, appname.Length - 12)
                        End If
                    End If

                    Accountdetails.Label1.Text = ac_name & "   -->   " & .Item("accountid")
                    datatable1.Rows.Add(a + 1, ac_name, .Item("accountid"), rdate, depo_date, .Item("Amount"))

                End With
            Next
        End If
        Dim rectcounter As Integer
        With Accountdetails.DataGridView1
            If .Rows.Count > 0 Then .Rows.Clear()
            If .Columns.Count > 0 Then .Columns.Clear()

            If .Columns.Count = 0 Then
                .Columns.Add("Receipt No", "Receipt No")
                .Columns.Add("Account Number", "Account Number")
                .Columns.Add("Amount", "Amount")
                .Columns.Add("Receipt_Date", "Receipt_Date")
                .Columns.Add("Deposit_Date", "Deposit_Date")
            End If
            .Columns("Receipt No").ReadOnly = True
            .Columns("Account Number").ReadOnly = True
            .Columns("Amount").ReadOnly = False
            .Columns("Receipt_Date").ReadOnly = True
            .Columns("Deposit_Date").ReadOnly = True

            For y As Integer = 0 To datatable1.Rows.Count - 1

                With datatable1.Rows(y)
                    Accountdetails.DataGridView1.Rows.Add(y + 1, .Item("account_number"), .Item("Amount"), .Item("Receipt_Date"), .Item("Depo_Date"))
                End With

                If y = datatable1.Rows.Count - 1 Then
                    curcell += datatable1.Rows(y).Item("Amount")
                    rectcounter += 1
                    .Rows.Add()
                    .Rows(y + 1).Cells("Account Number").Value = "Total Amount"
                    .Rows(y + 1).Cells("Amount").Value = curcell
                    .Rows(y + 1).Cells("Receipt_Date").Value = "Total Receipt"
                    .Rows(y + 1).Cells("Deposit_Date").Value = rectcounter
                    rectcounter = 0
                    curcell = 0
                Else
                    If datatable1.Rows(y).Item("Amount") > 0 Then
                        curcell += datatable1.Rows(y).Item("Amount")
                        rectcounter += 1
                    End If
                End If
            Next

        End With
        Accountdetails.Show()
        indivisualac = 1
        Dgviews = New DataGridView
        Dgviews = Accountdetails.DataGridView1
        Dgview = Dgviews
    End Sub

    Private Sub Dgviews_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Dgviews.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If Dgviews.CurrentRow.Index = Dgviews.RowCount - 1 Then
                If TabControl1.SelectedIndex <> TabControl1.TabPages.Count - 1 Then
                    TabControl1.SelectTab(TabControl1.SelectedIndex + 1)
                End If
            End If
        ElseIf e.KeyChar = ChrW(Keys.Enter + Keys.ControlKey) Then
            If TabControl1.SelectedIndex <> TabControl1.TabPages.Count - 1 And e.KeyChar = ChrW(Keys.ControlKey) Then
                If Colltype.Text = "DD" Then
                    For a As Integer = 0 To DGviewcoll.Rows.Count - 1
                        If DGviewcoll.Rows(a).Cells(0).Value = Collname.Text And
                            DGviewcoll.Rows(a).Cells(1).Value = "DL" Then
                            Me.collector_id.Text = DGviewcoll.Rows(a).Cells(2).Value
                            Getdata.PerformClick()
                        End If
                    Next
                ElseIf Me.Colltype.Text = "DL" Then
                    For a As Integer = 0 To DGviewcoll.Rows.Count - 1
                        If DGviewcoll.Rows(a).Cells(0).Value = Collname.Text And
                            DGviewcoll.Rows(a).Cells(1).Value = "STBL" Then
                            Me.collector_id.Text = DGviewcoll.Rows(a).Cells(2).Value
                            Getdata.PerformClick()
                        End If
                    Next
                ElseIf Me.Colltype.Text = "STBL" Then
                    For a As Integer = 0 To DGviewcoll.Rows.Count - 1
                        If DGviewcoll.Rows(a).Cells(0).Value = Collname.Text And
                            DGviewcoll.Rows(a).Cells(1).Value = "MTBL" Then
                            Me.collector_id.Text = DGviewcoll.Rows(a).Cells(2).Value
                            Getdata.PerformClick()
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click

        Try
            If Me.Dgviews.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
                ' Add the selection to the clipboard.
                Clipboard.SetDataObject(Me.Dgviews.GetClipboardContent())
            End If
        Catch ex As System.Runtime.InteropServices.ExternalException
            MsgBox("Datagrid copy error" & ex.ToString, vbOKOnly)
        End Try

    End Sub

    Private Sub MultiRowSelectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultiRowSelectToolStripMenuItem.Click

        If ContextMenuStrip1.Items("MultiRowSelectToolStripMenuItem").Text = "Multi Row Select" Then
            ContextMenuStrip1.Items("MultiRowSelectToolStripMenuItem").Text = "Single Row Select"
            Dgview.MultiSelect = True
        ElseIf ContextMenuStrip1.Items("MultiRowSelectToolStripMenuItem").Text = "Single Row Select" Then
            ContextMenuStrip1.Items("MultiRowSelectToolStripMenuItem").Text = "Multi Row Select"
            Dgview.MultiSelect = False
            Dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End If
    End Sub

    Private Sub btn_collectionsheet_Click(sender As Object, e As EventArgs) Handles btn_collectionsheet.Click
        collectionsheet.ShowDialog()
        collectionsheet.collector_id.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        readimport()
    End Sub

    Public Sub online_Collection_to_sheet()
        Dim rectcounter As Integer
        Dim accountnumber As String
        Dim loan_amount, Return_amount, collection_amount As Integer
        dgview_online = New DataGridView
        Dim tbpg As TabPage
        Dim ddexcessmessages As String
        ddexcessmessages = ""
        If loan_report = 1 Then Exit Sub
        Try
            If dt_online_coll.Rows.Count = 0 Then
                MsgBox("No onine data available")
            Else
                For s As Integer = 0 To TabControl1.TabPages.Count - 1
                    curcell = 0
                    rectcounter = 0
                    SetProgress_instanceSafe(s, dt_online_coll.Rows.Count - 1)
                    tbpg = TabControl1.TabPages(s)
                    dgview_online = tbpg.Controls.Item(0)
                    For y As Integer = 0 To dgview_online.Rows.Count - 1
                        For c As Integer = 0 To dt_online_coll.Rows.Count - 1
                            'SetProgress_instanceSafe(c, datatable.Rows.Count - 1)
                            If y = dgview_online.Rows.Count - 1 Then
                                Invokelalbel10(curcell)
                                dgview_online.Rows(y).Cells("Amount").Value = curcell
                                dgview_online.Rows(y).Cells("Account Number").Value = rectcounter
                                rectcounter = 0
                                curcell = 0

                                Exit For
                            Else
                                accountnumber = Strings.Right(dgview_online.Rows(y).Cells("Account Number").Value.ToString, 6)
                                accountnumber = Convert.ToInt32(accountnumber)
                                If accountnumber = dt_online_coll.Rows(c).Item("Account_no") Then
                                    dgview_online.Rows(y).Cells("Amount").Value = CInt(dt_online_coll.Rows(c).Item("Amount"))
                                    If Colltype.Text <> "DD" Then
                                        loan_amount = dgview_online.Rows(y).Cells("Loan Amount").Value
                                        Return_amount = dgview_online.Rows(y).Cells("Returned Amount").Value
                                        collection_amount = dgview_online.Rows(y).Cells("Amount").Value
                                        dgview_online.Rows(y).Cells("Balance Amount").Value = CInt((loan_amount - Return_amount) - collection_amount)
                                    End If
                                End If
                                If dgview_online.Rows(y).Cells("Amount").Value > 0 Then
                                    curcell += CInt(dgview_online.Rows(y).Cells("Amount").Value)
                                    rectcounter += 1
                                    If Colltype.Text = "DD" Then
                                        If dgview_online.Rows(y).Cells("Amount").Value > 30000 Then
                                            dgview_online.Rows(y).DefaultCellStyle.ForeColor = Color.Red
                                            ddexcessmessages = ddexcessmessages & Environment.NewLine & dgview_online.Rows(y).Cells("Account Number").Value & "DD Collection is exceeded limit of 30000"
                                        End If
                                    End If
                                    Exit For
                                End If
                            End If
                        Next
                        If Colltype.Text <> "DD" Then
                            If dgview_online.Rows(y).Cells("Loan Amount").Value <= dgview_online.Rows(y).Cells("Returned Amount").Value And y <> dgview_online.Rows.Count - 1 Then
                                dgview_online.Rows(y).DefaultCellStyle.ForeColor = Color.Red
                            End If
                        End If
                    Next
                    If dgview_online.Rows.Count - 1 > 1 Then dgview_online.Rows(dgview_online.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(0, 64, 0)
                    If dgview_online.Rows.Count - 1 > 1 Then dgview_online.Rows(dgview_online.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.White
                    If dgview_online.Rows.Count - 1 > 1 Then dgview_online.Rows(dgview_online.Rows.Count - 1).ReadOnly = True
                Next
            End If
            If Colltype.Text = "DD" And ddexcessmessages <> "" Then
                MsgBox(ddexcessmessages, vbOKOnly, "DD Limit exceded")
                ddexcessmessages = ""
            End If
            SetProgress_instanceSafe(0, 100)
        Catch exth As Threading.ThreadStateException
            MsgBox(exth.ToString)
        Catch ex As Exception
            Error_handle("dgview_online Loan Sheet Totaling Error", ex)
        Finally
            dt_online_coll.Dispose()
            dgview_online = Nothing
        End Try
        Collector_info()
    End Sub

End Class
