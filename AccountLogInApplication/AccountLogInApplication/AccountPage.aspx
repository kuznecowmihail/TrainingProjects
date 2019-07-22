<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountPage.aspx.cs" Inherits="AccountLogInApplication.Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account</title>
    <link rel="stylesheet" href="Styles/AccountPages.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Quit" runat="server" Text="Quit" OnClick="QuitButton_Click"/>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                        <h1>Information about me</h1>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell >
                        <asp:label ID="Label1" runat="server">Fist name:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell >
                        <asp:label ID="FistName" runat="server"></asp:label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:label ID="Label2" runat="server">Last name:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:label ID="LastName" runat="server"></asp:label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:label ID="Label3" runat="server">Age:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:label ID="Age" runat="server"></asp:label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:label ID="Label4" runat="server">Leaving place:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:label ID="LeavingPlace" runat="server"></asp:label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:label ID="Label5" runat="server">Career:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:label ID="Career" runat="server"></asp:label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                        <asp:Button ID="AllUsers" runat="server" Text="All Users" OnClick="AllUsers_Click"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
