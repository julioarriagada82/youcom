using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_EstatusActas : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarEstatus();
                cargarActas();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void cargarEstatus()
    {
        IList<YouCom.DTO.ArchivoDTO> myArchivo = new List<YouCom.DTO.ArchivoDTO>();

        //myArchivo = YouCom.bll.ArchivoBLL.getListadoArchivoByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        myArchivo = myArchivo.Where(x => x.TheCategoriaDTO.IdCategoria == 15).ToList();

        rptEstatus.DataSource = myArchivo;
        rptEstatus.DataBind();
    }

    protected void cargarActas()
    {
        IList<YouCom.DTO.ArchivoDTO> myArchivo = new List<YouCom.DTO.ArchivoDTO>();

        myArchivo = YouCom.bll.ArchivoBLL.listaArchivoActivo();

        myArchivo = myArchivo.Where(x => x.TheCategoriaDTO.IdCategoria == 16).ToList();


        rptActas.DataSource = myArchivo;
        rptActas.DataBind();
    }

    protected void rptEstatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                    myHyperLink.Text = ((YouCom.DTO.ArchivoDTO)e.Item.DataItem).ArchivoTitulo;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptActas_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                    myHyperLink.Text = ((YouCom.DTO.ArchivoDTO)e.Item.DataItem).ArchivoTitulo;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}