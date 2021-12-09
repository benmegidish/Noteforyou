<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication13.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post">
        <div>
            <asp:Label runat="server" ID="Hello"></asp:Label>
           <div>
               <h1>Note list For You</h1>
               Search: <asp:TextBox runat="server" ID="Searchtxt" ></asp:TextBox>
               <asp:Button runat="server" ID="BtnSrch" Text="Search" OnClick="Search_click" />
               Sort:
               <asp:DropDownList runat="server" ID="Sort">
                   <asp:ListItem Value="0">HIGH-Priority</asp:ListItem>
                   <asp:ListItem Value="1">Low-Priority</asp:ListItem>
               </asp:DropDownList>
               <asp:Button runat="server" Text="Sort" OnClick="Unnamed_Click" />

           </div>
            <div>
                <asp:TextBox runat="server" Width="200px" ID="UNote"></asp:TextBox>
                <asp:DropDownList runat="server" ID="Importance">
                    <asp:ListItem Value="1">1</asp:ListItem>
                     <asp:ListItem Value="2">2</asp:ListItem>
                     <asp:ListItem Value="3">3</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Button runat="server" ID="CRT" Text="Create" OnClick="Create_Click" />
            <asp:Button runat="server" ID="UPD" Text="Update" OnClick="Update_Click" Visible="false"/>
        </div>
        <div>
            <asp:Repeater ID="RPT" runat="server">
                <HeaderTemplate>
                    <h5>This Is Your List</h5>
                </HeaderTemplate>
                <ItemTemplate>
                    <table>
                        <tr style="border:solid 2px black">
                            <td style="border:solid 2px black">
                                <asp:Label runat="server" ID="SortId" Text="Note ID"></asp:Label>
                            </td>
                            <td style="border:solid 2px black">
                                <asp:Label runat="server" ID="Nid" Text='<%#Eval("Id") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr style="border:solid 2px black">
                            <td style="border:solid 2px black">
                                <asp:Label runat="server" ID="SortImport" Text="Improtance"></asp:Label>
                            </td>
                            <td style="border:solid 2px black">
                                <asp:Label runat="server" ID="IMport" Text='<%#Eval("Importance") %>'></asp:Label>
                            </td>
                            </tr>
                        <tr style="border:solid 2px black">
                            <td style="border:solid 2px black">
                                <asp:Label runat="server" ID="SortNote" Text="Notes"></asp:Label>
                            </td>
                            <td style="border:solid 2px black">
                                <asp:Label runat="server" ID="Notus" Width="300px" Text='<%#Eval("Note") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:LinkButton CssClass="color:red" Text="Delete" runat="server" OnClick="Delete_Click"/>
                    <asp:LinkButton CssClass="color:green" Text="Edit" runat="server" OnClick="Edit_click"/>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
