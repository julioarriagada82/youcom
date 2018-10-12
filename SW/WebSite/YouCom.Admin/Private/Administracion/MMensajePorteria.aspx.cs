using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Mensajeria;

public partial class Admin_Administracion_MMensajePorteria : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarMensajePorteria();
        }
    }

    protected void cargarMensajePorteria()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["mensaje_porteria"] = YouCom.bll.Mensajeria.MensajePorteriaBLL.getListadoMensajePorteria();
            rptMensajePorteria.DataSource = YouCom.bll.Mensajeria.MensajePorteriaBLL.listaMensajePorteriaActivo().Where(x => x.IdPadre == 0).ToList();
            rptMensajePorteria.DataBind();
        }
        else
        {
            Session["mensaje_porteria"] = YouCom.bll.Mensajeria.MensajePorteriaBLL.getListadoMensajePorteria();
            rptMensajePorteria.DataSource = YouCom.bll.Mensajeria.MensajePorteriaBLL.listaMensajePorteriaActivo().Where(x => x.IdPadre == 0 && x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList(); ;
            rptMensajePorteria.DataBind();
        }
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionMensajePorteria.Visible = false;
        cargarMensajePorteriaInactivo();
    }
    protected void cargarMensajePorteriaInactivo()
    {
        IList<MensajePorteriaDTO> MensajePorteria = new List<MensajePorteriaDTO>();
        MensajePorteria = YouCom.bll.Mensajeria.MensajePorteriaBLL.listaMensajePorteriaInactivo();
        if (MensajePorteria.Any())
        {
            rptMensajePorteriaInactivo.DataSource = MensajePorteria;
            rptMensajePorteriaInactivo.DataBind();
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

        MensajePorteriaDTO theMensajePorteriaDTO = new MensajePorteriaDTO();
        theMensajePorteriaDTO.MensajeTitulo = this.txtTituloMensaje.Text.ToUpper();
        theMensajePorteriaDTO.MensajeDescripcion = this.txtMensaje.Text.ToUpper();
        theMensajePorteriaDTO.MensajeFecha = DateTime.Now;
        theMensajePorteriaDTO.IdPadre = 0;
        
        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theMensajePorteriaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theMensajePorteriaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO.IdFamilia = decimal.Parse(ddlFamilia.SelectedValue);
        theMensajePorteriaDTO.TheFamiliaDTO = myFamiliaDTO;

        YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
        myPorteriaDTO.IdPorteria = decimal.Parse(ddlPorteria.SelectedValue);
        theMensajePorteriaDTO.ThePorteriaDTO = myPorteriaDTO;

        YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO myMensajeTipoEnvioDTO = new YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO();
        myMensajeTipoEnvioDTO.IdMensajeTipoEnvio = 2;
        theMensajePorteriaDTO.TheMensajeTipoEnvioDTO = myMensajeTipoEnvioDTO;

        theMensajePorteriaDTO.UsuarioIngreso = myUsuario.Rut;

        bool respuesta = YouCom.bll.Mensajeria.MensajePorteriaBLL.Insert(theMensajePorteriaDTO);
        if (respuesta)
        {
            this.txtTituloMensaje.Text = string.Empty;
            this.txtMensaje.Text = string.Empty;
            
            string script = "alert('Mensaje enviado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarMensajePorteria();
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

        MensajePorteriaDTO theMensajePorteriaDTO = new MensajePorteriaDTO();
        theMensajePorteriaDTO.MensajeTitulo = this.txtTituloMensaje.Text.ToUpper();
        theMensajePorteriaDTO.MensajeDescripcion = this.txtMensaje.Text.ToUpper();
        theMensajePorteriaDTO.MensajeFecha = DateTime.Now;
        theMensajePorteriaDTO.IdPadre = decimal.Parse(this.hdnIdMensajePorteria.Value);

        YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO myMensajeTipoEnvioDTO = new YouCom.DTO.Mensajeria.MensajeTipoEnvioDTO();
        myMensajeTipoEnvioDTO.IdMensajeTipoEnvio = 2;
        theMensajePorteriaDTO.TheMensajeTipoEnvioDTO = myMensajeTipoEnvioDTO;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theMensajePorteriaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theMensajePorteriaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO.IdFamilia = decimal.Parse(ddlFamilia.SelectedValue);
        theMensajePorteriaDTO.TheFamiliaDTO = myFamiliaDTO;

        YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
        myPorteriaDTO.IdPorteria = decimal.Parse(ddlPorteria.SelectedValue);
        theMensajePorteriaDTO.ThePorteriaDTO = myPorteriaDTO;

        theMensajePorteriaDTO.UsuarioIngreso = myUsuario.Rut;

        bool respuesta = YouCom.bll.Mensajeria.MensajePorteriaBLL.Insert(theMensajePorteriaDTO);

        if (respuesta)
        {
            cargarMensajePorteria();
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
    protected void rptMensajePorteriaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdMensajePorteria = new HiddenField();
            hdnIdMensajePorteria = (HiddenField)e.Item.FindControl("hdnIdMensajePorteria");

            MensajePorteriaDTO theMensajePorteriaDTO = new MensajePorteriaDTO();
            theMensajePorteriaDTO.IdMensajePorteria = decimal.Parse(hdnIdMensajePorteria.Value);
            theMensajePorteriaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.Mensajeria.MensajePorteriaBLL.ActivaMensajePorteria(theMensajePorteriaDTO);
            if (respuesta)
            {
                cargarMensajePorteriaInactivo();
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
    protected void rptMensajePorteria_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasaFamilia1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");
        DropDownList ddlFamilia = (DropDownList)wucCondominio.FindControl("ddlFamilia");

        if (e.CommandName == "Ver")
        {
            HiddenField hdnIdMensajePorteria = new HiddenField();
            hdnIdMensajePorteria = (HiddenField)e.Item.FindControl("hdnIdMensajePorteria");

            YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();
            myMensajePorteriaDTO = YouCom.bll.Mensajeria.MensajePorteriaBLL.detalleMensajePorteria(decimal.Parse(hdnIdMensajePorteria.Value));

            this.hdnIdMensajePorteria.Value = myMensajePorteriaDTO.IdMensajePorteria.ToString();
            this.txtTituloMensaje.Text = myMensajePorteriaDTO.MensajeTitulo;
            this.txtMensaje.Text = myMensajePorteriaDTO.MensajeDescripcion;
            this.txtFecha.Text = myMensajePorteriaDTO.MensajeFecha.ToShortDateString();
            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myMensajePorteriaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myMensajePorteriaDTO.TheComunidadDTO.IdComunidad.ToString()));

            YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

            myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamilia(myMensajePorteriaDTO.TheFamiliaDTO.IdFamilia);

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

            ddlFamilia.SelectedIndex = ddlFamilia.Items.IndexOf(ddlFamilia.Items.FindByValue(myMensajePorteriaDTO.TheFamiliaDTO.IdFamilia.ToString()));

            ddlPorteria.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlPorteria.DataTextField = "NombreComunidad";
            ddlPorteria.DataValueField = "IdComunidad";
            ddlPorteria.DataBind();
            ddlPorteria.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlPorteria.SelectedIndex = ddlPorteria.Items.IndexOf(ddlPorteria.Items.FindByValue(myMensajePorteriaDTO.ThePorteriaDTO.IdPorteria.ToString()));

            
            btnGrabar.Visible = false;
            btnResponder.Visible = true;

        }
        if (e.CommandName == "Responder")
        {
            HiddenField hdnIdMensajePorteria = new HiddenField();
            hdnIdMensajePorteria = (HiddenField)e.Item.FindControl("hdnIdMensajePorteria");

            YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();
            myMensajePorteriaDTO = YouCom.bll.Mensajeria.MensajePorteriaBLL.detalleMensajePorteria(decimal.Parse(hdnIdMensajePorteria.Value));

            this.hdnIdMensajePorteria.Value = myMensajePorteriaDTO.IdMensajePorteria.ToString();
            this.txtTituloMensaje.Text = myMensajePorteriaDTO.MensajeTitulo;
            this.txtMensaje.Text = string.Empty;
            this.txtFecha.Text = DateTime.Now.ToShortDateString();

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myMensajePorteriaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myMensajePorteriaDTO.TheComunidadDTO.IdComunidad.ToString()));

            YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

            myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamilia(myMensajePorteriaDTO.TheFamiliaDTO.IdFamilia);

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

            ddlFamilia.SelectedIndex = ddlFamilia.Items.IndexOf(ddlFamilia.Items.FindByValue(myMensajePorteriaDTO.TheFamiliaDTO.IdFamilia.ToString()));

            ddlPorteria.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlPorteria.DataTextField = "NombreComunidad";
            ddlPorteria.DataValueField = "IdComunidad";
            ddlPorteria.DataBind();
            ddlPorteria.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlPorteria.SelectedIndex = ddlPorteria.Items.IndexOf(ddlPorteria.Items.FindByValue(myMensajePorteriaDTO.ThePorteriaDTO.IdPorteria.ToString()));

            btnGrabar.Visible = false;
            btnResponder.Visible = true;
        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdMensajePorteria = new HiddenField();
            hdnIdMensajePorteria = (HiddenField)e.Item.FindControl("hdnIdMensajePorteria");

            MensajePorteriaDTO theMensajePorteriaDTO = new MensajePorteriaDTO();
            theMensajePorteriaDTO.IdMensajePorteria = decimal.Parse(hdnIdMensajePorteria.Value);
            theMensajePorteriaDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.Mensajeria.MensajePorteriaBLL.ValidaEliminacionMensajePorteria(theMensajePorteriaDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un mensaje con informacion asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.Mensajeria.MensajePorteriaBLL.Delete(theMensajePorteriaDTO);
                if (respuesta)
                {
                    cargarMensajePorteria();
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
