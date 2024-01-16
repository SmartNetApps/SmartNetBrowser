Module TimestampConverter
    Function DateTimeToUnixTimestamp(Original As DateTime) As Double
        Return (Original - New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds
    End Function

    Function UnixTimestampToDateTime(UnixTimestamp As Double) As DateTime
        Return (New DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(UnixTimestamp)
    End Function
End Module
