<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAdminMenu
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
        Label1 = New Label()
        btnUserPermisos = New Button()
        btnMenuP = New Button()
        btnSalir = New Button()
        btnAyuda = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(719, 56)
        Label1.Name = "Label1"
        Label1.Size = New Size(413, 180)
        Label1.TabIndex = 14
        Label1.Text = "Módulo de Gestión " & vbCrLf & "de" & vbCrLf & "Nómina"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' btnUserPermisos
        ' 
        btnUserPermisos.Location = New Point(808, 325)
        btnUserPermisos.Margin = New Padding(3, 4, 3, 4)
        btnUserPermisos.Name = "btnUserPermisos"
        btnUserPermisos.Size = New Size(181, 79)
        btnUserPermisos.TabIndex = 18
        btnUserPermisos.Text = "Usuarios " & vbCrLf & "Y " & vbCrLf & "Permisos"
        btnUserPermisos.UseVisualStyleBackColor = True
        ' 
        ' btnMenuP
        ' 
        btnMenuP.Location = New Point(808, 461)
        btnMenuP.Margin = New Padding(3, 4, 3, 4)
        btnMenuP.Name = "btnMenuP"
        btnMenuP.Size = New Size(181, 51)
        btnMenuP.TabIndex = 17
        btnMenuP.Text = "Menu Principal"
        btnMenuP.UseVisualStyleBackColor = True
        ' 
        ' btnSalir
        ' 
        btnSalir.Location = New Point(951, 565)
        btnSalir.Margin = New Padding(3, 4, 3, 4)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(86, 31)
        btnSalir.TabIndex = 16
        btnSalir.Text = "Salir"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' btnAyuda
        ' 
        btnAyuda.Location = New Point(776, 565)
        btnAyuda.Margin = New Padding(3, 4, 3, 4)
        btnAyuda.Name = "btnAyuda"
        btnAyuda.Size = New Size(86, 31)
        btnAyuda.TabIndex = 15
        btnAyuda.Text = "Ayuda"
        btnAyuda.UseVisualStyleBackColor = True
        ' 
        ' FormAdminMenu
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = My.Resources.Resources.Diseño_sin_título
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1159, 681)
        Controls.Add(btnUserPermisos)
        Controls.Add(btnMenuP)
        Controls.Add(btnSalir)
        Controls.Add(btnAyuda)
        Controls.Add(Label1)
        DoubleBuffered = True
        Margin = New Padding(3, 4, 3, 4)
        Name = "FormAdminMenu"
        Text = "FormAdminMenu"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnUserPermisos As Button
    Friend WithEvents btnMenuP As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAyuda As Button
End Class
