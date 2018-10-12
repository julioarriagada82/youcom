<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Home.master" AutoEventWireup="true"
    CodeFile="Comunidad.aspx.cs" Inherits="Privado_Comunidad" %>

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
                                    <table width="100%">
                                        <tr>
                                            <td width="350px">Asunto</td>
                                            <td width="100px">Respuestas</td>
                                            <td width="200px">Autor</td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="LnkBtnDetalleAviso" runat="server" CommandName="Detalle" Text='<%# DataBinder.Eval(Container.DataItem, "TituloForoComunidad")%>'></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Literal ID="LitRespuestas" runat="server"></asp:Literal></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "theFamiliaDTO.NombreCompleto")%></td>
                                        <asp:HiddenField ID="HidIdForoComunidad" Value='<%# DataBinder.Eval(Container.DataItem, "IdForoComunidad")%>'
                                            runat="server"></asp:HiddenField>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
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
                <div class="separa cf">
                    <div class="left back-button">
                        <asp:Button ID="BntAgregar" runat="server" CssClass="send-button" Text="Nuevo Mensaje" ValidationGroup="DatosPaso1" OnClick="BntAgregar_Click" />
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="articulo_dest col_3">
                    <h3>
                        <asp:Literal ID="LitForoComunidadTitulo" runat="server"></asp:Literal>
                        <asp:HiddenField ID="HdnIdForoComunidad" runat="server"></asp:HiddenField>
                    </h3>
                    <p>
                        <asp:Literal ID="LitForoComunidadDetalle" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="articulo_dest col_3">
                    <p>
                        <asp:LinkButton ID="LnkBtnIngresaRespuesta" runat="server" Text="Responder" OnClick="LnkBtnIngresaRespuesta_Click"></asp:LinkButton>
                    </p>
                </div>
                <asp:Repeater ID="rptComentarios" runat="server" OnItemDataBound="rptComentarios_ItemDataBound">
                    <HeaderTemplate>
                        <div>
                            <h2>Comentarios</h2>
                            <table width="100%">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <itemtemplate>
                                    <tr>
                                        <td width="250px">
                                            <%# DataBinder.Eval(Container.DataItem, "TheFamiliaDTO.NombreCompleto")%><br />
                                            <%# DataBinder.Eval(Container.DataItem, "FechaForoComunidad")%>

                                        </td>
                                        <td width="450px">
                                            <div class="articulo_dest col_3">
                                                <p>
                                                    <%# DataBinder.Eval(Container.DataItem, "TituloForoComunidad")%></p>
                                                <p>
                                                    <%# DataBinder.Eval(Container.DataItem, "DescripcionForoComunidad")%></p>
                                                <p>
                                                    <a>Responder</a>
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
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div class="articulo_dest col_3">
                    <h3>
                        <%=LitForoComunidadTitulo.Text%>
                    </h3>
                    <p>
                        <%=LitForoComunidadDetalle.Text%>
                    </p>
                </div>
                <div class="left-align ui-tabs-panel cf">
                    <h2>Ingresa tus datos y tu respuesta</h2>
                    <div class="left cf">
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
