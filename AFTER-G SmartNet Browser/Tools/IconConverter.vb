Imports System.IO

''' <summary>
''' Fonctions permettant la conversion d'icônes
''' </summary>
Module IconConverter
    Function ImageToBase64(original As Image) As String
        Using ms As New MemoryStream()
            original.Save(ms, Imaging.ImageFormat.Png)
            Dim obyte = ms.ToArray()
            Return Convert.ToBase64String(obyte)
        End Using
    End Function

    Function Base64ToImage(original As String) As Image
        Dim ba = Convert.FromBase64String(original)
        Dim ms As New MemoryStream(ba)
        Dim newimage = Image.FromStream(ms)
        Return newimage
    End Function
End Module
