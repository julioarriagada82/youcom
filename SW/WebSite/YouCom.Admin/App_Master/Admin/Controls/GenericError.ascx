<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GenericError.ascx.cs"
    Inherits="App_Master_UserControl_GenericError" %>
<div id="error_generico">
    <p>
        <strong>Estimado Cliente, en estos Momentos no es Posible Procesar su Solicitud, por
            Favor Inténtelo nuevamente más Tarde.</strong></p>
</div>
<table class="botones">
    <tr>
        <td>
            <asp:Button ID="Button1" runat="server" Text="" CssClass="volver_sitio_publico" 
                onclick="Button1_Click" />
        </td>
    </tr>
</table>
</div>