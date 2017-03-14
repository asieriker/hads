Imports accesodatosSQL.accesodatosSQL
Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As String
        cerrarconexion()

        result = conectar()
        If result.ToString <> "CONEXION OK" Then
            Label1.Text = "Error db" + result
            Exit Sub
        End If
        result = loginUsuario(Usuario.Text, password.Text)
        If result = "P" Then
            cerrarconexion()
            Session.Contents("email") = Usuario.Text
            Response.Redirect("http://hads11asik.azurewebsites.net/Profesor.aspx")

        ElseIf result = "A" Then
            cerrarconexion()
            Session.Contents("email") = Usuario.Text
            Response.Redirect("http://hads11asik.azurewebsites.net/Alumno.aspx")

        Else
            Label1.Text = "Datos de acceso incorrectos"
        End If
        cerrarconexion()
    End Sub
End Class