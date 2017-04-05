<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pruebaTUITAH.aspx.vb" Inherits="lab2_.pruebaTUITAH" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
         <div>
            
             
        </div>
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <ajaxToolkit:Twitter ID="Twitter1" Mode="Search" Search="spiderman" runat="server" IncludeRetweets="True" IsLiveContentOnDesignMode="True" CacheDuration="15" IncludeReplies="False"/>
                 </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
