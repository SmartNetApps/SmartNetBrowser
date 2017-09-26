Imports System.ComponentModel
Imports System.Net

Public Class DownloadForm
    Public DownloadLink As String
    Public DownloadFolder As String
    Dim Downloader As New WebClient
    Private Sub DownloadButton_Click(sender As Object, e As EventArgs) Handles DownloadButton.Click
        Dim SaveAsDialog As New SaveFileDialog
        SaveAsDialog.FileName = FileNameLabel.Text
        SaveAsDialog.Filter = "Fichier|*." + FileNameLabel.Text.ToString.Substring(FileNameLabel.Text.ToString.LastIndexOf(".") + 1)
        SaveAsDialog.DefaultExt = FileNameLabel.Text.ToString.Substring(FileNameLabel.Text.ToString.LastIndexOf(".") + 1)
        SaveAsDialog.Title = "Télécharger le fichier..."
        If SaveAsDialog.ShowDialog = DialogResult.OK Then
            ProgressBar1.Visible = True
            DownloadButton.Visible = False
            DownloadFolder = SaveAsDialog.OpenFile.ToString
            AddHandler Downloader.DownloadFileCompleted, AddressOf Downloader_DownloadFileCompleted
            AddHandler Downloader.DownloadProgressChanged, AddressOf Downloader_DownloadProgressChanged
            Downloader.DownloadFileAsync(New Uri(DownloadLink), SaveAsDialog.FileName.ToString)
        End If
    End Sub
    Private Sub Downloader_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Process.Start("explorer", DownloadFolder)
        Me.Close()
    End Sub

    Private Sub Downloader_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100
        ProgressBar1.Value = Int32.Parse(Math.Truncate(percentage).ToString())
    End Sub

    Private Sub DownloadForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ProgressBar1.Visible = False
        DownloadButton.Visible = True
    End Sub

    Private Sub AbortButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
        Downloader.CancelAsync()
        Me.Close()
    End Sub
End Class