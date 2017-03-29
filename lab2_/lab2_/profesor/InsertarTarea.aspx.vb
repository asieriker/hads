Public Class InsertarTarea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SqlDataSource2.Insert() Then
            Label6.Text = "Tarea insertada correctamente"
        Else
            Label6.Text = "Fallo en la inserción"
        End If
    End Sub
End Class