Imports System.Net
''' <summary>
''' Représente l'agent qui effectue le lien entre l'application cliente et SmartNet AdsBlocker.
''' </summary>
Public Class AdsBlockerAgent

    ''' <summary>
    ''' Indique si la page ou le cadre est une publicité.
    ''' </summary>
    ''' <param name="url">URL de la page ou du cadre.</param>
    ''' <returns></returns>
    Public Shared Function IsAdvertisement(url As String) As Boolean
        Dim AdsDomainsList As List(Of String) = GetBlackList()
        For Each domain In AdsDomainsList
            If url.Contains(domain) Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Vérifie si le domaine passé en paramètre est inclus dans la liste blanche de l'utilisateur.
    ''' </summary>
    ''' <param name="_domain">Nom de domaine</param>
    ''' <returns>Vrai si le domaine est en liste blanche, faux sinon.</returns>
    Public Shared Function IsWhitelisted(_domain As String) As Boolean
        For Each domain In My.Settings.AdBlockerWhitelist
            If _domain Like domain Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Télécharge et retourne la liste noire depuis les serveurs d'AdsBlocker.
    ''' </summary>
    ''' <returns>La liste noire d'AdsBlocker.</returns>
    Public Shared Function GetBlackList() As List(Of String)
        Dim AdsDomainsFileDownloader As New WebClient
        Dim AdsDomainsListFile As String = AdsDomainsFileDownloader.DownloadString("http://adsblocker.smartnetapps.quentinpugeat.fr/v1/AdsDomains.txt")
        Dim AdsDomainsList As New List(Of String)(AdsDomainsListFile.Split(","c))
        Return AdsDomainsList
    End Function
End Class
