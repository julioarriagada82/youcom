<%@ Page Language="C#" MasterPageFile="~/App_Master/Admin/Home.master" AutoEventWireup="true"
    CodeFile="MNoticia.aspx.cs" Inherits="Admin_Mantenedores_MNoticia" Title="Untitled Page" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/App_Master/Admin/Controls/BannerCentral.ascx" TagName="BannerCentral" TagPrefix="uc1" %>
<%@ Register Src="~/App_Master/Admin/Controls/GenericError.ascx" TagName="GenericError" TagPrefix="uc1" %>

<%@ Register Src="../../App_Master/Admin/Controls/wucCondominio.ascx" TagName="wucCondominio" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlProducto" runat="server" Visible="true">

        <asp:Label runat="server" ID="lblPopUp"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
            ShowSummary="false" />
        <div class="tit_box_white">
            Mantenedor de Noticia
        </div>
        <div class="conte_box_whitetabs">
            <uc1:wucCondominio ID="wucCondominio1" runat="server" />
            <div class="columna-left-160">
                <p>
                    Categoria
                </p>
            </div>
            <div class="columna-right">
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="select_option">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCategoria"
                    Display="None" ErrorMessage="La categoria es Obligatoria.">*</asp:RequiredFieldValidator>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Titulo
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="txtNoticiaTitulo" runat="server" Width="1000px" TextMode="SingleLine"
                    MaxLength="200" />
                <asp:RequiredFieldValidator ID="RFVTxtContTitulo" runat="server" ControlToValidate="txtNoticiaTitulo"
                    Display="None" ErrorMessage="Ingrese Titulo por favor" />
                <cc1:FilteredTextBoxExtender ID="FTEBannerNombre" runat="server" TargetControlID="txtNoticiaTitulo"
                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                </cc1:FilteredTextBoxExtender>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Resumen
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="txtNoticiaResumen" runat="server" Width="1000px" TextMode="SingleLine"
                    MaxLength="200" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoticiaResumen"
                    Display="None" ErrorMessage="Ingrese Resumen por favor" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtNoticiaResumen"
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
                <FCKeditorV2:FCKeditor ID="FCKeditorDetalle" runat="server" Height="500" Width="1000px" />
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Fecha Publicaci&oacute;n
                </p>
            </div>
            <div class="columna-right">
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
            </div>
            <div class="columna-left-160">
                <p>
                    Expira
                </p>
            </div>
            <div class="columna-right">
                <asp:RadioButtonList ID="RdbNotiExpira" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow" CssClass="select_option" OnSelectedIndexChanged="RdbNotiExpira_SelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem Value="S">Si</asp:ListItem>
                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RdbNotiExpira"
                    Display="None" ErrorMessage="Seleccione si la Noticia expira por favor" />
            </div>
            <div class="borde_bottom cf">
            </div>
            <asp:Panel ID="pnlExpira" runat="server" Visible="false">
                <div class="columna-left-160">
                    <p>
                        Fecha Expiración
                    </p>
                </div>
                <div class="columna-right">
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
                </div>
                <div class="borde_bottom cf">
                </div>
            </asp:Panel>
            <div class="columna-left-160">
                <p>
                    Autor
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox ID="TxtNotiAutor" runat="server" Width="200px" TextMode="SingleLine"
                    MaxLength="50" />
                <asp:RequiredFieldValidator ID="RFVTxtNotiAutor" runat="server" ControlToValidate="TxtNotiAutor"
                    Display="None" ErrorMessage="Ingrese Autor por favor" />
            </div>
            <div class="columna-left-160">
                <p>
                    Imagen (*)
                </p>
            </div>
            <div class="columna-right">
                <asp:FileUpload ID="FileImagenNoticia" runat="server" TabIndex="2" CssClass="select_option" /><br />
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
                    ControlToValidate="FileImagenNoticia" Display="None" ClientValidationFunction="isImageFlash" />
                <asp:RequiredFieldValidator ID="RFVFileArchivoBanner" runat="server" ControlToValidate="FileImagenNoticia"
                    Display="None" ErrorMessage="Seleccione Imagen por favor" />
                <asp:RegularExpressionValidator ID="REVUpload" runat="server" ErrorMessage="Solo los archivos jpg, gif, bmp ó png están permitidos"
                    ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([bB][mM][pP])|([pP][nN][gG])|([wW][mM][fF])|([sS][wW][fF]))$"
                    ControlToValidate="FileImagenNoticia"></asp:RegularExpressionValidator>
            </div>
            <div class="mt10">
                <asp:LinkButton runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" CssClass="BigButton" />
                <asp:LinkButton runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" CssClass="BigButton" />
                <asp:ImageButton Text="Ver Papeleria" OnClick="lblPapeleria_OnClick" ImageUrl="~/images/iconos/bot_papelera.jpg"
                    AlternateText="Papelera" ToolTip="Papelera" CausesValidation="false" ID="lblPapeleria"
                    runat="server"></asp:ImageButton>
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlAdministracionNoticia">
            <asp:Repeater ID="rptNoticia" OnItemCommand="rptNoticia_OnItemCommand" runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white_gr">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w20 titulos">Titulo
                                    </th>
                                    <th class="w10 titulos">Fecha Publicación
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
                            <%# DataBinder.Eval(Container.DataItem, "NotiTitulo")%>
                        </th>
                        <th class="w10">
                            <%# DataBinder.Eval(Container.DataItem, "NotiPublicacion")%>
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
                            <asp:HiddenField ID="hdnNoticiaId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "NoticiaId")%>' />
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
            <asp:Repeater ID="rptNoticiaInactivo" OnItemCommand="rptNoticiaInactivo_OnItemCommand"
                runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w20">Titulo
                                    </th>
                                    <th class="w10">Fecha Publicación
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
                            <%# DataBinder.Eval(Container.DataItem, "BannerNombre")%>
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
                            <asp:HiddenField ID="hdnNoticiaId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "NoticiaId")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></div></div></div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnNoticiaId" />
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
