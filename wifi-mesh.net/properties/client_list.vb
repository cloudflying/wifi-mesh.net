Public Class client_list
    Public Property clients As New Dictionary(Of String, client_list_description)
End Class
Public Class client_list_description
    Public Property name As String
    Public Property name_override As String
    Public Property cid As String
    Public Property signal As New client_list_Signal
    Public Property mcs As New client_list_Mcs
    Public Property bitrate As New client_list_Bitrate
    Public Property channel_width As Integer
    Public Property band As String
    Public Property last_seen As DateTime
    Public Property last_name As String
    Public Property last_node As String
    Public Property link As String
    Public Property wifi_mode As String
    Public Property blocked As Boolean
    Public Property os As String
    Public Property os_version As String
    Public Property traffic As New client_list_Traffic
End Class

Public Class client_list_Signal
    Public Property antenna1 As Double
    Public Property antenna2 As Double
    Public Property antenna3 As Double
    Public Property antenna4 As Double
    Public Property average As Double
End Class

Public Class client_list_Mcs
    Public Property tx As Double
End Class

Public Class client_list_Bitrate
    Public Property rx As Double
    Public Property tx As Double
End Class

Public Class client_list_Ssid
    Public Property bup As Double
    Public Property bdown As Double
End Class

Public Class client_list_Traffic
    Public Property ssid1 As client_list_Ssid
    Public Property ssid2 As client_list_Ssid
    Public Property ssid3 As client_list_Ssid
    Public Property ssid4 As client_list_Ssid
End Class
