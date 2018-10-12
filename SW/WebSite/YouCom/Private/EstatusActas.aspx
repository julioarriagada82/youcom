<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true" CodeFile="EstatusActas.aspx.cs" Inherits="Privado_EstatusActas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Estatus y Actas</h1>
    <div class="row">
        <div class="procedimientos col-sm-6">
            <asp:Repeater ID="rptEstatus" runat="server" OnItemDataBound="rptEstatus_ItemDataBound">
                <ItemTemplate>
                    <div class="procedimiento">
                        <p class="titulo">
                            <%# DataBinder.Eval(Container.DataItem, "ArchivoTitulo")%></p>
                        <asp:HyperLink ID="hlDescarga" CssClass="archivo" runat="server"></asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="actas col-sm-6">
            <asp:Repeater ID="rptActas" runat="server" OnItemDataBound="rptActas_ItemDataBound">
                <ItemTemplate>
                    <div class="procedimiento">
                        <p class="titulo">
                            <%# DataBinder.Eval(Container.DataItem, "ArchivoTitulo")%></p>
                        <asp:HyperLink ID="hlDescarga" CssClass="archivo" runat="server"></asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
