<%@ page title="" language="C#" masterpagefile="~/App_Master/Chat.master" autoeventwireup="true" inherits="Privado_Chat, App_Web_2_3use4y" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../App_Master/Controls/uscMenuPrivado.ascx" TagName="uscMenuPrivado"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">       
        function SetScrollPosition()
        {
            var div = document.getElementById('divMessages');
            div.scrollTop = 100000000000;
        }
        
        function SetToEnd(txtMessage)
        {                    
            if (txtMessage.createTextRange)
            {
                var fieldRange = txtMessage.createTextRange();
                fieldRange.moveStart('character', txtMessage.value.length);
                fieldRange.collapse();
                fieldRange.select();
            }
        }
               
        function ReplaceChars() 
        {
            var txt = document.getElementById('txtMessage').value;
            var out = "<"; // replace this
            var add = ""; // with this
            var temp = "" + txt; // temporary holder

            while (temp.indexOf(out)>-1) 
            {
                pos= temp.indexOf(out);
                temp = "" + (temp.substring(0, pos) + add + 
                temp.substring((pos + out.length), temp.length));
            }
            
            document.getElementById('txtMessage').value = temp;
        }
        
        function LogOutUser(result, context)
        {
            // don't do anything here
        }
        
        function LogMeOut()
        {
            LogOutUserCallBack();   
        }
    </script>

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
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
                    <asp:Label ID="lblRoomName" Font-Size="18px" runat="server" /><br />
                    <br />
                    <asp:Label ID="lblRoomId" Visible="false" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Timer ID="Timer1" Interval="7000" OnTick="Timer1_OnTick" runat="server" />
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 500px;">
                                        <div id="divMessages" style="background-color: White; border-color: Black; border-width: 1px;
                                            border-style: solid; height: 300px; width: 592px; overflow-y: scroll; font-size: 11px;
                                            padding: 4px 4px 4px 4px;" onresize="SetScrollPosition()">
                                            <asp:Literal ID="litMessages" runat="server" />
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <div id="divUsers" style="background-color: White; border-color: Black; border-width: 1px;
                                            border-style: solid; height: 300px; width: 150px; overflow-y: scroll; font-size: 11px;
                                            padding: 4px 4px 4px 4px;">
                                            <asp:Literal ID="litUsers" runat="server" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtMessage" onkeyup="ReplaceChars()" onfocus="SetToEnd(this)" runat="server"
                                            MaxLength="100" Width="500px" />
                                        <asp:Button ID="btnSend" runat="server" Text="Send" OnClientClick="SetScrollPosition()"
                                            OnClick="BtnSend_Click" />
                                        &nbsp; <b>Color:</b>
                                        <asp:DropDownList ID="ddlColor" runat="server">
                                            <asp:ListItem Value="Black" Selected="true">Black</asp:ListItem>
                                            <asp:ListItem Value="Blue">Blue</asp:ListItem>
                                            <asp:ListItem Value="Navy">Navy</asp:ListItem>
                                            <asp:ListItem Value="Red">Red</asp:ListItem>
                                            <asp:ListItem Value="Orange">Orange</asp:ListItem>
                                            <asp:ListItem Value="#666666">Gray</asp:ListItem>
                                            <asp:ListItem Value="Green">Green</asp:ListItem>
                                            <asp:ListItem Value="#FF00FF">Pink</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:Button ID="btnLogOut" Text="Log Out" runat="server" OnClick="BtnLogOut_Click" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <div class="cf">
        </div>
    </div>
    <asp:ValidationSummary ID="VSAll" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Insertar" />
</asp:Content>
