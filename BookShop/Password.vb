Imports System.Data.SqlClient

Public Class Password
    ' Declare the connection variable
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")

    ' Event handler for the Cancel button click to close the form
    Private Sub CancelLb_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub



    ' Check if the username exists in the database
    Private Function UsernameExists(username As String) As Boolean
        Try
            Con.Open()
            Dim query As String = "SELECT COUNT(*) FROM UserTable WHERE Username = @username"
            Using cmd As New SqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@username", username)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking username: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Con.Close()
        End Try
    End Function

    ' Event handler for the Reset button click to reset the password
    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        ' Check if the username is empty
        If String.IsNullOrWhiteSpace(UsernameTb.Text) Then
            MessageBox.Show("Please enter a username.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if the new password is empty
        If String.IsNullOrWhiteSpace(NewPassswordTb.Text) Then
            MessageBox.Show("Please enter a new password.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if the confirm password is empty
        If String.IsNullOrWhiteSpace(ConfirmPassTb.Text) Then
            MessageBox.Show("Please confirm the new password.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if the new password and confirm password match
        If NewPassswordTb.Text <> ConfirmPassTb.Text Then
            MessageBox.Show("Passwords do not match.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if the username exists in the database
        If Not UsernameExists(UsernameTb.Text) Then
            MessageBox.Show("Username does not exist.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Open the database connection
            Con.Open()

            ' SQL query to update the user's password
            Dim query As String = "UPDATE UserTable SET Password = @password WHERE Username = @username"

            ' Create a new SqlCommand object with the query and connection
            Using cmd As New SqlCommand(query, Con)
                ' Add parameters to the SQL command
                cmd.Parameters.AddWithValue("@password", NewPassswordTb.Text)
                cmd.Parameters.AddWithValue("@username", UsernameTb.Text)

                ' Execute the SQL command
                cmd.ExecuteNonQuery()
            End Using

            ' Display a success message
            MessageBox.Show("Password updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Close the current form and show the login form
            Login.Show()
            Me.Close()
        Catch ex As Exception
            ' Display an error message if an exception occurs
            MessageBox.Show("Error updating password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the database connection
            Con.Close()
        End Try
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.Close()
        Login.Show()
    End Sub

    Private Sub TogglePasswordBtn_Click(sender As Object, e As EventArgs) Handles TogglePasswordBtn.Click
        ' Toggle the visibility of the password
        If ConfirmPassTb.PasswordChar = ControlChars.NullChar Then
            ConfirmPassTb.PasswordChar = "*"c  ' Hide the password
            TogglePasswordBtn.Text = "Show"
        Else
            ConfirmPassTb.PasswordChar = ControlChars.NullChar  ' Show the password
            TogglePasswordBtn.Text = "Hide"
        End If
    End Sub

End Class
