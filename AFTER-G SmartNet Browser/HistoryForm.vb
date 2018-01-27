Public Class HistoryForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Formhistorique_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each item In My.Settings.History
            BrowsingHistoryListBox.Items.Add(item)
        Next
        For Each item In My.Settings.SearchHistory
            SearchHistoryListBox.Items.Add(item)
        Next
        If BrowsingHistoryListBox.Items.Count = 0 Then
            DeleteAllBrowsingHistoryButton.Enabled = False
            RemoveSelectedBrowsingButton.Enabled = False
            DisplaySelectedBrowsingButton.Enabled = False
        Else
            DeleteAllBrowsingHistoryButton.Enabled = True
            RemoveSelectedBrowsingButton.Enabled = True
            DisplaySelectedBrowsingButton.Enabled = True
        End If
        If SearchHistoryListBox.Items.Count = 0 Then
            DeleteAllSearchHistoryButton.Enabled = False
            DeleteSelectedSearchButton.Enabled = False
            OpenSearchResultsButton.Enabled = False
        Else
            DeleteAllSearchHistoryButton.Enabled = True
            DeleteSelectedSearchButton.Enabled = True
            OpenSearchResultsButton.Enabled = True
        End If
    End Sub

    Private Sub DeleteAllHistory_Click(sender As Object, e As EventArgs) Handles DeleteAllBrowsingHistoryButton.Click, DeleteAllSearchHistoryButton.Click, DeleteAllDownloadHistoryButton.Click
        SettingsForm.TabControl1.SelectedTab = SettingsForm.TabControl1.TabPages.Item(1)
        SettingsForm.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles DisplaySelectedBrowsingButton.Click
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(CType(BrowsingHistoryListBox.SelectedItem, String))
        If BrowsingHistoryListBox.Items.Count = 0 Then
            DeleteAllBrowsingHistoryButton.Enabled = False
            RemoveSelectedBrowsingButton.Enabled = False
            DisplaySelectedBrowsingButton.Enabled = False
        Else
            DeleteAllBrowsingHistoryButton.Enabled = True
            RemoveSelectedBrowsingButton.Enabled = True
            DisplaySelectedBrowsingButton.Enabled = True
        End If
    End Sub
    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles BrowsingHistoryListBox.KeyDown
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If e.KeyCode = Keys.Delete Then
            My.Settings.History.Remove(CType(BrowsingHistoryListBox.SelectedItem, String))
            BrowsingHistoryListBox.Items.Remove(BrowsingHistoryListBox.SelectedItem)
            BrowserForm.URLBox.Items.Remove(BrowsingHistoryListBox.SelectedItem)
            If BrowsingHistoryListBox.Items.Count = 0 Then
                DeleteAllBrowsingHistoryButton.Enabled = False
                RemoveSelectedBrowsingButton.Enabled = False
                DisplaySelectedBrowsingButton.Enabled = False
            Else
                DeleteAllBrowsingHistoryButton.Enabled = True
                RemoveSelectedBrowsingButton.Enabled = True
                DisplaySelectedBrowsingButton.Enabled = True
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            WB.Navigate(BrowsingHistoryListBox.SelectedItem.ToString)
            Me.Close()
        End If
    End Sub
    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles BrowsingHistoryListBox.DoubleClick
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(BrowsingHistoryListBox.SelectedItem.ToString)
        Me.Close()
    End Sub
    Private Sub RemoveSelectedBrowsingButton_Click(sender As Object, e As EventArgs) Handles RemoveSelectedBrowsingButton.Click
        My.Settings.History.Remove(BrowsingHistoryListBox.SelectedItem.ToString)
        BrowsingHistoryListBox.Items.Remove(BrowsingHistoryListBox.SelectedItem)
        BrowserForm.URLBox.Items.Remove(BrowsingHistoryListBox.SelectedItem)
        If BrowsingHistoryListBox.Items.Count = 0 Then
            DeleteAllBrowsingHistoryButton.Enabled = False
            RemoveSelectedBrowsingButton.Enabled = False
            DisplaySelectedBrowsingButton.Enabled = False
        Else
            DeleteAllBrowsingHistoryButton.Enabled = True
            RemoveSelectedBrowsingButton.Enabled = True
            DisplaySelectedBrowsingButton.Enabled = True
        End If
    End Sub

    Private Sub DeleteSelectedSearchButton_Click(sender As Object, e As EventArgs) Handles DeleteSelectedSearchButton.Click
        My.Settings.SearchHistory.Remove(SearchHistoryListBox.SelectedItem.ToString)
        SearchHistoryListBox.Items.Remove(SearchHistoryListBox.SelectedItem)
        BrowserForm.SearchBox.Items.Remove(SearchHistoryListBox.SelectedItem)
        If SearchHistoryListBox.Items.Count = 0 Then
            DeleteAllSearchHistoryButton.Enabled = False
            DeleteSelectedSearchButton.Enabled = False
            OpenSearchResultsButton.Enabled = False
        Else
            DeleteAllSearchHistoryButton.Enabled = True
            DeleteSelectedSearchButton.Enabled = True
            OpenSearchResultsButton.Enabled = True
        End If
    End Sub
    Private Sub OpenSearchResultsButton_Click(sender As Object, e As EventArgs) Handles OpenSearchResultsButton.Click
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        Select Case My.Settings.SearchEngine
            Case 1
                WB.Navigate("https://www.google.fr/search?q=" + SearchHistoryListBox.SelectedItem.ToString)
            Case 2
                WB.Navigate("https://www.bing.com/search?q=" + SearchHistoryListBox.SelectedItem.ToString)
            Case 3
                WB.Navigate("https://fr.search.yahoo.com/search;_ylt=Art7C6mA.dKDerFt5RNNyYFNhJp4?p=" + SearchHistoryListBox.SelectedItem.ToString)
            Case 4
                WB.Navigate("https://duckduckgo.com/?q=" + SearchHistoryListBox.SelectedItem.ToString)
            Case 5
                WB.Navigate("https://www.qwant.com/?q=" + SearchHistoryListBox.SelectedItem.ToString)
            Case 0
                WB.Navigate(My.Settings.CustomSearchURL + SearchHistoryListBox.SelectedItem.ToString)
        End Select

        If My.Settings.PrivateBrowsing = False Then
            BrowserForm.SearchBox.Items.Add(SearchHistoryListBox.SelectedItem.ToString)
            My.Settings.SearchHistory.Add(SearchHistoryListBox.SelectedItem.ToString)
        End If
    End Sub

    Private Sub RemoveSelectedDownload_Click(sender As Object, e As EventArgs) Handles RemoveSelectedDownload.Click
        My.Settings.DownloadHistory.Remove(DownloadHistoryListBox.SelectedItem.ToString)
        DownloadHistoryListBox.Items.Remove(DownloadHistoryListBox.SelectedItem)
    End Sub
    Private Sub DownloadAgainButton_Click(sender As Object, e As EventArgs) Handles DownloadAgainButton.Click
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(DownloadHistoryListBox.SelectedItem.ToString)
    End Sub
End Class