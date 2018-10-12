<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Admin/Home.master" AutoEventWireup="true" CodeFile="MVotacionPropuesta.aspx.cs" Inherits="Admin_Administracion_MVotacionPropuesta" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/App_Master/Admin/Controls/BannerCentral.ascx" TagName="BannerCentral" TagPrefix="uc1" %>
<%@ Register Src="~/App_Master/Admin/Controls/GenericError.ascx" TagName="GenericError" TagPrefix="uc1" %>

<%@ Register Src="../../App_Master/Admin/Controls/wucCondominioCasaFamilia.ascx" TagName="wucCondominioCasaFamilia" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlProducto" runat="server" Visible="true">
        <div class="tit_box_white">
            Listado de Votaciones de Propuestas
        </div>
        <div class="conte_box_whitetabs">
            <uc1:wucCondominioCasaFamilia ID="wucCondominioCasaFamilia1" runat="server" />
            <div class="columna-left-160">
                <p>
                    Nombre
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="txtVotacionPropuestaNombre" runat="server" TextMode="SingleLine" Width="750px"
                    MaxLength="300" />
                <asp:RequiredFieldValidator ID="RFVTxtContTitulo" runat="server" ControlToValidate="txtVotacionPropuestaNombre"
                    Display="None" ErrorMessage="Ingrese Nombre por favor" />
                <cc1:FilteredTextBoxExtender ID="FTEBannerNombre" runat="server" TargetControlID="txtVotacionPropuestaNombre"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Descripción
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="txtVotacionPropuestaDescripcion" runat="server" TextMode="MultiLine"
                    MaxLength="200" Columns="100" Rows="20" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVotacionPropuestaDescripcion"
                    Display="None" ErrorMessage="Ingrese Descripción por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtVotacionPropuestaDescripcion"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Fecha Ingreso
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="FechaIngreso" runat="server" CssClass="campo_txt" Columns="10"
                    Width="60px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="FechaIngreso"
                    Format="dd/MM/yyyy" TargetControlID="FechaIngreso" />
                <cc1:MaskedEditExtender ID="FechaIngreso_MaskedEditExtender" runat="server" Mask="99/99/9999"
                    MaskType="Date" TargetControlID="FechaIngreso" CultureName="es-ES">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="FechaIngreso_MaskedEditExtender"
                    ControlToValidate="FechaIngreso" Display="None" EmptyValueMessage="Fecha Ingreso"
                    ErrorMessage="Fecha Ingreso no válida." InvalidValueMessage="Fecha Ingreso no válida."
                    IsValidEmpty="False" SetFocusOnError="True">*
                </cc1:MaskedEditValidator>
            </div>
            <div class="columna-left-160">
                <p>
                    Fecha Termino
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="FechaTermino" runat="server" CssClass="campo_txt" Columns="10"
                    Width="60px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="FechaTermino"
                    Format="dd/MM/yyyy" TargetControlID="FechaTermino" />
                <cc1:MaskedEditExtender ID="FechaTermino_MaskedEditExtender" runat="server" Mask="99/99/9999"
                    MaskType="Date" TargetControlID="FechaTermino" CultureName="es-ES">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="FechaTermino_MaskedEditExtender"
                    ControlToValidate="FechaTermino" Display="None" EmptyValueMessage="Fecha Termino"
                    ErrorMessage="Fecha Termino no válida." InvalidValueMessage="Fecha Termino no válida."
                    IsValidEmpty="False" SetFocusOnError="True">*
                </cc1:MaskedEditValidator>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Cantidad Si
                </p>
            </div>
            <div class="columna-right">
                <asp:Literal ID="LitCantidadSi" runat="server"></asp:Literal>
            </div>
            <div class="columna-left-160">
                <p>
                    Cantidad No
                </p>
            </div>
            <div class="columna-right">
                <asp:Literal ID="LitCantidadNo" runat="server"></asp:Literal>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Estado
                </p>
            </div>
            <div class="columna-right">
                <asp:DropDownList runat="server" ID="ddlEstado" CssClass="select_option" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlEstado"
                    Display="None" ErrorMessage="El estado es Obligatorio.">*</asp:RequiredFieldValidator>
            </div>
            <asp:Panel ID="pnlEstado" runat="server" Visible="false">
                <div class="columna-left-160">
                    <p>
                        Motivo
                    </p>
                </div>
                <div class="columna-right">
                    <asp:TextBox ID="txtMotivoEstado" runat="server" TextMode="MultiLine"
                        MaxLength="200" Columns="50" Rows="10" />
                </div>
            </asp:Panel>
            <div class="mt10">
                <asp:LinkButton runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" CssClass="BigButton" />
                <asp:LinkButton runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" CssClass="BigButton" />
                <asp:ImageButton Text="Ver Papeleria" OnClick="lblPapeleria_OnClick" ImageUrl="~/images/iconos/bot_papelera.jpg"
                    AlternateText="Papelera" ToolTip="Papelera" CausesValidation="false" ID="lblPapeleria"
                    runat="server"></asp:ImageButton>
            </div>
            <div class="cf">
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlAdministracionVotacionPropuesta">
            <asp:Repeater ID="rptVotacionPropuesta" OnItemCommand="rptVotacionPropuesta_OnItemCommand" runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white_gr">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w10 titulos">Nombre Propuesta
                                    </th>
                                    <th class="w10 titulos">Familia
                                    </th>
                                    <th class="w10 titulos">Fecha Inicio
                                    </th>
                                    <th class="w10 titulos">Fecha Termino
                                    </th>
                                    <th class="w10 titulos">Estado Votación
                                    </th>
                                    <th class="w10 titulos">Usuario Ingreso
                                    </th>
                                    <th class="w10 titulos">Fecha Ingreso
                                    </th>
                                    <th class="w10 titulos">Usuario Modificacion
                                    </th>
                                    <th class="w10 titulos">Fecha Mofificacion
                                    </th>
                                    <th class="w10 titulos">Ver
                                    </th>
                                    <th class="w10 titulos">Votaciones
                                    </th>
                                    <th class="w10 titulos">Eliminar
                                    </th>
                                </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th class="w10 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "ThePropuestaDTO.NombrePropuesta")%>
                        </th>
                        <th class="w10 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "ThePropuestaDTO.TheFamiliaDTO.NombreCompleto")%>
                        </th>
                        <th class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "FechaInicioVotacionPropuesta")%>
                        </th>
                        <th class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "FechaTerminoVotacionPropuesta")%>
                        </th>
                        <th class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "TheVotacionPropuestaEstadoDTO.NombreVotacionPropuestaEstado")%>
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
                            <asp:LinkButton ID="LnkBtnVotaciones" CausesValidation="false" runat="server" ToolTip="Ver Votaciones"
                                CommandName="Editar">Ver</asp:LinkButton>
                        </th>
                        <th class="w10">
                            <asp:LinkButton ID="LnkBtnEditar" CausesValidation="false" runat="server" ToolTip="Ver Votacion Propuesta"
                                CommandName="Votaciones">Votaciones</asp:LinkButton>
                            <asp:HiddenField ID="hdnVotacionPropuestaId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdVotacionPropuesta")%>' />
                            <asp:HiddenField ID="hdnPropuestaId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ThePropuestaDTO.IdPropuesta")%>' />
                        </th>
                        <th class="w10">
                            <asp:LinkButton ID="LnkBtnEliminar" runat="server" ToolTip="Eliminar" CausesValidation="false"
                                CommandName="Eliminar"><span class="icon_trash"></span></asp:LinkButton>
                        </th>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></div>
                </FooterTemplate>
            </asp:Repeater>
        </asp:Panel>
        <asp:Panel ID="pnlPapelera" runat="server" Visible="false">
            <asp:Repeater ID="rptVotacionPropuestaInactivo" OnItemCommand="rptVotacionPropuestaInactivo_OnItemCommand"
                runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w20">Condomino
                                    </th>
                                    <th class="w20">Nombre
                                    </th>
                                    <th class="w10">Fecha Inicio
                                    </th>
                                    <th class="w10">Fecha Termino
                                    </th>
                                    <th class="w10">Estado
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
                        <td class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "NotiTitulo")%>
                        </td>
                        <td class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "VotacionPropuestaNombre")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "VotacionPropuestaFechaInicio")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "VotacionPropuestaFechaTermino")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "VotacionPropuestaEstadoNombre")%>
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
                            <asp:LinkButton ID="LnkBtnCodVotacionPropuesta" CausesValidation="false" runat="server" ToolTip="Editar Tipo"
                                CommandName="Activar">Activar Registro</asp:LinkButton>
                            <asp:HiddenField ID="hdnVotacionPropuestaId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdVotacionPropuesta")%>' />
                            <asp:HiddenField ID="hdnPropuestaId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ThePropuestaDTO.IdPropuesta")%>' />

                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></div></div></div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnVotacionPropuestaId" />
            <asp:HiddenField runat="server" ID="HdnPropuestaId" />
        </asp:Panel>
        <asp:Panel ID="pnlVotaciones" runat="server" Visible="false">
            <asp:Repeater ID="rptVotaciones"
                runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w20">Familia
                                    </th>
                                    <th class="w20">Fecha Votación
                                    </th>
                                    <th class="w10">Elección
                                    </th>
                                </tr>
                            </table>
                            <div class="conte_tabla_datos_body_gr">
                                <table class="tabla_datos_body" border="0" cellspacing="0" cellpadding="0">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "TheFamiliaDTO.NombreCompleto")%>
                        </td>
                        <td class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "FechaVotacion")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "EleccionVotacion")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></div></div></div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField runat="server" ID="HiddenField1" />
            <asp:HiddenField runat="server" ID="HiddenField2" />
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
