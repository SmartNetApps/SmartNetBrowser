''' <summary>
''' Représente un objet stockage en base de données utilisateur
''' </summary>
Public Class SerializableUserDataItem
    ''' <summary>
    ''' Date de création de l'objet
    ''' </summary>
    Public ReadOnly CreationDate As Long

    ''' <summary>
    ''' Date de suppression de l'objet
    ''' </summary>
    Public DeletionDate As Long?

    Public Sub New()
        CreationDate = TimestampConverter.DateTimeToUnixTimestamp(DateTime.Now())
        DeletionDate = Nothing
    End Sub

    Public Sub New(NewCreationDate As Long)
        CreationDate = NewCreationDate
        DeletionDate = Nothing
    End Sub

    Public Sub New(NewCreationDate As Long, NewDeletionDate As Long?)
        CreationDate = NewCreationDate
        DeletionDate = NewDeletionDate
    End Sub
End Class
