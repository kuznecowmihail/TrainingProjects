<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="AccountLogInApplication.StartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet" href="Styles/StartPageStyle.css" />
</head>
<body >
    <div>
        <form id="form1" runat="server">
            <div >
                <asp:Table ID="Table1" runat="server">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <h1>Home Page</h1>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="LoginLabel" runat="server" Text="Login:"></asp:Label>    
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="LoginBox" runat="server" placeholder="Enter login"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>    
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="PasswordBox" runat="server" placeholder="Enter password" TextMode="Password" ></asp:TextBox>
                        </asp:TableCell>
                        </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Right" ColumnSpan="2">
                            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell style="padding:25px">
                            <asp:Button ID="LogInButton" runat="server" Text="LogIn" OnClick="LogInButton_Click"/>
                        </asp:TableCell>
                        <asp:TableCell style="padding:25px">
                            <asp:Button ID="SignUpButton" runat="server" Text="SignUp" OnClick="SignUpButton_Click"/>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </form>
    </div>
</body>
</html>
