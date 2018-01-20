Imports System.Net
Imports Gecko.Events

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
