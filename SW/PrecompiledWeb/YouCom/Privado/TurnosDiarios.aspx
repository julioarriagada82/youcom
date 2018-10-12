<%@ page title="" language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Privado_TurnosDiarios, App_Web_2_3use4y" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Turnos Diarios</h1>
    <asp:Repeater ID="rptTurnos" runat="server" OnItemDataBound="rptTurnos_ItemDataBound">
        <ItemTemplate>
            <div class="blacklist">
                <p class="titulo">
                    <%# DataBinder.Eval(Container.DataItem, "NombreTurnoDiario")%></p>
                <asp:Repeater ID="rptPortero" runat="server">
                    <ItemTemplate>
                        <p class="idnumber">
                            <%# YouCom.Service.Generales.Formato.FormatoRut(DataBinder.Eval(Container.DataItem, "RutPorteria").ToString())%></p>
                        <p class="titulo">
                            <%# DataBinder.Eval(Container.DataItem, "NombrePorteria")%>
                            <%# DataBinder.Eval(Container.DataItem, "ApellidoPorteria")%></p>
                        <p class="motivo">
                            <%# DataBinder.Eval(Container.DataItem, "EmailPorteria")%></p>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="rptHorario" runat="server" OnItemDataBound="rptHorario_ItemDataBound">
                    <ItemTemplate>
                        <p class="titulo">
                            <asp:Literal ID="LitPeriodo" runat="server"></asp:Literal></p>
                        <p class="idnumber">
                            Horario de
                            <%# DataBinder.Eval(Container.DataItem, "HoraInicio")%>
                            -
                            <%# DataBinder.Eval(Container.DataItem, "HoraTermino")%></p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
