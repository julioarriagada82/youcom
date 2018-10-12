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

using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;

public partial class Privado_Reservas : Intermedia.IMSystem.Navigation.Page.WebPage
{
    private const string retorno1 = "Default.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarAreasComunes();
        }
    }

    protected void cargarAreasComunes()
    {
        //ddlAreaComun.DataSource = YouCom.bll.AreasComunesBLL.getListadoAreasComunesByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);
        ddlAreaComun.DataTextField = "NombreAreasComunes";
        ddlAreaComun.DataValueField = "IdAreasComunes";
        ddlAreaComun.DataBind();
        ddlAreaComun.Items.Insert(0, new ListItem("Seleccione Aréa Común", string.Empty));
    }

    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                YouCom.DTO.AreasComunesDTO myAreasComunesDTO = new YouCom.DTO.AreasComunesDTO();

                myAreasComunesDTO = YouCom.bll.AreasComunesBLL.detalleAreasComunes(decimal.Parse(ddlAreaComun.SelectedValue));

                decimal hora_inicio = decimal.Parse(ddlHoraInicio.SelectedValue);
                decimal minuto_inicio = decimal.Parse(ddlMinutoInicio.SelectedValue);
                decimal hora_termino = decimal.Parse(ddlHoraTermino.SelectedValue);
                decimal minuto_termino = decimal.Parse(ddlMinutoTermino.SelectedValue);

                decimal inicio = 0;
                decimal termino = 0;
                decimal diferencia = 0;

                inicio = (hora_inicio * 60) + minuto_inicio;
                termino = (hora_termino * 60) + minuto_termino;

                diferencia = (termino - inicio) / 60;

                if (hora_inicio > hora_termino)
                {
                    string script = "var texto='Estimado cliente, la hora de inicio no puede ser mayor que la hora de termino.'; alert(texto);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "trxErr", script, true);
                }
                else if (diferencia > myAreasComunesDTO.CantidadHora)
                {
                    string script = "var texto='Estimado cliente, la cantidad de horas de reserva para " + ddlAreaComun.SelectedItem.Text + " no puede ser superior a " + myAreasComunesDTO.CantidadHora.ToString() + ".'; alert(texto);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "trxErr", script, true);
                }
                else
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

        newhtmlCode = Regex.Replace(newhtmlCode, "{AreaComun}", this.ddlAreaComun.SelectedItem.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{HoraInicio}", this.ddlHoraInicio.SelectedValue + ":" + this.ddlMinutoInicio.SelectedValue, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{HoraTermino}", this.ddlHoraTermino.SelectedValue + ":" + this.ddlMinutoTermino.SelectedValue, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Mensaje}", this.TxtComentarios.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        return newhtmlCode;
    }
}
