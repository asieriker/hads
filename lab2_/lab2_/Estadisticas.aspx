<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Estadisticas.aspx.vb" Inherits="lab2_.Estadisticas" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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
    
    &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Email" DataValueField="Email">
        </asp:DropDownList>
&nbsp;Sólo aparecerán los estudiantes con tareas<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS11_TareasConnectionString %>" SelectCommand="SELECT DISTINCT Email FROM EstudiantesTareas"></asp:SqlDataSource>
        <br />
        <br />
        <br />
        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2">
            <series>
                <asp:Series Name="Series1" XValueMember="CodTarea" YValueMembers="HReales">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS11_TareasConnectionString %>" SelectCommand="SELECT [HReales], [CodTarea] FROM [EstudiantesTareas] WHERE ([Email] = @Email)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="Email" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Profesor.aspx">Volver</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
