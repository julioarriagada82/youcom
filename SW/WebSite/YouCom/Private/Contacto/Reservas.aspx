<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true"
    CodeFile="Reservas.aspx.cs" Inherits="Privado_Reservas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">Reservas</h1>
    <form>
        <!-- Nombre -->
        <fieldset class="form-group">
            <label for="email" class="col-sm-12 col-md-2 control-label">
                Aréa Común</label>
            <div class="col-sm-12 col-md-10">
                <asp:DropDownList ID="ddlAreaComun" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAreaComun"
                    Display="None" ErrorMessage="Por favor el aréa común a reservar" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
            </div>
        </fieldset>
        <fieldset class="form-group">
            <label for="email" class="col-sm-12 col-md-2 control-label">
                Fecha</label>
            <div class="col-sm-12 col-md-10">
                <asp:TextBox ID="TxtFecha" runat="server" MaxLength="10" CssClass="form-control"
                    placeholder="Ingresar fecha"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVCtaCteOrigen" runat="server" ControlToValidate="TxtFecha"
                    Display="None" ErrorMessage="La Fecha es Obligatoria." ValidationGroup="Insertar">*</asp:RequiredFieldValidator>
                <cc1:CalendarExtender ID="calendarioDesde" FirstDayOfWeek="Monday" Format="dd/MM/yyyy"
                    runat="server" TargetControlID="TxtFecha" CssClass="cal_Theme1" PopupButtonID="TxtFecha" />
                <cc1:MaskedEditExtender ID="TxtFecha_MaskedEditExtender" runat="server" Mask="99/99/9999"
                    MaskType="Date" TargetControlID="TxtFecha" CultureName="es-ES">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="TxtFecha_MaskedEditExtender"
                    ControlToValidate="TxtFecha" Display="None" EmptyValueMessage="Fecha" ErrorMessage="Fecha no válida."
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
                    <asp:ListItem Text="01" Value="01"></asp:ListItem>
                    <asp:ListItem Text="02" Value="02"></asp:ListItem>
                    <asp:ListItem Text="03" Value="03"></asp:ListItem>
                    <asp:ListItem Text="04" Value="04"></asp:ListItem>
                    <asp:ListItem Text="05" Value="05"></asp:ListItem>
                    <asp:ListItem Text="06" Value="06"></asp:ListItem>
                    <asp:ListItem Text="07" Value="07"></asp:ListItem>
                    <asp:ListItem Text="08" Value="08"></asp:ListItem>
                    <asp:ListItem Text="09" Value="09"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMinutoInicio" runat="server" CssClass="form-control">
                    <asp:ListItem Text="00" Value="00"></asp:ListItem>
                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlHoraInicio"
                    Display="None" ErrorMessage="Por favor seleccione hora de inicio" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlMinutoInicio"
                    Display="None" ErrorMessage="Por favor ingrese minuto de inicio" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
            </div>
        </fieldset>
        <fieldset class="form-group">
            <label for="email" class="col-sm-12 col-md-2 control-label">
                Hora Termino</label>
            <div class="col-sm-12 col-md-10">
                <asp:DropDownList ID="ddlHoraTermino" runat="server" CssClass="form-control">
                    <asp:ListItem Text="01" Value="01"></asp:ListItem>
                    <asp:ListItem Text="02" Value="02"></asp:ListItem>
                    <asp:ListItem Text="03" Value="03"></asp:ListItem>
                    <asp:ListItem Text="04" Value="04"></asp:ListItem>
                    <asp:ListItem Text="05" Value="05"></asp:ListItem>
                    <asp:ListItem Text="06" Value="06"></asp:ListItem>
                    <asp:ListItem Text="07" Value="07"></asp:ListItem>
                    <asp:ListItem Text="08" Value="08"></asp:ListItem>
                    <asp:ListItem Text="09" Value="09"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMinutoTermino" runat="server" CssClass="form-control">
                    <asp:ListItem Text="00" Value="00"></asp:ListItem>
                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlHoraTermino"
                    Display="None" ErrorMessage="Por favor seleccione hora de termino" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlMinutoTermino"
                    Display="None" ErrorMessage="Por favor ingrese minuto de termino" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
            </div>
        </fieldset>
        <!-- Comentarios -->
        <fieldset class="form-group">
            <label for="comentarios" class="col-sm-12 col-md-2 control-label">
                Comentarios</label>
            <div class="col-sm-12 col-md-10">
                <asp:TextBox ID="TxtComentarios" runat="server" Rows="3" CssClass="form-control"
                    TextMode="MultiLine" placeholder="Sus comentarios..."></asp:TextBox>
            </div>
        </fieldset>
        <asp:Button ID="BtnEnviar" runat="server" CssClass="btn btn-default" Text="Enviar"
            ValidationGroup="DatosPaso1" OnClick="BtnEnviar_Click" />
        <asp:Button ID="BtnVolver" runat="server" CssClass="btn btn-default" CausesValidation="false" Text="Volver" />
    </form>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="DatosPaso1" />
</asp:Content>
