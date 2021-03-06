﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="inicio.aspx.vb" Inherits="lab2_.Inicio" %>

<%@ Register src="WebUserControl1.ascx" tagname="WebUserControl1" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .nuevoEstilo1 {
            background-image: url('imagenes/ignasi_pattern_s.png');
            background-repeat: repeat;
        }
        .nuevoEstilo2 {
            background-image: url('imagenes/ignasi_pattern_s.png');
            background-repeat: repeat;
        }
        .auto-style2 {
            width: 70px;
            height: 59px;
            float: left;
            z-index: 1;
            left: 25px;
            top: 23px;
            position: absolute;
            right: 1222px;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            width: 171px;
            height: 447px;
            z-index: 1;
            left: 600px;
            top: 174px;
            position: absolute;
            float: right;
            text-align: justify;
        }
        </style>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style3">
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#FFCC66" Font-Size="XX-Large" ForeColor="Black" Height="79px" HorizontalAlign="Center" Font-Bold="True">
            <br />
            Gestión de Tareas<img alt="" class="auto-style2" src="imagenes/upv-ehu.gif" /></asp:Panel>
    
        <div class="auto-style3">
            <br />
            <br />
    
        Usuario&nbsp;&nbsp;
        <asp:TextBox ID="Usuario" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Usuario" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;Contraseña:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="password" runat="server" EnableTheming="True" TextMode="Password" Width="128px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" BorderStyle="Groove" Text="Iniciar Sesión" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ARegistro" runat="server" BorderStyle="Groove" Text="Registrar" CausesValidation="False" PostBackUrl="~/Registro.aspx" />
            <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Usuario" ErrorMessage="Introduce un email válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" BorderStyle="Groove" Text="Cambiar contraseña" CausesValidation="False" PostBackUrl="~/CambiarPassword.aspx" />
        <br />
   
        </div>
    
    </div>
        
    <p class="auto-style3">
        <img alt="" class="auto-style4" src="imagenes/J3xurDF.gif" /></p>
        <p class="auto-style3">
            &nbsp;</p>

                <uc1:WebUserControl1 ID="WebUserControl11" runat="server" />

        <p>
            &nbsp;

        </p>
        <p class="auto-style3">
            &nbsp;</p>
    <p class="auto-style3">
        &nbsp;</p>
         </form>
</body>
</html>
