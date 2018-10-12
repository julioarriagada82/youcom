using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Master_UserControl_BannerCentral : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lnkBtnSolicitud_Click(object sender, EventArgs e)
    {
        //HttpContext.Current.Session.Add("Producto", Business.Banner.SubSeccion.CuentaCorriente);
        //Response.Redirect("solicitud.aspx");
    }

}
