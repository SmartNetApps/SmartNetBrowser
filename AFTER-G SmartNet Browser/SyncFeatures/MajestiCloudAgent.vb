Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class MajestiCloudAgent
    Public Event SessionOpened()
    Public Event SessionClosed()
    Private Shared ReadOnly APIBase As String = "https://api.cloud.lesmajesticiels.org"
    Private Shared CurrentInstance As MajestiCloudAgent
    Public CurrentSession As MajestiCloudSession

    Structure MajestiCloudCommit
        Dim CreatedHistory As List(Of SerializableWebPage)
        Dim DeletedHistory As List(Of SerializableWebPage)
        Dim CreatedBookmarks As List(Of SerializableWebPage)
        Dim UpdatedBookmarks As List(Of SerializableWebPage)
        Dim DeletedBookmarks As List(Of SerializableWebPage)
        Dim CreatedSearchHistory As List(Of SerializableSearchHistoryItem)
        Dim DeletedSearchHistory As List(Of SerializableSearchHistoryItem)
        Dim CreatedDownloadHistory As List(Of SerializableDownloadedItem)
        Dim DeletedDownloadHistory As List(Of SerializableDownloadedItem)
    End Structure

    Public Sub New()
        CurrentSession = MajestiCloudSession.FromFile()
        CheckSessionStatus()
        TriggerSynchonization()
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
        Console.WriteLine(String.Concat(APIBase, endpoint))
        Using client As WebClient = InitWebClient()
            Dim responsebody = Await client.DownloadStringTaskAsync(New Uri(String.Concat(APIBase, endpoint)))
            Return JsonConvert.DeserializeObject(Of JObject)(responsebody)
        End Using
    End Function

    Private Async Function PostRequest(endpoint As String, postData As Specialized.NameValueCollection) As Task(Of JObject)
        Console.WriteLine(String.Concat(APIBase, endpoint))
        Using client As WebClient = InitWebClient()
            Dim responsebytes = Await client.UploadValuesTaskAsync(String.Concat(APIBase, endpoint), "POST", postData)
            Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)
            Return JsonConvert.DeserializeObject(Of JObject)(responsebody)
        End Using
    End Function

    Private Async Sub CheckSessionStatus()
        If CurrentSession IsNot Nothing AndAlso NetworkChecker.IsInternetAvailable() Then
            Try
                Dim sessionFullData = Await GetRequest("/session/current.php")
                Await InitWebClient().DownloadFileTaskAsync(
                    String.Concat(APIBase, "/user/profile_picture.php"),
                    String.Concat(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\MajestiCloudPicture.pic")
                )
                CurrentSession.UserUUID = sessionFullData("data")("user")("uuid").ToString()
                CurrentSession.UserName = sessionFullData("data")("user")("name").ToString()
                CurrentSession.UserEmail = sessionFullData("data")("user")("primary_email").ToString()
                CurrentSession.UserPicture = ImageToBase64(Image.FromFile(String.Concat(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\MajestiCloudPicture.pic")))
                CurrentSession.DeviceName = sessionFullData("data")("device_name").ToString()
                CurrentSession.SaveAsFile()
            Catch ex As Exception
                TriggerLogout(True)
                If MessageBox.Show(String.Concat("Nous avons dû vous déconnecter de MajestiCloud. Votre session a probablement été révoquée. Voulez-vous essayer de vous reconnecter maintenant ? (", ex.Message, ")"), "MajestiCloud", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    TriggerLogin()
                End If
            End Try
        End If
    End Sub

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
                Await InitWebClient().DownloadFileTaskAsync(
                    String.Concat(APIBase, "/user/profile_picture.php"),
                    String.Concat(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\MajestiCloudPicture.pic")
                )
                CurrentSession.UserUUID = sessionFullData("data")("user")("uuid").ToString()
                CurrentSession.UserName = sessionFullData("data")("user")("name").ToString()
                CurrentSession.UserEmail = sessionFullData("data")("user")("primary_email").ToString()
                CurrentSession.UserPicture = ImageToBase64(Image.FromFile(String.Concat(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\MajestiCloudPicture.pic")))
                CurrentSession.DeviceName = sessionFullData("data")("device_name").ToString()
                CurrentSession.SaveAsFile()
                RaiseEvent SessionOpened()
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

    Public Function TriggerLogout(Optional force As Boolean = False) As Boolean
        If CurrentSession Is Nothing Then
            Return True
        End If

        If force OrElse MessageBox.Show("Êtes-vous sûr.e de vouloir vous déconnecter de cet appareil ?", "MajestiCloud", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CurrentSession.Destroy()
            CurrentSession = Nothing
            RaiseEvent SessionClosed()
            Return True
        End If
        Return False
    End Function

    Public Async Sub TriggerSynchonization()
        If CurrentSession IsNot Nothing AndAlso NetworkChecker.IsInternetAvailable() Then
            Dim SyncTime As Integer = CurrentSession.GetLastSynchronizationTime()
            Dim SyncTimeObject As Date = TimestampConverter.UnixTimestampToDateTime(SyncTime)
            Dim NewCommit As New MajestiCloudCommit With {
                .CreatedHistory = UserDataManager.GetInstance().GetHistory(False, SyncTime).ConvertAll(Function(wp) wp.ToSerializable()),
                .DeletedHistory = UserDataManager.GetInstance().GetHistory(True, 0, SyncTime).ConvertAll(Function(wp) wp.ToSerializable()),
                .CreatedBookmarks = UserDataManager.GetInstance().GetBookmarks(False, SyncTime).ConvertAll(Function(wp) wp.ToSerializable()),
                .DeletedBookmarks = UserDataManager.GetInstance().GetBookmarks(True, 0, SyncTime).ConvertAll(Function(wp) wp.ToSerializable()),
                .CreatedSearchHistory = UserDataManager.GetInstance().GetSearchHistory(False, SyncTime).ConvertAll(Function(h) h.ToSerializable()),
                .DeletedSearchHistory = UserDataManager.GetInstance().GetSearchHistory(True, 0, SyncTime).ConvertAll(Function(h) h.ToSerializable()),
                .CreatedDownloadHistory = UserDataManager.GetInstance().GetDownloadHistory(False, SyncTime).ConvertAll(Function(h) h.ToSerializable()),
                .DeletedDownloadHistory = UserDataManager.GetInstance().GetDownloadHistory(True, 0, SyncTime).ConvertAll(Function(h) h.ToSerializable())
            }
            Dim RequestParams As New Specialized.NameValueCollection From {
                {"last_sync_datetime", DateTimeToSQLDateTime(SyncTimeObject)},
                {"new_commit", JsonConvert.SerializeObject(NewCommit)}
            }

            Try
                IO.File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Temp & "\majesticlouddump.json", JsonConvert.SerializeObject(NewCommit))
                Dim Response = Await PostRequest("/browser/synchronize.php", RequestParams)
                IO.File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Temp & "\majesticlouddump_response.json", JsonConvert.SerializeObject(Response))
                CurrentSession.SetLastSynchronizationTime(DateTimeToUnixTimestamp(Date.Now))

                Dim IncomingCommits As JArray = TryCast(Response("commits"), JArray)
                Dim IncomingCommitsEnum = IncomingCommits.GetEnumerator()
                While IncomingCommitsEnum.MoveNext()
                    UserDataManager.GetInstance().AddInHistory(Array.ConvertAll(TryCast(IncomingCommitsEnum.Current("CreatedHistory"), JArray).ToArray(), Function(x) x.ToObject(Of SerializableWebPage).ToRegularObject()))
                    UserDataManager.GetInstance().DeleteFromHistory(Array.ConvertAll(TryCast(IncomingCommitsEnum.Current("DeletedHistory"), JArray).ToArray(), Function(x) x.ToObject(Of SerializableWebPage).CreationDate))
                    UserDataManager.GetInstance().AddInBookmarks(Array.ConvertAll(TryCast(IncomingCommitsEnum.Current("CreatedBookmarks"), JArray).ToArray(), Function(x) x.ToObject(Of SerializableWebPage).ToRegularObject()))
                    UserDataManager.GetInstance().DeleteFromBookmarks(Array.ConvertAll(TryCast(IncomingCommitsEnum.Current("DeletedBookmarks"), JArray).ToArray(), Function(x) x.ToObject(Of SerializableWebPage).CreationDate))
                    UserDataManager.GetInstance().AddInSearchHistory(Array.ConvertAll(TryCast(IncomingCommitsEnum.Current("CreatedSearchHistory"), JArray).ToArray(), Function(x) x.ToObject(Of SerializableSearchHistoryItem).ToRegularObject()))
                    UserDataManager.GetInstance().DeleteFromSearchHistory(Array.ConvertAll(TryCast(IncomingCommitsEnum.Current("DeletedSearchHistory"), JArray).ToArray(), Function(x) x.ToObject(Of SerializableSearchHistoryItem).CreationDate))
                    UserDataManager.GetInstance().DeleteFromDownloadHistory(Array.ConvertAll(TryCast(IncomingCommitsEnum.Current("DeletedDownloadHistory"), JArray).ToArray(), Function(x) x.ToObject(Of SerializableDownloadedItem).CreationDate))
                End While
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End If
    End Sub
End Class