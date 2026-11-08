Public Class MenuP

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If My.Settings.TipoUsuario = "Administrador" Then
            Dim formAdmi As New FormAdminMenu()
            Form1.Instancia.CargarFormularioEnPanel(formAdmi)
        Else
            Me.Hide()
            Form1.Instancia.PanelPrincipal.Hide()
        End If
    End Sub



    ' Botón de configuraciones
    Private Sub btnconf_Click(sender As Object, e As EventArgs) Handles btnconf.Click
        Dim formConfiguraciones As New FormConfiguracion()
        Form1.Instancia.PanelPrincipal.Visible = True
        Form1.Instancia.CargarFormularioEnPanel(formConfiguraciones)
    End Sub

    ' Botón para ver historial de nóminas
    Private Sub btnHistorialNominas_Click(sender As Object, e As EventArgs) Handles btnHistorialNominas.Click
        Dim formHistNom As New FormReporte("Reporte Histórico", 0)
        Form1.Instancia.PanelPrincipal.Visible = True
        Form1.Instancia.CargarFormularioEnPanel(formHistNom)
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Dim mensaje As String = "Instrucciones para la ventana:" & vbCrLf &
                                "1. Opcion 1: Mostrara una lista de todos los empleados en conjunto con sus datos. En esta ventana usted podra agregar, editar y eliminar empleados." & vbCrLf &
                                "2. Opcion 2: Le llevara al histprial de nominas donde podra ver las diferentes nominas de acuerdo a su periodo y los detalles de las mismas." & vbCrLf &
                                "3. Use el botón 'Salir' para regresar."
        MessageBox.Show(mensaje, "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnEmpleadosNomina_Click(sender As Object, e As EventArgs) Handles btnEmpleadosNomina.Click
        Dim formEmpleados As New FormEmpleados
        Form1.Instancia.PanelPrincipal.Visible = True
        Form1.Instancia.CargarFormularioEnPanel(formEmpleados)
    End Sub

    Private Sub MenuP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
End Class
