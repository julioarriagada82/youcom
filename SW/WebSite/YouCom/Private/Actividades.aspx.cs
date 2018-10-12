using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_Actividades : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarActividad();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void cargarActividad()
    {
        IList<YouCom.DTO.NoticiaDTO> myNoticia = new List<YouCom.DTO.NoticiaDTO>();

        //myNoticia = YouCom.bll.NoticiaBLL.getListadoNoticiaByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        myNoticia = myNoticia.Where(x => x.TheCategoriaDTO.IdCategoria == 14).ToList();

        rptActividad.DataSource = myNoticia;
        rptActividad.DataBind();
    }

    protected void rptActividad_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                Image img = (Image)e.Item.FindControl("imgActividad");


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