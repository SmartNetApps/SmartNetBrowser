Public Class NewHistoryForm

    Private Sub NewHistoryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        DataGridView1.Update()
    End Sub

    Private Sub PrivacySettingsButton_Click(sender As Object, e As EventArgs) Handles PrivacySettingsButton.Click
        SettingsForm.TabControl1.SelectedTab = SettingsForm.Confidentialité
        SettingsForm.Show()
        Me.Close()
    End Sub
End Class