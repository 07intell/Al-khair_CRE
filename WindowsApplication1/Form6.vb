Imports System.IO

Public Class Form6

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Excessprofitgst = True Then
            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText(Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath) & "\Message_log.txt")
            TextBox1.Text = fileReader
            TextBox1.SelectionStart = TextBox1.Text.Length + 1
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

End Class