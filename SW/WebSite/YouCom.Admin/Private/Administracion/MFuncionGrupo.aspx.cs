using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Administracion_MFuncionGrupo : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarFuncionGrupo();
        }
    }
    protected void cargarFuncionGrupo()
    {
        Session["Grupo"] = YouCom.Seguridad.BLL.FuncionGrupoBLL.listaFuncionGrupo();
        rptGrupo.DataSource = YouCom.Seguridad.BLL.FuncionGrupoBLL.listaFuncionGrupoActivo();
        rptGrupo.DataBind();
    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {

        pnlPapelera.Visible = true;
        pnlAdministracionFuncionGrupo.Visible = false;
        cargarFuncionGrupoInactivo();
    }
    protected void cargarFuncionGrupoInactivo()
    {

        List<YouCom.DTO.Seguridad.FuncionGrupoDTO> grupo = new List<YouCom.DTO.Seguridad.FuncionGrupoDTO>();
        grupo = YouCom.Seguridad.BLL.FuncionGrupoBLL.listaFuncionGrupoInactivo();
        if (grupo.Any())
        {

            rptGrupoInactivo.DataSource = grupo;
            rptGrupoInactivo.DataBind();
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

        List<YouCom.DTO.Seguridad.FuncionGrupoDTO> grupo = new List<YouCom.DTO.Seguridad.FuncionGrupoDTO>();
        grupo = (Session["Grupo"] as List<YouCom.DTO.Seguridad.FuncionGrupoDTO>);

        YouCom.DTO.Seguridad.FuncionGrupoDTO theFuncionGrupoDTO = new YouCom.DTO.Seguridad.FuncionGrupoDTO();
        theFuncionGrupoDTO.FuncionGrupoNombre = txtGrupo.Text.ToUpper();
        theFuncionGrupoDTO.UsuarioIngreso = myUsuario.Rut;


        grupo = grupo.Where(x => x.FuncionGrupoNombre == theFuncionGrupoDTO.FuncionGrupoNombre).ToList();
        if (grupo.Any())
        {
            foreach (var item in grupo)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Grupo Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert(' Grupo ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.Seguridad.BLL.FuncionGrupoBLL.InsertFuncionGrupo(theFuncionGrupoDTO);
        if (respuesta)
        {

            txtGrupo.Text = string.Empty;
            string script = "alert('Grupo Ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarFuncionGrupo();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        YouCom.DTO.Seguridad.FuncionGrupoDTO theFuncionGrupoDTO = new YouCom.DTO.Seguridad.FuncionGrupoDTO();
        theFuncionGrupoDTO.FuncionGrupoCod = HidIdTipoEtapa.Value;
        theFuncionGrupoDTO.FuncionGrupoNombre = txtGrupo.Text.ToUpper();
        theFuncionGrupoDTO.UsuarioIngreso = myUsuario.Rut;
        bool respuesta = YouCom.Seguridad.BLL.FuncionGrupoBLL.UpdateFuncionGrupo(theFuncionGrupoDTO);

        if (respuesta)
        {
            cargarFuncionGrupo();
            txtGrupo.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Grupo editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptGrupoInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            YouCom.DTO.Seguridad.FuncionGrupoDTO theFuncionGrupoDTO = new YouCom.DTO.Seguridad.FuncionGrupoDTO();
            theFuncionGrupoDTO.FuncionGrupoCod = hdnTipoSistema.Value;
            theFuncionGrupoDTO.UsuarioIngreso = myUsuario.Rut;

            bool respuesta = YouCom.Seguridad.BLL.FuncionGrupoBLL.ActivaFuncionGrupo(theFuncionGrupoDTO);
            if (respuesta)
            {
                cargarFuncionGrupoInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Grupo Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }


        }

    }
    protected void rptGrupo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            
            HidIdTipoEtapa.Value = hdnTipoSistema.Value;
            txtGrupo.Text = hdnDescripcion.Value;
            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            YouCom.DTO.Seguridad.FuncionGrupoDTO theFuncionGrupoDTO = new YouCom.DTO.Seguridad.FuncionGrupoDTO();

            theFuncionGrupoDTO.FuncionGrupoCod = hdnTipoSistema.Value;
            theFuncionGrupoDTO.UsuarioIngreso = myUsuario.Rut;

            bool validacionIntegridad = YouCom.Seguridad.BLL.FuncionGrupoBLL.ValidaEliminacionFuncionGrupo(theFuncionGrupoDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un Grupo  Asociado a Una Funcion .');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {


                bool respuesta = YouCom.Seguridad.BLL.FuncionGrupoBLL.DeleteFuncionGrupo(theFuncionGrupoDTO);
                if (respuesta)
                {
                    cargarFuncionGrupo();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Grupo Eliminado correctamente.');";
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
