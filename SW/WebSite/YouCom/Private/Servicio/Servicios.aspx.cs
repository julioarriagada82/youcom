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
using System.Collections.Generic;
using YouCom.DTO.Servicio;
using System.Net.Mail;
using System.Text.RegularExpressions;

public partial class Privado_Servicios : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                SelView(0);

                cargarCategoria();

                cargarServicio();
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
        Int32 oIndex = this.mvwServicio.ActiveViewIndex;
        this.mvwServicio.ActiveViewIndex = nIndex;
    }

    protected void cargarCategoria()
    {
        UserControl UCCatergoria = (UserControl)Page.Master.FindControl("ContentPlaceHolder2").FindControl("wucCategoria1");
        Repeater myRepeater = (Repeater)UCCatergoria.FindControl("rptCategoria");

        IList<YouCom.DTO.CategoriaDTO> myCategoria = new List<YouCom.DTO.CategoriaDTO>();

        myCategoria = YouCom.bll.CategoriaBLL.getListadoCategoriaByCondominioByComunidad(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad);

        myCategoria = myCategoria.Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 1 | x.TheTipoCategoriaDTO.IdTipoCategoria == 2).ToList();

        myRepeater.DataSource = myCategoria;
        myRepeater.DataBind();
    }

    protected void cargarServicio()
    {
        IList<ServiciosDTO> myServicioDTO = new List<ServiciosDTO>();

        if (Session["CategoriaServicio"] == null)
            myServicioDTO = YouCom.bll.ServiciosBLL.getListadoServiciosByCondominioByComunidad(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad);
        else
            myServicioDTO = YouCom.bll.ServiciosBLL.getListadoServiciosByCondominioByComunidad(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad).Where(x => x.TheCategoriaDTO.IdCategoria == decimal.Parse(Session["CategoriaServicio"].ToString())).ToList(); ;

        rptServicio.DataSource = myServicioDTO;
        rptServicio.DataBind();

        Session.Remove("CategoriaServicio");
    }

    protected void rptServicio_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                LinkButton myLnkBtnVer = (LinkButton)e.Item.FindControl("LnkBtnVer");

                Image img = (Image)e.Item.FindControl("imgServicio");

                RadioButtonList rdblNotas = new RadioButtonList();
                rdblNotas = (RadioButtonList)e.Item.FindControl("rdblNotas");

                Literal myLitServicioDescripcion = new Literal();
                myLitServicioDescripcion = (Literal)e.Item.FindControl("LitServicioDescripcion");

                LinkButton myLnkBtnVerMas = (LinkButton)e.Item.FindControl("LnkBtnVerMas");

                if (!string.IsNullOrEmpty(((ServiciosDTO)e.Item.DataItem).ImagenServicio) && ((ServiciosDTO)e.Item.DataItem).ImagenServicio.Trim() != "")
                {
                    img.ImageUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathServicioPub") + ((ServiciosDTO)e.Item.DataItem).ImagenServicio;
                    img.AlternateText = ((ServiciosDTO)e.Item.DataItem).NombreServicio;
                    img.ToolTip = ((ServiciosDTO)e.Item.DataItem).NombreServicio;
                }
                else
                {
                    img.ImageUrl = "http://placehold.it/300x200";
                    img.AlternateText = ((ServiciosDTO)e.Item.DataItem).NombreServicio;
                    img.ToolTip = ((ServiciosDTO)e.Item.DataItem).NombreServicio;
                }

                RankingServicioDTO myRankingServicioDTO = new RankingServicioDTO();
                IList<RankingServicioDTO> collRankingServicioDTO = new List<RankingServicioDTO>();
                myRankingServicioDTO = YouCom.bll.RankingServicioBLL.getListadoRankingServicioByFamilia(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad, myUsuario.TheFamiliaDTO.IdFamilia);
                collRankingServicioDTO = YouCom.bll.RankingServicioBLL.getListadoRankingServicioByCondominioByComunidad(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad);

                if (myRankingServicioDTO.TheFamiliaDTO != null)
                {
                    rdblNotas.SelectedIndex = rdblNotas.Items.IndexOf(rdblNotas.Items.FindByValue(myRankingServicioDTO.Nota.ToString()));
                }

                myLnkBtnVer.Text = "<span class=\"glyphicon glyphicon-comment\"></span> (" + collRankingServicioDTO.Count().ToString() + ")";

                if (((YouCom.DTO.Servicio.ServiciosDTO)e.Item.DataItem).DescripcionServicio.Length < 200)
                {
                    myLitServicioDescripcion.Text = ((YouCom.DTO.Servicio.ServiciosDTO)e.Item.DataItem).DescripcionServicio;
                    myLnkBtnVerMas.Visible = false;
                }
                else
                {
                    myLitServicioDescripcion.Text = YouCom.Service.Generales.General.truncaTitulo(((YouCom.DTO.Servicio.ServiciosDTO)e.Item.DataItem).DescripcionServicio, 200);
                    myLnkBtnVerMas.Visible = true;
                }

                myLnkBtnVerMas.Visible = true;
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptServicio_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            HiddenField myHdnIdServicio = (HiddenField)e.Item.FindControl("hdnIdServicio");
            
            TextBox myTxtMensaje = (TextBox)e.Item.FindControl("txtMensaje");

            Repeater myRptRespuestas = (Repeater)e.Item.FindControl("rptRespuestas");

            LinkButton myLnkBtnMeGusta = (LinkButton)e.Item.FindControl("LnkBtnMeGusta");
            LinkButton myLnkBtnNoMeGusta = (LinkButton)e.Item.FindControl("LnkBtnNoMeGusta");
            LinkButton myLnkBtnAgregarComentario = (LinkButton)e.Item.FindControl("LnkBtnAgregarComentario");

            Panel PnlResultado = (Panel)e.Item.FindControl("pnlResultado");
            Panel PnlComentar = (Panel)e.Item.FindControl("pnlComentar");
            Panel pnlMensajes = (Panel)e.Item.FindControl("pnlMensajes");

            Literal LitMensaje = (Literal)e.Item.FindControl("litMensaje");

            if (e.CommandName.Equals("EnviarComentario"))
            {
                

                PnlComentar.Visible = false;
                PnlResultado.Visible = true;
                myTxtMensaje.Text = string.Empty;

                LitMensaje.Text = "<strong>Estimado Usuario,</strong> El comentario ha sido enviado correctamente.";
            }

            if (e.CommandName.Equals("AgregarComentario"))
            {
                if (PnlComentar.Visible)
                {
                    PnlResultado.Visible = false;
                    PnlComentar.Visible = false;
                    myLnkBtnAgregarComentario.Text = "<span class=\"glyphicon glyphicon-pencil\"></span> Agregar Comentario";
                }
                else
                {
                    PnlResultado.Visible = false;
                    PnlComentar.Visible = true;
                    myLnkBtnAgregarComentario.Text = "<span class=\"glyphicon glyphicon-pencil\"></span> Ocultar Comentario";
                }
            }
            if (e.CommandName.Equals("VerDescripcion"))
            {
                Literal myLitServicioDescripcion = new Literal();
                myLitServicioDescripcion = (Literal)e.Item.FindControl("LitServicioDescripcion");

                LinkButton myLnkBtnVerMas = (LinkButton)e.Item.FindControl("LnkBtnVerMas");

                YouCom.DTO.Servicio.ServiciosDTO myServiciosDTO = new YouCom.DTO.Servicio.ServiciosDTO();
                myServiciosDTO = YouCom.bll.ServiciosBLL.detalleServicios(decimal.Parse(myHdnIdServicio.Value));

                myLitServicioDescripcion.Text = myServiciosDTO.DescripcionServicio;
                myLnkBtnVerMas.Visible = false;
            }

            if (e.CommandName.Equals("VerComentarios"))
            {
                //getVerComentarios(decimal.Parse(myHdnIdMensaje.Value), myHdnQuienEnvia.Value, pnlMensajes, myRptRespuestas, myLnkBtnAgregarComentario, false);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptEmpresaServicio_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {                
                

                LinkButton LnkBtnVotar = new LinkButton();
                LnkBtnVotar = (LinkButton)e.Item.FindControl("LnkBtnVotar");

                TextBox txtPromedio = new TextBox();
                txtPromedio = (TextBox)e.Item.FindControl("txtPromedio");


                

                txtPromedio.Text = YouCom.bll.RankingServicioBLL.getNotaByEmpresaServicio(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad, ((EmpresaServicioDTO)e.Item.DataItem).IdEmpresaServicio).ToString();

            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptEmpresaServicio_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Votar")
        {
            HiddenField hdnIdEmpresaServicio = new HiddenField();
            hdnIdEmpresaServicio = (HiddenField)e.Item.FindControl("hdnIdEmpresaServicio");

            RadioButtonList rdblNotas = new RadioButtonList();
            rdblNotas = (RadioButtonList)e.Item.FindControl("rdblNotas");

            bool retorno = false;

            YouCom.DTO.Servicio.RankingServicioDTO theRankingServicioDTO = new YouCom.DTO.Servicio.RankingServicioDTO();

            YouCom.DTO.Servicio.EmpresaServicioDTO myEmpresaServicioDTO = new YouCom.DTO.Servicio.EmpresaServicioDTO();
            myEmpresaServicioDTO.IdEmpresaServicio = decimal.Parse(hdnIdEmpresaServicio.Value);
            theRankingServicioDTO.TheEmpresaServicioDTO = myEmpresaServicioDTO;

            theRankingServicioDTO.Nota = int.Parse(rdblNotas.SelectedValue);
            theRankingServicioDTO.FechaRanking = DateTime.Now;

            theRankingServicioDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
            theRankingServicioDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

            YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

            myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
            theRankingServicioDTO.TheFamiliaDTO = myFamiliaDTO;

            theRankingServicioDTO.UsuarioIngreso = myUsuario.Rut;

            retorno = YouCom.bll.RankingServicioBLL.Insert(theRankingServicioDTO);

            if(retorno)
            {
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Estimado Cliente, hemos recibido su votación, en breve nos contactaremos con usted.');";
                    script += "parent.location = '" + YouCom.Service.Configuracion.Config.getPageName(true) + "';";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
        }
    }
    protected void RblServicio_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RblServicio.SelectedValue == "E")
        {
            pnlEmpresaServicio.Visible = true;
            LitTituloNombre.Text = "Razón Social";
        }
        else if (RblServicio.SelectedValue == "P")
        {
            pnlEmpresaServicio.Visible = false;
            LitTituloNombre.Text = "Nombre";
        }
    }
    protected void txtRutEmpresa_TextChanged(object sender, EventArgs e)
    {
        try
        {
            YouCom.DTO.Servicio.EmpresaServicioDTO theEmpresaServicioDTO = new EmpresaServicioDTO();

            theEmpresaServicioDTO = YouCom.bll.EmpresaServicioBLL.detalleEmpresaServicioByRut(txtRutEmpresa.Text);

            txtNombreEmpresa.Text = theEmpresaServicioDTO.RazonSocialEmpresaServicio;
            txtDireccion.Text = theEmpresaServicioDTO.DireccionEmpresaServicio;

            txtTelefono.Text = theEmpresaServicioDTO.TelefonoEmpresaServicio;
            txtCelular.Text = theEmpresaServicioDTO.CelularEmpresaServicio;
            txtURL.Text = theEmpresaServicioDTO.UrlEmpresaServicio;
            txtEmail.Text = theEmpresaServicioDTO.EmailEmpresaServicio;

            ddlGiro.DataSource = YouCom.bll.GiroBLL.getListadoGiro();
            ddlGiro.DataTextField = "NombreGiro";
            ddlGiro.DataValueField = "IdGiro";
            ddlGiro.DataBind();
            ddlGiro.Items.Insert(0, new ListItem("Seleccione Giro", string.Empty));

            ddlGiro.SelectedIndex = ddlGiro.Items.IndexOf(ddlGiro.Items.FindByValue(theEmpresaServicioDTO.TheGiroDTO.IdGiro.ToString()));

            ddlPais.SelectedIndex = ddlPais.Items.IndexOf(ddlPais.Items.FindByValue(theEmpresaServicioDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.ThePaisDTO.IdPais.ToString()));

            ddlRegion.DataSource = YouCom.bll.RegionBLL.listaRegionByPais(decimal.Parse(ddlPais.SelectedValue));
            ddlRegion.DataTextField = "NombreRegion";
            ddlRegion.DataValueField = "IdRegion";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Seleccione Región", string.Empty));

            ddlRegion.SelectedIndex = ddlRegion.Items.IndexOf(ddlRegion.Items.FindByValue(theEmpresaServicioDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.IdRegion.ToString()));

            ddlCiudad.DataSource = YouCom.bll.RegionBLL.listaRegionByPais(decimal.Parse(ddlRegion.SelectedValue));
            ddlCiudad.DataTextField = "NombreCiudad";
            ddlCiudad.DataValueField = "IdCiudad";
            ddlCiudad.DataBind();
            ddlCiudad.Items.Insert(0, new ListItem("Seleccione Ciudad", string.Empty));

            ddlCiudad.SelectedIndex = ddlCiudad.Items.IndexOf(ddlCiudad.Items.FindByValue(theEmpresaServicioDTO.TheComunaDTO.TheCiudadDTO.IdCiudad.ToString()));

            ddlComuna.DataSource = YouCom.bll.RegionBLL.listaRegionByPais(decimal.Parse(ddlCiudad.SelectedValue));
            ddlComuna.DataTextField = "NombreComuna";
            ddlComuna.DataValueField = "IdComuna";
            ddlComuna.DataBind();
            ddlComuna.Items.Insert(0, new ListItem("Seleccione Comuna", string.Empty));

            ddlComuna.SelectedIndex = ddlCiudad.Items.IndexOf(ddlComuna.Items.FindByValue(theEmpresaServicioDTO.TheComunaDTO.IdComuna.ToString()));

            pnlDatosContratista.Visible = true;
        }
        catch (Exception ex)
        { 
        
        }
    }

    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (setEnviaServicio())
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

    protected bool setEnviaServicio()
    {
        bool retorno = false;
        bool salida = false;

        ServiciosDTO theServiciosDTO = new ServiciosDTO();
        theServiciosDTO.NombreServicio = this.txtServicioNombre.Text.ToUpper();
        theServiciosDTO.DescripcionServicio = this.txtServicioDescripcion.Text.ToUpper();

        theServiciosDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;
        theServiciosDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theServiciosDTO.TheCategoriaDTO = myCategoriaDTO;

        theServiciosDTO.FechaInicio = DateTime.ParseExact(this.FechaInicio.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theServiciosDTO.FechaTermino = DateTime.ParseExact(this.FechaTermino.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

        theServiciosDTO.UsuarioIngreso = myUsuario.Rut;

        retorno = YouCom.bll.ServiciosBLL.Insert(theServiciosDTO);

        if (retorno)
        {

            YouCom.DTO.Servicio.EmpresaServicioDTO theEmpresaServicioDTO = new YouCom.DTO.Servicio.EmpresaServicioDTO();
            theEmpresaServicioDTO.RutEmpresaServicio = this.txtRutEmpresa.Text.ToUpper();
            theEmpresaServicioDTO.RazonSocialEmpresaServicio = this.txtNombreEmpresa.Text.ToUpper();
            theEmpresaServicioDTO.TelefonoEmpresaServicio = this.txtTelefono.Text;
            theEmpresaServicioDTO.UrlEmpresaServicio = this.txtURL.Text;
            theEmpresaServicioDTO.CelularEmpresaServicio = this.txtCelular.Text;
            theEmpresaServicioDTO.DireccionEmpresaServicio = this.txtDireccion.Text;
            theEmpresaServicioDTO.EmailEmpresaServicio = this.txtEmail.Text;

            YouCom.DTO.ComunaDTO myComunaDTO = new YouCom.DTO.ComunaDTO();
            myComunaDTO.IdComuna = decimal.Parse(ddlComuna.SelectedValue);
            theEmpresaServicioDTO.TheComunaDTO = myComunaDTO;

            YouCom.DTO.CiudadDTO myCiudadDTO = new YouCom.DTO.CiudadDTO();
            myCiudadDTO.IdCiudad = decimal.Parse(ddlCiudad.SelectedValue);
            theEmpresaServicioDTO.TheComunaDTO.TheCiudadDTO = myCiudadDTO;

            YouCom.DTO.RegionDTO myRegionDTO = new YouCom.DTO.RegionDTO();
            myRegionDTO.IdRegion = decimal.Parse(ddlRegion.SelectedValue);
            theEmpresaServicioDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO = myRegionDTO;

            YouCom.DTO.PaisDTO myPaisDTO = new YouCom.DTO.PaisDTO();
            myPaisDTO.IdPais = decimal.Parse(ddlPais.SelectedValue);
            theEmpresaServicioDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.ThePaisDTO = myPaisDTO;

            theEmpresaServicioDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;
            theEmpresaServicioDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;

            theEmpresaServicioDTO.TheServiciosDTO = theServiciosDTO;

            if (this.FileImagenServicio.HasFile)
            {
                theEmpresaServicioDTO.LogoEmpresaServicio = this.ProcessOtherFile(FileImagenServicio, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathServiciosPub"));
            }

            salida = YouCom.bll.EmpresaServicioBLL.Insert(theEmpresaServicioDTO);

            salida = true;
        }

        return salida;
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


    protected void BtnVolver_Click(object sender, EventArgs e)
    {
        this.SelView(this.mvwServicio.ActiveViewIndex - 1);
    }

    protected void BntAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            this.SelView(this.mvwServicio.ActiveViewIndex + 1);
        }
        catch (Exception ex)
        {

        }
    }
}
