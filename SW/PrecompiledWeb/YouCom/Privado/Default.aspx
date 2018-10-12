<%@ page language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="Privado_Default, App_Web_2_3use4y" title="Untitled Page" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="page-header">
        Home</h1>
    <div class="table-responsive">
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <asp:Repeater ID="rptAutorizaciones" runat="server" OnItemDataBound="rptAutorizaciones_ItemDataBound"
                OnItemCommand="rptAutorizaciones_ItemCommand">
                <HeaderTemplate>
                    <div class="panel-heading">
                        Mis Autorizaciones</div>
                    <!-- Table -->
                    <table class="table">
                        <thead>
                            <tr>
                                <th>
                                    R.U.T.
                                </th>
                                <th>
                                    Nombre
                                </th>
                                <th>
                                    Actividad
                                </th>
                                <th>
                                    Tipo
                                </th>
                                <th>
                                    Fecha Inicio
                                </th>
                                <th>
                                    Fecha Termino
                                </th>
                                <th>
                                    Eliminar
                                </th>
                                <th>
                                    Lista Negra
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# YouCom.Service.Generales.Formato.FormatoRut(DataBinder.Eval(Container.DataItem, "RutVisita").ToString())%>
                            <asp:HiddenField ID="HdnIdAccesoHogar" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdAccesoHogar")%>' />
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "NombreVisita")%>
                        </td>
                        <td>
                            <asp:Literal ID="LitNombreActividad" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="LitFrecuencia" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaInicio")).ToShortDateString()%>
                        </td>
                        <td>
                            <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaTermino")).ToShortDateString()%>
                        </td>
                        <td>
                            <asp:LinkButton ID="LnkBtnDetalle" runat="server" CommandName="Eliminar">
                                                        <span class="glyphicon glyphicon-eye-open"></span>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkBtnListaNegra" runat="server" CommandName="ListaNegra">
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
    </div>
    <div class="row">
        <div class="col-sm-12 col-md-6">
            <div class="panel panel-default">
                <!-- Default panel contents -->
                <asp:Repeater ID="rptNucleoFamiliar" runat="server" OnItemDataBound="rptNucleoFamiliar_ItemDataBound">
                    <HeaderTemplate>
                        <div class="panel-heading">
                            Núcleo Familiar</div>
                        <!-- Table -->
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>
                                        Nombre
                                    </th>
                                    <th>
                                        Teléfono
                                    </th>
                                    <th>
                                        Parentesco
                                    </th>
                                    <th>
                                        Crear Acceso
                                    </th>
                                    <th>
                                        Eliminar
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "NombreContacto")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "TelefonoContacto")%>
                            </td>
                            <td>
                                <asp:Literal ID="LitParentesco" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:LinkButton ID="LnkBtnCrear" runat="server" CommandName="Crear">
                                                        <span class="glyphicon glyphicon-credit-card"></span>
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LnkBtnEliminar" runat="server" CommandName="Eliminar">
                                                        <span class="glyphicon glyphicon-credit-card"></span>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="panel-body">
                <form role="form">
                <div class="col-sm-6">
                    <asp:Button ID="BtnIngresarNucleoFamiliar" CssClass="btn btn-default" 
                        runat="server" Text="Ingresar" onclick="BtnIngresarNucleoFamiliar_Click" />
                </div>
                </form>
            </div>
        </div>
        <div class="col-sm-12 col-md-6">
            <div class="panel panel-default">
                <!-- Default panel contents -->
                <asp:Repeater ID="rptGastosComunes" runat="server" OnItemDataBound="rptGastosComunes_ItemDataBound">
                    <HeaderTemplate>
                        <div class="panel-heading">
                            Resumen Gastos Comunes</div>
                        <!-- Table -->
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>
                                        Fecha
                                    </th>
                                    <th>
                                        Monto
                                    </th>
                                    <th>
                                        Estado
                                    </th>
                                    <th>
                                        Detalle
                                    </th>
                                    <th>
                                        Pagar
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaGasto")).ToShortDateString()%>
                            </td>
                            <td>
                                <%# YouCom.Service.Generales.Formato.FormatoMontoPeso(DataBinder.Eval(Container.DataItem, "MontoGasto").ToString(), true)%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "EstadoGasto")%>
                            </td>
                            <td>
                                <asp:HyperLink ID="LnkDetalle" runat="server">
                                </asp:HyperLink>
                            </td>
                            <td>
                                <asp:LinkButton ID="LnkBtnPagar" runat="server" CommandName="Pagar">
                                                        <span class="glyphicon glyphicon-credit-card"></span>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12 col-md-6">
            <div class="panel panel-default">
                <!-- Default panel contents -->
                <asp:Repeater ID="rptVacaciones" runat="server">
                    <HeaderTemplate>
                        <div class="panel-heading">
                            Propiedad desocupada</div>
                        <!-- Table -->
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>
                                        Motivo
                                    </th>
                                    <th>
                                        Fecha Inicio
                                    </th>
                                    <th>
                                        Fecha Termino
                                    </th>
                                    <th>
                                        Detalle
                                    </th>
                                    <th>
                                        Eliminar
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "DestinoVacaciones")%>
                            </td>
                            <td>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaInicio")).ToShortDateString()%>
                            </td>
                            <td>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FechaTermino")).ToShortDateString()%>
                            </td>
                            <td>
                                <asp:HyperLink ID="LnkDetalle" runat="server">
                                </asp:HyperLink>
                            </td>
                            <td>
                                <asp:LinkButton ID="LnkBtnEliminar" runat="server" CommandName="Eliminar">
                                                        <span class="glyphicon glyphicon-credit-card"></span>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="panel-body">
                <form role="form">
                <div class="col-sm-6">
                    <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Ingresar"
                        OnClick="BtnIngresar_Click" />
                </div>
                </form>
            </div>
        </div>
        <div class="col-sm-12 col-md-6">
            <div class="panel panel-default">
                <!-- Default panel contents -->
                <div class="panel-heading">
                    Mensajes</div>
                <!-- Table -->
                <table class="table">
                    <thead>
                        <tr>
                            <th>
                                Fecha
                            </th>
                            <th>
                                De
                            </th>
                            <th>
                                Mensaje
                            </th>
                            <th>
                                Responder
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                01/11/2013
                            </td>
                            <td>
                                Administracion
                            </td>
                            <td>
                                Corte de Luz fin de semana
                            </td>
                            <td>
                                <span class="glyphicon glyphicon-credit-card"></span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
