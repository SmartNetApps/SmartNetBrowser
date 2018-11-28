Public Class WebPage
    Private nom As String
    Private URL As String
    Private favicon As Bitmap

    Public Sub New(pURL As String)
        nom = "Page sans nom"
        URL = pURL
        favicon = My.Resources.ErrorFavicon
    End Sub

    Public Sub New(pNom As String, pURL As String)
        nom = pNom
        URL = pURL
        favicon = My.Resources.ErrorFavicon
    End Sub

    Public Function GetNom() As String
        Return nom
    End Function

    Public Function GetURL() As String
        Return URL
    End Function

    Public Function GetFavicon() As Bitmap
        Return favicon
    End Function

    Public Sub SetURL(nouvURL As String)
        URL = nouvURL
    End Sub

    Public Sub SetNom(nouvNom As String)
        nom = nouvNom
    End Sub
End Class
