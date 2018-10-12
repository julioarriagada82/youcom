using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_Vecinos : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarCasa();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void cargarCasa()
    {
        IList<YouCom.DTO.Propietario.CasaDTO> myCasa = new List<YouCom.DTO.Propietario.CasaDTO>();

        //myCasa = YouCom.bll.CasaBLL.getListadoCasaByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        rptCasa.DataSource = myCasa;
        rptCasa.DataBind();
    }

    protected void rptCasa_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.Propietario.CasaDTO)e.Item.DataItem).NombreCasa))
                {
                    Repeater myRepeater = new Repeater();

                    myRepeater = (Repeater)e.Item.FindControl("rptIntegrantes");

                    IList<YouCom.DTO.Propietario.FamiliaDTO> myFamilia = new List<YouCom.DTO.Propietario.FamiliaDTO>();

                    myFamilia = YouCom.bll.FamiliaBLL.listaFamiliaActivo();

                    myFamilia = myFamilia.Where(x => x.TheCasaDTO.IdCasa == ((YouCom.DTO.Propietario.CasaDTO)e.Item.DataItem).IdCasa).ToList();

                    myRepeater.DataSource = myFamilia;
                    myRepeater.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptIntegrantes_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Contactar"))
            {
                HiddenField hdnFamiliaId = (HiddenField)e.Item.FindControl("hdnFamiliaId");

                Session.Add("FamiliaId", hdnFamiliaId.Value);
                Response.Redirect("~/Privado/Contacto/MensajePropietario.aspx", false);
            }
        }
        catch (Exception ex)
        {

        }
    }
}
