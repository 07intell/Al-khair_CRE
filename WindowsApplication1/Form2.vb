Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Form2

    Private syncContext As SynchronizationContext
    Const WM_NCHITTEST As Integer = &H84
    Const HTCLIENT As Integer = &H1
    Const HTCAPTION As Integer = &H2

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_NCHITTEST
                MyBase.WndProc(m)
                If m.Result = IntPtr.op_Explicit(HTCLIENT) Then m.Result = IntPtr.op_Explicit(HTCAPTION)
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

    Private Sub Getdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Getdata.Click
        Form1.Dgview = Nothing
        Form1.Dgviews = Nothing
        If collid <> "" Then collid = ""
        editpreviousreceipt = True
        loan_report = 0
        Form1.manual_number = 0
        Form1.collector_id.Text = collector_id.Text
        Form1.Dtprectdate.Value = receipt_date.Value
        receiptdate = receipt_date.Value
        Form1.change_rect_date.Visible = False
        Form1.labelentry.Show()
        Form1.Label14.Show()
        Form1.savelist.Enabled = False
        Form1.btn_manual.Enabled = False
        Ac_odr_collid = collector_id.Text
        indivisualac = 0
        accesstablefound = 0
        loanbropendateid = dsalkhairnew.Tables("opendate").Rows(0).Item("id")
        If RadioButton1.Checked = True Then
            Form1.RadioButton1.Checked = True
        ElseIf RadioButton3.Checked = True Then
            Form1.RadioButton3.Checked = True
        End If
        Try
            If dateof_entry.Value.Month >= 10 And dateof_entry.Value.Day >= 10 Then
                doedate = String.Concat(dateof_entry.Value.Year, "-", dateof_entry.Value.Month, "-", dateof_entry.Value.Day)
            ElseIf dateof_entry.Value.Month < 10 And dateof_entry.Value.Day >= 10 Then
                doedate = String.Concat(dateof_entry.Value.Year, "-", "0" & dateof_entry.Value.Month, "-", dateof_entry.Value.Day)
            ElseIf dateof_entry.Value.Day < 10 And dateof_entry.Value.Month >= 10 Then
                doedate = String.Concat(dateof_entry.Value.Year, "-", dateof_entry.Value.Month, "-", "0" & dateof_entry.Value.Day)
            ElseIf dateof_entry.Value.Day < 10 And dateof_entry.Value.Month < 10 Then
                doedate = String.Concat(dateof_entry.Value.Year, "-", "0" & dateof_entry.Value.Month, "-", "0" & dateof_entry.Value.Day)
            End If
            Form1.labelentry.Text = doedate
            sql = "select id,cur_date from day_clese where cur_date='" & doedate & "'"
            Tableload(dsalkhairnew, sql, Conalkhairnew, "dateofentry")
            dateofentryid = dsalkhairnew.Tables("dateofentry").Rows(0).Item("id")
        Catch ex As Exception
            Error_handle("Date of Entry Loading Error", ex)
        End Try
        'Me.Close()
        'Form1.Enabled = True

        Form1.Loaddata()
        Form1.Dgview = Form1.TabControl1.SelectedTab.Controls.Item(0)

        If Form1.Colltype.Text = "DD" Then Form1.Dgviews = Form1.TabControl1.SelectedTab.Controls.Item(0)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form1.Enabled = True
        Me.Close()
    End Sub

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Form1.Enabled = False Then Form1.Enabled = True
        'Form1.Manual_Entry.Visible = True
        Me.Dispose()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Form1.Width / 2) - (Me.Width / 2), 15)
        receipt_date.Value = day
        dateof_entry.Value = day
        receipt_date.MaxDate = Form1.dateofsoftware.Text
        dateof_entry.MaxDate = Form1.dateofsoftware.Text
        receipt_date.MinDate = month_first_date
        dateof_entry.MinDate = month_first_date
        RadioButton3.Checked = True
        Me.TopMost = True
    End Sub

    Private Sub collector_id_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles collector_id.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Getdata.PerformClick()
        End If
    End Sub

    Private Sub collector_id_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles collector_id.KeyUp
        Dim pattern As String = "^*[0-9]$"
        Dim values As Match = Regex.Match(collector_id.Text, pattern)
        If values.Success = False Then collector_id.Text = ""
    End Sub

    Private Sub receipt_date_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles receipt_date.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Getdata.PerformClick()
        End If
    End Sub

    Private Sub Get_ac_data_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Get_ac_data.Click
        Form1.Dgcompare = Nothing
        Form1.Dgviews = Nothing
        Form1.Dgview = Nothing
        editpreviousreceipt = True
        Form1.savelist.Enabled = False
        Form1.btn_manual.Enabled = False

        sql = "select id,accountid,colle_id,amount,receiptno,collectionTYpe,rectDateid,depo_date from coll_depo_amount " & _
              "where accountid='" & txtacid.Text & "' and confstatus='0' order by rectDateid"
        loan_report = 0
        Tableload(dsalbank, sql, Conalbank, "Account_reciept")

        If dsalbank.Tables("Account_reciept").Rows.Count > 0 Then
            Form1.collector_id.Text = dsalbank.Tables("Account_reciept").Rows(0).Item("colle_id")
        Else
            Form1.progress.Text = txtacid.Text + " No Reciept Entry Found"
            Exit Sub
            Me.Close()
        End If

        sql = "select id_by_name,groups from genrate_total_id where id = '" & Form1.collector_id.Text & "' and type_of_user='COLL'"
        Tableload(dsalbank, sql, Conalbank, "genrate_total_id")
        With dsalbank.Tables("genrate_total_id")
            If .Rows.Count > 0 Then Form1.Colltype.Text = .Rows(0).Item("groups").ToString
            If .Rows.Count > 0 Then Form1.Collname.Text = .Rows(0).Item("id_by_name").ToString
        End With


        If Form1.Colltype.Text = "DD" Then

            sql = "select m.id,m.account_number,d.membership_tableid,d.app_name_one from membership_details as d, membership as m where m.account_number='" & _
                dsalbank.Tables("Account_reciept").Rows(0).Item("accountid") & "' and m.id = d.membership_tableid"

            Tableload(dsalbank, sql, Conalbank, "Ac_holder_name")

        Else

            sql = "select l.gen_loan_id,g.id_by_name from loan_id l, genrate_total_id g where g.genrated_id=l.id and l.gen_loan_id ='" & _
                dsalbank.Tables("Account_reciept").Rows(0).Item("accountid") & "' and g.groups='CA' and g.type_of_user='LO'"

            Tableload(dsalbank, sql, Conalbank, "Ac_holder_name")

        End If

        Dim ac_name As String

        datatable.Reset()

        datatable.Columns.Add("Receipt_No")
        datatable.Columns.Add("app_name_one")
        datatable.Columns.Add("account_number")
        datatable.Columns.Add("Receipt_Date")
        datatable.Columns.Add("Depo_Date")
        datatable.Columns.Add("Amount")
        datatable.Columns("Amount").DefaultValue = 0

        Dim depo_date As String

        For a As Integer = 0 To dsalbank.Tables("Account_reciept").Rows.Count - 1

            With dsalbank.Tables("Account_reciept").Rows(a)

                sql = "select * from day_clese where id='" & .Item("rectDateid") & "'"
                Tableload(dsalkhairnew, sql, Conalkhairnew, "recieptdate")

                rdate = dsalkhairnew.Tables("recieptdate").Rows(0).Item("cur_date").ToString

                sql = "select * from day_clese where id='" & .Item("depo_date") & "'"
                Tableload(dsalkhairnew, sql, Conalkhairnew, "recieptdate")

                depo_date = dsalkhairnew.Tables("recieptdate").Rows(0).Item("cur_date").ToString

                If Form1.Colltype.Text = "DD" Then

                    ac_name = dsalbank.Tables("Ac_holder_name").Rows(0).Item("app_name_one")

                Else

                    Dim appname As String = dsalbank.Tables("Ac_holder_name").Rows(0).Item("id_by_name")

                    If actype = "DL" Then
                        ac_name = appname.Substring(0, appname.Length - 8)
                    Else
                        ac_name = appname.Substring(0, appname.Length - 12)
                    End If

                End If

                datatable.Rows.Add(a + 1, ac_name, .Item("accountid"), rdate, depo_date, .Item("Amount"))

            End With
        Next

        dateofentryid = 0
        Form1.manual_number = 0
        indivisualac = 1

        Form1.OneSheet_Without_Total()

        collid = collector_id.Text

        Form1.Collector_info()

        Form1.Dgviews = Form1.TabControl1.SelectedTab.Controls.Item(0)

    End Sub

    Private Sub dateof_entry_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dateof_entry.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Getdata.PerformClick()
        End If
    End Sub

    Private Sub RadioButton1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles RadioButton1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Get_ac_data.PerformClick()
        End If
    End Sub

    Private Sub txtacid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtacid.KeyPress
        Get_ac_data.PerformClick()
    End Sub

    Private Sub Form2_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If accdetails Then
            If accdepositdate <> Date.FromOADate(1 / 1 / 2000) Then dateof_entry.Value = accdepositdate
            If accreceptdate <> Date.FromOADate(1 / 1 / 2000) Then receipt_date.Value = accreceptdate
            collector_id.Text = Form1.collector_id.Text
            Getdata.PerformClick()
            accdetails = False
            accdepositdate = Date.FromOADate(1 / 1 / 2000)
            accreceptdate = Date.FromOADate(1 / 1 / 2000)
        End If
    End Sub

    Private Sub btn_close_Click(sender As System.Object, e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
End Class