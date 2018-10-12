<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucCondominio.ascx.cs" Inherits="App_Master_Admin_Controls_wucCondominio" %>
<asp:Panel ID="pnlAdministrador" runat="server">
    <div class="columna-left-160">
        <p>
            Condominio
        </p>
    </div>
    <div class="columna-right">
        <asp:DropDownList runat="server" ID="ddlCondominio" CssClass="select_option" AutoPostBack="True" OnSelectedIndexChanged="ddlCondominio_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlCondominio"
            Display="None" ErrorMessage="El Condominio es Obligatorio.">*</asp:RequiredFieldValidator>
    </div>
    <div class="columna-left-160">
        <p>
            Comunidad
        </p>
    </div>
    <div class="columna-right">
        <asp:DropDownList runat="server" ID="ddlComunidad" CssClass="select_option">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlComunidad"
            Display="None" ErrorMessage="La Comunidad es Obligatoria.">*</asp:RequiredFieldValidator>
    </div>
    <div class="borde_bottom cf">
    </div>
</asp:Panel>
