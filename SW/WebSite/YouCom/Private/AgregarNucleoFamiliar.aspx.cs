using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Net.Mail;

public partial class Privado_AgregarNucleoFamiliar : Intermedia.IMSystem.Navigation.Page.WebPage
{
    private const string retorno1 = "Default.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarParentesco();
            cargarDatosPropietario();
        }
    }

    protected void cargarParentesco()
    {
        ddlParentesco.DataSource = YouCom.bll.ParentescoBLL.listaParentescoActivo();
        ddlParentesco.DataTextField = "NombreParentesco";
        ddlParentesco.DataValueField = "IdParentesco";
        ddlParentesco.DataBind();
        ddlParentesco.Items.Insert(0, new ListItem("Seleccione Parentesco", string.Empty));
    }

    protected void cargarDatosPropietario()
    {
        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

        myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);

        this.TxtNombre.Text = myFamiliaDTO.NombreFamilia;
        this.TxtPaterno.Text = myFamiliaDTO.ApellidoPaternoFamilia;
    }

    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);

                YouCom.DTO.ContactoFamiliaDTO myContactoFamiliaDTO = new YouCom.DTO.ContactoFamiliaDTO();
                //myContactoFamiliaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;
                //myContactoFamiliaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                myContactoFamiliaDTO.TheCasaDTO = myFamiliaDTO.TheCasaDTO;

                YouCom.DTO.Propietario.ParentescoDTO myParentescoDTO = new YouCom.DTO.Propietario.ParentescoDTO();
                myParentescoDTO.IdParentesco = decimal.Parse(ddlParentesco.SelectedValue);

                myContactoFamiliaDTO.TheParentescoDTO = myParentescoDTO;

                myContactoFamiliaDTO.NombreContacto = this.TxtNombreIntegrante.Text;
                myContactoFamiliaDTO.TelefonoContacto = this.TxtTelefonoIntegrante.Text;
                myContactoFamiliaDTO.EmailContacto = this.TxtEmailIntegrante.Text;
                myContactoFamiliaDTO.UsuarioIngreso = myUsuario.Rut;

                bool respuesta = YouCom.bll.ContactoFamiliaBLL.Insert(myContactoFamiliaDTO);
                if (respuesta)
                {
                    if (enviarMail())
                    {
                        if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                        {
                            string script = "alert('Estimado Cliente, hemos recibido su mensaje, en breve nos contactaremos con usted.');";
                            script += "parent.location = '" + retorno1 + "';";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                        }
                    }
                    else
                    {
                        if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                        {
                            string script = "alert('A ocurrido un error. Favor envíe su solicitud al mail contacto@isomin.cl intente más tarde.');";
                            script += "parent.location = '" + retorno1 + "';";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected bool enviarMail()
    {
        try
        {
            string[] _server = YouCom.Service.Generales.General.GetPropiedad("SMTP").Split(new Char[] { ';' });
            string[] _to = YouCom.Service.Generales.General.GetPropiedad("MAILTOCONTACTO").Split(new Char[] { ';' });
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
        string Url = "http://" + Request.Url.Authority + "/mailing/plantilla_contacto_mailing.htm";

        System.Net.WebClient client = new System.Net.WebClient();
        String htmlCode = client.DownloadString(Url);
        string newhtmlCode = "";

        newhtmlCode = Regex.Replace(htmlCode, "src=\"images", "src=\"" + "http://" + Request.Url.Authority + "/mailing/images", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        newhtmlCode = Regex.Replace(newhtmlCode, "{Nombre}", this.TxtNombre.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Apellido}", this.TxtPaterno.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Email}", this.TxtEmail.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);


        newhtmlCode = Regex.Replace(newhtmlCode, "{NombreNuevoIntegrante}", this.TxtNombreIntegrante.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{TelefonoNuevoIntegrante}", this.TxtTelefonoIntegrante.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{EmailNuevoIntegrante}", this.TxtEmailIntegrante.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);


        newhtmlCode = Regex.Replace(newhtmlCode, "{Mensaje}", this.TxtComentarios.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        return newhtmlCode;
    }
}