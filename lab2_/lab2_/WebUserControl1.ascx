<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WebUserControl1.ascx.vb" Inherits="lab2_.WebUserControl1" %>
<asp:Panel ID="Panel1" runat="server" Width="193px">
</asp:Panel>
<p>
    <br />
    </p>
<p>
</p>
<p>
    &nbsp;</p>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Timer ID="Timer1" runat="server" Interval="1000">
        </asp:Timer>
            Alumnos conectados&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Profesores conectados&nbsp;
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
        <ajaxToolkit:Twitter ID="Twitter2"  Mode="Profile"
            ScreenName="dotnetlogix" runat="server">
        </ajaxToolkit:Twitter>
    </ContentTemplate>
</asp:UpdatePanel>



