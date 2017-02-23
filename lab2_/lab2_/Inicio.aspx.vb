Imports accesodatosSQL.accesodatosSQL
Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As String
        result = conectar()
        result = loginUsuario(Usuario.Text, password.Text)
        If result = 1 Then
            Response.Redirect("http://hads11asik.azurewebsites.net/aplicacion.aspx")
        Else
            Response.Redirect("http://hads11asik.azurewebsites.net/inicio.aspx")
        End If
        cerrarconexion()
    End Sub
End Class