Public Class Alumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        System.Threading.Thread.Sleep(2000)
        'Label1.Text = "AJAXXXXXXXXXXX"
    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Label1.Text = Session.Contents("email")
        'Label1.Text = Application.Contents("email")
        'Dim lista As New List(Of String)
        'lista = Application.Contents("lista")
        ' For Each i As String In lista
        'Label1.Text += i
        'Next
    End Sub
End Class