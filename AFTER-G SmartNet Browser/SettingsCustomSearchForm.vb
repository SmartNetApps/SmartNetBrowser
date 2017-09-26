Public Class SettingsCustomSearchForm
    Private Sub MyBase_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        If TextBox2.Text = "" Then
            My.Settings.SearchEngine = 5
            SettingsForm.RadioButton5.Checked = True
            BrowserForm.SearchBoxLabel.Text = "Qwant"
        Else
            My.Settings.SearchEngine = 0
            My.Settings.CustomSearchName = TextBox1.Text
            My.Settings.CustomSearchURL = TextBox2.Text
            BrowserForm.SearchBoxLabel.Text = My.Settings.CustomSearchName
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub SettingsCustomSearchForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Settings.CustomSearchName = "" Then
            TextBox1.Text = "Custom Search"
        Else
            TextBox1.Text = My.Settings.CustomSearchName
        End If
        TextBox2.Text = My.Settings.CustomSearchURL
    End Sub
End Class