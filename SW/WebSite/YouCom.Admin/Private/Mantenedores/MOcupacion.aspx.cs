using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using YouCom.DTO.Propietario;

public partial class Admin_Mantenedores_MOcupacion : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarOcupacion();
        }
    }

    protected void cargarOcupacion()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["ocupacion"] = YouCom.bll.OcupacionBLL.getListadoOcupacion();
            rptOcupacion.DataSource = YouCom.bll.OcupacionBLL.listaOcupacionActivo();
            rptOcupacion.DataBind();

        }
        else
        {
            Session["ocupacion"] = YouCom.bll.OcupacionBLL.getListadoOcupacion().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptOcupacion.DataSource = YouCom.bll.OcupacionBLL.listaOcupacionActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptOcupacion.DataBind();
        }

    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionOcupacion.Visible = false;
        cargarOcupacionInactivo();
    }
    protected void cargarOcupacionInactivo()
    {
        IList<OcupacionDTO> ocupacion = new List<OcupacionDTO>();
        ocupacion = YouCom.bll.OcupacionBLL.listaOcupacionInactivo();
        if (ocupacion.Any())
        {
            rptOcupacionInactivo.DataSource = ocupacion;
            rptOcupacionInactivo.DataBind();
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
        IList<OcupacionDTO> ocupacion = new List<OcupacionDTO>();
        ocupacion = (Session["ocupacion"] as List<OcupacionDTO>);

        OcupacionDTO theOcupacionDTO = new OcupacionDTO();
        theOcupacionDTO.NombreOcupacion = this.txtNombre.Text.ToUpper();
        theOcupacionDTO.UsuarioIngreso = myUsuario.Rut;

        ocupacion = ocupacion.Where(x => x.NombreOcupacion == theOcupacionDTO.NombreOcupacion).ToList();
        if (ocupacion.Any())
        {
            foreach (var item in ocupacion)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Ocupación Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Ocupación ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.OcupacionBLL.Insert(theOcupacionDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            string script = "alert('Ocupación Ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarOcupacion();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        OcupacionDTO theOcupacionDTO = new OcupacionDTO();
        theOcupacionDTO.IdOcupacion = decimal.Parse(this.HdnIdOcupacion.Value);
        theOcupacionDTO.NombreOcupacion = this.txtNombre.Text;
        theOcupacionDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.OcupacionBLL.Update(theOcupacionDTO);

        if (respuesta)
        {
            cargarOcupacion();
            this.txtNombre.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Ocupación editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptOcupacionInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField HdnIdOcupacion = new HiddenField();
            HdnIdOcupacion = (HiddenField)e.Item.FindControl("HdnIdOcupacion");

            OcupacionDTO theOcupacionDTO = new OcupacionDTO();
            theOcupacionDTO.IdOcupacion = decimal.Parse(HdnIdOcupacion.Value);
            theOcupacionDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.OcupacionBLL.ActivaOcupacion(theOcupacionDTO);
            if (respuesta)
            {
                cargarOcupacionInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Ocupación Activada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptOcupacion_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            HiddenField HdnIdOcupacion = new HiddenField();
            HdnIdOcupacion = (HiddenField)e.Item.FindControl("HdnIdOcupacion");

            YouCom.DTO.Propietario.OcupacionDTO theOcupacionDTO = new YouCom.DTO.Propietario.OcupacionDTO();
            theOcupacionDTO = YouCom.bll.OcupacionBLL.detalleOcupacion(decimal.Parse(HdnIdOcupacion.Value));

            this.HdnIdOcupacion.Value = theOcupacionDTO.IdOcupacion.ToString();
            txtNombre.Text = theOcupacionDTO.NombreOcupacion;

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField HdnIdOcupacion = new HiddenField();
            HdnIdOcupacion = (HiddenField)e.Item.FindControl("HdnIdOcupacion");

            OcupacionDTO theOcupacionDTO = new OcupacionDTO();
            theOcupacionDTO.IdOcupacion = decimal.Parse(HdnIdOcupacion.Value);
            theOcupacionDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.OcupacionBLL.ValidaEliminacionOcupacion(theOcupacionDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar una ocupacion con información asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.OcupacionBLL.Delete(theOcupacionDTO);
                if (respuesta)
                {
                    cargarOcupacion();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Ocupacion Eliminada correctamente.');";
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
