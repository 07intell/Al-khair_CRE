Public Class Form3

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

    Private Sub Get_ac_list_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Get_ac_list.Click
        Form1.collector_id.Text = Collectors_ac_id.Text
        Form1.savelist.Enabled = True
        Form1.btn_manual.Enabled = True
        Form1.savelist.Text = "Save Collectors Ac Order"
        Form1.btn_manual.Text = "Manual Numbering"
        Form1.btn_manual.Visible = True
        collid = Collectors_ac_id.Text
        Get_old_aclist = 0
        editpreviousreceipt = False
        Module1.Get_Account_List()
        Me.Close()
    End Sub

    Private Sub Get_old_ac_list_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Get_old_ac_list.Click
        loan_report = 0
        Get_old_aclist = 1
        editpreviousreceipt = False
        Form1.savelist.Enabled = True
        Form1.btn_manual.Enabled = True
        Form1.btn_manual.Text = "Manual Numbering"
        Form1.savelist.Text = "Save Collectors Ac Order"
        Ac_odr_collid = Collectors_ac_id.Text
        Module1.Get_Account_List()
        Me.Close()
    End Sub

    Private Sub Collectors_ac_id_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Collectors_ac_id.KeyPress, TextBox2.KeyPress, TextBox1.KeyPress, TextBox4.KeyPress, TextBox3.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Get_ac_list.PerformClick()
        End If
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Form1.Width / 2) - (Me.Width / 2), 15)
    End Sub

    Private Sub btn_close_Click(sender As System.Object, e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        sql = "DELETE FROM Coll_Ac_order WHERE Account_no=" & TextBox1.Text
        If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
        daaccess.DeleteCommand = Conaccess.CreateCommand
        daaccess.DeleteCommand.CommandText = sql
        daaccess.DeleteCommand.ExecuteNonQuery()
        Conaccess.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        sql = "select * from Coll_Ac_order where Account_No='" & TextBox1.Text
        Tableload(dsalbank, sql, Conaccess, "Account_status")

        If dsalbank.Tables("Cleared_loan").Rows.Count > 0 Then
            For a As Integer = 0 To dsalbank.Tables("Cleared_loan").Rows.Count - 1
                Dim mystring As String = TextBox1.Text
                If mystring.Substring(0, 2) = "DL" Then

                ElseIf mystring.Substring(0, 2) = "MT" Then

                ElseIf mystring.Substring(0, 2) = "ST" Then

                Else

                End If
            Next
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sql = "DELETE FROM Coll_Ac_order WHERE Ac_holder_name=" & TextBox2.Text
        If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
        daaccess.DeleteCommand = Conaccess.CreateCommand
        daaccess.DeleteCommand.CommandText = sql
        daaccess.DeleteCommand.ExecuteNonQuery()
        Conaccess.Close()
    End Sub

End Class