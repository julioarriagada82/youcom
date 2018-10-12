﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_Contacto_MensajePropietario : Intermedia.IMSystem.Navigation.Page.WebPage
{
    private const string retorno1 = "Default.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }
    protected bool setEnviaMensaje()
    {
        bool retorno = false;

        YouCom.DTO.Mensajeria.MensajePropietarioDTO theMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();

        theMensajePropietarioDTO.MensajeTitulo = TxtAsunto.Text;
        theMensajePropietarioDTO.MensajeDescripcion = TxtComentarios.Text;
        theMensajePropietarioDTO.MensajeFecha = DateTime.Now;

        theMensajePropietarioDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
        theMensajePropietarioDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

        myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
        theMensajePropietarioDTO.TheFamiliaOrigenDTO = myFamiliaDTO;

        myFamiliaDTO.IdFamilia = decimal.Parse(Session["FamiliaId"].ToString());
        theMensajePropietarioDTO.TheFamiliaDestinoDTO = myFamiliaDTO;

        if (Session["MensajeId"] != null)
        {
            theMensajePropietarioDTO.IdPadre = decimal.Parse(Session["MensajeId"].ToString());
        }

        theMensajePropietarioDTO.UsuarioIngreso = myUsuario.Rut;

        retorno = YouCom.bll.Mensajeria.MensajePropietarioBLL.Insert(theMensajePropietarioDTO);

        return retorno;
    }

    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (setEnviaMensaje())
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

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);

        newhtmlCode = Regex.Replace(newhtmlCode, "{Nombre}", myFamiliaDTO.NombreFamilia, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Apellido}", myFamiliaDTO.ApellidoPaternoFamilia + " " + myFamiliaDTO.ApellidoMaternoFamilia, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Email}", myFamiliaDTO.EmailFamilia, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Asunto}", this.TxtAsunto.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Mensaje}", this.TxtComentarios.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        return newhtmlCode;
    }
}
