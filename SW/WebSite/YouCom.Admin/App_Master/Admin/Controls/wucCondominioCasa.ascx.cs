using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Master_Admin_Controls_wucCondominioCasa : System.Web.UI.UserControl
{
    public YouCom.DTO.Seguridad.UsuarioDTO myUsuario = new YouCom.DTO.Seguridad.UsuarioDTO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            myUsuario = (YouCom.DTO.Seguridad.UsuarioDTO)Session["usuario"];

            cargarCondominio();

            if (myUsuario.IndexCondominio == 0)
            {
                pnlAdministrador.Visible = true;
            }
            else
            {
                pnlAdministrador.Visible = false;

                ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myUsuario.TheCondominioSeleccionDTO.IdCondominio.ToString()));

                ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
                ddlComunidad.DataTextField = "NombreComunidad";
                ddlComunidad.DataValueField = "IdComunidad";
                ddlComunidad.DataBind();
                ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

                ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myUsuario.TheComunidadSeleccionDTO.IdComunidad.ToString()));
            }
        }
    }

    protected void cargarCondominio()
    {
        ddlCondominio.DataSource = YouCom.Seguridad.BLL.CondominioBLL.getListadoCondominio();
        ddlCondominio.DataTextField = "NombreCondominio";
        ddlCondominio.DataValueField = "IdCondominio";
        ddlCondominio.DataBind();
        ddlCondominio.Items.Insert(0, new ListItem("Seleccione Condominio", string.Empty));
    }

    protected void ddlCondominio_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlCondominio.SelectedValue))
            {
                ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
                ddlComunidad.DataTextField = "NombreComunidad";
                ddlComunidad.DataValueField = "IdComunidad";
                ddlComunidad.DataBind();
                ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));
            }
        }
        catch (Exception ex)
        {


        }
    }

    protected void ddlComunidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlComunidad.SelectedValue))
        {
            ddlCasa.DataSource = YouCom.bll.CasaBLL.getListadoCasaByComunidad(decimal.Parse(ddlComunidad.SelectedValue));
            ddlCasa.DataTextField = "NombreCasa";
            ddlCasa.DataValueField = "IdCasa";
            ddlCasa.DataBind();
            ddlCasa.Items.Insert(0, new ListItem("Seleccione Casa", string.Empty));
        }
    }
 }