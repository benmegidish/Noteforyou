<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication13.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label runat="server" Text="First Name"></asp:Label>
                <asp:TextBox runat="server" ID="Fname"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" Text="ID"></asp:Label>
                <asp:TextBox runat="server" ID="id"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" Text="Password"></asp:Label>
                <asp:TextBox runat="server" ID="Pass" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button runat="server" Text="Submit" OnClick="Submit_Click" />
            <asp:Label runat="server" ID="confirm"></asp:Label>
        </div>
    </form>
</body>
</html>
