Imports System.Text

Public Class HttpValueCollection
        Inherits List(Of HttpValue)
#Region "Constructors"

        ''' <summary>
        ''' Initializes a new instance of the <see cref="HttpValueCollection"/> class. 
        '''     Public constructor.
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="HttpValueCollection"/> class. 
        '''     Public constructor that accepts a query to parse into
        '''     a new HttpValueCollection and sets the URL encoded value to true.
        ''' </summary>
        ''' <param name="query">
        ''' The query to parse into a new HttpValueCollection.
        ''' </param>
        Public Sub New(query As String)
            Me.New(query, True)
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="HttpValueCollection"/> class. 
        '''     Public constructor that accepts a query to parse into
        '''     a new HttpValueCollection and sets the URL encoded
        '''     value to the given boolean value.
        ''' </summary>
        ''' <param name="query">
        ''' The query to parse into a new HttpValueCollection.
        ''' </param>
        ''' <param name="urlEncoded">
        ''' True if the HttpValueCollection is URL encoded.
        ''' </param>
        Public Sub New(query As String, urlEncoded As Boolean)
            If Not String.IsNullOrEmpty(query) Then
                Me.FillFromString(query, urlEncoded)
            End If
        End Sub

#End Region

#Region "Parameters"

#Region "Public Properties"

        ''' <summary>
        '''     Gets all of the keys in the collection.
        ''' </summary>
        Public ReadOnly Property AllKeys() As String()
            Get
                Return Me.[Select](Function(item) item.Key).ToArray()
            End Get
        End Property

#End Region

#Region "Public Indexers"

        ''' <summary>
        '''     Gets or sets the value at the given key.
        ''' </summary>
        ''' <param name="key">
        '''     The key.
        ''' </param>
        ''' <returns>
        '''     The value.
        ''' </returns>
        Default Public Property Item(key As String) As String
            Get
                Return Me.First(Function(x) String.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Value
            End Get

            Set
                Me.First(Function(x) String.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Value = Value
            End Set
        End Property

#End Region

#End Region

#Region "Public Methods and Operators"


    Public Overloads Sub Add(key As String, value As String)
        Me.Add(New HttpValue(key, value))
    End Sub

    ''' <summary>
    '''     Returns true if the collection contains an HttpValue with the given key.
    ''' </summary>
    ''' <param name="key">
    '''     The key to search for in the collection.
    ''' </param>
    ''' <returns>
    '''     True if the collection contains an HttpValue with the given key.
    ''' </returns>
    Public Function ContainsKey(key As String) As Boolean
            Return Me.Any(Function(x) String.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase))
        End Function

        ''' <summary>
        '''     Returns an array of values that correspond to the given key.
        ''' </summary>
        ''' <param name="key">
        '''     The key.
        ''' </param>
        ''' <returns>
        '''     An array of values that correspond go the given key.
        ''' </returns>
        Public Function GetValues(key As String) As String()
            Return Me.Where(Function(x) String.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).[Select](Function(x) x.Value).ToArray()
        End Function

    ''' <summary>
    '''     Removes from the collection all of the HttpValue objects with the given key.
    ''' </summary>
    ''' <param name="key">
    '''     The key.
    ''' </param>
    Public Overloads Sub Remove(key As String)
        Me.RemoveAll(Function(x) String.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase))
    End Sub

    ''' <summary>
    '''     Formats the collection with a URL encoded boolean value of true.
    ''' </summary>
    ''' <returns>
    '''     The formatted string.
    ''' </returns>
    Public Overrides Function ToString() As String
            Return Me.ToString(True)
        End Function

    ''' <summary>
    '''     Formats the collection with the given URL encoded boolean value and null
    '''     for any excluded keys.
    ''' </summary>
    ''' <param name="urlEncoded">
    '''     True if the collection is URL encoded.
    ''' </param>
    ''' <returns>
    '''     The formatted string.
    ''' </returns>
    Public Overloads Function ToString(urlEncoded As Boolean) As String
        Return Me.ToString(urlEncoded, Nothing)
    End Function

    ''' <summary>
    '''     Formats the collection into a string with the given URL encoded boolean value
    '''     and a dictionary of excluded keys.
    ''' </summary>
    ''' <param name="urlEncoded">
    '''     True if the collection is URL encoded.
    ''' </param>
    ''' <param name="excludeKeys">
    '''     Keys to be excluded.
    ''' </param>
    ''' <returns>
    '''     The formatted string.
    ''' </returns>
    Public Overloads Function ToString(urlEncoded As Boolean, excludeKeys As IDictionary) As String
        If Me.Count = 0 Then
            Return String.Empty
        End If

        Dim stringBuilder = New StringBuilder()

        For Each item As HttpValue In Me
            Dim key As String = item.Key

            If (excludeKeys Is Nothing) OrElse Not excludeKeys.Contains(key) Then
                Dim value As String = item.Value

                If urlEncoded Then
                    key = Uri.EscapeDataString(key)
                End If

                If stringBuilder.Length > 0 Then
                    stringBuilder.Append("&"c)
                End If

                stringBuilder.Append(If((key IsNot Nothing), (key & Convert.ToString("=")), String.Empty))

                If Not String.IsNullOrWhiteSpace(value) Then
                    If urlEncoded Then
                        value = Uri.EscapeDataString(value)
                    End If

                    stringBuilder.Append(value)
                End If
            End If
        Next

        Return stringBuilder.ToString()
    End Function

#End Region

#Region "Methods"

    ''' <summary>
    '''     Fills the collection with HttpValues from the given query.
    ''' </summary>
    ''' <param name="query">
    '''     The query to parse.
    ''' </param>
    ''' <param name="urlEncoded">
    '''     True if the collection is URL encoded.
    ''' </param>
    Private Sub FillFromString(query As String, urlEncoded As Boolean)
            Dim num As Integer = If((query IsNot Nothing), query.Length, 0)
            For i As Integer = 0 To num - 1
                Dim startIndex As Integer = i
                Dim num4 As Integer = -1
                While i < num
                    Dim ch As Char = query(i)
                    If ch = "="c Then
                        If num4 < 0 Then
                            num4 = i
                        End If
                    ElseIf ch = "&"c Then
                        Exit While
                    End If

                    i += 1
                End While

                Dim str As String = Nothing
                Dim str2 As String = Nothing
                If num4 >= 0 Then
                    str = query.Substring(startIndex, num4 - startIndex)
                    str2 = query.Substring(num4 + 1, (i - num4) - 1)
                Else
                    str2 = query.Substring(startIndex, i - startIndex)
                End If

                If urlEncoded Then
                    Me.Add(Uri.UnescapeDataString(str), Uri.UnescapeDataString(str2))
                Else
                    Me.Add(str, str2)
                End If

                If (i = (num - 1)) AndAlso (query(i) = "&"c) Then
                    Me.Add(Nothing, String.Empty)
                End If
            Next
        End Sub

#End Region
    End Class
