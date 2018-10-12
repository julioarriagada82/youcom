using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Emergencia;

public partial class Admin_Mantenedores_MTipoEmergencia : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarTipoEmergencia();
        }
    }

    protected void cargarTipoEmergencia()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["TipoEmergencia"] = YouCom.bll.TipoEmergenciaBLL.getListadoTipoEmergencia();
            rptTipoEmergencia.DataSource = YouCom.bll.TipoEmergenciaBLL.listaTipoEmergenciaActivo();
            rptTipoEmergencia.DataBind();
        }
        else
        {
            Session["TipoEmergencia"] = YouCom.bll.TipoEmergenciaBLL.getListadoTipoEmergencia().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptTipoEmergencia.DataSource = YouCom.bll.TipoEmergenciaBLL.listaTipoEmergenciaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptTipoEmergencia.DataBind();
        }
    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionCasa.Visible = false;
        cargarTipoEmergenciaInactivo();
    }
    protected void cargarTipoEmergenciaInactivo()
    {
        IList<TipoEmergenciaDTO> tipo_aviso = new List<TipoEmergenciaDTO>();
        tipo_aviso = YouCom.bll.TipoEmergenciaBLL.listaTipoEmergenciaInactivo();
        if (tipo_aviso.Any())
        {
            rptTipoEmergenciaInactivo.DataSource = tipo_aviso;
            rptTipoEmergenciaInactivo.DataBind();
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

        List<TipoEmergenciaDTO> tipo_aviso = new List<TipoEmergenciaDTO>();
        tipo_aviso = (Session["TipoEmergencia"] as List<TipoEmergenciaDTO>);

        TipoEmergenciaDTO theTipoEmergenciaDTO = new TipoEmergenciaDTO();
        theTipoEmergenciaDTO.NombreTipoEmergencia = this.txtNombre.Text.ToUpper();
        theTipoEmergenciaDTO.UsuarioIngreso = myUsuario.Rut;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theTipoEmergenciaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theTipoEmergenciaDTO.TheComunidadDTO = myComunidadDTO;

        tipo_aviso = tipo_aviso.Where(x => x.NombreTipoEmergencia == theTipoEmergenciaDTO.NombreTipoEmergencia).ToList();
        if (tipo_aviso.Any())
        {
            foreach (var item in tipo_aviso)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Tipo Aviso Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Tipo Aviso ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }


        }


        bool respuesta = YouCom.bll.TipoEmergenciaBLL.Insert(theTipoEmergenciaDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            string script = "alert('Tipo Aviso Ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarTipoEmergencia();
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

        TipoEmergenciaDTO theTipoEmergenciaDTO = new TipoEmergenciaDTO();
        theTipoEmergenciaDTO.IdTipoEmergencia = decimal.Parse(this.hdnIdTipoEmergencia.Value);
        theTipoEmergenciaDTO.NombreTipoEmergencia = this.txtNombre.Text.ToUpper();
        theTipoEmergenciaDTO.UsuarioModificacion = myUsuario.Rut;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theTipoEmergenciaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theTipoEmergenciaDTO.TheComunidadDTO = myComunidadDTO;

        bool respuesta = YouCom.bll.TipoEmergenciaBLL.Update(theTipoEmergenciaDTO);

        if (respuesta)
        {
            cargarTipoEmergencia();
            this.txtNombre.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Tipo Aviso editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptTipoEmergenciaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdTipoEmergencia = new HiddenField();
            hdnIdTipoEmergencia = (HiddenField)e.Item.FindControl("hdnIdTipoEmergencia");

            TipoEmergenciaDTO theTipoEmergenciaDTO = new TipoEmergenciaDTO();
            theTipoEmergenciaDTO.IdTipoEmergencia = decimal.Parse(hdnIdTipoEmergencia.Value);
            theTipoEmergenciaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.TipoEmergenciaBLL.ActivaTipoEmergencia(theTipoEmergenciaDTO);
            if (respuesta)
            {
                cargarTipoEmergenciaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Tipo Aviso Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptTipoEmergencia_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdTipoEmergencia = new HiddenField();
            hdnIdTipoEmergencia = (HiddenField)e.Item.FindControl("hdnIdTipoEmergencia");

            YouCom.DTO.Emergencia.TipoEmergenciaDTO theTipoEmergenciaDTO = new YouCom.DTO.Emergencia.TipoEmergenciaDTO();
            theTipoEmergenciaDTO = YouCom.bll.TipoEmergenciaBLL.detalleTipoEmergencia(decimal.Parse(hdnIdTipoEmergencia.Value));

            txtNombre.Text = theTipoEmergenciaDTO.NombreTipoEmergencia;
            this.hdnIdTipoEmergencia.Value = theTipoEmergenciaDTO.IdTipoEmergencia.ToString();

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(theTipoEmergenciaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(theTipoEmergenciaDTO.TheComunidadDTO.IdComunidad.ToString()));

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdTipoEmergencia = new HiddenField();
            hdnIdTipoEmergencia = (HiddenField)e.Item.FindControl("hdnIdTipoEmergencia");

            TipoEmergenciaDTO theTipoEmergenciaDTO = new TipoEmergenciaDTO();
            theTipoEmergenciaDTO.IdTipoEmergencia = decimal.Parse(hdnIdTipoEmergencia.Value);
            theTipoEmergenciaDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.TipoEmergenciaBLL.ValidaEliminacionTipoEmergencia(theTipoEmergenciaDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un TipoEmergencia con aviso asociado.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.TipoEmergenciaBLL.Delete(theTipoEmergenciaDTO);

                if (respuesta)
                {
                    cargarTipoEmergencia();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Tipo aviso eliminado correctamente.');";
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
