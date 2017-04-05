<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertarTarea.aspx.vb" Inherits="lab2_.InsertarTarea" %>

<%@ Register src="../LogOut.ascx" tagname="LogOut" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            GESTIÓN DE TAREAS GENÉRICAS</asp:Panel>
    
    </div>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Código" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="149px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Descripción" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Height="52px" Width="488px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Asignatura" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#FFCC66" Height="33px" Width="106px" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Codigo" DataValueField="Codigo">
            </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Horas Est." Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Codigo Invalido. Rango de horas 0-99" ForeColor="Red" ValidationExpression="^[0-9]{1,2}$"></asp:RegularExpressionValidator>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS11_TareasConnectionString %>" SelectCommand="SELECT DISTINCT A.Codigo FROM Asignaturas AS A, ProfesoresGrupo AS PG, GruposClase GC WHERE A.Codigo=GC.CodigoAsig AND GC.Codigo=PG.CodigoGrupo AND PG.email=@email">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="email" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Tipo Tarea" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server" Height="18px" Width="97px" BackColor="#FFCC66">
            <asp:ListItem>Ejercicio</asp:ListItem>
            <asp:ListItem>Examen</asp:ListItem>
            <asp:ListItem>Laboratorio</asp:ListItem>
        </asp:DropDownList>
&nbsp;<p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Añadir tarea" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </p>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS11_TareasConnectionString %>" InsertCommand="INSERT INTO TareasGenericas VALUES (@Codigo, @Descripcion, @CodAsig, @HEstimadas, 0, @TipoTarea)" SelectCommand="SELECT * FROM TareasGenericas AS TG WHERE TG.CodAsig=@cod" UpdateCommand="UPDATE TareasGenericas SET Descripcion =@Descripcion, CodAsig =@CodAsig, HEstimadas =@HEstimadas, Explotacion =@Explotacion, TipoTarea =@TipoTarea WHERE Codigo=@Codigo">
            <InsertParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="Codigo" PropertyName="Text" />
                <asp:ControlParameter ControlID="TextBox2" Name="Descripcion" PropertyName="Text" />
                <asp:ControlParameter ControlID="DropDownList1" Name="CodAsig" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="TextBox3" Name="HEstimadas" PropertyName="Text" />
                <asp:ControlParameter ControlID="DropDownList2" Name="TipoTarea" PropertyName="SelectedValue" />
            </InsertParameters>
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
        <p>
&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server">Volver</asp:LinkButton>
        </p>
    </form>
</body>
</html>
