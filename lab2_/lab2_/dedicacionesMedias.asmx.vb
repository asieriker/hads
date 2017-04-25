Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports accesodatosSQL.accesodatosSQL
Imports System.Data.SqlClient

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class dedicacionesMedias
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function getMedia(codAsig As String) As Integer
        Dim conexion As New SqlConnection("Server=tcp:servidorhads11.database.windows.net,1433;Initial Catalog=HADS11_Tareas;Persist Security Info=False;User ID=asik9692@servidorhads11;Password=Quepazaloko23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        conexion.Open()
        Dim st = "SELECT AVG(ET.HReales) FROM TareasGenericas TG, EstudiantesTareas ET WHERE TG.Codigo = ET.codTarea and TG.CodAsig='" + codAsig + "' GROUP BY TG.CodAsig"
        Dim comando = New SqlCommand(st, conexion)
        Return comando.ExecuteScalar()
    End Function
End Class