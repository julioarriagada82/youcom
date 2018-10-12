using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privado_TurnosDiarios : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarTurnos();
            }
        }
        catch (Exception ex)
        {
            string script = "'alert('" + ex.Message + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
        }
    }

    protected void cargarTurnos()
    {
        IList<YouCom.DTO.TurnoDiarioDTO> myTurnoDiarioDTO = new List<YouCom.DTO.TurnoDiarioDTO>();

        //myTurnoDiarioDTO = YouCom.bll.TurnoDiarioBLL.getListadoTurnoDiarioByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        rptTurnos.DataSource = myTurnoDiarioDTO;
        rptTurnos.DataBind();
    }

    protected void rptTurnos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.TurnoDiarioDTO)e.Item.DataItem).NombreTurnoDiario))
                {
                    Repeater myRptPorteria = new Repeater();
                    Repeater myRptHorario = new Repeater();

                    myRptPorteria = (Repeater)e.Item.FindControl("rptPortero");
                    myRptHorario = (Repeater)e.Item.FindControl("rptHorario");

                    IList<YouCom.DTO.PorteriaDTO> myPorteriaDTO = new List<YouCom.DTO.PorteriaDTO>();
                    IList<YouCom.DTO.HorarioTurnoDTO> myHorarioTurnoDTO = new List<YouCom.DTO.HorarioTurnoDTO>();

                    //myPorteriaDTO = YouCom.bll.PorteriaBLL.getListadoPorteriaByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);
                    //myHorarioTurnoDTO = YouCom.bll.HorarioTurnoBLL.getListadoHorarioTurnoByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

                    myPorteriaDTO = myPorteriaDTO.Where(x => x.IdPorteria == ((YouCom.DTO.TurnoDiarioDTO)e.Item.DataItem).ThePorteriaDTO.IdPorteria).ToList();
                    myHorarioTurnoDTO = myHorarioTurnoDTO.Where(x => x.IdHorarioTurno == ((YouCom.DTO.TurnoDiarioDTO)e.Item.DataItem).TheHorarioTurnoDTO.IdHorarioTurno).ToList();

                    myRptPorteria.DataSource = myPorteriaDTO;
                    myRptPorteria.DataBind();

                    myRptHorario.DataSource = myHorarioTurnoDTO;
                    myRptHorario.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptHorario_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.HorarioTurnoDTO)e.Item.DataItem).IdHorarioTurno.ToString()))
                {
                    Literal myLiteral = new Literal();

                    myLiteral = (Literal)e.Item.FindControl("LitPeriodo");

                    YouCom.DTO.PeriodoHorarioDTO myPeriodoHorarioDTO = new YouCom.DTO.PeriodoHorarioDTO();

                    myPeriodoHorarioDTO = YouCom.bll.PeriodoHorarioBLL.detallePeriodoHorario(((YouCom.DTO.HorarioTurnoDTO)e.Item.DataItem).ThePeriodoHorarioDTO.IdPeriodoHorario);

                    myLiteral.Text = myPeriodoHorarioDTO.NombrePeriodoHorario;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}
