Public Class SearchHistoryItem
    Inherits UserDataItem

    Public Query As String

    Public Sub New(NewQuery As String)
        MyBase.New()
        Query = NewQuery
    End Sub

    Public Sub New(NewQuery As String, NewCreationDate As Long)
        MyBase.New(NewCreationDate)
        Query = NewQuery
    End Sub

    Public Sub New(NewQuery As String, NewCreationDate As Long, NewDeletionDate As Long?)
        MyBase.New(NewCreationDate, NewDeletionDate)
        Query = NewQuery
    End Sub

    Public Function ToSerializable() As SerializableSearchHistoryItem
        Return New SerializableSearchHistoryItem(Query, CreationDate, DeletionDate)
    End Function
End Class
