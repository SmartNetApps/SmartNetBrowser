Imports System.Net
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.Devices

Namespace My
    ' Les événements suivants sont disponibles pour MyApplication :
    ' Startup : déclenché au démarrage de l'application avant la création du formulaire de démarrage.
    ' Shutdown : déclenché après la fermeture de tous les formulaires de l'application. Cet événement n'est pas déclenché si l'application se termine de façon anormale.
    ' UnhandledException : déclenché si l'application rencontre une exception non gérée.
    ' StartupNextInstance : déclenché lors du lancement d'une application à instance unique et si cette application est déjà active. 
    ' NetworkAvailabilityChanged : déclenché lorsque la connexion réseau est connectée ou déconnectée.
    Partial Friend Class MyApplication
        Private Sub MyApplication_NetworkAvailabilityChanged(sender As Object, e As NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
            If e.IsNetworkAvailable = False Then
                MsgBox("Il semblerait que SmartNet Browser n'arrive plus à se connecter. Veuillez vérifier votre connexion réseau. Vérifiez que votre pare-feu et votre antivirus autorisent SmartNet Browser à se connecter à Internet.", MsgBoxStyle.Critical, "Connexion Internet indisponible :(")
            End If
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            If My.Settings.DeleteCookiesWhileClosing = True Then
                Gecko.CookieManager.RemoveAll()
                BrowserForm.StatusLabel.Text = "Effacement des cookies..."
            End If
            Gecko.Xpcom.Shutdown()
            My.Settings.Save()
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            Try
                If Screen.PrimaryScreen.Bounds.Width < 1024 Or Screen.PrimaryScreen.Bounds.Height < 768 Then
                    MsgBox("Votre ordinateur est configuré pour afficher une résolution inférieure à 1024x768 pixels. Certaines pages Web peuvent ne pas s'afficher correctement. Pour configurer la résolution, faites un clic droit sur le Bureau et sélectionnez ""Résolution d'écran"" ou ""Paramètres d'affichage"". Poussez le curseur vers la droite (ou le haut) jusqu'à 1024x768 ou plus.", CType(MessageBoxIcon.Exclamation, MsgBoxStyle), "Problème avec la résolution d'écran")
                End If
                Gecko.Xpcom.Initialize("Firefox")
                Select Case My.Settings.SearchEngine
                    Case 1
                        BrowserForm.SearchBoxLabel.Text = "Google"
                    Case 2
                        BrowserForm.SearchBoxLabel.Text = "Bing"
                    Case 3
                        BrowserForm.SearchBoxLabel.Text = "Yahoo!"
                    Case 4
                        BrowserForm.SearchBoxLabel.Text = "DuckDuckGo"
                    Case 5
                        BrowserForm.SearchBoxLabel.Text = "Qwant"
                    Case 0
                        BrowserForm.SearchBoxLabel.Text = My.Settings.CustomSearchName
                End Select
            Catch ex As Exception
            End Try
            Try
                Dim MiniNTVersionChecker As New WebClient
                Dim NTActualVersion As Version = Environment.OSVersion.Version
                Dim MiniNTVersion As Version = New Version(MiniNTVersionChecker.DownloadString("http://quentinpugeat.pagesperso-orange.fr/downloads/smartnet-browser/MinimumNTVersion.txt"))
                Dim MAJ As New WebClient
                Dim VersionActuelle As Version = My.Application.Info.Version
                Dim DerniereVersion As Version = New Version(MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/downloads/smartnet-browser/smartnetbrowser-version.txt"))
                Dim SupportStatus As String = MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/downloads/smartnet-browser/support-status.txt")
                If VersionActuelle > DerniereVersion Then
                    MsgBox("Vous utilisez une version préliminaire de SmartNet Browser. Vous pourriez trouver des beugs ou incohérences, mais merci de ne pas les signaler tant que cette version n'est pas publiée. Veuillez nous contacter si vous pensez qu'il s'agit d'une erreur.", MsgBoxStyle.Exclamation, "Version préliminaire")
                    BrowserForm.EnvoyerVosCommentairesToolStripMenuItem.Enabled = False
                    GoTo StopVersionChecking
                End If
                If My.Settings.AutoUpdates = True Then
                    If NTActualVersion < MiniNTVersion Then
                        MsgBox("Votre système d'exploitation n'est plus pris en charge par SmartNet Apps. Visitez le site SmartNet Apps pour en savoir plus à ce sujet. La recherche automatique de mises à jour à été désactivée.", MsgBoxStyle.Exclamation, "Avertissement")
                        My.Settings.AutoUpdates = False
                        My.Settings.Save()
                        BrowserForm.NouvelleVersionDisponibleSubMenu.Visible = False
                        GoTo StopVersionChecking
                    End If
                    If SupportStatus = "on" Then
                        If VersionActuelle < DerniereVersion Then
                            BrowserForm.UpdateNotifyIcon.Visible = True
                            BrowserForm.UpdateNotifyIcon.ShowBalloonTip(1000)
                            BrowserForm.NouvelleVersionDisponibleSubMenu.Visible = True
                            BrowserForm.TéléchargerLaVersionXXXXToolStripMenuItem.Text = "Télécharger la version " + DerniereVersion.ToString
                        Else
                            BrowserForm.NouvelleVersionDisponibleSubMenu.Visible = False
                            GoTo StopVersionChecking
                        End If
                    Else
                        BrowserForm.NouvelleVersionDisponibleSubMenu.Visible = False
                        MsgBox("Le support et le développement de ce produit ont été interrompus. Visitez le site SmartNet Apps pour en savoir plus.", MsgBoxStyle.Critical, "Service interrompu")
                        GoTo StopVersionChecking
                    End If
                End If
StopVersionChecking:
            Catch ex As Exception
                MsgBox("La connexion à SmartNet Apps Updater a échoué : " + ex.Message, MsgBoxStyle.Critical, "SmartNet Apps Updater")
            End Try
        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = e.Exception.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & e.Exception.Source & vbCrLf & e.Exception.GetType.ToString & vbCrLf & e.Exception.StackTrace
                ExceptionForm.ShowDialog()
            Else
                e.ExitApplication = False
            End If
        End Sub
    End Class
End Namespace
