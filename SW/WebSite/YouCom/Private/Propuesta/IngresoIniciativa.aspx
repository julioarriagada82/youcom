<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true" CodeFile="IngresoIniciativa.aspx.cs" Inherits="Privado_Propuesta_IngresoIniciativa" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Iniciativa</h1>
    <form class="form-horizontal col-sm-12 col-md-9" role="form">
    <!-- Nombre -->
    <div class="form-group">
        <label for="nombre" class="col-sm-12 col-md-2 control-label">
            Nombre</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" placeholder="Nombre" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <!-- Apellido Paterno -->
    <div class="form-group">
        <label for="apellidopaterno" class="col-sm-12 col-md-2 control-label">
            Apellido Paterno</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtPaterno" runat="server" CssClass="form-control" placeholder="Apellido Paterno" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="apellidomaterno" class="col-sm-12 col-md-2 control-label">
            Apellido Materno</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtMaterno" runat="server" CssClass="form-control" placeholder="Apellido Materno" Enabled="false"></asp:TextBox>
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
    <!-- Asunto -->
    <div class="form-group">
        <label for="direccion" class="col-sm-12 col-md-2 control-label">
            Dirección</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtDireccion" runat="server"  CssClass="form-control" placeholder="Dirección"></asp:TextBox>
        </div>
    </div>
        <!-- Asunto -->
    <div class="form-group">
        <label for="nombre_iniciativa" class="col-sm-12 col-md-2 control-label">
            Nombre Iniciativa</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtNombreIniciativa" runat="server"  CssClass="form-control" placeholder="Nombre Iniciativa"></asp:TextBox>
        </div>
    </div>
    <!-- Comentarios -->
    <div class="form-group">
        <label for="comentarios" class="col-sm-12 col-md-2 control-label">
            Descripción Iniciativa</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtDescripcion" runat="server" Rows="3" CssClass="form-control"
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
