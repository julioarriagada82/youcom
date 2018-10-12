using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MNoticia : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FCKeditorDetalle.BasePath = this.GetBasePath();
            FCKeditorDetalle.Config["AutoDetectLanguage"] = "true";
            FCKeditorDetalle.Config["DefaultLanguage"] = "es";

            cargarNoticia();
            cargarCategoria();
        }
    }

    protected void cargarNoticia()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["noticia"] = YouCom.bll.NoticiaBLL.listaNoticiaActivo();
            rptNoticia.DataSource = YouCom.bll.NoticiaBLL.listaNoticiaActivo();
            rptNoticia.DataBind();

        }
        else
        {
            Session["noticia"] = YouCom.bll.NoticiaBLL.listaNoticiaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptNoticia.DataSource = YouCom.bll.NoticiaBLL.listaNoticiaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptNoticia.DataBind();
        }

    }

    protected void cargarCategoria()
    {
        IList<YouCom.DTO.CategoriaDTO> myCategoria = new List<YouCom.DTO.CategoriaDTO>();

        myCategoria = YouCom.bll.CategoriaBLL.listaCategoriaActivo();

        myCategoria = myCategoria.Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 4).ToList();

        ddlCategoria.DataSource = myCategoria;
        ddlCategoria.DataTextField = "NombreCategoria";
        ddlCategoria.DataValueField = "IdCategoria";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, new ListItem("Seleccione Categoria", string.Empty));
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionNoticia.Visible = false;
        cargarNoticiaInactivo();
    }
    protected void cargarNoticiaInactivo()
    {
        IList<NoticiaDTO> noticia = new List<NoticiaDTO>();
        noticia = YouCom.bll.NoticiaBLL.listaNoticiaInactivo();
        if (noticia.Any())
        {
            rptNoticiaInactivo.DataSource = noticia;
            rptNoticiaInactivo.DataBind();
        }
        else
        {
            string script = "alert('No existen registros en  papelera .');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            return;

        }


    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        List<NoticiaDTO> noticias = new List<NoticiaDTO>();
        noticias = (Session["noticia"] as List<NoticiaDTO>);

        NoticiaDTO theNoticiaDTO = new NoticiaDTO();
        theNoticiaDTO.NotiTitulo = this.txtNoticiaTitulo.Text.ToUpper();
        theNoticiaDTO.NotiResumen = this.txtNoticiaResumen.Text.ToUpper();
        theNoticiaDTO.NotiDetalle = this.FCKeditorDetalle.Value;
        theNoticiaDTO.NotiAutor = this.TxtNotiAutor.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theNoticiaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theNoticiaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theNoticiaDTO.TheCategoriaDTO = myCategoriaDTO;

        theNoticiaDTO.UsuarioIngreso = myUsuario.Rut;

        if (this.FileImagenNoticia.HasFile)
        {
            if (System.IO.Path.GetExtension(FileImagenNoticia.PostedFile.FileName) == ".swf")
                theNoticiaDTO.NotiImagen = this.ProcessOtherFile(FileImagenNoticia, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathNoticiaPub"));
            else
                theNoticiaDTO.NotiImagen = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenNoticia, YouCom.Service.Generales.General.GetPropiedad("UploadsPathNoticiaPub"), 198, 118, Page);
        }

        theNoticiaDTO.NotiPublicacion = DateTime.ParseExact(this.FechaPublicacion.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theNoticiaDTO.NotiInicio = DateTime.ParseExact(this.FechaPublicacion.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

        theNoticiaDTO.NotiExpira = string.Copy(RdbNotiExpira.SelectedItem.Value);

        if (RdbNotiExpira.SelectedValue.Equals("S"))
            theNoticiaDTO.NotiExpiracion = DateTime.ParseExact(this.FechaExpiracion.Text + " 00:00", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        else
            theNoticiaDTO.NotiExpiracion = DateTime.MaxValue;

        noticias = noticias.Where(x => x.NotiTitulo == theNoticiaDTO.NotiTitulo).ToList();
        if (noticias.Any())
        {
            foreach (var item in noticias)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Noticia existe pero fue eliminado para activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Noticia ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.NoticiaBLL.Insert(theNoticiaDTO);
        if (respuesta)
        {
            this.TxtNotiAutor.Text = string.Empty;
            this.txtNoticiaTitulo.Text = string.Empty;
            this.txtNoticiaResumen.Text = string.Empty;
            string script = "alert('Noticia ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarNoticia();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        NoticiaDTO theNoticiaDTO = new NoticiaDTO();
        theNoticiaDTO.NoticiaId = decimal.Parse(this.hdnNoticiaId.Value);
        theNoticiaDTO.NotiTitulo = this.txtNoticiaTitulo.Text.ToUpper();
        theNoticiaDTO.NotiResumen = this.txtNoticiaResumen.Text.ToUpper();
        theNoticiaDTO.NotiDetalle = this.FCKeditorDetalle.Value;
        theNoticiaDTO.NotiAutor = this.TxtNotiAutor.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theNoticiaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theNoticiaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theNoticiaDTO.TheCategoriaDTO = myCategoriaDTO;

        theNoticiaDTO.UsuarioModificacion = myUsuario.Rut;

        if (this.FileImagenNoticia.HasFile)
        {
            theNoticiaDTO.NotiImagen = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenNoticia, YouCom.Service.Generales.General.GetPropiedad("UploadsPathBann"), 198, 118, Page);
        }
        else
        {
            YouCom.DTO.NoticiaDTO myNoticiaDTO = new YouCom.DTO.NoticiaDTO();
            myNoticiaDTO = YouCom.bll.NoticiaBLL.detalleNoticia(decimal.Parse(hdnNoticiaId.Value));

            theNoticiaDTO.NotiImagen = myNoticiaDTO.NotiImagen;
        }


        theNoticiaDTO.NotiPublicacion = DateTime.ParseExact(this.FechaPublicacion.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theNoticiaDTO.NotiInicio = DateTime.ParseExact(this.FechaPublicacion.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

        theNoticiaDTO.NotiExpira = string.Copy(RdbNotiExpira.SelectedItem.Value);

        if (RdbNotiExpira.SelectedValue.Equals("S"))
            theNoticiaDTO.NotiExpiracion = DateTime.ParseExact(this.FechaExpiracion.Text + " 00:00", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        else
            theNoticiaDTO.NotiExpiracion = DateTime.MaxValue;

        bool respuesta = YouCom.bll.NoticiaBLL.Update(theNoticiaDTO);

        if (respuesta)
        {
            cargarNoticia();
            this.TxtNotiAutor.Text = string.Empty;
            this.txtNoticiaTitulo.Text = string.Empty;
            this.txtNoticiaResumen.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Noticia editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptNoticiaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnNoticiaId = new HiddenField();
            hdnNoticiaId = (HiddenField)e.Item.FindControl("hdnNoticiaId");

            NoticiaDTO theNoticiaDTO = new NoticiaDTO();
            theNoticiaDTO.NoticiaId = decimal.Parse(hdnNoticiaId.Value);
            theNoticiaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.NoticiaBLL.ActivaNoticia(theNoticiaDTO);
            if (respuesta)
            {
                cargarNoticiaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Noticia activada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptNoticia_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnNoticiaId = new HiddenField();
            hdnNoticiaId = (HiddenField)e.Item.FindControl("hdnNoticiaId");

            YouCom.DTO.NoticiaDTO theNoticiaDTO = new YouCom.DTO.NoticiaDTO();
            theNoticiaDTO = YouCom.bll.NoticiaBLL.detalleNoticia(decimal.Parse(hdnNoticiaId.Value));

            this.hdnNoticiaId.Value = theNoticiaDTO.NoticiaId.ToString();
            txtNoticiaTitulo.Text = theNoticiaDTO.NotiTitulo;
            txtNoticiaResumen.Text = theNoticiaDTO.NotiResumen;
            FCKeditorDetalle.Value = theNoticiaDTO.NotiDetalle;
            TxtNotiAutor.Text = theNoticiaDTO.NotiAutor;

            this.FechaPublicacion.Text = theNoticiaDTO.NotiPublicacion.ToShortDateString();
            this.FechaExpiracion.Text = theNoticiaDTO.NotiExpiracion.ToShortDateString();

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(theNoticiaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(theNoticiaDTO.TheComunidadDTO.IdComunidad.ToString()));

            ddlCategoria.SelectedIndex = ddlCategoria.Items.IndexOf(ddlCategoria.Items.FindByValue(theNoticiaDTO.TheCategoriaDTO.IdCategoria.ToString()));

            RdbNotiExpira.SelectedIndex = RdbNotiExpira.Items.IndexOf(RdbNotiExpira.Items.FindByValue(theNoticiaDTO.NotiExpira.ToString()));

            if (!string.IsNullOrEmpty(theNoticiaDTO.NotiImagen))
            {
                this.lnkImagen.Visible = true;
                this.chkImagen.Visible = true;
                this.lnkImagen.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathNoticiaPub") + theNoticiaDTO.NotiImagen;
            }


            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnNoticiaId = new HiddenField();
            hdnNoticiaId = (HiddenField)e.Item.FindControl("hdnNoticiaId");

            NoticiaDTO theNoticiaDTO = new NoticiaDTO();
            theNoticiaDTO.NoticiaId = decimal.Parse(hdnNoticiaId.Value);
            theNoticiaDTO.UsuarioModificacion = myUsuario.Rut;

            bool respuesta = YouCom.bll.NoticiaBLL.Delete(theNoticiaDTO);
            if (respuesta)
            {
                cargarNoticia();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Noticia Eliminada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }
    }

    protected void RdbNotiExpira_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbNotiExpira.SelectedValue.Equals("S"))
            pnlExpira.Visible = true;
        else
            pnlExpira.Visible = false;
    }
    void MuestraPanelError(bool wvarGeneric, bool wvarProducto, bool wvarSinProducto)
    {
        pnlGenericError.Visible = wvarGeneric;
        pnlProducto.Visible = wvarProducto;
        pnlSinProducto.Visible = wvarSinProducto;
    }
    void MuestraError(Exception ex)
    {
        HttpContext.Current.Session.Add("usuario", myUsuario);

        //Banner Central
        UserControl UCBanner = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl(YouCom.Service.Configuracion.General.getPageName(false) + "1").FindControl("BannerCentral1");
        Literal myLiteral = (Literal)UCBanner.FindControl("LitMensaje");
        HyperLink myHyperLink = (HyperLink)UCBanner.FindControl("HnlVolver");

        MuestraPanelError(false, false, true);

        myHyperLink.NavigateUrl = "/Private/" + YouCom.Service.Configuracion.General.getPageName(true);
        myLiteral.Text = YouCom.Web.KtErrores.MuestraError(myUsuario, ex, "MS_IB - Consulta Pizarra Autorizaciones", "http://" + Request.Url.Authority + ResolveUrl("~/") + YouCom.Service.Configuracion.General.getPageName(true));
    }
}
