Imports System.ComponentModel

Public Class CreateBrowserSettingsSecurityPasswordForm
    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        If NewPasswordTextBox.Text = "" Then
            MsgBox("Vous n'avez rien tapé dans la case du nouveau mot de passe.", MsgBoxStyle.Information, "SmartNet Browser Protection des paramètres - Créer un mot de passe")
        Else
            My.Settings.BrowserSettingsSecurityPassword = BrowserForm.GetSHA512(NewPasswordTextBox.Text)
            My.Settings.BrowserSettingsSecurity = True
            SettingsForm.BrowserSettingsSecurityCheckBox.Checked = True
            SettingsForm.ChangeBrowserSettingsSecurityPasswordButton.Enabled = True
            Me.Close()
        End If
    End Sub

    Private Sub AbortButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
        My.Settings.BrowserSettingsSecurity = False
        SettingsForm.BrowserSettingsSecurityCheckBox.Checked = False
        SettingsForm.ChangeBrowserSettingsSecurityPasswordButton.Enabled = False
        Me.Close()
    End Sub

    Private Sub CreateBrowserSettingsSecurityPasswordForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        NewPasswordTextBox.Text = ""
    End Sub
End Class