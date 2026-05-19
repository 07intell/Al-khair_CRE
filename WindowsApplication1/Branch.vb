
Public Class Branch

    Shared Sub viewreceiptbyentrydate(ByVal collid As Integer, ByVal doe As Integer)
        '-------View Reciept Entry by Deposit Date-------
        Form1.labelentry.Show()
        Form1.Label14.Show()

        Dim actype As String = ""
        Form1.Dgcompare = Nothing
        Form1.Dgview = Nothing
        Form1.Dgviews = Nothing

        Try
            For b As Integer = 0 To dsalbank.Tables("collector_id").Rows.Count - 1
                If dsalbank.Tables("collector_id").Rows(b).Item("Account id") = collid Then actype = dsalbank.Tables("collector_id").Rows(b).Item("groups")
            Next

            If actype = "DD" Then

                sql = "Select cd.id,cd.colle_id,cd.depo_date,cd.accountid,cd.amount," & _
                "cd.rectDateid,md.app_name_one from coll_depo_amount cd, membership me, membership_details md " & _
                "where cd.colle_id='" & collid & "' and cd.depo_date='" & _
                doe & "' and cd.accountid=me.account_number and me.id=md.membership_tableid "
                Tableload(dsalbank, sql, Conalbank, "Cdepo_Edate")

            Else

                sql = "Select cd.id,cd.colle_id,cd.depo_date,li.gen_loan_id as accountid,cd.amount,cd.rectDateid," & _
                    "gt.id_by_name from coll_depo_amount cd, loan_id li, genrate_total_id gt " & _
                    "where cd.accountid=li.gen_loan_id and cd.colle_id='" & collid & "' and cd.depo_date='" & doe & "' and gt.tableid=li.id " & _
                      "and gt.genrated_id=li.id and gt.type_of_user='LO' and gt.groups='CA' order by li.gen_loan_id"
                Tableload(dsalbank, sql, Conalbank, "Cdepo_Edate")

                dsalbank.Tables("Cdepo_Edate").Columns("id_by_name").ColumnName = "app_name_one"

                For b As Integer = 0 To dsalbank.Tables("Cdepo_Edate").Rows.Count - 1

                    Dim appname As String = dsalbank.Tables("Cdepo_Edate").Rows(b).Item("app_name_one").ToString
                    Dim newappname As String

                    If actype = "DL" Then
                        newappname = appname.Substring(0, appname.Length - 10)
                    Else
                        newappname = appname.Substring(0, appname.Length - 12)
                    End If
                    dsalbank.Tables("Cdepo_Edate").Rows(b).Item("app_name_one") = newappname

                Next

            End If

            Form1.Tab_remove()

            Form1.TabControl1.Name = "Tabctrl_Reciept"
            Temptabcontrol = Form1.TabControl1

            Form1.Dgviewrect = Temptabcontrol.TabPages(0).Controls.Item(0)
            Form1.Dgviewrect.MultiSelect = False

            If Form1.Dgviewrect.Rows.Count > 0 Then Form1.Dgviewrect.Rows.Clear()
            If Form1.Dgviewrect.Columns.Count > 0 Then Form1.Dgviewrect.Columns.Clear()

            With Form1.Dgviewrect.Columns
                .Add("Receipt_No", "Receipt No")
                .Add("Account Number", "Account Number")
                .Add("Account_Holder_Name", "Account Holder Name")
                .Add("Amount", "Amount")
                .Add("Reciept_Date", "Reciept Date")
            End With

            With Form1.Dgviewrect
                .Columns(2).Width = 150
                .Columns(0).ReadOnly = True
                .Columns(1).ReadOnly = True
                .Columns(2).ReadOnly = True
                .Columns(3).ReadOnly = True
                .Columns(4).ReadOnly = True
            End With

            Form1.Dgviewrect.AllowUserToAddRows = False

        Catch ex As Exception
            Error_handle("Loading Reciept Entry Error for viewreceiptbyentrydate", ex)
        End Try

        If datatable IsNot Nothing Then datatable.Reset()


        Try '----- Making data Table------

            With datatable.Columns
                .Add("Table_id")
                .Add("Receipt_No")
                .Add("Account_number")
                .Add("app_name_one")
                .Add("Amount")
                .Add("Reciept Date")
                .Add("Reciept_Date_id")
                .Add("Depo_date_id")
            End With

        Catch ex As Exception
            Error_handle("Datatable designing and setting Error for viewreceiptbyentrydate", ex)
        End Try

        Dim dates As String
        dates = ""

        Try

            For a As Integer = 0 To dsalbank.Tables("Cdepo_Edate").Rows.Count - 1

                With dsalbank.Tables("Cdepo_Edate").Rows(a)

                    If .Item("rectDateid") = 0 Then
                        dates = 0
                        GoTo Mark3
                    End If

                    sql = "select id,cur_date from day_clese where id='" & .Item("rectDateid") & "'"
                    Tableload(dsalkhairnew, sql, Conalkhairnew, "dateofentry")

                    If dsalkhairnew.Tables("dateofentry").Rows(0).Item("cur_date") IsNot Nothing Then dates = dsalkhairnew.Tables("dateofentry").Rows(0).Item("cur_date").ToString
Mark3:              datatable.Rows.Add(.Item("id"), a + 1, .Item("accountid"), .Item("app_name_one"), .Item("amount"), dates, .Item("rectDateid"), .Item("depo_date"))

                End With

            Next

            dsalbank.Tables("Cdepo_Edate").Reset()

            For a As Integer = 0 To datatable.Rows.Count - 1

                With datatable.Rows(a)
                    Form1.Dgviewrect.Rows.Add(.Item("Receipt_No"), .Item("Account_number"), .Item("app_name_one"), .Item("Amount"), .Item("Reciept Date"))
                End With

            Next

            Form1.Dgviewrect.Rows.Add("Reciept Count", "", "Total Amount", "", "")
            Dim recttotal, rectcounter As Integer

            For y As Integer = 0 To Form1.Dgviewrect.Rows.Count - 1

                If y = Form1.Dgviewrect.Rows.Count - 1 Then

                    Form1.Dgviewrect.Rows(y).Cells("Amount").Value = recttotal
                    Form1.Dgviewrect.Rows(y).Cells("Account number").Value = rectcounter
                    rectcounter = 0
                    recttotal = 0
                    Form1.Dgviewrect.Rows(y).DefaultCellStyle.BackColor = Color.FromArgb(0, 64, 0)
                    Form1.Dgviewrect.Rows(y).DefaultCellStyle.ForeColor = Color.White

                Else

                    If Form1.Dgviewrect.Rows(y).Cells("Amount").Value > 0 Then
                        recttotal += Form1.Dgviewrect.Rows(y).Cells("Amount").Value
                        rectcounter += 1
                    End If

                End If

            Next

        Catch ex As Exception
            Error_handle("Data filling to Datatable and Dgviewrect for viewreceiptbyentrydate", ex)
        End Try

    End Sub

    Shared Sub Submit_data()

        daycloseid = dateofentryid

        Dim sl, counter, delcounter, updatecounter As Integer
        Dim newreceiptdate, Insert, Update, Delete, amt, accnum As String

        Dim fechedreord As System.Data.DataTable = New System.Data.DataTable
        Dim createdreord As System.Data.DataTable = New System.Data.DataTable

        amt = ""
        accnum = ""

        With createdreord.Columns
            .Add("branch_code")
            .Add("colle_id")
            .Add("depo_date")
            .Add("accountid")
            .Add("amount")
            .Add("voucher_no")
            .Add("collectionTYpe")
            .Add("returnType")
            .Add("rectDateid")
        End With


        If Form1.Dgviews.CurrentRow.Index < 0 Then

            val2 = 0
        Else
            val2 = Form1.Dgviews.CurrentRow.Index
        End If

        Try

            newreceiptdate = mydate(Form1.Dtprectdate.Value)

            sql = "select * from day_clese where cur_date='" & newreceiptdate & "'"

            Tableload(dsalkhairnew, sql, Conalkhairnew, "Receiptdateid")

            For b As Integer = 0 To dsalbank.Tables("collector_id").Rows.Count - 1

                If dsalbank.Tables("collector_id").Rows(b).Item("groups") = Form1.Colltype.Text Then

                    colltypeId = dsalbank.Tables("collector_id").Rows(b).Item("Colltype_id")

                End If
            Next

            With dsalkhairnew.Tables("Receiptdateid")

                For b As Integer = 0 To .Rows.Count - 1

                    If .Rows(b).Item("cur_date") = newreceiptdate Then rectdateid = .Rows(b).Item("id")

                Next

            End With

            For b As Integer = 0 To datatable.Rows.Count - 1

                If datatable.Rows(b).Item("account_number") = Form1.Dgviews.Rows(val2).Cells("Account Number").Value Then

                    amt = Val(datatable.Rows(b).Item("Amount"))
                    accnum = datatable.Rows(b).Item("account_number")
                    sl = Form1.Dgviews.Rows(val2).Cells("Receipt No").Value

                    If daycloseid = 0 Then
                        rdate = mydate(datatable.Rows(b).Item("Receipt_Date"))
                        sql = "select id,cur_date from day_clese where cur_date='" & rdate & "'"
                        Tableload(dsalkhairnew, sql, Conalkhairnew, "recieptdate")
                        rectdateid = dsalkhairnew.Tables("monthday1").Rows(0).Item("id")

                        rdate = mydate(datatable.Rows(b).Item("Depo_Date"))
                        sql = "select id,cur_date from day_clese where cur_date='" & rdate & "'"
                        Tableload(dsalkhairnew, sql, Conalkhairnew, "recieptdate")
                        daycloseid = dsalkhairnew.Tables("monthday1").Rows(0).Item("id")

                    End If


                End If

            Next

            If indivisualac = 1 Then
                amt = Form1.Dgview.CurrentRow.Cells("Amount").Value
                accnum = Form1.Dgview.CurrentRow.Cells("Account Number").Value
                daycloseid = dsalbank.Tables("Account_reciept").Rows(Form1.Dgview.CurrentRow.Index).Item("depo_date")
                rectdateid = dsalbank.Tables("Account_reciept").Rows(Form1.Dgview.CurrentRow.Index).Item("rectDateid")
            End If

            If ddmanualentry = 1 Then
                amt = Form1.Dgview.CurrentRow.Cells("Amount").Value
            End If

        Catch ex As Exception
            Error_handle("Reciept date id loading Error", ex)
        End Try

        '-------creating recordset to compare -------------
        Try

            createdreord.Rows.Add(Form1.Branch_Code.Text, Val(Form1.collector_id.Text), daycloseid, accnum, amt, "0", colltypeId, "1", rectdateid)
            sql = "SELECT branch_code, colle_id, depo_date, accountid AS account_number, amount, voucher_no, collectionTYpe, returnType, rectDateid" & _
                " FROM  coll_depo_amount " & _
                " WHERE  colle_id =" & Val(Form1.collector_id.Text) & _
                " AND  depo_date =" & daycloseid & _
                " AND  accountid LIKE  '" & accnum & "'" & _
                " AND  rectDateid =" & rectdateid

            'sql = "Select branch_code,colle_id,depo_date,accountid as account_number,amount,voucher_no,collectionTYpe,returnType,rectDateid from coll_depo_amount where " & _
            '"  colle_id='" & Val(Form1.collector_id.Text) & "' and depo_date='" & daycloseid & "' and accountid='" & accnum & "' and collectionTYpe='" & colltypeId & _
            '"' and rectDateid='" & rectdateid & "'"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)
            da.Fill(fechedreord)

        Catch ex As Exception
            Error_handle("Creating Recordset or loading recordset Error", ex)
        End Try

        Try
            If fechedreord.Rows.Count > 0 Then

                For b As Integer = 0 To fechedreord.Rows.Count

                    If fechedreord.Rows(b).Item("account_number") = accnum And amt = 0 Then

                        Delete = "Delete from coll_depo_amount where colle_id='" & Val(Form1.collector_id.Text) & "' and depo_date='" & daycloseid & _
                                 "' and accountid='" & accnum & "' and collectionTYpe='" & colltypeId & "' and rectDateid='" & rectdateid & "'"
                        If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
                        da.DeleteCommand = Conalbank.CreateCommand       '------Deleting Entry--------
                        da.DeleteCommand.CommandText = Delete
                        da.DeleteCommand.ExecuteNonQuery()
                        Conalbank.Close()
                        Form1.Todays_deposited_amount_total()
                        delcounter += 1
                        Exit Try

                    ElseIf fechedreord.Rows(b).Item("account_number") = accnum And amt <> 0 Or fechedreord.Rows(b).Item("Amount") = 0 And amt > fechedreord.Rows(b).Item("Amount") Then

                        If fechedreord.Rows(b).Item("Amount") = amt Then

                            Exit Try

                        ElseIf fechedreord.Rows(b).Item("Amount") <> amt Then

                            Update = "update coll_depo_amount set amount='" & amt & "' where colle_id='" & Val(Form1.collector_id.Text) & _
                                     "' and accountid='" & accnum & "' and rectDateid='" & rectdateid & "' and depo_date='" & daycloseid & "'"
                            If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
                            da.UpdateCommand = Conalbank.CreateCommand  '-------Updating Entry---------
                            da.UpdateCommand.CommandText = Update
                            da.UpdateCommand.ExecuteNonQuery()
                            Conalbank.Close()
                            Form1.Todays_deposited_amount_total()
                            updatecounter += 1
                            Exit Try

                        End If

                    End If

                Next
            ElseIf amt > 0 Then

                Insert = "insert into coll_depo_amount(branch_code,colle_id,depo_date,accountid,amount,voucher_no,collectionTYpe,returnType," & _
                         "receiptno,rectDateid,user_login_id,user_login_date_time) values('" & Form1.Branch_Code.Text & "','" & Val(Form1.collector_id.Text) & _
                         "','" & daycloseid & "','" & accnum & "','" & amt & "','0','" & colltypeId & "','1','" & sl & "','" & rectdateid & _
                         "','" & loginid & "','" & Now() & "')"
                If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
                da.InsertCommand = Conalbank.CreateCommand    '---------Inserting New Record -----------
                da.InsertCommand.CommandText = Insert
                da.InsertCommand.ExecuteNonQuery()
                Conalbank.Close()
                Form1.Todays_deposited_amount_total()
                counter += 1
            End If

        Catch ex As Exception
            Error_handle("Data Saving Error", ex)
        Finally
            createdreord.Reset()
            fechedreord.Reset()
        End Try

        Try
            If Form1.Colltype.Text <> "DD" Then
                If indivisualac = 1 Then
                    GoTo mark1
                End If
                With Form1.Dgviews.Rows(val2)
                    balanceloanamt = Val(.Cells("Balance Amount").Value)
                    .Cells("Balance Amount").Value = Val(.Cells("Loan Amount").Value) - (Val(.Cells("Returned Amount").Value) + Val(.Cells("Amount").Value))
                    nweballoanamt = Val(.Cells("Balance Amount").Value)
                End With
            End If

mark1:      Form1.progress.Text = "Processing " & accnum

            Form1.Month_total_deposit()

            Form1.Collectors_total_reciept()

            If dsalbank.Tables("coll_total_trfr_amount").Rows(0).Item("sum(amount)") IsNot DBNull.Value Then
                Totalrecieptamt = dsalbank.Tables("coll_total_trfr_amount").Rows(0).Item("sum(amount)")
            Else
                Totalrecieptamt = 0
            End If
            balanceofmonth = Monthtotaldeposit - Totalrecieptamt
            Form1.Balanceamount.Text = balanceofmonth
        Catch ex As Exception
            Error_handle(" Balance Amount Calculation Error ", ex)
        End Try

        If counter > 0 Then          '------------ Messaging---------
            Form1.progress.Text = accnum & " Receipt Submited Successfully"
        ElseIf delcounter > 0 Then
            Form1.progress.Text = accnum & " Receipt Deleted Successfully"
        ElseIf updatecounter > 0 Then
            Form1.progress.Text = accnum & " Receipt Update Successfully"
        End If

    End Sub


End Class
