<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BannerCentral.ascx.cs" Inherits="App_Master_UserControl_BannerCentral" %>
<div class="sin_prod">
    <p>
        <asp:Literal ID="LitMensaje" runat="server"></asp:Literal>
    </p>
</div>
<table class="botones">
    <tr>
        <td>
            <asp:HyperLink ID="HnlVolver" runat="server" CssClass="btn_volver left">
                <asp:Image ID="imgBoton" runat="server" ImageUrl="~/images/botones/btn_cerrar.jpg" />
            </asp:HyperLink>
        </td>
    </tr>
</table>
</div>