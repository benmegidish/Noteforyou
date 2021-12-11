<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WebApplication13.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label runat="server" Text="Enter ID"></asp:Label>
                <asp:TextBox runat="server" ID="Uid"></asp:TextBox>
            </div>
              <div>
                <asp:Label runat="server" Text="Enter Password"></asp:Label>
                <asp:TextBox runat="server" ID="UPass"></asp:TextBox>
            </div>
            <asp:Button runat="server" ForeColor="BlueViolet" Text="Log-In" OnClick="LogIn_Click" />
        </div>
    </form>
</body>
</html>
