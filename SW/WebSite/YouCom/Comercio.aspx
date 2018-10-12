<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Login.master" AutoEventWireup="true"
    CodeFile="Comercio.aspx.cs" Inherits="Comercio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="conte">
        <h2>
            HOME</h2>
        <table width="100%">
            <tr>
                <td style="width: 159px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 159px">
                    <table>
                        <tr>
                            <td>
                                Usuario
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtUsuario" Width="147px" onblur="return validaRut(this)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Password
                            </td>
                            <td>
                                <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" Width="143px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="btnIngresar" Text="Ingresar" OnClick="btnIngresar_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
                        ValidationGroup="DatosPaso1" />
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
                                <asp:Repeater ID="rptComercio" runat="server" OnItemDataBound="rptComercio_ItemDataBound">
                                    <HeaderTemplate>
                                        <ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <div class="articulo_dest col_3">
                                            <h3><%# DataBinder.Eval(Container.DataItem, "NombreComercio")%></h3>
                                            <p>
                                                Direccion: <%# DataBinder.Eval(Container.DataItem, "DireccionComercio")%></p>
                                            <p>
                                                Telefono: <%# DataBinder.Eval(Container.DataItem, "TelefonoComercio")%></p>
                                            <p>
                                                URL: <asp:HyperLink ID="hlUrl" runat="server"></asp:HyperLink></p>
                                        </div>
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </ul>
                                    </FooterTemplate>
                                </asp:Repeater>
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
</asp:Content>
