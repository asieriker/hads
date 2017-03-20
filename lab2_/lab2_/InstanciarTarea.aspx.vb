Imports accesodatosSQL.accesodatosSQL
Imports System.Data.SqlClient
Public Class InstanciarTarea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim codTarea = Session.Contents("Tarea")
        Label5.Text = Session.Contents("Tarea")
        Dim email = Session.Contents("email")
        Dim dataset As New DataSet
        dataset = Session.Contents("datosTgs")
        Dim dataTable As DataTable
        DataTable = dataset.Tables("Tareas")
        Dim dataview As DataView
        dataview = New DataView(DataTable)
        dataview.RowFilter = "Codigo='" & codTarea & "'"
        Label7.Text = dataview.Count
        TextBox1.Text = email
        TextBox2.Text = dataview(0)("Codigo").ToString
        TextBox3.Text = dataview(0)("HEstimadas").ToString

        Dim dstTes As New DataSet
        Dim dapTes As SqlDataAdapter
        dapTes = getTareasEstudianteDA(email) 'TareasEstudiante
        Dim bld As New SqlCommandBuilder(dapTes)
        dapTes.Fill(dstTes, "TareasEstudiante")
        Session.Contents("datosTareasEstudiante") = dstTes
        Session.Contents("dapTareasEstudiante") = dapTes
        Dim dataTable2 = dstTes.Tables("TareasEstudiante")

        If dataTable2.Rows.Count = 0 Then
            Label5.Text = "No hay tareas instanciadas"
        Else
            Label5.Text = ""
            GridView1.DataSource = dataTable2
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim tareas As DataSet
            tareas = Session.Contents("datosTareasEstudiante")
            Dim dap As SqlDataAdapter
            dap = Session.Contents("dapTareasEstudiante")
            Dim tabla As DataTable
            tabla = tareas.Tables(0)
            Dim fila As DataRow = tabla.NewRow()
            fila("Email") = Session.Contents("email")
            fila("CodTarea") = Session.Contents("Tarea")
            fila("HEstimadas") = TextBox3.Text
            fila("HReales") = TextBox4.Text
            tabla.Rows.Add(fila)
            dap.Update(tareas, "TareasEstudiante")
            tareas.AcceptChanges()
            'Dim s = instanciarTareaDB(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
            'Label5.Text = s
            'Dim dataset2 As New DataSet
            'dataset2 = getTareasEstudiante(TextBox1.Text) 'TareasEstudiante
            'Session.Contents("datosTareasEstudiante") = dataset
            'Dim dataTable2 = dataset2.Tables("TareasEstudiante")
            If tabla.Rows.Count = 0 Then
                Label6.Text = "No hay tareas instanciadas"
            Else
                Label6.Text = ""
                GridView1.DataSource = tabla
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Label5.Text = "Error en la instanciación"
        End Try

    End Sub
End Class