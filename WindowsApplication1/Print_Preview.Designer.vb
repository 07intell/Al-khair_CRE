<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Print_Preview
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Print_Preview))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.nud_pages = New System.Windows.Forms.NumericUpDown()
        Me.nud_copy = New System.Windows.Forms.NumericUpDown()
        Me.tb_to = New System.Windows.Forms.TextBox()
        Me.tb_from = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_print = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.nud_zoom = New System.Windows.Forms.NumericUpDown()
        Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.cb_margin = New Alkhair_CRE.ImageComboBox()
        Me.cb_page_size = New Alkhair_CRE.ImageComboBox()
        Me.cb_orientation = New Alkhair_CRE.ImageComboBox()
        Me.cb_duplex = New Alkhair_CRE.ImageComboBox()
        Me.cb_pages = New Alkhair_CRE.ImageComboBox()
        Me.cb_printer = New Alkhair_CRE.ImageComboBox()
        Me.Panel1.SuspendLayout()
        CType(Me.nud_pages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_copy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.nud_zoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.nud_pages)
        Me.Panel1.Controls.Add(Me.nud_copy)
        Me.Panel1.Controls.Add(Me.cb_margin)
        Me.Panel1.Controls.Add(Me.cb_page_size)
        Me.Panel1.Controls.Add(Me.cb_orientation)
        Me.Panel1.Controls.Add(Me.cb_duplex)
        Me.Panel1.Controls.Add(Me.cb_pages)
        Me.Panel1.Controls.Add(Me.cb_printer)
        Me.Panel1.Controls.Add(Me.tb_to)
        Me.Panel1.Controls.Add(Me.tb_from)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btn_print)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(307, 615)
        Me.Panel1.TabIndex = 0
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(156, 154)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox1.Size = New System.Drawing.Size(78, 17)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Print to File"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'nud_pages
        '
        Me.nud_pages.Location = New System.Drawing.Point(236, 118)
        Me.nud_pages.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nud_pages.Name = "nud_pages"
        Me.nud_pages.Size = New System.Drawing.Size(45, 20)
        Me.nud_pages.TabIndex = 3
        Me.nud_pages.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nud_copy
        '
        Me.nud_copy.Location = New System.Drawing.Point(236, 54)
        Me.nud_copy.Name = "nud_copy"
        Me.nud_copy.Size = New System.Drawing.Size(45, 20)
        Me.nud_copy.TabIndex = 2
        '
        'tb_to
        '
        Me.tb_to.Enabled = False
        Me.tb_to.Location = New System.Drawing.Point(219, 330)
        Me.tb_to.Name = "tb_to"
        Me.tb_to.Size = New System.Drawing.Size(62, 20)
        Me.tb_to.TabIndex = 6
        '
        'tb_from
        '
        Me.tb_from.Enabled = False
        Me.tb_from.Location = New System.Drawing.Point(126, 330)
        Me.tb_from.Name = "tb_from"
        Me.tb_from.Size = New System.Drawing.Size(62, 20)
        Me.tb_from.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(197, 333)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "to"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 333)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "      Pages: -    From"
        '
        'btn_print
        '
        Me.btn_print.Image = CType(resources.GetObject("btn_print.Image"), System.Drawing.Image)
        Me.btn_print.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_print.Location = New System.Drawing.Point(36, 53)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(87, 87)
        Me.btn_print.TabIndex = 4
        Me.btn_print.Text = "Print"
        Me.btn_print.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 247)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Settings"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Printer"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(153, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Current Page :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(153, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Pages  :  "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Copies  :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Print Preview"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoScroll = True
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.nud_zoom, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PrintPreviewControl1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(307, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(618, 615)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'nud_zoom
        '
        Me.nud_zoom.Location = New System.Drawing.Point(70, 592)
        Me.nud_zoom.Name = "nud_zoom"
        Me.nud_zoom.Size = New System.Drawing.Size(58, 20)
        Me.nud_zoom.TabIndex = 11
        '
        'PrintPreviewControl1
        '
        Me.PrintPreviewControl1.AutoZoom = False
        Me.TableLayoutPanel1.SetColumnSpan(Me.PrintPreviewControl1, 2)
        Me.PrintPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrintPreviewControl1.Document = Me.PrintDocument1
        Me.PrintPreviewControl1.Location = New System.Drawing.Point(23, 23)
        Me.PrintPreviewControl1.Name = "PrintPreviewControl1"
        Me.PrintPreviewControl1.Size = New System.Drawing.Size(566, 563)
        Me.PrintPreviewControl1.TabIndex = 0
        Me.PrintPreviewControl1.Zoom = 0.35414884516680922R
        '
        'PrintDocument1
        '
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 589)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(5, 5, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(41, 26)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Zoom"
        '
        'Timer1
        '
        '
        'cb_margin
        '
        Me.cb_margin.FormattingEnabled = True
        Me.cb_margin.ItemHeight = 35
        Me.cb_margin.Location = New System.Drawing.Point(25, 535)
        Me.cb_margin.Name = "cb_margin"
        Me.cb_margin.SelectedItem = Nothing
        Me.cb_margin.Size = New System.Drawing.Size(256, 41)
        Me.cb_margin.TabIndex = 10
        '
        'cb_page_size
        '
        Me.cb_page_size.FormattingEnabled = True
        Me.cb_page_size.ItemHeight = 35
        Me.cb_page_size.Location = New System.Drawing.Point(25, 477)
        Me.cb_page_size.Name = "cb_page_size"
        Me.cb_page_size.SelectedItem = Nothing
        Me.cb_page_size.Size = New System.Drawing.Size(256, 41)
        Me.cb_page_size.TabIndex = 9
        '
        'cb_orientation
        '
        Me.cb_orientation.FormattingEnabled = True
        Me.cb_orientation.ItemHeight = 35
        Me.cb_orientation.Location = New System.Drawing.Point(25, 421)
        Me.cb_orientation.Name = "cb_orientation"
        Me.cb_orientation.SelectedItem = Nothing
        Me.cb_orientation.Size = New System.Drawing.Size(256, 41)
        Me.cb_orientation.TabIndex = 8
        '
        'cb_duplex
        '
        Me.cb_duplex.FormattingEnabled = True
        Me.cb_duplex.ItemHeight = 35
        Me.cb_duplex.Location = New System.Drawing.Point(25, 365)
        Me.cb_duplex.Name = "cb_duplex"
        Me.cb_duplex.SelectedItem = Nothing
        Me.cb_duplex.Size = New System.Drawing.Size(256, 41)
        Me.cb_duplex.TabIndex = 7
        '
        'cb_pages
        '
        Me.cb_pages.FormattingEnabled = True
        Me.cb_pages.ItemHeight = 35
        Me.cb_pages.Location = New System.Drawing.Point(25, 273)
        Me.cb_pages.Name = "cb_pages"
        Me.cb_pages.SelectedItem = Nothing
        Me.cb_pages.Size = New System.Drawing.Size(256, 41)
        Me.cb_pages.TabIndex = 4
        '
        'cb_printer
        '
        Me.cb_printer.FormattingEnabled = True
        Me.cb_printer.ItemHeight = 35
        Me.cb_printer.Location = New System.Drawing.Point(25, 194)
        Me.cb_printer.Name = "cb_printer"
        Me.cb_printer.SelectedItem = Nothing
        Me.cb_printer.Size = New System.Drawing.Size(256, 41)
        Me.cb_printer.TabIndex = 1
        '
        'Print_Preview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(925, 615)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Print_Preview"
        Me.Text = "Print Preview"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nud_pages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_copy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.nud_zoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tb_from As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_print As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PrintPreviewControl1 As System.Windows.Forms.PrintPreviewControl
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_to As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cb_printer As Alkhair_CRE.ImageComboBox
    Friend WithEvents cb_margin As Alkhair_CRE.ImageComboBox
    Friend WithEvents cb_page_size As Alkhair_CRE.ImageComboBox
    Friend WithEvents cb_orientation As Alkhair_CRE.ImageComboBox
    Friend WithEvents cb_duplex As Alkhair_CRE.ImageComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cb_pages As Alkhair_CRE.ImageComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nud_copy As System.Windows.Forms.NumericUpDown
    Friend WithEvents nud_zoom As System.Windows.Forms.NumericUpDown
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents nud_pages As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
