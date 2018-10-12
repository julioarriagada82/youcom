<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true"
    CodeFile="ListaNegra.aspx.cs" Inherits="Privado_ListaNegra" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">Lista Negra</h1>
    <div class="row">
        <asp:Repeater ID="rptListaNegra" runat="server">
            <ItemTemplate>
                <div class="col-sm-6 col-md-4">
                    <div class="thumbnail">
                        <p class="idnumber">
                            <%# YouCom.Service.Generales.Formato.FormatoRut(DataBinder.Eval(Container.DataItem, "RutListaNegra").ToString())%>
                        </p>
                        <p class="titulo">
                            <%# DataBinder.Eval(Container.DataItem, "NombreCompleto")%>
                        </p>
                        <p class="motivo">
                            Motivo:
                    <%# DataBinder.Eval(Container.DataItem, "MotivoListaNegra")%>
                        </p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
