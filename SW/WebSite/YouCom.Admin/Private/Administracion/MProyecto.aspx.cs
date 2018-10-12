using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Administracion_MProyecto : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarProyecto();
            cargarProyectoEstado();
            cargarEmpresaContratista();
        }
    }

    protected void cargarProyecto()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["Proyecto"] = YouCom.bll.ProyectoBLL.listaProyectoActivo();
            rptProyecto.DataSource = YouCom.bll.ProyectoBLL.listaProyectoActivo();
            rptProyecto.DataBind();
        }
        else
        {
            Session["Proyecto"] = YouCom.bll.ProyectoBLL.listaProyectoActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptProyecto.DataSource = YouCom.bll.ProyectoBLL.listaProyectoActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptProyecto.DataBind();
        }
    }

    protected void cargarProyectoEstado()
    {
        ddlEstado.DataSource = YouCom.bll.ProyectoEstadoBLL.listaProyectoEstadoActivo();
        ddlEstado.DataTextField = "NombreProyectoEstado";
        ddlEstado.DataValueField = "IdProyectoEstado";
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("Seleccione Estado", string.Empty));
    }

    protected void cargarEmpresaContratista()
    {
        ddlEmpresaContratista.DataSource = YouCom.bll.EmpresaContratistaBLL.listaEmpresaContratistaActivo();
        ddlEmpresaContratista.DataTextField = "RazonSocialEmpresaContratista";
        ddlEmpresaContratista.DataValueField = "IdEmpresaContratista";
        ddlEmpresaContratista.DataBind();
        ddlEmpresaContratista.Items.Insert(0, new ListItem("Seleccione Empresa Contratista", string.Empty));
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionProyecto.Visible = false;
        cargarProyectoInactivo();
    }
    protected void cargarProyectoInactivo()
    {
        IList<ProyectoDTO> Proyecto = new List<ProyectoDTO>();
        Proyecto = YouCom.bll.ProyectoBLL.listaProyectoInactivo();
        if (Proyecto.Any())
        {
            rptProyectoInactivo.DataSource = Proyecto;
            rptProyectoInactivo.DataBind();
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

        ProyectoDTO theProyectoDTO = new ProyectoDTO();
        theProyectoDTO.NombreProyecto = this.txtProyectoNombre.Text.ToUpper();
        theProyectoDTO.DescripcionProyecto = this.txtProyectoDescripcion.Text.ToUpper();
        theProyectoDTO.FechaInicioProyecto = DateTime.ParseExact(this.FechaInicio.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theProyectoDTO.FechaTerminoProyecto = DateTime.ParseExact(this.FechaTermino.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theProyectoDTO.FechaEntregaProyecto = DateTime.ParseExact(this.FechaEntrega.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theProyectoDTO.DireccionProyecto = this.txtDireccion.Text.ToUpper();
        theProyectoDTO.PresupuestoProyecto = decimal.Parse(this.txtPresupuestoProyecto.Text);

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theProyectoDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theProyectoDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.ProyectoEstadoDTO myProyectoEstadoDTO = new YouCom.DTO.ProyectoEstadoDTO();
        myProyectoEstadoDTO.IdProyectoEstado = decimal.Parse(this.ddlEstado.SelectedValue);
        theProyectoDTO.TheProyectoEstadoDTO = myProyectoEstadoDTO;

        YouCom.DTO.EmpresaContratistaDTO myEmpresaContratistaDTO = new YouCom.DTO.EmpresaContratistaDTO();
        myEmpresaContratistaDTO.IdEmpresaContratista = decimal.Parse(this.ddlEmpresaContratista.SelectedValue);
        theProyectoDTO.TheEmpresaContratistaDTO = myEmpresaContratistaDTO;

        theProyectoDTO.UsuarioIngreso = myUsuario.Rut;

        bool respuesta = YouCom.bll.ProyectoBLL.Insert(theProyectoDTO);
        if (respuesta)
        {
            cargarProyecto();
            this.txtProyectoNombre.Text = string.Empty;
            this.txtProyectoDescripcion.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.FechaInicio.Text = string.Empty;
            this.FechaTermino.Text = string.Empty;
            this.FechaEntrega.Text = string.Empty;
            this.txtPresupuestoProyecto.Text = string.Empty;

            ddlCondominio.ClearSelection();
            ddlComunidad.ClearSelection();
            this.ddlEmpresaContratista.ClearSelection();

            string script = "alert('Proyecto ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarProyecto();
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

        ProyectoDTO theProyectoDTO = new ProyectoDTO();
        theProyectoDTO.IdProyecto = decimal.Parse(this.hdnProyectoId.Value);
        theProyectoDTO.NombreProyecto = this.txtProyectoNombre.Text.ToUpper();
        theProyectoDTO.DescripcionProyecto = this.txtProyectoDescripcion.Text.ToUpper();
        theProyectoDTO.FechaInicioProyecto = DateTime.ParseExact(this.FechaInicio.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theProyectoDTO.FechaTerminoProyecto = DateTime.ParseExact(this.FechaTermino.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theProyectoDTO.FechaEntregaProyecto = DateTime.ParseExact(this.FechaEntrega.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theProyectoDTO.DireccionProyecto = this.txtDireccion.Text.ToUpper();
        theProyectoDTO.PresupuestoProyecto = decimal.Parse(this.txtPresupuestoProyecto.Text);

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theProyectoDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theProyectoDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.ProyectoEstadoDTO myProyectoEstadoDTO = new YouCom.DTO.ProyectoEstadoDTO();
        myProyectoEstadoDTO.IdProyectoEstado = decimal.Parse(this.ddlEstado.SelectedValue);
        theProyectoDTO.TheProyectoEstadoDTO = myProyectoEstadoDTO;

        YouCom.DTO.EmpresaContratistaDTO myEmpresaContratistaDTO = new YouCom.DTO.EmpresaContratistaDTO();
        myEmpresaContratistaDTO.IdEmpresaContratista = decimal.Parse(this.ddlEmpresaContratista.SelectedValue);
        theProyectoDTO.TheEmpresaContratistaDTO = myEmpresaContratistaDTO;

        YouCom.DTO.Propuesta.PropuestaDTO myPropuestaDTO = new YouCom.DTO.Propuesta.PropuestaDTO();
        myPropuestaDTO.IdPropuesta = decimal.Parse(this.hdnPropuestaId.Value);
        theProyectoDTO.ThePropuestaDTO = myPropuestaDTO;

        theProyectoDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.ProyectoBLL.Update(theProyectoDTO);

        if (respuesta)
        {
            cargarProyecto();
            this.txtProyectoNombre.Text = string.Empty;
            this.txtProyectoDescripcion.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.FechaInicio.Text = string.Empty;
            this.FechaTermino.Text = string.Empty;
            this.FechaEntrega.Text = string.Empty;
            this.txtPresupuestoProyecto.Text = string.Empty;

            ddlCondominio.ClearSelection();
            ddlComunidad.ClearSelection();
            this.ddlEmpresaContratista.ClearSelection();

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Proyecto editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }            
        }
        else
        {
        }

    }
    protected void rptProyectoInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnProyectoId = new HiddenField();
            hdnProyectoId = (HiddenField)e.Item.FindControl("hdnProyectoId");

            ProyectoDTO theProyectoDTO = new ProyectoDTO();
            theProyectoDTO.IdProyecto = decimal.Parse(hdnProyectoId.Value);
            theProyectoDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.ProyectoBLL.ActivaProyecto(theProyectoDTO);
            if (respuesta)
            {
                cargarProyectoInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Proyecto activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptProyecto_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnProyectoId = new HiddenField();
            hdnProyectoId = (HiddenField)e.Item.FindControl("hdnProyectoId");

            YouCom.DTO.ProyectoDTO theProyectoDTO = new YouCom.DTO.ProyectoDTO();
            theProyectoDTO = YouCom.bll.ProyectoBLL.detalleProyecto(decimal.Parse(hdnProyectoId.Value));

            this.hdnProyectoId.Value = theProyectoDTO.IdProyecto.ToString();
            this.txtProyectoNombre.Text = theProyectoDTO.NombreProyecto;
            this.txtProyectoDescripcion.Text = theProyectoDTO.DescripcionProyecto;
            this.txtDireccion.Text = theProyectoDTO.DireccionProyecto;

            this.FechaInicio.Text = theProyectoDTO.FechaInicioProyecto.ToShortDateString();
            this.FechaTermino.Text = theProyectoDTO.FechaTerminoProyecto.ToShortDateString();
            this.FechaEntrega.Text = theProyectoDTO.FechaEntregaProyecto.ToShortDateString();

            this.txtPresupuestoProyecto.Text = theProyectoDTO.PresupuestoProyecto.ToString();

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(theProyectoDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(theProyectoDTO.TheComunidadDTO.IdComunidad.ToString()));

            ddlEmpresaContratista.SelectedIndex = ddlEmpresaContratista.Items.IndexOf(ddlEmpresaContratista.Items.FindByValue(theProyectoDTO.TheEmpresaContratistaDTO.IdEmpresaContratista.ToString()));

            ddlEstado.SelectedIndex = ddlEstado.Items.IndexOf(ddlEstado.Items.FindByValue(theProyectoDTO.TheProyectoEstadoDTO.IdProyectoEstado.ToString()));

            this.hdnPropuestaId.Value = theProyectoDTO.ThePropuestaDTO.IdPropuesta.ToString();

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnProyectoId = new HiddenField();
            hdnProyectoId = (HiddenField)e.Item.FindControl("hdnProyectoId");

            ProyectoDTO theProyectoDTO = new ProyectoDTO();
            theProyectoDTO.IdProyecto = decimal.Parse(hdnProyectoId.Value);
            theProyectoDTO.UsuarioModificacion = myUsuario.Rut;

            bool respuesta = YouCom.bll.ProyectoBLL.Delete(theProyectoDTO);
            if (respuesta)
            {
                cargarProyecto();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Proyecto Eliminado correctamente.');";
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
