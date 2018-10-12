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
using YouCom.DTO.Seguridad;
using System.Collections.Generic;

public partial class App_Master_Controls_uscMenuPrivado : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rptMenuPrivado.DataSource = CargarMenu();
            rptMenuPrivado.DataBind();
        }
    }

    /// <summary>
    /// Carga Menu Dinamico desde BD
    /// </summary>
    protected IList<FuncionGrupoDTO> CargarMenu()
    {
        IList<FuncionGrupoDTO> IFuncionGrupo = new List<FuncionGrupoDTO>();

        IList<OperadorDTO> operador = new List<OperadorDTO>();
        operador = (IList<OperadorDTO>)Session["InformacionUsuario"];

        string grupoCod = string.Empty;

        foreach (OperadorDTO ope in operador)
        {
            ///Menu Primer Nivel
            foreach (var principal in ope.Grupo)
            {
                if (grupoCod == principal.FuncionGrupoCod)
                {
                }
                else
                {
                    FuncionGrupoDTO funcionGrupo = new FuncionGrupoDTO();

                    funcionGrupo.FuncionGrupoCod = principal.FuncionGrupoCod;
                    funcionGrupo.FuncionGrupoNombre = principal.FuncionGrupoNombre;
                    funcionGrupo.FuncionGrupoTipo = principal.FuncionGrupoTipo;

                    IFuncionGrupo.Add(funcionGrupo);
                    grupoCod = principal.FuncionGrupoCod;
                }
            }
        }

        return IFuncionGrupo;
    }


    protected void rptMenuPrivado_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.Seguridad.FuncionGrupoDTO)e.Item.DataItem).FuncionGrupoCod))
                {
                    Repeater myRepeater = new Repeater();

                    myRepeater = (Repeater)e.Item.FindControl("rptSubMenuPrivado");

                    myRepeater.DataSource = CargarSubMenu(((YouCom.DTO.Seguridad.FuncionGrupoDTO)e.Item.DataItem).FuncionGrupoCod);
                    myRepeater.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected IList<FuncionDTO> CargarSubMenu(string pFuncionGrupoCod)
    {

        List<OperadorDTO> operador = new List<OperadorDTO>();
        operador = Session["InformacionUsuario"] as List<OperadorDTO>;
        IList<FuncionDTO> IFuncion = new List<FuncionDTO>();

        foreach (var item in operador)
        {
            ///Menu Primer Nivel
            foreach (var principal in item.Grupo)
            {
                if (pFuncionGrupoCod == principal.FuncionGrupoCod)
                {
                    if (principal.Funciones != null)
                    {
                        foreach (FuncionDTO opcionesMenu in principal.Funciones)
                        {
                            ///Ejemplo Sub Menu Segundo Nivel  FuncionDTO
                            ///
                            FuncionDTO funcion = new FuncionDTO();

                            funcion.FuncionNombre = opcionesMenu.FuncionNombre;
                            funcion.FuncionGrupoCod = opcionesMenu.FuncionGrupoCod;
                            funcion.Url = "http://" + Request.Url.Authority + ResolveUrl("~/") + opcionesMenu.Url.Replace("~/", "");
                            funcion.GrupoCod = opcionesMenu.FuncionGrupoCod;
                            IFuncion.Add(funcion);
                        }
                    }
                }
            }
        }

        return IFuncion;
    }
}

