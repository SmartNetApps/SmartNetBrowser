Imports System.ComponentModel

Public Class ChangeBrowserSettingsSecurityPasswordForm
    Private Sub SavePasswordButton_Click(sender As Object, e As EventArgs) Handles SavePasswordButton.Click
        If BrowserForm.GetSHA512(ActualPasswordTextBox.Text) = My.Settings.BrowserSettingsSecurityPassword Then
            If NewPasswordTextBox.Text = "" Then
                MsgBox("Vous n'avez rien tapé dans la case du nouveau mot de passe.", MsgBoxStyle.Information, "SmartNet Browser Protection des paramètres - Changer le mot de passe")
            Else
                My.Settings.BrowserSettingsSecurityPassword = BrowserForm.GetSHA512(NewPasswordTextBox.Text)
                Me.Close()
            End If
        Else
            MsgBox("Mot de passe incorrect", MsgBoxStyle.Critical, "SmartNet Browser Protection des paramètres - Changer le mot de passe")
        End If
    End Sub

    Private Sub KeepCurrentSettingsButton_Click(sender As Object, e As EventArgs) Handles KeepCurrentSettingsButton.Click
        Me.Close()
    End Sub

    Private Sub ChangeBrowserSettingsSecurityPasswordForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ActualPasswordTextBox.Text = ""
        NewPasswordTextBox.Text = ""
    End Sub
End Class