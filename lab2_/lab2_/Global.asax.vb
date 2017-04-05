Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al iniciar la aplicación
        Application.Contents("numerousuarios") = 0
        Application.Contents("numeroprofes") = 0
        Dim lista As New List(Of String)
        Application.Contents("lista") = lista
        Dim listaProfs As New List(Of String)
        Application.Contents("listaProfs") = listaProfs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al iniciar la sesión
        Dim lista As New List(Of String)
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al comienzo de cada solicitud
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al intentar autenticar el uso
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando se produce un error
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la sesión
        Application.Lock()
        Dim s1 As String = Session.Contents("email")
        If s1.Contains("ikasle") Then
            Dim NS As Integer = Application.Contents("numerousuarios")
            NS = Application.Contents("numerousuarios") - 1
            Application.Contents("numerousuarios") = NS
            Dim lista As New List(Of String)
            lista = Application.Contents("lista")
            lista.Remove(Session.Contents("email"))
            Application.Contents("lista") = lista
        Else
            Dim NS2 As Integer = Application.Contents("numeroprofes") - 1
            Application.Contents("numeroprofes") = NS2
            Dim listaProfs As New List(Of String)
            listaProfs = Application.Contents("listaProfs")
            listaProfs.Remove(Session.Contents("email"))
            Application.Contents("listaProfs") = listaProfs
        End If
        Application.UnLock()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la aplicación
    End Sub

End Class