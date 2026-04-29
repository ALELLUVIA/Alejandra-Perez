<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        GroupBox1 = New GroupBox()
        txtNombre = New TextBox()
        Label3 = New Label()
        txtIdEstado = New TextBox()
        Label2 = New Label()
        DateTimePicker1 = New DateTimePicker()
        DataGridView1 = New DataGridView()
        GroupBox2 = New GroupBox()
        btnInsertar = New Button()
        btnEditar = New Button()
        btnEliminar = New Button()
        txtLimpiar = New Button()
        GroupBox1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bernard MT Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DarkViolet
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(109, 36)
        Label1.TabIndex = 0
        Label1.Text = "ESTADOS"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txtNombre)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(txtIdEstado)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Location = New Point(12, 126)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(364, 116)
        GroupBox1.TabIndex = 2
        GroupBox1.TabStop = False
        GroupBox1.Text = "Campo de Datos"
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(153, 78)
        txtNombre.MaxLength = 20
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(125, 27)
        txtNombre.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Bernard MT Condensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(33, 78)
        Label3.Name = "Label3"
        Label3.Size = New Size(67, 21)
        Label3.TabIndex = 2
        Label3.Text = "NOMBRE"
        ' 
        ' txtIdEstado
        ' 
        txtIdEstado.Location = New Point(153, 38)
        txtIdEstado.MaxLength = 5
        txtIdEstado.Name = "txtIdEstado"
        txtIdEstado.Size = New Size(125, 27)
        txtIdEstado.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Bernard MT Condensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(33, 38)
        Label2.Name = "Label2"
        Label2.Size = New Size(81, 21)
        Label2.TabIndex = 0
        Label2.Text = "ID ESTADO"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.CalendarForeColor = SystemColors.ActiveCaption
        DateTimePicker1.CalendarMonthBackground = SystemColors.MenuBar
        DateTimePicker1.CalendarTitleForeColor = SystemColors.ActiveCaption
        DateTimePicker1.Location = New Point(471, 18)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(277, 27)
        DateTimePicker1.TabIndex = 3
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(43, 21)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(276, 162)
        DataGridView1.TabIndex = 4
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(DataGridView1)
        GroupBox2.Location = New Point(393, 81)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(355, 204)
        GroupBox2.TabIndex = 5
        GroupBox2.TabStop = False
        GroupBox2.Text = "LISTADO"
        ' 
        ' btnInsertar
        ' 
        btnInsertar.BackColor = Color.Khaki
        btnInsertar.Font = New Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnInsertar.Location = New Point(165, 329)
        btnInsertar.Name = "btnInsertar"
        btnInsertar.Size = New Size(94, 29)
        btnInsertar.TabIndex = 6
        btnInsertar.Text = "INSERTAR"
        btnInsertar.UseVisualStyleBackColor = False
        ' 
        ' btnEditar
        ' 
        btnEditar.BackColor = Color.Plum
        btnEditar.Font = New Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnEditar.Location = New Point(330, 329)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(100, 29)
        btnEditar.TabIndex = 7
        btnEditar.Text = "MODIFICAR"
        btnEditar.UseVisualStyleBackColor = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.BackColor = Color.Salmon
        btnEliminar.Font = New Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnEliminar.Location = New Point(518, 329)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(94, 29)
        btnEliminar.TabIndex = 8
        btnEliminar.Text = "ELIMINAR"
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' txtLimpiar
        ' 
        txtLimpiar.BackColor = SystemColors.ActiveCaption
        txtLimpiar.Font = New Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtLimpiar.Location = New Point(18, 256)
        txtLimpiar.Name = "txtLimpiar"
        txtLimpiar.Size = New Size(94, 29)
        txtLimpiar.TabIndex = 10
        txtLimpiar.Text = "LIMPIAR"
        txtLimpiar.UseVisualStyleBackColor = False
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(760, 417)
        Controls.Add(txtLimpiar)
        Controls.Add(btnEliminar)
        Controls.Add(btnEditar)
        Controls.Add(btnInsertar)
        Controls.Add(GroupBox2)
        Controls.Add(DateTimePicker1)
        Controls.Add(GroupBox1)
        Controls.Add(Label1)
        Name = "Form2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "MENU"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtIdEstado As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnInsertar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents txtLimpiar As Button
End Class
