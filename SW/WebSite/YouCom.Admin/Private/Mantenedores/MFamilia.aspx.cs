using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Propietario;

public partial class Admin_Mantenedores_MFamilia : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarParentesco();
            cargarOcupacion();
            cargarFamilia();
            cargarParametros();
        }
    }

    protected void cargarParametros()
    {
        ddlAnexoCelular.DataSource = YouCom.bll.ParametrosBLL.getListadoParametrosByConcepto("ANEXOCELULAR");
        ddlAnexoCelular.DataTextField = "Descripcion";
        ddlAnexoCelular.DataValueField = "Codigo";
        ddlAnexoCelular.DataBind();
        ddlAnexoCelular.Items.Insert(0, new ListItem("--", string.Empty));

        ddlAnexoTelefono.DataSource = YouCom.bll.ParametrosBLL.getListadoParametrosByConcepto("ANEXOTELEFONO");
        ddlAnexoTelefono.DataTextField = "Descripcion";
        ddlAnexoTelefono.DataValueField = "Codigo";
        ddlAnexoTelefono.DataBind();
        ddlAnexoTelefono.Items.Insert(0, new ListItem("--", string.Empty));
    }

    protected void cargarOcupacion()
    {
        ddlOcupacion.DataSource = YouCom.bll.OcupacionBLL.listaOcupacionActivo();
        ddlOcupacion.DataTextField = "NombreOcupacion";
        ddlOcupacion.DataValueField = "IdOcupacion";
        ddlOcupacion.DataBind();
        ddlOcupacion.Items.Insert(0, new ListItem("Seleccione Ocupación", string.Empty));
    }

    protected void cargarParentesco()
    {
        ddlParentesco.DataSource = YouCom.bll.ParentescoBLL.listaParentescoActivo();
        ddlParentesco.DataTextField = "NombreParentesco";
        ddlParentesco.DataValueField = "IdParentesco";
        ddlParentesco.DataBind();
        ddlParentesco.Items.Insert(0, new ListItem("Seleccione Parentesco", string.Empty));
    }

    protected void cargarFamilia()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["familia"] = YouCom.bll.FamiliaBLL.getListadoFamilia();
            rptFamilia.DataSource = YouCom.bll.FamiliaBLL.listaFamiliaActivo();
            rptFamilia.DataBind();
        }
        else
        {
            Session["familia"] = YouCom.bll.FamiliaBLL.getListadoFamilia().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptFamilia.DataSource = YouCom.bll.FamiliaBLL.listaFamiliaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptFamilia.DataBind();
        }

    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionCasa.Visible = false;
        cargarFamiliaInactivo();
    }
    protected void cargarFamiliaInactivo()
    {
        IList<FamiliaDTO> familias = new List<FamiliaDTO>();
        familias = YouCom.bll.FamiliaBLL.listaFamiliaInactivo();
        if (familias.Any())
        {
            rptFamiliaInactivo.DataSource = familias;
            rptFamiliaInactivo.DataBind();
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
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        List<FamiliaDTO> familia = new List<FamiliaDTO>();
        familia = (Session["familia"] as List<FamiliaDTO>);

        FamiliaDTO theFamiliaDTO = new FamiliaDTO();
        theFamiliaDTO.RutFamilia = this.txtRut.Text.ToUpper();
        theFamiliaDTO.NombreFamilia = this.txtNombre.Text.ToUpper();
        theFamiliaDTO.ApellidoPaternoFamilia = this.txtApellidoPaterno.Text.ToUpper();
        theFamiliaDTO.ApellidoMaternoFamilia = this.txtApellidoMaterno.Text.ToUpper();
        theFamiliaDTO.TelefonoFamilia = this.txtTelefono.Text;
        theFamiliaDTO.EmailFamilia = this.txtEmail.Text;
        theFamiliaDTO.CelularFamilia = this.txtCelular.Text;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theFamiliaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theFamiliaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propietario.ParentescoDTO myParentescoDTO = new YouCom.DTO.Propietario.ParentescoDTO();
        myParentescoDTO.IdParentesco = decimal.Parse(ddlParentesco.SelectedValue);
        theFamiliaDTO.TheParentescoDTO = myParentescoDTO;

        YouCom.DTO.Propietario.OcupacionDTO myOcupacionDTO = new YouCom.DTO.Propietario.OcupacionDTO();
        myOcupacionDTO.IdOcupacion = decimal.Parse(ddlOcupacion.SelectedValue);
        theFamiliaDTO.TheOcupacionDTO = myOcupacionDTO;

        YouCom.DTO.Propietario.CasaDTO myCasaDTO = new YouCom.DTO.Propietario.CasaDTO();
        myCasaDTO.IdCasa = decimal.Parse(ddlCasa.SelectedValue);
        theFamiliaDTO.TheCasaDTO = myCasaDTO;

        theFamiliaDTO.UsuarioIngreso = myUsuario.Rut;

        familia = familia.Where(x => x.NombreFamilia == theFamiliaDTO.NombreFamilia).ToList();
        if (familia.Any())
        {
            foreach (var item in familia)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Familia Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Familia ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.FamiliaBLL.Insert(theFamiliaDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            this.txtRut.Text = string.Empty;
            this.txtApellidoPaterno.Text = string.Empty;
            this.txtApellidoMaterno.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtCelular.Text = string.Empty;
            this.ddlCasa.ClearSelection();
            this.ddlOcupacion.ClearSelection();
            this.ddlParentesco.ClearSelection();

            string script = "alert('Familia Ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarFamilia();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        FamiliaDTO theFamiliaDTO = new FamiliaDTO();
        theFamiliaDTO.IdFamilia = decimal.Parse(this.hdnIdFamilia.Value);
        theFamiliaDTO.RutFamilia = YouCom.Service.Generales.Formato.LimpiarRut(this.txtRut.Text.ToUpper());
        theFamiliaDTO.NombreFamilia = this.txtNombre.Text.ToUpper();
        theFamiliaDTO.ApellidoPaternoFamilia = this.txtApellidoPaterno.Text.ToUpper();
        theFamiliaDTO.ApellidoMaternoFamilia = this.txtApellidoMaterno.Text.ToUpper();
        theFamiliaDTO.EmailFamilia = this.txtEmail.Text.ToUpper();
        theFamiliaDTO.TelefonoFamilia = this.txtTelefono.Text.ToUpper();
        theFamiliaDTO.CelularFamilia = this.txtCelular.Text;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theFamiliaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theFamiliaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propietario.ParentescoDTO myParentescoDTO = new YouCom.DTO.Propietario.ParentescoDTO();
        myParentescoDTO.IdParentesco = decimal.Parse(ddlParentesco.SelectedValue);
        theFamiliaDTO.TheParentescoDTO = myParentescoDTO;

        YouCom.DTO.Propietario.OcupacionDTO myOcupacionDTO = new YouCom.DTO.Propietario.OcupacionDTO();
        myOcupacionDTO.IdOcupacion = decimal.Parse(ddlOcupacion.SelectedValue);
        theFamiliaDTO.TheOcupacionDTO = myOcupacionDTO;

        YouCom.DTO.Propietario.CasaDTO myCasaDTO = new YouCom.DTO.Propietario.CasaDTO();
        myCasaDTO.IdCasa = decimal.Parse(ddlCasa.SelectedValue);
        theFamiliaDTO.TheCasaDTO = myCasaDTO;

        theFamiliaDTO.UsuarioModificacion = myUsuario.Rut;
        bool respuesta = YouCom.bll.FamiliaBLL.Update(theFamiliaDTO);

        if (respuesta)
        {
            cargarFamilia();
            this.txtNombre.Text = string.Empty;
            this.txtRut.Text = string.Empty;
            this.txtApellidoPaterno.Text = string.Empty;
            this.txtApellidoMaterno.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtCelular.Text = string.Empty;
            this.ddlCasa.ClearSelection();
            this.ddlOcupacion.ClearSelection();
            this.ddlParentesco.ClearSelection();

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Familia editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptFamiliaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdFamilia = new HiddenField();
            hdnIdFamilia = (HiddenField)e.Item.FindControl("hdnIdFamilia");

            FamiliaDTO theFamiliaDTO = new FamiliaDTO();
            theFamiliaDTO.IdFamilia = decimal.Parse(hdnIdFamilia.Value);
            theFamiliaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.FamiliaBLL.ActivaFamilia(theFamiliaDTO);
            if (respuesta)
            {
                cargarFamiliaInactivo();
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
    protected void rptFamilia_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdFamilia = new HiddenField();
            hdnIdFamilia = (HiddenField)e.Item.FindControl("hdnIdFamilia");

            YouCom.DTO.Propietario.FamiliaDTO theFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
            theFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamilia(decimal.Parse(hdnIdFamilia.Value));

            this.hdnIdFamilia.Value = theFamiliaDTO.IdFamilia.ToString();
            txtNombre.Text = theFamiliaDTO.NombreFamilia;
            txtApellidoPaterno.Text = theFamiliaDTO.ApellidoPaternoFamilia;
            txtApellidoMaterno.Text = theFamiliaDTO.ApellidoMaternoFamilia;
            txtEmail.Text = theFamiliaDTO.EmailFamilia;
            txtTelefono.Text = theFamiliaDTO.TelefonoFamilia;
            txtCelular.Text = theFamiliaDTO.CelularFamilia;
            this.txtRut.Text = YouCom.Service.Generales.Formato.FormatoRut(theFamiliaDTO.RutFamilia);

            ddlOcupacion.SelectedIndex = ddlOcupacion.Items.IndexOf(ddlOcupacion.Items.FindByValue(theFamiliaDTO.TheOcupacionDTO.IdOcupacion.ToString()));
            ddlParentesco.SelectedIndex = ddlParentesco.Items.IndexOf(ddlParentesco.Items.FindByValue(theFamiliaDTO.TheParentescoDTO.IdParentesco.ToString()));

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(theFamiliaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(theFamiliaDTO.TheComunidadDTO.IdComunidad.ToString()));

            ddlCasa.DataSource = YouCom.bll.CasaBLL.getListadoCasaByComunidad(decimal.Parse(ddlComunidad.SelectedValue));
            ddlCasa.DataTextField = "NombreCasa";
            ddlCasa.DataValueField = "IdCasa";
            ddlCasa.DataBind();
            ddlCasa.Items.Insert(0, new ListItem("Seleccione Casa", string.Empty));

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdFamilia = new HiddenField();
            hdnIdFamilia = (HiddenField)e.Item.FindControl("hdnIdFamilia");

            FamiliaDTO theFamiliaDTO = new FamiliaDTO();
            theFamiliaDTO.IdFamilia = decimal.Parse(hdnIdFamilia.Value);
            theFamiliaDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.FamiliaBLL.ValidaEliminacionFamilia(theFamiliaDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar una familia con informacion asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.FamiliaBLL.Delete(theFamiliaDTO);
                if (respuesta)
                {
                    cargarFamilia();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Integrante Familia Eliminada correctamente.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
                else
                {
                }
            }
        }
    }

    protected void ddlComunidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (!string.IsNullOrEmpty(ddlComunidad.SelectedValue))
        {
            ddlCasa.DataSource = YouCom.bll.CasaBLL.getListadoCasaByComunidad(decimal.Parse(ddlComunidad.SelectedValue));
            ddlCasa.DataTextField = "NombreCasa";
            ddlCasa.DataValueField = "IdCasa";
            ddlCasa.DataBind();
            ddlCasa.Items.Insert(0, new ListItem("Seleccione Casa", string.Empty));
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
