
Public NotInheritable Class HttpUtility
    Public Shared Function ParseQueryString(query As String) As HttpValueCollection
        If query Is Nothing Then
            Throw New ArgumentNullException("query")
        End If

        If (query.Length > 0) AndAlso (query(0) = "?"c) Then
            query = query.Substring(1)
        End If

        Return New HttpValueCollection(query, True)
    End Function
End Class
