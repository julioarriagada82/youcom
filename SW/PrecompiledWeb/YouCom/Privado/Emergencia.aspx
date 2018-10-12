<%@ page title="" language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Privado_Emergencia, App_Web_2_3use4y" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Emergencia</h1>
    <asp:Repeater ID="rptEmergencia" runat="server">
        <ItemTemplate>
            <div class="blacklist">
                <p class="titulo">
                    <%# DataBinder.Eval(Container.DataItem, "NombreEmergencia")%></p>
                <p class="motivo">
                    Motivo:
                    <%# DataBinder.Eval(Container.DataItem, "DescripcionEmergencia")%></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
