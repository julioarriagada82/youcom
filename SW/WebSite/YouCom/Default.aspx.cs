using System;
using System.Collections;
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
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    private const string retorno1 = "Default.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarNoticia();
                cargarBanner();
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

    protected void cargarBanner()
    {
        IList<YouCom.DTO.BannerDTO> myBanner = new List<YouCom.DTO.BannerDTO>();

        myBanner = YouCom.bll.BannerBLL.listaBannerActivo();

        //myAccesoHogar = myAccesoHogar.Where(x => x.FuncionNombre == theFuncionDTO.FuncionNombre).ToList();

        rptBanner.DataSource = myBanner;
        rptBanner.DataBind();
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

    protected void rptBanner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                Image img = (Image)e.Item.FindControl("imgBanner");


                if (!string.IsNullOrEmpty(((YouCom.DTO.BannerDTO)e.Item.DataItem).BannerImagen) && ((YouCom.DTO.BannerDTO)e.Item.DataItem).BannerImagen.Trim() != "")
                {
                    img.ImageUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathBannerPub") + ((YouCom.DTO.BannerDTO)e.Item.DataItem).BannerImagen;
                    img.AlternateText = ((YouCom.DTO.BannerDTO)e.Item.DataItem).BannerNombre;
                    img.ToolTip = ((YouCom.DTO.BannerDTO)e.Item.DataItem).BannerNombre;
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
