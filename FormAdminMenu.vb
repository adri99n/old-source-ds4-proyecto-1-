Public Class FormAdminMenu

    Private Sub btnUserPermisos_Click(sender As Object, e As EventArgs) Handles btnUserPermisos.Click
        Dim menuUsuario As New FormUsuarios() ' Pasamos FormAdminMenu como origen
        menuUsuario.Show()
        Form1.Instancia.PanelPrincipal.Visible = True
        Form1.Instancia.CargarFormularioEnPanel(menuUsuario)
    End Sub

    Private Sub btnMenuP_Click(sender As Object, e As EventArgs) Handles btnMenuP.Click
        Dim menuPrincipal As New MenuP() ' Pasamos FormAdminMenu como origen
        menuPrincipal.Show()
        Form1.Instancia.PanelPrincipal.Visible = True
        Form1.Instancia.CargarFormularioEnPanel(menuPrincipal)
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Hide()
        Form1.Instancia.PanelPrincipal.Hide()
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Dim mensaje As String = "Instrucciones para la ventana:" & vbCrLf &
                                "1. Opcion 1: Mostrara una lista de todos los usuarios en conjunto con sus permisos. En esta ventana usted podra agregar, editar y eliminar usuaios." & vbCrLf &
                                "2. Opcion 2: Le llevara al menu principal donde podra ver a todos los empleados, calcular la nomina, ver reportes y mas." & vbCrLf &
                                "3. Use el botón 'Salir' para regresar."
        MessageBox.Show(mensaje, "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub FormAdminMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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