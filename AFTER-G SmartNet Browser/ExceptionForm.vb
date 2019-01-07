Public Class ExceptionForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ForceCloseButton_Click(sender As Object, e As EventArgs) Handles ForceCloseButton.Click
        My.Settings.Save()
        Environment.Exit(1)
    End Sub

    Private Sub IgnoreButton_Click(sender As Object, e As EventArgs) Handles IgnoreButton.Click
        Me.Close()
    End Sub

    Public Sub SetException(exception As Exception)
        MessageTextBox.Text = exception.Message
        DetailsTextBox.Text = exception.StackTrace
    End Sub
End Class