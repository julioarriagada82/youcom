<%@ page title="" language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Privado_Vecinos, App_Web_2_3use4y" enableEventValidation="false" %>

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
            <asp:Repeater ID="rptIntegrantes" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="estado-financiero">
                        <p class="titulo">
                            <%# YouCom.Service.Generales.Formato.FormatoRut(DataBinder.Eval(Container.DataItem, "RutFamilia").ToString())%>
                            -
                            <%# DataBinder.Eval(Container.DataItem, "NombreCompleto")%></p>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
