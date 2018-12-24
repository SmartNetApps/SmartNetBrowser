Public Class UserAgentChangeForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ReturnToDefaultButton_Click(sender As Object, e As EventArgs) Handles ReturnToDefaultButton.Click
        Dim newUserAgent As String
        If Environment.Is64BitOperatingSystem = True Then
            newUserAgent = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0  SmartNet/" + My.Application.Info.Version.ToString
        Else
            newUserAgent = "Mozilla/5.0 (Windows NT " + Environment.OSVersion.Version.Major.ToString + "." + Environment.OSVersion.Version.Minor.ToString + "; rv:60.0) Gecko/20100101 Firefox/60.0  SmartNet/" + My.Application.Info.Version.ToString
        End If
        UserAgentRichTextBox.Text = newUserAgent
        Gecko.GeckoPreferences.User("general.useragent.override") = newUserAgent
        SettingsForm.UserAgentTextBox.Text = newUserAgent
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