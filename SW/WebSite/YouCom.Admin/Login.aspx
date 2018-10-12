<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/Admin/Login.master" CodeFile="Login.aspx.cs" Inherits="Administracion_Login" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Label runat="server" ID="lblMensaje"></asp:Label>
    <div id="login-box">
        <label>
            Usuario</label>
        <asp:TextBox runat="server" ID="txtUsuario" onblur="return validaRut(this)"
            MaxLength="12"></asp:TextBox>
        <label>
            Password</label>
        <asp:TextBox runat="server" TextMode="Password" ID="txtPassword"></asp:TextBox>
        <asp:LinkButton runat="server" CssClass="bt-ingresar" ID="btnIngresar" Text="Ingresar"
            OnClick="btnIngresar_Click" />
    </div>
</asp:Content>

