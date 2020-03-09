Public Class AboutForm
    Dim versionNumber As String

    Public Sub New()
        InitializeComponent()
        versionNumber = My.Application.Info.Version.Major.ToString() + "." + My.Application.Info.Version.Minor.ToString()

        If My.Application.Info.Version.Revision <> 0 Then
            versionNumber += "." + My.Application.Info.Version.Build.ToString() + "." + My.Application.Info.Version.Revision.ToString()
        ElseIf My.Application.Info.Version.Build <> 0 Then
            versionNumber += "." + My.Application.Info.Version.Build.ToString()
        End If
    End Sub

    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label2.Text = "Version " + versionNumber
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles HomepageLinkLabel.LinkClicked
        BrowserForm.AddTab("https://smartnetapps.quentinpugeat.fr/browser")
        Me.Close()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As EventArgs) Handles LicenseLinkLabel.LinkClicked
        LicenseForm.ShowDialog()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ClipconverterLinkLabel.LinkClicked
        BrowserForm.AddTab("http://www.clipconverter.cc/terms")
        Me.Close()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GeckoFXLinkLabel.LinkClicked
        BrowserForm.AddTab("https://www.mozilla.org/en-US/MPL/2.0/")
        Me.Close()
    End Sub

    Private Sub ReleaseNotesLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ReleaseNotesLinkLabel.LinkClicked
        BrowserForm.AddTab("https://smartnetapps.quentinpugeat.fr/browser/releasenotes/" + versionNumber)
        Me.Close()
    End Sub

    Private Sub GitHubLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GitHubLinkLabel.LinkClicked
        BrowserForm.AddTab("https://github.com/RNbowKing/SmartNetBrowser")
        Me.Close()
    End Sub

    Private Sub AboutForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class