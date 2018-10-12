<%@ Page Language="C#" MasterPageFile="~/App_Master/Login.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

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
                    <div class="container">
                        <div id="slides">
                            <asp:Repeater ID="rptBanner" runat="server" OnItemDataBound="rptBanner_ItemDataBound">
                            <ItemTemplate>
                                <asp:Image ID="imgBanner" CssClass="left" runat="server" Width="700" Height="280" />
                            </ItemTemplate>
                        </asp:Repeater>
                        </div>
                    </div>
                    <div style="height: 25px">
                    </div>
                    <table width="100%">
                        <tr>
                            <asp:Repeater ID="rptNoticia" runat="server" OnItemDataBound="rptNoticia_ItemDataBound">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <td>
                                        <div class="articulo_dest col_3">
                                            <asp:Image ID="imgNoticia" CssClass="left" runat="server" Width="180" Height="93" />
                                            <h3>
                                                <a href="DetalleNoticia.aspx?id=<%# DataBinder.Eval(Container.DataItem, "NoticiaId")%>">
                                                    <%# DataBinder.Eval(Container.DataItem, "NotiTitulo")%></a></h3>
                                            <p>
                                                <%# DataBinder.Eval(Container.DataItem, "NotiResumen")%><a href="DetalleNoticia.aspx?id=<%# DataBinder.Eval(Container.DataItem, "NoticiaId")%>">(Ver más)</a></p>
                                        </div>
                                    </td>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div class="cf">
        </div>
    </div>
</asp:Content>
