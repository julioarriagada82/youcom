using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class App_Master_Controls_UCLogin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            ValidarClaveEmpresa(YouCom.Service.Generales.Formato.LimpiarRut(txtUsuario.Text), YouCom.Service.Generales.Formato.LimpiarRut(txtUsuario.Text), txtPassword.Text);
            //Session["InformacionUsuario"] = SeguridadBLL.Seguridad.LoginPrivado(YouCom.Service.Generales.Formato.LimpiarRut(txtUsuario.Text), txtPassword.Text);
            //Response.Redirect("Privado/Inicio.aspx");
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void ValidarClaveEmpresa(string pRut, string pRutCondominio, string pPassword)
    {
        try
        {
            //Genero token para log
            YouCom.DTO.Seguridad.UsuarioDTO myUsuario = new YouCom.DTO.Seguridad.UsuarioDTO();
            string retornoToken = YouCom.Service.Configuracion.General.getGeneraToken(HttpContext.Current.Server.HtmlEncode(pRut), HttpContext.Current.Server.HtmlEncode(pRutCondominio), HttpContext.Current.Server.HtmlEncode(pPassword));
            myUsuario.Token_Usr = retornoToken;
            HttpContext.Current.Session["usuario"] = myUsuario;
            //Genero token para log

            string pass = string.Empty;
            string sXmlResponse = string.Empty;

            string rut = YouCom.Service.Configuracion.Formato.LimpiarRut(pRut).ToUpper();
            string rut_empresa = YouCom.Service.Configuracion.Formato.LimpiarRut(pRutCondominio).ToUpper();

            string grupo_cod = string.Empty;


            string pAmbiente = YouCom.Service.Parametrizacion.Parametros.GetConsultaParametros("AMBIENTE", "DISPONIBLE");
            string pUrlAmbiente = YouCom.Service.Parametrizacion.Parametros.GetConsultaParametros("AMBIENTE", "URLNODISP");

            if (pAmbiente.Equals("INFORMACIÓN NO CARGADA"))
            {
                Response.Redirect("ErrorClaveErronea.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                return;
            }

            if (pPassword.Length == 4)
                pass = pPassword.ToUpper();
            else
                pass = pPassword;

            if (pAmbiente == "1")
            {
                if (YouCom.Service.Configuracion.General.AuthenticateEmpresa(Server.HtmlEncode(rut),
                                         Server.HtmlEncode(rut_empresa),
                                         Server.HtmlEncode(pass),
                                         ref sXmlResponse))
                {
                    myUsuario = (YouCom.DTO.Seguridad.UsuarioDTO)Session["usuario"];

                    string retorno = YouCom.Service.Configuracion.General.getGeneraToken(Server.HtmlEncode(rut), Server.HtmlEncode(rut_empresa), Server.HtmlEncode(pass));

                    myUsuario.Token_Usr = retorno;

                    HttpContext.Current.Session["usuario"] = myUsuario;

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                                                                        myUsuario.Rut,
                                                                                        DateTime.Now,
                                                                                        DateTime.Now.AddDays(1), // value of time out property
                                                                                        false, // Value of IsPersistent property
                                                                                        String.Empty,
                                                                                        FormsAuthentication.FormsCookiePath);



                    if (myUsuario.TheCondominioDTO.Count == 0)
                    {
                        string script = "var texto='Usted no tiene acceso para entrar a este portal.'; alert(texto);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "trxErr", script, true);
                    }
                    else
                        FormsAuthentication.RedirectFromLoginPage(myUsuario.Rut, false);
                }
                else
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(sXmlResponse);

                    Session.Add("RutCliente", rut);
                    Session.Add("RutCondominio", rut_empresa);

                    if (xmlDoc.SelectSingleNode("Error/ErrorCod").InnerText == "3")
                    {
                        Response.Redirect("funcionales/cambia_clave.aspx", false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                        return;
                    }
                    else if (xmlDoc.SelectSingleNode("Error/ErrorCod").InnerText == "4")
                    {
                        Response.Redirect(YouCom.Service.Parametrizacion.Parametros.GetConsultaParametros("PUBLICO", "URLERRORBLOQ"), false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                        return;
                    }
                    else
                    {
                        Response.Redirect("ErrorClaveErronea.aspx", false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                        return;
                    }
                }
            }
            else
            {
                Response.Redirect(YouCom.Service.Parametrizacion.Parametros.GetConsultaParametros("AMBIENTE", "URLNODISP"), false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                return;
            }
        }
        catch (Exception ex)
        {
            string script = "var texto='" + ex.Message + "'; alert(texto);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "trxErr", script, true);
        }
    }
}
