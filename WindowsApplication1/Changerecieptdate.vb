Public Class Changerecieptdate

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProgressBar1.Value = datatable.Rows.Count
        Change_Reciept_date()
        Form1.Enabled = True
        Me.Close()
    End Sub

    Public Sub Change_Reciept_date()
        Dim rectdate As String = mydate(Old_reciept_date.Value)
        Dim newrectdate As String = mydate(New_reciept_date.Value)
        Dim newrectdateid, oldrectdateid As Integer
        Dim update As String
        Dim counter As Integer
        Try

            sql = "select id,cur_date from day_clese where cur_date='" & newrectdate & "'"
            Tableload(dsalkhairnew, sql, Conalkhairnew, "Newrectdate")
            If (dsalkhairnew.Tables("Newrectdate").Rows.Count - 1) >= 0 Then newrectdateid = dsalkhairnew.Tables("Newrectdate").Rows(0).Item("id")

            sql = "select id,cur_date from day_clese where cur_date='" & rectdate & "'"
            Tableload(dsalkhairnew, sql, Conalkhairnew, "Oldrectdate")
            If (dsalkhairnew.Tables("Oldrectdate").Rows.Count - 1) >= 0 Then oldrectdateid = dsalkhairnew.Tables("Oldrectdate").Rows(0).Item("id")

            For a As Integer = 0 To datatable.Rows.Count - 1
                With datatable.Rows(a)
                    If .Item("Amount") > 0 Then
                        If .Item("Reciept_Date_id") = oldrectdateid Then
                            sql = "select id,accountid,amount,collectionTYpe,rectDateid,depo_date from coll_depo_amount where confstatus=0 and colle_id='" & _
                                  Val(Form1.collector_id.Text) & "' and id='" & .Item("Table_id") & "' and depo_date='" & .Item("Depo_date_id") & "' and rectDateid='" & oldrectdateid & "'"
                            Tableload(dsalbank, sql, Conalbank, "Recieptdatechange")

                            If dsalbank.Tables("Recieptdatechange").Rows.Count - 1 >= 0 Then
                                If .Item("Table_id") = dsalbank.Tables("Recieptdatechange").Rows(0).Item("id") Then
                                    update = "update coll_depo_amount set rectDateid='" & newrectdateid & _
                                             "' where id='" & .Item("Table_id") & "'"

                                    If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
                                    da.UpdateCommand = Conalbank.CreateCommand  '-------Updating Entry---------
                                    da.UpdateCommand.CommandText = update
                                    da.UpdateCommand.ExecuteNonQuery()
                                    Conalbank.Close()
                                    .Item("Reciept_Date_id") = newrectdateid
                                    counter += 1

                                    For c As Integer = 0 To Form1.Dgviewrect.Rows.Count - 1
                                        If Old_reciept_date.Value = Form1.Dgviewrect.Rows(c).Cells("Reciept_Date").Value Then
                                            Form1.Dgviewrect.Rows(c).Cells("Reciept_Date").Value = New_reciept_date.Value.ToString.Substring(0, New_reciept_date.Value.ToString.Length - 12)
                                            Exit For
                                        End If
                                    Next

                                End If
                                Label4.Text = "Processing  --  " & .Item("Account_number")
                                ProgressBar1.Increment(.Item("Receipt_No"))
                            End If
                        End If
                    End If
                End With
            Next
            dsalbank.Tables("Recieptdatechange").Reset()
            MsgBox(counter & " Records Updated", vbOKOnly)
        Catch ex As Exception
            Error_handle("Change Reciept date Subroutine Error", ex)
        Finally

            Conalbank.Close()
            Conalkhairnew.Close()
            counter = 0
            Label4.Text = ""
            ProgressBar1.Value = 0
        End Try
        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.Enabled = True
        Label4.Text = ""
        Me.Close()
    End Sub

    Private Sub Changerecieptdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Date_of_entry.Value = Form1.labelentry.Text
        Old_reciept_date.Value = Form1.dateofsoftware.Text
        New_reciept_date.Value = Form1.dateofsoftware.Text
        Date_of_entry.MaxDate = Form1.dateofsoftware.Text
        Old_reciept_date.MaxDate = Form1.dateofsoftware.Text
        New_reciept_date.MaxDate = Form1.dateofsoftware.Text
        Date_of_entry.MinDate = month_first_date
        Old_reciept_date.MinDate = month_first_date
        New_reciept_date.MinDate = month_first_date

    End Sub

    Private Sub New_reciept_date_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles New_reciept_date.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub btn_close_Click(sender As System.Object, e As System.EventArgs) Handles btn_close.Click
        Button2.PerformClick()
    End Sub
End Class