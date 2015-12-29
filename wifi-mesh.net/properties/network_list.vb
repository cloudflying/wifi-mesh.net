Public Class network_list
    Public Property name As String
    Public Property id As Integer
    Public Property latitude As Double
    Public Property longitude As Double
    Public Property down_repeater As Integer
    Public Property down_gateway As Integer
    Public Property spare_nodes As Integer
    Public Property node_count As Integer
End Class
Public Class network_list_wrapper
    Public Property networks As New List(Of network_list)
End Class
