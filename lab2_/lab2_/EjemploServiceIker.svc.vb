' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "EjemploServiceIker" en el código, en svc y en el archivo de configuración a la vez.
' NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EjemploServiceIker.svc o EjemploServiceIker.svc.vb en el Explorador de soluciones e inicie la depuración.
Imports accesodatosSQL.accesodatosSQL
Imports System.Data.SqlClient

Public Class EjemploServiceIker
    Implements IEjemploServiceIker

    Public Function GetUsuarios() As System.Data.DataSet Implements IEjemploServiceIker.GetUsuarios
        cerrarconexion()
        Dim conexion As New SqlConnection("Server=tcp:servidorhads11.database.windows.net,1433;Initial Catalog=HADS11_Tareas;Persist Security Info=False;User ID=asik9692@servidorhads11;Password=Quepazaloko23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        Dim dp = getTareasEstudianteDA("pepe@ikasle.ehu.es")
        Dim ds As New DataSet
        dp.Fill(ds, "Users")
        Return ds
    End Function
End Class
