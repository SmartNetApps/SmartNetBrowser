Imports System.Collections.Specialized
Imports System.Reflection

''' <summary>
''' Fonctions héritées de gestion des données utilisateur.
''' </summary>
<Obsolete("Ces fonctions sont dépréciées, le stockage sur SQLite est désormais privilégié.")>
Module LegacyUserDataManagement
    ''' <summary>
    ''' Migration des listes Historique et Favoris du format d'origine au format évolué
    ''' </summary>
    Sub MigrateFromV1Format()
        Try
            Dim title As String
            Dim url As String
            Dim visitDate As DateTime
            Dim pageDetails As String()

            If My.Settings.History.Count > 0 AndAlso My.Settings.History(0).Contains(">") = False Then
                Dim newHistory As New WebPageList

                For Each item In My.Settings.History
                    If Not item.Contains(">") Then
                        newHistory.Add(New WebPage(item))
                    Else
                        pageDetails = item.Split(">"c)
                        title = pageDetails(0)
                        url = pageDetails(1)
                        visitDate = DateTime.Parse(pageDetails(2))
                        newHistory.Add(New WebPage(title, url, visitDate))
                    End If
                Next

                My.Settings.History = newHistory.ToStringCollection()
                My.Settings.Save()
            End If


            If My.Settings.Favorites.Count > 0 AndAlso My.Settings.Favorites(0).Contains(">") = False Then
                Dim newFavorites As New WebPageList

                For Each item In My.Settings.Favorites
                    If Not item.Contains(">") Then
                        newFavorites.Add(New WebPage(item))
                    Else
                        pageDetails = item.Split(">"c)
                        title = pageDetails(0)
                        url = pageDetails(1)
                        visitDate = DateTime.Parse(pageDetails(2))
                        newFavorites.Add(New WebPage(title, url, visitDate))
                    End If
                Next

                My.Settings.Favorites = newFavorites.ToStringCollection()
                My.Settings.Save()
            End If
        Catch ex As Exception
            MessageBox.Show(
                ex.Message,
                "Erreur pendant la migration des données (héritée)",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
            Application.Exit()
            End
        End Try
    End Sub

    Function GetHistory() As WebPageList
        Return WebPageList.FromStringCollection(My.Settings.History)
    End Function

    Function GetFavorites() As WebPageList
        Return WebPageList.FromStringCollection(My.Settings.Favorites)
    End Function

    Function GetSearchHistory() As StringCollection
        Return My.Settings.SearchHistory
    End Function

    Function GetDownloadHistory() As StringCollection
        Return My.Settings.DownloadHistory
    End Function

    ''' <summary>
    ''' Ajoute la page spécifiée dans l'historique de l'utilisateur.
    ''' </summary>
    ''' <param name="page">Page à ajouter</param>
    Sub AddInHistory(page As WebPage)
        Dim Historique As WebPageList = WebPageList.FromStringCollection(My.Settings.History)
        Historique.Add(page)
        My.Settings.History = Historique.ToStringCollection()
        My.Settings.Save()
    End Sub

    ''' <summary>
    ''' Ajoute la page spécifiée dans la liste des favoris de l'utilisateur.
    ''' </summary>
    ''' <param name="page">Page à ajouter</param>
    Sub AddInFavorites(page As WebPage)
        Dim Favoris As WebPageList = WebPageList.FromStringCollection(My.Settings.Favorites)
        Favoris.Add(page)
        My.Settings.Favorites = Favoris.ToStringCollection()
        My.Settings.Save()
    End Sub

    Sub AddInSearchHistory(query As String)
        My.Settings.SearchHistory.Add(query)
        My.Settings.Save()
    End Sub

    Sub AddInDownloadsHistory(url As String)
        My.Settings.DownloadHistory.Add(url)
        My.Settings.Save()
    End Sub

    Sub RemoveFromHistory(index As Integer)
        My.Settings.History.RemoveAt(index)
        My.Settings.Save()
    End Sub
    Sub RemoveFromFavorites(index As Integer)
        My.Settings.Favorites.RemoveAt(index)
        My.Settings.Save()
    End Sub

    Sub RemoveFromSearchHistory(index As Integer)
        My.Settings.SearchHistory.RemoveAt(index)
        My.Settings.Save()
    End Sub

    Sub RemoveFromDownloads(index As Integer)
        My.Settings.DownloadHistory.RemoveAt(index)
        My.Settings.Save()
    End Sub
End Module
