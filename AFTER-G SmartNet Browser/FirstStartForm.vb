Imports System.ComponentModel

Public Class FirstStartForm
    Dim etape As Integer
    Public Sub New()
        InitializeComponent()
        etape = 1
    End Sub

    Private Sub DeroulerEtape()
        Select Case etape
            Case 1
                'Définir paramètres utilisateur
                My.Settings.Homepage = HomepageURLBox.Text
                If RadioButton1.Checked = True Then
                    My.Settings.SearchEngine = 1
                End If
                If RadioButton2.Checked = True Then
                    My.Settings.SearchEngine = 2
                End If
                If RadioButton3.Checked = True Then
                    My.Settings.SearchEngine = 3
                End If
                If RadioButton4.Checked = True Then
                    My.Settings.SearchEngine = 4
                End If
                If RadioButton5.Checked = True Then
                    My.Settings.SearchEngine = 5
                End If
                My.Settings.AdBlocker = AdBlockerCheckBox.Checked
                NextButton.Enabled = False
                etape = 2
                DeroulerEtape()
            Case 2
                'Définir paramètres par défaut
                HomepageGroupBox.Visible = False
                SearchEngineGroupBox.Visible = False
                SmartNetSecurityGroupBox.Visible = False
                LabelTitle.Text = "Veuillez patienter..."
                LabelSubtitle.Text = "SmartNet Browser se prépare pour sa première utilisation."
                PictureBoxHourglass.Visible = True
                LabelState.Visible = True
                LabelState.Text = "Définition des paramètres par défaut pour la navigation privée..."
                My.Settings.PrivateBrowsing = False
                My.Settings.DeleteCookiesWhileClosing = False
                My.Settings.DoNotTrack = False
                LabelState.Text = "Définition du paramètre par défaut pour l'avertisseur de fermeture d'onglets multiples..."
                My.Settings.PreventMultipleTabsClose = True
                LabelState.Text = "Définition des paramètres par défaut pour la recherche personnalisée..."
                My.Settings.CustomSearchName = ""
                My.Settings.CustomSearchURL = ""
                LabelState.Text = "Définition du paramètre par défaut pour la mise à jour automatique..."
                My.Settings.AutoUpdates = True
                LabelState.Text = "Définition des paramètres par défaut pour SmartNet ChildGuard..."
                My.Settings.ChildrenProtection = False
                My.Settings.ChildrenProtectionPassword = ""
                LabelState.Text = "Définition du paramètre par défaut pour la sécurité du navigateur..."
                My.Settings.BrowserSettingsSecurity = False
                My.Settings.BrowserSettingsSecurityPassword = ""
                My.Settings.HistoryFavoritesSecurity = False
                LabelState.Text = "Définition des paramètres par défaut pour l'agent utilisateur..."
                My.Settings.UserAgent = ""
                My.Settings.UserAgentLanguage = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName
                LabelState.Text = "Définition des paramètres par défaut pour SmartNet AdsBlocker..."
                My.Settings.PopUpBlocker = My.Settings.AdBlocker
                My.Settings.AllowAdsSites = "http://quentinpugeat.pagesperso-orange.fr"
                LabelState.Text = "Définition des paramètres par défaut pour le téléchargement de fichiers..."
                Dim DownloadFolderrKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders")
                If DownloadFolderrKey Is Nothing Then
                    My.Settings.DefaultDownloadFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\Downloads"
                Else
                    My.Settings.DefaultDownloadFolder = DownloadFolderrKey.GetValue("{374DE290-123F-4565-9164-39C4925E467B}").ToString()
                End If
                LabelState.Text = "Définition des paramètres par défaut pour le comportement de SmartNet Browser..."
                My.Settings.CorrectlyClosed = True
                My.Settings.FirstStartFromReset = False
                My.Settings.FirstStart = False
                LabelState.Text = "La configuration initiale se termine bientôt..."
                etape = 3
                'Remercier l'utilisateur et l'inviter à fermer la fenêtre
                NextButton.Enabled = True
                NextButton.Text = "Terminer"
                LabelTitle.Text = "Merci !"
                LabelSubtitle.Text = "La configuration initiale de SmartNet Browser est terminée."
                PictureBoxHourglass.Image = My.Resources.ThumbUp
                LabelState.Text = "Vous pouvez commencer à naviguer sur Internet en cliquant sur Terminer. Vous retrouverez tous les paramètres de SmartNet Browser depuis le menu. Vous pouvez aussi relancer cet assistant depuis les paramètres avancés."
            Case 3
                Me.Close()
        End Select
    End Sub

    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        DeroulerEtape()
    End Sub

    Private Sub FirstStartForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FirstStartForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If My.Settings.FirstStart = True Then
            Dim res As MsgBoxResult
            res = MsgBox("Êtes-vous sûr(e) de vouloir passer cette étape ? Vous utiliserez SmartNet Browser avec les paramètres par défaut. Cette fenêtre se réaffichera lors du prochain démarrage.", MsgBoxStyle.YesNo, "Configuration initiale de SmartNet Browser")
            If res = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class