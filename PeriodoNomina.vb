Public Class PeriodoNomina
    Public Property NominaID As Integer
    Public Property PeriodoPagado As String

    Public Overrides Function ToString() As String
        Return PeriodoPagado
    End Function
End Class