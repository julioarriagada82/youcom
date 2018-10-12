<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header_privado.ascx.cs"
    Inherits="App_Master_Controls_Header_privado" %>
<div class="log-info">
    <div class="container-fluid">
        <ul>
            <li>Bienvenido, <span class="user-name">
                <asp:Literal ID="LitUsuario" runat="server"></asp:Literal></span></li>
            <li class="hidden-xs"><span class="glyphicon glyphicon-calendar"></span>
                <asp:Literal ID="LitFecha" runat="server"></asp:Literal></li>
            <li class="hidden-xs"><span class="glyphicon glyphicon-time"></span>
                <asp:Literal ID="LitHora" runat="server"></asp:Literal></li>
            <li>
                <asp:LinkButton ID="btnCerrar" runat="server" CssClass="sesion" CausesValidation="False"
                    ToolTip="Cerrar Sesión" OnClick="btnCerrar_Click"><span class="glyphicon glyphicon-off"></span> Cerrar Sesión</asp:LinkButton>
            </li>
        </ul>
    </div>
</div>
