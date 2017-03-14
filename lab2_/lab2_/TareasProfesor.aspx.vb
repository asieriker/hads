Public Class TareasProfesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        Session.Abandon()
        Response.Redirect("http://hads11asik.azurewebsites.net/Inicio.aspx")
    End Sub
End Class