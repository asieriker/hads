<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExportarTareas.aspx.vb" Inherits="lab2_.ExportarTareas" %>

<%@ Register src="../LogOut.ascx" tagname="LogOut" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#FFCC66" Font-Size="Large" ForeColor="Black" Height="79px" HorizontalAlign="Center" Font-Bold="True">
            PROFESOR<br />
            <uc1:LogOut ID="LogOut1" runat="server" />
            <br />
            EXPORTAR TAREAS GENÉRICAS</asp:Panel>
    
    </div>
        <br />
        Seleccionar asignatura a Exportar:<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#FFCC66" Height="33px" Width="106px" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Codigo" DataValueField="Codigo">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS11_TareasConnectionString %>" SelectCommand="SELECT DISTINCT A.Codigo FROM Asignaturas AS A, ProfesoresGrupo AS PG, GruposClase GC WHERE A.Codigo=GC.CodigoAsig AND GC.Codigo=PG.CodigoGrupo AND PG.email=@email">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Codigo" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" style="z-index: 1; left: 260px; top: 186px; position: absolute; height: 133px; width: 309px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <p style="width: 225px">
        <asp:Button ID="Button1" runat="server" Text="Exportar XML (XMLWriter)" style="position: relative" Width="226px" />
        </p>
        <p style="width: 223px">
        &nbsp;<asp:Button ID="Button3" runat="server" Text="Exportar XML (WriteXML)" style="position: relative; margin-left: 0px" Width="226px" />
        </p>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <br />
            <asp:Button ID="Button2" runat="server" Text="Exportar formato JSON " />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS11_TareasConnectionString %>" SelectCommand="SELECT * FROM [TareasGenericas] WHERE ([CodAsig] = @CodAsig)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <p>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Profesor.aspx">Volver</asp:LinkButton>
        </p>
        <asp:Panel ID="Panel2" runat="server" BackColor="#FFCCFF" ScrollBars="Vertical" style="z-index: 1; left: 953px; top: 142px; position: absolute; height: 463px; width: 405px">
&nbsp;<asp:Label ID="Label2" runat="server">Aquí se mostrará el JSON (sin indentar, en el archivo si está)</asp:Label>
        </asp:Panel>
    </form>
</body>
</html>
