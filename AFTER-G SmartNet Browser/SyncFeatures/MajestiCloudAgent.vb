Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class MajestiCloudAgent
    Private Shared ReadOnly APIBase As String = "https://api.cloud.lesmajesticiels.org"
    Private Shared CurrentInstance As MajestiCloudAgent
    Public CurrentSession As MajestiCloudSession

    Public Sub New()
        CurrentSession = MajestiCloudSession.FromFile()
        CheckSessionStatus()
    End Sub

    Public Shared Function GetInstance() As MajestiCloudAgent
        If CurrentInstance Is Nothing Then
            CurrentInstance = New MajestiCloudAgent
        End If

        Return CurrentInstance
    End Function

    Private Function InitWebClient() As WebClient
        Using client As New WebClient
            If (CurrentSession IsNot Nothing) Then
                client.Headers.Set(HttpRequestHeader.Authorization, String.Concat("Bearer ", CurrentSession.SessionToken))
            End If
            Return client
        End Using
    End Function

    Private Async Function GetRequest(endpoint As String) As Task(Of JObject)
        Using client As WebClient = InitWebClient()
            Dim responsebody = Await client.DownloadStringTaskAsync(New Uri(String.Concat(APIBase, endpoint)))
            Return JsonConvert.DeserializeObject(Of JObject)(responsebody)
        End Using
    End Function

    Private Async Function PostRequest(endpoint As String, postData As Specialized.NameValueCollection) As Task(Of JObject)
        Using client As WebClient = InitWebClient()
            Dim responsebytes = Await client.UploadValuesTaskAsync(String.Concat(APIBase, endpoint), "POST", postData)
            Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)
            Return JsonConvert.DeserializeObject(Of JObject)(responsebody)
        End Using
    End Function

    Private Async Function CheckSessionStatus() As Task(Of Boolean)
        If CurrentSession IsNot Nothing AndAlso NetworkChecker.IsInternetAvailable() Then
            Try
                Dim sessionFullData = Await GetRequest("/session/current.php")
                CurrentSession.UserUUID = sessionFullData("data")("user")("uuid").ToString()
                CurrentSession.UserName = sessionFullData("data")("user")("name").ToString()
                CurrentSession.UserEmail = sessionFullData("data")("user")("primary_email").ToString()
                CurrentSession.UserPicture = IconConverter.ImageToBase64(My.Resources.Person)
                CurrentSession.DeviceName = sessionFullData("data")("device_name").ToString()
                CurrentSession.SaveAsFile()
            Catch ex As Exception
                TriggerLogout(True)
                If MessageBox.Show(String.Concat("Nous avons dû vous déconnecter de MajestiCloud. Votre session a probablement été révoquée. Voulez-vous essayer de vous reconnecter maintenant ? (", ex.Message, ")"), "MajestiCloud", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    TriggerLogin()
                End If
                Return False
            End Try
        End If

        Return True
    End Function

    Public Async Sub TriggerLogin()
        If CurrentSession IsNot Nothing Then
            MessageBox.Show("Votre profil est déjà lié à un compte MajestiCloud.", "MajestiCloud", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        Dim CodeVerifier As String = RandomString.Generate(128, 43)
        Console.WriteLine(CodeVerifier)
        MajestiCloudLoginForm.CodeVerifier = CodeVerifier
        Dim DialogResponse = MajestiCloudLoginForm.ShowDialog()

        If DialogResponse = DialogResult.OK Then
            Try
                Dim reqparm As New Specialized.NameValueCollection From {
                    {"authorization_code", MajestiCloudLoginForm.Tag.ToString()},
                    {"client_uuid", My.Settings.MajestiCloudClientUuid},
                    {"code_verifier", CodeVerifier}
                }
                Dim parsedResponse = Await PostRequest("/oauth/token.php", reqparm)
                CurrentSession = New MajestiCloudSession(parsedResponse.Property("access_token").Value.ToString())

                Dim sessionFullData = Await GetRequest("/session/current.php")
                CurrentSession.UserUUID = sessionFullData("data")("user")("uuid").ToString()
                CurrentSession.UserName = sessionFullData("data")("user")("name").ToString()
                CurrentSession.UserEmail = sessionFullData("data")("user")("primary_email").ToString()
                CurrentSession.UserPicture = IconConverter.ImageToBase64(My.Resources.Person)
                CurrentSession.DeviceName = sessionFullData("data")("device_name").ToString()
                CurrentSession.SaveAsFile()
            Catch ex As Exception
                Select Case MessageBox.Show(ex.ToString(), "MajestiCloud", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)
                    Case DialogResult.Abort
                        TriggerLogout(True)
                    Case DialogResult.Retry
                        TriggerLogin()
                End Select
            End Try
        End If
    End Sub

    Public Sub TriggerLogout(Optional force As Boolean = False)
        If force OrElse MessageBox.Show("Êtes-vous sûr.e de vouloir vous déconnecter de cet appareil ?", "SmartNet AppSync", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CurrentSession.Destroy()
            CurrentSession = Nothing
        End If
    End Sub

    Public Async Sub TriggerSynchonization()
        If Not Await CheckSessionStatus() Then
            Return
        End If
    End Sub
End Class