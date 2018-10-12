using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class App_Master_UserControl_GenericError : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        //Server.Transfer("~/default.aspx", false);
        //Response.Redirect("~/Private/default.aspx", true); // CAMBIAR
        Response.Redirect("~/", true); // CAMBIAR
    }
}
