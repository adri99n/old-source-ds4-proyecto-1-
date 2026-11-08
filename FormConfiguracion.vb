Public Class FormConfiguracion

    Private Sub FormConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbFormatoExportacion.Items.AddRange({"Excel", "PDF"})
        cmbFormatoExportacion.SelectedItem = My.Settings.FormatoExportacion

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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim formatoSeleccionado As String = cmbFormatoExportacion.SelectedItem.ToString()
        My.Settings.FormatoExportacion = formatoSeleccionado
        My.Settings.Save()
        MessageBox.Show("Configuración guardada exitosamente.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Form1.Instancia.CargarFormularioEnPanel(Form1.Instancia)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim formMenuP As New MenuP()
        Form1.Instancia.CargarFormularioEnPanel(formMenuP)
    End Sub
End Class