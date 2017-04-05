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
            Application.Lock()
            Dim listaProfs As New List(Of String)
            listaProfs = Application.Contents("listaProfs")
            listaProfs.Add(Usuario.Text)
            Application.Contents("listaProfs") = listaProfs
            Dim NS As Integer = Application.Contents("numeroprofes")
            NS = Application.Contents("numeroprofes") + 1
            Application.Contents("numeroprofes") = NS
            Application.UnLock()
            Session.Contents("email") = Usuario.Text
            If Usuario.Text.Equals("vadillo@ehu.es") Then
                FormsAuthentication.SetAuthCookie("vadillo", False)
                Response.Redirect("~/profesor/Profesor.aspx")
            ElseIf Usuario.Text = "admin@ehu.es" Then
                FormsAuthentication.SetAuthCookie("Admin", False)
                Response.Redirect("~/admin/Admin.aspx")
            Else
                FormsAuthentication.SetAuthCookie("Profesor", False)
                Response.Redirect("~/profesor/Profesor.aspx")
            End If
        ElseIf result = "A" Then
            cerrarconexion()
            Application.Lock()

            Dim lista As New List(Of String)
            lista = Application.Contents("lista")
            lista.Add(Usuario.Text)
            Application.Contents("lista") = lista

            Dim NS As Integer = Application.Contents("numerousuarios")
            NS = Application.Contents("numerousuarios") + 1
            Application.Contents("numerousuarios") = NS
            Application.UnLock()

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