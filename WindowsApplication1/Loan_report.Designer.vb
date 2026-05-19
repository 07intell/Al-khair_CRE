<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Loans_report
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPriviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DTPEdate = New System.Windows.Forms.DateTimePicker()
        Me.DTPSdate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.printprivew = New System.Windows.Forms.Button()
        Me.Btn_loan_report = New System.Windows.Forms.Button()
        Me.collector_id = New System.Windows.Forms.TextBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.Dgview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgview1
        '
        Me.Dgview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgview1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Dgview1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgview1.Location = New System.Drawing.Point(0, 97)
        Me.Dgview1.Margin = New System.Windows.Forms.Padding(2)
        Me.Dgview1.Name = "Dgview1"
        Me.Dgview1.RowTemplate.Height = 24
        Me.Dgview1.Size = New System.Drawing.Size(798, 412)
        Me.Dgview1.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.PrintPriviewToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(141, 48)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PrintPriviewToolStripMenuItem
        '
        Me.PrintPriviewToolStripMenuItem.Name = "PrintPriviewToolStripMenuItem"
        Me.PrintPriviewToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.PrintPriviewToolStripMenuItem.Text = "Print Priview"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Controls.Add(Me.DTPEdate)
        Me.Panel1.Controls.Add(Me.DTPSdate)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.printprivew)
        Me.Panel1.Controls.Add(Me.Btn_loan_report)
        Me.Panel1.Controls.Add(Me.collector_id)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(798, 97)
        Me.Panel1.TabIndex = 1
        '
        'DTPEdate
        '
        Me.DTPEdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPEdate.Location = New System.Drawing.Point(116, 63)
        Me.DTPEdate.Margin = New System.Windows.Forms.Padding(2)
        Me.DTPEdate.Name = "DTPEdate"
        Me.DTPEdate.Size = New System.Drawing.Size(85, 20)
        Me.DTPEdate.TabIndex = 16
        '
        'DTPSdate
        '
        Me.DTPSdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPSdate.Location = New System.Drawing.Point(15, 63)
        Me.DTPSdate.Margin = New System.Windows.Forms.Padding(2)
        Me.DTPSdate.Name = "DTPSdate"
        Me.DTPSdate.Size = New System.Drawing.Size(86, 20)
        Me.DTPSdate.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 18)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Loan Monthly Report"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(219, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Collector Loan ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(113, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "End Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Start Date"
        '
        'printprivew
        '
        Me.printprivew.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.printprivew.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.printprivew.Location = New System.Drawing.Point(503, 61)
        Me.printprivew.Name = "printprivew"
        Me.printprivew.Size = New System.Drawing.Size(157, 23)
        Me.printprivew.TabIndex = 2
        Me.printprivew.Text = "Print"
        Me.printprivew.UseVisualStyleBackColor = False
        '
        'Btn_loan_report
        '
        Me.Btn_loan_report.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Btn_loan_report.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_loan_report.Location = New System.Drawing.Point(324, 61)
        Me.Btn_loan_report.Name = "Btn_loan_report"
        Me.Btn_loan_report.Size = New System.Drawing.Size(161, 23)
        Me.Btn_loan_report.TabIndex = 1
        Me.Btn_loan_report.Text = "Genrate Monthly Loan Report"
        Me.Btn_loan_report.UseVisualStyleBackColor = False
        '
        'collector_id
        '
        Me.collector_id.Location = New System.Drawing.Point(218, 63)
        Me.collector_id.Name = "collector_id"
        Me.collector_id.Size = New System.Drawing.Size(89, 20)
        Me.collector_id.TabIndex = 0
        '
        'PrintDocument1
        '
        '
        'Loans_report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(798, 509)
        Me.Controls.Add(Me.Dgview1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Loans_report"
        Me.Text = "Loan_report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Dgview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgview1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Btn_loan_report As System.Windows.Forms.Button
    Friend WithEvents collector_id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents printprivew As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents DTPEdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPSdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPriviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
