Public Class SerializableDownloadedItem
    Inherits SerializableUserDataItem

    Public Title As String
    Public URI As String

    Public Sub New(newUrl As String)
        MyBase.New()
        URI = newUrl
        Title = newUrl
    End Sub

    Public Sub New(newUrl As String, newTitle As String)
        MyBase.New()
        URI = newUrl
        Title = If(newTitle, newUrl)
    End Sub

    Public Sub New(newUrl As String, newTitle As String, newCreationDate As Long)
        MyBase.New(newCreationDate)
        URI = newUrl
        Title = If(newTitle, newUrl)
    End Sub

    Public Sub New(newUrl As String, newTitle As String, newCreationDate As Long, newDeletionDate As Long?)
        MyBase.New(newCreationDate, newDeletionDate)
        URI = newUrl
        Title = If(newTitle, newUrl)
    End Sub

    Public Function ToRegularObject() As DownloadedItem
        Return New DownloadedItem(URI, Title, CreationDate, DeletionDate)
    End Function
End Class
