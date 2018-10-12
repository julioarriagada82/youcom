<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/Admin/Home.master"
    CodeFile="MFuncionGrupo.aspx.cs" Inherits="Administracion_MFuncionGrupo" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/App_Master/Admin/Controls/BannerCentral.ascx" TagName="BannerCentral" TagPrefix="uc1" %>
<%@ Register Src="~/App_Master/Admin/Controls/GenericError.ascx" TagName="GenericError" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlProducto" runat="server" Visible="true">
        <asp:Panel runat="server" ID="pnlAdministracionFuncionGrupo">
            <asp:Label runat="server" ID="lblPopUp"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                ShowSummary="false" />
            <div class="tit_box_white">
                Mantenedor de Grupos de funciones
            </div>
            <div class="conte_box_whitetabs">
                <div class="columna-left-160">
                    <p>
                        Grupo
                    </p>
                </div>
                <div class="columna-right">
                    <asp:TextBox runat="server" ID="txtGrupo" CssClass="texto_option" MaxLength="60"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGrupo"
                        Display="None" ErrorMessage="Grupo es campo Obligatorio."></asp:RequiredFieldValidator>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                        TargetControlID="txtGrupo" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                    </cc1:FilteredTextBoxExtender>
                </div>
                <div class="mt10">
                    <asp:LinkButton runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" CssClass="BigButton" />
                    <asp:LinkButton runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" CssClass="BigButton" />
                    <asp:ImageButton Text="Ver Papeleria" OnClick="lblPapeleria_OnClick" ImageUrl="~/images/iconos/bot_papelera.jpg"
                        AlternateText="Papelera" ToolTip="Papelera" CausesValidation="false" ID="lblPapeleria"
                        runat="server"></asp:ImageButton>
                </div>
            </div>
            <asp:Repeater ID="rptGrupo" OnItemCommand="rptGrupo_OnItemCommand" runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w10 titulos">Id
                                    </th>
                                    <th class="w20 titulos">Descripcion
                                    </th>
                                    <th class="w10 titulos">Usuario Ingreso
                                    </th>
                                    <th class="w10 titulos">Fecha Ingreso
                                    </th>
                                    <th class="w10 titulos">Usuario Modificacion
                                    </th>
                                    <th class="w10 titulos">Fecha Mofificacion
                                    </th>
                                    <th class="w10 titulos">Editar
                                    </th>
                                    <th class="w10 titulos">Eliminar
                                    </th>
                                </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th class="w10 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "FuncionGrupoCod")%>
                        </th>
                        <th class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "FuncionGrupoNombre")%>
                        </th>
                        <th class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "usuarioIngreso")%>
                        </th>
                        <th class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "fechaIngreso")%>
                        </th>
                        <th class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "usuarioModificacion")%>
                        </th>
                        <th class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "fechaModificacion")%>
                        </th>
                        <th class="w10">
                            <asp:LinkButton ID="LnkBtnCodPropuesta" CausesValidation="false" runat="server" ToolTip="Editar Grupo"
                                CommandName="Editar"><span class="icon_edit"></span></asp:LinkButton>
                            <asp:HiddenField ID="hdnDescripcion" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "FuncionGrupoNombre")%>' />
                            <asp:HiddenField ID="HdnTipoSistema" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "FuncionGrupoCod")%>' />
                        </th>
                        <th class="w10">
                            <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Eliminar" CausesValidation="false"
                                CommandName="Eliminar"><span class="icon_trash"></span></asp:LinkButton>
                        </th>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField runat="server" ID="HidIdTipoEtapa" />
        </asp:Panel>
        <asp:Panel ID="pnlPapelera" runat="server" Visible="false">
            <asp:Repeater ID="rptGrupoInactivo" OnItemCommand="rptGrupoInactivo_OnItemCommand"
                runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w10">Id
                                    </th>
                                    <th class="w20">Descripcion
                                    </th>
                                    <th class="w10">Usuario Ingreso
                                    </th>
                                    <th class="w10">Fecha Ingreso
                                    </th>
                                    <th class="w10">Usuario Modificacion
                                    </th>
                                    <th class="w10">Fecha Mofificacion
                                    </th>
                                    <th class="w10">Activar
                                    </th>
                                </tr>
                            </table>
                            <div class="conte_tabla_datos_body_gr">
                                <table class="tabla_datos_body" border="0" cellspacing="0" cellpadding="0">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="w10 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "FuncionGrupoCod")%>
                        </td>
                        <td class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "FuncionGrupoNombre")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "usuarioIngreso")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "fechaIngreso")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "usuarioModificacion")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "fechaModificacion")%>
                        </td>
                        <td class="w10">
                            <asp:LinkButton ID="LnkBtnCodPropuesta" CausesValidation="false" runat="server" ToolTip="Editar Grupo"
                                CommandName="Activar">Activar Registro</asp:LinkButton>
                            <asp:HiddenField ID="hdnDescripcion" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "FuncionGrupoNombre")%>' />
                            <asp:HiddenField ID="HdnTipoSistema" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "FuncionGrupoCod")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></div></div></div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField runat="server" ID="HiddenField1" />
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="pnlSinProducto" Visible="false" runat="server">
        <uc1:BannerCentral ID="BannerCentral1" runat="server" />
    </asp:Panel>
    <asp:Panel ID="pnlGenericError" runat="server" Visible="false">
        <uc1:GenericError ID="GenericError1" runat="server" />
    </asp:Panel>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="DatosEmpresa" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="DatosUsuario" />
</asp:Content>
