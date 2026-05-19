<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewrectbydate
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.getdate = New System.Windows.Forms.Button()
        Me.collector_id = New System.Windows.Forms.TextBox()
        Me.Dateofentry = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter Collector ID"
        '
        'getdate
        '
        Me.getdate.BackColor = System.Drawing.Color.White
        Me.getdate.ForeColor = System.Drawing.Color.Black
        Me.getdate.Location = New System.Drawing.Point(238, 18)
        Me.getdate.Name = "getdate"
        Me.getdate.Size = New System.Drawing.Size(75, 50)
        Me.getdate.TabIndex = 3
        Me.getdate.Text = "Get Data"
        Me.getdate.UseVisualStyleBackColor = False
        '
        'collector_id
        '
        Me.collector_id.Location = New System.Drawing.Point(112, 19)
        Me.collector_id.Name = "collector_id"
        Me.collector_id.Size = New System.Drawing.Size(105, 20)
        Me.collector_id.TabIndex = 1
        '
        'Dateofentry
        '
        Me.Dateofentry.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dateofentry.Location = New System.Drawing.Point(112, 48)
        Me.Dateofentry.Name = "Dateofentry"
        Me.Dateofentry.Size = New System.Drawing.Size(105, 20)
        Me.Dateofentry.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Date of Entry"
        '
        'btn_close
        '
        Me.btn_close.BackColor = System.Drawing.Color.White
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_close.ForeColor = System.Drawing.Color.Black
        Me.btn_close.Location = New System.Drawing.Point(332, 0)
        Me.btn_close.Margin = New System.Windows.Forms.Padding(1)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(17, 19)
        Me.btn_close.TabIndex = 6
        Me.btn_close.Text = "X"
        Me.btn_close.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btn_close.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Dateofentry)
        Me.GroupBox1.Controls.Add(Me.collector_id)
        Me.GroupBox1.Controls.Add(Me.getdate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(11, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 78)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View Receipt by Entry Date"
        '
        'viewrectbydate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(349, 105)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.GroupBox1)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "viewrectbydate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "View Receipt by Entry Date"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents getdate As System.Windows.Forms.Button
    Friend WithEvents collector_id As System.Windows.Forms.TextBox
    Friend WithEvents Dateofentry As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
