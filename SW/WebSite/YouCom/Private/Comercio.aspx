<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true"
    CodeFile="Comercio.aspx.cs" Inherits="Privado_Comercio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Comercios</h1>
    <div class="row">
        <asp:Repeater ID="rptComercio" runat="server" OnItemDataBound="rptComercio_ItemDataBound">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="directivo col-sm-6 col-md-4">
                    <asp:Image ID="imgLogo" CssClass="left" runat="server" Width="180" Height="93" />
                    <h4>
                        Categoria</h4>
                    <h3>
                        <%# DataBinder.Eval(Container.DataItem, "NombreComercio")%></h3>
                    <p>
                        Dirección:
                        <%# DataBinder.Eval(Container.DataItem, "DireccionComercio")%></p>
                    <p>
                        Telefono:
                        <%# DataBinder.Eval(Container.DataItem, "TelefonoComercio")%></p>
                    <p>
                        URL:
                        <asp:HyperLink ID="hlUrl" runat="server"></asp:HyperLink></p>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
