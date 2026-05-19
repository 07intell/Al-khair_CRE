<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.collector_id = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Dtprectdate = New System.Windows.Forms.DateTimePicker()
        Me.Getdata = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Collname = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Colltype = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Todaydeposit = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Totaldeposit = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Balanceamount = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Branch_Code = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dateofsoftware = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.labelentry = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.change_rect_date = New System.Windows.Forms.Button()
        Me.viewreciept = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Btn_loan_report = New System.Windows.Forms.Button()
        Me.Gurantor_history = New System.Windows.Forms.Button()
        Me.Create_bfs_ac_list = New System.Windows.Forms.Button()
        Me.Edit = New System.Windows.Forms.Button()
        Me.btn_find = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Dgview0 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MultiRowSelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.progress = New System.Windows.Forms.Label()
        Me.savelist = New System.Windows.Forms.Button()
        Me.btn_manual = New System.Windows.Forms.Button()
        Me.Btn_exit = New System.Windows.Forms.Button()
        Me.DGviewcoll = New System.Windows.Forms.DataGridView()
        Me.Coll_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Coll_id_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Coll_id = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.balance_amount = New System.Windows.Forms.Button()
        Me.todays_deposit = New System.Windows.Forms.Button()
        Me.Collectoraclist = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.server_setting = New System.Windows.Forms.Panel()
        Me.serversetting = New System.Windows.Forms.Button()
        Me.btn_collectionsheet = New System.Windows.Forms.Button()
        Me.Reload = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Dgview0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.DGviewcoll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.server_setting.SuspendLayout()
        Me.SuspendLayout()
        '
        'collector_id
        '
        Me.collector_id.Location = New System.Drawing.Point(607, 67)
        Me.collector_id.Name = "collector_id"
        Me.collector_id.Size = New System.Drawing.Size(87, 20)
        Me.collector_id.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 29)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Daily Receipt Entry"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(604, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Enter Collector ID"
        '
        'Dtprectdate
        '
        Me.Dtprectdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtprectdate.Location = New System.Drawing.Point(711, 67)
        Me.Dtprectdate.Name = "Dtprectdate"
        Me.Dtprectdate.Size = New System.Drawing.Size(86, 20)
        Me.Dtprectdate.TabIndex = 5
        '
        'Getdata
        '
        Me.Getdata.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Getdata.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Getdata.Location = New System.Drawing.Point(813, 47)
        Me.Getdata.Name = "Getdata"
        Me.Getdata.Size = New System.Drawing.Size(98, 40)
        Me.Getdata.TabIndex = 6
        Me.Getdata.Text = "Get Data"
        Me.Getdata.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Collector Name"
        '
        'Collname
        '
        Me.Collname.AutoSize = True
        Me.Collname.Location = New System.Drawing.Point(8, 70)
        Me.Collname.Name = "Collname"
        Me.Collname.Size = New System.Drawing.Size(25, 13)
        Me.Collname.TabIndex = 4
        Me.Collname.Text = "......"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(147, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Collection Type"
        '
        'Colltype
        '
        Me.Colltype.AutoSize = True
        Me.Colltype.Location = New System.Drawing.Point(147, 70)
        Me.Colltype.Name = "Colltype"
        Me.Colltype.Size = New System.Drawing.Size(25, 13)
        Me.Colltype.TabIndex = 4
        Me.Colltype.Text = "......"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(336, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Today's Amount"
        '
        'Todaydeposit
        '
        Me.Todaydeposit.AutoSize = True
        Me.Todaydeposit.Location = New System.Drawing.Point(336, 70)
        Me.Todaydeposit.Name = "Todaydeposit"
        Me.Todaydeposit.Size = New System.Drawing.Size(13, 13)
        Me.Todaydeposit.TabIndex = 4
        Me.Todaydeposit.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(250, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Total Amount"
        '
        'Totaldeposit
        '
        Me.Totaldeposit.AutoSize = True
        Me.Totaldeposit.Location = New System.Drawing.Point(250, 70)
        Me.Totaldeposit.Name = "Totaldeposit"
        Me.Totaldeposit.Size = New System.Drawing.Size(13, 13)
        Me.Totaldeposit.TabIndex = 4
        Me.Totaldeposit.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(435, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Balance Amount"
        '
        'Balanceamount
        '
        Me.Balanceamount.AutoSize = True
        Me.Balanceamount.Location = New System.Drawing.Point(435, 70)
        Me.Balanceamount.Name = "Balanceamount"
        Me.Balanceamount.Size = New System.Drawing.Size(13, 13)
        Me.Balanceamount.TabIndex = 4
        Me.Balanceamount.Text = "0"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.Branch_Code)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.dateofsoftware)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.labelentry)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Balanceamount)
        Me.Panel1.Controls.Add(Me.collector_id)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Totaldeposit)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Dtprectdate)
        Me.Panel1.Controls.Add(Me.Todaydeposit)
        Me.Panel1.Controls.Add(Me.Getdata)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Colltype)
        Me.Panel1.Controls.Add(Me.Collname)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(31, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1039, 100)
        Me.Panel1.TabIndex = 8
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(814, 27)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(105, 17)
        Me.CheckBox1.TabIndex = 23
        Me.CheckBox1.Text = "Online Collection"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(-2, 96)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1039, 1)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 15
        '
        'Branch_Code
        '
        Me.Branch_Code.AutoSize = True
        Me.Branch_Code.ForeColor = System.Drawing.Color.Black
        Me.Branch_Code.Location = New System.Drawing.Point(1012, 7)
        Me.Branch_Code.Name = "Branch_Code"
        Me.Branch_Code.Size = New System.Drawing.Size(16, 13)
        Me.Branch_Code.TabIndex = 21
        Me.Branch_Code.Text = "..."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(937, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Branch Code -"
        '
        'dateofsoftware
        '
        Me.dateofsoftware.AutoSize = True
        Me.dateofsoftware.ForeColor = System.Drawing.Color.Black
        Me.dateofsoftware.Location = New System.Drawing.Point(846, 8)
        Me.dateofsoftware.Name = "dateofsoftware"
        Me.dateofsoftware.Size = New System.Drawing.Size(16, 13)
        Me.dateofsoftware.TabIndex = 20
        Me.dateofsoftware.Text = "..."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(709, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 13)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Entry Date "
        '
        'labelentry
        '
        Me.labelentry.BackColor = System.Drawing.Color.White
        Me.labelentry.Location = New System.Drawing.Point(711, 25)
        Me.labelentry.Name = "labelentry"
        Me.labelentry.ReadOnly = True
        Me.labelentry.Size = New System.Drawing.Size(86, 20)
        Me.labelentry.TabIndex = 19
        Me.labelentry.Text = "Entry Date "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(810, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Date -"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(709, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Receipt Date"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(918, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(100, 65)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(13, 37)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(78, 17)
        Me.RadioButton3.TabIndex = 9
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Multi Sheet"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(13, 15)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(85, 17)
        Me.RadioButton1.TabIndex = 9
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Single Sheet"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(533, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(533, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sheet Total"
        '
        'change_rect_date
        '
        Me.change_rect_date.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.change_rect_date.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.change_rect_date.Location = New System.Drawing.Point(493, 0)
        Me.change_rect_date.Name = "change_rect_date"
        Me.change_rect_date.Size = New System.Drawing.Size(116, 20)
        Me.change_rect_date.TabIndex = 12
        Me.change_rect_date.Text = "Change Reciept Date"
        Me.change_rect_date.UseVisualStyleBackColor = False
        Me.change_rect_date.Visible = False
        '
        'viewreciept
        '
        Me.viewreciept.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.viewreciept.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.viewreciept.Location = New System.Drawing.Point(149, 0)
        Me.viewreciept.Name = "viewreciept"
        Me.viewreciept.Size = New System.Drawing.Size(78, 20)
        Me.viewreciept.TabIndex = 12
        Me.viewreciept.Tag = "View Reciept By Entry Date"
        Me.viewreciept.Text = "View Reciept"
        Me.viewreciept.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(398, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 20)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Online Data Import"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Btn_loan_report
        '
        Me.Btn_loan_report.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Btn_loan_report.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_loan_report.Location = New System.Drawing.Point(320, 0)
        Me.Btn_loan_report.Name = "Btn_loan_report"
        Me.Btn_loan_report.Size = New System.Drawing.Size(78, 20)
        Me.Btn_loan_report.TabIndex = 12
        Me.Btn_loan_report.Tag = "Generate Monthly Loan Report"
        Me.Btn_loan_report.Text = "Loan Report"
        Me.Btn_loan_report.UseVisualStyleBackColor = False
        '
        'Gurantor_history
        '
        Me.Gurantor_history.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Gurantor_history.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Gurantor_history.Location = New System.Drawing.Point(609, 0)
        Me.Gurantor_history.Name = "Gurantor_history"
        Me.Gurantor_history.Size = New System.Drawing.Size(92, 20)
        Me.Gurantor_history.TabIndex = 12
        Me.Gurantor_history.Text = "Gurantor History"
        Me.Gurantor_history.UseVisualStyleBackColor = False
        Me.Gurantor_history.Visible = False
        '
        'Create_bfs_ac_list
        '
        Me.Create_bfs_ac_list.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Create_bfs_ac_list.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Create_bfs_ac_list.Location = New System.Drawing.Point(0, 0)
        Me.Create_bfs_ac_list.Name = "Create_bfs_ac_list"
        Me.Create_bfs_ac_list.Size = New System.Drawing.Size(74, 20)
        Me.Create_bfs_ac_list.TabIndex = 12
        Me.Create_bfs_ac_list.Tag = "Create BF's Account List"
        Me.Create_bfs_ac_list.Text = "Account List"
        Me.Create_bfs_ac_list.UseVisualStyleBackColor = False
        '
        'Edit
        '
        Me.Edit.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Edit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Edit.Location = New System.Drawing.Point(74, 0)
        Me.Edit.Name = "Edit"
        Me.Edit.Size = New System.Drawing.Size(75, 20)
        Me.Edit.TabIndex = 12
        Me.Edit.Tag = "Edit Previous Day Receipt"
        Me.Edit.Text = "Edit Receipt"
        Me.Edit.UseVisualStyleBackColor = False
        '
        'btn_find
        '
        Me.btn_find.BackColor = System.Drawing.Color.Transparent
        Me.btn_find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_find.FlatAppearance.BorderSize = 0
        Me.btn_find.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_find.Image = CType(resources.GetObject("btn_find.Image"), System.Drawing.Image)
        Me.btn_find.Location = New System.Drawing.Point(954, 0)
        Me.btn_find.Name = "btn_find"
        Me.btn_find.Size = New System.Drawing.Size(31, 20)
        Me.btn_find.TabIndex = 24
        Me.btn_find.Tag = "Find"
        Me.btn_find.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(339, 137)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TableLayoutPanel1.SetRowSpan(Me.TabControl1, 2)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(731, 467)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Dgview0)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(723, 441)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Sheet1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Dgview0
        '
        Me.Dgview0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgview0.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Dgview0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgview0.Location = New System.Drawing.Point(3, 3)
        Me.Dgview0.MultiSelect = False
        Me.Dgview0.Name = "Dgview0"
        Me.Dgview0.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgview0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgview0.Size = New System.Drawing.Size(717, 435)
        Me.Dgview0.TabIndex = 12
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.MultiRowSelectToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(163, 70)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "Print Preview"
        '
        'MultiRowSelectToolStripMenuItem
        '
        Me.MultiRowSelectToolStripMenuItem.Name = "MultiRowSelectToolStripMenuItem"
        Me.MultiRowSelectToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.MultiRowSelectToolStripMenuItem.Text = "Multi Row Select"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.progress)
        Me.Panel7.Controls.Add(Me.savelist)
        Me.Panel7.Controls.Add(Me.btn_manual)
        Me.Panel7.Controls.Add(Me.Btn_exit)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(339, 610)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(731, 24)
        Me.Panel7.TabIndex = 13
        '
        'progress
        '
        Me.progress.AutoSize = True
        Me.progress.BackColor = System.Drawing.Color.Transparent
        Me.progress.ForeColor = System.Drawing.Color.White
        Me.progress.Location = New System.Drawing.Point(6, 5)
        Me.progress.Name = "progress"
        Me.progress.Size = New System.Drawing.Size(46, 13)
        Me.progress.TabIndex = 14
        Me.progress.Text = "............."
        '
        'savelist
        '
        Me.savelist.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.savelist.Enabled = False
        Me.savelist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.savelist.Location = New System.Drawing.Point(526, 1)
        Me.savelist.Name = "savelist"
        Me.savelist.Size = New System.Drawing.Size(143, 20)
        Me.savelist.TabIndex = 12
        Me.savelist.Text = "Save Collectors Ac Order"
        Me.savelist.UseVisualStyleBackColor = False
        '
        'btn_manual
        '
        Me.btn_manual.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_manual.Enabled = False
        Me.btn_manual.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_manual.Location = New System.Drawing.Point(407, 1)
        Me.btn_manual.Name = "btn_manual"
        Me.btn_manual.Size = New System.Drawing.Size(118, 20)
        Me.btn_manual.TabIndex = 12
        Me.btn_manual.Text = "Manual Numbering"
        Me.btn_manual.UseVisualStyleBackColor = False
        '
        'Btn_exit
        '
        Me.Btn_exit.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_exit.Location = New System.Drawing.Point(670, 1)
        Me.Btn_exit.Name = "Btn_exit"
        Me.Btn_exit.Size = New System.Drawing.Size(59, 20)
        Me.Btn_exit.TabIndex = 12
        Me.Btn_exit.Text = "Exit"
        Me.Btn_exit.UseVisualStyleBackColor = False
        '
        'DGviewcoll
        '
        Me.DGviewcoll.AllowUserToAddRows = False
        Me.DGviewcoll.AllowUserToDeleteRows = False
        Me.DGviewcoll.AllowUserToResizeRows = False
        Me.DGviewcoll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGviewcoll.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGviewcoll.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DGviewcoll.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGviewcoll.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGviewcoll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGviewcoll.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Coll_Name, Me.Coll_id_type, Me.Coll_id})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGviewcoll.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGviewcoll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGviewcoll.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGviewcoll.Location = New System.Drawing.Point(31, 188)
        Me.DGviewcoll.MultiSelect = False
        Me.DGviewcoll.Name = "DGviewcoll"
        Me.DGviewcoll.RowHeadersWidth = 10
        Me.DGviewcoll.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.TableLayoutPanel1.SetRowSpan(Me.DGviewcoll, 2)
        Me.DGviewcoll.Size = New System.Drawing.Size(302, 446)
        Me.DGviewcoll.TabIndex = 0
        '
        'Coll_Name
        '
        Me.Coll_Name.HeaderText = "Collectors Name"
        Me.Coll_Name.Name = "Coll_Name"
        Me.Coll_Name.ReadOnly = True
        Me.Coll_Name.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Coll_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Coll_id_type
        '
        Me.Coll_id_type.HeaderText = "Collector ID"
        Me.Coll_id_type.Name = "Coll_id_type"
        Me.Coll_id_type.ReadOnly = True
        Me.Coll_id_type.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Coll_id_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Coll_id
        '
        Me.Coll_id.HeaderText = "Collector ID"
        Me.Coll_id.Name = "Coll_id"
        Me.Coll_id.ReadOnly = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.balance_amount)
        Me.Panel6.Controls.Add(Me.todays_deposit)
        Me.Panel6.Controls.Add(Me.Collectoraclist)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(31, 137)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(302, 45)
        Me.Panel6.TabIndex = 1
        '
        'balance_amount
        '
        Me.balance_amount.BackColor = System.Drawing.SystemColors.ControlLight
        Me.balance_amount.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.balance_amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.balance_amount.Location = New System.Drawing.Point(2, 22)
        Me.balance_amount.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.balance_amount.Name = "balance_amount"
        Me.balance_amount.Size = New System.Drawing.Size(80, 20)
        Me.balance_amount.TabIndex = 13
        Me.balance_amount.Text = "Balance Amount"
        Me.balance_amount.UseVisualStyleBackColor = False
        '
        'todays_deposit
        '
        Me.todays_deposit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.todays_deposit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.todays_deposit.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.todays_deposit.Location = New System.Drawing.Point(2, 1)
        Me.todays_deposit.Name = "todays_deposit"
        Me.todays_deposit.Size = New System.Drawing.Size(80, 20)
        Me.todays_deposit.TabIndex = 12
        Me.todays_deposit.Text = "Today's Deposit"
        Me.todays_deposit.UseVisualStyleBackColor = False
        '
        'Collectoraclist
        '
        Me.Collectoraclist.AutoSize = True
        Me.Collectoraclist.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Collectoraclist.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Collectoraclist.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Collectoraclist.Location = New System.Drawing.Point(95, 10)
        Me.Collectoraclist.Name = "Collectoraclist"
        Me.Collectoraclist.Size = New System.Drawing.Size(194, 20)
        Me.Collectoraclist.TabIndex = 0
        Me.Collectoraclist.Text = "Collectors Account List"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.555555!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 308.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 737.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.38889!))
        Me.TableLayoutPanel1.Controls.Add(Me.DGviewcoll, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.server_setting, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.77311!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1107, 637)
        Me.TableLayoutPanel1.TabIndex = 20
        '
        'server_setting
        '
        Me.server_setting.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.server_setting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.server_setting, 2)
        Me.server_setting.Controls.Add(Me.serversetting)
        Me.server_setting.Controls.Add(Me.Create_bfs_ac_list)
        Me.server_setting.Controls.Add(Me.Edit)
        Me.server_setting.Controls.Add(Me.btn_collectionsheet)
        Me.server_setting.Controls.Add(Me.viewreciept)
        Me.server_setting.Controls.Add(Me.Gurantor_history)
        Me.server_setting.Controls.Add(Me.Btn_loan_report)
        Me.server_setting.Controls.Add(Me.btn_find)
        Me.server_setting.Controls.Add(Me.Reload)
        Me.server_setting.Controls.Add(Me.Button1)
        Me.server_setting.Controls.Add(Me.change_rect_date)
        Me.server_setting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.server_setting.Location = New System.Drawing.Point(31, 3)
        Me.server_setting.Name = "server_setting"
        Me.server_setting.Size = New System.Drawing.Size(1039, 22)
        Me.server_setting.TabIndex = 18
        '
        'serversetting
        '
        Me.serversetting.BackgroundImage = Global.Alkhair_CRE.My.Resources.Resources.Setting_icon
        Me.serversetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.serversetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.serversetting.FlatAppearance.BorderSize = 0
        Me.serversetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.serversetting.Location = New System.Drawing.Point(1010, 0)
        Me.serversetting.Name = "serversetting"
        Me.serversetting.Size = New System.Drawing.Size(19, 20)
        Me.serversetting.TabIndex = 22
        Me.serversetting.UseVisualStyleBackColor = True
        '
        'btn_collectionsheet
        '
        Me.btn_collectionsheet.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_collectionsheet.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_collectionsheet.Location = New System.Drawing.Point(227, 0)
        Me.btn_collectionsheet.Name = "btn_collectionsheet"
        Me.btn_collectionsheet.Size = New System.Drawing.Size(93, 20)
        Me.btn_collectionsheet.TabIndex = 12
        Me.btn_collectionsheet.Tag = "Generate and collection sheet"
        Me.btn_collectionsheet.Text = "Collection Sheet"
        Me.btn_collectionsheet.UseVisualStyleBackColor = False
        '
        'Reload
        '
        Me.Reload.BackColor = System.Drawing.Color.Transparent
        Me.Reload.BackgroundImage = CType(resources.GetObject("Reload.BackgroundImage"), System.Drawing.Image)
        Me.Reload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Reload.Enabled = False
        Me.Reload.FlatAppearance.BorderSize = 0
        Me.Reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Reload.Location = New System.Drawing.Point(987, 0)
        Me.Reload.Name = "Reload"
        Me.Reload.Size = New System.Drawing.Size(19, 20)
        Me.Reload.TabIndex = 10
        Me.Reload.Tag = "Reload"
        Me.Reload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Reload.UseVisualStyleBackColor = False
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'BackgroundWorker2
        '
        Me.BackgroundWorker2.WorkerReportsProgress = True
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1107, 637)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "Form1"
        Me.Text = "Alkhair Cooperative Credit Society Ltd"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Dgview0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.DGviewcoll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.server_setting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents collector_id As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Dtprectdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Getdata As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Collname As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Colltype As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Todaydeposit As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Totaldeposit As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Balanceamount As System.Windows.Forms.Label
    'Friend WithEvents DGview As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents DGviewcoll As System.Windows.Forms.DataGridView
    Friend WithEvents Edit As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Collectoraclist As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Coll_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Coll_id_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Coll_id As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents balance_amount As System.Windows.Forms.Button
    Friend WithEvents todays_deposit As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Btn_exit As System.Windows.Forms.Button
    Friend WithEvents server_setting As System.Windows.Forms.Panel
    Friend WithEvents viewreciept As System.Windows.Forms.Button
    Friend WithEvents progress As System.Windows.Forms.Label
    Friend WithEvents labelentry As System.Windows.Forms.TextBox
    Friend WithEvents Branch_Code As System.Windows.Forms.Label
    Friend WithEvents dateofsoftware As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Dgview0 As System.Windows.Forms.DataGridView
    Friend WithEvents Create_bfs_ac_list As System.Windows.Forms.Button
    Friend WithEvents change_rect_date As System.Windows.Forms.Button
    Friend WithEvents btn_find As System.Windows.Forms.Button
    Friend WithEvents savelist As System.Windows.Forms.Button
    Friend WithEvents Reload As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Gurantor_history As System.Windows.Forms.Button
    Friend WithEvents btn_manual As System.Windows.Forms.Button
    Friend WithEvents serversetting As System.Windows.Forms.Button
    Friend WithEvents Btn_loan_report As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MultiRowSelectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_collectionsheet As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class
