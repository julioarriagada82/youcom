<%@ page title="" language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Mantenedores_MGastosComunes, App_Web_y4k0mwx9" enableEventValidation="false" %>

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
                <asp:DropDownList runat="server" ID="ddlCondominio" Width="234px" OnSelectedIndexChanged="ddlCondominio_OnSelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCondominio"
                    Display="None" ErrorMessage="El Condominio es Obligatorio.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Casa
            </td>
            <td>
                <asp:DropDownList ID="ddlCasa" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCasa"
                    Display="None" ErrorMessage="Casa es campo Obligatorio."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Descripción
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDescripcion" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtDescripcion" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDescripcion"
                    Display="None" ErrorMessage="Descripción es campo Obligatorio."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Monto
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtMonto" Width="210px" Height="18px" MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                    TargetControlID="txtMonto">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMonto"
                    Display="None" ErrorMessage="Monto es campo Obligatorio."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Fecha
            </td>
            <td>
                <asp:TextBox ID="FechaGasto" runat="server" CssClass="campo_txt" Columns="10" Width="60px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="FechaGasto"
                    Format="dd/MM/yyyy" TargetControlID="FechaGasto" />
                <cc1:MaskedEditExtender ID="FechaGasto_MaskedEditExtender" runat="server" Mask="99/99/9999"
                    MaskType="Date" TargetControlID="FechaGasto" CultureName="es-ES">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="FechaGasto_MaskedEditExtender"
                    ControlToValidate="FechaGasto" Display="None" EmptyValueMessage="Fecha Gasto Común"
                    ErrorMessage="Fecha Gasto Común no válida." InvalidValueMessage="Fecha Gasto Común no válida."
                    IsValidEmpty="False" SetFocusOnError="True">*
                </cc1:MaskedEditValidator>
            </td>
        </tr>
        <tr>
            <td>
                Archivo (*)
            </td>
            <td>
                <asp:FileUpload ID="FileArchivo" runat="server" TabIndex="2" /><br />
                (200px - 100px)&nbsp; Peso Máximo
                <%=GetMaxUploadMessage()%>
                <asp:HyperLink ID="lnkImagen" runat="server" Visible="false" CssClass="fancybox"
                    ToolTip="Ver imagen">
                    <asp:Image ID="imgImagen" runat="server" AlternateText="Imagen" ToolTip="Ver imagen"
                        ImageUrl="~/images/iconos/ico_camara.gif" Width="20px" Height="20px" /></asp:HyperLink>
                <asp:CheckBox ID="chkImagen" runat="server" Visible="false" CssClass="radiobutton"
                    Text="Eliminar imagen" />
                <asp:CustomValidator ID="CVImagen" ValidationGroup="formulario" runat="server" ErrorMessage="El archivo sólo puede ser de tipo imagen y flash"
                    ControlToValidate="FileArchivo" Display="None" ClientValidationFunction="isImageFlash" />
                <asp:RegularExpressionValidator ID="REVUpload" runat="server" ErrorMessage="Solo los archivos jpg, gif, bmp ó png están permitidos"
                    ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([bB][mM][pP])|([pP][nN][gG])|([wW][mM][fF])|([sS][wW][fF]))$"
                    ControlToValidate="FileArchivo"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Estado
            </td>
            <td>
                <asp:DropDownList ID="ddlEstado" runat="server" OnSelectedIndexChanged="ddlEstado_OnSelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem Value="" Text="Seleccione Estado"></asp:ListItem>
                    <asp:ListItem Value="PE" Text="Pendiente"></asp:ListItem>
                    <asp:ListItem Value="PA" Text="Pagado"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCasa"
                    Display="None" ErrorMessage="Casa es campo Obligatorio."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <asp:Panel ID="pnlEstado" runat="server" Visible="false">
            <tr>
                <td>
                    Fecha de Pago
                </td>
                <td>
                    <asp:TextBox ID="FechaPago" runat="server" CssClass="campo_txt" Columns="10" Width="60px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="FechaPago"
                        Format="dd/MM/yyyy" TargetControlID="FechaPago" />
                    <cc1:MaskedEditExtender ID="FechaPago_MaskedEditExtender" runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="FechaGasto" CultureName="es-ES">
                    </cc1:MaskedEditExtender>
                    <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="FechaPago_MaskedEditExtender"
                        ControlToValidate="FechaPago" Display="None" EmptyValueMessage="Fecha Pago" ErrorMessage="Fecha Pago no válida."
                        InvalidValueMessage="Fecha Pago no válida." IsValidEmpty="False" SetFocusOnError="True">*
                    </cc1:MaskedEditValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Comentario
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtComentario" Width="210px" Height="18px" MaxLength="500"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:Button runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" />
            </td>
            <td>
                <asp:Button runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" />
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="pnlAdministracionGastoComun">
        <h2>
            Listado de Gastos Comunes</h2>
        <asp:Repeater ID="rptGastoComun" OnItemCommand="rptGastoComun_OnItemCommand" runat="server">
            <HeaderTemplate>
                <div class="conte_box_white">
                    <div class="conte_tabla_datos_body_detail ">
                        <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th class="w10">
                                    Casa
                                </th>
                                <th class="w20">
                                    Monto
                                </th>
                                <th class="w20">
                                    Estado
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
                    <td class="w10 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "IdCasa")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "MontoGasto")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "EstadoGasto")%>
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
                        <asp:HiddenField ID="hdnIdGastoComun" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdGastoComun")%>' />
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
        <asp:Repeater ID="rptGastoComunInactivo" OnItemCommand="rptGastoComunInactivo_OnItemCommand"
            runat="server">
            <HeaderTemplate>
                <div class="conte_box_white">
                    <div class="conte_tabla_datos_body_detail ">
                        <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th class="w10">
                                    Casa
                                </th>
                                <th class="w20">
                                    Monto
                                </th>
                                <th class="w20">
                                    Estado
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
                                    Activar
                                </th>
                            </tr>
                        </table>
                        <div class="conte_tabla_datos_body_gr">
                            <table class="tabla_datos_body" border="0" cellspacing="0" cellpadding="0">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="w10 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "IdCasa")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "MontoGasto")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "EstadoGasto")%>
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
                        <asp:HiddenField ID="hdnIdGastoComun" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdGastoComun")%>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></div></div></div>
            </FooterTemplate>
        </asp:Repeater>
        <asp:HiddenField runat="server" ID="hdnIdGastoComun" />
    </asp:Panel>
</asp:Content>
