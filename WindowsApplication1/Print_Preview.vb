Option Explicit On
Imports System.Drawing.Printing
Imports System.ComponentModel.AsyncOperationManager
Imports System.IO
Imports System.Threading

Public Class Print_Preview

    Private ImgList As New ImageList With {.ImageSize = New Size(24, 24)}
    Dim pkInstalledPrinters As String
    Private Const WM_VSCROLL = &H115
    Private Const SB_PAGEDOWN As Int32 = 3
    Private Const SB_PAGEUP As Int32 = 2
    Private Const SB_ENDSCROLL As Integer = 8
    Private Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" _
        (ByVal winHandle As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32
    Private Declare Function HideCaret Lib "user32" (ByVal hwnd As Integer) As Integer
    Private firstattempt As Boolean = True
    Dim page As Integer
    Shared randomgenerator As Random = New Random
    Dim maxPage As Integer
    Shared localslot As LocalDataStoreSlot

    Shared Sub New()
        randomgenerator = New Random
        localslot = Thread.AllocateDataSlot()
    End Sub

    Private Sub Print_Preview_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Thread.SetData(localslot, randomgenerator.Next(1, 200))

        Try

            'Combobox for Paper Size
            Dim pkSize As String
            Dim newpksize As String
            For i = 0 To PrintPreviewControl1.Document.PrinterSettings.PaperSizes.Count - 1
                pkSize = PrintPreviewControl1.Document.PrinterSettings.PaperSizes.Item(i).ToString
                newpksize = pkSize.Substring(1, pkSize.Length - 2)
                Dim substrings() As String = newpksize.Split(" "c)
                Dim newstr As String
                newstr = String.Format("    " & substrings(0) & " " & substrings(1), FontStyle.Bold)
                cb_page_size.Items.Add(newstr & Environment.NewLine & "    " & substrings(3) & " " & substrings(4), My.Resources.poster_06_512)
            Next
            For i = 0 To cb_page_size.Items.Count - 1
                If cb_page_size.Items(i).Text.Contains("A4") Then
                    cb_page_size.SelectedIndex = i
                End If
            Next


            'Combobox for Page Orientation
            cb_orientation.Items.Add("   Portrait", My.Resources.portrait)
            cb_orientation.Items.Add("   Landscape", My.Resources.lanscape)
            For i = 0 To cb_orientation.Items.Count - 1
                If cb_orientation.Items(i).Text.Contains("Portrait") Then
                    cb_orientation.SelectedIndex = i
                End If
            Next


            'Combobox for Duplex Print Setting
            cb_duplex.Items.Add("   Simplex" & Environment.NewLine & "   Print one sided", My.Resources.One_side)
            cb_duplex.Items.Add("   Duplex" & Environment.NewLine & "   Print Both side", My.Resources.Simplex)
            cb_duplex.Items.Add("   Horizontal Duplex" & Environment.NewLine & "   Print both side Horizontal", My.Resources.Port_duplex)
            cb_duplex.Items.Add("   Verticle Duplex" & Environment.NewLine & "   Print both side verticle", My.Resources.land_duplex)
            For i = 0 To cb_duplex.Items.Count - 1
                If cb_duplex.Items(i).Text.Contains("Print one sided") Then
                    cb_duplex.SelectedIndex = i
                End If
            Next

            'Combobox for Margin Setting
            cb_margin.Items.Add("    Normal" & Environment.NewLine & "   Top: 1""" & "      Bottom: 1""" & _
                                Environment.NewLine & "   Left: 1""" & "      Ringht: 1""", My.Resources.Normal)
            cb_margin.Items.Add("    Narrow" & Environment.NewLine & "   Top: .5""" & "      Bottom: .5""" & _
                                Environment.NewLine & "   Left: .5""" & "      Ringht: .5""", My.Resources.Narrow)
            cb_margin.Items.Add("    Moderate" & Environment.NewLine & "   Top: 1""" & "      Bottom: 1""" & _
                                Environment.NewLine & "   Left: .75""" & "      Ringht: .75""", My.Resources.Moderate)
            cb_margin.Items.Add("    Wide" & Environment.NewLine & "   Top: 1""" & "      Bottom: 1""" & _
                                Environment.NewLine & "   Left: 2""" & "      Ringht: 2""", My.Resources.Wide)
            cb_margin.Items.Add("Page Setup", My.Resources.Normal)
            For i = 0 To cb_margin.Items.Count - 1
                If cb_margin.Items(i).Text.Contains("Normal") Then
                    cb_margin.SelectedIndex = i
                End If
            Next

            'Number of copy
            nud_copy.Value = 1

            'Zoom control
            nud_zoom.Value = 75
            PrintPreviewControl1.Zoom = 0.75

            'Print number of pages
            cb_pages.Items.Add("   Print All Pages" & Environment.NewLine & "   The Whole thing", My.Resources.printallpages)
            cb_pages.Items.Add("   Print Current Page" & Environment.NewLine & "   Just This Page", My.Resources.printcurrentpage)
            cb_pages.Items.Add("   Custom Print" & Environment.NewLine & "   Type Specific Pages", My.Resources.printcustompage)
            cb_pages.SelectedIndex = 0

            btn_print.Focus()

            Timer1.Enabled = True

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        HideCaret(nud_copy.Controls(1).Handle)
        HideCaret(nud_zoom.Controls(1).Handle)
        HideCaret(nud_pages.Controls(1).Handle)
    End Sub

    Private Sub nud_copy_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nud_copy.KeyPress
        e.Handled = True
    End Sub

    Private Sub nud_zoom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nud_zoom.KeyPress
        e.Handled = True
    End Sub

    Private Sub btn_print_Click(sender As System.Object, e As System.EventArgs) Handles btn_print.Click
        printstart = True
        If CheckBox1.Checked = True Then
            SaveFileDialog1.AddExtension = True
            SaveFileDialog1.Filter = "PDF (*.pdf)|*.pdf|Jpeg Image (.jpeg)|*.jpg|Bitmap Image (*.bmp)|*.bmp|Gif Image (*.gif)|*.gif|All (*.*)|*.*"
            SaveFileDialog1.DefaultExt = "pdf"
            SaveFileDialog1.FileName = printtofilename
            SaveFileDialog1.ShowDialog()
            PrintPreviewControl1.Document.PrinterSettings.PrintFileName = SaveFileDialog1.FileName
        End If
        PrintPreviewControl1.Document.Print()
        printtofilename = ""
        SaveFileDialog1.Reset()
    End Sub

    Private Sub nud_copy_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nud_copy.ValueChanged
        Me.PrintPreviewControl1.Document.PrinterSettings.Copies = CInt(nud_copy.Value)
        HideCaret(nud_copy.Controls(1).Handle)
    End Sub

    Private Sub nud_zoom_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nud_zoom.ValueChanged
        Me.PrintPreviewControl1.Zoom = CInt(nud_zoom.Value) / 100
        HideCaret(nud_zoom.Controls(1).Handle)
    End Sub

    Private Sub tb_from_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tb_from.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            e.KeyChar = ""
            e.Handled = True
        End If
    End Sub

    Private Sub tb_from_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_from.TextChanged
        If tb_from.Text <> "" Then
            frompages = CInt(nud_pages.Text)
        Else
            frompages = 0
        End If
    End Sub

    Private Sub tb_to_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tb_to.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            e.KeyChar = ""
            e.Handled = True
        End If
    End Sub

    Private Sub tb_to_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_to.TextChanged
        If tb_to.Text <> "" Then
            topages = CInt(nud_pages.Text)
        ElseIf CInt(tb_from.Text) > CInt(tb_to.Text) Then
            tb_from.Text = tb_to.Text
        Else
            topages = pagescount
        End If
    End Sub

    Private Sub cb_printer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_printer.SelectedIndexChanged

        For j = 0 To PrinterSettings.InstalledPrinters.Count - 1
            Dim printname As String = PrinterSettings.InstalledPrinters.Item(j)
            If printname.Contains(cb_printer.SelectedItem.Text) Then
                PrintPreviewControl1.Document.PrinterSettings.PrinterName = Drawing.Printing.PrinterSettings.InstalledPrinters.Item(j)
                PrintPreviewControl1.Document.PrinterSettings.PrinterName = Drawing.Printing.PrinterSettings.InstalledPrinters.Item(j)
            End If
        Next

    End Sub

    Private Sub cb_pages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_pages.SelectedIndexChanged

        If cb_pages.SelectedItem.Text.Contains("Print All Pages") Then
            tb_from.Enabled = False
            tb_to.Enabled = False
        ElseIf cb_pages.SelectedItem.Text.Contains("Print Current Page") Then
            tb_from.Enabled = False
            tb_to.Enabled = False
        ElseIf cb_pages.SelectedItem.Text.Contains("Custom Print") Then
            tb_from.Enabled = True
            tb_to.Enabled = True
        End If

    End Sub

    Private Sub cb_duplex_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_duplex.SelectedIndexChanged

        If cb_duplex.SelectedItem.Text.Contains("Simplex") Then
            PrintPreviewControl1.Document.PrinterSettings.Duplex = Duplex.Simplex
        ElseIf cb_duplex.SelectedItem.Text.Contains("Duplex") Then
            PrintPreviewControl1.Document.PrinterSettings.Duplex = Duplex.Default
        ElseIf cb_duplex.SelectedItem.Text.Contains("Horizontal") Then
            PrintPreviewControl1.Document.PrinterSettings.Duplex = Duplex.Horizontal
        ElseIf cb_duplex.SelectedItem.Text.Contains("Verticle") Then
            PrintPreviewControl1.Document.PrinterSettings.Duplex = Duplex.Vertical
        End If
    End Sub

    Private Sub cb_orientation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_orientation.SelectedIndexChanged

        If cb_orientation.SelectedItem.Text.Contains("Portrait") Then
            PrintPreviewControl1.Document.DefaultPageSettings.Landscape = False
        ElseIf cb_orientation.SelectedItem.Text.Contains("Landscape") Then
            PrintPreviewControl1.Document.DefaultPageSettings.Landscape = True
        End If
        PrintPreviewControl1.InvalidatePreview()
        'PrintPreviewControl1.Refresh()
    End Sub

    Private Sub cb_page_size_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_page_size.SelectedIndexChanged

        PrintPreviewControl1.Document.DefaultPageSettings.PaperSize = PrintPreviewControl1.Document.PrinterSettings.PaperSizes.Item(cb_page_size.SelectedIndex)

        PrintPreviewControl1.InvalidatePreview()

    End Sub

    Private Sub cb_margin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_margin.SelectedIndexChanged

        If cb_margin.SelectedItem.Text.Contains("Normal") Then
            Dim margins As New Margins(100, 100, 100, 100)
            PrintPreviewControl1.Document.DefaultPageSettings.Margins = margins
        ElseIf cb_margin.SelectedItem.Text.Contains("Narrow") Then
            Dim margins As New Margins(50, 150, 50, 50)
            PrintPreviewControl1.Document.DefaultPageSettings.Margins = margins
        ElseIf cb_margin.SelectedItem.Text.Contains("Moderate") Then
            Dim margins As New Margins(75, 125, 100, 100)
            PrintPreviewControl1.Document.DefaultPageSettings.Margins = margins
        ElseIf cb_margin.SelectedItem.Text.Contains("Wide") Then
            Dim margins As New Margins(200, 200, 100, 100)
            PrintPreviewControl1.Document.DefaultPageSettings.Margins = margins
        End If

        PrintPreviewControl1.InvalidatePreview()

    End Sub

    Private Sub Print_Preview_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        PrintPreviewControl1.Dispose()
        releaseObject(nud_pages)
        releaseObject(nud_copy)
        releaseObject(nud_zoom)
        Me.Dispose()
    End Sub

    Private Sub PrintPreviewControl1_MouseWheel(sender As Object, e As MouseEventArgs) Handles PrintPreviewControl1.MouseWheel

        Dim dblZoom As Double
        'If control pressed then
        Try
            If Control.ModifierKeys = Keys.Control Then
                'Compute new Zoom position
                dblZoom = PrintPreviewControl1.Zoom
                dblZoom += e.Delta / 1200 * (1 + (dblZoom / 2))
                'Limit Zoom
                If dblZoom < 0.1 Then dblZoom = 0.1
                If dblZoom > 5 Then dblZoom = 5

                'Make integer value
                dblZoom = Fix(dblZoom * 10) / 10
                'Do zoom
                PrintPreviewControl1.Zoom = dblZoom '<--- WITH THIS FUNCTION WE CALL THE ZOOM CONTROL USING AN HIGH LEVEL PROGRAMMING

            Else
                'Compute scroll direction
                If e.Delta < 0 Then
                    If nud_pages.Value >= 0 And CInt(nud_pages.Value) < pagescount Then
                        nud_pages.Maximum = pagescount
                        nud_pages.Value += 1
                    End If
                Else
                    If nud_pages.Value > 1 And CInt(nud_pages.Value) <= pagescount Then
                        nud_pages.Value -= 1
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub nud_pages_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nud_pages.KeyPress
        e.Handled = True
    End Sub

    Private Sub nud_pages_ValueChanged(sender As Object, e As EventArgs) Handles nud_pages.ValueChanged
        HideCaret(nud_pages.Controls(1).Handle)
        Try
            If CInt(nud_pages.Value) < pagescount + 1 And CInt(nud_pages.Value) > 0 Then
                If pagescount = 2 And Me.PrintPreviewControl1.StartPage = 0 Then
                    Me.PrintPreviewControl1.StartPage = CInt(nud_pages.Value)
                Else
                    Me.PrintPreviewControl1.StartPage = CInt(nud_pages.Value - 1)
                End If
                PrintPreviewControl1.Refresh()
                nud_pages.Maximum = pagescount
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Print_Preview_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        'Combobox for Printer
        cb_printer.DropDownStyle = ComboBoxStyle.DropDownList
        cb_printer.DrawMode = DrawMode.OwnerDrawVariable
        For i As Integer = 0 To PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
            cb_printer.Items.Add("   " & pkInstalledPrinters, My.Resources.index)
        Next
        If (PrintPreviewControl1.Document.PrinterSettings.IsDefaultPrinter()) Then
            For i = 0 To cb_printer.Items.Count - 1
                If cb_printer.Items(i).Text.Contains(PrintPreviewControl1.Document.PrinterSettings.PrinterName) Then
                    cb_printer.SelectedIndex = i
                End If
            Next
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            PrintPreviewControl1.Document.PrinterSettings.PrintToFile = True
        ElseIf CheckBox1.Checked = False Then
            PrintPreviewControl1.Document.PrinterSettings.PrintToFile = False
        End If
    End Sub

End Class