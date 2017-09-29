Public Class NewHistoryForm

    Private Sub NewHistoryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'DataGridView1.Update()
    End Sub

    Private Sub PrivacySettingsButton_Click(sender As Object, e As EventArgs) Handles PrivacySettingsButton.Click
        SettingsForm.TabControl1.SelectedTab = SettingsForm.Confidentialité
        If My.Settings.BrowserSettingsSecurity = True Then
            EnterBrowserSettingsSecurityForm.SecurityMode = "Settings"
            EnterBrowserSettingsSecurityForm.ShowDialog()
        Else
            SettingsForm.Show()
        End If
        Me.Close()
    End Sub
End Class