Imports accesodatosSQL.accesodatosSQL
Public Class pruebita
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim codTarea = Session.Contents("Tarea")
        Label5.Text = Session.Contents("Tarea")
        Dim email = Session.Contents("email")
        Dim dataset As New DataSet
        dataset = Session.Contents("datosTgs")
        Dim dataTable As New DataTable
        dataTable = dataset.Tables("Tareas")
        Dim dataview As DataView
        dataview = New DataView(dataTable)
        dataview.RowFilter = "Codigo='" & codTarea & "'"
        GridView2.DataSource = dataset
        GridView2.DataBind()
        Label7.Text = dataview.Count
        TextBox1.Text = email
        TextBox2.Text = dataTable.Rows(0).Item(0).ToString
        TextBox3.Text = dataTable.Rows(0).Item(3).ToString

        Dim dataset2 As New DataSet
        dataset2 = getTareasEstudiante(email) 'TareasEstudiante
        'Session.Contents("datosTareasEstudiante") = dataset
        Dim dataTable2 = dataset2.Tables("TareasEstudiante")
        If dataTable2.Rows.Count = 0 Then
            Label5.Text = "No hay tareas instanciadas"
        Else
            Label5.Text = ""
            GridView1.DataSource = dataTable2
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim s = instanciarTareaDB(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
        Label5.Text = s
        Dim dataset2 As New DataSet
        dataset2 = getTareasEstudiante(TextBox1.Text) 'TareasEstudiante
        'Session.Contents("datosTareasEstudiante") = dataset
        Dim dataTable2 = dataset2.Tables("TareasEstudiante")
        If dataTable2.Rows.Count = 0 Then
            Label6.Text = "No hay tareas instanciadas"
        Else
            Label6.Text = ""
            GridView1.DataSource = dataTable2
            GridView1.DataBind()
        End If
    End Sub
End Class