Imports accesodatosSQL.accesodatosSQL
Public Class Confirmar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = conectar()
        result = confirmarUsuario(Request.QueryString("email"), Request.QueryString("numConfir"))
        If result = 1 Then
            Label1.Text = "ConfirmADO.NET"
        End If
        cerrarconexion()
        'Application.Contents("numerousuarios") = 0

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("~/Inicio.aspx")
    End Sub
End Class