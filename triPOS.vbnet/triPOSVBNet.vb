Imports Newtonsoft.Json
Imports System.Net.Http

Public Class Form1
    Private Sub btnSendTransaction_Click(sender As Object, e As EventArgs) Handles btnSendTransaction.Click
        Dim request As SaleRequest = SaleRequest.GetSaleRequest()

        Dim url As String = String.Format("http://localhost:{0}/api/v1/sale", "8080")
        Dim postBody As String = JsonConvert.SerializeObject(request, Formatting.Indented)

        Dim response As HttpResponseMessage = triPOSWebRequest.DotriPOSRequest(postBody, url)

        Dim readAsync As Task(Of String) = response.Content.ReadAsStringAsync()
        readAsync.Wait()
        Dim actualResponse As String = readAsync.Result

    End Sub
End Class
