Imports System.Net
Imports System.Web
Imports System.Text
Imports Newtonsoft.Json

''' <summary>
''' Agent de connexion de SmartNet AppSync
''' </summary>
Public Class AppSyncAgent
    Structure Connection
        Dim idUtilisateur As Integer
        Dim idConnexion, nomConnexion, applicationConnexion As String
        Dim dateDeDerniereConnexion As Date
    End Structure

    Structure BrowserConfig
        Dim idBrowserConfig, searchEngine, idUtilisateur As Integer
        Dim privateBrowsing, preventMultipleTabsClose, adBlocker, deleteCookiesWhileClosing, popUpBlocker, doNotTrack As Integer
        Dim customSearchURL, customSearchName, homepage, adBlockerWhitelist, userAgentLanguage As String
        Dim lastSyncDateTime As Date
    End Structure

    Structure BrowserSearchHistory
        Dim idBrowserSearchHistory, idUtilisateur As Integer
        Dim searchHistoryText As String
    End Structure

    Structure Page
        Dim pageTitle, pageURL As String
        Dim pageVisitDateTime As Date
    End Structure

    ''' <summary>
    ''' Vérifie les identifiants entrés par l'utilisateur
    ''' </summary>
    ''' <param name="username">Nom d'utilisateur</param>
    ''' <param name="password">Mot de passe</param>
    ''' <returns>Vrai si les identifiants sont bons, Faux sinon</returns>
    Public Shared Function CheckCredentials(username As String, password As String) As Boolean
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/main/query.php"
        Dim queryParameters As String = "?action=CheckCredentials&username=" + username + "&password=" + password
        Console.WriteLine(engineURL + queryParameters)

        resultat = client.DownloadString(engineURL + queryParameters)

        If resultat.ToLower() = "false" Then
            Return False
        ElseIf resultat.ToLower() = "true" Then
            Return True
        Else
            Throw New AppSyncException(resultat)
        End If
    End Function

    ''' <summary>
    ''' Charge l'ID de l'utilisateur de SmartNet AppSync à partir de l'adresse e-mail
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetUserID() As Integer
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
        Dim queryParameters As String = "?action=GetUserID&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = client.DownloadString(engineURL + queryParameters)

        If resultat.Contains("err#") Then
            Throw New AppSyncException(resultat.Substring(4))
        Else
            Return CType(resultat, Integer)
        End If
    End Function

    ''' <summary>
    ''' Charge le prénom et le nom de l'utilisateur tels qu'enregistrés sur SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetUserName() As String
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
        Dim queryParameters As String = "?action=GetUserName&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = client.DownloadString(engineURL + queryParameters)

        If resultat.Contains("err#") Then
            Throw New AppSyncException(resultat.Substring(4))
        Else
            Return resultat
        End If
    End Function

    ''' <summary>
    ''' Charge l'image de profil de l'utilisateur depuis SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetUserProfilePicture() As Bitmap
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
        Dim queryParameters As String = "?action=GetUserProfilePicture&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = client.DownloadString(engineURL + queryParameters)

        If resultat.Contains("err#") Then
            Throw New AppSyncException(resultat.Substring(4))
        ElseIf resultat.ToLower() = "null" Then
            Return My.Resources.Person
        Else
            Dim imgDistantPath As String = resultat
            Dim imgLocalPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData.ToString() + "\appsyncprofilepic" + imgDistantPath.Substring(imgDistantPath.LastIndexOf("."))
            Try
                If System.IO.File.Exists(imgLocalPath) Then
                    System.IO.File.Delete(imgLocalPath)
                End If
                Dim telechargeur As New WebClient()
                telechargeur.DownloadFile(imgDistantPath, imgLocalPath)
            Catch ex As Exception
            End Try
            Return New Bitmap(imgLocalPath)
        End If
    End Function

    ''' <summary>
    ''' Charge la configuration distante et l'enregistre sur le profil local.
    ''' </summary>
    ''' <returns>Vrai si l'enregistrement se passe sans erreur.</returns>
    Public Shared Async Function GetConfig() As Task(Of Boolean)
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=GetConfig&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

        If resultat.Contains("err#") Then
            Throw New AppSyncException(resultat.Substring(4))
        Else
            Dim config As BrowserConfig = JsonConvert.DeserializeObject(Of BrowserConfig)(resultat)
            My.Settings.PrivateBrowsing = CBool(config.privateBrowsing)
            My.Settings.PreventMultipleTabsClose = CBool(config.preventMultipleTabsClose)
            My.Settings.SearchEngine = config.searchEngine
            My.Settings.CustomSearchURL = WebUtility.UrlDecode(config.customSearchURL)
            My.Settings.CustomSearchName = WebUtility.UrlDecode(config.customSearchName)
            My.Settings.AdBlocker = CBool(config.adBlocker)
            My.Settings.DeleteCookiesWhileClosing = CBool(config.deleteCookiesWhileClosing)
            My.Settings.PopUpBlocker = CBool(config.popUpBlocker)
            My.Settings.Homepage = WebUtility.UrlDecode(config.homepage)
            My.Settings.UserAgentLanguage = config.userAgentLanguage
            My.Settings.DoNotTrack = CBool(config.doNotTrack)
            Return True
        End If
    End Function

    ''' <summary>
    ''' Envoie la configuration locale sur le serveur AppSync en écrasant l'existant.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Async Function SendConfig() As Task(Of Boolean)
        Dim config As New BrowserConfig


        If My.Settings.PrivateBrowsing Then
            config.privateBrowsing = 1
        Else
            config.privateBrowsing = 0
        End If
        If My.Settings.PreventMultipleTabsClose Then
            config.preventMultipleTabsClose = 1
        Else
            config.preventMultipleTabsClose = 0
        End If
        config.searchEngine = My.Settings.SearchEngine
        config.customSearchURL = WebUtility.UrlEncode(My.Settings.CustomSearchURL)
        config.customSearchName = WebUtility.UrlEncode(My.Settings.CustomSearchName)
        If My.Settings.AdBlocker Then
            config.adBlocker = 1
        Else
            config.adBlocker = 0
        End If
        If My.Settings.DeleteCookiesWhileClosing Then
            config.deleteCookiesWhileClosing = 1
        Else
            config.deleteCookiesWhileClosing = 0
        End If
        If My.Settings.PopUpBlocker Then
            config.popUpBlocker = 1
        Else
            config.popUpBlocker = 0
        End If
        config.homepage = WebUtility.UrlEncode(My.Settings.Homepage)
        config.userAgentLanguage = My.Settings.UserAgentLanguage
        If My.Settings.DoNotTrack Then
            config.doNotTrack = 1
        Else
            config.doNotTrack = 0
        End If
        config.lastSyncDateTime = My.Settings.AppSyncLastSyncTime

        Dim jsonconfig As String = JsonConvert.SerializeObject(config)
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=SendConfig&config=" + jsonconfig + "&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

        If resultat.ToLower() = "false" Then
            Return False
        ElseIf resultat.ToLower() = "true" Then
            Return True
        Else
            Throw New AppSyncException(resultat)
        End If
    End Function

    Public Shared Async Function GetHistory() As Task(Of WebPageList)
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=GetHistory&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

        If (resultat.Contains("err#")) Then
            Throw New AppSyncException(resultat.Substring(4))
        Else
            Dim history As List(Of Page) = JsonConvert.DeserializeObject(Of List(Of Page))(resultat)
            Dim list As New WebPageList()
            For Each p As Page In history
                list.Add(New WebPage(WebUtility.UrlDecode(p.pageTitle), WebUtility.UrlDecode(p.pageURL), p.pageVisitDateTime))
            Next
            Return list
        End If
    End Function

    Public Shared Async Function GetFavorites() As Task(Of WebPageList)
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=GetFavorites&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

        If (resultat.Contains("err#")) Then
            Throw New AppSyncException(resultat.Substring(4))
        Else
            Dim favorites As List(Of Page) = JsonConvert.DeserializeObject(Of List(Of Page))(resultat)
            Dim list As New WebPageList()
            For Each p As Page In favorites
                list.Add(New WebPage(WebUtility.UrlDecode(p.pageTitle), WebUtility.UrlDecode(p.pageURL)))
            Next
            Return list
        End If
    End Function

    Public Shared Async Function GetSearchHistory() As Task(Of Specialized.StringCollection)
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=GetSearchHistory&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

        If (resultat.Contains("err#")) Then
            Throw New AppSyncException(resultat.Substring(4))
        Else
            Dim searchhistory As List(Of BrowserSearchHistory) = JsonConvert.DeserializeObject(Of List(Of BrowserSearchHistory))(resultat)
            Dim list As New Specialized.StringCollection()
            For Each p In searchhistory
                list.Add(WebUtility.UrlDecode(p.searchHistoryText))
            Next
            Return list
        End If
    End Function

    Public Shared Async Function AddHistory(page As WebPage) As Task(Of Boolean)
        Dim laPage As New Page
        laPage.pageTitle = WebUtility.UrlEncode(page.GetNom())
        laPage.pageURL = WebUtility.UrlEncode(page.GetURL())
        laPage.pageVisitDateTime = page.GetVisitDateTime()
        Dim jsonpage As String = JsonConvert.SerializeObject(laPage)

        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=AddHistory&page=" + jsonpage + "&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

        If resultat = "false" Then
            Return False
        ElseIf resultat = "true" Then
            Return True
        Else
            Throw New AppSyncException(resultat)
        End If
    End Function

    Public Shared Async Function AddFavorite(page As WebPage) As Task(Of Boolean)
        Dim laPage As New Page
        laPage.pageTitle = WebUtility.UrlEncode(page.GetNom())
        laPage.pageURL = WebUtility.UrlEncode(page.GetURL())
        Dim jsonpage As String = JsonConvert.SerializeObject(laPage)

        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=AddFavorite&page=" + jsonpage + "&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

        If resultat = "false" Then
            Return False
        ElseIf resultat = "true" Then
            Return True
        Else
            Throw New AppSyncException(resultat)
        End If
    End Function

    Public Shared Async Function AddSearchHistory(query As String) As Task(Of Boolean)
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=AddSearchHistory&texte=" + WebUtility.UrlEncode(query) + "&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

        If resultat = "false" Then
            Return False
        ElseIf resultat = "true" Then
            Return True
        Else
            Throw New AppSyncException(resultat)
        End If
    End Function

    Public Shared Async Function DeleteHistory(page As WebPage) As Task(Of Boolean)
        Dim laPage As New Page
        laPage.pageTitle = WebUtility.UrlEncode(page.GetNom())
        laPage.pageURL = WebUtility.UrlEncode(page.GetURL())
        laPage.pageVisitDateTime = page.GetVisitDateTime()
        Dim jsonpage As String = JsonConvert.SerializeObject(laPage)

        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=DeleteHistory&page=" + jsonpage + "&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

        If resultat = "false" Then
            Return False
        ElseIf resultat = "true" Then
            Return True
        Else
            Throw New AppSyncException(resultat)
        End If
    End Function

    Public Shared Async Function DeleteFavorite(page As WebPage) As Task(Of Boolean)
        Dim laPage As New Page
        laPage.pageTitle = WebUtility.UrlEncode(page.GetNom())
        laPage.pageURL = WebUtility.UrlEncode(page.GetURL())
        Dim jsonpage As String = JsonConvert.SerializeObject(laPage)

        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=DeleteFavorite&page=" + jsonpage + "&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

        If resultat = "false" Then
            Return False
        ElseIf resultat = "true" Then
            Return True
        Else
            Throw New AppSyncException(resultat)
        End If
    End Function

    Public Shared Async Function DeleteSearchHistory(query As String) As Task(Of Boolean)
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=DeleteSearchHistory&texte=" + WebUtility.UrlEncode(query) + "&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

        If (resultat.Contains("err#")) Then
            Throw New AppSyncException(resultat.Substring(4))
        ElseIf (resultat = "false") Then
            Return False
        Else
            Return True
        End If
    End Function


    ''' <summary>
    ''' Charge la dernière date et heure de synchronisation de la configuration.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function LastConfigSyncTime() As Date
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=GetLastSyncTime&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

        resultat = client.DownloadString(engineURL + queryParameters)

        If resultat.Contains("err#") Then
            Throw New AppSyncException(resultat)
        ElseIf resultat.Length = 0 Then
            Return New Date(1, 1, 1)
        Else
            Return New Date(CInt(resultat.Substring(0, 4)), CInt(resultat.Substring(5, 2)), CInt(resultat.Substring(8, 2)), CInt(resultat.Substring(11, 2)), CInt(resultat.Substring(14, 2)), CInt(resultat.Substring(17, 2)))
        End If
    End Function

    Public Shared Async Function RefreshSyncTime() As Task(Of Boolean)
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
        Dim queryParameters As String = "?action=RefreshSyncTime&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

        My.Settings.AppSyncLastSyncTime = Date.Now
        resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

        If resultat = "false" Then
            Return False
        ElseIf resultat = "true" Then
            Return True
        Else
            Throw New AppSyncException(resultat)
        End If
    End Function

    ''' <summary>
    ''' Génère et retourne un jeton de connexion pour l'utilisateur connecté à SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GenerateToken() As String
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
        Dim queryParameters As String = "?action=GenerateToken&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = client.DownloadString(engineURL + queryParameters)

        If resultat.Contains("err#") Then
            Throw New AppSyncException(resultat.Substring(4))
        ElseIf resultat = "false" Then
            Return "False"
        Else
            Return resultat
        End If
    End Function

    ''' <summary>
    ''' Synchronise les données de l'utilisateur avec la base de données de SmartNet AppSync.
    ''' </summary>
    ''' <returns>Vrai si réussite, Faux en cas d'échec.</returns>
    Public Shared Async Function SyncNow() As Task(Of Boolean)
        SettingsForm.ButtonSyncNow.Text = "Synchronisation en cours..."
        SettingsForm.ButtonSyncNow.Enabled = False

        Dim config As Boolean
        'Dim history As Boolean
        'Dim searchHistory As Boolean
        'Dim favorites As Boolean

        Dim theHistory As WebPageList = WebPageList.FromStringCollection(My.Settings.History)
        Dim theOnlineHistory As WebPageList = Await GetHistory()
        Dim theFavorites As WebPageList = WebPageList.FromStringCollection(My.Settings.Favorites)
        Dim theOnlineFavorites As WebPageList = Await GetFavorites()
        Dim theSearchHistory As Specialized.StringCollection = My.Settings.SearchHistory
        Dim theOnlineSearchHistory As Specialized.StringCollection = Await GetSearchHistory()

        If My.Settings.AppSyncLastSyncTime >= LastConfigSyncTime() Then
            config = Await SendConfig()

            For Each p As WebPage In theHistory
                If theOnlineHistory.ContainsPage(p.GetURL(), p.GetNom(), p.GetVisitDateTime()) = False Then
                    Await AddHistory(p)
                End If
            Next

            For Each p As WebPage In theOnlineHistory
                If theHistory.ContainsPage(p.GetURL(), p.GetNom(), p.GetVisitDateTime()) = False Then
                    Await DeleteHistory(p)
                End If
            Next

            For Each p As WebPage In theFavorites
                If theOnlineFavorites.ContainsPage(p.GetURL(), p.GetNom()) = False Then
                    Await AddFavorite(p)
                End If
            Next

            For Each op As WebPage In theOnlineFavorites
                If theFavorites.ContainsPage(op.GetURL(), op.GetNom()) = False Then
                    Await DeleteFavorite(op)
                End If
            Next

            For Each q As String In theSearchHistory
                If theOnlineSearchHistory.Contains(q) = False Then
                    Await AddSearchHistory(q)
                End If
            Next

            For Each q As String In theOnlineSearchHistory
                If theSearchHistory.Contains(q) = False Then
                    Await DeleteSearchHistory(q)
                End If
            Next
        Else
            config = Await GetConfig()

            Dim theNewHistory As WebPageList = WebPageList.FromStringCollection(My.Settings.History)
            Dim theNewFavorites As WebPageList = WebPageList.FromStringCollection(My.Settings.Favorites)
            Dim theNewSearchHistory As Specialized.StringCollection = My.Settings.SearchHistory

            For Each p As WebPage In theHistory
                If theOnlineHistory.ContainsPage(p.GetURL(), p.GetNom(), p.GetVisitDateTime()) = False Then
                    theNewHistory.Remove(p, True)
                End If
            Next

            For Each p As WebPage In theFavorites
                If theOnlineFavorites.ContainsPage(p.GetURL(), p.GetNom()) = False Then
                    theNewFavorites.Remove(p, False)
                End If
            Next

            For Each q As String In theSearchHistory
                If theOnlineSearchHistory.Contains(q) = False Then
                    theNewSearchHistory.Remove(q)
                End If
            Next

            For Each p As WebPage In theOnlineHistory
                If theNewHistory.ContainsPage(p.GetURL(), p.GetNom(), p.GetVisitDateTime()) = False Then
                    theNewHistory.Add(p)
                End If
            Next

            For Each op As WebPage In theOnlineFavorites
                If theNewFavorites.ContainsPage(op.GetURL(), op.GetNom()) = False Then
                    theNewFavorites.Add(op)
                    BrowserForm.URLBox.Items.Add(op.GetURL())
                End If
            Next

            For Each q As String In theOnlineSearchHistory
                If theNewSearchHistory.Contains(q) = False Then
                    theNewSearchHistory.Add(q)
                    BrowserForm.SearchBox.Items.Add(q)
                End If
            Next

            My.Settings.History = theNewHistory.ToStringCollection()
            My.Settings.Favorites = theNewFavorites.ToStringCollection()
            My.Settings.SearchHistory = theNewSearchHistory
        End If

        Dim synctime As Boolean = Await RefreshSyncTime()
        SettingsForm.ButtonSyncNow.Text = "Synchroniser maintenant"
        SettingsForm.ButtonSyncNow.Enabled = True
        Return (config And synctime)
    End Function

    ''' <summary>
    ''' Supprime l'appareil de la base de données SmartNet AppSync. Avertissement : ceci obligera l'utilisateur à se reconnecter.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function UnregisterDevice() As Boolean
        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/main/query.php"
        Dim queryParameters As String = "?action=UnregisterDevice&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
        Console.WriteLine(engineURL + queryParameters)

        resultat = client.DownloadString(engineURL + queryParameters)

        If resultat = "false" Then
            Return False
        ElseIf resultat = "true" Then
            My.Settings.AppSyncDeviceNumber = ""
            Return True
        Else
            Throw New AppSyncException(resultat)
        End If
    End Function

    ''' <summary>
    ''' Enregistre l'appareil pour l'autoriser à utiliser SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function RegisterDevice(username As String, password As String) As Boolean
        If IsDeviceRegistered() Then
            UnregisterDevice()
        End If

        Dim client As New WebClient
        Dim resultat As String
        Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/main/query.php"
        Dim queryParameters As String = "?action=RegisterDevice&username=" + username + "&password=" + password + "&machineName=" + Environment.MachineName + "&appName=SmartNet Browser"
        Console.WriteLine(engineURL + queryParameters)

        resultat = client.DownloadString(engineURL + queryParameters)

        If resultat = "false" Then
            Return False
        ElseIf resultat.Contains("err#") Then
            Throw New AppSyncException(resultat.Substring(4))
        Else
            My.Settings.AppSyncDeviceNumber = resultat
            My.Settings.Save()
            Return True
        End If
    End Function

    ''' <summary>
    ''' Vérifie si l'appareil est enregistré auprès de SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function IsDeviceRegistered() As Boolean
        If My.Settings.AppSyncDeviceNumber <> "" Then
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
            Dim queryParameters As String = "?action=IsDeviceRegistered&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
            Console.WriteLine(engineURL + queryParameters)

            resultat = client.DownloadString(engineURL + queryParameters)

            If resultat.Contains("err#") Then
                Return False
                'Throw New AppSyncException(resultat.Substring(4))
            Else
                Dim details As Connection = JsonConvert.DeserializeObject(Of Connection)(resultat)
                Dim result As Boolean = (details.idUtilisateur = GetUserID())
                If (result = False) Then
                    Throw New AppSyncException("Le numéro de session enregistré n'est pas associé à l'utilisateur actuellement connecté")
                    Return False
                Else
                    Return True
                End If
            End If
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Récupère le nom de l'appareil depuis SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetDeviceName() As String
        If IsDeviceRegistered() Then
            Try
                Dim client As New WebClient
                Dim resultat As String
                Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
                Dim queryParameters As String = "?action=GetDeviceName&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()
                Console.WriteLine(engineURL + queryParameters)

                resultat = client.DownloadString(engineURL + queryParameters)

                If resultat.Contains("err#") Then
                    Throw New AppSyncException(resultat.Substring(4))
                Else
                    Return resultat
                End If
            Catch ex As Exception
                Throw New AppSyncException("Une erreur est survenue lors de la réception du nom de votre appareil depuis AppSync.", ex)
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function SetDeviceName(newDeviceName As String) As Boolean
        If IsDeviceRegistered() Then
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
            Dim queryParameters As String = "?action=SetDeviceName&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString() + "NewName=" + newDeviceName
            Console.WriteLine(engineURL + queryParameters)

            resultat = client.DownloadString(engineURL + queryParameters)

            If resultat = "false" Then
                Return False
            ElseIf resultat = "true" Then
                Return True
            Else
                Throw New AppSyncException(resultat)
            End If
        Else
            Return False
        End If
    End Function
End Class
