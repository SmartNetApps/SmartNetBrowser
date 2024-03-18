Imports System.Configuration
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
                BrowserForm.msgBar = New MessageBar(MessageBar.MessageBarLevel.Critical, "SmartNet Browser ne parvient pas à se connecter à Internet. Veuillez vérifier les paramètres réseau de votre ordinateur.", MessageBar.MessageBarAction.OpenInternetSettings, "Ouvrir les paramètres Windows")
                BrowserForm.DisplayMessageBar()
            Else
                CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser).Refresh()
            End If
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            If My.Settings.DeleteCookiesWhileClosing = True Then
                Gecko.CookieManager.RemoveAll()
                BrowserForm.StatusLabel.Text = "Effacement des cookies..."
            End If
            Gecko.Xpcom.Shutdown()
            My.Settings.CorrectlyClosed = True
            My.Settings.Save()
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            If Screen.PrimaryScreen.Bounds.Width < 1024 Or Screen.PrimaryScreen.Bounds.Height < 768 Then
                MessageBox.Show("Votre ordinateur est configuré pour afficher une résolution inférieure à 1024x768 pixels. Certaines pages Web peuvent ne pas s'afficher correctement. Pour configurer la résolution, faites un clic droit sur le Bureau et sélectionnez ""Résolution d'écran"" ou ""Paramètres d'affichage"". Poussez le curseur vers la droite (ou le haut) jusqu'à 1024x768 ou plus.", "Résolution d'écran trop faible", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
RetryInit:
            Try
                Console.WriteLine(My.Application.Info.DirectoryPath + "\Firefox")
                Gecko.Xpcom.Initialize(My.Application.Info.DirectoryPath + "\Firefox")
                Gecko.GeckoPreferences.User("intl.accept_languages") = My.Settings.UserAgentLanguage
                Gecko.GeckoPreferences.User("general.useragent.locale") = My.Settings.UserAgentLanguage
                Gecko.GeckoPreferences.Default("media.fragmented-mp4.ffmpeg.enabled") = True
                Gecko.GeckoPreferences.Default("media.mediasource.enabled") = True
                Gecko.GeckoPreferences.Default("media.mediasource.ignore_codecs") = True
                Gecko.GeckoPreferences.Default("extensions.blocklist.enabled") = False
                Gecko.GeckoPreferences.Default("dom.disable_beforeunload") = True
                Gecko.GeckoPreferences.User("privacy.donottrackheader.enabled") = My.Settings.DoNotTrack
                Gecko.GeckoPreferences.Default("security.csp.enable") = True
                If Gecko.GeckoPreferences.Default("general.useragent.override") Is Nothing Then
                    If Environment.Is64BitOperatingSystem = True Then
                        Gecko.GeckoPreferences.Default("general.useragent.override") = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0  SmartNet/" + My.Application.Info.Version.ToString
                    Else
                        Gecko.GeckoPreferences.Default("general.useragent.override") = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; rv:60.0) Gecko/20100101 Firefox/60.0  SmartNet/" + My.Application.Info.Version.ToString
                    End If
                End If
                Gecko.GeckoPreferences.Default("geo.enabled") = True
                Gecko.GeckoPreferences.Default("geo.timeout") = 6000
                Gecko.GeckoPreferences.Default("geo.provider.ms-windows-location") = True
                Gecko.GeckoPreferences.Default("geo.provider.network.url") = "https://www.googleapis.com/geolocation/v1/geolocate?key=%GOOGLE_LOCATION_SERVICE_API_KEY%"
                Gecko.GeckoPreferences.Default("geo.provider.network.timeout") = 6000
                Gecko.GeckoPreferences.Default("geo.provider.network.timeToWaitBeforeSending") = 5000
            Catch ex As Exception
                Select Case MessageBox.Show("SmartNet Browser a rencontré une erreur pendant son initialisation. (" + ex.Message + ")", "Rapporteur de plantage de SmartNet Browser", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)
                    Case DialogResult.Abort
                        Environment.Exit(2)
                    Case DialogResult.Retry
                        GoTo RetryInit
                    Case DialogResult.Ignore
                        'Ignorer l'erreur et continuer.
                End Select
            End Try

            ' Migration des listes Historique et Favoris vers le nouveau format
            Try
                Dim migrated As Boolean = False
                Dim title As String
                Dim url As String
                Dim visitDate As DateTime
                Dim pageDetails As String()

                If My.Settings.History.Count > 0 AndAlso My.Settings.History(0).Contains(">") = False Then
                    Dim newHistory As New WebPageList

                    For Each item In My.Settings.History
                        If Not item.Contains(">") Then
                            newHistory.Add(New WebPage(item))
                            migrated = True
                        Else
                            pageDetails = item.Split(">"c)
                            title = pageDetails(0)
                            url = pageDetails(1)
                            visitDate = DateTime.Parse(pageDetails(2))
                            newHistory.Add(New WebPage(title, url, visitDate))
                        End If
                    Next

                    My.Settings.History = newHistory.ToStringCollection()
                    My.Settings.Save()
                End If


                If My.Settings.Favorites.Count > 0 AndAlso My.Settings.Favorites(0).Contains(">") = False Then
                    Dim newFavorites As New WebPageList

                    For Each item In My.Settings.Favorites
                        If Not item.Contains(">") Then
                            newFavorites.Add(New WebPage(item))
                            migrated = True
                        Else
                            pageDetails = item.Split(">"c)
                            title = pageDetails(0)
                            url = pageDetails(1)
                            visitDate = DateTime.Parse(pageDetails(2))
                            newFavorites.Add(New WebPage(title, url, visitDate))
                        End If
                    Next

                    My.Settings.Favorites = newFavorites.ToStringCollection()
                    My.Settings.Save()
                End If

                'If migrated Then
                '    MessageBox.Show("Bonjour ! Votre historique et vos favoris ont été convertis vers le nouveau format. Bonne navigation :)", "SmartNet Browser", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'End If

            Catch ex As Exception
                MessageBox.Show("Nous avons tenté de migrer vos données vers le nouveau format d'enregistrement, mais quelque chose s'est mal passé. Veuillez contacter l'assistance technique avec les données suivantes :" + vbCrLf + ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace, "Rapporteur de plantage de SmartNet Browser", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try

            Try
                If My.Settings.AutoUpdates = True Then
                    Select Case UpdateAgent.IsUpdateAvailable()
                        Case UpdateAgent.UpdateStatus.OSNotSupported
                            MessageBox.Show("Nous vous informons que les mises à jour de SmartNet Browser ne sont plus fournies pour ce système d'exploitation. Veuillez mettre à niveau votre ordinateur. SmartNet Apps Updater a été désactivé.", "SmartNet Browser", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            BrowserForm.UpdateNotifyIcon.Visible = False
                            BrowserForm.NouvelleVersionDisponibleSubMenu.Visible = False
                            My.Settings.AutoUpdates = False
                            My.Settings.Save()
                        Case UpdateAgent.UpdateStatus.SupportStatusOff
                            MessageBox.Show("Nous vous informons que ce logiciel a été abandonné. De ce fait, il ne sera plus mis à jour, vous exposant alors à des risques de stabilité et de sécurité. SmartNet Apps Updater a été désactivé.", "SmartNet Browser", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            BrowserForm.UpdateNotifyIcon.Visible = False
                            BrowserForm.NouvelleVersionDisponibleSubMenu.Visible = False
                            My.Settings.AutoUpdates = False
                            My.Settings.Save()
                        Case UpdateAgent.UpdateStatus.UpdateAvailable
                            BrowserForm.UpdateNotifyIcon.Visible = True
                            BrowserForm.UpdateNotifyIcon.ShowBalloonTip(5000)
                            BrowserForm.NouvelleVersionDisponibleSubMenu.Visible = True
                            BrowserForm.TéléchargerLaVersionXXXXToolStripMenuItem.Text = "Télécharger la version " + UpdateAgent.LastVersionAvailable().ToString()
                        Case UpdateAgent.UpdateStatus.UpToDate
                            BrowserForm.UpdateNotifyIcon.Visible = False
                            BrowserForm.NouvelleVersionDisponibleSubMenu.Visible = False
                    End Select
                End If
            Catch ex As Exception
                BrowserForm.UpdateNotifyIcon.Visible = False
                BrowserForm.NouvelleVersionDisponibleSubMenu.Visible = False
            End Try
        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            e.ExitApplication = False
            Console.WriteLine(e.Exception.Message)
            MessageBox.Show("SmartNet Browser a planté." + vbCrLf + e.Exception.Message + vbCrLf + e.Exception.StackTrace, "Rapporteur de plantage de SmartNet Browser", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(2)
        End Sub
    End Class
End Namespace
