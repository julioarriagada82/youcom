using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_ListaNegra : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarListaNegra();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void cargarListaNegra()
    {
        IList<YouCom.DTO.ListaNegraDTO> myListaNegra = new List<YouCom.DTO.ListaNegraDTO>();

        //myListaNegra = YouCom.bll.ListaNegraBLL.getListadoListaNegraByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        myListaNegra = myListaNegra.Where(x => x.TheCondominioDTO.IdCondominio == 1).ToList();

        rptListaNegra.DataSource = myListaNegra;
        rptListaNegra.DataBind();
    }
}
