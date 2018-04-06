Imports System.Net

<Serializable()> Public Class Webpage

    Public name As String
    Public URL As String
    Public favicon As Image

    Public Sub New()
        name = New String("(Page sans nom)".ToCharArray())
        Me.URL = New String("about:blank".ToCharArray())
        Try
            If Me.URL.Contains("https://quentinpugeat.wixsite.com/smartnetbrowserhome") Or Me.URL.Contains(My.Application.Info.DirectoryPath) Or Me.URL.Contains("about:") Then
                Me.favicon = BrowserForm.FaviconBox.InitialImage
            Else
                Dim iurl As Uri = New Uri(Me.URL)
                If iurl.HostNameType = UriHostNameType.Dns Then
                    Dim iconURL = "http://" & iurl.Host & "/favicon.ico"
                    Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(iconURL)
                    Dim response As System.Net.HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                    Dim stream As System.IO.Stream = response.GetResponseStream()
                    Dim Newfavicon = Image.FromStream(stream)
                    Me.favicon = Newfavicon
                Else
                    Me.favicon = BrowserForm.FaviconBox.ErrorImage
                End If
            End If
        Catch ex As Exception
            Me.favicon = BrowserForm.FaviconBox.ErrorImage
        End Try
    End Sub

    ''' <summary>
    ''' Nouvelle page
    ''' </summary>
    ''' <param name="uRL">URL de la page</param>
    Public Sub New(uRL As String)
        Me.name = New String("(Page sans nom)".ToCharArray())
        Me.URL = New String(uRL.ToCharArray())
        Try
            If Me.URL.Contains("https://quentinpugeat.wixsite.com/smartnetbrowserhome") Or Me.URL.Contains(My.Application.Info.DirectoryPath) Or Me.URL.Contains("about:") Then
                Me.favicon = BrowserForm.FaviconBox.InitialImage
            Else
                Dim iurl As Uri = New Uri(Me.URL)
                If iurl.HostNameType = UriHostNameType.Dns Then
                    Dim iconURL = "http://" & iurl.Host & "/favicon.ico"
                    Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(iconURL)
                    Dim response As System.Net.HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                    Dim stream As System.IO.Stream = response.GetResponseStream()
                    Dim Newfavicon = Image.FromStream(stream)
                    Me.favicon = Newfavicon
                Else
                    Me.favicon = BrowserForm.FaviconBox.ErrorImage
                End If
            End If
        Catch ex As Exception
            Me.favicon = BrowserForm.FaviconBox.ErrorImage
        End Try
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
        Return name + "," + URL
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return MyBase.Equals(obj)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function
End Class
