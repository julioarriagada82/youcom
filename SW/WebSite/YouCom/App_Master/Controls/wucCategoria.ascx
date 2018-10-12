<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucCategoria.ascx.cs" Inherits="App_Master_Controls_wucCategoria" %>
<asp:Repeater ID="rptCategoria" runat="server" OnItemCommand="rptCategoria_ItemCommand">
    <HeaderTemplate>
        <div class="col-sm-3 col-md-2 sidebar">
            <ul class="nav nav-sidebar">
                <li class="page-header">
                    Categorías (Filtros)</li>
                <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <asp:LinkButton ID="LnkBtnCategoria" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NombreCategoria")%>' CommandName="Seleccionar"></asp:LinkButton>
            <asp:HiddenField ID="HidIdCategoria" Value='<%# DataBinder.Eval(Container.DataItem, "IdCategoria")%>'
                                        runat="server"></asp:HiddenField>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
        </ul>
        </div>
    </FooterTemplate>
</asp:Repeater>
