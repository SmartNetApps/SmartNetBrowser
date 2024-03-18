Imports Newtonsoft.Json

Public Class MajestiCloudSession
    Public SessionToken As String
    Public UserUUID As String = ""
    Public UserName As String = ""
    Public UserEmail As String = ""
    Public UserPicture As String = ""
    Public DeviceName As String = ""

    Public Sub New(NewToken As String)
        SessionToken = NewToken
        SaveAsFile()
    End Sub

    Public Shared Function FromFile() As MajestiCloudSession
        If IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\MajestiCloudSession.json") Then
            Return JsonConvert.DeserializeObject(Of MajestiCloudSession)(IO.File.ReadAllText(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\MajestiCloudSession.json"))
        Else
            Return Nothing
        End If
    End Function

    Public Sub SaveAsFile()
        IO.File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\MajestiCloudSession.json", JsonConvert.SerializeObject(Me))
    End Sub

    Public Function GetLastSynchronizationTime() As Integer
        If IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\" + UserUUID + ".int") Then
            Return CInt(IO.File.ReadAllText(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\" + UserUUID + ".int"))
        Else
            Return 0
        End If
    End Function

    Public Sub SetLastSynchronizationTime(newValue As Double)
        IO.File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\" + UserUUID + ".int", newValue.ToString())
    End Sub

    Public Function UserPictureAsImage() As Image
        Return Base64ToImage(UserPicture)
    End Function

    Public Sub Destroy()
        If IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\MajestiCloudSession.json") Then
            IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\MajestiCloudSession.json")
        End If
    End Sub
End Class
