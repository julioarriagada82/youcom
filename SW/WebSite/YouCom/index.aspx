<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/HomePublico.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register src="App_Master/Controls/UCLogin.ascx" tagname="UCLogin" tagprefix="uc1" %>
<%@ Register src="App_Master/Controls/WUCNoticias.ascx" tagname="WUCNoticias" tagprefix="uc2" %>
<%@ Register src="App_Master/Controls/WUCBanner.ascx" tagname="WUCBanner" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <uc1:UCLogin ID="UCLogin1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc3:WUCBanner ID="WUCBanner1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc2:WUCNoticias ID="WUCNoticias1" runat="server" />
</asp:Content>

