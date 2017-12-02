Public Class AboutForm
    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Application.Info.Version.Revision > 0 Then
            Label2.Text = "Version " + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString + "." + My.Application.Info.Version.Build.ToString + " avec correctif " + My.Application.Info.Version.Revision.ToString
        Else
            Label2.Text = "Version " + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString + "." + My.Application.Info.Version.Build.ToString
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles HomepageLinkLabel.LinkClicked
        BrowserForm.AddTab("https://quentinpugeat.wixsite.com/apps/browser", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LicenseLinkLabel.LinkClicked
        LicenseForm.ShowDialog()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles LicensePictureBox.Click
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
End Class