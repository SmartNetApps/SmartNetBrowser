Public Class Webpage

    Dim name As String
    Dim URL As String
    Dim favicon As Image

    ''' <summary>
    ''' Nouvelle page
    ''' </summary>
    ''' <param name="uRL">URL de la page</param>
    Public Sub New(uRL As String)
        Me.name = New String("(Page sans nom)".ToCharArray())
        Me.URL = New String(uRL.ToCharArray())
        Me.favicon = BrowserForm.FaviconBox.ErrorImage
    End Sub

    ''' <summary>
    ''' Nouvelle page
    ''' </summary>
    ''' <param name="NewName">Nom de la page</param>
    ''' <param name="uRL">Adresse de la page</param>
    ''' <param name="favicon">Favicon de la page</param>
    Public Sub New(NewName As String, uRL As String, favicon As Image)
        Me.name = New String(NewName.ToCharArray())
        Me.URL = New String(uRL.ToCharArray())
        Me.favicon = favicon
    End Sub

    ''' <summary>
    ''' Changer le nom de la page
    ''' </summary>
    ''' <param name="Newname">Nouveau nom</param>
    Public Sub ChangeName(Newname As String)
        Me.name = Newname
    End Sub

    ''' <summary>
    ''' Changer l'URL de la page
    ''' </summary>
    ''' <param name="NewURL">Nouvelle URL</param>
    Public Sub ChangeURL(NewURL As String)
        Me.URL = NewURL
    End Sub

    ''' <summary>
    ''' Changer la favicon de la page
    ''' </summary>
    ''' <param name="NewFavicon">Nouvelle favicon</param>
    Public Sub ChangeFavicon(NewFavicon As Image)
        Me.favicon = NewFavicon
    End Sub

    ''' <summary>
    ''' Obtenir le nom de la page
    ''' </summary>
    ''' <returns></returns>
    Public Function GetName() As String
        Return name
    End Function

    ''' <summary>
    ''' Obtenir l'URL de la page
    ''' </summary>
    ''' <returns></returns>
    Public Function GetURL() As String
        Return URL
    End Function

    ''' <summary>
    ''' Obtenir la favicon de la page
    ''' </summary>
    ''' <returns></returns>
    Public Function GetFavicon() As Image
        Return favicon
    End Function

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
