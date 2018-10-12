using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Master_Controls_wucCategoria : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void rptCategoria_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Seleccionar"))
            {
                HiddenField myHidIdCategoria = (HiddenField)e.Item.FindControl("HidIdCategoria");

                if (YouCom.Service.Configuracion.Config.getPageName(true) == "Avisos.aspx")
                {
                    Session.Add("CategoriaAviso", myHidIdCategoria.Value);

                    Response.Redirect("Avisos.aspx");
                }
                else if (YouCom.Service.Configuracion.Config.getPageName(true) == "Servicios.aspx")
                {
                    Session.Add("CategoriaServicio", myHidIdCategoria.Value);

                    Response.Redirect("Servicios.aspx");
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}

