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

public partial class App_Master_Home : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarMenu();
        }

    }
     //<summary>
     //Carga Menu Dinamico desde BD
     //</summary>
    protected void CargarMenu()
    {

        //List<OperadorDTO> operador = new List<OperadorDTO>();
        //operador = Session["InformacionUsuario"] as List<OperadorDTO>;
        //string grupoCod = string.Empty;

        //foreach (var item in operador)
        //{

        //    ///Menu Primer Nivel
        //    foreach (var principal in item.Grupo)
        //    {
        //        if (grupoCod == principal.FuncionGrupoCod)
        //        {
        //        }
        //        else
        //        {

        //            menuPrincipal.Items.Add(new MenuItem(principal.FuncionGrupoNombre, principal.FuncionGrupoCod));
        //            menuPrincipal.Orientation = Orientation.Horizontal;
        //            grupoCod = principal.FuncionGrupoCod;


        //        }
        //        if (principal.Funciones != null)
        //        {
        //            foreach (var opcionesMenu in principal.Funciones)
        //            {
        //                ///Ejemplo Sub Menu Segundo Nivel  FuncionDTO

        //                MenuItem mnu = new MenuItem(opcionesMenu.FuncionNombre, opcionesMenu.Url, string.Empty, opcionesMenu.Url);

        //                menuPrincipal.FindItem(principal.FuncionGrupoCod).ChildItems.Add(mnu);

        //            }
        //        }


        //    }
        //}

    }

}


