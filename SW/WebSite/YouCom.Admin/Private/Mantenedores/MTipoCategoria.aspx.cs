using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MTipoCategoria : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarTipoCategoria();
        }
    }

    protected void cargarTipoCategoria()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["TipoCategoria"] = YouCom.bll.TipoCategoriaBLL.getListadoTipoCategoria();
            rptTipoCategoria.DataSource = YouCom.bll.TipoCategoriaBLL.listaTipoCategoriaActivo();
            rptTipoCategoria.DataBind();
        }
        else
        {
            Session["TipoCategoria"] = YouCom.bll.TipoCategoriaBLL.getListadoTipoCategoria().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptTipoCategoria.DataSource = YouCom.bll.TipoCategoriaBLL.listaTipoCategoriaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptTipoCategoria.DataBind();
        }
    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionCasa.Visible = false;
        cargarTipoCategoriaInactivo();
    }
    protected void cargarTipoCategoriaInactivo()
    {
        IList<TipoCategoriaDTO> tipo_aviso = new List<TipoCategoriaDTO>();
        tipo_aviso = YouCom.bll.TipoCategoriaBLL.listaTipoCategoriaInactivo();
        if (tipo_aviso.Any())
        {
            rptTipoCategoriaInactivo.DataSource = tipo_aviso;
            rptTipoCategoriaInactivo.DataBind();
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

        List<TipoCategoriaDTO> tipo_aviso = new List<TipoCategoriaDTO>();
        tipo_aviso = (Session["TipoCategoria"] as List<TipoCategoriaDTO>);

        TipoCategoriaDTO theTipoCategoriaDTO = new TipoCategoriaDTO();
        theTipoCategoriaDTO.NombreTipoCategoria = this.txtNombre.Text.ToUpper();
        theTipoCategoriaDTO.UsuarioIngreso = myUsuario.Rut;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theTipoCategoriaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theTipoCategoriaDTO.TheComunidadDTO = myComunidadDTO;

        tipo_aviso = tipo_aviso.Where(x => x.NombreTipoCategoria == theTipoCategoriaDTO.NombreTipoCategoria).ToList();
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


        bool respuesta = YouCom.bll.TipoCategoriaBLL.Insert(theTipoCategoriaDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            string script = "alert('Tipo Aviso Ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarTipoCategoria();
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

        TipoCategoriaDTO theTipoCategoriaDTO = new TipoCategoriaDTO();
        theTipoCategoriaDTO.IdTipoCategoria = decimal.Parse(this.hdnIdTipoCategoria.Value);
        theTipoCategoriaDTO.NombreTipoCategoria = this.txtNombre.Text.ToUpper();
        theTipoCategoriaDTO.UsuarioModificacion = myUsuario.Rut;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theTipoCategoriaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theTipoCategoriaDTO.TheComunidadDTO = myComunidadDTO;

        bool respuesta = YouCom.bll.TipoCategoriaBLL.Update(theTipoCategoriaDTO);

        if (respuesta)
        {
            cargarTipoCategoria();
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
    protected void rptTipoCategoriaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdTipoCategoria = new HiddenField();
            hdnIdTipoCategoria = (HiddenField)e.Item.FindControl("hdnIdTipoCategoria");

            TipoCategoriaDTO theTipoCategoriaDTO = new TipoCategoriaDTO();
            theTipoCategoriaDTO.IdTipoCategoria = decimal.Parse(hdnIdTipoCategoria.Value);
            theTipoCategoriaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.TipoCategoriaBLL.ActivaTipoCategoria(theTipoCategoriaDTO);
            if (respuesta)
            {
                cargarTipoCategoriaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Tipo Categoria Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptTipoCategoria_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdTipoCategoria = new HiddenField();
            hdnIdTipoCategoria = (HiddenField)e.Item.FindControl("hdnIdTipoCategoria");

            YouCom.DTO.TipoCategoriaDTO theTipoCategoriaDTO = new YouCom.DTO.TipoCategoriaDTO();
            theTipoCategoriaDTO = YouCom.bll.TipoCategoriaBLL.detalleTipoCategoria(decimal.Parse(hdnIdTipoCategoria.Value));

            txtNombre.Text = theTipoCategoriaDTO.NombreTipoCategoria;
            this.hdnIdTipoCategoria.Value = theTipoCategoriaDTO.IdTipoCategoria.ToString();

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(theTipoCategoriaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(theTipoCategoriaDTO.TheComunidadDTO.IdComunidad.ToString()));

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdTipoCategoria = new HiddenField();
            hdnIdTipoCategoria = (HiddenField)e.Item.FindControl("hdnIdTipoCategoria");

            TipoCategoriaDTO theTipoCategoriaDTO = new TipoCategoriaDTO();
            theTipoCategoriaDTO.IdTipoCategoria = decimal.Parse(hdnIdTipoCategoria.Value);
            theTipoCategoriaDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.TipoCategoriaBLL.ValidaEliminacionTipoCategoria(theTipoCategoriaDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un Tipo Categoria con aviso asociado.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.TipoCategoriaBLL.Delete(theTipoCategoriaDTO);
                if (respuesta)
                {
                    cargarTipoCategoria();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Tipo Categoria Eliminada correctamente.');";
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
