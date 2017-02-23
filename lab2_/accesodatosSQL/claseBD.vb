Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class accesodatosSQL
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand
    Public Shared Function conectar() As String
        Try
            'conexion.ConnectionString = "Data Source=158.227.106.20;Initial Catalog=HADS11_Usuarios;User ID=HADS11;Password=orca"
            conexion.ConnectionString = "Server=tcp:hads11asik.database.windows.net,1433;Initial Catalog=HADS11_Usuarios;Persist Security Info=False;User ID=asik9692@hads11asik;Password=Quepazaloko23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

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
        Dim st = "insert into Usuarios (email,nombre,apellidos,pregunta,respuesta,dni,numconfir,confirmado,pass)  values ('" & email & " ', '" & nombre & " ', '" & apellidos & " ', '" & pregunta & " ', '" & respuesta & " ', '" & dni & " ', '" & numConfir & " ', 0, '" & pass & " ')"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
            accesodatosSQL.enviarEmail(email, numConfir)
        Catch ex As Exception
            Return "," + ex.Message
        End Try
        Return (numregs & " registro(s) insertado(s) en la BD ")
    End Function

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
        Dim st = "select count(*) from Usuarios WHERE email='" & email.ToString & "' and pass='" + pass.ToString & "' and confirmado=0"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        numregs = comando.ExecuteScalar()
        Return numregs
    End Function

    Public Shared Function confirmarUsuario(ByVal email As String, ByVal numConfir As Integer) As String
        Dim st = "select count(*) from Usuarios WHERE email='" & email.ToString & "' and numConfir='" & numConfir.ToString & "'"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        numregs = comando.ExecuteScalar()
        If numregs = 1 Then
            st = "update Usuarios SET confirmado=1  WHERE email='" & email.ToString & "' and numConfir='" & numConfir.ToString & "'"
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


End Class