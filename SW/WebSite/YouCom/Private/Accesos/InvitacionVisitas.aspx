<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true" CodeFile="InvitacionVisitas.aspx.cs" Inherits="Privado_Accesos_InvitacionVisitas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:MultiView ID="mvwAutorizaciones" runat="server">
        <asp:View ID="View1" runat="server">
            <h1 class="page-header">Invitación Visitas</h1>
            <div class="btn-toolbar" role="toolbar">
                <asp:LinkButton ID="BntAgregar" runat="server" CssClass="btn btn-default btn-lg pull-left" Text="Agregar Invitación Visitas" ValidationGroup="DatosPaso1" OnClick="BntAgregar_Click" />
            </div>
            <div class="row">
                <asp:Repeater ID="rptAutorizaciones" runat="server" OnItemCommand="rptAutorizaciones_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>R.U.T.
                                    </th>
                                    <th>Nombre
                                    </th>
                                    <th>Actividad
                                    </th>
                                    <th>Tipo
                                    </th>
                                    <th>Fecha Inicio
                                    </th>
                                    <th>Fecha Termino
                                    </th>
                                    <th>Detalle
                                    </th>
                                    <th>Eliminar
                                    </th>
                                    <th>Lista Negra
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# YouCom.Service.Generales.Formato.FormatoRut(DataBinder.Eval(Container.DataItem, "RutVisita").ToString())%>
                                <asp:HiddenField ID="HdnIdAccesoHogar" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdAccesoHogar")%>' />
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "NombreCompleto")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "TheTipoVisitaDTO.NombreTipoVisita")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "TheFrecuenciaDTO.NombreFrecuencia")%>
                            </td>
                            <td>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaInicio")).ToShortDateString()%>
                            </td>
                            <td>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaTermino")).ToShortDateString()%>
                            </td>
                            <td>
                                <asp:LinkButton ID="LnkBtnDetalle" runat="server" CommandName="Detalle">
                                                        <span class="glyphicon glyphicon-eye-open"></span>
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LnkBtnEliminar" runat="server" CommandName="Eliminar">
                                                        <span class="glyphicon glyphicon-eye-open"></span>
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkBtnListaNegra" runat="server" CommandName="ListaNegra">
                                                        <span class="glyphicon glyphicon-eye-open"></span>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>

            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="col-lg-8">
                <h1 class="page-header">Agregar Invitación Visitas</h1>
                <form>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Rut</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:TextBox ID="TxtRut" runat="server" CssClass="form-control" placeholder="Rut" onblur="formateaRut(this,'X.XXX.XXX-X');"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtRut"
                                Display="None" ErrorMessage="Por favor ingrese rut" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers, Custom"
                                TargetControlID="TxtRut" ValidChars=".-kK">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Nombre</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNombre"
                                Display="None" ErrorMessage="Por favor ingrese nombre" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FTE1" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                                TargetControlID="TxtNombre" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!ñÑ">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Apellido Paterno</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:TextBox ID="TxtApellidoPaterno" runat="server" CssClass="form-control" placeholder="Apellido Paterno"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtApellidoPaterno"
                                Display="None" ErrorMessage="Por favor ingrese apellido paterno" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                                TargetControlID="TxtApellidoPaterno" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!ñÑ">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Apellido Materno</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:TextBox ID="TxtApellidoMaterno" runat="server" CssClass="form-control" placeholder="Apellido Materno"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                                TargetControlID="TxtApellidoMaterno" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!ñÑ">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            E-Mail</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtEmail"
                                Display="None" ErrorMessage="Por favor ingrese e-mail" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterType="Numbers, Custom, LowercaseLetters, UppercaseLetters"
                                TargetControlID="TxtEmail" ValidChars=" @;:*.,-_|#$%/()[]{}¿?¡!">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RegularExpressionValidator ID="REVMailDestino" runat="server" ControlToValidate="TxtEmail"
                                Display="None" ErrorMessage="Estimado Cliente, el formato del E-mail no es correcto."
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="DatosPaso1">*</asp:RegularExpressionValidator>
                        </div>
                    </fieldset>
                    <!-- Nombre -->
                    <fieldset class="form-group">
                        <label for="telmovil" class="col-sm-12 col-md-2 control-label">
                            Tipo Visita</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:DropDownList runat="server" ID="ddlTipoVisita" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlTipoVisita"
                                Display="None" ErrorMessage="Por favor seleccione Tipo Visita." Style="display: inline;"
                                ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Fecha Inicio</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:TextBox ID="TxtFechaInicio" runat="server" MaxLength="10" CssClass="form-control"
                                placeholder="Ingresar fecha"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVCtaCteOrigen" runat="server" ControlToValidate="TxtFechaInicio"
                                Display="None" ErrorMessage="La Fecha es Obligatoria." ValidationGroup="Insertar">*</asp:RequiredFieldValidator>
                            <cc1:CalendarExtender ID="calendarioDesde" FirstDayOfWeek="Monday" Format="dd/MM/yyyy"
                                runat="server" TargetControlID="TxtFechaInicio" CssClass="cal_Theme1" PopupButtonID="TxtFechaInicio" />
                            <cc1:MaskedEditExtender ID="TxtFechaInicio_MaskedEditExtender" runat="server" Mask="99/99/9999"
                                MaskType="Date" TargetControlID="TxtFechaInicio" CultureName="es-ES">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="TxtFechaInicio_MaskedEditExtender"
                                ControlToValidate="TxtFechaInicio" Display="None" EmptyValueMessage="Fecha" ErrorMessage="Fecha no válida."
                                InvalidValueMessage="Fecha no válida" IsValidEmpty="False" SetFocusOnError="True"
                                ValidationGroup="Insertar">*
                            </cc1:MaskedEditValidator>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Fecha Termino</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:TextBox ID="TxtFechaTermino" runat="server" MaxLength="10" CssClass="form-control"
                                placeholder="Ingresar fecha termino"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtFechaTermino"
                                Display="None" ErrorMessage="La Fecha Termino es Obligatoria." ValidationGroup="Insertar">*</asp:RequiredFieldValidator>
                            <cc1:CalendarExtender ID="CalendarExtender1" FirstDayOfWeek="Monday" Format="dd/MM/yyyy"
                                runat="server" TargetControlID="TxtFechaTermino" CssClass="cal_Theme1" PopupButtonID="TxtFechaTermino" />
                            <cc1:MaskedEditExtender ID="TxtFechaTermino_MaskedEditExtender" runat="server" Mask="99/99/9999"
                                MaskType="Date" TargetControlID="TxtFechaTermino" CultureName="es-ES">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="TxtFechaTermino_MaskedEditExtender"
                                ControlToValidate="TxtFechaTermino" Display="None" EmptyValueMessage="Fecha" ErrorMessage="Fecha no válida."
                                InvalidValueMessage="Fecha no válida" IsValidEmpty="False" SetFocusOnError="True"
                                ValidationGroup="Insertar">*
                            </cc1:MaskedEditValidator>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Hora Inicio</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:DropDownList ID="ddlHoraInicio" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlMinutoInicio" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlHoraInicio"
                                Display="None" ErrorMessage="Por favor seleccione hora de inicio" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMinutoInicio"
                                Display="None" ErrorMessage="Por favor ingrese minuto de inicio" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Hora Termino</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:DropDownList ID="ddlHoraTermino" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlMinutoTermino" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlHoraTermino"
                                Display="None" ErrorMessage="Por favor seleccione hora de termino" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlMinutoTermino"
                                Display="None" ErrorMessage="Por favor ingrese minuto de termino" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Dia semana</label>
                        <div class="radio radiobuttonlist col-sm-12 col-md-10">
                            <asp:CheckBoxList ID="rblSemana" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
                                <asp:ListItem Text="Lunes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Martes" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Miercoles" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Jueves" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Viernes" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Sabado" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Domingo" Value="7"></asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </fieldset>
                    <asp:Button ID="BtnEnviar" runat="server" CssClass="btn btn-primary" Text="Publicar Ingreso" ValidationGroup="DatosPaso1" OnClick="BtnEnviar_Click" />
                    <asp:Button ID="BtnVolver" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Volver" OnClick="BtnVolver_Click" />

                </form>
            </div>
            <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
                ValidationGroup="DatosPaso1" />
        </asp:View>
        <asp:View ID="View3" runat="server">
            <h1 class="page-header">Invitación Visitas</h1>
            <div class="col-lg">
                <div class="media-body">
                    <table class="table">
                        <tbody>
                            <tr>
                                <td class="success">
                                    <h4 class="media-heading">
                                        <asp:Literal ID="LitNombre" runat="server"></asp:Literal>
                                    </h4>
                                    <h2 class="media-heading">
                                        <asp:Literal ID="LitEmail" runat="server"></asp:Literal>
                                    </h2>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="media-body">
                    <h2>Actividad:</h2>
                    <p>
                        <asp:Literal ID="LitActividad" runat="server"></asp:Literal>
                    </p>
                    <p>
                        <span class="glyphicon glyphicon-time"></span>
                        <small>Fecha Inicio:
                        <asp:Literal ID="LitFechaInicio" runat="server"></asp:Literal></small>
                    </p>
                    <p>
                        <span class="glyphicon glyphicon-time"></span>
                        <small>Fecha Termino:
                        <asp:Literal ID="LitFechaTermino" runat="server"></asp:Literal></small>
                    </p>
                    <p>
                        Tipo:
                        <asp:Literal ID="LitTipo" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="media-body">
                    <asp:UpdatePanel ID="updPanelCalendar" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="calendarFechas" runat="server" BackColor="#e2e2e2"
                                BorderColor="Black" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" ForeColor="Black"
                                Height="190px" NextPrevFormat="FullMonth" DayHeaderStyle-BorderStyle="Solid"
                                DayHeaderStyle-BorderColor="Black" DayStyle-BorderColor="Black" DayStyle-BorderStyle="Solid"
                                FirstDayOfWeek="Monday" Width="450" OnDayRender="calendarFechas_DayRender">
                                <SelectedDayStyle ForeColor="Red" Font-Bold="true" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                <DayHeaderStyle Font-Bold="True" BorderColor="Black" BorderWidth="1px" Font-Size="8pt" />
                                <TitleStyle BackColor="#e2e2e2" BorderColor="Black" BorderWidth="1px" Font-Bold="True"
                                    Font-Size="12pt" ForeColor="Black" />
                            </asp:Calendar>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="calendarFechas" EventName="" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="btn-toolbar" role="toolbar">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Volver" OnClick="BtnVolver_Click" />
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

