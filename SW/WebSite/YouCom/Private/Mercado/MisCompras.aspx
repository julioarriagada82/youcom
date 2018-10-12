<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true" CodeFile="MisCompras.aspx.cs" Inherits="Privado_Mercado_MisCompras" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:MultiView ID="mvwCompras" runat="server">
        <asp:View ID="View1" runat="server">
            <h1 class="page-header">Mis Compras</h1>
            <%--<div class="btn-toolbar" role="toolbar">
                <asp:LinkButton ID="BntAgregar" runat="server" CssClass="btn btn-default btn-lg pull-left" Text="Agregar Acceso" ValidationGroup="DatosPaso1" OnClick="BntAgregar_Click" />
            </div>--%>
            <div class="row">
                <asp:Repeater ID="rptCompras" runat="server" OnItemCommand="rptCompras_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Titulo Aviso
                                    </th>
                                    <th>Contacto
                                    </th>
                                    <th>Fecha Publicacion
                                    </th>
                                    <th>Fecha Compra
                                    </th>
                                    <th>Categoria
                                    </th>
                                    <th>Precio
                                    </th>
                                    <th>Detalle
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "TituloAviso").ToString()%>
                                <asp:HiddenField ID="HdnIdAviso" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdAviso")%>' />
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "TheFamiliaDTO.NombreCompleto")%>
                            </td>
                            <td>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaPublicacion")).ToShortDateString()%>
                            </td>
                            <td>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaCompra")).ToShortDateString()%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "TheCategoriaDTO.NombreCategoria")%>
                            </td>
                            <td>
                                <%# YouCom.Service.Generales.Formato.FormatoMontoPesoSinReplace(DataBinder.Eval(Container.DataItem, "PrecioAviso").ToString(), true)%>
                            </td>
                            <td>
                                <asp:LinkButton ID="LnkBtnDetalle" runat="server" CommandName="Detalle">
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
            <h1 class="page-header">Avisos</h1>
            <div class="col-lg">
                <div class="media-body">
                    <table class="table">
                        <tbody>
                            <tr>
                                <td class="success">
                                    <h4 class="media-heading">
                                        <asp:Literal ID="LitAvisoTitulo" runat="server"></asp:Literal>
                                    </h4>
                                    <small>Fecha Publicación:
                                        <asp:Literal ID="LitFechaPublicacion" runat="server"></asp:Literal></small>
                                </td>
                                <td class="success">
                                    <h2 class="media-heading">
                                        <span class="pull-right price">
                                            <asp:Literal ID="LitPrecio" runat="server"></asp:Literal>
                                        </span>
                                    </h2>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
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

                        <asp:Repeater ID="rptGaleriaAvisos" OnItemDataBound="rptGaleriaAvisos_ItemDataBound" runat="server">
                            <HeaderTemplate>
                                <div class="carousel-inner" role="listbox">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div id="div_mensaje" runat="server">
                                    <%--<img src="http://placehold.it/900x500" alt="Chania">--%>
                                    <asp:ImageButton ID="imgAviso" CssClass="img-responsive" Width="900px" Height="500px" runat="server" CommandName="Detalle" />
                                    <div class="carousel-caption">
                                        <asp:HiddenField ID="hdnIdImagenAviso" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdImagenAviso")%>' />
                                    </div>
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
                <div class="media-body">
                    <h2>Descripción:</h2>
                    <p>
                        <asp:Literal ID="LitAvisoDetalle" runat="server"></asp:Literal>
                        <asp:HiddenField ID="HdnIdAviso" runat="server"></asp:HiddenField>
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
                    <p>
                        Datos Contacto:
                        <asp:Literal ID="LitContacto" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="btn-toolbar" role="toolbar">
                    <asp:LinkButton ID="LnkBtnAgregarComentario" CausesValidation="false" Text="Contacta al anunciante" runat="server" CssClass="btn btn-default btn-sm"
                        OnClick="LnkBtnIngresaComentario_Click"></asp:LinkButton>
                    <asp:LinkButton ID="LnkBtnComprar" CausesValidation="false" Text="Comprar" runat="server" CssClass="btn btn-default btn-sm"
                        OnClick="LnkBtnComprar_Click"></asp:LinkButton>
                </div>
                <asp:Repeater ID="rptComentarios" runat="server" OnItemDataBound="rptComentarios_ItemDataBound">
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
                <asp:Panel ID="PnlComentar" runat="server" Visible="false">
                    <div class="well">
                        <hr />
                        <h2>Ingresa tus datos y tu consulta</h2>
                        <div class="left cf">
                            <p>
                                Complete los datos, y envíelo, el anunciante se pondra en contacto con usted a la
                            brevedad.
                            </p>
                            <form>
                                <fieldset class="form-group">
                                    <label for="nombre" class="left">
                                        <span>Nombre:</span></label>
                                    <div class="left back-field">
                                        <asp:Literal ID="LitNombre" runat="server"></asp:Literal>
                                    </div>
                                </fieldset>
                                <fieldset class="form-group">
                                    <label for="email" class="left">
                                        <span>Email:</span></label>
                                    <div class="left back-field">
                                        <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtEmail"
                                            Display="None" ErrorMessage="Por favor ingrese un correo electrónico" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="REVMail" runat="server" ControlToValidate="TxtEmail"
                                            Display="None" ErrorMessage="Por favor ingrese un correo electrónico valido."
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="DatosPaso1">*</asp:RegularExpressionValidator>
                                    </div>
                                </fieldset>
                                <fieldset class="form-group">
                                    <label for="comentarios" class="left">
                                        <span>Comentarios:</span></label>
                                    <div class="left back-textarea">
                                        <asp:TextBox ID="TxtComentarios" runat="server" Rows="5" onkeyDown="checkTextAreaMaxLength(this,event,'2000');" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </fieldset>
                                <asp:Button ID="BtnEnviar" runat="server" CssClass="btn btn-primary" Text="Enviar" ValidationGroup="DatosPaso1" OnClick="BtnEnviar_Click" />
                                <asp:Button ID="BtnVolver" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Volver" />
                            </form>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlResultado" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <asp:Literal ID="litMensaje" runat="server"></asp:Literal>
                </asp:Panel>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

