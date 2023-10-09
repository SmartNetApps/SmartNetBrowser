Public Class NetworkChecker
    ''' <summary>
    ''' Envoie une requête Ping à lesmajesticiels.org.
    ''' </summary>
    ''' <returns>True en cas de réussite, False en cas d'échec</returns>
    Public Shared Function IsInternetAvailable() As Boolean
        If Not My.Computer.Network.IsAvailable Then Return False

        Dim rv As Boolean = False
        Dim ping As New Net.NetworkInformation.Ping
        Dim reply As Net.NetworkInformation.PingReply
        Dim options As New Net.NetworkInformation.PingOptions

        Try
            Dim buf(4) As Byte
            reply = ping.Send("www.lesmajesticiels.org", 1000, buf, options)

            If reply.Status = Net.NetworkInformation.IPStatus.TtlExpired Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function
End Class
