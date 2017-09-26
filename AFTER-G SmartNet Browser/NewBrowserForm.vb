Public Class NewBrowserForm
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As Gecko.Events.GeckoDocumentCompletedEventArgs) Handles GeckoWebBrowser1.DocumentCompleted
        Try
            Dim url As Uri = New Uri(GeckoWebBrowser1.Document.Url.ToString)
            If url.HostNameType = UriHostNameType.Dns Then
                Dim iconURL = "http://" & url.Host & "/favicon.ico"
                Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(iconURL)
                Dim response As System.Net.HttpWebResponse = CType(request.GetResponse(), Net.HttpWebResponse)
                Dim stream As System.IO.Stream = response.GetResponseStream()
                Dim favicon = Image.FromStream(stream)
                FaviconBox.Image = favicon
            End If
        Catch ex As Exception
            FaviconBox.Image = FaviconBox.ErrorImage
        End Try
        Me.Text = GeckoWebBrowser1.DocumentTitle + " - SmartNet Browser"
        URLBox.Text = GeckoWebBrowser1.Document.Url.ToString
    End Sub
End Class