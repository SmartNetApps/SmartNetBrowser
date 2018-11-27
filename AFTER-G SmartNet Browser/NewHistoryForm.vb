Public Class NewHistoryForm
    'Dim Historique As List(Of Webpage)

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub NewHistoryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        HistoryListView.Items.Clear()
        FaviconImageList.Images.Clear()
        'If Not (My.Settings.NewHistory Is Nothing) Then
        '    For Each entree In My.Settings.NewHistory
        '        Dim element As New ListViewItem
        '        FaviconImageList.Images.Add(New Bitmap(0, 0))
        '        element = CType(HistoryListView.Items.Add(entree.Split("\").GetValue(1)), ListViewItem)
        '        element.SubItems.Add(entree.Split("\").GetValue(1))
        '    Next
        '    HistoryListView.SmallImageList = FaviconImageList
        '    HistoryListView.LargeImageList = FaviconImageList
        'End If
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