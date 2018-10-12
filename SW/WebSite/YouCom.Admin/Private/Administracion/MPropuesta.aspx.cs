using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Propuesta;

public partial class Admin_Administracion_MPropuesta : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarPropuesta();
            cargarPropuestaEstado();
        }
    }

    protected void cargarPropuesta()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["propuesta"] = YouCom.bll.PropuestaBLL.listaPropuestaActivo();
            rptPropuesta.DataSource = YouCom.bll.PropuestaBLL.listaPropuestaActivo();
            rptPropuesta.DataBind();
        }
        else
        {
            Session["propuesta"] = YouCom.bll.PropuestaBLL.listaPropuestaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptPropuesta.DataSource = YouCom.bll.PropuestaBLL.listaPropuestaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptPropuesta.DataBind();
        }
    }

    protected void cargarPropuestaEstado()
    {
        ddlEstado.DataSource = YouCom.bll.PropuestaEstadoBLL.listaPropuestaEstadoActivo();
        ddlEstado.DataTextField = "NombrePropuestaEstado";
        ddlEstado.DataValueField = "IdPropuestaEstado";
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("Seleccione Estado", string.Empty));
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionPropuesta.Visible = false;
        cargarPropuestaInactivo();
    }
    protected void cargarPropuestaInactivo()
    {
        IList<PropuestaDTO> propuesta = new List<PropuestaDTO>();
        propuesta = YouCom.bll.PropuestaBLL.listaPropuestaInactivo();
        if (propuesta.Any())
        {
            rptPropuestaInactivo.DataSource = propuesta;
            rptPropuestaInactivo.DataBind();
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

        PropuestaDTO thePropuestaDTO = new PropuestaDTO();
        thePropuestaDTO.NombrePropuesta = this.txtPropuestaNombre.Text.ToUpper();
        thePropuestaDTO.DescripcionPropuesta = this.txtPropuestaDescripcion.Text.ToUpper();
        thePropuestaDTO.FechaPropuesta = DateTime.ParseExact(this.FechaIngreso.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        thePropuestaDTO.DireccionPropuesta = this.txtDireccion.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        thePropuestaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        thePropuestaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.PropuestaEstadoDTO myPropuestaEstadoDTO = new YouCom.DTO.PropuestaEstadoDTO();
        myPropuestaEstadoDTO.IdPropuestaEstado = decimal.Parse(this.ddlEstado.SelectedValue);
        thePropuestaDTO.ThePropuestaEstadoDTO = myPropuestaEstadoDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO.IdFamilia = decimal.Parse(ddlFamilia.SelectedValue);
        thePropuestaDTO.TheFamiliaDTO = myFamiliaDTO;

        thePropuestaDTO.UsuarioIngreso = myUsuario.Rut;

        bool respuesta = YouCom.bll.PropuestaBLL.Insert(thePropuestaDTO);
        if (respuesta)
        {
            this.txtPropuestaNombre.Text = string.Empty;
            this.txtPropuestaDescripcion.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.FechaIngreso.Text = string.Empty;
            
            ddlCondominio.ClearSelection();
            ddlComunidad.ClearSelection();
            ddlFamilia.ClearSelection();
            
            string script = "alert('Propuesta ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarPropuesta();
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

        PropuestaDTO thePropuestaDTO = new PropuestaDTO();
        thePropuestaDTO.IdPropuesta = decimal.Parse(this.hdnPropuestaId.Value);
        thePropuestaDTO.NombrePropuesta = this.txtPropuestaNombre.Text.ToUpper();
        thePropuestaDTO.DescripcionPropuesta = this.txtPropuestaDescripcion.Text.ToUpper();
        thePropuestaDTO.FechaPropuesta = DateTime.ParseExact(this.FechaIngreso.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        thePropuestaDTO.DireccionPropuesta = this.txtDireccion.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        thePropuestaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        thePropuestaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.PropuestaEstadoDTO myPropuestaEstadoDTO = new YouCom.DTO.PropuestaEstadoDTO();
        myPropuestaEstadoDTO.IdPropuestaEstado = decimal.Parse(this.ddlEstado.SelectedValue);
        thePropuestaDTO.ThePropuestaEstadoDTO = myPropuestaEstadoDTO;

        thePropuestaDTO.MotivoEstado = txtMotivoEstado.Text;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO.IdFamilia = decimal.Parse(ddlFamilia.SelectedValue);
        thePropuestaDTO.TheFamiliaDTO = myFamiliaDTO;

        thePropuestaDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.PropuestaBLL.Update(thePropuestaDTO);

        if (respuesta)
        {

            if(ddlEstado.SelectedValue == "3")
            {
                VotacionPropuestaDTO theVotacionPropuestaDTO = new VotacionPropuestaDTO();
                theVotacionPropuestaDTO.FechaInicioVotacionPropuesta = DateTime.Now;
                theVotacionPropuestaDTO.FechaTerminoVotacionPropuesta = DateTime.Now.AddDays(30);
                
                myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
                theVotacionPropuestaDTO.TheCondominioDTO = myCondominioDTO;

                myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
                theVotacionPropuestaDTO.TheComunidadDTO = myComunidadDTO;

                YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO myVotacionPropuestaEstadoDTO = new YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO();
                myVotacionPropuestaEstadoDTO.IdVotacionPropuestaEstado = decimal.Parse(this.ddlEstado.SelectedValue);
                theVotacionPropuestaDTO.TheVotacionPropuestaEstadoDTO = myVotacionPropuestaEstadoDTO;

                theVotacionPropuestaDTO.ThePropuestaDTO = thePropuestaDTO;

                theVotacionPropuestaDTO.UsuarioIngreso = myUsuario.Rut;

                bool respuesta_votacion = YouCom.bll.VotacionPropuestaBLL.Insert(theVotacionPropuestaDTO);

                if(respuesta_votacion)
                {
                    cargarPropuesta();
                    this.txtPropuestaNombre.Text = string.Empty;
                    this.txtPropuestaDescripcion.Text = string.Empty;
                    this.txtDireccion.Text = string.Empty;
                    this.FechaIngreso.Text = string.Empty;

                    ddlCondominio.ClearSelection();
                    ddlComunidad.ClearSelection();
                    ddlFamilia.ClearSelection();

                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Se ha cambiado el estado de la propuesta correctamente.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
            }
            else
            {
                cargarPropuesta();
                this.txtPropuestaNombre.Text = string.Empty;
                this.txtPropuestaDescripcion.Text = string.Empty;
                this.txtDireccion.Text = string.Empty;
                this.FechaIngreso.Text = string.Empty;

                ddlCondominio.ClearSelection();
                ddlComunidad.ClearSelection();
                ddlFamilia.ClearSelection();

                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Propuesta editado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
        }
        else
        {
        }

    }
    protected void rptPropuestaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnPropuestaId = new HiddenField();
            hdnPropuestaId = (HiddenField)e.Item.FindControl("hdnPropuestaId");

            PropuestaDTO thePropuestaDTO = new PropuestaDTO();
            thePropuestaDTO.IdPropuesta = decimal.Parse(hdnPropuestaId.Value);
            thePropuestaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.PropuestaBLL.ActivaPropuesta(thePropuestaDTO);
            if (respuesta)
            {
                cargarPropuestaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Propuesta activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptPropuesta_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasaFamilia1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");
        DropDownList ddlFamilia = (DropDownList)wucCondominio.FindControl("ddlFamilia");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnPropuestaId = new HiddenField();
            hdnPropuestaId = (HiddenField)e.Item.FindControl("hdnPropuestaId");

            YouCom.DTO.Propuesta.PropuestaDTO thePropuestaDTO = new YouCom.DTO.Propuesta.PropuestaDTO();
            thePropuestaDTO = YouCom.bll.PropuestaBLL.detallePropuesta(decimal.Parse(hdnPropuestaId.Value));

            this.hdnPropuestaId.Value = thePropuestaDTO.IdPropuesta.ToString();
            this.txtPropuestaNombre.Text = thePropuestaDTO.NombrePropuesta;
            this.txtPropuestaDescripcion.Text = thePropuestaDTO.DescripcionPropuesta;
            this.txtDireccion.Text = thePropuestaDTO.DireccionPropuesta;

            this.FechaIngreso.Text = thePropuestaDTO.FechaPropuesta.ToShortDateString();
            
            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(thePropuestaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(thePropuestaDTO.TheComunidadDTO.IdComunidad.ToString()));

            YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

            myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamilia(thePropuestaDTO.TheFamiliaDTO.IdFamilia);

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

            ddlFamilia.SelectedIndex = ddlFamilia.Items.IndexOf(ddlFamilia.Items.FindByValue(thePropuestaDTO.TheFamiliaDTO.IdFamilia.ToString()));

            ddlEstado.SelectedIndex = ddlEstado.Items.IndexOf(ddlEstado.Items.FindByValue(thePropuestaDTO.ThePropuestaEstadoDTO.IdPropuestaEstado.ToString()));

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnPropuestaId = new HiddenField();
            hdnPropuestaId = (HiddenField)e.Item.FindControl("hdnPropuestaId");

            PropuestaDTO thePropuestaDTO = new PropuestaDTO();
            thePropuestaDTO.IdPropuesta = decimal.Parse(hdnPropuestaId.Value);
            thePropuestaDTO.UsuarioModificacion = myUsuario.Rut;

            bool respuesta = YouCom.bll.PropuestaBLL.Delete(thePropuestaDTO);
            if (respuesta)
            {
                cargarPropuesta();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Propuesta Eliminado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }
    }

    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(!string.IsNullOrEmpty(ddlEstado.SelectedValue))
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
