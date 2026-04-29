Imports System.Data.SqlClient

Public Class CnxCrud
    ' Se define una conexión a la base de datos utilizando la clase SqlConnection.
    ' La cadena de conexión especifica el servidor, la base de datos y las credenciales de usuario.
    Public con As New SqlConnection("server=LLUVIA-LAP\SQLEXPRESS;Initial Catalog=My_reportedebaches;user ID=User1_abd;Password=User1_abd")
    ' Se crea un objeto DataAdapter para comunicarse con la base de datos y llenar un DataSet.
    'Se utiliza para ejecutar comandos SQL en la base de datos (como SELECT, INSERT, UPDATE, DELETE) y llenar un DataSet con los resultados de esas consultas.
    Public da As New SqlDataAdapter
    ' Se crea un objeto DataSet para almacenar los datos de la consulta.
    'Se utiliza para almacenar y manipular los resultados de las consultas a la base de datos de manera temporal en la memoria del programa.
    Public ds As New DataSet
    ' Se crea un objeto SqlCommandBuilder para generar comandos SQL automáticamente 
    ' basados en los cambios realizados en el DataSet. 
    Public cmd As New SqlCommandBuilder
    ' Se crea un objeto SqlCommand para ejecutar comandos SQL directamente en la base de datos.
    Private comando As New SqlCommand


    ' Método para consultar la base de datos y llenar un DataGridView con los resultados
    ' Recibe como parámetros el nombre de la tabla, la consulta SQL y el DataGridView donde se mostrarán los resultados.
    Public Sub consultar(ByVal tabla As String, ByVal sql As String, ByVal dgv As DataGridView)
        ds.Tables.Clear()           ' Se limpia el DataSet para asegurarse de que esté vacío antes de llenarlo nuevamente.
        da = New SqlDataAdapter(sql, con)          ' Se crea un DataAdapter con la consulta SQL y la conexión a la base de datos.
        cmd = New SqlCommandBuilder(da) ' Se crea un SqlCommandBuilder basado en el DataAdapter.
        ' Esto permite generar automáticamente comandos SQL para insertar, actualizar y eliminar filas en la base de datos.
        da.Fill(ds, tabla)   'Esta línea de código ejecuta la consulta SQL especificada en el DataAdapter (da) y llena el DataSet (ds) con los resultados de la consulta. La tabla resultante se
        'almacena en el DataSet con el nombre especificado por el parámetro tabla.

        dgv.DataSource = ds.Tables(tabla) ' los datos mostrados en el DataGridView provienen de la tabla en el DataSet y cualquier cambio realizado en el DataGridView también se reflejará en el DataSet.

    End Sub
    'funcion para insertar un nuevo registro en la tabla
    Function insertar(ByVal tabla As String, ByVal campos As String) As Boolean
        ' Construir la consulta SQL con espacios adecuados y corchetes alrededor de los nombres de tabla
        Dim consulta As String = "INSERT INTO [" & tabla & "] VALUES (" & campos & ")"
        comando = New SqlCommand(consulta, con)

        Try
            con.Open()
            Dim i As Integer = comando.ExecuteNonQuery()
            con.Close()

            ' Verificar si se insertó al menos una fila
            If i > 0 Then
                Return True ' Devolver true si se insertó una fila
            Else
                Return False
            End If
        Catch
            ' Manejar excepciones de SQL
            MsgBox("Error al insertar en la tabla: Este ID ya esta registrado")
            con.Close() ' Asegúrate de cerrar la conexión en caso de excepción
            Return False 'devolver falso si la insercion fallo
        End Try
    End Function




    'funcion para eliminar un registro de la tabla
    Function eliminar(ByVal tabla As String, ByVal condicion As String) As Boolean
        Try
            con.Open()
            Dim delete As String = "DELETE FROM [" & tabla & "] WHERE " & condicion
            comando = New SqlCommand(delete, con)
            Dim i As Integer = comando.ExecuteNonQuery()
            If i > 0 Then
                Return True
            Else
                Return False
            End If
        Catch
            MsgBox("Error: El registro existe en otra tabla")
            Return False
        Finally
            ' Se asegura de cerrar la conexión, independientemente de si ocurrió una excepción o no
            con.Close()
        End Try
    End Function


    Function modificar(ByVal tabla As String, ByVal nuevoValor As String, ByVal condicion As String) As Boolean
        con.Open()
        ' Construir la consulta SQL con espacios adecuados y corchetes alrededor del nombre de la tabla
        Dim update As String = "UPDATE [" & tabla & "] SET Nombre = '" & nuevoValor & "' WHERE " & condicion
        comando = New SqlCommand(update, con)
        ' Ejecutar la consulta SQL y validar que los valores no sean nulos
        Dim i As Integer = comando.ExecuteNonQuery()
        con.Close()
        If i > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    'esta funcion acepta 2 parametros,el nombre de la tabla  y una condición para verificar
    'si existen registros que cumplan con esa condición.
    'La función devuelve un valor booleano que indica si existe al menos un registro que cumpla con la condición.
    Function existeRegistro(ByVal tabla As String, ByVal condicion As String) As Boolean
        ' Esta línea construye una consulta SQL para contar el número de registros que cumplen
        ' con la condición dada
        Dim countQuery As String = "SELECT COUNT(*) FROM [" & tabla & "] WHERE " & condicion
        'se declara una variable para almacenar el resultado del recuento de registros.
        Dim countResult As Integer
        'utilice un try catch para manejo de excepciones en caso de un error
        Try
            con.Open()
            'se crea un nuevo comando SQL utilizando la consulta de conteo y la conexión a la base de datos.
            comando = New SqlCommand(countQuery, con)
            'se ejecuta el comando SQL y almacena el resultado del recuento en la variable countResult. 
            countResult = Convert.ToInt32(comando.ExecuteScalar()) 'ExecuteScalar se utiliza aquí porque la consulta devuelve un solo valor: el recuento de registros.
            con.Close()
            ' Si countResult es mayor que 0, significa que al menos un registro cumple la condición
            Return countResult > 0
        Catch ex As Exception
            ' Manejar cualquier error de consulta aquí
            MsgBox("Error al verificar la existencia del registro: " & ex.Message)
            con.Close()
            Return False 'Esta línea devuelve False para indicar que no se pudo verificar la existencia del registro debido a un error.
        End Try
    End Function



End Class
