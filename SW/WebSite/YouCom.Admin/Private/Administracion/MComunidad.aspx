<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Admin/Home.master" AutoEventWireup="true" CodeFile="MComunidad.aspx.cs" Inherits="YouCom.Web.Private.Administracion.Comunidad" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/App_Master/Admin/Controls/BannerCentral.ascx" TagName="BannerCentral" TagPrefix="uc1" %>
<%@ Register Src="~/App_Master/Admin/Controls/GenericError.ascx" TagName="GenericError" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Panel ID="pnlProducto" runat="server" Visible="true">
        <asp:MultiView ID="mvwEmpresa" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                    ShowSummary="false" />
                <table>
                    <tr>
                        <td>Condominio
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlCondominio">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCondominio"
                                Display="None" ErrorMessage="El Condominio es Obligatorio.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Nombre Comunidad
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtNombre" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                                TargetControlID="txtNombre" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre"
                                Display="None" ErrorMessage="Nombre es campo Obligatorio."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Dirección Comunidad
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDireccion" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                                TargetControlID="txtDireccion" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDireccion"
                                Display="None" ErrorMessage="Dirección es campo Obligatorio."></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" />
                        </td>
                        <td>
                            <asp:Button runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Panel runat="server" ID="pnlAdministracionComunidad">
                    <h2>Listado de Comunidades</h2>
                    <asp:Repeater ID="rptComunidad" OnItemCommand="rptComunidad_OnItemCommand" runat="server">
                        <HeaderTemplate>
                            <div class="conte_box_white">
                                <div class="conte_tabla_datos_body_detail ">
                                    <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <th class="w10">Id
                                            </th>
                                            <th class="w20">Condominio
                                            </th>
                                            <th class="w20">Nombre
                                            </th>
                                            <th class="w20">Dirección
                                            </th>
                                            <th class="w10">Usuario Ingreso
                                            </th>
                                            <th class="w10">Fecha Ingreso
                                            </th>
                                            <th class="w10">Usuario Modificacion
                                            </th>
                                            <th class="w10">Fecha Mofificacion
                                            </th>
                                            <th class="w10">Editar
                                            </th>
                                            <th class="w10">Eliminar
                                            </th>
                                        </tr>
                                    </table>
                                    <div class="conte_tabla_datos_body_gr">
                                        <table class="tabla_datos_body" border="0" cellspacing="0" cellpadding="0">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="w10 txt-left">
                                    <%# DataBinder.Eval(Container.DataItem, "IdComunidad")%>
                                </td>
                                <td class="w20 txt-left">
                                    <%# DataBinder.Eval(Container.DataItem, "NombreCondominio")%>
                                </td>
                                <td class="w20 txt-left">
                                    <%# DataBinder.Eval(Container.DataItem, "NombreComunidad")%>
                                </td>
                                <td class="w20 txt-left">
                                    <%# DataBinder.Eval(Container.DataItem, "DireccionComunidad")%>
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
                                    <asp:LinkButton ID="LnkBtnEditar" CausesValidation="false" runat="server" ToolTip="Editar Casa"
                                        CommandName="Editar"><span class="icon_edit"></span></asp:LinkButton>
                                    <asp:HiddenField ID="hdnComunidadId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdComunidad")%>' />
                                </td>
                                <td class="w10">
                                    <asp:LinkButton ID="LnkBtnEliminar" runat="server" ToolTip="Eliminar" CausesValidation="false"
                                        CommandName="Eliminar"><span class="icon_trash"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table></div></div></div>
                        </FooterTemplate>
                    </asp:Repeater>
                </asp:Panel>
                <asp:Panel ID="pnlPapelera" runat="server" Visible="false">
                    <asp:Repeater ID="rptComunidadInactivo" OnItemCommand="rptComunidadInactivo_OnItemCommand"
                        runat="server">
                        <HeaderTemplate>
                            <div class="conte_box_white">
                                <div class="conte_tabla_datos_body_detail ">
                                    <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <th class="w10">Id
                                            </th>
                                            <th class="w20">Condominio
                                            </th>
                                            <th class="w20">Nombre
                                            </th>
                                            <th class="w20">Dirección
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
                                    <%# DataBinder.Eval(Container.DataItem, "IdComunidad")%>
                                </td>
                                <td class="w20 txt-left">
                                    <%# DataBinder.Eval(Container.DataItem, "NombreCondominio")%>
                                </td>
                                <td class="w20 txt-left">
                                    <%# DataBinder.Eval(Container.DataItem, "NombreComunidad")%>
                                </td>
                                <td class="w20 txt-left">
                                    <%# DataBinder.Eval(Container.DataItem, "DireccionComunidad")%>
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
                                    <asp:LinkButton ID="LnkBtnCodPropuesta" CausesValidation="false" runat="server" ToolTip="Editar Tipo"
                                        CommandName="Activar">Activar Registro</asp:LinkButton>
                                    <asp:HiddenField ID="hdnComunidadId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdComunidad")%>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table></div></div></div>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:HiddenField runat="server" ID="hdnComunidadId" />
                </asp:Panel>
            </asp:View>
        </asp:MultiView>
    </asp:Panel>
    <asp:Panel ID="pnlSinProducto" Visible="false" runat="server">
        <uc1:bannercentral id="BannerCentral1" runat="server" />
    </asp:Panel>
    <asp:Panel ID="pnlGenericError" runat="server" Visible="false">
        <uc1:genericerror id="GenericError1" runat="server" />
    </asp:Panel>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="DatosEmpresa" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="DatosUsuario" />



</asp:Content>

