<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="AccountLogInApplication.RegistrationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/RegistrationPageStyle.css" />
</head>
<body>
    <div>
    <form id="form1" runat="server" >
            <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click"/>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3" HorizontalAlign="Center" style="padding:0px;">
                        <h1>Registration</h1>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <span class="CommonLabel">Login:</span>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="Login" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="InformationLabel1" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <span class="CommonLabel">Password:</span>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="InformationLabel2" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                        <h1>Close information</h1>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell >
                        <span class="CommonLabel">First Name:</span>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="InformationLabel3" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <span class="CommonLabel">Last Name:</span>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
                    </asp:TableCell>
                     <asp:TableCell>
                        <asp:Label ID="InformationLabel4" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <span class="CommonLabel">Years:</span>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="Age" runat="server"></asp:TextBox>
                    </asp:TableCell>
                     <asp:TableCell>
                        <asp:Label ID="InformationLabel5" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <span class="CommonLabel">Leaving place:</span>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="LeavingPlace" runat="server"></asp:TextBox>
                    </asp:TableCell>
                     <asp:TableCell>
                        <asp:Label ID="InformationLabel6" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <span class="CommonLabel">Career:</span>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="Career" runat="server"></asp:TextBox>
                    </asp:TableCell>
                     <asp:TableCell>
                        <asp:Label ID="InformationLabel7" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                        <asp:Button ID="Registration" runat="server" Text="Register" OnClick="Button1_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
    </form>
        </div>
</body>
</html>
