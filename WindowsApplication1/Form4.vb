Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Reflection
Imports System.Data.SQLite
Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Globalization

Public Class Form4

#Region "veriables"

    Dim apppath As String = ""
    Dim fileaddress, folderName As String
    Private Delegate Sub delegate_progressbarupdate(ByVal value As Integer, ByVal maximum As Integer)
    Dim device_id, device_name, device_list, device_full_name, selected_device As String
    Dim user_name, Password, collector_name, rept_pass, ms_name, dd_acc_no, loan1_acc_no, loan2_acc_no,
        collection_type, collection_date, Insert, account_no, amounts, id, transfer_date As String
    Dim branch_code, dd_id, dl_id, stbl_id, mtbl_id, ml_id, ms_id, ms_number, collector_id, dd_balance,
        loan1_amount, loan1_balance, loan2_amount, loan2_balance, collection_amount,
        rectcounter, sl_no, rectdate As Integer
    Dim mobileno As Long
    Dim datatabletemp As DataTable = New DataTable
    Dim datatransfer_bydate As Boolean
    Dim mybaseloading As Boolean = False

#End Region

#Region "Form Process"

    Private Sub SetProgress_instanceSafe(ByVal paramvalue As Integer, ByVal parammaximum As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New delegate_progressbarupdate(AddressOf Me.SetProgress_instanceSafe), paramvalue, parammaximum)
        Else
            Me.ProgressBar1.Visible = True
            Me.ProgressBar1.Maximum = parammaximum
            Me.ProgressBar1.Value = paramvalue
            Me.ProgressBar1.Update()

        End If
    End Sub

    Private Sub Form4_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        adb("/c adb kill-server")
    End Sub

    Private Sub Form4_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        releaseObject(datatabletemp)
        Me.Dispose()
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'ProgressBar1.Width = Panel1.Width
            If Not Directory.Exists(Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\ADB") Then
                Directory.CreateDirectory(Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\ADB")
            Else
                If Not File.Exists(Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\ADB\adb.exe") Then
                    File.WriteAllBytes(Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\ADB\adb.exe", My.Resources.adb)
                End If
                If Not File.Exists(Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\ADB\AdbWinApi.dll") Then
                    File.WriteAllBytes(Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\ADB\AdbWinApi.dll", My.Resources.AdbWinApi)
                End If
                If Not File.Exists(Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\ADB\AdbWinUsbApi.dll") Then
                    File.WriteAllBytes(Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\ADB\AdbWinUsbApi.dll", My.Resources.AdbWinUsbApi)
                End If
                If Not File.Exists(Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\ADB\fastboot.exe") Then
                    File.WriteAllBytes(Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\ADB\fastboot.exe", My.Resources.fastboot)
                End If
            End If
            If Not Directory.Exists(backup_path) Then
                MsgBox("Please set backup path for Android database backup", vbOKOnly)
                tab1page.Btn_Backup.PerformClick()
                Exit Try
            Else

            End If
            device_list = (adb("/c adb start-server"))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        mybaseloading = True
    End Sub

    Private Sub Form4_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'ProgressBar1.Width = Panel1.Width
    End Sub

#End Region

#Region "Tab1"

    Private Sub Btn_device_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_device.Click

        Try
            If LB_device.Items.Count > 0 Then LB_device.Items.Clear()
            device_list = (adb("/c adb devices -l"))
            Dim parts As String() = device_list.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
            If parts.Length <= 3 Then
                LB_device.Items.Add("No Attached Device Found")
            Else
                For i = 1 To parts.Length - 3
                    device_id = parts(i).ToString.Substring(0, 10)
                    device_name = (adb("/c adb -s " & device_id & " shell getprop ro.semc.product.name"))
                    device_full_name = device_id & "-> " & device_name
                    LB_device.Items.Add(device_full_name)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'device_id = adb("/c adb shell getprop ro.serialno")
        'MsgBox(adb("/c adb shell getprop ro.semc.product.name") & device_id)

        'Shell("cmd.exe /c " & Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\ADB" & _
        '      " adb devices -l", AppWinStyle.Hide)

    End Sub

    Private Sub Btn_sync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_sync.Click
        Try
            LB_process.Items.Clear()
            LB_process.Items.Add("Syncing Started...")
            LB_process.Refresh()

            If LB_device.SelectedItem IsNot Nothing Then

                selected_device = LB_device.SelectedItem.ToString.Substring(0, 10)
                adb("/c adb -s " & selected_device & " pull " & sqlite_db_loc & "collection_info " & backup_path)

                If My.Computer.FileSystem.FileExists(backup_path & "\collection_info_" & Today.Date & "_" & Now.Hour & "_" & Now.Minute) Then
                    MsgBox("Same Backup Exist", vbOKOnly)
                Else
                    If My.Computer.FileSystem.FileExists(backup_path & "\collection_info") Then
                        My.Computer.FileSystem.RenameFile(backup_path & "\collection_info", "collection_info_" & Today.Date & "_" & Now.Hour & "_" & Now.Minute)
                    Else
                        MsgBox("Backup Fail", vbOKOnly)
                    End If
                End If

                LB_process.Items.Add("Android Database Backup Complete...")
                LB_process.Refresh()

                adb("/c adb -s " & selected_device & " pull " & sqlite_db_loc & "collection_info " & _
                    Path.GetDirectoryName(My.Application.Info.DirectoryPath))

                Load_date(List_date, Label19, Label18, Label14, Label16)

                Load_balance_datagrid(DGView1, "ALL")
                RadioButton6.Checked = True

                Amount_total(DGView1)

            Else
                MsgBox("Please Select a device to Sync")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        '/mnt/sdcard/Al-khair/
    End Sub

    Private Sub Btn_data_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_data.Click
        Try
            Androidstring = "Data Source=" & Path.GetDirectoryName(My.Application.Info.DirectoryPath) & _
                          "\collection_Info;Version=3;New=True;"
            conandroid = New System.Data.SQLite.SQLiteConnection(Androidstring)

            LB_process.Items.Add("Data Transfer Started...")
            LB_process.Refresh()

            conandroid.Open()
            sql = "SELECT * FROM coll_deposit Where transfer_status=0"
            daAndroid = New SQLite.SQLiteDataAdapter(sql, conandroid)
            daAndroid.Fill(dsAndroid, "coll_deposit")

            For a As Integer = 0 To List_date.Items.Count - 1
                transfer_date = List_date.Items(a).ToString
                Data_transfer_to_database()
            Next

            Updated_database_to_android_device()

            datatable_design(datatabletemp)

            Listboxvalue = True

            Member_info(datatabletemp, Label18.Text.ToString)

            loan_balance(datatabletemp)

            New_account_check(LB_process, datatabletemp)

            MsgBox("Data Transfer Process Completed", vbOKOnly)

        Catch ex As Exception
            MsgBox("Error in Inserting new account details" + Environment.NewLine + ex.Message.ToString)
            Exit Sub
        End Try

        If conandroid.State = ConnectionState.Open Then conandroid.Close()
        If Conalbank.State = ConnectionState.Open Then Conalbank.Close()

    End Sub

    Private Sub Btn_get_date_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_get_date.Click

        load_by_date_to_datagrid(List_date, LB_process, DGView1, datatabletemp)

        Amount_total(DGView1)

    End Sub

    Private Sub Btn_Trfr_date_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Trfr_date.Click

        Androidstring = "Data Source=" & Path.GetDirectoryName(My.Application.Info.DirectoryPath) & _
               "\collection_Info;Version=3;New=True;"
        conandroid = New System.Data.SQLite.SQLiteConnection(Androidstring)

        LB_process.Items.Add("Data Transfer Started...")
        LB_process.Refresh()

        conandroid.Open()
        sql = "SELECT * FROM coll_deposit Where transfer_status=0"
        daAndroid = New SQLite.SQLiteDataAdapter(sql, conandroid)
        daAndroid.Fill(dsAndroid, "coll_deposit")

        If List_date.SelectedItem IsNot Nothing Then

            transfer_date = List_date.SelectedItem.ToString

            Data_transfer_to_database()

            Updated_database_to_android_device()

            Listboxvalue = True

            datatable_design(datatabletemp)

            Member_info(datatabletemp, Label18.Text.ToString)

            loan_balance(datatabletemp)

            New_account_check(LB_process, datatabletemp)

            MsgBox("Data Transfer Process Completed", vbOKOnly)

        Else
            MsgBox("Please Select Date", vbOKOnly)
        End If

        conandroid.Close()
        Conalbank.Close()

    End Sub

    Public Sub Data_transfer_to_database()

        Dim mysqldate As String
        If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
        For a As Integer = 0 To dsAndroid.Tables("coll_deposit").Rows.Count - 1
            Me.SetProgress_instanceSafe(a, dsAndroid.Tables("coll_deposit").Rows.Count - 1)
            collection_date = Module1.Format_date(dsAndroid.Tables("coll_deposit").Rows(a).Item("depo_date").ToString)
            If collection_date = transfer_date Then
                LB_process.Items.Add("Receipt Entery of " & account_no & " Transfered...")
                LB_process.Refresh()

                id = dsAndroid.Tables("coll_deposit").Rows(a).Item("id").ToString
                branch_code = CInt(dsAndroid.Tables("coll_deposit").Rows(a).Item("branch_code"))
                collector_id = CInt(dsAndroid.Tables("coll_deposit").Rows(a).Item("collector_id"))
                colltypeId = CInt(collectionType(dsAndroid.Tables("coll_deposit").Rows(a).Item("collection_type").ToString))
                account_no = dsAndroid.Tables("coll_deposit").Rows(a).Item("account_id").ToString
                amounts = dsAndroid.Tables("coll_deposit").Rows(a).Item("amount").ToString

                mysqldate = mydate(CDate(collection_date))
                sql = "select id,cur_date from day_clese where cur_date='" & mysqldate & "'"
                Tableload(dsalkhairnew, sql, Conalkhairnew, "receipt_date_id")

                rectdate = CInt(dsalkhairnew.Tables("receipt_date_id").Rows(0).Item("id"))

                Insert = "INSERT INTO coll_depo_amount (branch_code,colle_id,depo_date,accountid,amount,voucher_no,collectionTYpe," & _
                    "returnType,receiptno,rectDateid,user_login_id,user_login_date_time) VALUES('" & _
                    branch_code & "','" & _
                    collector_id & "','" & _
                    daycloseid & "','" & _
                    account_no & "','" & _
                    amounts & "','0','" & _
                    colltypeId & "','1','" & _
                    a + 1 & "','" & _
                    rectdate & "','" & _
                    loginid & "','" & _
                    Now() & "')"

                da.InsertCommand = Conalbank.CreateCommand    '---------Inserting New Record -----------
                da.InsertCommand.CommandText = Insert
                da.InsertCommand.ExecuteNonQuery()


                sql = "UPDATE coll_deposit set transfer_status=1 WHERE id=" & id
                daAndroid.InsertCommand = conandroid.CreateCommand    '---------Update status of old Record -----------
                daAndroid.InsertCommand.CommandText = sql
                daAndroid.InsertCommand.ExecuteNonQuery()

            End If
        Next

    End Sub

    Public Sub Updated_database_to_android_device()

        selected_device = LB_device.SelectedItem.ToString.Substring(0, 10)
        adb("/c adb -s " & selected_device & " push " & Path.GetDirectoryName(My.Application.Info.DirectoryPath) & _
            "\collection_Info " & sqlite_db_loc)

        LB_process.Items.Add("Receipt Entery Completed...")
        LB_process.Refresh()

    End Sub

    Private Sub DGView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGView1.MouseClick

        If DGView1.CurrentCell.ColumnIndex <> 5 Or DGView1.CurrentCell.RowIndex = DGView1.RowCount - 1 Or DGView1.CurrentCell.RowIndex = 0 Then
            Exit Sub
        Else
            Dim id As String = ""
            For a As Integer = 0 To dsAndroid.Tables("coll_deposit").Rows.Count - 1
                collection_date = Module1.Format_date(dsAndroid.Tables("coll_deposit").Rows(a).Item("depo_date").ToString)
                If DGView1.Rows(DGView1.CurrentCell.RowIndex).Cells("AccountNo").Value.ToString =
                    dsAndroid.Tables("coll_deposit").Rows(a).Item("account_id").ToString And
                    DGView1.Rows(DGView1.CurrentCell.RowIndex).Cells("DepoDate").Value.ToString = collection_date Then
                    id = dsAndroid.Tables("coll_deposit").Rows(a).Item("id").ToString
                End If
            Next

            Androidstring = "Data Source=" & Path.GetDirectoryName(My.Application.Info.DirectoryPath) & _
                     "\collection_Info;Version=3;New=True;"
            conandroid = New System.Data.SQLite.SQLiteConnection(Androidstring)
            conandroid.Open()

            sql = "DELETE FROM coll_deposit WHERE id=" & id
            daAndroid.DeleteCommand = conandroid.CreateCommand
            daAndroid.DeleteCommand.CommandText = sql
            daAndroid.DeleteCommand.ExecuteNonQuery()

        End If

        If RadioButton1.Checked Then
            Load_balance_datagrid(DGView1, "DD")
        ElseIf RadioButton2.Checked Then
            Load_balance_datagrid(DGView1, "DL")
        ElseIf RadioButton2.Checked Then
            Load_balance_datagrid(DGView1, "STBL")
        ElseIf RadioButton2.Checked Then
            Load_balance_datagrid(DGView1, "MTBL")
        ElseIf RadioButton2.Checked Then
            Load_balance_datagrid(DGView1, "ML")
        ElseIf RadioButton2.Checked Then
            Load_balance_datagrid(DGView1, "ALL")
        End If

        LB_process.Items.Add("Record Deleted...")
        LB_process.Refresh()

        Amount_total(DGView1)

    End Sub

#End Region

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Load_balance_datagrid(DGView1, "DD")
        Amount_total(DGView1)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Load_balance_datagrid(DGView1, "DL")
        Amount_total(DGView1)
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Load_balance_datagrid(DGView1, "STBL")
        Amount_total(DGView1)
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Load_balance_datagrid(DGView1, "MTBL")
        Amount_total(DGView1)
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton5.CheckedChanged
        Load_balance_datagrid(DGView1, "ML")
        Amount_total(DGView1)
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton6.CheckedChanged
        If Me.Created Then
            Load_balance_datagrid(DGView1, "ALL")
            Amount_total(DGView1)
        End If
    End Sub

End Class
