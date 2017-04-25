Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.IO

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class contraseñaSegura
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function esSegura(pass As String) As String

        Dim objReader As New System.IO.StreamReader(Server.MapPath("App_Data/toppasswords.txt"))
        '"C:\Users\iker5\Desktop\2CUATRI\HADS\lab2\lab2_\lab2_\App_Data\toppasswords.txt"
        Dim sLinea As String = ""
        Dim TextLine As String = ""
        Do While objReader.Peek() <> -1
            sLinea = objReader.ReadLine()
            If sLinea = pass Then
                Return "NO"
            End If
        Loop
        Return "SI"
        objReader.Close()


        '     Dim stFile = "C:\Users\iker5\Desktop\2CUATRI\HADS\lab2\lab2_\lab2_\App_Data\toppasswords.txt"
        '    Dim text As String = File.ReadAllText(stFile)
        '    Dim index As Integer = text.IndexOf(pass)
        '    If index >= 0 Then
        'Return "NO"
        ' String is in file, starting at character "index"
        '   End If
        '   Return "SI"
    End Function

End Class