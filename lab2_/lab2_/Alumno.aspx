<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Alumno.aspx.vb" Inherits="lab2_.Alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            font-family: Verdana, Geneva, Tahoma, sans-serif;
            font-size: xx-large;
        }
        </style>
</head>
<body style="height: 456px">
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px" style="font-weight: 700; font-size: medium">
            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <DynamicSelectedStyle BackColor="#FFCC66" />
            <Items>
                <asp:MenuItem NavigateUrl="~/Alumno.aspx" Selected="True" Text="Inicio" Value="Inicio"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/imagenes/rsz_tareas.png" NavigateUrl="~/TareasAlumnos.aspx" Text="Tareas Genéricas" Value="Tareas Genéricas"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/imagenes/rsz_social.png" Text="Grupos" Value="Grupos"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#FFCC66" />
        </asp:Menu>
        <asp:Panel ID="Panel1" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="#FF6600" HorizontalAlign="Center" style="z-index: -1; left: 11px; top: 47px; position: absolute; height: 72px; width: 1270px">
            Gestión Web de Tareas-Dedicación<br /> Alumnos</asp:Panel>
        <span class="auto-style1">
        <br />
        <br />
        </span></div>
    </form>
</body>
</html>
