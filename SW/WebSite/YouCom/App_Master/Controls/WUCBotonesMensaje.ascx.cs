using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Master_Controls_WUCBotonesMensaje : Intermedia.IMSystem.Navigation.UserControl.WebUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if(!IsPostBack)
            {
                IList<YouCom.DTO.Notificaciones.NotificacionDTO> myNotificacionDTO = new List<YouCom.DTO.Notificaciones.NotificacionDTO>();
                myNotificacionDTO = YouCom.bll.Notificaciones.NotificacionBLL.getListadoNotificacionesByIdFamiliaOrigen(myUsuario.Rut).Where(x => x.VerNotificacion == "NO").ToList();

                LitCantidadNotificaciones.Text = myNotificacionDTO.Count.ToString();
            }
        }
        catch (Exception ex)
        { 
        
        }
    }

    void SelView(Int32 nIndex)
    {
        MultiView UCMultiView = (MultiView)Page.Master.FindControl("ContentPlaceHolder1").FindControl("mvwMensaje");

        UCMultiView.ActiveViewIndex = nIndex;
    }

    protected void LnkBtnPublicarMensaje_Click(object sender, EventArgs e)
    {
        MultiView UCMultiView = (MultiView)Page.Master.FindControl("ContentPlaceHolder1").FindControl("mvwMensaje");


        this.SelView(UCMultiView.ActiveViewIndex + 1);
    }

    protected void LnkBtnNotificaciones_Click(object sender, EventArgs e)
    {
        try
        {
            Panel pnlNotificaciones = (Panel)Page.Master.FindControl("ContentPlaceHolder1").FindControl("pnlNotificaciones");

            Repeater rptNotificaciones = (Repeater)Page.Master.FindControl("ContentPlaceHolder1").FindControl("rptNotificaciones");

            IList<YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO> myResumenNotificacionDTO = new List<YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO>();
            myResumenNotificacionDTO = YouCom.bll.Notificaciones.ResumenNotificacionBLL.getResumenNotificacion(myUsuario.Rut);

            if (myResumenNotificacionDTO.Any())
            {
                rptNotificaciones.DataSource = myResumenNotificacionDTO;
                rptNotificaciones.DataBind();

                pnlNotificaciones.Visible = true;
            }
            else
            {
                pnlNotificaciones.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void LnkBtnBusqueda_Click(object sender, EventArgs e)
    {
        Panel UCPanel = (Panel)Page.Master.FindControl("ContentPlaceHolder1").FindControl("pnlBuscador");

        if (!UCPanel.Visible)
        {
            UCPanel.Visible = true;
        }
        else
        {
            UCPanel.Visible = false;
        }
    }
}