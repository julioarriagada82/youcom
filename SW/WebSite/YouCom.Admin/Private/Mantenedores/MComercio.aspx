<%@ Page Language="C#" MasterPageFile="~/App_Master/Admin/Home.master" AutoEventWireup="true" CodeFile="MComercio.aspx.cs" Inherits="Admin_Mantenedores_MComercio" Title="Untitled Page" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/App_Master/Admin/Controls/BannerCentral.ascx" TagName="BannerCentral" TagPrefix="uc1" %>
<%@ Register Src="~/App_Master/Admin/Controls/GenericError.ascx" TagName="GenericError" TagPrefix="uc1" %>

<%@ Register Src="../../App_Master/Admin/Controls/wucCondominio.ascx" TagName="wucCondominio" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlProducto" runat="server" Visible="true">
        <div id="conte">
            <asp:Label runat="server" ID="lblPopUp"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                ShowSummary="false" />
            <div class="tit_box_white">
                Mantenedor de Comercio
            </div>
            <div class="conte_box_whitetabs">
                <uc1:wucCondominio ID="wucCondominio1" runat="server" />
                <div class="columna-left-160">
                    <p>
                        Nombre
                    </p>
                </div>
                <div class="columna-right">
                    <asp:TextBox ID="txtComercioNombre" runat="server" TextMode="SingleLine"
                        MaxLength="200" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComercioNombre"
                        Display="None" ErrorMessage="Ingrese Nombre por favor" />
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtComercioNombre"
                        ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                    </cc1:FilteredTextBoxExtender>
                </div>
                <div class="columna-left-160">
                    <p>
                        Dirección
                    </p>
                </div>
                <div class="columna-right">
                    <asp:TextBox ID="txtComercioDireccion" runat="server" TextMode="SingleLine"
                        MaxLength="200" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtComercioDireccion"
                        Display="None" ErrorMessage="Ingrese Dirección por favor" />
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtComercioDireccion"
                        ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                    </cc1:FilteredTextBoxExtender>
                </div>
                <div class="borde_bottom cf">
                </div>
                <div class="columna-left-160">
                    <p>
                        Teléfono
                    </p>
                </div>
                <div class="columna-right">
                    <asp:DropDownList runat="server" ID="ddlAnexoTelefono">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlAnexoTelefono"
                        Display="None" ErrorMessage="El anexo de teléfono es Obligatorio.">*</asp:RequiredFieldValidator>
                    -
                <asp:TextBox runat="server" ID="txtComercioTelefono" TextMode="SingleLine" MaxLength="30"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers"
                        TargetControlID="txtComercioTelefono">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtComercioTelefono"
                        Display="None" ErrorMessage="Teléfono es campo Obligatorio."></asp:RequiredFieldValidator>
                </div>
                <div class="columna-left-160">
                    <p>
                        Celular
                    </p>
                </div>
                <div class="columna-right">
                    <asp:DropDownList runat="server" ID="ddlAnexoCelular">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlAnexoCelular"
                        Display="None" ErrorMessage="El anexo de celular es Obligatorio.">*</asp:RequiredFieldValidator>
                    -
                <asp:TextBox runat="server" ID="txtComercioCelular" TextMode="SingleLine" MaxLength="30"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                        TargetControlID="txtComercioCelular">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtComercioCelular"
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEmail"
                        Display="None" ErrorMessage="Email es campo Obligatorio."></asp:RequiredFieldValidator>
                </div>
                <div class="columna-left-160">
                    <p>
                        URL
                    </p>
                </div>
                <div class="columna-right">
                    <asp:TextBox ID="txtComercioURL" runat="server" TextMode="SingleLine"
                        MaxLength="200" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtComercioURL"
                        Display="None" ErrorMessage="Ingrese URL por favor" />
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtComercioURL"
                        ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                    </cc1:FilteredTextBoxExtender>
                </div>
                <div class="borde_bottom cf">
                </div>
                <div class="columna-left-160">
                    <p>
                        Categoria
                    </p>
                </div>
                <div class="columna-right">
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="select_option">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCategoria"
                        Display="None" ErrorMessage="La categoria es Obligatoria.">*</asp:RequiredFieldValidator>
                </div>
                <div class="columna-left-160">
                    <p>
                        Logo (*)
                    </p>
                </div>
                <div class="columna-right">
                    <asp:FileUpload ID="FileImagenComercio" runat="server" TabIndex="2" CssClass="select_option" /><br />
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
                        ControlToValidate="FileImagenComercio" Display="None" ClientValidationFunction="isImageFlash" />
                    <asp:RegularExpressionValidator ID="REVUpload" runat="server" ErrorMessage="Solo los archivos jpg, gif, bmp ó png están permitidos"
                        ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([bB][mM][pP])|([pP][nN][gG])|([wW][mM][fF])|([sS][wW][fF]))$"
                        ControlToValidate="FileImagenComercio"></asp:RegularExpressionValidator>
                </div>
                <div class="mt10">
                    <asp:LinkButton runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" CssClass="BigButton" />
                    <asp:LinkButton runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" CssClass="BigButton" />
                    <asp:ImageButton Text="Ver Papeleria" OnClick="lblPapeleria_OnClick" ImageUrl="~/images/iconos/bot_papelera.jpg"
                        AlternateText="Papelera" ToolTip="Papelera" CausesValidation="false" ID="lblPapeleria"
                        runat="server"></asp:ImageButton>
                </div>
            </div>
            <asp:Panel runat="server" ID="pnlAdministracionComercio">
                <asp:Repeater ID="rptComercio" OnItemCommand="rptComercio_OnItemCommand" runat="server">
                    <HeaderTemplate>
                        <div class="conte_box_white_gr">
                            <div class="conte_tabla_datos_body_detail ">
                                <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
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
                            <th class="w20 txt-left">
                                <%# DataBinder.Eval(Container.DataItem, "NombreComercio")%>
                            </th>
                            <th class="w10">
                                <%# DataBinder.Eval(Container.DataItem, "DireccionComercio")%>
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
                                <asp:HiddenField ID="hdnIdComercio" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdComercio")%>' />
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
                <asp:Repeater ID="rptComercioInactivo" OnItemCommand="rptComercioInactivo_OnItemCommand"
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
                                <%# DataBinder.Eval(Container.DataItem, "NombreComercio")%>
                            </td>
                            <td class="w10">
                                <%# DataBinder.Eval(Container.DataItem, "DireccionComercio")%>
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
                                <asp:HiddenField ID="hdnIdComercio" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdComercio")%>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></div></div></div>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HiddenField runat="server" ID="hdnIdComercio" />
            </asp:Panel>
        </div>
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
