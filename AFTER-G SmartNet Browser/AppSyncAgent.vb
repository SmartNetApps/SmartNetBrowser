Imports System.Net
Imports System.Text
Imports MySql.Data.MySqlClient

''' <summary>
''' Agent de connexion de SmartNet AppSync
''' </summary>
Public Class AppSyncAgent

    ''' <summary>
    ''' Vérifie les identifiants enregistrés dans My.Settings
    ''' </summary>
    ''' <returns></returns>
    Public Function CheckCredentials() As Boolean
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim dataReader As MySqlDataReader
            Dim query As String = "SELECT motDePasseUtilisateur from utilisateur WHERE emailLoginUtilisateur = @username"
            Dim command As New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@username", My.Settings.AppSyncUsername)
            dataReader = command.ExecuteReader()
            dataReader.Read()
            Dim mdp As String = dataReader.GetString("motDePasseUtilisateur")
            connection.Close()
            Return mdp = My.Settings.AppSyncPassword
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la vérification de vos identifiants SmartNet AppSync.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Vérifie les identifiants entrés par l'utilisateur
    ''' </summary>
    ''' <param name="username">Nom d'utilisateur</param>
    ''' <param name="password">Mot de passe</param>
    ''' <returns>Vrai si les identifiants sont bons, Faux sinon</returns>
    Public Function CheckCredentials(username As String, password As String) As Boolean
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim dataReader As MySqlDataReader
            Dim query As String = "SELECT motDePasseUtilisateur from utilisateur WHERE emailLoginUtilisateur = @username"
            Dim command As New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@username", username)
            dataReader = command.ExecuteReader()
            dataReader.Read()
            Dim mdp As String = dataReader.GetString("motDePasseUtilisateur")
            connection.Close()
            Return BCrypt.Net.BCrypt.Verify(password, mdp)
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la vérification de vos identifiants SmartNet AppSync.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    Public Function GetUserPassword() As String
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim dataReader As MySqlDataReader
            Dim query As String = "SELECT motDePasseUtilisateur from utilisateur WHERE emailLoginUtilisateur = @username"
            Dim command As New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@username", My.Settings.AppSyncUsername)
            dataReader = command.ExecuteReader()
            dataReader.Read()
            Dim mdp = dataReader.GetString("motDePasseUtilisateur")
            connection.Close()
            Return mdp
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la vérification de vos identifiants SmartNet AppSync.")
            BrowserForm.DisplayMessageBar()
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Charge l'ID de l'utilisateur de SmartNet AppSync à partir de l'adresse e-mail
    ''' </summary>
    ''' <returns></returns>
    Public Function GetUserID() As Integer
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim dataReader As MySqlDataReader
            Dim query As String = "SELECT idUtilisateur from utilisateur WHERE emailLoginUtilisateur = @username"
            Dim command As New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@username", My.Settings.AppSyncUsername)
            dataReader = command.ExecuteReader()
            dataReader.Read()
            Dim userID As Integer = dataReader.GetInt32("idUtilisateur")
            connection.Close()
            Return userID
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la réception de votre ID utilisateur depuis AppSync.")
            BrowserForm.DisplayMessageBar()
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Charge le prénom et le nom de l'utilisateur tels qu'enregistrés sur SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetUserName() As String
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim dataReader As MySqlDataReader
            Dim query As String = "SELECT prenomUtilisateur, nomUtilisateur from utilisateur WHERE emailLoginUtilisateur = @username"
            Dim command As New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@username", My.Settings.AppSyncUsername)
            dataReader = command.ExecuteReader
            dataReader.Read()
            Dim userName As String = dataReader.GetString("prenomUtilisateur") + " " + dataReader.GetString("nomUtilisateur")
            connection.Close()
            Return userName
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la réception de votre identité depuis AppSync.")
            BrowserForm.DisplayMessageBar()
            Return "Compte AppSync"
        End Try
    End Function

    ''' <summary>
    ''' Charge l'image de profil de l'utilisateur depuis SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetUserProfilePicture() As Bitmap
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim dataReader As MySqlDataReader
            Dim query As String = "SELECT imageProfilClient from client WHERE idUtilisateur = @userid"
            Dim command As New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            Dim userid As Integer = GetUserID()
            command.Parameters.AddWithValue("@userid", userid.ToString())
            dataReader = command.ExecuteReader
            dataReader.Read()
            Dim imgPath As String = dataReader.GetString("imageProfilClient")
            imgPath = imgPath.Substring(1)
            Dim imgLocalPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData.ToString() + "\appsyncprofilepic" + imgPath.Substring(imgPath.LastIndexOf("."))
            Dim imgDistantPath = "http://appsync.smartnetapps.com" + imgPath
            Try
                If System.IO.File.Exists(imgLocalPath) Then
                    System.IO.File.Delete(imgLocalPath)
                End If
                Dim telechargeur As New WebClient()
                telechargeur.DownloadFile(imgDistantPath, imgLocalPath)
            Catch ex As Exception
            End Try
            connection.Close()
            Return New Bitmap(imgLocalPath)
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la réception de votre image de profil depuis AppSync.")
            BrowserForm.DisplayMessageBar()
            Return My.Resources.Person
        End Try
    End Function

    ''' <summary>
    ''' Charge la configuration distante et l'enregistre sur le profil local.
    ''' </summary>
    ''' <returns>Vrai si l'enregistrement se passe sans erreur.</returns>
    Public Function GetConfig() As Boolean
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim dataReader As MySqlDataReader
            Dim query As String = "SELECT * from browserconfig WHERE idUtilisateur = @userid"
            Dim command As New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@userid", GetUserID())
            dataReader = command.ExecuteReader
            If dataReader.Read() Then
                My.Settings.PrivateBrowsing = dataReader.GetBoolean("privateBrowsing")
                My.Settings.PreventMultipleTabsClose = dataReader.GetBoolean("preventMultipleTabsClose")
                My.Settings.SearchEngine = dataReader.GetInt32("searchEngine")
                My.Settings.CustomSearchURL = dataReader.GetString("customSearchURL")
                My.Settings.CustomSearchName = dataReader.GetString("customSearchName")
                My.Settings.AdBlocker = dataReader.GetBoolean("adBlocker")
                My.Settings.ChildrenProtection = dataReader.GetBoolean("childrenProtection")
                My.Settings.ChildrenProtectionPassword = dataReader.GetString("childrenProtectionPassword")
                My.Settings.BrowserSettingsSecurity = dataReader.GetBoolean("browserSettingsSecurity")
                My.Settings.BrowserSettingsSecurityPassword = dataReader.GetString("browserSettingsSecurityPassword")
                My.Settings.DeleteCookiesWhileClosing = dataReader.GetBoolean("deleteCookiesWhileClosing")
                My.Settings.PopUpBlocker = dataReader.GetBoolean("popUpBlocker")
                My.Settings.Homepage = dataReader.GetString("homepage")
                My.Settings.UserAgentLanguage = dataReader.GetString("userAgentLanguage")
                My.Settings.HistoryFavoritesSecurity = dataReader.GetBoolean("historyFavoritesSecurity")
                My.Settings.DoNotTrack = dataReader.GetBoolean("doNotTrack")
                My.Settings.AppSyncLastSyncTime = dataReader.GetDateTime("lastSyncDateTime")
            Else
                SendConfig()
            End If


            connection.Close()
            Return True
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la réception de votre configuration depuis AppSync. Elle a donc été renvoyée.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    Public Function SendConfig() As Boolean
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim dataReader As MySqlDataReader
            Dim query As String = "SELECT * from browserconfig WHERE idUtilisateur = @userid"
            Dim command As New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@userid", GetUserID())
            dataReader = command.ExecuteReader
            Dim exists As Boolean = dataReader.Read()
            connection.Close()
            If exists Then
                query = "UPDATE browserconfig SET privateBrowsing = @privateBrowsing, preventMultipleTabsClose = @preventMultipleTabsClose, searchEngine = @searchEngine, customSearchURL = @customSearchURL, customSearchName = @customSearchName, adBlocker = @adBlocker, childrenProtection = @childrenProtection, childrenProtectionPassword = @childrenProtectionPassword, browserSettingsSecurity = @browserSettingsSecurity, browserSettingsSecurityPassword = @browserSettingsSecurityPassword, deleteCookiesWhileClosing = @deleteCookiesWhileClosing, popUpBlocker = @popUpBlocker, homepage = @homepage, userAgentLanguage = @userAgentLanguage, historyFavoritesSecurity = @historyFavoritesSecurity, doNotTrack = @doNotTrack, lastSyncDateTime = @lastSyncDateTime WHERE idUtilisateur = @userid"
            Else
                query = "INSERT INTO browserconfig(privateBrowsing, preventMultipleTabsClose, searchEngine, customSearchURL, customSearchName, adBlocker, childrenProtection, childrenProtectionPassword, browserSettingsSecurity, browserSettingsSecurityPassword, deleteCookiesWhileClosing, popUpBlocker, homepage, userAgentLanguage, historyFavoritesSecurity, doNotTrack, lastSyncDateTime, idUtilisateur) VALUES(@privateBrowsing, @preventMultipleTabsClose, @searchEngine, @customSearchURL, @customSearchName, @adBlocker, @childrenProtection, @childrenProtectionPassword, @browserSettingsSecurity, @browserSettingsSecurityPassword, @deleteCookiesWhileClosing, @popUpBlocker, @homepage, @userAgentLanguage, @historyFavoritesSecurity, @doNotTrack, @lastSyncDateTime, @userid)"
            End If

            connection.Open()
            command = New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@userid", GetUserID())
            command.Parameters.AddWithValue("@privateBrowsing", My.Settings.PrivateBrowsing)
            command.Parameters.AddWithValue("@preventMultipleTabsClose", My.Settings.PreventMultipleTabsClose)
            command.Parameters.AddWithValue("@searchEngine", My.Settings.SearchEngine)
            command.Parameters.AddWithValue("@customSearchURL", My.Settings.CustomSearchURL)
            command.Parameters.AddWithValue("@customSearchName", My.Settings.CustomSearchName)
            command.Parameters.AddWithValue("@adBlocker", My.Settings.AdBlocker)
            command.Parameters.AddWithValue("@childrenProtection", My.Settings.ChildrenProtection)
            command.Parameters.AddWithValue("@childrenProtectionPassword", My.Settings.ChildrenProtectionPassword)
            command.Parameters.AddWithValue("@browserSettingsSecurity", My.Settings.BrowserSettingsSecurity)
            command.Parameters.AddWithValue("@browserSettingsSecurityPassword", My.Settings.BrowserSettingsSecurityPassword)
            command.Parameters.AddWithValue("@deleteCookiesWhileClosing", My.Settings.DeleteCookiesWhileClosing)
            command.Parameters.AddWithValue("@popUpBlocker", My.Settings.PopUpBlocker)
            command.Parameters.AddWithValue("@homepage", My.Settings.Homepage)
            command.Parameters.AddWithValue("@userAgentLanguage", My.Settings.UserAgentLanguage)
            command.Parameters.AddWithValue("@historyFavoritesSecurity", My.Settings.HistoryFavoritesSecurity)
            command.Parameters.AddWithValue("@doNotTrack", My.Settings.DoNotTrack)
            command.Parameters.AddWithValue("@lastSyncDateTime", My.Settings.AppSyncLastSyncTime)
            command.ExecuteNonQuery()
            connection.Close()
            Return True
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de l'envoi de votre configuration vers AppSync.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    Public Function GetHistory() As Boolean
        Try
            Return True
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la réception de l'historique de navigation depuis AppSync.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    Public Function GetFavorites() As Boolean
        Try
            Return True
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la réception des favoris depuis AppSync.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    Public Function GetSearchHistory() As Boolean
        Try
            Return True
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la réception de l'historique de recherche depuis AppSync.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    Public Function SendHistory() As Boolean
        Try
            Return True
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de l'envoi de l'historique de navigation vers AppSync.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    Public Function SendFavorites() As Boolean
        Try
            Return True
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de l'envoi des favoris vers AppSync.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    Public Function SendSearchHistory() As Boolean
        Try
            Return True
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de l'envoi de l'historique de recherche vers AppSync.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Charge la dernière date et heure de synchronisation des données.
    ''' </summary>
    ''' <returns></returns>
    Public Function LastSyncTime() As Date
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim dataReader As MySqlDataReader
            Dim query As String = "SELECT lastSyncDateTime from browserconfig WHERE idUtilisateur = @userid"
            Dim command As New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@userid", GetUserID())
            dataReader = command.ExecuteReader
            Dim result As Date
            If dataReader.Read() Then
                result = dataReader.GetDateTime("lastSyncDateTime")
            Else
                SendConfig()
                result = Date.Now
            End If
            connection.Close()
            Return result
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Impossible de retrouver la date de dernière synchronisation du compte AppSync.")
            BrowserForm.DisplayMessageBar()
            Return New Date(1, 1, 1)
        End Try
    End Function

    Public Function RefreshSyncTime() As Boolean
        Dim now As Date = Date.Now
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim query As String = "UPDATE browserconfig SET lastSyncDateTime = @now WHERE idUtilisateur = @idUser"
            Dim command As New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@now", now)
            command.Parameters.AddWithValue("@idUser", GetUserID())
            command.ExecuteNonQuery()
            connection.Close()

            connection.Open()
            query = "UPDATE connexion SET dateDeDerniereConnexion = @now WHERE idConnexion = @connectionId"
            command = New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@now", now)
            command.Parameters.AddWithValue("@connectionId", My.Settings.AppSyncDeviceNumber)
            command.ExecuteNonQuery()
            connection.Close()

            My.Settings.AppSyncLastSyncTime = now
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Génère et retourne un jeton de connexion pour l'utilisateur connecté à SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Function GenerateToken() As String
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim firstQuery As String = "DELETE FROM jetondeconnexion WHERE idUtilisateur = @userid"
            Dim firstCommand As New MySqlCommand()
            firstCommand.Connection = connection
            firstCommand.CommandText = firstQuery
            firstCommand.Prepare()
            firstCommand.Parameters.AddWithValue("@userid", GetUserID())
            firstCommand.ExecuteReader()
            connection.Close()

            Dim newToken As String
            Dim s As String = "0aAbBc1CdDeE2fFgGh3HiIjJ4kKlLm5MnNoO6pPqQr7RsStT8uUvVw9WxXyYzZ"
            Dim r As New Random
            Dim sb As New StringBuilder
            For i As Integer = 1 To 64
                Dim idx As Integer = r.Next(0, 35)
                sb.Append(s.Substring(idx, 1))
            Next
            newToken = sb.ToString()

            connection.Open()
            Dim secondQuery As String = "INSERT INTO jetondeconnexion(idUtilisateur, codeJeton) VALUES(@userid, @newToken)"
            Dim secondCommand As New MySqlCommand()
            secondCommand.Connection = connection
            secondCommand.CommandText = secondQuery
            secondCommand.Prepare()
            secondCommand.Parameters.AddWithValue("@userid", GetUserID())
            secondCommand.Parameters.AddWithValue("@newToken", newToken)
            secondCommand.ExecuteReader()
            connection.Close()
            Return newToken
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
    Public Function SyncNow() As Boolean
        Dim config As Boolean
        Dim history As Boolean
        Dim searchHistory As Boolean
        Dim favorites As Boolean

        If My.Settings.AppSyncLastSyncTime >= LastSyncTime() Then
            config = SendConfig()
            history = SendHistory()
            searchHistory = SendSearchHistory()
            favorites = SendFavorites()
        Else
            config = GetConfig()
            history = GetHistory()
            searchHistory = GetSearchHistory()
            favorites = GetFavorites()
        End If

        Dim synctime As Boolean = RefreshSyncTime()
        Return (config And history And searchHistory And favorites And synctime)
    End Function

    ''' <summary>
    ''' Supprime l'appareil de la base de données SmartNet AppSync. Avertissement : ceci obligera l'utilisateur à se reconnecter.
    ''' </summary>
    ''' <returns></returns>
    Public Function UnregisterDevice() As Boolean
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim query As String = "DELETE FROM connexion WHERE idConnexion = @idConnexion"
            Dim command As New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@idConnexion", My.Settings.AppSyncDeviceNumber)
            command.ExecuteReader()
            connection.Close()
            My.Settings.AppSyncDeviceNumber = 0
            Return True
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la désinscription de l'appareil.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Enregistre l'appareil pour l'autoriser à utiliser SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Function RegisterDevice() As Boolean
        If IsDeviceRegistered() Then
            UnregisterDevice()
        End If
        Try
            Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
            connection.Open()
            Dim query As String = "INSERT INTO connexion(nomConnexion, dateDeDerniereConnexion, applicationConnexion, idUtilisateur) VALUES(@nomConnexion, NOW(), @appliConnexion, @idUser)"
            Dim command As New MySqlCommand()
            command.Connection = connection
            command.CommandText = query
            command.Prepare()
            command.Parameters.AddWithValue("@nomConnexion", Environment.MachineName)
            command.Parameters.AddWithValue("@appliConnexion", "SmartNet Browser")
            command.Parameters.AddWithValue("@idUser", GetUserID())
            command.ExecuteNonQuery()
            My.Settings.AppSyncDeviceNumber = CType(command.LastInsertedId, Integer)
            connection.Close()
            Return True
        Catch ex As Exception
            BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de l'inscription de l'appareil à AppSync.")
            BrowserForm.DisplayMessageBar()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Vérifie si l'appareil est enregistré auprès de SmartNet AppSync.
    ''' </summary>
    ''' <returns></returns>
    Public Function IsDeviceRegistered() As Boolean
        If My.Settings.AppSyncDeviceNumber > 0 Then
            Try
                Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
                connection.Open()
                Dim dataReader As MySqlDataReader
                Dim query As String = "SELECT * from connexion WHERE idConnexion = @idConnexion"
                Dim command As New MySqlCommand()
                command.Connection = connection
                command.CommandText = query
                command.Prepare()
                command.Parameters.AddWithValue("@idConnexion", My.Settings.AppSyncDeviceNumber)
                dataReader = command.ExecuteReader()
                Dim result As Boolean
                If (dataReader.Read()) Then
                    result = (dataReader.GetInt32("idUtilisateur") = GetUserID())
                    If (result = False) Then
                        BrowserForm.msgBar = New MessageBar(MessageBar.MessageBarLevel.Critical, "AppSync : Le numéro de session enregistré n'est pas associé à l'utilisateur actuellement connecté.")
                        BrowserForm.DisplayMessageBar()
                    End If
                Else
                    result = False
                End If
                connection.Close()
                Return result
            Catch ex As Exception
                BrowserForm.msgBar = New MessageBar(ex, "Impossible de vérifier l'inscription de l'appareil à AppSync.")
                BrowserForm.DisplayMessageBar()
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
                Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
                connection.Open()
                Dim dataReader As MySqlDataReader
                Dim query As String = "SELECT nomConnexion from connexion WHERE idConnexion = @idConnexion"
                Dim command As New MySqlCommand()
                command.Connection = connection
                command.CommandText = query
                command.Prepare()
                command.Parameters.AddWithValue("@idConnexion", My.Settings.AppSyncDeviceNumber)
                dataReader = command.ExecuteReader()
                dataReader.Read()
                Dim deviceName As String = dataReader.GetString("nomConnexion")
                connection.Close()
                Return deviceName
            Catch ex As Exception
                BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de la requête du nom de l'appareil à AppSync.")
                BrowserForm.DisplayMessageBar()
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
    End Function

    Public Function SetDeviceName(newDeviceName As String) As Boolean
        If IsDeviceRegistered() Then
            Try
                Dim connection As New MySqlConnection(My.Settings.mysqlconnection)
                connection.Open()
                Dim query As String = "UPDATE connexion SET nomConnexion = @nouvNom WHERE idConnexion = @idConnexion"
                Dim command As New MySqlCommand()
                command.Connection = connection
                command.CommandText = query
                command.Prepare()
                command.Parameters.AddWithValue("@nouvNom", newDeviceName)
                command.Parameters.AddWithValue("@idConnexion", My.Settings.AppSyncDeviceNumber)
                command.ExecuteNonQuery()
                connection.Close()
                Return True
            Catch ex As Exception
                BrowserForm.msgBar = New MessageBar(ex, "Une erreur est survenue lors de l'envoi du nom de l'appareil à AppSync.")
                BrowserForm.DisplayMessageBar()
                Return False
            End Try
        Else
            Return False
        End If
    End Function
End Class
