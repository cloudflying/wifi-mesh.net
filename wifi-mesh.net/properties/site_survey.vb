Public Class site_survey
    Public Property ssid As String
    Public Property bssid As String
    Public Property channel_width As Integer
    Public Property encryption As String
    Public Property mode As String
    Public Property vendor As String
    Public Property channel As Integer()
    Public Property seen_by_node As SeenByNode()
End Class
Public Class SeenByNode
    Public Property mac As String
    Public Property name As String
    Public Property time As DateTime
    Public Property signal As Integer
End Class
Public Class site_survey_wrapper
    Public Property access_points As New List(Of site_survey)
End Class
