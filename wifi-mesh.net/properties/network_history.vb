Public Class network_history_ssids
    Public Property ssid1 As Integer
    Public Property ssid2 As Integer
    Public Property ssid3 As Integer
    Public Property ssid4 As Integer

End Class

Public Class network_history_wrapper
    Public Property clients As New network_history_ssids
    Public Property rows As New List(Of network_history_Row)
End Class

'Public Class network_history_rows
'    Public Property ssid1 As New Ssid1
'    Public Property ssid2 As New Ssid2
'    Public Property ssid3 As New Ssid3
'    Public Property ssid4 As New Ssid4

'    Public Property time As DateTime
'End Class
Public Class Ssid1
    Public Property traffic As New network_history_Traffic
    Public Property users As Integer
End Class

Public Class Ssid2
    Public Property traffic As New network_history_Traffic
    Public Property users As Integer
End Class

Public Class Ssid3
    Public Property traffic As New network_history_Traffic
    Public Property users As Integer
End Class

Public Class Ssid4
    Public Property traffic As New network_history_Traffic
    Public Property users As Integer
End Class

Public Class network_history_Row
    Public Property time As DateTime
    Public Property ssid1 As New Ssid1
    Public Property ssid2 As New Ssid2
    Public Property ssid3 As New Ssid3
    Public Property ssid4 As New Ssid4

End Class

Public Class network_history_TrafficCounter
    Public Property bdown As Integer
    Public Property bup As Integer
    Public Property rdown As Integer
    Public Property rup As Integer
End Class

Public Class network_history_Traffic
    Public Property youtube As New network_history_TrafficCounter
    Public Property googlesocial As New network_history_TrafficCounter
    Public Property twitter As New network_history_TrafficCounter
    Public Property facebook As New network_history_TrafficCounter
    Public Property vocera As New network_history_TrafficCounter
    Public Property http As New network_history_TrafficCounter
    Public Property ssl As New network_history_TrafficCounter
    Public Property google As New network_history_TrafficCounter
    Public Property spotify As New network_history_TrafficCounter
    Public Property itunes As New network_history_TrafficCounter
    Public Property udp As New network_history_TrafficCounter
    Public Property tcp As New network_history_TrafficCounter
    Public Property netbios As New network_history_TrafficCounter
    Public Property dhcp As New network_history_TrafficCounter
    Public Property upnp As New network_history_TrafficCounter
    Public Property dns As New network_history_TrafficCounter
    Public Property yahoo As New network_history_TrafficCounter
    Public Property instagram As New network_history_TrafficCounter
    Public Property linkedin As New network_history_TrafficCounter
    Public Property wordpresscom As New network_history_TrafficCounter
    Public Property amazon As New network_history_TrafficCounter
    Public Property tumblr As New network_history_TrafficCounter
    Public Property edonkey As New network_history_TrafficCounter
    Public Property skype As New network_history_TrafficCounter
    Public Property msn As New network_history_TrafficCounter
    Public Property igmp As New network_history_TrafficCounter
    Public Property bing As New network_history_TrafficCounter
    Public Property soundcloud As New network_history_TrafficCounter
    Public Property ebay As New network_history_TrafficCounter
    Public Property http_video As New network_history_TrafficCounter
    Public Property yelp As New network_history_TrafficCounter
    Public Property blogger As New network_history_TrafficCounter
    Public Property icmp As New network_history_TrafficCounter
    Public Property hostbasedemail As New network_history_TrafficCounter
    Public Property ftp As New network_history_TrafficCounter
End Class


