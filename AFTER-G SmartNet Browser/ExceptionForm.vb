Public Class ExceptionForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ForceCloseButton_Click(sender As Object, e As EventArgs) Handles ForceCloseButton.Click
        Me.Close()
        My.Settings.Save()
        Application.Exit()
        End
    End Sub

    Private Sub IgnoreButton_Click(sender As Object, e As EventArgs) Handles IgnoreButton.Click
        Me.Close()
    End Sub
End Class