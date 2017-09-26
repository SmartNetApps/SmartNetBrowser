Imports System.ComponentModel
Imports Gecko
Imports Gecko.Events

Public Class SourceCodeForm

    Private Sub ÀProposDeSmartNetBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÀProposDeSmartNetBrowserToolStripMenuItem.Click
        AboutForm.Show()
    End Sub

    Private Sub CopierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopierToolStripMenuItem.Click
        If GeckoWebBrowser1.CanCopySelection = True Then
            GeckoWebBrowser1.CopySelection()
        End If
    End Sub

    Private Sub FermerLaFenêtreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FermerLaFenêtreToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GeckoWebBrowser1_DocumentCompleted(sender As Object, e As GeckoDocumentCompletedEventArgs) Handles GeckoWebBrowser1.DocumentCompleted
        GeckoWebBrowser1.Navigate("view-source:" + GeckoWebBrowser1.Url.ToString)
        Label1.Visible = False
    End Sub

    Private Sub SourceCodeForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Label1.Visible = True
    End Sub

    Private Sub SourceCodeForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        GeckoWebBrowser1.NoDefaultContextMenu = True
    End Sub

    Private Sub PagePrécédenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagePrécédenteToolStripMenuItem.Click
        If GeckoWebBrowser1.CanGoBack = True Then
            GeckoWebBrowser1.GoBack()
        End If
    End Sub

    Private Sub GeckoWebBrowser1_Navigated(sender As Object, e As GeckoNavigatedEventArgs) Handles GeckoWebBrowser1.Navigated
        If GeckoWebBrowser1.CanGoBack = True Then
            PagePrécédenteToolStripMenuItem.Enabled = True
        Else
            PagePrécédenteToolStripMenuItem.Enabled = False
        End If
    End Sub
End Class