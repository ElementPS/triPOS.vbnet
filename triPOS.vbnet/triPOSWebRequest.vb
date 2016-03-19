
Imports System.Xml
Imports System.Net.Http

Public Class triPOSWebRequest
    Public Shared Function DotriPOSRequest(json As String, url As String) As HttpResponseMessage

        Dim TriPosConfigFilePath As String = "C:\Program Files (x86)\Vantiv\TriPOS Service\TriPOS.config"

        Dim triPosConfig = New XmlDocument()
        triPosConfig.Load(TriPosConfigFilePath)

        Dim developerKeys = triPosConfig.GetElementsByTagName("developerKey")
        Dim developerKey As String = developerKeys(0).InnerXml

        Dim developerSecrets = triPosConfig.GetElementsByTagName("developerSecret")
        Dim developerSecret As String = developerSecrets(0).InnerXml

        Dim respMessage As HttpResponseMessage = Nothing
        Using httpClient = New HttpClient()
            Dim message = New HttpRequestMessage(HttpMethod.Post, New Uri(url))
            Dim authorizationHeader As AuthorizationHeader = AuthorizationHeader.Create(message.Headers, message.RequestUri, json, message.Method.Method, "1.0", "TP-HMAC-SHA1", Guid.NewGuid().ToString(), DateTime.UtcNow.ToString("O"), developerKey, developerSecret)

            message.Headers.Add("tp-authorization", authorizationHeader.ToString())
            message.Headers.Add("tp-application-id", "1234")
            message.Headers.Add("tp-application-name", "triPOS.CSharp")
            message.Headers.Add("tp-application-version", "1.0.0")
            message.Headers.Add("tp-return-logs", "false")
            message.Headers.Add("accept", "application/json")

            Dim response As Task(Of HttpResponseMessage) = httpClient.SendAsync(message)
            response.Wait()
            respMessage = response.Result
        End Using

        Return respMessage
    End Function
End Class
