<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Admin/Home.master" AutoEventWireup="true" CodeFile="PersonaCrear.aspx.cs" Inherits="BI.Web.Private.Administracion.Persona" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/App_Master/Admin/Controls/BannerCentral.ascx" TagName="BannerCentral" TagPrefix="uc1" %>
<%@ Register Src="~/App_Master/Admin/Controls/GenericError.ascx" TagName="GenericError" TagPrefix="uc1" %>

<%@ Register Src="../../App_Master/Admin/Controls/wucCondominio.ascx" TagName="wucCondominio" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlProducto" runat="server" Visible="true">
        <asp:MultiView ID="mvwEmpresa" runat="server">
            <!--Creacion de usuario -->
            <asp:View runat="server" ID="mvPersonaCrear">
                <asp:HiddenField runat="server" ID="hidRut" />
                <div class="tit_box_white">
                    Mantenedor de Usuarios
                </div>
                <div class="conte_box_whitetabs">
                    <uc1:wucCondominio ID="wucCondominio1" runat="server" />
                    <div class="columna-left-160">
                        <p>
                            Perfil
                        </p>
                    </div>
                    <div class="columna-right">
                        <asp:DropDownList runat="server" CssClass="select_option" ID="ddlPerfil" OnSelectedIndexChanged="ddlPerfil_OnSelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlPerfil"
                            Display="None" ErrorMessage="El Tipo de Categoria es Obligatorio.">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="borde_bottom cf">
                    </div>
                    <asp:Panel ID="pnlPropietario" runat="server" Visible="false">
                        <div class="columna-left-160">
                            <p>
                                Casa
                            </p>
                        </div>
                        <div class="columna-right">
                            <asp:DropDownList runat="server" ID="ddlCasa" OnSelectedIndexChanged="ddlCasa_OnSelectedIndexChanged"
                                AutoPostBack="true" CssClass="select_option">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCasa"
                                Display="None" ErrorMessage="Debe Seleccionar Empleado.">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="columna-left-160">
                            <p>
                                Integrante Familia
                            </p>
                        </div>
                        <div class="columna-right">
                            <asp:DropDownList runat="server" ID="dllIntegrante" OnSelectedIndexChanged="dllIntegrante_OnSelectedIndexChanged"
                                AutoPostBack="true" CssClass="select_option">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="dllIntegrante"
                                Display="None" ErrorMessage="Debe Seleccionar Empleado.">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="borde_bottom cf">
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlDirectiva" runat="server" Visible="false">
                        <div class="columna-left-160">
                            <p>
                                Directiva
                            </p>
                        </div>
                        <div class="columna-right">
                            <asp:DropDownList runat="server" ID="ddlDirectiva" OnSelectedIndexChanged="ddlDirectiva_OnSelectedIndexChanged"
                                AutoPostBack="true" CssClass="select_option">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlDirectiva"
                                Display="None" ErrorMessage="Debe Seleccionar Directiva.">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="borde_bottom cf">
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlPorteria" runat="server" Visible="false">
                        <div class="columna-left-160">
                            <p>
                                Portero
                            </p>
                        </div>
                        <div class="columna-right">
                            <asp:DropDownList runat="server" ID="ddlPorteria" OnSelectedIndexChanged="ddlPorteria_OnSelectedIndexChanged"
                                AutoPostBack="true" CssClass="select_option">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlPorteria"
                                Display="None" ErrorMessage="Debe Seleccionar Porteria.">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="borde_bottom cf">
                        </div>
                    </asp:Panel>
                    <div class="columna-left-160">
                        <p>
                            Rut
                        </p>
                    </div>
                    <div class="columna-right">
                        <asp:TextBox ID="txtRut" runat="server" onblur="return validaRut(this)" onfocus="if(Trim(this.value)=='RUT')this.value=''"
                            MaxLength="12" CssClass="calendar left texto_option" Width="102px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVCtaCteOrigen" runat="server" ControlToValidate="txtRut"
                            Display="None" ErrorMessage="Rut es Oblitario.">*</asp:RequiredFieldValidator>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers"
                            TargetControlID="txtRut" ValidChars=".-Kk">
                        </cc1:FilteredTextBoxExtender>
                    </div>
                    <div class="columna-left-160">
                        <p>
                            Password inicial
                        </p>
                    </div>
                    <div class="columna-right">
                        <asp:TextBox runat="server" ID="txtpasswordInicial" MaxLength="12" CssClass="texto_option"></asp:TextBox>
                        <asp:LinkButton ID="Button1" runat="server" Text="Genera Clave" CssClass="BigButton mt10" OnClick="Button1_Click"
                            CausesValidation="false" />
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers, LowercaseLetters, UppercaseLetters"
                            TargetControlID="txtpasswordInicial">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpasswordInicial"
                            Display="None" ErrorMessage="Debe Ingresar Password Inicial.">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="borde_bottom cf">
                    </div>
                    <div class="columna-left-160">
                        <p>
                            Nombre
                        </p>
                    </div>
                    <div class="columna-right">
                        <asp:TextBox runat="server" ID="txtNombre" MaxLength="200" CssClass="texto_option"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNombre"
                            Display="None" ErrorMessage="Nombre es Obligatorio.">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="columna-left-160">
                        <p>
                            Apellido Paterno
                        </p>
                    </div>
                    <div class="columna-right">
                        <asp:TextBox runat="server" ID="txtPaterno" MaxLength="200" CssClass="texto_option"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPaterno"
                            Display="None" ErrorMessage="Apellido Paterno es Obligatorio.">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="borde_bottom cf">
                    </div>
                    <div class="columna-left-160">
                        <p>
                            Apellido Materno
                        </p>
                    </div>
                    <div class="columna-right">
                        <asp:TextBox runat="server" ID="txtMaterno" MaxLength="200" CssClass="texto_option"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMaterno"
                            Display="None" ErrorMessage="Apellido Materno es Obligatorio.">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="columna-left-160">
                        <p>
                            Fecha Nacimiento
                        </p>
                    </div>
                    <div class="columna-right">
                        <asp:TextBox ID="TxtFechaNacimiento" runat="server" MaxLength="10" CssClass="texto_option"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtFechaNacimiento"
                            Display="None" ErrorMessage="La Fecha Nacimiento es Obligatoria.">*</asp:RequiredFieldValidator>
                        <cc1:CalendarExtender ID="calendarioDesde" FirstDayOfWeek="Monday" Format="dd/MM/yyyy"
                            runat="server" TargetControlID="TxtFechaNacimiento" CssClass="cal_Theme1" PopupButtonID="TxtFechaNacimiento" />
                        <cc1:MaskedEditExtender ID="TxtFechaNacimiento_MaskedEditExtender" runat="server"
                            Mask="99/99/9999" MaskType="Date" TargetControlID="TxtFechaNacimiento" CultureName="es-ES">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="TxtFechaNacimiento_MaskedEditExtender"
                            ControlToValidate="TxtFechaNacimiento" Display="None" EmptyValueMessage="Fecha"
                            ErrorMessage="Fecha no válida." InvalidValueMessage="Fecha Nacimiento no válida."
                            IsValidEmpty="False" SetFocusOnError="True">*
                        </cc1:MaskedEditValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtFechaNacimiento"
                            Display="None" ErrorMessage="La fecha nacimiento es obligatoria.">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="borde_bottom cf">
                    </div>
                    <div class="columna-left-160">
                        <p>
                            Email
                        </p>
                    </div>
                    <div class="columna-right">
                        <asp:TextBox runat="server" ID="txtMail" MaxLength="200" CssClass="texto_option"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMail"
                            Display="None" ErrorMessage="El Correo es Obligatorio.">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="none" ErrorMessage="Correo Invalido"
                            runat="server" ControlToValidate="txtMail" SetFocusOnError="true" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="mt10">
                        <asp:LinkButton ID="BtnCrear" CssClass="BigButton mt10" CausesValidation="true" Text="Grabar"
                            runat="server" OnClick="BtnCrear_Click" />
                        <asp:LinkButton ID="btnEditar" Visible="false" CssClass="BigButton mt10" CausesValidation="true"
                            Text="Editar" runat="server" OnClick="btnEditar_Click" />
                    </div>
                    <div class="cf">
                    </div>
                </div>
                <asp:Repeater ID="rptUsuario" OnItemCommand="rptUsuario_OnItemCommand" runat="server">
                    <HeaderTemplate>
                        <div class="conte_box_white_gr">
                            <div class="conte_tabla_datos_body_detail ">
                                <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <th class="w10 titulos">Rut
                                        </th>
                                        <th class="w10 titulos">Nombre
                                        </th>
                                        <th class="w5 titulos">E-Mail
                                        </th>
                                        <th class="w5 titulos">Estado
                                        </th>
                                        <th class="w5 titulos">Activar/Desactivar
                                        </th>
                                        <th class="w5 titulos">Funcionalidades
                                        </th>
                                    </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <th class="w10">
                                <%# YouCom.Service.Generales.Formato.FormatoRut(DataBinder.Eval(Container.DataItem, "Rut").ToString())%>
                            </th>
                            <th class="w10 ">
                                <%# DataBinder.Eval(Container.DataItem, "Nombres")%>
                            </th>
                            <th class="w5">
                                <%# DataBinder.Eval(Container.DataItem, "Mail")%>
                            </th>
                            <th class="w5">
                                <%# DataBinder.Eval(Container.DataItem, "Estado")%>
                            </th>
                            <th class="w5">
                                <asp:LinkButton ID="LinkButton4" runat="server" ToolTip="Activar" Text='' CausesValidation="false"
                                    CommandName="Activar">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/icons/icon_ok.jpg" />
                                </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" ToolTip="Desactivar" Text='' CausesValidation="false"
                                    CommandName="Desactivar">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/icons/icon_trash.png" />
                                </asp:LinkButton>
                                <asp:HiddenField ID="hdnRut" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Rut")%>' />
                                <asp:HiddenField ID="hdnCondominio" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TheCondominioDTO.IdCondominio")%>' />
                            </th>
                            <th class="w5">
                                <asp:LinkButton ID="LinkButton2" runat="server" ToolTip="Funcionalidades" CausesValidation="false"
                                    CommandName="Funcionalidad">
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/icons/icon_more.jpg" />
                                </asp:LinkButton>
                            </th>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></div>
                    </FooterTemplate>
                </asp:Repeater>

            </asp:View>
            <asp:View runat="server" ID="mvcFuncionalidades">
                <div class="contenedor_box_center">
                    <h2>Datos del Empleado</h2>
                    <div class="conte_box_whitetabs_ch">
                        <div class="columna-left-160">
                            <p>
                                Rut:
                            </p>
                        </div>
                        <div class="columna-right">
                            <p>
                                <%=this.txtRut.Text%>
                            </p>
                        </div>
                        <div class="borde_left cf">
                        </div>
                        <div class="columna-left-160">
                            <p>
                                Nombre:
                            </p>
                        </div>
                        <div class="columna-right">
                            <p>
                                <%=this.txtNombre.Text%>
                            </p>
                        </div>
                        <div class="borde_left cf">
                        </div>
                        <div class="columna-left-160">
                            <p>
                                Paterno
                            </p>
                        </div>
                        <div class="columna-right">
                            <p>
                                <%=this.txtPaterno.Text%>
                            </p>
                        </div>
                        <div class="borde_left cf">
                        </div>
                        <div class="columna-left-160">
                            <p>
                                Materno
                            </p>
                        </div>
                        <div class="columna-right">
                            <p>
                                <%=this.txtMaterno.Text%>
                            </p>
                        </div>
                        <div class="borde_left cf">
                        </div>
                        <div class="columna-left-160">
                            <p>
                                Mail
                            </p>
                        </div>
                        <div class="columna-right">
                            <p>
                                <%=this.txtMail.Text%>
                            </p>
                        </div>
                        <div class="borde_left cf">
                        </div>
                    </div>
                </div>
                <div class="contenedor_box_center">
                    <h2>Asignacion de Funcionalidades
                    </h2>
                    <asp:Repeater ID="rptGrupo" runat="server" OnItemDataBound="rptGrupo_OnItemDataBound">
                        <HeaderTemplate>
                            <div>
                                <table class="tabla_datos_body" border="0" cellspacing="0" cellpadding="0">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="w10 txt-left" style="color: Black">
                                    <%# DataBinder.Eval(Container.DataItem, "FuncionGrupoNombre")%>
                                    <asp:HiddenField ID="hdnFuncionGrupoCod" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "FuncionGrupoCod")%>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Repeater ID="rptFuncionesGrupo" runat="server">
                                        <HeaderTemplate>
                                            <table class="tabla_datos_body" border="0" cellspacing="0" cellpadding="0">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td class="w20">
                                                    <%# DataBinder.Eval(Container.DataItem, "FuncionNombre") %>
                                                    <asp:HiddenField ID="hdnFuncionGrupoCod" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "FuncionCod")%>' />
                                                </td>
                                                <td class="w4">
                                                    <asp:CheckBox runat="server" ID="chkFuncion" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table></div></div>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table></div>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div>
                        <asp:Button ID="btnAsignar" CssClass="BigButton mt10" CausesValidation="true" Text="Asignar Funcionalidades"
                            runat="server" OnClick="btnAsignar_Click" />
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
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

