using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Privado_Mercado_MisCompras : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SelView(0);
            cargarCompras();
        }
    }


    void SelView(Int32 nIndex)
    {
        Int32 oIndex = this.mvwCompras.ActiveViewIndex;
        this.mvwCompras.ActiveViewIndex = nIndex;
    }

    protected void cargarCompras()
    {
        IList<YouCom.DTO.Avisos.AvisoDTO> myAvisosDTO = new List<YouCom.DTO.Avisos.AvisoDTO>();

        //myAvisosDTO = YouCom.bll.Avisos.AvisoBLL.getListadoAvisoByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        if (myAvisosDTO.Any())
        {
            rptCompras.DataSource = myAvisosDTO.Where(x => x.RutComprador == myUsuario.Rut).ToList();
            rptCompras.DataBind();
        }
    }
    
    protected void rptCompras_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Detalle"))
            {
                HiddenField myHidIdAviso = (HiddenField)e.Item.FindControl("HdnIdAviso");

                HdnIdAviso.Value = myHidIdAviso.Value;

                getObtieneDetalleAviso(myHidIdAviso.Value);
            }
        }
        catch (Exception ex)
        {

        }
    }


    protected void getObtieneDetalleAviso(string idAviso)
    {
        try
        {
            YouCom.DTO.Avisos.AvisoDTO myAvisoDTO = new YouCom.DTO.Avisos.AvisoDTO();
            myAvisoDTO = YouCom.bll.Avisos.AvisoBLL.detalleAviso(decimal.Parse(idAviso));

            LitAvisoTitulo.Text = myAvisoDTO.TituloAviso;
            LitAvisoDetalle.Text = myAvisoDTO.DescripcionAviso;
            LitPrecio.Text = YouCom.Service.Generales.Formato.FormatoMontoPesoSinReplace(myAvisoDTO.PrecioAviso.ToString(), true);

            YouCom.DTO.Avisos.TipoAvisoDTO myTipoAvisoDTO = new YouCom.DTO.Avisos.TipoAvisoDTO();
            myTipoAvisoDTO = YouCom.bll.Avisos.TipoAvisoBLL.detalleTipoAviso(myAvisoDTO.TheTipoAvisoDTO.IdTipoAviso);

            LitTipo.Text = myTipoAvisoDTO.NombreTipoAviso;
            LitFechaPublicacion.Text = myAvisoDTO.FechaPublicacion.ToString();
            LitFechaTermino.Text = myAvisoDTO.FechaTermino.ToShortDateString();

            YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
            myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamilia(myAvisoDTO.TheFamiliaDTO.IdFamilia);

            LitContacto.Text = myFamiliaDTO.NombreCompleto;

            cargarComentarioAvisos(decimal.Parse(idAviso));

            IList<YouCom.DTO.Avisos.ImagenAvisoDTO> myImagenAvisoDTO = new List<YouCom.DTO.Avisos.ImagenAvisoDTO>();
            myImagenAvisoDTO = YouCom.bll.Avisos.ImagenAvisoBLL.getListadoImagenAvisoByIdAviso(decimal.Parse(idAviso));

            if (myImagenAvisoDTO.Any())
            {
                rptIndicadorCarrusel.DataSource = myImagenAvisoDTO;
                rptIndicadorCarrusel.DataBind();

                rptGaleriaAvisos.DataSource = myImagenAvisoDTO;
                rptGaleriaAvisos.DataBind();
            }
            else
            {
                pnlCarrusel.Visible = false;
            }

            this.SelView(this.mvwCompras.ActiveViewIndex + 1);
        }
        catch (Exception ex)
        { }
    }

    protected void cargarComentarioAvisos(decimal idAviso)
    {
        IList<YouCom.DTO.Avisos.ComentarioAvisoDTO> myComentarioAviso = new List<YouCom.DTO.Avisos.ComentarioAvisoDTO>();
        myComentarioAviso = YouCom.bll.Avisos.ComentarioAvisoBLL.getListadoComentarioAvisoByAviso(idAviso);

        this.rptComentarios.DataSource = myComentarioAviso;
        this.rptComentarios.DataBind();
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
                myComentarioAvisoDTO = YouCom.bll.Avisos.ComentarioAvisoBLL.getListadoComentarioAvisoByComentario(((YouCom.DTO.Avisos.ComentarioAvisoDTO)e.Item.DataItem).IdComentarioAviso);

                LitCantidadRespuestas.Text = myComentarioAvisoDTO.Count().ToString();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void LnkBtnIngresaComentario_Click(object sender, EventArgs e)
    {
        PnlComentar.Visible = true;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

        myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);

        this.LitNombre.Text = myFamiliaDTO.NombreFamilia + " " + myFamiliaDTO.ApellidoPaternoFamilia + " " + myFamiliaDTO.ApellidoMaternoFamilia;
        this.TxtEmail.Text = myFamiliaDTO.EmailFamilia;
    }

    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                YouCom.DTO.Avisos.ComentarioAvisoDTO theComentarioAvisoDTO = new YouCom.DTO.Avisos.ComentarioAvisoDTO();

                YouCom.DTO.Avisos.AvisoDTO myAvisosDTO = new YouCom.DTO.Avisos.AvisoDTO();
                myAvisosDTO.IdAviso = decimal.Parse(this.HdnIdAviso.Value);
                theComentarioAvisoDTO.TheAvisosDTO = myAvisosDTO;

                theComentarioAvisoDTO.ComentarioAviso = this.TxtComentarios.Text.ToUpper();
                theComentarioAvisoDTO.EmailComentarioAviso = this.TxtEmail.Text.ToUpper();
                theComentarioAvisoDTO.FechaComentarioAviso = DateTime.Now;

                theComentarioAvisoDTO.IdPadre = 0;

                YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);

                theComentarioAvisoDTO.TheFamiliaDTO = myFamiliaDTO;

                theComentarioAvisoDTO.UsuarioIngreso = myUsuario.Rut;
                theComentarioAvisoDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;
                theComentarioAvisoDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;

                bool respuesta = YouCom.bll.Avisos.ComentarioAvisoBLL.Insert(theComentarioAvisoDTO);

                if (respuesta)
                {
                    cargarComentarioAvisos(decimal.Parse(HdnIdAviso.Value));

                    PnlComentar.Visible = false;
                    pnlResultado.Visible = true;

                    litMensaje.Text = "<strong>Estimado Usuario,</strong> El comentario ha sido enviado correctamente.";
                }
                else
                {
                    PnlComentar.Visible = false;
                    pnlResultado.Visible = true;

                    litMensaje.Text = "<strong>Estimado Usuario,</strong> Ha ocurrido un error al momento de enviar el comentario.";
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

        newhtmlCode = Regex.Replace(newhtmlCode, "{Nombre}", this.LitNombre.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Email}", this.TxtEmail.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        newhtmlCode = Regex.Replace(newhtmlCode, "{Mensaje}", this.TxtComentarios.Text, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        return newhtmlCode;
    }
    protected void BntAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AgregarAviso.aspx", false);
        }
        catch (Exception ex)
        {

        }
    }

    protected void LnkBtnComprar_Click(object sender, EventArgs e)
    {
        try
        {
            YouCom.DTO.Avisos.AvisoDTO myAvisoDTO = new YouCom.DTO.Avisos.AvisoDTO();
            myAvisoDTO = YouCom.bll.Avisos.AvisoBLL.detalleAviso(decimal.Parse(this.HdnIdAviso.Value));

            YouCom.DTO.Avisos.AvisoEstadoDTO myAvisoEstadoDTO = new YouCom.DTO.Avisos.AvisoEstadoDTO();
            myAvisoEstadoDTO.IdAvisoEstado = 4;
            myAvisoDTO.TheAvisosEstadoDTO = myAvisoEstadoDTO;
            myAvisoDTO.RutComprador = myUsuario.Rut;

            myAvisoDTO.FechaCompra = DateTime.Now;

            bool respuesta = YouCom.bll.Avisos.AvisoBLL.Update(myAvisoDTO);

            if (respuesta)
            {
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Estimado Cliente,se ha confirmado la compra, el publicador del aviso se contactara con usted para cerrar la compra.');";
                    script += "parent.location = '" + YouCom.Service.Configuracion.Config.getPageName(true) + "';";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('A ocurrido un error. Favor envíe su solicitud al mail contacto@youcom.cl intente más tarde.');";
                    script += "parent.location = '" + YouCom.Service.Configuracion.Config.getPageName(true) + "';";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }


        }
        catch (Exception ex)
        {

        }
    }

    protected void rptIndicadorCarrusel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                HtmlGenericControl li_mensaje = new HtmlGenericControl();
                li_mensaje = (HtmlGenericControl)e.Item.FindControl("li_mensaje");

                if (e.Item.ItemIndex == 0)
                {
                    li_mensaje.Attributes.Add("class", "active");
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptGaleriaAvisos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {

                HtmlGenericControl div_mensaje = new HtmlGenericControl();
                div_mensaje = (HtmlGenericControl)e.Item.FindControl("div_mensaje");

                if (e.Item.ItemIndex == 0)
                {
                    div_mensaje.Attributes.Add("class", "item active");
                }
                else
                {
                    div_mensaje.Attributes.Add("class", "item");
                }

                if (!string.IsNullOrEmpty(((YouCom.DTO.Avisos.ImagenAvisoDTO)e.Item.DataItem).IdImagenAviso.ToString()))
                {
                    string ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathAvisosPub");

                    ImageButton img = (ImageButton)e.Item.FindControl("imgAviso");

                    if (!string.IsNullOrEmpty(((YouCom.DTO.Avisos.ImagenAvisoDTO)e.Item.DataItem).GrandeImagenAviso) && ((YouCom.DTO.Avisos.ImagenAvisoDTO)e.Item.DataItem).GrandeImagenAviso.Trim() != "")
                    {
                        img.ImageUrl = ruta + ((YouCom.DTO.Avisos.ImagenAvisoDTO)e.Item.DataItem).GrandeImagenAviso;
                        img.AlternateText = ((YouCom.DTO.Avisos.ImagenAvisoDTO)e.Item.DataItem).TituloImagenAviso;
                        img.ToolTip = ((YouCom.DTO.Avisos.ImagenAvisoDTO)e.Item.DataItem).TituloImagenAviso;
                    }
                    else
                    {
                        img.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}