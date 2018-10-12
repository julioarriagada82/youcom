<%@ control language="C#" autoeventwireup="true" inherits="App_Master_Controls_MLocalidad, App_Web_khwfgdoq" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" />
<table>
    <tr>
        <td>
            Pais
        </td>
        <td>
            <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPais_OnSelectedIndexChanged"
                Height="34px" Width="127px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                ErrorMessage="Seleccione Pais." ControlToValidate="ddlPais"></asp:RequiredFieldValidator>
        </td>
        <td>
            Ciudad
        </td>
        <td>
            <asp:DropDownList ID="dllRegion" runat="server" Height="34px" Width="127px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                ErrorMessage="Seleccione Region." ControlToValidate="dllRegion"></asp:RequiredFieldValidator>
        </td>
        <td>
            localidad
        </td>
        <td>
            <asp:TextBox runat="server" MaxLength="40" ID="txtLocalidad"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers, LowercaseLetters, UppercaseLetters"
                TargetControlID="txtLocalidad" ValidChars=" ;:*.,-_|#$%/()[]{}¿?¡!">
            </cc1:FilteredTextBoxExtender>
            <asp:RequiredFieldValidator runat="server" Display="None" ErrorMessage="campo Descripcion Localidad es obligatorio."
                ControlToValidate="txtLocalidad"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:Button runat="server" Text="Grabar" ID="btnGrabar" CausesValidation="true" OnClick="btnGrabar_Click" />
        </td>
        <td>
            <asp:Button runat="server" Text="Editar" Visible="false" ID="btnEditar" OnClick="btnEditar_Click" />
        </td>
    </tr>
</table>
<asp:Repeater ID="rptLocalidad" OnItemCommand="rptLocalidad_OnItemCommand" runat="server">
    <HeaderTemplate>
        <div class="conte_box_white">
            <div class="conte_tabla_datos_body_detail ">
                <table class="tabla_datos_top" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th class="w10">
                            Region Dependiente
                        </th>
                        <th class="w20">
                            Localidad
                        </th>
                        <th class="w10">
                            Usuario Ingreso
                        </th>
                        <th class="w10">
                            Fecha Ingreso
                        </th>
                        <th class="w10">
                            Usuario Modificacion
                        </th>
                        <th class="w10">
                            Fecha Mofificacion
                        </th>
                        <th class="w10">
                            Editar
                        </th>
                        <th class="w10">
                            Eliminar
                        </th>
                    </tr>
                </table>
                <div class="conte_tabla_datos_body_gr">
                    <table class="tabla_datos_body" border="0" cellspacing="0" cellpadding="0">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td class="w10 txt-left">
                <%# DataBinder.Eval(Container.DataItem, "idLocalidad")%>
            </td>
            <td class="w20 txt-left">
                <%# DataBinder.Eval(Container.DataItem, "Descripcion")%>
            </td>
            <td class="w10">
                <%# DataBinder.Eval(Container.DataItem, "usuarioIngreso")%>
            </td>
            <td class="w10">
                <%# DataBinder.Eval(Container.DataItem, "fechaIngreso")%>
            </td>
            <td class="w10">
                <%# DataBinder.Eval(Container.DataItem, "usuarioModificacion")%>
            </td>
            <td class="w10">
                <%# DataBinder.Eval(Container.DataItem, "fechaModificacion")%>
            </td>
            <td class="w10">
                <asp:LinkButton ID="LnkBtnCodPropuesta" CausesValidation="false" runat="server" ToolTip="Editar Tipo"
                    CommandName="Editar">Editar</asp:LinkButton>
                <asp:HiddenField ID="hdnDescripcion" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Descripcion")%>' />
                <asp:HiddenField ID="hdnlocalidad" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdLocalidad")%>' />
                <asp:HiddenField ID="hdnRegion" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdRegion")%>' />
            </td>
            <td class="w10">
                <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Eliminar" CausesValidation="false"
                    CommandName="Eliminar">Eliminar</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table></div></div></div>
    </FooterTemplate>
</asp:Repeater>
<asp:HiddenField runat="server" ID="HidIdLocalidad" />
<asp:HiddenField runat="server" ID="HidIdRegion" />
