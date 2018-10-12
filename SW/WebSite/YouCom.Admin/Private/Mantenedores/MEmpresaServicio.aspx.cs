using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Servicio;

public partial class Admin_Mantenedores_MEmpresaServicio : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarEmpresaServicio();
            cargarParametros();
            cargarServicio();
            cargarPais();
            cargarGiro();
        }
    }

    protected void cargarParametros()
    {
        ddlAnexoCelular.DataSource = YouCom.bll.ParametrosBLL.getListadoParametrosByConcepto("ANEXOCELULAR");
        ddlAnexoCelular.DataTextField = "Descripcion";
        ddlAnexoCelular.DataValueField = "Codigo";
        ddlAnexoCelular.DataBind();
        ddlAnexoCelular.Items.Insert(0, new ListItem("--", string.Empty));

        ddlAnexoTelefono.DataSource = YouCom.bll.ParametrosBLL.getListadoParametrosByConcepto("ANEXOTELEFONO");
        ddlAnexoTelefono.DataTextField = "Descripcion";
        ddlAnexoTelefono.DataValueField = "Codigo";
        ddlAnexoTelefono.DataBind();
        ddlAnexoTelefono.Items.Insert(0, new ListItem("--", string.Empty));
    }

    protected void cargarEmpresaServicio()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["empresa_servicio"] = YouCom.bll.EmpresaServicioBLL.getListadoEmpresaServicio();
            rptEmpresaServicio.DataSource = YouCom.bll.EmpresaServicioBLL.listaEmpresaServicioActivo();
            rptEmpresaServicio.DataBind();
        }
        else
        {
            Session["empresa_servicio"] = YouCom.bll.EmpresaServicioBLL.getListadoEmpresaServicio().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptEmpresaServicio.DataSource = YouCom.bll.EmpresaServicioBLL.listaEmpresaServicioActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptEmpresaServicio.DataBind();
        }

    }

    protected void cargarServicio()
    {
        ddlServicio.DataSource = YouCom.bll.ServiciosBLL.listaServiciosActivo();
        ddlServicio.DataTextField = "NombreServicio";
        ddlServicio.DataValueField = "IdServicio";
        ddlServicio.DataBind();
        ddlServicio.Items.Insert(0, new ListItem("Seleccione Servicio", string.Empty));
    }

    protected void cargarPais()
    {
        ddlPais.DataSource = YouCom.bll.PaisBLL.listaPaisActivo();
        ddlPais.DataTextField = "NombrePais";
        ddlPais.DataValueField = "IdPais";
        ddlPais.DataBind();
        ddlPais.Items.Insert(0, new ListItem("Seleccione Pais", string.Empty));
    }

    protected void cargarGiro()
    {
        ddlGiro.DataSource = YouCom.bll.GiroBLL.listaGiroActivo();
        ddlGiro.DataTextField = "NombreGiro";
        ddlGiro.DataValueField = "IdGiro";
        ddlGiro.DataBind();
        ddlGiro.Items.Insert(0, new ListItem("Seleccione Giro", string.Empty));
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionEmpresaServicio.Visible = false;
        cargarEmpresaServicioInactivo();
    }
    protected void cargarEmpresaServicioInactivo()
    {
        IList<EmpresaServicioDTO> EmpresaServicio = new List<EmpresaServicioDTO>();
        EmpresaServicio = YouCom.bll.EmpresaServicioBLL.listaEmpresaServicioInactivo();
        if (EmpresaServicio.Any())
        {
            rptEmpresaServicioInactivo.DataSource = EmpresaServicio;
            rptEmpresaServicioInactivo.DataBind();
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

        List<EmpresaServicioDTO> empresa_servicio = new List<EmpresaServicioDTO>();
        empresa_servicio = (Session["empresa_servicio"] as List<EmpresaServicioDTO>);

        EmpresaServicioDTO theEmpresaServicioDTO = new EmpresaServicioDTO();
        theEmpresaServicioDTO.RazonSocialEmpresaServicio = this.txtRazonSocialEmpresaServicio.Text.ToUpper();
        theEmpresaServicioDTO.RutEmpresaServicio = this.txtRutEmpresaServicio.Text.ToUpper();
        theEmpresaServicioDTO.DireccionEmpresaServicio = this.txtEmpresaServicioDireccion.Text.ToUpper();
        theEmpresaServicioDTO.TelefonoEmpresaServicio = this.txtEmpresaServicioTelefono.Text;
        theEmpresaServicioDTO.CelularEmpresaServicio = this.txtEmpresaServicioTelefono.Text;
        theEmpresaServicioDTO.UrlEmpresaServicio = this.txtEmpresaServicioURL.Text.ToUpper();
        theEmpresaServicioDTO.EmailEmpresaServicio = this.txtEmail.Text;

        YouCom.DTO.Servicio.ServiciosDTO myServiciosDTO = new YouCom.DTO.Servicio.ServiciosDTO();
        myServiciosDTO.IdServicio = decimal.Parse(ddlServicio.SelectedValue);
        theEmpresaServicioDTO.TheServiciosDTO = myServiciosDTO;

        YouCom.DTO.GiroDTO myGiroDTO = new YouCom.DTO.GiroDTO();
        myGiroDTO.IdGiro = decimal.Parse(ddlGiro.SelectedValue);
        theEmpresaServicioDTO.TheGiroDTO = myGiroDTO;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theEmpresaServicioDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theEmpresaServicioDTO.TheComunidadDTO = myComunidadDTO;

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

        theEmpresaServicioDTO.UsuarioIngreso = myUsuario.Rut;

        if (this.FileImagenEmpresaServicio.HasFile)
        {
            if (System.IO.Path.GetExtension(FileImagenEmpresaServicio.PostedFile.FileName) == ".swf")
                theEmpresaServicioDTO.LogoEmpresaServicio = this.ProcessOtherFile(FileImagenEmpresaServicio, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathEmpresaServicioPub"));
            else
                theEmpresaServicioDTO.LogoEmpresaServicio = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenEmpresaServicio, YouCom.Service.Generales.General.GetPropiedad("UploadsPathEmpresaServicioPub"), 198, 118, Page);
        }

        empresa_servicio = empresa_servicio.Where(x => x.RazonSocialEmpresaServicio == theEmpresaServicioDTO.RazonSocialEmpresaServicio).ToList();
        if (empresa_servicio.Any())
        {
            foreach (var item in empresa_servicio)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Empresa Servicio existe pero fue eliminado para activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Empresa Servicio ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.EmpresaServicioBLL.Insert(theEmpresaServicioDTO);
        if (respuesta)
        {
            this.txtRutEmpresaServicio.Text = string.Empty;
            this.txtRazonSocialEmpresaServicio.Text = string.Empty;
            this.txtEmpresaServicioDireccion.Text = string.Empty;
            this.txtEmpresaServicioTelefono.Text = string.Empty;
            this.txtEmpresaServicioCelular.Text = string.Empty;
            this.txtEmpresaServicioURL.Text = string.Empty;
            this.txtEmail.Text = string.Empty;

            string script = "alert('Empresa Servicio ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarEmpresaServicio();
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

        EmpresaServicioDTO theEmpresaServicioDTO = new EmpresaServicioDTO();
        theEmpresaServicioDTO.IdEmpresaServicio = decimal.Parse(this.hdnIdEmpresaServicio.Value);
        theEmpresaServicioDTO.RazonSocialEmpresaServicio = this.txtRazonSocialEmpresaServicio.Text.ToUpper();
        theEmpresaServicioDTO.RutEmpresaServicio = this.txtRutEmpresaServicio.Text.ToUpper();
        theEmpresaServicioDTO.DireccionEmpresaServicio = this.txtEmpresaServicioDireccion.Text.ToUpper();
        theEmpresaServicioDTO.TelefonoEmpresaServicio = this.txtEmpresaServicioTelefono.Text;
        theEmpresaServicioDTO.CelularEmpresaServicio = this.txtEmpresaServicioCelular.Text;
        theEmpresaServicioDTO.UrlEmpresaServicio = this.txtEmpresaServicioURL.Text.ToUpper();
        theEmpresaServicioDTO.EmailEmpresaServicio = this.txtEmail.Text;

        YouCom.DTO.Servicio.ServiciosDTO myServiciosDTO = new YouCom.DTO.Servicio.ServiciosDTO();
        myServiciosDTO.IdServicio = decimal.Parse(ddlServicio.SelectedValue);
        theEmpresaServicioDTO.TheServiciosDTO = myServiciosDTO;

        YouCom.DTO.GiroDTO myGiroDTO = new YouCom.DTO.GiroDTO();
        myGiroDTO.IdGiro = decimal.Parse(ddlGiro.SelectedValue);
        theEmpresaServicioDTO.TheGiroDTO = myGiroDTO;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theEmpresaServicioDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theEmpresaServicioDTO.TheComunidadDTO = myComunidadDTO;

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

        theEmpresaServicioDTO.UsuarioModificacion = myUsuario.Rut;

        if (this.FileImagenEmpresaServicio.HasFile)
        {
            theEmpresaServicioDTO.LogoEmpresaServicio = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenEmpresaServicio, YouCom.Service.Generales.General.GetPropiedad("UploadsPathEmpresaServicioPub"), 198, 118, Page);
        }
        else
        {
            EmpresaServicioDTO myEmpresaServicioDTO = new EmpresaServicioDTO();
            myEmpresaServicioDTO = YouCom.bll.EmpresaServicioBLL.detalleEmpresaServicio(decimal.Parse(hdnIdEmpresaServicio.Value));

            theEmpresaServicioDTO.LogoEmpresaServicio = myEmpresaServicioDTO.LogoEmpresaServicio;
        }


        bool respuesta = YouCom.bll.EmpresaServicioBLL.Update(theEmpresaServicioDTO);

        if (respuesta)
        {
            cargarEmpresaServicio();
            this.txtRutEmpresaServicio.Text = string.Empty;
            this.txtRazonSocialEmpresaServicio.Text = string.Empty;
            this.txtEmpresaServicioDireccion.Text = string.Empty;
            this.txtEmpresaServicioTelefono.Text = string.Empty;
            this.txtEmpresaServicioCelular.Text = string.Empty;
            this.txtEmpresaServicioURL.Text = string.Empty;
            this.txtEmail.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Empresa Servicio editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptEmpresaServicioInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdEmpresaServicio = new HiddenField();
            hdnIdEmpresaServicio = (HiddenField)e.Item.FindControl("hdnIdEmpresaServicio");

            EmpresaServicioDTO theEmpresaServicioDTO = new EmpresaServicioDTO();
            theEmpresaServicioDTO.IdEmpresaServicio = decimal.Parse(hdnIdEmpresaServicio.Value);
            theEmpresaServicioDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.EmpresaServicioBLL.ActivaEmpresaServicio(theEmpresaServicioDTO);
            if (respuesta)
            {
                cargarEmpresaServicioInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('EmpresaServicio Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptEmpresaServicio_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdEmpresaServicio = new HiddenField();
            hdnIdEmpresaServicio = (HiddenField)e.Item.FindControl("hdnIdEmpresaServicio");

            EmpresaServicioDTO myEmpresaServicioDTO = new EmpresaServicioDTO();
            myEmpresaServicioDTO = YouCom.bll.EmpresaServicioBLL.detalleEmpresaServicio(decimal.Parse(hdnIdEmpresaServicio.Value));

            this.hdnIdEmpresaServicio.Value = myEmpresaServicioDTO.IdEmpresaServicio.ToString();
            this.txtRazonSocialEmpresaServicio.Text = myEmpresaServicioDTO.RazonSocialEmpresaServicio;
            this.txtRutEmpresaServicio.Text = myEmpresaServicioDTO.RutEmpresaServicio;
            this.txtEmpresaServicioDireccion.Text = myEmpresaServicioDTO.DireccionEmpresaServicio;
            this.txtEmpresaServicioTelefono.Text = myEmpresaServicioDTO.TelefonoEmpresaServicio;
            this.txtEmpresaServicioCelular.Text = myEmpresaServicioDTO.CelularEmpresaServicio;
            this.txtEmail.Text = myEmpresaServicioDTO.EmailEmpresaServicio;
            this.txtEmpresaServicioURL.Text = myEmpresaServicioDTO.UrlEmpresaServicio;

            ddlServicio.SelectedIndex = ddlServicio.Items.IndexOf(ddlServicio.Items.FindByValue(myEmpresaServicioDTO.TheServiciosDTO.IdServicio.ToString()));

            ddlGiro.SelectedIndex = ddlGiro.Items.IndexOf(ddlGiro.Items.FindByValue(myEmpresaServicioDTO.TheGiroDTO.IdGiro.ToString()));

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myEmpresaServicioDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myEmpresaServicioDTO.TheComunidadDTO.IdComunidad.ToString()));

            if (!string.IsNullOrEmpty(myEmpresaServicioDTO.LogoEmpresaServicio))
            {
                this.lnkImagen.Visible = true;
                this.chkImagen.Visible = true;
                this.lnkImagen.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathEmpresaServicioPub") + myEmpresaServicioDTO.LogoEmpresaServicio;
            }

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdEmpresaServicio = new HiddenField();
            hdnIdEmpresaServicio = (HiddenField)e.Item.FindControl("hdnIdEmpresaServicio");

            EmpresaServicioDTO theEmpresaServicioDTO = new EmpresaServicioDTO();
            theEmpresaServicioDTO.IdEmpresaServicio = decimal.Parse(hdnIdEmpresaServicio.Value);
            theEmpresaServicioDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.EmpresaServicioBLL.ValidaEliminacionEmpresaServicio(theEmpresaServicioDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un EmpresaServicio con informacion asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.EmpresaServicioBLL.Delete(theEmpresaServicioDTO);
                if (respuesta)
                {
                    cargarEmpresaServicio();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('EmpresaServicio Eliminada correctamente.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
                else
                {
                }
            }
        }
    }

    protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (!string.IsNullOrEmpty(ddlPais.SelectedValue))
            {
                ddlRegion.DataSource = YouCom.bll.RegionBLL.listaRegionByPais(decimal.Parse(ddlPais.SelectedValue));
                ddlRegion.DataTextField = "NombreRegion";
                ddlRegion.DataValueField = "IdRegion";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, new ListItem("Seleccione Región", string.Empty));
            }
        }
        catch (Exception ex)
        {


        }
    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (!string.IsNullOrEmpty(ddlRegion.SelectedValue))
            {
                ddlCiudad.DataSource = YouCom.bll.CiudadBLL.listaCiudadByRegion(decimal.Parse(ddlRegion.SelectedValue));
                ddlCiudad.DataTextField = "NombreCiudad";
                ddlCiudad.DataValueField = "IdCiudad";
                ddlCiudad.DataBind();
                ddlCiudad.Items.Insert(0, new ListItem("Seleccione Ciudad", string.Empty));
            }
        }
        catch (Exception ex)
        {


        }
    }

    protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (!string.IsNullOrEmpty(ddlCiudad.SelectedValue))
            {
                ddlComuna.DataSource = YouCom.bll.ComunaBLL.listaComunaByCiudad(decimal.Parse(ddlCiudad.SelectedValue));
                ddlComuna.DataTextField = "NombreComuna";
                ddlComuna.DataValueField = "IdComuna";
                ddlComuna.DataBind();
                ddlComuna.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));
            }
        }
        catch (Exception ex)
        {


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
