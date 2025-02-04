Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class Record
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Populate()
        Con.Open()
        Dim query = "SELECT ClientName, Bid, BName, Quantity, Price, Amount FROM BillTbl"
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(query, Con)
        Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet = New DataSet
        adapter.Fill(ds)
        RecordDGV.DataSource = ds.Tables(0)
        Con.Close()

        ' Add serial number column if it doesn't exist
        If Not RecordDGV.Columns.Contains("S.No.") Then
            Dim serialColumn As New DataGridViewTextBoxColumn()
            serialColumn.Name = "S.No."
            serialColumn.HeaderText = "S.No."
            serialColumn.ReadOnly = True
            RecordDGV.Columns.Insert(0, serialColumn)
        End If

        ' Populate the serial number column
        For i As Integer = 0 To RecordDGV.Rows.Count - 1
            RecordDGV.Rows(i).Cells("S.No.").Value = i + 1
        Next

        CalculateTotals()

    End Sub

    ' Function to calculate and display total quantity and grand total amount
    Private Sub CalculateTotals()
        Dim totalQuantity As Integer = 0
        Dim grandTotal As Decimal = 0

        For Each row As DataGridViewRow In RecordDGV.Rows
            If Not row.IsNewRow Then
                totalQuantity += Convert.ToInt32(row.Cells("Quantity").Value)
                grandTotal += Convert.ToDecimal(row.Cells("Amount").Value)
            End If
        Next

        TotalQuantityTb.Text = totalQuantity.ToString()
        GrandTotalTb.Text = grandTotal.ToString("C2") ' Format as currency
    End Sub

    Private Sub Filter()
        Using Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
            Try
                Con.Open()

                Dim selectedDate1 As DateTime
                Dim selectedDate2 As DateTime

                If Not DateTime.TryParseExact(DateTimePicker1.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", Nothing, Globalization.DateTimeStyles.None, selectedDate1) OrElse
               Not DateTime.TryParseExact(DateTimePicker2.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", Nothing, Globalization.DateTimeStyles.None, selectedDate2) Then
                    MsgBox("Invalid date format. Please use yyyy-MM-dd.")
                    Return
                End If

                ' Example query to filter between two dates
                Dim query As String = "SELECT ClientName, Bid, BName, Quantity, Price, Amount FROM BillTbl WHERE CAST(Date AS DATE) BETWEEN @Date1 AND @Date2"

                Using adapter As New SqlDataAdapter(query, Con)
                    adapter.SelectCommand.Parameters.AddWithValue("@Date1", selectedDate1.Date)
                    adapter.SelectCommand.Parameters.AddWithValue("@Date2", selectedDate2.Date)

                    Dim ds As New DataSet()
                    adapter.Fill(ds)
                    ' ds.Tables(0).Columns.Add("S.No.", GetType(Integer))
                    RecordDGV.DataSource = ds.Tables(0)

                    ' Add serial number column if it doesn't exist
                    If Not RecordDGV.Columns.Contains("S.No.") Then
                        Dim serialColumn As New DataGridViewTextBoxColumn()
                        serialColumn.Name = "S.No."
                        serialColumn.HeaderText = "S.No."
                        serialColumn.ReadOnly = True
                        RecordDGV.Columns.Insert(0, serialColumn)
                    End If

                    ' Populate the serial number column
                    For i As Integer = 0 To RecordDGV.Rows.Count - 1
                        RecordDGV.Rows(i).Cells("S.No.").Value = i + 1
                    Next
                    CalculateTotals()
                End Using
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            Finally
                Con.Close()
            End Try
        End Using
    End Sub

    ' Function to load data from BillTbl and bind to RecordDGV
    Private Sub LoadBillRecords()
        Using conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
            Try
                conn.Open()

                Dim query As String = "SELECT ClientName, Bid, BName, Quantity, Price, Amount FROM BillTbl"
                Using cmd As New SqlCommand(query, conn)
                    Using adapter As New SqlDataAdapter(cmd)
                        Dim table As New DataTable()
                        adapter.Fill(table)

                        ' Add serial number column if it doesn't exist
                        If Not RecordDGV.Columns.Contains("S.No.") Then
                            Dim serialColumn As New DataGridViewTextBoxColumn()
                            serialColumn.Name = "S.No."
                            serialColumn.HeaderText = "S.No."
                            serialColumn.ReadOnly = True
                            RecordDGV.Columns.Insert(0, serialColumn)
                        End If

                        RecordDGV.DataSource = table

                        For i As Integer = 0 To RecordDGV.Rows.Count - 1
                            RecordDGV.Rows(i).Cells("S.No.").Value = i + 1
                        Next

                        CalculateTotals()
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub



    ' Form Load event to load data when the form is opened
    Private Sub Record_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        LoadBillRecords()
    End Sub

    Private Sub CancelLb_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub
    ' Flags to check if dates have been selected
    Private startDateSelected As Boolean = False
        Private endDateSelected As Boolean = False

        Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
            ' Ensure DateTimePicker1 value is not greater than DateTimePicker2 value
            If DateTimePicker1.Value > DateTimePicker2.Value Then
                MessageBox.Show("The start date cannot be greater than the end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                DateTimePicker1.Value = DateTimePicker2.Value
            End If

            ' Set the selected date to the TextBox in the correct format
            SelectDateTb.Text = DateTimePicker1.Value.ToString("yyyy-MM-dd")
            Filter() ' Filter records based on the new date

            ' Mark that the start date has been selected
            startDateSelected = True
        End Sub

        Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
            ' Ensure DateTimePicker2 value is not less than DateTimePicker1 value
            If DateTimePicker2.Value < DateTimePicker1.Value Then
            ' MessageBox.Show("The end date cannot be less than the start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            DateTimePicker2.Value = DateTimePicker1.Value
            End If

            ' Set the selected date to the TextBox in the correct format
            SelectDateTb2.Text = DateTimePicker2.Value.ToString("yyyy-MM-dd")
            Filter() ' Filter records based on the new date

            ' Mark that the end date has been selected
            endDateSelected = True
        End Sub

        Private Sub RefreshBtn_Click(sender As Object, e As EventArgs) Handles RefreshBtn.Click
            ' Temporarily remove event handlers to prevent validation during refresh
            RemoveHandler DateTimePicker1.ValueChanged, AddressOf DateTimePicker1_ValueChanged
            RemoveHandler DateTimePicker2.ValueChanged, AddressOf DateTimePicker2_ValueChanged

            ' Reset DateTimePicker values to current date
            DateTimePicker1.Value = DateTime.Now
            DateTimePicker2.Value = DateTime.Now

        ' Update the TextBox to display the current date
        SelectDateTb.Text = "Select A Date"
        SelectDateTb2.Text = "Selectt A Date"

        ' Reattach the event handlers
        AddHandler DateTimePicker1.ValueChanged, AddressOf DateTimePicker1_ValueChanged
            AddHandler DateTimePicker2.ValueChanged, AddressOf DateTimePicker2_ValueChanged

            ' Reset the flags
            startDateSelected = False
            endDateSelected = False

            ' Repopulate the data grid view
            Populate()

            If RecordDGV.Rows.Count > 0 Then
                ' Add serial number column if it doesn't exist
                If Not RecordDGV.Columns.Contains("S.No.") Then
                    Dim serialColumn As New DataGridViewTextBoxColumn()
                    serialColumn.Name = "S.No."
                    serialColumn.HeaderText = "S.No."
                    serialColumn.ReadOnly = True
                    RecordDGV.Columns.Insert(0, serialColumn)
                End If

                For i As Integer = 0 To RecordDGV.Rows.Count - 1
                    RecordDGV.Rows(i).Cells("S.No.").Value = i + 1
                Next

                ' Calculate and display totals
                CalculateTotals()
            End If
        End Sub

        Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
            ' Set up fonts and brushes
            Dim titleFont As New Font("Consolas", 30, FontStyle.Bold)
            Dim headerFont As New Font("Consolas", 14, FontStyle.Regular)
            Dim bodyFont As New Font("Consolas", 10)
            Dim brush As New SolidBrush(Color.Black)
            Dim footerFont As New Font("Consolas", 14, FontStyle.Regular)

            ' Define margins and positions
            Dim yPosition As Integer = 60
            Dim xPosition As Integer = 80
            Dim pageWidth As Integer = e.MarginBounds.Width
            Dim leftMargin As Integer = e.MarginBounds.Left

            ' Draw title
            e.Graphics.DrawString("Bookshop", titleFont, brush, New PointF(leftMargin + 200, yPosition))
            yPosition += 60

            ' Draw header
            e.Graphics.DrawString("======== Sales Record =======", headerFont, brush, New PointF(leftMargin + 150, yPosition))
            yPosition += 50

            ' Draw current date and selected dates
            Dim currentDate As DateTime = DateTime.Now
            Dim currentDateString As String = "Current Date: " & currentDate.ToString("dd/MM/yyyy")
            Dim fromDateLabel As String = If(startDateSelected, "From Date: " & DateTimePicker1.Value.ToString("dd/MM/yyyy"), "From Date: All Records")
            Dim toDateLabel As String = If(endDateSelected, "To Date: " & DateTimePicker2.Value.ToString("dd/MM/yyyy"), "To Date: All Records")

            ' Draw current date
            e.Graphics.DrawString(currentDateString, bodyFont, brush, New PointF(leftMargin + 20, yPosition))
            yPosition += 20

            ' Draw selected dates
            e.Graphics.DrawString(fromDateLabel, bodyFont, brush, New PointF(leftMargin + 20, yPosition))
            e.Graphics.DrawString(toDateLabel, bodyFont, brush, New PointF(leftMargin + 20, yPosition + 20))
            yPosition += 50

            ' Define column headers and widths
            Dim columnHeaders As String() = {"S.No.", "Customer", "BookID", "Title", "Qty", "Price", "Total"}
            Dim columnWidths As Integer() = {50, 100, 60, 200, 60, 50, 60} ' Adjusted column widths to fit the page

            ' Draw column headers
            xPosition = leftMargin + 20
            For i As Integer = 0 To columnHeaders.Length - 1
                e.Graphics.DrawString(columnHeaders(i), headerFont, brush, New PointF(xPosition, yPosition))
                xPosition += columnWidths(i) + 10 ' Add spacing between columns
            Next
            yPosition += 40

            ' Draw table rows
            Dim rowHeight As Integer = 20
            Dim rowPosition As Integer = yPosition

            ' Iterate over visible rows in RecordDGV
            For Each row As DataGridViewRow In RecordDGV.Rows
                If Not row.IsNewRow AndAlso row.Visible Then ' Ensure row is not a new row and is visible
                    xPosition = leftMargin + 20

                    ' Draw the serial number based on visible rows
                    Dim visibleIndex As Integer = RecordDGV.Rows.GetFirstRow(DataGridViewElementStates.Visible) + row.Index + 1
                    e.Graphics.DrawString(visibleIndex.ToString(), bodyFont, brush, New PointF(xPosition, rowPosition))
                    xPosition += columnWidths(0) + 10 ' Move to the next column

                    ' Draw the remaining cells
                    For i As Integer = 1 To columnHeaders.Length - 1
                        Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")
                        e.Graphics.DrawString(cellValue, bodyFont, brush, New PointF(xPosition, rowPosition))
                        xPosition += columnWidths(i) + 10 ' Add spacing between columns
                    Next

                    rowPosition += rowHeight
                End If
            Next

            ' Ensure there is enough space for the total amount
            If rowPosition + 60 > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                Return
            End If

            ' Draw the total quantity
            Dim TotalQuantity As Integer = TotalQuantityTb.Text
            yPosition = rowPosition + 30 ' Adjust yPosition to ensure there's enough space
            e.Graphics.DrawString("Total Sales Quantity : " & TotalQuantity.ToString(), footerFont, brush, New PointF(80, yPosition))
            yPosition += 50

            ' Draw the total amount
            Dim GrandTotal As Integer = GrandTotalTb.Text
            yPosition = rowPosition + 60 ' Adjust yPosition to ensure there's enough space
            e.Graphics.DrawString("Grand Total : Rs. " & GrandTotal.ToString(), footerFont, brush, New PointF(80, yPosition))
            yPosition += 50

            ' Optionally draw footer or additional content
            ' Example:
            ' yPosition += 20
            ' e.Graphics.DrawString("Footer text", bodyFont, brush, New PointF(leftMargin, yPosition))

            ' End of page
            e.HasMorePages = False
        End Sub

    Private Sub PrintBtn_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click
        ' Display the Print Dialog and print if the user confirms
        If PrintDmnt.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CurrentDateLb.Text = Date.Now.ToString("dd-MM-yyyy")
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)
        Dim obj = New Login()
        obj.Show()
        Me.Close()
    End Sub

    Private Sub Label10_Click_1(sender As Object, e As EventArgs) Handles Label10.Click
        Dim obj = New Dashboard()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click_1(sender As Object, e As EventArgs) Handles Label4.Click
        Dim obj = New Book()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click
        Dim obj = New User()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click_1(sender As Object, e As EventArgs) Handles Label12.Click
        Dim obj = New Login()
        obj.Show()
        Me.Hide()
    End Sub




End Class