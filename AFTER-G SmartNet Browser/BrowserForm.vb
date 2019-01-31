Imports System.ComponentModel
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text

Public Class BrowserForm
    Public WithEvents CurrentDocument As Gecko.GeckoDocument
    Public MousePoint As Point
    Public Ele As Gecko.GeckoElement
    Public msgBar As MessageBar
    Dim tabPageIndex As Integer = 0
    Public lastClosedTab As String
    Dim appsync As AppSyncAgent

    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Ajoute la page spécifiée dans l'historique de l'utilisateur.
    ''' </summary>
    ''' <param name="page">Page à ajouter</param>
    Public Sub AddInHistory(page As WebPage)
        Dim Historique As WebPageList = WebPageList.FromStringCollection(My.Settings.History)
        My.Settings.History = Historique.ToStringCollection()
        My.Settings.Save()
        URLBox.Items.Add(page.GetURL())
    End Sub

    ''' <summary>
    ''' Ajoute la page spécifiée dans la liste des favoris de l'utilisateur.
    ''' </summary>
    ''' <param name="page">Page à ajouter</param>
    Public Sub AddInFavorites(page As WebPage)
        Dim Favoris As WebPageList = WebPageList.FromStringCollection(My.Settings.Favorites)
        Favoris.Add(page)
        My.Settings.Favorites = Favoris.ToStringCollection()
        My.Settings.Save()
        URLBox.Items.Add(page.GetURL())
        UpdateInterface()
    End Sub

    ''' <summary>
    ''' Actualise la liste des onglets pour le garde fou.
    ''' </summary>
    Public Sub RefreshListOfTabs()
        Dim WB As CustomBrowser
        Dim newList As New Specialized.StringCollection
        For Each onglet As TabPage In BrowserTabs.TabPages
            WB = CType(onglet.Tag, CustomBrowser)
            newList.Add(WB.Url.ToString())
        Next
        My.Settings.LastSessionListOfTabs = newList
        My.Settings.Save()
    End Sub

    ''' <summary>
    ''' Ajoute un nouvel onglet.
    ''' </summary>
    ''' <param name="URL">URL de la page qui sera chargée dans le nouvel onglet</param>
    ''' <param name="TabControl">Dispositif d'onglets dans lequel sera ajouté l'onglet</param>
    Public Sub AddTab(ByRef URL As String, ByRef TabControl As TabControl)
        Try
            Dim NewBrowser As New CustomBrowser()
            Dim NewTab As New TabPage("Nouvel onglet")
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
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub

    ''' <summary>
    ''' Déclenche la mise à jour de la favicon de l'onglet actuellement ouvert.
    ''' </summary>
    Public Sub CheckFavicon()
        Dim WB As CustomBrowser = CType(BrowserTabs.SelectedTab.Tag, CustomBrowser)
        FaviconBox.Image = PageFavicon(WB.Url.ToString())
        BrowserTabs.ImageList.Images.Item(BrowserTabs.SelectedIndex) = New Bitmap(PageFavicon(WB.Url.ToString()), 16, 16)
        BrowserTabs.SelectedTab.ImageIndex = BrowserTabs.SelectedIndex
        PropertiesForm.FaviconBox.Image = PageFavicon(WB.Url.ToString())
    End Sub

    ''' <summary>
    ''' Favicon de la page passée en paramètre.
    ''' </summary>
    ''' <returns></returns>
    Public Function PageFavicon(pURL As String) As Image
        Try
            If pURL.Contains("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser/homepage/") Or pURL.Contains(My.Application.Info.DirectoryPath.Replace("\", "/")) Or pURL.Contains("about:") Then
                Return My.Resources._2019_SmartNetBrowser_64
            Else
                Dim url As Uri = New Uri(pURL)
                If url.HostNameType = UriHostNameType.Dns Then
                    Dim iconURL = "http://" & url.Host & "/favicon.ico"
                    Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(iconURL)
                    Dim response As System.Net.HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                    Dim stream As System.IO.Stream = response.GetResponseStream()
                    Dim favicon = Image.FromStream(stream)
                    Return favicon
                Else
                    Return My.Resources.ErrorFavicon
                End If
            End If
        Catch ex As Exception
            Return My.Resources.ErrorFavicon
        End Try
    End Function

    ''' <summary>
    ''' Retourne une chaîne après cryptage en SHA512.
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
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

    ''' <summary>
    ''' Ferme SmartNet Browser.
    ''' </summary>
    Public Sub CloseSmartNetBrowser()
        Try
            If BrowserTabs.TabPages.Count > 1 And My.Settings.PreventMultipleTabsClose = True Then
                If PreventTabsCloseForm.ShowDialog() = DialogResult.Yes Then
                    My.Settings.CorrectlyClosed = True
                    My.Settings.Save()
                    Environment.Exit(0)
                End If
            Else
                My.Settings.CorrectlyClosed = True
                My.Settings.Save()
                Environment.Exit(0)
            End If
        Catch ex As Exception
            Environment.Exit(1)
        End Try
    End Sub

    ''' <summary>
    ''' Déclenche le chargement d'une recherche dans l'onglet actif.
    ''' </summary>
    ''' <param name="keywords">Mots-clés de la recherche</param>
    Public Sub OpenSearchResults(keywords As String)
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Select Case My.Settings.SearchEngine
            Case 1
                WB.Navigate("https://www.google.fr/search?q=" + keywords)
            Case 2
                WB.Navigate("https://www.bing.com/search?q=" + keywords)
            Case 3
                WB.Navigate("https://fr.search.yahoo.com/search;_ylt=Art7C6mA.dKDerFt5RNNyYFNhJp4?p=" + keywords)
            Case 4
                WB.Navigate("https://duckduckgo.com/?q=" + keywords)
            Case 5
                WB.Navigate("https://www.qwant.com/?q=" + keywords)
            Case 0
                WB.Navigate(My.Settings.CustomSearchURL + keywords)
        End Select

        If My.Settings.PrivateBrowsing = False Then
            SearchBox.Items.Add(keywords)
            My.Settings.SearchHistory.Add(keywords)
        End If
    End Sub

    ''' <summary>
    ''' Déclenche le rafraîchissement de tous les composants dynamiques de l'interface.
    ''' </summary>
    Public Sub UpdateInterface()
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Dim WB2 As CustomBrowser

        Select Case My.Settings.SearchEngine
            Case 1
                SearchBoxLabel.Text = "Google"
            Case 2
                SearchBoxLabel.Text = "Bing"
            Case 3
                SearchBoxLabel.Text = "Yahoo!"
            Case 4
                SearchBoxLabel.Text = "DuckDuckGo"
            Case 5
                SearchBoxLabel.Text = "Qwant"
            Case 0
                SearchBoxLabel.Text = My.Settings.CustomSearchName
            Case Else
                SearchBoxLabel.Text = "Rechercher"
        End Select

        Dim Favoris As WebPageList = WebPageList.FromStringCollection(My.Settings.Favorites)
        If Favoris.ContainsPage(WB.Url.ToString()) Then
            FavoritesButton.Image = My.Resources.FavoritesBlue
        Else
            FavoritesButton.Image = My.Resources.FavoritesOutline
        End If

        If WB.IsBusy Then
            StopButton.Visible = True
            RefreshButton.Visible = False
            LoadingGif.Visible = True
            AperçuAvantImpressionToolStripMenuItem.Enabled = False
        Else
            StopButton.Visible = False
            RefreshButton.Visible = True
            LoadingGif.Visible = False
            AperçuAvantImpressionToolStripMenuItem.Enabled = True
        End If

        PreviouspageButton.Enabled = WB.CanGoBack
        NextpageButton.Enabled = WB.CanGoForward

        If Not URLBox.Focused Then
            If WB.Url.ToString.Contains(My.Application.Info.DirectoryPath.Replace("\", "/")) Then
                URLBox.Text = ""
            Else
                URLBox.Text = WB.Url.ToString
            End If
        End If

        For Each onglet As TabPage In Me.BrowserTabs.TabPages
            WB2 = CType(onglet.Tag, CustomBrowser)
            If WB2.DocumentTitle = "" Or WB2.DocumentTitle Is Nothing Then
                If WB2.Url.ToString.Length > 30 Then
                    onglet.Text = WB2.Url.ToString.Substring(0, 26) & "..."
                Else
                    onglet.Text = WB2.Url.ToString
                End If
            Else
                If WB2.DocumentTitle.Length > 30 Then
                    onglet.Text = WB2.DocumentTitle.Substring(0, 26) & "..."
                Else
                    onglet.Text = WB2.DocumentTitle
                End If
            End If
        Next

        If WB.DocumentTitle = "" Then
            Me.Text = WB.Url.ToString + " - SmartNet Browser"
        Else
            Me.Text = WB.DocumentTitle.ToString + " - SmartNet Browser"
        End If

        If (WB.Url.ToString.Contains("www.youtube.com/watch?v=") Or WB.Url.ToString.Contains("dailymotion.com/video")) And Not WB.Url.ToString.Contains("www.clipconverter.cc") Then
            TéléchargerCetteVidéoToolStripMenuItem.Visible = True
            ToolStripSeparator6.Visible = True
        Else
            TéléchargerCetteVidéoToolStripMenuItem.Visible = False
            ToolStripSeparator6.Visible = False
        End If

        CouperToolStripMenuItem.Enabled = WB.CanCutSelection
        CopierToolStripMenuItem.Enabled = WB.CanCopySelection
        CollerToolStripMenuItem.Enabled = WB.CanPaste

        If URLBox.Text = "" Then
            URLBoxLabel.Visible = True
        Else
            URLBoxLabel.Visible = False
        End If

        If SearchBox.Text = "" Then
            SearchBoxLabel.Visible = True
        Else
            SearchBoxLabel.Visible = False
        End If
    End Sub

    Private Sub BrowserForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        CloseMessageBar()
        AddTab(My.Settings.Homepage, BrowserTabs)

        If My.Settings.FirstStart = True Then
            If My.Settings.FirstStartFromReset = False Then
                My.Settings.Upgrade()
                My.Settings.Reload()
                If My.Settings.FirstStart = True Then
                    FirstStartForm.ShowDialog()
                End If
            Else
                FirstStartForm.ShowDialog()
            End If
        End If

        Try
            appsync = New AppSyncAgent()
            If appsync.IsDeviceRegistered() Then
                appsync.SyncNow()
                SeConnecterÀAppSyncToolStripMenuItem.Text = appsync.GetUserName()
                SeConnecterÀAppSyncToolStripMenuItem.Image = appsync.GetUserProfilePicture()
            Else
                My.Settings.AppSyncLastSyncTime = New Date(1, 1, 1)
                My.Settings.AppSyncDeviceNumber = 0
                msgBar = New MessageBar(MessageBar.MessageBarLevel.Info, "Cet appareil a été déconnecté de SmartNet AppSync.", MessageBar.MessageBarAction.DisplayAppSyncLogin, "Se reconnecter...")
                DisplayMessageBar()
                SeConnecterÀAppSyncToolStripMenuItem.Text = "Se connecter à AppSync..."
                SeConnecterÀAppSyncToolStripMenuItem.Image = My.Resources.Person
            End If
        Catch ex As AppSyncException
            msgBar = New MessageBar(MessageBar.MessageBarLevel.Critical, "Un problème est survenu lors de l'ouverture de votre session SmartNet AppSync. (" + ex.Message + ", " + ex.GetBaseException().Message + ")", MessageBar.MessageBarAction.OpenPopup, "Obtenir de l'aide", "http://quentinpugeat.pagesperso-orange.fr/appsync/support/")
            DisplayMessageBar()
        End Try

        Dim Favoris As WebPageList = WebPageList.FromStringCollection(My.Settings.Favorites)
        Dim Historique As WebPageList = WebPageList.FromStringCollection(My.Settings.History)

        For Each favorite In Favoris
            URLBox.Items.Add(favorite.GetURL())
        Next

        For Each HistoryEntry In Historique
            URLBox.Items.Add(HistoryEntry.GetURL())
        Next

        For Each SearchHistoryEntry In My.Settings.SearchHistory
            SearchBox.Items.Add(SearchHistoryEntry)
        Next

        If My.Settings.CorrectlyClosed = False Then
            msgBar = New MessageBar(MessageBar.MessageBarLevel.Info, "SmartNet Browser n'a pas été fermé correctement la dernière fois.", MessageBar.MessageBarAction.RestorePreviousSession, "Restaurer la session")
            DisplayMessageBar()
        End If
        My.Settings.CorrectlyClosed = False

        AddHandler Gecko.LauncherDialog.Download, AddressOf LauncherDialog_Download
    End Sub

    Private Sub LauncherDialog_Download(ByVal sender As Object, ByVal e As Gecko.LauncherDialogEvent) 'Handles Gecko.LauncherDialog.Download
        DownloadForm.FileNameLabel.Text = e.Url.Substring(e.Url.LastIndexOf("/") + 1)
        DownloadForm.URLLabel.Text = "À partir de : " + e.Url
        DownloadForm.DownloadLink = e.Url
        DownloadForm.Show()
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
    Private Sub RefreshPage(sender As Object, e As EventArgs) Handles ActualiserLaPageToolStripMenuItem.Click, RefreshButton.Click
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

        If BrowserTabs.TabPages.Count = 1 Then
            CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser).Dispose()
            CloseSmartNetBrowser()
        Else
            lastClosedTab = WB.Url.ToString()
            CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser).Dispose()
            BrowserTabs.TabPages.Remove(BrowserTabs.SelectedTab)
        End If
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
        GoButton.Visible = True
    End Sub

    Private Sub SavePageAs(sender As Object, e As EventArgs) Handles SavePageToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            If SavePageDialog.ShowDialog = DialogResult.OK Then
                WB.SaveDocument(SavePageDialog.FileName)
            End If
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub OpenDocument(sender As Object, e As EventArgs) Handles OpenPageToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            If OpenFileDialog1.ShowDialog <> DialogResult.Cancel Then
                WB.Navigate(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub PrintPreview(sender As Object, e As EventArgs) Handles AperçuAvantImpressionToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate("javascript:print()")
    End Sub

    Private Sub HomeNavigating(sender As Object, e As EventArgs) Handles HomepageButton.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(My.Settings.Homepage)
    End Sub

    Private Sub Cut(sender As Object, e As EventArgs) Handles CouperToolStripMenuItem.Click, CouperToolStripMenuItem1.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            If WB.CanCutSelection = True Then
                WB.CutSelection()
            End If
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub Copy(sender As Object, e As EventArgs) Handles CopierToolStripMenuItem.Click, CopierToolStripMenuItem1.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If WB.CanCopySelection = True Then
            WB.CopySelection()
        End If
    End Sub
    Private Sub Paste(sender As Object, e As EventArgs) Handles CollerToolStripMenuItem.Click, CollerToolStripMenuItem1.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If WB.CanPaste Then
            WB.Paste()
        End If
    End Sub
    Private Sub AjouterCettePageDansLesFavorisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouterCettePageDansLesFavorisToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        AddInFavorites(New WebPage(WB.DocumentTitle, WB.Url.ToString()))
    End Sub
    Private Sub ShowFavorites(sender As Object, e As EventArgs) Handles AfficherLesFavorisToolStripMenuItem.Click
        If My.Settings.HistoryFavoritesSecurity = True Then
            EnterBrowserSettingsSecurityForm.SecurityMode = "Favorites"
            EnterBrowserSettingsSecurityForm.ShowDialog()
        Else
            NewHistoryForm.TabControl1.SelectTab(1)
            NewHistoryForm.Show()
        End If
    End Sub

    Private Sub GoToSettings(sender As Object, e As EventArgs) Handles ParamètresToolStripMenuItem.Click
        If My.Settings.BrowserSettingsSecurity = True Then
            EnterBrowserSettingsSecurityForm.SecurityMode = "Settings"
            EnterBrowserSettingsSecurityForm.ShowDialog()
        Else
            SettingsForm.Show()
        End If
    End Sub

    Private Sub DownloadUpdateButton_Click(sender As Object, e As EventArgs) Handles TéléchargerLaVersionXXXXToolStripMenuItem.Click
        UpdaterForm.ShowDialog()
    End Sub
    Private Sub UpdateNotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles UpdateNotifyIcon.MouseDoubleClick
        UpdaterForm.Show()
        UpdateNotifyIcon.Visible = False
    End Sub

    Private Sub PleinÉcranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PleinÉcranToolStripMenuItem.Click
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable And Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        PleinÉcranToolStripMenuItem.Visible = False
        PleinÉcranToolStripMenuItem.Enabled = False
        QuitterLePleinÉcranToolStripMenuItem.Visible = True
        QuitterLePleinÉcranToolStripMenuItem.Enabled = True
    End Sub
    Private Sub QuitterLePleinÉcranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterLePleinÉcranToolStripMenuItem.Click
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.WindowState = FormWindowState.Maximized
        PleinÉcranToolStripMenuItem.Visible = True
        PleinÉcranToolStripMenuItem.Enabled = True
        QuitterLePleinÉcranToolStripMenuItem.Visible = False
        QuitterLePleinÉcranToolStripMenuItem.Enabled = False
    End Sub

    Private Sub SupportCenterNavigating(sender As Object, e As EventArgs) Handles CentreDaideEnLigneToolStripMenuItem.Click
        AddTab("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser/support/", BrowserTabs)
    End Sub
    Private Sub ContacterLéquipeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContacterLéquipeToolStripMenuItem.Click
        AddTab("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/contact.html", BrowserTabs)
    End Sub
    Private Sub EnvoyerVosCommentairesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvoyerVosCommentairesToolStripMenuItem.Click
        AddTab("https://docs.google.com/forms/d/e/1FAIpQLSeefp223iFND5m2GG9fsKZo3oI6hC4Hthr14H2mFsFzU2WbIw/viewform?usp=sf_link", BrowserTabs)
    End Sub
    Private Sub AboutSmartNetBrowser(sender As Object, e As EventArgs) Handles ÀProposDeSmartNetBrowserToolStripMenuItem.Click
        AboutForm.ShowDialog()
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        OpenSearchResults(SearchBox.Text)
    End Sub
    Private Sub SearchBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles SearchBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            OpenSearchResults(SearchBox.Text)
        End If
    End Sub

    Private Sub Zoom_100(sender As Object, e As EventArgs) Handles Zoom100.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(1.0F)
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub Zoom_50(sender As Object, e As EventArgs) Handles Zoom50.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(0.5F)
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub Zoom_75(sender As Object, e As EventArgs) Handles Zoom75.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(0.75F)
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub Zoom_125(sender As Object, e As EventArgs) Handles Zoom125.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(1.25F)
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub Zoom_150(sender As Object, e As EventArgs) Handles Zoom150.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(1.5F)
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub Zoom_175(sender As Object, e As EventArgs) Handles Zoom175.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(1.75F)
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub Zoom_200(sender As Object, e As EventArgs) Handles Zoom200.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(2.0F)
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub Zoom_250(sender As Object, e As EventArgs) Handles Zoom250.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(2.5F)
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub Zoom_300(sender As Object, e As EventArgs) Handles Zoom300.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(3.0F)
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub Zoom_400(sender As Object, e As EventArgs) Handles Zoom400.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(4.0F)
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub ZoomPlusButton_Click(sender As Object, e As EventArgs) Handles ZoomPlusButton.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(WB.GetDocShellAttribute.GetContentViewerAttribute.GetFullZoomAttribute + 0.25F)
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub ZoomMinusButton_Click(sender As Object, e As EventArgs) Handles ZoomMinusButton.Click
        Try
            Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
            WB.GetDocShellAttribute.GetContentViewerAttribute.SetFullZoomAttribute(WB.GetDocShellAttribute.GetContentViewerAttribute.GetFullZoomAttribute - 0.25F)
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub

    Private Sub MyBase_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        CloseSmartNetBrowser()
    End Sub
    Private Sub FermerSmartNetBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FermerSmartNetBrowserToolStripMenuItem.Click
        CloseSmartNetBrowser()
    End Sub

    Private Sub ActiveTabChange(sender As Object, e As EventArgs) Handles BrowserTabs.SelectedIndexChanged
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        CheckFavicon()
        UpdateInterface()
        CurrentDocument = WB.Document
    End Sub

    Private Sub TéléchargerCetteVidéoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TéléchargerCetteVidéoToolStripMenuItem.Click
        AddTab("http://www.clipconverter.cc/?ref=addon&url=" + URLBox.Text, BrowserTabs)
    End Sub

    Private Sub ShowProperties(sender As Object, e As EventArgs) Handles FaviconBox.DoubleClick, PropriétésToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
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
            Case "html"
                PropertiesForm.PageTypeLabel.Text = "Type : Page Web HTML"
            Case "php"
                PropertiesForm.PageTypeLabel.Text = "Type : Page Web PHP"
            Case "css"
                PropertiesForm.PageTypeLabel.Text = "Type : Feuille de style CSS"
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
            Case "mp4"
                PropertiesForm.PageTypeLabel.Text = "Type : Vidéo MP4"
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
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
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
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub

    Private Sub CopierLadresseDuLienToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopierLadresseDuLienToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If WB.CanCopyLinkLocation = True Then
            WB.CopyLinkLocation()
        End If
    End Sub

    Private Sub AjouterLeLienAuxFavorisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouterLeLienAuxFavorisToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            Dim ClipboardOriginalData As IDataObject
            ClipboardOriginalData = Clipboard.GetDataObject
            WB.CopyLinkLocation()
            Dim Link As String = Clipboard.GetText
            Clipboard.SetDataObject(ClipboardOriginalData, True)

            AddInFavorites(New WebPage(Link))
            If WebPageList.FromStringCollection(My.Settings.Favorites).ContainsPage(Link) Then
                msgBar = New MessageBar(MessageBar.MessageBarLevel.Info, "Favori enregistré !")
                DisplayMessageBar()
            Else
                msgBar = New MessageBar(MessageBar.MessageBarLevel.Warning, "Oups, le favori ne s'est pas enregistré...")
                DisplayMessageBar()
            End If
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
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
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub

    Private Sub CopierLadresseDeLimageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopierLadresseDeLimageToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If WB.CanCopyImageLocation = True Then
            WB.CopyImageLocation()
        End If
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
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub AfficherLeCodeSourceDeLaPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfficherLeCodeSourceDeLaPageToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        AddTab("view-source:" & WB.Url.ToString, BrowserTabs)
    End Sub
    Private Sub LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Dim ClipboardActualData As IDataObject
        ClipboardActualData = Clipboard.GetDataObject()
        WB.CopySelection()
        Dim Selection As String = Clipboard.GetText()
        Clipboard.SetDataObject(ClipboardActualData, True)
        OpenSearchResults(Selection)
    End Sub

    Private Sub FavoritesButton_Click(sender As Object, e As EventArgs) Handles FavoritesButton.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If WebPageList.FromStringCollection(My.Settings.Favorites).ContainsPage(WB.Url.ToString) Then
            If My.Settings.HistoryFavoritesSecurity = True Then
                EnterBrowserSettingsSecurityForm.SecurityMode = "Favorites"
                EnterBrowserSettingsSecurityForm.ShowDialog()
            Else
                NewHistoryForm.TabControl1.SelectTab(1)
                NewHistoryForm.Show()
            End If
        Else
            AddInFavorites(New WebPage(WB.DocumentTitle, WB.Url.ToString()))
            My.Settings.Save()
            UpdateInterface()
        End If
    End Sub

    Private Sub MainMenu_Click(sender As Object, e As EventArgs) Handles MainMenu.DropDownOpening
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        UpdateInterface()
    End Sub
    Public Link As String

    Private Sub BrowserContextMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles BrowserContextMenuStrip.Opening
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
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
    End Sub
    Private Sub URLBox_TextChanged(sender As Object, e As EventArgs) Handles URLBox.TextChanged
        GoButton.Visible = True
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
        If WB.Focused Then
            WB.SelectAll()
        End If
    End Sub
    Private Sub RechercherDansLaPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RechercherDansLaPageToolStripMenuItem.Click
        SearchTextInPageForm.Show()
    End Sub

    Private Sub BrowserForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Try
            Select Case e.KeyCode
                Case Keys.F5
                    WB.Reload()
                Case Keys.BrowserBack
                    WB.GoBack()
                Case Keys.BrowserFavorites
                    If My.Settings.HistoryFavoritesSecurity = True Then
                        EnterBrowserSettingsSecurityForm.SecurityMode = "Favorites"
                        EnterBrowserSettingsSecurityForm.ShowDialog()
                    Else
                        NewHistoryForm.TabControl1.SelectTab(1)
                        NewHistoryForm.Show()
                    End If
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
        Dim Link As String = WB.Url.ToString()
        Dim PageTitle As String = WB.DocumentTitle
        Process.Start("mailto:?subject=Un ami vous a envoyé le lien du site '" + PageTitle + "' via SmartNet Browser" + "&body=Regarde cette page ! " + PageTitle + " : " + Link + " (Partagé via SmartNet Browser : http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser)")
    End Sub

    ''' <summary>
    ''' Déclenche l'affichage de la barre de message.
    ''' </summary>
    ''' <param name="message">Texte du message.</param>
    ''' <param name="action">Code donnant l'action à réaliser par le bouton de la barre de message.</param>
    ''' <param name="buttonText">Texte a afficher sur le bouton.</param>
    ''' <param name="buttonLink">Lien à ouvrir par le bouton.</param>
    ''' <param name="ex">Exception à traiter par la barre de message.</param>
    Public Sub DisplayMessageBar()
        MessageBarPictureBox.BackColor = msgBar.GetColor()
        MessageBarLabel1.BackColor = msgBar.GetColor()
        MessageBarLabel1.ForeColor = Color.White
        MessageBarCloseButton1.BackColor = msgBar.GetColor()
        MessageBarLabel1.Text = msgBar.message

        MessageBarPictureBox.Visible = True
        MessageBarCloseButton1.Visible = True
        MessageBarLabel1.Visible = True
        MessageBarCloseButton1.Enabled = True

        If msgBar.buttonText = "" Or msgBar.action = MessageBar.MessageBarAction.NoAction Then
            MessageBarButton1.Visible = False
            MessageBarButton1.Enabled = False
        Else
            MessageBarButton1.Visible = True
            MessageBarButton1.Enabled = True
            MessageBarButton1.Text = msgBar.buttonText
        End If
    End Sub

    ''' <summary>
    ''' Déclenche la fermeture de la barre de message.
    ''' </summary>
    Public Sub CloseMessageBar()
        MessageBarButton1.Visible = False
        MessageBarLabel1.Visible = False
        MessageBarPictureBox.Visible = False
        MessageBarCloseButton1.Visible = False
        MessageBarButton1.Enabled = False
        MessageBarCloseButton1.Enabled = False
    End Sub

    Private Sub MessageBarCloseButton_Click(sender As Object, e As EventArgs) Handles MessageBarCloseButton1.Click
        CloseMessageBar()
    End Sub
    Private Sub MessageBarButton_Click(sender As Object, e As EventArgs) Handles MessageBarButton1.Click
        Select Case msgBar.action
            Case MessageBar.MessageBarAction.OpenPopup
                AddTab(msgBar.link, BrowserTabs)
            Case MessageBar.MessageBarAction.RestorePreviousSession
                For Each page As String In My.Settings.LastSessionListOfTabs
                    AddTab(page, BrowserTabs)
                Next
                My.Settings.CorrectlyClosed = False
            Case MessageBar.MessageBarAction.OpenExceptionForm
                ExceptionForm.SetException(msgBar.exception)
                ExceptionForm.ShowDialog()
            Case MessageBar.MessageBarAction.OpenInternetSettings
                Process.Start("inetcpl.cpl")
            Case MessageBar.MessageBarAction.DisplayAppSyncLogin
                AppSyncLogin.ShowDialog()
            Case Else
                MsgBox("Ce bouton ne peut rien faire. Voir le support pour plus de détails.", MsgBoxStyle.Information, "SmartNet Browser")
        End Select
        CloseMessageBar()
    End Sub

    Private Sub FermerCetOngletToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FermerCetOngletToolStripMenuItem.Click
        Dim tabPageToRemove As TabPage = BrowserTabs.TabPages.Item(tabPageIndex)
        Dim WB As CustomBrowser = CType(tabPageToRemove.Tag, CustomBrowser)
        Try
            WB.Navigate("about:blank")
            If BrowserTabs.TabPages.Count = 1 Then
                CloseSmartNetBrowser()
            Else
                lastClosedTab = WB.Url.ToString
                BrowserTabs.TabPages.Remove(tabPageToRemove)
            End If
        Catch ex As Exception
            msgBar = New MessageBar(ex)
            DisplayMessageBar()
        End Try
    End Sub
    Private Sub RouvrirLeDernierOngletFerméToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RouvrirLeDernierOngletFerméToolStripMenuItem.Click
        AddTab(lastClosedTab, BrowserTabs)
        lastClosedTab = ""
    End Sub
    Private Sub TabsContextMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles TabsContextMenuStrip.Opening
        If lastClosedTab = "" Then
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

    Private Sub GardeFouTimer_Tick(sender As Object, e As EventArgs) Handles GardeFouTimer.Tick
        RefreshListOfTabs()
    End Sub
    Private Sub SignalerUnSiteMalveillantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SignalerUnSiteMalveillantToolStripMenuItem.Click
        Dim WB As CustomBrowser = CType(Me.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        AddTab("https://safebrowsing.google.com/safebrowsing/report_phish/?tpl=mozilla&hl=fr&url=" + WB.Url.ToString(), BrowserTabs)
    End Sub

    Private Sub HistoriqueDeNavigationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoriqueDeNavigationToolStripMenuItem.Click
        If My.Settings.HistoryFavoritesSecurity = True Then
            EnterBrowserSettingsSecurityForm.SecurityMode = "History"
            EnterBrowserSettingsSecurityForm.ShowDialog()
        Else
            NewHistoryForm.TabControl1.SelectTab(0)
            NewHistoryForm.Show()
        End If
    End Sub

    Private Sub HistoriqueDesRecherchesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoriqueDesRecherchesToolStripMenuItem.Click
        If My.Settings.HistoryFavoritesSecurity = True Then
            EnterBrowserSettingsSecurityForm.SecurityMode = "SearchHistory"
            EnterBrowserSettingsSecurityForm.ShowDialog()
        Else
            NewHistoryForm.TabControl1.SelectTab(2)
            NewHistoryForm.Show()
        End If
    End Sub

    Private Sub TéléchargementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TéléchargementsToolStripMenuItem.Click
        If My.Settings.HistoryFavoritesSecurity = True Then
            EnterBrowserSettingsSecurityForm.SecurityMode = "DownloadHistory"
            EnterBrowserSettingsSecurityForm.ShowDialog()
        Else
            NewHistoryForm.TabControl1.SelectTab(3)
            NewHistoryForm.Show()
        End If
    End Sub

    Private Sub SeConnecterÀAppSyncToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeConnecterÀAppSyncToolStripMenuItem.Click
        If My.Settings.AppSyncDeviceNumber > 0 Then
            AppSyncLogin.ShowDialog()
        Else
            AddTab("http://smartnetappsync.wampserver/login.php?action=oneclick&token=" + appsync.GenerateToken(), BrowserTabs)
        End If
    End Sub

    Private Sub AppSyncTimer_Tick(sender As Object, e As EventArgs) Handles AppSyncTimer.Tick
        Try
            If appsync.IsDeviceRegistered() Then
                appsync.SyncNow()
            Else
                My.Settings.AppSyncLastSyncTime = New Date(1, 1, 1)
                My.Settings.AppSyncDeviceNumber = 0
                msgBar = New MessageBar(MessageBar.MessageBarLevel.Info, "Cet appareil a été déconnecté de SmartNet AppSync.", MessageBar.MessageBarAction.DisplayAppSyncLogin, "Se reconnecter...")
                DisplayMessageBar()
                SeConnecterÀAppSyncToolStripMenuItem.Text = "Se connecter à AppSync..."
                SeConnecterÀAppSyncToolStripMenuItem.Image = My.Resources.Person
            End If
        Catch ex As AppSyncException
            msgBar = New MessageBar(ex, "AppSync : Échec de la synchronisation périodique.")
            DisplayMessageBar()
        End Try
    End Sub
End Class

