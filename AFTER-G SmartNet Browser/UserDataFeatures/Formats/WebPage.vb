''' <summary>
''' Représente une page Web.
''' </summary>
Public Class WebPage
    Inherits UserDataItem

    ''' <summary>
    ''' Titre de la page Web
    ''' </summary>
    Public Title As String

    ''' <summary>
    ''' URI de la page Web
    ''' </summary>
    Public URI As Uri

    ''' <summary>
    ''' Icône de la page Web
    ''' </summary>
    Public Icon As Image

    Public Sub New()
        MyBase.New()
        Title = "Nameless webpage"
        URI = New Uri("about:blank")
        Icon = My.Resources.ErrorFavicon
    End Sub

    Public Sub New(NewTitle As String)
        MyBase.New()
        Title = NewTitle
        URI = New Uri("about:blank")
        Icon = My.Resources.ErrorFavicon
    End Sub

    Public Sub New(NewTitle As String, URL As String)
        MyBase.New()
        Title = NewTitle
        URI = New Uri(URL)
        Icon = My.Resources.ErrorFavicon
    End Sub

    Public Sub New(NewTitle As String, URL As String, NewIcon As Image)
        MyBase.New()
        Title = NewTitle
        URI = New Uri(URL)
        Icon = NewIcon
    End Sub

    Public Sub New(NewTitle As String, URL As String, NewIcon As Image, NewCreationDate As Double)
        MyBase.New(NewCreationDate)
        Title = NewTitle
        URI = New Uri(URL)
        Icon = NewIcon
    End Sub

    Public Sub New(NewTitle As String, URL As String, NewIcon As Image, NewCreationDate As Double, NewDeletionDate As Double)
        MyBase.New(NewCreationDate, NewDeletionDate)
        Title = NewTitle
        URI = New Uri(URL)
        Icon = NewIcon
    End Sub

    Public Function IsSimilarTo(otherWebPage As WebPage, Optional strict As Boolean = False) As Boolean
        If strict Then
            Return Title = otherWebPage.Title AndAlso URI.AbsoluteUri = otherWebPage.URI.AbsoluteUri AndAlso CreationDate = otherWebPage.GetRawCreationDate()
        Else
            Return Title = otherWebPage.Title AndAlso URI.AbsoluteUri = otherWebPage.URI.AbsoluteUri
        End If
    End Function
End Class
