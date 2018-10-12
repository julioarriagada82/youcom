<%@ page title="" language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Privado_Avisos, App_Web_2_3use4y" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <td>
        <asp:MultiView ID="mvwAviso" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:Repeater ID="rptCategoria" runat="server" OnItemDataBound="rptCategoria_ItemDataBound">
                    <HeaderTemplate>
                        <td style="width: 859px">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div>
                            <h2>
                                <%# DataBinder.Eval(Container.DataItem, "NombreCategoria")%>
                            </h2>
                            <asp:Repeater ID="rptAviso" runat="server" OnItemDataBound="rptAviso_ItemDataBound"
                                OnItemCommand="rptAviso_ItemCommand">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <div class="articulo_dest col_3">
                                            <div>
                                                <asp:Image ID="imgLogo" CssClass="left" runat="server" Width="180" Height="93" />
                                            </div>
                                            <h3>
                                                <%# DataBinder.Eval(Container.DataItem, "TituloAviso")%></h3>
                                            <p>
                                                <%# DataBinder.Eval(Container.DataItem, "DescripcionAviso")%>
                                                <asp:LinkButton ID="LnkBtnDetalleAviso" runat="server" CommandName="Detalle" Text="(Ver
                                                    más)"></asp:LinkButton></p>
                                            <asp:HiddenField ID="HidIdAviso" Value='<%# DataBinder.Eval(Container.DataItem, "IdAviso")%>'
                                                runat="server"></asp:HiddenField>
                                        </div>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <br />
                        <div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </td>
                    </FooterTemplate>
                </asp:Repeater>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="articulo_dest col_3">
                    <h3>
                        <asp:Literal ID="LitAvisoTitulo" runat="server"></asp:Literal>
                        <asp:HiddenField ID="HdnIdAviso" runat="server"></asp:HiddenField>
                    </h3>
                    <p>
                        <asp:Literal ID="LitAvisoResumen" runat="server"></asp:Literal>
                    </p>
                    <p>
                        <asp:Literal ID="LitAvisoDetalle" runat="server"></asp:Literal></p>
                    <p>
                        Tipo:
                        <asp:Literal ID="LitTipo" runat="server"></asp:Literal></p>
                    <p>
                        Precio:
                        <asp:Literal ID="LitPrecio" runat="server"></asp:Literal></p>
                    <p>
                        Fecha Publicación:
                        <asp:Literal ID="LitFechaPublicacion" runat="server"></asp:Literal></p>
                    <p>
                        Fecha Termino:
                        <asp:Literal ID="LitFechaTermino" runat="server"></asp:Literal></p>
                    <p>
                        Datos Contacto:
                        <asp:Literal ID="LitContacto" runat="server"></asp:Literal></p>
                </div>
                <asp:Repeater ID="rptComentarios" runat="server" OnItemDataBound="rptComentarios_ItemDataBound">
                    <HeaderTemplate>
                        <div>
                            <h2>
                                Comentarios</h2>
                            <table width="100%">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <itemtemplate>
                                    <tr>
                                    <td>
                                        <div class="articulo_dest col_3">
                                            <h3>
                                                <a href="DetalleComentarioAviso.aspx?id=<%# DataBinder.Eval(Container.DataItem, "IdComentarioAviso")%>">
                                                    <asp:Literal ID="LitNombreConsultante" runat="server"></asp:Literal></a></h3>
                                            <p>
                                                <%# DataBinder.Eval(Container.DataItem, "ComentarioAviso")%><a href="DetalleComentarioAviso.aspx?id=<%# DataBinder.Eval(Container.DataItem, "IdComentarioAviso")%>">(Ver más)</a></p>
                                            <p>
                                                <a href="RespuestaComentarioAviso.aspx?id=<%# DataBinder.Eval(Container.DataItem, "IdComentarioAviso")%>" >Ver Respuestas <asp:Literal ID="LitCantidadRespuestas" runat="server"></asp:Literal></a>
                                                <a href="ResponderComentarioAviso.aspx?id=<%# DataBinder.Eval(Container.DataItem, "IdComentarioAviso")%>" >Responder</a>
                                            </p>
                                        </div>
                                    </td>
                                    </tr>
                                </itemtemplate>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table> </div>
                    </FooterTemplate>
                </asp:Repeater>
                <div class="articulo_dest col_3">
                    <p>
                        Contacta al anunciante
                        <asp:LinkButton ID="LnkBtnIngresaComentario" runat="server" Text="Aqui" OnClick="LnkBtnIngresaComentario_Click"></asp:LinkButton>
                    </p>
                </div>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div class="articulo_dest col_3">
                    <h3>
                        <%=LitAvisoTitulo.Text%>
                    </h3>
                    <p>
                        <%=LitAvisoResumen.Text%>
                    </p>
                    <p>
                        <%=LitAvisoDetalle.Text%>
                        <p>
                            Tipo:
                            <%=this.LitTipo.Text%>
                            <p>
                                Precio:
                                <%=this.LitPrecio.Text%>
                                <p>
                                    Fecha Publicación:
                                    <%=this.LitFechaPublicacion.Text%>
                                    <p>
                                        Fecha Termino:
                                        <%=this.LitFechaTermino.Text%>
                                        <p>
                                            Datos Contacto:
                                            <%=LitAvisoTitulo.Text%></p>
                </div>
                <div class="left-align ui-tabs-panel cf">
                    <h2>
                        Ingresa tus datos y tu consulta</h2>
                    <div class="left cf">
                        <p>
                            Complete los datos, y envíelo, el anunciante se pondra en contacto con usted a la
                            brevedad.</p>
                        <fieldset>
                            <div class="separa cf">
                                <label for="nombre" class="left">
                                    <span>Nombre:</span></label>
                                <div class="left back-field">
                                    <asp:Literal ID="LitNombre" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="separa cf">
                                <label for="email" class="left">
                                    <span>Email:</span></label>
                                <div class="left back-field">
                                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="text-field"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtEmail"
                                        Display="None" ErrorMessage="Por favor ingrese un correo electrónico" ValidationGroup="DatosPaso1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="REVMail" runat="server" ControlToValidate="TxtEmail"
                                        Display="None" ErrorMessage="Por favor ingrese un correo electrónico valido."
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="DatosPaso1">*</asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="separa cf">
                                <label for="comentarios" class="left">
                                    <span>Comentarios:</span></label>
                                <div class="left back-textarea">
                                    <asp:TextBox ID="TxtComentarios" runat="server" CssClass="text-field" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="separa cf">
                                <div class="left back-button">
                                    <asp:Button ID="BtnEnviar" runat="server" CssClass="send-button" Text="Enviar" ValidationGroup="DatosPaso1"
                                        OnClick="BtnEnviar_Click" />
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
    </td>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
