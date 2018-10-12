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

public partial class Privado_DetalleNoticia : Intermedia.IMSystem.Navigation.Page.WebPage
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
}
