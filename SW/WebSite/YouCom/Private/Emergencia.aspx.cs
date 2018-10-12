using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_Emergencia : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarEmergencia();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void cargarEmergencia()
    {
        IList<YouCom.DTO.Emergencia.EmergenciaDTO> myEmergencia = new List<YouCom.DTO.Emergencia.EmergenciaDTO>();

        //myEmergencia = YouCom.bll.EmergenciaBLL.getListadoEmergenciaByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        rptEmergencia.DataSource = myEmergencia;
        rptEmergencia.DataBind();
    }
}
