using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MRegion : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarRegiones();
            cargarPaises();
        }
    }
    protected void cargarPaises()
    {
        ddlPais.DataSource = YouCom.bll.PaisBLL.listaPaisActivo().Where(x=>x.Estado!="P");
        ddlPais.DataTextField = "NombrePais";
        ddlPais.DataValueField = "idPais";
        ddlPais.DataBind();
        ddlPais.Items.Insert(0, new ListItem("Seleccione Pais", string.Empty));
    
    }
    protected void cargarRegiones()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["regiones"] = YouCom.bll.RegionBLL.getListadoRegion();
            rptRegion.DataSource = YouCom.bll.RegionBLL.listaRegionActivo().Where(x => x.Estado != "P");
            rptRegion.DataBind();
        }
        else
        {
            Session["regiones"] = YouCom.bll.RegionBLL.getListadoRegion().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptRegion.DataSource = YouCom.bll.RegionBLL.listaRegionActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptRegion.DataBind();
        }
    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionRegion.Visible = false;
        cargarRegionInactivo();
    }
    protected void cargarRegionInactivo()
    {

        IList<RegionDTO> region = new List<RegionDTO>();
        region = YouCom.bll.RegionBLL.listaRegionInactivo();
        if (region.Any())
        {

            rptRegionInactivo.DataSource = region;
            rptRegionInactivo.DataBind();
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
        List<RegionDTO> region = new List<RegionDTO>();
        region = (Session["regiones"] as List<RegionDTO>);

        RegionDTO theRegionDTO = new RegionDTO();
        theRegionDTO.DescripcionRegion = txtRegion.Text.ToUpper();
        theRegionDTO.NombreRegion = txtRegion.Text.ToUpper();

        PaisDTO myPaisDTO = new PaisDTO();
        myPaisDTO.IdPais = decimal.Parse(ddlPais.SelectedValue);
        theRegionDTO.ThePaisDTO = myPaisDTO;

        theRegionDTO.UsuarioIngreso = myUsuario.Rut;


        region = region.Where(x => x.DescripcionRegion == theRegionDTO.DescripcionRegion).ToList();
        if (region.Any())
        {
            foreach (var item in region)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Region Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Region ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }


        }


        bool respuesta = YouCom.bll.RegionBLL.Insert(theRegionDTO);
        if (respuesta)
        {

            txtRegion.Text = string.Empty;
            string script = "alert('Region Ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarRegiones();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        RegionDTO theRegionDTO = new RegionDTO();
        theRegionDTO.IdRegion = decimal.Parse(HidIdRegion.Value);

        PaisDTO myPaisDTO = new PaisDTO();
        myPaisDTO.IdPais = decimal.Parse(ddlPais.SelectedValue);
        theRegionDTO.ThePaisDTO = myPaisDTO;
 
        theRegionDTO.DescripcionRegion = txtRegion.Text.ToUpper();
        theRegionDTO.UsuarioIngreso = myUsuario.Rut;
        bool respuesta = YouCom.bll.RegionBLL.Update(theRegionDTO);

        if (respuesta)
        {
            cargarRegiones();

            txtRegion.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Region editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptRegionInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            RegionDTO theRegionDTO = new RegionDTO();

            theRegionDTO.IdRegion = decimal.Parse(hdnTipoSistema.Value);
            theRegionDTO.UsuarioIngreso = myUsuario.Rut;

            bool respuesta = YouCom.bll.RegionBLL.ActivaRegion(theRegionDTO);
            if (respuesta)
            {
                cargarRegionInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Region Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }


        }

    }
    protected void rptRegion_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            HiddenField hdnPais = new HiddenField();
            hdnPais = (HiddenField)e.Item.FindControl("hdnIdPais");

            ddlPais.SelectedValue = hdnPais.Value;
            HidIdRegion.Value = hdnTipoSistema.Value;
            txtRegion.Text = hdnDescripcion.Value;
            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            RegionDTO theRegionDTO = new RegionDTO();
            theRegionDTO.IdRegion = decimal.Parse(hdnTipoSistema.Value);
            theRegionDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.RegionBLL.ValidaEliminacionRegion(theRegionDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar una Region con Localidad Asociadas.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {


                bool respuesta = YouCom.bll.RegionBLL.Delete(theRegionDTO);
                if (respuesta)
                {
                    cargarRegiones();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Region Eliminado correctamente.');";
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
