<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header_privado.ascx.cs" Inherits="App_Master_Controls_Header_privado" %>
<div id="header">
    <div class="menu-login">
        <ul>
             <li>
                <asp:LinkButton ID="btnCerrar" runat="server" CssClass="sesion" CausesValidation="False"
                    ToolTip="Cerrar Sesión" OnClick="btnCerrar_Click">Cerrar Sesión</asp:LinkButton>
            </li>
            <li class="hour">
                <asp:Literal ID="LitHora" runat="server"></asp:Literal></li>
            <li>
                <asp:Literal ID="LitFecha" runat="server"></asp:Literal></li>
            <li>Bienvenido, <strong>
                <asp:Literal ID="LitUsuario" runat="server"></asp:Literal></strong></li>
            <li>
                <asp:DropDownList ID="ddlCondominio" runat="server" CssClass="select_option">
                </asp:DropDownList>
            </li>
        </ul>
    </div>
</div>