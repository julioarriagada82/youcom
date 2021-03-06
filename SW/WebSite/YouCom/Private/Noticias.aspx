﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true"
    CodeFile="Noticias.aspx.cs" Inherits="Privado_Noticias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Noticias</h1>
    <div class="row">
        <asp:Repeater ID="rptNoticia" runat="server" OnItemDataBound="rptNoticia_ItemDataBound">
            <ItemTemplate>
                <div class="noticia col-sm-4">
                    <asp:Image ID="imgNoticia" CssClass="noticia-imagen" runat="server" Width="100%" Height="100%" />
                    <h3 class="subtitle">
                        <%# DataBinder.Eval(Container.DataItem, "NotiTitulo")%></h3>
                    <p class="noticia-resumen">
                        <%# DataBinder.Eval(Container.DataItem, "NotiResumen")%></p>
                    <a class="noticia-link" href="DetalleNoticia.aspx?id=<%# DataBinder.Eval(Container.DataItem, "NoticiaId")%>">
                        Ver noticia</a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
