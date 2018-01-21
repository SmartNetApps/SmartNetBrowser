Public Class NewHistoryForm
    Private Sub NewHistoryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each Page In CType(My.Settings.NewHistory, List(Of Webpage))
            ListBox1.Items.AddRange({Page.GetName(), Page.GetURL(), Page.GetFavicon()})
        Next
    End Sub
End Class