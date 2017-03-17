<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportarTareasXmlDocument.aspx.vb" Inherits="lab2_.ImportarTareasXmlDocument" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#FFCC66" Font-Size="Large" ForeColor="Black" Height="79px" HorizontalAlign="Center" Font-Bold="True">
            PROFESOR<br />
            <br />
            IMPORTAR TAREAS GENÉRICAS</asp:Panel>
    
    </div>
        <br />
        Seleccionar asignatura a Importar:<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#FFCC66" Height="33px" Width="106px" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Codigo" DataValueField="Codigo">
            </asp:DropDownList>
        <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS11_TareasConnectionString %>" SelectCommand="SELECT DISTINCT A.Codigo FROM Asignaturas AS A, ProfesoresGrupo AS PG, GruposClase GC WHERE A.Codigo=GC.CodigoAsig AND GC.Codigo=PG.CodigoGrupo AND PG.email=@email">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
        <asp:Xml ID="Xml1" runat="server"></asp:Xml>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Importar XMLD" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Importar DataSet" />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS11_TareasConnectionString %>" SelectCommand="SELECT * FROM TareasGenericas AS TG WHERE TG.CodAsig=@cod" UpdateCommand="UPDATE TareasGenericas SET Descripcion =@Descripcion, CodAsig =@CodAsig, HEstimadas =@HEstimadas, Explotacion =@Explotacion, TipoTarea =@TipoTarea WHERE Codigo=@Codigo">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="cod" PropertyName="SelectedValue" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Descripcion" />
                <asp:Parameter Name="CodAsig" />
                <asp:Parameter Name="HEstimadas" />
                <asp:Parameter Name="Explotacion" />
                <asp:Parameter Name="TipoTarea" />
                <asp:Parameter Name="Codigo" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" style="z-index: 1; left: 461px; top: 216px; position: absolute; height: 133px; width: 187px">
        </asp:GridView>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Profesor.aspx">Volver</asp:LinkButton>
    </form>
</body>
</html>
