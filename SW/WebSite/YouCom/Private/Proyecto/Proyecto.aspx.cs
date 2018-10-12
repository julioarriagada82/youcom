using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_Proyecto_Proyecto : Intermedia.IMSystem.Navigation.Page.WebPage
{
    private const string retorno1 = "../Default.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                SelView(0);
                cargarProyecto();
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
        this.mvwProyecto.ActiveViewIndex = nIndex;
    }

    protected void cargarProyecto()
    {
        IList<YouCom.DTO.ProyectoDTO> myProyectoDTO = new List<YouCom.DTO.ProyectoDTO>();

        //myProyectoDTO = YouCom.bll.ProyectoBLL.getListadoProyectoByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        rptProyecto.DataSource = myProyectoDTO;
        rptProyecto.DataBind();
    }

    protected void rptVotacion_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Detalle"))
            {
                HiddenField HdnIdProyecto = (HiddenField)e.Item.FindControl("hdnIdProyecto");
                
                YouCom.DTO.ProyectoDTO myProyectoDTO = new YouCom.DTO.ProyectoDTO();
                myProyectoDTO = YouCom.bll.ProyectoBLL.detalleProyecto(decimal.Parse(HdnIdProyecto.Value));

                LitProyectoNombre.Text = myProyectoDTO.NombreProyecto;
                LitProyectoDecripcion.Text = myProyectoDTO.DescripcionProyecto;
                LitProyectoFecha.Text = myProyectoDTO.FechaEntregaProyecto.ToShortDateString();
                LitNombreFamilia.Text = myProyectoDTO.TheEmpresaContratistaDTO.RazonSocialEmpresaContratista;

                this.SelView(this.mvwProyecto.ActiveViewIndex + 1);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void BtnVolver_Click(object sender, EventArgs e)
    {
        this.SelView(this.mvwProyecto.ActiveViewIndex - 1);
    }
}