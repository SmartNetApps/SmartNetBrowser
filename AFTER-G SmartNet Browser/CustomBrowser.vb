Imports System.IO
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
        Dim AdsDomainsListFile As String = AdsDomainsFile.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser/security/AdsDomains.txt")
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
        Try
            Dim dangerous As Boolean = False
            If My.Settings.ChildrenProtection = True Then
                Dim AdultDomainsFile As New WebClient
                Dim AdultDomainsListFile As String = AdultDomainsFile.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser/security/ChildrenProtection.txt")
                Dim AdultDomainsList As New List(Of String)(AdultDomainsListFile.Split(","c))
                For I = 0 To AdultDomainsList.Count - 1
                    If url.Contains(AdultDomainsList.Item(I)) Then
                        dangerous = True
                    End If
                Next
            End If
            Return dangerous
        Catch ex As Exception
            BrowserForm.DisplayMessageBar("Critical", "SmartNet ChildGuard a rencontré une erreur inattendue. (CHILDGUARD_ERROR)", "OpenExceptionForm", "Voir les détails", "", ex)
            Return True
        End Try
    End Function

    Private Sub CustomBrowser_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F5
                    Reload()
                Case Keys.BrowserBack
                    GoBack()
                Case Keys.BrowserFavorites
                    FavoritesForm.Show()
                Case Keys.BrowserForward
                    GoForward()
                Case Keys.BrowserHome
                    AddTab(My.Settings.Homepage, BrowserForm.BrowserTabs)
                Case Keys.BrowserRefresh
                    Reload()
                Case Keys.BrowserSearch
                    BrowserForm.SearchBox.Focus()
                    BrowserForm.SearchBoxLabel.Visible = False
                Case Keys.BrowserStop
                    Me.Stop()
                Case Keys.Print
                    Navigate("javascript.print()")
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BrowserDocumentCompleted(ByVal sender As System.Object, ByVal e As GeckoDocumentCompletedEventArgs) Handles Me.DocumentCompleted
        If e.Uri.ToString <> "about:blank" Then
            BrowserForm.UpdateInterface()
        End If
    End Sub
    Private Sub BrowserNavigated(sender As Object, e As Gecko.GeckoNavigatedEventArgs) Handles Me.Navigated
        CurrentWebpage.ChangeName(Me.DocumentTitle)
        CurrentWebpage.ChangeURL(Me.Url.ToString())
        CurrentWebpage.ChangeFavicon(CurrentPageFavicon())
        If e.Uri.ToString <> "about:blank" Then
            BrowserForm.CurrentDocument = Me.Document
            BrowserForm.UpdateInterface()
            BrowserForm.CheckFavicon()
            If My.Settings.PrivateBrowsing = False Then
                If Not (e.Uri.ToString.Contains("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser/homepage") Or e.Uri.ToString.Contains(My.Application.Info.DirectoryPath.Replace("\", "/")) Or e.Uri.ToString.Contains("about:")) Then
                    If FirstTimeNavigated = True Then
                        BrowserForm.AddInHistory(CurrentWebpage)
                        FirstTimeNavigated = False
                    Else
                        FirstTimeNavigated = True
                    End If
                    BrowserForm.URLBox.Items.Add(Me.Url.ToString)
                End If
            End If
        End If
    End Sub

    Private Sub BrowserNavigating(ByVal sender As Object, ByVal e As GeckoNavigatingEventArgs) Handles Me.Navigating

        If IsDangerousForChildren(e.Uri.ToString()) = True Then
            Dim Language As String = Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName
            If File.Exists(My.Application.Info.DirectoryPath + "\ChildGuard\" + Language + ".html") Then
                Me.Navigate("file:///" + My.Application.Info.DirectoryPath + "\ChildGuard\" + Language + ".html")
            Else
                Me.Navigate("file:///" + My.Application.Info.DirectoryPath + "\ChildGuard\en.html")
            End If
        End If
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

            BrowserForm.UpdateInterface()
            BrowserForm.CheckFavicon()
            BrowserForm.CloseMessageBar()
            BrowserForm.CurrentDocument = Me.Document
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
        e.Cancel = True
        If IsAdvertisement(e.Uri) = True And My.Settings.PopUpBlocker = True And My.Settings.AllowAdsSites.Contains(Me.Url.Host.ToString) = False Then
            BrowserForm.DisplayMessageBar("Info", "SmartNet Browser a empêché l'ouverture d'une fenêtre publicitaire.", "OpenPopup", "Ouvrir quand même", e.Uri)
        Else
            AddTab(e.Uri, BrowserForm.BrowserTabs)
        End If
    End Sub

    Private Sub CustomBrowser_FrameNavigating(sender As Object, e As GeckoNavigatingEventArgs) Handles Me.FrameNavigating
        If My.Settings.AllowAdsSites.Contains(Me.Url.Host.ToString) = False And My.Settings.AdBlocker = True And IsAdvertisement(e.Uri.ToString()) = True Then
            e.Cancel = True
        End If
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
        If DocumentTitle = "" Then
            If Url.ToString.Length > 30 Then
                CType(Me.Tag, TabPage).Text = Url.ToString.Substring(0, 29) & "..."
            Else
                CType(Me.Tag, TabPage).Text = Url.ToString
            End If
            If CType(Me.Tag, TabPage).TabIndex = BrowserForm.BrowserTabs.SelectedTab.TabIndex Then
                BrowserForm.Text = Url.ToString + " - SmartNet Browser"
            End If
        Else
            If DocumentTitle.Length > 30 Then
                CType(Me.Tag, TabPage).Text = DocumentTitle.Substring(0, 29) & "..."
            Else
                CType(Me.Tag, TabPage).Text = DocumentTitle
            End If
            If CType(Me.Tag, TabPage).TabIndex = BrowserForm.BrowserTabs.SelectedTab.TabIndex Then
                BrowserForm.Text = DocumentTitle.ToString + " - SmartNet Browser"
            End If
        End If
    End Sub

    Private Sub CustomBrowser_CanGoBackChanged(sender As Object, e As EventArgs) Handles Me.CanGoBackChanged
        BrowserForm.PreviouspageButton.Enabled = CanGoBack
    End Sub
    Private Sub CustomBrowser_CanGoForwardChanged(sender As Object, e As EventArgs) Handles Me.CanGoForwardChanged
        BrowserForm.NextpageButton.Enabled = CanGoForward
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

    'Private Sub CustomBrowser_DomClick(sender As Object, e As Gecko.DomMouseEventArgs) Handles Me.DomClick
    '    BrowserForm.BrowserTabs.SelectedTab.Focus()
    'End Sub

    ''' <summary>
    ''' Favicon de la page actuellement chargée
    ''' </summary>
    ''' <returns>Favicon de la page actuellement chargée</returns>
    Public Function CurrentPageFavicon() As Image
        Try
            If Me.Url.ToString.Contains("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser/homepage") Or Me.Url.ToString.Contains(My.Application.Info.DirectoryPath.Replace("\", "/")) Or Me.Url.ToString.Contains("about:") Then
                Return My.Resources.logo32
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
                    Return My.Resources.ErrorFavicon
                End If
            End If
        Catch ex As Exception
            Return My.Resources.ErrorFavicon
        End Try
    End Function

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'CustomBrowser
        '
        Me.ResumeLayout(False)

    End Sub

    Private Sub CustomBrowser_NavigationError(sender As Object, e As GeckoNavigationErrorEventArgs) Handles MyBase.NavigationError
        Select Case e.ErrorCode
            Case -2142568446
                BrowserForm.StopButton.Visible = False
                BrowserForm.RefreshButton.Visible = True
            Case -2142568418
                If System.IO.File.Exists(My.Application.Info.DirectoryPath + "/404/" + My.Computer.Info.InstalledUICulture.TwoLetterISOLanguageName + ".html") Then
                    Navigate("file:///" + My.Application.Info.DirectoryPath.Replace("\", "/") + "/404/" + My.Computer.Info.InstalledUICulture.TwoLetterISOLanguageName + ".html")
                Else
                    Navigate("file:///" + My.Application.Info.DirectoryPath.Replace("\", "/") + "/404/en.html")
                End If
            Case Else
                Console.WriteLine("Erreur de navigation inconnue sur " + e.Uri + " Code : " + e.ErrorCode.ToString())
        End Select
        BrowserForm.URLBox.Text = e.Uri
    End Sub

    Private Sub CustomBrowser_NSSError(sender As Object, e As GeckoNSSErrorEventArgs) Handles MyBase.NSSError
        Console.WriteLine("Erreur de certificat. Code : " + e.ErrorCode.ToString())
    End Sub
End Class
