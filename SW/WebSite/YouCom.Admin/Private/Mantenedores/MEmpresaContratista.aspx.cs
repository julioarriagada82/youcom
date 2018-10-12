using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MEmpresaContratista : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarEmpresaContratista();
            cargarParametros();
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

    protected void cargarEmpresaContratista()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["empresa_servicio"] = YouCom.bll.EmpresaContratistaBLL.getListadoEmpresaContratista();
            rptEmpresaContratista.DataSource = YouCom.bll.EmpresaContratistaBLL.listaEmpresaContratistaActivo();
            rptEmpresaContratista.DataBind();
        }
        else
        {
            Session["empresa_servicio"] = YouCom.bll.EmpresaContratistaBLL.getListadoEmpresaContratista().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptEmpresaContratista.DataSource = YouCom.bll.EmpresaContratistaBLL.listaEmpresaContratistaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptEmpresaContratista.DataBind();
        }
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
        pnlAdministracionEmpresaContratista.Visible = false;
        cargarEmpresaContratistaInactivo();
    }
    protected void cargarEmpresaContratistaInactivo()
    {
        IList<EmpresaContratistaDTO> EmpresaContratista = new List<EmpresaContratistaDTO>();
        EmpresaContratista = YouCom.bll.EmpresaContratistaBLL.listaEmpresaContratistaInactivo();
        if (EmpresaContratista.Any())
        {
            rptEmpresaContratistaInactivo.DataSource = EmpresaContratista;
            rptEmpresaContratistaInactivo.DataBind();
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

        List<EmpresaContratistaDTO> empresa_contratista = new List<EmpresaContratistaDTO>();
        empresa_contratista = (Session["empresa_contratista"] as List<EmpresaContratistaDTO>);

        EmpresaContratistaDTO theEmpresaContratistaDTO = new EmpresaContratistaDTO();
        theEmpresaContratistaDTO.RazonSocialEmpresaContratista = this.txtRazonSocialEmpresaContratista.Text.ToUpper();
        theEmpresaContratistaDTO.RutCondominioContratista = this.txtRutCondominioContratista.Text.ToUpper();
        theEmpresaContratistaDTO.DireccionEmpresaContratista = this.txtEmpresaContratistaDireccion.Text.ToUpper();
        theEmpresaContratistaDTO.TelefonoEmpresaContratista = this.txtEmpresaContratistaTelefono.Text;
        theEmpresaContratistaDTO.CelularEmpresaContratista = this.txtEmpresaContratistaTelefono.Text;
        theEmpresaContratistaDTO.UrlEmpresaContratista = this.txtEmpresaContratistaURL.Text.ToUpper();
        theEmpresaContratistaDTO.EmailEmpresaContratista = this.txtEmail.Text;

        YouCom.DTO.GiroDTO myGiroDTO = new YouCom.DTO.GiroDTO();
        myGiroDTO.IdGiro = decimal.Parse(ddlGiro.SelectedValue);
        theEmpresaContratistaDTO.TheGiroDTO = myGiroDTO;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theEmpresaContratistaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theEmpresaContratistaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.ComunaDTO myComunaDTO = new YouCom.DTO.ComunaDTO();
        myComunaDTO.IdComuna = decimal.Parse(ddlComuna.SelectedValue);
        theEmpresaContratistaDTO.TheComunaDTO = myComunaDTO;

        YouCom.DTO.CiudadDTO myCiudadDTO = new YouCom.DTO.CiudadDTO();
        myCiudadDTO.IdCiudad = decimal.Parse(ddlCiudad.SelectedValue);
        theEmpresaContratistaDTO.TheComunaDTO.TheCiudadDTO = myCiudadDTO;

        YouCom.DTO.RegionDTO myRegionDTO = new YouCom.DTO.RegionDTO();
        myRegionDTO.IdRegion = decimal.Parse(ddlRegion.SelectedValue);
        theEmpresaContratistaDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO = myRegionDTO;

        YouCom.DTO.PaisDTO myPaisDTO = new YouCom.DTO.PaisDTO();
        myPaisDTO.IdPais = decimal.Parse(ddlPais.SelectedValue);
        theEmpresaContratistaDTO.TheComunaDTO.TheCiudadDTO.TheRegionDTO.ThePaisDTO = myPaisDTO;

        theEmpresaContratistaDTO.UsuarioIngreso = myUsuario.Rut;

        if (this.FileImagenEmpresaContratista.HasFile)
        {
            if (System.IO.Path.GetExtension(FileImagenEmpresaContratista.PostedFile.FileName) == ".swf")
                theEmpresaContratistaDTO.LogoEmpresaContratista = this.ProcessOtherFile(FileImagenEmpresaContratista, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathEmpresaContratistaPub"));
            else
                theEmpresaContratistaDTO.LogoEmpresaContratista = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenEmpresaContratista, YouCom.Service.Generales.General.GetPropiedad("UploadsPathEmpresaContratistaPub"), 198, 118, Page);
        }

        empresa_contratista = empresa_contratista.Where(x => x.RazonSocialEmpresaContratista == theEmpresaContratistaDTO.RazonSocialEmpresaContratista).ToList();
        if (empresa_contratista.Any())
        {
            foreach (var item in empresa_contratista)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Empresa Contratista existe pero fue eliminado para activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Empresa Contratista ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.EmpresaContratistaBLL.Insert(theEmpresaContratistaDTO);
        if (respuesta)
        {
            this.txtRutCondominioContratista.Text = string.Empty;
            this.txtRazonSocialEmpresaContratista.Text = string.Empty;
            this.txtEmpresaContratistaDireccion.Text = string.Empty;
            this.txtEmpresaContratistaTelefono.Text = string.Empty;
            this.txtEmpresaContratistaCelular.Text = string.Empty;
            this.txtEmpresaContratistaURL.Text = string.Empty;
            this.txtEmail.Text = string.Empty;

            string script = "alert('Empresa Servicio ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarEmpresaContratista();
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

        EmpresaContratistaDTO theEmpresaContratistaDTO = new EmpresaContratistaDTO();
        theEmpresaContratistaDTO.IdEmpresaContratista = decimal.Parse(this.hdnIdEmpresaContratista.Value);
        theEmpresaContratistaDTO.RazonSocialEmpresaContratista = this.txtRazonSocialEmpresaContratista.Text.ToUpper();
        theEmpresaContratistaDTO.RutCondominioContratista = this.txtRutCondominioContratista.Text.ToUpper();
        theEmpresaContratistaDTO.DireccionEmpresaContratista = this.txtEmpresaContratistaDireccion.Text.ToUpper();
        theEmpresaContratistaDTO.TelefonoEmpresaContratista = this.txtEmpresaContratistaTelefono.Text;
        theEmpresaContratistaDTO.CelularEmpresaContratista = this.txtEmpresaContratistaCelular.Text;
        theEmpresaContratistaDTO.UrlEmpresaContratista = this.txtEmpresaContratistaURL.Text.ToUpper();
        theEmpresaContratistaDTO.EmailEmpresaContratista = this.txtEmail.Text;

        YouCom.DTO.GiroDTO myGiroDTO = new YouCom.DTO.GiroDTO();
        myGiroDTO.IdGiro = decimal.Parse(ddlGiro.SelectedValue);
        theEmpresaContratistaDTO.TheGiroDTO = myGiroDTO;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theEmpresaContratistaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theEmpresaContratistaDTO.TheComunidadDTO = myComunidadDTO;

        theEmpresaContratistaDTO.UsuarioModificacion = myUsuario.Rut;

        if (this.FileImagenEmpresaContratista.HasFile)
        {
            theEmpresaContratistaDTO.LogoEmpresaContratista = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenEmpresaContratista, YouCom.Service.Generales.General.GetPropiedad("UploadsPathEmpresaContratistaPub"), 198, 118, Page);
        }
        else
        {
            EmpresaContratistaDTO myEmpresaContratistaDTO = new EmpresaContratistaDTO();
            myEmpresaContratistaDTO = YouCom.bll.EmpresaContratistaBLL.detalleEmpresaContratista(decimal.Parse(hdnIdEmpresaContratista.Value));

            theEmpresaContratistaDTO.LogoEmpresaContratista = myEmpresaContratistaDTO.LogoEmpresaContratista;
        }


        bool respuesta = YouCom.bll.EmpresaContratistaBLL.Update(theEmpresaContratistaDTO);

        if (respuesta)
        {
            cargarEmpresaContratista();
            this.txtRutCondominioContratista.Text = string.Empty;
            this.txtRazonSocialEmpresaContratista.Text = string.Empty;
            this.txtEmpresaContratistaDireccion.Text = string.Empty;
            this.txtEmpresaContratistaTelefono.Text = string.Empty;
            this.txtEmpresaContratistaCelular.Text = string.Empty;
            this.txtEmpresaContratistaURL.Text = string.Empty;
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
    protected void rptEmpresaContratistaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdEmpresaContratista = new HiddenField();
            hdnIdEmpresaContratista = (HiddenField)e.Item.FindControl("hdnIdEmpresaContratista");

            EmpresaContratistaDTO theEmpresaContratistaDTO = new EmpresaContratistaDTO();
            theEmpresaContratistaDTO.IdEmpresaContratista = decimal.Parse(hdnIdEmpresaContratista.Value);
            theEmpresaContratistaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.EmpresaContratistaBLL.ActivaEmpresaContratista(theEmpresaContratistaDTO);
            if (respuesta)
            {
                cargarEmpresaContratistaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('EmpresaContratista Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptEmpresaContratista_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdEmpresaContratista = new HiddenField();
            hdnIdEmpresaContratista = (HiddenField)e.Item.FindControl("hdnIdEmpresaContratista");

            EmpresaContratistaDTO myEmpresaContratistaDTO = new EmpresaContratistaDTO();
            myEmpresaContratistaDTO = YouCom.bll.EmpresaContratistaBLL.detalleEmpresaContratista(decimal.Parse(hdnIdEmpresaContratista.Value));

            this.hdnIdEmpresaContratista.Value = myEmpresaContratistaDTO.IdEmpresaContratista.ToString();
            this.txtRazonSocialEmpresaContratista.Text = myEmpresaContratistaDTO.RazonSocialEmpresaContratista;
            this.txtRutCondominioContratista.Text = myEmpresaContratistaDTO.RutCondominioContratista;
            this.txtEmpresaContratistaDireccion.Text = myEmpresaContratistaDTO.DireccionEmpresaContratista;
            this.txtEmpresaContratistaTelefono.Text = myEmpresaContratistaDTO.TelefonoEmpresaContratista;
            this.txtEmpresaContratistaCelular.Text = myEmpresaContratistaDTO.CelularEmpresaContratista;
            this.txtEmail.Text = myEmpresaContratistaDTO.EmailEmpresaContratista;
            this.txtEmpresaContratistaURL.Text = myEmpresaContratistaDTO.UrlEmpresaContratista;

            ddlGiro.SelectedIndex = ddlGiro.Items.IndexOf(ddlGiro.Items.FindByValue(myEmpresaContratistaDTO.TheGiroDTO.IdGiro.ToString()));

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myEmpresaContratistaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myEmpresaContratistaDTO.TheComunidadDTO.IdComunidad.ToString()));

            if (!string.IsNullOrEmpty(myEmpresaContratistaDTO.LogoEmpresaContratista))
            {
                this.lnkImagen.Visible = true;
                this.chkImagen.Visible = true;
                this.lnkImagen.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathEmpresaContratistaPub") + myEmpresaContratistaDTO.LogoEmpresaContratista;
            }

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdEmpresaContratista = new HiddenField();
            hdnIdEmpresaContratista = (HiddenField)e.Item.FindControl("hdnIdEmpresaContratista");

            EmpresaContratistaDTO theEmpresaContratistaDTO = new EmpresaContratistaDTO();
            theEmpresaContratistaDTO.IdEmpresaContratista = decimal.Parse(hdnIdEmpresaContratista.Value);
            theEmpresaContratistaDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.EmpresaContratistaBLL.ValidaEliminacionEmpresaContratista(theEmpresaContratistaDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un EmpresaContratista con informacion asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.EmpresaContratistaBLL.Delete(theEmpresaContratistaDTO);
                if (respuesta)
                {
                    cargarEmpresaContratista();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('EmpresaContratista Eliminada correctamente.');";
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
