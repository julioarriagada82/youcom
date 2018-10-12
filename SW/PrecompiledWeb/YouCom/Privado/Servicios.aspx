<%@ page language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Privado_Servicios, App_Web_2_3use4y" title="Untitled Page" enableEventValidation="false" %>

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
                <td style="width: 20px">
                </td>
                <td>
                    <asp:Repeater ID="rptCategoria" runat="server" OnItemDataBound="rptCategoria_ItemDataBound">
                        <HeaderTemplate>
                            <td style="width: 859px">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div>
                                <h2>
                                    <%# DataBinder.Eval(Container.DataItem, "NombreCategoria")%>
                                </h2>
                                <asp:Repeater ID="rptServicio" runat="server" OnItemDataBound="rptServicio_ItemDataBound">
                                    <HeaderTemplate>
                                        <ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <div class="articulo_dest col_3">
                                                <div>
                                                    <asp:Image ID="imgLogo" CssClass="left" runat="server" Width="180" Height="93" />
                                                </div>
                                                <h3>
                                                    <%# DataBinder.Eval(Container.DataItem, "NombreServicio")%></h3>
                                                <p>
                                                    Direccion:
                                                    <%# DataBinder.Eval(Container.DataItem, "DireccionServicio")%></p>
                                                <p>
                                                    Telefono:
                                                    <%# DataBinder.Eval(Container.DataItem, "TelefonoServicio")%></p>
                                                <p>
                                                    Descripcion:
                                                    <%# DataBinder.Eval(Container.DataItem, "DescripcionServicio")%></p>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </ul>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                            <br />
                            <div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </td>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
        <div class="cf">
        </div>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
