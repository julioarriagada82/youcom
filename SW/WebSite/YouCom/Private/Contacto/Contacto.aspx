<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true"
    CodeFile="Contacto.aspx.cs" Inherits="Privado_Contacto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Contacto</h1>
    <form class="form-horizontal col-sm-12 col-md-9" role="form">
    <!-- Nombre -->
    <div class="form-group">
        <label for="nombre" class="col-sm-12 col-md-2 control-label">
            Nombre</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox Enabled="false" ID="TxtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNombre"
                Display="None" ErrorMessage="Por favor ingrese su nombre." Style="display: inline;"
                ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="TxtNombre"
                ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
            </cc1:FilteredTextBoxExtender>
        </div>
    </div>
    <!-- Apellido Paterno -->
    <div class="form-group">
        <label for="apellidopaterno" class="col-sm-12 col-md-2 control-label">
            Apellido Paterno</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox Enabled="false" ID="TxtPaterno" runat="server" CssClass="form-control" placeholder="Apellido Paterno"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtPaterno"
                Display="None" ErrorMessage="Por favor ingrese su apellido paterno." Style="display: inline;"
                ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="TxtPaterno"
                ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
            </cc1:FilteredTextBoxExtender>
        </div>
    </div>
    <!-- Apellido Materno -->
    <div class="form-group">
        <label for="apellidomaterno" class="col-sm-12 col-md-2 control-label">
            Apellido Materno</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtMaterno" runat="server" CssClass="form-control" placeholder="Apellido Materno"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtMaterno"
                Display="None" ErrorMessage="Por favor ingrese su apellido materno." Style="display: inline;"
                ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="TxtMaterno"
                ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
            </cc1:FilteredTextBoxExtender>
        </div>
    </div>
    <!-- Telefono Fijo -->
    <div class="form-group">
        <label for="telfijo" class="col-sm-12 col-md-2 control-label">
            Teléfono Fijo</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtTelefono" runat="server" CssClass="form-control" placeholder="Teléfono Fijo"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="TxtTelefono"
                ValidChars=" -()" FilterType="Custom, Numbers">
            </cc1:FilteredTextBoxExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtTelefono"
                Display="None" ErrorMessage="Por favor ingrese su telefono fijo." Style="display: inline;"
                ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
        </div>
    </div>
    <!-- Teléfono Celular -->
    <div class="form-group">
        <label for="telmovil" class="col-sm-12 col-md-2 control-label">
            Teléfono Celular</label>
        <div class="col-sm-12 col-md-10">
            <asp:TextBox ID="TxtCelular" runat="server" CssClass="form-control" placeholder="Teléfono Celular"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="TxtCelular"
                ValidChars=" -()" FilterType="Custom, Numbers">
            </cc1:FilteredTextBoxExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtCelular"
                Display="None" ErrorMessage="Por favor ingrese el celular." Style="display: inline;"
                ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
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
        ValidationGroup="Insertar" />
</asp:Content>
