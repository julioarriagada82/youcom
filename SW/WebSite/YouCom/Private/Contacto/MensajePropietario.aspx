<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true" CodeFile="MensajePropietario.aspx.cs" Inherits="Privado_Contacto_MensajePropietario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">Mensaje Administración</h1>
    <form>
        <!-- Asunto -->
        <fieldset class="form-group">
            <label for="asunto" class="col-sm-12 col-md-2 control-label">
                Asunto</label>
            <div class="col-sm-12 col-md-10">
                <asp:TextBox ID="TxtAsunto" runat="server" CssClass="form-control" placeholder="Asunto"></asp:TextBox>
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
