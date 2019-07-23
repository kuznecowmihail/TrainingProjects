<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessagePage.aspx.cs" Inherits="AccountLogInApplication.MessagePage" %>

<!DOCTYPE html>
<%
    


    %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/MessageStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click"/>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>My messages</asp:ListItem>
                <asp:ListItem>All messages</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="GetMessages" runat="server" OnClick="GetMessages_Click" Text="Show messages"/>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
