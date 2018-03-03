Public Class SettingsCustomSearchForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub MyBase_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        If TextBox2.Text = "" Then
            Select Case My.Settings.SearchEngine
                Case 1
                    SettingsForm.RadioButton1.Checked = True
                Case 2
                    SettingsForm.RadioButton2.Checked = True
                Case 3
                    SettingsForm.RadioButton3.Checked = True
                Case 4
                    SettingsForm.RadioButton4.Checked = True
                Case 5
                    SettingsForm.RadioButton5.Checked = True
                Case 0
                    SettingsForm.RadioButton0.Checked = True
            End Select
        Else
            My.Settings.SearchEngine = 0
            My.Settings.CustomSearchName = TextBox1.Text
            My.Settings.CustomSearchURL = TextBox2.Text
            BrowserForm.SearchBoxLabel.Text = My.Settings.CustomSearchName
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OKButton.Click
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