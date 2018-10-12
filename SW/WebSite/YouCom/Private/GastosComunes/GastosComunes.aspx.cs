using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_GastosComunes_GastosComunes : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SelView(0);
            cargarGastosComunes();
        }
    }

    void SelView(Int32 nIndex)
    {
        Int32 oIndex = this.mvwAutorizaciones.ActiveViewIndex;
        this.mvwAutorizaciones.ActiveViewIndex = nIndex;
    }

    protected void cargarGastosComunes()
    {
        IList<YouCom.DTO.GastosComunes.GastoComunDTO> myGastosComunes = new List<YouCom.DTO.GastosComunes.GastoComunDTO>();

        myGastosComunes = YouCom.bll.GastosComunes.GastoComunBLL.getListadoEventoByCasa(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad, myUsuario.TheFamiliaDTO.TheCasaDTO.IdCasa);

        rptGastosComunes.DataSource = myGastosComunes;
        rptGastosComunes.DataBind();
    }

    protected void rptGastosComunes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                HyperLink myHyperLink = (HyperLink)e.Item.FindControl("LnkDetalle");

                if (!string.IsNullOrEmpty(((YouCom.DTO.GastosComunes.GastoComunDTO)e.Item.DataItem).ArchivoGasto.Trim()))
                {
                    myHyperLink.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathGastoComunPub") + ((YouCom.DTO.GastosComunes.GastoComunDTO)e.Item.DataItem).ArchivoGasto;
                    myHyperLink.Target = "_blank";
                    myHyperLink.Text = @"<span class=""glyphicon glyphicon-eye-open""></span>";
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}