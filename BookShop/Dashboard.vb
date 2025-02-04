Imports System.Data.SqlClient
Public Class Dashboard
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\BookShop\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub CountBook()
        con.Open()
        Dim BookNum As Integer
        Dim sql = "select COUNT(*) from BookTable"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, con)
        BookNum = cmd.ExecuteScalar
        BookNumlb.Text = BookNum
        con.Close()
    End Sub

    Private Sub CountUser()
        con.Open()
        Dim UserNum As Integer
        Dim sql = "select COUNT(*) from UserTable"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, con)
        UserNum = cmd.ExecuteScalar
        UserNumLb.Text = UserNum
        con.Close()
    End Sub

    Private Sub SumAmount()
        Try
            con.Open()
            Dim AmountNum As Integer
            Dim sql = "select SUM(Amount) from BillTbl"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(sql, con)

            ' Check if the result is DBNull and handle it accordingly
            Dim result = cmd.ExecuteScalar()
            If IsDBNull(result) Then
                AmountNum = 0 ' or any default value you prefer
            Else
                AmountNum = Convert.ToInt32(result)
            End If

            AmountNumLb.Text = "Rs. " + Convert.ToString(AmountNum)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        CountBook()
        CountUser()
        SumAmount()
    End Sub

    Private Sub CancelLb_Click(sender As Object, e As EventArgs) 
        Application.Exit()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim obj = New Book()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim obj = New User()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim obj = New Login()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim obj = New Record()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Dim obj = New Book()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Dim obj = New User()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateLb.Text = Date.Now.ToString("dd-MM-yyyy")
    End Sub
End Class