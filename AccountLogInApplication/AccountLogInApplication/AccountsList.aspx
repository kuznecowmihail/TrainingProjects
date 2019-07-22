<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountsList.aspx.cs" Inherits="AccountLogInApplication.AccountsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AllList</title>
    <link rel="stylesheet" href="Styles/ListPage.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Back" runat="server" Text="Back to profile" OnClick="Back_Click"/>
            <asp:Table ID="Table1" runat="server" Height ="700px" style="margin-top:0px; margin-left:1500px;">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <h1>List of all accounts</h1>                    
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/AccountInformation.aspx?id=1"  runat="server" style=""></asp:HyperLink>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:HyperLink ID="HyperLink2" NavigateUrl="~/AccountInformation.aspx?id=2" runat="server"></asp:HyperLink>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:HyperLink ID="HyperLink3" NavigateUrl="~/AccountInformation.aspx?id=3" runat="server"></asp:HyperLink>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:HyperLink ID="HyperLink4" NavigateUrl="~/AccountInformation.aspx?id=3" runat="server"></asp:HyperLink>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:HyperLink ID="HyperLink5" NavigateUrl="~/AccountInformation.aspx?id=3" runat="server"></asp:HyperLink>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:HyperLink ID="HyperLink6" NavigateUrl="~/AccountInformation.aspx?id=3" runat="server"></asp:HyperLink>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:HyperLink ID="HyperLink7" NavigateUrl="~/AccountInformation.aspx?id=3" runat="server"></asp:HyperLink>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="LeftButton" runat="server" Text="<--" OnClick="LeftButton_Click"/>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Button ID="RightButton" runat="server" Text="-->" OnClick="RightButton_Click"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
