using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_EstadoFinanciero : Intermedia.IMSystem.Navigation.Page.WebPage
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

        //myCategoria = YouCom.bll.CategoriaBLL.getListadoCategoriaByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        myCategoria = myCategoria.Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 7).ToList();

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

                    myRepeater = (Repeater)e.Item.FindControl("rptArchivo");

                    IList<YouCom.DTO.ArchivoDTO> myArchivo = new List<YouCom.DTO.ArchivoDTO>();

                    myArchivo = YouCom.bll.ArchivoBLL.listaArchivoActivo();

                    myArchivo = myArchivo.Where(x => x.TheCategoriaDTO.IdCategoria == ((YouCom.DTO.CategoriaDTO)e.Item.DataItem).IdCategoria).ToList();

                    myRepeater.DataSource = myArchivo;
                    myRepeater.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptArchivo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                HyperLink myHyperLink = (HyperLink)e.Item.FindControl("hlDescarga");

                if (!string.IsNullOrEmpty(((YouCom.DTO.ArchivoDTO)e.Item.DataItem).ArchivoNombre))
                {
                    myHyperLink.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathArchivoPub") + ((YouCom.DTO.ArchivoDTO)e.Item.DataItem).ArchivoNombre;
                    myHyperLink.Target = "_blank";
                    myHyperLink.Text = @"<span class=""glyphicon glyphicon-paperclip""></span>" + ((YouCom.DTO.ArchivoDTO)e.Item.DataItem).ArchivoTitulo;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}