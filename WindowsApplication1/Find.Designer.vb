<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Find
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
        Me.Btnsearch = New System.Windows.Forms.Button()
        Me.txtfind = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Btnsearch
        '
        Me.Btnsearch.BackColor = System.Drawing.Color.White
        Me.Btnsearch.Location = New System.Drawing.Point(183, 10)
        Me.Btnsearch.Name = "Btnsearch"
        Me.Btnsearch.Size = New System.Drawing.Size(46, 21)
        Me.Btnsearch.TabIndex = 2
        Me.Btnsearch.Text = "Find"
        Me.Btnsearch.UseVisualStyleBackColor = False
        '
        'txtfind
        '
        Me.txtfind.Location = New System.Drawing.Point(79, 10)
        Me.txtfind.Name = "txtfind"
        Me.txtfind.Size = New System.Drawing.Size(100, 20)
        Me.txtfind.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(14, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Account No"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(14, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "...."
        '
        'btn_close
        '
        Me.btn_close.BackColor = System.Drawing.Color.White
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_close.Location = New System.Drawing.Point(247, 0)
        Me.btn_close.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(17, 19)
        Me.btn_close.TabIndex = 3
        Me.btn_close.Text = "X"
        Me.btn_close.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btn_close.UseVisualStyleBackColor = False
        '
        'Find
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(264, 53)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.Btnsearch)
        Me.Controls.Add(Me.txtfind)
        Me.Controls.Add(Me.Label12)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Find"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Find"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btnsearch As System.Windows.Forms.Button
    Friend WithEvents txtfind As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_close As System.Windows.Forms.Button
End Class
