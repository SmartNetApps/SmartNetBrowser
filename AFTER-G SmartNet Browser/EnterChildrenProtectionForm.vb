Imports System.ComponentModel

Public Class EnterChildrenProtectionForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        If BrowserForm.GetSHA512(PasswordTextBox.Text) = My.Settings.ChildrenProtectionPassword Then
            My.Settings.ChildrenProtection = False
            SettingsForm.ChangeChildrenProtectionPasswordButton.Enabled = False
            SettingsForm.ChildrenProtectionCheckBox.Checked = False
            PasswordTextBox.Text = ""
            Me.Close()
        Else
            MsgBox("Mot de passe incorrect", MsgBoxStyle.Critical, "SmartNet ChildGuard - Saisie du mot de passe")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
        My.Settings.ChildrenProtection = True
        SettingsForm.ChangeChildrenProtectionPasswordButton.Enabled = True
        SettingsForm.ChildrenProtectionCheckBox.Checked = True
        CreateChildrenProtectionPasswordForm.Close()
        Me.Close()
    End Sub

    Private Sub EnterChildrenProtectionForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        PasswordTextBox.Text = ""
    End Sub
End Class