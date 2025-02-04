Imports System.Data.SqlClient
Imports System.IO

Public Class Book
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
    Dim categoriesFile As String = "categories.txt"

    Private Sub user_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        LoadCategoriesFromFile() ' Load categories from file when the form loads
        Populate() ' Populate the DataGridView when the form loads
    End Sub

    Private Sub AddBook(Title As String, Author As String, Category As String, Quantity As String, Price As String, PDate As String)
        Try
            Using conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
                conn.Open() ' Open the database connection
                Dim query As String = "INSERT INTO BookTable (Title, Author, Category, Quantity, Price, pdate) VALUES (@title, @author, @category, @quantity, @price, @pdate)"
                Using cmd As New SqlCommand(query, conn)
                    ' Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@title", Title)
                    cmd.Parameters.AddWithValue("@category", Category)
                    cmd.Parameters.AddWithValue("@author", Author)
                    cmd.Parameters.AddWithValue("@quantity", Quantity)
                    cmd.Parameters.AddWithValue("@price", Price)
                    cmd.Parameters.AddWithValue("@pdate", PDate)

                    cmd.ExecuteNonQuery() ' Execute the SQL command
                End Using
            End Using
            MessageBox.Show("Book Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error Adding Book : " & ex.Message, "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        If String.IsNullOrWhiteSpace(TitleTb.Text) Or
           String.IsNullOrWhiteSpace(AuthorTb.Text) Or
           String.IsNullOrWhiteSpace(CategoryCb.Text) Or ' Check if CategoryCb is empty
           String.IsNullOrWhiteSpace(QuantityTb.Text) Or
           String.IsNullOrWhiteSpace(PriceTb.Text) Then
            MessageBox.Show("Missing Information", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return ' Exit the method if any fields are empty
        End If

        ' Get the category from the ComboBox
        Dim category As String = CategoryCb.Text

        ' Check if the category is not already in the ComboBox and add it if it is new
        If Not CategoryCb.Items.Contains(category) Then
            CategoryCb.Items.Add(category)
            FilterCb.Items.Add(category)
            SaveCategoryToFile(category)
        End If

        ' Add the book to the database
        AddBook(TitleTb.Text, AuthorTb.Text, category, QuantityTb.Text, PriceTb.Text, datelb.Text)

        ' Populate the data and reset the fields
        Populate()
        Reset()
    End Sub

    ' Method to save a category to a file
    Private Sub SaveCategoryToFile(category As String)
        Using writer As StreamWriter = New StreamWriter(categoriesFile, True)
            writer.WriteLine(category)
        End Using
    End Sub

    ' Method to load categories from a file
    Private Sub LoadCategoriesFromFile()
        If File.Exists(categoriesFile) Then
            Using reader As StreamReader = New StreamReader(categoriesFile)
                Dim line As String
                Do
                    line = reader.ReadLine()
                    If Not String.IsNullOrWhiteSpace(line) Then
                        CategoryCb.Items.Add(line)
                        FilterCb.Items.Add(line)
                    End If
                Loop Until line Is Nothing
            End Using
        End If
    End Sub

    ' Method to populate the DataGridView with book data
    Private Sub Populate()
        Con.Open()
        Dim query = "SELECT * FROM BookTable"
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(query, Con)
        Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet = New DataSet
        adapter.Fill(ds)
        BookDGV.DataSource = ds.Tables(0)
        Con.Close()

        ' Capitalize the first letter of each column header
        For Each column As DataGridViewColumn In BookDGV.Columns
            column.HeaderText = CapitalizeFirstLetter(column.HeaderText)
        Next
    End Sub

    Private Sub Filter()
        Con.Open()
        Dim query = "SELECT * FROM BookTable where Category = '" & FilterCb.SelectedItem.ToString() & "'"
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(query, Con)
        Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet = New DataSet
        adapter.Fill(ds)
        BookDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    ' Method to reset the input fields
    Private Sub Reset()
        TitleTb.Clear()
        AuthorTb.Clear()
        CategoryCb.SelectedIndex = -1
        QuantityTb.Clear()
        PriceTb.Clear()
        BidTb.Text = "" ' Reset the selectedBookID
    End Sub

    Private Sub CancelLb_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    ' Method to delete a book from the database
    Private Sub DeleteBook(bookID As Integer)
        Try
            Using conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
                conn.Open()
                Dim query As String = "DELETE FROM BookTable WHERE Bid = @bookID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@bookID", bookID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Book Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error Deleting Book: " & ex.Message, "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' Method to handle the Delete button click
    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If BidTb.Text = -1 Then
            MessageBox.Show("Please Select A Book To Delete", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            DeleteBook(BidTb.Text)
            Populate()
            Reset()
        End If
    End Sub
    ' ... (Other code remains unchanged) ...

    ' Method to capitalize the first letter of a string
    Private Function CapitalizeFirstLetter(input As String) As String
            If String.IsNullOrEmpty(input) Then
                Return input
            End If
            Return Char.ToUpper(input(0)) & input.Substring(1)
        End Function





    ' Method to handle cell click in DataGridView
    Private Sub BookDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles BookDGV.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = BookDGV.Rows(e.RowIndex)
            BidTb.Text = If(IsDBNull(row.Cells("Bid").Value), String.Empty, Convert.ToInt32(row.Cells("Bid").Value)) ' Assuming 'Bid' is the column name for the book ID
            TitleTb.Text = row.Cells("Title").Value.ToString()
            AuthorTb.Text = row.Cells("Author").Value.ToString()
            CategoryCb.Text = row.Cells("Category").Value.ToString()
            QuantityTb.Text = row.Cells("Quantity").Value.ToString()
            PriceTb.Text = row.Cells("Price").Value.ToString()
        End If
    End Sub

    ' Method to handle the Edit button click
    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        If String.IsNullOrWhiteSpace(BidTb.Text) Then
            MessageBox.Show("Please Select A Book To Delete", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf String.IsNullOrWhiteSpace(TitleTb.Text) Or
               String.IsNullOrWhiteSpace(AuthorTb.Text) Or
               String.IsNullOrWhiteSpace(CategoryCb.Text) Or
               String.IsNullOrWhiteSpace(QuantityTb.Text) Or
               String.IsNullOrWhiteSpace(PriceTb.Text) Then
            MessageBox.Show("Missing Information", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                Using conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
                    conn.Open()
                    Dim query As String = "UPDATE BookTable SET Title = @title, Author = @author, Category = @category, Quantity = @quantity, Price = @price WHERE Bid = @bookID"
                    Using cmd As New SqlCommand(query, conn)
                        ' Add parameters to the SQL command
                        cmd.Parameters.AddWithValue("@title", TitleTb.Text)
                        cmd.Parameters.AddWithValue("@category", CategoryCb.Text)
                        cmd.Parameters.AddWithValue("@author", AuthorTb.Text)
                        cmd.Parameters.AddWithValue("@quantity", QuantityTb.Text)
                        cmd.Parameters.AddWithValue("@price", PriceTb.Text)
                        cmd.Parameters.AddWithValue("@bookID", Convert.ToInt32(BidTb.Text))

                        cmd.ExecuteNonQuery() ' Execute the SQL command
                    End Using
                End Using
                MessageBox.Show("Book Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Populate()
                Reset()
            Catch ex As Exception
                MessageBox.Show("Error Updating Book:" & ex.Message, "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        Reset()
    End Sub

    Private Sub FilterCb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterCb.SelectedIndexChanged
        Filter()
    End Sub

    Private Sub RefreshBtn_Click(sender As Object, e As EventArgs) Handles RefreshBtn.Click
        Populate()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        datelb.Text = Date.Now.ToString("yyyy-MM-dd")
    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click
        Dim obj = New User()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim obj = New Login()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Dim obj = New Record()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim obj = New Dashboard()
        obj.Show()
        Me.Hide()
    End Sub


End Class
