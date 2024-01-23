Imports System.Net
Public Class UpdaterForm

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub DownloadButton_Click(sender As Object, e As EventArgs) Handles DownloadButton.Click
        Try
            If MessageBox.Show("Le navigateur se fermera automatiquement pour procéder à la mise à jour. Voulez-vous continuer maintenant ?", "SmartNet Apps Updater", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
RetryDownloading:
                DownloadButton.Enabled = False
                CloseButton.Enabled = False
                ProgressBar1.Visible = True

                Dim MAJ2 As New WebClient
                AddHandler MAJ2.DownloadProgressChanged, AddressOf MAJ2_ProgressChanged
                AddHandler MAJ2.DownloadFileCompleted, AddressOf MAJ2_DownloadCompleted

                Dim DownloadLink As String = UpdateAgent.DownloadLink()
                Dim NewVersionNumber As String = UpdateAgent.LastVersionNumberAvailable()
                MAJ2.DownloadFileAsync(New Uri(DownloadLink), My.Computer.FileSystem.SpecialDirectories.Temp + "\smartnetbrowser-update-" + NewVersionNumber + ".exe")
            End If
        Catch ex As Exception
            If MessageBox.Show(ex.Message, "SmartNet Apps Updater", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) = DialogResult.Retry Then
                GoTo RetryDownloading
            End If
        End Try
    End Sub

    Private Sub MAJ2_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100
        ProgressBar1.Value = Int32.Parse(Math.Truncate(percentage).ToString())
    End Sub

    Private Sub MAJ2_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Dim NewVersionNumber As String = UpdateAgent.LastVersionNumberAvailable()
        Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp + "\smartnetbrowser-update-" + NewVersionNumber + ".exe", "/SILENT /NOCANCEL /CLOSEAPPLICATIONS /RESTARTAPPLICATIONS")
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Text = UpdateAgent.ReleaseNotes()
    End Sub
End Class