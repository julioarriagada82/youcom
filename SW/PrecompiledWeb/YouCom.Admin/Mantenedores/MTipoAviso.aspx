﻿<%@ page title="" language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Mantenedores_MTipoAviso, App_Web_y4k0mwx9" enableEventValidation="false" %>

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
            Listado de Tipo de Aviso</h2>
        <asp:Repeater ID="rptTipoAviso" OnItemCommand="rptTipoAviso_OnItemCommand" runat="server">
            <HeaderTemplate>
                <div class="conte_box_white">
                    <div class="conte_tabla_datos_body_detail ">
                        <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th class="w10">
                                    Id
                                </th>
                                <th class="w20">
                                    Nombre
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
                        <%# DataBinder.Eval(Container.DataItem, "IdTipoAviso")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "NombreTipoAviso")%>
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
                        <asp:HiddenField ID="hdnIdTipoAviso" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdTipoAviso")%>' />
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
        <asp:Repeater ID="rptTipoAvisoInactivo" OnItemCommand="rptTipoAvisoInactivo_OnItemCommand"
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
                                    Nombre
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
                        <%# DataBinder.Eval(Container.DataItem, "IdTipoAviso")%>
                    </td>
                    <td class="w20 txt-left">
                        <%# DataBinder.Eval(Container.DataItem, "NombreTipoAviso")%>
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
                        <asp:HiddenField ID="hdnIdTipoAviso" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdTipoAviso")%>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></div></div></div>
            </FooterTemplate>
        </asp:Repeater>
        <asp:HiddenField runat="server" ID="hdnIdTipoAviso" />
    </asp:Panel>
</asp:Content>
