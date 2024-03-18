Public Class LicenseForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub LicenseForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class