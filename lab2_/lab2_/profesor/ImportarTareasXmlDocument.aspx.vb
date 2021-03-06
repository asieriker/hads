﻿Imports System.IO
Imports System.Xml
Imports accesodatosSQL.accesodatosSQL
Imports System.Data.SqlClient

Public Class ImportarTareasXmlDocument
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dapTgs = getTodasLasTareasGenericas()
        Dim dstTgs = New DataSet()
        Dim bld As New SqlCommandBuilder(dapTgs)
        dapTgs.Fill(dstTgs, "TareasGenericas")
        Session("dataAdapterTgs") = dapTgs
        Session("dataSetTgs") = dstTgs
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim xd As New XmlDocument
            xd.Load(Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xml"))
            'Dim docNodo As XmlNode = xd.DocumentElement
            Dim LasTareas As XmlNodeList
            LasTareas = xd.GetElementsByTagName("tarea")
            'HAY Q METERLO TODO EN UN DATASET Y ESTE PASARLO A LA BASE DE DATOS
            Dim dataSetTgs As New DataSet
            Dim dapTgs As New SqlDataAdapter
            dataSetTgs = Session("dataSetTgs")
            dapTgs = Session("dataAdapterTgs")
            Dim dataTableTareas As New DataTable
            dataTableTareas = dataSetTgs.Tables("TareasGenericas")
            Dim i As Integer
            For i = 0 To LasTareas.Count - 1
                Dim datarow As DataRow = dataTableTareas.NewRow
                datarow("Codigo") = LasTareas(i).ChildNodes(0).ChildNodes(0).Value
                datarow("Descripcion") = LasTareas(i).ChildNodes(1).ChildNodes(0).Value
                datarow("codAsig") = DropDownList1.SelectedValue
                datarow("HEstimadas") = LasTareas(i).ChildNodes(2).ChildNodes(0).Value
                datarow("Explotacion") = LasTareas(i).ChildNodes(3).ChildNodes(0).Value
                datarow("TipoTarea") = LasTareas(i).ChildNodes(4).ChildNodes(0).Value
                dataTableTareas.Rows.Add(datarow)
            Next
            dapTgs.Update(dataSetTgs, "TareasGenericas")
            dataSetTgs.AcceptChanges()
            Label3.Text = "Importado correctamente"
        Catch _Ex As SqlException

            If _Ex.Number = 2627 Then
                Label3.Text = "Ya has importado las tareas"
            End If

        End Try
    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        If Not File.Exists(Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xml")) Then
            Label1.Text = "No existe el XML"
        Else
            Try
                Xml1.DocumentSource = Server.MapPath("App_Data/" &
                DropDownList1.SelectedValue & ".xml")
                Xml1.TransformSource = Server.MapPath("App_Data/XSLTFile" & RadioButtonList1.SelectedValue & ".xsl")
            Catch ex As Exception
                Label1.Text = ex.ToString + "Error al cargar el XML"
            End Try
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim xmldata As DataSet = New DataSet()
        Dim dataSetTgs As New DataSet
        Dim dapTgs As New SqlDataAdapter
        dataSetTgs = Session("dataSetTgs")
        dapTgs = Session("dataAdapterTgs")
        Try
            Dim table As DataTable = New DataTable()
            Dim newColumn As New Data.DataColumn("CodAsig", GetType(System.String))
            newColumn.DefaultValue = DropDownList1.SelectedValue
            xmldata.ReadXml(Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xml"))
            table = xmldata.Tables(0)
            table.Columns.Add(newColumn)
            Dim oldtable As DataTable = New DataTable()
            oldtable = dataSetTgs.Tables(0)
            For Each tarea In table.Rows

                Dim rowselected() As DataRow
                rowselected = oldtable.Select("codigo='" + tarea(0).ToString + "'")
                If rowselected.Length < 1 Then
                    Dim row As DataRow
                    row = oldtable.NewRow()
                    row("codigo") = tarea(0).ToString
                    row("descripcion") = tarea(1).ToString
                    row("codasig") = tarea(5).ToString
                    row("hestimadas") = Convert.ToInt32(tarea(2).ToString)
                    row("explotacion") = tarea(3).ToString
                    row("tipotarea") = tarea(4).ToString
                    oldtable.Rows.Add(row)
                End If
            Next
            Dim num = dapTgs.Update(dataSetTgs, "TareasGenericas")
            dataSetTgs.AcceptChanges()
            If num > 0 Then
                Label3.Text = "Cambios salvados en la BD"
            Else
                Label3.Text = "No hay nuevas tareas"
            End If
        Catch _Ex As SqlException

            If _Ex.Number = 2627 Then
                Label3.Text = "Ya has importado las tareas"
            End If

        End Try
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Not File.Exists(Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xml")) Then
            Label1.Text = "No existe el XML"
        Else
            Try
                Xml1.DocumentSource = Server.MapPath("App_Data/" &
                DropDownList1.SelectedValue & ".xml")
                Xml1.TransformSource = Server.MapPath("App_Data/XSLTFile" & RadioButtonList1.SelectedValue & ".xsl")
            Catch ex As Exception
                Label1.Text = ex.ToString + "Error al cargar el XML"
            End Try
        End If
    End Sub
End Class