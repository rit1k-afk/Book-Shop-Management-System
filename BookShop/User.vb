Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class User
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")



    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Populate() ' Populate the DataGridView when the form loads
    End Sub

    Private Sub Populate()
        Con.Open() ' Open the database connection
        Dim query = "SELECT username, name, address, phone, password, role, creationDate FROM UserTable" ' SQL query to select all records from UserTable
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(query, Con) ' Create a data adapter
        Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter) ' Create a command builder
        Dim ds As DataSet = New DataSet ' Create a new DataSet
        adapter.Fill(ds) ' Fill the DataSet with data from the adapter
        UserDGV.DataSource = ds.Tables(0) ' Set the DataGridView data source to the first table in the DataSet
        Con.Close() ' Close the database connection

        ' Capitalize the first letter of each column header
        For Each column As DataGridViewColumn In UserDGV.Columns
            column.HeaderText = CapitalizeFirstLetter(column.HeaderText)
        Next
    End Sub

    ' Method to capitalize the first letter of a string
    Private Function CapitalizeFirstLetter(input As String) As String
        If String.IsNullOrEmpty(input) Then
            Return input
        End If
        Return Char.ToUpper(input(0)) & input.Substring(1)
    End Function

    Private Sub Reset()
        ' Clear the text of all input fields
        UsernameTb.Clear()
        NameTb.Clear()
        AddressTb.Clear()
        PhoneTb.Clear()
        PasswordTb.Clear()


        ' Reset the selected index of the RoleCb ComboBox
        RoleCb.SelectedIndex = -1
    End Sub

    Private Function UsernameExists(username As String) As Boolean
        Dim exists As Boolean = False
        Using conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
            conn.Open()
            Dim query As String = "SELECT COUNT(*) FROM UserTable WHERE Username = @username"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)
                exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using
        End Using
        Return exists
    End Function

    Private Sub AddUser(username As String, name As String, address As String, phone As String, password As String, role As String, creationDate As DateTime)
        Try
            Using conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
                conn.Open() ' Open the database connection
                Dim query As String = "INSERT INTO UserTable (Username, Name, Address, Phone, Password, Role, creationDate) VALUES (@username, @name, @address, @phone, @password, @role, @creationDate)"
                Using cmd As New SqlCommand(query, conn)
                    ' Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@name", name)
                    cmd.Parameters.AddWithValue("@address", address)
                    cmd.Parameters.AddWithValue("@phone", phone)
                    cmd.Parameters.AddWithValue("@password", password)
                    cmd.Parameters.AddWithValue("@role", role)
                    cmd.Parameters.AddWithValue("@creationDate", creationDate)
                    cmd.ExecuteNonQuery() ' Execute the SQL command
                End Using
            End Using
            Dim result2 As DialogResult = MessageBox.Show("User Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Dim result2 As DialogResult = MessageBox.Show("Error Adding User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        ' Validate the Phone number
        If Not Regex.IsMatch(PhoneTb.Text, "^\d{10}$") Then
            Dim result2 As DialogResult = MessageBox.Show("Phone number must be exactly 10 digits.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if any of the fields are empty
        If String.IsNullOrWhiteSpace(UsernameTb.Text) Or String.IsNullOrWhiteSpace(NameTb.Text) Or String.IsNullOrWhiteSpace(AddressTb.Text) Or String.IsNullOrWhiteSpace(PhoneTb.Text) Or String.IsNullOrWhiteSpace(PasswordTb.Text) Or RoleCb.SelectedIndex = -1 Then
            Dim result2 As DialogResult = MessageBox.Show("Missing Information", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return ' Exit the method if any fields are empty
        End If

        ' Check if the username already exists
        If UsernameExists(UsernameTb.Text) Then
            Dim result2 As DialogResult = MessageBox.Show("Username already taken.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Add the user to the database
        AddUser(UsernameTb.Text, NameTb.Text, AddressTb.Text, PhoneTb.Text, PasswordTb.Text, RoleCb.SelectedItem.ToString(), DateLb.Text)

        ' Close the connection and reset the fields
        Populate()
        Reset()
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        ' Check if a user is selected
        If String.IsNullOrWhiteSpace(UsernameTb.Text) Then
            Dim result2 As DialogResult = MessageBox.Show("Select A User To Delete", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Open the database connection
            Con.Open()

            ' SQL query to delete the selected user
            Dim query As String = "DELETE FROM UserTable WHERE Username = @username"

            ' Create a new SqlCommand object with the query and connection
            Using cmd As New SqlCommand(query, Con)
                ' Add parameter to the SQL command
                cmd.Parameters.AddWithValue("@username", UsernameTb.Text)

                ' Execute the SQL command
                cmd.ExecuteNonQuery()
            End Using

            ' Close the database connection
            Con.Close()

            Dim result2 As DialogResult = MessageBox.Show("User Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Populate the DataGridView with updated data
            Populate()
            ' Reset the input fields
            Reset()
        Catch ex As Exception
            ' Display an error message if an exception occurs
            Dim result2 As DialogResult = MessageBox.Show("Error: " & ex.Message, "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub UserDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles UserDGV.CellMouseClick
        ' Check if the clicked cell is not a header
        If e.RowIndex >= 0 Then
            ' Get the DataGridViewRow corresponding to the clicked cell
            Dim row As DataGridViewRow = UserDGV.Rows(e.RowIndex)

            ' Populate the input fields with the data from the selected row
            UsernameTb.Text = row.Cells("Username").Value.ToString()
            NameTb.Text = row.Cells("Name").Value.ToString()
            AddressTb.Text = row.Cells("Address").Value.ToString()
            PhoneTb.Text = row.Cells("Phone").Value.ToString()
            PasswordTb.Text = row.Cells("Password").Value.ToString()
            RoleCb.SelectedItem = row.Cells("Role").Value.ToString()
            DateLb.Text = Convert.ToDateTime(row.Cells("creationDate").Value.ToString())
        End If
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        ' Validate the Phone number
        If Not Regex.IsMatch(PhoneTb.Text, "^\d{10}$") Then
            Dim result2 As DialogResult = MessageBox.Show("Phone number must be exactly 10 digits.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if any of the fields are empty
        If String.IsNullOrWhiteSpace(UsernameTb.Text) Or String.IsNullOrWhiteSpace(NameTb.Text) Or String.IsNullOrWhiteSpace(AddressTb.Text) Or String.IsNullOrWhiteSpace(PhoneTb.Text) Or String.IsNullOrWhiteSpace(PasswordTb.Text) Or RoleCb.SelectedIndex = -1 Then
            Dim result2 As DialogResult = MessageBox.Show("Missing Information", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return ' Exit the method if any fields are empty
        End If

        ' Get the selected role from the ComboBox
        Dim selectedRole As String = RoleCb.SelectedItem.ToString()

        Try
            ' Open the database connection
            Con.Open()

            ' SQL query to update the user's information
            Dim query As String = "UPDATE UserTable SET Name = @name, Address = @address, Phone = @phone, Password = @password, Role = @role WHERE Username = @username"

            ' Create a new SqlCommand object with the query and connection
            Using cmd As New SqlCommand(query, Con)
                ' Add parameters to the SQL command
                cmd.Parameters.AddWithValue("@name", NameTb.Text)
                cmd.Parameters.AddWithValue("@address", AddressTb.Text)
                cmd.Parameters.AddWithValue("@phone", PhoneTb.Text)
                cmd.Parameters.AddWithValue("@password", PasswordTb.Text)
                cmd.Parameters.AddWithValue("@role", selectedRole)
                cmd.Parameters.AddWithValue("@username", UsernameTb.Text)

                ' Execute the SQL command
                cmd.ExecuteNonQuery()
            End Using

            ' Close the database connection
            Con.Close()

            Dim result2 As DialogResult = MessageBox.Show("User Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Populate the DataGridView with updated data
            Populate()
            ' Reset the input fields
            Reset()
        Catch ex As Exception
            ' Display an error message if an exception occurs
            Dim result2 As DialogResult = MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        Reset()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)
        Dim obj = New Book()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)
        Dim obj = New Dashboard()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)
        Dim obj = New Login()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs)
        Dim obj = New Record()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateLb.Text = Date.Now.ToString("dd-MM-yyyy")
    End Sub



    Private Sub Label12_Click_1(sender As Object, e As EventArgs) Handles Label12.Click
        Dim obj = New Login()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click_1(sender As Object, e As EventArgs) Handles Label4.Click
        Dim obj = New Book()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label10_Click_1(sender As Object, e As EventArgs) Handles Label10.Click
        Dim obj = New Dashboard()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label14_Click_1(sender As Object, e As EventArgs) Handles Label14.Click
        Dim obj = New Record()
        obj.Show()
        Me.Hide()
    End Sub

    ' Add other event handlers and methods as needed...
End Class
