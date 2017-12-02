Imports System.ComponentModel
Imports System.Net
Imports Gecko.Events
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.OleDb

Public Class BrowserForm
    Public WithEvents CurrentDocument As Gecko.GeckoDocument
    Public MousePoint As Point
    Public Ele As Gecko.GeckoElement
    Public MessageBarAction As String
    Public MessageBarButtonLink As String
    Dim tabPageIndex As Integer = 0

    Public Function GetSHA512(ByVal str As String) As String
        'desc   : Encrypt a strin using the SHA512 algorithm
        Dim UE As UnicodeEncoding = New UnicodeEncoding
        Dim HashValue As Byte()
        'convert the string to Byte
        Dim MessageBytes As Byte() = UE.GetBytes(str)
        Dim SHhash As SHA512Managed = New SHA512Managed
        Dim strHex As String = ""

        'create the hash table using the SHA512 algorithm
        HashValue = SHhash.ComputeHash(MessageBytes)
        'convert the hash table to a string
        For Each b As Byte In HashValue
            strHex += String.Format("{0:x2}", b)
        Next
        Return strHex
    End Function

    Private Sub HomepageButton_MouseEnter(sender As Object, e As EventArgs) Handles HomepageButton.MouseEnter
        HomepageButton.Image = HomepageButton.InitialImage
    End Sub
    Private Sub HomepageButton_MouseLeave(sender As Object, e As EventArgs) Handles HomepageButton.MouseLeave
        HomepageButton.Image = HomepageButton.ErrorImage
    End Sub
    Private Sub PreviouspageButton_MouseEnter(sender As Object, e As EventArgs) Handles PreviouspageButton.MouseEnter
        PreviouspageButton.Image = PreviouspageButton.InitialImage
    End Sub
    Private Sub PreviouspageButton_MouseLeave(sender As Object, e As EventArgs) Handles PreviouspageButton.MouseLeave
        PreviouspageButton.Image = PreviouspageButton.ErrorImage
    End Sub
    Private Sub NextpageButton_MouseEnter(sender As Object, e As EventArgs) Handles NextpageButton.MouseEnter
        NextpageButton.Image = NextpageButton.InitialImage
    End Sub
    Private Sub NextpageButton_MouseLeave(sender As Object, e As EventArgs) Handles NextpageButton.MouseLeave
        NextpageButton.Image = NextpageButton.ErrorImage
    End Sub
    Private Sub RefreshButton_MouseEnter(sender As Object, e As EventArgs) Handles RefreshButton.MouseEnter
        RefreshButton.Image = RefreshButton.InitialImage
    End Sub
    Private Sub RefreshButton_MouseLeave(sender As Object, e As EventArgs) Handles RefreshButton.MouseLeave
        RefreshButton.Image = RefreshButton.ErrorImage
    End Sub
    Private Sub StopButton_MouseEnter(sender As Object, e As EventArgs) Handles StopButton.MouseEnter
        StopButton.Image = StopButton.InitialImage
    End Sub
    Private Sub StopButton_MouseLeave(sender As Object, e As EventArgs) Handles StopButton.MouseLeave
        StopButton.Image = StopButton.ErrorImage
    End Sub
    Private Sub GoButton_MouseEnter(sender As Object, e As EventArgs) Handles GoButton.MouseEnter
        GoButton.Image = GoButton.InitialImage
    End Sub
    Private Sub GoButton_MouseLeave(sender As Object, e As EventArgs) Handles GoButton.MouseLeave
        GoButton.Image = GoButton.ErrorImage
    End Sub
    Private Sub SearchButton_MouseEnter(sender As Object, e As EventArgs) Handles SearchButton.MouseEnter
        SearchButton.Image = SearchButton.InitialImage
    End Sub
    Private Sub SearchButton_MouseLeave(sender As Object, e As EventArgs) Handles SearchButton.MouseLeave
        SearchButton.Image = SearchButton.ErrorImage
    End Sub
    Private Sub CloseTabButton_MouseEnter(sender As Object, e As EventArgs) Handles CloseTabButton.MouseEnter
        CloseTabButton.Image = CloseTabButton.InitialImage
    End Sub
    Private Sub CloseTabButton_MouseLeave(sender As Object, e As EventArgs) Handles CloseTabButton.MouseLeave
        CloseTabButton.Image = CloseTabButton.ErrorImage
    End Sub
    Private Sub NewTabButton_MouseEnter(sender As Object, e As EventArgs) Handles NewTabButton.MouseEnter
        NewTabButton.Image = NewTabButton.InitialImage
    End Sub
    Private Sub NewTabButton_MouseLeave(sender As Object, e As EventArgs) Handles NewTabButton.MouseLeave
        NewTabButton.Image = NewTabButton.ErrorImage
    End Sub

    Public Sub AddTab(ByRef URL As String, ByRef TabControl As TabControl)
        Try
            Dim NewBrowser As New CustomBrowser
            Dim NewTab As New TabPage
            NewBrowser.Tag = NewTab
            NewTab.Tag = NewBrowser
            ImageList1.Images.Add(FaviconBox.InitialImage)
            BrowserTabs.ImageList.Images.Add(FaviconBox.InitialImage)
            NewTab.ContextMenuStrip = TabsContextMenuStrip
            NewTab.ContextMenuStrip.Tag = NewTab
            TabControl.TabPages.Add(NewTab)
            NewTab.Controls.Add(NewBrowser)
            NewBrowser.Dock = DockStyle.Fill
            NewBrowser.Navigate(URL)
            BrowserTabs.SelectedTab = NewTab
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Public Sub CheckFavicon()
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            If WB.Url.ToString.Contains("https://quentinpugeat.wixsite.com/smartnetbrowserhome") Or WB.Url.ToString.Contains(My.Application.Info.DirectoryPath) Or WB.Url.ToString.Contains("about:") Then
                FaviconBox.Image = FaviconBox.InitialImage
                BrowserTabs.ImageList.Images.Item(BrowserTabs.SelectedIndex) = FaviconBox.InitialImage
                BrowserTabs.SelectedTab.ImageIndex = BrowserTabs.SelectedIndex
                PropertiesForm.FaviconBox.Image = PropertiesForm.FaviconBox.InitialImage
            Else
                Dim url As Uri = New Uri(WB.Url.ToString)
                If url.HostNameType = UriHostNameType.Dns Then
                    Dim iconURL = "http://" & url.Host & "/favicon.ico"
                    Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(iconURL)
                    Dim response As System.Net.HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                    Dim stream As System.IO.Stream = response.GetResponseStream()
                    Dim favicon = Image.FromStream(stream)
                    FaviconBox.Image = favicon
                    BrowserTabs.ImageList.Images.Item(BrowserTabs.SelectedIndex) = favicon
                    BrowserTabs.SelectedTab.ImageIndex = BrowserTabs.SelectedIndex
                    PropertiesForm.FaviconBox.Image = favicon
                End If
            End If
        Catch ex As Exception
            FaviconBox.Image = FaviconBox.ErrorImage
            BrowserTabs.ImageList.Images.Item(BrowserTabs.SelectedIndex) = FaviconBox.ErrorImage
            BrowserTabs.SelectedTab.ImageIndex = BrowserTabs.SelectedIndex
            PropertiesForm.FaviconBox.Image = PropertiesForm.FaviconBox.ErrorImage
        End Try
    End Sub

    Private Sub FormEssai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If My.Settings.FirstStart = True And My.Settings.FirstStartFromReset = False Then
                My.Settings.Upgrade()
                My.Settings.Reload()
                If My.Settings.ChildrenProtectionPassword.Length <> 128 And My.Settings.ChildrenProtectionPassword.Length <> 0 Then
                    Dim OriginalPassword As String = My.Settings.ChildrenProtectionPassword
                    My.Settings.ChildrenProtectionPassword = GetSHA512(OriginalPassword)
                End If
                If My.Settings.BrowserSettingsSecurityPassword.Length <> 128 And My.Settings.BrowserSettingsSecurityPassword.Length <> 0 Then
                    Dim OriginalPassword As String = My.Settings.BrowserSettingsSecurityPassword
                    My.Settings.BrowserSettingsSecurityPassword = GetSHA512(OriginalPassword)
                End If
                My.Settings.UserAgentLanguage = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName
                FirstStartForm.Show()
            End If
            AddTab(My.Settings.Homepage, BrowserTabs)
            For Each item In My.Settings.Favorites
                URLBox.Items.Add(item)
            Next
            For Each item2 In My.Settings.History
                URLBox.Items.Add(item2)
            Next
            For Each item3 In My.Settings.SearchHistory
                SearchBox.Items.Add(item3)
            Next

            AddHandler Gecko.LauncherDialog.Download, AddressOf LauncherDialog_Download
            URLBox.Select(0, 0)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub LauncherDialog_Download(ByVal sender As Object, ByVal e As Gecko.LauncherDialogEvent)
        Try
            Dim ie As New WebBrowser
            ie.Navigate(e.Url)
            'DownloadForm.FileNameLabel.Text = e.Url.ToString.Substring(e.Url.ToString.LastIndexOf("/") + 1)
            'DownloadForm.URLLabel.Text = "À partir de : " + e.Url.ToString
            'DownloadForm.DownloadLink = e.Url.ToString
            'DownloadForm.Show()
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            Else
                MsgBox("Une erreur est survenue lors du téléchargement. Merci de réessayer. Code d'erreur : DOWNLOAD_ERROR", MsgBoxStyle.Critical, "Téléchargement du fichier")
            End If
        End Try
    End Sub
    Private Sub GoForward(sender As Object, e As EventArgs) Handles NextpageButton.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If WB.CanGoForward = True Then
            WB.GoForward()
        End If
    End Sub
    Private Sub GoBack(sender As Object, e As EventArgs) Handles PreviouspageButton.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If WB.CanGoBack = True Then
            WB.GoBack()
        End If
    End Sub
    Private Sub RefreshPage(sender As Object, e As EventArgs) Handles RefreshButton.Click, ActualiserLaPageToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Reload()
    End Sub
    Private Sub StopPage(sender As Object, e As EventArgs) Handles StopButton.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Stop()
        StopButton.Visible = False
        RefreshButton.Visible = True
        GoButton.Visible = False
        LoadingGif.Visible = False
    End Sub

    Private Sub NewTabOpen(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTabButton.Click, NewTabToolStripMenuItem.Click
        AddTab(My.Settings.Homepage, BrowserTabs)
    End Sub

    Private Sub CloseTab(sender As Object, e As EventArgs) Handles CloseTabButton.Click, CloseTabToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            WB.Navigate("about:blank")
            If BrowserTabs.TabPages.Count = 1 Then
                Me.Close()
            Else
                My.Settings.LastClosedTab = WB.Url.ToString
                BrowserTabs.TabPages.Remove(BrowserTabs.SelectedTab)
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub GoButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoButton.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(Me.URLBox.Text)
    End Sub
    Private Sub URLBoxKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles URLBox.KeyDown
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If e.KeyCode = Keys.Enter Then
            WB.Navigate(URLBox.Text)
        End If
    End Sub

    Private Sub URLBox_KeyPress(sender As Object, e As EventArgs) Handles URLBox.KeyPress
        StopButton.Visible = False
        RefreshButton.Visible = False
        GoButton.Visible = True
        LoadingGif.Visible = False
    End Sub

    Private Sub SavePageAs(sender As Object, e As EventArgs) Handles SavePageToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            If SavePageDialog.ShowDialog = DialogResult.OK Then
                WB.SaveDocument(SavePageDialog.OpenFile.ToString)
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub OpenDocument(sender As Object, e As EventArgs) Handles OpenPageToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                WB.Navigate(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub PrintPreview(sender As Object, e As EventArgs) Handles AperçuAvantImpressionToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            WB.Navigate("javascript:print()")
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            Else
                MsgBox("Une erreur est survenue lors du lancement de l'impression. Veuillez réessayer. Code d'erreur : JAVASCRIPT_PRINT_ERROR", MsgBoxStyle.Critical, "Impression de la page")
            End If
        End Try
    End Sub

    Private Sub HomeNavigating(sender As Object, e As EventArgs) Handles HomepageButton.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(My.Settings.Homepage)
    End Sub

    Private Sub MenuPrincipalNavigating(sender As Object, e As EventArgs) Handles MenuPrincipalToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate("https://quentinpugeat.wixsite.com/smartnetbrowserhome")
    End Sub
    Private Sub AFTERGServicesWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AFTERGServicesWebToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate("https://quentinpugeat.wixsite.com/lesiteofficiel")
    End Sub
    Private Sub AFTERGAppsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AFTERGAppsToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate("https://quentinpugeat.wixsite.com/apps")
    End Sub

    Private Sub Cut(sender As Object, e As EventArgs) Handles CouperToolStripMenuItem.Click, CouperToolStripMenuItem1.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            If WB.CanCutSelection = True Then
                WB.CutSelection()
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub Copy(sender As Object, e As EventArgs) Handles CopierToolStripMenuItem.Click, CopierToolStripMenuItem1.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            If WB.CanCopySelection = True Then
                WB.CopySelection()
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub Paste(sender As Object, e As EventArgs) Handles CollerToolStripMenuItem.Click, CollerToolStripMenuItem1.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            If WB.CanPaste Then
                WB.Paste()
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub AddFavorite(sender As Object, e As EventArgs) Handles AjouterCettePageDansLesFavorisToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)

        Try
            My.Settings.Favorites.Add(WB.Url.ToString)
            URLBox.Items.Add(WB.Url.ToString)
            My.Settings.Save()
            If My.Settings.Favorites.Contains(WB.ToString) Then
                FavoritesButton.Image = FavoritesButton.ErrorImage
            Else
                FavoritesButton.Image = FavoritesButton.InitialImage
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
                If My.Settings.Favorites.Contains(WB.ToString) Then
                    FavoritesButton.Image = FavoritesButton.ErrorImage
                Else
                    FavoritesButton.Image = FavoritesButton.InitialImage
                End If
            Else
                If My.Settings.Favorites.Contains(WB.ToString) Then
                    FavoritesButton.Image = FavoritesButton.ErrorImage
                Else
                    FavoritesButton.Image = FavoritesButton.InitialImage
                    MsgBox("Désolé, une erreur est survenue, votre favori n'est pas enregistré. Code d'erreur : FAVORITE_SAVE_ERROR", MsgBoxStyle.Critical, "Enregistrer dans les favoris")
                End If
            End If
        End Try
    End Sub

    Private Sub ShowFavorites(sender As Object, e As EventArgs) Handles AfficherLesFavorisToolStripMenuItem.Click
        Try
            If My.Settings.HistoryFavoritesSecurity = True Then
                EnterBrowserSettingsSecurityForm.SecurityMode = "Favorites"
                EnterBrowserSettingsSecurityForm.ShowDialog()
            Else
                FavoritesForm.Show()
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub ShowHistory(sender As Object, e As EventArgs) Handles AfficherLhistoriqueToolStripMenuItem.Click
        Try
            If My.Settings.HistoryFavoritesSecurity = True Then
                EnterBrowserSettingsSecurityForm.SecurityMode = "History"
                EnterBrowserSettingsSecurityForm.ShowDialog()
            Else
                HistoryForm.Show()
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub GoToSettings(sender As Object, e As EventArgs) Handles ParamètresToolStripMenuItem.Click
        Try
            If My.Settings.BrowserSettingsSecurity = True Then
                EnterBrowserSettingsSecurityForm.SecurityMode = "Settings"
                EnterBrowserSettingsSecurityForm.ShowDialog()
            Else
                SettingsForm.ShowDialog()
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub DownloadUpdateButton_Click(sender As Object, e As EventArgs) Handles TéléchargerLaVersionXXXXToolStripMenuItem.Click
        UpdaterForm.ShowDialog()
    End Sub
    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles UpdateNotifyIcon.MouseDoubleClick
        UpdaterForm.Show()
        UpdateNotifyIcon.Visible = False
    End Sub

    Private Sub PleinÉcranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PleinÉcranToolStripMenuItem.Click
        Try
            If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable And Me.WindowState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
            End If
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
            PleinÉcranToolStripMenuItem.Visible = False
            PleinÉcranToolStripMenuItem.Enabled = False
            QuitterLePleinÉcranToolStripMenuItem.Visible = True
            QuitterLePleinÉcranToolStripMenuItem.Enabled = True
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub QuitterLePleinÉcranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterLePleinÉcranToolStripMenuItem.Click
        Try
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Maximized
            PleinÉcranToolStripMenuItem.Visible = True
            PleinÉcranToolStripMenuItem.Enabled = True
            QuitterLePleinÉcranToolStripMenuItem.Visible = False
            QuitterLePleinÉcranToolStripMenuItem.Enabled = False
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub SupportCenterNavigating(sender As Object, e As EventArgs) Handles CentreDaideEnLigneToolStripMenuItem.Click
        AddTab("https://quentinpugeat.wixsite.com/apps/support-browser", BrowserTabs)
    End Sub
    Private Sub ContacterLéquipeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContacterLéquipeToolStripMenuItem.Click
        AddTab("https://quentinpugeat.wixsite.com/lesiteofficiel/contact", BrowserTabs)
    End Sub
    Private Sub EnvoyerVosCommentairesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvoyerVosCommentairesToolStripMenuItem.Click
        AddTab("https://docs.google.com/forms/d/e/1FAIpQLSeefp223iFND5m2GG9fsKZo3oI6hC4Hthr14H2mFsFzU2WbIw/viewform?usp=sf_link", BrowserTabs)
    End Sub
    Private Sub AboutSmartNetBrowser(sender As Object, e As EventArgs) Handles ÀProposDeSmartNetBrowserToolStripMenuItem.Click
        AboutForm.ShowDialog()
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Select Case My.Settings.SearchEngine
            Case 1
                WB.Navigate("https://www.google.fr/search?q=" + SearchBox.Text)
            Case 2
                WB.Navigate("https://www.bing.com/search?q=" + SearchBox.Text)
            Case 3
                WB.Navigate("https://fr.search.yahoo.com/search;_ylt=Art7C6mA.dKDerFt5RNNyYFNhJp4?p=" + SearchBox.Text)
            Case 4
                WB.Navigate("https://duckduckgo.com/?q=" + SearchBox.Text)
            Case 5
                WB.Navigate("https://www.qwant.com/?q=" + SearchBox.Text)
            Case 0
                WB.Navigate(My.Settings.CustomSearchURL + SearchBox.Text)
        End Select

        If My.Settings.PrivateBrowsing = False Then
            SearchBox.Items.Add(SearchBox.Text)
            My.Settings.SearchHistory.Add(SearchBox.Text)
        End If
    End Sub
    Private Sub SearchBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles SearchBox.KeyDown
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If e.KeyCode = Keys.Enter Then
            Select Case My.Settings.SearchEngine
                Case 1
                    WB.Navigate("https://www.google.fr/search?q=" + SearchBox.Text)
                Case 2
                    WB.Navigate("https://www.bing.com/search?q=" + SearchBox.Text)
                Case 3
                    WB.Navigate("https://fr.search.yahoo.com/search;_ylt=Art7C6mA.dKDerFt5RNNyYFNhJp4?p=" + SearchBox.Text)
                Case 4
                    WB.Navigate("https://duckduckgo.com/?q=" + SearchBox.Text)
                Case 5
                    WB.Navigate("https://www.qwant.com/?q=" + SearchBox.Text)
                Case 0
                    WB.Navigate(My.Settings.CustomSearchURL + SearchBox.Text)
            End Select

            If My.Settings.PrivateBrowsing = False Then
                SearchBox.Items.Add(SearchBox.Text)
                My.Settings.SearchHistory.Add(SearchBox.Text)
            End If
        End If

    End Sub

    Private Sub Zoom_100(sender As Object, e As EventArgs) Handles Zoom100.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(1.0F)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub Zoom_50(sender As Object, e As EventArgs) Handles Zoom50.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(0.5F)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub Zoom_75(sender As Object, e As EventArgs) Handles Zoom75.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(0.75F)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub Zoom_125(sender As Object, e As EventArgs) Handles Zoom125.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(1.25F)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub Zoom_150(sender As Object, e As EventArgs) Handles Zoom150.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(1.5F)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub Zoom_175(sender As Object, e As EventArgs) Handles Zoom175.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(1.75F)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub Zoom_200(sender As Object, e As EventArgs) Handles Zoom200.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(2.0F)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub Zoom_250(sender As Object, e As EventArgs) Handles Zoom250.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(2.5F)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub Zoom_300(sender As Object, e As EventArgs) Handles Zoom300.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(3.0F)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub Zoom_400(sender As Object, e As EventArgs) Handles Zoom400.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(4.0F)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub ZoomPlusButton_Click(sender As Object, e As EventArgs) Handles ZoomPlusButton.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(WB.GetDocShellAttribute.GetContentViewerAttribute.GetFullZoomAttribute + 0.25F)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub ZoomMinusButton_Click(sender As Object, e As EventArgs) Handles ZoomMinusButton.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(WB.GetDocShellAttribute.GetContentViewerAttribute.GetFullZoomAttribute - 0.25F)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub SmartNetBrowserClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If BrowserTabs.TabPages.Count > 1 Then
                If My.Settings.PreventMultipleTabsClose = True Then
                    e.Cancel = True
                    PreventTabsCloseForm.ShowDialog()
                Else
                    My.Settings.LastClosedTab = ""
                    My.Settings.Save()
                End If
            Else
                My.Settings.LastClosedTab = ""
                My.Settings.Save()
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub SmartNetBrowserClosingWithButton(sender As Object, e As EventArgs) Handles FermerSmartNetBrowserToolStripMenuItem.Click
        Try
            If BrowserTabs.TabPages.Count > 1 Then
                If My.Settings.PreventMultipleTabsClose = True Then
                    PreventTabsCloseForm.ShowDialog()
                Else
                    My.Settings.Save()
                    Application.Exit()
                    End
                End If
            Else
                My.Settings.Save()
                Application.Exit()
                End
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub ActiveTabChange(sender As Object, e As EventArgs) Handles BrowserTabs.SelectedIndexChanged
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            CheckFavicon()
            PreviouspageButton.Visible = WB.CanGoBack
            NextpageButton.Visible = WB.CanGoForward
            If WB.Url.ToString.Contains(My.Application.Info.DirectoryPath) Or WB.Url.ToString.Contains("https://quentinpugeat.wixsite.com/smartnetbrowserhome") Then
                URLBox.Text = ""
            Else
                URLBox.Text = WB.Url.ToString
            End If
            CurrentDocument = WB.Document
            If WB.DocumentTitle = "" Then
                If WB.Url.ToString.Length > 30 Then
                    BrowserTabs.SelectedTab.Text = WB.Url.ToString.Substring(0, 29) & "..."
                Else
                    BrowserTabs.SelectedTab.Text = WB.Url.ToString
                End If
                Me.Text = WB.Url.ToString + " - SmartNet Browser"
            Else
                If WB.DocumentTitle.Length > 30 Then
                    BrowserTabs.SelectedTab.Text = WB.DocumentTitle.Substring(0, 29) & "..."
                Else
                    BrowserTabs.SelectedTab.Text = WB.DocumentTitle
                End If
                Me.Text = WB.DocumentTitle.ToString + " - SmartNet Browser"
            End If
            If (WB.Url.ToString.Contains("www.youtube.com/watch?v=") Or WB.Url.ToString.Contains("dailymotion.com/video")) And Not WB.Url.ToString.Contains("www.clipconverter.cc") Then
                TéléchargerCetteVidéoToolStripMenuItem.Visible = True
                ToolStripSeparator6.Visible = True
            Else
                TéléchargerCetteVidéoToolStripMenuItem.Visible = False
                ToolStripSeparator6.Visible = False
            End If
            If My.Settings.Favorites.Contains(WB.ToString) Then
                FavoritesButton.Image = FavoritesButton.ErrorImage
            Else
                FavoritesButton.Image = FavoritesButton.InitialImage
            End If
            LoadingGif.Visible = False
            MessageBarPictureBox.Visible = False
            MessageBarButton.Visible = False
            MessageBarCloseButton.Visible = False
            MessageBarLabel.Visible = False
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub TéléchargerCetteVidéoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TéléchargerCetteVidéoToolStripMenuItem.Click
        AddTab("http://www.clipconverter.cc/?ref=addon&url=" + URLBox.Text, BrowserTabs)
    End Sub

    Private Sub ShowProperties(sender As Object, e As EventArgs) Handles FaviconBox.DoubleClick, PropriétésToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        'WB.ShowPageProperties()
        Dim PageFormat As String = WB.Url.ToString.Substring(WB.Url.ToString.LastIndexOf(".") + 1)
        If WB.DocumentTitle = "" Then
            PropertiesForm.PageNameLabel.Text = "Page sans nom"
        Else
            PropertiesForm.PageNameLabel.Text = WB.DocumentTitle
        End If
        PropertiesForm.PageURLTextBox.Text = WB.Url.ToString
        Select Case PageFormat
            Case "htm"
                PropertiesForm.PageTypeLabel.Text = "Type : Page Web HTML"
            Case "xml"
                PropertiesForm.PageTypeLabel.Text = "Type : Fichier XML"
            Case "jpg"
                PropertiesForm.PageTypeLabel.Text = "Type : Image JPEG"
            Case "png"
                PropertiesForm.PageTypeLabel.Text = "Type : Image PNG"
            Case "bmp"
                PropertiesForm.PageTypeLabel.Text = "Type : Image bitmap"
            Case "svg"
                PropertiesForm.PageTypeLabel.Text = "Type : Image SVG"
            Case Else
                PropertiesForm.PageTypeLabel.Text = "Type : Page Web"
        End Select
        CheckFavicon()
        PropertiesForm.ShowDialog()
    End Sub

    Private Sub OuvrirLeLienToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirLeLienToolStripMenuItem.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            Dim ClipboardOriginalData As IDataObject
            ClipboardOriginalData = Clipboard.GetDataObject
            WB.CopyLinkLocation()
            Dim Link As String = Clipboard.GetText
            Clipboard.SetDataObject(ClipboardOriginalData, True)
            WB.Navigate(Link)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            Else
                MsgBox("Erreur lors de l'ouverture du lien. Veuillez réessayer. Code d'erreur : LINK_OPENING_ERROR", MsgBoxStyle.Critical, "Ouvrir le lien")
            End If
        End Try
    End Sub

    Public Sub OuvrirDansUnNouvelOngletToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirDansUnNouvelOngletToolStripMenuItem.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            Dim ClipboardOriginalData As IDataObject
            ClipboardOriginalData = Clipboard.GetDataObject
            WB.CopyLinkLocation()
            Dim Link As String = Clipboard.GetText
            Clipboard.SetDataObject(ClipboardOriginalData, True)
            AddTab(Link, BrowserTabs)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            Else
                MsgBox("Erreur lors de l'ouverture du lien. Veuillez réessayer. Code d'erreur : LINK_OPENING_INNEWTAB_ERROR", MsgBoxStyle.Critical, "Ouvrir le lien")
            End If
        End Try
    End Sub

    Private Sub CopierLadresseDuLienToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopierLadresseDuLienToolStripMenuItem.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            If WB.CanCopyLinkLocation = True Then
                WB.CopyLinkLocation()
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub AjouterLeLienAuxFavorisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouterLeLienAuxFavorisToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            Dim ClipboardOriginalData As IDataObject
            ClipboardOriginalData = Clipboard.GetDataObject
            WB.CopyLinkLocation()
            Dim Link As String = Clipboard.GetText
            Clipboard.SetDataObject(ClipboardOriginalData, True)

            My.Settings.Favorites.Add(Link)
            URLBox.Items.Add(Link)
            My.Settings.Save()
            If My.Settings.Favorites.Contains(Link) Then
                MsgBox("Le favori est enregistré.", CType(MessageBoxIcon.Asterisk, MsgBoxStyle), "SmartNet Browser")
            Else
                MsgBox("Désolé, une erreur est survenue, votre favori n'est pas enregistré. Code d'erreur : LINK_FAVORITE_SAVE_ERROR", MsgBoxStyle.Critical, "Enregistrer dans les favoris")
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
                If My.Settings.Favorites.Contains(Link) Then
                    MsgBox("Le favori est enregistré.", CType(MessageBoxIcon.Asterisk, MsgBoxStyle), "SmartNet Browser")
                Else
                    MsgBox("Désolé, une erreur est survenue, votre favori n'est pas enregistré. Code d'erreur : LINK_FAVORITE_SAVE_ERROR", MsgBoxStyle.Critical, "Enregistrer dans les favoris")
                End If
            Else
                If My.Settings.Favorites.Contains(Link) Then
                    MsgBox("Le favori est enregistré.", CType(MessageBoxIcon.Asterisk, MsgBoxStyle), "SmartNet Browser")
                Else
                    MsgBox("Désolé, une erreur est survenue, votre favori n'est pas enregistré. Code d'erreur : LINK_FAVORITE_SAVE_ERROR", MsgBoxStyle.Critical, "Enregistrer dans les favoris")
                End If
            End If
        End Try
    End Sub

    Private Sub EnregistrerLimageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnregistrerLimageToolStripMenuItem.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            Dim ClipboardActualData As IDataObject
            ClipboardActualData = Clipboard.GetDataObject
            WB.CopyImageLocation()
            Dim ImageSource As String = Clipboard.GetText
            Clipboard.SetDataObject(ClipboardActualData, True)

            'Dim ImageSource As String = Ele.GetAttribute("src")
            Dim FileExtension As String = ImageSource.Substring(ImageSource.LastIndexOf(".") + 1)
            Dim FileName As String = ImageSource.Substring(ImageSource.LastIndexOf("/") + 1)
            Dim ImageDownloader As New WebClient
            SaveImageDialog.FileName = FileName
            SaveImageDialog.DefaultExt = FileExtension
            SaveImageDialog.Filter = "Image|*." + FileExtension
            If SaveImageDialog.ShowDialog = MsgBoxResult.Ok Then
                ImageDownloader.DownloadFile(ImageSource, SaveImageDialog.FileName.ToString)
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            Else
                MsgBox("Erreur lors de l'enregistrement de l'image. Veuillez réessayer. Code d'erreur : IMAGE_SAVING_ERROR", MsgBoxStyle.Critical, "Ouvrir le lien")
            End If
        End Try
    End Sub

    Private Sub CopierLadresseDeLimageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopierLadresseDeLimageToolStripMenuItem.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.CopyImageLocation()
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub AfficherLimageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfficherLimageToolStripMenuItem.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            Dim ClipboardActualData As IDataObject
            ClipboardActualData = Clipboard.GetDataObject
            WB.CopyImageLocation()
            Dim ImageSource As String = Clipboard.GetText
            Clipboard.SetDataObject(ClipboardActualData, True)


            WB.Navigate(ImageSource) 'Ele.GetAttribute("src")
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub AfficherLeCodeSourceDeLaPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfficherLeCodeSourceDeLaPageToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        AddTab("view-source:" & WB.Url.ToString, BrowserTabs)
    End Sub

    Private Sub LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Dim ClipboardActualData As IDataObject
        ClipboardActualData = Clipboard.GetDataObject
        WB.CopySelection()
        Dim Selection As String = Clipboard.GetText
        Clipboard.SetDataObject(ClipboardActualData, True)

        Select Case My.Settings.SearchEngine
            Case 1
                WB.Navigate("https://www.google.fr/search?q=" + Selection)
            Case 2
                WB.Navigate("https://www.bing.com/search?q=" + Selection)
            Case 3
                WB.Navigate("https://fr.search.yahoo.com/search;_ylt=Art7C6mA.dKDerFt5RNNyYFNhJp4?p=" + Selection)
            Case 4
                WB.Navigate("https://duckduckgo.com/?q=" + Selection)
            Case 5
                WB.Navigate("https://www.qwant.com/?q=" + Selection)
            Case 0
                WB.Navigate(My.Settings.CustomSearchURL + Selection)
        End Select

        Try
            If My.Settings.PrivateBrowsing = False Then
                SearchBox.Items.Add(WB.CopySelection.ToString)
                My.Settings.SearchHistory.Add(WB.CopySelection.ToString)
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub


    Private Sub FavoritesButton_Click(sender As Object, e As EventArgs) Handles FavoritesButton.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            If My.Settings.Favorites.Contains(WB.Url.ToString) Then
                FavoritesForm.Show()
            Else
                My.Settings.Favorites.Add(WB.Url.ToString)
                URLBox.Items.Add(WB.Url.ToString)
                My.Settings.Save()
                If My.Settings.Favorites.Contains(WB.Url.ToString) Then
                    FavoritesButton.Image = FavoritesButton.ErrorImage
                Else
                    FavoritesButton.Image = FavoritesButton.InitialImage
                    MsgBox("Désolé, une erreur est survenue, votre favori n'est pas enregistré. Code d'erreur : FAVORITE_SAVE_ERROR", MsgBoxStyle.Critical, "Enregistrer dans les favoris")
                End If
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            Else
                If My.Settings.Favorites.Contains(WB.Url.ToString) Then
                    FavoritesButton.Image = FavoritesButton.ErrorImage
                Else
                    FavoritesButton.Image = FavoritesButton.InitialImage
                    MsgBox("Désolé, une erreur est survenue, votre favori n'est pas enregistré. Code d'erreur : FAVORITE_SAVE_ERROR", MsgBoxStyle.Critical, "Enregistrer dans les favoris")
                End If
            End If
        End Try
    End Sub



    Private Sub MainMenu_Click(sender As Object, e As EventArgs) Handles MainMenu.DropDownOpening
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            CouperToolStripMenuItem.Enabled = WB.CanCutSelection
            CopierToolStripMenuItem.Enabled = WB.CanCopySelection
            CollerToolStripMenuItem.Enabled = WB.CanPaste
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Public Link As String

    Private Sub BrowserContextMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles BrowserContextMenuStrip.Opening
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            CopierLadresseDeLimageToolStripMenuItem.Visible = WB.CanCopyImageLocation
            EnregistrerLimageToolStripMenuItem.Visible = WB.CanCopyImageLocation
            AfficherLimageToolStripMenuItem.Visible = WB.CanCopyImageLocation
            ImageToolStripSeparator.Visible = WB.CanCopyImageLocation
            CopierLadresseDuLienToolStripMenuItem.Visible = WB.CanCopyLinkLocation
            OuvrirLeLienToolStripMenuItem.Visible = WB.CanCopyLinkLocation
            OuvrirDansUnNouvelOngletToolStripMenuItem.Visible = WB.CanCopyLinkLocation
            AjouterLeLienAuxFavorisToolStripMenuItem.Visible = WB.CanCopyLinkLocation
            LinkToolStripSeparator.Visible = WB.CanCopyLinkLocation
            CouperToolStripMenuItem1.Visible = WB.CanCutSelection
            CollerToolStripMenuItem1.Visible = WB.CanPaste
            CopierToolStripMenuItem1.Visible = WB.CanCopySelection
            LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem.Visible = WB.CanCopySelection
            If WB.CanCutSelection = True Or WB.CanPaste = True Or WB.CanCopySelection = True Then
                EditionToolStripSeparator.Visible = True
            Else
                EditionToolStripSeparator.Visible = False
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub URLBox_TextChanged(sender As Object, e As EventArgs) Handles URLBox.TextChanged
        If URLBox.Text = "" Then
            URLBoxLabel.Visible = True
        Else
            URLBoxLabel.Visible = False
        End If
    End Sub
    Private Sub SearchBox_TextChanged(sender As Object, e As EventArgs) Handles SearchBox.TextChanged
        If SearchBox.Text = "" Then
            SearchBoxLabel.Visible = True
        Else
            SearchBoxLabel.Visible = False
        End If
    End Sub
    Private Sub URLBoxLabel_Click(sender As Object, e As EventArgs) Handles URLBoxLabel.Click
        URLBox.Focus()
    End Sub
    Private Sub SearchBoxLabel_Click(sender As Object, e As EventArgs) Handles SearchBoxLabel.Click
        SearchBox.Focus()
    End Sub

    Private Sub SélectionnerToutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SélectionnerToutToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.SelectAll()
    End Sub
    Private Sub RechercherDansLaPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RechercherDansLaPageToolStripMenuItem.Click
        SearchTextInPageForm.Show()
    End Sub

    Private Sub BrowserForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            Select Case e.KeyCode
                Case Keys.BrowserBack
                    WB.GoBack()
                Case Keys.BrowserFavorites
                    FavoritesForm.Show()
                Case Keys.BrowserForward
                    WB.GoForward()
                Case Keys.BrowserHome
                    AddTab(My.Settings.Homepage, BrowserTabs)
                Case Keys.BrowserRefresh
                    WB.Reload()
                Case Keys.BrowserSearch
                    SearchBox.Focus()
                    SearchBoxLabel.Visible = False
                Case Keys.BrowserStop
                    WB.Stop()
                Case Keys.Print
                    WB.Navigate("javascript.print()")
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub EnvoyerLadresseDeLaPageParCourrierÉlectoniqueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvoyerLadresseDeLaPageParCourrierÉlectoniqueToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Dim Link As String = WB.Url.ToString
        Dim PageTitle As String = WB.DocumentTitle
        Process.Start("mailto:?subject=Un ami vous a envoyé le lien du site '" + PageTitle + "' via SmartNet Browser" + "&body=Regarde cette page ! " + PageTitle + " : " + Link + " (Partagé via SmartNet Browser : https://quentinpugeat.wixsite.com/apps/browser)")
    End Sub

    Private Sub MessageBarCloseButton_Click(sender As Object, e As EventArgs) Handles MessageBarCloseButton.Click
        MessageBarButton.Visible = False
        MessageBarLabel.Visible = False
        MessageBarPictureBox.Visible = False
        MessageBarCloseButton.Visible = False
    End Sub

    Private Sub MessageBarButton_Click(sender As Object, e As EventArgs) Handles MessageBarButton.Click
        Select Case MessageBarAction
            Case "OpenPopup"
                AddTab(MessageBarButtonLink, BrowserTabs)
            Case Else
                MsgBox("Ce bouton ne peut rien faire. Voir le support pour plus de détails.", MsgBoxStyle.Information, "SmartNet Browser")
        End Select
        MessageBarPictureBox.Visible = False
        MessageBarButton.Visible = False
        MessageBarCloseButton.Visible = False
        MessageBarLabel.Visible = False
    End Sub

    Private Sub FermerCetOngletToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FermerCetOngletToolStripMenuItem.Click
        Dim tabPageToRemove As TabPage = BrowserTabs.TabPages.Item(tabPageIndex)
        Dim WB As CustomBrowser = CType(tabPageToRemove.Tag, CustomBrowser)
        Try
            WB.Navigate("about:blank")
            If BrowserTabs.TabPages.Count = 1 Then
                Me.Close()
            Else
                My.Settings.LastClosedTab = WB.Url.ToString
                BrowserTabs.TabPages.Remove(tabPageToRemove)
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub
    Private Sub RouvrirLeDernierOngletFerméToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RouvrirLeDernierOngletFerméToolStripMenuItem.Click
        AddTab(My.Settings.LastClosedTab, BrowserTabs)
        My.Settings.LastClosedTab = ""
    End Sub
    Private Sub TabsContextMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles TabsContextMenuStrip.Opening
        If My.Settings.LastClosedTab = "" Then
            RouvrirLeDernierOngletFerméToolStripMenuItem.Enabled = False
        Else
            RouvrirLeDernierOngletFerméToolStripMenuItem.Enabled = True
        End If
    End Sub
    Private Sub BrowserTabs_MouseClick(sender As Object, e As MouseEventArgs) Handles BrowserTabs.MouseClick
        Dim i As Integer = 0
        If e.Button = MouseButtons.Right Then
            While i <= BrowserTabs.TabPages.Count - 1
                If BrowserTabs.GetTabRect(i).Contains(e.Location) Then
                    tabPageIndex = i
                End If
                i += 1
            End While
            TabsContextMenuStrip.Show(MousePosition)
        End If
    End Sub
End Class

Public Class CustomBrowser
    Inherits Gecko.GeckoWebBrowser
    Public Sub New()
        Me.NoDefaultContextMenu = True
        Me.ContextMenuStrip = BrowserForm.BrowserContextMenuStrip
        Gecko.GeckoPreferences.User("intl.accept_languages") = My.Settings.UserAgentLanguage
        Gecko.GeckoPreferences.User("general.useragent.locale") = My.Settings.UserAgentLanguage
        If My.Settings.UserAgent = "" Then
            If Environment.Is64BitOperatingSystem = True Then
                Gecko.GeckoPreferences.User("general.useragent.override") = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; Win64; x64; rv:45.0) Gecko/20100101 Firefox/45.0  SmartNet/" + My.Application.Info.Version.ToString
            Else
                Gecko.GeckoPreferences.User("general.useragent.override") = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; rv:45.0) Gecko/20100101 Firefox/45.0  SmartNet/" + My.Application.Info.Version.ToString
            End If
        Else
            Gecko.GeckoPreferences.User("general.useragent.override") = My.Settings.UserAgent
        End If
        Gecko.GeckoPreferences.Default("media.fragmented-mp4.ffmpeg.enabled") = True
        Gecko.GeckoPreferences.Default("media.mediasource.enabled") = True
        Gecko.GeckoPreferences.Default("media.mediasource.ignore_codecs") = True
        Gecko.GeckoPreferences.Default("extensions.blocklist.enabled") = False
    End Sub

    Private Sub BrowserForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            Select Case e.KeyCode
                Case Keys.BrowserBack
                    WB.GoBack()
                Case Keys.BrowserFavorites
                    FavoritesForm.Show()
                Case Keys.BrowserForward
                    WB.GoForward()
                Case Keys.BrowserHome
                    AddTab(My.Settings.Homepage, BrowserForm.BrowserTabs)
                Case Keys.BrowserRefresh
                    WB.Reload()
                Case Keys.BrowserSearch
                    BrowserForm.SearchBox.Focus()
                    BrowserForm.SearchBoxLabel.Visible = False
                Case Keys.BrowserStop
                    WB.Stop()
                Case Keys.Print
                    WB.Navigate("javascript.print()")
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BrowserDocumentCompleted(ByVal sender As System.Object, ByVal e As GeckoDocumentCompletedEventArgs) Handles Me.DocumentCompleted
        If e.Uri.ToString <> "about:blank" Then
            BrowserForm.StopButton.Visible = False
            BrowserForm.RefreshButton.Visible = True
            BrowserForm.GoButton.Visible = False
            BrowserForm.LoadingGif.Visible = False
            BrowserForm.AperçuAvantImpressionToolStripMenuItem.Enabled = True
            BrowserForm.CurrentDocument = Me.Document
            If e.Uri.ToString.Contains(My.Application.Info.DirectoryPath) Or e.Uri.ToString.Contains("https://quentinpugeat.wixsite.com/smartnetbrowserhome") Then
                BrowserForm.URLBox.Text = ""
            Else
                BrowserForm.URLBox.Text = Me.Url.ToString
            End If
            BrowserForm.Text = Me.DocumentTitle.ToString + " - SmartNet Browser"
        End If
    End Sub

    Private Sub BrowserNavigated(sender As Object, e As Gecko.GeckoNavigatedEventArgs) Handles Me.Navigated
        If e.Uri.ToString <> "about:blank" Then
            Try
                BrowserForm.CurrentDocument = Me.Document
                If e.Uri.ToString.Contains(My.Application.Info.DirectoryPath) Or e.Uri.ToString.Contains("https://quentinpugeat.wixsite.com/smartnetbrowserhome") Then
                    BrowserForm.URLBox.Text = ""
                Else
                    BrowserForm.URLBox.Text = Me.Url.ToString
                End If
                BrowserForm.Text = Me.DocumentTitle.ToString + " - SmartNet Browser"
                If (Me.Url.ToString.Contains("www.youtube.com/watch?v=") Or Me.Url.ToString.Contains("dailymotion.com/video")) And Not Me.Url.ToString.Contains("www.clipconverter.cc") Then
                    BrowserForm.TéléchargerCetteVidéoToolStripMenuItem.Visible = True
                    BrowserForm.ToolStripSeparator6.Visible = True
                Else
                    BrowserForm.TéléchargerCetteVidéoToolStripMenuItem.Visible = False
                    BrowserForm.ToolStripSeparator6.Visible = False
                End If
                If My.Settings.PrivateBrowsing = False Then
                    If Not (e.Uri.ToString.Contains("https://quentinpugeat.wixsite.com/smartnetbrowserhome") Or e.Uri.ToString.Contains(My.Application.Info.DirectoryPath) Or e.Uri.ToString.Contains("about:")) Then
                        My.Settings.History.Add(Me.Url.ToString)
                        BrowserForm.URLBox.Items.Add(Me.Url.ToString)
                    End If
                End If
                If My.Settings.Favorites.Contains(e.Uri.ToString) Then
                    BrowserForm.FavoritesButton.Image = BrowserForm.FavoritesButton.ErrorImage
                Else
                    BrowserForm.FavoritesButton.Image = BrowserForm.FavoritesButton.InitialImage
                End If
                BrowserForm.CheckFavicon()
            Catch ex As Exception
                If My.Settings.DisplayExceptions = True Then
                    ExceptionForm.MessageTextBox.Text = ex.Message
                    ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                    ExceptionForm.ShowDialog()
                End If
            End Try
        End If
    End Sub

    Private Sub BrowserNavigating(ByVal sender As Object, ByVal e As GeckoNavigatingEventArgs) Handles Me.Navigating
        If e.Uri.ToString <> "about:blank" Then
            Try
                If My.Settings.ChildrenProtection = True Then
                    Dim AdultDomainsFile As New WebClient
                    Dim AdultDomainsListFile As String = AdultDomainsFile.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetbrowser/ChildrenProtection.txt")
                    Dim AdultDomainsList As New List(Of String)(AdultDomainsListFile.Split(","c))
                    For I = 0 To AdultDomainsList.Count - 1
                        If e.Uri.ToString.Contains(AdultDomainsList.Item(I)) Then
                            Dim Language As String = Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName
                            Me.Navigate(My.Application.Info.DirectoryPath + "\ChildGuard\" + Language + ".html")
                        End If
                    Next
                End If
            Catch ex As Exception
                If My.Settings.DisplayExceptions = True Then
                    ExceptionForm.MessageTextBox.Text = ex.Message
                    ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                    ExceptionForm.ShowDialog()
                Else
                    MsgBox("Une erreur est survenue avec SmartNet ChildGuard. Code d'erreur : CHILDGUARD_ERROR", MsgBoxStyle.Critical, "SmartNet ChildGuard")
                End If
            End Try
            If e.Uri.ToString.Contains("window.close") Then
                If BrowserForm.BrowserTabs.TabPages.Count > 1 Then
                    BrowserForm.BrowserTabs.TabPages.Remove(BrowserForm.BrowserTabs.SelectedTab)
                Else
                    If MsgBox("Le site Web tente de fermer la fenêtre. Voulez-vous continuer ? (Si vous cliquez sur non, vous serez redirigé vers la page d'accueil)", MsgBoxStyle.YesNo, "Fermeture de la fenêtre") = MsgBoxResult.Yes Then
                        Application.Exit()
                    Else
                        Me.Navigate(My.Settings.Homepage)
                    End If
                End If
            End If
            BrowserForm.StopButton.Visible = True
            BrowserForm.RefreshButton.Visible = False
            BrowserForm.GoButton.Visible = False
            BrowserForm.LoadingGif.Visible = True
            BrowserForm.AperçuAvantImpressionToolStripMenuItem.Enabled = False
            BrowserForm.MessageBarButton.Visible = False
            BrowserForm.MessageBarLabel.Visible = False
            BrowserForm.MessageBarPictureBox.Visible = False
            BrowserForm.MessageBarCloseButton.Visible = False
            BrowserForm.CurrentDocument = Me.Document
            If e.Uri.ToString.Contains(My.Application.Info.DirectoryPath) Or e.Uri.ToString.Contains("https://quentinpugeat.wixsite.com/smartnetbrowserhome") Then
                BrowserForm.URLBox.Text = ""
            Else
                BrowserForm.URLBox.Text = Me.Url.ToString
            End If
            BrowserForm.Text = Me.DocumentTitle.ToString + " - SmartNet Browser"
        End If

    End Sub

    Public Sub AddTab(ByRef URL As String, ByRef TabControl As TabControl)
        Try
            Dim NewBrowser As New CustomBrowser
            Dim NewTab As New TabPage
            NewBrowser.Tag = NewTab
            NewTab.Tag = NewBrowser
            BrowserForm.ImageList1.Images.Add(BrowserForm.FaviconBox.InitialImage)
            BrowserForm.BrowserTabs.ImageList.Images.Add(BrowserForm.FaviconBox.InitialImage)
            TabControl.TabPages.Add(NewTab)
            NewTab.Controls.Add(NewBrowser)
            NewBrowser.Dock = DockStyle.Fill
            NewBrowser.Navigate(URL)
            TabControl.SelectedTab = NewTab
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub CustomBrowser_NewWindow(sender As Object, e As Gecko.GeckoCreateWindowEventArgs) Handles Me.CreateWindow
        Try
            e.Cancel = True
            Dim block = False
            Dim target As String = e.Uri
            Dim AdsDomainsFile As New WebClient
            Dim AdsDomainsListFile As String = AdsDomainsFile.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetbrowser/AdsDomains.txt")
            Dim AdsDomainsList As New List(Of String)(AdsDomainsListFile.Split(","c))
            For I = 0 To AdsDomainsList.Count - 1
                If My.Settings.PopUpBlocker = True And target.Contains(AdsDomainsList.Item(I)) Then
                    block = True
                End If
            Next
            If block = True Then
                BrowserForm.MessageBarLabel.Text = "SmartNet Browser a empêché l'ouverture d'une fenêtre publicitaire."
                BrowserForm.MessageBarButton.Text = "Ouvrir quand même"
                BrowserForm.MessageBarAction = "OpenPopup"
                BrowserForm.MessageBarButtonLink = target
                BrowserForm.MessageBarButton.Visible = True
                BrowserForm.MessageBarLabel.Visible = True
                BrowserForm.MessageBarPictureBox.Visible = True
                BrowserForm.MessageBarCloseButton.Visible = True
            Else
                AddTab(target, BrowserForm.BrowserTabs)
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            Else
                MsgBox("Un problème est survenu avec le bloqueur de Pop-Ups.", MsgBoxStyle.Exclamation, "SmartNet AdsBlocker")
            End If
            Dim target As String = e.Uri
            Dim block2 = False
            Dim AdsDomainsFile As New WebClient
            Dim AdsDomainsListFile As String = AdsDomainsFile.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetbrowser/AdsDomains.txt")
            Dim AdsDomainsList As New List(Of String)(AdsDomainsListFile.Split(","c))
            For I = 0 To AdsDomainsList.Count - 1
                If My.Settings.PopUpBlocker = True And target.Contains(AdsDomainsList.Item(I)) Then
                    block2 = True
                End If
            Next
            If block2 = False Then
                NewBrowserForm.GeckoWebBrowser1.Navigate(target)
                NewBrowserForm.Show()
            End If
        End Try
    End Sub

    Private Sub CustomBrowser_FrameNavigating(sender As Object, e As GeckoNavigatingEventArgs) Handles Me.FrameNavigating
        Dim block = False
        Try
            If My.Settings.AllowAdsSites.Contains(Me.Url.Host.ToString) = False Then
                If My.Settings.AdBlocker = True Then
                    Dim AdsDomainsFile As New WebClient
                    Dim AdsDomainsListFile As String = AdsDomainsFile.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetbrowser/AdsDomains.txt")
                    Dim AdsDomainsList As New List(Of String)(AdsDomainsListFile.Split(","c))
                    For I = 0 To AdsDomainsList.Count - 1
                        If e.Uri.ToString.Contains(AdsDomainsList.Item(I)) Then
                            block = True
                        End If
                    Next
                    If block = True Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            Else
                MsgBox("Une erreur est survenue avec le bloqueur de publicités. Code d'erreur : ADSBLOCKER_ERROR", MsgBoxStyle.Critical, "SmartNet AdsBlocker")
            End If
        End Try
    End Sub

    Private Sub CustomBrowser_ShowContextMenu(sender As Object, e As Gecko.DomMouseEventArgs) Handles Me.DomContextMenu
        Try
            BrowserForm.CopierLadresseDeLimageToolStripMenuItem.Visible = CanCopyImageLocation
            BrowserForm.EnregistrerLimageToolStripMenuItem.Visible = CanCopyImageLocation
            BrowserForm.AfficherLimageToolStripMenuItem.Visible = CanCopyImageLocation
            BrowserForm.ImageToolStripSeparator.Visible = CanCopyImageLocation
            BrowserForm.CopierLadresseDuLienToolStripMenuItem.Visible = CanCopyLinkLocation
            BrowserForm.OuvrirLeLienToolStripMenuItem.Visible = CanCopyLinkLocation
            BrowserForm.OuvrirDansUnNouvelOngletToolStripMenuItem.Visible = CanCopyLinkLocation
            BrowserForm.AjouterLeLienAuxFavorisToolStripMenuItem.Visible = CanCopyLinkLocation
            BrowserForm.LinkToolStripSeparator.Visible = CanCopyLinkLocation
            BrowserForm.CouperToolStripMenuItem1.Visible = CanCutSelection
            BrowserForm.CollerToolStripMenuItem1.Visible = CanPaste
            BrowserForm.CopierToolStripMenuItem1.Visible = CanCopySelection
            BrowserForm.LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem.Visible = CanCopySelection
            If CanCutSelection Or CanPaste Or CanCopySelection Then
                BrowserForm.EditionToolStripSeparator.Visible = True
            Else
                BrowserForm.EditionToolStripSeparator.Visible = False
            End If
            BrowserForm.BrowserContextMenuStrip.Show(MousePosition)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub CustomBrowser_DomMouseMove(sender As Object, e As Gecko.DomMouseEventArgs) Handles Me.DomMouseMove
        Try
            BrowserForm.MousePoint = New Point(e.ClientX, e.ClientY)
            BrowserForm.Ele = BrowserForm.CurrentDocument.ElementFromPoint(BrowserForm.MousePoint.X, BrowserForm.MousePoint.Y)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CustomBrowser_StatusTextChanged(sender As Object, e As EventArgs) Handles Me.StatusTextChanged
        Try
            BrowserForm.StatusLabel.Text = Me.StatusText
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub CustomBrowser_DocumentTitleChanged(sender As Object, e As EventArgs) Handles Me.DocumentTitleChanged
        If Me.Url.ToString <> "about:blank" Then
            Try
                Dim TP As TabPage = CType(Me.Tag, TabPage)
                If Me.DocumentTitle = "" Then
                    If Me.Url.ToString.Length > 30 Then
                        TP.Text = Me.Url.ToString.Substring(0, 29) & "..."
                    Else
                        TP.Text = Me.Url.ToString
                    End If
                Else
                    If Me.DocumentTitle.Length > 30 Then
                        TP.Text = Me.DocumentTitle.Substring(0, 29) & "..."
                    Else
                        TP.Text = Me.DocumentTitle
                    End If
                End If
            Catch ex As Exception
                If My.Settings.DisplayExceptions = True Then
                    ExceptionForm.MessageTextBox.Text = ex.Message
                    ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                    ExceptionForm.ShowDialog()
                End If
            End Try
        End If
    End Sub

    Private Sub CustomBrowser_CanGoBackChanged(sender As Object, e As EventArgs) Handles Me.CanGoBackChanged
        Try
            BrowserForm.PreviouspageButton.Visible = CanGoBack
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub CustomBrowser_CanGoForwardChanged(sender As Object, e As EventArgs) Handles Me.CanGoForwardChanged
        Try
            BrowserForm.NextpageButton.Visible = CanGoForward
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub CustomBrowser_ShowContextMenu(sender As Object, e As Gecko.GeckoContextMenuEventArgs) Handles Me.ShowContextMenu
        Try
            BrowserForm.CopierLadresseDeLimageToolStripMenuItem.Visible = CanCopyImageLocation
            BrowserForm.EnregistrerLimageToolStripMenuItem.Visible = CanCopyImageLocation
            BrowserForm.AfficherLimageToolStripMenuItem.Visible = CanCopyImageLocation
            BrowserForm.ImageToolStripSeparator.Visible = CanCopyImageLocation
            BrowserForm.CopierLadresseDuLienToolStripMenuItem.Visible = CanCopyLinkLocation
            BrowserForm.OuvrirLeLienToolStripMenuItem.Visible = CanCopyLinkLocation
            BrowserForm.OuvrirDansUnNouvelOngletToolStripMenuItem.Visible = CanCopyLinkLocation
            BrowserForm.AjouterLeLienAuxFavorisToolStripMenuItem.Visible = CanCopyLinkLocation
            BrowserForm.LinkToolStripSeparator.Visible = CanCopyLinkLocation
            BrowserForm.CouperToolStripMenuItem1.Visible = CanCutSelection
            BrowserForm.CollerToolStripMenuItem1.Visible = CanPaste
            BrowserForm.CopierToolStripMenuItem1.Visible = CanCopySelection
            BrowserForm.LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem.Visible = CanCopySelection
            If CanCutSelection Or CanPaste Or CanCopySelection Then
                BrowserForm.EditionToolStripSeparator.Visible = True
            Else
                BrowserForm.EditionToolStripSeparator.Visible = False
            End If
            BrowserForm.BrowserContextMenuStrip.Show(MousePosition)
        Catch ex As Exception
            If My.Settings.DisplayExceptions = True Then
                ExceptionForm.MessageTextBox.Text = ex.Message
                ExceptionForm.DetailsTextBox.Text = vbCrLf & ex.Source & vbCrLf & ex.GetType.ToString & vbCrLf & ex.StackTrace
                ExceptionForm.ShowDialog()
            End If
        End Try
    End Sub

    Private Sub CustomBrowser_DomClick(sender As Object, e As Gecko.DomMouseEventArgs) Handles Me.DomClick
        BrowserForm.URLBox.Select(0, 0)
    End Sub
End Class