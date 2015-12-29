Public Class node_history_wrapper
    Public Property nodes As New Dictionary(Of String, node_history)
End Class

Public Class node_history
    Public Property checkins As New List(Of node_history_checkins)
    Public Property traffic As New node_history_traffic
End Class
Public Class node_history_checkins
    Public Property time As DateTime
    Public Property status As String
End Class

Public Class node_history_traffic
    Public Property ssid1 As New node_history_traffic_ssid
    Public Property ssid2 As New node_history_traffic_ssid
    Public Property ssid3 As New node_history_traffic_ssid
    Public Property ssid4 As New node_history_traffic_ssid
End Class
Public Class node_history_traffic_ssid
    Public Property bup As Int64
    Public Property bdown As Int64
    Public Property users As Int64
End Class

Public Class single_node_history_wrapper
    Public Property nid As String
    Public Property traffic As New List(Of single_node_history_traffic)

End Class
Public Class single_node_history_traffic
    Public Property time As DateTime
    Public Property ssid1 As New single_node_history_traffic_ssid
End Class
Public Class single_node_history_traffic_ssid
    Public Property rup As Int64
    Public Property rdown As Int64
End Class
