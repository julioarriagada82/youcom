using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_MFuncion : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            cargarFunciones();
            cargarGrupos();
            cargarTipos();
        }
    }
    protected void cargarGrupos()
    {
        ddlGrupo.DataSource = YouCom.Seguridad.BLL.FuncionGrupoBLL.listaFuncionGrupoActivo();
        ddlGrupo.DataTextField = "FuncionGrupoNombre";
        ddlGrupo.DataValueField = "FuncionGrupoCod";
        ddlGrupo.DataBind();
        ddlGrupo.Items.Insert(0, new ListItem("Seleccione Grupo", string.Empty));
    }
    protected void cargarTipos()
    {
        ddlTipo.DataSource = YouCom.Seguridad.BLL.FuncionTipoBLL.listaFuncionTipoActivo();
        ddlTipo.DataTextField = "FuncionTipoNombre";
        ddlTipo.DataValueField = "FuncionTipoCod";
        ddlTipo.DataBind();
        ddlTipo.Items.Insert(0, new ListItem("Seleccione Tipo", string.Empty));
    }
    protected void cargarFunciones()
    {
        Session["Funciones"] = YouCom.Seguridad.BLL.FuncionBLL.listaFuncion();
        rptFunciones.DataSource = YouCom.Seguridad.BLL.FuncionBLL.listaFuncionActivo();
        rptFunciones.DataBind();
    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {

        pnlPapelera.Visible = true;
        pnlAdministracionFuncion.Visible = false;
        cargarFuncionesInactivo();
    }
    protected void cargarFuncionesInactivo()
    {

        List<YouCom.DTO.Seguridad.FuncionDTO> funciones=new List<YouCom.DTO.Seguridad.FuncionDTO>();
        funciones = YouCom.Seguridad.BLL.FuncionBLL.listaFuncionInactivo();
        if (funciones.Any())
        {
            rptFuncionesInactivo.DataSource = funciones;
            rptFuncionesInactivo.DataBind();
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

        List<YouCom.DTO.Seguridad.FuncionDTO> funciones=new List<YouCom.DTO.Seguridad.FuncionDTO>();
        funciones = (Session["funciones"] as List<YouCom.DTO.Seguridad.FuncionDTO>);

        YouCom.DTO.Seguridad.FuncionDTO theFuncionDTO = new YouCom.DTO.Seguridad.FuncionDTO();
        theFuncionDTO.FuncionNombre = txtNombreFuncion.Text.ToUpper();
        theFuncionDTO.Url = txtUrl.Text;
        theFuncionDTO.FuncionGrupoCod = ddlGrupo.SelectedValue;
        theFuncionDTO.FuncionTipoCod = ddlTipo.SelectedValue;
        theFuncionDTO.UsuarioIngreso = myUsuario.Rut;
        if (chkEnviaCorreo.Checked)
        {
            theFuncionDTO.EnviaCorreo = "S";
        }
        else
        {
            theFuncionDTO.EnviaCorreo = "N";
        }
      


        funciones = funciones.Where(x => x.FuncionNombre == theFuncionDTO.FuncionNombre).ToList();
        if (funciones.Any())
        {
            foreach (var item in funciones)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Funcion Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert(' Funcion ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.Seguridad.BLL.FuncionBLL.InsertFuncion(theFuncionDTO);
        if (respuesta)
        {

            txtNombreFuncion.Text = string.Empty;
            txtUrl.Text = string.Empty;
            string script = "alert('Funciones Ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarFunciones();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        YouCom.DTO.Seguridad.FuncionDTO theFuncionDTO = new YouCom.DTO.Seguridad.FuncionDTO();
        theFuncionDTO.FuncionCod = HidIdFuncion.Value;
        theFuncionDTO.FuncionGrupoCod = ddlGrupo.SelectedValue;
        theFuncionDTO.FuncionTipoCod = ddlTipo.SelectedValue;
        theFuncionDTO.FuncionNombre = txtNombreFuncion.Text.ToUpper();
        theFuncionDTO.Url = txtUrl.Text;
        theFuncionDTO.UsuarioIngreso = myUsuario.Rut;
        if (chkEnviaCorreo.Checked)
        {
            theFuncionDTO.EnviaCorreo = "S";
        }
        else
        {
            theFuncionDTO.EnviaCorreo = "N";
        }

        bool respuesta = YouCom.Seguridad.BLL.FuncionBLL.UpdateFuncion(theFuncionDTO);

        if (respuesta)
        {
            cargarFunciones();
            txtNombreFuncion.Text = string.Empty;
            txtUrl.Text = string.Empty;
            

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Funcion editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptFuncionesInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            YouCom.DTO.Seguridad.FuncionDTO theFuncionDTO=new YouCom.DTO.Seguridad.FuncionDTO();

            theFuncionDTO.FuncionCod = hdnTipoSistema.Value;
            theFuncionDTO.UsuarioIngreso = myUsuario.Rut;

            bool respuesta = YouCom.Seguridad.BLL.FuncionBLL.ActivaFuncion(theFuncionDTO);
            if (respuesta)
            {
                cargarFuncionesInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Funcion Activada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptFunciones_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            HiddenField hdnUrl= new HiddenField();
            hdnUrl = (HiddenField)e.Item.FindControl("hdnUrl");


            HiddenField hdnFuncionGrupo = new HiddenField();
            hdnFuncionGrupo = (HiddenField)e.Item.FindControl("hdnFuncionGrupo");


            HiddenField hdnFuncionTipo = new HiddenField();
            hdnFuncionTipo = (HiddenField)e.Item.FindControl("hdnFuncionTipo");

           
            HidIdFuncion.Value = hdnTipoSistema.Value;
            txtNombreFuncion.Text= hdnDescripcion.Value;
            txtUrl.Text = hdnUrl.Value;
            ddlGrupo.SelectedValue = hdnFuncionGrupo.Value;
            ddlTipo.SelectedValue = hdnFuncionTipo.Value;
            
            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            YouCom.DTO.Seguridad.FuncionDTO theFuncionDTO=new YouCom.DTO.Seguridad.FuncionDTO();

            theFuncionDTO.FuncionCod = hdnTipoSistema.Value;
            theFuncionDTO.UsuarioIngreso = myUsuario.Rut;

            bool validacionIntegridad = YouCom.Seguridad.BLL.FuncionBLL.ValidaEliminacionFuncion(theFuncionDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar una Funcion  Asociado a Una URl vigente .');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.Seguridad.BLL.FuncionBLL.DeleteFuncion(theFuncionDTO);
                if (respuesta)
                {
                    cargarFunciones();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Funcion Eliminada correctamente.');";
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
