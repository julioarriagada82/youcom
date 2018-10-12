<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true" CodeFile="GastosComunes.aspx.cs" Inherits="Privado_GastosComunes_GastosComunes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:MultiView ID="mvwAutorizaciones" runat="server">
        <asp:View ID="View1" runat="server">
            <h1 class="page-header">Estado Gastos Comunes</h1>
            <%--<div class="btn-toolbar" role="toolbar">
                <asp:LinkButton ID="BntAgregar" runat="server" CssClass="btn btn-default btn-lg pull-left" Text="Agregar Acceso" ValidationGroup="DatosPaso1" OnClick="BntAgregar_Click" />
            </div>--%>
            <div class="row">
                <asp:Repeater ID="rptGastosComunes" runat="server" OnItemDataBound="rptGastosComunes_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Fecha
                                    </th>
                                    <th>Monto
                                    </th>
                                    <th>Estado
                                    </th>
                                    <th>Fecha Vencimiento
                                    </th>
                                    <th>Detalle
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaGasto")).ToShortDateString()%>
                            </td>
                            <td>
                                <%# YouCom.Service.Generales.Formato.FormatoMontoPeso(DataBinder.Eval(Container.DataItem, "MontoGasto").ToString(), true)%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "TheGastoComunEstadoDTO.NombreGastoComunEstado")%>
                            </td>
                            <td>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaVencimiento")).ToShortDateString()%>
                            </td>
                            <td>
                                <asp:HyperLink ID="LnkDetalle" runat="server">
                                </asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>

            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>

