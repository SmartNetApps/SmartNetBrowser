Public Class AppSyncLogin
    Dim agent As New AppSyncAgent
    Private Sub Button_Connecter_Click(sender As Object, e As EventArgs) Handles Button_Connecter.Click
        If agent.CheckCredentials(TextBox_Email.Text, TextBox_MDP.Text) Then
            My.Settings.Save()
            agent.RegisterDevice()
            BrowserForm.SeConnecterÀAppSyncToolStripMenuItem.Text = agent.GetUserName()
            BrowserForm.SeConnecterÀAppSyncToolStripMenuItem.Image = agent.GetUserProfilePicture()
            agent.SyncNow()
            Me.Close()
        Else
            MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "SmartNet AppSync", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Button_CreerCompte_Click(sender As Object, e As EventArgs) Handles Button_CreerCompte.Click
        BrowserForm.AddTab("https://appsync.quentinpugeat.fr/newaccount.php", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub LinkLabel_MDPOublie_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_MDPOublie.LinkClicked
        BrowserForm.AddTab("https://appsync.quentinpugeat.fr/passwordrecovery.php", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub
End Class