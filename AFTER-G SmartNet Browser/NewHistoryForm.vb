Public Class NewHistoryForm
    Dim Historique As List(Of WebPage)
    Dim Favoris As List(Of WebPage)

    Public Sub New()
        InitializeComponent()
        Historique = New List(Of WebPage)
        Favoris = New List(Of WebPage)
    End Sub

    Private Sub NewHistoryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        HistoryListView.Items.Clear()
        HistoryFaviconImageList.Images.Clear()
        Historique = BrowserForm.Historique
        For Each entree In Historique
            Dim element As New ListViewItem
            HistoryFaviconImageList.Images.Add(entree.GetFavicon())
            element = CType(HistoryListView.Items.Add(entree.GetNom()), ListViewItem)
            element.SubItems.Add(entree.GetURL())
        Next
        HistoryListView.SmallImageList = HistoryFaviconImageList
        HistoryListView.LargeImageList = HistoryFaviconImageList


        ListViewFavorites.Items.Clear()
        FavoritesFaviconImageList.Images.Clear()
        Favoris = BrowserForm.Favoris
        For Each entree In Favoris
            Dim element As New ListViewItem
            FavoritesFaviconImageList.Images.Add(entree.GetFavicon())
            element = CType(ListViewFavorites.Items.Add(entree.GetNom()), ListViewItem)
            element.SubItems.Add(entree.GetURL())
        Next
        ListViewFavorites.SmallImageList = FavoritesFaviconImageList
        ListViewFavorites.LargeImageList = FavoritesFaviconImageList
    End Sub

    Private Sub HistoryListView_DoubleClick(sender As Object, e As EventArgs) Handles HistoryListView.DoubleClick
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(HistoryListView.SelectedItems.Item(0).SubItems(1).Text)
        Me.Close()
    End Sub

    Private Sub OpenPageButton_Click(sender As Object, e As EventArgs) Handles OpenPageButton.Click
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        For Each Item As ListViewItem In HistoryListView.SelectedItems
            BrowserForm.AddTab(Item.SubItems(1).Text.ToString(), BrowserForm.BrowserTabs)
        Next
        WB.Navigate(HistoryListView.SelectedItems.Item(0).SubItems(1).Text)
        Me.Close()
    End Sub

    Private Sub OpenOldHistoryButton_Click(sender As Object, e As EventArgs) Handles OpenOldHistoryButton.Click
        HistoryForm.Show()
        Me.Close()
    End Sub
End Class