Public Class PropertiesForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub PropertiesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If FaviconBox.Image.Width > FaviconBox.Width Or FaviconBox.Image.Height > FaviconBox.Height Then
            FaviconBox.SizeMode = PictureBoxSizeMode.Zoom
        Else
            FaviconBox.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub
End Class