Imports System.IO.File
Imports System.Net
Imports Microsoft.Win32

Public Class SettingsForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HomepageURLBox.Text = My.Settings.Homepage
        Select Case My.Settings.SearchEngine
            Case 1
                RadioButton1.Checked = True
            Case 2
                RadioButton2.Checked = True
            Case 3
                RadioButton3.Checked = True
            Case 4
                RadioButton4.Checked = True
            Case 5
                RadioButton5.Checked = True
            Case 0
                RadioButton0.Checked = True
        End Select
        PreventMultipleTabsCloseCheckBox.Checked = My.Settings.PreventMultipleTabsClose
        EraseCookiesCheckBox.Checked = My.Settings.DeleteCookiesWhileClosing
        If My.Settings.PrivateBrowsing = False Then
            PrivateBrowsingCheckBox.Checked = True
        Else
            PrivateBrowsingCheckBox.Checked = False
        End If
        DeleteHistoryButton.Enabled = True
        DeleteHistoryButton.Text = "Effacer tout l'historique de navigation"
        DeleteCookiesButton.Enabled = True
        DeleteCookiesButton.Text = "Effacer les cookies"
        DeleteTemporaryInternetFilesButton.Enabled = True
        DeleteTemporaryInternetFilesButton.Text = "Effacer le cache"
        DeleteSearchHistoryButton.Enabled = True
        DeleteSearchHistoryButton.Text = "Effacer l'historique des recherches"
        DoNotTrackCheckBox.Checked = My.Settings.DoNotTrack
        If My.Settings.ChildrenProtection = True Then
            ChildrenProtectionCheckBox.Checked = True
            ChangeChildrenProtectionPasswordButton.Enabled = True
            CreateChildrenProtectionPasswordForm.Close()
        Else
            ChildrenProtectionCheckBox.Checked = False
            ChangeChildrenProtectionPasswordButton.Enabled = False
        End If
        If My.Settings.BrowserSettingsSecurity = True Then
            BrowserSettingsSecurityCheckBox.Checked = True
            CreateBrowserSettingsSecurityPasswordForm.Close()
            ChangeBrowserSettingsSecurityPasswordButton.Enabled = True
            HistoryFavoritesSecurityCheckBox.Enabled = True
        Else
            BrowserSettingsSecurityCheckBox.Checked = False
            ChangeBrowserSettingsSecurityPasswordButton.Enabled = False
            HistoryFavoritesSecurityCheckBox.Enabled = False
            HistoryFavoritesSecurityCheckBox.Checked = False
        End If
        If My.Settings.AdBlocker = True Then
            AdBlockerCheckBox.Checked = True
            PopUpsBlockerCheckBox.Enabled = True
        Else
            AdBlockerCheckBox.Checked = False
            PopUpsBlockerCheckBox.Enabled = False
            PopUpsBlockerCheckBox.Checked = False
        End If
        PopUpsBlockerCheckBox.Checked = My.Settings.PopUpBlocker
        AutoUpdateCheckBox.Checked = My.Settings.AutoUpdates
        VersionActuelleLabel.Text = "Version actuelle : " + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString + "." + My.Application.Info.Version.Build.ToString
        ImportSettingsButton.Text = "Importer mes paramètres depuis une ancienne version..."
        ImportSettingsButton.Enabled = True
        UserAgentTextBox.Text = CType(Gecko.GeckoPreferences.User("general.useragent.override"), String)
        LanguagesComboBox.SelectedIndex = LanguagesComboBox.FindString(My.Settings.UserAgentLanguage)
        DefaultDownloadFolderTextBox.Text = My.Settings.DefaultDownloadFolder
        Me.CenterToScreen()
    End Sub

    Private Sub MenuURLHomepageButton_Click(sender As Object, e As EventArgs) Handles MenuURLHomepageButton.Click
        HomepageURLBox.Text = "http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser/homepage/"
    End Sub
    Private Sub WhitePageHomepageButton_Click(sender As Object, e As EventArgs) Handles WhitePageHomepageButton.Click
        HomepageURLBox.Text = "about:blank"
    End Sub
    Private Sub ActualPageURLHomepageButton_Click(sender As Object, e As EventArgs) Handles ActualPageURLHomepageButton.Click
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        HomepageURLBox.Text = WB.Url.ToString
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        My.Settings.SearchEngine = 1
        BrowserForm.SearchBoxLabel.Text = "Google"
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        My.Settings.SearchEngine = 2
        BrowserForm.SearchBoxLabel.Text = "Bing"
    End Sub
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        My.Settings.SearchEngine = 3
        BrowserForm.SearchBoxLabel.Text = "Yahoo!"
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        My.Settings.SearchEngine = 4
        BrowserForm.SearchBoxLabel.Text = "DuckDuckGo"
    End Sub
    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        My.Settings.SearchEngine = 5
        BrowserForm.SearchBoxLabel.Text = "Qwant"
    End Sub
    Private Sub RadioButton0_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton0.CheckedChanged
        BrowserForm.SearchBoxLabel.Text = My.Settings.CustomSearchName
        If My.Settings.CustomSearchURL = "" Then
            SettingsCustomSearchForm.Show()
        End If
    End Sub
    Private Sub CustomSearchSettingsButton_Click(sender As Object, e As EventArgs) Handles CustomSearchSettingsButton.Click
        SettingsCustomSearchForm.Show()
    End Sub

    Private Sub PrivateBrowsingCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PrivateBrowsingCheckBox.CheckedChanged
        If PrivateBrowsingCheckBox.Checked = False Then
            MsgBox("Avertissement : Ceci n'est pas une fonction de navigation privée. Les cookies et le cache du navigateur seront toujours enregistrés.", MsgBoxStyle.Information, "SmartNet Browser : Gestion de l'historique")
        End If
    End Sub
    Private Sub CookiesLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles CookiesLinkLabel.LinkClicked
        BrowserForm.AddTab("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser/support", BrowserForm.BrowserTabs)
    End Sub

    Private Sub DeleteHistoryButton_Click(sender As Object, e As EventArgs) Handles DeleteHistoryButton.Click
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            My.Settings.History.Clear()
            My.Settings.NewHistory.Clear()
            BrowserForm.URLBox.Items.Clear()
            WB.History.Clear()
            DeleteHistoryButton.Enabled = False
            DeleteHistoryButton.Text = "Historique de navigation effacé"
        Catch ex As Exception
            MsgBox("Erreur lors de la suppression de l'historique : " + ex.Message, CType(MessageBoxIcon.Error, MsgBoxStyle), "SmartNet Browser : Gestion de l'historique")
            DeleteHistoryButton.Enabled = True
            DeleteHistoryButton.Text = "Effacer tout l'historique de navigation"
        End Try
    End Sub
    Private Sub DeleteCookiesButton_Click(sender As Object, e As EventArgs) Handles DeleteCookiesButton.Click
        Try
            Gecko.CookieManager.RemoveAll()
            DeleteCookiesButton.Enabled = False
            DeleteCookiesButton.Text = "Cookies effacés"
        Catch ex As Exception
            MsgBox("Erreur lors de la suppression des cookies : " + ex.Message, CType(MessageBoxIcon.Error, MsgBoxStyle), "SmartNet Browser : Gestion des cookies")
            DeleteCookiesButton.Enabled = True
            DeleteCookiesButton.Text = "Effacer les cookies"
        End Try
    End Sub
    Private Sub DeleteTemporaryInternetFilesButton_Click(sender As Object, e As EventArgs) Handles DeleteTemporaryInternetFilesButton.Click
        Try
            Gecko.Cache.CacheService.Clear(Gecko.Cache.CacheStoragePolicy.Anywhere)
            DeleteTemporaryInternetFilesButton.Enabled = False
            DeleteTemporaryInternetFilesButton.Text = "Cache effacé"
        Catch ex As Exception
            MsgBox("Erreur lors de la suppression du cache : " + ex.Message, CType(MessageBoxIcon.Error, MsgBoxStyle), "SmartNet Browser : Gestion du cache")
            DeleteTemporaryInternetFilesButton.Enabled = True
            DeleteTemporaryInternetFilesButton.Text = "Effacer le cache"
        End Try
    End Sub
    Private Sub DeleteSearchHistoryButton_Click(sender As Object, e As EventArgs) Handles DeleteSearchHistoryButton.Click
        Try
            My.Settings.SearchHistory.Clear()
            BrowserForm.SearchBox.Items.Clear()
            DeleteSearchHistoryButton.Enabled = False
            DeleteSearchHistoryButton.Text = "Historique des recherches effacé"
        Catch ex As Exception
            MsgBox("Erreur lors de la suppression de l'historique des recherches : " + ex.Message, CType(MessageBoxIcon.Error, MsgBoxStyle), "SmartNet Browser : Gestion de l'historique des recherches")
            DeleteSearchHistoryButton.Enabled = True
            DeleteSearchHistoryButton.Text = "Effacer l'historique des recherches"
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ChangeChildrenProtectionPasswordButton.Click
        ChangeChildrenProtectionPasswordForm.ShowDialog()
    End Sub
    Private Sub ChildrenProtectionCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ChildrenProtectionCheckBox.CheckedChanged
        If ChildrenProtectionCheckBox.Checked = True Then
            If My.Settings.ChildrenProtection = False Then
                CreateChildrenProtectionPasswordForm.ShowDialog()
            End If
        Else
            If My.Settings.ChildrenProtection = True Then
                EnterChildrenProtectionForm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub ChangeBrowserSettingsSecurityPasswordButton_Click(sender As Object, e As EventArgs) Handles ChangeBrowserSettingsSecurityPasswordButton.Click
        ChangeBrowserSettingsSecurityPasswordForm.ShowDialog()
    End Sub
    Private Sub BrowserSettingsSecurityCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles BrowserSettingsSecurityCheckBox.CheckedChanged
        If BrowserSettingsSecurityCheckBox.Checked = True Then
            If My.Settings.BrowserSettingsSecurity = False Then
                CreateBrowserSettingsSecurityPasswordForm.ShowDialog()
            Else
                ChangeBrowserSettingsSecurityPasswordButton.Enabled = True
                HistoryFavoritesSecurityCheckBox.Enabled = True
            End If
        Else
            ChangeBrowserSettingsSecurityPasswordButton.Enabled = False
            HistoryFavoritesSecurityCheckBox.Enabled = False
            HistoryFavoritesSecurityCheckBox.Checked = False
        End If
    End Sub

    Private Sub AdBlockerSignalementButton_Click(sender As Object, e As EventArgs) Handles ChildGuardProblemSignalementButton.Click, AdsBlockerProblemSignalementButton.Click
        BrowserForm.AddTab("https://docs.google.com/forms/d/e/1FAIpQLScxWEiZYE9ZQNQ1su4356QWW837j_jB7JGzbMxAqbVPM2nmcw/viewform?usp=sf_link", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub AdBlockerCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AdBlockerCheckBox.CheckedChanged
        If AdBlockerCheckBox.Checked = True Then
            PopUpsBlockerCheckBox.Enabled = True
        Else
            PopUpsBlockerCheckBox.Enabled = False
            PopUpsBlockerCheckBox.Checked = False
        End If
    End Sub
    Private Sub EditWhitelistButton_Click(sender As Object, e As EventArgs) Handles EditWhitelistButton.Click
        AdBlockerWhitelistForm.ShowDialog()
    End Sub

    Private Sub AutoUpdateCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AutoUpdateCheckBox.CheckedChanged
        Try
            If AutoUpdateCheckBox.Checked = False And My.Settings.AutoUpdates = True Then
                MsgBox("Avertissement : Les mises à jour automatiques permettent au navigateur de recevoir les dernières fonctionnalités et les corrections de bugs dès qu'elles sont disponibles. Si vous désactivez les mises à jour automatiques, vous acceptez que des bugs puissent être présents dans le logiciel et que ceux-ci ne soient pas corrigés. Ceci est vivement déconseillé.", MsgBoxStyle.Exclamation, "Désactiver SmartNet Apps Updater")
            End If
            Dim MiniNTVersionChecker As New WebClient
            Dim NTActualVersion As Version = Environment.OSVersion.Version
            Dim MiniNTVersion As Version = New Version(MiniNTVersionChecker.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/MinimumNTVersion.txt"))
            If NTActualVersion < MiniNTVersion And AutoUpdateCheckBox.Checked = True Then
                MsgBox("Votre système d'exploitation n'est plus pris en charge par SmartNet Apps. Visitez le site SmartNet Apps pour en savoir plus à ce sujet. La recherche automatique de mises à jour ne peut être activée.", MsgBoxStyle.Critical, "Impossible de continuer")
                AutoUpdateCheckBox.Checked = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckUpdatesNowButton_Click(sender As Object, e As EventArgs) Handles CheckUpdatesNowButton.Click
        Try
            Dim MiniNTVersionChecker As New WebClient
            Dim NTActualVersion As Version = Environment.OSVersion.Version
            Dim MiniNTVersion As Version = New Version(MiniNTVersionChecker.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/MinimumNTVersion.txt"))
            Dim MAJ As New WebClient
            Dim VersionActuelle As Version = My.Application.Info.Version
            Dim DerniereVersion As Version = New Version(MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/version.txt"))
            Dim SupportStatus As String = MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/support-status.txt")
            If VersionActuelle > DerniereVersion Then
                MsgBox("Vous utilisez une version préliminaire de SmartNet Browser. Vous pourriez trouver des beugs ou incohérences, merci de ne pas les signaler tant que cette version n'est pas publiée. Veuillez me contacter si vous pensez qu'il s'agit d'une erreur.", MsgBoxStyle.Exclamation, "Version préliminaire")
                GoTo StopVersionChecking
            End If
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
                    UpdaterForm.ShowDialog()
                Else
                    BrowserForm.NouvelleVersionDisponibleSubMenu.Visible = False
                    MsgBox("Vous utilisez dejà la dernière version de SmartNet Browser.", MsgBoxStyle.Information, "SmartNet Apps Updater")
                    GoTo StopVersionChecking
                End If
            Else
                BrowserForm.NouvelleVersionDisponibleSubMenu.Visible = False
                MsgBox("Le support et le développement de ce produit ont été interrompus. Visitez le site SmartNet Apps pour en savoir plus.", MsgBoxStyle.Critical, "Service interrompu")
                GoTo StopVersionChecking
            End If
StopVersionChecking:
        Catch ex As Exception
            MsgBox("La connexion à SmartNet Apps Updater a échoué : " + ex.Message, MsgBoxStyle.Critical, "SmartNet Apps Updater")
        End Try
    End Sub

    Private Sub ImportSettingsButton_Click(sender As Object, e As EventArgs) Handles ImportSettingsButton.Click
        Try
            My.Settings.Upgrade()
            ImportSettingsButton.Text = "Importation terminée."
        Catch ex As Exception
            MsgBox("Erreur lors de l'importation : " + ex.Message, CType(MessageBoxIcon.Error, MsgBoxStyle), "SmartNet Browser : Gestion des données")
            ImportSettingsButton.Text = "Erreur lors de l'importation."
        End Try
        My.Settings.Reload()
    End Sub

    Private Sub RepareBrowserButton_Click(sender As Object, e As EventArgs) Handles RepareBrowserButton.Click
        If MsgBox("Êtes-vous sûr(e) de vouloir réinitialiser le navigateur ? Vous perdrez toutes vos informations personnelles, y compris vos Favoris et votre Historique. Les cookies seront tous effacés. Le contrôle parental et la sécurité des paramètres seront désactivés. Le navigateur redémarrera.", MsgBoxStyle.OkCancel, "Réinitialisation de SmartNet Browser") = MsgBoxResult.Ok Then
            My.Settings.PrivateBrowsing = False
            My.Settings.History.Clear()
            My.Settings.NewHistory.Clear()
            My.Settings.Homepage = "http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser/homepage/"
            My.Settings.Favorites.Clear()
            My.Settings.SearchHistory.Clear()
            My.Settings.PreventMultipleTabsClose = True
            My.Settings.SearchEngine = 5
            My.Settings.CustomSearchURL = ""
            My.Settings.CustomSearchName = ""
            My.Settings.FirstStart = True
            My.Settings.AutoUpdates = True
            My.Settings.AdBlocker = False
            My.Settings.PopUpBlocker = False
            My.Settings.AllowAdsSites = "quentinpugeat.wixsite.com"
            My.Settings.ChildrenProtection = False
            My.Settings.ChildrenProtectionPassword = ""
            My.Settings.BrowserSettingsSecurity = False
            My.Settings.BrowserSettingsSecurityPassword = ""
            My.Settings.DeleteCookiesWhileClosing = False
            My.Settings.UserAgent = ""
            My.Settings.FirstStartFromReset = True
            My.Settings.UserAgentLanguage = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName
            Gecko.CookieManager.RemoveAll()
            Dim DownloadFolderrKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders")
            If DownloadFolderrKey Is Nothing Then
                My.Settings.DefaultDownloadFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\Downloads"
            Else
                My.Settings.DefaultDownloadFolder = DownloadFolderrKey.GetValue("{374DE290-123F-4565-9164-39C4925E467B}").ToString
            End If
            My.Settings.Save()
            Application.Restart()
            End
        End If
    End Sub

    Private Sub FirstStartDialogButton_Click(sender As Object, e As EventArgs) Handles FirstStartDialogButton.Click
        Me.Close()
        FirstStartForm.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ChangeUserAgentLinkLabel.LinkClicked
        UserAgentChangeForm.UserAgentRichTextBox.Text = CType(Gecko.GeckoPreferences.User("general.useragent.override"), String)
        UserAgentChangeForm.ShowDialog()
    End Sub

    Private Sub AbortButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
        Me.Close()
    End Sub
    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        My.Settings.Homepage = HomepageURLBox.Text
        My.Settings.PopUpBlocker = PopUpsBlockerCheckBox.Checked
        My.Settings.DeleteCookiesWhileClosing = EraseCookiesCheckBox.Checked
        My.Settings.BrowserSettingsSecurity = BrowserSettingsSecurityCheckBox.Checked
        My.Settings.HistoryFavoritesSecurity = HistoryFavoritesSecurityCheckBox.Checked
        My.Settings.ChildrenProtection = ChildrenProtectionCheckBox.Checked
        My.Settings.AdBlocker = AdBlockerCheckBox.Checked
        My.Settings.PreventMultipleTabsClose = PreventMultipleTabsCloseCheckBox.Checked
        If PrivateBrowsingCheckBox.Checked = True Then
            My.Settings.PrivateBrowsing = False
        Else
            My.Settings.PrivateBrowsing = True
        End If
        My.Settings.AutoUpdates = AutoUpdateCheckBox.Checked
        My.Settings.UserAgentLanguage = LanguagesComboBox.Text.Split(" "c)(0)
        Gecko.GeckoPreferences.User("intl.accept_languages") = My.Settings.UserAgentLanguage
        Gecko.GeckoPreferences.User("general.useragent.locale") = My.Settings.UserAgentLanguage
        My.Settings.DefaultDownloadFolder = DefaultDownloadFolderTextBox.Text
        My.Settings.DoNotTrack = DoNotTrackCheckBox.Checked
        Gecko.GeckoPreferences.User("privacy.donottrackheader.enabled") = My.Settings.DoNotTrack
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub SetDefaultDownloadFolderButton_Click(sender As Object, e As EventArgs) Handles SetDefaultDownloadFolderButton.Click
        If DefaultDownloadFolderBrowserDialog.ShowDialog() = DialogResult.OK Then
            DefaultDownloadFolderTextBox.Text = My.Settings.DefaultDownloadFolder
        End If
    End Sub
End Class