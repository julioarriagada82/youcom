<%@ page title="" language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Privado_Directiva, App_Web_2_3use4y" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Directiva</h1>
    <div class="row">
        <asp:Repeater ID="rptDirectiva" runat="server" OnItemDataBound="rptDirectiva_ItemDataBound">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="directivo col-sm-6 col-md-4">
                    <img src="../img/no-user.jpg" alt="No Photo" class="img-thumbnail">
                    <h4>
                        <asp:Literal ID="LitCargo" runat="server"></asp:Literal> </h4>
                    <h3>
                        <%# DataBinder.Eval(Container.DataItem, "NombreDirectiva")%>
                            <%# DataBinder.Eval(Container.DataItem, "ApellidoDirectiva")%></h3>
                    <p>
                        Teléfono: <%# DataBinder.Eval(Container.DataItem, "TelefonoDirectiva")%></p>
                    <p>
                        Email: 
                        <asp:HyperLink ID="LnkContactar" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmailDirectiva")%>'></asp:HyperLink>
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
