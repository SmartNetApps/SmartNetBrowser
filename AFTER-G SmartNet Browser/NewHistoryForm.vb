Public Class NewHistoryForm
    Dim Historique As List(Of Webpage)

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub NewHistoryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        HistoryListView.Items.Clear()
        FaviconImageList.Images.Clear()
        Historique = New List(Of Webpage)(CType(My.Settings.NewHistory, List(Of Webpage)))
        For index = 0 To Historique.Count - 1
            Dim element As New ListViewItem
            FaviconImageList.Images.Add(Historique(index).GetFavicon())
            element = HistoryListView.Items.Add(Historique(index).GetName())
            element.SubItems.Add(Historique(index).GetURL())
            HistoryListView.SmallImageList = FaviconImageList
            HistoryListView.LargeImageList = FaviconImageList
        Next
    End Sub

    Private Sub HistoryListView_DoubleClick(sender As Object, e As EventArgs) Handles HistoryListView.DoubleClick
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(HistoryListView.SelectedItems.Item(0).SubItems(1).Text)
        Me.Close()
    End Sub
End Class