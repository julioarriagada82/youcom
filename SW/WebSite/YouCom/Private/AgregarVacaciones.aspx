<%@ Page Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true"
    CodeFile="AgregarVacaciones.aspx.cs" Inherits="Privado_AgregarVacaciones" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Ingresar Propiedad desocupada</h1>
    <form class="form-horizontal col-sm-12 col-md-9" role="form">
    <!-- Nombre -->
    <div class="form-group">
        <label for="nombre" class="col-sm-12 col-md-2 control-label">
            Nombre</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" placeholder="Nombre"
                Enabled="false"></asp:TextBox>
        </div>
    </div>
    <!-- Apellido Paterno -->
    <div class="form-group">
        <label for="apellidopaterno" class="col-sm-12 col-md-2 control-label">
            Apellido</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtPaterno" runat="server" CssClass="form-control" placeholder="Apellido Paterno"
                Enabled="false"></asp:TextBox>
        </div>
    </div>
    <!-- Email -->
    <div class="form-group">
        <label for="email" class="col-sm-12 col-md-2 control-label">
            Email</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtEmail"
                Display="None" ErrorMessage="Por favor ingrese un correo electrónico" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="REVMail" runat="server" ControlToValidate="TxtEmail"
                Display="None" ErrorMessage="Por favor ingrese un correo electrónico valido."
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="DatosPaso1">*</asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="form-group">
        <label for="email" class="col-sm-12 col-md-2 control-label">
            Desde</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtDesde" runat="server" MaxLength="10" CssClass="form-control"
                placeholder="Ingresar fecha"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVCtaCteOrigen" runat="server" ControlToValidate="TxtDesde"
                Display="None" ErrorMessage="La Fecha Desde es Obligatoria." ValidationGroup="Insertar">*</asp:RequiredFieldValidator>
            <cc1:CalendarExtender ID="calendarioDesde" FirstDayOfWeek="Monday" Format="dd/MM/yyyy"
                runat="server" TargetControlID="TxtDesde" CssClass="cal_Theme1" PopupButtonID="TxtDesde" />
            <cc1:MaskedEditExtender ID="TxtDesde_MaskedEditExtender" runat="server" Mask="99/99/9999"
                MaskType="Date" TargetControlID="TxtDesde" CultureName="es-ES">
            </cc1:MaskedEditExtender>
            <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="TxtDesde_MaskedEditExtender"
                ControlToValidate="TxtDesde" Display="None" EmptyValueMessage="Fecha" ErrorMessage="Fecha no válida."
                InvalidValueMessage="Fecha no válida" IsValidEmpty="False" SetFocusOnError="True"
                ValidationGroup="Insertar">*
            </cc1:MaskedEditValidator>
        </div>
    </div>
    <div class="form-group">
        <label for="email" class="col-sm-12 col-md-2 control-label">
            Hasta</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtHasta" runat="server" MaxLength="10" CssClass="form-control"
                placeholder="Ingresar fecha"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtHasta"
                Display="None" ErrorMessage="La Fecha es Obligatoria." ValidationGroup="Insertar">*</asp:RequiredFieldValidator>
            <cc1:CalendarExtender ID="calendarioHasta" FirstDayOfWeek="Monday" Format="dd/MM/yyyy"
                runat="server" TargetControlID="TxtHasta" CssClass="cal_Theme1" PopupButtonID="TxtHasta" />
            <cc1:MaskedEditExtender ID="TxtHasta_MaskedEditExtender" runat="server" Mask="99/99/9999"
                MaskType="Date" TargetControlID="TxtHasta" CultureName="es-ES">
            </cc1:MaskedEditExtender>
            <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="TxtHasta_MaskedEditExtender"
                ControlToValidate="TxtHasta" Display="None" EmptyValueMessage="Fecha" ErrorMessage="Fecha no válida."
                InvalidValueMessage="Fecha no válida." IsValidEmpty="False" SetFocusOnError="True"
                ValidationGroup="Insertar">*
            </cc1:MaskedEditValidator>
        </div>
    </div>
    <div class="form-group">
        <label for="email" class="col-sm-12 col-md-2 control-label">
            Motivo</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtMotivo" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtMotivo"
                Display="None" ErrorMessage="Por favor ingrese motivo" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label for="email" class="col-sm-12 col-md-2 control-label">
            Nombre Contacto</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtNombreContacto" runat="server" CssClass="form-control" placeholder="Nombre Contacto"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtEmail"
                Display="None" ErrorMessage="Por favor ingrese nombre contacto" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label for="email" class="col-sm-12 col-md-2 control-label">
            Telefono Contacto</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtTelefonoContacto" runat="server" CssClass="form-control" placeholder="Telefono Contacto"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtTelefonoContacto"
                Display="None" ErrorMessage="Por favor ingrese telefono contacto" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label for="email" class="col-sm-12 col-md-2 control-label">
            Parentesco</label>
        <div class="col-sm-12 col-md-10">
            <asp:DropDownList ID="ddlParentesco" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlParentesco"
                Display="None" ErrorMessage="Por favor seleccione parentesco" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
        </div>
    </div>
    <!-- Comentarios -->
    <div class="form-group">
        <label for="comentarios" class="col-sm-12 col-md-2 control-label">
            Comentarios</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtComentarios" runat="server" Rows="3" CssClass="form-control"
                TextMode="MultiLine" placeholder="Sus comentarios..."></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-offset-2 col-sm-12 col-md-10">
            <asp:Button ID="BtnEnviar" runat="server" CssClass="btn btn-default" Text="Enviar"
                ValidationGroup="DatosPaso1" OnClick="BtnEnviar_Click" />
        </div>
    </div>
    </form>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="DatosPaso1" />
</asp:Content>
