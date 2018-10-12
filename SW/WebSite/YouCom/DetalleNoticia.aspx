<%@ Page Language="C#" MasterPageFile="~/App_Master/Login.master" AutoEventWireup="true"
    CodeFile="DetalleNoticia.aspx.cs" Inherits="Privado_DetalleNoticia" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"
                        ValidationGroup="DatosPaso1" />
                </td>
                <td>
                    <table width="100%">
                        <tr>
                            <td>
                                <div class="articulo_dest col_3">
                                    <h3>
                                        <asp:Literal ID="LitNoticiaTitulo" runat="server"></asp:Literal>
                                    </h3>
                                    <p>
                                        <asp:Literal ID="LitNoticiaResumen" runat="server"></asp:Literal>
                                     </p>
                                    <p>
                                        <asp:Literal ID="LitNoticiaDetalle" runat="server"></asp:Literal></p>
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
