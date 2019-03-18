Imports System.Net
Imports System.Text
Imports MySql.Data.MySqlClient
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
        Dim privateBrowsing, preventMultipleTabsClose, adBlocker, childrenProtection, browserSettingsSecurity, deleteCookiesWhileClosing, popUpBlocker, historyFavoritesSecurity, doNotTrack As Integer
        Dim customSearchURL, customSearchName, childrenProtectionPassword, browserSettingsSecurityPassword, homepage, adBlockerWhitelist, userAgentLanguage As String
        Dim lastSyncDateTime As Date
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
    Public Function CheckCredentials(username As String, password As String) As Boolean
        Try
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/main/query.php"
            Dim queryParameters As String = "?action=CheckCredentials&username=" + username + "&password=" + password

            resultat = client.DownloadString(engineURL + queryParameters)

            If resultat.Contains("err#") Then
                Throw New AppSyncException(resultat.Substring(4))
            ElseIf resultat = "true" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de la vérification de vos identifiants AppSync.", ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Charge l'ID de l'utilisateur de SmartNet AppSync à partir de l'adresse e-mail
    ''' </summary>
    ''' <returns></returns>
    Public Function GetUserID() As Integer
        Try
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
            Dim queryParameters As String = "?action=GetUserID&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = client.DownloadString(engineURL + queryParameters)

            If resultat.Contains("err#") Then
                Throw New AppSyncException(resultat.Substring(4))
            Else
                Return CType(resultat, Integer)
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de la réception de votre ID d'utilisateur AppSync.", ex)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Charge le prénom et le nom de l'utilisateur tels qu'enregistrés sur SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetUserName() As String
        Try
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
            Dim queryParameters As String = "?action=GetUserName&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = client.DownloadString(engineURL + queryParameters)

            If resultat.Contains("err#") Then
                Throw New AppSyncException(resultat.Substring(4))
            Else
                Return resultat
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de la réception de votre nom depuis AppSync.", ex)
            Return "Compte AppSync"
        End Try
    End Function

    ''' <summary>
    ''' Charge l'image de profil de l'utilisateur depuis SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetUserProfilePicture() As Bitmap
        Try
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
            Dim queryParameters As String = "?action=GetUserProfilePicture&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = client.DownloadString(engineURL + queryParameters)

            If resultat.Contains("err#") Then
                Throw New AppSyncException(resultat.Substring(4))
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
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de la réception de votre photo de profil depuis AppSync.", ex)
            Return My.Resources.Person
        End Try
    End Function

    ''' <summary>
    ''' Charge la configuration distante et l'enregistre sur le profil local.
    ''' </summary>
    ''' <returns>Vrai si l'enregistrement se passe sans erreur.</returns>
    Public Async Function GetConfig() As Task(Of Boolean)
        Try
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
            Dim queryParameters As String = "?action=GetConfig&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

            If resultat.Contains("err#") Then
                Throw New AppSyncException(resultat.Substring(4))
            Else
                Dim config As BrowserConfig = JsonConvert.DeserializeObject(Of BrowserConfig)(resultat)
                My.Settings.PrivateBrowsing = config.privateBrowsing
                My.Settings.PreventMultipleTabsClose = config.preventMultipleTabsClose
                My.Settings.SearchEngine = config.searchEngine
                My.Settings.CustomSearchURL = config.customSearchURL
                My.Settings.CustomSearchName = config.customSearchName
                My.Settings.AdBlocker = config.adBlocker
                My.Settings.ChildrenProtection = config.childrenProtection
                My.Settings.ChildrenProtectionPassword = config.childrenProtectionPassword
                My.Settings.BrowserSettingsSecurity = config.browserSettingsSecurity
                My.Settings.BrowserSettingsSecurityPassword = config.browserSettingsSecurityPassword
                My.Settings.DeleteCookiesWhileClosing = config.deleteCookiesWhileClosing
                My.Settings.PopUpBlocker = config.popUpBlocker
                My.Settings.Homepage = config.homepage
                My.Settings.UserAgentLanguage = config.userAgentLanguage
                My.Settings.HistoryFavoritesSecurity = config.historyFavoritesSecurity
                My.Settings.DoNotTrack = config.doNotTrack
                My.Settings.AppSyncLastSyncTime = config.lastSyncDateTime
                Return True
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de la réception de votre configuration depuis AppSync.", ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Envoie la configuration locale sur le serveur AppSync en écrasant l'existant.
    ''' </summary>
    ''' <returns></returns>
    Public Async Function SendConfig() As Task(Of Boolean)
        Try
            Dim config As New BrowserConfig

            config.privateBrowsing = My.Settings.PrivateBrowsing
            config.preventMultipleTabsClose = My.Settings.PreventMultipleTabsClose
            config.searchEngine = My.Settings.SearchEngine
            config.customSearchURL = My.Settings.CustomSearchURL
            config.customSearchName = My.Settings.CustomSearchName
            config.adBlocker = My.Settings.AdBlocker
            config.childrenProtection = My.Settings.ChildrenProtection
            config.childrenProtectionPassword = My.Settings.ChildrenProtectionPassword
            config.browserSettingsSecurity = My.Settings.BrowserSettingsSecurity
            config.browserSettingsSecurityPassword = My.Settings.BrowserSettingsSecurityPassword
            config.deleteCookiesWhileClosing = My.Settings.DeleteCookiesWhileClosing
            config.popUpBlocker = My.Settings.PopUpBlocker
            config.homepage = My.Settings.Homepage
            config.userAgentLanguage = My.Settings.UserAgentLanguage
            config.historyFavoritesSecurity = My.Settings.HistoryFavoritesSecurity
            config.doNotTrack = My.Settings.DoNotTrack
            config.lastSyncDateTime = My.Settings.AppSyncLastSyncTime

            Dim jsonconfig As String = JsonConvert.SerializeObject(config)
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
            Dim queryParameters As String = "?action=SendConfig&config=" + jsonconfig + "&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

            If (resultat.Contains("err#")) Then
                Throw New AppSyncException(resultat.Substring(4))
            ElseIf resultat = "false" Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de l'envoi de votre configuration vers AppSync.", ex)
            Return False
        End Try
    End Function

    Public Async Function GetHistory() As Task(Of WebPageList)
        Try
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
            Dim queryParameters As String = "?action=GetHistory&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

            If (resultat.Contains("err#")) Then
                Throw New AppSyncException(resultat.Substring(4))
            Else
                Dim history As List(Of Page) = JsonConvert.DeserializeObject(Of List(Of Page))(resultat)
                Dim list As New WebPageList()
                For Each p As Page In history
                    list.Add(New WebPage(p.pageTitle, p.pageURL, p.pageVisitDateTime))
                Next
                Return list
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de la réception de votre historique de navigation depuis AppSync.", ex)
            Return Nothing
        End Try
    End Function

    Public Async Function GetFavorites() As Task(Of WebPageList)
        Try
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
            Dim queryParameters As String = "?action=GetFavorites&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

            If (resultat.Contains("err#")) Then
                Throw New AppSyncException(resultat.Substring(4))
            Else
                Dim favorites As List(Of Page) = JsonConvert.DeserializeObject(Of List(Of Page))(resultat)
                Dim list As New WebPageList()
                For Each p As Page In favorites
                    list.Add(New WebPage(p.pageTitle, p.pageURL))
                Next
                Return list
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de la réception de vos favoris depuis AppSync.", ex)
            Return Nothing
        End Try
    End Function

    Public Function GetSearchHistory() As Specialized.StringCollection
        Try
            Return Nothing
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de la réception de votre historique de recherche depuis AppSync.", ex)
            Return Nothing
        End Try
    End Function

    '''' <summary>
    '''' Charge la dernière date et heure de synchronisation de l'historique.
    '''' </summary>
    '''' <returns></returns>
    'Public Function LastHistorySyncTime() As Date
    '    Try
    '        Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
    '        connection.Open()
    '        Dim dataReader As MySqlDataReader
    '        Dim query As String = "SELECT MAX(pageVisitDateTime) AS lastSyncDateTime from browserhistory WHERE idUtilisateur = @userid"
    '        Dim command As New MySqlCommand()
    '        command.Connection = connection
    '        command.CommandText = query
    '        command.Prepare()
    '        command.Parameters.AddWithValue("@userid", GetUserID())
    '        dataReader = command.ExecuteReader
    '        Dim result As Date
    '        If dataReader.Read() Then
    '            result = dataReader.GetDateTime("lastSyncDateTime")
    '        Else
    '            result = New Date(1, 1, 1)
    '        End If
    '        connection.Close()
    '        Return result
    '    Catch ex As Exception
    '        Throw New AppSyncException("Une erreur est survenue lors de la récupération de la dernière date de synchronisation de votre historique de navigation depuis AppSync.", ex)
    '        Return New Date(1, 1, 1)
    '    End Try
    'End Function

    Public Async Function AddHistory(page As WebPage) As Task(Of Boolean)
        Try
            Dim laPage As New Page
            laPage.pageTitle = page.GetNom()
            laPage.pageURL = page.GetURL()
            laPage.pageVisitDateTime = page.GetVisitDateTime()
            Dim jsonpage As String = JsonConvert.SerializeObject(laPage)

            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
            Dim queryParameters As String = "?action=AddHistory&page=" + jsonpage + "&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

            If (resultat.Contains("err#")) Then
                Throw New AppSyncException(resultat.Substring(4))
            ElseIf (resultat = "false") Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de l'envoi d'une entrée d'historique vers AppSync.", ex)
            Return False
        End Try
    End Function

    Public Async Function AddFavorite(page As WebPage) As Task(Of Boolean)
        Try
            Dim laPage As New Page
            laPage.pageTitle = page.GetNom()
            laPage.pageURL = page.GetURL()
            Dim jsonpage As String = JsonConvert.SerializeObject(laPage)

            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
            Dim queryParameters As String = "?action=AddFavorite&page=" + jsonpage + "&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

            If (resultat.Contains("err#")) Then
                Throw New AppSyncException(resultat.Substring(4))
            ElseIf (resultat = "false") Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de l'envoi d'un favori vers AppSync.", ex)
            Return False
        End Try
    End Function

    Public Function AddSearchHistory(query As String) As Boolean
        Try
            Return True
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de la suppression d'un historique de recherche sur AppSync.", ex)
            Return False
        End Try
    End Function

    Public Async Function DeleteHistory(page As WebPage) As Task(Of Boolean)
        Try
            Dim laPage As New Page
            laPage.pageTitle = page.GetNom()
            laPage.pageURL = page.GetURL()
            laPage.pageVisitDateTime = page.GetVisitDateTime()
            Dim jsonpage As String = JsonConvert.SerializeObject(laPage)

            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
            Dim queryParameters As String = "?action=DeleteHistory&page=" + jsonpage + "&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

            If (resultat.Contains("err#")) Then
                Throw New AppSyncException(resultat.Substring(4))
            ElseIf (resultat = "false") Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de la suppression d'une entrée d'historique sur AppSync.", ex)
            Return False
        End Try
    End Function

    Public Async Function DeleteFavorite(page As WebPage) As Task(Of Boolean)
        Try
            Dim laPage As New Page
            laPage.pageTitle = page.GetNom()
            laPage.pageURL = page.GetURL()
            Dim jsonpage As String = JsonConvert.SerializeObject(laPage)

            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
            Dim queryParameters As String = "?action=DeleteFavorite&page=" + jsonpage + "&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

            If (resultat.Contains("err#")) Then
                Throw New AppSyncException(resultat.Substring(4))
            ElseIf (resultat = "false") Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de la suppression du favori sur AppSync.", ex)
            Return False
        End Try
    End Function


    ''' <summary>
    ''' Charge la dernière date et heure de synchronisation de la configuration.
    ''' </summary>
    ''' <returns></returns>
    Public Function LastConfigSyncTime() As Date
        Try
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
            Dim queryParameters As String = "?action=GetLastSyncTime&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = client.DownloadString(engineURL + queryParameters)

            If resultat.Contains("err#") Then
                Throw New AppSyncException(resultat.Substring(4))
            Else
                Return New Date(resultat.Substring(0, 4), resultat.Substring(5, 2), resultat.Substring(8, 2), resultat.Substring(11, 2), resultat.Substring(14, 2), resultat.Substring(17, 2))
            End If
        Catch ex As Exception
            Throw New AppSyncException("Impossible de récupérer la date de dernière synchronisation de votre compte AppSync.", ex)
            Return New Date(1, 1, 1)
        End Try
    End Function

    Public Async Function RefreshSyncTime() As Task(Of Boolean)
        Dim now As Date = Date.Now
        Try
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/browser/query.php"
            Dim queryParameters As String = "?action=RefreshSyncTime&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = Await client.DownloadStringTaskAsync(engineURL + queryParameters)

            If resultat.Contains("err#") Then
                Throw New AppSyncException(resultat.Substring(4))
            ElseIf resultat = "true" Then
                My.Settings.AppSyncLastSyncTime = now
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de l'actualisation de la date de dernière synchronisation.", ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Génère et retourne un jeton de connexion pour l'utilisateur connecté à SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Function GenerateToken() As String
        Try
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
            Dim queryParameters As String = "?action=GenerateToken&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = client.DownloadString(engineURL + queryParameters)

            If resultat.Contains("err#") Then
                Throw New AppSyncException(resultat.Substring(4))
            ElseIf resultat = "false" Then
                Return "False"
            Else
                Return resultat
            End If
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la génération du jeton de connexion.")
            BrowserForm.DisplayMessageBar()
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Synchronise les données de l'utilisateur avec la base de données de SmartNet AppSync.
    ''' </summary>
    ''' <returns>Vrai si réussite, Faux en cas d'échec.</returns>
    Public Async Function SyncNow() As Task(Of Boolean)
        Dim config As Boolean
        'Dim history As Boolean
        'Dim searchHistory As Boolean
        'Dim favorites As Boolean

        Dim theHistory As WebPageList = WebPageList.FromStringCollection(My.Settings.History)
        Dim theOnlineHistory As WebPageList = Await GetHistory()
        Dim theFavorites As WebPageList = WebPageList.FromStringCollection(My.Settings.Favorites)
        Dim theOnlineFavorites As WebPageList = Await GetFavorites()

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
            'My.Settings.History = theHistory.ToStringCollection()

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
            'My.Settings.Favorites = theFavorites.ToStringCollection()
        Else
            config = Await GetConfig()

            Dim theNewHistory As WebPageList = WebPageList.FromStringCollection(My.Settings.History)
            Dim theNewFavorites As WebPageList = WebPageList.FromStringCollection(My.Settings.Favorites)

            For Each p As WebPage In theHistory
                If theOnlineHistory.ContainsPage(p.GetURL(), p.GetNom(), p.GetVisitDateTime()) = False Then
                    theNewHistory.Remove(p)
                End If
            Next

            For Each p As WebPage In theFavorites
                If theOnlineFavorites.ContainsPage(p.GetURL(), p.GetNom()) = False Then
                    theNewFavorites.Remove(p)
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

            My.Settings.History = theNewHistory.ToStringCollection()
            My.Settings.Favorites = theNewFavorites.ToStringCollection()
        End If

        'Il manque l'historique de recherche

        Dim synctime As Boolean = Await RefreshSyncTime()
        Return (config And synctime)
    End Function

    ''' <summary>
    ''' Supprime l'appareil de la base de données SmartNet AppSync. Avertissement : ceci obligera l'utilisateur à se reconnecter.
    ''' </summary>
    ''' <returns></returns>
    Public Function UnregisterDevice() As Boolean
        Try
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/main/query.php"
            Dim queryParameters As String = "?action=UnregisterDevice&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

            resultat = client.DownloadString(engineURL + queryParameters)

            If resultat.Contains("err#") Then
                Throw New AppSyncException(resultat.Substring(4))
            ElseIf resultat = "false" Then
                Return False
            Else
                My.Settings.AppSyncDeviceNumber = ""
                Return True
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de la suppression de l'autorisation de connexion à AppSync.", ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Enregistre l'appareil pour l'autoriser à utiliser SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Function RegisterDevice(username As String, password As String) As Boolean
        If IsDeviceRegistered() Then
            UnregisterDevice()
        End If
        Try
            Dim client As New WebClient
            Dim resultat As String
            Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/main/query.php"
            Dim queryParameters As String = "?action=RegisterDevice&username=" + username + "&password=" + password + "&machineName=" + Environment.MachineName + "&appName=SmartNet Browser"

            resultat = client.DownloadString(engineURL + queryParameters)

            If resultat.Contains("err#") Then
                Throw New AppSyncException(resultat.Substring(4))
            ElseIf resultat = "false" Then
                Return False
            Else
                My.Settings.AppSyncDeviceNumber = resultat
                My.Settings.Save()
                Return True
            End If
        Catch ex As Exception
            Throw New AppSyncException("Une erreur est survenue lors de l'enregistrement de votre appareil sur votre compte AppSync.", ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Vérifie si l'appareil est enregistré auprès de SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Function IsDeviceRegistered() As Boolean
        If My.Settings.AppSyncDeviceNumber <> "" Then
            Try
                Dim client As New WebClient
                Dim resultat As String
                Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
                Dim queryParameters As String = "?action=IsDeviceRegistered&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

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
            Catch ex As Exception
                Throw New AppSyncException("Une erreur est survenue lors de la vérification de votre autorisation de connexion à AppSync.", ex)
                Return False
            End Try
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Récupère le nom de l'appareil depuis SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetDeviceName() As String
        If IsDeviceRegistered() Then
            Try
                Dim client As New WebClient
                Dim resultat As String
                Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
                Dim queryParameters As String = "?action=GetDeviceName&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString()

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

    Public Function SetDeviceName(newDeviceName As String) As Boolean
        If IsDeviceRegistered() Then
            Try
                Dim client As New WebClient
                Dim resultat As String
                Dim engineURL As String = "https://appsync.quentinpugeat.fr/engine/user/query.php"
                Dim queryParameters As String = "?action=SetDeviceName&connectionID=" + My.Settings.AppSyncDeviceNumber.ToString() + "NewName=" + newDeviceName

                resultat = client.DownloadString(engineURL + queryParameters)

                If resultat.Contains("err#") Then
                    Throw New AppSyncException(resultat.Substring(4))
                ElseIf resultat = "true" Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw New AppSyncException("Une erreur est survenue lors de l'envoi du nouveau nom de votre appareil à AppSync.", ex)
                Return False
            End Try
        Else
            Return False
        End If
    End Function
End Class
