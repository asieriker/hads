Public Class WebUserControl1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Application.Contents("numerousuarios")
        Label2.Text = Application.Contents("numeroprofes")
        Dim lista As New List(Of String)
        ListBox1.Items.Clear()
        lista = Application.Contents("lista")
        For Each i As String In lista
            ListBox1.Items.Add(New ListItem(i, i))
        Next
        Dim listaProfs As New List(Of String)
        ListBox2.Items.Clear()
        listaProfs = Application.Contents("listaProfs")
        For Each i As String In listaProfs
            ListBox2.Items.Add(New ListItem(i, i))
        Next
    End Sub
End Class