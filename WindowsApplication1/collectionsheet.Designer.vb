<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class collectionsheet
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
        Me.Dgview1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.printprivew = New System.Windows.Forms.Button()
        Me.Btn_collection_sheet = New System.Windows.Forms.Button()
        Me.collector_id = New System.Windows.Forms.TextBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPriviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Dgview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgview1
        '
        Me.Dgview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgview1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgview1.Location = New System.Drawing.Point(0, 70)
        Me.Dgview1.Margin = New System.Windows.Forms.Padding(2)
        Me.Dgview1.Name = "Dgview1"
        Me.Dgview1.RowTemplate.Height = 24
        Me.Dgview1.Size = New System.Drawing.Size(823, 384)
        Me.Dgview1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.printprivew)
        Me.Panel1.Controls.Add(Me.Btn_collection_sheet)
        Me.Panel1.Controls.Add(Me.collector_id)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(823, 70)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 18)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Daily Collection Sheet"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Collector Loan ID"
        '
        'printprivew
        '
        Me.printprivew.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.printprivew.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.printprivew.Location = New System.Drawing.Point(426, 38)
        Me.printprivew.Name = "printprivew"
        Me.printprivew.Size = New System.Drawing.Size(166, 23)
        Me.printprivew.TabIndex = 2
        Me.printprivew.Text = "Print"
        Me.printprivew.UseVisualStyleBackColor = False
        '
        'Btn_collection_sheet
        '
        Me.Btn_collection_sheet.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Btn_collection_sheet.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_collection_sheet.Location = New System.Drawing.Point(243, 38)
        Me.Btn_collection_sheet.Name = "Btn_collection_sheet"
        Me.Btn_collection_sheet.Size = New System.Drawing.Size(161, 23)
        Me.Btn_collection_sheet.TabIndex = 1
        Me.Btn_collection_sheet.Text = "Genrate Sheet Account list"
        Me.Btn_collection_sheet.UseVisualStyleBackColor = False
        '
        'collector_id
        '
        Me.collector_id.Location = New System.Drawing.Point(129, 40)
        Me.collector_id.Name = "collector_id"
        Me.collector_id.Size = New System.Drawing.Size(89, 20)
        Me.collector_id.TabIndex = 0
        '
        'PrintDocument1
        '
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.PrintPriviewToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(144, 48)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PrintPriviewToolStripMenuItem
        '
        Me.PrintPriviewToolStripMenuItem.Name = "PrintPriviewToolStripMenuItem"
        Me.PrintPriviewToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.PrintPriviewToolStripMenuItem.Text = "Print Preview"
        '
        'collectionsheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 454)
        Me.Controls.Add(Me.Dgview1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "collectionsheet"
        Me.Text = "Collection Sheet Print"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Dgview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgview1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents printprivew As System.Windows.Forms.Button
    Friend WithEvents Btn_collection_sheet As System.Windows.Forms.Button
    Friend WithEvents collector_id As System.Windows.Forms.TextBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPriviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
