<%@ page language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Mantenedores_MComunidad, App_Web_y4k0mwx9" title="Untitled Page" enableEventValidation="false" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Label runat="server" ID="lblPopUp"></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
        ShowSummary="false" />
    <table>
        <tr>
            <td>
                Dirección Comunidad
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDireccion" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtDireccion" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDireccion"
                    Display="None" ErrorMessage="Dirección es campo Obligatorio."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Teléfono
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtTelefono" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtTelefono" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTelefono"
                    Display="None" ErrorMessage="Teléfono es campo Obligatorio."></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" />
            </td>
            <td>
                <asp:Button runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" />
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="pnlAdministracionComunidad">
        <h2>
            Listado de Comunidades</h2>
        <asp:Repeater ID="rptComunidad" OnItemCommand="rptComunidad_OnItemCommand" runat="server">
            <HeaderTemplate>
                <div class="conte_box_white">
                    <div class="conte_tabla_datos_body_detail ">
                        <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th class="w10">
                                    Id
                                </th>
                                <th class="w20">
                                    Dirección
                                </th>
                                <th class="w20">
                                    Teléfono
                                </th>
                                <th class="w20">
                                    Cantidad Integrantes
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
                        <%# DataBinder.Eval(Container.DataItem, "Direccion")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "Telefono")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "Integrantes")%>
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
                        <asp:HiddenField ID="hdnDireccion" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Direccion")%>' />
                        <asp:HiddenField ID="hdnTelefono" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Telefono")%>' />
                        <asp:HiddenField ID="hdnCantidad" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Integrantes")%>' />
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
        <asp:Repeater ID="rptComunidadInactivo" OnItemCommand="rptComunidadInactivo_OnItemCommand"
            runat="server">
            <HeaderTemplate>
                <div class="conte_box_white">
                    <div class="conte_tabla_datos_body_detail ">
                        <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th class="w10">
                                    Id
                                </th>
                                <th class="w20">
                                    Descripcion
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
                        <%# DataBinder.Eval(Container.DataItem, "Id")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "Descripcion")%>
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
                        <asp:HiddenField ID="hdnDescripcion" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Descripcion")%>' />
                        <asp:HiddenField ID="HdnTipoSistema" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></div></div></div>
            </FooterTemplate>
        </asp:Repeater>
        <asp:HiddenField runat="server" ID="HiddenField1" />
    </asp:Panel>
</asp:Content>
