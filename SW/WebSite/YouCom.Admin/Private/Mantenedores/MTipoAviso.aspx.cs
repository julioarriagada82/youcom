using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Avisos;

public partial class Admin_Mantenedores_MTipoAviso : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarTipoAviso();
        }
    }

    protected void cargarTipoAviso()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["tipoAviso"] = YouCom.bll.Avisos.TipoAvisoBLL.getListadoTipoAviso();
            rptTipoAviso.DataSource = YouCom.bll.Avisos.TipoAvisoBLL.listaTipoAvisoActivo();
            rptTipoAviso.DataBind();
        }
        else
        {
            Session["tipoAviso"] = YouCom.bll.Avisos.TipoAvisoBLL.getListadoTipoAviso().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptTipoAviso.DataSource = YouCom.bll.Avisos.TipoAvisoBLL.listaTipoAvisoActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptTipoAviso.DataBind();
        }
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionCasa.Visible = false;
        cargarTipoAvisoInactivo();
    }
    protected void cargarTipoAvisoInactivo()
    {
        IList<TipoAvisoDTO> tipo_aviso = new List<TipoAvisoDTO>();
        tipo_aviso = YouCom.bll.Avisos.TipoAvisoBLL.listaTipoAvisoInactivo();
        if (tipo_aviso.Any())
        {
            rptTipoAvisoInactivo.DataSource = tipo_aviso;
            rptTipoAvisoInactivo.DataBind();
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

        List<TipoAvisoDTO> tipo_aviso = new List<TipoAvisoDTO>();
        tipo_aviso = (Session["tipoAviso"] as List<TipoAvisoDTO>);

        TipoAvisoDTO theTipoAvisoDTO = new TipoAvisoDTO();
        theTipoAvisoDTO.NombreTipoAviso = this.txtNombre.Text.ToUpper();
        theTipoAvisoDTO.UsuarioIngreso = myUsuario.Rut;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theTipoAvisoDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theTipoAvisoDTO.TheComunidadDTO = myComunidadDTO;

        tipo_aviso = tipo_aviso.Where(x => x.NombreTipoAviso == theTipoAvisoDTO.NombreTipoAviso).ToList();
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


        bool respuesta = YouCom.bll.Avisos.TipoAvisoBLL.Insert(theTipoAvisoDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            string script = "alert('Tipo Aviso Ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarTipoAviso();
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

        TipoAvisoDTO theTipoAvisoDTO = new TipoAvisoDTO();
        theTipoAvisoDTO.IdTipoAviso = decimal.Parse(this.hdnIdTipoAviso.Value);
        theTipoAvisoDTO.NombreTipoAviso = this.txtNombre.Text.ToUpper();
        theTipoAvisoDTO.UsuarioModificacion = myUsuario.Rut;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theTipoAvisoDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theTipoAvisoDTO.TheComunidadDTO = myComunidadDTO;

        bool respuesta = YouCom.bll.Avisos.TipoAvisoBLL.Update(theTipoAvisoDTO);

        if (respuesta)
        {
            cargarTipoAviso();
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
    protected void rptTipoAvisoInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdTipoAviso = new HiddenField();
            hdnIdTipoAviso = (HiddenField)e.Item.FindControl("hdnIdTipoAviso");

            TipoAvisoDTO theTipoAvisoDTO = new TipoAvisoDTO();
            theTipoAvisoDTO.IdTipoAviso = decimal.Parse(hdnIdTipoAviso.Value);
            theTipoAvisoDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.Avisos.TipoAvisoBLL.ActivaTipoAviso(theTipoAvisoDTO);
            if (respuesta)
            {
                cargarTipoAvisoInactivo();
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
    protected void rptTipoAviso_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdTipoAviso = new HiddenField();
            hdnIdTipoAviso = (HiddenField)e.Item.FindControl("hdnIdTipoAviso");

            YouCom.DTO.Avisos.TipoAvisoDTO theTipoAvisoDTO = new YouCom.DTO.Avisos.TipoAvisoDTO();
            theTipoAvisoDTO = YouCom.bll.Avisos.TipoAvisoBLL.detalleTipoAviso(decimal.Parse(hdnIdTipoAviso.Value));

            txtNombre.Text = theTipoAvisoDTO.NombreTipoAviso;
            this.hdnIdTipoAviso.Value = theTipoAvisoDTO.IdTipoAviso.ToString();

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(theTipoAvisoDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(theTipoAvisoDTO.TheComunidadDTO.IdComunidad.ToString()));
            
            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdTipoAviso = new HiddenField();
            hdnIdTipoAviso = (HiddenField)e.Item.FindControl("hdnIdTipoAviso");

            TipoAvisoDTO theTipoAvisoDTO = new TipoAvisoDTO();
            theTipoAvisoDTO.IdTipoAviso = decimal.Parse(hdnIdTipoAviso.Value);
            theTipoAvisoDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.Avisos.TipoAvisoBLL.ValidaEliminacionTipoAviso(theTipoAvisoDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un tipoaviso con aviso asociado.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.Avisos.TipoAvisoBLL.Delete(theTipoAvisoDTO);

                if (respuesta)
                {
                    cargarTipoAviso();
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
