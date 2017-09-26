Public Class AdBlockerWhitelistForm
    Private Sub AdBlockerWhitelistForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        RichTextBox1.Text = My.Settings.AllowAdsSites
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Si vous constatez un problème avec le bloqueur de publicités, essayez de vider la whitelist puis rechargez la page", MsgBoxStyle.Information, "SmartNet Ads Blocker")
        My.Settings.AllowAdsSites = RichTextBox1.Text
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class