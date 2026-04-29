
Imports System.Text.RegularExpressions

Public Class Form2
    Dim conexion As New CnxCrud ' Se crea un objeto que puede acceder a los métodos y propiedades definidos en la clase CnxCrud     

    Public Sub mostrar() 'este metodo se encarga de mostrar la tabla estados en el DataGridView
        conexion.consultar("Estados", "select * from Estados", DataGridView1)   'se llama a la funcion consultar de la clase conexion,enviando los
        'parametros correspondientes

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar() ' Al cargar el formulario, se llama al método mostrar para mostrar la tabla de estados
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        ' aquí se comprueba si se ingresó un valor en el cuadro de texto IdEstado y Nombre
        If Not String.IsNullOrEmpty(txtIdEstado.Text) AndAlso Not String.IsNullOrEmpty(txtNombre.Text) Then
            ' Construir la cadena de campos correctamente, rodeando los valores de texto con comillas simples

            Dim campos As String = "'" + txtIdEstado.Text + "', '" + txtNombre.Text + "'" ' Se construye una cadena con los valores de los campos IdEstado y Nombre

            ' Intentar insertar el registro
            If conexion.insertar("Estados", campos) Then
                ' Si la inserción se realizó correctamente, mostrar un mensaje y actualizar la vista
                MsgBox("1 fila insertada")
                mostrar()
            End If
        Else
            MsgBox("Por favor, llene los campos")
        End If
    End Sub


    'sub= subprocedimiento
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        'declaro variable que obtiene el texto ingresado en el cuadro de texto txtIdEstado y lo almacena en la variable idEstado.
        Dim idEstado As String = txtIdEstado.Text
        ' aqui se comprueba si se ingreso un valor en el cuadro de texto idEstado
        If Not String.IsNullOrEmpty(idEstado) Then
            ' Verificar si el ID ingresado existe en la tabla Estados
            If conexion.existeRegistro("Estados", "id_Estado=" + idEstado) Then

                ' Si el ID existe, proceder con la eliminación
                If conexion.eliminar("Estados", "id_Estado=" + idEstado) Then
                    MsgBox("1 fila eliminada")
                    mostrar()
                End If
            Else
                    MsgBox("el ID no existe ")
            End If
        Else
            MsgBox("Por favor, ingrese un ID de Estado válido.")
        End If
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        ' Se verifica si se ingresó un valor en los campos txtIdEstado y txtNombre
        If Not String.IsNullOrEmpty(txtIdEstado.Text) AndAlso Not String.IsNullOrEmpty(txtNombre.Text) Then
            ' Se crea una cadena llamada condicion basada en el contenido del cuadro de texto txtIdEstado.
            Dim condicion As String = "id_Estado=" & txtIdEstado.Text

            ' Se verifica si el registro con el ID proporcionado existe en la tabla Estados
            If conexion.existeRegistro("Estados", condicion) Then
                ' Se obtiene el nuevo valor para el campo 'nombre'
                Dim nuevoValor As String = txtNombre.Text

                ' Se llama a la función modificar de la instancia conexion para actualizar el registro
                conexion.modificar("Estados", nuevoValor, condicion)

                ' Se muestra un mensaje indicando que se modificó la fila
                MsgBox("1 fila modificada")

                ' Se actualiza la DataGridView para reflejar los cambios
                mostrar()
            Else
                ' Si el registro no existe, se muestra un mensaje de error
                MsgBox("Error: El ID proporcionado no existe en la tabla Estados")
            End If
        Else
            ' Si falta alguno de los campos, se muestra un mensaje de error
            MsgBox("Error: Ingrese tanto el ID como el nombre para modificar el registro")
        End If
    End Sub



    Private Sub txtLimpiar_Click(sender As Object, e As EventArgs) Handles txtLimpiar.Click
        txtIdEstado.Text = ""
        txtNombre.Text = ""
    End Sub

    Private Sub txtIdEstado_TextChanged(sender As Object, e As EventArgs) Handles txtIdEstado.TextChanged
        ' Verificar si el texto ingresado no está vacío
        If Not String.IsNullOrEmpty(txtIdEstado.Text) Then
            ' Verificar si el texto no contiene numeros
            If Not IsNumeric(txtIdEstado.Text) Then
                ' Si no son números, eliminar el último caracter ingresado
                txtIdEstado.Text = txtIdEstado.Text.Remove(txtIdEstado.Text.Length - 1)
                ' Colocar el cursor al final del texto
                txtIdEstado.SelectionStart = txtIdEstado.Text.Length
            Else
                ' Buscar el nombre correspondiente al ID en el conjunto de datos del DataGridView
                Dim id As Integer = Integer.Parse(txtIdEstado.Text) ' Convertir el texto del cuadro de texto txtIdEstado a un entero
                For Each row As DataGridViewRow In DataGridView1.Rows ' Iterar sobre cada fila en el DataGridView
                    ' Verificar si el valor en la primera celda de la fila actual no es nulo y coincide con el ID buscado
                    If row.Cells(0).Value IsNot Nothing AndAlso Integer.Parse(row.Cells(0).Value.ToString()) = id Then
                        ' Si se encuentra el ID, establecer el nombre correspondiente en el cuadro de texto txtNombre
                        txtNombre.Text = row.Cells(1).Value.ToString() ' Establecer el texto del cuadro de texto txtNombre con el valor de la segunda celda de la fila actual
                        Exit Sub ' Salir del bucle una vez que se encuentra el nombre correspondiente
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        ' Verificar si el texto ingresado no está vacío
        If Not String.IsNullOrEmpty(txtNombre.Text) Then
            ' Verificar si el texto contiene números
            If IsNumeric(txtNombre.Text) Then
                ' Si son números, eliminar el último caracter ingresado
                txtNombre.Text = txtNombre.Text.Remove(txtNombre.Text.Length - 1)
                ' Colocar el cursor al final del texto
                txtNombre.SelectionStart = txtNombre.Text.Length
            ElseIf Not ContieneSoloLetras(txtNombre.Text) Then

                MsgBox("Ingresa un solo letras")
                txtNombre.Text = txtNombre.Text.Remove(txtNombre.Text.Length - 1)
                ' Colocar el cursor al final del texto
                txtNombre.SelectionStart = txtNombre.Text.Length
            Else
                ' Buscar el ID correspondiente al nombre en el conjunto de datos del DataGridView
                ' Se obtiene el nombre del cuadro de texto txtNombre
                Dim nombre As String = txtNombre.Text
                ' Se itera sobre cada fila en el DataGridView
                For Each row As DataGridViewRow In DataGridView1.Rows
                    ' Se verifica si el valor de la celda en la segunda columna (índice 1) no es nulo
                    ' y si coincide con el nombre buscado
                    If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = nombre Then
                        ' Si se encuentra el nombre, se establece el valor de la primera celda (índice 0)
                        ' de esa fila en el cuadro de texto txtIdEstado
                        txtIdEstado.Text = row.Cells(0).Value.ToString()

                        ' Se utiliza Exit Sub para salir del bucle una vez que se encuentra el ID correspondiente
                        Exit Sub
                    End If
                Next

            End If
        End If
    End Sub
    'valida el contenido que se ingresa que contenga solo letras y espacios
    Private Function ContieneSoloLetras(ByVal cadena As String) As Boolean
        'se hace una busqueda en toda la cadena escrita 
        'validando cada caracter y que sea letra o espacio
        For Each c As Char In cadena
            If Not Char.IsLetter(c) And c <> " " Then
                Return False
            End If
        Next
        Return True
    End Function




    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            txtIdEstado.Text = DataGridView1.CurrentRow.Cells(0).Value
            txtNombre.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        Catch

        End Try
    End Sub
    Private Sub txtNombre_Leave(sender As Object, e As EventArgs) Handles txtNombre.Leave
        ' Verificar si el cuadro de texto txtNombre está vacío
        If String.IsNullOrEmpty(txtNombre.Text) Then
            Try
                ' Obtener el valor de la celda en la columna 1 (segunda columna) de la fila actual del DataGridView
                ' y establecerlo en el cuadro de texto txtNombre
                txtNombre.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
            Catch
                ' Si ocurre algún error al intentar obtener el valor de la celda, no se hace nada
            End Try
        End If
    End Sub

End Class