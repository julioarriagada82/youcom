using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Mensajeria;

public partial class Admin_Administracion_MMensajeDirectorio : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarMensajeDirectiva();
        }
    }

    protected void cargarMensajeDirectiva()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["mensaje_porteria"] = YouCom.bll.Mensajeria.MensajeDirectivaBLL.getListadoMensajeDirectiva();
            rptMensajeDirectiva.DataSource = YouCom.bll.Mensajeria.MensajeDirectivaBLL.listaMensajeDirectivaActivo().Where(x => x.IdPadre == 0).ToList();
            rptMensajeDirectiva.DataBind();
        }
        else
        {
            Session["mensaje_porteria"] = YouCom.bll.Mensajeria.MensajeDirectivaBLL.getListadoMensajeDirectiva();
            rptMensajeDirectiva.DataSource = YouCom.bll.Mensajeria.MensajeDirectivaBLL.listaMensajeDirectivaActivo().Where(x => x.IdPadre == 0 && x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptMensajeDirectiva.DataBind();
        }
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionMensajeDirectiva.Visible = false;
        cargarMensajeDirectivaInactivo();
    }
    protected void cargarMensajeDirectivaInactivo()
    {
        IList<MensajeDirectivaDTO> MensajeDirectiva = new List<MensajeDirectivaDTO>();
        MensajeDirectiva = YouCom.bll.Mensajeria.MensajeDirectivaBLL.listaMensajeDirectivaInactivo();
        if (MensajeDirectiva.Any())
        {
            rptMensajeDirectivaInactivo.DataSource = MensajeDirectiva;
            rptMensajeDirectivaInactivo.DataBind();
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

        MensajeDirectivaDTO theMensajeDirectivaDTO = new MensajeDirectivaDTO();
        theMensajeDirectivaDTO.MensajeTitulo = this.txtTituloMensaje.Text.ToUpper();
        theMensajeDirectivaDTO.MensajeDescripcion = this.txtMensaje.Text.ToUpper();
        theMensajeDirectivaDTO.MensajeFecha = DateTime.Now;
        theMensajeDirectivaDTO.IdPadre = 0;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theMensajeDirectivaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theMensajeDirectivaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO.IdFamilia = decimal.Parse(ddlFamilia.SelectedValue);
        theMensajeDirectivaDTO.TheFamiliaDTO = myFamiliaDTO;

        YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
        myDirectivaDTO.IdDirectiva = decimal.Parse(ddlDirectiva.SelectedValue);
        theMensajeDirectivaDTO.TheDirectivaDTO = myDirectivaDTO;

        YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO myMensajeTipoEnvioDTO = new YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO();
        myMensajeTipoEnvioDTO.IdMensajeTipoEnvio = 2;
        theMensajeDirectivaDTO.TheMensajeTipoEnvioDTO = myMensajeTipoEnvioDTO;

        theMensajeDirectivaDTO.UsuarioIngreso = myUsuario.Rut;

        bool respuesta = YouCom.bll.Mensajeria.MensajeDirectivaBLL.Insert(theMensajeDirectivaDTO);
        if (respuesta)
        {
            this.txtTituloMensaje.Text = string.Empty;
            this.txtMensaje.Text = string.Empty;

            string script = "alert('Mensaje enviado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarMensajeDirectiva();
        }
        else
        {
        }
    }
    protected void btnResponder_Click(object sender, EventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasaFamilia1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");
        DropDownList ddlFamilia = (DropDownList)wucCondominio.FindControl("ddlFamilia");

        btnResponder.Visible = false;
        btnGrabar.Visible = true;

        MensajeDirectivaDTO theMensajeDirectivaDTO = new MensajeDirectivaDTO();
        theMensajeDirectivaDTO.MensajeTitulo = this.txtTituloMensaje.Text.ToUpper();
        theMensajeDirectivaDTO.MensajeDescripcion = this.txtMensaje.Text.ToUpper();
        theMensajeDirectivaDTO.MensajeFecha = DateTime.Now;
        theMensajeDirectivaDTO.IdPadre = decimal.Parse(this.hdnIdMensajeDirectiva.Value);

        YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO myMensajeTipoEnvioDTO = new YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO();
        myMensajeTipoEnvioDTO.IdMensajeTipoEnvio = 2;
        theMensajeDirectivaDTO.TheMensajeTipoEnvioDTO = myMensajeTipoEnvioDTO;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theMensajeDirectivaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theMensajeDirectivaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO.IdFamilia = decimal.Parse(ddlFamilia.SelectedValue);
        theMensajeDirectivaDTO.TheFamiliaDTO = myFamiliaDTO;

        YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
        myDirectivaDTO.IdDirectiva = decimal.Parse(ddlDirectiva.SelectedValue);
        theMensajeDirectivaDTO.TheDirectivaDTO = myDirectivaDTO;

        theMensajeDirectivaDTO.UsuarioIngreso = myUsuario.Rut;

        bool respuesta = YouCom.bll.Mensajeria.MensajeDirectivaBLL.Insert(theMensajeDirectivaDTO);

        if (respuesta)
        {
            cargarMensajeDirectiva();
            this.txtTituloMensaje.Text = string.Empty;
            this.txtMensaje.Text = string.Empty;

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
    protected void rptMensajeDirectivaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdMensajeDirectiva = new HiddenField();
            hdnIdMensajeDirectiva = (HiddenField)e.Item.FindControl("hdnIdMensajeDirectiva");

            MensajeDirectivaDTO theMensajeDirectivaDTO = new MensajeDirectivaDTO();
            theMensajeDirectivaDTO.IdMensajeDirectiva = decimal.Parse(hdnIdMensajeDirectiva.Value);
            theMensajeDirectivaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.Mensajeria.MensajeDirectivaBLL.ActivaMensajeDirectiva(theMensajeDirectivaDTO);
            if (respuesta)
            {
                cargarMensajeDirectivaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Mensaje Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptMensajeDirectiva_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasaFamilia1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");
        DropDownList ddlFamilia = (DropDownList)wucCondominio.FindControl("ddlFamilia");

        if (e.CommandName == "Ver")
        {
            HiddenField hdnIdMensajeDirectiva = new HiddenField();
            hdnIdMensajeDirectiva = (HiddenField)e.Item.FindControl("hdnIdMensajeDirectiva");

            YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();
            myMensajeDirectivaDTO = YouCom.bll.Mensajeria.MensajeDirectivaBLL.detalleMensajeDirectiva(decimal.Parse(hdnIdMensajeDirectiva.Value));

            this.hdnIdMensajeDirectiva.Value = myMensajeDirectivaDTO.IdMensajeDirectiva.ToString();
            this.txtTituloMensaje.Text = myMensajeDirectivaDTO.MensajeTitulo;
            this.txtMensaje.Text = myMensajeDirectivaDTO.MensajeDescripcion;
            this.txtFecha.Text = myMensajeDirectivaDTO.MensajeFecha.ToShortDateString();
            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myMensajeDirectivaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myMensajeDirectivaDTO.TheComunidadDTO.IdComunidad.ToString()));

            YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

            myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamilia(myMensajeDirectivaDTO.TheFamiliaDTO.IdFamilia);

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

            ddlFamilia.SelectedIndex = ddlFamilia.Items.IndexOf(ddlFamilia.Items.FindByValue(myMensajeDirectivaDTO.TheFamiliaDTO.IdFamilia.ToString()));

            ddlDirectiva.DataSource = YouCom.bll.DirectivaBLL.getListadoDirectivaByComunidad(decimal.Parse(ddlCondominio.SelectedValue));
            ddlDirectiva.DataTextField = "NombreComunidad";
            ddlDirectiva.DataValueField = "IdComunidad";
            ddlDirectiva.DataBind();
            ddlDirectiva.Items.Insert(0, new ListItem("Seleccione Directiva", string.Empty));

            ddlDirectiva.SelectedIndex = ddlDirectiva.Items.IndexOf(ddlDirectiva.Items.FindByValue(myMensajeDirectivaDTO.TheDirectivaDTO.IdDirectiva.ToString()));


            btnGrabar.Visible = false;
            btnResponder.Visible = true;

        }
        if (e.CommandName == "Responder")
        {
            HiddenField hdnIdMensajeDirectiva = new HiddenField();
            hdnIdMensajeDirectiva = (HiddenField)e.Item.FindControl("hdnIdMensajeDirectiva");

            YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();
            myMensajeDirectivaDTO = YouCom.bll.Mensajeria.MensajeDirectivaBLL.detalleMensajeDirectiva(decimal.Parse(hdnIdMensajeDirectiva.Value));

            this.hdnIdMensajeDirectiva.Value = myMensajeDirectivaDTO.IdMensajeDirectiva.ToString();
            this.txtTituloMensaje.Text = myMensajeDirectivaDTO.MensajeTitulo;
            this.txtMensaje.Text = string.Empty;
            this.txtFecha.Text = DateTime.Now.ToShortDateString();

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myMensajeDirectivaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myMensajeDirectivaDTO.TheComunidadDTO.IdComunidad.ToString()));

            YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

            myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamilia(myMensajeDirectivaDTO.TheFamiliaDTO.IdFamilia);

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

            ddlFamilia.SelectedIndex = ddlFamilia.Items.IndexOf(ddlFamilia.Items.FindByValue(myMensajeDirectivaDTO.TheFamiliaDTO.IdFamilia.ToString()));

            ddlDirectiva.DataSource = YouCom.bll.DirectivaBLL.getListadoDirectivaByComunidad(decimal.Parse(ddlCondominio.SelectedValue));
            ddlDirectiva.DataTextField = "NombreComunidad";
            ddlDirectiva.DataValueField = "IdComunidad";
            ddlDirectiva.DataBind();
            ddlDirectiva.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlDirectiva.SelectedIndex = ddlDirectiva.Items.IndexOf(ddlDirectiva.Items.FindByValue(myMensajeDirectivaDTO.TheDirectivaDTO.IdDirectiva.ToString()));

            btnGrabar.Visible = false;
            btnResponder.Visible = true;
        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdMensajeDirectiva = new HiddenField();
            hdnIdMensajeDirectiva = (HiddenField)e.Item.FindControl("hdnIdMensajeDirectiva");

            MensajeDirectivaDTO theMensajeDirectivaDTO = new MensajeDirectivaDTO();
            theMensajeDirectivaDTO.IdMensajeDirectiva = decimal.Parse(hdnIdMensajeDirectiva.Value);
            theMensajeDirectivaDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.Mensajeria.MensajeDirectivaBLL.ValidaEliminacionMensajeDirectiva(theMensajeDirectivaDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un mensaje con informacion asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.Mensajeria.MensajeDirectivaBLL.Delete(theMensajeDirectivaDTO);
                if (respuesta)
                {
                    cargarMensajeDirectiva();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Mensaje eliminado correctamente.');";
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
