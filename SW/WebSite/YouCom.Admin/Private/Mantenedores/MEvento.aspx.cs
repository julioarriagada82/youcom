using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MEvento : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FCKeditorDetalle.BasePath = this.GetBasePath();
            FCKeditorDetalle.Config["AutoDetectLanguage"] = "true";
            FCKeditorDetalle.Config["DefaultLanguage"] = "es";

            cargarEvento();
            cargarCategoria();
        }
    }

    protected void cargarEvento()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["Evento"] = YouCom.bll.EventoBLL.listaEventoActivo();
            rptEvento.DataSource = YouCom.bll.EventoBLL.listaEventoActivo();
            rptEvento.DataBind();
        }
        else
        {
            Session["Evento"] = YouCom.bll.EventoBLL.listaEventoActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptEvento.DataSource = YouCom.bll.EventoBLL.listaEventoActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptEvento.DataBind();
        }
    }

    protected void cargarCategoria()
    {
        IList<YouCom.DTO.CategoriaDTO> myCategoria = new List<YouCom.DTO.CategoriaDTO>();

        myCategoria = YouCom.bll.CategoriaBLL.listaCategoriaActivo();

        myCategoria = myCategoria.Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 9).ToList();

        ddlCategoria.DataSource = myCategoria;
        ddlCategoria.DataTextField = "NombreCategoria";
        ddlCategoria.DataValueField = "IdCategoria";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, new ListItem("Seleccione Categoria", string.Empty));
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionEvento.Visible = false;
        cargarEventoInactivo();
    }
    protected void cargarEventoInactivo()
    {
        IList<EventoDTO> Evento = new List<EventoDTO>();
        Evento = YouCom.bll.EventoBLL.listaEventoInactivo();
        if (Evento.Any())
        {
            rptEventoInactivo.DataSource = Evento;
            rptEventoInactivo.DataBind();
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

        List<EventoDTO> eventos = new List<EventoDTO>();
        eventos = (Session["evento"] as List<EventoDTO>);

        EventoDTO theEventoDTO = new EventoDTO();
        theEventoDTO.EventoTitulo = this.txtEventoTitulo.Text.ToUpper();
        theEventoDTO.EventoResumen = this.txtEventoResumen.Text.ToUpper();
        theEventoDTO.EventoDetalle = this.FCKeditorDetalle.Value;
        theEventoDTO.EventoAutor = this.TxtNotiAutor.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theEventoDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theEventoDTO.TheComunidadDTO = myComunidadDTO;

        CategoriaDTO myCategoria = new CategoriaDTO();

        myCategoria.IdCategoria = decimal.Parse(this.ddlCategoria.SelectedValue);
        theEventoDTO.TheCategoriaDTO = myCategoria;

        theEventoDTO.UsuarioIngreso = myUsuario.Rut;

        if (this.FileImagenEvento.HasFile)
        {
            if (System.IO.Path.GetExtension(FileImagenEvento.PostedFile.FileName) == ".swf")
                theEventoDTO.EventoImagen = this.ProcessOtherFile(FileImagenEvento, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathEventoPub"));
            else
                theEventoDTO.EventoImagen = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenEvento, YouCom.Service.Generales.General.GetPropiedad("UploadsPathEventoPub"), 198, 118, Page);
        }

        theEventoDTO.EventoPublicacion = DateTime.ParseExact(this.FechaPublicacion.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theEventoDTO.EventoInicio = DateTime.ParseExact(this.FechaPublicacion.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theEventoDTO.EventoExpiracion = DateTime.ParseExact(this.FechaExpiracion.Text + " 00:00", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

        eventos = eventos.Where(x => x.EventoTitulo == theEventoDTO.EventoTitulo).ToList();
        if (eventos.Any())
        {
            foreach (var item in eventos)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Evento existe pero fue eliminado para activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Evento ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.EventoBLL.Insert(theEventoDTO);
        if (respuesta)
        {
            this.TxtNotiAutor.Text = string.Empty;
            this.txtEventoTitulo.Text = string.Empty;
            this.txtEventoResumen.Text = string.Empty;
            string script = "alert('Evento ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarEvento();
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

        EventoDTO theEventoDTO = new EventoDTO();
        theEventoDTO.EventoId = decimal.Parse(this.hdnEventoId.Value);
        theEventoDTO.EventoTitulo = this.txtEventoTitulo.Text.ToUpper();
        theEventoDTO.EventoResumen = this.txtEventoResumen.Text.ToUpper();
        theEventoDTO.EventoDetalle = this.FCKeditorDetalle.Value;
        theEventoDTO.EventoAutor = this.TxtNotiAutor.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theEventoDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theEventoDTO.TheComunidadDTO = myComunidadDTO;

        CategoriaDTO myCategoria = new CategoriaDTO();

        myCategoria.IdCategoria = decimal.Parse(this.ddlCategoria.SelectedValue);
        theEventoDTO.TheCategoriaDTO = myCategoria;

        theEventoDTO.UsuarioModificacion = myUsuario.Rut;

        if (this.FileImagenEvento.HasFile)
        {
            theEventoDTO.EventoImagen = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenEvento, YouCom.Service.Generales.General.GetPropiedad("UploadsPathBann"), 198, 118, Page);
        }
        else
        {
            YouCom.DTO.EventoDTO myEventoDTO = new YouCom.DTO.EventoDTO();
            myEventoDTO = YouCom.bll.EventoBLL.detalleEvento(decimal.Parse(hdnEventoId.Value));

            theEventoDTO.EventoImagen = myEventoDTO.EventoImagen;
        }

        theEventoDTO.EventoPublicacion = DateTime.ParseExact(this.FechaPublicacion.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theEventoDTO.EventoInicio = DateTime.ParseExact(this.FechaPublicacion.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theEventoDTO.EventoExpiracion = DateTime.ParseExact(this.FechaExpiracion.Text + " 00:00", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

        bool respuesta = YouCom.bll.EventoBLL.Update(theEventoDTO);

        if (respuesta)
        {
            cargarEvento();
            this.TxtNotiAutor.Text = string.Empty;
            this.txtEventoTitulo.Text = string.Empty;
            this.txtEventoResumen.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Evento editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptEventoInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnEventoId = new HiddenField();
            hdnEventoId = (HiddenField)e.Item.FindControl("hdnEventoId");

            EventoDTO theEventoDTO = new EventoDTO();
            theEventoDTO.EventoId = decimal.Parse(hdnEventoId.Value);
            theEventoDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.EventoBLL.ActivaEvento(theEventoDTO);
            if (respuesta)
            {
                cargarEventoInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Evento Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptEvento_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnEventoId = new HiddenField();
            hdnEventoId = (HiddenField)e.Item.FindControl("hdnEventoId");

            YouCom.DTO.EventoDTO myEventoDTO = new YouCom.DTO.EventoDTO();
            myEventoDTO = YouCom.bll.EventoBLL.detalleEvento(decimal.Parse(hdnEventoId.Value));

            this.hdnEventoId.Value = myEventoDTO.EventoId.ToString();
            txtEventoTitulo.Text = myEventoDTO.EventoTitulo;
            txtEventoResumen.Text = myEventoDTO.EventoResumen;
            FCKeditorDetalle.Value = myEventoDTO.EventoDetalle;
            TxtNotiAutor.Text = myEventoDTO.EventoAutor;

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myEventoDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myEventoDTO.TheComunidadDTO.IdComunidad.ToString()));

            ddlCategoria.SelectedIndex = ddlCategoria.Items.IndexOf(ddlCategoria.Items.FindByValue(myEventoDTO.TheCategoriaDTO.IdCategoria.ToString()));

            this.FechaPublicacion.Text = myEventoDTO.EventoPublicacion.ToShortDateString();
            this.FechaExpiracion.Text = myEventoDTO.EventoExpiracion.ToShortDateString();

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnEventoId = new HiddenField();
            hdnEventoId = (HiddenField)e.Item.FindControl("hdnEventoId");

            EventoDTO theEventoDTO = new EventoDTO();
            theEventoDTO.EventoId = decimal.Parse(hdnEventoId.Value);
            theEventoDTO.UsuarioModificacion = myUsuario.Rut;

            bool respuesta = YouCom.bll.EventoBLL.Delete(theEventoDTO);
            if (respuesta)
            {
                cargarEvento();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Evento eliminado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }
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
