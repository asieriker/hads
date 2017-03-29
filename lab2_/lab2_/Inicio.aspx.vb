Imports accesodatosSQL.accesodatosSQL
Imports System.Web.Security

Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As String
        result = conectar()
        If result.ToString <> "CONEXION OK" Then
            Label1.Text = "Error db" + result
            Exit Sub
        End If
        result = loginUsuario(Usuario.Text, password.Text)
        'programita()
        If result = "P" Then
            cerrarconexion()
            Session.Contents("email") = Usuario.Text
            If Usuario.Text = "vadillo@ehu.es" Then
                FormsAuthentication.SetAuthCookie("vadillo@ehu.es", False)
            ElseIf Usuario.Text = "admin@ehu.es" Then
                FormsAuthentication.SetAuthCookie("Admin", False)
                Response.Redirect("~/admin/Admin.aspx")
            Else
                FormsAuthentication.SetAuthCookie("Profesor", False)
                Response.Redirect("~/profesor/Profesor.aspx")
            End If
        ElseIf result = "A" Then
            cerrarconexion()
            Session.Contents("email") = Usuario.Text
            FormsAuthentication.SetAuthCookie("Alumno", False)
            Response.Redirect("~/alumno/Alumno.aspx")
        Else
            Label1.Text = "Datos de acceso incorrectos"
            Label2.Text = result
        End If

        cerrarconexion()
    End Sub

End Class