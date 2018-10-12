<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Admin/Home.master" AutoEventWireup="true" CodeFile="MMensajeDirectiva.aspx.cs" Inherits="Admin_Administracion_MMensajeDirectorio" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/App_Master/Admin/Controls/BannerCentral.ascx" TagName="BannerCentral" TagPrefix="uc1" %>
<%@ Register Src="~/App_Master/Admin/Controls/GenericError.ascx" TagName="GenericError" TagPrefix="uc1" %>

<%@ Register Src="../../App_Master/Admin/Controls/wucCondominioCasaFamilia.ascx" TagName="wucCondominioCasaFamilia" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlProducto" runat="server" Visible="true">
        <div class="tit_box_white">
            Listado de Mensajes Directiva
        </div>
        <div class="conte_box_whitetabs">
            <uc1:wucCondominioCasaFamilia ID="wucCondominioCasaFamilia1" runat="server" />
            <div class="columna-left-160">
                <p>
                    Directiva
                </p>
            </div>
            <div class="columna-right">
                <asp:DropDownList runat="server" ID="ddlDirectiva" CssClass="select_option">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDirectiva"
                    Display="None" ErrorMessage="La Directiva es Obligatoria.">*</asp:RequiredFieldValidator>
            </div>
            <div class="columna-left-160">
                <p>
                    Fecha
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox runat="server" ID="txtFecha" TextMode="SingleLine" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha"
                    Display="None" ErrorMessage="Fecha es campo Obligatorio."></asp:RequiredFieldValidator>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Titulo
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox runat="server" ID="txtTituloMensaje" TextMode="SingleLine" MaxLength="300" CssClass="texto_option" Width="750px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtTituloMensaje" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtMensaje"
                    Display="None" ErrorMessage="Titulo es campo Obligatorio."></asp:RequiredFieldValidator>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Mensaje
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox runat="server" ID="txtMensaje" TextMode="MultiLine" MaxLength="30" Columns="60" Rows="20"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtMensaje" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMensaje"
                    Display="None" ErrorMessage="Mensaje es campo Obligatorio."></asp:RequiredFieldValidator>
            </div>
            <div class="mt10">
                <asp:LinkButton runat="server" ID="btnGrabar" CssClass="BigButton mt10" Text="Enviar" OnClick="btnGrabar_Click" />
                <asp:LinkButton ID="btnResponder" CssClass="BigButton mt10" CausesValidation="true" Text="Responder"
                    runat="server" OnClick="btnResponder_Click" />
                <asp:ImageButton Text="Ver Papeleria" OnClick="lblPapeleria_OnClick" ImageUrl="~/images/iconos/bot_papelera.jpg"
                    AlternateText="Papelera" ToolTip="Papelera" CausesValidation="false" ID="lblPapeleria"
                    runat="server"></asp:ImageButton>
            </div>
            <div class="cf">
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlAdministracionMensajeDirectiva">
            <asp:Repeater ID="rptMensajeDirectiva" OnItemCommand="rptMensajeDirectiva_OnItemCommand" runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white_gr">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w20 titulos">Fecha
                                    </th>
                                    <th class="w10 titulos">Titulo
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
                                    <th class="w10 titulos">Responder
                                    </th>
                                    <th class="w10 titulos">Eliminar
                                    </th>
                                </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "MensajeFecha")%>
                        </th>
                        <th class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "MensajeTitulo")%>
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
                            <asp:LinkButton ID="LnkBtnVer" CausesValidation="false" runat="server" ToolTip="Ver Mensaje"
                                CommandName="Ver">Ver</asp:LinkButton>
                            <asp:HiddenField ID="hdnIdMensajeDirectiva" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdMensajeDirectiva")%>' />
                        </th>
                        <th class="w10">
                            <asp:LinkButton ID="LnkBtnResponder" CausesValidation="false" runat="server" ToolTip="Responder Mensaje"
                                CommandName="Responder">Responder</asp:LinkButton>
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
            <asp:Repeater ID="rptMensajeDirectivaInactivo" OnItemCommand="rptMensajeDirectivaInactivo_OnItemCommand"
                runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w20">Nombre
                                    </th>
                                    <th class="w10">Dirección
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
                            <%# DataBinder.Eval(Container.DataItem, "NombreMensajeDirectiva")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "DireccionMensajeDirectiva")%>
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
                            <asp:HiddenField ID="hdnIdMensajeDirectiva" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdMensajeDirectiva")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></div></div></div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnIdMensajeDirectiva" />
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


