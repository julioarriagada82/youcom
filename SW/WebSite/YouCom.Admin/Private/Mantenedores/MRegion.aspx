﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/Admin/Home.master"
    CodeFile="MRegion.aspx.cs" Inherits="Admin_Mantenedores_MRegion" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/App_Master/Admin/Controls/BannerCentral.ascx" TagName="BannerCentral" TagPrefix="uc1" %>
<%@ Register Src="~/App_Master/Admin/Controls/GenericError.ascx" TagName="GenericError" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlProducto" runat="server" Visible="true">

        <asp:Label runat="server" ID="lblPopUp"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
            ShowSummary="false" />
        <div class="tit_box_white">
            Mantenedor de Regiones
        </div>
        <div class="conte_box_whitetabs">
            <div class="columna-left-160">
                <p>
                    País
                </p>
            </div>
            <div class="columna-right">
                <asp:DropDownList runat="server" ID="ddlPais" Width="120px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlPais"
                    Display="None" ErrorMessage="Debe Seleccionar Pais."></asp:RequiredFieldValidator>
            </div>
            <div class="columna-left-160">
                <p>
                    Región
                </p>
            </div>
            <div class="columna-right">
                <asp:TextBox runat="server" MaxLength="50" ID="txtRegion" Width="210px" Height="18px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                    TargetControlID="txtRegion" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRegion"
                    Display="None" ErrorMessage="Region es campo Obligatorio."></asp:RequiredFieldValidator>
            </div>
            <div class="mt10">
                <asp:LinkButton runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" CssClass="BigButton" />
                <asp:LinkButton runat="server" Visible="false" ID="btnEditar" Text="Editar" OnClick="btnEditar_Click" CssClass="BigButton" />
                <asp:ImageButton Text="Ver Papeleria" OnClick="lblPapeleria_OnClick" ImageUrl="~/images/iconos/bot_papelera.jpg"
                    AlternateText="Papelera" ToolTip="Papelera" CausesValidation="false" ID="lblPapeleria"
                    runat="server"></asp:ImageButton>
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlAdministracionRegion">
            <asp:Repeater ID="rptRegion" OnItemCommand="rptRegion_OnItemCommand" runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white_gr">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w10 titulos">Id
                                    </th>
                                    <th class="w20 titulos">Nombre
                                    </th>
                                    <th class="w20 titulos">País
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
                            <%# DataBinder.Eval(Container.DataItem, "IdRegion")%>
                        </th>
                        <th class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "NombreRegion")%>
                        </th>
                        <th class="w20 txt-left">
                            <%# DataBinder.Eval(Container.DataItem, "ThePaisDTO.NombrePais")%>
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
                            <asp:LinkButton ID="LnkBtnCodPropuesta" CausesValidation="false" runat="server" ToolTip="Editar Region"
                                CommandName="Editar"><span class="icon_edit"></span></asp:LinkButton>
                            <asp:HiddenField ID="HdnTipoSistema" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "idRegion")%>' />
                        </th>
                        <th class="w10">
                            <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Eliminar" CausesValidation="false"
                                CommandName="Eliminar"><span class="icon_trash"></span></asp:LinkButton>
                        </th>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></div></div></div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField runat="server" ID="HidIdRegion" />
        </asp:Panel>
        <asp:Panel ID="pnlPapelera" runat="server" Visible="false">
            <asp:Repeater ID="rptRegionInactivo" OnItemCommand="rptRegionInactivo_OnItemCommand"
                runat="server">
                <HeaderTemplate>
                    <div class="conte_box_white">
                        <div class="conte_tabla_datos_body_detail ">
                            <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th class="w10">Id
                                    </th>
                                    <th class="w20">Descripcion
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
                            <%# DataBinder.Eval(Container.DataItem, "IdRegion")%>
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
                            <asp:LinkButton ID="LnkBtnCodPropuesta" CausesValidation="false" runat="server" ToolTip="Editar Region"
                                CommandName="Activar">Activar Registro</asp:LinkButton>
                            <asp:HiddenField ID="HdnTipoSistema" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "idRegion")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></div></div></div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField runat="server" ID="HiddenField1" />
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
