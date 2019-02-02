Imports System.IO
Imports System.Net
Imports Gecko
Imports Gecko.Events

Public Class CustomBrowser
    Inherits Gecko.GeckoWebBrowser

    Public Sub New()
        Me.NoDefaultContextMenu = True
        Me.ContextMenuStrip = BrowserForm.BrowserContextMenuStrip
    End Sub

    ''' <summary>
    ''' Indique si la page ou le cadre est une publicité.
    ''' </summary>
    ''' <param name="url">URL de la page ou du cadre.</param>
    ''' <returns></returns>
    Public Function IsAdvertisement(url As String) As Boolean
        Try
            Dim AdsDomainsFileDownloader As New WebClient
            Dim AdsDomainsListFile As String = AdsDomainsFileDownloader.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser/security/AdsDomains.txt")
            Dim AdsDomainsList As New List(Of String)(AdsDomainsListFile.Split(","c))
            For Each domain In AdsDomainsList
                If url.Contains(domain) Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(MessageBar.MessageBarLevel.Warning, "SmartNet AdsBlocker a rencontré une erreur. (" + ex.Message + ")", MessageBar.MessageBarAction.OpenExceptionForm, "Voir les détails", ex)
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Indique si la page est dangereuse pour les enfants.
    ''' </summary>
    ''' <param name="url">URL de la page à tester</param>
    ''' <returns></returns>
    Public Function IsDangerousForChildren(url As String) As Boolean
        Try
            Dim AdultDomainsFile As New WebClient
            Dim AdultDomainsListFile As String = AdultDomainsFile.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser/security/ChildrenProtection.txt")
            Dim AdultDomainsList As New List(Of String)(AdultDomainsListFile.Split(","c))
            For Each domain In AdultDomainsList
                If url.Contains(domain) Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(MessageBar.MessageBarLevel.Critical, "SmartNet ChildGuard a rencontré une erreur. (" + ex.Message + ")", MessageBar.MessageBarAction.OpenExceptionForm, "Voir les détails", ex)
            BrowserForm.DisplayMessageBar()
            Return False
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
                    If My.Settings.HistoryFavoritesSecurity = True Then
                        EnterBrowserSettingsSecurityForm.SecurityMode = "Favorites"
                        EnterBrowserSettingsSecurityForm.ShowDialog()
                    Else
                        NewHistoryForm.TabControl1.SelectTab(1)
                        NewHistoryForm.Show()
                    End If
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
        BrowserForm.UpdateInterface()
    End Sub

    Private Sub BrowserNavigated(sender As Object, e As Gecko.GeckoNavigatedEventArgs) Handles Me.Navigated
        BrowserForm.CurrentDocument = Me.Document
        BrowserForm.UpdateInterface()
        BrowserForm.CheckFavicon()
        If My.Settings.PrivateBrowsing = False And Not (e.Uri.ToString.Contains(My.Application.Info.DirectoryPath.Replace("\", "/")) Or e.Uri.ToString.Contains("about:") Or e.IsSameDocument Or e.IsErrorPage) Then
            BrowserForm.AddInHistory(New WebPage(Me.Document.Title, Me.Url.ToString()))
        End If
    End Sub

    Private Sub BrowserNavigating(ByVal sender As Object, ByVal e As GeckoNavigatingEventArgs) Handles Me.Navigating
        If My.Settings.ChildrenProtection = True And IsDangerousForChildren(e.Uri.ToString()) = True Then
            Dim Language As String = Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName
            If File.Exists(My.Application.Info.DirectoryPath + "\ChildGuard\" + Language + ".html") Then
                Me.Navigate("file:///" + My.Application.Info.DirectoryPath + "\ChildGuard\" + Language + ".html")
            Else
                Me.Navigate("file:///" + My.Application.Info.DirectoryPath + "\ChildGuard\en.html")
            End If
        End If

        If My.Settings.PopUpBlocker = True And My.Settings.AdBlocker = True And IsAdvertisement(e.Uri.ToString()) And Me.GetContextFlagsAttribute() = GeckoWindowFlags.WindowPopup Then
            Dim url As String = Me.Url.ToString()
            BrowserForm.BrowserTabs.TabPages.Remove(CType(Me.Tag, TabPage))
            BrowserForm.msgBar = New MessageBar(MessageBar.MessageBarLevel.Info, "SmartNet Browser a empêché l'ouverture d'une fenêtre publicitaire.", MessageBar.MessageBarAction.OpenPopup, "Ouvrir quand même", url)
            BrowserForm.DisplayMessageBar()
            Me.Dispose()
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
    ''' <param name="isPopup">Si le nouvel onglet est contextuel, indiquer True.</param>
    Public Sub AddTab(ByRef URL As String, ByRef TabControl As TabControl, Optional isPopup As Boolean = False)
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
            BrowserForm.msgBar = New MessageBar(ex)
            BrowserForm.DisplayMessageBar()
        End Try
    End Sub

    Private Sub CustomBrowser_NewWindow(sender As Object, e As Gecko.GeckoCreateWindowEventArgs) Handles Me.CreateWindow
        Try
            Dim NewBrowser As New CustomBrowser
            NewBrowser.SetContextFlagsAttribute(CType(GeckoWindowFlags.WindowPopup, UInteger)) '32768
            e.WebBrowser = NewBrowser
            Dim NewTab As New TabPage
            NewBrowser.Tag = NewTab
            NewTab.Tag = NewBrowser
            BrowserForm.ImageList1.Images.Add(BrowserForm.FaviconBox.InitialImage)
            BrowserForm.BrowserTabs.ImageList.Images.Add(BrowserForm.FaviconBox.InitialImage)
            BrowserForm.BrowserTabs.TabPages.Add(NewTab)
            NewTab.Controls.Add(NewBrowser)
            NewBrowser.Dock = DockStyle.Fill
            'NewBrowser.Navigate(Url)
            BrowserForm.BrowserTabs.SelectedTab = NewTab
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex)
            BrowserForm.DisplayMessageBar()
        End Try
    End Sub

    Private Sub CustomBrowser_FrameNavigating(sender As Object, e As GeckoNavigatingEventArgs) Handles Me.FrameNavigating
        If (My.Settings.AdBlocker = True And My.Settings.AdBlockerWhitelist.Contains(e.Uri.Host.ToString()) = False AndAlso IsAdvertisement(e.Uri.ToString()) = True) Or (My.Settings.ChildrenProtection = True AndAlso IsDangerousForChildren(e.Uri.ToString())) Then
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
        Dim doctitle As String
        If DocumentTitle = "" Then
            doctitle = Url.ToString()
        Else
            doctitle = DocumentTitle
        End If

        If doctitle.Length > 30 Then
            doctitle = doctitle.Substring(0, 26) & "..."
        End If

        CType(Me.Tag, TabPage).Text = doctitle

        If CType(Me.Tag, TabPage).TabIndex = BrowserForm.BrowserTabs.SelectedTab.TabIndex Then
            BrowserForm.Text = DocumentTitle + " - SmartNet Browser"
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

    ''' <summary>
    ''' Favicon de la page actuellement chargée
    ''' </summary>
    ''' <returns>Favicon de la page actuellement chargée</returns>
    Public Function CurrentPageFavicon() As Image
        Try
            If Me.Url.ToString.Contains("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/browser/homepage") Or Me.Url.ToString.Contains(My.Application.Info.DirectoryPath.Replace("\", "/")) Or Me.Url.ToString.Contains("about:") Then
                Return My.Resources._2019_SmartNetBrowser_32
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

    Private Sub CustomBrowser_NavigationError(sender As Object, e As GeckoNavigationErrorEventArgs) Handles MyBase.NavigationError
        Select Case e.ErrorCode
            'Case -2142568446
            '    BrowserForm.StopButton.Visible = False
            '    BrowserForm.RefreshButton.Visible = True
            Case -2142568418
                If System.IO.File.Exists(My.Application.Info.DirectoryPath + "/404/" + My.Computer.Info.InstalledUICulture.TwoLetterISOLanguageName + ".html") Then
                    Navigate("file:///" + My.Application.Info.DirectoryPath.Replace("\", "/") + "/404/" + My.Computer.Info.InstalledUICulture.TwoLetterISOLanguageName + ".html")

                Else
                    Navigate("file:///" + My.Application.Info.DirectoryPath.Replace("\", "/") + "/404/en.html")
                End If
                BrowserForm.URLBox.Text = e.Uri
            Case -2142568435
                Console.WriteLine("Refus de connexion sur " + e.Uri + " (Code d'erreur " + e.ErrorCode.ToString() + ")")
            Case Else
                Console.WriteLine("Erreur de navigation inconnue sur " + e.Uri + " (Code d'erreur " + e.ErrorCode.ToString() + ")")
        End Select
    End Sub

    Private Sub CustomBrowser_NSSError(sender As Object, e As GeckoNSSErrorEventArgs) Handles MyBase.NSSError
        Console.WriteLine("Erreur de certificat non identifiée. Code d'erreur : " + e.ErrorCode.ToString())
    End Sub
End Class
