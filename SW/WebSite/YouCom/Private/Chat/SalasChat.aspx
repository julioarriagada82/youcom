<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Chat.master" AutoEventWireup="true"
    CodeFile="SalasChat.aspx.cs" Inherits="Privado_SalasChat" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="conte">
        <table width="100%">
            <tr>
                <td style="width: 159px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <uc1:uscMenuPrivado ID="uscMenuPrivado1" runat="server" />
                <td style="width: 20px">
                </td>
                <td>
                    <asp:Repeater ID="rptSalas" runat="server">
                        <HeaderTemplate>
                            <div>
                                <h2>
                                    Salas</h2>
                                <table width="100%">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <itemtemplate>
                                    <tr>
                                    <td>
                                        <div class="articulo_dest col_3">
                                            <h3><a href="Chat.aspx?roomId=<%# DataBinder.Eval(Container.DataItem, "RoomID")%>">
                                                    <%# DataBinder.Eval(Container.DataItem, "Name")%></a></h3>
                                        </div>
                                    </td>
                                    </tr>
                                </itemtemplate>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table> </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
        <div class="cf">
        </div>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
