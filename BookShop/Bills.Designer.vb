<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bills
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Bills))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.QuantityTb = New System.Windows.Forms.TextBox()
        Me.TitleTb = New System.Windows.Forms.TextBox()
        Me.PriceTb = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BidTb = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BookDGV = New System.Windows.Forms.DataGridView()
        Me.BillDGV = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrintBtn = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GrandTotalTb = New System.Windows.Forms.TextBox()
        Me.UsernameLb = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.AddToBillBtn = New System.Windows.Forms.Button()
        Me.ResetBtn = New System.Windows.Forms.Button()
        Me.RefreshBtn = New System.Windows.Forms.Button()
        Me.FilterCb = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.RemoveBtn = New System.Windows.Forms.Button()
        Me.ClientNameTb = New System.Windows.Forms.TextBox()
        Me.PrintDmnt = New System.Windows.Forms.PrintPreviewDialog()
        Me.DateLb = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BookDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BillDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(13, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(206, 761)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.PictureBox9)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel5.Location = New System.Drawing.Point(0, 721)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(206, 39)
        Me.Panel5.TabIndex = 10
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(6, -2)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(39, 40)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox9.TabIndex = 91
        Me.PictureBox9.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(66, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 20)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Logout"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(93, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 29)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Billing"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(85, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(964, 458)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 20)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Price"
        '
        'QuantityTb
        '
        Me.QuantityTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuantityTb.Location = New System.Drawing.Point(786, 455)
        Me.QuantityTb.Name = "QuantityTb"
        Me.QuantityTb.Size = New System.Drawing.Size(157, 27)
        Me.QuantityTb.TabIndex = 4
        '
        'TitleTb
        '
        Me.TitleTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleTb.Location = New System.Drawing.Point(482, 455)
        Me.TitleTb.Name = "TitleTb"
        Me.TitleTb.Size = New System.Drawing.Size(197, 27)
        Me.TitleTb.TabIndex = 3
        '
        'PriceTb
        '
        Me.PriceTb.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.PriceTb.Enabled = False
        Me.PriceTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PriceTb.Location = New System.Drawing.Point(1028, 455)
        Me.PriceTb.Name = "PriceTb"
        Me.PriceTb.Size = New System.Drawing.Size(143, 27)
        Me.PriceTb.TabIndex = 47
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(234, 458)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 20)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Book ID"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(696, 458)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 20)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Quantity"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(424, 458)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 20)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Title"
        '
        'BidTb
        '
        Me.BidTb.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BidTb.Enabled = False
        Me.BidTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BidTb.Location = New System.Drawing.Point(319, 455)
        Me.BidTb.Name = "BidTb"
        Me.BidTb.Size = New System.Drawing.Size(77, 27)
        Me.BidTb.TabIndex = 48
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(236, 414)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 22)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Customer Name"
        '
        'BookDGV
        '
        Me.BookDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.BookDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.BookDGV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.BookDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BookDGV.Location = New System.Drawing.Point(240, 178)
        Me.BookDGV.Name = "BookDGV"
        Me.BookDGV.RowHeadersWidth = 51
        Me.BookDGV.RowTemplate.Height = 24
        Me.BookDGV.Size = New System.Drawing.Size(1030, 216)
        Me.BookDGV.TabIndex = 51
        '
        'BillDGV
        '
        Me.BillDGV.AllowUserToAddRows = False
        Me.BillDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.BillDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.BillDGV.BackgroundColor = System.Drawing.Color.White
        Me.BillDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BillDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleTurquoise
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.BillDGV.DefaultCellStyle = DataGridViewCellStyle1
        Me.BillDGV.Location = New System.Drawing.Point(240, 557)
        Me.BillDGV.Name = "BillDGV"
        Me.BillDGV.RowHeadersWidth = 51
        Me.BillDGV.RowTemplate.Height = 24
        Me.BillDGV.Size = New System.Drawing.Size(881, 184)
        Me.BillDGV.TabIndex = 53
        '
        'Column1
        '
        Me.Column1.HeaderText = "Book ID"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Book"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Price"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Quantity"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Total"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        '
        'PrintBtn
        '
        Me.PrintBtn.BackColor = System.Drawing.Color.DarkCyan
        Me.PrintBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintBtn.ForeColor = System.Drawing.Color.White
        Me.PrintBtn.Location = New System.Drawing.Point(1141, 731)
        Me.PrintBtn.Name = "PrintBtn"
        Me.PrintBtn.Size = New System.Drawing.Size(111, 33)
        Me.PrintBtn.TabIndex = 9
        Me.PrintBtn.Text = "Print"
        Me.PrintBtn.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(863, 750)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 20)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Grand Total"
        '
        'GrandTotalTb
        '
        Me.GrandTotalTb.Enabled = False
        Me.GrandTotalTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrandTotalTb.Location = New System.Drawing.Point(989, 747)
        Me.GrandTotalTb.Name = "GrandTotalTb"
        Me.GrandTotalTb.Size = New System.Drawing.Size(127, 27)
        Me.GrandTotalTb.TabIndex = 46
        '
        'UsernameLb
        '
        Me.UsernameLb.AutoSize = True
        Me.UsernameLb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLb.Location = New System.Drawing.Point(287, 103)
        Me.UsernameLb.Name = "UsernameLb"
        Me.UsernameLb.Size = New System.Drawing.Size(113, 25)
        Me.UsernameLb.TabIndex = 44
        Me.UsernameLb.Text = "UserName"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(238, 93)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(43, 40)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'AddToBillBtn
        '
        Me.AddToBillBtn.BackColor = System.Drawing.Color.DarkCyan
        Me.AddToBillBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddToBillBtn.ForeColor = System.Drawing.Color.White
        Me.AddToBillBtn.Location = New System.Drawing.Point(550, 503)
        Me.AddToBillBtn.Name = "AddToBillBtn"
        Me.AddToBillBtn.Size = New System.Drawing.Size(111, 33)
        Me.AddToBillBtn.TabIndex = 5
        Me.AddToBillBtn.Text = "Add To Bill"
        Me.AddToBillBtn.UseVisualStyleBackColor = False
        '
        'ResetBtn
        '
        Me.ResetBtn.BackColor = System.Drawing.Color.DarkCyan
        Me.ResetBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetBtn.ForeColor = System.Drawing.Color.White
        Me.ResetBtn.Location = New System.Drawing.Point(689, 503)
        Me.ResetBtn.Name = "ResetBtn"
        Me.ResetBtn.Size = New System.Drawing.Size(111, 33)
        Me.ResetBtn.TabIndex = 6
        Me.ResetBtn.Text = "Reset"
        Me.ResetBtn.UseVisualStyleBackColor = False
        '
        'RefreshBtn
        '
        Me.RefreshBtn.BackColor = System.Drawing.Color.DarkCyan
        Me.RefreshBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefreshBtn.Location = New System.Drawing.Point(701, 146)
        Me.RefreshBtn.Name = "RefreshBtn"
        Me.RefreshBtn.Size = New System.Drawing.Size(116, 29)
        Me.RefreshBtn.TabIndex = 1
        Me.RefreshBtn.Text = "Refresh"
        Me.RefreshBtn.UseVisualStyleBackColor = False
        '
        'FilterCb
        '
        Me.FilterCb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilterCb.FormattingEnabled = True
        Me.FilterCb.Items.AddRange(New Object() {"English", "Mathematics", "Programming", "Novels"})
        Me.FilterCb.Location = New System.Drawing.Point(536, 146)
        Me.FilterCb.Name = "FilterCb"
        Me.FilterCb.Size = New System.Drawing.Size(159, 26)
        Me.FilterCb.TabIndex = 0
        Me.FilterCb.Text = "Filter By Category"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(652, 118)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 25)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "Book List"
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'RemoveBtn
        '
        Me.RemoveBtn.BackColor = System.Drawing.Color.DarkCyan
        Me.RemoveBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.RemoveBtn.Location = New System.Drawing.Point(1141, 674)
        Me.RemoveBtn.Name = "RemoveBtn"
        Me.RemoveBtn.Size = New System.Drawing.Size(111, 30)
        Me.RemoveBtn.TabIndex = 8
        Me.RemoveBtn.Text = "Return"
        Me.RemoveBtn.UseVisualStyleBackColor = False
        '
        'ClientNameTb
        '
        Me.ClientNameTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientNameTb.Location = New System.Drawing.Point(409, 413)
        Me.ClientNameTb.Name = "ClientNameTb"
        Me.ClientNameTb.Size = New System.Drawing.Size(175, 28)
        Me.ClientNameTb.TabIndex = 2
        '
        'PrintDmnt
        '
        Me.PrintDmnt.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintDmnt.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintDmnt.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintDmnt.Document = Me.PrintDocument1
        Me.PrintDmnt.Enabled = True
        Me.PrintDmnt.Icon = CType(resources.GetObject("PrintDmnt.Icon"), System.Drawing.Icon)
        Me.PrintDmnt.Name = "PrintDmnt"
        Me.PrintDmnt.Visible = False
        '
        'DateLb
        '
        Me.DateLb.AutoSize = True
        Me.DateLb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateLb.Location = New System.Drawing.Point(1139, 408)
        Me.DateLb.Name = "DateLb"
        Me.DateLb.Size = New System.Drawing.Size(57, 25)
        Me.DateLb.TabIndex = 57
        Me.DateLb.Text = "Date"
        '
        'Timer1
        '
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1057, 408)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 25)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Date : "
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.Controls.Add(Me.Label15)
        Me.Panel7.Location = New System.Drawing.Point(238, 13)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1032, 52)
        Me.Panel7.TabIndex = 67
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Bookman Old Style", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(348, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Padding = New System.Windows.Forms.Padding(5)
        Me.Label15.Size = New System.Drawing.Size(319, 46)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Ajanta Book Store "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Bills
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkCyan
        Me.ClientSize = New System.Drawing.Size(1282, 786)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateLb)
        Me.Controls.Add(Me.ClientNameTb)
        Me.Controls.Add(Me.RemoveBtn)
        Me.Controls.Add(Me.RefreshBtn)
        Me.Controls.Add(Me.FilterCb)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ResetBtn)
        Me.Controls.Add(Me.AddToBillBtn)
        Me.Controls.Add(Me.PrintBtn)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.BillDGV)
        Me.Controls.Add(Me.BookDGV)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.QuantityTb)
        Me.Controls.Add(Me.GrandTotalTb)
        Me.Controls.Add(Me.TitleTb)
        Me.Controls.Add(Me.PriceTb)
        Me.Controls.Add(Me.BidTb)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.UsernameLb)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Bills"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bills"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BookDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BillDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents QuantityTb As TextBox
    Friend WithEvents TitleTb As TextBox
    Friend WithEvents PriceTb As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents BidTb As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BookDGV As DataGridView
    Friend WithEvents BillDGV As DataGridView
    Friend WithEvents PrintBtn As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents GrandTotalTb As TextBox
    Friend WithEvents UsernameLb As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents AddToBillBtn As Button
    Friend WithEvents ResetBtn As Button
    Friend WithEvents RefreshBtn As Button
    Friend WithEvents FilterCb As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents RemoveBtn As Button
    Friend WithEvents ClientNameTb As TextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents PrintDmnt As PrintPreviewDialog
    Friend WithEvents DateLb As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents PictureBox9 As PictureBox
End Class
