using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_Directiva : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarDirectiva();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void cargarDirectiva()
    {
        IList<YouCom.DTO.DirectivaDTO> myDirectiva = new List<YouCom.DTO.DirectivaDTO>();

        //myDirectiva = YouCom.bll.DirectivaBLL.getListadoDirectivaByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        rptDirectiva.DataSource = myDirectiva;
        rptDirectiva.DataBind();
    }

    protected void rptDirectiva_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.DirectivaDTO)e.Item.DataItem).NombreDirectiva))
                {
                    HyperLink myLnkContactar = new HyperLink();
                    myLnkContactar = (HyperLink)e.Item.FindControl("LnkContactar");

                    LinkButton myLnkBtnContactar = new LinkButton();
                    myLnkBtnContactar = (LinkButton)e.Item.FindControl("LnkBtnContactar");

                    Image img = (Image)e.Item.FindControl("imgDirectiva");

                    if (!string.IsNullOrEmpty(((YouCom.DTO.DirectivaDTO)e.Item.DataItem).ImagenDirectiva) && ((YouCom.DTO.DirectivaDTO)e.Item.DataItem).ImagenDirectiva.Trim() != "")
                    {
                        img.ImageUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathDirectivaPub") + ((YouCom.DTO.DirectivaDTO)e.Item.DataItem).ImagenDirectiva;
                        img.AlternateText = ((YouCom.DTO.DirectivaDTO)e.Item.DataItem).NombreCompleto;
                        img.ToolTip = ((YouCom.DTO.DirectivaDTO)e.Item.DataItem).NombreCompleto;
                    }
                    else
                    {
                        //img.Visible = false;
                        img.ImageUrl = "../img/no-user.jpg";
                        img.AlternateText = ((YouCom.DTO.DirectivaDTO)e.Item.DataItem).NombreCompleto;
                        img.ToolTip = ((YouCom.DTO.DirectivaDTO)e.Item.DataItem).NombreCompleto;
                    }

                    if (((YouCom.DTO.DirectivaDTO)e.Item.DataItem).TheCargoDTO.IdCargo == 1)
                    {
                        myLnkBtnContactar.Visible = true;
                        myLnkContactar.Visible = false;
                    }
                    else
                    {
                        myLnkBtnContactar.Visible = false;
                        myLnkContactar.Visible = true;

                        myLnkContactar.NavigateUrl = "mailto:" + ((YouCom.DTO.DirectivaDTO)e.Item.DataItem).EmailDirectiva;
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptDirectiva_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Contactar"))
            {
                HiddenField hdnIdDirectiva = (HiddenField)e.Item.FindControl("hdnIdDirectiva");

                Session.Add("DirectivaId", hdnIdDirectiva.Value);
                Response.Redirect("~/Privado/Contacto/MensajeAdministracion.aspx", false);
            }
        }
        catch (Exception ex)
        {

        }
    }
}
