using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MPais : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarPaises();
        }
    }
    protected void cargarPaises()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["paises"] = YouCom.bll.PaisBLL.getListadoPais();
            rptPais.DataSource = YouCom.bll.PaisBLL.listaPaisActivo().Where(x => x.Estado != "P");
            rptPais.DataBind();

        }
        else
        {
            Session["paises"] = YouCom.bll.PaisBLL.getListadoPais().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptPais.DataSource = YouCom.bll.PaisBLL.listaPaisActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList(); ;
            rptPais.DataBind();
        }
    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionPais.Visible = false;
        cargarPaisInactivo();
    }
    protected void cargarPaisInactivo()
    {

        IList<PaisDTO> pais=new List<PaisDTO>();
        pais = YouCom.bll.PaisBLL.listaPaisInactivo();
        if (pais.Any())
        {

            rptPaisInactivo.DataSource = pais;
            rptPaisInactivo.DataBind();
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
        List<PaisDTO> pais = new List<PaisDTO>();
        pais = (Session["paises"] as List<PaisDTO>);

        PaisDTO thePaisDTO = new PaisDTO(); 
        thePaisDTO.DescripcionPais = txtPais.Text.ToUpper();
        thePaisDTO.UsuarioIngreso = myUsuario.Rut;


        pais = pais.Where(x => x.DescripcionPais == thePaisDTO.DescripcionPais).ToList();
        if (pais.Any())
        {
            foreach (var item in pais)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Pais Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Pais ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }


        }


        bool respuesta = YouCom.bll.PaisBLL.Insert(thePaisDTO);
        if (respuesta)
        {

            txtPais.Text = string.Empty;
            string script = "alert('Pais Ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarPaises();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        PaisDTO thePaisDTO=new PaisDTO();
        thePaisDTO.IdPais = decimal.Parse(HidIdPais.Value);
        thePaisDTO.DescripcionPais = txtPais.Text.ToUpper();
        thePaisDTO.UsuarioIngreso = myUsuario.Rut;
        bool respuesta = YouCom.bll.PaisBLL.Update(thePaisDTO);

        if (respuesta)
        {
            cargarPaises();

            txtPais.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Pais editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptPaisInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            PaisDTO thePaisDTO=new PaisDTO();

            thePaisDTO.IdPais = decimal.Parse(hdnTipoSistema.Value);
            thePaisDTO.UsuarioIngreso = myUsuario.Rut;

            bool respuesta = YouCom.bll.PaisBLL.ActivaPais(thePaisDTO);
            if (respuesta)
            {
                cargarPaisInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Pais Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }


        }

    }
    protected void rptPais_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");


            HidIdPais.Value = hdnTipoSistema.Value;
            txtPais.Text = hdnDescripcion.Value;
            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            PaisDTO thePaisDTO=new PaisDTO();
            thePaisDTO.IdPais = decimal.Parse(hdnTipoSistema.Value);
            thePaisDTO.UsuarioIngreso = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.PaisBLL.ValidaEliminacionPais(thePaisDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un Pais Con regiones Asociadas.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {


                bool respuesta = YouCom.bll.PaisBLL.Delete(thePaisDTO);
                if (respuesta)
                {
                    cargarPaises();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Pais Eliminado correctamente.');";
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
