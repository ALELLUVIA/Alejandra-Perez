Imports System.Data.SqlClient


Public Class Form1


    Private Sub VerContraseña_Click(sender As Object, e As EventArgs) Handles VerContraseña.Click
        'Al oprimir el icono Ver contraseña, esta se mostrara

        TxtContraseña.PasswordChar = "" 'mostrar las contraseñas
        VerContraseña.Visible = False   'ocultar el boton verContraseña
        NoVerContraseña.Visible = True  'Mostrar el boton noVerContraseña
    End Sub

    Private Sub NoVerContraseña_Click(sender As Object, e As EventArgs) Handles NoVerContraseña.Click
        'al oprimir el icono NoVerContraseña, la contraseña se ocultara
        TxtContraseña.PasswordChar = "*"    'ocultar la contraseña mostrando asteriscos
        VerContraseña.Visible = True    'mostrar el boton verContraseña
        NoVerContraseña.Visible = False 'ocultar e boton novercontraseña

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close() ' Al hacer clic en la X se cerrara el formulario
    End Sub

    Private Sub Btninicio_Click(sender As Object, e As EventArgs) Handles btninicio.Click
        'al dar clic en el boton ingresar, se intentara iniciar sesion
        Dim cn As New SqlConnection("server=LLUVIA-LAP\SQLEXPRESS;Initial Catalog=My_reportedebaches;user ID=User1_abd;Password=User1_abd") 'establecer la conexion a la base de datos
        Dim sql As String
        sql = "select * from Usuarios where Nombre='" & TxtUsuario.Text & "'and id_Usuario='" & TxtContraseña.Text & "'"   'construir la consulta SQL para buscar el usuario con el nombre y la contraseña con id_Asistente
        Dim cmd As New SqlCommand(sql, cn)  'crear un nuevo comando sql con la consulta y la conexion
        Dim dr As SqlDataReader 'se declara una variable para leer los resultados de la consulta
        cn.Open()   'abrir la conexion a la base de datos
        dr = cmd.ExecuteReader  'ejecutar la consulta y leer los resultados
        If dr.Read = True Then  'si se encuentra el usuario y contraseña ingresados
            Form2.Show()
            AddHandler Form2.FormClosed, AddressOf Form2_Closed ' Manejar el evento FormClosed de Form2
            Me.Hide() ' Ocultar Form1
        Else
            MsgBox("USUARIO O CONTRASEÑA INCORRECTOS")
        End If
    End Sub

    Private Sub Form2_Closed(sender As Object, e As EventArgs)
        ' Cuando se cierre Form2, mostrar nuevamente Form1
        Me.Show()
    End Sub



End Class
