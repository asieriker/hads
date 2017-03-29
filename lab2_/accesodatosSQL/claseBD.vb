Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Security.Cryptography

Public Class accesodatosSQL
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand
    Private Shared comando2 As New SqlCommand

    Public Shared Function conectar() As String
        Try
            'conexion.ConnectionString = "Data Source=158.227.106.20;Initial Catalog=HADS11_Usuarios;User ID=HADS11;Password=orca"
            'conexion.ConnectionString = "Server=tcp:hads11asik.database.windows.net,1433;Initial Catalog=HADS11_Usuarios;Persist Security Info=False;User ID=asik9692@hads11asik;Password=Quepazaloko23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.ConnectionString = "Server=tcp:servidorhads11.database.windows.net,1433;Initial Catalog=HADS11_Tareas;Persist Security Info=False;User ID=asik9692@servidorhads11;Password=Quepazaloko23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN: " + ex.Message
        End Try
        Return "CONEXION OK"
    End Function

    Public Shared Sub cerrarconexion()
        conexion.Close()
    End Sub
    Public Shared Function registrarUsuario(ByVal email As String, ByVal nombre As String, ByVal apellidos As String, ByVal pregunta As String, ByVal respuesta As String, ByVal dni As String, ByVal pass As String) As String
        Dim numConfir As Integer
        Randomize()
        numConfir = CLng(Rnd() * 9000000) + 1000000

        ''''''''''''''''''''''''''''
        'Dim Texto As String = "Prueba" ' Cadena original
        Dim TextoEnBytes As Byte()
        Dim HashEnBytes As Byte() 'Resultado en Bytes
        Dim HashPass As String 'Resultado de HASH

        Dim md5 As New SHA1CryptoServiceProvider
        TextoEnBytes = System.Text.Encoding.ASCII.GetBytes(pass)

        HashEnBytes = md5.ComputeHash(TextoEnBytes)
        'HashPass = System.Text.Encoding.UTF8.GetString(HashEnBytes)
        HashPass = BitConverter.ToString(HashEnBytes)
        Dim HashPassNuevo = HashPass.Replace("-", "")
        ''''''''''''''''''''''''''''''
        'Dim laPass = AES_Encrypt("23", pass)
        '     aaaaabbbcccccccdd.Substring(5, 3) = bbb
        Dim dniNuevo = dni.Substring(0, dni.Length - 1)
        'Dim HashPassNuevo = HashPass.Substring(0, HashPass.Length - 10)

        'Dim st = "insert into Usuarios (email,nombre,apellidos,pregunta,respuesta,dni,numconfir,confirmado,pass)  values ('" & email & " ', '" & nombre & " ', '" & apellidos & " ', '" & pregunta & " ', '" & respuesta & " ', '" & dni & " ', '" & numConfir & " ', 0, '" & pass & " ')"
        Dim st = "insert into Usuarios (email,nombre,pregunta,respuesta,dni,confirmado,pass,tipo)  values ('" & email & " ', '" & nombre & " ', '" & pregunta & " ', '" & respuesta & " ', '" & dniNuevo & " ', 0, '" & HashPassNuevo & "'," & " 'A')"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
            'accesodatosSQL.enviarEmail(email, numConfir)
        Catch ex As Exception
            Return "," + ex.Message
        End Try
        Return (numregs & " registro(s) insertado(s) en la BD ")
    End Function
    ' Public Shared Function programita()
    'cerrarconexion()

    'conectar()
    'registrarUsuario("pepe@ikasle.ehu.es", "JM Blanco", "nolometemos", "Mi segundo", "Arbe", "13231313T", "blanco")
    'registrarUsuario("vadillo@ehu.es", "JA Vadillo", "nolometemos", "Mi apellido", "Vadillo", "87654321", "vadillo")
    'registrarUsuario("admin@ehu.es", "Admin", "admin", "Admin", "Admin", "72455696", "admin")
    'registrarUsuario("pepe@ikasle.ehu.es", "Pepe", "nolometemos", "Mi nombre", "Pepe", "1234567T", "pepe")
    'registrarUsuario("nerea@ikasle.ehu.es", "Nerea", "nolometemos", "Mi nombre", "Nerea", "23232323T", "nerea")
    'cerrarconexion()
    'Return ""
    ' End Function

    Public Shared Function enviarEmail(ByVal email As String, ByVal numConfir As String) As Boolean
        Try
            'Direccion de origen
            Dim from_address As New MailAddress("HADS11asiker@gmail.com", "admin")
            'Direccion de destino
            Dim to_address As New MailAddress(email)
            'Password de la cuenta
            Dim from_pass As String = "Quepazaloko23"
            'Objeto para el cliente smtp
            Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.gmail.com"
            'Puerto
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            'Credenciales
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)
            'Añadimos el asunto
            message.Subject = "Confirmación de Registro"
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>" + "Congratulations! You have registered in our awesome webpage. Click http://hads11asik.azurewebsites.net/Confirmar.aspx?numConfir=" + numConfir.ToString + "&email=" + email.ToString + "</body></html>"
            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos
            message.IsBodyHtml = True
            'Se envia el correo
            smtp.Send(message)
        Catch e As Exception
            Return False
        End Try
        Return True
    End Function

    Public Shared Function loginUsuario(ByVal email As String, ByVal pass As String) As String

        Dim TextoEnBytes As Byte()
        Dim HashEnBytes As Byte() 'Resultado en Bytes
        Dim HashPass As String 'Resultado de HASH
        Dim md5 As New SHA1CryptoServiceProvider
        TextoEnBytes = System.Text.Encoding.ASCII.GetBytes(pass)

        HashEnBytes = md5.ComputeHash(TextoEnBytes)
        'HashPass = System.Text.Encoding.UTF8.GetString(HashEnBytes)
        HashPass = BitConverter.ToString(HashEnBytes)
        Dim HashPassNuevo = HashPass.Replace("-", "")
        'BitConverter.toString

        ''''''''''''''''''

        Dim st = "select count(*) from Usuarios WHERE email='" & email.ToString & "' and pass='" & HashPassNuevo & "' and confirmado=1" & " and tipo='P'"
        Dim st2 = "select count(*) from Usuarios WHERE email='" & email.ToString & "' and pass='" & HashPassNuevo & "' and confirmado=1" & " and tipo='A'"

        Dim numregs As Integer
        Dim numregs2 As Integer

        comando = New SqlCommand(st, conexion)
        numregs = comando.ExecuteScalar()

        comando2 = New SqlCommand(st2, conexion)
        numregs2 = comando2.ExecuteScalar()

        If numregs = 1 Then
            Return "P"
        ElseIf numregs2 = 1 Then
            Return "A"
        Else
            Return "0"
        End If
    End Function

    Public Shared Function confirmarUsuario(ByVal email As String, ByVal numConfir As Integer) As String
        Dim st = "select count(*) from Usuarios WHERE email='" & email.ToString & "'"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        numregs = comando.ExecuteScalar()
        If numregs = 1 Then
            st = "update Usuarios SET confirmado=1  WHERE email='" & email.ToString & "'"
            comando = New SqlCommand(st, conexion)
            numregs = comando.ExecuteNonQuery()
        End If
        Return numregs
    End Function

    Public Shared Function conseguirPregunta(ByVal email As String) As String
        Dim st = "SELECT pregunta FROM Usuarios WHERE email='" & email.ToString & "' and confirmado=1"
        Dim R As SqlDataReader
        comando = New SqlCommand(st, conexion)
        R = comando.ExecuteReader()
        Dim s
        Try
            R.Read()
            s = R.Item("pregunta")
        Catch ex As Exception
            s = "No hay usuarios con ese email"
            R.Close()
            Return s
            Exit Function
        End Try
        R.Close()
        Return s
    End Function
    Public Shared Function actualizarPassword(ByVal email As String, ByVal pass As String) As String
        Dim st = "select count(*) from Usuarios WHERE email='" & email.ToString & "'"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        numregs = comando.ExecuteScalar()
        If numregs = 1 Then
            st = "update Usuarios SET pass='" & pass & "' WHERE email='" & email.ToString & "'"
            comando = New SqlCommand(st, conexion)
            numregs = comando.ExecuteNonQuery()
        End If
        Return numregs
    End Function


    Public Shared Function getTareasGenericas(ByVal codAsig As String, ByVal email As String) As DataSet
        conexion.ConnectionString = "Server=tcp:servidorhads11.database.windows.net,1433;Initial Catalog=HADS11_Tareas;Persist Security Info=False;User ID=asik9692@servidorhads11;Password=Quepazaloko23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim dstTgs = New DataSet()
        Dim dapTgs As New SqlDataAdapter()
        Dim st = "SELECT DISTINCT T.Codigo,T.Descripcion,T.HEstimadas,T.TipoTarea FROM Usuarios AS U, TareasGenericas AS T, EstudiantesTareas AS E WHERE T.CodAsig='" & codAsig & "' AND T.Explotacion=1 AND T.Codigo NOT IN(Select ET.CodTarea FROM EstudiantesTareas AS ET WHERE ET.CodTarea=T.Codigo AND ET.email='" & email & "')"
        dapTgs = New SqlDataAdapter(st, conexion)
        dapTgs.Fill(dstTgs, "Tareas")
        Return dstTgs
    End Function

    Public Shared Function getAsignaturasAlumno(ByVal email As String) As DataSet
        conexion.ConnectionString = "Server=tcp:servidorhads11.database.windows.net,1433;Initial Catalog=HADS11_Tareas;Persist Security Info=False;User ID=asik9692@servidorhads11;Password=Quepazaloko23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim dstAsigs = New DataSet()
        Dim dapAsigs As New SqlDataAdapter()
        Dim st = "SELECT DISTINCT A.codigo FROM Usuarios AS U, Asignaturas AS A, GruposClase AS G, EstudiantesGrupo AS EG WHERE U.email='" & email & "' AND G.codigoasig=A.codigo AND U.email=EG.Email AND EG.Grupo=G.codigo"
        dapAsigs = New SqlDataAdapter(st, conexion)
        dapAsigs.Fill(dstAsigs, "Asignaturas")
        Return dstAsigs
    End Function
    Public Shared Function getTareaInstanciada(ByVal codTarea) As DataSet
        conexion.ConnectionString = "Server=tcp:servidorhads11.database.windows.net,1433;Initial Catalog=HADS11_Tareas;Persist Security Info=False;User ID=asik9692@servidorhads11;Password=Quepazaloko23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim dstTarea = New DataSet()
        Dim dapTarea As New SqlDataAdapter()
        Dim st = "SELECT *  FROM TareasGenericas AS T WHERE T.Codigo='" & codTarea & "'"
        dapTarea = New SqlDataAdapter(st, conexion)
        dapTarea.Fill(dstTarea, "Tarea")
        Return dstTarea
    End Function
    Public Shared Function getTareasEstudiante(ByVal email As String) As DataSet
        conexion.ConnectionString = "Server=tcp:servidorhads11.database.windows.net,1433;Initial Catalog=HADS11_Tareas;Persist Security Info=False;User ID=asik9692@servidorhads11;Password=Quepazaloko23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim dstTes = New DataSet()
        Dim dapTes As New SqlDataAdapter()
        Dim st = "SELECT * FROM EstudiantesTareas AS ET WHERE ET.email='" & email & "'"
        dapTes = New SqlDataAdapter(st, conexion)
        dapTes.Fill(dstTes, "TareasEstudiante")
        Return dstTes
    End Function

    Public Shared Function getTareasEstudianteDA(ByVal email As String) As SqlDataAdapter
        conexion.ConnectionString = "Server=tcp:servidorhads11.database.windows.net,1433;Initial Catalog=HADS11_Tareas;Persist Security Info=False;User ID=asik9692@servidorhads11;Password=Quepazaloko23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim dstTes = New DataSet()
        Dim dapTes As New SqlDataAdapter()
        Dim st = "SELECT * FROM EstudiantesTareas AS ET WHERE ET.email='" & email & "'"
        dapTes = New SqlDataAdapter(st, conexion)
        Return dapTes
    End Function

    Public Shared Function instanciarTareaDB(ByVal email As String, ByVal codTarea As String, ByVal Hest As String, ByVal Hreal As String)
        'conexion.ConnectionString = "Server=tcp:servidorhads11.database.windows.net,1433;Initial Catalog=HADS11_Tareas;Persist Security Info=False;User ID=asik9692@servidorhads11;Password=Quepazaloko23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        conectar()
        Dim st = "INSERT INTO EstudiantesTareas VALUES('" & email & " ', '" & codTarea & " ', '" & Hest & " ', '" & Hreal & "')"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
        Catch ex As Exception
            cerrarconexion()
            Return "," + ex.Message
        End Try
        cerrarconexion()
        Return (numregs & " Tarea Instanciada ")
    End Function
    Public Shared Function getTodasLasTareasGenericas() As SqlDataAdapter
        conexion.ConnectionString = "Server=tcp:servidorhads11.database.windows.net,1433;Initial Catalog=HADS11_Tareas;Persist Security Info=False;User ID=asik9692@servidorhads11;Password=Quepazaloko23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim dstTgs = New DataSet()
        Dim dapTgs As New SqlDataAdapter()
        Dim st = "SELECT  * FROM  TareasGenericas"
        dapTgs = New SqlDataAdapter(st, conexion)

        Return dapTgs
    End Function


 
End Class