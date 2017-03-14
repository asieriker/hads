<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasProfesor.aspx.vb" Inherits="lab2_.TareasProfesor" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#FF9999" Font-Size="Large" ForeColor="Black" Height="79px" HorizontalAlign="Center" Font-Bold="True">
            PROFESOR<br />
            <br />
            GESTIÓN DE TAREAS GENÉRICAS</asp:Panel>
    
    </div>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Seleccionar asignatura"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#FFCC66" Height="33px" Width="106px" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Codigo" DataValueField="Codigo">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS11_TareasConnectionString %>" SelectCommand="SELECT DISTINCT A.Codigo FROM Asignaturas AS A, ProfesoresGrupo AS PG, GruposClase GC WHERE A.Codigo=GC.CodigoAsig AND GC.Codigo=PG.CodigoGrupo AND PG.email=@email">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Insertar nueva tarea" Height="50px" style="margin-top: 0px" PostBackUrl="~/InsertarTarea.aspx" />
        </p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
&nbsp;
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" style="position: absolute; top: 152px; left: 277px; height: 162px; width: 413px;" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Codigo" DataSourceID="SqlDataSource2">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField SelectText="Editar" ShowEditButton="True" />
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" />
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
        <asp:LinkButton ID="LinkButton2" runat="server" style="z-index: 1; left: 865px; top: 49px; position: absolute">Cerrar Sesión</asp:LinkButton>
        <p>
            &nbsp;</p>
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Profesor.aspx">Volver</asp:LinkButton>
        </p>
    </form>
</body>
</html>