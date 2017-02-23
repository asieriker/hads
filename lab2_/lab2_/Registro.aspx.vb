Imports accesodatosSQL.accesodatosSQL

Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As String
        result = conectar()
        result += registrarUsuario(correo.Text, nombre.Text, apellido.Text, pregunta.Text, respuesta.Text, dni.Text, password2.Text)
        Label1.Text = result
        cerrarconexion()
    End Sub
End Class