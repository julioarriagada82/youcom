using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Foro;

public partial class Admin_Administracion_MForoComunidad : Intermedia.IMSystem.Navigation.Page.WebPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarForoComunidad();
            cargarCategoria();
            cargarForoComunidadEstado();
        }
    }

    protected void cargarForoComunidadEstado()
    {
        ddlEstado.DataSource = YouCom.bll.ForoComunidadEstadoBLL.listaForoComunidadEstadoActivo();
        ddlEstado.DataTextField = "NombreForoComunidadEstado";
        ddlEstado.DataValueField = "IdForoComunidadEstado";
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("Seleccione Estado", string.Empty));
    }

    protected void cargarCategoria()
    {
        IList<YouCom.DTO.CategoriaDTO> myCategoria = new List<YouCom.DTO.CategoriaDTO>();

        myCategoria = YouCom.bll.CategoriaBLL.listaCategoriaActivo();

        myCategoria = myCategoria.Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 11).ToList();

        ddlCategoria.DataSource = myCategoria;
        ddlCategoria.DataTextField = "NombreCategoria";
        ddlCategoria.DataValueField = "IdCategoria";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, new ListItem("Seleccione Categoria", string.Empty));
    }

    protected void cargarForoComunidad()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["foro_comunidad"] = YouCom.bll.ForoComunidadBLL.getListadoForoComunidad();
            rptForoComunidad.DataSource = YouCom.bll.ForoComunidadBLL.listaForoComunidadActivo().Where(x => x.IdPadre == 0).ToList();
            rptForoComunidad.DataBind();
        }
        else
        {
            Session["foro_comunidad"] = YouCom.bll.ForoComunidadBLL.getListadoForoComunidad().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptForoComunidad.DataSource = YouCom.bll.ForoComunidadBLL.listaForoComunidadActivo().Where(x => x.IdPadre == 0).ToList().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptForoComunidad.DataBind();
        }
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionForoComunidad.Visible = false;
        cargarForoComunidadInactivo();
    }
    protected void cargarForoComunidadInactivo()
    {
        IList<ForoComunidadDTO> foroComunidad = new List<ForoComunidadDTO>();
        foroComunidad = YouCom.bll.ForoComunidadBLL.listaForoComunidadInactivo();
        if (foroComunidad.Any())
        {
            rptForoComunidadInactivo.DataSource = foroComunidad;
            rptForoComunidadInactivo.DataBind();
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
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasaFamilia1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");
        DropDownList ddlFamilia = (DropDownList)wucCondominio.FindControl("ddlFamilia");

        ForoComunidadDTO theForoComunidadDTO = new ForoComunidadDTO();
        theForoComunidadDTO.TituloForoComunidad = this.txtTituloForo.Text.ToUpper();
        theForoComunidadDTO.DescripcionForoComunidad = this.txtDescripcion.Text.ToUpper();
        theForoComunidadDTO.FechaPublicacion = DateTime.Now;
        theForoComunidadDTO.IdPadre = 0;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theForoComunidadDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theForoComunidadDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO.IdFamilia = decimal.Parse(ddlFamilia.SelectedValue);
        theForoComunidadDTO.TheFamiliaDTO = myFamiliaDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theForoComunidadDTO.TheCategoriaDTO = myCategoriaDTO;

        YouCom.DTO.Foro.ForoComunidadEstadoDTO myForoComunidadEstadoDTO = new YouCom.DTO.Foro.ForoComunidadEstadoDTO();
        myForoComunidadEstadoDTO.IdForoComunidadEstado = 2;
        theForoComunidadDTO.TheForoComunidadEstadoDTO = myForoComunidadEstadoDTO;

        theForoComunidadDTO.UsuarioIngreso = myUsuario.Rut;

        bool respuesta = YouCom.bll.ForoComunidadBLL.Insert(theForoComunidadDTO);
        if (respuesta)
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtFecha.Text = string.Empty;
            this.txtTituloForo.Text = string.Empty;

            string script = "alert('Mensaje enviado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarForoComunidad();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasaFamilia1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");
        DropDownList ddlFamilia = (DropDownList)wucCondominio.FindControl("ddlFamilia");

        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        ForoComunidadDTO theForoComunidadDTO = new ForoComunidadDTO();

        theForoComunidadDTO.IdForoComunidad = decimal.Parse(this.hdnIdForoComunidad.Value);
        theForoComunidadDTO.TituloForoComunidad = this.txtTituloForo.Text.ToUpper();
        theForoComunidadDTO.DescripcionForoComunidad = this.txtDescripcion.Text.ToUpper();
        theForoComunidadDTO.FechaPublicacion = DateTime.Now;
        theForoComunidadDTO.IdPadre = 0;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theForoComunidadDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theForoComunidadDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO.IdFamilia = decimal.Parse(ddlFamilia.SelectedValue);
        theForoComunidadDTO.TheFamiliaDTO = myFamiliaDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theForoComunidadDTO.TheCategoriaDTO = myCategoriaDTO;

        YouCom.DTO.Foro.ForoComunidadEstadoDTO myForoComunidadEstadoDTO = new YouCom.DTO.Foro.ForoComunidadEstadoDTO();
        myForoComunidadEstadoDTO.IdForoComunidadEstado = decimal.Parse(ddlEstado.SelectedValue);
        theForoComunidadDTO.TheForoComunidadEstadoDTO = myForoComunidadEstadoDTO;

        if (ddlEstado.SelectedValue == "3")
        {
            theForoComunidadDTO.FechaPublicacion = DateTime.Now;
            theForoComunidadDTO.FechaTermino = DateTime.Now.AddMonths(1);
        }

        theForoComunidadDTO.MotivoEstadoForoComunidad = this.txtMotivoEstado.Text;

        theForoComunidadDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.ForoComunidadBLL.Update(theForoComunidadDTO);

        if (respuesta)
        {
            cargarForoComunidad();
            this.txtDescripcion.Text = string.Empty;
            this.txtFecha.Text = string.Empty;
            this.txtTituloForo.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Mensaje respondido correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptForoComunidadInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdForoComunidad = new HiddenField();
            hdnIdForoComunidad = (HiddenField)e.Item.FindControl("hdnIdForoComunidad");

            ForoComunidadDTO theForoComunidadDTO = new ForoComunidadDTO();
            theForoComunidadDTO.IdForoComunidad = decimal.Parse(hdnIdForoComunidad.Value);
            theForoComunidadDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.ForoComunidadBLL.ActivaForoComunidad(theForoComunidadDTO);
            if (respuesta)
            {
                cargarForoComunidadInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Foro Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptForoComunidad_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasaFamilia1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");
        DropDownList ddlFamilia = (DropDownList)wucCondominio.FindControl("ddlFamilia");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdForoComunidad = new HiddenField();
            hdnIdForoComunidad = (HiddenField)e.Item.FindControl("hdnIdForoComunidad");

            YouCom.DTO.Foro.ForoComunidadDTO myForoComunidadDTO = new YouCom.DTO.Foro.ForoComunidadDTO();
            myForoComunidadDTO = YouCom.bll.ForoComunidadBLL.detalleForoComunidad(decimal.Parse(hdnIdForoComunidad.Value));

            this.hdnIdForoComunidad.Value = myForoComunidadDTO.IdForoComunidad.ToString();
            this.txtTituloForo.Text = myForoComunidadDTO.TituloForoComunidad;
            this.txtDescripcion.Text = myForoComunidadDTO.DescripcionForoComunidad;
            this.txtFecha.Text = myForoComunidadDTO.FechaForoComunidad.ToShortDateString();
            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myForoComunidadDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myForoComunidadDTO.TheComunidadDTO.IdComunidad.ToString()));

            YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

            myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamilia(myForoComunidadDTO.TheFamiliaDTO.IdFamilia);

            ddlCasa.DataSource = YouCom.bll.CasaBLL.getListadoCasaByComunidad(decimal.Parse(ddlComunidad.SelectedValue));
            ddlCasa.DataTextField = "NombreCasa";
            ddlCasa.DataValueField = "IdCasa";
            ddlCasa.DataBind();
            ddlCasa.Items.Insert(0, new ListItem("Seleccione Casa", string.Empty));

            ddlCasa.SelectedIndex = ddlCasa.Items.IndexOf(ddlCasa.Items.FindByValue(myFamiliaDTO.TheCasaDTO.IdCasa.ToString()));

            ddlFamilia.DataSource = YouCom.bll.FamiliaBLL.getListadoFamiliaByCasa(decimal.Parse(ddlCasa.SelectedValue));
            ddlFamilia.DataTextField = "NombreCompleto";
            ddlFamilia.DataValueField = "IdFamilia";
            ddlFamilia.DataBind();
            ddlFamilia.Items.Insert(0, new ListItem("Seleccione Familia", string.Empty));

            ddlFamilia.SelectedIndex = ddlFamilia.Items.IndexOf(ddlFamilia.Items.FindByValue(myForoComunidadDTO.TheFamiliaDTO.IdFamilia.ToString()));

            ddlCategoria.SelectedIndex = ddlCategoria.Items.IndexOf(ddlCategoria.Items.FindByValue(myForoComunidadDTO.TheCategoriaDTO.IdCategoria.ToString()));

            ddlEstado.SelectedIndex = ddlEstado.Items.IndexOf(ddlEstado.Items.FindByValue(myForoComunidadDTO.TheForoComunidadEstadoDTO.IdForoComunidadEstado.ToString()));

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdForoComunidad = new HiddenField();
            hdnIdForoComunidad = (HiddenField)e.Item.FindControl("hdnIdForoComunidad");

            ForoComunidadDTO theForoComunidadDTO = new ForoComunidadDTO();
            theForoComunidadDTO.IdForoComunidad = decimal.Parse(hdnIdForoComunidad.Value);
            theForoComunidadDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.ForoComunidadBLL.ValidaEliminacionForoComunidad(theForoComunidadDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un foro con informacion asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.ForoComunidadBLL.Delete(theForoComunidadDTO);
                if (respuesta)
                {
                    cargarForoComunidad();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Foro eliminado correctamente.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
                else
                {
                }
            }
        }
    }

    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlEstado.SelectedValue))
        {
            pnlEstado.Visible = true;
        }
        else
        {
            pnlEstado.Visible = false;

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
