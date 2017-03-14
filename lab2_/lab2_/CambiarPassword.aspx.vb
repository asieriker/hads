Imports accesodatosSQL.accesodatosSQL
Public Class CambiarPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As String
        result = conectar()
        Label2.Visible = True
        
        If mail.Text <> "" Then
            Label2.Text = conseguirPregunta(mail.Text)
            If Label2.Text <> "No hay usuarios con ese email" Then
                respuesta.Enabled = True
                password1.Enabled = True
                password2.Enabled = True
                CompareValidator1.Enabled = True
                RegularExpressionValidator2.Enabled = True
            End If
        End If
        cerrarconexion()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As String
        result = conectar()
        If actualizarPassword(mail.Text, password1.Text) = 1 Then
            Label3.Text = "Password CambiADO.NET"
        End If
        cerrarconexion()
    End Sub
End Class