<%@ page language="C#" autoeventwireup="true" inherits="Encriptacion, App_Web_hs8l09xh" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TxtInicial" runat="server" TextMode="MultiLine" Columns="100" Rows="5"></asp:TextBox>
        <br />
        <asp:Button ID="BtnEncriptar" runat="server" Text="Encriptar" 
            onclick="BtnEncriptar_Click" />
        <br />
        <asp:TextBox ID="TxtEncriptado" runat="server" TextMode="MultiLine" Columns="100" Rows="5"></asp:TextBox>
        <br />
        <asp:Button ID="BtnDesencriptar" runat="server" Text="Desencriptar" 
            onclick="BtnDesencriptar_Click" />
        <br />
        <asp:TextBox ID="TxtFinal" runat="server" TextMode="MultiLine" Columns="100" Rows="5"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>

