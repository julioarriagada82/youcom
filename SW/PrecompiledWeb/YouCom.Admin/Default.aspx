<%@ page language="C#" masterpagefile="~/App_Master/Home.master" autoeventwireup="true" inherits="_Default, App_Web_niaggcfu" title="Untitled Page" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="conte">
        <h2>
            HOME</h2>
        <div class="cf">
        </div>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="DatosPaso1" />
</asp:Content>
