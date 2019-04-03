Public Class AppSyncLogin
    Private Sub Button_Connecter_Click(sender As Object, e As EventArgs) Handles Button_Connecter.Click
        Try
            If AppSyncAgent.CheckCredentials(TextBox_Email.Text, TextBox_MDP.Text) Then
                My.Settings.Save()
                If AppSyncAgent.RegisterDevice(TextBox_Email.Text, TextBox_MDP.Text) Then
                    BrowserForm.SeConnecterÀAppSyncToolStripMenuItem.Text = AppSyncAgent.GetUserName()
                    BrowserForm.SeConnecterÀAppSyncToolStripMenuItem.Image = AppSyncAgent.GetUserProfilePicture()
                Else
                    MessageBox.Show("SmartNet AppSync n'a pas réussi à enregistrer votre appareil. Veuillez réessayer plus tard ou contacter l'assistance technique.", "SmartNet AppSync", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Close()
            Else
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "SmartNet AppSync", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show("Impossible de se connecter avec les serveurs de SmartNet AppSync en raison d'une erreur interne (" + ex.Message + " - " + ex.Message + "). Veuillez réessayer plus tard ou contacter l'assistance technique.", "SmartNet AppSync", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_CreerCompte_Click(sender As Object, e As EventArgs) Handles Button_CreerCompte.Click
        BrowserForm.AddTab("https://appsync.quentinpugeat.fr/newaccount.php")
        Me.Close()
    End Sub

    Private Sub LinkLabel_MDPOublie_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_MDPOublie.LinkClicked
        BrowserForm.AddTab("https://appsync.quentinpugeat.fr/passwordrecovery.php")
        Me.Close()
    End Sub
End Class