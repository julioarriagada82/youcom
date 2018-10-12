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

public partial class Admin_Mantenedores_MCasa : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarCasa();
            cargarParametros();
        }
    }

    protected void cargarParametros()
    {
        ddlAnexoTelefono.DataSource = YouCom.bll.ParametrosBLL.getListadoParametrosByConcepto("ANEXOTELEFONO");
        ddlAnexoTelefono.DataTextField = "Descripcion";
        ddlAnexoTelefono.DataValueField = "Codigo";
        ddlAnexoTelefono.DataBind();
        ddlAnexoTelefono.Items.Insert(0, new ListItem("--", string.Empty));
    }

    protected void cargarCasa()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["casa"] = YouCom.bll.CasaBLL.getListadoCasa();
            rptCasa.DataSource = YouCom.bll.CasaBLL.listaCasaActivo();
            rptCasa.DataBind();
        }
        else
        {
            Session["casa"] = YouCom.bll.CasaBLL.getListadoCasa().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptCasa.DataSource = YouCom.bll.CasaBLL.listaCasaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptCasa.DataBind();
        }
    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionCasa.Visible = false;
        cargarCasaInactivo();
    }
    protected void cargarCasaInactivo()
    {
        IList<CasaDTO> casas = new List<CasaDTO>();
        casas = YouCom.bll.CasaBLL.listaCasaInactivo();
        if (casas.Any())
        {
            rptCargoInactivo.DataSource = casas;
            rptCargoInactivo.DataBind();
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

        List<CasaDTO> casa = new List<CasaDTO>();
        casa = (Session["casa"] as List<CasaDTO>);

        CasaDTO theCasaDTO = new CasaDTO();
        theCasaDTO.NombreCasa = this.txtNombre.Text.ToUpper();
        theCasaDTO.DireccionCasa = this.txtDireccion.Text.ToUpper();
        theCasaDTO.TelefonoCasa = this.txtTelefono.Text;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theCasaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theCasaDTO.TheComunidadDTO = myComunidadDTO;

        theCasaDTO.UsuarioIngreso = myUsuario.Rut;

        casa = casa.Where(x => x.NombreCasa == theCasaDTO.NombreCasa).ToList();
        if (casa.Any())
        {
            foreach (var item in casa)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Casa Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Casa ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }


        }

        bool respuesta = YouCom.bll.CasaBLL.Insert(theCasaDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            string script = "alert('Casa Ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarCasa();
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

        CasaDTO theCasaDTO = new CasaDTO();
        theCasaDTO.IdCasa = decimal.Parse(this.hdnCasaId.Value);
        theCasaDTO.NombreCasa = this.txtNombre.Text;
        theCasaDTO.DireccionCasa = this.txtDireccion.Text;
        theCasaDTO.TelefonoCasa = this.txtTelefono.Text;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theCasaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theCasaDTO.TheComunidadDTO = myComunidadDTO;

        theCasaDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.CasaBLL.Update(theCasaDTO);

        if (respuesta)
        {
            cargarCasa();
            this.txtNombre.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Casa editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptCargoInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdCasa = new HiddenField();
            hdnIdCasa = (HiddenField)e.Item.FindControl("hdnCasaId");

            CasaDTO theCasaDTO = new CasaDTO();
            theCasaDTO.IdCasa = decimal.Parse(hdnIdCasa.Value);
            theCasaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.CasaBLL.ActivaCasa(theCasaDTO);
            if (respuesta)
            {
                cargarCasaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Cargo Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptCasa_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdCasa = new HiddenField();
            hdnIdCasa = (HiddenField)e.Item.FindControl("hdnCasaId");

            YouCom.DTO.Propietario.CasaDTO myCasaDTO = new CasaDTO();
            myCasaDTO = YouCom.bll.CasaBLL.detalleCasa(decimal.Parse(hdnIdCasa.Value));

            this.hdnCasaId.Value = myCasaDTO.IdCasa.ToString();
            txtNombre.Text = myCasaDTO.NombreCasa;
            txtDireccion.Text = myCasaDTO.DireccionCasa;
            txtTelefono.Text = myCasaDTO.TelefonoCasa;

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myCasaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myCasaDTO.TheComunidadDTO.IdComunidad.ToString()));

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdCasa = new HiddenField();
            hdnIdCasa = (HiddenField)e.Item.FindControl("hdnCasaId");

            CasaDTO theCasaDTO = new CasaDTO();
            theCasaDTO.IdCasa = decimal.Parse(hdnIdCasa.Value);
            theCasaDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.CasaBLL.ValidaEliminacionCasa(theCasaDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un cargo con personal asociado.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.CasaBLL.Delete(theCasaDTO);
                if (respuesta)
                {
                    cargarCasa();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Casa Eliminada correctamente.');";
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
