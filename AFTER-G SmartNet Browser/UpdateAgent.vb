Imports System.Net

''' <summary>
''' Représente un agent de mise à jour basé sur SmartNet Apps Updater.
''' </summary>
Public Class UpdateAgent
    ''' <summary>
    ''' Représente les états possibles renvoyés par SmartNet Apps Updater.
    ''' </summary>
    Public Enum UpdateStatus
        ''' <summary>
        ''' Le logiciel est à jour.
        ''' </summary>
        UpToDate
        ''' <summary>
        ''' Une mise à jour est disponible.
        ''' </summary>
        UpdateAvailable
        ''' <summary>
        ''' Le système d'exploitation n'est plus supporté.
        ''' </summary>
        OSNotSupported
        ''' <summary>
        ''' Le service Apps Updater a été interrompu pour ce logiciel.
        ''' </summary>
        SupportStatusOff
    End Enum

    Public Sub New()
    End Sub

    ''' <summary>
    ''' Vérifie si une mise à jour du logiciel est disponible et retourne la réponse de SmartNet Apps Updater.
    ''' </summary>
    ''' <returns>La réponse de SmartNet App Updater.</returns>
    Public Shared Function IsUpdateAvailable() As UpdateStatus
        Try
            Dim MAJ As New WebClient()

            Dim NTActualVersion As Version = Environment.OSVersion.Version
            Dim MiniNTVersion As Version = New Version(MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/MinimumNTVersion.txt"))

            Dim VersionActuelle As Version = My.Application.Info.Version
            Dim DerniereVersion As Version = New Version(MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/version.txt"))

            Dim SupportStatus As String = MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/support-status.txt")

            If VersionActuelle > DerniereVersion Then
                Return UpdateStatus.UpToDate
            End If
            If NTActualVersion < MiniNTVersion Then
                Return UpdateStatus.OSNotSupported
            End If
            If SupportStatus = "on" Then
                If VersionActuelle < DerniereVersion Then
                    Return UpdateStatus.UpdateAvailable
                Else
                    Return UpdateStatus.UpToDate
                End If
            Else
                Return UpdateStatus.SupportStatusOff
            End If
        Catch ex As Exception
            Throw New Exception("La connexion à SmartNet AppSync a échoué.", ex)
            Return UpdateStatus.UpToDate
        End Try
    End Function

    ''' <summary>
    ''' Demande le dernier numéro de version à SmartNet Apps Updater et le retourne.
    ''' </summary>
    ''' <returns>Le dernier numéro de version disponible.</returns>
    Public Shared Function LastVersionAvailable() As Version
        Try
            Dim MAJ As New WebClient()
            Dim DerniereVersion As Version = New Version(MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/version.txt"))
            Return DerniereVersion
        Catch ex As Exception
            Throw New Exception("La connexion à SmartNet AppSync a échoué.", ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Demande le dernier numéro de version à SmartNet Apps Updater et le retourne.
    ''' </summary>
    ''' <returns>Le dernier numéro de version disponible.</returns>
    Public Shared Function LastVersionNumberAvailable() As String
        Try
            Dim MAJ As New WebClient()
            Return MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/version.txt")
        Catch ex As Exception
            Throw New Exception("La connexion à SmartNet AppSync a échoué.", ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Retrouve et retourne le lien vers l'exécutable de la mise à jour.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function DownloadLink() As String
        Try
            Dim MAJ As New WebClient()
            Return MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/download.txt")
        Catch ex As Exception
            Throw New Exception("La connexion à SmartNet AppSync a échoué.", ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Télécharge et retourne les dernières notes de version.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function ReleaseNotes() As String
        Try
            Dim MAJ As New WebClient
            Return MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/releasenotes.txt")
        Catch ex As Exception
            Throw New Exception("La connexion à SmartNet AppSync a échoué.", ex)
            Return Nothing
        End Try
    End Function
End Class
