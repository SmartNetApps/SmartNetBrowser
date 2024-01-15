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

    Public Sub New(newUrl As String, newTitle As String, newCreationDate As Double)
        MyBase.New(newCreationDate)
        URI = New Uri(newUrl)
        Title = If(newTitle, URI.AbsoluteUri)
    End Sub

    Public Sub New(newUrl As String, newTitle As String, newCreationDate As Double, newDeletionDate As Double)
        MyBase.New(newCreationDate, newDeletionDate)
        URI = New Uri(newUrl)
        Title = If(newTitle, URI.AbsoluteUri)
    End Sub
End Class
