Public Class Find
    Dim findtext As String
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

    Private Sub Btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsearch.Click
        If Form1.BackgroundWorker1.IsBusy Or Form1.BackgroundWorker2.IsBusy Then
            MsgBox("Just Wait Another Process is going on" & Environment.NewLine & "Click after Few second")
            Exit Sub
        End If

        Dim dgviewx As DataGridView

        If findtext <> txtfind.Text Then
            finds = 0
            findtab = 0
        End If
        dgviewx = Form1.TabControl1.TabPages(Form1.TabControl1.SelectedIndex).Controls.Item(0)
        Try
            If txtfind.Text <> "" And dgviewx IsNot Nothing Then

                For a As Integer = findtab To Form1.TabControl1.TabCount - 1

                    dgviewx = Form1.TabControl1.TabPages(a).Controls.Item(0)

                    For b As Integer = finds To dgviewx.RowCount - 1

                        If txtfind.Text = dgviewx.Rows(b).Cells("Account Number").Value.ToString Then
                            finds = b + 1

                            findtab = a
                            Label1.Text = "Account Number Found" & dgviewx.Rows(b).Cells("Account Number").Value
                            Form1.TabControl1.SelectedIndex = a
                            dgviewx.Rows(b).Selected = True
                            findtext = txtfind.Text
                            Btnsearch.Text = "Next"
                            dgviewx.FirstDisplayedScrollingRowIndex = b
                            Exit Sub
                        End If
                    Next
                Next
            End If

        Catch ex As Exception
            Error_handle("Data Searching Error", ex)
        End Try
    End Sub

    Private Sub search_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txtfind_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfind.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Btnsearch.PerformClick()
        End If
    End Sub

    Private Sub txtfind_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtfind.KeyUp
        If txtfind.Text <> findtext Then
            Btnsearch.Text = "Find"
        Else
            Btnsearch.Text = "Next"
        End If
    End Sub

    Private Sub Find_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Form1.Width / 2) - (Me.Width / 2), 15)
        txtfind.Focus()
        Me.TopMost = True
        'Me.MdiParent = Form1
    End Sub

    Private Sub btn_close_Click(sender As System.Object, e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

End Class