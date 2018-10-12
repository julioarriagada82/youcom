using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MCargo : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarCargo();
        }
    }

    protected void cargarCargo()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["cargo"] = YouCom.bll.CargoBLL.getListadoCargo();
            rptCargo.DataSource = YouCom.bll.CargoBLL.listaCargoActivo();
            rptCargo.DataBind();
        }
        else
        {
            Session["cargo"] = YouCom.bll.CargoBLL.getListadoCargo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptCargo.DataSource = YouCom.bll.CargoBLL.listaCargoActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptCargo.DataBind();
        }

    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionCargo.Visible = false;
        cargarCargoInactivo();
    }
    protected void cargarCargoInactivo()
    {
        IList<CargoDTO> Cargos = new List<CargoDTO>();
        Cargos = YouCom.bll.CargoBLL.listaCargoInactivo();
        if (Cargos.Any())
        {
            rptCargoInactivo.DataSource = Cargos;
            rptCargoInactivo.DataBind();
        }
        else
        {
            string script = "alert('No existen registros en  papelera .');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            return;

        }


    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        List<CargoDTO> Cargo = new List<CargoDTO>();
        Cargo = (Session["Cargo"] as List<CargoDTO>);

        CargoDTO theCargoDTO = new CargoDTO();
        theCargoDTO.NombreCargo = this.txtNombre.Text.ToUpper();
        theCargoDTO.DescripcionCargo = this.txtDescripcion.Text.ToUpper();
        theCargoDTO.UsuarioIngreso = myUsuario.Rut;

        //YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        //myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        //theCargoDTO.TheCondominioDTO = myCondominioDTO;

        Cargo = Cargo.Where(x => x.NombreCargo == theCargoDTO.NombreCargo).ToList();
        if (Cargo.Any())
        {
            foreach (var item in Cargo)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Cargo Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Cargo ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }


        }


        bool respuesta = YouCom.bll.CargoBLL.Insert(theCargoDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;

            string script = "alert('Cargo Ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarCargo();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        CargoDTO theCargoDTO = new CargoDTO();
        theCargoDTO.IdCargo = decimal.Parse(HdnIdCargo.Value);
        theCargoDTO.NombreCargo = this.txtNombre.Text;
        theCargoDTO.DescripcionCargo = this.txtDescripcion.Text;
        theCargoDTO.UsuarioModificacion = myUsuario.Rut;

        //YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        //myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        //theCargoDTO.TheCondominioDTO = myCondominioDTO;

        bool respuesta = YouCom.bll.CargoBLL.Update(theCargoDTO);

        if (respuesta)
        {
            cargarCargo();
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Cargo editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptCargoInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdCargo = new HiddenField();
            hdnIdCargo = (HiddenField)e.Item.FindControl("HdnIdCargo");
            
            CargoDTO theCargoDTO = new CargoDTO();
            theCargoDTO.IdCargo = decimal.Parse(hdnIdCasa.Value);
            theCargoDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.CargoBLL.ActivaCargo(theCargoDTO);
            if (respuesta)
            {
                cargarCargoInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Cargo Activada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptCargo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdCargo = new HiddenField();
            hdnIdCargo = (HiddenField)e.Item.FindControl("HdnIdCargo");

            YouCom.DTO.CargoDTO myCargoDTO = new CargoDTO();
            myCargoDTO = YouCom.bll.CargoBLL.detalleCargo(decimal.Parse(hdnIdCargo.Value));

            txtNombre.Text = myCargoDTO.NombreCargo;
            txtDescripcion.Text = myCargoDTO.DescripcionCargo;
            HdnIdCargo.Value = myCargoDTO.IdCargo.ToString();

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdCargo = new HiddenField();
            hdnIdCargo = (HiddenField)e.Item.FindControl("HdnIdCargo");

            CargoDTO theCargoDTO = new CargoDTO();
            theCargoDTO.IdCargo = decimal.Parse(hdnIdCargo.Value);
            theCargoDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.CargoBLL.ValidaEliminacionCargo(theCargoDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un Cargo con registro asociado.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.CargoBLL.Delete(theCargoDTO);
                if (respuesta)
                {
                    cargarCargo();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Cargo Eliminada correctamente.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
                else
                {
                }
            }
        }
    }
    void MuestraPanelError(bool wvarGeneric, bool wvarProducto, bool wvarSinProducto)
    {
        pnlGenericError.Visible = wvarGeneric;
        pnlProducto.Visible = wvarProducto;
        pnlSinProducto.Visible = wvarSinProducto;
    }
    void MuestraError(Exception ex)
    {
        HttpContext.Current.Session.Add("usuario", myUsuario);

        //Banner Central
        UserControl UCBanner = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl(YouCom.Service.Configuracion.General.getPageName(false) + "1").FindControl("BannerCentral1");
        Literal myLiteral = (Literal)UCBanner.FindControl("LitMensaje");
        HyperLink myHyperLink = (HyperLink)UCBanner.FindControl("HnlVolver");

        MuestraPanelError(false, false, true);

        myHyperLink.NavigateUrl = "/Private/" + YouCom.Service.Configuracion.General.getPageName(true);
        myLiteral.Text = YouCom.Web.KtErrores.MuestraError(myUsuario, ex, "MS_IB - Consulta Pizarra Autorizaciones", "http://" + Request.Url.Authority + ResolveUrl("~/") + YouCom.Service.Configuracion.General.getPageName(true));
    }
}
