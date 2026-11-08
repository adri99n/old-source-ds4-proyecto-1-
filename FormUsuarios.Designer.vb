<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUsuarios
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
        dgvUsuarios = New DataGridView()
        txtNombreUsuario = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        txtContrasena = New TextBox()
        Label3 = New Label()
        txtCorreo = New TextBox()
        cmbTipo = New ComboBox()
        Label4 = New Label()
        chkActivo = New CheckBox()
        chkEsFijo = New CheckBox()
        btnAgregar = New Button()
        btnEditar = New Button()
        btnLimpiar = New Button()
        btnEliminar = New Button()
        lblEstado = New Label()
        btnSalir = New Button()
        btnAyuda = New Button()
        txtConfirmarContrasena = New TextBox()
        Label5 = New Label()
        lblUsuarioId = New Label()
        CType(dgvUsuarios, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvUsuarios
        ' 
        dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUsuarios.Location = New Point(316, 24)
        dgvUsuarios.Name = "dgvUsuarios"
        dgvUsuarios.Size = New Size(674, 461)
        dgvUsuarios.TabIndex = 0
        ' 
        ' txtNombreUsuario
        ' 
        txtNombreUsuario.Location = New Point(43, 49)
        txtNombreUsuario.Name = "txtNombreUsuario"
        txtNombreUsuario.Size = New Size(202, 23)
        txtNombreUsuario.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Location = New Point(43, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(113, 15)
        Label1.TabIndex = 2
        Label1.Text = "Nombre de Usuario:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Location = New Point(43, 94)
        Label2.Name = "Label2"
        Label2.Size = New Size(70, 15)
        Label2.TabIndex = 4
        Label2.Text = "Contraseña:"
        ' 
        ' txtContrasena
        ' 
        txtContrasena.Location = New Point(43, 112)
        txtContrasena.Name = "txtContrasena"
        txtContrasena.Size = New Size(202, 23)
        txtContrasena.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Location = New Point(43, 159)
        Label3.Name = "Label3"
        Label3.Size = New Size(46, 15)
        Label3.TabIndex = 6
        Label3.Text = "Correo:"
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Location = New Point(43, 177)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(202, 23)
        txtCorreo.TabIndex = 5
        ' 
        ' cmbTipo
        ' 
        cmbTipo.FormattingEnabled = True
        cmbTipo.Location = New Point(43, 244)
        cmbTipo.Name = "cmbTipo"
        cmbTipo.Size = New Size(202, 23)
        cmbTipo.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Location = New Point(43, 226)
        Label4.Name = "Label4"
        Label4.Size = New Size(33, 15)
        Label4.TabIndex = 8
        Label4.Text = "Tipo:"
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.BackColor = Color.Transparent
        chkActivo.Location = New Point(64, 289)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(60, 19)
        chkActivo.TabIndex = 11
        chkActivo.Text = "Activo"
        chkActivo.UseVisualStyleBackColor = False
        ' 
        ' chkEsFijo
        ' 
        chkEsFijo.AutoSize = True
        chkEsFijo.BackColor = Color.Transparent
        chkEsFijo.Location = New Point(171, 289)
        chkEsFijo.Name = "chkEsFijo"
        chkEsFijo.Size = New Size(45, 19)
        chkEsFijo.TabIndex = 12
        chkEsFijo.Text = "Fijo"
        chkEsFijo.UseVisualStyleBackColor = False
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Location = New Point(43, 364)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(106, 32)
        btnAgregar.TabIndex = 13
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(155, 364)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(106, 32)
        btnEditar.TabIndex = 14
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnLimpiar
        ' 
        btnLimpiar.Location = New Point(155, 411)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(106, 32)
        btnLimpiar.TabIndex = 16
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Location = New Point(43, 411)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(106, 32)
        btnEliminar.TabIndex = 15
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' lblEstado
        ' 
        lblEstado.AutoSize = True
        lblEstado.BackColor = Color.Transparent
        lblEstado.Location = New Point(12, 315)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(0, 15)
        lblEstado.TabIndex = 17
        ' 
        ' btnSalir
        ' 
        btnSalir.Location = New Point(170, 449)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(75, 23)
        btnSalir.TabIndex = 20
        btnSalir.Text = "Salir"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' btnAyuda
        ' 
        btnAyuda.Location = New Point(59, 449)
        btnAyuda.Name = "btnAyuda"
        btnAyuda.Size = New Size(75, 23)
        btnAyuda.TabIndex = 19
        btnAyuda.Text = "Ayuda"
        btnAyuda.UseVisualStyleBackColor = True
        ' 
        ' txtConfirmarContrasena
        ' 
        txtConfirmarContrasena.Location = New Point(43, 133)
        txtConfirmarContrasena.Name = "txtConfirmarContrasena"
        txtConfirmarContrasena.Size = New Size(202, 23)
        txtConfirmarContrasena.TabIndex = 21
        txtConfirmarContrasena.Text = "Confirmar Contraseña"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Location = New Point(43, 9)
        Label5.Name = "Label5"
        Label5.Size = New Size(21, 15)
        Label5.TabIndex = 22
        Label5.Text = "ID:"
        ' 
        ' lblUsuarioId
        ' 
        lblUsuarioId.AutoSize = True
        lblUsuarioId.BackColor = Color.Transparent
        lblUsuarioId.Location = New Point(95, 9)
        lblUsuarioId.Name = "lblUsuarioId"
        lblUsuarioId.Size = New Size(0, 15)
        lblUsuarioId.TabIndex = 23
        ' 
        ' FormUsuarios
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Diseño_sin_título__6_
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1014, 511)
        Controls.Add(lblUsuarioId)
        Controls.Add(Label5)
        Controls.Add(txtConfirmarContrasena)
        Controls.Add(btnSalir)
        Controls.Add(btnAyuda)
        Controls.Add(lblEstado)
        Controls.Add(btnLimpiar)
        Controls.Add(btnEliminar)
        Controls.Add(btnEditar)
        Controls.Add(btnAgregar)
        Controls.Add(chkEsFijo)
        Controls.Add(chkActivo)
        Controls.Add(Label4)
        Controls.Add(cmbTipo)
        Controls.Add(Label3)
        Controls.Add(txtCorreo)
        Controls.Add(Label2)
        Controls.Add(txtContrasena)
        Controls.Add(Label1)
        Controls.Add(txtNombreUsuario)
        Controls.Add(dgvUsuarios)
        DoubleBuffered = True
        Name = "FormUsuarios"
        Text = "FormUsuarios"
        CType(dgvUsuarios, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvUsuarios As DataGridView
    Friend WithEvents txtNombreUsuario As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents chkEsFijo As CheckBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents lblEstado As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAyuda As Button
    Friend WithEvents txtConfirmarContrasena As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblUsuarioId As Label
End Class
