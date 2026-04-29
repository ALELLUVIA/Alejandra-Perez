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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Panel1 = New Panel()
        Button1 = New Button()
        Label1 = New Label()
        Label2 = New Label()
        TxtUsuario = New TextBox()
        TxtContraseña = New TextBox()
        PictureBox1 = New PictureBox()
        btninicio = New Button()
        VerContraseña = New PictureBox()
        NoVerContraseña = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(VerContraseña, ComponentModel.ISupportInitialize).BeginInit()
        CType(NoVerContraseña, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ActiveCaption
        Panel1.Controls.Add(Button1)
        Panel1.Location = New Point(2, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(488, 30)
        Panel1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.WhiteSmoke
        Button1.ForeColor = SystemColors.ControlText
        Button1.Location = New Point(435, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(50, 24)
        Button1.TabIndex = 1
        Button1.Text = "X"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(208, 105)
        Label1.Name = "Label1"
        Label1.Size = New Size(59, 20)
        Label1.TabIndex = 1
        Label1.Text = "Usuario"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(208, 163)
        Label2.Name = "Label2"
        Label2.Size = New Size(83, 20)
        Label2.TabIndex = 2
        Label2.Text = "Contraseña"
        ' 
        ' TxtUsuario
        ' 
        TxtUsuario.Location = New Point(296, 98)
        TxtUsuario.Name = "TxtUsuario"
        TxtUsuario.Size = New Size(125, 27)
        TxtUsuario.TabIndex = 3
        ' 
        ' TxtContraseña
        ' 
        TxtContraseña.Location = New Point(297, 160)
        TxtContraseña.Name = "TxtContraseña"
        TxtContraseña.PasswordChar = "*"c
        TxtContraseña.Size = New Size(125, 27)
        TxtContraseña.TabIndex = 4
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(22, 75)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(180, 137)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' btninicio
        ' 
        btninicio.Location = New Point(277, 220)
        btninicio.Name = "btninicio"
        btninicio.Size = New Size(94, 29)
        btninicio.TabIndex = 7
        btninicio.Text = "Ingresar"
        btninicio.UseVisualStyleBackColor = True
        ' 
        ' VerContraseña
        ' 
        VerContraseña.Image = My.Resources.Resources.ojo1
        VerContraseña.Location = New Point(428, 163)
        VerContraseña.Name = "VerContraseña"
        VerContraseña.Size = New Size(34, 23)
        VerContraseña.SizeMode = PictureBoxSizeMode.Zoom
        VerContraseña.TabIndex = 8
        VerContraseña.TabStop = False
        ' 
        ' NoVerContraseña
        ' 
        NoVerContraseña.Image = My.Resources.Resources.ojo2
        NoVerContraseña.Location = New Point(428, 163)
        NoVerContraseña.Name = "NoVerContraseña"
        NoVerContraseña.Size = New Size(34, 30)
        NoVerContraseña.SizeMode = PictureBoxSizeMode.Zoom
        NoVerContraseña.TabIndex = 9
        NoVerContraseña.TabStop = False
        NoVerContraseña.Visible = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(489, 261)
        Controls.Add(NoVerContraseña)
        Controls.Add(VerContraseña)
        Controls.Add(btninicio)
        Controls.Add(PictureBox1)
        Controls.Add(TxtContraseña)
        Controls.Add(TxtUsuario)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        Panel1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(VerContraseña, ComponentModel.ISupportInitialize).EndInit()
        CType(NoVerContraseña, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtUsuario As TextBox
    Friend WithEvents TxtContraseña As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btninicio As Button
    Friend WithEvents VerContraseña As PictureBox
    Friend WithEvents NoVerContraseña As PictureBox

End Class
