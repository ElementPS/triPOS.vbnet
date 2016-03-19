Imports System.Xml
Imports System.Net.Http

Public Class triPOSWebRequest

    Public Property Headers() As String
        Get
            Return m_Headers
        End Get
        Set
            m_Headers = Value
        End Set
    End Property
    Private m_Headers As String

    Public Function DotriPOSRequest(json As String, url As String, developerKey As String, developerSecret As String, contentType As String) As HttpResponseMessage

        Dim respMessage As HttpResponseMessage = Nothing
        Using httpClient = New HttpClient()
            Dim message = New HttpRequestMessage(HttpMethod.Post, New Uri(url))
            Dim authorizationHeader As AuthorizationHeader = AuthorizationHeader.Create(message.Headers, message.RequestUri, json, message.Method.Method, "1.0", "TP-HMAC-SHA1", Guid.NewGuid().ToString(), DateTime.UtcNow.ToString("O"), developerKey, developerSecret)

            message.Headers.Add("tp-authorization", authorizationHeader.ToString())
            message.Headers.Add("tp-application-id", "1234")
            message.Headers.Add("tp-application-name", "triPOS.vbnet")
            message.Headers.Add("tp-application-version", "1.0.0")
            message.Headers.Add("tp-return-logs", "false")
            message.Headers.Add("accept", contentType)
            message.Content = New StringContent(json, System.Text.Encoding.UTF8, contentType)

            m_Headers = message.Headers.ToString()

            Dim response As Task(Of HttpResponseMessage) = httpClient.SendAsync(message)
            response.Wait()
            respMessage = response.Result
        End Using

        Return respMessage
    End Function
End Class
