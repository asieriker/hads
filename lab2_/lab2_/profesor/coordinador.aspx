<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="coordinador.aspx.vb" Inherits="lab2_.coordinador" %>

<%@ Register src="../LogOut.ascx" tagname="LogOut" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <div>
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#FFCC66" Font-Size="Large" ForeColor="Black" Height="79px" HorizontalAlign="Center" Font-Bold="True">
            PROFESOR COORDINADOR<br />
            <uc1:LogOut ID="LogOut1" runat="server" />
            <br />
            DEDICACIONES MEDIAS </asp:Panel>
    
    </div>
    
    </div>
        <br />
        Selecciona una asignatura para ver la dedicación media:<br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS11_TareasConnectionString %>" SelectCommand="SELECT [codigo] FROM [Asignaturas]"></asp:SqlDataSource>
        <br />
        <br />
        La dedicación media es:
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/profesor/Profesor.aspx">Volver</asp:LinkButton>
        </p>
    </form>
</body>
</html>
