Public Class AboutForm
    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If CInt(My.Application.Info.Version.Revision.ToString) > 0 Then
            Label2.Text = "Version " + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString + "." + My.Application.Info.Version.Build.ToString + " avec correctif " + My.Application.Info.Version.Revision.ToString
        Else
            Label2.Text = "Version " + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString + "." + My.Application.Info.Version.Build.ToString
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        BrowserForm.AddTab("http://quentinpugeat.wixsite.com/apps/browser", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        BrowserForm.AddTab("http://quentinpugeat.wixsite.com/lesiteofficiel/declaration-de-confidentialite", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        LicenseForm.ShowDialog()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        LicenseForm.ShowDialog()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        BrowserForm.AddTab("http://www.clipconverter.cc/terms", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        BrowserForm.AddTab("https://www.mozilla.org/en-US/MPL/2.0/", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub
End Class