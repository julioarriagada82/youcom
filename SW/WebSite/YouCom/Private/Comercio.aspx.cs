using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_Comercio : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarComercio();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void cargarComercio()
    {
        IList<YouCom.DTO.ComercioDTO> myComercio = new List<YouCom.DTO.ComercioDTO>();

        //myComercio = YouCom.bll.ComercioBLL.getListadoComercioByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        myComercio = myComercio.Where(x => x.TheCategoriaDTO.IdCategoria == 20 || x.TheCategoriaDTO.IdCategoria == 21).ToList();

        rptComercio.DataSource = myComercio;
        rptComercio.DataBind();
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
                Image img = (Image)e.Item.FindControl("imgLogo");

                HyperLink myHyperLink = (HyperLink)e.Item.FindControl("hlUrl");

                if (!string.IsNullOrEmpty(((YouCom.DTO.ComercioDTO)e.Item.DataItem).LogoComercio) && ((YouCom.DTO.ComercioDTO)e.Item.DataItem).LogoComercio.Trim() != "")
                {
                    img.ImageUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathComercioPub") + ((YouCom.DTO.ComercioDTO)e.Item.DataItem).LogoComercio;
                    img.AlternateText = ((YouCom.DTO.ComercioDTO)e.Item.DataItem).NombreComercio;
                    img.ToolTip = ((YouCom.DTO.ComercioDTO)e.Item.DataItem).NombreComercio;
                }
                else
                {
                    img.Visible = false;
                }

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
}
