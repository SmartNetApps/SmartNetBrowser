Public Class AboutForm

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label2.Text = "Version " + My.Application.Info.Version.ToString
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles HomepageLinkLabel.LinkClicked
        BrowserForm.AddTab("https://quentinpugeat.wixsite.com/apps/browser", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As EventArgs) Handles LicenseLinkLabel.LinkClicked, LicensePictureBox.Click
        LicenseForm.ShowDialog()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ClipconverterLinkLabel.LinkClicked
        BrowserForm.AddTab("http://www.clipconverter.cc/terms", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GeckoFXLinkLabel.LinkClicked
        BrowserForm.AddTab("https://www.mozilla.org/en-US/MPL/2.0/", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub ReleaseNotesLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ReleaseNotesLinkLabel.LinkClicked
        BrowserForm.AddTab("https://quentinpugeat.wixsite.com/apps/whatsnew-smartnetbrowser", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub GitHubLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GitHubLinkLabel.LinkClicked
        BrowserForm.AddTab("https://github.com/RNbowKing/SmartNetBrowser", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub AboutForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class