Imports System.Collections.Specialized

''' <summary>
''' Représente une liste de pages web, fournit des méthodes pour y ajouter ou supprimer des pages.
''' </summary>
Public Class WebPageList
    Inherits List(Of WebPage)

    ''' <summary>
    ''' Donne une liste de chaînes à partir de la liste de pages
    ''' </summary>
    ''' <returns>Une StringCollection</returns>
    Public Function ToStringCollection() As StringCollection
        Dim listToReturn As New StringCollection
        For Each page In Me
            listToReturn.Add(page.GetNom().Replace(">", " ") + ">" + page.GetURL() + ">" + page.GetVisitDateTime().ToString())
        Next
        Return listToReturn
    End Function

    Public Function Clone() As WebPageList
        Return CType(Me.MemberwiseClone(), WebPageList)
    End Function

    Public Overloads Function Remove(item As WebPage, compareDate As Boolean) As Boolean
        Dim theList As New WebPageList()
        For Each page In Me
            theList.Add(page)
        Next

        For Each page As WebPage In theList
            If page.GetURL() = item.GetURL() And page.GetNom() = item.GetNom() Then
                If compareDate = True Then
                    If page.GetVisitDateTime() = item.GetVisitDateTime() Then
                        Me.Remove(page)
                    End If
                Else
                    Me.Remove(page)
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' Construit une WebPageList à partir d'une StringCollection correctement construite.
    ''' </summary>
    ''' <param name="collection">La StringCollection à partir de laquelle sera construite la WebPageList.</param>
    ''' <returns>Une WebPageList</returns>
    Public Shared Function FromStringCollection(collection As StringCollection) As WebPageList
        Dim listToReturn As New WebPageList
        Dim url As String
        Dim title As String
        Dim visitDate As DateTime
        Dim pageDetails As String()
        For Each page In collection
            pageDetails = page.Split(">"c)
            title = pageDetails(0)
            url = pageDetails(1)
            visitDate = DateTime.Parse(pageDetails(2))
            listToReturn.Add(New WebPage(title, url, visitDate))
        Next
        Return listToReturn
    End Function

    ''' <summary>
    ''' Vérifier si la liste contient une page avec une URL définie en paramètre.
    ''' </summary>
    ''' <param name="url">URL de la page à trouver</param>
    ''' <returns>Vrai si l'URL a été trouvée, faux sinon.</returns>
    Public Function ContainsPage(url As String) As Boolean
        For Each page In Me
            If page.GetURL() = url Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Vérifier si la liste contient une page avec les critères définis en paramètre.
    ''' </summary>
    ''' <param name="url">URL de la page à trouver</param>
    ''' <param name="title">Titre de la page à trouver</param>
    ''' <returns>Vrai si la page a été trouvée, faux sinon.</returns>
    Public Function ContainsPage(url As String, title As String) As Boolean
        For Each page In Me
            If page.GetURL() = url And page.GetNom() = title Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Vérifier si la liste contient une page avec les critères définis en paramètre.
    ''' </summary>
    ''' <param name="url">URL de la page à trouver</param>
    ''' <param name="title">Titre de la page à trouver</param>
    ''' <param name="visitDateTime">Date et heure de visite de la page à trouver</param>
    ''' <returns>Vrai si la page a été trouvée, faux sinon.</returns>
    Public Function ContainsPage(url As String, title As String, visitDateTime As DateTime) As Boolean
        For Each page In Me
            If page.GetURL() = url And page.GetNom() = title And page.GetVisitDateTime() = visitDateTime Then
                Return True
            End If
        Next
        Return False
    End Function
End Class
