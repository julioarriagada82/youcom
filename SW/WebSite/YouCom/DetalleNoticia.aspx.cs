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

public partial class Privado_DetalleNoticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];

                YouCom.DTO.NoticiaDTO myNoticiaDTO = new YouCom.DTO.NoticiaDTO();
                myNoticiaDTO = YouCom.bll.NoticiaBLL.detalleNoticia(decimal.Parse(id));

                LitNoticiaTitulo.Text = myNoticiaDTO.NotiTitulo;
                LitNoticiaResumen.Text = myNoticiaDTO.NotiResumen;
                LitNoticiaDetalle.Text = myNoticiaDTO.NotiDetalle;
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
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
