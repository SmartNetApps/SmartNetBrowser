Imports System.Net
Imports Gecko.Events

Public Class CustomBrowser
    Inherits Gecko.GeckoWebBrowser
    Dim CurrentWebpage As Webpage
    Dim FirstTimeNavigated As Boolean

    Public Sub New()
        FirstTimeNavigated = True
        CurrentWebpage = New Webpage("about:blank")
        Me.NoDefaultContextMenu = True
        Me.ContextMenuStrip = BrowserForm.BrowserContextMenuStrip
        Gecko.GeckoPreferences.User("intl.accept_languages") = My.Settings.UserAgentLanguage
        Gecko.GeckoPreferences.User("general.useragent.locale") = My.Settings.UserAgentLanguage
        If My.Settings.UserAgent = "" Then
            If Environment.Is64BitOperatingSystem = True Then
                Gecko.GeckoPreferences.Default("general.useragent.override") = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; WOW64; rv:45.0) Gecko/20100101 Firefox/45.0  SmartNet/" + My.Application.Info.Version.ToString
            Else
                Gecko.GeckoPreferences.Default("general.useragent.override") = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; rv:45.0) Gecko/20100101 Firefox/45.0  SmartNet/" + My.Application.Info.Version.ToString
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
    End Sub

    ''' <summary>
    ''' Indique si la page ou le cadre est une publicité.
    ''' </summary>
    ''' <param name="url">URL de la page ou du cadre.</param>
    ''' <returns></returns>
    Public Function IsAdvertisement(url As String) As Boolean
        Dim ad As Boolean = False
        Dim target As String = url
        Dim AdsDomainsFile As New WebClient
        Dim AdsDomainsListFile As String = AdsDomainsFile.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetbrowser/AdsDomains.txt")
        Dim AdsDomainsList As New List(Of String)(AdsDomainsListFile.Split(","c))
        For I = 0 To AdsDomainsList.Count - 1
            If My.Settings.PopUpBlocker = True And target.Contains(AdsDomainsList.Item(I)) Then
                ad = True
            End If
        Next
        Return ad
    End Function

    ''' <summary>
    ''' Indique si la page est dangereuse pour les enfants.
    ''' </summary>
    ''' <param name="url">URL de la page à tester</param>
    ''' <returns></returns>
    Public Function IsDangerousForChildren(url As String) As Boolean
        Dim dangerous As Boolean = False
        If My.Settings.ChildrenProtection = True Then
            Dim AdultDomainsFile As New WebClient
            Dim AdultDomainsListFile As String = AdultDomainsFile.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetbrowser/ChildrenProtection.txt")
            Dim AdultDomainsList As New List(Of String)(AdultDomainsListFile.Split(","c))
            For I = 0 To AdultDomainsList.Count - 1
                If url.Contains(AdultDomainsList.Item(I)) Then
                    dangerous = True
                End If
            Next
        End If
        Return dangerous
    End Function

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
        CurrentWebpage.ChangeName(Me.DocumentTitle)
        CurrentWebpage.ChangeURL(Me.Url.ToString())
        CurrentWebpage.ChangeFavicon(CurrentPageFavicon())
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
                        If FirstTimeNavigated = True Then
                            BrowserForm.AddInHistory(CurrentWebpage)
                            FirstTimeNavigated = False
                        Else
                            FirstTimeNavigated = True
                        End If
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
                BrowserForm.DisplayMessageBar("Warning", "SmartNet Browser a rencontré une erreur interne.", "OpenExceptionForm", "Voir les détails", "", ex)
            End Try
        End If
    End Sub

    Private Sub BrowserNavigating(ByVal sender As Object, ByVal e As GeckoNavigatingEventArgs) Handles Me.Navigating
        If e.Uri.ToString <> "about:blank" Then
            Try
                If IsDangerousForChildren(e.Uri.ToString()) = True Then
                    Dim Language As String = Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName
                    Select Case Language
                        Case "fr"
                            Me.Navigate(My.Application.Info.DirectoryPath + "\ChildGuard\" + Language + ".html")
                        Case Else
                            Me.Navigate(My.Application.Info.DirectoryPath + "\ChildGuard\en.html")
                    End Select
                End If
            Catch ex As Exception
                BrowserForm.DisplayMessageBar("Warning", "SmartNet Browser a rencontré une erreur interne. (Code d'erreur : CHILDGUARD_ERROR)", "OpenExceptionForm", "Voir les détails", "", ex)
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
            BrowserForm.MessageBarButton1.Visible = False
            BrowserForm.MessageBarLabel1.Visible = False
            BrowserForm.MessageBarPictureBox.Visible = False
            BrowserForm.MessageBarCloseButton1.Visible = False
            BrowserForm.MessageBarButton1.Enabled = False
            BrowserForm.MessageBarCloseButton1.Enabled = False
            BrowserForm.CurrentDocument = Me.Document
            If e.Uri.ToString.Contains(My.Application.Info.DirectoryPath) Or e.Uri.ToString.Contains("https://quentinpugeat.wixsite.com/smartnetbrowserhome") Then
                BrowserForm.URLBox.Text = ""
            Else
                BrowserForm.URLBox.Text = Me.Url.ToString
            End If
            BrowserForm.Text = Me.DocumentTitle.ToString + " - SmartNet Browser"
        End If

    End Sub

    ''' <summary>
    ''' Ajoute un nouvel onglet dans le système d'onglets spécifié.
    ''' </summary>
    ''' <param name="URL">URL de la page à afficher</param>
    ''' <param name="TabControl">Système d'onglets dans lequel s'ajoute l'onglet</param>
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
            BrowserForm.DisplayMessageBar("Warning", "SmartNet Browser a rencontré une erreur interne.", "OpenExceptionForm", "Voir les détails", "", ex)
        End Try
    End Sub

    Private Sub CustomBrowser_NewWindow(sender As Object, e As Gecko.GeckoCreateWindowEventArgs) Handles Me.CreateWindow
        Try
            e.Cancel = True
            If IsAdvertisement(e.Uri) = True And My.Settings.PopUpBlocker = True And My.Settings.AllowAdsSites.Contains(Me.Url.Host.ToString) = False Then
                BrowserForm.DisplayMessageBar("Info", "SmartNet Browser a empêché l'ouverture d'une fenêtre publicitaire.", "OpenPopup", "Ouvrir quand même", e.Uri)
            Else
                AddTab(e.Uri, BrowserForm.BrowserTabs)
            End If
        Catch ex As Exception
            BrowserForm.DisplayMessageBar("Warning", "SmartNet Browser a rencontré une erreur interne.", "OpenExceptionForm", "Voir les détails", "", ex)
            If IsAdvertisement(e.Uri) = False Then
                NewBrowserForm.GeckoWebBrowser1.Navigate(e.Uri)
                NewBrowserForm.Show()
            End If
        End Try
    End Sub
    Private Sub CustomBrowser_FrameNavigating(sender As Object, e As GeckoNavigatingEventArgs) Handles Me.FrameNavigating
        Try
            If My.Settings.AllowAdsSites.Contains(Me.Url.Host.ToString) = False And My.Settings.AdBlocker = True And IsAdvertisement(e.Uri.ToString()) = True Then
                e.Cancel = True
            End If
        Catch ex As Exception
            BrowserForm.DisplayMessageBar("Warning", "SmartNet Browser a rencontré une erreur interne. (Code d'erreur : ADSBLOCKER_ERROR)", "OpenExceptionForm", "Voir les détails", "", ex)
        End Try
    End Sub

    Private Sub CustomBrowser_ShowContextMenu(sender As Object, e As Gecko.DomMouseEventArgs) Handles Me.DomContextMenu
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
    End Sub

    Private Sub CustomBrowser_DomMouseMove(sender As Object, e As Gecko.DomMouseEventArgs) Handles Me.DomMouseMove
        Try
            BrowserForm.MousePoint = New Point(e.ClientX, e.ClientY)
            BrowserForm.Ele = BrowserForm.CurrentDocument.ElementFromPoint(BrowserForm.MousePoint.X, BrowserForm.MousePoint.Y)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CustomBrowser_StatusTextChanged(sender As Object, e As EventArgs) Handles Me.StatusTextChanged
        BrowserForm.StatusLabel.Text = Me.StatusText
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
                TP.ToolTipText = Me.DocumentTitle
            Catch ex As Exception
                BrowserForm.DisplayMessageBar("Warning", "SmartNet Browser a rencontré une erreur interne.", "OpenExceptionForm", "Voir les détails", "", ex)
            End Try
        End If
    End Sub

    Private Sub CustomBrowser_CanGoBackChanged(sender As Object, e As EventArgs) Handles Me.CanGoBackChanged
        BrowserForm.PreviouspageButton.Visible = CanGoBack
    End Sub
    Private Sub CustomBrowser_CanGoForwardChanged(sender As Object, e As EventArgs) Handles Me.CanGoForwardChanged
        BrowserForm.NextpageButton.Visible = CanGoForward
    End Sub

    Private Sub CustomBrowser_ShowContextMenu(sender As Object, e As Gecko.GeckoContextMenuEventArgs) Handles Me.ShowContextMenu
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
    End Sub

    Private Sub CustomBrowser_DomClick(sender As Object, e As Gecko.DomMouseEventArgs) Handles Me.DomClick
        BrowserForm.BrowserTabs.SelectedTab.Focus()
    End Sub

    ''' <summary>
    ''' Favicon de la page actuellement chargée
    ''' </summary>
    ''' <returns></returns>
    Public Function CurrentPageFavicon() As Image
        Try
            If Me.Url.ToString.Contains("https://quentinpugeat.wixsite.com/smartnetbrowserhome") Or Me.Url.ToString.Contains(My.Application.Info.DirectoryPath) Or Me.Url.ToString.Contains("about:") Then
                Return BrowserForm.FaviconBox.InitialImage
            Else
                Dim url As Uri = New Uri(Me.Url.ToString)
                If url.HostNameType = UriHostNameType.Dns Then
                    Dim iconURL = "http://" & url.Host & "/favicon.ico"
                    Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(iconURL)
                    Dim response As System.Net.HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                    Dim stream As System.IO.Stream = response.GetResponseStream()
                    Dim favicon = Image.FromStream(stream)
                    Return favicon
                Else
                    Return BrowserForm.FaviconBox.ErrorImage
                End If
            End If
        Catch ex As Exception
            Return BrowserForm.FaviconBox.ErrorImage
        End Try
    End Function
End Class
