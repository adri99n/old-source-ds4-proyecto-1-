Imports System.Data.SqlClient
Public Class Form1
    Private Shared _instancia As Form1
    Private intentosRestantes As Integer = 3 ' Número máximo de intentos permitidos

    Public Sub New()
        InitializeComponent()
        _instancia = Me
    End Sub

    Public Shared ReadOnly Property Instancia As Form1
        Get
            Return _instancia
        End Get
    End Property

    ' Método para cargar formularios en el panel
    Public Sub CargarFormularioEnPanel(form As Form)
        form.TopLevel = False
        form.FormBorderStyle = FormBorderStyle.None
        form.Dock = DockStyle.Fill
        PanelPrincipal.Controls.Clear()
        PanelPrincipal.Controls.Add(form)
        form.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelPrincipal.Visible = False


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
    Private Sub BorrarCampos()
        txtUser.Clear()
        txtContra.Clear()
    End Sub

    ' Botón único para validar credenciales y abrir el menú correspondiente
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim mensaje As String
        Dim tipoUsuario As String = DeterminarTipoUsuario(txtUser.Text.Trim(), txtContra.Text, mensaje)

        If Not String.IsNullOrEmpty(tipoUsuario) Then
            My.Settings.TipoUsuario = tipoUsuario ' Asigna el tipo de usuario

            Select Case tipoUsuario
                Case "Usuario"
                    Dim menuUsuario As New MenuP()
                    PanelPrincipal.Visible = True
                    CargarFormularioEnPanel(menuUsuario)
                Case "Administrador"
                    Dim adminMenu As New FormAdminMenu()
                    PanelPrincipal.Visible = True
                    CargarFormularioEnPanel(adminMenu)
                Case Else
                    MessageBox.Show("Tipo de usuario desconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
        Else
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        BorrarCampos()
    End Sub

    ' Método para determinar el tipo de usuario según las credenciales
    Private Function DeterminarTipoUsuario(usuario As String, contrasena As String, ByRef mensaje As String) As String
        If String.IsNullOrEmpty(usuario) Or String.IsNullOrEmpty(contrasena) Then
            mensaje = "Por favor, llene todos los campos."
            Return Nothing
        End If

        Using conn As New SqlConnection(My.Settings.BD)
            Using cmd As New SqlCommand("sp_VerificarUsuario", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@NombreUsuario", usuario)
                cmd.Parameters.AddWithValue("@Contrasena", If(String.IsNullOrEmpty(contrasena), DBNull.Value, contrasena))
                cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output

                conn.Open()
                cmd.ExecuteNonQuery()

                Dim resultado As Integer = Convert.ToInt32(cmd.Parameters("@Resultado").Value)
                Dim tipoUsuario As String = cmd.Parameters("@Tipo").Value?.ToString()

                Select Case resultado
                    Case 0 ' Usuario inactivo
                        mensaje = "El usuario ha sido desactivado por demasiados intentos fallidos. Contacte al administrador."
                        Return Nothing
                    Case 1 ' Usuario válido
                        mensaje = "Bienvenido."
                        Return tipoUsuario
                    Case 2 ' Usuario no encontrado
                        mensaje = "Usuario no encontrado. Intente de nuevo o contacte al administrador."
                    Case 3 ' Contraseña incorrecta
                        intentosRestantes -= 1
                        If intentosRestantes > 0 Then
                            mensaje = $"Usuario o contraseña incorrectos. Intentos restantes: {intentosRestantes}."
                        Else
                            mensaje = "Número máximo de intentos alcanzado. El usuario ha sido desactivado. Contacte al administrador."
                        End If
                        Return Nothing
                    Case 4 ' Campos vacíos
                        mensaje = "Sin espacios en blanco."
                        Return Nothing
                    Case Else ' Error desconocido
                        mensaje = "Ocurrió un error inesperado. Intente de nuevo más tarde."
                        Return Nothing
                End Select
            End Using
        End Using
    End Function

End Class
