<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Admin/Home.master" AutoEventWireup="true" CodeFile="MProyecto.aspx.cs" Inherits="Admin_Administracion_MProyecto" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/App_Master/Admin/Controls/BannerCentral.ascx" TagName="BannerCentral" TagPrefix="uc1" %>
<%@ Register Src="~/App_Master/Admin/Controls/GenericError.ascx" TagName="GenericError" TagPrefix="uc1" %>

<%@ Register Src="../../App_Master/Admin/Controls/wucCondominio.ascx" TagName="wucCondominio" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlProducto" runat="server" Visible="true">
        <div class="tit_box_white">
            Listado de Proyectos
        </div>
        <div class="conte_box_whitetabs">
            <uc1:wucCondominio ID="wucCondominio1" runat="server" />
            <div class="columna-left-160">
                <p>
                    Nombre
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="txtProyectoNombre" runat="server" TextMode="SingleLine" Width="750px"
                    MaxLength="300" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProyectoNombre"
                    Display="None" ErrorMessage="Ingrese Nombre por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtProyectoNombre"
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
                <asp:TextBox ID="txtProyectoDescripcion" runat="server" TextMode="MultiLine"
                    MaxLength="200" Columns="100" Rows="20" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtProyectoDescripcion"
                    Display="None" ErrorMessage="Ingrese Descripción por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtProyectoDescripcion"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Dirección
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="texto_option" TextMode="SingleLine"
                    MaxLength="50" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDireccion"
                    Display="None" ErrorMessage="Ingrese Dirección por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtDireccion"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </div>
            <div class="columna-left-160">
                <p>
                    Empresa Contratista
                </p>
            </div>
            <div class="columna-right">
                <asp:DropDownList runat="server" ID="ddlEmpresaContratista" CssClass="select_option">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlEmpresaContratista"
                    Display="None" ErrorMessage="La Empresa contratista es Obligatoria.">*</asp:RequiredFieldValidator>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Fecha Inicio
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="FechaInicio" runat="server" CssClass="campo_txt" Columns="10"
                    Width="60px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="FechaInicio"
                    Format="dd/MM/yyyy" TargetControlID="FechaInicio" />
                <cc1:MaskedEditExtender ID="FechaInicio_MaskedEditExtender" runat="server" Mask="99/99/9999"
                    MaskType="Date" TargetControlID="FechaInicio" CultureName="es-ES">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="FechaInicio_MaskedEditExtender"
                    ControlToValidate="FechaInicio" Display="None" EmptyValueMessage="Fecha Inicio"
                    ErrorMessage="Fecha Inicio no válida." InvalidValueMessage="Fecha Inicio no válida."
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
                    Fecha Entrega
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="FechaEntrega" runat="server" CssClass="campo_txt" Columns="10"
                    Width="60px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="FechaEntrega"
                    Format="dd/MM/yyyy" TargetControlID="FechaEntrega" />
                <cc1:MaskedEditExtender ID="FechaEntrega_MaskedEditExtender" runat="server" Mask="99/99/9999"
                    MaskType="Date" TargetControlID="FechaEntrega" CultureName="es-ES">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="FechaEntrega_MaskedEditExtender"
                    ControlToValidate="FechaEntrega" Display="None" EmptyValueMessage="Fecha Entrega"
                    ErrorMessage="Fecha Entrega no válida." InvalidValueMessage="Fecha Entrega no válida."
                    IsValidEmpty="False" SetFocusOnError="True">*
                </cc1:MaskedEditValidator>
            </div>
            <div class="columna-left-160">
                <p>
                    Presupuesto
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="txtPresupuestoProyecto" runat="server" TextMode="SingleLine"
                    MaxLength="300" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPresupuestoProyecto"
                    Display="None" ErrorMessage="Ingrese Presupuesto por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPresupuestoProyecto"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
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
        <asp:Panel runat="server" ID="pnlAdministracionProyecto">
            <asp:Repeater ID="rptProyecto" OnItemCommand="rptProyecto_OnItemCommand" runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white_gr">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w20 titulos">Nombre
                                    </th>
                                    <th class="w20 titulos">Propuesta
                                    </th>
                                    <th class="w10 titulos">Estado Proyecto
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
                        <th class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "NombreProyecto")%>
                        </th>
                        <th class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "ThePropuestaDTO.IdPropuesta")%> -
                        <%# DataBinder.Eval(Container.DataItem, "ThePropuestaDTO.NombrePropuesta")%>
                        </th>
                        <th class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "TheProyectoEstadoDTO.NombreProyectoEstado")%>
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
                            <asp:LinkButton ID="LnkBtnEditar" CausesValidation="false" runat="server" ToolTip="Editar Proyecto"
                                CommandName="Editar"><span class="icon_edit"></span></asp:LinkButton>
                            <asp:HiddenField ID="hdnProyectoId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdProyecto")%>' />
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
            <asp:Repeater ID="rptProyectoInactivo" OnItemCommand="rptProyectoInactivo_OnItemCommand"
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
                            <%# DataBinder.Eval(Container.DataItem, "ProyectoNombre")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "ProyectoFechaInicio")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "ProyectoFechaTermino")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "ProyectoEstadoNombre")%>
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
                            <asp:LinkButton ID="LnkBtnCodProyecto" CausesValidation="false" runat="server" ToolTip="Editar Tipo"
                                CommandName="Activar">Activar Registro</asp:LinkButton>
                            <asp:HiddenField ID="hdnProyectoId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ProyectoId")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></div></div></div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnProyectoId" />
            <asp:HiddenField runat="server" ID="hdnPropuestaId" />
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
