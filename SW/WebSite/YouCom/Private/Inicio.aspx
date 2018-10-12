<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Mensajes.master" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Inicio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:MultiView ID="mvwMensaje" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:UpdatePanel ID="updPanel" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlNotificaciones" runat="server" CssClass="list-group" Visible="false">
                        <asp:Repeater ID="rptNotificaciones" OnItemDataBound="rptNotificaciones_ItemDataBound" OnItemCommand="rptNotificaciones_ItemCommand" runat="server">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkBtnDetalle" runat="server" CommandName="VerDetalle" CssClass="list-group-item"></asp:LinkButton>
                                <asp:HiddenField ID="hdnIdMensaje" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TheMensajeDTO.IdMensaje")%>' />
                                <asp:HiddenField ID="hdnQuienEnvia" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TheMensajeTipoDTO.NombreMensajeTipo")%>' />
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                    <asp:Panel ID="pnlBuscador" runat="server" CssClass="thumbnail" Visible="false">
                        <h3 class="page-header">Buscador</h3>
                        <form>
                            <fieldset class="form-group">
                                <label for="exampleInputPassword1">Filtro</label>
                                <div class="radio">
                                    <asp:RadioButtonList ID="rdbListFiltros" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbListFiltros_SelectedIndexChanged">
                                        <asp:ListItem Text="Categoria" Value="C"></asp:ListItem>
                                        <asp:ListItem Text="Usuario" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="Titulo" Value="T"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </fieldset>
                            <fieldset class="form-group" id="form_categoria" runat="server" visible="false">
                                <label for="exampleInputPassword1">Categoría</label>
                                <asp:DropDownList ID="ddlBuscadorCategoria" runat="server" CssClass="form-control" ValidationGroup="DatosPaso1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCategoria"
                                    Display="None" ErrorMessage="Por favor seleccione categoría" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                            </fieldset>
                            <fieldset class="form-group" id="form_usuario" runat="server" visible="false">
                                <label for="exampleInputPassword1">Usuario</label>
                                <asp:TextBox ID="TxtUsuarioBusqueda" runat="server" CssClass="form-control" placeholder="Usuario..."></asp:TextBox>
                            </fieldset>
                            <fieldset class="form-group" id="form_titulo" runat="server" visible="false">
                                <label for="exampleInputPassword1">Titulo</label>
                                <asp:TextBox ID="TxtTituloBusqueda" runat="server" CssClass="form-control" placeholder="Titulo..."></asp:TextBox>
                            </fieldset>
                            <asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" ValidationGroup="DatosPaso1" OnClick="BtnBuscar_Click" />
                            <asp:Button ID="BtnCerrar" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Volver" OnClick="BtnVolver_Click" />
                        </form>
                    </asp:Panel>
                    <asp:Panel ID="pnlCarrusel" runat="server">
                        <div id="myCarousel" class="carousel slide" data-ride="carousel">
                            <!-- Indicators -->
                            <asp:Repeater ID="rptIndicadorCarrusel" OnItemDataBound="rptIndicadorCarrusel_ItemDataBound" runat="server">
                                <HeaderTemplate>
                                    <ol class="carousel-indicators">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li id="li_mensaje" runat="server" data-target="#myCarousel" data-slide-to='<%# Container.ItemIndex%>'></li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ol>
                                </FooterTemplate>
                            </asp:Repeater>
                            <!-- Wrapper for slides -->

                            <asp:Repeater ID="rptMensajesInternos" OnItemDataBound="rptMensajesInternos_ItemDataBound" OnItemCommand="rptMensajesInternos_ItemCommand" runat="server">
                                <HeaderTemplate>
                                    <div class="carousel-inner" role="listbox">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div id="div_mensaje" runat="server">
                                        <%--<img src="http://placehold.it/900x500" alt="Chania">--%>
                                        <asp:ImageButton ID="imgMensaje" CssClass="img-responsive" Width="900px" Height="500px" runat="server" CommandName="Detalle" />
                                        <div class="carousel-caption">
                                            <h3><%# DataBinder.Eval(Container.DataItem, "MensajeTitulo")%></h3>
                                            <p><%# DataBinder.Eval(Container.DataItem, "MensajeDescripcion")%></p>
                                            <asp:HiddenField ID="hdnIdMensaje" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdMensaje")%>' />
                                            <asp:HiddenField ID="hdnQuienEnvia" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TheMensajeTipoDTO.NombreMensajeTipo")%>' />
                                        </div>
                                        <asp:LinkButton ID="lnkBtnVerTodos" runat="server" CssClass="btn btn-default btn-sm center-block" CommandName="VerTodos" Text="Ver Todos>>"></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                            <!-- Left and right controls -->
                            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                    </asp:Panel>
                    <asp:Repeater ID="rptMensajes" OnItemDataBound="rptMensajes_ItemDataBound" OnItemCommand="rptMensajes_ItemCommand" runat="server">
                        <ItemTemplate>
                            <div class="media" id="div_contenedor" runat="server">
                                <br />
                                <asp:Image ID="imgCategoria" CssClass="img-responsive" runat="server" />
                                <a class="pull-left" href="#">
                                    <asp:Image ID="imgMensaje" CssClass="img-responsive" Width="172px" Height="168px" runat="server" />
                                </a>
                                <div class="media-body">
                                    <p>
                                        <span class="glyphicon glyphicon-time"></span>
                                        <small>
                                            <asp:Literal ID="LitTiempo" runat="server"></asp:Literal></small>
                                    </p>
                                    <h4 class="media-heading">
                                        <%# DataBinder.Eval(Container.DataItem, "MensajeTitulo")%>
                                    </h4>
                                    <p>
                                        <small>
                                            <asp:Literal ID="LitQuienEnvia" runat="server"></asp:Literal></small>
                                    </p>
                                    <p>
                                        <asp:Literal ID="LitMensajeDescripcion" runat="server"></asp:Literal>
                                        <asp:LinkButton ID="LnkBtnVerMas" runat="server" Text="Ver más" CommandName="VerDescripcion" Visible="false"></asp:LinkButton>
                                    </p>
                                    <p>
                                        <span class="glyphicon glyphicon-time"></span>
                                        <small>
                                            <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "MensajeFecha")).ToShortDateString()%>
                                            <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "MensajeFecha")).ToShortTimeString()%>
                                            <asp:HiddenField ID="hdnIdMensaje" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdMensaje")%>' />
                                            <asp:HiddenField ID="hdnQuienEnvia" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TheMensajeTipoDTO.NombreMensajeTipo")%>' />
                                        </small>
                                    </p>
                                    <div class="btn-toolbar" role="toolbar">
                                        <asp:LinkButton ID="LnkBtnMeGusta" CausesValidation="false" runat="server" CssClass="btn btn-default btn-sm"
                                            CommandName="MeGusta"><span class="glyphicon glyphicon-thumbs-up"></span></asp:LinkButton>
                                        <asp:LinkButton ID="LnkBtnNoMeGusta" CausesValidation="false" runat="server" CssClass="btn btn-default btn-sm"
                                            CommandName="NoMeGusta"><span class="glyphicon glyphicon-thumbs-down"></span></asp:LinkButton>
                                        <asp:LinkButton ID="LnkBtnVer" CausesValidation="false" runat="server" CssClass="btn btn-default btn-sm"
                                            CommandName="VerComentarios"></asp:LinkButton>
                                    </div>
                                    <asp:Panel ID="pnlGaleriaImagenes" runat="server" CssClass="row" Visible="false">
                                        <asp:Repeater ID="rptGaleriaImagenes" OnItemDataBound="rptGaleriaImagenes_ItemDataBound" runat="server">
                                            <ItemTemplate>
                                                <div class="col-sm-6 col-md-3">
                                                    <a href="#" class="thumbnail">
                                                        <asp:Image ID="imgMensaje" CssClass="img-responsive" Width="100px" Height="100px" runat="server" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </asp:Panel>

                                    <asp:Panel ID="pnlGaleriaVideos" runat="server" CssClass="row" Visible="false">
                                        <asp:Repeater ID="rptGaleriaVideos" runat="server">
                                            <ItemTemplate>
                                                <object width="250" height="100">
                                                    <param name="movie" value="<%#DataBinder.Eval(Container.DataItem, "UrlWatchVideoMensajePropietario") %>"></param>
                                                    <param name="allowFullScreen" value="true"></param>
                                                    <param name="allowscriptaccess" value="always"></param>
                                                    <embed src="<%#DataBinder.Eval(Container.DataItem, "UrlWatchVideoMensajePropietario") %>" type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" width="250" height="100">
                                                    </embed>
                                                </object>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </asp:Panel>
                                    <br />
                                </div>
                                <asp:Panel ID="pnlMensajes" runat="server" Visible="false">
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
                                    <asp:Repeater ID="rptRespuestas" OnItemDataBound="rptRespuestas_ItemDataBound" runat="server">
                                        <ItemTemplate>
                                            <div class="media">
                                                <a class="pull-left" href="#">
                                                    <img class="media-object" src="http://placehold.it/64x64" alt />
                                                </a>
                                                <div class="media-body">
                                                    <h4 class="media-heading">
                                                        <asp:Literal ID="LitQuienEnvia" runat="server"></asp:Literal>
                                                        <small><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "MensajeFecha")).ToLongDateString()%> <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "MensajeFecha")).ToShortTimeString()%> </small>
                                                    </h4>
                                                    <%# DataBinder.Eval(Container.DataItem, "MensajeDescripcion")%>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </asp:Panel>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="col-lg-8">
                <h1 class="page-header">Publicar Mensaje</h1>
                <form>
                    <fieldset class="form-group">
                        <label for="exampleInputPassword1">Asunto</label>
                        <asp:TextBox ID="TxtAsunto" runat="server" CssClass="form-control" placeholder="Asunto" ValidationGroup="DatosPaso1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtAsunto"
                            Display="None" ErrorMessage="Por favor ingrese asunto" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="exampleInputPassword1">Categoría</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control" ValidationGroup="DatosPaso1">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategoria"
                            Display="None" ErrorMessage="Por favor seleccione categoría" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                    </fieldset>
                    <fieldset class="form-group" id="form_imagen" visible="true" runat="server">
                        <label for="exampleInputFile">Imagen</label>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:FileUpload ID="FileImagenMensaje" AllowMultiple="true" CssClass="form-control-file" runat="server" TabIndex="2" ValidationGroup="DatosPaso1" />
                                <small>(200px - 100px)&nbsp; Peso Máximo <%=GetMaxUploadMessage()%></small>
                                <asp:HyperLink ID="lnkImagen" runat="server" Visible="false" CssClass="fancybox"
                                    ToolTip="Ver imagen">
                                    <asp:Image ID="imgImagen" runat="server" AlternateText="Imagen" ToolTip="Ver imagen"
                                        ImageUrl="~/images/iconos/ico_camara.gif" Width="20px" Height="20px" />
                                </asp:HyperLink>
                                <asp:CheckBox ID="chkImagen" runat="server" Visible="false" CssClass="radiobutton"
                                    Text="Eliminar imagen" />
                                <asp:CustomValidator ID="CVImagen" ValidationGroup="formulario" runat="server" ErrorMessage="El archivo sólo puede ser de tipo imagen"
                                    ControlToValidate="FileImagenMensaje" Display="None" ClientValidationFunction="isImage" />
                                <asp:RegularExpressionValidator ID="REVUpload" runat="server" ErrorMessage="Solo los archivos jpg, gif, bmp ó png están permitidos"
                                    ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([bB][mM][pP])|([pP][nN][gG]))$"
                                    ControlToValidate="FileImagenMensaje" ValidationGroup="DatosPaso1"></asp:RegularExpressionValidator>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="BtnPublicarMensaje" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </fieldset>
                    <fieldset class="form-group" id="form_video" visible="true" runat="server">
                        <label for="exampleInputFile">Video</label>
                        <div class="table-responsive">
                            <table class="table">
                                <tbody>
                                    <asp:Repeater ID="rptVideosYoutube" OnItemDataBound="rptVideosYoutube_ItemDataBound" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="success">
                                                    <asp:TextBox ID="TxtUrl" runat="server" CssClass="form-control" placeholder="Url Youtube..."></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                        runat="server" ErrorMessage="Url video youtube invalida" ControlToValidate="TxtUrl"
                                                        ValidationExpression="^(?:https?\:\/\/)?(?:www\.)?(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\/|watch\?v\=))([\w-]{10,12})(?:$|\&|\?\#).*" />
                                                </td>
                                                <td class="success">
                                                    <asp:TextBox ID="TxtTitulo" runat="server" CssClass="form-control" placeholder="Titulo Video..."></asp:TextBox></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr>
                                        <td>
                                            <asp:Button ID="BtnAgregarVideo" CausesValidation="false" runat="server" Text="Agregar Video +" CssClass="btn btn-default btn-sm" OnClick="BtnAgregarVideo_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </fieldset>
                    <fieldset class="form-group">
                        <label for="exampleInputPassword1">Comentarios</label>
                        <asp:TextBox ID="TxtComentarios" runat="server" Rows="5" onkeyDown="checkTextAreaMaxLength(this,event,'2000');" CssClass="form-control"
                            TextMode="MultiLine" placeholder="Sus comentarios..."></asp:TextBox>
                    </fieldset>
                    <asp:Button ID="BtnPublicarMensaje" runat="server" CssClass="btn btn-primary" Text="Publicar" ValidationGroup="DatosPaso1" OnClick="BtnPublicarMensaje_Click" />
                    <asp:Button ID="BtnVolver" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Volver" OnClick="BtnVolver_Click" />
                </form>
            </div>
        </asp:View>
    </asp:MultiView>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-md-4">
        <div class="well">
            <h4><span class="glyphicon glyphicon-usd"></span>Gastos Comunes Pendientes</h4>
            <h1><span>
                <asp:Literal ID="litMontoPendiente" runat="server"></asp:Literal></span></h1>
            <p>
                Vencimiento:
                <asp:Literal ID="litFechaVencimiento" runat="server"></asp:Literal>
            </p>
        </div>
        <div class="thumbnail">
            <h4><span class="glyphicon glyphicon-minus-sign"></span>Ultimos ingresos</h4>
            <asp:Repeater ID="rptAutorizaciones" runat="server" OnItemDataBound="rptAutorizaciones_ItemDataBound" OnItemCommand="rptAutorizaciones_ItemCommand">
                <HeaderTemplate>
                    <div class="table-responsive">
                        <table class="table">
                            <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="success"><%# DataBinder.Eval(Container.DataItem, "NombreVisita")%></td>
                        <td class="success"><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaInicio")).ToShortDateString()%> <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaInicio")).ToShortTimeString()%></td>
                        <td class="success">
                            <asp:LinkButton ID="LnkBtnDetalle" runat="server" CommandName="Detalle">
                                                        <span class="glyphicon glyphicon-eye-open"></span>
                            </asp:LinkButton>
                        </td>
                        <asp:HiddenField ID="HdnIdAccesoHogar" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdAccesoHogar")%>' />
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="thumbnail">
            <h4><span class="glyphicon glyphicon-lock"></span>Servicios</h4>
            <asp:Repeater ID="rptServicio" runat="server" OnItemDataBound="rptServicio_ItemDataBound" OnItemCommand="rptServicio_ItemCommand">
                <HeaderTemplate>
                    <div class="table-responsive">
                        <table class="table">
                            <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="success">
                            <asp:Image ID="imgLogo" CssClass="img-responsive" runat="server" />
                            <asp:HiddenField ID="HidIdServicio" Value='<%# DataBinder.Eval(Container.DataItem, "IdServicio")%>'
                                runat="server"></asp:HiddenField>
                        </td>
                        <td class="success"><%# DataBinder.Eval(Container.DataItem, "NombreServicio")%></td>
                        <td class="success"><%# DataBinder.Eval(Container.DataItem, "TheCategoriaDTO.NombreCategoria")%></td>
                        <td class="success">
                            <asp:LinkButton ID="LnkBtnDetalle" runat="server" CommandName="Detalle">
                                <span class="glyphicon glyphicon-eye-open"></span>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
            </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="thumbnail">
            <h4><span class="glyphicon glyphicon-lock"></span>MiCom Mercado</h4>
            <asp:Repeater ID="rptAviso" runat="server" OnItemDataBound="rptAviso_ItemDataBound" OnItemCommand="rptAviso_ItemCommand">
                <HeaderTemplate>
                    <div class="table-responsive">
                        <table class="table">
                            <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="success">
                            <asp:Image ID="imgLogo" CssClass="img-responsive" runat="server" />
                            <asp:HiddenField ID="HidIdAviso" Value='<%# DataBinder.Eval(Container.DataItem, "IdAviso")%>'
                                runat="server"></asp:HiddenField>
                        </td>
                        <td class="success"><%# DataBinder.Eval(Container.DataItem, "TituloAviso")%></td>
                        <td class="success"><%# YouCom.Service.Generales.Formato.FormatoMontoPesoSinReplace(DataBinder.Eval(Container.DataItem, "PrecioAviso").ToString(), true)%></td>
                        <td class="success">
                            <asp:LinkButton ID="LnkBtnDetalle" runat="server" CommandName="Detalle">
                                                        <span class="glyphicon glyphicon-eye-open"></span>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
            </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="thumbnail">
            <h2><span class="glyphicon glyphicon-envelope"></span>CONTACTOS</h2>
            <asp:Repeater ID="rptContacto" runat="server" OnItemCommand="rptContacto_ItemCommand">
                <HeaderTemplate>
                    <div class="caption">
                </HeaderTemplate>
                <ItemTemplate>
                    <h4>
                        <asp:HiddenField ID="hdnIdDirectiva" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdDirectiva")%>' />
                    <asp:LinkButton ID="LnkBtnMensaje" runat="server" CommandName="EnviarMensaje"><span class="glyphicon glyphicon-comment"></span>Enviar Mensaje <%# DataBinder.Eval(Container.DataItem, "NombreCompleto")%></asp:LinkButton></h4>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="DatosPaso1" />
</asp:Content>
