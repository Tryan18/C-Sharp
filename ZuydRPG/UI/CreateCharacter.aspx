<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateCharacter.aspx.cs" Inherits="UI_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Name : "></asp:Label>
        <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Job : "></asp:Label>
        <asp:DropDownList ID="ddl_job" runat="server">
            <asp:ListItem>Fighter</asp:ListItem>
            <asp:ListItem>Mage</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="btn_insert" runat="server" OnClick="btn_insert_Click" Text="Insert" />
    
    </div>
    </form>
</body>
</html>
