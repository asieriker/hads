Public Class LogOut
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        'FormsAuthentication.SignOut()
        Session.Abandon()
        System.Web.Security.FormsAuthentication.SignOut()
        Response.Redirect("inicio.aspx")
    End Sub
End Class