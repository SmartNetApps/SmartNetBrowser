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
            Try
                Gecko.Xpcom.Initialize("Firefox")
                Gecko.GeckoPreferences.User("intl.accept_languages") = My.Settings.UserAgentLanguage
                Gecko.GeckoPreferences.User("general.useragent.locale") = My.Settings.UserAgentLanguage
                If My.Settings.UserAgent = "" Then
                    If Environment.Is64BitOperatingSystem = True Then
                        Gecko.GeckoPreferences.Default("general.useragent.override") = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0  SmartNet/" + My.Application.Info.Version.ToString
                    Else
                        Gecko.GeckoPreferences.Default("general.useragent.override") = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; rv:60.0) Gecko/20100101 Firefox/60.0  SmartNet/" + My.Application.Info.Version.ToString
                    End If
                Else
                    Gecko.GeckoPreferences.User("general.useragent.override") = My.Settings.UserAgent
                End If
                Gecko.GeckoPreferences.Default("media.fragmented-mp4.ffmpeg.enabled") = True
                Gecko.GeckoPreferences.Default("media.mediasource.enabled") = True
                Gecko.GeckoPreferences.Default("media.mediasource.ignore_codecs") = True
                Gecko.GeckoPreferences.Default("extensions.blocklist.enabled") = False
                Gecko.GeckoPreferences.Default("dom.disable_beforeunload") = True
                Gecko.GeckoPreferences.User("privacy.donottrackheader.enabled") = My.Settings.DoNotTrack
            Catch ex As Exception
                BrowserForm.msgBar = New MessageBar(MessageBar.MessageBarLevel.Critical, "Malheureusement, SmartNet Browser n'a pas pu démarrer correctement.", MessageBar.MessageBarAction.OpenExceptionForm, "Voir les détails", ex)
                BrowserForm.DisplayMessageBar()
            End Try

            Dim newHistory As New WebPageList
            Dim newFavorites As New WebPageList
            Dim migrated As Boolean = False
            Dim title As String
            Dim url As String
            Dim visitDate As DateTime
            Dim pageDetails As String()
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
            My.Settings.History = newHistory.ToStringCollection()
            My.Settings.Favorites = newFavorites.ToStringCollection()

            If migrated Then
                BrowserForm.msgBar = New MessageBar(MessageBar.MessageBarLevel.Info, "Nous avons migré votre historique vers le nouveau format.")
                BrowserForm.DisplayMessageBar()
            End If

            Dim updateAgent As New UpdateAgent
            updateAgent.IsUpdateAvailable(False)

            ' Connection string encryption
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            config.ConnectionStrings.SectionInformation.ProtectSection(Nothing)
            ' We must save the changes to the configuration file.
            config.Save(ConfigurationSaveMode.Full, True)
        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            BrowserForm.msgBar = New MessageBar(e.Exception)
            BrowserForm.DisplayMessageBar()
            Console.WriteLine(e.Exception.Message)
            Environment.Exit(2)
        End Sub
    End Class
End Namespace
