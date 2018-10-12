using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_DetalleActividad : System.Web.UI.Page
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
