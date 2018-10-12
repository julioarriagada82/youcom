<%@ control language="C#" autoeventwireup="true" inherits="App_Master_Controls_Menu, App_Web_khwfgdoq" %>
<!--Menu Ppal-->
<div id="menu_ppal">
    <!--INICIO wrap_menu_ppal-->
    <div id="wrap_menu_ppal">
        <!--INICIO menu_con submenú-->
        <asp:Repeater ID="rptMenu" runat="server" OnItemDataBound="rptMenu_ItemDataBound">
            <ItemTemplate>
                <dl class="dropdown">
                <dt id="<%# DataBinder.Eval(Container.DataItem, "FuncionGrupoCod")%>-ddheader" onmouseover="ddMenu('<%# DataBinder.Eval(Container.DataItem, "FuncionGrupoCod")%>',1)"
                    onmouseout="ddMenu('<%# DataBinder.Eval(Container.DataItem, "FuncionGrupoCod")%>',-1)">
                    <%# DataBinder.Eval(Container.DataItem, "FuncionGrupoNombre")%></dt>
                <dd id="<%# DataBinder.Eval(Container.DataItem, "FuncionGrupoCod")%>-ddcontent" onmouseover="cancelHide('<%# DataBinder.Eval(Container.DataItem, "FuncionGrupoCod")%>')" onmouseout="ddMenu('<%# DataBinder.Eval(Container.DataItem, "FuncionGrupoCod")%>',-1)">
                <ul>
                <asp:Repeater ID="rptSubMenu" runat="server">
                    <ItemTemplate>
                        <li><a href='<%# DataBinder.Eval(Container.DataItem, "Url")%>'>
                            <%# DataBinder.Eval(Container.DataItem, "FuncionNombre")%></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul> </dd>
                    </FooterTemplate>
                </asp:Repeater>
                </dl>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <!--FIN wrap_menu_ppal-->
</div>
