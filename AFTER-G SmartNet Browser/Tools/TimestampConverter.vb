Module TimestampConverter
    Function DateTimeToUnixTimestamp(Original As DateTime) As Long
        Return CLng((Original - New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds)
    End Function

    Function UnixTimestampToDateTime(UnixTimestamp As Long) As DateTime
        Return (New DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(UnixTimestamp)
    End Function

    Function DateTimeToSQLDateTime(Original As DateTime) As String
        Return Original.Year & "-" & Original.Month.ToString().PadLeft(2, "0"c) & "-" & Original.Day.ToString().PadLeft(2, "0"c) & " " & Original.Hour.ToString().PadLeft(2, "0"c) & ":" & Original.Minute.ToString().PadLeft(2, "0"c) & ":" & Original.Second.ToString().PadLeft(2, "0"c)
    End Function
End Module
