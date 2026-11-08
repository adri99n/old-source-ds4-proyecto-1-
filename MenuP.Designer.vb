<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuP
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnHistorialNominas = New Button()
        btnconf = New Button()
        btnSalir = New Button()
        btnAyuda = New Button()
        btnEmpleadosNomina = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' btnHistorialNominas
        ' 
        btnHistorialNominas.Location = New Point(821, 379)
        btnHistorialNominas.Margin = New Padding(3, 4, 3, 4)
        btnHistorialNominas.Name = "btnHistorialNominas"
        btnHistorialNominas.Size = New Size(181, 51)
        btnHistorialNominas.TabIndex = 11
        btnHistorialNominas.Text = "Historial de Nóminas"
        btnHistorialNominas.UseVisualStyleBackColor = True
        ' 
        ' btnconf
        ' 
        btnconf.Location = New Point(821, 476)
        btnconf.Margin = New Padding(3, 4, 3, 4)
        btnconf.Name = "btnconf"
        btnconf.Size = New Size(181, 51)
        btnconf.TabIndex = 10
        btnconf.Text = "Configuracion"
        btnconf.UseVisualStyleBackColor = True
        ' 
        ' btnSalir
        ' 
        btnSalir.Location = New Point(963, 580)
        btnSalir.Margin = New Padding(3, 4, 3, 4)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(86, 31)
        btnSalir.TabIndex = 9
        btnSalir.Text = "Salir"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' btnAyuda
        ' 
        btnAyuda.Location = New Point(789, 580)
        btnAyuda.Margin = New Padding(3, 4, 3, 4)
        btnAyuda.Name = "btnAyuda"
        btnAyuda.Size = New Size(86, 31)
        btnAyuda.TabIndex = 8
        btnAyuda.Text = "Ayuda"
        btnAyuda.UseVisualStyleBackColor = True
        ' 
        ' btnEmpleadosNomina
        ' 
        btnEmpleadosNomina.ForeColor = SystemColors.ActiveCaptionText
        btnEmpleadosNomina.Location = New Point(821, 277)
        btnEmpleadosNomina.Margin = New Padding(3, 4, 3, 4)
        btnEmpleadosNomina.Name = "btnEmpleadosNomina"
        btnEmpleadosNomina.Size = New Size(181, 51)
        btnEmpleadosNomina.TabIndex = 12
        btnEmpleadosNomina.Text = "Empleados y Calculos de Nómina"
        btnEmpleadosNomina.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(720, 56)
        Label1.Name = "Label1"
        Label1.Size = New Size(413, 180)
        Label1.TabIndex = 13
        Label1.Text = "Módulo de Gestión " & vbCrLf & "de" & vbCrLf & "Nómina"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' MenuP
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Diseño_sin_título
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1159, 681)
        Controls.Add(Label1)
        Controls.Add(btnEmpleadosNomina)
        Controls.Add(btnHistorialNominas)
        Controls.Add(btnconf)
        Controls.Add(btnSalir)
        Controls.Add(btnAyuda)
        DoubleBuffered = True
        Margin = New Padding(3, 4, 3, 4)
        Name = "MenuP"
        Text = "MenuP"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnHistorialNominas As Button
    Friend WithEvents btnconf As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAyuda As Button
    Friend WithEvents btnEmpleadosNomina As Button
    Friend WithEvents Label1 As Label
End Class
