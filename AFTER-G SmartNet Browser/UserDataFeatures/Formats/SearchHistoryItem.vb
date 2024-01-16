Public Class SearchHistoryItem
    Inherits UserDataItem

    Public Query As String

    Public Sub New(NewQuery As String)
        MyBase.New()
        Query = NewQuery
    End Sub

    Public Sub New(NewQuery As String, NewCreationDate As Double)
        MyBase.New(NewCreationDate)
        Query = NewQuery
    End Sub

    Public Sub New(NewQuery As String, NewCreationDate As Double, NewDeletionDate As Double)
        MyBase.New(NewCreationDate, NewDeletionDate)
        Query = NewQuery
    End Sub
End Class
