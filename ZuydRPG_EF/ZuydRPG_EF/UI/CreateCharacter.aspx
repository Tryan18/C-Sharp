<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCharacter.aspx.cs" Inherits="ZuydRPG_EF.UI.CreateCharacter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Create Character</h1>
        <p>Name:
            <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btn_ok" runat="server" Text="OK" OnClick="btn_ok_Click" />
        </p>
    </div>
    </form>
</body>
</html>
