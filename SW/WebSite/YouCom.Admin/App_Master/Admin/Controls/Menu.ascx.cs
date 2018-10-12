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

public partial class App_Master_Controls_Menu : System.Web.UI.UserControl
{
    public YouCom.DTO.Seguridad.UsuarioDTO myUsuario = new YouCom.DTO.Seguridad.UsuarioDTO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rptMenu.DataSource = CargarMenu();
            rptMenu.DataBind();
        }
    }

    /// <summary>
    /// Carga Menu Dinamico desde BD
    /// </summary>
    protected IList<FuncionGrupoDTO> CargarMenu()
    {
        IList<FuncionGrupoDTO> IFuncionGrupo = new List<FuncionGrupoDTO>();
        myUsuario = (YouCom.DTO.Seguridad.UsuarioDTO)Session["usuario"];

        string grupoCod = string.Empty;

        foreach (YouCom.DTO.Seguridad.CondominioDTO condominio in myUsuario.TheCondominioDTO)
        {
            foreach (YouCom.DTO.ProductoDTO producto in condominio.Productos)
            {
                FuncionGrupoDTO funcionGrupo = new FuncionGrupoDTO();

                funcionGrupo.FuncionGrupoCod = producto.Codigo;
                funcionGrupo.FuncionGrupoNombre = producto.Descripcion;
                //funcionGrupo.FuncionGrupoTipo = principal.FuncionGrupoTipo;

                IFuncionGrupo.Add(funcionGrupo);
            }
        }

        return IFuncionGrupo;
    }


    protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.Seguridad.FuncionGrupoDTO)e.Item.DataItem).FuncionGrupoCod))
                {
                    Repeater myRepeater = new Repeater();

                    myRepeater = (Repeater)e.Item.FindControl("rptSubMenu");

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
        myUsuario = (YouCom.DTO.Seguridad.UsuarioDTO)Session["usuario"];
        IList<FuncionDTO> IFuncion = new List<FuncionDTO>();

        foreach (YouCom.DTO.Seguridad.CondominioDTO condominio in myUsuario.TheCondominioDTO)
        {
            foreach (YouCom.DTO.ProductoDTO producto in condominio.Productos)
            {
                if (producto.Codigo.Equals(pFuncionGrupoCod))
                {
                    foreach (YouCom.DTO.Item funciones in producto.Funciones)
                    {
                        FuncionDTO funcion = new FuncionDTO();
                        FuncionDTO theFuncion = new FuncionDTO();

                        theFuncion = YouCom.Seguridad.BLL.FuncionBLL.detalleFuncion(funciones.Codigo);

                        funcion.FuncionNombre = funciones.Descripcion;
                        funcion.FuncionGrupoCod = theFuncion.FuncionGrupoCod;
                        funcion.Url = "http://" + Request.Url.Authority + ResolveUrl("~/") + "Private/" + theFuncion.Url.Replace("~/", "");
                        funcion.GrupoCod = theFuncion.FuncionGrupoCod;
                        IFuncion.Add(funcion);
                    }
                }
            }
        }

        return IFuncion;
    }
}
