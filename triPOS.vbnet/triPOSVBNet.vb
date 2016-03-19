Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Xml
Imports System.Text

Public Class Form1
    Private Sub btnSendTransaction_Click(sender As Object, e As EventArgs) Handles btnSendTransaction.Click
        Dim contentType As String = "application/json"
        Dim TriPosConfigFilePath As String = "C:\Program Files (x86)\Vantiv\TriPOS Service\TriPOS.config"

        Dim triPosConfig = New XmlDocument()
        triPosConfig.Load(TriPosConfigFilePath)

        Dim developerKeys = triPosConfig.GetElementsByTagName("developerKey")
        Dim developerKey As String = developerKeys(0).InnerXml

        Dim developerSecrets = triPosConfig.GetElementsByTagName("developerSecret")
        Dim developerSecret As String = developerSecrets(0).InnerXml

        Dim url As String = String.Format("http://localhost:{0}/api/v1/sale", "8080")

        Dim triPOSWebRequest As triPOSWebRequest = New triPOSWebRequest()

        Dim response As HttpResponseMessage = triPOSWebRequest.DotriPOSRequest(txtRequest.Text, url, developerKey, developerSecret, contentType)

        Dim readAsync As Task(Of String) = response.Content.ReadAsStringAsync()
        readAsync.Wait()
        Dim actualResponse As String = readAsync.Result
        txtResponse.Text = BeautifyResponse(actualResponse, contentType)
        txtHeaders.Text = triPOSWebRequest.Headers

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnGenerateXML.Click
        Dim request As SaleRequest = SaleRequest.GetSaleRequest()
        MessageBox.Show("Not Implemented")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGenerateJSON.Click
        Dim request As SaleRequest = SaleRequest.GetSaleRequest()
        Dim postBody As String = JsonConvert.SerializeObject(request, Newtonsoft.Json.Formatting.Indented)
        txtRequest.Text = postBody

    End Sub

    Private Sub btnClearData_Click(sender As Object, e As EventArgs) Handles btnClearData.Click
        txtRequest.Text = String.Empty
        txtResponse.Text = String.Empty
        txtHeaders.Text = String.Empty
    End Sub


    Private Function BeautifyResponse(actualResponse As String, contentType As String) As String
        Dim response As String = String.Empty

        Select Case contentType
            Case "application/xml"
                Dim stringBuilder = New StringBuilder()
                Dim settings = New XmlWriterSettings()
                settings.Indent = True
                settings.IndentChars = "  "
                settings.NewLineChars = vbCr & vbLf
                settings.NewLineHandling = NewLineHandling.Replace

                Using writer = XmlWriter.Create(stringBuilder, settings)
                        Dim doc = New XmlDocument()
                        doc.LoadXml(actualResponse)
                    doc.Save(writer)
                End Using

                response = stringBuilder.ToString()
                Exit Select

            Case "application/json"
                response = Newtonsoft.Json.Linq.JObject.Parse(actualResponse).ToString()
                Exit Select
        End Select

        Return response
    End Function

End Class
