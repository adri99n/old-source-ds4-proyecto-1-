<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        PanelPrincipal = New Panel()
        txtContra = New TextBox()
        txtUser = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        btnLogin = New Button()
        SuspendLayout()
        ' 
        ' PanelPrincipal
        ' 
        PanelPrincipal.BackColor = Color.Transparent
        PanelPrincipal.BackgroundImageLayout = ImageLayout.None
        PanelPrincipal.Location = New Point(0, 0)
        PanelPrincipal.Margin = New Padding(3, 4, 3, 4)
        PanelPrincipal.Name = "PanelPrincipal"
        PanelPrincipal.Size = New Size(1157, 746)
        PanelPrincipal.TabIndex = 22
        ' 
        ' txtContra
        ' 
        txtContra.Location = New Point(859, 472)
        txtContra.Margin = New Padding(3, 4, 3, 4)
        txtContra.Name = "txtContra"
        txtContra.Size = New Size(259, 27)
        txtContra.TabIndex = 30
        ' 
        ' txtUser
        ' 
        txtUser.Location = New Point(859, 403)
        txtUser.Margin = New Padding(3, 4, 3, 4)
        txtUser.Name = "txtUser"
        txtUser.Size = New Size(259, 27)
        txtUser.TabIndex = 29
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(707, 469)
        Label4.Name = "Label4"
        Label4.Size = New Size(114, 28)
        Label4.TabIndex = 28
        Label4.Text = "Contraseña:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(707, 400)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 28)
        Label3.TabIndex = 27
        Label3.Text = "Usuario:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(848, 319)
        Label2.Name = "Label2"
        Label2.Size = New Size(141, 28)
        Label2.TabIndex = 24
        Label2.Text = "Ingresar como:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(725, 67)
        Label1.Name = "Label1"
        Label1.Size = New Size(413, 180)
        Label1.TabIndex = 23
        Label1.Text = "Módulo de Gestión " & vbCrLf & "de" & vbCrLf & "Nómina"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(829, 589)
        btnLogin.Margin = New Padding(3, 4, 3, 4)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(181, 51)
        btnLogin.TabIndex = 31
        btnLogin.Text = "Iniciar Sesion"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Diseño_sin_título
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1139, 746)
        Controls.Add(PanelPrincipal)
        Controls.Add(txtContra)
        Controls.Add(txtUser)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnLogin)
        DoubleBuffered = True
        Margin = New Padding(3, 4, 3, 4)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents PanelPrincipal As Panel
    Friend WithEvents txtContra As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLogin As Button

End Class
