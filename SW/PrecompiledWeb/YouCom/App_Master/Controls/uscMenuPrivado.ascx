<%@ control language="C#" autoeventwireup="true" inherits="App_Master_Controls_uscMenuPrivado, App_Web_khwfgdoq" %>
<asp:Repeater ID="rptMenuPrivado" runat="server" OnItemDataBound="rptMenuPrivado_ItemDataBound">
    <HeaderTemplate>
        <div class="col-sm-3 col-md-2 sidebar">
    </HeaderTemplate>
    <ItemTemplate>
        <ul class="nav nav-sidebar">
            <li class="page-header">
                <%# DataBinder.Eval(Container.DataItem, "FuncionGrupoNombre")%></li>
            <asp:Repeater ID="rptSubMenuPrivado" runat="server">
                <ItemTemplate>
                    <li><a href='<%# DataBinder.Eval(Container.DataItem, "Url")%>'>
                        <%# DataBinder.Eval(Container.DataItem, "FuncionNombre")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
