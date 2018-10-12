<%@ Page Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true" CodeFile="DetalleEvento.aspx.cs" Inherits="Privado_DetalleEvento" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="conte">
        <table width="100%">
            <tr>
                <td style="width: 159px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <uc1:uscMenuPrivado ID="uscMenuPrivado1" runat="server" />
                <td style="width: 20px"></td>
                <td>
                    <table width="100%">
                        <tr>
                            <td>
                                <div class="articulo_dest col_3">
                                    <h3>
                                        <asp:Literal ID="LitEventoTitulo" runat="server"></asp:Literal>
                                    </h3>
                                    <p>
                                        <asp:Literal ID="LitEventoResumen" runat="server"></asp:Literal>
                                     </p>
                                    <p>
                                        <asp:Literal ID="LitEventoDetalle" runat="server"></asp:Literal></p>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div class="cf">
        </div>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
