Imports System.ComponentModel

Public Class ChangeChildrenProtectionPasswordForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub SavePasswordButton_Click(sender As Object, e As EventArgs) Handles SavePasswordButton.Click
        If BrowserForm.GetSHA512(ActualPasswordTextBox.Text) = My.Settings.ChildrenProtectionPassword Then
            If NewPasswordTextBox.Text = "" Then
                MsgBox("Vous n'avez rien tapé dans la case du nouveau mot de passe.", MsgBoxStyle.Information, "SmartNet ChildGuard - Changer le mot de passe")
            Else
                My.Settings.ChildrenProtectionPassword = BrowserForm.GetSHA512(NewPasswordTextBox.Text)
                Me.Close()
            End If
        Else
            MsgBox("Mot de passe incorrect", MsgBoxStyle.Critical, "SmartNet ChildGuard - Changer le mot de passe")
        End If
    End Sub

    Private Sub KeepCurrentSettingsButton_Click(sender As Object, e As EventArgs) Handles KeepCurrentSettingsButton.Click
        Me.Close()
    End Sub

    Private Sub ChangeChildrenProtectionPasswordForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        NewPasswordTextBox.Text = ""
        ActualPasswordTextBox.Text = ""
    End Sub
End Class