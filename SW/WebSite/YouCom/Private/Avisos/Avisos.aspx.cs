using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Web.UI.HtmlControls;

public partial class Privado_Avisos : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                SelView(0);

                if(Session["idAviso"] != null)
                {
                    getObtieneDetalleAviso(Session["idAviso"].ToString());

                    Session.Remove("idAviso");
                }
                else
                {
                    cargarCategoria();

                    cargarAviso();
                }
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void cargarCategoria()
    {
        UserControl UCCatergoria = (UserControl)Page.Master.FindControl("ContentPlaceHolder2").FindControl("wucCategoria1");
        Repeater myRepeater = (Repeater)UCCatergoria.FindControl("rptCategoria");

        IList<YouCom.DTO.CategoriaDTO> myCategoria = new List<YouCom.DTO.CategoriaDTO>();

        myCategoria = YouCom.bll.CategoriaBLL.listaCategoriaActivo();

        myCategoria = myCategoria.Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 8).ToList();

        myRepeater.DataSource = myCategoria;
        myRepeater.DataBind();
    }

    void SelView(Int32 nIndex)
    {
        Int32 oIndex = this.mvwAviso.ActiveViewIndex;
        this.mvwAviso.ActiveViewIndex = nIndex;
    }

    protected void cargarAviso()
    {
        IList<YouCom.DTO.Avisos.AvisoDTO> myAvisosDTO = new List<YouCom.DTO.Avisos.AvisoDTO>();

        if (Session["CategoriaAviso"] == null)
            myAvisosDTO = YouCom.bll.Avisos.AvisoBLL.getListadoAvisoByCondominioByComunidadVigentes(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad);
        else
            myAvisosDTO = YouCom.bll.Avisos.AvisoBLL.getListadoAvisoByCondominioByComunidadVigentes(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad).Where(x => x.TheCategoriaDTO.IdCategoria == decimal.Parse(Session["CategoriaAviso"].ToString())).ToList(); ;
        
        rptAviso.DataSource = myAvisosDTO;
        rptAviso.DataBind();

        Session.Remove("CategoriaAviso");
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

                    myRepeater = (Repeater)e.Item.FindControl("rptAviso");

                    IList<YouCom.DTO.Avisos.AvisoDTO> myAvisos = new List<YouCom.DTO.Avisos.AvisoDTO>();

                    myAvisos = YouCom.bll.Avisos.AvisoBLL.listaAvisosActivo();

                    myAvisos = myAvisos.Where(x => x.TheCategoriaDTO.IdCategoria == ((YouCom.DTO.CategoriaDTO)e.Item.DataItem).IdCategoria && x.TheAvisosEstadoDTO.IdAvisoEstado == 3).ToList();

                    myRepeater.DataSource = myAvisos;
                    myRepeater.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    
    protected void rptAviso_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                Image img = (Image)e.Item.FindControl("imgLogo");

                if (!string.IsNullOrEmpty(((YouCom.DTO.Avisos.AvisoDTO)e.Item.DataItem).ImagenAviso) && ((YouCom.DTO.Avisos.AvisoDTO)e.Item.DataItem).ImagenAviso.Trim() != "")
                {
                    img.ImageUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathAvisosPub") + ((YouCom.DTO.Avisos.AvisoDTO)e.Item.DataItem).ImagenAviso;
                    img.AlternateText = ((YouCom.DTO.Avisos.AvisoDTO)e.Item.DataItem).TituloAviso;
                    img.ToolTip = ((YouCom.DTO.Avisos.AvisoDTO)e.Item.DataItem).TituloAviso;
                }
                else
                {
                    img.ImageUrl = "http://placehold.it/300x200";
                    img.AlternateText = ((YouCom.DTO.Avisos.AvisoDTO)e.Item.DataItem).TituloAviso;
                    img.ToolTip = ((YouCom.DTO.Avisos.AvisoDTO)e.Item.DataItem).TituloAviso;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptAviso_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Detalle"))
            {
                HiddenField myHidIdAviso = (HiddenField)e.Item.FindControl("HidIdAviso");

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

            this.SelView(this.mvwAviso.ActiveViewIndex + 1);
        }
        catch(Exception ex)
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
        catch(Exception ex)
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

            myAvisoDTO.FechaCompra =DateTime.Now;

            bool respuesta = YouCom.bll.Avisos.AvisoBLL.Update(myAvisoDTO);

            if(respuesta)
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
        catch(Exception ex)
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
