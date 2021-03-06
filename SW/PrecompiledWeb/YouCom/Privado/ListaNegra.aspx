﻿<%@ page title="" language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Privado_ListaNegra, App_Web_2_3use4y" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Lista Negra</h1>
    <asp:Repeater ID="rptListaNegra" runat="server">
        <ItemTemplate>
            <div class="blacklist">
                <p class="idnumber">
                    <%# YouCom.Service.Generales.Formato.FormatoRut(DataBinder.Eval(Container.DataItem, "RutListaNegra").ToString())%></p>
                <p class="titulo">
                    <%# DataBinder.Eval(Container.DataItem, "NombreCompleto")%></p>
                <p class="motivo">
                    Motivo:
                    <%# DataBinder.Eval(Container.DataItem, "MotivoListaNegra")%></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
