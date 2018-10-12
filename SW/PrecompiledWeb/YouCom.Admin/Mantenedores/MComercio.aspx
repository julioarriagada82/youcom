<%@ page language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Mantenedores_MComercio, App_Web_y4k0mwx9" title="Untitled Page" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ImageButton Text="Ver Papeleria" OnClick="lblPapeleria_OnClick" ImageUrl="~/images/iconos/bot_papelera.jpg"
        AlternateText="Papelera" ToolTip="Papelera" CausesValidation="false" ID="lblPapeleria"
        runat="server"></asp:ImageButton>
    <asp:Label runat="server" ID="lblPopUp"></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
        ShowSummary="false" />
    <table>
        <tr>
            <td>
                Condominio
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlCondominio" Width="234px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCondominio"
                    Display="None" ErrorMessage="El Condominio es Obligatorio.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Categoria
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlCategoria" Width="234px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCategoria"
                    Display="None" ErrorMessage="La categoria es Obligatoria.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Nombre
            </td>
            <td>
                <asp:TextBox ID="txtComercioNombre" runat="server" Width="1000px" TextMode="SingleLine"
                    MaxLength="200" />
                <asp:RequiredFieldValidator ID="RFVTxtContTitulo" runat="server" ControlToValidate="txtComercioNombre"
                    Display="None" ErrorMessage="Ingrese Nombre por favor" />
                <cc1:FilteredTextBoxExtender ID="FTEBannerNombre" runat="server" TargetControlID="txtComercioNombre"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td>
                Dirección
            </td>
            <td>
                <asp:TextBox ID="txtComercioDireccion" runat="server" Width="1000px" TextMode="SingleLine"
                    MaxLength="200" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtComercioDireccion"
                    Display="None" ErrorMessage="Ingrese Dirección por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtComercioDireccion"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td>
                Telefono
            </td>
            <td>
                <asp:TextBox ID="txtComercioTelefono" runat="server" Width="1000px" TextMode="SingleLine"
                    MaxLength="200" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtComercioTelefono"
                    Display="None" ErrorMessage="Ingrese Telefono por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtComercioTelefono"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td>
                URL
            </td>
            <td>
                <asp:TextBox ID="txtComercioURL" runat="server" Width="1000px" TextMode="SingleLine"
                    MaxLength="200" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtComercioURL"
                    Display="None" ErrorMessage="Ingrese URL por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtComercioURL"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td>
                Logo (*)
            </td>
            <td>
                <asp:FileUpload ID="FileImagenComercio" runat="server" TabIndex="2" />
                (200px - 100px)&nbsp; Peso Máximo
                <%=GetMaxUploadMessage()%>
                <asp:HyperLink ID="lnkImagen" runat="server" Visible="false" CssClass="fancybox"
                    ToolTip="Ver imagen">
                    <asp:Image ID="imgImagen" runat="server" AlternateText="Imagen" ToolTip="Ver imagen"
                        ImageUrl="~/images/iconos/ico_camara.gif" Width="20px" Height="20px" /></asp:HyperLink>
                <asp:CheckBox ID="chkImagen" runat="server" Visible="false" CssClass="radiobutton"
                    Text="Eliminar imagen" />
                <asp:CustomValidator ID="CVImagen" ValidationGroup="formulario" runat="server" ErrorMessage="El archivo sólo puede ser de tipo imagen y flash"
                    ControlToValidate="FileImagenComercio" Display="None" ClientValidationFunction="isImageFlash" />
                <asp:RegularExpressionValidator ID="REVUpload" runat="server" ErrorMessage="Solo los archivos jpg, gif, bmp ó png están permitidos"
                    ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([bB][mM][pP])|([pP][nN][gG])|([wW][mM][fF])|([sS][wW][fF]))$"
                    ControlToValidate="FileImagenComercio"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:Button runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" />
            </td>
            <td>
                <asp:Button runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" />
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="pnlAdministracionComercio">
        <h2>
            Listado de Comercios</h2>
        <asp:Repeater ID="rptComercio" OnItemCommand="rptComercio_OnItemCommand" runat="server">
            <HeaderTemplate>
                <div class="conte_box_white">
                    <div class="conte_tabla_datos_body_detail ">
                        <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th class="w20">
                                    Nombre
                                </th>
                                <th class="w10">
                                    Dirección
                                </th>
                                <th class="w10">
                                    Usuario Ingreso
                                </th>
                                <th class="w10">
                                    Fecha Ingreso
                                </th>
                                <th class="w10">
                                    Usuario Modificacion
                                </th>
                                <th class="w10">
                                    Fecha Mofificacion
                                </th>
                                <th class="w10">
                                    Editar
                                </th>
                                <th class="w10">
                                    Eliminar
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
                            CommandName="Editar">Editar</asp:LinkButton>
                        <asp:HiddenField ID="hdnIdComercio" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdComercio")%>' />
                    </td>
                    <td class="w10">
                        <asp:LinkButton ID="LnkBtnEliminar" runat="server" ToolTip="Eliminar" CausesValidation="false"
                            CommandName="Eliminar">Eliminar</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></div></div></div>
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
                                <th class="w20">
                                    Nombre
                                </th>
                                <th class="w10">
                                    Dirección
                                </th>
                                <th class="w10">
                                    Usuario Ingreso
                                </th>
                                <th class="w10">
                                    Fecha Ingreso
                                </th>
                                <th class="w10">
                                    Usuario Modificacion
                                </th>
                                <th class="w10">
                                    Fecha Mofificacion
                                </th>
                                <th class="w10">
                                    Editar
                                </th>
                                <th class="w10">
                                    Eliminar
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
</asp:Content>


