<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConfiguracion
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
        cmbFormatoExportacion = New ComboBox()
        btnGuardar = New Button()
        Label1 = New Label()
        btnSalir = New Button()
        btnAyuda = New Button()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' cmbFormatoExportacion
        ' 
        cmbFormatoExportacion.FormattingEnabled = True
        cmbFormatoExportacion.Location = New Point(516, 113)
        cmbFormatoExportacion.Name = "cmbFormatoExportacion"
        cmbFormatoExportacion.Size = New Size(121, 23)
        cmbFormatoExportacion.TabIndex = 0
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(723, 343)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(133, 40)
        btnGuardar.TabIndex = 1
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.White
        Label1.Font = New Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlText
        Label1.Location = New Point(62, 191)
        Label1.Name = "Label1"
        Label1.Size = New Size(338, 130)
        Label1.TabIndex = 2
        Label1.Text = "Configuracion " & vbCrLf & "General"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnSalir
        ' 
        btnSalir.BackColor = Color.White
        btnSalir.Location = New Point(258, 423)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(102, 55)
        btnSalir.TabIndex = 11
        btnSalir.Text = "Salir"
        btnSalir.UseVisualStyleBackColor = False
        ' 
        ' btnAyuda
        ' 
        btnAyuda.BackColor = Color.White
        btnAyuda.Location = New Point(105, 423)
        btnAyuda.Name = "btnAyuda"
        btnAyuda.Size = New Size(102, 55)
        btnAyuda.TabIndex = 10
        btnAyuda.Text = "Ayuda"
        btnAyuda.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(516, 79)
        Label2.Name = "Label2"
        Label2.Size = New Size(159, 21)
        Label2.TabIndex = 12
        Label2.Text = "Formato de Reportes:"
        ' 
        ' FormConfiguracion
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Diseño_sin_título__5_
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1014, 511)
        Controls.Add(Label2)
        Controls.Add(btnSalir)
        Controls.Add(btnAyuda)
        Controls.Add(Label1)
        Controls.Add(btnGuardar)
        Controls.Add(cmbFormatoExportacion)
        DoubleBuffered = True
        Name = "FormConfiguracion"
        Text = "FormConfiguracion"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cmbFormatoExportacion As ComboBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAyuda As Button
    Friend WithEvents Label2 As Label
End Class
