Imports accesodatosSQL.accesodatosSQL

Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As String
        Dim serComprobar As New servicioComprobarMatricula.Matriculas
        If serComprobar.comprobar(correo.Text) = "SI" Then
            result = conectar()
            result += registrarUsuario(correo.Text, nombre.Text, apellido.Text, pregunta.Text, respuesta.Text, dni.Text, password2.Text)
            Label1.Text = result
            cerrarconexion()
        Else
            Label1.Text = "Los alumnos no matriculados no podrán registrarse"
        End If
    End Sub
    Protected Sub correo_TextChanged(sender As Object, e As EventArgs) Handles correo.TextChanged
        'Dim result As String
        Dim serComprobar As New servicioComprobarMatricula.Matriculas
        If serComprobar.comprobar(correo.Text) = "SI" Then
            'Label2.Text = "SI"
            tickGreen.Visible = True
            redTick.Visible = False
        Else
            'Label2.Text = "NO"
            tickGreen.Visible = False
            redTick.Visible = True
        End If
    End Sub
    Protected Sub password1_TextChanged(sender As Object, e As EventArgs) Handles password1.TextChanged
        Dim serComprobar As New comprobarContraseña.contraseñaSegura
        If serComprobar.esSegura(password1.Text) = "SI" Then
            tickGreen2.Visible = True
            redTick2.Visible = False
        Else
            tickGreen2.Visible = False
            redTick2.Visible = True
        End If
    End Sub
End Class