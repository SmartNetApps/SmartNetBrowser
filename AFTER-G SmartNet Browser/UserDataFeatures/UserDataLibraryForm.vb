Public Class UserDataLibraryForm
    Private db As UserDataManager = UserDataManager.GetInstance()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub NewHistoryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case TabControl1.SelectedIndex
            Case 0
                RefreshHistory()
            Case 1
                RefreshFavorites()
            Case 2
                RefreshSearches()
            Case 3
                RefreshDownloads()
        End Select
    End Sub

    Private Sub HistoryListView_DoubleClick(sender As Object, e As EventArgs) Handles HistoryListView.DoubleClick
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(HistoryListView.SelectedItems.Item(0).SubItems(1).Text)
        BrowserForm.BringToFront()
    End Sub

    Private Sub OpenPageButton_Click(sender As Object, e As EventArgs) Handles OpenPageButton.Click
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        For Each Item As ListViewItem In HistoryListView.SelectedItems
            BrowserForm.AddTab(Item.SubItems(1).Text.ToString())
        Next
        BrowserForm.BringToFront()
    End Sub

    Private Sub ButtonOpenFavorite_Click(sender As Object, e As EventArgs) Handles ButtonOpenFavorite.Click
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        For Each Item As ListViewItem In ListViewFavorites.SelectedItems
            BrowserForm.AddTab(Item.SubItems(1).Text.ToString())
        Next
        BrowserForm.BringToFront()
    End Sub

    Private Sub ButtonDeleteFavorite_Click(sender As Object, e As EventArgs) Handles ButtonDeleteFavorite.Click
        DeleteSelectedFavorites()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        DeleteSelectedHistory()
    End Sub

    Private Sub ButtonSearchAgain_Click(sender As Object, e As EventArgs) Handles ButtonSearchAgain.Click
        BrowserForm.OpenSearchResults(SearchHistoryListView.SelectedItems(0).SubItems(0).Text.ToString())
        BrowserForm.BringToFront()
    End Sub

    Private Sub ButtonDeleteSearch_Click(sender As Object, e As EventArgs) Handles ButtonDeleteSearch.Click
        DeleteSelectedSearchHistoryItems()
    End Sub

    Private Sub ListViewFavorites_DoubleClick(sender As Object, e As EventArgs) Handles ListViewFavorites.DoubleClick
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(ListViewFavorites.SelectedItems.Item(0).SubItems(1).Text)
        Me.Close()
    End Sub

    Private Sub RefreshHistory()
        HistoryListView.Items.Clear()
        HistoryFaviconImageList.Images.Clear()
        Dim Historique = db.GetHistory().GetEnumerator()
        While Historique.MoveNext()
            HistoryFaviconImageList.Images.Add(Historique.Current.Icon)
            Dim element = HistoryListView.Items.Add(Historique.Current.Title)
            element.SubItems.Add(Historique.Current.URI.AbsoluteUri)
            element.SubItems.Add(Historique.Current.GetCreationDate().ToString())
            element.Tag = Historique.Current
        End While
        HistoryListView.SmallImageList = HistoryFaviconImageList
        HistoryListView.LargeImageList = HistoryFaviconImageList
        HistoryListView.StateImageList = HistoryFaviconImageList
    End Sub

    Private Sub RefreshFavorites()
        ListViewFavorites.Items.Clear()
        FavoritesFaviconImageList.Images.Clear()
        Dim Favoris = db.GetBookmarks().GetEnumerator()
        While Favoris.MoveNext()
            FavoritesFaviconImageList.Images.Add(Favoris.Current.Icon)
            Dim element = ListViewFavorites.Items.Add(Favoris.Current.Title)
            element.SubItems.Add(Favoris.Current.URI.AbsoluteUri)
            element.Tag = Favoris.Current
        End While
        ListViewFavorites.SmallImageList = FavoritesFaviconImageList
        ListViewFavorites.LargeImageList = FavoritesFaviconImageList
        ListViewFavorites.StateImageList = FavoritesFaviconImageList
    End Sub

    Private Sub RefreshSearches()
        SearchHistoryListView.Items.Clear()
        Dim SearchHistory = db.GetSearchHistory().GetEnumerator()
        While SearchHistory.MoveNext()
            Dim element = SearchHistoryListView.Items.Add(SearchHistory.Current.Query)
            element.SubItems.Add(SearchHistory.Current.GetCreationDate().ToString())
            element.Tag = SearchHistory.Current
        End While
    End Sub

    Private Sub RefreshDownloads()
        DownloadedItemsListView.Items.Clear()
        Dim DownloadHistory = db.GetDownloadHistory().GetEnumerator()
        While DownloadHistory.MoveNext()
            Dim element = DownloadedItemsListView.Items.Add(DownloadHistory.Current.URI.AbsoluteUri)
            element.SubItems.Add(DownloadHistory.Current.Title)
            element.SubItems.Add(DownloadHistory.Current.GetCreationDate().ToString())
            element.Tag = DownloadHistory.Current
        End While
    End Sub

    Private Sub DeleteSelectedHistory()
        Dim indice As Integer
        Dim SelectedIndexes As ListView.SelectedIndexCollection
        SelectedIndexes = HistoryListView.SelectedIndices
        For i As Integer = SelectedIndexes.Count - 1 To 0 Step -1
            indice = SelectedIndexes.Item(i)
            Dim item As WebPage = CType(HistoryListView.Items(indice).Tag, WebPage)
            db.DeleteFromHistory(item.GetRawCreationDate())
        Next
        RefreshHistory()
    End Sub

    Private Sub DeleteSelectedFavorites()
        Dim indice As Integer
        Dim SelectedIndexes As ListView.SelectedIndexCollection
        SelectedIndexes = ListViewFavorites.SelectedIndices
        For i As Integer = SelectedIndexes.Count - 1 To 0 Step -1
            indice = SelectedIndexes.Item(i)
            Dim item As WebPage = CType(ListViewFavorites.Items(indice).Tag, WebPage)
            db.DeleteFromBookmarks(item.GetRawCreationDate())
        Next
        RefreshFavorites()
    End Sub

    Private Sub DeleteSelectedSearchHistoryItems()
        Dim SelectedIndexes As ListView.SelectedIndexCollection = SearchHistoryListView.SelectedIndices
        For i As Integer = SelectedIndexes.Count - 1 To 0 Step -1
            Dim index = SelectedIndexes.Item(i)
            Dim item As SearchHistoryItem = CType(SearchHistoryListView.Items(index).Tag, SearchHistoryItem)
            db.DeleteFromSearchHistory(item.GetRawCreationDate())
        Next
        RefreshSearches()
    End Sub

    Private Sub DeleteSelectedDownloadedItems()
        Dim SelectedIndexes As ListView.SelectedIndexCollection = DownloadedItemsListView.SelectedIndices
        For i As Integer = SelectedIndexes.Count - 1 To 0 Step -1
            Dim index = SelectedIndexes.Item(i)
            Dim item As DownloadedItem = CType(DownloadedItemsListView.Items(index).Tag, DownloadedItem)
            db.DeleteFromDownloadHistory(item.GetRawCreationDate())
        Next
        RefreshSearches()
    End Sub

    Private Sub FermerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FermerToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AProposDeSmartNetBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AProposDeSmartNetBrowserToolStripMenuItem.Click
        AboutForm.ShowDialog()
    End Sub

    Private Sub RafraîchirLesListesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RafraîchirLesListesToolStripMenuItem.Click
        RefreshHistory()
        RefreshFavorites()
        RefreshSearches()
        RefreshDownloads()
    End Sub

    Private Sub HistoryListView_KeyDown(sender As Object, e As KeyEventArgs) Handles HistoryListView.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                DeleteSelectedHistory()
            Case Keys.Enter
                For Each Item As ListViewItem In HistoryListView.SelectedItems
                    BrowserForm.AddTab(Item.SubItems(1).Text.ToString())
                Next
                BrowserForm.BringToFront()
        End Select
    End Sub

    Private Sub ListViewFavorites_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewFavorites.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                DeleteSelectedFavorites()
            Case Keys.Enter
                For Each Item As ListViewItem In ListViewFavorites.SelectedItems
                    BrowserForm.AddTab(Item.SubItems(1).Text.ToString())
                Next
                BrowserForm.BringToFront()
        End Select
    End Sub

    Private Sub SearchHistoryListView_KeyDown(sender As Object, e As KeyEventArgs) Handles SearchHistoryListView.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                DeleteSelectedSearchHistoryItems()
            Case Keys.Enter
                For Each Item As ListViewItem In SearchHistoryListView.SelectedItems
                    BrowserForm.OpenSearchResults(Item.SubItems(0).Text.ToString())
                Next
                BrowserForm.BringToFront()
        End Select
    End Sub

    Private Sub DownloadedItemsListView_KeyDown(sender As Object, e As KeyEventArgs) Handles DownloadedItemsListView.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                DeleteSelectedSearchHistoryItems()
            Case Keys.Enter
                For Each Item As ListViewItem In DownloadedItemsListView.SelectedItems
                    BrowserForm.AddTab(Item.SubItems(0).Text.ToString())
                Next
                BrowserForm.BringToFront()
        End Select
    End Sub

    Private Sub ButtonDeleteDownload_Click(sender As Object, e As EventArgs) Handles ButtonDeleteDownload.Click
        DeleteSelectedDownloadedItems()
    End Sub

    Private Sub ButtonDownloadAgain_Click(sender As Object, e As EventArgs) Handles ButtonDownloadAgain.Click
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(DownloadedItemsListView.SelectedItems(0).SubItems(0).Text.ToString())
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 0
                RefreshHistory()
            Case 1
                RefreshFavorites()
            Case 2
                RefreshSearches()
            Case 3
                RefreshDownloads()
        End Select
    End Sub
End Class