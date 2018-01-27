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
            Dim element As New ListViewItem(Historique(index).GetName(), Historique(index).GetURL())
            FaviconImageList.Images.Add(Historique(index).GetFavicon())
            HistoryListView.Items.Add(element)
        Next

        'For Each Page In CType(My.Settings.NewHistory, List(Of Webpage))
        'Dim element As New ListViewItem(Page.GetName(), Page.GetURL())
        'FaviconImageList.Images.Add(Page.GetFavicon())
        'HistoryListView.Items.Add(element)
        'Next
    End Sub
End Class