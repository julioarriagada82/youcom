<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true" CodeFile="VotacionIniciativa.aspx.cs" Inherits="Privado_VotacionIniciativa" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Listado de Iniciativas</h1>
    <asp:MultiView ID="mvwVotacion" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:Repeater ID="rptVotacion" runat="server" OnItemCommand="rptVotacion_ItemCommand">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="estado-financiero">
                        <p class="titulo">
                            <%# DataBinder.Eval(Container.DataItem, "ThePropuestaDTO.NombrePropuesta")%>
                            <asp:HiddenField ID="hdnIdPropuesta" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ThePropuestaDTO.IdPropuesta")%>' />
                            <asp:HiddenField ID="hdnIdVotacionPropuesta" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdVotacionPropuesta")%>' />
                        </p>
                        <asp:LinkButton ID="lnkBtnVerDetalle" runat="server" Text="Ver Detalle" CommandName="Detalle"></asp:LinkButton>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div id="conte">
                <table width="100%">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>
                                        <div class="articulo_dest col_3">
                                            <h3>
                                                <asp:Literal ID="LitPropuestaNombre" runat="server"></asp:Literal>
                                                <asp:HiddenField ID="hdnVotacionPropuestaId" runat="server" />
                                            </h3>
                                            <p>
                                                <asp:Literal ID="LitPropuestaFecha" runat="server"></asp:Literal>
                                            </p>
                                            <p>
                                                <asp:Literal ID="LitNombreFamilia" runat="server"></asp:Literal>
                                            </p>
                                            <p>
                                                <asp:Literal ID="LitPropuestaDecripcion" runat="server"></asp:Literal>
                                            </p>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rdbSeleccion" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="SI" Value="S"></asp:ListItem>
                                            <asp:ListItem Text="NO" Value="N"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <div class="col-md-offset-2 col-sm-12 col-md-10">
                                                <asp:Button ID="BtnEnviar" runat="server" CssClass="btn btn-default" Text="Enviar Votación"
                                                    ValidationGroup="DatosPaso1" OnClick="BtnEnviar_Click" />
                                            </div>
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
        </asp:View>

    </asp:MultiView>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
