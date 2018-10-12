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

public partial class App_Master_Controls_Header_privado : System.Web.UI.UserControl
{
    public YouCom.DTO.Seguridad.UsuarioDTO myUsuario = new YouCom.DTO.Seguridad.UsuarioDTO();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LitFecha.Text = DateTime.Now.ToString("dddd dd/MM/yyyy tt");
        this.LitHora.Text = DateTime.Now.ToString("HH:mm tt");

        if (!IsPostBack)
        {
            myUsuario = (YouCom.DTO.Seguridad.UsuarioDTO)Session["usuario"];

            this.LitUsuario.Text = myUsuario.NombreCompleto;

            ddlCondominio.DataSource = myUsuario.TheCondominioDTO;
            ddlCondominio.DataTextField = "NombreCondominio";
            ddlCondominio.DataValueField = "IdCondominio";
            ddlCondominio.DataBind();

            if (myUsuario.TheCondominioDTO.Count == 1)
            {
                ddlCondominio.Enabled = false;
            }
        }
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Logout("http://" + Request.Url.Authority + ResolveUrl("~/") + "login.aspx");
    }

    void Logout(string pag)
    {
        GC.Collect();
        Session.Abandon();
        Session.RemoveAll();
        FormsAuthentication.SignOut();
        Response.Redirect(pag, true); // CAMBIAR
    }
}
