using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MCategoria : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarTipoCategoria();
            cargarCategoria();
        }
    }

    protected void cargarTipoCategoria()
    {
        ddlTipo.DataSource = YouCom.bll.TipoCategoriaBLL.listaTipoCategoriaActivo();
        ddlTipo.DataTextField = "NombreTipoCategoria";
        ddlTipo.DataValueField = "IdTipoCategoria";
        ddlTipo.DataBind();
        ddlTipo.Items.Insert(0, new ListItem("Seleccione Tipo Categoria", string.Empty));

    }

    protected void cargarCategoria()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["categoria"] = YouCom.bll.CategoriaBLL.getListadoCategoria();
            rptCategoria.DataSource = YouCom.bll.CategoriaBLL.listaCategoriaActivo();
            rptCategoria.DataBind();
        }
        else
        {
            Session["categoria"] = YouCom.bll.CategoriaBLL.getListadoCategoria().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptCategoria.DataSource = YouCom.bll.CategoriaBLL.listaCategoriaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptCategoria.DataBind();
        }

    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionCasa.Visible = false;
        cargarCategoriaInactivo();
    }
    protected void cargarCategoriaInactivo()
    {
        IList<CategoriaDTO> categorias = new List<CategoriaDTO>();
        categorias = YouCom.bll.CategoriaBLL.listaCategoriaInactivo();
        if (categorias.Any())
        {
            rptCategoriaInactivo.DataSource = categorias;
            rptCategoriaInactivo.DataBind();
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

        List<CategoriaDTO> categoria = new List<CategoriaDTO>();
        categoria = (Session["categoria"] as List<CategoriaDTO>);

        CategoriaDTO theCategoriaDTO = new CategoriaDTO();
        theCategoriaDTO.NombreCategoria = this.txtNombre.Text.ToUpper();
        theCategoriaDTO.DescripcionCategoria = this.txtDescripcion.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theCategoriaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theCategoriaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.TipoCategoriaDTO myTipoCategoriaDTO = new YouCom.DTO.TipoCategoriaDTO();
        myTipoCategoriaDTO.IdTipoCategoria = decimal.Parse(this.ddlTipo.SelectedValue);
        theCategoriaDTO.TheTipoCategoriaDTO = myTipoCategoriaDTO;

        theCategoriaDTO.UsuarioIngreso = myUsuario.Rut;

        categoria = categoria.Where(x => x.NombreCategoria == theCategoriaDTO.NombreCategoria).ToList();
        if (categoria.Any())
        {
            foreach (var item in categoria)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Categoria Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Categoria ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }


        }


        bool respuesta = YouCom.bll.CategoriaBLL.Insert(theCategoriaDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.ddlTipo.ClearSelection();
            string script = "alert('Categoria Ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarCategoria();
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

        CategoriaDTO theCategoriaDTO = new CategoriaDTO();
        theCategoriaDTO.IdCategoria = decimal.Parse(this.hdnIdCategoria.Value);
        theCategoriaDTO.NombreCategoria = this.txtNombre.Text;
        theCategoriaDTO.DescripcionCategoria = this.txtDescripcion.Text;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theCategoriaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theCategoriaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.TipoCategoriaDTO myTipoCategoriaDTO = new YouCom.DTO.TipoCategoriaDTO();
        myTipoCategoriaDTO.IdTipoCategoria = decimal.Parse(this.ddlTipo.SelectedValue);
        theCategoriaDTO.TheTipoCategoriaDTO = myTipoCategoriaDTO;

        theCategoriaDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.CategoriaBLL.Update(theCategoriaDTO);

        if (respuesta)
        {
            cargarCategoria();
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.ddlTipo.ClearSelection();

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Categoria editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptCategoriaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdCategoria = new HiddenField();
            hdnIdCategoria = (HiddenField)e.Item.FindControl("hdnIdCategoria");

            CategoriaDTO theCategoriaDTO = new CategoriaDTO();
            theCategoriaDTO.IdCategoria = decimal.Parse(hdnIdCategoria.Value);
            theCategoriaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.CategoriaBLL.ActivaCategoria(theCategoriaDTO);
            if (respuesta)
            {
                cargarCategoriaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Categoria Activada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptCategoria_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdCategoria = new HiddenField();
            hdnIdCategoria = (HiddenField)e.Item.FindControl("hdnIdCategoria");

            YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
            myCategoriaDTO = YouCom.bll.CategoriaBLL.detalleCategoria(decimal.Parse(hdnIdCategoria.Value));

            this.hdnIdCategoria.Value = myCategoriaDTO.IdCategoria.ToString();
            txtNombre.Text = myCategoriaDTO.NombreCategoria;
            txtDescripcion.Text = myCategoriaDTO.DescripcionCategoria;
            ddlTipo.SelectedIndex = ddlTipo.Items.IndexOf(ddlTipo.Items.FindByValue(myCategoriaDTO.TheTipoCategoriaDTO.IdTipoCategoria.ToString()));

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myCategoriaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myCategoriaDTO.TheComunidadDTO.IdComunidad.ToString()));

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdCategoria = new HiddenField();
            hdnIdCategoria = (HiddenField)e.Item.FindControl("hdnIdCategoria");

            CategoriaDTO theCategoriaDTO = new CategoriaDTO();
            theCategoriaDTO.IdCategoria = decimal.Parse(hdnIdCategoria.Value);
            theCategoriaDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.CategoriaBLL.ValidaEliminacionCategoria(theCategoriaDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un categoria con registro asociado.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.CategoriaBLL.Delete(theCategoriaDTO);
                if (respuesta)
                {
                    cargarCategoria();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Categoria Eliminada correctamente.');";
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
