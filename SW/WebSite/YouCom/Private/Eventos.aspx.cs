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

public partial class Privado_Eventos : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarEventos();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void cargarEventos()
    {
        IList<YouCom.DTO.EventoDTO> myEvento = new List<YouCom.DTO.EventoDTO>();

        //myEvento = YouCom.bll.EventoBLL.getListadoEventoByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        //myAccesoHogar = myAccesoHogar.Where(x => x.FuncionNombre == theFuncionDTO.FuncionNombre).ToList();

        rptEvento.DataSource = myEvento;
        rptEvento.DataBind();
    }

    protected void rptEvento_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                Image img = (Image)e.Item.FindControl("imgEvento");


                if (!string.IsNullOrEmpty(((YouCom.DTO.EventoDTO)e.Item.DataItem).EventoImagen) && ((YouCom.DTO.EventoDTO)e.Item.DataItem).EventoImagen.Trim() != "")
                {
                    img.ImageUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathEventoPub") + ((YouCom.DTO.EventoDTO)e.Item.DataItem).EventoImagen;
                    img.AlternateText = ((YouCom.DTO.EventoDTO)e.Item.DataItem).EventoTitulo;
                    img.ToolTip = ((YouCom.DTO.EventoDTO)e.Item.DataItem).EventoTitulo;
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
