Imports RestSharp
Imports Newtonsoft.Json
Public Class api
    Public Shared Property apiKey As String
    Public Shared Property apiSignature As String

#Region "Network Management"
    Public Shared Function getNetworkList() As network_list_wrapper
        Try
            Dim auth As String = getAuthHeader()
            Dim client As New RestClient("https://api.cloudtrax.com")
            Dim req As New RestRequest("/network/list")

            ' ################ AUTHORIZATION ########################
            req.AddHeader("Authorization", auth)
            req.AddHeader("Signature", genSignature(client.BuildUri(req).AbsolutePath, auth))
            req.AddHeader("Content-Type", "application/json")
            req.AddHeader("OpenMesh-API-Version", "1")
            ' ################ END AUTHORIZATION ####################

            Dim body As String = client.Execute(req).Content
            Return JsonConvert.DeserializeObject(Of network_list_wrapper)(body)
        Catch ex As Exception
            Throw New ApplicationException("Error Generating Network List: " & ex.Message)
        End Try
    End Function
#End Region

#Region "History - TODO - Single Client & Documentation"


    Public Shared Function getHistoryAllssid(network_id As String, Optional period As String = "day") As network_history_wrapper
        Dim body As String = requestGet("/history/network/" & network_id & "?period=" & period)
        Return JsonConvert.DeserializeObject(Of network_history_wrapper)(body)
    End Function
    Public Shared Function getHistoryAllClients(network_id As String, Optional period As String = "day") As client_list
        Dim body As String = requestGet("/history/network/" & network_id & "/clients?period=" & period)
        Return JsonConvert.DeserializeObject(Of client_list)(body)
    End Function

    Public Shared Function getHistorySingleClient(network_id As String, client_id As String, Optional period As String = "day") As String
        Dim body As String = requestGet("/history/network/" & network_id & "/client/" & client_id & "?period=" & period)
        Return body 'JsonConvert.DeserializeObject(Of client_list)(body)


        ' Need to test out various options
    End Function

    Public Shared Function getHistoryNodes(network_id As String, Optional period As String = "day") As node_history_wrapper
        Dim body As String = requestGet("/history/network/" & network_id & "/nodes?period=" & period)
        Return JsonConvert.DeserializeObject(Of node_history_wrapper)(body)
    End Function
    Public Shared Function getHistorySingleNode(network_id As String, node_id As String, Optional period As String = "day") As single_node_history_wrapper
        Dim body As String = requestGet("/history/network/" & network_id & "/node/" & node_id & "?period=" & period)
        Return JsonConvert.DeserializeObject(Of single_node_history_wrapper)(body)
    End Function
#End Region

#Region "Site Survey - COMPLETED"
    ' ## CloudTrax API v1
    ' ## https://github.com/cloudtrax/docs/blob/master/api/site_survey.md
    ' ## JP - 12/28/15 - 2PM EST


    ''' <summary>
    ''' Starts a Site Survey Scan on your network. Average time to complete is 5 minutes (node checkin starts process)
    ''' </summary>
    ''' <param name="network_id">CloudTrax Network ID</param>
    ''' <returns>Returns True if scan started, otherwise False means scan failed to start.</returns>
    Public Shared Function startSiteSurvey(network_id As String) As Boolean
        Try
            Dim auth As String = getAuthHeader()
            Dim client As New RestClient("https://api.cloudtrax.com")
            Dim req As New RestRequest("/sitesurvey/network/{id}/scan")
            req.AddUrlSegment("id", network_id)

            ' ################ AUTHORIZATION ########################
            req.AddHeader("Authorization", auth)
            req.AddHeader("Signature", genSignature(client.BuildUri(req).AbsolutePath, auth))
            req.AddHeader("Content-Type", "application/json")
            req.AddHeader("OpenMesh-API-Version", "1")
            ' ################ END AUTHORIZATION ####################

            Dim body As String = client.Execute(req).Content
            If InStr(body, "200") > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New ApplicationException("Error Generating Network List: " & ex.Message)
        End Try
    End Function
    ''' <summary>
    ''' Retrieves Site Survey Results as Site_Survey_Wrapper Object
    ''' </summary>
    ''' <param name="network_id">CloudTrax Network ID</param>
    ''' <returns>Returns site_survey_wrapper object, inside wrapper is a list of access points found</returns>
    Public Shared Function getSiteSurvey(network_id As String) As site_survey_wrapper
        Try
            Dim auth As String = getAuthHeader()
            Dim client As New RestClient("https://api.cloudtrax.com")
            Dim req As New RestRequest("/sitesurvey/network/{id}")
            req.AddUrlSegment("id", network_id)

            ' ################ AUTHORIZATION ########################
            req.AddHeader("Authorization", auth)
            req.AddHeader("Signature", genSignature(client.BuildUri(req).AbsolutePath, auth))
            req.AddHeader("Content-Type", "application/json")
            req.AddHeader("OpenMesh-API-Version", "1")
            ' ################ END AUTHORIZATION ####################

            Dim body As String = client.Execute(req).Content
            Return JsonConvert.DeserializeObject(Of site_survey_wrapper)(body)

        Catch ex As Exception
            Throw New ApplicationException("Error Generating Network List: " & ex.Message)
        End Try
    End Function
#End Region

#Region "Request Processing"
    ' Note Editing below this line may break ALL functionality


    Private Shared Function requestGet(URI As String) As String
        Try
            Dim auth As String = getAuthHeader()
            Dim client As New RestClient("https://api.cloudtrax.com")
            Dim req As New RestRequest(URI)




            ' ################ AUTHORIZATION ########################
            req.AddHeader("Authorization", auth)
            Dim urlForSignature As String = URI
            'If InStr(urlForSignature, "?") > 0 Then
            '    urlForSignature = Split(urlForSignature, "?")(0)
            'End If
            req.AddHeader("Signature", genSignature(urlForSignature, auth))
            req.AddHeader("Content-Type", "application/json")
            req.AddHeader("OpenMesh-API-Version", "1")
            ' ################ END AUTHORIZATION ####################

            Return client.Execute(req).Content


        Catch ex As Exception
            Throw New ApplicationException("Request Error: " & ex.Message)
        End Try
    End Function
#End Region
End Class
