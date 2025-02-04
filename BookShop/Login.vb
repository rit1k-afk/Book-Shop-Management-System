Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Login
    ' Declare command and connection variables
    Dim cmd As SqlCommand
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")

    ' Event handler for Cancel button click to exit the application
    Private Sub CancelLb_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub Reset()
        ' Clear the text of all input fields
        UsernameTb.Clear()
        PasswordTb.Clear()
        LoginRoleCb.SelectedIndex = -1
    End Sub

    ' Event handler for Forgot Password label click to show the Password form
    Private Sub ForgotPasswordLb_Click(sender As Object, e As EventArgs) Handles ForgotPasswordLb.Click
        Password.Show()
        Me.Hide()
    End Sub

    ' Event handler for Cancel button click to exit the application
    Private Sub CancelLb_Click_1(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    ' Event handler for Login button click to authenticate the user
    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        ' Check if username or password fields are empty

        If UsernameTb.Text = "" Then
            Dim result2 As DialogResult = MessageBox.Show("Please Enter Username", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf PasswordTb.Text = "" Then
            Dim result2 As DialogResult = MessageBox.Show("Please Enter Password", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf LoginRoleCb.SelectedIndex = -1 Then
            Dim result2 As DialogResult = MessageBox.Show("Pleasse Select Role", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else
            Try
                ' Open the database connection
                Con.Open()

                ' SQL query to select the user with the provided username, password, and role
                Dim query = "SELECT * FROM UserTable WHERE Username = @Username AND Password = @Password AND Role = @Role"
                cmd = New SqlCommand(query, Con)

                ' Add parameters to the SQL command to prevent SQL injection
                cmd.Parameters.AddWithValue("@Username", UsernameTb.Text)
                cmd.Parameters.AddWithValue("@Password", PasswordTb.Text)
                cmd.Parameters.AddWithValue("@Role", LoginRoleCb.SelectedItem.ToString())

                ' Execute the query and fill the result into a DataSet
                Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()
                sda.Fill(ds)

                ' Check if any matching user is found
                Dim a As Integer = ds.Tables(0).Rows.Count

                If a = 0 Then
                    ' Show error message if no matching user is found
                    Dim result2 As DialogResult = MessageBox.Show("Wrong Username or Password", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Else
                    ' Open the appropriate form based on the selected role
                    If LoginRoleCb.SelectedItem.ToString() = "Admin" Then
                        Dim Dashboard = New Dashboard
                        Dashboard.Show()
                    ElseIf LoginRoleCb.SelectedItem.ToString() = "User" Then
                        Dim Bill = New Bills
                        Bill.UserName = UsernameTb.Text
                        Bill.Show()
                    End If
                    ' Hide the login form
                    Me.Close()
                End If
            Catch ex As Exception
                ' Show error message if an exception occurs
                Dim result2 As DialogResult = MessageBox.Show("Error: " & ex.Message, "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                ' Ensure the connection is closed
                Con.Close()
            End Try
        End If

    End Sub


    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.Close()
    End Sub

    Private Sub AddNewUser(username As String, name As String, address As String, phone As String, password As String, role As String)
        Try
            Using conn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
                conn.Open() ' Open the database connection
                Dim query As String = "INSERT INTO UserTable (Username, Name, Address, Phone, Password, Role) VALUES (@username, @name, @address, @phone, @password, @role)"
                Using cmd As New SqlCommand(query, conn)
                    ' Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@name", name)
                    cmd.Parameters.AddWithValue("@address", address)
                    cmd.Parameters.AddWithValue("@phone", phone)
                    cmd.Parameters.AddWithValue("@password", password)
                    cmd.Parameters.AddWithValue("@role", role)
                    cmd.ExecuteNonQuery() ' Execute the SQL command
                End Using
            End Using
            Dim result2 As DialogResult = MessageBox.Show("SignedUp Successfully, Please Login", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Dim result2 As DialogResult = MessageBox.Show("Error: " & ex.Message, "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub




    ' Validate Phone number input
    Private Sub PhoneTb_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Allow only digits and control keys (backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Dim result2 As DialogResult = MessageBox.Show("Phone Number Expected", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    ' Validate Username input
    Private Sub UNameTb_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Allow only letters, digits, and control keys (backspace)
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Dim result2 As DialogResult = MessageBox.Show("Usssername cannot contain space", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    ' Validate Name input
    Private Sub NameTb_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Allow only letters and control keys (backspace)
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
            Dim result2 As DialogResult = MessageBox.Show("Name can only conatins letter", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Private Sub TogglePasswordBtn_Click(sender As Object, e As EventArgs) Handles TogglePasswordBtn.Click
        ' Toggle the visibility of the password
        If PasswordTb.PasswordChar = ControlChars.NullChar Then
            PasswordTb.PasswordChar = "*"c  ' Hide the password
            TogglePasswordBtn.Text = "Show"
        Else
            PasswordTb.PasswordChar = ControlChars.NullChar  ' Show the password
            TogglePasswordBtn.Text = "Hide"
        End If
    End Sub

End Class
