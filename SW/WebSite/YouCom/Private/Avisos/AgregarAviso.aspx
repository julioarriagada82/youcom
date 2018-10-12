<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true" CodeFile="AgregarAviso.aspx.cs" Inherits="Privado_Avisos_AgregarAviso" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-8">
        <h1 class="page-header">Agregar Aviso</h1>
        <form>
            <!-- Nombre -->
            <fieldset class="form-group">
                <label for="telmovil" class="col-sm-12 col-md-2 control-label">
                    Categoria</label>
                <div class="col-sm-12 col-md-10">
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCategoria"
                        Display="None" ErrorMessage="Por favor seleccione Categoria." Style="display: inline;"
                        ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <label for="email" class="col-sm-12 col-md-2 control-label">
                    Tipo Aviso</label>
                <div class="col-sm-12 col-md-10">
                    <asp:DropDownList runat="server" ID="ddlTipoAviso" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlTipoAviso"
                        Display="None" ErrorMessage="Por favor seleccione tipo de aviso" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <label for="email" class="col-sm-12 col-md-2 control-label">
                    Precio</label>
                <div class="col-sm-12 col-md-10">
                    <asp:TextBox ID="TxtPrecio" runat="server" CssClass="form-control" placeholder="Precio"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtPrecio"
                        Display="None" ErrorMessage="Por favor ingrese un precio" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <label for="email" class="col-sm-12 col-md-2 control-label">
                    Imagen Principal</label>
                <div class="col-sm-12 col-md-10">
                    <asp:FileUpload ID="FileImagenPrincipalAviso" CssClass="form-control-file" runat="server" TabIndex="2" /><br />
                    (200px - 100px)&nbsp; Peso Máximo
                <%=GetMaxUploadMessage()%>
                    <asp:HyperLink ID="lnkImagenAvisoPrincipal" runat="server" Visible="false" CssClass="fancybox"
                        ToolTip="Ver imagen">
                        <asp:Image ID="imgImagenAvisoPrincipal" runat="server" AlternateText="Imagen" ToolTip="Ver imagen"
                            ImageUrl="~/images/iconos/ico_camara.gif" Width="20px" Height="20px" />
                    </asp:HyperLink>
                    <asp:CheckBox ID="chkImagenAvisoPrincipal" runat="server" Visible="false" CssClass="radiobutton"
                        Text="Eliminar imagen" />
                    <asp:CustomValidator ID="CVImagenAvisoPrincipal" ValidationGroup="formulario" runat="server" ErrorMessage="El archivo sólo puede ser de tipo imagen y flash"
                        ControlToValidate="FileImagenPrincipalAviso" Display="None" ClientValidationFunction="isImageFlash" />
                    <asp:RegularExpressionValidator ID="REVUpload" runat="server" ErrorMessage="Solo los archivos jpg, gif, bmp ó png están permitidos"
                        ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([bB][mM][pP])|([pP][nN][gG])|([wW][mM][fF])|([sS][wW][fF]))$"
                        ControlToValidate="FileImagenPrincipalAviso"></asp:RegularExpressionValidator>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <label for="email" class="col-sm-12 col-md-2 control-label">
                    Imagen</label>
                <div class="col-sm-12 col-md-10">
                    <asp:FileUpload ID="FileImagenAviso" AllowMultiple="true" CssClass="form-control-file"  runat="server" TabIndex="2" /><br />
                    (200px - 100px)&nbsp; Peso Máximo
                <%=GetMaxUploadMessage()%>
                    <asp:HyperLink ID="lnkImagenAviso" runat="server" Visible="false" CssClass="fancybox"
                        ToolTip="Ver imagen">
                        <asp:Image ID="imgImagenAviso" runat="server" AlternateText="Imagen" ToolTip="Ver imagen"
                            ImageUrl="~/images/iconos/ico_camara.gif" Width="20px" Height="20px" />
                    </asp:HyperLink>
                    <asp:CheckBox ID="chkImagenAviso" runat="server" Visible="false" CssClass="radiobutton"
                        Text="Eliminar imagen" />
                    <asp:CustomValidator ID="CVImagen" ValidationGroup="formulario" runat="server" ErrorMessage="El archivo sólo puede ser de tipo imagen y flash"
                        ControlToValidate="FileImagenAviso" Display="None" ClientValidationFunction="isImageFlash" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo los archivos jpg, gif, bmp ó png están permitidos"
                        ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([bB][mM][pP])|([pP][nN][gG])|([wW][mM][fF])|([sS][wW][fF]))$"
                        ControlToValidate="FileImagenAviso"></asp:RegularExpressionValidator>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <label for="email" class="col-sm-12 col-md-2 control-label">
                    Titulo</label>
                <div class="col-sm-12 col-md-10">
                    <asp:TextBox ID="TxtTitulo" runat="server" CssClass="form-control" placeholder="Titulo Aviso"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtTitulo"
                        Display="None" ErrorMessage="Por favor ingrese un correo electrónico" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <label for="comentarios" class="col-sm-12 col-md-2 control-label">
                    Descripción</label>
                <div class="col-sm-12 col-md-10">
                    <asp:TextBox ID="TxtDescripcion" runat="server" Rows="3" CssClass="form-control"
                        TextMode="MultiLine" placeholder="Descripción aviso..."></asp:TextBox>
                </div>
            </fieldset>
            <asp:Button ID="BtnEnviar" runat="server" CssClass="btn btn-primary" Text="Publicar Aviso" ValidationGroup="DatosPaso1" OnClick="BtnEnviar_Click" />
            <asp:Button ID="BtnVolver" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Volver" />

        </form>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="DatosPaso1" />
</asp:Content>

