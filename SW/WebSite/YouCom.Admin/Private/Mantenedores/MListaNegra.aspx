<%@ Page Language="C#" MasterPageFile="~/App_Master/Admin/Home.master" AutoEventWireup="true"
    CodeFile="MListaNegra.aspx.cs" Inherits="Admin_Mantenedores_MListaNegra" Title="Untitled Page" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/App_Master/Admin/Controls/BannerCentral.ascx" TagName="BannerCentral" TagPrefix="uc1" %>
<%@ Register Src="~/App_Master/Admin/Controls/GenericError.ascx" TagName="GenericError" TagPrefix="uc1" %>

<%@ Register Src="../../App_Master/Admin/Controls/wucCondominioCasaFamilia.ascx" TagName="wucCondominioCasaFamilia" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlProducto" runat="server" Visible="true">

        <asp:Label runat="server" ID="lblPopUp"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
            ShowSummary="false" />
        <div class="tit_box_white">
            Mantenedor de Lista Negra
        </div>
        <div class="conte_box_whitetabs">
            <uc1:wucCondominioCasaFamilia ID="wucCondominioCasaFamilia1" runat="server" />
            <div class="columna-left-160">
                <p>
                    Rut
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox runat="server" ID="txtRut" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom,Numbers"
                    TargetControlID="txtRut" ValidChars="-kK.">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRut"
                    Display="None" ErrorMessage="Rut es campo Obligatorio."></asp:RequiredFieldValidator>
            </div>
            <div class="columna-left-160">
                <p>
                    Nombre
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox runat="server" ID="txtNombre" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtNombre" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNombre"
                    Display="None" ErrorMessage="Nombre es campo Obligatorio."></asp:RequiredFieldValidator>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Apellido Paterno
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox runat="server" ID="txtApellidoPaterno" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtApellidoPaterno" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApellidoPaterno"
                    Display="None" ErrorMessage="Apellido Paterno es campo Obligatorio."></asp:RequiredFieldValidator>
            </div>
            <div class="columna-left-160">
                <p>
                    Apellido Materno
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox runat="server" ID="txtApellidoMaterno" Width="210px" Height="18px" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtApellidoMaterno" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtApellidoMaterno"
                    Display="None" ErrorMessage="Apellido Materno es campo Obligatorio."></asp:RequiredFieldValidator>
            </div>
            <div class="borde_bottom cf">
            </div>
            <div class="columna-left-160">
                <p>
                    Motivo
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox runat="server" ID="txtMotivo" Width="210px" Height="18px" MaxLength="500"
                    TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMotivo"
                    Display="None" ErrorMessage="Motivo es campo Obligatorio."></asp:RequiredFieldValidator>
            </div>
            <div class="mt10">
                <asp:LinkButton runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" CssClass="BigButton" />
                <asp:LinkButton runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" CssClass="BigButton" />
                <asp:ImageButton Text="Ver Papeleria" OnClick="lblPapeleria_OnClick" ImageUrl="~/images/iconos/bot_papelera.jpg"
                    AlternateText="Papelera" ToolTip="Papelera" CausesValidation="false" ID="lblPapeleria"
                    runat="server"></asp:ImageButton>
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlAdministracionListaNegra">
            <asp:Repeater ID="rptListaNegra" OnItemCommand="rptListaNegra_OnItemCommand" runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white_gr">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w10 titulos">Rut
                                    </th>
                                    <th class="w10 titulos">Nombre
                                    </th>
                                    <th class="w10 titulos">Apellido Paterno
                                    </th>
                                    <th class="w10 titulos">Apellido Materno
                                    </th>
                                    <th class="w10 titulos">Integrante
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
                            <%# DataBinder.Eval(Container.DataItem, "RutListaNegra")%>
                        </th>
                        <th class="w10 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "NombreListaNegra")%>
                        </th>
                        <th class="w10 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "ApellidoPaternoListaNegra")%>
                        </th>
                        <th class="w10 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "ApellidoMaternoListaNegra")%>
                        </th>
                        <th class="w10 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "TheFamiliaDTO.NombreCompleto")%>
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
                            <asp:HiddenField ID="hdnIdListaNegra" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdListaNegra")%>' />
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
            <asp:Repeater ID="rptListaNegraInactivo" OnItemCommand="rptListaNegraInactivo_OnItemCommand"
                runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w10">Rut
                                    </th>
                                    <th class="w20">Nombre
                                    </th>
                                    <th class="w20">Apellido
                                    </th>
                                    <th class="w10">Usuario Ingreso
                                    </th>
                                    <th class="w10">Fecha Ingreso
                                    </th>
                                    <th class="w10">Usuario Modificacion
                                    </th>
                                    <th class="w10">Fecha Mofificacion
                                    </th>
                                    <th class="w10">Activar
                                    </th>
                                </tr>
                            </table>
                            <div class="conte_tabla_datos_body_gr">
                                <table class="tabla_datos_body" border="0" cellspacing="0" cellpadding="0">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="w10 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "RutListaNegra")%>
                        </td>
                        <td class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "NombreListaNegra")%>
                        </td>
                        <td class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "ApellidoListaNegra")%>
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
                            <asp:HiddenField ID="hdnIdListaNegra" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdListaNegra")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></div></div></div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnIdListaNegra" />
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
