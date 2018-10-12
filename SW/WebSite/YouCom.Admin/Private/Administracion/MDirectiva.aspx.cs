using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MDirectiva : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarDirectiva();

            cargarCargo();
            cargarParametros();
        }
    }

    protected void cargarDirectiva()
    {
        if(myUsuario.TheCondominioSeleccionDTO.IdCondominio == 0)
        {
            Session["directiva"] = YouCom.bll.DirectivaBLL.listaDirectivaActivo();
            rptDirectiva.DataSource = YouCom.bll.DirectivaBLL.listaDirectivaActivo();
            rptDirectiva.DataBind();
        }
        else
        {
            Session["directiva"] = YouCom.bll.DirectivaBLL.getListadoDirectiva().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptDirectiva.DataSource = YouCom.bll.DirectivaBLL.listaDirectivaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptDirectiva.DataBind();
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
        pnlAdministracionDirectiva.Visible = false;
        cargarDirectivaInactivo();
    }
    protected void cargarDirectivaInactivo()
    {
        IList<DirectivaDTO> Directiva = new List<DirectivaDTO>();
        Directiva = YouCom.bll.DirectivaBLL.listaDirectivaInactivo();
        if (Directiva.Any())
        {
            rptDirectivaInactivo.DataSource = Directiva;
            rptDirectivaInactivo.DataBind();
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

        List<DirectivaDTO> directivas = new List<DirectivaDTO>();
        directivas = (Session["directiva"] as List<DirectivaDTO>);

        DirectivaDTO theDirectivaDTO = new DirectivaDTO();
        theDirectivaDTO.RutDirectiva = this.txtRut.Text.ToUpper();
        theDirectivaDTO.NombreDirectiva = this.txtNombre.Text.ToUpper();
        theDirectivaDTO.ApellidoPaternoDirectiva = this.txtApellidoPaterno.Text.ToUpper();
        theDirectivaDTO.ApellidoMaternoDirectiva = this.txtApellidoMaterno.Text.ToUpper();
        theDirectivaDTO.TelefonoDirectiva = this.txtTelefono.Text;
        theDirectivaDTO.EmailDirectiva = this.txtMail.Text;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theDirectivaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theDirectivaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.CargoDTO myCargoDTO = new YouCom.DTO.CargoDTO();
        myCargoDTO.IdCargo = decimal.Parse(ddlCargo.SelectedValue);
        theDirectivaDTO.TheCargoDTO = myCargoDTO;

        theDirectivaDTO.UsuarioIngreso = myUsuario.Rut;

        if (this.FileImagenDirectiva.HasFile)
        {
            if (System.IO.Path.GetExtension(FileImagenDirectiva.PostedFile.FileName) == ".swf")
                theDirectivaDTO.ImagenDirectiva = this.ProcessOtherFile(FileImagenDirectiva, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathDirectivaPub"));
            else
                theDirectivaDTO.ImagenDirectiva = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenDirectiva, YouCom.Service.Generales.General.GetPropiedad("UploadsPathDirectivaPub"), 198, 118, Page);
        }

        directivas = directivas.Where(x => x.NombreDirectiva == theDirectivaDTO.NombreDirectiva).ToList();
        if (directivas.Any())
        {
            foreach (var item in directivas)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Directiva existe pero fue eliminado para activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Directiva ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.DirectivaBLL.Insert(theDirectivaDTO);
        if (respuesta)
        {
            this.txtRut.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellidoPaterno.Text = string.Empty;
            this.txtApellidoMaterno.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtMail.Text = string.Empty;

            this.ddlCargo.ClearSelection();
            ddlCondominio.ClearSelection();

            string script = "alert('Directiva Ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarDirectiva();
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

        DirectivaDTO theDirectivaDTO = new DirectivaDTO();
        theDirectivaDTO.IdDirectiva = decimal.Parse(this.hdnDirectivaId.Value);
        theDirectivaDTO.RutDirectiva = this.txtRut.Text.ToUpper();
        theDirectivaDTO.NombreDirectiva = this.txtNombre.Text.ToUpper();
        theDirectivaDTO.ApellidoPaternoDirectiva = this.txtApellidoPaterno.Text.ToUpper();
        theDirectivaDTO.ApellidoMaternoDirectiva = this.txtApellidoMaterno.Text.ToUpper();
        theDirectivaDTO.TelefonoDirectiva = this.txtTelefono.Text;
        theDirectivaDTO.EmailDirectiva = this.txtMail.Text;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theDirectivaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theDirectivaDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.CargoDTO myCargoDTO = new YouCom.DTO.CargoDTO();
        myCargoDTO.IdCargo = decimal.Parse(ddlCargo.SelectedValue);
        theDirectivaDTO.TheCargoDTO = myCargoDTO;
        theDirectivaDTO.UsuarioModificacion = myUsuario.Rut;

        if (this.FileImagenDirectiva.HasFile)
        {
            theDirectivaDTO.ImagenDirectiva = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenDirectiva, YouCom.Service.Generales.General.GetPropiedad("UploadsPathDirectivaPub"), 198, 118, Page);
        }
        else
        {
            YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
            myDirectivaDTO = YouCom.bll.DirectivaBLL.detalleDirectiva(decimal.Parse(hdnDirectivaId.Value));

            theDirectivaDTO.ImagenDirectiva = myDirectivaDTO.ImagenDirectiva;
        }

        bool respuesta = YouCom.bll.DirectivaBLL.Update(theDirectivaDTO);

        if (respuesta)
        {
            cargarDirectiva();
            this.txtRut.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellidoPaterno.Text = string.Empty;
            this.txtApellidoMaterno.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtMail.Text = string.Empty;

            this.ddlCargo.ClearSelection();
            ddlCondominio.ClearSelection();

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Directiva editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptDirectivaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnDirectivaId = new HiddenField();
            hdnDirectivaId = (HiddenField)e.Item.FindControl("hdnDirectivaId");

            DirectivaDTO theDirectivaDTO = new DirectivaDTO();
            theDirectivaDTO.IdDirectiva = decimal.Parse(hdnDirectivaId.Value);
            theDirectivaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.DirectivaBLL.ActivaDirectiva(theDirectivaDTO);
            if (respuesta)
            {
                cargarDirectivaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Cargo Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptDirectiva_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnDirectivaId = new HiddenField();
            hdnDirectivaId = (HiddenField)e.Item.FindControl("hdnDirectivaId");

            YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
            myDirectivaDTO = YouCom.bll.DirectivaBLL.detalleDirectiva(decimal.Parse(hdnDirectivaId.Value));

            this.hdnDirectivaId.Value = myDirectivaDTO.IdDirectiva.ToString();
            this.txtRut.Text = YouCom.Service.Generales.Formato.FormatoRut(myDirectivaDTO.RutDirectiva);
            this.txtNombre.Text = myDirectivaDTO.NombreDirectiva;
            this.txtApellidoPaterno.Text = myDirectivaDTO.ApellidoPaternoDirectiva;
            this.txtApellidoMaterno.Text = myDirectivaDTO.ApellidoMaternoDirectiva;
            this.txtTelefono.Text = myDirectivaDTO.TelefonoDirectiva;
            this.txtMail.Text = myDirectivaDTO.EmailDirectiva;

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myDirectivaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myDirectivaDTO.TheComunidadDTO.IdComunidad.ToString()));

            ddlCargo.SelectedIndex = ddlCargo.Items.IndexOf(ddlCargo.Items.FindByValue(myDirectivaDTO.TheCargoDTO.IdCargo.ToString()));

            if (!string.IsNullOrEmpty(myDirectivaDTO.ImagenDirectiva))
            {
                this.lnkImagen.Visible = true;
                this.chkImagen.Visible = true;
                this.lnkImagen.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathDirectivaPub") + myDirectivaDTO.ImagenDirectiva;
            }

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnDirectivaId = new HiddenField();
            hdnDirectivaId = (HiddenField)e.Item.FindControl("hdnDirectivaId");

            DirectivaDTO theDirectivaDTO = new DirectivaDTO();
            theDirectivaDTO.IdDirectiva = decimal.Parse(hdnDirectivaId.Value);
            theDirectivaDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.DirectivaBLL.ValidaEliminacionDirectiva(theDirectivaDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar una directiva con informacion asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.DirectivaBLL.Delete(theDirectivaDTO);
                if (respuesta)
                {
                    cargarDirectiva();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Directiva eliminada correctamente.');";
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
