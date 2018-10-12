<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wcMenuHorizontalPrivado.ascx.cs" Inherits="App_Master_Controls_WebUserControl" %>

<div class="navbar-collapse collapse">
    <ul class="nav navbar-nav navbar-right">
        <li>
            <asp:HyperLink ID="hlnkPortada" runat="server" Text="PORTADA"></asp:HyperLink>
        </li>
        <asp:Repeater ID="rptMenuPrivado" runat="server" OnItemDataBound="rptMenuPrivado_ItemDataBound">
            <ItemTemplate>
                <li>
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><%# DataBinder.Eval(Container.DataItem, "FuncionGrupoNombre")%></a>
                    <asp:HiddenField ID="HdnFuncionGrupoCod" Value='<%# DataBinder.Eval(Container.DataItem, "FuncionGrupoCod")%>' runat="server" />
                    <asp:Repeater ID="rptSubMenuPrivado" OnItemDataBound="rptSubMenuPrivado_ItemDataBound" runat="server">
                        <HeaderTemplate>
                            <ul class="dropdown-menu">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li><a href='<%# DataBinder.Eval(Container.DataItem, "Url")%>'><%# DataBinder.Eval(Container.DataItem, "FuncionNombre")%></a>
                                <asp:Repeater ID="rptSubSubMenuPrivado" runat="server">
                                    <HeaderTemplate>
                                        <ul class="menu">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li><a href='<%# DataBinder.Eval(Container.DataItem, "Url")%>'><%# DataBinder.Eval(Container.DataItem, "FuncionNombre")%></a></li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </ul>
                                    </FooterTemplate>
                                </asp:Repeater>

                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
