<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="lab2_.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 33px;
            height: 39px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="z-index: 1; left: 10px; top: 15px; position: relative; height: 372px; width: 1032px">
    
        Registrar usuario:<br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        Correo:
        <asp:TextBox ID="correo" runat="server" AutoPostBack="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="correo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="correo" ErrorMessage="Introduce un email válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        &nbsp;&nbsp;


                <br />
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" class="auto-style1" src="imagenes/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Label ID="Label2" runat="server"></asp:Label>
                <asp:Image   ImageUrl="imagenes/tickGreen.gif" runat="server" ID="tickGreen" Height="44px" Visible="False" Width="46px"/>
                <asp:Image   ImageUrl="imagenes/redTick.gif" runat="server" ID="redTick" Height="44px" Visible="False" Width="46px"/>


        <br />
        Nombre:
        <asp:TextBox ID="nombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="nombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp; Apellido:&nbsp;
        <asp:TextBox ID="apellido" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="apellido" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="nombre" ErrorMessage="Introduce un nombre válido" ForeColor="Red" ValidationExpression="^([A-Z]{1}[a-zñáéíóú]+[\s]*)$" style="z-index: 1; left: 516px; top: 79px; position: relative; margin-bottom: 0px"></asp:RegularExpressionValidator>
        &nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Introduce un apellido válido" ForeColor="Red" ValidationExpression="^([A-Z]{1}[a-zñáéíóú]+[\s]*)$" ControlToValidate="apellido" style="z-index: 1; left: 517px; top: 114px; position: relative; right: 259px"></asp:RegularExpressionValidator>
        <br />
        <br />
        DNI:
        <asp:TextBox ID="dni" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dni" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="dni" ErrorMessage="Introduce un DNI válido" ForeColor="Red" ValidationExpression="^[0-9]{8}[A-Z]$"></asp:RegularExpressionValidator>
        <br />
        <br />
        Password:
        <asp:TextBox ID="password1" runat="server"  AutoPostBack="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="password1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;&nbsp; 
            <asp:Image   ImageUrl="imagenes/tickGreen.gif" runat="server" ID="tickGreen2" Height="44px" Visible="False" Width="46px"/>
            <asp:Image   ImageUrl="imagenes/redTick.gif" runat="server" ID="redTick2" Height="44px" Visible="False" Width="46px"/>
        </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        Repita Password:&nbsp;&nbsp;
        <asp:TextBox ID="password2" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="password2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="password2" ControlToValidate="password1" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red" ValueToCompare="password2" style="z-index: 1; left: 487px; top: 171px; position: relative"></asp:CompareValidator>
        &nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="password1" ErrorMessage="Introduce una contraseña válida (al menos 4 caracteres de este estilo: aZ*1)" ForeColor="Red" ValidationExpression="^[a-zA-ZÁáÀàÉéÈèÍíÌìÓóÒòÚúÙùÑñüÜ0-9!@#\$%\^&amp;\*\?_~\/]{4,20}$" style="position: relative"></asp:RegularExpressionValidator>
        <br />
        <br />
        Pregunta secreta:
        <asp:TextBox ID="pregunta" runat="server" Width="228px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="pregunta" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        Respuesta:
        <asp:TextBox ID="respuesta" runat="server" Width="146px"></asp:TextBox>
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="respuesta" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" BorderStyle="Groove" Text="Registrar" />
    
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
