<%@ Page Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true" CodeFile="MensajePorteria.aspx.cs" Inherits="Privado_MensajePorteria" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">Mensaje Porteria</h1>
    <form>
        <!-- Asunto -->
        <fieldset class="form-group">
            <label for="asunto" class="col-sm-12 col-md-2 control-label">
                Asunto</label>
            <div class="col-sm-12 col-md-10">
                <asp:TextBox ID="TxtAsunto" runat="server" CssClass="form-control" placeholder="Asunto"></asp:TextBox>
            </div>
        </fieldset>
        <fieldset class="form-group">
            <label for="exampleInputPassword1" class="col-sm-12 col-md-2 control-label">Categoría</label>
            <div class="col-sm-12 col-md-10">
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control" ValidationGroup="DatosPaso1">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategoria"
                    Display="None" ErrorMessage="Por favor seleccione categoría" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
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
