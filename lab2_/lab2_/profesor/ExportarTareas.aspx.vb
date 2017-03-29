Imports System.Xml
Imports Newtonsoft.Json
Imports accesodatosSQL.accesodatosSQL
Imports System
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient

Public Class ExportarTareas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Label1.Text = ""
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
                ' Write the xmlns:bk="urn:book" namespace declaration.
                writer.WriteAttributeString("xmlns", DropDownList1.SelectedValue.ToLower, Nothing, "http://ji.ehu.es/" & DropDownList1.SelectedValue.ToLower)
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
        'Label1.Text = resultJEISON

        Dim path As String = Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".json") '"c:\temp\MyTest.txt"  
        'Dim pathLOCAL As String = "C:\Users\Asier\Source\Workspaces\Área de trabajo\HADS\lab2_\lab2_\App_Data\" & DropDownList1.SelectedValue & ".json"
        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(path) 'OJOOOOOOOOO

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(resultJEISON)
        fs.Write(info, 0, info.Length)
        fs.Close()
        'Label1.Text = Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".json")
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText(Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".json"))
        Label2.Text = fileReader
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dta As New SqlDataAdapter
        Dim dts As New DataSet
        Dim tbl As New DataTable
        Label1.Text = ""
        dta = getTodasLasTareasGenericas()
        dta.Fill(dts, "TareasGenericas")
        tbl = dts.Tables("TareasGenericas")
        Try
            tbl.WriteXml(Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xml"))
        Catch ex As Exception
            Label1.Text = "MAL: " + ex.StackTrace
        End Try


        Dim xmldoc As New System.Xml.XmlDocument
        xmldoc.Load(Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xml"))
        Label1.Text = "XML exportado correctamente"
    End Sub
End Class