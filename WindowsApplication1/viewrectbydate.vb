
Public Class viewrectbydate

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

    Private Sub getdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles getdate.Click

        Form1.change_rect_date.Visible = True
        Form1.collector_id.Text = collector_id.Text
        Loan_report = 0
        editpreviousreceipt = False
        Try
            Form1.Todaydeposit.Text = 0
            Form1.labelentry.Text = Dateofentry.Value

            If Dateofentry.Value.Month >= 10 And Dateofentry.Value.Day >= 10 Then
                doedate = String.Concat(Dateofentry.Value.Year, "-", Dateofentry.Value.Month, "-", Dateofentry.Value.Day)
            ElseIf Dateofentry.Value.Month < 10 And Dateofentry.Value.Day >= 10 Then
                doedate = String.Concat(Dateofentry.Value.Year, "-", "0" & Dateofentry.Value.Month, "-", Dateofentry.Value.Day)
            ElseIf Dateofentry.Value.Day < 10 And Dateofentry.Value.Month >= 10 Then
                doedate = String.Concat(Dateofentry.Value.Year, "-", Dateofentry.Value.Month, "-", "0" & Dateofentry.Value.Day)
            ElseIf Dateofentry.Value.Day < 10 And Dateofentry.Value.Month < 10 Then
                doedate = String.Concat(Dateofentry.Value.Year, "-", "0" & Dateofentry.Value.Month, "-", "0" & Dateofentry.Value.Day)
            End If

            sql = "select id,cur_date from day_clese where cur_date='" & doedate & "'"
            Tableload(dsalkhairnew, sql, Conalkhairnew, "dateofentry")
            dateofentryid = dsalkhairnew.Tables("dateofentry").Rows(0).Item("id")

            For a As Integer = 0 To dsalbank.Tables("collector_id").Rows.Count - 1

                If dsalbank.Tables("collector_id").Rows(a).Item("Account Id") = Val(collector_id.Text) Then

                    colltypeId = dsalbank.Tables("collector_id").Rows(a).Item("Colltype_id")
                    Form1.Collname.Text = dsalbank.Tables("collector_id").Rows(a).Item("Collector Name")
                    Form1.Colltype.Text = dsalbank.Tables("collector_id").Rows(a).Item("groups")

                    Form1.Totaldeposit.Text = 0
                    Form1.Todaydeposit.Text = 0
                    Form1.Balanceamount.Text = 0

                End If
            Next

        Catch ex As Exception
            Error_handle("Date of Entry Loading Error", ex)
        End Try

        'Form1.Enabled = True

        Form1.Collector_info()

        Branch.viewreceiptbyentrydate(Val(collector_id.Text), dateofentryid)

        Form1.change_rect_date.Text = "Change Reciept Date"

        'Me.Close()

    End Sub

    Private Sub viewrectbydate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Form1.Enabled = False Then Form1.Enabled = True
        Me.Dispose()
    End Sub

    Private Sub viewrectbydate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Form1.Width / 2) - (Me.Width / 2), 15)
        Dateofentry.Value = Form1.dateofsoftware.Text
        Dateofentry.MaxDate = Form1.dateofsoftware.Text
        Dateofentry.MinDate = month_first_date

    End Sub

    Private Sub Dateofentry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dateofentry.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            getdate.PerformClick()
        End If
    End Sub

    Private Sub collector_id_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles collector_id.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            getdate.PerformClick()
        End If
    End Sub

    Private Sub btn_close_Click(sender As System.Object, e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
End Class