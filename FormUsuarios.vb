Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class FormUsuarios
    Dim connection As New SqlConnection(My.Settings.BD)
    Dim command As SqlCommand
    Dim reader As SqlDataReader


    ' Botón para cerrar el formulario
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim formAdmi As New FormAdminMenu()
        Form1.Instancia.CargarFormularioEnPanel(formAdmi)
    End Sub

    ' Método para cargar los usuarios al DataGridView
    Private Sub FormUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)
                btn.BackColor = Color.FromArgb(254, 223, 231)
                btn.ForeColor = Color.Black
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
            End If
        Next

        CargarUsuarios()
        CargarTipoUsuario() ' Cargar los tipos de usuario en cmbTipoUsuario
    End Sub

    Private Sub CargarUsuarios()
        Dim query As String = "SELECT UsuarioID, NombreUsuario, Correo, Tipo, Activo, EsFijo, IntentosFallidos, UltimoIntentoFallido  FROM Usuarios WHERE UsuarioID <> 1"
        Dim adapter As New SqlDataAdapter(query, connection)
        Dim dt As New DataTable()
        adapter.Fill(dt)
        dgvUsuarios.DataSource = dt

        dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Opcionalmente, forzar un redibujo del DataGridView
        dgvUsuarios.Refresh()
    End Sub



    ' Método para cargar los tipos de usuario al ComboBox
    Private Sub CargarTipoUsuario()
        cmbTipo.Items.Clear()

        ' Agregar las opciones manualmente
        cmbTipo.Items.Add("Administrador")
        cmbTipo.Items.Add("Usuario")

        ' Si deseas que el ComboBox tenga un valor predeterminado, puedes seleccionar un ítem:
        cmbTipo.SelectedIndex = 0
    End Sub

    ' Evento para capturar la selección del usuario en el DataGridView
    Private Sub dgvUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellClick
        LimpiarCampos()
        If e.RowIndex >= 0 Then
            ' Obtener el ID del usuario seleccionado
            Dim selectedUserID As Integer = dgvUsuarios.Rows(e.RowIndex).Cells("UsuarioID").Value

            ' Consultar la información del usuario seleccionado
            Dim query As String = "SELECT * FROM Usuarios WHERE UsuarioID = @UsuarioID"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@UsuarioID", selectedUserID)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    ' Llenar los campos con los datos del usuario seleccionado
                    txtNombreUsuario.Text = reader("NombreUsuario").ToString()
                    txtCorreo.Text = reader("Correo").ToString()
                    cmbTipo.SelectedItem = reader("Tipo").ToString()
                    chkActivo.Checked = If(reader("Activo").ToString() = "1", True, False)
                    chkEsFijo.Checked = If(reader("EsFijo").ToString() = "1", True, False)

                    ' Guardar el ID del usuario seleccionado para editar o eliminar
                    lblUsuarioId.Text = selectedUserID.ToString()
                    Dim intentosFallidos As Integer = Convert.ToInt32(reader("IntentosFallidos"))
                    Dim ultimoIntentoFallido As Object = reader("UltimoIntentoFallido")

                    If intentosFallidos > 0 Then
                        ' Si el usuario tiene intentos fallidos, mostrar en el label el número de intentos y la fecha del último intento fallido
                        lblEstado.Text = String.Format("El usuario tiene {0} intentos fallidos.{1}Último intento: {2}.", intentosFallidos, Environment.NewLine, If(ultimoIntentoFallido IsNot DBNull.Value, Convert.ToDateTime(ultimoIntentoFallido).ToString("dd/MM/yyyy HH:mm:ss"), "No disponible"))
                    End If
                End If
            Catch ex As Exception
                lblEstado.Text = "Error al cargar el usuario seleccionado: " & ex.Message
            Finally
                connection.Close()
            End Try
        End If
    End Sub

    ' Método para insertar un nuevo usuario
    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        txtConfirmarContrasena.Visible = True

        ' Validar los campos antes de continuar
        Dim errores As New List(Of String) ' Lista para acumular errores

        ' Validaciones
        If Not ValidarCampos(errores, isEditar:=False) Then
            ' Si hay errores, mostramos una ventana con todos los mensajes
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Preparar la consulta para insertar el nuevo usuario
        Dim query As String = "INSERT INTO Usuarios (NombreUsuario, Contrasena, Correo, Tipo, Activo, EsFijo) VALUES (@NombreUsuario, @Contrasena, @Correo, @Tipo, @Activo, @EsFijo)"
        Dim command As New SqlCommand(query, connection)

        ' Asignar los parámetros
        command.Parameters.AddWithValue("@NombreUsuario", txtNombreUsuario.Text)
        command.Parameters.AddWithValue("@Contrasena", txtContrasena.Text)
        command.Parameters.AddWithValue("@Correo", txtCorreo.Text)
        command.Parameters.AddWithValue("@Tipo", cmbTipo.SelectedItem.ToString())
        command.Parameters.AddWithValue("@Activo", If(chkActivo.Checked, 1, 0))
        command.Parameters.AddWithValue("@EsFijo", If(chkEsFijo.Checked, 1, 0))

        ' Ejecutar la consulta en la base de datos
        Try
            connection.Open()
            command.ExecuteNonQuery()
            lblEstado.Text = "Usuario insertado con éxito."
            CargarUsuarios()
            LimpiarCampos()
        Catch ex As Exception
            lblEstado.Text = "Error al insertar el usuario: " & ex.Message
        Finally
            connection.Close()
        End Try
    End Sub

    ' Método para editar un usuario
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim errores As New List(Of String)

        If Not ValidarCampos(errores, isEditar:=True) Then
            ' Si hay errores, mostramos una ventana con todos los mensajes
            MessageBox.Show(String.Join(Environment.NewLine, errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If lblUsuarioId.Text = "" Then
            lblEstado.Text = "Seleccione un usuario para editar."
            Return
        End If

        ' Preparar el comando para ejecutar el procedimiento almacenado
        Dim command As New SqlCommand("sp_EditarUsuario", connection)
        command.CommandType = CommandType.StoredProcedure

        ' Añadir los parámetros al procedimiento
        command.Parameters.AddWithValue("@UsuarioID", lblUsuarioId.Text)
        command.Parameters.AddWithValue("@NombreUsuario", txtNombreUsuario.Text)
        command.Parameters.AddWithValue("@Correo", txtCorreo.Text)
        command.Parameters.AddWithValue("@Tipo", cmbTipo.SelectedItem.ToString())
        command.Parameters.AddWithValue("@Activo", If(chkActivo.Checked, 1, 0))
        command.Parameters.AddWithValue("@EsFijo", If(chkEsFijo.Checked, 1, 0))

        ' Verificar si la contraseña no está vacía y añadirla solo si es necesario
        If Not String.IsNullOrEmpty(txtContrasena.Text) Then
            command.Parameters.AddWithValue("@Contrasena", txtContrasena.Text)
        Else
            ' Si la contraseña está vacía, no enviarla
            command.Parameters.AddWithValue("@Contrasena", DBNull.Value)
        End If

        Try
            connection.Open()
            command.ExecuteNonQuery()
            lblEstado.Text = "Usuario editado con éxito."
            CargarUsuarios()
            LimpiarCampos()
        Catch ex As Exception
            lblEstado.Text = "Error al editar el usuario: " & ex.Message
        Finally
            connection.Close()
        End Try
    End Sub

    ' Modificado para acumular errores en una lista
    Private Function ValidarCampos(ByRef errores As List(Of String), isEditar As Boolean) As Boolean
        ' Validar campos vacíos
        If String.IsNullOrWhiteSpace(txtNombreUsuario.Text) Then
            errores.Add("El nombre de usuario es obligatorio.")
        End If

        ' Validar contraseñas solo si es creación (no en edición)
        If Not isEditar Then
            If String.IsNullOrWhiteSpace(txtContrasena.Text) Then
                errores.Add("La contraseña es obligatoria.")
            ElseIf String.IsNullOrWhiteSpace(txtConfirmarContrasena.Text) OrElse txtConfirmarContrasena.Text = "Confirmar Contraseña" Then
                errores.Add("Por favor, confirme la contraseña.")
            ElseIf txtContrasena.Text <> txtConfirmarContrasena.Text Then
                errores.Add("Las contraseñas no coinciden.")
            End If
        End If

        ' Validar correo
        If String.IsNullOrWhiteSpace(txtCorreo.Text) Then
            errores.Add("El correo es obligatorio.")
        ElseIf Not EsCorreoValido(txtCorreo.Text) Then
            errores.Add("El formato del correo es inválido.")
        ElseIf VerificarCorreoDuplicado(lblUsuarioId.Text) Then
            errores.Add("El correo ya está registrado en otro usuario.")
        End If

        If cmbTipo.SelectedItem Is Nothing Then
            errores.Add("Debe seleccionar un tipo de usuario.")
        End If

        ' Si hay errores, devolver False
        Return errores.Count = 0
    End Function


    ' Método para eliminar un usuario
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If lblUsuarioId.Text = "" Then
            lblEstado.Text = "Seleccione un usuario para eliminar."
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Dim query As String = "DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@UsuarioID", lblUsuarioId.Text)

            Try
                connection.Open()
                command.ExecuteNonQuery()
                lblEstado.Text = "Usuario eliminado con éxito."
                CargarUsuarios()
                LimpiarCampos()
            Catch ex As Exception
                lblEstado.Text = "Error al eliminar el usuario: " & ex.Message
            Finally
                connection.Close()
            End Try
        End If
    End Sub



    ' Método para limpiar los campos, también ocultando el campo de confirmar contraseña
    Private Sub LimpiarCampos()
        txtNombreUsuario.Clear()
        txtCorreo.Clear()
        txtContrasena.Clear()
        txtConfirmarContrasena.ResetText()
        cmbTipo.SelectedIndex = -1
        chkActivo.Checked = False
        chkEsFijo.Checked = False
        lblUsuarioId.Text = ""
        lblEstado.Text = " "
    End Sub

    ' Verificar si el correo ya está registrado
    Private Function VerificarCorreoDuplicado(Optional ByVal usuarioID As String = "") As Boolean
        Dim query As String
        If String.IsNullOrEmpty(usuarioID) Then
            query = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @Correo"
        Else
            query = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @Correo AND UsuarioID <> @UsuarioID"
        End If
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@Correo", txtCorreo.Text)
        If Not String.IsNullOrEmpty(usuarioID) Then
            command.Parameters.AddWithValue("@UsuarioID", usuarioID)
        End If

        Dim count As Integer = 0
        Try
            connection.Open()
            count = Convert.ToInt32(command.ExecuteScalar())
        Catch ex As Exception
            lblEstado.Text = "Error al verificar el correo: " & ex.Message
        Finally
            connection.Close()
        End Try

        Return count > 0
    End Function

    ' Validar el formato del correo
    Private Function EsCorreoValido(correo As String) As Boolean
        Dim regex As New Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
        Return regex.IsMatch(correo)
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarCampos()
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        ' Mensaje de ayuda
        Dim mensaje As String = "Este formulario permite editar los datos de un usuario en el sistema." & vbCrLf & vbCrLf &
                            "Pasos para editar un usuario:" & vbCrLf &
                            "1. Selecciona un usuario de la lista." & vbCrLf &
                            "2. Modifica los campos deseados (Nombre, Correo, Tipo, etc.)." & vbCrLf &
                            "3. Si deseas cambiar la contraseña, ingresa una nueva en los campos de Contraseña y Confirmar Contraseña." & vbCrLf &
                            "4. Marca la casilla 'Activo' si deseas activar al usuario, o desmárcala para desactivarlo." & vbCrLf &
                            "5. Haz clic en 'Guardar' para aplicar los cambios o 'Cancelar' para descartarlos." & vbCrLf &
                            "6. Si la contraseña no se ingresa o está vacía, no se actualizará."

        ' Mostrar el mensaje de ayuda
        MessageBox.Show(mensaje, "Ayuda - Edición de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
