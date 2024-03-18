''' <summary>
''' Représente une page Web.
''' </summary>
Public Class SerializableWebPage
    Inherits SerializableUserDataItem

    ''' <summary>
    ''' Titre de la page Web
    ''' </summary>
    Public Title As String

    ''' <summary>
    ''' URI de la page Web
    ''' </summary>
    Public URI As String

    ''' <summary>
    ''' Icône de la page Web
    ''' </summary>
    Public Icon As String

    Public Sub New()
        MyBase.New()
        Title = "Nameless webpage"
        URI = "about:blank"
        Icon = ImageToBase64(My.Resources.ErrorFavicon)
    End Sub

    Public Sub New(NewTitle As String)
        MyBase.New()
        Title = NewTitle
        URI = "about:blank"
        Icon = ImageToBase64(My.Resources.ErrorFavicon)
    End Sub

    Public Sub New(NewTitle As String, URL As String)
        MyBase.New()
        Title = NewTitle
        URI = URL
        Icon = ImageToBase64(My.Resources.ErrorFavicon)
    End Sub

    Public Sub New(NewTitle As String, URL As String, NewIcon As String)
        MyBase.New()
        Title = NewTitle
        URI = URL
        Icon = NewIcon
    End Sub

    Public Sub New(NewTitle As String, URL As String, NewIcon As String, NewCreationDate As Long)
        MyBase.New(NewCreationDate)
        Title = NewTitle
        URI = URL
        Icon = NewIcon
    End Sub

    Public Sub New(NewTitle As String, URL As String, NewIcon As String, NewCreationDate As Long, NewDeletionDate As Long?)
        MyBase.New(NewCreationDate, NewDeletionDate)
        Title = NewTitle
        URI = URL
        Icon = NewIcon
    End Sub

    Public Function ToRegularObject() As WebPage
        Return New WebPage(Title, URI, Base64ToImage(Icon), CreationDate, DeletionDate)
    End Function
End Class
