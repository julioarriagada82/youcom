using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Comercio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarCategoria();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void cargarCategoria()
    {
        IList<YouCom.DTO.CategoriaDTO> myCategoria = new List<YouCom.DTO.CategoriaDTO>();

        myCategoria = YouCom.bll.CategoriaBLL.listaCategoriaActivo();

        myCategoria = myCategoria.Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 8).ToList();

        rptCategoria.DataSource = myCategoria;
        rptCategoria.DataBind();
    }

    protected void rptCategoria_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.CategoriaDTO)e.Item.DataItem).NombreCategoria))
                {
                    Repeater myRepeater = new Repeater();

                    myRepeater = (Repeater)e.Item.FindControl("rptComercio");

                    IList<YouCom.DTO.ComercioDTO> myComercio = new List<YouCom.DTO.ComercioDTO>();

                    myComercio = YouCom.bll.ComercioBLL.listaComercioActivo();

                    myComercio = myComercio.Where(x => x.TheCategoriaDTO.IdCategoria == ((YouCom.DTO.CategoriaDTO)e.Item.DataItem).IdCategoria).ToList();

                    myRepeater.DataSource = myComercio;
                    myRepeater.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptComercio_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                HyperLink myHyperLink = (HyperLink)e.Item.FindControl("hlUrl");

                if (!string.IsNullOrEmpty(((YouCom.DTO.ComercioDTO)e.Item.DataItem).UrlComercio))
                {
                    myHyperLink.NavigateUrl = ((YouCom.DTO.ComercioDTO)e.Item.DataItem).UrlComercio;
                    myHyperLink.Target = "_blank";
                    myHyperLink.Text = ((YouCom.DTO.ComercioDTO)e.Item.DataItem).NombreComercio;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {

            Session["InformacionUsuario"] = SeguridadBLL.Seguridad.LoginPrivado(YouCom.Service.Generales.Formato.LimpiarRut(txtUsuario.Text), txtPassword.Text);
            Response.Redirect("Privado/Default.aspx");
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }
}