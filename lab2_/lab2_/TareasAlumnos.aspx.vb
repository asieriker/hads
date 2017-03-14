Imports System.Data.SqlClient
Imports accesodatosSQL.accesodatosSQL

Public Class TareasAlumnos
    Inherits System.Web.UI.Page
    Dim dapMbrs As New SqlDataAdapter()
    Dim dapMbrs2 As New SqlDataAdapter()
    Dim dstMbrs As New DataSet
    Dim dstMbrs2 As New DataSet
    Dim tblMbrs As New DataTable
    Dim tblMbrs2 As New DataTable
    Dim rowMbrs As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dataset = getAsignaturasAlumno(Session.Contents("email"))
            Session.Contents("datosAsigs") = dataset
            Dim dataTable = dataset.Tables("Asignaturas")
            DropDownList1.DataSource = dataTable
            DropDownList1.DataTextField = "codigo"
            DropDownList1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim dataset = Session.Contents("datosTgs")
        Dim dataTable As New DataTable
        dataTable = dataset.Tables("Tareas")
        Session.Contents("Tarea") = dataTable.Rows(GridView1.SelectedIndex).Item(0).ToString
        Response.Redirect("InstanciarTarea.aspx")
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        Dim codAsig = DropDownList1.SelectedValue()
        Dim dataset = getTareasGenericas(codAsig, Session.Contents("email"))
        Session.Contents("datosTgs") = dataset
        Dim dataTable = dataset.Tables("Tareas")
        If dataTable.Rows.Count = 0 Then
            Label1.Text = "No hay tareas para instanciar"
        Else
            Label1.Text = ""
            GridView1.DataSource = dataTable
            GridView1.DataBind()
        End If
    End Sub
End Class