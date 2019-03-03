Public Class AppSyncLogin
    Dim agent As New AppSyncAgent
    Private Sub Button_Connecter_Click(sender As Object, e As EventArgs) Handles Button_Connecter.Click
        Try
            If agent.CheckCredentials(TextBox_Email.Text, TextBox_MDP.Text) Then
                My.Settings.Save()
                agent.RegisterDevice(TextBox_Email.Text, TextBox_MDP.Text)
                BrowserForm.SeConnecterÀAppSyncToolStripMenuItem.Text = agent.GetUserName()
                BrowserForm.SeConnecterÀAppSyncToolStripMenuItem.Image = agent.GetUserProfilePicture()
                agent.SyncNow()
                Me.Close()
            Else
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "SmartNet AppSync", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show("Impossible de se connecter avec les serveurs de SmartNet AppSync en raison d'une erreur interne (" + ex.GetBaseException().Message + "). Veuillez réessayer plus tard ou contacter l'assistance technique.", "SmartNet AppSync", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_CreerCompte_Click(sender As Object, e As EventArgs) Handles Button_CreerCompte.Click
        BrowserForm.AddTab("https://smartnetappsync.wampserver/newaccount.php", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub LinkLabel_MDPOublie_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_MDPOublie.LinkClicked
        BrowserForm.AddTab("https://smartnetappsync.wampserver/passwordrecovery.php", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub
End Class