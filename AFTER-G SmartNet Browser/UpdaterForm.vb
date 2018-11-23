Imports System.Net
Public Class UpdaterForm
    Dim agent As New UpdateAgent

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub DownloadButton_Click(sender As Object, e As EventArgs) Handles DownloadButton.Click
        Try
            If MsgBox("Le navigateur se fermera tout seul pour procéder à la mise à jour. Cliquez sur Annuler pour retourner en arrière et enregistrer votre travail. Pour commencer la mise à jour, cliquez sur OK.", MsgBoxStyle.OkCancel, "SmartNet Apps Updater") = MsgBoxResult.Ok Then
                DownloadButton.Enabled = False
                CloseButton.Enabled = False
                ProgressBar1.Visible = True
                'Dim NewVersion As New WebClient
                'Dim MAJ As New WebClient
                Dim MAJ2 As New WebClient
                AddHandler MAJ2.DownloadProgressChanged, AddressOf MAJ2_ProgressChanged
                AddHandler MAJ2.DownloadFileCompleted, AddressOf MAJ2_DownloadCompleted
                Dim DownloadLink As String = agent.DownloadLink() 'MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/download.txt")
                Dim NewVersionNumber As String = agent.LastVersionNumberAvailable() 'NewVersion.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/version.txt")
                MAJ2.DownloadFileAsync(New Uri(DownloadLink), My.Computer.FileSystem.SpecialDirectories.Temp + "\smartnetbrowser-update-" + NewVersionNumber + ".exe")
            End If
        Catch ex As Exception
            MsgBox("Téléchargement impossible : " + ex.Message, CType(MessageBoxIcon.Error, MsgBoxStyle), "Téléchargement de la mise à jour")
        End Try

    End Sub

    Private Sub MAJ2_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100
        ProgressBar1.Value = Int32.Parse(Math.Truncate(percentage).ToString())
    End Sub

    Private Sub MAJ2_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        'Dim NewVersion As New WebClient
        'Dim NewVersionNumber As String = NewVersion.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/version.txt")

        Dim NewVersionNumber As String = agent.LastVersionNumberAvailable()
        Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp + "\smartnetbrowser-update-" + NewVersionNumber + ".exe", "/SILENT /NOCANCEL /CLOSEAPPLICATIONS /RESTARTAPPLICATIONS")
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim MAJ As New WebClient
        'Dim Nouveautes As String = MAJ.DownloadString("http://quentinpugeat.pagesperso-orange.fr/smartnetapps/updater/browser/windows/releasenotes.txt")
        RichTextBox1.Text = agent.ReleaseNotes()
    End Sub
End Class