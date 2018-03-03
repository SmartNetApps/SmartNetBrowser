Public Class FirstStartForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            My.Settings.SearchEngine = 1
            BrowserForm.SearchBoxLabel.Text = "Google"
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            My.Settings.SearchEngine = 2
            BrowserForm.SearchBoxLabel.Text = "Bing"
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            My.Settings.SearchEngine = 3
            BrowserForm.SearchBoxLabel.Text = "Yahoo!"
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            My.Settings.SearchEngine = 4
            BrowserForm.SearchBoxLabel.Text = "DuckDuckGo"
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            My.Settings.SearchEngine = 5
            BrowserForm.SearchBoxLabel.Text = "Qwant"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        My.Settings.FirstStart = False
        My.Settings.Homepage = HomepageURLBox.Text
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        BrowserForm.AddTab("http://afterguix71.wixsite.com/smartnetbrowserhome/premier-demarrage", BrowserForm.BrowserTabs)
        Me.Close()
    End Sub

    Private Sub AdBlockerCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AdBlockerCheckBox.CheckedChanged
        If AdBlockerCheckBox.Checked = True Then
            My.Settings.AdBlocker = True
        Else
            My.Settings.AdBlocker = False
        End If
    End Sub

    Private Sub FirstStartForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class