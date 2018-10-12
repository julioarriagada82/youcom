using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_MFuncionTipo : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarFuncionTipo();
        }
    }
    protected void cargarFuncionTipo()
    {

        Session["FuncionTipo"] = YouCom.Seguridad.BLL.FuncionTipoBLL.listaFuncionTipo();
        rptTipoFuncion.DataSource = YouCom.Seguridad.BLL.FuncionTipoBLL.listaFuncionTipoActivo();
        rptTipoFuncion.DataBind();
    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {

        pnlPapelera.Visible = true;

        pnlAdministracionFuncionTipo.Visible = false;
        cargarFuncionTipoInactivo();
    }
    protected void cargarFuncionTipoInactivo()
    {

        List<YouCom.DTO.Seguridad.FuncionTipoDTO> tipo = new List<YouCom.DTO.Seguridad.FuncionTipoDTO>();
        tipo = YouCom.Seguridad.BLL.FuncionTipoBLL.listaFuncionTipoInactivo();
        if (tipo.Any())
        {

            rptTipoFuncionInactivo.DataSource = tipo;
            rptTipoFuncionInactivo.DataBind();
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

        List<YouCom.DTO.Seguridad.FuncionTipoDTO> tipo = new List<YouCom.DTO.Seguridad.FuncionTipoDTO>();
        tipo = (Session["FuncionTipo"] as List<YouCom.DTO.Seguridad.FuncionTipoDTO>);

        YouCom.DTO.Seguridad.FuncionTipoDTO theFuncionTipoDTO=new YouCom.DTO.Seguridad.FuncionTipoDTO();
        theFuncionTipoDTO.FuncionTipoNombre = txtTipoFuncion.Text.ToUpper();
        theFuncionTipoDTO.UsuarioIngreso = myUsuario.Rut;


        tipo = tipo.Where(x => x.FuncionTipoNombre == theFuncionTipoDTO.FuncionTipoNombre).ToList();
        if (tipo.Any())
        {
            foreach (var item in tipo)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Tipo Funcion Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert(' Tipo Funcion ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }


        }


        bool respuesta = YouCom.Seguridad.BLL.FuncionTipoBLL.InsertFuncionTipo(theFuncionTipoDTO);
        if (respuesta)
        {

            txtTipoFuncion.Text = string.Empty;
            string script = "alert('Tipo Funcion Ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarFuncionTipo();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        YouCom.DTO.Seguridad.FuncionTipoDTO theFuncionTipoDTO=new YouCom.DTO.Seguridad.FuncionTipoDTO();
        theFuncionTipoDTO.FuncionTipoCod = HidIdTipoFuncion.Value;
        theFuncionTipoDTO.FuncionTipoNombre = txtTipoFuncion.Text.ToUpper();
        theFuncionTipoDTO.UsuarioIngreso = myUsuario.Rut;
        bool respuesta = YouCom.Seguridad.BLL.FuncionTipoBLL.UpdateFuncionTipo(theFuncionTipoDTO);

        if (respuesta)
        {
            cargarFuncionTipo();
            txtTipoFuncion.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Tipo Funcion editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptTipoFuncionInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            YouCom.DTO.Seguridad.FuncionTipoDTO theFuncionTipoDTO=new YouCom.DTO.Seguridad.FuncionTipoDTO();
            theFuncionTipoDTO.FuncionTipoCod = hdnTipoSistema.Value;
            theFuncionTipoDTO.UsuarioIngreso = myUsuario.Rut;

            bool respuesta = YouCom.Seguridad.BLL.FuncionTipoBLL.ActivaFuncionTipo(theFuncionTipoDTO);
            if (respuesta)
            {
                cargarFuncionTipoInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Tipo Funcion Activada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }


        }

    }
    
    protected void rptTipoFuncion_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            
            HidIdTipoFuncion.Value = hdnTipoSistema.Value;
            txtTipoFuncion.Text = hdnDescripcion.Value;
            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            YouCom.DTO.Seguridad.FuncionTipoDTO theFuncionTipoDTO=new YouCom.DTO.Seguridad.FuncionTipoDTO();

            theFuncionTipoDTO.FuncionTipoCod = hdnTipoSistema.Value;
            theFuncionTipoDTO.UsuarioIngreso = myUsuario.Rut;

            bool validacionIntegridad = YouCom.Seguridad.BLL.FuncionTipoBLL.ValidaEliminacionFuncionTipo(theFuncionTipoDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un Tipo Funcion  Asociado a Una Funcion .');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.Seguridad.BLL.FuncionTipoBLL.DeleteFuncionTipo(theFuncionTipoDTO);
                if (respuesta)
                {
                    cargarFuncionTipo();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Tipo Funcion Eliminado correctamente.');";
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
