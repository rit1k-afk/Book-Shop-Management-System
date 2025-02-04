Public Class Splash

    ' This event is triggered every time the Timer ticks
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Increment the progress bar by 1
        ProgressBar1.Increment(1)

        ' Update the text of the PercentageLbl to show the current progress
        PercentageLbl.Text = Convert.ToString(ProgressBar1.Value) + "%"

        ' Check if the progress bar has reached 100%
        If ProgressBar1.Value = 100 Then
            ' If the progress bar has reached 100%, hide the splash screen
            Me.Hide()

            ' Create a new instance of the Login form
            Dim log = New Home

            ' Show the Login form
            log.Show()

            ' Disable the Timer as its job is done
            Timer1.Enabled = False
        End If
    End Sub

    ' This event is triggered when the Splash form is loaded
    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Start the Timer when the form is loaded
        Timer1.Start()
    End Sub
End Class
