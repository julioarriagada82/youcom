using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Propuesta;

public partial class Admin_Administracion_MVotacionPropuesta : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarVotacionPropuesta();
            cargarVotacionPropuestaEstado();
        }
    }

    protected void cargarVotacionPropuesta()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["VotacionPropuesta"] = YouCom.bll.VotacionPropuestaBLL.listaVotacionPropuestaActivo();
            rptVotacionPropuesta.DataSource = YouCom.bll.VotacionPropuestaBLL.listaVotacionPropuestaActivo();
            rptVotacionPropuesta.DataBind();
        }
        else
        {
            Session["VotacionPropuesta"] = YouCom.bll.VotacionPropuestaBLL.listaVotacionPropuestaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptVotacionPropuesta.DataSource = YouCom.bll.VotacionPropuestaBLL.listaVotacionPropuestaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptVotacionPropuesta.DataBind();
        }

    }

    protected void cargarVotacionPropuestaEstado()
    {
        ddlEstado.DataSource = YouCom.bll.VotacionPropuestaEstadoBLL.listaVotacionPropuestaEstadoActivo();
        ddlEstado.DataTextField = "NombreVotacionPropuestaEstado";
        ddlEstado.DataValueField = "IdVotacionPropuestaEstado";
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("Seleccione Estado", string.Empty));
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionVotacionPropuesta.Visible = false;
        cargarVotacionPropuestaInactivo();
    }
    protected void cargarVotacionPropuestaInactivo()
    {
        IList<VotacionPropuestaDTO> votacion_propuesta = new List<VotacionPropuestaDTO>();
        votacion_propuesta = YouCom.bll.VotacionPropuestaBLL.listaVotacionPropuestaInactivo();
        if (votacion_propuesta.Any())
        {
            rptVotacionPropuestaInactivo.DataSource = votacion_propuesta;
            rptVotacionPropuestaInactivo.DataBind();
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

        VotacionPropuestaDTO theVotacionPropuestaDTO = new VotacionPropuestaDTO();
        theVotacionPropuestaDTO.IdVotacionPropuesta = decimal.Parse(this.hdnVotacionPropuestaId.Value);
        theVotacionPropuestaDTO.FechaInicioVotacionPropuesta = DateTime.ParseExact(this.FechaIngreso.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theVotacionPropuestaDTO.FechaTerminoVotacionPropuesta = DateTime.ParseExact(this.FechaTermino.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theVotacionPropuestaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theVotacionPropuestaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO myVotacionPropuestaEstadoDTO = new YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO();
        myVotacionPropuestaEstadoDTO.IdVotacionPropuestaEstado = decimal.Parse(this.ddlEstado.SelectedValue);
        theVotacionPropuestaDTO.TheVotacionPropuestaEstadoDTO = myVotacionPropuestaEstadoDTO;

        YouCom.DTO.Propuesta.PropuestaDTO myPropuestaDTO = new YouCom.DTO.Propuesta.PropuestaDTO();
        myPropuestaDTO.IdPropuesta = decimal.Parse(this.HdnPropuestaId.Value);
        theVotacionPropuestaDTO.ThePropuestaDTO = myPropuestaDTO;

        theVotacionPropuestaDTO.MotivoEstado = txtMotivoEstado.Text;

        theVotacionPropuestaDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.VotacionPropuestaBLL.Insert(theVotacionPropuestaDTO);
        if (respuesta)
        {
            this.txtVotacionPropuestaNombre.Text = string.Empty;
            this.txtVotacionPropuestaDescripcion.Text = string.Empty;
            this.FechaTermino.Text = string.Empty;
            this.FechaIngreso.Text = string.Empty;

            ddlCondominio.ClearSelection();
            ddlComunidad.ClearSelection();
            ddlFamilia.ClearSelection();

            string script = "alert('VotacionPropuesta ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarVotacionPropuesta();
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

        VotacionPropuestaDTO theVotacionPropuestaDTO = new VotacionPropuestaDTO();
        theVotacionPropuestaDTO.IdVotacionPropuesta = decimal.Parse(this.hdnVotacionPropuestaId.Value);
        theVotacionPropuestaDTO.FechaInicioVotacionPropuesta = DateTime.ParseExact(this.FechaIngreso.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theVotacionPropuestaDTO.FechaTerminoVotacionPropuesta = DateTime.ParseExact(this.FechaTermino.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        
        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theVotacionPropuestaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theVotacionPropuestaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO myVotacionPropuestaEstadoDTO = new YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO();
        myVotacionPropuestaEstadoDTO.IdVotacionPropuestaEstado = decimal.Parse(this.ddlEstado.SelectedValue);
        theVotacionPropuestaDTO.TheVotacionPropuestaEstadoDTO = myVotacionPropuestaEstadoDTO;

        YouCom.DTO.Propuesta.PropuestaDTO myPropuestaDTO = new YouCom.DTO.Propuesta.PropuestaDTO();
        myPropuestaDTO.IdPropuesta = decimal.Parse(this.HdnPropuestaId.Value);
        theVotacionPropuestaDTO.ThePropuestaDTO = myPropuestaDTO;

        theVotacionPropuestaDTO.MotivoEstado = txtMotivoEstado.Text;

        theVotacionPropuestaDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.VotacionPropuestaBLL.Update(theVotacionPropuestaDTO);

        if (respuesta)
        {
            if (ddlEstado.SelectedValue == "3")
            {
                YouCom.DTO.ProyectoDTO theProyectoDTO = new YouCom.DTO.ProyectoDTO();

                myPropuestaDTO = YouCom.bll.PropuestaBLL.detallePropuesta(myPropuestaDTO.IdPropuesta);

                theProyectoDTO.ThePropuestaDTO = myPropuestaDTO;

                theProyectoDTO.NombreProyecto = myPropuestaDTO.NombrePropuesta;
                theProyectoDTO.DescripcionProyecto = myPropuestaDTO.DescripcionPropuesta;
                theProyectoDTO.FechaInicioProyecto = DateTime.Now;
                theProyectoDTO.FechaTerminoProyecto = DateTime.Now.AddDays(90);
                theProyectoDTO.FechaEntregaProyecto = DateTime.Now.AddDays(120);
                theProyectoDTO.PresupuestoProyecto = 0;
                theProyectoDTO.DireccionProyecto = myPropuestaDTO.DireccionPropuesta;

                YouCom.DTO.EmpresaContratistaDTO myEmpresaContratistaDTO = new YouCom.DTO.EmpresaContratistaDTO();
                myEmpresaContratistaDTO.IdEmpresaContratista = 1;
                theProyectoDTO.TheEmpresaContratistaDTO = myEmpresaContratistaDTO;

                YouCom.DTO.ProyectoEstadoDTO myProyectoEstadoDTO = new YouCom.DTO.ProyectoEstadoDTO();
                myProyectoEstadoDTO.IdProyectoEstado = 1;
                theProyectoDTO.TheProyectoEstadoDTO = myProyectoEstadoDTO;

                myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
                theProyectoDTO.TheCondominioDTO = myCondominioDTO;

                myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
                theProyectoDTO.TheComunidadDTO = myComunidadDTO;

                theProyectoDTO.UsuarioIngreso = myUsuario.Rut;

                bool respuesta_votacion = YouCom.bll.ProyectoBLL.Insert(theProyectoDTO);

                if (respuesta_votacion)
                {
                    cargarVotacionPropuesta();
                    this.txtVotacionPropuestaNombre.Text = string.Empty;
                    this.txtVotacionPropuestaDescripcion.Text = string.Empty;
                    this.FechaTermino.Text = string.Empty;
                    this.FechaIngreso.Text = string.Empty;

                    ddlCondominio.ClearSelection();
                    ddlComunidad.ClearSelection();
                    ddlFamilia.ClearSelection();

                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Se ha cambiado el estado de la Votacion Propuesta correctamente.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
            }
            else
            {
                cargarVotacionPropuesta();
                this.txtVotacionPropuestaNombre.Text = string.Empty;
                this.txtVotacionPropuestaDescripcion.Text = string.Empty;
                this.FechaTermino.Text = string.Empty;
                this.FechaIngreso.Text = string.Empty;

                ddlCondominio.ClearSelection();
                ddlComunidad.ClearSelection();
                ddlFamilia.ClearSelection();

                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Votacion Propuesta editado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
        }
        else
        {
        }

    }
    protected void rptVotacionPropuestaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnVotacionPropuestaId = new HiddenField();
            hdnVotacionPropuestaId = (HiddenField)e.Item.FindControl("hdnVotacionPropuestaId");

            VotacionPropuestaDTO theVotacionPropuestaDTO = new VotacionPropuestaDTO();
            theVotacionPropuestaDTO.IdVotacionPropuesta = decimal.Parse(hdnVotacionPropuestaId.Value);
            theVotacionPropuestaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.VotacionPropuestaBLL.ActivaVotacionPropuesta(theVotacionPropuestaDTO);
            if (respuesta)
            {
                cargarVotacionPropuestaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Votacion Propuesta activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptVotacionPropuesta_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasaFamilia1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");
        DropDownList ddlFamilia = (DropDownList)wucCondominio.FindControl("ddlFamilia");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnVotacionPropuestaId = new HiddenField();
            hdnVotacionPropuestaId = (HiddenField)e.Item.FindControl("hdnVotacionPropuestaId");

            YouCom.DTO.Propuesta.PropuestaDTO myPropuestaDTO = new PropuestaDTO();
            YouCom.DTO.Propuesta.VotacionPropuestaDTO theVotacionPropuestaDTO = new YouCom.DTO.Propuesta.VotacionPropuestaDTO();
            theVotacionPropuestaDTO = YouCom.bll.VotacionPropuestaBLL.detalleVotacionPropuesta(decimal.Parse(hdnVotacionPropuestaId.Value));
            
            myPropuestaDTO = YouCom.bll.PropuestaBLL.detallePropuesta(theVotacionPropuestaDTO.ThePropuestaDTO.IdPropuesta);

            this.hdnVotacionPropuestaId.Value = theVotacionPropuestaDTO.IdVotacionPropuesta.ToString();
            this.txtVotacionPropuestaNombre.Text = theVotacionPropuestaDTO.ThePropuestaDTO.NombrePropuesta;
            this.txtVotacionPropuestaDescripcion.Text = theVotacionPropuestaDTO.ThePropuestaDTO.DescripcionPropuesta;

            this.FechaTermino.Text = theVotacionPropuestaDTO.FechaTerminoVotacionPropuesta.ToShortDateString();
            this.FechaIngreso.Text = theVotacionPropuestaDTO.FechaInicioVotacionPropuesta.ToShortDateString();

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(theVotacionPropuestaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(theVotacionPropuestaDTO.TheComunidadDTO.IdComunidad.ToString()));

            YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

            myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamilia(myPropuestaDTO.TheFamiliaDTO.IdFamilia);

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

            ddlFamilia.SelectedIndex = ddlFamilia.Items.IndexOf(ddlFamilia.Items.FindByValue(myPropuestaDTO.TheFamiliaDTO.IdFamilia.ToString()));

            ddlEstado.SelectedIndex = ddlEstado.Items.IndexOf(ddlEstado.Items.FindByValue(theVotacionPropuestaDTO.TheVotacionPropuestaEstadoDTO.IdVotacionPropuestaEstado.ToString()));

            this.HdnPropuestaId.Value = theVotacionPropuestaDTO.ThePropuestaDTO.IdPropuesta.ToString();

            IList<VotacionPropuestaRespuestaDTO> theVotacionPropuestaRespuestaDTO = new List<VotacionPropuestaRespuestaDTO>();
            theVotacionPropuestaRespuestaDTO = YouCom.bll.VotacionPropuestaRespuestaBLL.getListadoVotacionPropuestaRespuestaByVotacion(decimal.Parse(hdnVotacionPropuestaId.Value));

            LitCantidadSi.Text = theVotacionPropuestaRespuestaDTO.Where(x => x.EleccionVotacion == "SI").Count().ToString();
            LitCantidadNo.Text = theVotacionPropuestaRespuestaDTO.Where(x => x.EleccionVotacion == "NO").Count().ToString();

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnVotacionPropuestaId = new HiddenField();
            hdnVotacionPropuestaId = (HiddenField)e.Item.FindControl("hdnVotacionPropuestaId");

            VotacionPropuestaDTO theVotacionPropuestaDTO = new VotacionPropuestaDTO();
            theVotacionPropuestaDTO.IdVotacionPropuesta = decimal.Parse(hdnVotacionPropuestaId.Value);
            theVotacionPropuestaDTO.UsuarioModificacion = myUsuario.Rut;

            bool respuesta = YouCom.bll.VotacionPropuestaBLL.Delete(theVotacionPropuestaDTO);
            if (respuesta)
            {
                cargarVotacionPropuesta();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('VotacionPropuesta Eliminado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }
        if (e.CommandName == "Votaciones")
        {
            HiddenField hdnVotacionPropuestaId = new HiddenField();
            hdnVotacionPropuestaId = (HiddenField)e.Item.FindControl("hdnVotacionPropuestaId");

            pnlAdministracionVotacionPropuesta.Visible = false;
            pnlVotaciones.Visible = true;

            IList<VotacionPropuestaRespuestaDTO> theVotacionPropuestaRespuestaDTO = new List<VotacionPropuestaRespuestaDTO>();

            theVotacionPropuestaRespuestaDTO = YouCom.bll.VotacionPropuestaRespuestaBLL.getListadoVotacionPropuestaRespuestaByVotacion(decimal.Parse(hdnVotacionPropuestaId.Value));

            rptVotaciones.DataSource = theVotacionPropuestaRespuestaDTO;
            rptVotaciones.DataBind();

            
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
