Imports System.Xml
Imports Newtonsoft.Json
Imports accesodatosSQL.accesodatosSQL
Imports System
Imports System.IO
Imports System.Text
Public Class ExportarTareas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim datos As DataView = SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            Dim tabla As DataTable = datos.Table
            ' Create XmlWriterSettings.
            Dim settings As XmlWriterSettings = New XmlWriterSettings()
            settings.Indent = True ' añade sangrias al resultado
            ' Create XmlWriter.
            Using writer As XmlWriter = XmlWriter.Create(Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xml"), settings)
                ' Begin writing.
                writer.WriteStartDocument()
                writer.WriteStartElement("tareas") 'Root.
                ' Loop over employees in array.
                For Each tarea In tabla.Rows
                    writer.WriteStartElement("tarea")
                    writer.WriteElementString("codigo", tarea("Codigo").ToString)
                    writer.WriteElementString("descripcion", tarea("Descripcion").ToString)
                    writer.WriteElementString("hestimadas", tarea("HEstimadas").ToString)
                    writer.WriteElementString("explotacion", tarea("Explotacion"))
                    writer.WriteElementString("tipotarea", tarea("TipoTarea").ToString)
                    writer.WriteEndElement()
                Next
                writer.WriteEndElement()
                writer.WriteEndDocument()
            End Using
            Label1.Text = "XML exportado correctamente"
        Catch exception As Exception
            Label1.Text = exception.ToString
        End Try
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim adapter = getTodasLasTareasGenericas()
        Dim dataset As New DataSet
        adapter.Fill(dataset, "TareasGenericas")
        Dim resultJEISON = JsonConvert.SerializeObject(dataset, Newtonsoft.Json.Formatting.Indented)
        Label1.Text = resultJEISON

        Dim path As String = Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".json") '"c:\temp\MyTest.txt"  
        Dim pathLOCAL As String = "C:\Users\iker5\Desktop\2CUATRI\HADS\lab2\lab2_\lab2_\App_Data\" & DropDownList1.SelectedValue & ".json"
        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(pathLOCAL) 'OJOOOOOOOOO

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(resultJEISON)
        fs.Write(info, 0, info.Length)
        fs.Close()
        Label1.Text = Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".json")
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText(Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".json"))
        Label1.Text = fileReader
    End Sub
End Class