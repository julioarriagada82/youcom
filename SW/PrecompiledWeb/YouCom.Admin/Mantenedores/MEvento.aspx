<%@ page language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Mantenedores_MEvento, App_Web_y4k0mwx9" title="Untitled Page" enableEventValidation="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
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
                Titulo
            </td>
            <td>
                <asp:TextBox ID="txtEventoTitulo" runat="server" Width="1000px" TextMode="SingleLine"
                    MaxLength="200" />
                <asp:RequiredFieldValidator ID="RFVTxtContTitulo" runat="server" ControlToValidate="txtEventoTitulo"
                    Display="None" ErrorMessage="Ingrese Titulo por favor" />
                <cc1:FilteredTextBoxExtender ID="FTEBannerNombre" runat="server" TargetControlID="txtEventoTitulo"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td>
                Resumen
            </td>
            <td>
                <asp:TextBox ID="txtEventoResumen" runat="server" Width="1000px" TextMode="SingleLine"
                    MaxLength="200" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEventoResumen"
                    Display="None" ErrorMessage="Ingrese Resumen por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtEventoResumen"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td>
                Detalle
            </td>
            <td>
                <FCKeditorV2:FCKeditor ID="FCKeditorDetalle" runat="server" Height="500" />
            </td>
        </tr>
        <tr>
            <td>
                Fecha Publicaci&oacute;n
            </td>
            <td>
                <asp:TextBox ID="FechaPublicacion" runat="server" CssClass="campo_txt" Columns="10"
                    Width="60px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="FechaPublicacion"
                    Format="dd/MM/yyyy" TargetControlID="FechaPublicacion" />
                <cc1:MaskedEditExtender ID="FechaPublicacion_MaskedEditExtender" runat="server" Mask="99/99/9999"
                    MaskType="Date" TargetControlID="FechaPublicacion" CultureName="es-ES">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="FechaPublicacion_MaskedEditExtender"
                    ControlToValidate="FechaPublicacion" Display="None" EmptyValueMessage="Fecha Publicación"
                    ErrorMessage="Fecha Publicación no válida." InvalidValueMessage="Fecha Publicación no válida."
                    IsValidEmpty="False" SetFocusOnError="True">*
                </cc1:MaskedEditValidator>
            </td>
        </tr>
        <tr>
            <td>
                Fecha Expiración
            </td>
            <td>
                <asp:TextBox ID="FechaExpiracion" runat="server" CssClass="campo_txt" Columns="10"
                    Width="60px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="FechaExpiracion"
                    Format="dd/MM/yyyy" TargetControlID="FechaExpiracion" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                    MaskType="Date" TargetControlID="FechaExpiracion" CultureName="es-ES">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="FechaPublicacion_MaskedEditExtender"
                    ControlToValidate="FechaExpiracion" Display="None" EmptyValueMessage="Fecha Expiracion"
                    ErrorMessage="Fecha Expiración no válida." InvalidValueMessage="Fecha Expiración no válida."
                    IsValidEmpty="False" SetFocusOnError="True">*
                </cc1:MaskedEditValidator>
            </td>
        </tr>
        <tr>
            <td>
                Autor
            </td>
            <td>
                <asp:TextBox ID="TxtNotiAutor" runat="server" Width="200px" TextMode="SingleLine"
                    MaxLength="50" />
                <asp:RequiredFieldValidator ID="RFVTxtNotiAutor" runat="server" ControlToValidate="TxtNotiAutor"
                    Display="None" ErrorMessage="Ingrese Autor por favor" />
            </td>
        </tr>
        <tr>
            <td>
                Imagen (*)
            </td>
            <td>
                <asp:FileUpload ID="FileImagenEvento" runat="server" TabIndex="2" />
                (200px - 100px)&nbsp; Peso Máximo
                <%=GetMaxUploadMessage()%>
                <asp:HyperLink ID="lnkImagen" runat="server" Visible="false" CssClass="fancybox"
                    ToolTip="Ver imagen">
                    <asp:Image ID="imgImagen" runat="server" AlternateText="Imagen" ToolTip="Ver imagen"
                        ImageUrl="~/images/iconos/ico_camara.gif" Width="20px" Height="20px" /></asp:HyperLink>
                <asp:CheckBox ID="chkImagen" runat="server" Visible="false" CssClass="radiobutton"
                    Text="Eliminar imagen" />
                <asp:CustomValidator ID="CVImagen" ValidationGroup="formulario" runat="server" ErrorMessage="El archivo sólo puede ser de tipo imagen y flash"
                    ControlToValidate="FileImagenEvento" Display="None" ClientValidationFunction="isImageFlash" />
                <asp:RegularExpressionValidator ID="REVUpload" runat="server" ErrorMessage="Solo los archivos jpg, gif, bmp ó png están permitidos"
                    ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([bB][mM][pP])|([pP][nN][gG])|([wW][mM][fF])|([sS][wW][fF]))$"
                    ControlToValidate="FileImagenEvento"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:Button runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" />
            </td>
            <td>
                <asp:Button runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" />
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="pnlAdministracionEvento">
        <h2>
            Listado de Eventos</h2>
        <asp:Repeater ID="rptEvento" OnItemCommand="rptEvento_OnItemCommand" runat="server">
            <HeaderTemplate>
                <div class="conte_box_white">
                    <div class="conte_tabla_datos_body_detail ">
                        <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th class="w20">
                                    Titulo
                                </th>
                                <th class="w10">
                                    Fecha Publicación
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
                        <%# DataBinder.Eval(Container.DataItem, "EventoTitulo")%>
                    </td>
                    <td class="w10">
                        <%# DataBinder.Eval(Container.DataItem, "EventoPublicacion")%>
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
                        <asp:HiddenField ID="hdnEventoId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "EventoId")%>' />
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
        <asp:Repeater ID="rptEventoInactivo" OnItemCommand="rptEventoInactivo_OnItemCommand"
            runat="server">
            <HeaderTemplate>
                <div class="conte_box_white">
                    <div class="conte_tabla_datos_body_detail ">
                        <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th class="w20">
                                    Titulo
                                </th>
                                <th class="w10">
                                    Fecha Publicación
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
                        <%# DataBinder.Eval(Container.DataItem, "EventoTitulo")%>
                    </td>
                    <td class="w10">
                        <%# DataBinder.Eval(Container.DataItem, "EventoPublicacion")%>
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
                        <asp:HiddenField ID="hdnEventoId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "EventoId")%>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></div></div></div>
            </FooterTemplate>
        </asp:Repeater>
        <asp:HiddenField runat="server" ID="hdnEventoId" />
    </asp:Panel>
</asp:Content>
