Imports System.Data.SqlClient
Imports System.IO

Public Class Bills
    Public Property UserName As String
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
    Dim categoriesFile As String = "categories.txt"
    Dim selectedRowIndex As Integer = -1

    ' Method to load categories from the file and populate ComboBoxes
    Private Sub LoadCategoriesFromFile()
        If File.Exists(categoriesFile) Then
            Using reader As StreamReader = New StreamReader(categoriesFile)
                Dim line As String
                Do
                    line = reader.ReadLine()
                    If Not String.IsNullOrWhiteSpace(line) Then
                        FilterCb.Items.Add(line)
                    End If
                Loop Until line Is Nothing
            End Using
        End If
    End Sub

    ' Method to populate the DataGridView with book data
    Private Sub Populate()
        Try
            Con.Open()
            Dim query = "SELECT * FROM BookTable"
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(query, Con)
            Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter)
            Dim ds As DataSet = New DataSet
            adapter.Fill(ds)
            BookDGV.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Error Populating Data:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Con.Close()
        End Try
    End Sub

    ' Method to filter books based on selected category
    Private Sub Filter()
        Try
            Con.Open()
            Dim query = "SELECT * FROM BookTable where category = '" & FilterCb.SelectedItem.ToString() & "'"
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(query, Con)
            Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter)
            Dim ds As DataSet = New DataSet
            adapter.Fill(ds)
            BookDGV.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Error Filtering Data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Con.Close()
        End Try
    End Sub

    ' Method to clear input fields after adding to the bill
    Private Sub Reset()
        TitleTb.Clear()
        PriceTb.Clear()
        QuantityTb.Clear()
        key = 0
        BidTb.Text = ""
    End Sub

    ' Load event for the form
    Private Sub Bills_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        LoadCategoriesFromFile()
        UsernameLb.Text = UserName
        Populate()
    End Sub

    ' Variables to hold selected book details and calculation data
    Dim key As Integer = 0
    Dim Stock As Integer = 0
    Dim GrndTotal As Integer = 0

    ' Event handler for cell content click in the DataGridView
    Private Sub BookDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles BookDGV.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = BookDGV.Rows(e.RowIndex)
            BidTb.Text = If(IsDBNull(row.Cells("Bid").Value), String.Empty, Convert.ToInt32(row.Cells("Bid").Value).ToString())
            TitleTb.Text = row.Cells("Title").Value.ToString()
            PriceTb.Text = row.Cells("Price").Value.ToString()
            Stock = Convert.ToInt32(row.Cells("Quantity").Value.ToString())
            key = Convert.ToInt32(row.Cells("Bid").Value.ToString())
        End If
    End Sub

    ' Method to update stock after adding a book to the bill
    Private Sub UpdateBookStock(bookID As Integer, newQuantity As Integer)
        Try
            Using conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
                conn.Open()
                Dim query As String = "UPDATE BookTable SET Quantity = @newQuantity WHERE Bid = @bookID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@newQuantity", newQuantity)
                    cmd.Parameters.AddWithValue("@bookID", bookID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error Updating Book Stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Method to add bill data to the BillTbl
    Private Sub AddBill(row As DataGridViewRow)
        Using conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
            Try
                conn.Open()

                ' Ensure the Amount contains a valid decimal number
                Dim amount As Decimal
                If Decimal.TryParse(row.Cells("Column5").Value.ToString(), amount) Then
                    ' Ensure the DateLb contains a valid DateTime
                    Dim billDate As DateTime
                    If DateTime.TryParse(DateLb.Text.Trim(), billDate) Then
                        Dim query As String = "INSERT INTO BillTbl (UName, ClientName, Bid, BName, Quantity, Price, Amount, Date) VALUES (@UName, @ClientName, @Bid, @BName, @Quantity, @Price, @Amount, @Date)"

                        Using cmd As New SqlCommand(query, conn)
                            ' Add parameters to the SQL command
                            cmd.Parameters.AddWithValue("@UName", UsernameLb.Text)
                            cmd.Parameters.AddWithValue("@ClientName", ClientNameTb.Text.Trim())
                            cmd.Parameters.AddWithValue("@Bid", row.Cells("Column1").Value.ToString())
                            cmd.Parameters.AddWithValue("@BName", row.Cells("Column2").Value.ToString())
                            cmd.Parameters.AddWithValue("@Quantity", row.Cells("Column4").Value.ToString())
                            cmd.Parameters.AddWithValue("@Price", row.Cells("Column3").Value.ToString())
                            cmd.Parameters.AddWithValue("@Amount", amount)
                            cmd.Parameters.AddWithValue("@Date", billDate)

                            ' Execute the SQL command
                            cmd.ExecuteNonQuery()

                        End Using
                    Else
                        MessageBox.Show("Invalid Date Format", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Invalid Amount", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub


    ' Event handler for Add to Bill button click
    Private Sub AddToBillBtn_Click(sender As Object, e As EventArgs) Handles AddToBillBtn.Click
        If String.IsNullOrEmpty(PriceTb.Text) Or String.IsNullOrEmpty(QuantityTb.Text) Then
            MessageBox.Show("Enter Quantity", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        ElseIf String.IsNullOrEmpty(ClientNameTb.Text) Then
            MessageBox.Show("Enter Client Name", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim quantityToAdd As Integer
        ' Check if quantity is a valid integer
        If Not Integer.TryParse(QuantityTb.Text, quantityToAdd) Then
            Dim result2 As DialogResult = MessageBox.Show("Invalid Quantity", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return
        End If

        ' Check if quantity is greater than zero
        If quantityToAdd <= 0 Then
            Dim result2 As DialogResult = MessageBox.Show("Enetr Valid Quantity (eg.1)", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return
        End If

        ' Check if quantity exceeds available stock
        If quantityToAdd > Stock Then
            Dim result2 As DialogResult = MessageBox.Show("Not Enough Stock", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return
        End If

        ' Check if a book is selected
        If key = 0 Then
            Dim result2 As DialogResult = MessageBox.Show("Please Select A Book", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return
        End If

        ' Update the stock in the database
        Dim newStock As Integer = Stock - quantityToAdd
        UpdateBookStock(key, newStock)

        ' Add book details to the Bill DataGridView
        Dim rnum As Integer = BillDGV.Rows.Add()
        Dim Total As Integer = quantityToAdd * Convert.ToInt32(PriceTb.Text)
        BillDGV.Rows.Item(rnum).Cells("Column1").Value = BidTb.Text
        BillDGV.Rows.Item(rnum).Cells("Column2").Value = TitleTb.Text
        BillDGV.Rows.Item(rnum).Cells("Column3").Value = PriceTb.Text
        BillDGV.Rows.Item(rnum).Cells("Column4").Value = quantityToAdd
        BillDGV.Rows.Item(rnum).Cells("Column5").Value = Total

        ' Update the grand total
        GrndTotal += Total
        Dim tot As String = "Rs. " + Convert.ToString(GrndTotal)
        GrandTotalTb.Text = tot

        ' Refresh the DataGridView to show updated stock
        Populate()

        ' Add this row to BillTbl
        AddBill(BillDGV.Rows(rnum))

        ' Clear input fields
        Reset()
    End Sub

    ' Event handler for Reset button click
    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        Reset()
    End Sub

    ' Event handler for Refresh button click
    Private Sub RefreshBtn_Click(sender As Object, e As EventArgs) Handles RefreshBtn.Click
        Populate()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Set up fonts
        Dim titleFont As New Font("Consolas", 30, FontStyle.Bold)
        Dim headerFont As New Font("Consolas", 20, FontStyle.Bold)
        Dim bodyFont As New Font("Consolas", 15)
        Dim footerFont As New Font("Consolas", 20, FontStyle.Bold)

        ' Set up brushes
        Dim brush As New SolidBrush(Color.Black)

        ' Define the initial Y position
        Dim yPosition As Integer = 60

        ' Draw the shop title
        e.Graphics.DrawString("Bookshop", titleFont, brush, New PointF(300, yPosition))
        yPosition += 60

        ' Draw the bill header
        e.Graphics.DrawString("======== Your Bill =======", headerFont, brush, New PointF(200, yPosition))
        yPosition += 50

        e.Graphics.DrawString("Date: " & DateLb.Text, New Font("Arial", 15, FontStyle.Bold), Brushes.Black, New PointF(100, yPosition))
        yPosition += 30

        ' Draw the client name
        e.Graphics.DrawString("Client Name: " & ClientNameTb.Text, New Font("Arial", 15, FontStyle.Bold), Brushes.Black, New PointF(100, yPosition))
        yPosition += 30

        ' Draw table headers
        Dim columnHeaders As String() = {"ID", "Name", "Price", "Qty", "Total"}
        Dim columnWidths As Integer() = {100, 250, 100, 100, 100}
        Dim xPosition As Integer = 80

        ' Draw table header
        For i As Integer = 0 To columnHeaders.Length - 1
            e.Graphics.DrawString(columnHeaders(i), headerFont, brush, New PointF(xPosition, yPosition))
            xPosition += columnWidths(i) + 10 ' Add extra spacing between columns
        Next
        yPosition += 40

        ' Draw table rows
        For Each row As DataGridViewRow In BillDGV.Rows
            xPosition = 80
            For i As Integer = 0 To columnHeaders.Length - 1
                Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")
                e.Graphics.DrawString(cellValue, bodyFont, brush, New PointF(xPosition, yPosition))
                xPosition += columnWidths(i) + 10 ' Add extra spacing between columns
            Next
            yPosition += 30
        Next

        yPosition += 20

        ' Draw the total amount
        e.Graphics.DrawString("Total Amount : Rs. " & GrndTotal.ToString(), footerFont, brush, New PointF(80, yPosition))
        yPosition += 50

        ' Draw the thank you message
        e.Graphics.DrawString("===== Thanks for Shopping! Visit Again =====", headerFont, brush, New PointF(100, yPosition))
    End Sub

    ' Event handler for Print button click
    Private Sub PrintBtn_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click
        ' Display the Print Dialog and print if the user confirms
        If PrintDmnt.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
        Dim result2 As DialogResult = MessageBox.Show("Bill Printed Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Clear the DataGridView
        BillDGV.Rows.Clear()
        GrndTotal = 0 * GrndTotal
        ' Clear other input fields and reset
        GrandTotalTb.Clear()
        ClientNameTb.Clear()
        Reset()
    End Sub

    ' Timer tick event for updating DateLb
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateLb.Text = DateTime.Now.ToString("dd-MM-yyyy")
    End Sub

    ' Event handler for Filter button click

    Private Sub FilterCb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterCb.SelectedIndexChanged
        If FilterCb.SelectedIndex = -1 Then
            MessageBox.Show("Select a category to filter", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Filter()
        End If
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim obj = New Login
        obj.Show()
        Me.Close()
    End Sub

    Private Sub RemoveBtn_Click(sender As Object, e As EventArgs) Handles RemoveBtn.Click
        If selectedRowIndex >= 0 Then
            Dim row As DataGridViewRow = BillDGV.Rows(selectedRowIndex)
            Dim quantity As Integer = Convert.ToInt32(row.Cells("Column4").Value)

            Dim newStock As Integer = Stock + quantity
            UpdateBookStock(key, newStock)

            GrndTotal -= Convert.ToInt32(row.Cells("Column5").Value)
            GrandTotalTb.Text = "Rs. " + Convert.ToString(GrndTotal)

            BillDGV.Rows.RemoveAt(selectedRowIndex)
            GrandTotalTb.Clear()

            Populate()
            Reset()
        End If
    End Sub

    Private Sub BillDGV_MouseClick(sender As Object, e As MouseEventArgs) Handles BillDGV.MouseClick
        If BillDGV.CurrentRow.Index >= 0 Then
            Dim row As DataGridViewRow = BillDGV.CurrentRow
            BidTb.Text = row.Cells("Column1").Value.ToString()
            TitleTb.Text = row.Cells("Column2").Value.ToString()

            PriceTb.Text = row.Cells("Column3").Value.ToString()
            QuantityTb.Text = row.Cells("Column4").Value.ToString()
            selectedRowIndex = row.Index
            key = GetBookIDByTitle(row.Cells("Column2").Value.ToString())
            Dim stockQuery As String = "SELECT Quantity FROM BookTable WHERE Title = @Title"
            Try
                Con.Open()
                Using cmd As New SqlCommand(stockQuery, Con)
                    cmd.Parameters.AddWithValue("@Title", row.Cells("Column2").Value.ToString())
                    Stock = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            Catch ex As Exception
                Dim result2 As DialogResult = MessageBox.Show("Error Retriving Data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                Con.Close()
            End Try
        End If
    End Sub

    Private Function GetBookIDByTitle(title As String) As Integer
        Dim bookID As Integer = 0
        Try
            Con.Open()
            Dim query As String = "SELECT Bid FROM BookTable WHERE Title = @Title"
            Using cmd As New SqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@Title", title)
                bookID = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        Catch ex As Exception
            Dim result2 As DialogResult = MessageBox.Show("Error Retriving Book ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Con.Close()
        End Try
        Return bookID
    End Function

End Class
