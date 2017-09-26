Public Class NewHistoryForm
    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Me.BrowserHistoryDataSet.History.RemoveHistoryRow(0)
    End Sub
End Class