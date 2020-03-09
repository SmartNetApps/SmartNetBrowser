Imports System.ComponentModel
Imports System.IO.File
Imports System.Net
Imports Microsoft.Win32

Public Class SettingsForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Async Function AppSyncSyncNowAsync() As Task(Of Boolean)
        Try
            ButtonSyncNow.Text = "Synchronisation en cours..."
            ButtonSyncNow.Enabled = False
            Return Await AppSyncAgent.SyncNow()
            ButtonSyncNow.Text = "Synchroniser maintenant"
            ButtonSyncNow.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SmartNet AppSync", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ButtonSyncNow.Text = "Échec de la synchronisation."
            ButtonSyncNow.Enabled = False
            Return False
        End Try
    End Function

    Private Async Function AppSyncSendConfigAsync() As Task(Of Boolean)
        Try
            Return Await AppSyncAgent.SendConfig()
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Malheureusement, nous n'avons pas pu envoyer votre configuration à SmartNet AppSync.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

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
            PopUpsBlockerCheckBox.Checked = My.Settings.PopUpBlocker
        Else
            AdBlockerCheckBox.Checked = False
            PopUpsBlockerCheckBox.Enabled = False
            PopUpsBlockerCheckBox.Checked = False
        End If

        ListBoxAdsBlockerWhitelistedPages.Items.Clear()
        For Each page In My.Settings.AdBlockerWhitelist
            ListBoxAdsBlockerWhitelistedPages.Items.Add(page)
        Next
        TextBoxNewPageInAdsBlockerWhitelist.ResetText()
        ButtonAddNewPageInAdsBlockerWhitelist.Enabled = False
        ButtonRemovePageFromAdsBlockerWhitelist.Enabled = False

        VersionActuelleLabel.Text = "Version actuelle : " + My.Application.Info.Version.ToString()

        Try
            Select Case UpdateAgent.IsUpdateAvailable()
                Case UpdateAgent.UpdateStatus.OSNotSupported
                    My.Settings.AutoUpdates = False
                    My.Settings.Save()
                    CheckUpdatesNowButton.Enabled = False
                    CheckUpdatesNowButton.Text = "SmartNet Browser est à jour."
                Case UpdateAgent.UpdateStatus.SupportStatusOff
                    My.Settings.AutoUpdates = False
                    My.Settings.Save()
                    CheckUpdatesNowButton.Enabled = False
                    CheckUpdatesNowButton.Text = "SmartNet Browser est à jour."
                Case UpdateAgent.UpdateStatus.UpdateAvailable
                    CheckUpdatesNowButton.Enabled = True
                    CheckUpdatesNowButton.Text = "Mise à jour disponible !"
                Case UpdateAgent.UpdateStatus.UpToDate
                    CheckUpdatesNowButton.Enabled = False
                    CheckUpdatesNowButton.Text = "SmartNet Browser est à jour."
            End Select
        Catch ex As Exception
            CheckUpdatesNowButton.Enabled = False
            CheckUpdatesNowButton.Text = "Erreur de connexion."
        End Try

        AutoUpdateCheckBox.Checked = My.Settings.AutoUpdates

        ImportSettingsButton.Text = "Importer mes paramètres depuis une ancienne version..."
        ImportSettingsButton.Enabled = True

        LanguagesComboBox.SelectedIndex = LanguagesComboBox.FindString(My.Settings.UserAgentLanguage)
        DefaultDownloadFolderTextBox.Text = My.Settings.DefaultDownloadFolder
        Me.CenterToScreen()
        Select Case CType(Gecko.GeckoPreferences.User("network.cookie.cookieBehavior"), Int32)
            Case 0
                RadioButtonAcceptAllCookies.Checked = True
                RadioButtonBlockThirdPartyCookies.Checked = False
                RadioButtonBlockAllCookies.Checked = False
            Case 1
                RadioButtonAcceptAllCookies.Checked = False
                RadioButtonBlockThirdPartyCookies.Checked = True
                RadioButtonBlockAllCookies.Checked = False
            Case 2
                RadioButtonAcceptAllCookies.Checked = False
                RadioButtonBlockThirdPartyCookies.Checked = False
                RadioButtonBlockAllCookies.Checked = True
        End Select

        If My.Settings.AppSyncDeviceNumber = "" Then
            ButtonManageAccount.Enabled = False
            ButtonManageAccount.Visible = False
            ButtonLoginLogout.Text = "Se connecter..."
            ButtonLoginLogout.Enabled = True
            LabelUsername.Text = "Déconnecté.e"
            PictureBoxUserProfilePic.Image = My.Resources.Person
            GroupBoxAppSyncDevice.Visible = False
            ButtonChangeAppSyncDeviceName.Enabled = False
            ButtonSyncNow.Enabled = False
            ButtonSyncNow.Visible = False
        Else
            Try
                ButtonManageAccount.Enabled = True
                ButtonManageAccount.Visible = True
                ButtonLoginLogout.Text = "Se déconnecter..."
                ButtonLoginLogout.Enabled = True
                LabelUsername.Text = AppSyncAgent.GetUserName()
                PictureBoxUserProfilePic.Image = New Bitmap(AppSyncAgent.GetUserProfilePicture(), 54, 54)
                GroupBoxAppSyncDevice.Visible = True
                TextBoxAppSyncDeviceName.Text = AppSyncAgent.GetDeviceName()
                ButtonChangeAppSyncDeviceName.Enabled = False
                ButtonSyncNow.Visible = True
                ButtonSyncNow.Enabled = True
            Catch ex As AppSyncException
                ButtonManageAccount.Enabled = False
                ButtonManageAccount.Visible = True
                ButtonLoginLogout.Text = "Se déconnecter..."
                ButtonLoginLogout.Enabled = False
                LabelUsername.Text = "Échec de l'ouverture de session. (" + ex.Message + ")"
                PictureBoxUserProfilePic.Image = My.Resources.Person
                GroupBoxAppSyncDevice.Visible = True
                TextBoxAppSyncDeviceName.Text = ""
                ButtonChangeAppSyncDeviceName.Enabled = False
                ButtonSyncNow.Enabled = False
            End Try
        End If
    End Sub

    Private Sub MenuURLHomepageButton_Click(sender As Object, e As EventArgs) Handles MenuURLHomepageButton.Click
        HomepageURLBox.Text = "https://homepage.quentinpugeat.fr"
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
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        My.Settings.SearchEngine = 2
    End Sub
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        My.Settings.SearchEngine = 3
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        My.Settings.SearchEngine = 4
    End Sub
    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        My.Settings.SearchEngine = 5
    End Sub
    Private Sub RadioButton0_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton0.CheckedChanged
        If My.Settings.CustomSearchURL = "" Then
            SettingsCustomSearchForm.Show()
        End If
    End Sub
    Private Sub CustomSearchSettingsButton_Click(sender As Object, e As EventArgs) Handles CustomSearchSettingsButton.Click
        SettingsCustomSearchForm.Show()
    End Sub

    Private Sub PrivateBrowsingCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PrivateBrowsingCheckBox.CheckedChanged
        If PrivateBrowsingCheckBox.Checked = False Then
            If MessageBox.Show("Avertissement : Ceci n'est pas une fonction de navigation privée. Les cookies et le cache du navigateur seront toujours enregistrés.", "SmartNet Browser : Gestion de l'historique", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then
                PrivateBrowsingCheckBox.Checked = True
            End If
        End If
        My.Settings.PrivateBrowsing = Not (PrivateBrowsingCheckBox.Checked)
    End Sub
    Private Sub CookiesLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles CookiesLinkLabel.LinkClicked
        BrowserForm.AddTab("https://smartnetapps.quentinpugeat.fr/browser/support/donnees_personnelles/index.html")
    End Sub

    Private Sub DeleteHistoryButton_Click(sender As Object, e As EventArgs) Handles DeleteHistoryButton.Click
        Dim WB As CustomBrowser
        Try
            My.Settings.History.Clear()
            BrowserForm.URLBox.Items.Clear()
            For Each tab As TabPage In BrowserForm.BrowserTabs.TabPages
                WB = CType(tab.Tag, CustomBrowser)
                WB.History.Clear()
            Next
            DeleteHistoryButton.Enabled = False
            DeleteHistoryButton.Text = "Historique de navigation effacé"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SmartNet Browser : Gestion de l'historique", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show(ex.Message, "SmartNet Browser : Gestion des cookies", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show(ex.Message, "SmartNet Browser : Gestion du cache", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DeleteTemporaryInternetFilesButton.Enabled = True
            DeleteTemporaryInternetFilesButton.Text = "Effacer le cache"
        End Try
    End Sub
    Private Sub DeleteSearchHistoryButton_Click(sender As Object, e As EventArgs) Handles DeleteSearchHistoryButton.Click
        Try
            My.Settings.SearchHistory.Clear()
            DeleteSearchHistoryButton.Enabled = False
            DeleteSearchHistoryButton.Text = "Historique des recherches effacé"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SmartNet Browser : Gestion de l'historique des recherches", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        BrowserForm.AddTab("https://docs.google.com/forms/d/e/1FAIpQLScxWEiZYE9ZQNQ1su4356QWW837j_jB7JGzbMxAqbVPM2nmcw/viewform?usp=sf_link")
        Me.Close()
    End Sub

    Private Sub AdBlockerCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AdBlockerCheckBox.CheckedChanged
        If AdBlockerCheckBox.Checked = True Then
            PopUpsBlockerCheckBox.Enabled = True
        Else
            PopUpsBlockerCheckBox.Enabled = False
            PopUpsBlockerCheckBox.Checked = False
        End If
        My.Settings.AdBlocker = AdBlockerCheckBox.Checked
    End Sub

    Private Sub AutoUpdateCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AutoUpdateCheckBox.CheckedChanged
        Try
            If CType(sender, CheckBox).CheckState = CheckState.Checked And My.Settings.AutoUpdates = False Then
                Select Case UpdateAgent.IsUpdateAvailable()
                    Case UpdateAgent.UpdateStatus.OSNotSupported
                        MessageBox.Show("Malheureusement, ce système d'exploitation n'étant plus pris en charge, aucune mise à jour ne sera proposée à l'avenir. Consultez le site d'assistance de SmartNet Apps pour en savoir plus.", "SmartNet Apps Updater", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        My.Settings.AutoUpdates = False
                        My.Settings.Save()
                        AutoUpdateCheckBox.Checked = False
                    Case UpdateAgent.UpdateStatus.SupportStatusOff
                        MessageBox.Show("Malheureusement, ce logiciel a été abandonné. Aucune mise à jour ne sera proposée à l'avenir. Consultez le site d'assistance de SmartNet Apps pour en savoir plus.", "SmartNet Apps Updater", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        My.Settings.AutoUpdates = False
                        My.Settings.Save()
                        AutoUpdateCheckBox.Checked = False
                    Case Else
                        My.Settings.AutoUpdates = True
                        My.Settings.Save()
                End Select
            ElseIf CType(sender, CheckBox).CheckState = CheckState.Unchecked And My.Settings.AutoUpdates = True Then
                If MessageBox.Show("La désactivation de la vérification automatique des mises à jour est déconseillée, car les mises à jour apportent des correctifs de bugs, ainsi que de nouvelles fonctionnalités, de manière régulière. Êtes-vous sûr.e de vouloir continuer ?", "SmartNet Apps Updater", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    My.Settings.AutoUpdates = False
                    My.Settings.Save()
                Else
                    My.Settings.AutoUpdates = True
                    My.Settings.Save()
                    AutoUpdateCheckBox.Checked = True
                End If
            Else
                My.Settings.AutoUpdates = AutoUpdateCheckBox.Checked
                My.Settings.Save()
            End If
        Catch ex As Exception
            MessageBox.Show("Nous rencontrons des difficultés pour contacter SmartNet Apps Updater. Veuillez retenter ultérieurement." + vbCrLf + "Erreur : " + ex.Message, "SmartNet Apps Updater", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub CheckUpdatesNowButton_Click(sender As Object, e As EventArgs) Handles CheckUpdatesNowButton.Click
        Try
            If UpdateAgent.IsUpdateAvailable() = UpdateAgent.UpdateStatus.UpdateAvailable Then
                UpdaterForm.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show("Nous rencontrons des difficultés pour contacter SmartNet Apps Updater. Veuillez retenter ultérieurement." + vbCrLf + "Erreur : " + ex.Message, "SmartNet Apps Updater", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ImportSettingsButton_Click(sender As Object, e As EventArgs) Handles ImportSettingsButton.Click
        Try
            My.Settings.Upgrade()
            ImportSettingsButton.Text = "Importation terminée."
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SmartNet Browser : Gestion des données", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ImportSettingsButton.Text = "Erreur lors de l'importation."
        End Try
        My.Settings.Reload()
    End Sub

    Private Sub RepareBrowserButton_Click(sender As Object, e As EventArgs) Handles RepareBrowserButton.Click
        If MessageBox.Show("Êtes-vous sûr.e de vouloir réinitialiser le navigateur ? Vous perdrez toutes vos informations personnelles, y compris vos Favoris et votre Historique. Les cookies seront tous effacés. Le contrôle parental et la sécurité des paramètres seront désactivés. Le navigateur redémarrera.", "Réinitialisation de SmartNet Browser", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            My.Settings.PrivateBrowsing = False
            My.Settings.History.Clear()
            My.Settings.Homepage = "https://homepage.quentinpugeat.fr"
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
            My.Settings.AdBlockerWhitelist.Clear()
            My.Settings.ChildrenProtection = False
            My.Settings.ChildrenProtectionPassword = ""
            My.Settings.BrowserSettingsSecurity = False
            My.Settings.BrowserSettingsSecurityPassword = ""
            My.Settings.DeleteCookiesWhileClosing = False
            If Environment.Is64BitOperatingSystem = True Then
                Gecko.GeckoPreferences.Default("general.useragent.override") = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0  SmartNet/" + My.Application.Info.Version.ToString
            Else
                Gecko.GeckoPreferences.Default("general.useragent.override") = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; rv:60.0) Gecko/20100101 Firefox/60.0  SmartNet/" + My.Application.Info.Version.ToString
            End If
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

    Private Sub ChangeUserAgentLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        BrowserForm.AddTab("about:config")
    End Sub

    Private Sub SetDefaultDownloadFolderButton_Click(sender As Object, e As EventArgs) Handles SetDefaultDownloadFolderButton.Click
        If DefaultDownloadFolderBrowserDialog.ShowDialog() = DialogResult.OK Then
            DefaultDownloadFolderTextBox.Text = DefaultDownloadFolderBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub RadioButtonAcceptAllCookies_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAcceptAllCookies.CheckedChanged
        Gecko.GeckoPreferences.User("network.cookie.cookieBehavior") = 0
    End Sub

    Private Sub RadioButtonBlockThirdPartyCookies_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonBlockThirdPartyCookies.CheckedChanged
        Gecko.GeckoPreferences.User("network.cookie.cookieBehavior") = 1
    End Sub

    Private Sub RadioButtonBlockAllCookies_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonBlockAllCookies.CheckedChanged
        Gecko.GeckoPreferences.User("network.cookie.cookieBehavior") = 2
    End Sub

    Private Sub ButtonLoginLogout_Click(sender As Object, e As EventArgs) Handles ButtonLoginLogout.Click
        If My.Settings.AppSyncDeviceNumber = "" Then
            AppSyncLogin.ShowDialog()
        Else
            If MessageBox.Show("Êtes-vous sûr.e de vouloir vous déconnecter de cet appareil ?", "SmartNet AppSync", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                My.Settings.AppSyncLastSyncTime = New Date(1, 1, 1)
                My.Settings.AppSyncDeviceNumber = ""
                ButtonManageAccount.Enabled = False
                ButtonManageAccount.Visible = False
                ButtonLoginLogout.Text = "Se connecter..."
                LabelUsername.Text = "Déconnecté.e"
                PictureBoxUserProfilePic.Image = My.Resources.Person
                BrowserForm.SeConnecterÀAppSyncToolStripMenuItem.Text = "Se connecter à AppSync..."
                BrowserForm.SeConnecterÀAppSyncToolStripMenuItem.Image = My.Resources.Person
            End If
        End If
    End Sub

    Private Sub ButtonManageAccount_Click(sender As Object, e As EventArgs) Handles ButtonManageAccount.Click
        Dim token As String = AppSyncAgent.GenerateToken()
        BrowserForm.AddTab("https://appsync.quentinpugeat.fr/login.php?action=oneclick&token=" + token)
        Me.Close()
    End Sub

    Private Sub TextBoxNewPageInAdsBlockerWhitelist_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNewPageInAdsBlockerWhitelist.TextChanged
        If TextBoxNewPageInAdsBlockerWhitelist.TextLength > 0 Then
            ButtonAddNewPageInAdsBlockerWhitelist.Enabled = True
        Else
            ButtonAddNewPageInAdsBlockerWhitelist.Enabled = False
        End If
    End Sub

    Private Sub ListBoxAdsBlockerWhitelistedPages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxAdsBlockerWhitelistedPages.SelectedIndexChanged
        If ListBoxAdsBlockerWhitelistedPages.SelectedIndex >= 0 Then
            ButtonRemovePageFromAdsBlockerWhitelist.Enabled = True
        Else
            ButtonRemovePageFromAdsBlockerWhitelist.Enabled = False
        End If
    End Sub

    Private Sub ButtonAddNewPageInAdsBlockerWhitelist_Click(sender As Object, e As EventArgs) Handles ButtonAddNewPageInAdsBlockerWhitelist.Click
        My.Settings.AdBlockerWhitelist.Add(TextBoxNewPageInAdsBlockerWhitelist.Text)
        TextBoxNewPageInAdsBlockerWhitelist.ResetText()
        ListBoxAdsBlockerWhitelistedPages.Items.Clear()
        For Each page In My.Settings.AdBlockerWhitelist
            ListBoxAdsBlockerWhitelistedPages.Items.Add(page)
        Next
    End Sub

    Private Sub ButtonRemovePageFromAdsBlockerWhitelist_Click(sender As Object, e As EventArgs) Handles ButtonRemovePageFromAdsBlockerWhitelist.Click
        My.Settings.AdBlockerWhitelist.Remove(ListBoxAdsBlockerWhitelistedPages.SelectedItem.ToString())
        ListBoxAdsBlockerWhitelistedPages.Items.Clear()
        For Each page In My.Settings.AdBlockerWhitelist
            ListBoxAdsBlockerWhitelistedPages.Items.Add(page)
        Next
    End Sub

    Private Sub TextBoxAppSyncDeviceName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxAppSyncDeviceName.TextChanged
        If TextBoxAppSyncDeviceName.Text.Length > 0 Then
            ButtonChangeAppSyncDeviceName.Enabled = True
        Else
            ButtonChangeAppSyncDeviceName.Enabled = False
        End If
    End Sub

    Private Sub ButtonChangeAppSyncDeviceName_Click(sender As Object, e As EventArgs) Handles ButtonChangeAppSyncDeviceName.Click
        Try
            If AppSyncAgent.SetDeviceName(TextBoxAppSyncDeviceName.Text) Then
                ButtonChangeAppSyncDeviceName.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("Une erreur est survenue lors du changement du nom de votre appareil." + vbCrLf + ex.Message, "SmartNet AppSync", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SettingsForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.BrowserSettingsSecurity = BrowserSettingsSecurityCheckBox.Checked
        My.Settings.ChildrenProtection = ChildrenProtectionCheckBox.Checked
        My.Settings.UserAgentLanguage = LanguagesComboBox.Text.Split(" "c)(0)
        Gecko.GeckoPreferences.User("intl.accept_languages") = My.Settings.UserAgentLanguage
        Gecko.GeckoPreferences.User("general.useragent.locale") = My.Settings.UserAgentLanguage
        My.Settings.Save()
        If My.Settings.AppSyncDeviceNumber <> "" Then
            AppSyncSendConfigAsync()
        End If
    End Sub

    Private Sub DoNotTrackCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles DoNotTrackCheckBox.CheckedChanged
        My.Settings.DoNotTrack = DoNotTrackCheckBox.Checked
        Gecko.GeckoPreferences.User("privacy.donottrackheader.enabled") = My.Settings.DoNotTrack
    End Sub

    Private Sub HomepageURLBox_TextChanged(sender As Object, e As EventArgs) Handles HomepageURLBox.TextChanged
        My.Settings.Homepage = HomepageURLBox.Text
    End Sub

    Private Sub PopUpsBlockerCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PopUpsBlockerCheckBox.CheckedChanged
        My.Settings.PopUpBlocker = PopUpsBlockerCheckBox.Checked
    End Sub

    Private Sub EraseCookiesCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles EraseCookiesCheckBox.CheckedChanged
        My.Settings.DeleteCookiesWhileClosing = EraseCookiesCheckBox.Checked
    End Sub

    Private Sub HistoryFavoritesSecurityCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles HistoryFavoritesSecurityCheckBox.CheckedChanged
        My.Settings.HistoryFavoritesSecurity = HistoryFavoritesSecurityCheckBox.Checked
    End Sub

    Private Sub PreventMultipleTabsCloseCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PreventMultipleTabsCloseCheckBox.CheckedChanged
        My.Settings.PreventMultipleTabsClose = PreventMultipleTabsCloseCheckBox.Checked
    End Sub

    Private Sub DefaultDownloadFolderTextBox_TextChanged(sender As Object, e As EventArgs) Handles DefaultDownloadFolderTextBox.TextChanged
        My.Settings.DefaultDownloadFolder = DefaultDownloadFolderTextBox.Text
    End Sub

    Private Sub ButtonSyncNow_Click(sender As Object, e As EventArgs) Handles ButtonSyncNow.Click
        AppSyncSyncNowAsync()
    End Sub
End Class