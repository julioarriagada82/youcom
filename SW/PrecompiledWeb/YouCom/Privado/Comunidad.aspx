<%@ page title="" language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Privado_Comunidad, App_Web_2_3use4y" enableEventValidation="false" %>

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
                            <asp:Repeater ID="rptForoComunidad" runat="server" OnItemDataBound="rptForoComunidad_ItemDataBound"
                                OnItemCommand="rptForoComunidad_ItemCommand">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <div class="articulo_dest col_3">
                                            <h3>
                                                <%# DataBinder.Eval(Container.DataItem, "TituloForoComunidad")%></h3>
                                            <p>
                                                <%# DataBinder.Eval(Container.DataItem, "DescripcionrptForoComunidad")%>
                                                <asp:LinkButton ID="LnkBtnDetalleAviso" runat="server" CommandName="Detalle" Text="(Ver
                                                    más)"></asp:LinkButton></p>
                                            <asp:HiddenField ID="HidIdAviso" Value='<%# DataBinder.Eval(Container.DataItem, "IdrptForoComunidad")%>'
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
                        <asp:Literal ID="LitForoComunidadTitulo" runat="server"></asp:Literal>
                        <asp:HiddenField ID="HdnIdForoComunidad" runat="server"></asp:HiddenField>
                    </h3>
                    <p>
                        <asp:Literal ID="LitForoComunidadResumen" runat="server"></asp:Literal>
                    </p>
                    <p>
                        <asp:Literal ID="LitForoComunidadDetalle" runat="server"></asp:Literal></p>
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
                                                <a href="DetalleComentarioAviso.aspx?id=<%# DataBinder.Eval(Container.DataItem, "IdComentarioForoComunidad")%>">
                                                    <asp:Literal ID="LitNombreConsultante" runat="server"></asp:Literal></a></h3>
                                            <p>
                                                <%# DataBinder.Eval(Container.DataItem, "MensajeComentarioForoComunidad")%><a href="DetalleComentarioAviso.aspx?id=<%# DataBinder.Eval(Container.DataItem, "IdComentarioForoComunidad")%>">(Ver más)</a></p>
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
                        <%=LitForoComunidadTitulo.Text%>
                    </h3>
                    <p>
                        <%=LitForoComunidadResumen.Text%>
                    </p>
                    <p>
                        <%=LitForoComunidadDetalle.Text%>
                    </p>
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
