Imports System.Data.SQLite
Imports System.Security.Policy
Imports Microsoft.VisualBasic.FileIO

''' <summary>
''' Classe permettant la connexion à la base SQLite locale et la gestion des données de l'utilisateur
''' </summary>
Public Class UserDataManager
    Private Shared Instance As UserDataManager

    Private ReadOnly dbPath As String
    Private ReadOnly db As SQLiteConnection

    Private Sub New()
        dbPath = SpecialDirectories.CurrentUserApplicationData & "\userdata.db"
        Console.WriteLine("Database path: " & dbPath)
        db = New SQLiteConnection("Data Source=" & dbPath)

        If Not My.Computer.FileSystem.FileExists(dbPath) Then
            CreateDatabase()
        Else
            OpenConnection()
        End If
    End Sub

    Public Shared Function GetInstance() As UserDataManager
        If (Instance Is Nothing) Then
            Instance = New UserDataManager()
        End If
        Return Instance

    End Function

    Private Sub OpenConnection()
        Try
            db.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur pendant l'instanciation de la base de données locale", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
            End
        End Try
    End Sub

    ''' <summary>
    ''' Crée la base de données et instancie toutes les tables requises
    ''' </summary>
    Private Sub CreateDatabase()
        OpenConnection()

        Try
            Dim command As New SQLiteCommand With {
                .Connection = db,
                .CommandText = "CREATE TABLE IF NOT EXISTS history(created_on INT PRIMARY KEY, title TEXT NOT NULL, url TEXT NOT NULL, icon TEXT NULL, deleted_on INT NULL)"
            }
            command.ExecuteNonQuery()

            command.CommandText = "CREATE TABLE IF NOT EXISTS bookmark(created_on INT PRIMARY KEY, title TEXT NOT NULL, url TEXT NOT NULL, icon TEXT NULL, updated_on INT NULL, deleted_on INT NULL)"
            command.ExecuteNonQuery()

            command.CommandText = "CREATE TABLE IF NOT EXISTS download(created_on INT PRIMARY KEY, title TEXT NULL, url TEXT NOT NULL, deleted_on INT NULL)"
            command.ExecuteNonQuery()

            command.CommandText = "CREATE TABLE IF NOT EXISTS searchquery(created_on INT PRIMARY KEY, query TEXT NOT NULL, deleted_on INT NULL)"
            command.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur pendant la création de la base de données locale", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
            End
        End Try

        MigrateFromLegacyFormat()
    End Sub

    ''' <summary>
    ''' Déclenche la migration des données à partir du format précédent (My.Settings.*)
    ''' </summary>
    Private Sub MigrateFromLegacyFormat()
#Disable Warning BC40000
        Try
            Dim command As New SQLiteCommand With {
                .Connection = db
            }

            Dim legacyHistory = LegacyWebPageList.FromStringCollection(My.Settings.History).GetEnumerator()
            While legacyHistory.MoveNext()
                Dim page = legacyHistory.Current
                Dim visitDate = (page.GetVisitDateTime().ToUniversalTime() - New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds

                command.CommandText = "INSERT OR IGNORE INTO history(created_on, title, url, icon) VALUES(@createdon, @title, @url, @icon)"
                command.Parameters.Clear()
                command.Parameters.Add(New SQLiteParameter("@createdon", visitDate))
                command.Parameters.Add(New SQLiteParameter("@title", page.GetNom()))
                command.Parameters.Add(New SQLiteParameter("@url", page.GetURL()))
                command.Parameters.Add(New SQLiteParameter("@icon", IconConverter.ImageToBase64(page.GetFavicon())))
                command.ExecuteNonQuery()
            End While

            Dim legacyBookmarks = LegacyWebPageList.FromStringCollection(My.Settings.Favorites).GetEnumerator()
            While legacyBookmarks.MoveNext()
                Dim page = legacyBookmarks.Current
                Dim visitDate = (page.GetVisitDateTime().ToUniversalTime() - New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds

                command.CommandText = "INSERT OR IGNORE INTO bookmark(created_on, title, url, icon) VALUES(@createdon, @title, @url, @icon)"
                command.Parameters.Clear()
                command.Parameters.Add(New SQLiteParameter("@createdon", visitDate))
                command.Parameters.Add(New SQLiteParameter("@title", page.GetNom()))
                command.Parameters.Add(New SQLiteParameter("@url", page.GetURL()))
                command.Parameters.Add(New SQLiteParameter("@icon", IconConverter.ImageToBase64(page.GetFavicon())))
                command.ExecuteNonQuery()
            End While

            Dim legacyDownloads = My.Settings.DownloadHistory.GetEnumerator()
            While legacyDownloads.MoveNext()
                Dim link = legacyDownloads.Current
                Dim visitDate = (DateTime.Now().ToUniversalTime() - New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds

                command.CommandText = "INSERT OR IGNORE INTO download(created_on, url) VALUES(@createdon, @url)"
                command.Parameters.Clear()
                command.Parameters.Add(New SQLiteParameter("@createdon", visitDate))
                command.Parameters.Add(New SQLiteParameter("@url", link))
                command.ExecuteNonQuery()
            End While

            Dim legacySearchHistory = My.Settings.SearchHistory.GetEnumerator()
            While legacySearchHistory.MoveNext()
                Dim query = legacySearchHistory.Current
                Dim visitDate = (DateTime.Now().ToUniversalTime() - New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds

                command.CommandText = "INSERT OR IGNORE INTO searchquery(created_on, query) VALUES(@createdon, @query)"
                command.Parameters.Clear()
                command.Parameters.Add(New SQLiteParameter("@createdon", visitDate))
                command.Parameters.Add(New SQLiteParameter("@query", query))
                command.ExecuteNonQuery()
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur pendant la migration de la base de données locale", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
            End
        End Try
#Enable Warning BC40000
    End Sub

    Public Function GetHistory(Optional WithDeletedItems As Boolean = False) As List(Of WebPage)
        Dim command As New SQLiteCommand With {
            .Connection = db,
            .CommandText = "SELECT title, url, icon, created_on, deleted_on FROM history" & If(Not WithDeletedItems, " WHERE deleted_on IS NULL", "") & " ORDER BY created_on DESC"
        }
        Dim reader = command.ExecuteReader()
        Dim history As New List(Of WebPage)

        While reader.Read()
            history.Add(
                New WebPage(
                    reader.GetString(0),
                    reader.GetString(1),
                    IconConverter.Base64ToImage(reader.GetString(2)),
                    reader.GetDouble(3),
                    If(Not reader.IsDBNull(4), reader.GetDouble(4), Nothing)
                )
            )
        End While

        Return history
    End Function

    Public Function GetBookmarks(Optional WithDeletedItems As Boolean = False) As List(Of WebPage)
        Dim command As New SQLiteCommand With {
            .Connection = db,
            .CommandText = "SELECT title, url, icon, created_on, deleted_on FROM bookmark" & If(Not WithDeletedItems, " WHERE deleted_on IS NULL", "") & " ORDER BY created_on DESC"
        }
        Dim reader = command.ExecuteReader()
        Dim bookmarks As New List(Of WebPage)

        While reader.Read()
            bookmarks.Add(
                New WebPage(
                    reader.GetString(0),
                    reader.GetString(1),
                    IconConverter.Base64ToImage(reader.GetString(2)),
                    reader.GetDouble(3),
                    If(Not reader.IsDBNull(4), reader.GetDouble(4), Nothing)
                )
            )
        End While

        Return bookmarks
    End Function

    Public Function GetSearchHistory(Optional WithDeletedItems As Boolean = False) As List(Of SearchHistoryItem)
        Dim command As New SQLiteCommand With {
            .Connection = db,
            .CommandText = "SELECT query, created_on, deleted_on FROM searchquery" & If(Not WithDeletedItems, " WHERE deleted_on IS NULL", "") & " ORDER BY created_on DESC"
        }
        Dim reader = command.ExecuteReader()
        Dim searchHistory As New List(Of SearchHistoryItem)

        While reader.Read()
            searchHistory.Add(
                New SearchHistoryItem(
                    reader.GetString(0),
                    reader.GetDouble(1),
                    If(Not reader.IsDBNull(2), reader.GetDouble(2), Nothing)
                )
            )
        End While

        Return searchHistory
    End Function

    Public Function GetDownloadHistory(Optional WithDeletedItems As Boolean = False) As List(Of DownloadedItem)
        Dim command As New SQLiteCommand With {
            .Connection = db,
            .CommandText = "SELECT url, title, created_on, deleted_on FROM download" & If(Not WithDeletedItems, " WHERE deleted_on IS NULL", "") & " ORDER BY created_on DESC"
        }
        Dim reader = command.ExecuteReader()
        Dim downloadHistory As New List(Of DownloadedItem)

        While reader.Read()
            downloadHistory.Add(
                New DownloadedItem(
                    reader.GetString(0),
                    If(Not reader.IsDBNull(1), reader.GetString(1), Nothing),
                    reader.GetDouble(2),
                    If(Not reader.IsDBNull(3), reader.GetDouble(3), Nothing)
                )
            )
        End While

        Return downloadHistory
    End Function

    Public Sub AddInHistory(ParamArray Pages() As WebPage)
        For Each Page In Pages
            Dim Command As New SQLiteCommand With {
                .Connection = db,
                .CommandText = "INSERT INTO history(created_on, title, url, icon, deleted_on) VALUES(@created_on, @title, @url, @icon, @deleted_on)"
            }

            Command.Parameters.Add(New SQLiteParameter("@created_on", Page.GetRawCreationDate()))
            Command.Parameters.Add(New SQLiteParameter("@title", Page.Title))
            Command.Parameters.Add(New SQLiteParameter("@url", Page.URI.AbsoluteUri))
            Command.Parameters.Add(New SQLiteParameter("@icon", IconConverter.ImageToBase64(Page.Icon)))
            If Page.GetRawDeletionDate() Is Nothing Then
                Command.Parameters.Add(New SQLiteParameter("@deleted_on", DBNull.Value))
            Else
                Command.Parameters.Add(New SQLiteParameter("@deleted_on", Page.GetRawDeletionDate()))
            End If

            Command.ExecuteNonQuery()
        Next
    End Sub

    Public Sub AddInBookmarks(ParamArray Pages() As WebPage)
        For Each Page In Pages
            Dim Command As New SQLiteCommand With {
                .Connection = db,
                .CommandText = "INSERT INTO bookmark(created_on, title, url, icon, deleted_on) VALUES(@created_on, @title, @url, @icon, @deleted_on)"
            }

            Command.Parameters.Add(New SQLiteParameter("@created_on", Page.GetRawCreationDate()))
            Command.Parameters.Add(New SQLiteParameter("@title", Page.Title))
            Command.Parameters.Add(New SQLiteParameter("@url", Page.URI.AbsoluteUri))
            Command.Parameters.Add(New SQLiteParameter("@icon", IconConverter.ImageToBase64(Page.Icon)))
            If Page.GetRawDeletionDate() Is Nothing Then
                Command.Parameters.Add(New SQLiteParameter("@deleted_on", DBNull.Value))
            Else
                Command.Parameters.Add(New SQLiteParameter("@deleted_on", Page.GetRawDeletionDate()))
            End If

            Command.ExecuteNonQuery()
        Next
    End Sub

    Public Sub AddInSearchHistory(ParamArray Items() As SearchHistoryItem)
        For Each Item In Items
            Dim Command As New SQLiteCommand With {
                .Connection = db,
                .CommandText = "INSERT INTO searchquery(created_on, query, deleted_on) VALUES(@created_on, @query, @deleted_on)"
            }

            Command.Parameters.Add(New SQLiteParameter("@created_on", Item.GetRawCreationDate()))
            Command.Parameters.Add(New SQLiteParameter("@query", Item.Query))
            If Item.GetRawDeletionDate() Is Nothing Then
                Command.Parameters.Add(New SQLiteParameter("@deleted_on", DBNull.Value))
            Else
                Command.Parameters.Add(New SQLiteParameter("@deleted_on", Item.GetRawDeletionDate()))
            End If

            Command.ExecuteNonQuery()
        Next
    End Sub

    Public Sub AddInDownloadHistory(ParamArray Items() As DownloadedItem)
        For Each Item In Items
            Dim Command As New SQLiteCommand With {
                .Connection = db,
                .CommandText = "INSERT INTO download(created_on, title, url, deleted_on) VALUES(@created_on, @title, @url, @deleted_on)"
            }

            Command.Parameters.Add(New SQLiteParameter("@created_on", Item.GetRawCreationDate()))
            Command.Parameters.Add(New SQLiteParameter("@title", Item.Title))
            Command.Parameters.Add(New SQLiteParameter("@url", Item.URI.AbsoluteUri))
            If Item.GetRawDeletionDate() Is Nothing Then
                Command.Parameters.Add(New SQLiteParameter("@deleted_on", DBNull.Value))
            Else
                Command.Parameters.Add(New SQLiteParameter("@deleted_on", Item.GetRawDeletionDate()))
            End If

            Command.ExecuteNonQuery()
        Next
    End Sub

    Public Function SearchInBookmarks(url As String) As List(Of WebPage)
        Dim command As New SQLiteCommand With {
            .Connection = db,
            .CommandText = "SELECT title, url, icon, created_on, deleted_on FROM bookmark WHERE url LIKE @url ORDER BY created_on DESC"
        }

        command.Parameters.Add(New SQLiteParameter("@url", "%" & url & "%"))

        Dim reader = command.ExecuteReader()
        Dim bookmarks As New List(Of WebPage)

        While reader.Read()
            bookmarks.Add(New WebPage(
                reader.GetString(0),
                reader.GetString(1),
                IconConverter.Base64ToImage(reader.GetString(2)),
                reader.GetDouble(3),
                If(Not reader.IsDBNull(4), reader.GetDouble(4), Nothing)
            ))
        End While

        Return bookmarks
    End Function

    Public Sub DeleteFromHistory(CreationDate As Double)
        Dim command As New SQLiteCommand With {
            .Connection = db,
            .CommandText = "UPDATE history SET deleted_on = @deleted_on WHERE created_on = @created_on"
        }
        command.Parameters.Add(New SQLiteParameter("@deleted_on", TimestampConverter.DateTimeToUnixTimestamp(DateTime.Now)))
        command.Parameters.Add(New SQLiteParameter("@created_on", CreationDate))
        command.ExecuteNonQuery()
    End Sub

    Public Sub DeleteFromBookmarks(CreationDate As Double, Optional Url As String = Nothing)
        Dim command As New SQLiteCommand With {
            .Connection = db
        }

        If Url IsNot Nothing Then
            command.CommandText = "UPDATE bookmark SET deleted_on = @deleted_on WHERE url = @url"
            command.Parameters.Add(New SQLiteParameter("@url", Url))
        Else
            command.CommandText = "UPDATE bookmark SET deleted_on = @deleted_on WHERE created_on = @created_on"
            command.Parameters.Add(New SQLiteParameter("@created_on", CreationDate))
        End If

        command.Parameters.Add(New SQLiteParameter("@deleted_on", TimestampConverter.DateTimeToUnixTimestamp(DateTime.Now)))
        command.ExecuteNonQuery()
    End Sub

    Public Sub DeleteFromSearchHistory(CreationDate As Double)
        Dim command As New SQLiteCommand With {
            .Connection = db,
            .CommandText = "UPDATE searchquery SET deleted_on = @deleted_on WHERE created_on = @created_on"
        }
        command.Parameters.Add(New SQLiteParameter("@deleted_on", TimestampConverter.DateTimeToUnixTimestamp(DateTime.Now)))
        command.Parameters.Add(New SQLiteParameter("@created_on", CreationDate))
        command.ExecuteNonQuery()
    End Sub

    Public Sub DeleteFromDownloadHistory(CreationDate As Double)
        Dim command As New SQLiteCommand With {
            .Connection = db,
            .CommandText = "UPDATE download SET deleted_on = @deleted_on WHERE created_on = @created_on"
        }
        command.Parameters.Add(New SQLiteParameter("@deleted_on", TimestampConverter.DateTimeToUnixTimestamp(DateTime.Now)))
        command.Parameters.Add(New SQLiteParameter("@created_on", CreationDate))
        command.ExecuteNonQuery()
    End Sub
End Class
