<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CambiarPassword.aspx.vb" Inherits="lab2_.CambiarPassword" %>

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
    
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" Text="Cambiar contraseña"></asp:Label>
        <br />
        <br />
        Email:&nbsp;
        <asp:TextBox ID="mail" runat="server" Width="147px" ValidationGroup="A"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="mail" ErrorMessage="*" ForeColor="Red" style="position: relative" ValidationGroup="A"></asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="mail" ErrorMessage="Introduce un email válido" ForeColor="Red" style="z-index: 1; left: 231px; top: 62px; position: absolute" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="A"></asp:RegularExpressionValidator>
        <br />
        <asp:Button ID="Button1" runat="server" BorderStyle="Groove" Text="Solicitar cambio de contraseña" ValidationGroup="A" />
        <br />
        <br />
        <br />
        Pregunta de seguridad:&nbsp; <asp:Label ID="Label2" runat="server" Font-Italic="True" Text="Aquí aparecera la pregunta de seguridad" Visible="False"></asp:Label>
        <br />
        <br />
        Respuesta:&nbsp;
        <asp:TextBox ID="respuesta" runat="server" Enabled="False" Width="184px" ValidationGroup="B"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="respuesta" ErrorMessage="*" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>
        <br />
        <br />
        Nueva contraseña:&nbsp;
        <asp:TextBox ID="password1" runat="server" Enabled="False" TextMode="Password" Width="160px" ValidationGroup="B"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="password1" ErrorMessage="*" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>
&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="password1" ErrorMessage="ehhh que noo!! te has confundADO.NET" ForeColor="Red" ValidationExpression="^(?=.{8,15}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&amp;*]).*" ValidationGroup="B"></asp:RegularExpressionValidator>
        &nbsp;&nbsp;&nbsp; Repetir contraseña:&nbsp;&nbsp;
        <asp:TextBox ID="password2" runat="server" Enabled="False" TextMode="Password" Width="171px" ValidationGroup="B"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="password2" ErrorMessage="*" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="password1" ControlToValidate="password2" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red" ValueToCompare="B"></asp:CompareValidator>
        <br />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" ForeColor="Fuchsia"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" BorderStyle="Groove" Text="Cambiar contraseña" ValidationGroup="B" />
        <br />
    
    </div>
    </form>
</body>
</html>
