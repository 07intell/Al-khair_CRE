Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Threading

Module Module1

#Region "Variables"

    '----------oledb----------------
    'Public Accessstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\Collectors_ac_list.mdb;"
    'Public conaccess As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(Accessstring)

    '--------- Mysql----------------
    'Public androidpath = "C:\Users\A Rahman\AppData\Local\Microsoft\Windows\Temporary Internet Files\Content.IE5\0XPU8XAZ\collection_Info[1];"
    Public Androidstring As String = "Dsn=SQLite3 Datasource;database=C:\Users\A Rahman\AppData\Local\Microsoft\Windows\Temporary Internet Files\Content.IE5\T2SA0PRV\collection_Info[1];stepapi=0;syncpragma=FULL;notxn=0;timeout=100000;shortnames=0;longnames=0;nocreat=0;nowchar=0;fksupport=0;oemcp=0;bigint=0;jdconv=0"
    Public conandroid As System.Data.Odbc.OdbcConnection = New System.Data.Odbc.OdbcConnection(Androidstring)

    Public albankstring, alkhairnewstring, accessstring, servername, Portnumber, userid, password, onlinedbpath As String

    Public Conalbank As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection()
    Public Conalkhairnew As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection()
    Public Conaccess As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection()

    Public da As MySql.Data.MySqlClient.MySqlDataAdapter
    Public daalkhairnew As MySql.Data.MySqlClient.MySqlDataAdapter
    Public daaccess As MySql.Data.MySqlClient.MySqlDataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter

    '----------Dataset and Datatable--------------
    Public dsalbank As DataSet = New DataSet
    Public dsalkhairnew As DataSet = New DataSet
    Public datatable As System.Data.DataTable = New System.Data.DataTable
    Public Dtloantemp As System.Data.DataTable = New System.Data.DataTable
    Public datatabletemp As System.Data.DataTable = New System.Data.DataTable
    Public Datatable_ac_list As System.Data.DataTable = New System.Data.DataTable
    Public dt_online_coll As System.Data.DataTable = New System.Data.DataTable

    Public NewTab As New TabPage
    Public constring_addrs As String = Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath) & "\connection.txt"
    Public onlinedbaddress As String = Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath) & "\onlinedbpath.txt"
    Public Temptabcontrol As New TabControl
    Private syncContext As SynchronizationContext = System.ComponentModel.AsyncOperationManager.SynchronizationContext
    Public sql, collid, newbranchcode, rdate, doedate, fromdate, message, Error_logfile_address, Ac_odr_collid, actype, constring, coll_ids, actype1 As String
    Public day, receiptdate, branchopendate, datecheck, todate, month_first_date, last_date, first_date, dat As Date
    Public curcell, sum, val1, val2, val3, val4, x, n, m, p, o, q, colltypeId, dsrowcount, dtrowcount, Get_old_aclist, gen_loanid, gstdedfrom As Integer
    Public rectdateid, accesstablefound, daycloseid, monthday1id, loginid, brncode, dateofentryid, balanceloanamt, ddmanualentry As Integer
    Public balanceamt, loanbropendateid, loanrectdateid, balanceofmonth, Monthtotaldeposit, Totalrecieptamt, finds, findtab, loan_report As Integer
    Public nweballoanamt, indivisualac, tabremove, refreshdata, totalbalanceamount, todaysdepositamount, collinfo, Dgviewrectrow, pagescount As Integer
    Public last_month_day1, last_month_lastday, loan_type, loantablename, clientsslcertpath, printtofilename, Message_logfile_address As String
    Public editpreviousreceipt As Boolean = False
    Public accreceptdate As Date = Date.FromOADate(1 / 1 / 2000)
    Public accdepositdate As Date = Date.FromOADate(1 / 1 / 2000)
    Public accdetails As Boolean = False
    Public Excessprofitgst As Boolean = False
    Public printersdetails As New Dictionary(Of String, Icon)()

    Private Declare Unicode Function WritePrivateProfileString Lib "kernel32" _
    Alias "WritePrivateProfileStringW" (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpString As String, _
    ByVal lpFileName As String) As Int32

    Private Declare Unicode Function GetPrivateProfileString Lib "kernel32" _
    Alias "GetPrivateProfileStringW" (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpDefault As String, _
    ByVal lpReturnedString As String, ByVal nSize As Int32, _
    ByVal lpFileName As String) As Int32


#End Region

    Public Sub readimport()
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True
        Dim sno As Integer = 0
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim constrfilecreate As StreamWriter
            Try
                If My.Computer.FileSystem.FileExists(onlinedbaddress) = False Then
                    constrfilecreate = File.CreateText(onlinedbaddress)
                    constrfilecreate.Close()
                End If
                Using writer As StreamWriter = New StreamWriter(onlinedbaddress)
                    writer.Write(openFileDialog1.FileName)
                    Dim query As String = "TRUNCATE TABLE online_daily_collection"
                    Dim cmd As New MySql.Data.MySqlClient.MySqlCommand(query, Conaccess)
                    If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
                    cmd.ExecuteNonQuery()
                    Conaccess.Close()
                End Using
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub online_collection_load()
        Dim myStream As Stream = Nothing
        Dim line As String
        Dim row As DataRow
        Dim sno As Integer
        If dt_online_coll.Columns.Count = 0 Then
            dt_online_coll.Columns.Add("id")
            dt_online_coll.Columns.Add("Branch_id")
            dt_online_coll.Columns.Add("Collector_Id")
            dt_online_coll.Columns.Add("Collection_id")
            dt_online_coll.Columns.Add("Date_id")
            dt_online_coll.Columns.Add("Account_no")
            dt_online_coll.Columns.Add("Amount")
        End If

        Try
            If My.Computer.FileSystem.FileExists(onlinedbaddress) = True Then
                Dim objReader As New System.IO.StreamReader(onlinedbaddress)
                While objReader.Peek() >= 0
                    onlinedbpath = objReader.ReadLine()
                End While
                If onlinedbpath = Nothing Then
                    My.Computer.FileSystem.DeleteFile(onlinedbpath)
                    GoTo addstring
                End If
                objReader.Close()
            Else
addstring:
                readimport()
            End If
        Catch ex As Exception
        End Try
        Dim checkfirstattempt As Integer = 0
        Try
            Dim mystreamreader As StreamReader = New StreamReader(onlinedbpath)
            Do
                line = mystreamreader.ReadLine
                If Not line = String.Empty Then
                    sno += 1
                    row = dt_online_coll.NewRow()
                    row.ItemArray = line.Split(","c)
                    'sql = "select * from online_daily_collection where Collection_id = " & row.Item(2) & " And Date_id = " & row.Item(3) & " and Account_no = " & row.Item(4) & " and Amount = " & row.Item(5)
                    'Tableload(dsalbank, sql, Conaccess, "online_daily_collection")
                    'If row.Item(2).ToString = Ac_odr_collid And dsalbank.Tables("online_daily_collection").Rows.Count = 0 Then
                    If row.Item(2).ToString = Ac_odr_collid Then
                        dt_online_coll.Rows.Add(sno, row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5))
                        '    sql = "INSERT INTO `online_daily_collection`(`Id`, `Branch_id`, `Collector_Id`, `Collection_id`, `Date_id`, `Account_no`, `Amount`) VALUES " & _
                        '          "(" & sno & "," & row.Item(0) & "," & row.Item(1) & "," & row.Item(2) & "," & row.Item(3) & "," & row.Item(4) & "," & row.Item(5) & ")"
                        '    daaccess.InsertCommand = Conaccess.CreateCommand
                        '    daaccess.InsertCommand.CommandText = sql
                        '    If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
                        '    daaccess.InsertCommand.ExecuteNonQuery()
                        '    Conaccess.Close()
                    End If
                Else
                    Exit Do
                End If
            Loop
            mystreamreader.Close()
        Catch Ex As Exception
            Error_handle("Collectors Base info Load Error", Ex)
        Finally
            ' Check this again, since we need to make sure we didn't throw an exception on open.
            If (myStream IsNot Nothing) Then
                myStream.Close()
            End If
        End Try

        Form1.online_Collection_to_sheet()

    End Sub

    Public Sub ReadTextFile()
        constring_addrs = Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath) & "\connection.txt"

        Try
            If My.Computer.FileSystem.FileExists(constring_addrs) = True Then

                Dim objReader As New System.IO.StreamReader(constring_addrs)

                While objReader.Peek() >= 0
                    constring = objReader.ReadLine()
                End While

                If constring = Nothing Then
                    My.Computer.FileSystem.DeleteFile(constring_addrs)
                    GoTo addstring
                End If
                objReader.Close()

                albankstring = constring & ";database=albank;Convert Zero Datetime=True"
                alkhairnewstring = constring & ";database=alkhairnew;Convert Zero Datetime=True"
                accessstring = constring & ";database=coll_ac_order;Convert Zero Datetime=True"

                Conalbank.ConnectionString = albankstring
                Conalkhairnew.ConnectionString = alkhairnewstring
                Conaccess.ConnectionString = accessstring

                Dim words As String() = constring.Split(New Char() {";", "="c})
                servername = words(1)
                Portnumber = words(3)
                userid = words(5)
                password = words(7)

            Else
addstring:
                If login.Visible = True Then login.Hide()
                Config.ShowDialog()
                Config.Server_name.Focus()

            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Error_handle(ByVal Trace As String, ByVal ex As Exception)

        message = Trace & " -- " & Today() & Environment.NewLine & ex.GetBaseException.ToString & Environment.NewLine
        MsgBox(message, vbOKOnly, "Error")
        Dim Errors As StreamWriter
        Error_logfile_address = Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath) & "\Error_log.txt"

        If My.Computer.FileSystem.FileExists(Error_logfile_address) = False Then
            Errors = File.CreateText(Error_logfile_address)
        End If

        My.Computer.FileSystem.WriteAllText(Error_logfile_address, message, True)
    End Sub

    Public Sub message_handle(ByVal Trace As String)
        message = Trace & " -- " & Today() & Environment.NewLine
        Dim messages As StreamWriter
        Message_logfile_address = Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath) & "\Message_log.txt"

        If My.Computer.FileSystem.FileExists(Message_logfile_address) = False Then
            messages = File.CreateText(Message_logfile_address)
        End If

        My.Computer.FileSystem.WriteAllText(Message_logfile_address, message, True)
    End Sub

    Public Sub Tableload(ByVal ds As DataSet, ByVal sql As String, ByVal con As MySql.Data.MySqlClient.MySqlConnection, ByVal Tablename As String)
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            For a As Integer = 0 To ds.Tables.Count - 1
                If ds.Tables(a).TableName = Tablename Then ds.Tables(Tablename).Reset()
            Next
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, con)
            da.Fill(ds, Tablename)
        Catch ex As Exception

        Finally
            con.Close()
        End Try

    End Sub

    Public Sub Insert(ByVal Insert As String)

        If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
        da.InsertCommand = Conalbank.CreateCommand    '---------Inserting New Record -----------
        da.InsertCommand.CommandText = Insert
        da.InsertCommand.ExecuteNonQuery()
        Conalbank.Close()

    End Sub

    Public Sub Access_db_table_check()

        Try
            sql = "select * from Coll_Ac_order where Coll_id='" & Ac_odr_collid & "' ORDER BY New_serial_no"
            Tableload(dsalbank, sql, Conaccess, "Coll_Ac_order")
            If dsalbank.Tables("Coll_Ac_order").Rows.Count > 0 Then accesstablefound = 1
        Catch ex As Exception
            Error_handle("Loading Collectors Account Order List Table Error", ex)
        Finally
            Conaccess.Close()
        End Try

    End Sub

    Public Sub collectors_id_List()

        Try '------ Loading Collector's Id and Account Name ----------
            If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()

            sql = "select id_by_name,groups from genrate_total_id where id = '" & coll_ids & "' and type_of_user='COLL'"
            Tableload(dsalbank, sql, Conalbank, "genrate_total_id")
            With dsalbank.Tables("genrate_total_id")
                If .Rows.Count > 0 Then Form1.Colltype.Text = .Rows(0).Item("groups").ToString
                If .Rows.Count > 0 Then Form1.Collname.Text = .Rows(0).Item("id_by_name").ToString
            End With
        Catch ex As Exception
            Error_handle("Collectors Base info Load Error", ex)
        Finally
            Conalbank.Close()
        End Try

    End Sub

    Private Sub Loan_reciept_date_id()

        Try '------- Loan receipt Date ID ---------
            If Conalkhairnew.State = ConnectionState.Closed Then Conalkhairnew.Open()
            rdate = mydate(receiptdate)
            sql = "select id,cur_date from day_clese where cur_date='" & rdate & "'"
            Tableload(dsalkhairnew, sql, Conalkhairnew, "Receipt_date")
            loanrectdateid = dsalkhairnew.Tables("Receipt_date").Rows(0).Item("id")
        Catch ex As Exception
            Error_handle("Receipt Date ID Load Error", ex)
        Finally
            Conalkhairnew.Close()
        End Try

    End Sub

    Private Sub New_branch_code()

        Try '----- New Branch Code ------
            If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
            sql = "select * from branch_detils"
            Tableload(dsalbank, sql, Conalbank, "branch_detils")
            For a As Integer = 0 To dsalbank.Tables("branch_detils").Rows.Count - 1
                newbranchcode = dsalbank.Tables("branch_detils").Rows(a).Item("branch_code")
            Next
        Catch ex As Exception
            Error_handle("Branch Code Load Error", ex)
        Finally
            Conalbank.Close()
        End Try

    End Sub

    Private Sub Collectors_Account_Order()
        Dim dataView As New DataView(datatabletemp)
        dataView.Sort = "account_number ASC"
        datatabletemp = dataView.ToTable

        If datatable.Rows.Count > 0 Then datatable.Rows.Clear()
        If accesstablefound = 1 Then

            Dim l As Integer = datatabletemp.Rows.Count - 1
            If datatabletemp.Rows.Count > 0 Then

                '----------Adding Account as per collectors Arrengement----------
                For b As Integer = 0 To l
                    datatable.Rows.Add(b + 1, _
                                                   datatabletemp.Rows(b).Item("app_name_one"), _
                                                   datatabletemp.Rows(b).Item("account_number"), _
                                                   datatabletemp.Rows(b).Item("join_date"))
                Next

                l = datatable.Rows.Count - 1
                If dsalbank.Tables("Coll_Ac_order").Rows.Count - 1 > 0 Then
                    For a As Integer = 0 To dsalbank.Tables("Coll_Ac_order").Rows.Count - 1
                        For b As Integer = 0 To l
                            If dsalbank.Tables("Coll_Ac_order").Rows(a).Item("Account_No") = datatable.Rows(b).Item("account_number") Then
                                datatable.Rows(b).Delete()
                                datatable.AcceptChanges()
                                l = l - 1
                                b = b - 1
                            End If
                            If l = b Then Exit For
                        Next
                    Next
                End If


                '----------Inserting Account at specified position -----------
                For a As Integer = 0 To dsalbank.Tables("Coll_Ac_order").Rows.Count - 1
                    With dsalbank.Tables("Coll_Ac_order").Rows(a)
                        If Char.IsNumber(.Item("New_serial_no")) Then
                            For b As Integer = 0 To datatabletemp.Rows.Count - 1
                                If .Item("Account_No") = datatabletemp.Rows(b).Item("account_number") Then
                                    Dim datarow As DataRow = datatable.NewRow()
                                    datarow.Item(0) = b
                                    datarow.Item(1) = datatabletemp.Rows(b).Item("app_name_one")
                                    datarow.Item(2) = datatabletemp.Rows(b).Item("account_number")
                                    datarow.Item(3) = datatabletemp.Rows(b).Item("join_date")
                                    datarow.Item(4) = 0
                                    datatable.Rows.InsertAt(datarow, CInt(.Item("New_serial_no")) - 1)
                                    Exit For
                                End If
                            Next
                        End If
                    End With
                Next

                For a As Integer = 0 To datatable.Rows.Count - 1
                    datatable.Rows(a).Item(0) = a + 1
                Next

            End If
        Else
            '-----------Adding Unarrenge Account List -------------

            'Dim dataView As New DataView(datatabletemp) 'sorting datatable
            'dataView.Sort = "account_number ASC"
            'datatabletemp = dataView.ToTable

            If datatabletemp.Rows.Count - 1 > 0 Then
                For b As Integer = 0 To datatabletemp.Rows.Count - 1
                    datatable.Rows.Add(datatable.Rows.Count + 1, datatabletemp.Rows(b).Item("app_name_one"), _
                                              datatabletemp.Rows(b).Item("account_number"), _
                                              datatabletemp.Rows(b).Item("join_date"))
                Next
            End If
        End If

        If datatabletemp IsNot Nothing Then datatabletemp.Reset()
        If dsalbank.Tables("Coll_Ac_order") IsNot Nothing Then dsalbank.Tables("Coll_Ac_order").Reset()

    End Sub

    Private Sub filldatatodatatable()

    End Sub

    Private Sub Collectors_Loan_Account_Order()

        Making_datatable_for_loan()
        Dim newlamount As Integer

        If accesstablefound = 1 Then
            If datatabletemp.Rows.Count > 0 Then
                '----------Adding Account as per collectors sheet Arrengement----------
                For a As Integer = 0 To dsalbank.Tables("Coll_Ac_order").Rows.Count - 1
                    For b As Integer = 0 To datatabletemp.Rows.Count - 1
                        With dsalbank.Tables("Coll_Ac_order").Rows(a)
                            If .Item("New_serial_no") <> "L" And .Item("New_serial_no") <> "D" Then
                                If .Item("Account_No") = datatabletemp.Rows(b).Item("gen_loan_id") Then
                                    sql = "select gst_ded_from from loan_gst where loanid=" & datatabletemp.Rows(b).Item("id")
                                    Tableload(dsalbank, sql, Conalbank, "loan_gst")
                                    If dsalbank.Tables("loan_gst").Rows.Count = 0 Then gstdedfrom = 0 Else gstdedfrom = dsalbank.Tables("loan_gst").Rows(0).Item("gst_ded_from")
                                    If datatabletemp.Rows(b).Item("loan_request_date") > 608 And gstdedfrom = 2 Then
                                        newlamount = CInt(datatabletemp.Rows(b).Item("loan_amount")) + ((CInt(datatabletemp.Rows(b).Item("loan_profit")) * 18) / 100)
                                    Else
                                        newlamount = CInt(datatabletemp.Rows(b).Item("loan_amount"))
                                    End If
                                    datatable.Rows.Add(.Item("New_serial_no"), _
                                                                   datatabletemp.Rows(b).Item("id"), _
                                                                   datatabletemp.Rows(b).Item("gen_loan_id"), _
                                                                   datatabletemp.Rows(b).Item("loan_type"), _
                                                                   datatabletemp.Rows(b).Item("oldAcNo"), _
                                                                   datatabletemp.Rows(b).Item("id1"), _
                                                                   datatabletemp.Rows(b).Item("id_by_name"), newlamount, 0, 0, 0, datatabletemp.Rows(b).Item("loan_profit"))

                                    datatable.Rows(datatable.Rows.Count - 1).Item("Installment") = datatabletemp.Rows(b).Item("loan_inst_amt")
                                    datatable.Rows(datatable.Rows.Count - 1).Item("loan_profit") = datatabletemp.Rows(b).Item("loan_profit")
                                    datatabletemp.Rows(b).Delete()
                                    datatabletemp.Rows(b).AcceptChanges()
                                    newlamount = 0
                                    Exit For
                                End If
                            End If
                        End With
                    Next
                Next

                '----------Adding New Account -----------
                For b As Integer = 0 To datatabletemp.Rows.Count - 1
                    For a As Integer = 0 To dsalbank.Tables("Coll_Ac_order").Rows.Count - 1
                        If dsalbank.Tables("Coll_Ac_order").Rows(a).Item("Account_No") = datatabletemp.Rows(b).Item("gen_loan_id") Then
                            Exit For
                        ElseIf a = dsalbank.Tables("Coll_Ac_order").Rows.Count - 1 Then
                            sql = "select gst_ded_from from loan_gst where loanid=" & datatabletemp.Rows(b).Item("id")
                            Tableload(dsalbank, sql, Conalbank, "loan_gst")
                            If dsalbank.Tables("loan_gst").Rows.Count = 0 Then gstdedfrom = 0 Else gstdedfrom = dsalbank.Tables("loan_gst").Rows(0).Item("gst_ded_from")
                            If datatabletemp.Rows(b).Item("loan_request_date") > 608 And gstdedfrom = 2 Then
                                newlamount = CInt(datatabletemp.Rows(b).Item("loan_amount")) + ((CInt(datatabletemp.Rows(b).Item("loan_profit")) * 18) / 100)
                            Else
                                newlamount = CInt(datatabletemp.Rows(b).Item("loan_amount"))
                            End If
                            datatable.Rows.Add(datatable.Rows.Count + 1, _
                                                                  datatabletemp.Rows(b).Item("id"), _
                                                                  datatabletemp.Rows(b).Item("gen_loan_id"), _
                                                                  datatabletemp.Rows(b).Item("loan_type"), _
                                                                  datatabletemp.Rows(b).Item("oldAcNo"), _
                                                                  datatabletemp.Rows(b).Item("id1"), _
                                                                  datatabletemp.Rows(b).Item("id_by_name"), newlamount, 0, 0, 0, datatabletemp.Rows(b).Item("loan_profit"))
                            datatable.Rows(datatable.Rows.Count - 1).Item("Installment") = datatabletemp.Rows(b).Item("loan_inst_amt")
                            datatable.Rows(datatable.Rows.Count - 1).Item("loan_profit") = datatabletemp.Rows(b).Item("loan_profit")
                            newlamount = 0
                        End If
                    Next
                Next

                '----------Adding Account Send to Last -----------
                For a As Integer = 0 To dsalbank.Tables("Coll_Ac_order").Rows.Count - 1
                    For b As Integer = 0 To datatabletemp.Rows.Count - 1
                        With dsalbank.Tables("Coll_Ac_order").Rows(a)
                            If .Item("New_serial_no") = "L" Then
                                If .Item("Account_No") = datatabletemp.Rows(b).Item("gen_loan_id") Then
                                    sql = "select gst_ded_from from loan_gst where loanid=" & datatabletemp.Rows(b).Item("id")
                                    Tableload(dsalbank, sql, Conalbank, "loan_gst")
                                    If dsalbank.Tables("loan_gst").Rows.Count = 0 Then gstdedfrom = 0 Else gstdedfrom = dsalbank.Tables("loan_gst").Rows(0).Item("gst_ded_from")
                                    If datatabletemp.Rows(b).Item("loan_request_date") > 608 And gstdedfrom = 2 Then

                                        newlamount = CInt(datatabletemp.Rows(b).Item("loan_amount")) + ((CInt(datatabletemp.Rows(b).Item("loan_profit")) * 18) / 100)
                                    Else
                                        newlamount = CInt(datatabletemp.Rows(b).Item("loan_amount"))
                                    End If
                                    datatable.Rows.Add(datatable.Rows.Count + 1, _
                                                                  datatabletemp.Rows(b).Item("id"), _
                                                                  datatabletemp.Rows(b).Item("gen_loan_id"), _
                                                                  datatabletemp.Rows(b).Item("loan_type"), _
                                                                  datatabletemp.Rows(b).Item("oldAcNo"), _
                                                                  datatabletemp.Rows(b).Item("id1"), _
                                                                  datatabletemp.Rows(b).Item("id_by_name"), newlamount, 0, 0, 0, datatabletemp.Rows(b).Item("loan_profit"))
                                    datatable.Rows(datatable.Rows.Count - 1).Item("Installment") = datatabletemp.Rows(b).Item("loan_inst_amt")
                                    datatable.Rows(datatable.Rows.Count - 1).Item("loan_profit") = datatabletemp.Rows(b).Item("loan_profit")
                                    newlamount = 0
                                End If
                            End If
                        End With
                    Next
                Next
            End If
        Else
            '-----------Adding Unarrenge Account List -------------

            If datatabletemp.Rows.Count > 0 Then
                For b As Integer = 0 To datatabletemp.Rows.Count - 1
                    sql = "select gst_ded_from from loan_gst where loanid=" & datatabletemp.Rows(b).Item("id")
                    Tableload(dsalbank, sql, Conalbank, "loan_gst")
                    If dsalbank.Tables("loan_gst").Rows.Count = 0 Then gstdedfrom = 0 Else gstdedfrom = dsalbank.Tables("loan_gst").Rows(0).Item("gst_ded_from")
                    If datatabletemp.Rows(b).Item("loan_request_date") > 608 And gstdedfrom = 2 Then
                        newlamount = CInt(datatabletemp.Rows(b).Item("loan_amount")) + ((CInt(datatabletemp.Rows(b).Item("loan_profit")) * 18) / 100)
                    Else
                        newlamount = CInt(datatabletemp.Rows(b).Item("loan_amount"))
                    End If
                    datatable.Rows.Add(datatable.Rows.Count + 1, _
                                                                  datatabletemp.Rows(b).Item("id"), _
                                                                  datatabletemp.Rows(b).Item("gen_loan_id"), _
                                                                  datatabletemp.Rows(b).Item("loan_type"), _
                                                                  datatabletemp.Rows(b).Item("oldAcNo"), _
                                                                  datatabletemp.Rows(b).Item("id1"), _
                                                                  datatabletemp.Rows(b).Item("id_by_name"), newlamount, 0, 0, 0)
                    datatable.Rows(datatable.Rows.Count - 1).Item("Installment") = datatabletemp.Rows(b).Item("loan_inst_amt")
                    datatable.Rows(datatable.Rows.Count - 1).Item("loan_profit") = datatabletemp.Rows(b).Item("loan_profit")
                    newlamount = 0
                Next
            End If
        End If

        If datatabletemp IsNot Nothing Then datatabletemp.Reset()
        If dsalbank.Tables("Coll_Ac_order") IsNot Nothing Then dsalbank.Tables("Coll_Ac_order").Reset()

    End Sub

    Private Sub Loan_total_deposit()

        Try '----- Loading Loan Total deposited amount and Loan Amount------
            Dim lastinatalldateid As Boolean = False
            Dim gen_loanid, roundamount As Integer
            Dim loan_type As String
            Dim n As Integer = datatable.Rows.Count - 1
            Dim Disburs_Date As Integer = 0
            Dim gststatus, profitstatus, gstamount, profitamount, excessgst, excessprofit, actualgst, actualprofit, loan_date_id As Integer


            For a As Integer = 0 To n
                If loan_report = 0 Then Form1.SetProgress_instanceSafe(a, n)
                gen_loanid = datatable.Rows(a).Item("gen_id")
                loan_type = datatable.Rows(a).Item("loan_type")

                sql = "select vou_id,drparticular,crparticular,drcramount,cramount,date_id,groups,id,narration from daybook where (drparticular='" & _
                    gen_loanid & "' or crparticular='" & gen_loanid & "') order by id"

                If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)

                da.Fill(Dtloantemp)
                Conalbank.Close()

                If loan_report = 1 Then
                    Loans_report.last_month_deposit(datatable.Rows(a).Item("account_number"))
                    actype = loan_type
                    Dim o As Integer = dsalbank.Tables("loan_date_Inst").Rows.Count - 1
                    For b As Integer = 0 To o
                        Dim dt As Date = Date.Parse(dsalbank.Tables("loan_date_Inst").Rows(b).Item("cur_date"))
                        Disburs_Date = dsalbank.Tables("loan_date_Inst").Rows(b).Item("loan_dateid")
                        datatable.Rows(a).Item("Disburse_date") = dt.ToShortDateString()
                        datatable.Rows(a).Item("Month_request") = dsalbank.Tables("loan_date_Inst").Rows(b).Item("loan_no_of_inst")
                    Next
                End If

                With datatable.Rows(a)
                    If .Item("Loan_amount") Is DBNull.Value Then .Item("Loan_amount") = 0
                    If .Item("Returned_amount") Is DBNull.Value Then .Item("Returned_amount") = 0
                    .Item("Balance_Amount") = 0
                    .Item("Amount") = 0
                    If loan_report = 1 Then .Item("Last_month_deposit") = 0
                    .Item("Receipt_No") = a + 1
                    Dim loantype As String = .Item("loan_type")
                    gststatus = 0
                    profitstatus = 0
                    excessgst = 0
                    excessprofit = 0
                    actualgst = 0
                    actualprofit = 0
                    profitamount = 0
                    gstamount = 0
                    loan_date_id = 0
                    For b As Integer = 1 To Dtloantemp.Rows.Count - 1
                        If Dtloantemp.Rows(b).Item("narration").ToString.Contains("GST Deducation") = True Or _
                            Dtloantemp.Rows(b).Item("narration").ToString.Contains("GST updated") = True Then
                            gststatus = 1
                            gstamount = gstamount + Dtloantemp.Rows(b).Item("drcramount")
                        End If
                        If Dtloantemp.Rows(b).Item("narration").ToString.Contains("Borrowing Cost Deducation") = True Or _
                            Dtloantemp.Rows(b).Item("narration").ToString.Contains("Borrowing Cost updated") = True Then
                            profitstatus = 1
                            profitamount = profitamount + Dtloantemp.Rows(b).Item("drcramount")
                        End If

                        If .Item("Loan_amount") = 0 Or b > 1 Then
                            If Dtloantemp.Rows(b).Item("drparticular") = .Item("gen_id") And Dtloantemp.Rows(b).Item("groups") = loantype Then
                                .Item("Loan_amount") += Dtloantemp.Rows(b).Item("drcramount")
                            End If
                        End If
                        If Dtloantemp.Rows(b).Item("crparticular") = .Item("gen_id") And Dtloantemp.Rows(b).Item("groups") = "C" & loantype Then
                            .Item("Returned_amount") += Dtloantemp.Rows(b).Item("cramount")
                        End If
                        If Dtloantemp.Rows(b).Item("crparticular") = .Item("gen_id") And Dtloantemp.Rows(b).Item("groups") = "RI" & loantype Then
                            .Item("Returned_amount") += Dtloantemp.Rows(b).Item("cramount")
                        End If

                        If Dtloantemp.Rows(b).Item("crparticular") = .Item("gen_id") And Dtloantemp.Rows(b).Item("groups") = "IT" & loantype Then
                            .Item("Returned_amount") += Dtloantemp.Rows(b).Item("cramount")
                            'Dim vouid As Integer
                            'vouid = Dtloantemp.Rows(b).Item("vou_id")
                            'sql = "select vou_id,drparticular,crparticular,drcramount,cramount,date_id,groups,id,narration from daybook where vou_id='" & vouid & "' order by vou_id"
                            'Tableload(dsalbank, sql, Conalbank, "Excess")
                            'For x As Integer = 0 To dsalbank.Tables("Excess").Rows.Count - 1
                            'If Dtloantemp.Rows(b).Item("cramount") = dsalbank.Tables("Excess").Rows(x).Item("cramount") Then
                            'excprofitreturn = excprofitreturn + Dtloantemp.Rows(b).Item("cramount")
                            'exgstreturn = exgstreturn + Dtloantemp.Rows(b).Item("cramount")
                            'End If
                            'Next
                        End If

                        If Dtloantemp.Rows(b).Item("crparticular") = .Item("gen_id") And Dtloantemp.Rows(b).Item("groups") = "BCE" & loantype Then
                            .Item("Returned_amount") += Dtloantemp.Rows(b).Item("cramount")
                        End If
                        If Dtloantemp.Rows(b).Item("crparticular") = .Item("gen_id") And Dtloantemp.Rows(b).Item("groups") = "WC" & loantype Then
                            .Item("Returned_amount") += Dtloantemp.Rows(b).Item("cramount")
                        End If
                        If Dtloantemp.Rows(b).Item("drparticular") = .Item("gen_id") And Dtloantemp.Rows(b).Item("groups") = "ITEX" & loantype Then
                            .Item("Loan_amount") += Dtloantemp.Rows(b).Item("drcramount")
                        End If
                        If Dtloantemp.Rows(b).Item("drparticular") = .Item("gen_id") And Dtloantemp.Rows(b).Item("groups") = "OWC" & loantype Then
                            .Item("Loan_amount") += Dtloantemp.Rows(b).Item("drcramount")
                        End If

                        If Dtloantemp.Rows(b).Item("date_id") >= last_month_day1 _
                            And Dtloantemp.Rows(b).Item("date_id") <= last_month_lastday _
                            And Dtloantemp.Rows(b).Item("crparticular") = .Item("gen_id") _
                            And (Dtloantemp.Rows(b).Item("groups") = "C" & loantype _
                            Or Dtloantemp.Rows(b).Item("groups") = "RI" & loantype _
                            Or Dtloantemp.Rows(b).Item("groups") = "IT" & loantype _
                            Or Dtloantemp.Rows(b).Item("groups") = "BCE" & loantype _
                            Or Dtloantemp.Rows(b).Item("groups") = "ITEX" & loantype _
                            Or Dtloantemp.Rows(b).Item("groups") = "WC" & loantype _
                            Or Dtloantemp.Rows(b).Item("groups") = "OWC" & loantype) _
                            And loan_report = 1 Then
                            .Item("Last_month_deposit") += Dtloantemp.Rows(b).Item("cramount")
                        End If

                        If (Dtloantemp.Rows(b).Item("crparticular") = .Item("gen_id") Or Dtloantemp.Rows(b).Item("drparticular") = .Item("gen_id")) And _
                            b = Dtloantemp.Rows.Count - 1 And Dtloantemp.Rows(b).Item("date_id") < monthday1id Then
                            lastinatalldateid = True
                        End If
                        loan_date_id = Dtloantemp.Rows(1).Item("date_id")
                    Next

                    actualprofit = .Item("loan_profit")
                    actualgst = (actualprofit * 18) / 100
                    If actualprofit = profitamount Or _
                       actualprofit + 1 = profitamount Or _
                       actualprofit + 2 = profitamount Or _
                       actualprofit + 3 = profitamount Or _
                       actualprofit + 4 = profitamount Or _
                       actualprofit - 1 = profitamount Or _
                       actualprofit - 2 = profitamount Or _
                       actualprofit - 3 = profitamount Or _
                       actualprofit - 4 = profitamount Then
                        excessprofit = 0
                        profitamount = actualprofit
                    Else
                        excessprofit = profitamount - actualprofit
                        If profitamount > actualprofit Then
                            'message_handle(.Item("account_number") & " -- Borrowing Cost = " & actualprofit & _
                            '" -- Borrowing Cost Deducted = " & profitamount & _
                            '" -- Excess Borrowing Cost = " & excessprofit)
                            Excessprofitgst = True
                        End If
                    End If

                    If actualgst = gstamount Or _
                       actualgst + 1 = gstamount Or _
                       actualgst + 2 = gstamount Or _
                       actualgst + 3 = gstamount Or _
                       actualgst + 4 = gstamount Or _
                       actualgst + 5 = gstamount Or _
                       actualgst - 1 = gstamount Or _
                       actualgst - 2 = gstamount Or _
                       actualgst - 3 = gstamount Or _
                       actualgst - 4 = gstamount Or _
                       actualgst - 5 = gstamount Then
                        excessgst = 0
                        gstamount = actualgst
                    Else
                        excessgst = gstamount - actualgst
                        If gstamount > actualgst Then
                            Excessprofitgst = True
                            'message_handle(.Item("account_number") & " -- GST = " & actualgst & _
                            '" -- GST Deducted = " & gstamount & " -- Excess GST = " & excessgst)
                        End If
                    End If

                    If profitstatus = 1 And gststatus = 1 And loan_date_id > 608 = True Then
                        If actualprofit = profitamount And actualgst = gstamount Then
                            .Item("Loan_amount") = .Item("Loan_amount") - (actualgst + actualprofit)
                        ElseIf actualprofit > profitamount And actualgst > gstamount Then
                            .Item("Loan_amount") = .Item("Loan_amount") - (gstamount + profitamount)
                        ElseIf actualprofit < profitamount And actualgst < gstamount Then
                            .Item("Loan_amount") = .Item("Loan_amount") - (actualgst + actualprofit)
                        ElseIf actualprofit = profitamount And actualgst = gstamount And CInt(.Item("Returned_amount")) > CInt(.Item("Loan_amount") - (actualgst + actualprofit)) Then
                            .Item("Balance_Amount") = (.Item("Loan_amount") - (actualgst + actualprofit)) - .Item("Returned_amount")
                        End If
                    ElseIf profitstatus = 1 And gststatus = 0 And loan_date_id > 608 = True Then
                        .Item("Loan_amount") = .Item("Loan_amount") - actualprofit
                    End If

                    roundamount = Math.Round(CInt(.Item("Loan_amount")))
                    .Item("Loan_amount") = roundamount
                    roundamount = Math.Round(CInt(.Item("Returned_amount")))
                    .Item("Returned_amount") = roundamount

                    If (.Item("Loan_amount") = .Item("Returned_amount") _
                        Or (.Item("Loan_amount") + 1 = .Item("Returned_amount")) _
                        Or (.Item("Loan_amount") + 2 = .Item("Returned_amount"))) _
                        And .Item("Loan_amount") IsNot DBNull.Value _
                        And .Item("Returned_amount") IsNot DBNull.Value And lastinatalldateid = True Then

                        sql = "INSERT INTO Coll_Ac_order (Coll_id, New_serial_no, Ac_holder_name, Account_no) VALUES('0', 'C', '" & _
                            loantype & "', '" & .Item("account_number") & "')"
                        If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
                        daaccess.InsertCommand = Conaccess.CreateCommand
                        daaccess.InsertCommand.CommandText = sql
                        daaccess.InsertCommand.ExecuteNonQuery()
                        Conaccess.Close()

                        .Delete()
                        datatable.AcceptChanges()
                        n -= 1
                        a -= 1
                        lastinatalldateid = False

                        'new code
                    ElseIf .Item("Loan_amount") <> .Item("Returned_amount") And .Item("Loan_amount") IsNot DBNull.Value _
                        And .Item("Returned_amount") IsNot DBNull.Value And lastinatalldateid = False Then
                        If dsalbank.Tables("Cleared_loan").Rows.Count > 0 Then
                            For k As Integer = 0 To dsalbank.Tables("Cleared_loan").Rows.Count - 1
                                If .Item("account_number") = dsalbank.Tables("Cleared_loan").Rows(k).Item("Account_no") Then
                                    sql = "DELETE FROM Coll_Ac_order WHERE Account_no=" & .Item("account_number")
                                    If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
                                    daaccess.DeleteCommand = Conaccess.CreateCommand
                                    daaccess.DeleteCommand.CommandText = sql
                                    daaccess.DeleteCommand.ExecuteNonQuery()
                                    Conaccess.Close()
                                    'new code
                                End If
                            Next
                        End If
                    End If

                End With
                lastinatalldateid = False
                Dtloantemp.Reset()
                If a = n Then Exit For

            Next

            Dim dataView As New DataView(datatable)

            dataView.Sort = "account_number ASC"

            datatable = dataView.ToTable

            If loan_report = 1 Then
                'If Excessprofitgst = True Then Form6.Show()
                Exit Sub
            End If

            Form1.SetProgress_instanceSafe(0, 1000)

            '----- Adding Total deposit till last month ------
            If Form1.CheckBox1.Checked = False Then
                Form1.BackgroundWorker2.WorkerReportsProgress = True
                Form1.BackgroundWorker2.WorkerSupportsCancellation = True
                Form1.BackgroundWorker2.RunWorkerAsync()
            End If

            If Form1.RadioButton3.Checked = True Then
                Form1.Multisheet()
            ElseIf Form1.RadioButton1.Checked = True Then
                Form1.OneSheet_Without_Total()
            End If

        Catch ex As Exception
            Error_handle("Loan Total Deposit or Loan Amount Load Error", ex)
        End Try

    End Sub

    Private Sub Making_datatable_for_loan()

        Try '----- Making data Table------
            With datatable
                .Columns.Add("Receipt_No")
                .Columns.Add("id")
                .Columns.Add("account_number")
                .Columns.Add("loan_type")
                .Columns.Add("oldAcNo")
                .Columns.Add("gen_id")
                .Columns.Add("id_by_name")
                .Columns.Add("Loan_amount")
                .Columns.Add("Returned_amount")
                .Columns.Add("Amount")
                .Columns.Add("Balance_Amount")
                If loan_report = 1 Then
                    .Columns.Add("Disburse_date").DefaultValue = 0
                    .Columns.Add("Last_month_deposit").DefaultValue = 0
                    .Columns.Add("Month_request").DefaultValue = 0
                End If
                .Columns.Add("Installment").DefaultValue = 0
                .Columns.Add("loan_profit")
            End With
        Catch ex As Exception
            Error_handle("Datatable designing and setting Error", ex)
        End Try

    End Sub

    Public Sub Collector_Ac_list()

        Dim Receipt_No As New DataColumn
        Receipt_No.AutoIncrement = True
        Receipt_No.AutoIncrementSeed = 1
        coll_ids = Form1.collector_id.Text
        actype = Form1.Colltype.Text
        If loan_report = 1 Then
            coll_ids = Loans_report.collector_id.Text
            actype = actype1
        End If

        Loan_reciept_date_id()

        New_branch_code()

        collectors_id_List()

        Access_db_table_check()

        If datatable IsNot Nothing Then datatable.Reset()

        If Form1.Colltype.Text = "DD" Then
            If datatabletemp.Rows.Count > 0 Then datatabletemp.Rows.Clear()
            If datatabletemp.Columns.Count > 0 Then datatabletemp.Columns.Clear()

            Try '---------- Loading Collectors DD Account List ----------
                datatable.Columns.Add("Receipt_No")
                datatable.Columns.Add("app_name_one")
                datatable.Columns.Add("account_number")
                datatable.Columns.Add("join_date")
                datatable.Columns.Add("Amount")
                datatable.Columns("Amount").DefaultValue = 0

                sql = "SELECT me.account_number, md.app_name_one, me.join_date FROM membership me, membership_details md " & _
                    "WHERE Me.id = md.membership_tableid AND me.colector_collection_id ='" & Val(Form1.collector_id.Text) & "'"
                '" & fromdate & "

                If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)

                da.Fill(datatabletemp)
                Conalbank.Close()

                sql = "SELECT me.account_number, me.account_close_status, me.account_close_date FROM membership me " & _
                    "WHERE me.account_close_status='1' AND me.colector_collection_id ='" & Val(Form1.collector_id.Text) & "'"
                Tableload(dsalbank, sql, Conalbank, "accountclose")

                Dim n As Integer = datatabletemp.Rows.Count - 1
                For i As Integer = 0 To dsalbank.Tables("accountclose").Rows.Count - 1
                    For j As Integer = 0 To n
                        If dsalbank.Tables("accountclose").Rows(i).Item("account_number") = datatabletemp.Rows(j).Item("account_number") _
                            And dsalbank.Tables("accountclose").Rows(i).Item("account_close_date") < month_first_date Then
                            If dsalbank.Tables("accountclose").Rows(i).Item("account_close_status") = 1 Then
                                datatabletemp.Rows(j).Delete()
                                datatabletemp.AcceptChanges()
                                j -= 1
                                n -= 1
                            End If
                        End If
                        If j = n Then Exit For
                    Next
                Next

                Collectors_Account_Order()

                Form1.Todays_entry_check()

                Conalbank.Close()

                Form1.Collector_info()

                If Form1.RadioButton3.Checked = True Then
                    Form1.Multisheet()
                ElseIf Form1.RadioButton1.Checked = True Then
                    Form1.OneSheet_Without_Total()
                End If

            Catch ex As Exception
                Error_handle("DD Account List Loading Error", ex)
            Finally
                Conalbank.Close()
            End Try

        Else

            Try '------- loading Collectors Loan Account List -----------

                'sql = "select lo.id,lo.gen_loan_id,lo.loan_type,lo.oldAcNo,gt.id,gt.id_by_name from loan_id lo,genrate_total_id gt " & _
                '  " where lo.loan_type='" & Form1.Colltype.Text & "' and lo.colector_id='" & Val(Form1.collector_id.Text) & "'" & _
                ' " and lo.loan_dateid between '" & loanbropendateid & "' and '" & loanrectdateid & "' and gt.genrated_id=lo.id " & _
                '"and gt.tableid=lo.id and gt.type_of_user='LO' and gt.tableid=lo.id and gt.groups='CA' order by lo.gen_loan_id"

                '-------important------------
                'sql = "select lo.id,lo.gen_loan_id,lo.loan_type,lo.oldAcNo,gt.id,me.applicant_name id_by_name from albank.loan_id lo,albank." &
                'Form1.Colltype.Text & "_loan de,albank.genrate_total_id gt,alkhairnew.membership me where lo.loan_type='" & Form1.Colltype.Text & "' and lo.colector_id='" &
                'Val(Form1.collector_id.Text) & "' and lo.id=de.loanid and de.loan_sgmno=me.fullmemshipid and " & " lo.loan_dateid between '" &
                'loanbropendateid & "' and '" & loanrectdateid & "' and gt.id=lo.loan_id and me.branch_code='BR04' order by lo.loan_id"
                'Tableload(dsalbank, sql, Conalbank, "MTBLDetails")

                If Form1.Colltype.Text = "DL" Then
                    loantablename = "demand"
                    actype = "DL"
                ElseIf Form1.Colltype.Text = "ML" Then
                    loantablename = "morabiya"
                    actype = "ML"
                ElseIf Form1.Colltype.Text = "MTBL" Then
                    loantablename = Form1.Colltype.Text
                    actype = "MTBL"
                ElseIf Form1.Colltype.Text = "STBL" Then
                    loantablename = Form1.Colltype.Text
                    actype = "STBL"
                End If
                If loantablename = Nothing And actype = Nothing Then
                    MsgBox("Error", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                Dim colname As String
                If loantablename = "demand" Then
                    colname = "loan_ser_charge as loan_profit"
                Else
                    colname = "loan_profit"
                End If

                sql = "select lo.id,lo.gen_loan_id,lo.loan_type,lo.oldAcNo,gt.id,gt.id_by_name,me.applicant_name," & _
                      "de.loan_inst_amt,de.loan_amount,de." & colname & ",de.loan_request_date from " & _
                      "albank.loan_id lo," & _
                      "albank.genrate_total_id gt," & _
                      "albank." & loantablename & "_loan de," & _
                      "alkhairnew.membership me where " & _
                      "lo.loan_type='" & actype & "' " & _
                      "and lo.colector_id='" & Val(coll_ids) & "' " & _
                      "and lo.id=de.loanid " & _
                      "and lo.loan_dateid between '" & loanbropendateid & "' and '" & loanrectdateid & "' " & _
                      "and gt.genrated_id=lo.id " & _
                      "and gt.tableid=lo.id " & _
                      "and gt.type_of_user='LO' " & _
                      "and gt.groups='CA' " & _
                      "and de.loan_sgmno=me.fullmemshipid order by lo.gen_loan_id"

                If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, Conalbank)
                If datatabletemp.Rows.Count > 0 Then datatabletemp.Reset()
                If datatabletemp.Columns.Count >= 1 Then GoTo Mark2 Else datatabletemp.Columns.Add(Receipt_No)
Mark2:          da.Fill(datatabletemp)

                sql = "select * from Coll_Ac_order where Ac_holder_name='" & actype & "' and New_serial_no='C'"
                Tableload(dsalbank, sql, Conaccess, "Cleared_loan")

                Dim c As Integer = datatabletemp.Rows.Count - 1
                Dim name As String
                If dsalbank.Tables("Cleared_loan").Rows.Count > 0 Then
                    For a As Integer = 0 To dsalbank.Tables("Cleared_loan").Rows.Count - 1
                        For b As Integer = 0 To c
                            If datatabletemp.Rows(b).Item("gen_loan_id") = dsalbank.Tables("Cleared_loan").Rows(a).Item("Account_no") Then
                                datatabletemp.Rows(b).Delete()
                                datatabletemp.AcceptChanges()
                                c -= 1
                                b -= 1
                            End If
                            If b = c Then Exit For
                        Next
                    Next
                End If

                For b As Integer = 0 To c
                    name = datatabletemp.Rows(b).Item("applicant_name") & "(" & datatabletemp.Rows(b).Item("gen_loan_id") & ")"
                    datatabletemp.Rows(b).Item("id_by_name") = name
                Next

                Collectors_Loan_Account_Order()

                If loan_report = 0 Then
                    datatable.Columns.Remove("Installment")
                    datatable.AcceptChanges()
                End If

            Catch ex As Exception
                Error_handle("Collectors Loan Account List Load Error", ex)
            Finally
                Conalbank.Close()
            End Try

            'Making_datatable_for_loan()

            Loan_total_deposit()

        End If

    End Sub

    Function mydate(ByVal dates As Date)

        Dim newdate As String = ""

        If dates.Month >= 10 And dates.Day >= 10 Then
            newdate = String.Concat(dates.Year, "-", dates.Month, "-", dates.Day)
        ElseIf dates.Month < 10 And dates.Day >= 10 Then
            newdate = String.Concat(dates.Year, "-", "0" & dates.Month, "-", dates.Day)
        ElseIf dates.Day < 10 And dates.Month >= 10 Then
            newdate = String.Concat(dates.Year, "-", dates.Month, "-", "0" & dates.Day)
        ElseIf dates.Day < 10 And dates.Month < 10 Then
            newdate = String.Concat(dates.Year, "-", "0" & dates.Month, "-", "0" & dates.Day)
        End If

        Return newdate

    End Function

    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect(obj)
        End Try
    End Sub

    Public Sub Get_Account_List()

        Form1.savelist.Enabled = True
        Form1.btn_manual.Enabled = True

        Form1.Dgview = Nothing
        Form1.Dgviews = Nothing
        collid = Form3.Collectors_ac_id.Text

        Try
            For b As Integer = 0 To dsalbank.Tables("collector_id").Rows.Count - 1
                If dsalbank.Tables("collector_id").Rows(b).Item("Account id") = Val(collid) Then actype = dsalbank.Tables("collector_id").Rows(b).Item("groups")
                If dsalbank.Tables("collector_id").Rows(b).Item("Account id") = Val(collid) Then Form1.Collname.Text = dsalbank.Tables("collector_id").Rows(b).Item("Collector Name")
            Next

            Form1.Colltype.Text = actype
            rdate = mydate(day)

            If Datatable_ac_list IsNot Nothing Then Datatable_ac_list.Reset()
            Datatable_ac_list.Columns.Add("Serial_No")
            Datatable_ac_list.Columns.Add("Ac_holder_name")
            Datatable_ac_list.Columns.Add("Account_no")
            Datatable_ac_list.Columns.Add("New_serial_no")

            If actype = "DD" Then

                sql = "Select me.account_number,md.app_name_one,me.join_date from membership me,membership_details md" & _
                      " where me.id=md.membership_tableid and me.account_close_status='0' and me.colector_collection_id='" & _
                      Val(collid) & "' and join_date between '" & branchopendate & "' and '" & rdate & "'order by me.account_number"
                Tableload(dsalbank, sql, Conalbank, "Collectors_ac_list")

                With dsalbank.Tables("Collectors_ac_list")
                    For a As Integer = 0 To .Rows.Count - 1
                        Datatable_ac_list.Rows.Add(a + 1, .Rows(a).Item(1), .Rows(a).Item(0), "")
                    Next
                End With

                If dsalbank.Tables("Collectors_ac_list") IsNot Nothing Then dsalbank.Tables("Collectors_ac_list").Reset()
                releaseObject(dsalbank.Tables("Collectors_ac_list"))

            Else

                sql = "select lo.id,lo.gen_loan_id,lo.loan_type,lo.oldAcNo,gt.id,gt.id_by_name from loan_id lo,genrate_total_id gt" & _
                      " where lo.loan_type='" & actype & "' and lo.colector_id='" & Val(collid) & "'" & " and lo.loan_dateid " & _
                      "between '" & loanbropendateid & "' and '" & daycloseid & "' and gt.genrated_id=lo.id " & "and gt.tableid=lo.id" & _
                      " and gt.type_of_user='LO' and gt.tableid=lo.id and gt.groups='CA' order by lo.gen_loan_id"

                Tableload(dsalbank, sql, Conalbank, "Collectors_loan_ac_list")

                With dsalbank.Tables("Collectors_loan_ac_list")

                    For a As Integer = 0 To .Rows.Count - 1

                        Dim appname As String = .Rows(a).Item("id_by_name").ToString
                        Dim newappname As String

                        If actype = "DL" Then
                            newappname = appname.Substring(0, appname.Length - 10)
                        Else
                            newappname = appname.Substring(0, appname.Length - 12)
                        End If

                        Datatable_ac_list.Rows.Add(a + 1, newappname, .Rows(a).Item("gen_loan_id").ToString, "")
                    Next

                End With

            End If

            Dim dataView As New DataView(Datatable_ac_list)

            dataView.Sort = "Account_no ASC"

            Datatable_ac_list = dataView.ToTable

            Form1.Tab_remove()

            Form1.TabControl1.Name = "Tabctrl_Reciept"
            Temptabcontrol = Form1.TabControl1

            Form1.Dgviewrect = Temptabcontrol.TabPages(0).Controls.Item(0)
            Form1.Dgviewrect.MultiSelect = False

            If Form1.Dgviewrect.Rows.Count > 0 Then Form1.Dgviewrect.Rows.Clear()
            If Form1.Dgviewrect.Columns.Count > 0 Then Form1.Dgviewrect.Columns.Clear()

            With Form1.Dgviewrect.Columns
                .Add("Serial_No", "Serial No")
                .Add("Account_Holder_Name", "Name")
                .Add("Account Number", "Account Number")
                .Add("New_serial_no", "New Serial No")
            End With

            With Form1.Dgviewrect
                .Columns(1).Width = 150
                .Columns(2).Width = 120
                .Columns(0).ReadOnly = True
                .Columns(1).ReadOnly = True
                .Columns(2).ReadOnly = True
                .Columns(3).ReadOnly = False
            End With

            Form1.Dgviewrect.AllowUserToAddRows = False
            Form1.Dgviewrect.EditMode = DataGridViewEditMode.EditOnEnter
            Form1.Dgviewrect.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            sql = "Select * from Coll_Ac_order where Ac_holder_name='" & actype & "' and New_serial_no='C'"
            Tableload(dsalbank, sql, Conaccess, "cleared_loan_list")
            Dim n As Integer = Datatable_ac_list.Rows.Count - 1
            For b = 0 To dsalbank.Tables("cleared_loan_list").Rows.Count - 1
                For a As Integer = 0 To n
                    If a = n Then Exit For
                    Dim k, l As String
                    k = Datatable_ac_list.Rows(a).Item("Account_no").ToString
                    l = dsalbank.Tables("cleared_loan_list").Rows(b).Item("Account_no").ToString
                    If k = l Then
                        Datatable_ac_list.Rows(a).Delete()
                        Datatable_ac_list.AcceptChanges()
                        n -= 1
                        a -= 1
                        Exit For
                    End If
                Next
            Next

            With Datatable_ac_list
                For a As Integer = 0 To Datatable_ac_list.Rows.Count - 1
                    Form1.Dgviewrect.Rows.Add(a + 1, .Rows(a).Item("Ac_holder_name"), .Rows(a).Item("Account_no"), .Rows(a).Item("New_serial_no"))
                Next
            End With

            If Get_old_aclist = 1 And Ac_odr_collid = Form3.Collectors_ac_id.Text Then

                sql = "Select * from Coll_Ac_order where Coll_id='" & Ac_odr_collid & "'"
                Tableload(dsalbank, sql, Conaccess, "Coll_Ac_order")

                If dsalbank.Tables("Coll_Ac_order").Rows.Count - 1 < 1 Then Form1.progress.Text = "Account order list is not available"

                With dsalbank.Tables("Coll_Ac_order")
                    For a As Integer = 0 To .Rows.Count - 1
                        For b As Integer = 0 To Form1.Dgviewrect.Rows.Count - 1
                            If Form1.Dgviewrect.Rows(b).Cells("Account Number").Value = .Rows(a).Item("Account_no") Then
                                Form1.Dgviewrect.Rows(b).Cells("New_serial_no").Value = .Rows(a).Item("New_serial_no")
                                Exit For
                            End If
                        Next
                    Next

                End With

                dsalbank.Tables("Coll_Ac_order").Reset()
                'dsalbank.Tables("Collectors_ac_list").Reset()

            Else

            End If

            Datatable_ac_list.Reset()
            If Form1.Dgviewrect.Rows.Count - 1 = 0 Then Form1.Dgviewrect.Rows(0).Cells("New_serial_no").Selected = True

        Catch ex As Exception
            Error_handle("Get collectors account List Error", ex)
        Finally

        End Try

    End Sub

    Public Sub Create_access_table()
        Dim strConn As String
        Dim conn As MySqlConnection
        Dim cmd As MySqlCommand
        'If File.Exists("C:\xampp\mysql\bin\my.ini") Then
        'WritePrivateProfileString("mysqld", "bind-address", "0.0.0.0", "C:\xampp\mysql\bin\my.ini")
        'End If
        ReadTextFile()
        strConn = constring
        strConn &= ";Database = mysql;Convert Zero Datetime=True"
        conn = New MySqlConnection(strConn)

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("Mysql or Xampp Server isnot Running")
            Config.ShowDialog()
        Finally
            conn.Close()
        End Try

        Try
            cmd = New MySqlCommand("Create Database If Not exists Coll_Ac_order", conn)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            Error_handle("Create My Sql Database Error", ex)
        End Try

        Try

            sql = "CREATE TABLE If Not exists Coll_Ac_order.Coll_Ac_order (Coll_id varchar(6), New_serial_no varchar(15) , Ac_holder_name varchar(50) ,Account_No varchar(15))"
            cmd = New MySqlCommand(sql, conn)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            Error_handle("Create Collector Table Error", ex)
        End Try

    End Sub

    Public Sub cleared_loan()

    End Sub

    Public Sub Access_database_insert()

        sql = "SELECT * FROM Coll_Ac_order where coll_id='" & Ac_odr_collid & "'"
        Tableload(dsalbank, sql, Conaccess, "Coll_Ac_order")

        If dsalbank.Tables("Coll_Ac_order").Rows.Count - 1 > 0 Then
            Try
                sql = "Delete from Coll_Ac_order where coll_id='" & Ac_odr_collid & "'"
                If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
                da.DeleteCommand = Conaccess.CreateCommand
                da.DeleteCommand.CommandText = sql
                da.DeleteCommand.ExecuteNonQuery()
                releaseObject(dsalbank.Tables("Coll_Ac_order"))
                Conaccess.Close()
            Catch ex As Exception
                Error_handle("Table All row delete error", ex)
            End Try
        End If

        dtrowcount = Form1.Dgviewrect.Rows.Count - 1
        With Form1.Dgviewrect
            If dtrowcount > 0 Then
                For c As Integer = 0 To dtrowcount
                    If Char.IsDigit(.Rows(c).Cells("New_serial_no").Value) Then
                        If CInt(.Rows(c).Cells("New_serial_no").Value) > 0 Then
                            sql = "INSERT INTO Coll_Ac_order (Coll_id, New_serial_no, Ac_holder_name, Account_no)" & _
                                   " VALUES('" & Ac_odr_collid & _
                                   "', '" & .Rows(c).Cells("New_serial_no").Value & _
                                   "', '" & .Rows(c).Cells("Account_Holder_Name").Value & _
                                   "', '" & .Rows(c).Cells("Account Number").Value & "')"

                            If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
                            daaccess.InsertCommand = Conaccess.CreateCommand
                            daaccess.InsertCommand.CommandText = sql
                            daaccess.InsertCommand.ExecuteNonQuery()
                            Conaccess.Close()
                        End If
                    ElseIf Char.IsLetter(.Rows(c).Cells("New_serial_no").Value) Then
                        If .Rows(c).Cells("New_serial_no").Value.ToString = "D" Or .Rows(c).Cells("New_serial_no").Value.ToString = "d" Then
                            sql = "INSERT INTO Coll_Ac_order (Coll_id, New_serial_no, Ac_holder_name, Account_no)" & _
                                   " VALUES('" & Ac_odr_collid & "', 'D', '" & .Rows(c).Cells("Account_Holder_Name").Value & _
                                   "', '" & .Rows(c).Cells("Account Number").Value & "')"

                            If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
                            daaccess.InsertCommand = Conaccess.CreateCommand
                            daaccess.InsertCommand.CommandText = sql
                            daaccess.InsertCommand.ExecuteNonQuery()
                            Conaccess.Close()
                        End If
                    End If
                Next

            End If
        End With
        Form1.progress.Text = "New Account Order is Saved for Collector ID " + collid
    End Sub

    Public Sub Access_database_insert_New()

        sql = "SELECT * FROM Coll_Ac_order where coll_id='" & Ac_odr_collid & "'"
        Tableload(dsalbank, sql, Conaccess, "Coll_Ac_order")

        If dsalbank.Tables("Coll_Ac_order").Rows.Count - 1 > 0 Then
            Try
                sql = "Delete from Coll_Ac_order where coll_id='" & Ac_odr_collid & "'"
                If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
                da.DeleteCommand = Conaccess.CreateCommand
                da.DeleteCommand.CommandText = sql
                da.DeleteCommand.ExecuteNonQuery()
                releaseObject(dsalbank.Tables("Coll_Ac_order"))
                Conaccess.Close()
            Catch ex As Exception
                Error_handle("Table All row delete error", ex)
            End Try
        End If

        If dsalbank.Tables("Coll_Ac_order").Rows.Count - 1 > 0 Then
            dtrowcount = Form1.Dgviewrect.Rows.Count - 1
            With Form1.Dgviewrect
                If dtrowcount > 0 Then
                    For a As Integer = 0 To dtrowcount
                        If .Rows(a).Cells("New_serial_no").Value.ToString = "L" Or .Rows(a).Cells("New_serial_no").Value.ToString = "l" Or .Rows(a).Cells("New_serial_no").Value.ToString = "0" Then
                            sql = "INSERT INTO Coll_Ac_order ( Coll_id, New_serial_no, Ac_holder_name, Account_no)" & _
                                   " VALUES('" & Ac_odr_collid & "', 'L', '" & .Rows(a).Cells("Account_Holder_Name").Value & _
                                   "', '" & .Rows(a).Cells("Account Number").Value & "')"

                            If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
                            daaccess.InsertCommand = Conaccess.CreateCommand
                            daaccess.InsertCommand.CommandText = sql
                            daaccess.InsertCommand.ExecuteNonQuery()
                            Conaccess.Close()
                        End If
                    Next

                    For a As Integer = 0 To dtrowcount
                        If .Rows(a).Cells("New_serial_no").Value.ToString = "D" Or .Rows(a).Cells("New_serial_no").Value.ToString = "d" Then
                            sql = "INSERT INTO Coll_Ac_order (Coll_id, New_serial_no, Ac_holder_name, Account_no)" & _
                                   " VALUES('" & Ac_odr_collid & "', 'D', '" & .Rows(a).Cells("Account_Holder_Name").Value & _
                                   "', '" & .Rows(a).Cells("Account Number").Value & "')"

                            If Conaccess.State = ConnectionState.Closed Then Conaccess.Open()
                            daaccess.InsertCommand = Conaccess.CreateCommand
                            daaccess.InsertCommand.CommandText = sql
                            daaccess.InsertCommand.ExecuteNonQuery()
                            Conaccess.Close()
                        End If
                    Next

                End If
            End With
        End If
        Form1.progress.Text = "New Account Order is Saved for Collector ID " + collid
    End Sub

End Module
