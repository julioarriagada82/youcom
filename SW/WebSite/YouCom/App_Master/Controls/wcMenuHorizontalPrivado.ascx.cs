using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Seguridad;
using System.Linq;

public partial class App_Master_Controls_WebUserControl : Intermedia.IMSystem.Navigation.UserControl.WebUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            hlnkPortada.NavigateUrl = "http://" + Request.Url.Authority + "/Privado/Inicio.aspx";

            rptMenuPrivado.DataSource = CargarMenu();
            rptMenuPrivado.DataBind();
        }
    }

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

    protected void rptSubMenuPrivado_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.Seguridad.FuncionDTO)e.Item.DataItem).FuncionCod))
                {
                    HiddenField myHiddenField = new HiddenField();

                    myHiddenField = (HiddenField)e.Item.Parent.Parent.FindControl("HdnFuncionGrupoCod");

                    Repeater myRepeater = new Repeater();

                    myRepeater = (Repeater)e.Item.FindControl("rptSubSubMenuPrivado");

                    IList<FuncionDTO> myFuncionDTO = new List<FuncionDTO>();

                    myFuncionDTO = CargarSubSubMenu(myUsuario.Rut, ((YouCom.DTO.Seguridad.FuncionDTO)e.Item.DataItem).FuncionCod);

                    if(myFuncionDTO.Count > 0)
                    {
                        myRepeater.DataSource = myFuncionDTO;
                        myRepeater.DataBind();
                    }
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
                        FuncionDTO theFuncion = new FuncionDTO();

                        theFuncion = YouCom.Seguridad.BLL.FuncionBLL.detalleFuncion(funciones.Codigo);

                        if(theFuncion.PadreCod == 0)
                        {
                            FuncionDTO funcion = new FuncionDTO();

                            funcion.FuncionCod = funciones.Codigo;
                            funcion.FuncionNombre = funciones.Descripcion;
                            funcion.FuncionGrupoCod = theFuncion.FuncionGrupoCod;
                            funcion.Url = "http://" + Request.Url.Authority + ResolveUrl("~/") + theFuncion.Url.Replace("~/", "");
                            funcion.GrupoCod = theFuncion.FuncionGrupoCod;
                            IFuncion.Add(funcion);
                        }
                    }
                }
            }
        }

        return IFuncion;
    }

    protected IList<FuncionDTO> CargarSubSubMenu(string pRutUsuario, string pFuncionCod)
    {
        IList<FuncionDTO> IFuncion = new List<FuncionDTO>();
        List<FuncionDTO> myFuncionDTO = new List<FuncionDTO>();
        myFuncionDTO = YouCom.Seguridad.BLL.FuncionBLL.listaFuncion().Where(x => x.PadreCod == int.Parse(pFuncionCod)).ToList();

        foreach (FuncionDTO opcionesMenu in myFuncionDTO)
        {
            FuncionDTO funcion = new FuncionDTO();

            funcion.FuncionCod = opcionesMenu.FuncionCod;
            funcion.FuncionNombre = opcionesMenu.FuncionNombre;
            funcion.FuncionGrupoCod = opcionesMenu.FuncionGrupoCod;
            funcion.Url = !string.IsNullOrEmpty(opcionesMenu.Url) ? "http://" + Request.Url.Authority + ResolveUrl("~/") + opcionesMenu.Url.Replace("~/", "") : "#";
            funcion.GrupoCod = opcionesMenu.FuncionGrupoCod;
            IFuncion.Add(funcion);
        }

        return IFuncion;
    }

}