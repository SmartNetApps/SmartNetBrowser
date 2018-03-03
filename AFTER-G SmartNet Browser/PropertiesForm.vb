Public Class PropertiesForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub
End Class