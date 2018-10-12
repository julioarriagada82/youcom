<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCLogin.ascx.cs" Inherits="App_Master_Controls_UCLogin" %>
<div id="login" class="col-xs-12 col-sm-5 col-md-4">
    <div class="row">
        <div class="col-xs-10 col-sm-10 col-md-10 col-xs-offset-1 col-sm-offset-1 col-md-offset-1">
            <p>
                Lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum. Lorem ipsum lorem ipsum
                lorem ipsum lorem ipsum lorem ipsum.</p>
            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon glyphicon glyphicon-user"></span>
                    <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" placeholder="Tu usuario" onblur="return validaRut(this)"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon glyphicon glyphicon-lock"></span>
                    <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="txtPassword" placeholder="Tu contraseña"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Button runat="server" CssClass="btn btn-primary btn-block" ID="btnIngresar" Text="Entrar" OnClick="btnIngresar_Click" />
            </div>
        </div>
    </div>
</div>
