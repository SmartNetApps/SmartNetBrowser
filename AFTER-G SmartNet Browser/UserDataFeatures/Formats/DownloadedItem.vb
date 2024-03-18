Public Class DownloadedItem
    Inherits UserDataItem

    Public Title As String
    Public URI As Uri

    Public Sub New(newUrl As String)
        MyBase.New()
        URI = New Uri(newUrl)
        Title = URI.AbsoluteUri
    End Sub

    Public Sub New(newUrl As String, newTitle As String)
        MyBase.New()
        URI = New Uri(newUrl)
        Title = If(newTitle, URI.AbsoluteUri)
    End Sub

    Public Sub New(newUrl As String, newTitle As String, newCreationDate As Long)
        MyBase.New(newCreationDate)
        URI = New Uri(newUrl)
        Title = If(newTitle, URI.AbsoluteUri)
    End Sub

    Public Sub New(newUrl As String, newTitle As String, newCreationDate As Long, newDeletionDate As Long?)
        MyBase.New(newCreationDate, newDeletionDate)
        URI = New Uri(newUrl)
        Title = If(newTitle, URI.AbsoluteUri)
    End Sub

    Public Function ToSerializable() As SerializableDownloadedItem
        Return New SerializableDownloadedItem(URI.AbsoluteUri, Title, CreationDate, DeletionDate)
    End Function
End Class
