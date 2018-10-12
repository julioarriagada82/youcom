<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCFooter.ascx.cs" Inherits="App_Master_Controls_WUCFooter" %>
<footer class="footer">
      <div class="container">
        <div class="row">
          <div class="col-xs-12 col-sm-6 col-md-6"><p class="copyright">Hirefront &copy; 2014<br>Todos los derechos reservados &reg;</p></div>
          <div class="col-xs-12 col-md-6">
            <ul class="nav nav-pills nav-justified">
              <li class="nav-item">
                  <a href="">Políticas de Privacidad</a>
              </li>
              <li class="nav-item">
                  <a href="">Ayuda</a>
              </li>
              <li class="nav-item">
                  <a href="{% url 'hirefront.webcontact' %}">Contacto</a>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </footer>
