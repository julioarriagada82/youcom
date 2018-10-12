using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MComuna : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarCiudad();
            cargarComuna();
        }
    }

    protected void cargarCiudad()
    {
        ddlCiudad.DataSource = YouCom.bll.CiudadBLL.listaCiudadActivo();
        ddlCiudad.DataTextField = "NombreCiudad";
        ddlCiudad.DataValueField = "IdCiudad";
        ddlCiudad.DataBind();
        ddlCiudad.Items.Insert(0, new ListItem("Seleccione Ciudad", string.Empty));
    }

    protected void cargarComuna()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["comuna"] = YouCom.bll.ComunaBLL.getListadoComuna();
            rptComuna.DataSource = YouCom.bll.ComunaBLL.listaComunaActivo();
            rptComuna.DataBind();
        }
        else
        {
            Session["comuna"] = YouCom.bll.ComunaBLL.getListadoComuna().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptComuna.DataSource = YouCom.bll.ComunaBLL.listaComunaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptComuna.DataBind();
        }

    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionCasa.Visible = false;
        cargarComunaInactivo();
    }
    protected void cargarComunaInactivo()
    {
        IList<ComunaDTO> comunas = new List<ComunaDTO>();
        comunas = YouCom.bll.ComunaBLL.listaComunaInactivo();
        if (comunas.Any())
        {
            rptComunaInactivo.DataSource = comunas;
            rptComunaInactivo.DataBind();
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
        List<ComunaDTO> comuna = new List<ComunaDTO>();
        comuna = (Session["comuna"] as List<ComunaDTO>);

        ComunaDTO theComunaDTO = new ComunaDTO();
        theComunaDTO.NombreComuna = this.txtNombre.Text.ToUpper();
        theComunaDTO.DescripcionComuna = this.txtNombre.Text.ToUpper();

        CiudadDTO myCiudadDTO = new CiudadDTO();

        myCiudadDTO.IdCiudad = decimal.Parse(this.ddlCiudad.SelectedValue);
        theComunaDTO.TheCiudadDTO = myCiudadDTO;

        theComunaDTO.UsuarioIngreso = myUsuario.Rut;

        comuna = comuna.Where(x => x.NombreComuna == theComunaDTO.NombreComuna).ToList();
        if (comuna.Any())
        {
            foreach (var item in comuna)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Comuna Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Comuna ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }


        }


        bool respuesta = YouCom.bll.ComunaBLL.Insert(theComunaDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            this.ddlCiudad.ClearSelection();
            string script = "alert('Comuna Ingresada correctamente.');";
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

        ComunaDTO theComunaDTO = new ComunaDTO();
        theComunaDTO.IdComuna = decimal.Parse(this.hdnIdComuna.Value);
        theComunaDTO.NombreComuna = this.txtNombre.Text.ToUpper();
        theComunaDTO.DescripcionComuna = this.txtNombre.Text.ToUpper();
        CiudadDTO myCiudadDTO = new CiudadDTO();

        myCiudadDTO.IdCiudad = decimal.Parse(this.ddlCiudad.SelectedValue);
        theComunaDTO.TheCiudadDTO = myCiudadDTO;

        theComunaDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.ComunaBLL.Update(theComunaDTO);

        if (respuesta)
        {
            cargarComuna();
            this.txtNombre.Text = string.Empty;
            this.ddlCiudad.ClearSelection();

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Comuna editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptComunaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdComuna = new HiddenField();
            hdnIdComuna = (HiddenField)e.Item.FindControl("hdnIdComuna");

            ComunaDTO theComunaDTO = new ComunaDTO();
            theComunaDTO.IdComuna = decimal.Parse(hdnIdComuna.Value);
            theComunaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.ComunaBLL.ActivaComuna(theComunaDTO);
            if (respuesta)
            {
                cargarComunaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Comuna Activada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptComuna_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdComuna = new HiddenField();
            hdnIdComuna = (HiddenField)e.Item.FindControl("hdnIdComuna");

            YouCom.DTO.ComunaDTO myComunaDTO = new YouCom.DTO.ComunaDTO();
            myComunaDTO = YouCom.bll.ComunaBLL.detalleComuna(decimal.Parse(hdnIdComuna.Value));

            this.hdnIdComuna.Value = myComunaDTO.IdComuna.ToString();
            txtNombre.Text = myComunaDTO.NombreComuna;
            ddlCiudad.SelectedIndex = ddlCiudad.Items.IndexOf(ddlCiudad.Items.FindByValue(myComunaDTO.TheCiudadDTO.IdCiudad.ToString()));

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdCiudad = new HiddenField();
            hdnIdCiudad = (HiddenField)e.Item.FindControl("hdnIdCiudad");

            ComunaDTO theComunaDTO = new ComunaDTO();
            theComunaDTO.IdComuna = decimal.Parse(hdnIdComuna.Value);
            theComunaDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.ComunaBLL.ValidaEliminacionComuna(theComunaDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un Comuna con registro asociado.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.ComunaBLL.Delete(theComunaDTO);
                if (respuesta)
                {
                    cargarCiudad();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Comuna Eliminada correctamente.');";
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
