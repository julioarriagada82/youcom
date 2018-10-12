<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Admin/Home.master" AutoEventWireup="true" CodeFile="MEmpresaContratista.aspx.cs" Inherits="Admin_Mantenedores_MEmpresaContratista" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/App_Master/Admin/Controls/BannerCentral.ascx" TagName="BannerCentral" TagPrefix="uc1" %>
<%@ Register Src="~/App_Master/Admin/Controls/GenericError.ascx" TagName="GenericError" TagPrefix="uc1" %>

<%@ Register Src="../../App_Master/Admin/Controls/wucCondominio.ascx" TagName="wucCondominio" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlProducto" runat="server" Visible="true">
        <asp:Label runat="server" ID="lblPopUp"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
            ShowSummary="false" />
        <div class="tit_box_white">
            Mantenedor de Empresa Contratista
        </div>
        <div class="conte_box_whitetabs">
            <uc1:wucCondominio ID="wucCondominio1" runat="server" />
            <div class="columna-left-160">
                <p>
                    Razón Social
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="txtRazonSocialEmpresaContratista" runat="server" TextMode="SingleLine"
                    MaxLength="200" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtRazonSocialEmpresaContratista"
                    Display="None" ErrorMessage="Ingrese Nombre por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtRazonSocialEmpresaContratista"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </div>
            <div class="columna-left-160">
                <p>
                    Rut
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="txtRutCondominioContratista" runat="server" TextMode="SingleLine"
                    MaxLength="200" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtRutCondominioContratista"
                    Display="None" ErrorMessage="Ingrese Dirección por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtRutCondominioContratista"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Giro
                </p>
            </div>
            <div class="columna-right">
                <asp:DropDownList runat="server" ID="ddlGiro" CssClass="select_option">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlGiro"
                    Display="None" ErrorMessage="El giro es Obligatorio.">*</asp:RequiredFieldValidator>
            </div>
            <div class="columna-left-160">
                <p>
                    Dirección
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="txtEmpresaContratistaDireccion" runat="server" TextMode="SingleLine"
                    MaxLength="200" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmpresaContratistaDireccion"
                    Display="None" ErrorMessage="Ingrese Dirección por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtEmpresaContratistaDireccion"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Pais
                </p>
            </div>
            <div class="columna-right">
                <asp:DropDownList runat="server" ID="ddlPais" CssClass="select_option" AutoPostBack="True" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPais"
                    Display="None" ErrorMessage="El Condominio es Obligatorio.">*</asp:RequiredFieldValidator>
            </div>
            <div class="columna-left-160">
                <p>
                    Región
                </p>
            </div>
            <div class="columna-right">
                <asp:DropDownList runat="server" ID="ddlRegion" CssClass="select_option" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlRegion"
                    Display="None" ErrorMessage="La región es Obligatoria.">*</asp:RequiredFieldValidator>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Ciudad
                </p>
            </div>
            <div class="columna-right">
                <asp:DropDownList runat="server" ID="ddlCiudad" CssClass="select_option" AutoPostBack="True" OnSelectedIndexChanged="ddlCiudad_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCiudad"
                    Display="None" ErrorMessage="La ciudad es Obligatorio.">*</asp:RequiredFieldValidator>
            </div>
            <div class="columna-left-160">
                <p>
                    Comuna
                </p>
            </div>
            <div class="columna-right">
                <asp:DropDownList runat="server" ID="ddlComuna" CssClass="select_option">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlComuna"
                    Display="None" ErrorMessage="La comuna es Obligatoria.">*</asp:RequiredFieldValidator>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Teléfono
                </p>
            </div>
            <div class="columna-right">
                <asp:DropDownList runat="server" ID="ddlAnexoTelefono" CssClass="select_option" Width="50px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlAnexoTelefono"
                    Display="None" ErrorMessage="El anexo de teléfono es Obligatorio.">*</asp:RequiredFieldValidator>
                -
                <asp:TextBox runat="server" ID="txtEmpresaContratistaTelefono" TextMode="SingleLine" MaxLength="30" CssClass="texto_option"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers"
                    TargetControlID="txtEmpresaContratistaTelefono">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEmpresaContratistaTelefono"
                    Display="None" ErrorMessage="Teléfono es campo Obligatorio."></asp:RequiredFieldValidator>
            </div>
            <div class="columna-left-160">
                <p>
                    Celular
                </p>
            </div>
            <div class="columna-right">
                <asp:DropDownList runat="server" ID="ddlAnexoCelular" CssClass="select_option" Width="50px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlAnexoCelular"
                    Display="None" ErrorMessage="El anexo de celular es Obligatorio.">*</asp:RequiredFieldValidator>
                -
                <asp:TextBox runat="server" ID="txtEmpresaContratistaCelular" TextMode="SingleLine" MaxLength="30" CssClass="texto_option"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers"
                    TargetControlID="txtEmpresaContratistaCelular">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmpresaContratistaCelular"
                    Display="None" ErrorMessage="Celular es campo Obligatorio."></asp:RequiredFieldValidator>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    E-Mail
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox runat="server" ID="txtEmail" Width="210px" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtEmail" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!~@">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail"
                    Display="None" ErrorMessage="Email es campo Obligatorio."></asp:RequiredFieldValidator>
            </div>
            <div class="columna-left-160">
                <p>
                    URL
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="txtEmpresaContratistaURL" runat="server" TextMode="SingleLine"
                    MaxLength="200" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmpresaContratistaURL"
                    Display="None" ErrorMessage="Ingrese URL por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtEmpresaContratistaURL"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Logo (*)
                </p>
            </div>
            <div class="columna-right">
                <asp:FileUpload ID="FileImagenEmpresaContratista" runat="server" CssClass="select_option" TabIndex="2" /><br />
                <span class="txt-ch">(200px - 100px)&nbsp; Peso Máximo
                <%=GetMaxUploadMessage()%></span>
                <asp:HyperLink ID="lnkImagen" runat="server" Visible="false" CssClass="fancybox"
                    ToolTip="Ver imagen">
                    <asp:Image ID="imgImagen" runat="server" AlternateText="Imagen" ToolTip="Ver imagen"
                        ImageUrl="~/images/iconos/ico_camara.gif" Width="20px" Height="20px" />
                </asp:HyperLink>
                <asp:CheckBox ID="chkImagen" runat="server" Visible="false" CssClass="radiobutton"
                    Text="Eliminar imagen" />
                <asp:CustomValidator ID="CVImagen" ValidationGroup="formulario" runat="server" ErrorMessage="El archivo sólo puede ser de tipo imagen y flash"
                    ControlToValidate="FileImagenEmpresaContratista" Display="None" ClientValidationFunction="isImageFlash" />
                <asp:RegularExpressionValidator ID="REVUpload" runat="server" ErrorMessage="Solo los archivos jpg, gif, bmp ó png están permitidos"
                    ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([bB][mM][pP])|([pP][nN][gG])|([wW][mM][fF])|([sS][wW][fF]))$"
                    ControlToValidate="FileImagenEmpresaContratista"></asp:RegularExpressionValidator>
            </div>
            <div class="mt10">
                <asp:LinkButton runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" CssClass="BigButton" />
                <asp:LinkButton runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" CssClass="BigButton" />
                <asp:ImageButton Text="Ver Papeleria" OnClick="lblPapeleria_OnClick" ImageUrl="~/images/iconos/bot_papelera.jpg"
                    AlternateText="Papelera" ToolTip="Papelera" CausesValidation="false" ID="lblPapeleria"
                    runat="server"></asp:ImageButton>
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlAdministracionEmpresaContratista">
            <asp:Repeater ID="rptEmpresaContratista" OnItemCommand="rptEmpresaContratista_OnItemCommand" runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white_gr">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w10 titulos">Rut
                                    </th>
                                    <th class="w20 titulos">Nombre
                                    </th>
                                    <th class="w10 titulos">Dirección
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
                            <%# DataBinder.Eval(Container.DataItem, "RutCondominioContratista")%>
                        </th>
                        <th class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "RazonSocialEmpresaContratista")%>
                        </th>
                        <th class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "DireccionEmpresaContratista")%>
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
                            <asp:LinkButton ID="LnkBtnEditar" CausesValidation="false" runat="server" ToolTip="Editar Casa"
                                CommandName="Editar"><span class="icon_edit"></span></asp:LinkButton>
                            <asp:HiddenField ID="hdnIdEmpresaContratista" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdEmpresaContratista")%>' />
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
            <asp:Repeater ID="rptEmpresaContratistaInactivo" OnItemCommand="rptEmpresaContratistaInactivo_OnItemCommand"
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
                            <%# DataBinder.Eval(Container.DataItem, "NombreEmpresaContratista")%>
                        </td>
                        <td class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "DireccionEmpresaContratista")%>
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
                            <asp:HiddenField ID="hdnIdEmpresaContratista" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdEmpresaContratista")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></div></div></div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnIdEmpresaContratista" />
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



