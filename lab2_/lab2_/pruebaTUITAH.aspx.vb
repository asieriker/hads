Imports lab2_.EjemploServiceIker

Public Class pruebaTUITAH
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim us As New AccesoServicioUsers.EjemploWebServiceIker
        Dim us1 As New ServiceReferenceCONsvc.EjemploServiceIkerClient
        'GridView1.DataSource = us.HelloWorld.Tables(0)
        GridView1.DataSource = us1.getUSuarios.Tables(0)
        GridView1.DataBind()
    End Sub
End Class