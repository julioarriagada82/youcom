using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text.RegularExpressions;

public partial class Privado_Comunidad : Intermedia.IMSystem.Navigation.Page.WebPage
{
    private const string retorno1 = "Comunidad.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                SelView(0);
                cargarCategoria();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    void SelView(Int32 nIndex)
    {
        Int32 oIndex = this.mvwAviso.ActiveViewIndex;
        this.mvwAviso.ActiveViewIndex = nIndex;
    }

    protected void cargarCategoria()
    {
        IList<YouCom.DTO.CategoriaDTO> myCategoria = new List<YouCom.DTO.CategoriaDTO>();

        //myCategoria = YouCom.bll.CategoriaBLL.getListadoCategoriaByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        myCategoria = myCategoria.Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 11).ToList();

        rptCategoria.DataSource = myCategoria;
        rptCategoria.DataBind();
    }

    protected void rptCategoria_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.CategoriaDTO)e.Item.DataItem).NombreCategoria))
                {
                    Repeater myRepeater = new Repeater();

                    myRepeater = (Repeater)e.Item.FindControl("rptForoComunidad");

                    IList<YouCom.DTO.Foro.ForoComunidadDTO> myForoComunidad = new List<YouCom.DTO.Foro.ForoComunidadDTO>();

                    myForoComunidad = YouCom.bll.ForoComunidadBLL.listaForoComunidadActivo();

                    if(myForoComunidad.Any())
                    {
                        myForoComunidad = myForoComunidad.Where(x => x.TheCategoriaDTO.IdCategoria == ((YouCom.DTO.CategoriaDTO)e.Item.DataItem).IdCategoria && x.IdPadre == 0).ToList();

                        myRepeater.DataSource = myForoComunidad;
                        myRepeater.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptForoComunidad_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                Literal myLiteral = new Literal();
                myLiteral = (Literal)e.Item.FindControl("LitRespuestas");

                IList<YouCom.DTO.Foro.ForoComunidadDTO> myForoComunidad = new List<YouCom.DTO.Foro.ForoComunidadDTO>();

                myForoComunidad = YouCom.bll.ForoComunidadBLL.listaForoComunidadActivo();

                if (myForoComunidad.Any())
                {
                    myForoComunidad = myForoComunidad.Where(x => x.IdPadre == ((YouCom.DTO.Foro.ForoComunidadDTO)e.Item.DataItem).IdForoComunidad).ToList();

                    myLiteral.Text = myForoComunidad.Count().ToString();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptForoComunidad_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Detalle"))
            {
                HiddenField myHidIdForo = (HiddenField)e.Item.FindControl("HidIdForoComunidad");

                HdnIdForoComunidad.Value = myHidIdForo.Value;

                YouCom.DTO.Foro.ForoComunidadDTO myForoComunidadDTO = new YouCom.DTO.Foro.ForoComunidadDTO();
                myForoComunidadDTO = YouCom.bll.ForoComunidadBLL.detalleForoComunidad(decimal.Parse(myHidIdForo.Value));

                LitForoComunidadTitulo.Text = myForoComunidadDTO.TituloForoComunidad;
                LitForoComunidadDetalle.Text = myForoComunidadDTO.DescripcionForoComunidad;

                cargarComentarioForoComunidad();

                this.SelView(this.mvwAviso.ActiveViewIndex + 1);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void cargarComentarioForoComunidad()
    {
        IList<YouCom.DTO.Foro.ForoComunidadDTO> myForoComunidadDTO = new List<YouCom.DTO.Foro.ForoComunidadDTO>();

        myForoComunidadDTO = YouCom.bll.ForoComunidadBLL.listaForoComunidadActivo();

        if(myForoComunidadDTO.Any())
        {
            myForoComunidadDTO = myForoComunidadDTO.Where(x => x.IdPadre == decimal.Parse(this.HdnIdForoComunidad.Value)).ToList();

            this.rptComentarios.DataSource = myForoComunidadDTO;
            this.rptComentarios.DataBind();
        }
    }

    protected void rptComentarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                Literal LitNombreConsultante = (Literal)e.Item.FindControl("LitNombreConsultante");
                Literal LitCantidadRespuestas = (Literal)e.Item.FindControl("LitCantidadRespuestas");

                YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamilia(((YouCom.DTO.Avisos.ComentarioAvisoDTO)e.Item.DataItem).TheFamiliaDTO.IdFamilia);

                LitNombreConsultante.Text = myFamiliaDTO.NombreCompleto;

                IList<YouCom.DTO.Avisos.ComentarioAvisoDTO> myComentarioAvisoDTO = new List<YouCom.DTO.Avisos.ComentarioAvisoDTO>();

                myComentarioAvisoDTO = YouCom.bll.Avisos.ComentarioAvisoBLL.listaComentarioAvisoActivo();

                LitCantidadRespuestas.Text = myComentarioAvisoDTO.Count().ToString();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void LnkBtnIngresaRespuesta_Click(object sender, EventArgs e)
    {
        this.SelView(this.mvwAviso.ActiveViewIndex + 1);
    }

    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                YouCom.DTO.Foro.ForoComunidadDTO theForoComunidadDTO = new YouCom.DTO.Foro.ForoComunidadDTO();

                YouCom.DTO.Foro.ForoComunidadDTO myForoComunidadDTO = new YouCom.DTO.Foro.ForoComunidadDTO();
                myForoComunidadDTO = YouCom.bll.ForoComunidadBLL.detalleForoComunidad(decimal.Parse(this.HdnIdForoComunidad.Value));

                theForoComunidadDTO.TituloForoComunidad = myForoComunidadDTO.TituloForoComunidad;
                theForoComunidadDTO.DescripcionForoComunidad = this.TxtComentarios.Text.ToUpper();
                theForoComunidadDTO.FechaForoComunidad = DateTime.Now;
                theForoComunidadDTO.IdPadre = myForoComunidadDTO.IdForoComunidad;

                theForoComunidadDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                theForoComunidadDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                theForoComunidadDTO.TheFamiliaDTO = myFamiliaDTO;

                YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                myCategoriaDTO.IdCategoria = myForoComunidadDTO.TheCategoriaDTO.IdCategoria;
                theForoComunidadDTO.TheCategoriaDTO = myCategoriaDTO;

                YouCom.DTO.Foro.ForoComunidadEstadoDTO myForoComunidadEstadoDTO = new YouCom.DTO.Foro.ForoComunidadEstadoDTO();
                myForoComunidadEstadoDTO.IdForoComunidadEstado = 2;
                theForoComunidadDTO.TheForoComunidadEstadoDTO = myForoComunidadEstadoDTO;

                theForoComunidadDTO.UsuarioIngreso = myUsuario.Rut;

                bool respuesta = YouCom.bll.ForoComunidadBLL.Insert(theForoComunidadDTO);

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
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected bool enviarMail()
    {
        try
        {
            //string[] _server = YouCom.Service.Generales.General.GetPropiedad("SMTP").Split(new Char[] { ';' });
            //string[] _to = YouCom.Service.Generales.General.GetPropiedad("MAILTOCONTACTO").Split(new Char[] { ';' });
            //string[] _from = YouCom.Service.Generales.General.GetPropiedad("MAILFROM").Split(new Char[] { ';' });

            //System.Net.Mail.MailMessage _mail = new System.Net.Mail.MailMessage();

            //_mail.From = new MailAddress(_from[0], _from[1], System.Text.Encoding.UTF8);
            //_mail.To.Add(new MailAddress(_to[0], _to[1], System.Text.Encoding.UTF8));

            //_mail.Subject = "Contacto " + " " + DateTime.Now.ToString("D");

            //_mail.SubjectEncoding = System.Text.Encoding.UTF8;
            //_mail.Body = this.creaCuerpo().Replace("ï»¿", "");

            //_mail.BodyEncoding = System.Text.Encoding.UTF8;
            //_mail.IsBodyHtml = true;

            //SmtpClient _smtp = new SmtpClient();

            //_smtp.Send(_mail);
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

        newhtmlCode = Regex.Replace(newhtmlCode, "{Nombre}", this.LitNombre.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Email}", this.TxtEmail.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Mensaje}", this.TxtComentarios.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        return newhtmlCode;
    }

    protected void BntAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AgregarForo.aspx", false);
        }
        catch (Exception ex)
        {

        }
    }
}
