Public Class Accountdetails

    Const WM_NCHITTEST As Integer = &H84
    Const HTCLIENT As Integer = &H1
    Const HTCAPTION As Integer = &H2
    Dim rowclicked As Integer
    Dim colclicked As Integer

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_NCHITTEST
                MyBase.WndProc(m)
                If m.Result = IntPtr.op_Explicit(HTCLIENT) Then m.Result = IntPtr.op_Explicit(HTCAPTION)
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

    Private Sub Accountdetails_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Form1.Dgviews = Form1.TabControl1.SelectedTab.Controls.Item(0)
        Form1.Dgview = Form1.Dgviews
        indivisualac = 0
        Me.Dispose()
    End Sub

    Private Sub Accountdetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With DataGridView1
            If .Rows.Count - 1 > 1 Then .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(0, 64, 0)
            If .Rows.Count - 1 > 1 Then .Rows(.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.White
            If .Rows.Count - 1 > 1 Then .Rows(.Rows.Count - 1).ReadOnly = True
        End With
    End Sub

    Private Sub Accountdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Form1.Width / 2) - (Me.Width / 2), 15)
        DataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
        Dim rectd As Date
        If Form1.labelentry.Visible = False Then rectd = Form1.dateofsoftware.Text Else rectd = Form1.labelentry.Text
        For a = 0 To DataGridView1.Rows.Count - 2
            If DataGridView1.Rows(a).Cells("Receipt_Date").Value = Form1.Dtprectdate.Value And _
                DataGridView1.Rows(a).Cells("Deposit_Date").Value = rectd Then
                DataGridView1.Rows(a).Cells("Amount").ReadOnly = True
            End If
        Next
        DataGridView1.ContextMenuStrip = ContextMenuStrip1
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        If Me.DataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
            Try
                ' Add the selection to the clipboard.
                Clipboard.SetDataObject(Me.DataGridView1.GetClipboardContent())
            Catch ex As System.Runtime.InteropServices.ExternalException
                MsgBox("Datagrid copy error" & ex.ToString, vbOKOnly)
            End Try
        End If
    End Sub

    Private Sub ShowAllEntryToolStrip_Click(sender As System.Object, e As System.EventArgs) Handles ShowAllEntryToolStrip.Click
        accdetails = True
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub btn_close_Click(sender As System.Object, e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.ColumnIndex = -1 = False And e.RowIndex = -1 = False And e.ColumnIndex = 1 Then
                DataGridView1.ClearSelection()
                DataGridView1.Rows(e.RowIndex).Selected = True
                accreceptdate = DataGridView1.Rows(e.RowIndex).Cells("Receipt_Date").Value
                accdepositdate = DataGridView1.Rows(e.RowIndex).Cells("Deposit_Date").Value
            End If
        End If
    End Sub

End Class