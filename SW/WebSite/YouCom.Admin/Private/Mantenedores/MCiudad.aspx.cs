using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MCiudad : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarRegion();
            cargarCiudad();
        }
    }

    protected void cargarRegion()
    {
        ddlRegion.DataSource = YouCom.bll.RegionBLL.listaRegionActivo();
        ddlRegion.DataTextField = "NombreRegion";
        ddlRegion.DataValueField = "IdRegion";
        ddlRegion.DataBind();
        ddlRegion.Items.Insert(0, new ListItem("Seleccione Región", string.Empty));
    }

    protected void cargarCiudad()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["ciudad"] = YouCom.bll.CiudadBLL.getListadoCiudad();
            rptCiudad.DataSource = YouCom.bll.CiudadBLL.listaCiudadActivo();
            rptCiudad.DataBind();
        }
        else
        {
            Session["ciudad"] = YouCom.bll.CiudadBLL.getListadoCiudad().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptCiudad.DataSource = YouCom.bll.CiudadBLL.listaCiudadActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptCiudad.DataBind();
        }
    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionCasa.Visible = false;
        cargarCiudadInactivo();
    }
    protected void cargarCiudadInactivo()
    {
        IList<CiudadDTO> Ciudads = new List<CiudadDTO>();
        Ciudads = YouCom.bll.CiudadBLL.listaCiudadInactivo();
        if (Ciudads.Any())
        {
            rptCiudadInactivo.DataSource = Ciudads;
            rptCiudadInactivo.DataBind();
        }
        else
        {
            string script = "alert('No existen registros en  papelera.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            return;

        }


    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        List<CiudadDTO> ciudad = new List<CiudadDTO>();
        ciudad = (Session["ciudad"] as List<CiudadDTO>);

        CiudadDTO theCiudadDTO = new CiudadDTO();
        theCiudadDTO.NombreCiudad = this.txtNombre.Text.ToUpper();
        theCiudadDTO.DescripcionCiudad = this.txtNombre.Text.ToUpper();

        RegionDTO myRegionDTO = new RegionDTO();

        myRegionDTO.IdRegion = decimal.Parse(this.ddlRegion.SelectedValue);
        theCiudadDTO.TheRegionDTO = myRegionDTO;

        theCiudadDTO.UsuarioIngreso = myUsuario.Rut;

        ciudad = ciudad.Where(x => x.NombreCiudad == theCiudadDTO.NombreCiudad).ToList();
        if (ciudad.Any())
        {
            foreach (var item in ciudad)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Ciudad Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Ciudad ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }


        }


        bool respuesta = YouCom.bll.CiudadBLL.Insert(theCiudadDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            this.ddlRegion.ClearSelection();
            string script = "alert('Ciudad Ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarCiudad();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        CiudadDTO theCiudadDTO = new CiudadDTO();
        theCiudadDTO.IdCiudad = decimal.Parse(this.hdnIdCiudad.Value);
        theCiudadDTO.NombreCiudad = this.txtNombre.Text.ToUpper();
        theCiudadDTO.DescripcionCiudad = this.txtNombre.Text.ToUpper();
        RegionDTO myRegionDTO = new RegionDTO();

        myRegionDTO.IdRegion = decimal.Parse(this.ddlRegion.SelectedValue);
        theCiudadDTO.TheRegionDTO = myRegionDTO;

        theCiudadDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.CiudadBLL.Update(theCiudadDTO);

        if (respuesta)
        {
            cargarCiudad();
            this.txtNombre.Text = string.Empty;
            this.ddlRegion.ClearSelection();

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Ciudad editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptCiudadInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdCiudad = new HiddenField();
            hdnIdCiudad = (HiddenField)e.Item.FindControl("hdnIdCiudad");

            CiudadDTO theCiudadDTO = new CiudadDTO();
            theCiudadDTO.IdCiudad = decimal.Parse(hdnIdCiudad.Value);
            theCiudadDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.CiudadBLL.ActivaCiudad(theCiudadDTO);
            if (respuesta)
            {
                cargarCiudadInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Ciudad Activada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptCiudad_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdCiudad = new HiddenField();
            hdnIdCiudad = (HiddenField)e.Item.FindControl("hdnIdCiudad");

            YouCom.DTO.CiudadDTO myCiudadDTO = new YouCom.DTO.CiudadDTO();
            myCiudadDTO = YouCom.bll.CiudadBLL.detalleCiudad(decimal.Parse(hdnIdCiudad.Value));

            this.hdnIdCiudad.Value = myCiudadDTO.IdCiudad.ToString();
            txtNombre.Text = myCiudadDTO.NombreCiudad;
            ddlRegion.SelectedIndex = ddlRegion.Items.IndexOf(ddlRegion.Items.FindByValue(myCiudadDTO.TheRegionDTO.IdRegion.ToString()));

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdCiudad = new HiddenField();
            hdnIdCiudad = (HiddenField)e.Item.FindControl("hdnIdCiudad");

            CiudadDTO theCiudadDTO = new CiudadDTO();
            theCiudadDTO.IdCiudad = decimal.Parse(hdnIdCiudad.Value);
            theCiudadDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.CiudadBLL.ValidaEliminacionCiudad(theCiudadDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un Ciudad con registro asociado.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.CiudadBLL.Delete(theCiudadDTO);
                if (respuesta)
                {
                    cargarCiudad();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Ciudad Eliminada correctamente.');";
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
