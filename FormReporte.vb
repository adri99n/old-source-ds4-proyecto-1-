Imports System.Data.SqlClient
Imports iTextSharp.text.pdf.fonts.cmaps

Public Class FormReporte
    Private TipoReporte As String
    Private NominaID As Integer

    Public Sub New(tipoReporteSeleccionado As String, nominaIdSeleccionado As Integer)
        InitializeComponent()
        TipoReporte = tipoReporteSeleccionado
        NominaID = nominaIdSeleccionado
        dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub FormReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)
                btn.BackColor = Color.FromArgb(254, 223, 231)
                btn.ForeColor = Color.Black
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
            End If
        Next

        ' Establecer "Reporte Histórico" como predeterminado si TipoReporte está vacío o es nulo.
        If String.IsNullOrEmpty(TipoReporte) And NominaID = 0 Then
            TipoReporte = "Reporte Histórico"
        End If

        lblTitulo.Text = "Mostrando: " & TipoReporte
        CargarComboBoxTipoReporte()
        CargarComboBoxPeriodoNomina()

        ' Aquí llamamos a CargarReporte para los diferentes tipos de reporte
        Select Case TipoReporte
            Case "Reporte Histórico"
                cmbPeriodoNomina.Visible = False
                CargarReporteHistorico() ' Llamada al método para cargar el reporte histórico
            Case "Resumen General"
                cmbPeriodoNomina.Visible = True
                cmbPeriodoNomina.Enabled = True
                CargarReporte() ' Llamada al método para cargar el reporte de resumen general
            Case "Reporte Detallado"
                cmbPeriodoNomina.Visible = True
                cmbPeriodoNomina.Enabled = True
                CargarReporte() ' Llamada al método para cargar el reporte detallado
            Case Else
                MessageBox.Show("Tipo de reporte no válido. Se cargará el reporte histórico por defecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TipoReporte = "Reporte Histórico"
                cmbPeriodoNomina.Enabled = False
                CargarReporte("Fecha") ' Cargar el reporte histórico por defecto
        End Select
    End Sub

    ' Llenar el ComboBox con los tipos de reporte
    Private Sub CargarComboBoxTipoReporte()
        cmbTipoReporte.Items.Clear()
        cmbTipoReporte.Items.Add("Reporte Histórico")
        cmbTipoReporte.Items.Add("Resumen General")
        cmbTipoReporte.Items.Add("Reporte Detallado")
        cmbTipoReporte.SelectedIndex = cmbTipoReporte.Items.IndexOf(TipoReporte)
    End Sub

    ' Llenar el ComboBox con los periodos de nómina disponibles
    Private Sub CargarComboBoxPeriodoNomina()
        cmbPeriodoNomina.Items.Clear()

        Dim query As String = "SELECT NominaID, PeriodoPagado FROM Nominas"
        Using conn As New SqlConnection(My.Settings.BD)
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim periodo As New PeriodoNomina With {
                        .NominaID = reader("NominaID"),
                        .PeriodoPagado = reader("PeriodoPagado").ToString()
                    }
                        cmbPeriodoNomina.Items.Add(periodo)
                    End While
                End Using
            End Using
        End Using

        If cmbPeriodoNomina.Items.Count > 0 Then
            cmbPeriodoNomina.SelectedIndex = 0 ' Selecciona el primer elemento por defecto
        End If
    End Sub


    ' Cargar los datos del reporte
    Private Sub CargarReporte(Optional ordenPor As String = "")
        lblTitulo.Text = "Mostrando: " & TipoReporte
        dgvReporte.DataSource = Nothing
        dgvReporte.Rows.Clear()
        Dim query As String = ""

        ' Dependiendo del tipo de reporte, se ejecuta la consulta correspondiente
        Select Case TipoReporte
            Case "Reporte Detallado"
                query = "EXEC ReporteDetalladoNomina @NominaID"
            Case "Resumen General"
                query = "EXEC ResumenGeneralNomina @NominaID"  ' Sólo pasamos NominaID
        End Select

        ' Crear un DataTable para almacenar los datos
        Dim dt As New DataTable()

        ' Crear el comando SQL y asignar el parámetro
        Using conn As New SqlConnection(My.Settings.BD)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@NominaID", NominaID) ' Usamos directamente el NominaID

                ' Ejecutar la consulta y llenar el DataTable
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        ' Asignar el DataTable al DataGridView
        dgvReporte.DataSource = dt

        ' Si es un reporte de Resumen General, agregar fila de totales
        If TipoReporte = "Resumen General" Then
            AgregarFilaTotales(dt)
        End If
    End Sub

    Private Sub cmbPeriodoNomina_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodoNomina.SelectedIndexChanged
        If cmbPeriodoNomina.SelectedItem IsNot Nothing Then
            Dim periodoSeleccionado As PeriodoNomina = CType(cmbPeriodoNomina.SelectedItem, PeriodoNomina)
            NominaID = periodoSeleccionado.NominaID

            ' Llama al método para cargar el reporte con el nuevo NominaID
            If TipoReporte = "Reporte Histórico" Then
                CargarReporteHistorico()
            Else
                CargarReporte()
            End If
        End If
    End Sub


    ' Cargar los datos históricos en el DataGridView (sin necesidad de seleccionar periodo)
    Private Sub CargarReporteHistorico()
        Try
            dgvReporte.DataSource = Nothing
            dgvReporte.Rows.Clear()

            Dim query As String = "EXEC ReporteHistoricoNominas"
            Dim dt As New DataTable()

            ' Crear el comando SQL para los datos históricos
            Using conn As New SqlConnection(My.Settings.BD)
                Using cmd As New SqlCommand(query, conn)
                    conn.Open()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            ' Verificar si el DataTable tiene datos
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No hay historial de nóminas disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Asignar el DataTable al DataGridView
                dgvReporte.DataSource = dt
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al cargar el reporte: no hay historial que mostrar ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' Agregar la fila de totales generales al DataTable del reporte
    Private Sub AgregarFilaTotales(dt As DataTable)
        Dim totalRow As DataRow = dt.NewRow()
        totalRow("Departamento") = "Total General"
        totalRow("TotalEmpleados") = dt.Compute("SUM(TotalEmpleados)", String.Empty)
        totalRow("CostoTotal") = dt.Compute("SUM(CostoTotal)", String.Empty)
        dt.Rows.Add(totalRow)
    End Sub

    ' Cuando cambia el ComboBox de tipo de reporte, actualizar el contenido
    Private Sub cmbTipoReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoReporte.SelectedIndexChanged
        ' Verificar que el valor seleccionado no sea Nothing
        If cmbTipoReporte.SelectedItem IsNot Nothing Then
            TipoReporte = cmbTipoReporte.SelectedItem.ToString()

            ' Dependiendo del tipo de reporte seleccionado, habilitar o deshabilitar elementos y cargar el reporte correspondiente
            If TipoReporte = "Reporte Histórico" Then
                cmbPeriodoNomina.Visible = False
                cmbPeriodoNomina.Enabled = False ' Deshabilitar el ComboBox de periodo
                CargarReporteHistorico() ' Cargar los datos históricos
            ElseIf TipoReporte = "Resumen General" Then
                cmbPeriodoNomina.Visible = True
                cmbPeriodoNomina.Enabled = True ' Habilitar el ComboBox de periodo
                CargarReporte() ' Cargar el reporte filtrado por el periodo seleccionado
            ElseIf TipoReporte = "Reporte Detallado" Then
                cmbPeriodoNomina.Visible = True
                cmbPeriodoNomina.Enabled = True ' Habilitar el ComboBox de periodo
                CargarReporte() ' Cargar el reporte detallado
            End If
        End If
    End Sub

    ' Exportar el reporte a Excel
    Private Sub btnExportarReporte_Click(sender As Object, e As EventArgs) Handles btnExportarReporte.Click
        If dgvReporte.DataSource IsNot Nothing AndAlso dgvReporte.Rows.Count > 0 Then
            ClaseUtilidades.ExportarAutomatico(dgvReporte, TipoReporte.Replace(" ", ""))
        Else
            MessageBox.Show("No hay datos para exportar.", "Exportación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Dim mensaje As String

        Select Case TipoReporte
            Case "Reporte Histórico"
                mensaje = "Este formulario muestra el histórico de todas las nóminas registradas. " & vbCrLf &
                          "Puede ver un resumen de todas las nóminas, incluyendo detalles generales de cada una."
            Case "Resumen General"
                mensaje = "Este formulario muestra un resumen general de la nómina seleccionada. " & vbCrLf &
                          "Incluye datos agregados como el número total de empleados y el costo total de la nómina."
            Case "Reporte Detallado"
                mensaje = "Este formulario muestra los detalles de la nómina seleccionada. " & vbCrLf &
                          "Los datos incluyen: Nombre del empleado, salario base, horas extras, bonos, descuentos y total pagado."
            Case Else
                mensaje = "Seleccione un tipo de reporte para obtener más información." & vbCrLf &
                          "Opciones disponibles: Histórico, Resumen General o Detallado."
        End Select

        mensaje &= vbCrLf & vbCrLf & "Puede exportar los datos mostrados a un archivo utilizando el botón 'Exportar'."

        MessageBox.Show(mensaje, "Ayuda - Formulario de Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim formmenuP As New MenuP
        Form1.Instancia.PanelPrincipal.Visible = True
        Form1.Instancia.CargarFormularioEnPanel(formmenuP)
    End Sub
End Class

