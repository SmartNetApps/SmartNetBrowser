Imports System.Net
Imports Gecko
Imports Gecko.Events

Public Class MajestiCloudLoginForm
    Dim WithEvents MyBrowser As GeckoWebBrowser
    Public CodeVerifier As String

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub MajestiCloudLoginForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        MyBrowser = New GeckoWebBrowser()
        BrowserPanel.Controls.Add(MyBrowser)
        MyBrowser.Dock = DockStyle.Fill
        MyBrowser.Navigate(String.Concat(
            "https://api.cloud.lesmajesticiels.org/oauth/authorize.php?client_uuid=", My.Settings.MajestiCloudClientUuid,
            "&redirect_uri=", WebUtility.UrlEncode(My.Settings.MajestiCloudRedirectUri),
            "&code_challenge=", WebUtility.UrlEncode(CodeVerifier),
            "&code_challenge_method=plain"
        ))
    End Sub

    Private Sub MajestiCloudLoginForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MyBrowser.Dispose()
    End Sub

    Private Sub MyBrowser_Navigate(sender As Object, e As GeckoNavigatingEventArgs) Handles MyBrowser.Navigating
        If Not e.Uri.Host.Contains("api.cloud.lesmajesticiels.org") And Not e.Uri.AbsoluteUri.Contains(My.Settings.MajestiCloudRedirectUri) Then
            BrowserForm.AddTab(e.Uri.AbsoluteUri)
            e.Cancel = True
        Else
            UrlLabel.Text = e.Uri.Host
        End If
    End Sub

    Private Sub MyBrowser_DOMContentLoaded(sender As Object, e As DomEventArgs) Handles MyBrowser.DOMContentLoaded
        Select Case MyBrowser.SecurityState
            Case GeckoSecurityState.Secure
                UrlLabel.ForeColor = Color.Green
            Case GeckoSecurityState.Broken
                UrlLabel.ForeColor = Color.Red
            Case GeckoSecurityState.Insecure
                UrlLabel.ForeColor = Color.Red
        End Select

        If MyBrowser.Url.AbsoluteUri.Contains(My.Settings.MajestiCloudRedirectUri) Then
            Tag = MyBrowser.Url.Query.Substring(MyBrowser.Url.Query.IndexOf("=") + 1)
            DialogResult = DialogResult.OK
            Close()
        End If
    End Sub
End Class