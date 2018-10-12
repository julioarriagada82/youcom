<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true"
    CodeFile="Directiva.aspx.cs" Inherits="Privado_Directiva" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Directiva</h1>
    <div class="row">
        <asp:Repeater ID="rptDirectiva" runat="server" OnItemDataBound="rptDirectiva_ItemDataBound" OnItemCommand="rptDirectiva_ItemCommand">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="directivo col-sm-6 col-md-4">
                    <asp:Image ID="imgDirectiva" CssClass="img-thumbnail" runat="server" Width="150px" Height="150px" />
                    <h4>
                        <%# DataBinder.Eval(Container.DataItem, "TheCargoDTO.NombreCargo")%> </h4>
                    <h3>
                        <%# DataBinder.Eval(Container.DataItem, "NombreCompleto")%>
                    <p>
                        Teléfono: <%# DataBinder.Eval(Container.DataItem, "TelefonoDirectiva")%></p>
                    <p>
                        Email: 
                        <asp:HyperLink ID="LnkContactar" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmailDirectiva")%>'></asp:HyperLink>
                        <asp:LinkButton ID="LnkBtnContactar" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmailDirectiva")%>' CommandName="Contactar"></asp:LinkButton>
                        <asp:HiddenField ID="hdnIdDirectiva" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdDirectiva")%>' />
                    </p>
                        
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
