using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_VotacionIniciativa : Intermedia.IMSystem.Navigation.Page.WebPage
{
    private const string retorno1 = "../Default.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                SelView(0);
                cargarVotacionPropuesta();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    void SelView(Int32 nIndex)
    {
        this.mvwVotacion.ActiveViewIndex = nIndex;
    }

    protected void cargarVotacionPropuesta()
    {
        IList<YouCom.DTO.Propuesta.VotacionPropuestaDTO> myVotacionPropuestaDTO = new List<YouCom.DTO.Propuesta.VotacionPropuestaDTO>();

        //myVotacionPropuestaDTO = YouCom.bll.VotacionPropuestaBLL.getListadoVotacionPropuestaByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        rptVotacion.DataSource = myVotacionPropuestaDTO;
        rptVotacion.DataBind();
    }

    protected void rptVotacion_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Detalle"))
            {
                HiddenField HdnIdPropuesta = (HiddenField)e.Item.FindControl("hdnIdPropuesta");
                HiddenField HdnIdVotacionPropuesta = (HiddenField)e.Item.FindControl("hdnIdVotacionPropuesta");

                YouCom.DTO.Propuesta.PropuestaDTO myPropuestaDTO = new YouCom.DTO.Propuesta.PropuestaDTO();
                myPropuestaDTO = YouCom.bll.PropuestaBLL.detallePropuesta(decimal.Parse(HdnIdPropuesta.Value));

                LitPropuestaNombre.Text = myPropuestaDTO.NombrePropuesta;
                LitPropuestaDecripcion.Text = myPropuestaDTO.DescripcionPropuesta;
                LitPropuestaFecha.Text = myPropuestaDTO.FechaPropuesta.ToShortDateString();
                LitNombreFamilia.Text = myPropuestaDTO.TheFamiliaDTO.NombreCompleto;

                this.hdnVotacionPropuestaId.Value = HdnIdVotacionPropuesta.Value;

                YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);

                YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO myVotacionPropuestaRespuestaDTO = new YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO();
                myVotacionPropuestaRespuestaDTO = YouCom.bll.VotacionPropuestaRespuestaBLL.detalleVotacionPropuestaRespuesta(decimal.Parse(this.hdnVotacionPropuestaId.Value), myFamiliaDTO.IdFamilia);

                if(!string.IsNullOrEmpty(myVotacionPropuestaRespuestaDTO.EleccionVotacion))
                {
                    rdbSeleccion.SelectedIndex = rdbSeleccion.Items.IndexOf(rdbSeleccion.Items.FindByValue(myVotacionPropuestaRespuestaDTO.EleccionVotacion.ToString()));
                }

                if(!string.IsNullOrEmpty(rdbSeleccion.SelectedValue))
                {
                    rdbSeleccion.Enabled = false;
                    BtnEnviar.Enabled = false;
                }
                else
                {
                    rdbSeleccion.Enabled = true;
                    BtnEnviar.Enabled = true;
                }



                this.SelView(this.mvwVotacion.ActiveViewIndex + 1);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO myVotacionPropuestaRespuestaDTO = new YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO();

                YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                myVotacionPropuestaRespuestaDTO.TheFamiliaDTO = myFamiliaDTO;

                YouCom.DTO.Propuesta.VotacionPropuestaDTO myVotacionPropuestaDTO = new YouCom.DTO.Propuesta.VotacionPropuestaDTO();
                myVotacionPropuestaDTO.IdVotacionPropuesta = decimal.Parse(this.hdnVotacionPropuestaId.Value);
                myVotacionPropuestaRespuestaDTO.TheVotacionPropuestaDTO = myVotacionPropuestaDTO;

                myVotacionPropuestaRespuestaDTO.EleccionVotacion = rdbSeleccion.SelectedValue;
                myVotacionPropuestaRespuestaDTO.FechaVotacion = DateTime.Now;

                bool respuesta = YouCom.bll.VotacionPropuestaRespuestaBLL.Insert(myVotacionPropuestaRespuestaDTO);

                if (respuesta)
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Estimado Cliente, hemos recibido su votación, en breve nos contactaremos con usted.');";
                        script += "parent.location = '" + retorno1 + "';";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
                else
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('A ocurrido un error. Favor envíe su solicitud al mail contacto@youcom.cl intente más tarde.');";
                        script += "parent.location = '" + retorno1 + "';";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}