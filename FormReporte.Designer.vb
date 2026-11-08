<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReporte
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
        lblTitulo = New Label()
        dgvReporte = New DataGridView()
        btnExportarReporte = New Button()
        btnSalir = New Button()
        btnAyuda = New Button()
        cmbTipoReporte = New ComboBox()
        cmbPeriodoNomina = New ComboBox()
        CType(dgvReporte, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Location = New Point(85, 29)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(41, 15)
        lblTitulo.TabIndex = 0
        lblTitulo.Text = "Label1"
        ' 
        ' dgvReporte
        ' 
        dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReporte.Location = New Point(25, 101)
        dgvReporte.Name = "dgvReporte"
        dgvReporte.Size = New Size(962, 335)
        dgvReporte.TabIndex = 1
        ' 
        ' btnExportarReporte
        ' 
        btnExportarReporte.Location = New Point(265, 459)
        btnExportarReporte.Name = "btnExportarReporte"
        btnExportarReporte.Size = New Size(125, 21)
        btnExportarReporte.TabIndex = 2
        btnExportarReporte.Text = "Exportar"
        btnExportarReporte.UseVisualStyleBackColor = True
        ' 
        ' btnSalir
        ' 
        btnSalir.Location = New Point(752, 459)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(75, 23)
        btnSalir.TabIndex = 5
        btnSalir.Text = "Salir"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' btnAyuda
        ' 
        btnAyuda.Location = New Point(510, 459)
        btnAyuda.Name = "btnAyuda"
        btnAyuda.Size = New Size(75, 23)
        btnAyuda.TabIndex = 4
        btnAyuda.Text = "Ayuda"
        btnAyuda.UseVisualStyleBackColor = True
        ' 
        ' cmbTipoReporte
        ' 
        cmbTipoReporte.FormattingEnabled = True
        cmbTipoReporte.Location = New Point(265, 58)
        cmbTipoReporte.Name = "cmbTipoReporte"
        cmbTipoReporte.Size = New Size(149, 23)
        cmbTipoReporte.TabIndex = 7
        ' 
        ' cmbPeriodoNomina
        ' 
        cmbPeriodoNomina.FormattingEnabled = True
        cmbPeriodoNomina.Location = New Point(508, 58)
        cmbPeriodoNomina.Name = "cmbPeriodoNomina"
        cmbPeriodoNomina.Size = New Size(149, 23)
        cmbPeriodoNomina.TabIndex = 8
        ' 
        ' FormReporte
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1014, 511)
        Controls.Add(cmbPeriodoNomina)
        Controls.Add(cmbTipoReporte)
        Controls.Add(btnSalir)
        Controls.Add(btnAyuda)
        Controls.Add(btnExportarReporte)
        Controls.Add(dgvReporte)
        Controls.Add(lblTitulo)
        Name = "FormReporte"
        Text = "FormReporte"
        CType(dgvReporte, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents dgvReporte As DataGridView
    Friend WithEvents btnExportarReporte As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAyuda As Button
    Friend WithEvents cmbTipoReporte As ComboBox
    Friend WithEvents cmbPeriodoNomina As ComboBox
End Class
