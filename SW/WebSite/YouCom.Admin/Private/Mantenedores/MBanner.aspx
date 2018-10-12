<%@ Page Language="C#" MasterPageFile="~/App_Master/Admin/Home.master" AutoEventWireup="true"
    CodeFile="MBanner.aspx.cs" Inherits="Admin_Mantenedores_MBanner" Title="Untitled Page" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/App_Master/Admin/Controls/BannerCentral.ascx" TagName="BannerCentral" TagPrefix="uc1" %>
<%@ Register Src="~/App_Master/Admin/Controls/GenericError.ascx" TagName="GenericError" TagPrefix="uc1" %>

<%@ Register Src="../../App_Master/Admin/Controls/wucCondominio.ascx" TagName="wucCondominio" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlProducto" runat="server" Visible="true">
        <div id="conte">
            <asp:HiddenField ID="hdnIdCasa" runat="server" />
            <asp:Label runat="server" ID="lblPopUp"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                ShowSummary="false" />
            <div class="tit_box_white">
                Mantenedor de Banner
            </div>
            <div class="conte_box_whitetabs">
                <uc1:wucCondominio ID="wucCondominio1" runat="server" />
                <div class="columna-left-160">
                    <p>
                        Nombre
                    </p>
                </div>
                <div class="columna-right">
                    <asp:TextBox ID="txtBannerNombre" runat="server" CssClass="texto_option" MaxLength="200" />
                    <asp:RequiredFieldValidator ID="RFVTxtContTitulo" runat="server" ControlToValidate="TxtBannerNombre"
                        Display="None" ErrorMessage="Ingrese Nombre por favor" />
                    <cc1:FilteredTextBoxExtender ID="FTEBannerNombre" runat="server" TargetControlID="TxtBannerNombre"
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
                    <asp:TextBox runat="server" ID="txtBannerDescripcion" TextMode="MultiLine" Rows="20" Columns="200" CssClass="select_option"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                        TargetControlID="txtBannerDescripcion" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                    </cc1:FilteredTextBoxExtender>
                </div>
                <div class="borde_bottom cf">
                </div>
                <div class="columna-left-160">
                    <p>
                        Tipo Despliegue
                    </p>
                </div>
                <div class="columna-right">
                    <asp:DropDownList ID="DDLBannerLink" AutoPostBack="true" runat="server" CssClass="select_option" OnSelectedIndexChanged="DDLBannerLink_SelectedIndexChanged">
                        <asp:ListItem Value="" Text="Seleccione"></asp:ListItem>
                        <asp:ListItem Value="L" Text="Link"></asp:ListItem>
                        <asp:ListItem Value="F" Text="Fijo"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVRdbPubliLink" runat="server" ControlToValidate="DDLBannerLink"
                        Display="None" ErrorMessage="Indique si el Banner tiene Link, Archivo o es Fijo" />
                </div>
                <div class="borde_bottom cf">
                </div>
                <asp:Panel ID="pnlDespliegueLink" runat="server" Visible="false">
                    <div class="columna-left-160">
                        <p>
                            Target
                        </p>
                    </div>
                    <div class="columna-right">
                        <asp:RadioButtonList ID="RdbBannerTarget" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" CssClass="select_option" AutoPostBack="False">
                            <asp:ListItem Value="_blank">Nueva Pagina</asp:ListItem>
                            <asp:ListItem Value="_self">Misma pagina</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="RdbBannerTarget"
                            Display="None" ErrorMessage="Indique el tipo de despliegue del link" />
                    </div>
                    <div class="columna-left-160">
                        <p>
                            URL
                        </p>
                    </div>
                    <div class="columna-right">
                        <asp:TextBox ID="TxtBannerURL" runat="server" CssClass="texto_option" MaxLength="200" />
                    </div>
                    <div class="borde_bottom cf">
                    </div>
                </asp:Panel>
                <div class="columna-left-160">
                    <p>
                        Imagen (*)
                    </p>
                </div>
                <div class="columna-right">
                    <asp:FileUpload ID="FileImagenBanner" runat="server" TabIndex="2" CssClass="select_option" /><br />
                    <span class="txt-ch">(200px - 100px)&nbsp; Peso Máximo
                <%=GetMaxUploadMessage()%></span>
                    <asp:HyperLink ID="lnkImagen" runat="server" Visible="false" CssClass="fancybox"
                        ToolTip="Ver imagen">
                        <asp:Image ID="imgImagen" runat="server" AlternateText="Imagen" ToolTip="Ver imagen"
                            ImageUrl="~/Admin/images/iconos/ico_camara.gif" Width="20px" Height="20px" />
                    </asp:HyperLink>
                    <asp:CheckBox ID="chkImagen" runat="server" Visible="false" CssClass="radiobutton"
                        Text="Eliminar imagen" />
                    <asp:CustomValidator ID="CVImagen" ValidationGroup="formulario" runat="server" ErrorMessage="El archivo sólo puede ser de tipo imagen y flash"
                        ControlToValidate="FileImagenBanner" Display="None" ClientValidationFunction="isImageFlash" />
                    <asp:RegularExpressionValidator ID="REVUpload" runat="server" ErrorMessage="Solo los archivos jpg, gif, bmp ó png están permitidos"
                        ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([bB][mM][pP])|([pP][nN][gG])|([wW][mM][fF])|([sS][wW][fF]))$"
                        ControlToValidate="FileImagenBanner"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileImagenBanner"
                        Display="None" ErrorMessage="Seleccione imagen por favor" />
                </div>
                <div class="mt10">
                    <asp:LinkButton runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" CssClass="BigButton" />
                    <asp:LinkButton runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" CssClass="BigButton" />
                    <asp:ImageButton Text="Ver Papeleria" OnClick="lblPapeleria_OnClick" ImageUrl="~/images/iconos/bot_papelera.jpg"
                        AlternateText="Papelera" ToolTip="Papelera" CausesValidation="false" ID="lblPapeleria"
                        runat="server"></asp:ImageButton>
                </div>
            </div>
            <asp:Panel runat="server" ID="pnlAdministracionBanner">
                <asp:Repeater ID="rptBanner" OnItemCommand="rptBanner_OnItemCommand" runat="server">
                    <HeaderTemplate>
                        <div class="conte_box_white_gr">
                            <div class="conte_tabla_datos_body_detail ">
                                <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <th class="w20 titulos">Nombre
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
                                <%# DataBinder.Eval(Container.DataItem, "BannerNombre")%>
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
                                <asp:HiddenField ID="hdnBannerId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "BannerId")%>' />
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
                <asp:Repeater ID="rptBannerInactivo" OnItemCommand="rptBannerInactivo_OnItemCommand"
                    runat="server">
                    <HeaderTemplate>
                        <div class="conte_box_white">
                            <div class="conte_tabla_datos_body_detail ">
                                <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <th class="w20">Nombre
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
                                <asp:HiddenField ID="hdnBannerId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "BannerId")%>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></div></div></div>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HiddenField runat="server" ID="hdnBannerId" />
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
