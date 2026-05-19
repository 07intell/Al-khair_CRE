<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Btn_device = New System.Windows.Forms.Button()
        Me.Btn_data = New System.Windows.Forms.Button()
        Me.Btn_sync = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Btn_Trfr_date = New System.Windows.Forms.Button()
        Me.Btn_get_date = New System.Windows.Forms.Button()
        Me.DGView1 = New System.Windows.Forms.DataGridView()
        Me.DepoDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MsName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeleteRecord = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.List_date = New System.Windows.Forms.ListBox()
        Me.LB_process = New System.Windows.Forms.ListBox()
        Me.LB_device = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'ProgressBar1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ProgressBar1, 14)
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBar1.Location = New System.Drawing.Point(4, 72)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1478, 2)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label5, 2)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(70, 20)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(179, 36)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Sync Mobile"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton6)
        Me.GroupBox1.Controls.Add(Me.RadioButton4)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton5)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(333, 124)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(15, 20, 3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.TableLayoutPanel1.SetRowSpan(Me.GroupBox1, 6)
        Me.GroupBox1.Size = New System.Drawing.Size(108, 434)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Checked = True
        Me.RadioButton6.ForeColor = System.Drawing.Color.White
        Me.RadioButton6.Location = New System.Drawing.Point(29, 350)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(54, 21)
        Me.RadioButton6.TabIndex = 22
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "ALL"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.ForeColor = System.Drawing.Color.White
        Me.RadioButton4.Location = New System.Drawing.Point(29, 235)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(66, 21)
        Me.RadioButton4.TabIndex = 22
        Me.RadioButton4.Text = "MTBL"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.ForeColor = System.Drawing.Color.White
        Me.RadioButton3.Location = New System.Drawing.Point(29, 177)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(64, 21)
        Me.RadioButton3.TabIndex = 22
        Me.RadioButton3.Text = "STBL"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.ForeColor = System.Drawing.Color.White
        Me.RadioButton5.Location = New System.Drawing.Point(29, 293)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(48, 21)
        Me.RadioButton5.TabIndex = 22
        Me.RadioButton5.Text = "ML"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.ForeColor = System.Drawing.Color.White
        Me.RadioButton2.Location = New System.Drawing.Point(29, 119)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(47, 21)
        Me.RadioButton2.TabIndex = 22
        Me.RadioButton2.Text = "DL"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.ForeColor = System.Drawing.Color.White
        Me.RadioButton1.Location = New System.Drawing.Point(29, 61)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(49, 21)
        Me.RadioButton1.TabIndex = 22
        Me.RadioButton1.Text = "DD"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox3, 7)
        Me.GroupBox3.Controls.Add(Me.Btn_device)
        Me.GroupBox3.Controls.Add(Me.Btn_data)
        Me.GroupBox3.Controls.Add(Me.Btn_sync)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(69, 584)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(825, 83)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        '
        'Btn_device
        '
        Me.Btn_device.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Btn_device.FlatAppearance.BorderSize = 0
        Me.Btn_device.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_device.ForeColor = System.Drawing.Color.White
        Me.Btn_device.Location = New System.Drawing.Point(64, 30)
        Me.Btn_device.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_device.Name = "Btn_device"
        Me.Btn_device.Size = New System.Drawing.Size(177, 28)
        Me.Btn_device.TabIndex = 4
        Me.Btn_device.Text = "Get Device list"
        Me.Btn_device.UseVisualStyleBackColor = False
        '
        'Btn_data
        '
        Me.Btn_data.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Btn_data.FlatAppearance.BorderSize = 0
        Me.Btn_data.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_data.ForeColor = System.Drawing.Color.White
        Me.Btn_data.Location = New System.Drawing.Point(517, 30)
        Me.Btn_data.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_data.Name = "Btn_data"
        Me.Btn_data.Size = New System.Drawing.Size(239, 28)
        Me.Btn_data.TabIndex = 4
        Me.Btn_data.Text = "Transfer Data to Database"
        Me.Btn_data.UseVisualStyleBackColor = False
        '
        'Btn_sync
        '
        Me.Btn_sync.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Btn_sync.FlatAppearance.BorderSize = 0
        Me.Btn_sync.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_sync.ForeColor = System.Drawing.Color.White
        Me.Btn_sync.Location = New System.Drawing.Point(284, 30)
        Me.Btn_sync.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_sync.Name = "Btn_sync"
        Me.Btn_sync.Size = New System.Drawing.Size(185, 28)
        Me.Btn_sync.TabIndex = 4
        Me.Btn_sync.Text = "Sync Device"
        Me.Btn_sync.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox2, 4)
        Me.GroupBox2.Controls.Add(Me.Btn_Trfr_date)
        Me.GroupBox2.Controls.Add(Me.Btn_get_date)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(917, 584)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(20, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(499, 83)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        '
        'Btn_Trfr_date
        '
        Me.Btn_Trfr_date.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Btn_Trfr_date.FlatAppearance.BorderSize = 0
        Me.Btn_Trfr_date.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Trfr_date.ForeColor = System.Drawing.Color.White
        Me.Btn_Trfr_date.Location = New System.Drawing.Point(276, 30)
        Me.Btn_Trfr_date.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Trfr_date.Name = "Btn_Trfr_date"
        Me.Btn_Trfr_date.Size = New System.Drawing.Size(185, 28)
        Me.Btn_Trfr_date.TabIndex = 4
        Me.Btn_Trfr_date.Text = "Transfer By Date"
        Me.Btn_Trfr_date.UseVisualStyleBackColor = False
        '
        'Btn_get_date
        '
        Me.Btn_get_date.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Btn_get_date.FlatAppearance.BorderSize = 0
        Me.Btn_get_date.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_get_date.ForeColor = System.Drawing.Color.White
        Me.Btn_get_date.Location = New System.Drawing.Point(46, 30)
        Me.Btn_get_date.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_get_date.Name = "Btn_get_date"
        Me.Btn_get_date.Size = New System.Drawing.Size(185, 28)
        Me.Btn_get_date.TabIndex = 4
        Me.Btn_get_date.Text = "Load By Date"
        Me.Btn_get_date.UseVisualStyleBackColor = False
        '
        'DGView1
        '
        Me.DGView1.AllowUserToAddRows = False
        Me.DGView1.AllowUserToDeleteRows = False
        Me.DGView1.AllowUserToResizeColumns = False
        Me.DGView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.DGView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.DGView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DepoDate, Me.MsName, Me.AccountNo, Me.Amount, Me.DeleteRecord})
        Me.TableLayoutPanel1.SetColumnSpan(Me.DGView1, 8)
        Me.DGView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGView1.Location = New System.Drawing.Point(460, 131)
        Me.DGView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DGView1.Name = "DGView1"
        Me.TableLayoutPanel1.SetRowSpan(Me.DGView1, 5)
        Me.DGView1.RowTemplate.Height = 24
        Me.DGView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGView1.Size = New System.Drawing.Size(956, 428)
        Me.DGView1.TabIndex = 21
        '
        'DepoDate
        '
        Me.DepoDate.HeaderText = "Deposit Date"
        Me.DepoDate.Name = "DepoDate"
        Me.DepoDate.ReadOnly = True
        Me.DepoDate.Width = 120
        '
        'MsName
        '
        Me.MsName.HeaderText = "Account Holder Name"
        Me.MsName.Name = "MsName"
        Me.MsName.ReadOnly = True
        Me.MsName.Width = 200
        '
        'AccountNo
        '
        Me.AccountNo.HeaderText = "Account Number"
        Me.AccountNo.Name = "AccountNo"
        Me.AccountNo.ReadOnly = True
        Me.AccountNo.Width = 180
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'DeleteRecord
        '
        Me.DeleteRecord.HeaderText = "Delete Record"
        Me.DeleteRecord.Name = "DeleteRecord"
        Me.DeleteRecord.ReadOnly = True
        Me.DeleteRecord.Width = 120
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(69, 223)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(161, 19)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Select Available Date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(69, 335)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 19)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Process"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(596, 104)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 19)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "..........."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(1286, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 19)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "..........."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(900, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 19)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "..........."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(1047, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(233, 19)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Remaining Balance to Transfer"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(460, 104)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 19)
        Me.Label18.TabIndex = 13
        Me.Label18.Text = "Collection Name"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label13, 2)
        Me.Label13.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(774, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 19)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Collection Total"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(69, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 19)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Select Device"
        '
        'List_date
        '
        Me.List_date.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.List_date.Dock = System.Windows.Forms.DockStyle.Fill
        Me.List_date.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List_date.FormattingEnabled = True
        Me.List_date.ItemHeight = 19
        Me.List_date.Location = New System.Drawing.Point(70, 248)
        Me.List_date.Margin = New System.Windows.Forms.Padding(4)
        Me.List_date.Name = "List_date"
        Me.List_date.Size = New System.Drawing.Size(244, 83)
        Me.List_date.TabIndex = 10
        '
        'LB_process
        '
        Me.LB_process.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.LB_process.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_process.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_process.FormattingEnabled = True
        Me.LB_process.ItemHeight = 19
        Me.LB_process.Location = New System.Drawing.Point(70, 362)
        Me.LB_process.Margin = New System.Windows.Forms.Padding(4)
        Me.LB_process.Name = "LB_process"
        Me.LB_process.Size = New System.Drawing.Size(244, 195)
        Me.LB_process.TabIndex = 11
        '
        'LB_device
        '
        Me.LB_device.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.LB_device.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_device.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_device.FormattingEnabled = True
        Me.LB_device.ItemHeight = 19
        Me.LB_device.Location = New System.Drawing.Point(70, 133)
        Me.LB_device.Margin = New System.Windows.Forms.Padding(4)
        Me.LB_device.Name = "LB_device"
        Me.LB_device.Size = New System.Drawing.Size(244, 86)
        Me.LB_device.TabIndex = 12
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 13
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 252.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 239.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.ProgressBar1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LB_device, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.List_date, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.LB_process, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.DGView1, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 8, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 9, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 10, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label19, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 8, 11)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 13
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 203.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1486, 754)
        Me.TableLayoutPanel1.TabIndex = 9
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1486, 754)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form4"
        Me.Text = "Mobile Manager"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DGView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_device As System.Windows.Forms.Button
    Friend WithEvents Btn_data As System.Windows.Forms.Button
    Friend WithEvents Btn_sync As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Trfr_date As System.Windows.Forms.Button
    Friend WithEvents Btn_get_date As System.Windows.Forms.Button
    Friend WithEvents DGView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DepoDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MsName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeleteRecord As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents List_date As System.Windows.Forms.ListBox
    Friend WithEvents LB_process As System.Windows.Forms.ListBox
    Friend WithEvents LB_device As System.Windows.Forms.ListBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
