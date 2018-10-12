using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;

public partial class Privado_Accesos_InvitacionVisitas : Intermedia.IMSystem.Navigation.Page.WebPage
{
    private const string retorno1 = "InvitacionVisitas.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SelView(0);

            if (Session["idInvitacionVisita"] != null)
            {
                getObtieneDetalleAcceso(Session["idInvitacionVisita"].ToString());

                Session.Remove("idInvitacionVisita");
            }
            else
            {
                cargarTipoVisita();
                cargarAutorizaciones();

                ddlHoraInicio.DataSource = YouCom.Service.Generales.Formato.getObtieneDatos(1, 24);
                ddlHoraInicio.DataBind();

                ddlHoraTermino.DataSource = YouCom.Service.Generales.Formato.getObtieneDatos(1, 24);
                ddlHoraTermino.DataBind();

                ddlMinutoInicio.DataSource = YouCom.Service.Generales.Formato.getObtieneDatos(0, 59);
                ddlMinutoInicio.DataBind();

                ddlMinutoTermino.DataSource = YouCom.Service.Generales.Formato.getObtieneDatos(0, 59);
                ddlMinutoTermino.DataBind();
            }
        }
    }


    void SelView(Int32 nIndex)
    {
        Int32 oIndex = this.mvwAutorizaciones.ActiveViewIndex;
        this.mvwAutorizaciones.ActiveViewIndex = nIndex;
    }

    protected void cargarTipoVisita()
    {
        ddlTipoVisita.DataSource = YouCom.bll.AccesoHogar.TipoVisitaBLL.listaTipoVisitaActivo();
        ddlTipoVisita.DataTextField = "NombreTipoVisita";
        ddlTipoVisita.DataValueField = "IdTipoVisita";
        ddlTipoVisita.DataBind();
        ddlTipoVisita.Items.Insert(0, new ListItem("Seleccione Tipo Visita", string.Empty));
    }

    protected void cargarAutorizaciones()
    {
        IList<YouCom.DTO.AccesoHogar.AccesoHogarDTO> myAccesoHogar = new List<YouCom.DTO.AccesoHogar.AccesoHogarDTO>();

        myAccesoHogar = YouCom.bll.AccesoHogar.AccesoHogarBLL.getListadoAccesoHogarByCasa(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad, myUsuario.TheFamiliaDTO.TheCasaDTO.IdCasa);

        if(myAccesoHogar.Any())
        {
            rptAutorizaciones.DataSource = myAccesoHogar.Where(x => x.TheFrecuenciaDTO.IdFrecuencia != 1).ToList();
            rptAutorizaciones.DataBind();
        }
    }

    protected void getObtieneDetalleAcceso(string idAccesoHogar)
    {
        try
        {
            YouCom.DTO.AccesoHogar.AccesoHogarDTO myAccesoHogar = new YouCom.DTO.AccesoHogar.AccesoHogarDTO();

            myAccesoHogar = YouCom.bll.AccesoHogar.AccesoHogarBLL.detalleAccesoHogar(decimal.Parse(idAccesoHogar));

            LitFechaInicio.Text = myAccesoHogar.FechaInicio.ToShortDateString() + " " + myAccesoHogar.HoraInicio.ToString();
            LitFechaTermino.Text = myAccesoHogar.FechaTermino.ToShortDateString() + " " + myAccesoHogar.HoraTermino.ToString();

            LitNombre.Text = YouCom.Service.Generales.Formato.FormatoRut(myAccesoHogar.RutVisita) + " - " + myAccesoHogar.NombreVisita;
            LitEmail.Text = myAccesoHogar.EmailVisita;
            LitTipo.Text = myAccesoHogar.TheTipoVisitaDTO.NombreTipoVisita;
            LitActividad.Text = myAccesoHogar.TheFrecuenciaDTO.NombreFrecuencia;

            IList<YouCom.DTO.AccesoHogar.AccesoHogarDetalleDTO> collAccesoHogarDetalleDTO = new List<YouCom.DTO.AccesoHogar.AccesoHogarDetalleDTO>();

            collAccesoHogarDetalleDTO = YouCom.bll.AccesoHogar.AccesoHogarDetalleBLL.getListadoAccesoHogarDetalleByAcceso(decimal.Parse(idAccesoHogar));

            foreach (YouCom.DTO.AccesoHogar.AccesoHogarDetalleDTO detalle in collAccesoHogarDetalleDTO)
            {
                calendarFechas.SelectedDates.Add(detalle.Fecha);
            }

            this.SelView(this.mvwAutorizaciones.ActiveViewIndex + 2);
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptAutorizaciones_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            HiddenField HdnIdAccesoHogar = (HiddenField)e.Item.FindControl("HdnIdAccesoHogar");

            if (e.CommandName.Equals("Detalle"))
            {
                getObtieneDetalleAcceso(HdnIdAccesoHogar.Value);
            }
            if (e.CommandName.Equals("Eliminar"))
            {
                YouCom.DTO.AccesoHogar.AccesoHogarDTO myAccesoHogarDTO = new YouCom.DTO.AccesoHogar.AccesoHogarDTO();

                myAccesoHogarDTO.IdAccesoHogar = decimal.Parse(HdnIdAccesoHogar.Value);
                myAccesoHogarDTO.UsuarioModificacion = myUsuario.Rut;

                if (YouCom.bll.AccesoHogar.AccesoHogarBLL.Delete(myAccesoHogarDTO))
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Autorización eliminada correctamente.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
            }

            if (e.CommandName.Equals("ListaNegra"))
            {
                YouCom.DTO.AccesoHogar.AccesoHogarDTO theAccesoHogarDTO = new YouCom.DTO.AccesoHogar.AccesoHogarDTO();
                YouCom.DTO.Propietario.FamiliaDTO theFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                theFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                theAccesoHogarDTO = YouCom.bll.AccesoHogar.AccesoHogarBLL.detalleAccesoHogar(decimal.Parse(HdnIdAccesoHogar.Value));

                YouCom.DTO.ListaNegraDTO theListaNegraDTO = new YouCom.DTO.ListaNegraDTO();
                theListaNegraDTO.RutListaNegra = YouCom.Service.Generales.Formato.LimpiarRut(theAccesoHogarDTO.RutVisita.ToUpper());
                theListaNegraDTO.NombreListaNegra = theAccesoHogarDTO.NombreVisita.ToUpper();
                theListaNegraDTO.ApellidoPaternoListaNegra = theAccesoHogarDTO.ApellidoPaternoVisita.ToUpper();
                theListaNegraDTO.ApellidoMaternoListaNegra = theAccesoHogarDTO.ApellidoPaternoVisita.ToUpper();
                theListaNegraDTO.MotivoListaNegra = "";
                theListaNegraDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;
                theListaNegraDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                theListaNegraDTO.TheFamiliaDTO = theFamiliaDTO;
                theListaNegraDTO.UsuarioIngreso = myUsuario.Rut;

                bool respuesta = YouCom.bll.ListaNegraBLL.Insert(theListaNegraDTO);
                if (respuesta)
                {
                    if (YouCom.bll.AccesoHogar.AccesoHogarBLL.Delete(theAccesoHogarDTO))
                    {
                        if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                        {
                            string script = "alert('Autorización agregada como lista negra correctamente.');";
                            script += "parent.location = '" + YouCom.Service.Configuracion.Config.getPageName(true) + "';";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                        }
                    }


                }
                else
                {
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void BntAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            this.SelView(this.mvwAutorizaciones.ActiveViewIndex + 1);
        }
        catch (Exception ex)
        {

        }
    }

    protected void BtnVolver_Click(object sender, EventArgs e)
    {
        try
        {
            if (mvwAutorizaciones.ActiveViewIndex == 2)
            {
                this.SelView(this.mvwAutorizaciones.ActiveViewIndex - 2);
            }
            else
            {
                this.SelView(this.mvwAutorizaciones.ActiveViewIndex - 1);
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected bool setEnviaIngresoHabitual()
    {
        CultureInfo ci = new CultureInfo("Es-Es");
        bool retorno = false;
        bool salida = false;

        YouCom.DTO.AccesoHogar.AccesoHogarDTO theAccesoHogarDTO = new YouCom.DTO.AccesoHogar.AccesoHogarDTO();
        theAccesoHogarDTO.Avisar = "S";
        theAccesoHogarDTO.NombreVisita = this.TxtNombre.Text.ToUpper();
        theAccesoHogarDTO.ApellidoPaternoVisita = this.TxtApellidoPaterno.Text.ToUpper();
        theAccesoHogarDTO.ApellidoMaternoVisita = this.TxtApellidoMaterno.Text.ToUpper();
        theAccesoHogarDTO.EmailVisita = this.TxtEmail.Text.ToUpper();
        theAccesoHogarDTO.RutVisita = YouCom.Service.Formato.Formato.limpiarRut(this.TxtRut.Text);

        theAccesoHogarDTO.TheCasaDTO = myUsuario.TheFamiliaDTO.TheCasaDTO;

        theAccesoHogarDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;
        theAccesoHogarDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;

        YouCom.DTO.AccesoHogar.TipoVisitaDTO myTipoVisitaDTO = new YouCom.DTO.AccesoHogar.TipoVisitaDTO();
        myTipoVisitaDTO.IdTipoVisita = decimal.Parse(this.ddlTipoVisita.SelectedValue);
        theAccesoHogarDTO.TheTipoVisitaDTO = myTipoVisitaDTO;

        YouCom.DTO.AccesoHogar.FrecuenciaDTO myFrecuenciaDTO = new YouCom.DTO.AccesoHogar.FrecuenciaDTO();
        myFrecuenciaDTO.IdFrecuencia = 2;
        theAccesoHogarDTO.TheFrecuenciaDTO = myFrecuenciaDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

        myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
        theAccesoHogarDTO.TheFamiliaDTO = myFamiliaDTO;

        theAccesoHogarDTO.FechaInicio = Convert.ToDateTime(this.TxtFechaInicio.Text);
        theAccesoHogarDTO.FechaTermino = Convert.ToDateTime(this.TxtFechaTermino.Text);

        theAccesoHogarDTO.HoraInicio = ddlHoraInicio.SelectedValue + ":" + ddlMinutoInicio.SelectedValue;
        theAccesoHogarDTO.HoraTermino = ddlHoraTermino.SelectedValue + ":" + ddlMinutoTermino.SelectedValue;

        theAccesoHogarDTO.UsuarioIngreso = myUsuario.Rut;

        retorno = YouCom.bll.AccesoHogar.AccesoHogarBLL.Insert(theAccesoHogarDTO);

        if (retorno)
        {
            DateTime Desde = Convert.ToDateTime(this.TxtFechaInicio.Text);
            DateTime Hasta = Convert.ToDateTime(this.TxtFechaTermino.Text);

            System.TimeSpan diffResultFecha = Desde - Hasta;

            if (diffResultFecha.Days > 0)
            {
                string script = "alert('La fecha desde debe ser menor que la fecha hasta!!!.');";
                script += "parent.location = '" + retorno1 + "';";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
            else
            {
                System.TimeSpan diffResultFechaCarga = Hasta - Desde;

                IList<YouCom.DTO.TrxHorasFechasDTO> ITrxHorasFechas = new List<YouCom.DTO.TrxHorasFechasDTO>();
                ITrxHorasFechas = YouCom.Service.Generales.General.getGeneraFechas(Desde, diffResultFechaCarga.Days + 1, true, false);

                foreach (YouCom.DTO.TrxHorasFechasDTO fecha in ITrxHorasFechas)
                {
                    foreach (ListItem semana in this.rblSemana.Items)
                    {
                        if (semana.Selected)
                        {

                            if (ci.DateTimeFormat.GetDayName(fecha.FechaHora.DayOfWeek).ToUpper() == semana.Text.ToUpper())
                            {
                                YouCom.DTO.AccesoHogar.AccesoHogarDetalleDTO acceso_detalle = new YouCom.DTO.AccesoHogar.AccesoHogarDetalleDTO();

                                acceso_detalle.Fecha = fecha.FechaHora;
                                acceso_detalle.UsuarioIngreso = myUsuario.Rut;

                                YouCom.DTO.AccesoHogar.AccesoHogarDTO myAccesoHogarDTO = new YouCom.DTO.AccesoHogar.AccesoHogarDTO();
                                myAccesoHogarDTO.IdAccesoHogar = theAccesoHogarDTO.IdAccesoHogar;
                                acceso_detalle.TheAccesoHogarDTO = myAccesoHogarDTO;

                                YouCom.bll.AccesoHogar.AccesoHogarDetalleBLL.Insert(acceso_detalle);

                            }
                        }
                    }
                }
            }
        }

        return retorno;

        return retorno;
    }

    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (setEnviaIngresoHabitual())
                {
                    //if (enviarMail())
                    //{
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Estimado Cliente, hemos recibido su mensaje, en breve nos contactaremos con usted.');";
                        script += "parent.location = '" + YouCom.Service.Configuracion.Config.getPageName(true) + "';";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                    //}
                    //else
                    //{
                    //    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    //    {
                    //        string script = "alert('A ocurrido un error. Favor envíe su solicitud al mail contacto@youcom.cl intente más tarde.');";
                    //        script += "parent.location = '" + retorno1 + "';";
                    //        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    //    }
                    //}
                }
                else
                {
                    string script = "alert('A ocurrido un error. Favor envíe su solicitud al mail contacto@youcom.cl intente más tarde.');";
                    script += "parent.location = '" + YouCom.Service.Configuracion.Config.getPageName(true) + "';";
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

        //newhtmlCode = Regex.Replace(newhtmlCode, "{Nombre}", this.TxtNombre.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //newhtmlCode = Regex.Replace(newhtmlCode, "{Paterno}", this.TxtPaterno.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //newhtmlCode = Regex.Replace(newhtmlCode, "{Materno}", this.TxtMaterno.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //newhtmlCode = Regex.Replace(newhtmlCode, "{Telefono}", this.ddlTipoAviso.SelectedItem.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //newhtmlCode = Regex.Replace(newhtmlCode, "{Celular}", this.TxtPrecio.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //newhtmlCode = Regex.Replace(newhtmlCode, "{Titulo}", this.TxtTitulo.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //newhtmlCode = Regex.Replace(newhtmlCode, "{Mensaje}", this.TxtDescripcion.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        return newhtmlCode;
    }

    protected void calendarFechas_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Day.IsSelectable = false;
    }
}