using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Servicio;

public partial class Admin_Mantenedores_MResponsable : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarResponsable();
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

    protected void cargarResponsable()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["responsable"] = YouCom.bll.ResponsableBLL.getListadoResponsable();
            rptResponsable.DataSource = YouCom.bll.ResponsableBLL.listaResponsableActivo();
            rptResponsable.DataBind();
        }
        else
        {
            Session["responsable"] = YouCom.bll.ResponsableBLL.getListadoResponsable().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptResponsable.DataSource = YouCom.bll.ResponsableBLL.listaResponsableActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptResponsable.DataBind();
        }
    }

    protected void cargarCargo()
    {
        ddlCargo.DataSource = YouCom.bll.CargoBLL.listaCargoActivo();
        ddlCargo.DataTextField = "NombreCargo";
        ddlCargo.DataValueField = "IdCargo";
        ddlCargo.DataBind();
        ddlCargo.Items.Insert(0, new ListItem("Seleccione Cargo", string.Empty));
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionResponsable.Visible = false;
        cargarResponsableInactivo();
    }
    protected void cargarResponsableInactivo()
    {
        IList<ResponsableDTO> responsable = new List<ResponsableDTO>();
        responsable = YouCom.bll.ResponsableBLL.listaResponsableInactivo();
        if (responsable.Any())
        {
            rptResponsableInactivo.DataSource = responsable;
            rptResponsableInactivo.DataBind();
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

        List<ResponsableDTO> responsable = new List<ResponsableDTO>();
        responsable = (Session["responsable"] as List<ResponsableDTO>);

        ResponsableDTO theResponsableDTO = new ResponsableDTO();
        theResponsableDTO.NombreResponsable = this.txtNombreResponsable.Text.ToUpper();
        theResponsableDTO.ApellidoPaternoResponsable = this.txtApellidoPaternoResponsable.Text.ToUpper();
        theResponsableDTO.ApellidoMaternoResponsable = this.txtApellidoMaternoResponsable.Text.ToUpper();
        theResponsableDTO.RutResponsable = this.txtRutResponsable.Text.ToUpper();
        theResponsableDTO.TelefonoResponsable = this.txtTelefonoResponsable.Text;
        theResponsableDTO.CelularResponsable = this.txtCelularResponsable.Text;
        theResponsableDTO.EmailResponsable = this.txtEmailResponsable.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theResponsableDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theResponsableDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.CargoDTO myCargoDTO = new YouCom.DTO.CargoDTO();
        myCargoDTO.IdCargo = decimal.Parse(ddlCargo.SelectedValue);
        theResponsableDTO.TheCargoDTO = myCargoDTO;

        theResponsableDTO.UsuarioIngreso = myUsuario.Rut;

        if (this.FileImagenResponsable.HasFile)
        {
            if (System.IO.Path.GetExtension(FileImagenResponsable.PostedFile.FileName) == ".swf")
                theResponsableDTO.FotoResponsable = this.ProcessOtherFile(FileImagenResponsable, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathResponsablePub"));
            else
                theResponsableDTO.FotoResponsable = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenResponsable, YouCom.Service.Generales.General.GetPropiedad("UploadsPathResponsablePub"), 198, 118, Page);
        }

        responsable = responsable.Where(x => x.NombreResponsable == theResponsableDTO.NombreResponsable).ToList();
        if (responsable.Any())
        {
            foreach (var item in responsable)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Empresa Servicio existe pero fue eliminado para activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Empresa Servicio ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.ResponsableBLL.Insert(theResponsableDTO);
        if (respuesta)
        {
            this.txtRutResponsable.Text = string.Empty;
            this.txtNombreResponsable.Text = string.Empty;
            this.txtApellidoPaternoResponsable.Text = string.Empty;
            this.txtApellidoMaternoResponsable.Text = string.Empty;
            this.txtTelefonoResponsable.Text = string.Empty;
            this.txtCelularResponsable.Text = string.Empty;
            this.txtEmailResponsable.Text = string.Empty;
            
            string script = "alert('Responsable ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarResponsable();
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

        ResponsableDTO theResponsableDTO = new ResponsableDTO();
        theResponsableDTO.IdResponsable = decimal.Parse(this.hdnIdResponsable.Value);
        theResponsableDTO.NombreResponsable = this.txtNombreResponsable.Text.ToUpper();
        theResponsableDTO.ApellidoPaternoResponsable = this.txtApellidoPaternoResponsable.Text.ToUpper();
        theResponsableDTO.ApellidoMaternoResponsable = this.txtApellidoMaternoResponsable.Text.ToUpper();
        theResponsableDTO.RutResponsable = this.txtRutResponsable.Text.ToUpper();
        theResponsableDTO.TelefonoResponsable = this.txtTelefonoResponsable.Text;
        theResponsableDTO.CelularResponsable = this.txtCelularResponsable.Text;
        theResponsableDTO.EmailResponsable = this.txtEmailResponsable.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theResponsableDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theResponsableDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.CargoDTO myCargoDTO = new YouCom.DTO.CargoDTO();
        myCargoDTO.IdCargo = decimal.Parse(ddlCargo.SelectedValue);
        theResponsableDTO.TheCargoDTO = myCargoDTO;

        theResponsableDTO.UsuarioModificacion = myUsuario.Rut;

        if (this.FileImagenResponsable.HasFile)
        {
            theResponsableDTO.FotoResponsable = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenResponsable, YouCom.Service.Generales.General.GetPropiedad("UploadsPathResponsablePub"), 198, 118, Page);
        }
        else
        {
            ResponsableDTO myResponsableDTO = new ResponsableDTO();
            myResponsableDTO = YouCom.bll.ResponsableBLL.detalleResponsable(decimal.Parse(hdnIdResponsable.Value));

            theResponsableDTO.FotoResponsable = myResponsableDTO.FotoResponsable;
        }


        bool respuesta = YouCom.bll.ResponsableBLL.Update(theResponsableDTO);

        if (respuesta)
        {
            cargarResponsable();
            this.txtRutResponsable.Text = string.Empty;
            this.txtNombreResponsable.Text = string.Empty;
            this.txtApellidoPaternoResponsable.Text = string.Empty;
            this.txtApellidoMaternoResponsable.Text = string.Empty;
            this.txtTelefonoResponsable.Text = string.Empty;
            this.txtCelularResponsable.Text = string.Empty;
            this.txtEmailResponsable.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Responsable editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptResponsableInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdResponsable = new HiddenField();
            hdnIdResponsable = (HiddenField)e.Item.FindControl("hdnIdResponsable");

            ResponsableDTO theResponsableDTO = new ResponsableDTO();
            theResponsableDTO.IdResponsable = decimal.Parse(hdnIdResponsable.Value);
            theResponsableDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.ResponsableBLL.ActivaResponsable(theResponsableDTO);
            if (respuesta)
            {
                cargarResponsableInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Responsable Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptResponsable_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdResponsable = new HiddenField();
            hdnIdResponsable = (HiddenField)e.Item.FindControl("hdnIdResponsable");

            ResponsableDTO myResponsableDTO = new ResponsableDTO();
            myResponsableDTO = YouCom.bll.ResponsableBLL.detalleResponsable(decimal.Parse(hdnIdResponsable.Value));

            this.hdnIdResponsable.Value = myResponsableDTO.IdResponsable.ToString();
            this.txtNombreResponsable.Text = myResponsableDTO.NombreResponsable;
            this.txtApellidoPaternoResponsable.Text = myResponsableDTO.ApellidoPaternoResponsable;
            this.txtApellidoMaternoResponsable.Text = myResponsableDTO.ApellidoMaternoResponsable;
            this.txtRutResponsable.Text = myResponsableDTO.RutResponsable;
            this.txtTelefonoResponsable.Text = myResponsableDTO.TelefonoResponsable;
            this.txtCelularResponsable.Text = myResponsableDTO.CelularResponsable;
            this.txtEmailResponsable.Text = myResponsableDTO.EmailResponsable;

            ddlCargo.SelectedIndex = ddlCargo.Items.IndexOf(ddlCargo.Items.FindByValue(myResponsableDTO.TheCargoDTO.IdCargo.ToString()));
            
            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myResponsableDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myResponsableDTO.TheComunidadDTO.IdComunidad.ToString()));

            if (!string.IsNullOrEmpty(myResponsableDTO.FotoResponsable))
            {
                this.lnkImagen.Visible = true;
                this.chkImagen.Visible = true;
                this.lnkImagen.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathResponsablePub") + myResponsableDTO.FotoResponsable;
            }

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdResponsable = new HiddenField();
            hdnIdResponsable = (HiddenField)e.Item.FindControl("hdnIdResponsable");

            ResponsableDTO theResponsableDTO = new ResponsableDTO();
            theResponsableDTO.IdResponsable = decimal.Parse(hdnIdResponsable.Value);
            theResponsableDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.ResponsableBLL.ValidaEliminacionResponsable(theResponsableDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un Responsable con informacion asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.ResponsableBLL.Delete(theResponsableDTO);
                if (respuesta)
                {
                    cargarResponsable();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Responsable Eliminada correctamente.');";
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
