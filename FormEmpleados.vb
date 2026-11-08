Imports System.Data.SqlClient

Public Class FormEmpleados
    Private conexion As New SqlConnection(My.Settings.BD)

    Private Sub FormEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpleados()
        ActualizarPeriodo()
        CargarComboBoxTipoRContrato()

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)
                btn.BackColor = Color.FromArgb(254, 223, 231)
                btn.ForeColor = Color.Black
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
            End If
        Next
    End Sub

    Private Sub CargarComboBoxTipoRContrato()
        cmbTipoContrato.Items.Clear()
        cmbTipoContrato.Items.Add("Permanente")
        cmbTipoContrato.Items.Add("ServiciosProfesionales")
        cmbTipoContrato.SelectedIndex = cmbTipoContrato.Items.IndexOf(0)
    End Sub
    Private Sub ActualizarPeriodo()
        ' Obtener la fecha seleccionada del DateTimePicker
        Dim fechaSeleccionada As DateTime = DateTimePickerFechaPago.Value

        ' Formatear el periodo y asignarlo al lblPeriodo
        lblPeriodo.Text = fechaSeleccionada.ToString("MMMM yyyy")
    End Sub

    Private Sub CargarEmpleados()
        Dim consulta As String = "SELECT EmpleadoID, Nombre, Cargo, SalarioBase, TipoContrato, AplicaDescuentos, FechaInicioContrato, Activo FROM Empleados"
        Dim adaptador As New SqlDataAdapter(consulta, conexion)
        Dim tabla As New DataTable()

        conexion.Open()
        adaptador.Fill(tabla)
        conexion.Close()

        dgvEmpleados.DataSource = tabla
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If ValidarCampos() Then
            If Not EmpleadoDuplicado(txtNombre.Text, txtCargo.Text) Then
                Dim consulta As String = "INSERT INTO Empleados (Nombre, Cargo, SalarioBase, TipoContrato, AplicaDescuentos, FechaInicioContrato, Activo) 
                                           VALUES (@Nombre, @Cargo, @SalarioBase, @TipoContrato, @AplicaDescuentos, @FechaInicioContrato, @Activo)"
                Dim comando As New SqlCommand(consulta, conexion)

                comando.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                comando.Parameters.AddWithValue("@Cargo", txtCargo.Text)
                comando.Parameters.AddWithValue("@SalarioBase", Decimal.Parse(txtSalarioBase.Text))
                comando.Parameters.AddWithValue("@TipoContrato", cmbTipoContrato.Text)
                comando.Parameters.AddWithValue("@AplicaDescuentos", chkAplicaDescuentos.Checked)
                comando.Parameters.AddWithValue("@FechaInicioContrato", dtpFechaInicio.Value)
                comando.Parameters.AddWithValue("@Activo", chkActivo.Checked)

                conexion.Open()
                comando.ExecuteNonQuery()
                conexion.Close()

                CargarEmpleados()
                LimpiarCampos()
            Else
                MessageBox.Show("Ya existe un empleado con el mismo Nombre y Cargo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        CalcularDescuentos()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If ValidarCampos() Then
            If Not EmpleadoDuplicado(txtNombre.Text, txtCargo.Text, lblEmpleadoID.Text) Then
                Dim consulta As String = "UPDATE Empleados 
                                           SET Nombre = @Nombre, Cargo = @Cargo, SalarioBase = @SalarioBase, 
                                               TipoContrato = @TipoContrato, AplicaDescuentos = @AplicaDescuentos, 
                                               FechaInicioContrato = @FechaInicioContrato, Activo = @Activo
                                           WHERE EmpleadoID = @EmpleadoID"
                Dim comando As New SqlCommand(consulta, conexion)

                comando.Parameters.AddWithValue("@EmpleadoID", Integer.Parse(lblEmpleadoID.Text))
                comando.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                comando.Parameters.AddWithValue("@Cargo", txtCargo.Text)
                comando.Parameters.AddWithValue("@SalarioBase", Decimal.Parse(txtSalarioBase.Text))
                comando.Parameters.AddWithValue("@TipoContrato", cmbTipoContrato.Text)
                comando.Parameters.AddWithValue("@AplicaDescuentos", chkAplicaDescuentos.Checked)
                comando.Parameters.AddWithValue("@FechaInicioContrato", dtpFechaInicio.Value)
                comando.Parameters.AddWithValue("@Activo", chkActivo.Checked)

                conexion.Open()
                comando.ExecuteNonQuery()
                conexion.Close()

                CargarEmpleados()
                LimpiarCampos()
            Else
                MessageBox.Show("Ya existe un empleado con el mismo Nombre y Cargo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        CalcularDescuentos()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            ' Verificar si la nómina ya fue emitida
            Dim consultaNomina As String = "SELECT COUNT(*) FROM Nominas WHERE EmpleadoID = @EmpleadoID AND Estado = 'Emitida'"
            Dim comandoVerificacion As New SqlCommand(consultaNomina, conexion)
            comandoVerificacion.Parameters.AddWithValue("@EmpleadoID", Integer.Parse(lblEmpleadoID.Text))

            conexion.Open()
            Dim existeNomina As Integer = Convert.ToInt32(comandoVerificacion.ExecuteScalar())
            conexion.Close()

            ' Lanzar excepción si existe una nómina emitida
            If existeNomina > 0 Then
                Throw New InvalidOperationException("No se puede eliminar este empleado porque ya se emitió una nómina asociada.")
            End If

            ' Si no hay nómina emitida, proceder con la eliminación
            Dim consulta As String = "DELETE FROM Empleados WHERE EmpleadoID = @EmpleadoID"
            Dim comando As New SqlCommand(consulta, conexion)
            comando.Parameters.AddWithValue("@EmpleadoID", Integer.Parse(lblEmpleadoID.Text))

            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()

            CargarEmpleados()
            LimpiarCampos()
            MessageBox.Show("El empleado ha sido eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As InvalidOperationException
            ' Manejar el error de nómina emitida
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Manejar cualquier otro error
            MessageBox.Show("Ocurrió un error inesperado: No se puede eliminar este empleado porque ya se emitió una nómina asociada. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvEmpleados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleados.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = dgvEmpleados.Rows(e.RowIndex)

            lblEmpleadoID.Text = fila.Cells("EmpleadoID").Value.ToString()
            txtNombre.Text = fila.Cells("Nombre").Value.ToString()
            txtCargo.Text = fila.Cells("Cargo").Value.ToString()
            txtSalarioBase.Text = fila.Cells("SalarioBase").Value.ToString()
            cmbTipoContrato.Text = fila.Cells("TipoContrato").Value.ToString()
            chkAplicaDescuentos.Checked = Convert.ToBoolean(fila.Cells("AplicaDescuentos").Value)
            dtpFechaInicio.Value = Convert.ToDateTime(fila.Cells("FechaInicioContrato").Value)
            chkActivo.Checked = Convert.ToBoolean(fila.Cells("Activo").Value)
        End If
    End Sub

    Private Sub LimpiarCampos()
        lblEmpleadoID.Text = ""
        txtNombre.Clear()
        txtCargo.Clear()
        txtSalarioBase.Clear()
        cmbTipoContrato.SelectedIndex = -1
        chkAplicaDescuentos.Checked = False
        chkActivo.Checked = True
        dtpFechaInicio.Value = DateTime.Now
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarCampos()
    End Sub

    ' Validar campos requeridos
    Private Function ValidarCampos() As Boolean
        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse String.IsNullOrWhiteSpace(txtCargo.Text) Then
            MessageBox.Show("El campo Nombre (Apellido, Nombre) y Cargo son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If Not txtNombre.Text.Contains(",") Then
            MessageBox.Show("El campo Nombre debe estar en formato 'Apellido, Nombre'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtSalarioBase.Text) OrElse Decimal.Parse(txtSalarioBase.Text) <= 0 Then
            MessageBox.Show("El Salario Base debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    ' Verificar si el empleado ya existe
    Private Function EmpleadoDuplicado(nombre As String, cargo As String, Optional empleadoID As String = "0") As Boolean
        Dim consulta As String = "SELECT COUNT(*) FROM Empleados WHERE Nombre = @Nombre AND Cargo = @Cargo AND EmpleadoID <> @EmpleadoID"
        Dim comando As New SqlCommand(consulta, conexion)

        comando.Parameters.AddWithValue("@Nombre", nombre)
        comando.Parameters.AddWithValue("@Cargo", cargo)
        comando.Parameters.AddWithValue("@EmpleadoID", empleadoID)

        conexion.Open()
        Dim resultado As Integer = Convert.ToInt32(comando.ExecuteScalar())
        conexion.Close()

        Return resultado > 0
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim formmenuP As New MenuP
        Form1.Instancia.PanelPrincipal.Visible = True
        Form1.Instancia.CargarFormularioEnPanel(formmenuP)
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        MessageBox.Show("La ventana 'Empleados' te permite gestionar toda la información relacionada con los empleados de la empresa. En esta ventana, puedes ingresar, modificar o eliminar empleados, así como visualizar sus datos importantes como nombre, cargo, salario, fecha de inicio de contrato, tipo de contrato (Permanente o Servicios Profesionales) y estado (activo o inactivo). " &
                   "Además, se pueden registrar los descuentos aplicables a los empleados, como el seguro social y el seguro educativo, si corresponde. La ventana también permite visualizar el historial de empleados y realizar búsquedas por nombre o cargo, facilitando la administración de los empleados dentro del sistema.",
                   "Ayuda - Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub btnCrearNomina_Click(sender As Object, e As EventArgs) Handles btnCrearNomina.Click
        Dim connectionString As String = My.Settings.BD
        Dim fechaPago As DateTime = DateTimePickerFechaPago.Value
        Dim periodoPagado As String = lblPeriodo.Text.Replace("Periodo: ", "").Trim()
        Dim id As Integer

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand("CrearNomina", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@FechaPago", fechaPago)
                command.Parameters.AddWithValue("@PeriodoPagado", periodoPagado)

                Try
                    connection.Open()
                    id = Convert.ToInt32(command.ExecuteScalar())
                    MessageBox.Show($"Nómina creada con ID: {id}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show($"Error al crear la nómina: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End Using
        End Using

        Dim formreporte As New FormReporte("Reporte Detallado", id)
        Form1.Instancia.PanelPrincipal.Visible = True
        Form1.Instancia.CargarFormularioEnPanel(formreporte)
    End Sub


    Private Sub DateTimePickerFechaPago_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerFechaPago.ValueChanged
        ' Actualizar el lblPeriodo cuando cambia el valor del DateTimePicker
        ActualizarPeriodo()
    End Sub



    Private Sub btnhistorial_Click(sender As Object, e As EventArgs) Handles btnhistorial.Click
        Dim formHistNom As New FormReporte("Reporte Histórico", 0)
        Form1.Instancia.PanelPrincipal.Visible = True
        Form1.Instancia.CargarFormularioEnPanel(formHistNom)
    End Sub

    Private Sub CalcularDescuentos()
        Using connection As New SqlConnection(My.Settings.BD)
            Using command As New SqlCommand("CalcularDescuentos", connection)
                command.CommandType = CommandType.StoredProcedure
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show($"Error al calcular descuentos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub
End Class

