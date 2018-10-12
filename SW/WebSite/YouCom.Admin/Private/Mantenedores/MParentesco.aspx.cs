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

public partial class Admin_Mantenedores_MParentesco : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarParentesco();
        }
    }

    protected void cargarParentesco()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["Parentesco"] = YouCom.bll.ParentescoBLL.getListadoParentesco();
            rptParentesco.DataSource = YouCom.bll.ParentescoBLL.listaParentescoActivo();
            rptParentesco.DataBind();
        }
        else
        {
            Session["Parentesco"] = YouCom.bll.ParentescoBLL.getListadoParentesco().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptParentesco.DataSource = YouCom.bll.ParentescoBLL.listaParentescoActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptParentesco.DataBind();
        }
    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionParentesco.Visible = false;
        cargarParentescoInactivo();
    }
    protected void cargarParentescoInactivo()
    {
        IList<ParentescoDTO> Parentesco = new List<ParentescoDTO>();
        Parentesco = YouCom.bll.ParentescoBLL.listaParentescoInactivo();
        if (Parentesco.Any())
        {
            rptParentescoInactivo.DataSource = Parentesco;
            rptParentescoInactivo.DataBind();
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
        IList<ParentescoDTO> Parentesco = new List<ParentescoDTO>();
        Parentesco = (Session["Parentesco"] as List<ParentescoDTO>);

        ParentescoDTO theParentescoDTO = new ParentescoDTO();
        theParentescoDTO.NombreParentesco = this.txtNombre.Text.ToUpper();
        theParentescoDTO.UsuarioIngreso = myUsuario.Rut;

        Parentesco = Parentesco.Where(x => x.NombreParentesco == theParentescoDTO.NombreParentesco).ToList();
        if (Parentesco.Any())
        {
            foreach (var item in Parentesco)
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

        bool respuesta = YouCom.bll.ParentescoBLL.Insert(theParentescoDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            string script = "alert('Parentesco Ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarParentesco();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        ParentescoDTO theParentescoDTO = new ParentescoDTO();
        theParentescoDTO.IdParentesco = decimal.Parse(this.hdnIdParentesco.Value);
        theParentescoDTO.NombreParentesco = this.txtNombre.Text;
        theParentescoDTO.UsuarioModificacion = myUsuario.Rut;
        bool respuesta = YouCom.bll.ParentescoBLL.Update(theParentescoDTO);

        if (respuesta)
        {
            cargarParentesco();
            this.txtNombre.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Parentesco editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptParentescoInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdParentesco = new HiddenField();
            hdnIdParentesco = (HiddenField)e.Item.FindControl("hdnIdParentesco");

            ParentescoDTO theParentescoDTO = new ParentescoDTO();
            theParentescoDTO.IdParentesco = decimal.Parse(hdnIdParentesco.Value);
            theParentescoDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.ParentescoBLL.ActivaParentesco(theParentescoDTO);
            if (respuesta)
            {
                cargarParentescoInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Parentesco activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptParentesco_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdParentesco = new HiddenField();
            hdnIdParentesco = (HiddenField)e.Item.FindControl("hdnIdParentesco");

            YouCom.DTO.Propietario.ParentescoDTO theParentescoDTO = new YouCom.DTO.Propietario.ParentescoDTO();
            theParentescoDTO = YouCom.bll.ParentescoBLL.detalleParentesco(decimal.Parse(hdnIdParentesco.Value));

            this.hdnIdParentesco.Value = theParentescoDTO.IdParentesco.ToString();
            txtNombre.Text = theParentescoDTO.NombreParentesco;

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdParentesco = new HiddenField();
            hdnIdParentesco = (HiddenField)e.Item.FindControl("hdnIdParentesco");

            ParentescoDTO theParentescoDTO = new ParentescoDTO();
            theParentescoDTO.IdParentesco = decimal.Parse(hdnIdParentesco.Value);
            theParentescoDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.ParentescoBLL.ValidaEliminacionParentesco(theParentescoDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un Parentesco con integrante de familia asociado.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.ParentescoBLL.Delete(theParentescoDTO);
                if (respuesta)
                {
                    cargarParentesco();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Parentesco Eliminada correctamente.');";
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
