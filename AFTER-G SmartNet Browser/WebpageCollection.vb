Imports SmartNet_Browser

<Serializable()> Public Class WebpageCollection
    Inherits List(Of Webpage)

    Public Sub New()
    End Sub

    Public Sub New(capacity As Integer)
        MyBase.New(capacity)
    End Sub

    Public Sub New(collection As IEnumerable(Of Webpage))
        MyBase.New(collection)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return MyBase.Equals(obj)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function
End Class
