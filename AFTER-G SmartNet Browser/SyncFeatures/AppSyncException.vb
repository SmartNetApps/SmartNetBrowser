Imports System.Runtime.Serialization

''' <summary>
''' Représente les erreurs qui se produisent lors de l'exécution de l'agent SmartNet AppSync.
''' </summary>
<Obsolete("Migré vers MajestiCloud v3.")>
Public Class AppSyncException
    Inherits Exception

    Public Sub New(message As String)
        MyBase.New("SmartNet AppSync a retourné le message suivant : " + message)
    End Sub

    Public Sub New(message As String, innerException As Exception)
        MyBase.New("SmartNet AppSync a retourné le message suivant : " + message, innerException)
    End Sub

    Public Overrides ReadOnly Property Message As String
        Get
            Return MyBase.Message
        End Get
    End Property

    Public Overrides ReadOnly Property Data As IDictionary
        Get
            Return MyBase.Data
        End Get
    End Property

    Public Overrides ReadOnly Property StackTrace As String
        Get
            Return MyBase.StackTrace
        End Get
    End Property

    Public Overrides Property HelpLink As String
        Get
            Return MyBase.HelpLink
        End Get
        Set(value As String)
            MyBase.HelpLink = value
        End Set
    End Property

    Public Overrides Property Source As String
        Get
            Return MyBase.Source
        End Get
        Set(value As String)
            MyBase.Source = value
        End Set
    End Property

    Public Overrides Sub GetObjectData(info As SerializationInfo, context As StreamingContext)
        MyBase.GetObjectData(info, context)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        Return MyBase.Equals(obj)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function

    Public Overrides Function GetBaseException() As Exception
        Return MyBase.GetBaseException()
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function
End Class
