Public Class AdBlockerWhitelistForm
    Private Sub AdBlockerWhitelistForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        WhitelistRichTextBox.Text = My.Settings.AllowAdsSites
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        MsgBox("Si vous constatez un problème avec le bloqueur de publicités, essayez de vider la whitelist puis rechargez la page", MsgBoxStyle.Information, "SmartNet Ads Blocker")
        My.Settings.AllowAdsSites = WhitelistRichTextBox.Text
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
        Me.Close()
    End Sub
End Class