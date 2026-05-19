Imports System.IO

Public Class Config

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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim constrfilecreate As StreamWriter
        Dim server, port, user_id, password As String
        Try
            server = Server_name.Text
            port = Port_no.Text
            user_id = User_name.Text
            password = Tb_Password.Text

            constring = "server=" + server + ";port=" + port + ";user id=" + user_id + ";password=" + password

            If My.Computer.FileSystem.FileExists(constring_addrs) = False Then
                constrfilecreate = File.CreateText(constring_addrs)
                constrfilecreate.Close()
            End If

            Using writer As StreamWriter = New StreamWriter(constring_addrs)
                writer.Write(constring)
            End Using
        Catch ex As Exception

        End Try
        ReadTextFile()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Config_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Form1.Enabled = False Then
            Form1.Enabled = True
        ElseIf Form1.IsAccessible = False And login.Visible = False Then
            login.Visible = True
        End If

    End Sub

    Private Sub Config_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Server_name.Text = servername
        'Port_no.Text = Portnumber
        User_name.Text = userid
        Tb_Password.Text = password
    End Sub

    Private Sub Tb_Password_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tb_Password.GotFocus
        Tb_Password.PasswordChar = Nothing
    End Sub

    Private Sub Tb_Password_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tb_Password.LostFocus
        Tb_Password.PasswordChar = "*"
    End Sub

    Private Sub btn_close_Click(sender As System.Object, e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

End Class