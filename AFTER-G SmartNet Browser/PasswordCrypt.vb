Imports System.Security.Cryptography
Imports System.Text

Public Class PasswordCrypt
    Public Function GetSHA512(ByVal str As String) As String
        'desc   : Encrypt a strin using the SHA512 algorithm
        Dim UE As UnicodeEncoding = New UnicodeEncoding
        Dim HashValue As Byte()
        'convert the string to Byte
        Dim MessageBytes As Byte() = UE.GetBytes(str)
        Dim SHhash As SHA512Managed = New SHA512Managed
        Dim strHex As String = ""

        'create the hash table using the SHA512 algorithm
        HashValue = SHhash.ComputeHash(MessageBytes)
        'convert the hash table to a string
        For Each b As Byte In HashValue
            strHex += String.Format("{0:x2}", b)
        Next
        Return strHex
    End Function
End Class
