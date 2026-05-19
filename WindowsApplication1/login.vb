Imports System.Data
Imports System.Data.Odbc
Imports System.IO
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports System.Text


Public Class login

    Private mydatatable As DataTable

    Private Function GetHash(strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As New StringBuilder

        For Each b As Byte In bytesToHash
            strResult.Append(b.ToString("x2"))
        Next

        Return strResult.ToString

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strpass As String

        Try

            If Conalbank.State = ConnectionState.Closed Then Conalbank.Open()
            sql = "select * from login"
            Tableload(dsalbank, sql, Conalbank, "login")
            For a As Integer = 0 To dsalbank.Tables("login").Rows.Count - 1
                strpass = GetHash(password.Text)
                If StrComp(userid.Text, dsalbank.Tables("login").Rows(a).Item("user_name").ToString, CompareMethod.Text) = 0 And _
                    StrComp(strpass, dsalbank.Tables("login").Rows(a).Item("password").ToString, CompareMethod.Binary) = 0 Then
                    loginid = dsalbank.Tables("login").Rows(a).Item("id")
                    brncode = Val(branchcode.Text)
                    Form1.Branch_Code.Text = brncode
                    strpass = ""
                    Exit For
                ElseIf a = dsalbank.Tables("login").Rows.Count - 1 Then
                    MsgBox("Database Login Error" & Environment.NewLine & "Username or Password is wrong", vbOKOnly, "Error")
                    Exit Sub
                End If
                strpass = ""
            Next
            Form1.Show()
            Me.Hide()
        Catch ex As Exception
            Error_handle("Database Login Error", ex)
        Finally
            Conalbank.Close()
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub login_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        releaseObject(dsalbank)
        releaseObject(dsalkhairnew)
        Me.Dispose()
    End Sub

    Private Sub branchcode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles branchcode.KeyUp
        Dim pattern As String = "^*[0-9]$"
        Dim values As Match = Regex.Match(branchcode.Text, pattern)
        If values.Success = False Then branchcode.Text = ""
    End Sub

    Private Sub login_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Form1.Hide()
        Form1.CreateControl()
        Form1.CreateGraphics()
    End Sub

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Create_access_table()
    End Sub

    Private Sub password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles password.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        Config.ShowDialog()
    End Sub

End Class