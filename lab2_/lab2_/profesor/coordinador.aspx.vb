Public Class coordinador
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim op As New referenciaServicioDedicaciones.dedicacionesMedias
        Dim num = op.getMedia(DropDownList1.SelectedValue())
        Label1.Text = num
    End Sub
End Class