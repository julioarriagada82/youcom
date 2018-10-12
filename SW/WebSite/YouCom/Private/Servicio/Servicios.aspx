<%@ Page Language="C#" MasterPageFile="~/App_Master/MPDosColumnas.master" AutoEventWireup="true" CodeFile="Servicios.aspx.cs" Inherits="Privado_Servicios" Title="Untitled Page" %>

<%@ Register Src="../../App_Master/Controls/wucCategoria.ascx" TagName="wucCategoria" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc1:wucCategoria ID="wucCategoria1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:MultiView ID="mvwServicio" runat="server">
        <asp:View ID="View1" runat="server">
            <h1 class="page-header">Servicios</h1>
            <div class="btn-toolbar" role="toolbar">
                <asp:LinkButton ID="BntAgregar" runat="server" CssClass="btn btn-default btn-lg pull-left" Text="Agregar Servicio" ValidationGroup="DatosPaso1" OnClick="BntAgregar_Click" />
            </div>
            <div class="row">
                <asp:Repeater ID="rptServicio" runat="server" OnItemDataBound="rptServicio_ItemDataBound" OnItemCommand="rptServicio_ItemCommand">
                    <ItemTemplate>
                        <div class="media" id="div_contenedor" runat="server">
                            <br />
                            <a class="pull-left" href="#">
                                <asp:Image ID="imgServicio" CssClass="img-responsive" Width="300px" Height="200px" runat="server" />
                            </a>
                            <div class="media-body">
                                <h4 class="media-heading">
                                    <%# DataBinder.Eval(Container.DataItem, "NombreServicio")%>
                                </h4>
                                <p style="width:250px;">
                                    <asp:Literal ID="LitServicioDescripcion" runat="server"></asp:Literal>
                                    <asp:LinkButton ID="LnkBtnVerMas" runat="server" Text="Ver más" CommandName="VerDescripcion" Visible="false"></asp:LinkButton>
                                    <asp:HiddenField ID="hdnIdServicio" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdServicio")%>' />
                                </p>
                                <div class="btn-toolbar" role="toolbar">
                                    <asp:RadioButtonList ID="rdblNotas" runat="server" RepeatDirection="Horizontal" CssClass="starr">
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:LinkButton ID="LnkBtnVer" CausesValidation="false" runat="server" CssClass="btn btn-default btn-sm"
                                        CommandName="VerComentarios"></asp:LinkButton>
                                </div>
                            </div>
                            <asp:Panel ID="pnlComentarios" runat="server" Visible="false">
                                <div class="btn-toolbar" role="toolbar">
                                    <asp:LinkButton ID="LnkBtnAgregarComentario" CausesValidation="false" runat="server" CssClass="btn btn-default btn-sm"
                                        CommandName="AgregarComentario"></asp:LinkButton>
                                </div>
                                <asp:Panel ID="pnlComentar" runat="server" CssClass="well" Visible="false">
                                    <hr />
                                    <h4>Ingrese Comentario:
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                                </div>
                                        <asp:Button ID="btnEnviarComentario" runat="server" CssClass="btn btn-primary" Text="Enviar" CommandName="EnviarComentario" />
                                    </h4>
                                </asp:Panel>
                                <asp:Panel ID="pnlResultado" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable">
                                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                                    <asp:Literal ID="litMensaje" runat="server"></asp:Literal>
                                </asp:Panel>
                                <asp:Repeater ID="rptComentarios" runat="server">
                                    <HeaderTemplate>
                                        <div>
                                            <h2>Comentarios</h2>
                                            <table width="100%">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="media">
                                            <a class="pull-left" href="#">
                                                <img class="media-object" src="http://placehold.it/64x64" alt />
                                            </a>
                                            <div class="media-body">
                                                <h4 class="media-heading">
                                                    <asp:Literal ID="LitNombreConsultante" runat="server"></asp:Literal>
                                                </h4>
                                                <%# DataBinder.Eval(Container.DataItem, "ComentarioAviso")%>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table> </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="col-lg-8">
                <h1 class="page-header">Agregar Servicio</h1>
                <form>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Nombre</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:TextBox ID="txtServicioNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtServicioNombre"
                                Display="None" ErrorMessage="Por favor ingrese nombre" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Descripción</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:TextBox ID="txtServicioDescripcion" runat="server" CssClass="form-control" placeholder="Descripción"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtServicioDescripcion"
                                Display="None" ErrorMessage="Por favor ingrese descripción" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Fecha Inicio</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:TextBox ID="FechaInicio" runat="server" CssClass="form-control" Columns="10"
                                Width="60px"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="FechaInicio"
                                Format="dd/MM/yyyy" TargetControlID="FechaInicio" />
                            <cc1:MaskedEditExtender ID="FechaInicio_MaskedEditExtender" runat="server" Mask="99/99/9999"
                                MaskType="Date" TargetControlID="FechaInicio" CultureName="es-ES">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="FechaInicio_MaskedEditExtender"
                                ControlToValidate="FechaInicio" Display="None" EmptyValueMessage="Fecha Inicio"
                                ErrorMessage="Fecha Publicación no válida." InvalidValueMessage="Fecha Inicio no válida."
                                IsValidEmpty="False" SetFocusOnError="True">*
                            </cc1:MaskedEditValidator>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Fecha Termino</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:TextBox ID="FechaTermino" runat="server" CssClass="form-control" Columns="10"
                                Width="60px"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="FechaTermino"
                                Format="dd/MM/yyyy" TargetControlID="FechaTermino" />
                            <cc1:MaskedEditExtender ID="FechaTermino_MaskedEditExtender" runat="server" Mask="99/99/9999"
                                MaskType="Date" TargetControlID="FechaTermino" CultureName="es-ES">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="FechaTermino_MaskedEditExtender"
                                ControlToValidate="FechaTermino" Display="None" EmptyValueMessage="Fecha Termino"
                                ErrorMessage="Fecha Termino no válida." InvalidValueMessage="Fecha Termino no válida."
                                IsValidEmpty="False" SetFocusOnError="True">*
                            </cc1:MaskedEditValidator>
                        </div>
                    </fieldset>
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
                        <label for="telmovil" class="col-sm-12 col-md-2 control-label">
                            Quien entrega el servicio</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:RadioButtonList ID="RblServicio" runat="server" OnSelectedIndexChanged="RblServicio_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Empresa" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Particular" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="email" class="col-sm-12 col-md-2 control-label">
                            Rut</label>
                        <div class="col-sm-12 col-md-10">
                            <asp:TextBox ID="txtRutEmpresa" runat="server" TextMode="SingleLine" MaxLength="200" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtRutEmpresa_TextChanged" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRutEmpresa"
                                Display="None" ErrorMessage="Por favor ingrese nombre" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                        </div>
                    </fieldset>
                    <asp:Panel ID="pnlDatosContratista" runat="server" Visible="false">
                        <fieldset class="form-group">
                            <label for="email" class="col-sm-12 col-md-2 control-label">
                                <asp:Literal ID="LitTituloNombre" runat="server"></asp:Literal></label>
                            <div class="col-sm-12 col-md-10">
                                <asp:TextBox ID="txtNombreEmpresa" runat="server" TextMode="SingleLine" MaxLength="200" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombreEmpresa"
                                    Display="None" ErrorMessage="Por favor ingrese descripción" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            </div>
                        </fieldset>
                        <asp:Panel ID="pnlEmpresaServicio" runat="server" Visible="false">
                            <fieldset class="form-group">
                                <label for="telmovil" class="col-sm-12 col-md-2 control-label">
                                    Giro</label>
                                <div class="col-sm-12 col-md-10">
                                    <asp:DropDownList runat="server" ID="ddlGiro" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlGiro"
                                        Display="None" ErrorMessage="Por favor seleccione Giro" Style="display: inline;"
                                        ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                                </div>
                            </fieldset>
                        </asp:Panel>
                        <fieldset class="form-group">
                            <label for="email" class="col-sm-12 col-md-2 control-label">
                                Dirección</label>
                            <div class="col-sm-12 col-md-10">
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Dirección"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDireccion"
                                    Display="None" ErrorMessage="Por favor ingrese descripción" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            </div>
                        </fieldset>
                        <fieldset class="form-group">
                            <label for="telmovil" class="col-sm-12 col-md-2 control-label">
                                País</label>
                            <div class="col-sm-12 col-md-10">
                                <asp:DropDownList runat="server" ID="ddlPais" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlPais"
                                    Display="None" ErrorMessage="Por favor seleccione País." Style="display: inline;"
                                    ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            </div>
                        </fieldset>
                        <fieldset class="form-group">
                            <label for="telmovil" class="col-sm-12 col-md-2 control-label">
                                Región</label>
                            <div class="col-sm-12 col-md-10">
                                <asp:DropDownList runat="server" ID="ddlRegion" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlRegion"
                                    Display="None" ErrorMessage="Por favor seleccione región." Style="display: inline;"
                                    ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            </div>
                        </fieldset>
                        <fieldset class="form-group">
                            <label for="telmovil" class="col-sm-12 col-md-2 control-label">
                                Ciudad</label>
                            <div class="col-sm-12 col-md-10">
                                <asp:DropDownList runat="server" ID="ddlCiudad" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlCiudad"
                                    Display="None" ErrorMessage="Por favor seleccione ciudad." Style="display: inline;"
                                    ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            </div>
                        </fieldset>
                        <fieldset class="form-group">
                            <label for="telmovil" class="col-sm-12 col-md-2 control-label">
                                Comuna</label>
                            <div class="col-sm-12 col-md-10">
                                <asp:DropDownList runat="server" ID="ddlComuna" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlComuna"
                                    Display="None" ErrorMessage="Por favor seleccione comuna." Style="display: inline;"
                                    ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            </div>
                        </fieldset>
                        <fieldset class="form-group">
                            <label for="email" class="col-sm-12 col-md-2 control-label">
                                Teléfono</label>
                            <div class="col-sm-12 col-md-10">
                                <asp:DropDownList runat="server" ID="ddlAnexoTelefono">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlAnexoTelefono"
                                    Display="None" ErrorMessage="El anexo de teléfono es Obligatorio.">*</asp:RequiredFieldValidator>
                                -
                            <asp:TextBox runat="server" ID="txtTelefono" TextMode="SingleLine" MaxLength="30"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers"
                                    TargetControlID="txtTelefono">
                                </cc1:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtTelefono"
                                    Display="None" ErrorMessage="Teléfono es campo Obligatorio."></asp:RequiredFieldValidator>
                            </div>
                        </fieldset>
                        <fieldset class="form-group">
                            <label for="email" class="col-sm-12 col-md-2 control-label">
                                Celular</label>
                            <div class="col-sm-12 col-md-10">
                                <asp:DropDownList runat="server" ID="ddlAnexoCelular">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlAnexoCelular"
                                    Display="None" ErrorMessage="El anexo de celular es Obligatorio.">*</asp:RequiredFieldValidator>
                                -
                            <asp:TextBox runat="server" ID="txtCelular" TextMode="SingleLine" MaxLength="30"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers"
                                    TargetControlID="txtCelular">
                                </cc1:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtCelular"
                                    Display="None" ErrorMessage="Celular es campo Obligatorio."></asp:RequiredFieldValidator>
                            </div>
                        </fieldset>
                        <fieldset class="form-group">
                            <label for="email" class="col-sm-12 col-md-2 control-label">
                                E-Mail</label>
                            <div class="col-sm-12 col-md-10">
                                <asp:TextBox runat="server" ID="txtEmail" Width="210px" MaxLength="30"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                                    TargetControlID="txtEmail" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!~@">
                                </cc1:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtEmail"
                                    Display="None" ErrorMessage="Email es campo Obligatorio."></asp:RequiredFieldValidator>
                            </div>
                        </fieldset>
                        <fieldset class="form-group">
                            <label for="email" class="col-sm-12 col-md-2 control-label">
                                URL</label>
                            <div class="col-sm-12 col-md-10">
                                <asp:TextBox ID="txtURL" runat="server" TextMode="SingleLine"
                                    MaxLength="200" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtURL"
                                    Display="None" ErrorMessage="Ingrese URL por favor" />
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtURL"
                                    ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!áéíóúñÑ<>" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters">
                                </cc1:FilteredTextBoxExtender>
                            </div>
                        </fieldset>
                        <fieldset class="form-group">
                            <label for="email" class="col-sm-12 col-md-2 control-label">
                                Imagen</label>
                            <div class="col-sm-12 col-md-10">
                                <asp:FileUpload ID="FileImagenServicio" AllowMultiple="true" CssClass="form-control-file" runat="server" TabIndex="2" /><br />
                                (200px - 100px)&nbsp; Peso Máximo
                            <%=GetMaxUploadMessage()%>
                                <asp:HyperLink ID="lnkImagenServicio" runat="server" Visible="false" CssClass="fancybox"
                                    ToolTip="Ver imagen">
                                    <asp:Image ID="imgImagenServicio" runat="server" AlternateText="Imagen" ToolTip="Ver imagen"
                                        ImageUrl="~/images/iconos/ico_camara.gif" Width="20px" Height="20px" />
                                </asp:HyperLink>
                                <asp:CheckBox ID="chkImagenServicio" runat="server" Visible="false" CssClass="radiobutton"
                                    Text="Eliminar imagen" />
                                <asp:CustomValidator ID="CVImagen" ValidationGroup="formulario" runat="server" ErrorMessage="El archivo sólo puede ser de tipo imagen y flash"
                                    ControlToValidate="FileImagenAviso" Display="None" ClientValidationFunction="isImageFlash" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo los archivos jpg, gif, bmp ó png están permitidos"
                                    ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([bB][mM][pP])|([pP][nN][gG])|([wW][mM][fF])|([sS][wW][fF]))$"
                                    ControlToValidate="FileImagenAviso"></asp:RegularExpressionValidator>
                            </div>
                        </fieldset>
                    </asp:Panel>
                    <asp:Button ID="BtnEnviar" runat="server" CssClass="btn btn-primary" Text="Publicar Aviso" ValidationGroup="DatosPaso1" OnClick="BtnEnviar_Click" />
                    <asp:Button ID="BtnVolver" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Volver" OnClick="BtnVolver_Click" />

                </form>
            </div>
        </asp:View>
    </asp:MultiView>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
