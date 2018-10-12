<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true"
    CodeFile="Vecinos.aspx.cs" Inherits="Privado_Vecinos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Mis vecinos</h1>
    <asp:Repeater ID="rptCasa" runat="server" OnItemDataBound="rptCasa_ItemDataBound">
        <ItemTemplate>
            <h1 class="page-header">
                <%# DataBinder.Eval(Container.DataItem, "NombreCasa")%></h1>
            <asp:Repeater ID="rptIntegrantes" runat="server" OnItemCommand="rptIntegrantes_OnItemCommand">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="estado-financiero">
                        <p class="titulo">
                            <asp:HiddenField ID="hdnFamiliaId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdFamilia")%>'/>
                            <%# YouCom.Service.Generales.Formato.FormatoRut(DataBinder.Eval(Container.DataItem, "RutFamilia").ToString())%>
                            -
                            <%# DataBinder.Eval(Container.DataItem, "NombreCompleto")%> <asp:LinkButton ID="LnkBtnContactar" runat="server" Text="Contactar" CommandName="Contactar"></asp:LinkButton></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            </ul>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
