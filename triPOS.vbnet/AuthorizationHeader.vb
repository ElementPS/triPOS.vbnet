Imports System.Collections.Specialized
Imports System.Net.Http.Headers
Imports System.Security.Authentication
Imports System.Security.Cryptography
Imports System.Text

Public Class AuthorizationHeader
#Region "Constants"

    Friend Const ValidUrlCharacters As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~"
    Friend Const ValidUrlCharactersRFC1738 As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_."

#End Region

#Region "Static Fields"

    Friend Shared RFCEncodingSchemes As New Dictionary(Of Integer, String)() From {
            {3986, ValidUrlCharacters},
            {1738, ValidUrlCharactersRFC1738}
        }

#End Region

#Region "Constructors and Destructors"

    Public Sub New(xauthorization As String)
        Dim authParts As String() = xauthorization.Split(","c)
        Dim authDictionary = New Dictionary(Of String, String)(StringComparer.InvariantCultureIgnoreCase)
        For Each authPart As String In authParts
            Dim keyValue As String() = authPart.Split("="c)
            authDictionary.Add(keyValue(0).Trim(), keyValue(1).Trim())
        Next

        If authDictionary.ContainsKey("version") Then
            Me.Version = authDictionary("version")
        End If

        If authDictionary.ContainsKey("algorithm") Then
            Me.Algorithm = authDictionary("algorithm")
        End If

        If authDictionary.ContainsKey("credential") Then
            Me.Credential = authDictionary("credential")
        End If

        If authDictionary.ContainsKey("signedheaders") Then
            Me.SignedHeaders = authDictionary("signedheaders")
        End If

        If authDictionary.ContainsKey("nonce") Then
            Me.Nonce = authDictionary("nonce")
        End If

        If authDictionary.ContainsKey("signature") Then
            Me.Signature = authDictionary("signature")
        End If

        If authDictionary.ContainsKey("requestdate") Then
            Me.RequestDate = authDictionary("requestdate")
        End If
    End Sub

    Public Sub New(version As String, algorithm As String, credential As String, signedHeaders As String, nonce As String, requestDate As String,
            signature As String)
        Me.Version = version
        Me.Algorithm = algorithm
        Me.Credential = credential
        Me.SignedHeaders = signedHeaders
        Me.Nonce = nonce
        Me.RequestDate = requestDate
        Me.Signature = signature
    End Sub

#End Region

#Region "Public Properties"

    Public Property Algorithm() As String
        Get
            Return m_Algorithm
        End Get
        Set
            m_Algorithm = Value
        End Set
    End Property
    Private m_Algorithm As String

    Public Property Credential() As String
        Get
            Return m_Credential
        End Get
        Set
            m_Credential = Value
        End Set
    End Property
    Private m_Credential As String

    Public Property Nonce() As String
        Get
            Return m_Nonce
        End Get
        Set
            m_Nonce = Value
        End Set
    End Property
    Private m_Nonce As String

    Public Property RequestDate() As String
        Get
            Return m_RequestDate
        End Get
        Set
            m_RequestDate = Value
        End Set
    End Property
    Private m_RequestDate As String

    Public Property Signature() As String
        Get
            Return m_Signature
        End Get
        Set
            m_Signature = Value
        End Set
    End Property
    Private m_Signature As String

    Public Property SignedHeaders() As String
        Get
            Return m_SignedHeaders
        End Get
        Set
            m_SignedHeaders = Value
        End Set
    End Property
    Private m_SignedHeaders As String

    Public Property Version() As String
        Get
            Return m_Version
        End Get
        Set
            m_Version = Value
        End Set
    End Property
    Private m_Version As String

#End Region

#Region "Public Methods and Operators"

    Public Shared Function Create(headers As HttpRequestHeaders, target As Uri, data As String, method As String, version As String, algorithm As String,
            nonce As String, requestDate As String, developerKey As String, developerSecret As String) As AuthorizationHeader
        ' Hash the request data
        Dim payloadHash As String = String.Empty

        If Not String.IsNullOrEmpty(data) Then
            payloadHash = HexEncodeHash(data, algorithm)
        End If

        Dim canonicalSignedHeaders As String = GetCanonicalSignedHeaders(headers)

        Dim canonicalHeaders As String = GetCanonicalHeaders(canonicalSignedHeaders, headers)

        Dim canonicalQueryString As String = GetCanonicalQueryString(target)

        Dim canonicalUri As String = GetCanonicalUri(target)

        Dim canonicalRequest As String = String.Format("{0}" & vbLf & "{1}" & vbLf & "{2}" & vbLf & "{3}" & vbLf & "{4}" & vbLf & "{5}", method, canonicalUri, canonicalQueryString, canonicalHeaders, canonicalSignedHeaders,
                payloadHash)

        Dim hashedCanonicalRequest As String = HexEncodeHash(canonicalRequest, algorithm)

        Dim keySignature As String = CreateHmacSignature(CreateUtf8(nonce & developerSecret), CreateUtf8(requestDate), algorithm)

        Dim stringToSign As String = String.Format("{0}" & vbLf & "{1}" & vbLf & "{2}" & vbLf & "{3}", algorithm, requestDate, developerKey, hashedCanonicalRequest)

        Dim finalSignature As String = CreateHmacSignature(CreateUtf8(stringToSign), CreateUtf8(keySignature), algorithm)

        Return New AuthorizationHeader(version, algorithm, developerKey, canonicalSignedHeaders, nonce, requestDate,
                finalSignature)
    End Function

    Public Overrides Function ToString() As String
        Dim output As String = String.Format("Version={0}, Algorithm={1}, Credential={2}, SignedHeaders={3}, Nonce={4}, RequestDate={5}, Signature={6}", Me.Version, Me.Algorithm, Me.Credential, Me.SignedHeaders, Me.Nonce,
                Me.RequestDate, Me.Signature)
        Return output
    End Function

#End Region

#Region "Methods"

    Private Shared Function CreateHmacSignature(data As String, key As String, algorithm As String) As String
        Dim hasher As KeyedHashAlgorithm = Nothing
        algorithm = algorithm.ToLower()
        Select Case algorithm
            Case "tp-hmac-md5"
                hasher = KeyedHashAlgorithm.Create("HMACMD5")
                Exit Select
            Case "tp-hmac-sha1"
                hasher = KeyedHashAlgorithm.Create("HMACSHA1")
                Exit Select
            Case "tp-hmac-sha256"
                hasher = KeyedHashAlgorithm.Create("HMACSHA256")
                Exit Select
            Case "tp-hmac-sha384"
                hasher = KeyedHashAlgorithm.Create("HMACSHA384")
                Exit Select
            Case "tp-hmac-sha512"
                hasher = KeyedHashAlgorithm.Create("HMACSHA512")
                Exit Select
            Case Else
                Throw New AuthenticationException(Convert.ToString("Invalid signature algorithm: ") & algorithm)
        End Select

        hasher.Key = Encoding.UTF8.GetBytes(key)

        Dim output As Byte() = hasher.ComputeHash(Encoding.UTF8.GetBytes(data))

        Return ToHex(output, True)
    End Function

    Private Shared Function CreateUtf8(input As String) As String
        Dim utf8Bytes As Byte() = Encoding.UTF8.GetBytes(input)

        ' Convert utf-8 bytes to a string.
        Dim output As String = Encoding.UTF8.GetString(utf8Bytes)

        Return output
    End Function

    Private Shared Function GetCanonicalHeaders(canonicalSignedHeaders As String, headers As HttpRequestHeaders) As String
        Dim sbHeader = New StringBuilder()
        Dim headersToSort = New Dictionary(Of String, String)(StringComparer.InvariantCultureIgnoreCase)
        For Each httpRequestHeader As KeyValuePair(Of String, IEnumerable(Of String)) In headers
            Dim key As String = httpRequestHeader.Key.ToLower().Trim()
            If Not key.StartsWith("tp-") Then
                For Each value As String In httpRequestHeader.Value
                    Dim newValue As String = value.Replace(Environment.NewLine, " ")

                    If headersToSort.ContainsKey(key) Then
                        ' headers put a space in duplicate key values
                        headersToSort(key) = Convert.ToString(headersToSort(key) + ", ") & newValue
                    Else
                        headersToSort.Add(key, newValue)
                    End If
                Next
            End If
        Next

        Dim signedHeaderList As String() = canonicalSignedHeaders.Split(";"c)
        For Each signedHeader As String In signedHeaderList
            If headersToSort.ContainsKey(signedHeader) Then
                sbHeader.Append(String.Format("{0}:{1}" & vbLf, signedHeader, headersToSort(signedHeader)))
            End If
        Next

        Dim output As String = sbHeader.ToString()
        If output.EndsWith(vbLf) Then
            output = output.Substring(0, output.Length - 1)
        End If

        Return output
    End Function

    Private Shared Function GetCanonicalQueryString(target As Uri) As String
        Dim result As String = String.Empty

        If Not String.IsNullOrWhiteSpace(target.Query) Then
            Dim nvc As HttpValueCollection = HttpUtility.ParseQueryString(target.Query)
            If nvc.Count > 0 Then
                Dim orderedKeyValue As IOrderedEnumerable(Of HttpValue) = nvc.OrderBy(Function(c) c.Key)
                Dim data = New StringBuilder(512)
                For Each keyValue As HttpValue In orderedKeyValue
                    If keyValue.Value IsNot Nothing Then
                        data.Append(keyValue.Key)
                        data.Append("="c)
                        data.Append(UrlEncode(keyValue.Value, False))
                        data.Append("&"c)
                    End If
                Next

                result = data.ToString()
                If result.Length > 0 Then
                    result = result.Remove(result.Length - 1)
                End If
            End If
        End If

        Return result
    End Function

    Private Shared Function GetCanonicalSignedHeaders(headers As HttpRequestHeaders) As String
        Dim sbHeader = New StringBuilder()
        Dim headersToSort = New List(Of String)()

        ' For all of the request headers, if the key does not start with tp- then
        ' add the request header to the list of headers that will be sorted
        For Each httpRequestHeader As KeyValuePair(Of String, IEnumerable(Of String)) In headers
            Dim key As String = httpRequestHeader.Key.ToLower().Trim()
            If Not key.StartsWith("tp-") Then
                If Not headersToSort.Contains(key) Then
                    headersToSort.Add(key)
                End If
            End If
        Next

        ' Sort the headers and create a string of semicolon separated headers, the last
        ' header value shall not end with a semicolon
        headersToSort.Sort()
        For Each sortedHeader As String In headersToSort
            If sbHeader.Length > 0 Then
                sbHeader.Append(String.Format(";{0}", sortedHeader))
            Else
                sbHeader.Append(String.Format("{0}", sortedHeader))
            End If
        Next

        Dim result As String = sbHeader.ToString()

        Return result
    End Function

    Private Shared Function GetCanonicalUri(target As Uri) As String
        Dim result = New StringBuilder()
        Dim url As String = target.AbsolutePath
        Dim bucket As String = url.Substring(url.IndexOf("/api/", StringComparison.OrdinalIgnoreCase))
        If Not String.IsNullOrWhiteSpace(bucket) Then
            If Not bucket.StartsWith("/") Then
                bucket = String.Format("/{0}", bucket)
            End If

            If bucket.EndsWith("/") Then
                bucket = bucket.TrimEnd("/"c)
            End If

            result.Append(bucket)
        End If

        Return result.ToString()
    End Function

    Private Shared Function HexEncodeHash(data As String, algorithm As String) As String
        Dim hashAlgorithm__1 As HashAlgorithm = Nothing

        algorithm = algorithm.ToLower()
        Select Case algorithm
            Case "tp-hmac-md5"
                hashAlgorithm__1 = HashAlgorithm.Create("MD5")
                Exit Select
            Case "tp-hmac-sha1"
                hashAlgorithm__1 = HashAlgorithm.Create("SHA1")
                Exit Select
            Case "tp-hmac-sha256"
                hashAlgorithm__1 = HashAlgorithm.Create("SHA256")
                Exit Select
            Case "tp-hmac-sha384"
                hashAlgorithm__1 = HashAlgorithm.Create("SHA384")
                Exit Select
            Case "tp-hmac-sha512"
                hashAlgorithm__1 = HashAlgorithm.Create("SHA512")
                Exit Select
            Case Else
                Throw New AuthenticationException(Convert.ToString("Invalid signature algorithm: ") & algorithm)
        End Select

        Return ToHex(hashAlgorithm__1.ComputeHash(Encoding.UTF8.GetBytes(data)), True)
    End Function

    Private Shared Function ToHex(data As Byte(), lowercase As Boolean) As String
        Dim sb = New StringBuilder()

        For i As Integer = 0 To data.Length - 1
            sb.Append(data(i).ToString(If(lowercase, "x2", "X2")))
        Next

        Return sb.ToString()
    End Function

    Private Shared Function UrlEncode(data As String, path As Boolean) As String
        Return UrlEncode(3986, data, path)
    End Function

    Private Shared Function UrlEncode(rfcNumber As Integer, data As String, path As Boolean) As String
        Dim encoded = New StringBuilder(data.Length * 2)
        Dim validUrlCharacters__1 As String = ""
        If Not RFCEncodingSchemes.TryGetValue(rfcNumber, validUrlCharacters__1) Then
            validUrlCharacters__1 = ValidUrlCharacters
        End If

        Dim unreservedChars As String = String.Concat(validUrlCharacters__1, If(path, "/:", String.Empty))

        For Each symbol As Char In data
            If unreservedChars.IndexOf(symbol) <> -1 Then
                encoded.Append(symbol)
            Else
                encoded.Append("%").Append(String.Format("{0:X2}", Convert.ToInt32(symbol)))
            End If
        Next

        Return encoded.ToString()
    End Function

#End Region
End Class
