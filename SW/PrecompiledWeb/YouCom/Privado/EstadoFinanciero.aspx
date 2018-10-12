<%@ page title="" language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Privado_EstadoFinanciero, App_Web_2_3use4y" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater ID="rptCategoria" runat="server" OnItemDataBound="rptCategoria_ItemDataBound">
        <ItemTemplate>
            <h1 class="page-header">
                <%# DataBinder.Eval(Container.DataItem, "NombreCategoria")%></h1>
            <asp:Repeater ID="rptArchivo" runat="server" OnItemDataBound="rptArchivo_ItemDataBound">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="estado-financiero">
                        <p class="titulo">
                            <%# DataBinder.Eval(Container.DataItem, "ArchivoTitulo")%></p>
                        <asp:HyperLink ID="hlDescarga" CssClass="archivo" runat="server"></asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
