<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCBotonesMensaje.ascx.cs" Inherits="App_Master_Controls_WUCBotonesMensaje" %>
<div class="btn-toolbar" role="toolbar">
    <asp:LinkButton ID="LnkBtnPublicarMensaje" CausesValidation="false" runat="server" CssClass="btn btn-default btn-lg pull-right" OnClick="LnkBtnPublicarMensaje_Click">
                        <span class="glyphicon glyphicon-upload"></span> Publicar</asp:LinkButton>
    <asp:LinkButton ID="LnkBtnNotificaciones" CausesValidation="false" runat="server" CssClass="btn btn-default btn-lg pull-right" OnClick="LnkBtnNotificaciones_Click">
                        <span class="glyphicon glyphicon-comment"></span><span class="badge"><asp:Literal ID="LitCantidadNotificaciones" runat="server"></asp:Literal></span></asp:LinkButton>
    <asp:LinkButton ID="LnkBtnBusqueda" CausesValidation="false" runat="server" CssClass="btn btn-default btn-lg pull-right" OnClick="LnkBtnBusqueda_Click">
                        <span class="glyphicon glyphicon-search"></span></asp:LinkButton>
</div>
