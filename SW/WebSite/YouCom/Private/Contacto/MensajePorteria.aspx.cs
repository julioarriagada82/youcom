using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text.RegularExpressions;

public partial class Privado_MensajePorteria : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarCategorias();
        }
    }

    protected void cargarCategorias()
    {
        IList<YouCom.DTO.CategoriaDTO> collCategoria = new List<YouCom.DTO.CategoriaDTO>();

        collCategoria = YouCom.bll.CategoriaBLL.getListadoCategoria().Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 12 || x.TheTipoCategoriaDTO.IdTipoCategoria == 11).ToList();

        ddlCategoria.DataSource = collCategoria;
        ddlCategoria.DataTextField = "NombreCategoria";
        ddlCategoria.DataValueField = "IdCategoria";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, new ListItem("Seleccione Categoría", string.Empty));
    }

    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                string retorno1 = "http://" + Request.Url.Authority + "/privado/Inicio.aspx";

                if (setEnviaMensaje())
                {
                    if (enviarMail())
                    {
                        if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                        {
                            string script = "alert('Estimado Cliente, su solicitud ha quedado registrada exitosamente.');";
                            script += "parent.location = '" + retorno1 + "';";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                        }
                    }
                    else
                    {
                        if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                        {
                            string script = "alert('A ocurrido un error. Favor envíe su solicitud al mail contacto@youcom.cl intente más tarde.');";
                            script += "parent.location = '" + retorno1 + "';";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                        }
                    }
                }
                else
                {
                    string script = "alert('A ocurrido un error. Favor envíe su solicitud al mail contacto@youcom.cl intente más tarde.');";
                    script += "parent.location = '" + retorno1 + "';";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);

                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected bool setEnviaMensaje()
    {
        bool retorno = false;

        YouCom.DTO.Mensajeria.MensajePorteriaDTO theMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();

        YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO myMensajeTipoEnvioDTO = new YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO();
        myMensajeTipoEnvioDTO.IdMensajeTipoEnvio = 1;
        theMensajePorteriaDTO.TheMensajeTipoEnvioDTO = myMensajeTipoEnvioDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theMensajePorteriaDTO.TheCategoriaDTO = myCategoriaDTO;

        theMensajePorteriaDTO.MensajeTitulo = TxtAsunto.Text;
        theMensajePorteriaDTO.MensajeDescripcion = TxtComentarios.Text;
        theMensajePorteriaDTO.MensajeFecha = DateTime.Now;

        theMensajePorteriaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
        theMensajePorteriaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

        myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
        theMensajePorteriaDTO.TheFamiliaDTO = myFamiliaDTO;

        YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
        myPorteriaDTO.IdPorteria = decimal.Parse(Session["PorteriaId"].ToString());
        theMensajePorteriaDTO.ThePorteriaDTO = myPorteriaDTO;

        if (Session["MensajeId"] != null)
        {
            theMensajePorteriaDTO.IdPadre = decimal.Parse(Session["MensajeId"].ToString());
        }

        theMensajePorteriaDTO.UsuarioIngreso = myUsuario.Rut;

        retorno = YouCom.bll.Mensajeria.MensajePorteriaBLL.Insert(theMensajePorteriaDTO);

        return retorno;
    }

    protected bool enviarMail()
    {
        try
        {
            string[] _server = YouCom.Service.Generales.General.GetPropiedad("SMTP").Split(new Char[] { ';' });
            string[] _to = YouCom.Service.Generales.General.GetPropiedad("MAILTO").Split(new Char[] { ';' });
            string[] _from = YouCom.Service.Generales.General.GetPropiedad("MAILFROM").Split(new Char[] { ';' });

            System.Net.Mail.MailMessage _mail = new System.Net.Mail.MailMessage();

            _mail.From = new MailAddress(_from[0], _from[1], System.Text.Encoding.UTF8);
            _mail.To.Add(new MailAddress(_to[0], _to[1], System.Text.Encoding.UTF8));

            _mail.Subject = "Contacto " + " " + DateTime.Now.ToString("D");

            _mail.SubjectEncoding = System.Text.Encoding.UTF8;
            _mail.Body = this.creaCuerpo().Replace("ï»¿", "");

            _mail.BodyEncoding = System.Text.Encoding.UTF8;
            _mail.IsBodyHtml = true;

            SmtpClient _smtp = new SmtpClient();

            _smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtp.UseDefaultCredentials = false;

            _smtp.Host = _server[0];
            _smtp.Port = int.Parse(_server[1]);

            _smtp.Credentials = new System.Net.NetworkCredential(_server[2], _server[3]);
            _smtp.EnableSsl = true;

            _smtp.Send(_mail);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    protected string creaCuerpo()
    {
        string Url = "http://" + Request.Url.Authority + "/mailing/plantilla_contacto_porteria_mailing.html";

        System.Net.WebClient client = new System.Net.WebClient();
        String htmlCode = client.DownloadString(Url);
        string newhtmlCode = "";

        newhtmlCode = Regex.Replace(htmlCode, "src=\"images", "src=\"" + "http://" + Request.Url.Authority + "/mailing/images", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);

        newhtmlCode = Regex.Replace(newhtmlCode, "{Nombre}", myFamiliaDTO.NombreFamilia, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Apellido}", myFamiliaDTO.ApellidoPaternoFamilia + " " + myFamiliaDTO.ApellidoMaternoFamilia, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Telefono}", myFamiliaDTO.TelefonoFamilia, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Email}", myFamiliaDTO.EmailFamilia, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Categoria}", this.ddlCategoria.SelectedItem.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Asunto}", this.TxtAsunto.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Mensaje}", this.TxtComentarios.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        return newhtmlCode;
    }
}
