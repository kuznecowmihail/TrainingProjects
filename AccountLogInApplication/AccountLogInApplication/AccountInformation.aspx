<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="AccountInformation.aspx.cs" Inherits="AccountLogInApplication.AccountInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Information</title>
    <link rel="stylesheet" href="Styles/AccountPages.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click"/>
            <asp:Table ID="Table1" runat="server" >
                <asp:TableRow >
                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                        <h1>Information</h1>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <span>Fist name</span>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:label ID="FistName" runat="server"></asp:label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <span>Last name</span>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:label ID="LastName" runat="server"></asp:label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <span>Years</span>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:label ID="Age" runat="server"></asp:label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <span>Leaving place</span>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:label ID="LeavingPlace" runat="server"></asp:label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <span>Career</span>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:label ID="Career" runat="server"></asp:label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Button ID="SendMessage" runat="server" Text="Send Message"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
