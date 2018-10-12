<%@ page title="" language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Privado_Eventos, App_Web_2_3use4y" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Eventos</h1>
    <div class="row">
        <asp:Repeater ID="rptEvento" runat="server" OnItemDataBound="rptEvento_ItemDataBound">
            <ItemTemplate>
                <div class="noticia col-sm-4">
                    <asp:Image ID="Image1" CssClass="noticia-imagen" runat="server" Width="100%" Height="100%" />
                    <h3 class="subtitle">
                        <%# DataBinder.Eval(Container.DataItem, "EventoTitulo")%></h3>
                    <p class="noticia-resumen">
                        <%# DataBinder.Eval(Container.DataItem, "EventoResumen")%></p>
                    <a class="noticia-link" href="DetalleEvento.aspx?id=<%# DataBinder.Eval(Container.DataItem, "EventoId")%>">Ver Evento</a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
