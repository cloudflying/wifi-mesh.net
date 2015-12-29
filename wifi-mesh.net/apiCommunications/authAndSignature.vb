Imports System.Security.Cryptography
Module authAndSignature
    Public Function getAuthHeader() As String
        Dim apiKey As String = api.apiKey
        Dim nonce As String = Replace(Guid.NewGuid().ToString, "-", "")
        Dim unixTime As Integer = Int((DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds)
        Dim authorization As String
        authorization = "key=" & apiKey & ",timestamp=" & unixTime & ",nonce=" & nonce
        Return authorization
    End Function

    Public Function genSignature(endpoint As String, authHeader As String, Optional jsonBody As String = "") As String
        Dim authorization As String

        If Len(jsonBody) > 1 Then
            authorization = authHeader & endpoint & jsonBody
        Else
            authorization = authHeader & endpoint
        End If

        Dim getkey As String = api.apiSignature
        Dim encoding As New System.Text.ASCIIEncoding()
        Dim getkeyByte As Byte() = encoding.GetBytes(getkey)
        Dim gethmacsha256 As New HMACSHA256(getkeyByte)
        Dim getmessageBytes As Byte() = encoding.GetBytes(authorization)
        Dim hashmessage As Byte() = gethmacsha256.ComputeHash(getmessageBytes)
        Return ByteToString(hashmessage).ToLower
    End Function
    Public Function ByteToString(buff As Byte()) As String
        Dim getbinary As String = ""
        For i As Integer = 0 To buff.Length - 1
            getbinary += buff(i).ToString("X2")
        Next
        Return (getbinary)
    End Function
End Module
