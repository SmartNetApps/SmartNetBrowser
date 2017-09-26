Imports System.ComponentModel

Public Class CreateChildrenProtectionPasswordForm
    Private Sub AbortButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
        My.Settings.ChildrenProtection = False
        SettingsForm.ChangeChildrenProtectionPasswordButton.Enabled = False
        SettingsForm.ChildrenProtectionCheckBox.Checked = False
        EnterChildrenProtectionForm.Close()
        Me.Close()
    End Sub

    Private Sub CreateChildrenProtectionPasswordForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        NewPasswordTextBox.Text = ""
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        If NewPasswordTextBox.Text = "" Then
            MsgBox("Vous n'avez rien tapé dans la case du nouveau mot de passe.", MsgBoxStyle.Information, "SmartNet ChildGuard - Créer un mot de passe")
        Else
            My.Settings.ChildrenProtectionPassword = BrowserForm.GetSHA512(NewPasswordTextBox.Text)
            My.Settings.ChildrenProtection = True
            SettingsForm.ChangeChildrenProtectionPasswordButton.Enabled = True
            SettingsForm.ChildrenProtectionCheckBox.Checked = True
            MsgBox("Notez bien que ce système de contrôle parental ne s'applique qu'à SmartNet Browser. Par conséquent, si votre enfant navigue avec un autre navigateur, il pourrait ne pas être protégé. Nous vous recommandons d'installer un contrôle parental complet ou d'empêcher l'exécution d'un autre navigateur", MsgBoxStyle.Information, "SmartNet ChildGuard")
            Me.Close()
        End If
    End Sub
End Class