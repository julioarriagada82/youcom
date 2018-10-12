using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Master_Interna : System.Web.UI.MasterPage
{
    public string url = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            url = "http://" + Request.Url.Authority + "/Privado/";
            cargarTurnos();
        }

    }

    protected void cargarTurnos()
    {
        IList<YouCom.DTO.TurnoDiarioDTO> myTurnoDiarioDTO = new List<YouCom.DTO.TurnoDiarioDTO>();

        myTurnoDiarioDTO = YouCom.bll.TurnoDiarioBLL.listaTurnoDiarioActivo();

        rptTurnosDiarios.DataSource = myTurnoDiarioDTO;
        rptTurnosDiarios.DataBind();
    }

    protected void rptTurnosDiarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.TurnoDiarioDTO)e.Item.DataItem).IdTurnoDiario.ToString()))
                {
                    HiddenField myHiddenPorteria = new HiddenField();
                    myHiddenPorteria = (HiddenField)e.Item.FindControl("hdnPorteriaId");

                    Literal myLitNombrePortero = new Literal();
                    myLitNombrePortero = (Literal)e.Item.FindControl("LitNombrePortero");

                    Literal myLitPeriodo = new Literal();
                    myLitPeriodo = (Literal)e.Item.FindControl("LitPeriodo");

                    Literal myLitHoraInicio = new Literal();
                    myLitHoraInicio = (Literal)e.Item.FindControl("LitHoraInicio");

                    Literal myLitHoraTermino = new Literal();
                    myLitHoraTermino = (Literal)e.Item.FindControl("LitHoraTermino");

                    YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
                    YouCom.DTO.HorarioTurnoDTO myHorarioTurnoDTO = new YouCom.DTO.HorarioTurnoDTO();
                    YouCom.DTO.PeriodoHorarioDTO myPeriodoHorarioDTO = new YouCom.DTO.PeriodoHorarioDTO();

                    myPorteriaDTO = YouCom.bll.PorteriaBLL.detallePorteria(((YouCom.DTO.TurnoDiarioDTO)e.Item.DataItem).ThePorteriaDTO.IdPorteria);
                    myHorarioTurnoDTO = YouCom.bll.HorarioTurnoBLL.detalleHorarioTurno(((YouCom.DTO.TurnoDiarioDTO)e.Item.DataItem).TheHorarioTurnoDTO.IdHorarioTurno);
                    myPeriodoHorarioDTO = YouCom.bll.PeriodoHorarioBLL.detallePeriodoHorario(myHorarioTurnoDTO.ThePeriodoHorarioDTO.IdPeriodoHorario);

                    myLitNombrePortero.Text = myPorteriaDTO.NombrePorteria + " " + myPorteriaDTO.ApellidoPaternoPorteria + " " + myPorteriaDTO.ApellidoMaternoPorteria;
                    myLitPeriodo.Text = myPeriodoHorarioDTO.NombrePeriodoHorario;
                    myLitHoraInicio.Text = myHorarioTurnoDTO.HoraInicio;
                    myLitHoraTermino.Text = myHorarioTurnoDTO.HoraTermino;

                    myHiddenPorteria.Value = myPorteriaDTO.IdPorteria.ToString();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptTurnosDiarios_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Contactar")
        {
            HiddenField myHiddenPorteria = new HiddenField();
            myHiddenPorteria = (HiddenField)e.Item.FindControl("hdnPorteriaId");

            Session.Add("PorteriaId", myHiddenPorteria.Value);
            Response.Redirect("~/Privado/Contacto/MensajePorteria.aspx", false);
        }

    }

}


