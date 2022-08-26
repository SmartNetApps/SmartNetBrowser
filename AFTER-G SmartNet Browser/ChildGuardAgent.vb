Imports System.Net
''' <summary>
''' Représente l'agent qui effectue le lien entre l'application cliente et SmartNet ChildGuard.
''' </summary>
Public Class ChildGuardAgent
    ''' <summary>
    ''' Indique si la page est orientée pour les adultes.
    ''' </summary>
    ''' <param name="url">URL de la page à tester</param>
    ''' <returns></returns>
    Public Shared Function IsAdultContent(url As String) As Boolean
        Dim AdultDomainsList As List(Of String) = GetBlackList()
        For Each domain In AdultDomainsList
            If url.Contains(domain) Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Télécharge et retourne la liste noire depuis les serveurs de ChildGuard.
    ''' </summary>
    ''' <returns>La liste noire de ChildGuard.</returns>
    Public Shared Function GetBlackList() As List(Of String)
        Dim AdultDomainsFile As New WebClient
        Dim AdultDomainsListFile As String = AdultDomainsFile.DownloadString("https://browser-api.lesmajesticiels.org/childguard/v1/ChildrenProtection.txt")
        Dim AdultDomainsList As New List(Of String)(AdultDomainsListFile.Split(","c))
        Return AdultDomainsList
    End Function
End Class
