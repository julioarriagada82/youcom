<%@ page title="" language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Mantenedores_MFamilia, App_Web_y4k0mwx9" enableEventValidation="false" %>

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
                Nombre
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtNombre" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtNombre" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNombre"
                    Display="None" ErrorMessage="Nombre es campo Obligatorio."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Apellido
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtApellido" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtApellido" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApellido"
                    Display="None" ErrorMessage="Apellido es campo Obligatorio."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Rut
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtRut" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom,Numbers"
                    TargetControlID="txtRut" ValidChars="-kK.">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRut"
                    Display="None" ErrorMessage="Rut es campo Obligatorio."></asp:RequiredFieldValidator>
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
                Ocupacion
            </td>
            <td>
                <asp:DropDownList ID="ddlOcupacion" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlOcupacion"
                    Display="None" ErrorMessage="Ocupacion es campo Obligatorio."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Parentesco
            </td>
            <td>
                <asp:DropDownList ID="ddlParentesco" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlParentesco"
                    Display="None" ErrorMessage="Parentesco es campo Obligatorio."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Celular
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCelular" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtCelular" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCelular"
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
    <asp:Panel runat="server" ID="pnlAdministracionCasa">
        <h2>
            Listado de Integrantes Familia</h2>
        <asp:Repeater ID="rptFamilia" OnItemCommand="rptFamilia_OnItemCommand" runat="server">
            <HeaderTemplate>
                <div class="conte_box_white">
                    <div class="conte_tabla_datos_body_detail ">
                        <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th class="w10">
                                    Rut
                                </th>
                                <th class="w20">
                                    Nombre
                                </th>
                                <th class="w20">
                                    Apellido
                                </th>
                                <th class="w20">
                                    Ocupacion
                                </th>
                                <th class="w20">
                                    Parentesco
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
                        <%# DataBinder.Eval(Container.DataItem, "RutFamilia")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "NombreFamilia")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "ApellidoFamilia")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "IdOcupacion")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "IdParentescoFamilia")%>
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
                        <asp:HiddenField ID="hdnIdFamilia" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdFamilia")%>' />
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
        <asp:Repeater ID="rptFamiliaInactivo" OnItemCommand="rptFamiliaInactivo_OnItemCommand"
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
                        <asp:HiddenField ID="hdnIdFamilia" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdFamilia")%>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></div></div></div>
            </FooterTemplate>
        </asp:Repeater>
        <asp:HiddenField runat="server" ID="hdnIdFamilia" />
    </asp:Panel>
</asp:Content>
