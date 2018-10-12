using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Servicio;

public partial class Admin_Mantenedores_MServicio : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarServicios();
            cargarCategoria();
        }
    }

    protected void cargarServicios()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["servicio"] = YouCom.bll.ServiciosBLL.listaServiciosActivo();
            rptServicios.DataSource = YouCom.bll.ServiciosBLL.listaServiciosActivo();
            rptServicios.DataBind();
        }
        else
        {
            Session["servicio"] = YouCom.bll.ServiciosBLL.listaServiciosActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptServicios.DataSource = YouCom.bll.ServiciosBLL.listaServiciosActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptServicios.DataBind();
        }
    }

    protected void cargarCategoria()
    {
        IList<YouCom.DTO.CategoriaDTO> myCategoria = new List<YouCom.DTO.CategoriaDTO>();

        myCategoria = YouCom.bll.CategoriaBLL.listaCategoriaActivo();

        myCategoria = myCategoria.Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 1 || x.TheTipoCategoriaDTO.IdTipoCategoria == 2).ToList();

        ddlCategoria.DataSource = myCategoria;
        ddlCategoria.DataTextField = "NombreCategoria";
        ddlCategoria.DataValueField = "IdCategoria";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, new ListItem("Seleccione Categoria", string.Empty));
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionServicios.Visible = false;
        cargarServiciosInactivo();
    }
    protected void cargarServiciosInactivo()
    {
        IList<ServiciosDTO> servicios = new List<ServiciosDTO>();
        servicios = YouCom.bll.ServiciosBLL.listaServiciosInactivo();
        if (servicios.Any())
        {
            rptServiciosInactivo.DataSource = servicios;
            rptServiciosInactivo.DataBind();
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

        List<ServiciosDTO> servicio = new List<ServiciosDTO>();
        servicio = (Session["servicio"] as List<ServiciosDTO>);

        ServiciosDTO theServiciosDTO = new ServiciosDTO();
        theServiciosDTO.NombreServicio = this.txtServicioNombre.Text.ToUpper();
        theServiciosDTO.DescripcionServicio = this.txtServicioDescripcion.Text.ToUpper();
        
        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theServiciosDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theServiciosDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theServiciosDTO.TheCategoriaDTO = myCategoriaDTO;

        theServiciosDTO.FechaInicio = DateTime.ParseExact(this.FechaInicio.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theServiciosDTO.FechaTermino = DateTime.ParseExact(this.FechaTermino.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

        theServiciosDTO.UsuarioIngreso = myUsuario.Rut;

        servicio = servicio.Where(x => x.NombreServicio == theServiciosDTO.NombreServicio).ToList();
        if (servicio.Any())
        {
            foreach (var item in servicio)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Servicio existe pero fue eliminado para activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Servicio ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.ServiciosBLL.Insert(theServiciosDTO);
        if (respuesta)
        {
            this.txtServicioNombre.Text = string.Empty;
            this.txtServicioDescripcion.Text = string.Empty;
            this.FechaInicio.Text = string.Empty;
            this.FechaTermino.Text = string.Empty;

            string script = "alert('Servicio ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarServicios();
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

        ServiciosDTO theServiciosDTO = new ServiciosDTO();
        theServiciosDTO.NombreServicio = this.txtServicioNombre.Text.ToUpper();
        theServiciosDTO.DescripcionServicio = this.txtServicioDescripcion.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theServiciosDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theServiciosDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theServiciosDTO.TheCategoriaDTO = myCategoriaDTO;

        theServiciosDTO.FechaInicio = DateTime.ParseExact(this.FechaInicio.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theServiciosDTO.FechaTermino = DateTime.ParseExact(this.FechaTermino.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

        theServiciosDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.ServiciosBLL.Update(theServiciosDTO);

        if (respuesta)
        {
            cargarServicios();
            this.txtServicioNombre.Text = string.Empty;
            this.txtServicioDescripcion.Text = string.Empty;
            this.FechaInicio.Text = string.Empty;
            this.FechaTermino.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Servicio editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptServiciosInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdServicios = new HiddenField();
            hdnIdServicios = (HiddenField)e.Item.FindControl("hdnIdServicios");

            ServiciosDTO theServiciosDTO = new ServiciosDTO();
            theServiciosDTO.IdServicio = decimal.Parse(hdnIdServicios.Value);
            theServiciosDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.ServiciosBLL.ActivaServicios(theServiciosDTO);
            if (respuesta)
            {
                cargarServiciosInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Servicio Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptServicios_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdServicios = new HiddenField();
            hdnIdServicios = (HiddenField)e.Item.FindControl("hdnIdServicios");

            ServiciosDTO myServiciosDTO = new ServiciosDTO();
            myServiciosDTO = YouCom.bll.ServiciosBLL.detalleServicios(decimal.Parse(hdnIdServicios.Value));

            this.hdnIdServicios.Value = myServiciosDTO.IdServicio.ToString();
            this.txtServicioNombre.Text = myServiciosDTO.NombreServicio;
            this.txtServicioDescripcion.Text = myServiciosDTO.DescripcionServicio;

            this.FechaInicio.Text = myServiciosDTO.FechaInicio.ToShortDateString();
            this.FechaTermino.Text = myServiciosDTO.FechaTermino.ToShortDateString();
            
            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myServiciosDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myServiciosDTO.TheComunidadDTO.IdComunidad.ToString()));

            ddlCategoria.SelectedIndex = ddlCategoria.Items.IndexOf(ddlCategoria.Items.FindByValue(myServiciosDTO.TheCategoriaDTO.IdCategoria.ToString()));

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdServicios = new HiddenField();
            hdnIdServicios = (HiddenField)e.Item.FindControl("hdnIdServicios");

            ServiciosDTO theServiciosDTO = new ServiciosDTO();
            theServiciosDTO.IdServicio = decimal.Parse(hdnIdServicios.Value);
            theServiciosDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.ServiciosBLL.ValidaEliminacionServicios(theServiciosDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un Servicio con informacion asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.ServiciosBLL.Delete(theServiciosDTO);
                if (respuesta)
                {
                    cargarServicios();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Servicio Eliminada correctamente.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
                else
                {
                }
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
