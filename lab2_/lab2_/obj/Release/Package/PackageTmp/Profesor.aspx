<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="lab2_.Profesor" %>

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
    
        <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px" style="font-weight: 700; font-size: medium">
            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <DynamicSelectedStyle BackColor="#FFCC66" />
            <Items>
                <asp:MenuItem NavigateUrl="~/Alumno.aspx" Selected="True" Text="Inicio" Value="Inicio"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/imagenes/rsz_icon3.png" NavigateUrl="~/Estadisticas.aspx" Text="Estadisticas" Value="Estadisticas"></asp:MenuItem>
                <asp:MenuItem Text="Asignaturas" Value="Asignaturas" ImageUrl="~/imagenes/rsz_boeken.png"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/imagenes/rsz_tareas.png" NavigateUrl="~/TareasProfesor.aspx" Text="Tareas " Value="Tareas"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/imagenes/rsz_social.png" Text="Grupos" Value="Grupos"></asp:MenuItem>
                <asp:MenuItem Text="XML" Value="XML" ImageUrl="~/imagenes/rsz_1xml.png">
                    <asp:MenuItem NavigateUrl="~/ImportarTareasXmlDocument.aspx" Text="Importar XML" Value="Importar XML"></asp:MenuItem>
                    <asp:MenuItem Text="Exportar XML" Value="Exportar XML" NavigateUrl="~/ExportarTareas.aspx"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#FFCC66" />
        </asp:Menu>
    
    </div>
        <asp:Panel ID="Panel1" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="#FF6600" HorizontalAlign="Center" style="z-index: -2; left: 11px; top: 47px; position: absolute; height: 72px; width: 1288px">
            Gestión Web de Tareas-Dedicación<br /> Profesores</asp:Panel>
    </form>
</body>
</html>
