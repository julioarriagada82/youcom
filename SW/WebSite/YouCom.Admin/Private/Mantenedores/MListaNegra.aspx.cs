using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MListaNegra : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarListaNegra();
        }
    }

    protected void cargarListaNegra()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["listaNegra"] = YouCom.bll.ListaNegraBLL.getListadoListaNegra();
            rptListaNegra.DataSource = YouCom.bll.ListaNegraBLL.listaListaNegraActivo();
            rptListaNegra.DataBind();

        }
        else
        {
            Session["listaNegra"] = YouCom.bll.ListaNegraBLL.getListadoListaNegra().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptListaNegra.DataSource = YouCom.bll.ListaNegraBLL.listaListaNegraActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptListaNegra.DataBind();
        }

    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionListaNegra.Visible = false;
        cargarListaNegraInactivo();
    }
    protected void cargarListaNegraInactivo()
    {
        IList<ListaNegraDTO> listaNegra = new List<ListaNegraDTO>();
        listaNegra = YouCom.bll.ListaNegraBLL.listaListaNegraInactivo();
        if (listaNegra.Any())
        {
            rptListaNegraInactivo.DataSource = listaNegra;
            rptListaNegraInactivo.DataBind();
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
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasaFamilia1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");
        DropDownList ddlFamilia = (DropDownList)wucCondominio.FindControl("ddlFamilia");

        List<ListaNegraDTO> listaNegra = new List<ListaNegraDTO>();
        listaNegra = (Session["listaNegra"] as List<ListaNegraDTO>);

        ListaNegraDTO theListaNegraDTO = new ListaNegraDTO();
        theListaNegraDTO.RutListaNegra = YouCom.Service.Generales.Formato.LimpiarRut(this.txtRut.Text.ToUpper());
        theListaNegraDTO.NombreListaNegra = this.txtNombre.Text.ToUpper();
        theListaNegraDTO.ApellidoPaternoListaNegra = this.txtApellidoPaterno.Text.ToUpper();
        theListaNegraDTO.ApellidoMaternoListaNegra = this.txtApellidoMaterno.Text.ToUpper();
        theListaNegraDTO.MotivoListaNegra = this.txtMotivo.Text;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theListaNegraDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theListaNegraDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propietario.CasaDTO myCasaDTO = new YouCom.DTO.Propietario.CasaDTO();
        myCasaDTO.IdCasa = decimal.Parse(ddlCasa.SelectedValue);
        theListaNegraDTO.TheCasaDTO = myCasaDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO.IdFamilia = decimal.Parse(ddlFamilia.SelectedValue);
        theListaNegraDTO.TheFamiliaDTO = myFamiliaDTO;

        theListaNegraDTO.UsuarioIngreso = myUsuario.Rut;

        listaNegra = listaNegra.Where(x => x.RutListaNegra == theListaNegraDTO.RutListaNegra).ToList();
        if (listaNegra.Any())
        {
            foreach (var item in listaNegra)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Lista Negra Existe pero fue eliminado para activarla dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Lista Negra ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.ListaNegraBLL.Insert(theListaNegraDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            this.txtRut.Text = string.Empty;
            this.txtApellidoPaterno.Text = string.Empty;
            this.txtApellidoMaterno.Text = string.Empty;
            this.txtMotivo.Text = string.Empty;
            ddlCondominio.ClearSelection();
            ddlCasa.ClearSelection();
            ddlFamilia.ClearSelection();

            string script = "alert('Lista Negra Ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarListaNegra();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasaFamilia1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");
        DropDownList ddlFamilia = (DropDownList)wucCondominio.FindControl("ddlFamilia");

        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        ListaNegraDTO theListaNegraDTO = new ListaNegraDTO();
        theListaNegraDTO.RutListaNegra = YouCom.Service.Generales.Formato.LimpiarRut(this.txtRut.Text.ToUpper());
        theListaNegraDTO.NombreListaNegra = this.txtNombre.Text.ToUpper();
        theListaNegraDTO.ApellidoPaternoListaNegra = this.txtApellidoPaterno.Text.ToUpper();
        theListaNegraDTO.ApellidoMaternoListaNegra = this.txtApellidoMaterno.Text.ToUpper();
        theListaNegraDTO.MotivoListaNegra = this.txtMotivo.Text;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theListaNegraDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theListaNegraDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propietario.CasaDTO myCasaDTO = new YouCom.DTO.Propietario.CasaDTO();
        myCasaDTO.IdCasa = decimal.Parse(ddlCasa.SelectedValue);
        theListaNegraDTO.TheCasaDTO = myCasaDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO.IdFamilia = decimal.Parse(ddlFamilia.SelectedValue);
        theListaNegraDTO.TheFamiliaDTO = myFamiliaDTO;

        theListaNegraDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.ListaNegraBLL.Update(theListaNegraDTO);

        if (respuesta)
        {
            cargarListaNegra();

            this.txtNombre.Text = string.Empty;
            this.txtRut.Text = string.Empty;
            this.txtApellidoPaterno.Text = string.Empty;
            this.txtApellidoMaterno.Text = string.Empty;
            this.txtMotivo.Text = string.Empty;
            ddlCondominio.ClearSelection();
            ddlCasa.ClearSelection();
            ddlFamilia.ClearSelection();

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Lista Negra editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptListaNegraInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdListaNegra = new HiddenField();
            hdnIdListaNegra = (HiddenField)e.Item.FindControl("hdnIdListaNegra");

            ListaNegraDTO theListaNegraDTO = new ListaNegraDTO();
            theListaNegraDTO.IdListaNegra = decimal.Parse(hdnIdListaNegra.Value);
            theListaNegraDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.ListaNegraBLL.ActivaListaNegra(theListaNegraDTO);
            if (respuesta)
            {
                cargarListaNegraInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Integrante de la Familia Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptListaNegra_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasaFamilia1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");
        DropDownList ddlFamilia = (DropDownList)wucCondominio.FindControl("ddlFamilia");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdListaNegra = new HiddenField();
            hdnIdListaNegra = (HiddenField)e.Item.FindControl("hdnIdListaNegra");

            YouCom.DTO.ListaNegraDTO theListaNegraDTO = new YouCom.DTO.ListaNegraDTO();
            theListaNegraDTO = YouCom.bll.ListaNegraBLL.detalleListaNegra(decimal.Parse(hdnIdListaNegra.Value));

            this.hdnIdListaNegra.Value = theListaNegraDTO.IdListaNegra.ToString();
            this.txtNombre.Text = theListaNegraDTO.NombreListaNegra;
            this.txtRut.Text = YouCom.Service.Generales.Formato.FormatoRut(theListaNegraDTO.RutListaNegra);
            this.txtApellidoPaterno.Text = theListaNegraDTO.ApellidoPaternoListaNegra;
            this.txtApellidoMaterno.Text = theListaNegraDTO.ApellidoMaternoListaNegra;
            this.txtMotivo.Text = theListaNegraDTO.MotivoListaNegra;

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(theListaNegraDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(theListaNegraDTO.TheComunidadDTO.IdComunidad.ToString()));

            ddlCasa.DataSource = YouCom.bll.CasaBLL.getListadoCasaByComunidad(decimal.Parse(ddlComunidad.SelectedValue));
            ddlCasa.DataTextField = "NombreCasa";
            ddlCasa.DataValueField = "IdCasa";
            ddlCasa.DataBind();
            ddlCasa.Items.Insert(0, new ListItem("Seleccione Casa", string.Empty));

            YouCom.DTO.Propietario.FamiliaDTO theFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
            theFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamilia(theListaNegraDTO.TheFamiliaDTO.IdFamilia);

            ddlCasa.SelectedIndex = ddlCasa.Items.IndexOf(ddlCasa.Items.FindByValue(theFamiliaDTO.TheCasaDTO.IdCasa.ToString()));

            List<YouCom.DTO.Propietario.FamiliaDTO> familias = new List<YouCom.DTO.Propietario.FamiliaDTO>();
            familias = YouCom.bll.FamiliaBLL.listaFamiliaActivo().Where(x => x.TheCasaDTO.IdCasa == decimal.Parse(ddlCasa.SelectedValue)).ToList();

            ddlFamilia.DataSource = familias;
            ddlFamilia.DataTextField = "NombreCompleto";
            ddlFamilia.DataValueField = "IdFamilia";
            ddlFamilia.DataBind();
            ddlFamilia.Items.Insert(0, new ListItem("Seleccione Integrante Familia", string.Empty));

            ddlFamilia.SelectedIndex = ddlFamilia.Items.IndexOf(ddlFamilia.Items.FindByValue(theListaNegraDTO.TheFamiliaDTO.IdFamilia.ToString()));

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdListaNegra = new HiddenField();
            hdnIdListaNegra = (HiddenField)e.Item.FindControl("hdnIdListaNegra");

            ListaNegraDTO theListaNegraDTO = new ListaNegraDTO();
            theListaNegraDTO.IdListaNegra = decimal.Parse(hdnIdListaNegra.Value);
            theListaNegraDTO.UsuarioModificacion = myUsuario.Rut;

            bool respuesta = YouCom.bll.ListaNegraBLL.Delete(theListaNegraDTO);
            if (respuesta)
            {
                cargarListaNegra();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Lista Negra Eliminada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
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
