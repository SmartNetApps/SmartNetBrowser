Imports System.ComponentModel

Public Class FavoritesForm
    Private Sub DeleteFavorite_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        My.Settings.Favorites.Remove(CType(ListBox1.SelectedItem, String))
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        BrowserForm.URLBox.Items.Remove(ListBox1.SelectedItem)
        If ListBox1.Items.Count = 0 Then
            GoToFavoriteButton.Enabled = False
            DeleteButton.Enabled = False
        Else
            GoToFavoriteButton.Enabled = True
            DeleteButton.Enabled = True
        End If
    End Sub

    Private Sub GoToFavorite_Click(sender As Object, e As EventArgs) Handles GoToFavoriteButton.Click
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(ListBox1.SelectedItem.ToString)
        Me.Close()
    End Sub

    Private Sub Formbookmarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each item In My.Settings.Favorites
                ListBox1.Items.Add(item)
            Next
            If ListBox1.Items.Count = 0 Then
                GoToFavoriteButton.Enabled = False
                DeleteButton.Enabled = False
            Else
                GoToFavoriteButton.Enabled = True
                DeleteButton.Enabled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FavoritesForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If My.Settings.Favorites.Contains(WB.Url.ToString) Then
            BrowserForm.FavoritesButton.Image = BrowserForm.FavoritesButton.ErrorImage
        Else
            BrowserForm.FavoritesButton.Image = BrowserForm.FavoritesButton.InitialImage
        End If
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(ListBox1.SelectedItem.ToString)
        Me.Close()
    End Sub

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If e.KeyCode = Keys.Enter Then
            WB.Navigate(ListBox1.SelectedItem.ToString)
            Me.Close()
        End If
        If e.KeyCode = Keys.Delete Then
            My.Settings.Favorites.Remove(CType(ListBox1.SelectedItem, String))
            ListBox1.Items.Remove(ListBox1.SelectedItem)
            BrowserForm.URLBox.Items.Remove(ListBox1.SelectedItem)
            If ListBox1.Items.Count = 0 Then
                GoToFavoriteButton.Enabled = False
                DeleteButton.Enabled = False
            Else
                GoToFavoriteButton.Enabled = True
                DeleteButton.Enabled = True
            End If
        End If
    End Sub
End Class