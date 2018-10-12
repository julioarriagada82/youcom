using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Master_Controls_WUCNoticias : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarNoticia();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void cargarNoticia()
    {
        IList<YouCom.DTO.NoticiaDTO> myNoticia = new List<YouCom.DTO.NoticiaDTO>();

        myNoticia = YouCom.bll.NoticiaBLL.listaNoticiaActivo();

        myNoticia = myNoticia.Where(x => x.TheCategoriaDTO.IdCategoria == 13).ToList();

        rptNoticia.DataSource = myNoticia;
        rptNoticia.DataBind();
    }

    protected void rptNoticia_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                Image img = (Image)e.Item.FindControl("imgNoticia");


                if (!string.IsNullOrEmpty(((YouCom.DTO.NoticiaDTO)e.Item.DataItem).NotiImagen) && ((YouCom.DTO.NoticiaDTO)e.Item.DataItem).NotiImagen.Trim() != "")
                {
                    img.ImageUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathNoticiaPub") + ((YouCom.DTO.NoticiaDTO)e.Item.DataItem).NotiImagen;
                    img.AlternateText = ((YouCom.DTO.NoticiaDTO)e.Item.DataItem).NotiTitulo;
                    img.ToolTip = ((YouCom.DTO.NoticiaDTO)e.Item.DataItem).NotiTitulo;
                }
                else
                {
                    img.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}
