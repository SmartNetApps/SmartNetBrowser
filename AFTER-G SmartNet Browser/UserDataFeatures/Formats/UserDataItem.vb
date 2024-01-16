''' <summary>
''' Représente un objet stockage en base de données utilisateur
''' </summary>
Public Class UserDataItem
    ''' <summary>
    ''' Date de création de l'objet
    ''' </summary>
    Protected ReadOnly CreationDate As Double

    ''' <summary>
    ''' Date de suppression de l'objet
    ''' </summary>
    Protected DeletionDate As Double?

    Public Sub New()
        CreationDate = TimestampConverter.DateTimeToUnixTimestamp(DateTime.Now())
        DeletionDate = Nothing
    End Sub

    Public Sub New(NewCreationDate As Double)
        CreationDate = NewCreationDate
        DeletionDate = Nothing
    End Sub

    Public Sub New(NewCreationDate As Double, NewDeletionDate As Double)
        CreationDate = NewCreationDate
        DeletionDate = NewDeletionDate
    End Sub

    Public Function GetCreationDate() As DateTime
        Return TimestampConverter.UnixTimestampToDateTime(CreationDate)
    End Function

    Public Function GetRawCreationDate() As Double
        Return CreationDate
    End Function

    Public Function GetDeletionDate() As DateTime
        Return TimestampConverter.UnixTimestampToDateTime(If(DeletionDate, 0))
    End Function

    Public Function GetRawDeletionDate() As Double?
        Return DeletionDate
    End Function

    Public Sub MarkAsDeleted()
        DeletionDate = TimestampConverter.DateTimeToUnixTimestamp(DateTime.Now())
    End Sub
End Class
