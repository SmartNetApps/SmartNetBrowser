''' <summary>
''' Représente une page web consultable avec un navigateur, ayant un nom, une adresse, une icône et une date de visite.
''' </summary>
Public Class WebPage
    Private nom As String
    Private URL As String
    Private favicon As Image
    Private visitDateTime As DateTime

    Public Sub New(pURL As String)
        nom = "Page sans nom"
        URL = pURL
        favicon = My.Resources.ErrorFavicon
        visitDateTime = DateTime.Now
    End Sub

    Public Sub New(pNom As String, pURL As String)
        If pNom = "" Then
            nom = "Page sans nom"
        Else
            nom = pNom
        End If
        URL = pURL
        favicon = My.Resources.ErrorFavicon
        visitDateTime = DateTime.Now
    End Sub

    Public Sub New(pNom As String, pURL As String, pVisitDateTime As DateTime)
        nom = pNom
        URL = pURL
        favicon = My.Resources.ErrorFavicon
        visitDateTime = pVisitDateTime
    End Sub

    Public Sub New(pNom As String, pURL As String, pVisitDateTime As DateTime, pFavicon As Image)
        nom = pNom
        URL = pURL
        favicon = pFavicon
        visitDateTime = pVisitDateTime
    End Sub

    Public Function GetNom() As String
        Return nom
    End Function

    Public Function GetURL() As String
        Return URL
    End Function

    Public Function GetFavicon() As Image
        Return New Bitmap(favicon, New Size(16, 16))
    End Function

    Public Function GetVisitDateTime() As DateTime
        Return visitDateTime
    End Function

    Public Sub SetURL(nouvURL As String)
        URL = nouvURL
    End Sub

    Public Sub SetNom(nouvNom As String)
        nom = nouvNom
    End Sub
End Class
