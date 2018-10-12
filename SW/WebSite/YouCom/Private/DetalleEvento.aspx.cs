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

public partial class Privado_DetalleEvento : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];

                YouCom.DTO.EventoDTO myEventoDTO = new YouCom.DTO.EventoDTO();
                myEventoDTO = YouCom.bll.EventoBLL.detalleEvento(decimal.Parse(id));

                LitEventoTitulo.Text = myEventoDTO.EventoTitulo;
                LitEventoResumen.Text = myEventoDTO.EventoResumen;
                LitEventoDetalle.Text = myEventoDTO.EventoDetalle;
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }
}
