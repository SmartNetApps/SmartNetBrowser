Imports System.ComponentModel
Imports System.Net

Public Class DownloadForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Public DownloadLink As String
    Public DownloadFolder As String
    Dim Downloader As New WebClient
    Dim Open As Boolean
    Private Sub DownloadButton_Click(sender As Object, e As EventArgs) Handles SaveAsButton.Click
        Open = False
        Dim SaveAsDialog As New SaveFileDialog With {
            .FileName = FileNameLabel.Text,
            .Filter = "Fichier|*." + FileNameLabel.Text.ToString.Substring(FileNameLabel.Text.ToString.LastIndexOf(".") + 1),
            .DefaultExt = FileNameLabel.Text.ToString.Substring(FileNameLabel.Text.ToString.LastIndexOf(".") + 1),
            .Title = "Télécharger le fichier..."
        }
        If SaveAsDialog.ShowDialog = DialogResult.OK Then
            ProgressBar1.Visible = True
            SaveAsButton.Visible = False
            SaveButton.Visible = False
            OpenButton.Visible = False
            DownloadFolder = SaveAsDialog.FileName.Substring(0, SaveAsDialog.FileName.Length - SaveAsDialog.FileName.Substring(SaveAsDialog.FileName.LastIndexOf("\") + 1).Length)
            AddHandler Downloader.DownloadFileCompleted, AddressOf Downloader_DownloadFileCompleted
            AddHandler Downloader.DownloadProgressChanged, AddressOf Downloader_DownloadProgressChanged
            Downloader.DownloadFileAsync(New Uri(DownloadLink), SaveAsDialog.FileName)
            If My.Settings.PrivateBrowsing = False Then
                My.Settings.DownloadHistory.Add(DownloadLink)
            End If
        End If
    End Sub
    Private Sub Downloader_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If Open = True Then
            Process.Start(DownloadFolder + "\" + FileNameLabel.Text)
        Else
            Process.Start("explorer", DownloadFolder)
        End If
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
        SaveAsButton.Visible = True
        SaveButton.Visible = True
        OpenButton.Visible = True
    End Sub

    Private Sub AbortButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
        Downloader.CancelAsync()
        Me.Close()
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Open = False
        ProgressBar1.Visible = True
        SaveAsButton.Visible = False
        SaveButton.Visible = False
        OpenButton.Visible = False
        DownloadFolder = My.Settings.DefaultDownloadFolder
        AddHandler Downloader.DownloadFileCompleted, AddressOf Downloader_DownloadFileCompleted
        AddHandler Downloader.DownloadProgressChanged, AddressOf Downloader_DownloadProgressChanged
        Downloader.DownloadFileAsync(New Uri(DownloadLink), DownloadFolder + "\" + FileNameLabel.Text)
        If My.Settings.PrivateBrowsing = False Then
            My.Settings.DownloadHistory.Add(DownloadLink)
        End If
    End Sub

    Private Sub OpenButton_Click(sender As Object, e As EventArgs) Handles OpenButton.Click
        Open = True
        ProgressBar1.Visible = True
        SaveAsButton.Visible = False
        SaveButton.Visible = False
        OpenButton.Visible = False
        DownloadFolder = My.Computer.FileSystem.SpecialDirectories.Temp
        AddHandler Downloader.DownloadFileCompleted, AddressOf Downloader_DownloadFileCompleted
        AddHandler Downloader.DownloadProgressChanged, AddressOf Downloader_DownloadProgressChanged
        Downloader.DownloadFileAsync(New Uri(DownloadLink), DownloadFolder + "\" + FileNameLabel.Text)
        If My.Settings.PrivateBrowsing = False Then
            My.Settings.DownloadHistory.Add(DownloadLink)
        End If
    End Sub
End Class