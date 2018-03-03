Public Class UserAgentChangeForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ReturnToDefaultButton_Click(sender As Object, e As EventArgs) Handles ReturnToDefaultButton.Click
        If Environment.Is64BitOperatingSystem = True Then
            UserAgentRichTextBox.Text = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; Win64; x64; rv:45.0) Gecko/20100101 Firefox/45.0  SmartNet/" + My.Application.Info.Version.ToString
            Gecko.GeckoPreferences.User("general.useragent.override") = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; Win64; x64; rv:45.0) Gecko/20100101 Firefox/45.0  SmartNet/" + My.Application.Info.Version.ToString
            SettingsForm.UserAgentTextBox.Text = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; Win64; x64; rv:45.0) Gecko/20100101 Firefox/45.0  SmartNet/" + My.Application.Info.Version.ToString
        Else
            UserAgentRichTextBox.Text = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; rv:45.0) Gecko/20100101 Firefox/45.0  SmartNet/" + My.Application.Info.Version.ToString
            SettingsForm.UserAgentTextBox.Text = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; Win64; x64; rv:45.0) Gecko/20100101 Firefox/45.0  SmartNet/" + My.Application.Info.Version.ToString
            Gecko.GeckoPreferences.User("general.useragent.override") = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; rv:45.0) Gecko/20100101 Firefox/45.0  SmartNet/" + My.Application.Info.Version.ToString
        End If
        My.Settings.UserAgent = ""
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        My.Settings.UserAgent = UserAgentRichTextBox.Text
        Gecko.GeckoPreferences.User("general.useragent.override") = UserAgentRichTextBox.Text
        SettingsForm.UserAgentTextBox.Text = UserAgentRichTextBox.Text
        Me.Close()
    End Sub

    Private Sub UserAgentChangeForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        UserAgentRichTextBox.Text = SettingsForm.UserAgentTextBox.Text
    End Sub
End Class