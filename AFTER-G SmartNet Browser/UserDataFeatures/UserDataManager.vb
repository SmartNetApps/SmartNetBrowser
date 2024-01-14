Imports System.Data.SQLite
Imports Microsoft.VisualBasic.FileIO

''' <summary>
''' Classe permettant la connexion à la base SQLite locale et la gestion des données de l'utilisateur
''' </summary>
Public Class UserDataManager
    Private ReadOnly dbPath As String
    Private ReadOnly db As SQLiteConnection

    Public Sub New()
        dbPath = SpecialDirectories.CurrentUserApplicationData & "\userdata.db"
        Console.WriteLine("Database path: " & dbPath)
        db = New SQLiteConnection("Data Source=" & dbPath)

        If Not My.Computer.FileSystem.FileExists(dbPath) Then
            CreateDatabase()
        Else
            OpenConnection()
        End If
    End Sub

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

            Dim legacyHistory = WebPageList.FromStringCollection(My.Settings.History).GetEnumerator()
            While legacyHistory.MoveNext()
                Dim page = legacyHistory.Current
                Dim visitDate = (page.GetVisitDateTime().ToUniversalTime() - New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds

                command.CommandText = "INSERT OR IGNORE INTO history(created_on, title, url) VALUES(@createdon, @title, @url)"
                command.Parameters.Clear()
                command.Parameters.Add(New SQLiteParameter("@createdon", visitDate))
                command.Parameters.Add(New SQLiteParameter("@title", page.GetNom()))
                command.Parameters.Add(New SQLiteParameter("@url", page.GetURL()))
                command.ExecuteNonQuery()
            End While

            Dim legacyBookmarks = WebPageList.FromStringCollection(My.Settings.Favorites).GetEnumerator()
            While legacyBookmarks.MoveNext()
                Dim page = legacyBookmarks.Current
                Dim visitDate = (page.GetVisitDateTime().ToUniversalTime() - New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds

                command.CommandText = "INSERT OR IGNORE INTO bookmark(created_on, title, url) VALUES(@createdon, @title, @url)"
                command.Parameters.Clear()
                command.Parameters.Add(New SQLiteParameter("@createdon", visitDate))
                command.Parameters.Add(New SQLiteParameter("@title", page.GetNom()))
                command.Parameters.Add(New SQLiteParameter("@url", page.GetURL()))
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
End Class
