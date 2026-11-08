<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpleados
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
        lblEmpleadoID = New Label()
        Label5 = New Label()
        btnSalir = New Button()
        btnAyuda = New Button()
        btnLimpiar = New Button()
        btnEliminar = New Button()
        btnEditar = New Button()
        btnAgregar = New Button()
        chkAplicaDescuentos = New CheckBox()
        Label4 = New Label()
        cmbTipoContrato = New ComboBox()
        Label3 = New Label()
        txtSalarioBase = New TextBox()
        Label2 = New Label()
        txtCargo = New TextBox()
        Label1 = New Label()
        txtNombre = New TextBox()
        dgvEmpleados = New DataGridView()
        dtpFechaInicio = New DateTimePicker()
        Label6 = New Label()
        chkActivo = New CheckBox()
        btnCrearNomina = New Button()
        btnhistorial = New Button()
        Label7 = New Label()
        DateTimePickerFechaPago = New DateTimePicker()
        lblPeriodo = New Label()
        Label8 = New Label()
        CType(dgvEmpleados, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblEmpleadoID
        ' 
        lblEmpleadoID.AutoSize = True
        lblEmpleadoID.BackColor = Color.Transparent
        lblEmpleadoID.Location = New Point(98, 23)
        lblEmpleadoID.Name = "lblEmpleadoID"
        lblEmpleadoID.Size = New Size(0, 20)
        lblEmpleadoID.TabIndex = 43
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Location = New Point(39, 23)
        Label5.Name = "Label5"
        Label5.Size = New Size(27, 20)
        Label5.TabIndex = 42
        Label5.Text = "ID:"
        ' 
        ' btnSalir
        ' 
        btnSalir.Location = New Point(167, 617)
        btnSalir.Margin = New Padding(3, 4, 3, 4)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(121, 43)
        btnSalir.TabIndex = 40
        btnSalir.Text = "Salir"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' btnAyuda
        ' 
        btnAyuda.Location = New Point(39, 617)
        btnAyuda.Margin = New Padding(3, 4, 3, 4)
        btnAyuda.Name = "btnAyuda"
        btnAyuda.Size = New Size(121, 43)
        btnAyuda.TabIndex = 39
        btnAyuda.Text = "Ayuda"
        btnAyuda.UseVisualStyleBackColor = True
        ' 
        ' btnLimpiar
        ' 
        btnLimpiar.Location = New Point(167, 559)
        btnLimpiar.Margin = New Padding(3, 4, 3, 4)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(121, 43)
        btnLimpiar.TabIndex = 38
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Location = New Point(39, 559)
        btnEliminar.Margin = New Padding(3, 4, 3, 4)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(121, 43)
        btnEliminar.TabIndex = 37
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(167, 496)
        btnEditar.Margin = New Padding(3, 4, 3, 4)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(121, 43)
        btnEditar.TabIndex = 36
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Location = New Point(39, 496)
        btnAgregar.Margin = New Padding(3, 4, 3, 4)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(121, 43)
        btnAgregar.TabIndex = 35
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' chkAplicaDescuentos
        ' 
        chkAplicaDescuentos.AutoSize = True
        chkAplicaDescuentos.BackColor = Color.Transparent
        chkAplicaDescuentos.Location = New Point(39, 451)
        chkAplicaDescuentos.Margin = New Padding(3, 4, 3, 4)
        chkAplicaDescuentos.Name = "chkAplicaDescuentos"
        chkAplicaDescuentos.Size = New Size(147, 24)
        chkAplicaDescuentos.TabIndex = 33
        chkAplicaDescuentos.Text = "Aplica Descuento"
        chkAplicaDescuentos.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Location = New Point(37, 289)
        Label4.Name = "Label4"
        Label4.Size = New Size(125, 20)
        Label4.TabIndex = 32
        Label4.Text = "Tipo de Contrato:"
        ' 
        ' cmbTipoContrato
        ' 
        cmbTipoContrato.FormattingEnabled = True
        cmbTipoContrato.Location = New Point(37, 313)
        cmbTipoContrato.Margin = New Padding(3, 4, 3, 4)
        cmbTipoContrato.Name = "cmbTipoContrato"
        cmbTipoContrato.Size = New Size(230, 28)
        cmbTipoContrato.TabIndex = 31
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Location = New Point(37, 205)
        Label3.Name = "Label3"
        Label3.Size = New Size(93, 20)
        Label3.TabIndex = 30
        Label3.Text = "Salario Base:"
        ' 
        ' txtSalarioBase
        ' 
        txtSalarioBase.Location = New Point(37, 229)
        txtSalarioBase.Margin = New Padding(3, 4, 3, 4)
        txtSalarioBase.Name = "txtSalarioBase"
        txtSalarioBase.Size = New Size(230, 27)
        txtSalarioBase.TabIndex = 29
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Location = New Point(37, 125)
        Label2.Name = "Label2"
        Label2.Size = New Size(52, 20)
        Label2.TabIndex = 28
        Label2.Text = "Cargo:"
        ' 
        ' txtCargo
        ' 
        txtCargo.Location = New Point(37, 149)
        txtCargo.Margin = New Padding(3, 4, 3, 4)
        txtCargo.Name = "txtCargo"
        txtCargo.Size = New Size(230, 27)
        txtCargo.TabIndex = 27
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Location = New Point(39, 52)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 20)
        Label1.TabIndex = 26
        Label1.Text = "Nombre:"
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(39, 76)
        txtNombre.Margin = New Padding(3, 4, 3, 4)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(230, 27)
        txtNombre.TabIndex = 25
        ' 
        ' dgvEmpleados
        ' 
        dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvEmpleados.Location = New Point(362, 23)
        dgvEmpleados.Margin = New Padding(3, 4, 3, 4)
        dgvEmpleados.Name = "dgvEmpleados"
        dgvEmpleados.RowHeadersWidth = 51
        dgvEmpleados.Size = New Size(770, 564)
        dgvEmpleados.TabIndex = 24
        ' 
        ' dtpFechaInicio
        ' 
        dtpFechaInicio.Location = New Point(37, 397)
        dtpFechaInicio.Margin = New Padding(3, 4, 3, 4)
        dtpFechaInicio.Name = "dtpFechaInicio"
        dtpFechaInicio.Size = New Size(228, 27)
        dtpFechaInicio.TabIndex = 44
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Location = New Point(39, 373)
        Label6.Name = "Label6"
        Label6.Size = New Size(128, 20)
        Label6.TabIndex = 45
        Label6.Text = "Inicio de Contrato"
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.BackColor = Color.Transparent
        chkActivo.Location = New Point(184, 451)
        chkActivo.Margin = New Padding(3, 4, 3, 4)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(73, 24)
        chkActivo.TabIndex = 46
        chkActivo.Text = "Activo"
        chkActivo.UseVisualStyleBackColor = False
        ' 
        ' btnCrearNomina
        ' 
        btnCrearNomina.BackColor = Color.White
        btnCrearNomina.Location = New Point(954, 624)
        btnCrearNomina.Margin = New Padding(3, 4, 3, 4)
        btnCrearNomina.Name = "btnCrearNomina"
        btnCrearNomina.Size = New Size(154, 36)
        btnCrearNomina.TabIndex = 47
        btnCrearNomina.Text = "Calcular Nomina"
        btnCrearNomina.UseVisualStyleBackColor = False
        ' 
        ' btnhistorial
        ' 
        btnhistorial.BackColor = Color.White
        btnhistorial.Location = New Point(362, 632)
        btnhistorial.Margin = New Padding(3, 4, 3, 4)
        btnhistorial.Name = "btnhistorial"
        btnhistorial.Size = New Size(154, 36)
        btnhistorial.TabIndex = 48
        btnhistorial.Text = "Historial de Nominas"
        btnhistorial.UseVisualStyleBackColor = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.White
        Label7.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(545, 637)
        Label7.Name = "Label7"
        Label7.Size = New Size(125, 23)
        Label7.TabIndex = 50
        Label7.Text = "Fecha de Pago:"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' DateTimePickerFechaPago
        ' 
        DateTimePickerFechaPago.Location = New Point(676, 632)
        DateTimePickerFechaPago.Margin = New Padding(3, 4, 3, 4)
        DateTimePickerFechaPago.Name = "DateTimePickerFechaPago"
        DateTimePickerFechaPago.Size = New Size(260, 27)
        DateTimePickerFechaPago.TabIndex = 49
        ' 
        ' lblPeriodo
        ' 
        lblPeriodo.AutoSize = True
        lblPeriodo.BackColor = Color.White
        lblPeriodo.Location = New Point(663, 605)
        lblPeriodo.Name = "lblPeriodo"
        lblPeriodo.Size = New Size(53, 20)
        lblPeriodo.TabIndex = 51
        lblPeriodo.Text = "Label8"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.White
        Label8.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(545, 603)
        Label8.Name = "Label8"
        Label8.Size = New Size(72, 23)
        Label8.TabIndex = 52
        Label8.Text = "Periodo:"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' FormEmpleados
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Diseño_sin_título__6_
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1159, 684)
        Controls.Add(Label8)
        Controls.Add(lblPeriodo)
        Controls.Add(Label7)
        Controls.Add(DateTimePickerFechaPago)
        Controls.Add(btnhistorial)
        Controls.Add(btnCrearNomina)
        Controls.Add(chkActivo)
        Controls.Add(Label6)
        Controls.Add(dtpFechaInicio)
        Controls.Add(lblEmpleadoID)
        Controls.Add(Label5)
        Controls.Add(btnSalir)
        Controls.Add(btnAyuda)
        Controls.Add(btnLimpiar)
        Controls.Add(btnEliminar)
        Controls.Add(btnEditar)
        Controls.Add(btnAgregar)
        Controls.Add(chkAplicaDescuentos)
        Controls.Add(Label4)
        Controls.Add(cmbTipoContrato)
        Controls.Add(Label3)
        Controls.Add(txtSalarioBase)
        Controls.Add(Label2)
        Controls.Add(txtCargo)
        Controls.Add(Label1)
        Controls.Add(txtNombre)
        Controls.Add(dgvEmpleados)
        DoubleBuffered = True
        Margin = New Padding(3, 4, 3, 4)
        Name = "FormEmpleados"
        Text = "FormEmpleados"
        CType(dgvEmpleados, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblEmpleadoID As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAyuda As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents chkAplicaDescuentos As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbTipoContrato As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSalarioBase As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCargo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents dgvEmpleados As DataGridView
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents btnCrearNomina As Button
    Friend WithEvents btnhistorial As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents DateTimePickerFechaPago As DateTimePicker
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents Label8 As Label
End Class
