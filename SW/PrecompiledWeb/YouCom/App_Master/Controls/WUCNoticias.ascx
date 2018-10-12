<%@ control language="C#" autoeventwireup="true" inherits="App_Master_Controls_WUCNoticias, App_Web_khwfgdoq" %>
<asp:Repeater ID="rptNoticia" runat="server" OnItemDataBound="rptNoticia_ItemDataBound">
    <HeaderTemplate>
        <div class="row">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="feature col-xs-12 col-sm-4 col-md-4">
            <h1>
                <%# DataBinder.Eval(Container.DataItem, "NotiTitulo")%></h1>
            <div class="txt-wrap">
                <p>
                    <%# DataBinder.Eval(Container.DataItem, "NotiResumen")%>
                </p>
                <a href="DetalleNoticia.aspx?id=<%# DataBinder.Eval(Container.DataItem, "NoticiaId")%>">
                    ver mas <span class="glyphicon glyphicon-chevron-right"></span></a>
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
