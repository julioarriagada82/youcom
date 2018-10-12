using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Emergencia;

public partial class Admin_Mantenedores_MEmergencia : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarTipoEmergencia();
            cargarEmergencia();
        }
    }

    protected void cargarTipoEmergencia()
    {
        ddlTipo.DataSource = YouCom.bll.TipoEmergenciaBLL.listaTipoEmergenciaActivo();
        ddlTipo.DataTextField = "NombreTipoEmergencia";
        ddlTipo.DataValueField = "IdTipoEmergencia";
        ddlTipo.DataBind();
        ddlTipo.Items.Insert(0, new ListItem("Seleccione Tipo Emergencia", string.Empty));

    }

    protected void cargarEmergencia()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["emergencia"] = YouCom.bll.EmergenciaBLL.getListadoEmergencia();
            rptEmergencia.DataSource = YouCom.bll.EmergenciaBLL.listaEmergenciaActivo();
            rptEmergencia.DataBind();
        }
        else
        {
            Session["emergencia"] = YouCom.bll.EmergenciaBLL.getListadoEmergencia().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptEmergencia.DataSource = YouCom.bll.EmergenciaBLL.listaEmergenciaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptEmergencia.DataBind();
        }

    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionEmergencia.Visible = false;
        cargarEmergenciaInactivo();
    }
    protected void cargarEmergenciaInactivo()
    {
        IList<EmergenciaDTO> Emergencias = new List<EmergenciaDTO>();
        Emergencias = YouCom.bll.EmergenciaBLL.listaEmergenciaInactivo();
        if (Emergencias.Any())
        {
            rptEmergenciaInactivo.DataSource = Emergencias;
            rptEmergenciaInactivo.DataBind();
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

        List<EmergenciaDTO> emergencia = new List<EmergenciaDTO>();
        emergencia = (Session["emergencia"] as List<EmergenciaDTO>);

        EmergenciaDTO theEmergenciaDTO = new EmergenciaDTO();
        theEmergenciaDTO.NombreEmergencia = this.txtNombre.Text.ToUpper();
        theEmergenciaDTO.DescripcionEmergencia = this.txtDescripcion.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theEmergenciaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theEmergenciaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Emergencia.TipoEmergenciaDTO myTipoEmergenciaDTO = new YouCom.DTO.Emergencia.TipoEmergenciaDTO();
        myTipoEmergenciaDTO.IdTipoEmergencia = decimal.Parse(this.ddlTipo.SelectedValue);
        theEmergenciaDTO.TheTipoEmergenciaDTO = myTipoEmergenciaDTO;

        theEmergenciaDTO.UsuarioIngreso = myUsuario.Rut;

        emergencia = emergencia.Where(x => x.NombreEmergencia == theEmergenciaDTO.NombreEmergencia).ToList();
        if (emergencia.Any())
        {
            foreach (var item in emergencia)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Emergencia Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Emergencia ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }


        bool respuesta = YouCom.bll.EmergenciaBLL.Insert(theEmergenciaDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            string script = "alert('Emergencia Ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarEmergencia();
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

        EmergenciaDTO theEmergenciaDTO = new EmergenciaDTO();
        theEmergenciaDTO.IdEmergencia = decimal.Parse(this.hdnIdEmergencia.Value);

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theEmergenciaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theEmergenciaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Emergencia.TipoEmergenciaDTO myTipoEmergenciaDTO = new YouCom.DTO.Emergencia.TipoEmergenciaDTO();
        myTipoEmergenciaDTO.IdTipoEmergencia = decimal.Parse(this.ddlTipo.SelectedValue);
        theEmergenciaDTO.TheTipoEmergenciaDTO = myTipoEmergenciaDTO;

        theEmergenciaDTO.NombreEmergencia = this.txtNombre.Text;
        theEmergenciaDTO.DescripcionEmergencia = this.txtDescripcion.Text;
        theEmergenciaDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.EmergenciaBLL.Update(theEmergenciaDTO);

        if (respuesta)
        {
            cargarEmergencia();
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        
            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Emergencia editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptEmergenciaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdEmergencia = new HiddenField();
            hdnIdEmergencia = (HiddenField)e.Item.FindControl("hdnIdEmergencia");

            EmergenciaDTO theEmergenciaDTO = new EmergenciaDTO();
            theEmergenciaDTO.IdEmergencia = decimal.Parse(hdnIdEmergencia.Value);
            theEmergenciaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.EmergenciaBLL.ActivaEmergencia(theEmergenciaDTO);
            if (respuesta)
            {
                cargarEmergenciaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Emergencia Activada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptEmergencia_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdEmergencia = new HiddenField();
            hdnIdEmergencia = (HiddenField)e.Item.FindControl("hdnIdEmergencia");

            YouCom.DTO.Emergencia.EmergenciaDTO myEmergenciaDTO = new YouCom.DTO.Emergencia.EmergenciaDTO();
            myEmergenciaDTO = YouCom.bll.EmergenciaBLL.detalleEmergencia(decimal.Parse(hdnIdEmergencia.Value));

            this.hdnIdEmergencia.Value = myEmergenciaDTO.IdEmergencia.ToString();
            txtNombre.Text = myEmergenciaDTO.NombreEmergencia;
            txtDescripcion.Text = myEmergenciaDTO.DescripcionEmergencia;

            ddlTipo.SelectedIndex = ddlTipo.Items.IndexOf(ddlTipo.Items.FindByValue(myEmergenciaDTO.TheTipoEmergenciaDTO.IdTipoEmergencia.ToString()));

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myEmergenciaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myEmergenciaDTO.TheComunidadDTO.IdComunidad.ToString()));

        
            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdEmergencia = new HiddenField();
            hdnIdEmergencia = (HiddenField)e.Item.FindControl("hdnIdEmergencia");

            EmergenciaDTO theEmergenciaDTO = new EmergenciaDTO();
            theEmergenciaDTO.IdEmergencia = decimal.Parse(hdnIdEmergencia.Value);
            theEmergenciaDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.EmergenciaBLL.ValidaEliminacionEmergencia(theEmergenciaDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un Emergencia con registro asociado.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.EmergenciaBLL.Delete(theEmergenciaDTO);
                if (respuesta)
                {
                    cargarEmergencia();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Emergencia Eliminada correctamente.');";
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
