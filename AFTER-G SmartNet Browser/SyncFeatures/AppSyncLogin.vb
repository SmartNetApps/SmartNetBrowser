
<Obsolete("Migré vers MajestiCloud v3.")>
Public Class AppSyncLogin
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Button_Connecter_Click(sender As Object, e As EventArgs) Handles Button_Connecter.Click
        If TextBox_Email.Text <> "" And TextBox_MDP.Text <> "" Then
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
                MessageBox.Show("Le serveur de SmartNet AppSync a retourné une erreur (" + ex.Message + "). Veuillez réessayer plus tard ou contacter l'assistance technique.", "SmartNet AppSync", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Button_CreerCompte_Click(sender As Object, e As EventArgs) Handles Button_CreerCompte.Click
        BrowserForm.AddTab("https://appsync.lesmajesticiels.org/newaccount.php")
        Me.Close()
    End Sub

    Private Sub LinkLabel_MDPOublie_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_MDPOublie.LinkClicked
        BrowserForm.AddTab("https://appsync.lesmajesticiels.org/passwordrecovery.php")
        Me.Close()
    End Sub
End Class