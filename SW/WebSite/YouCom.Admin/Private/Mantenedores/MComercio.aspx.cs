using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MComercio : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarComercio();
            cargarCategoria();
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

    protected void cargarComercio()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["comercio"] = YouCom.bll.ComercioBLL.listaComercioActivo();
            rptComercio.DataSource = YouCom.bll.ComercioBLL.listaComercioActivo();
            rptComercio.DataBind();
        }
        else
        {
            Session["comercio"] = YouCom.bll.ComercioBLL.getListadoComercio().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptComercio.DataSource = YouCom.bll.ComercioBLL.listaComercioActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptComercio.DataBind();
        }

    }

    protected void cargarCategoria()
    {
        IList<YouCom.DTO.CategoriaDTO> myCategoria = new List<YouCom.DTO.CategoriaDTO>();

        myCategoria = YouCom.bll.CategoriaBLL.listaCategoriaActivo();

        myCategoria = myCategoria.Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 8).ToList();

        ddlCategoria.DataSource = myCategoria;
        ddlCategoria.DataTextField = "NombreCategoria";
        ddlCategoria.DataValueField = "IdCategoria";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, new ListItem("Seleccione Categoria", string.Empty));
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionComercio.Visible = false;
        cargarComercioInactivo();
    }
    protected void cargarComercioInactivo()
    {
        IList<ComercioDTO> comercio = new List<ComercioDTO>();
        comercio = YouCom.bll.ComercioBLL.listaComercioInactivo();
        if (comercio.Any())
        {
            rptComercioInactivo.DataSource = comercio;
            rptComercioInactivo.DataBind();
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

        List<ComercioDTO> comercios = new List<ComercioDTO>();
        comercios = (Session["comercio"] as List<ComercioDTO>);

        ComercioDTO theComercioDTO = new ComercioDTO();
        theComercioDTO.NombreComercio = this.txtComercioNombre.Text.ToUpper();
        theComercioDTO.DireccionComercio = this.txtComercioDireccion.Text.ToUpper();
        theComercioDTO.TelefonoComercio = this.txtComercioTelefono.Text;
        theComercioDTO.UrlComercio = this.txtComercioURL.Text.ToUpper();
        theComercioDTO.EmailComercio = this.txtEmail.Text;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theComercioDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theComercioDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theComercioDTO.TheCategoriaDTO = myCategoriaDTO;

        theComercioDTO.UsuarioIngreso = myUsuario.Rut;

        if (this.FileImagenComercio.HasFile)
        {
            if (System.IO.Path.GetExtension(FileImagenComercio.PostedFile.FileName) == ".swf")
                theComercioDTO.LogoComercio = this.ProcessOtherFile(FileImagenComercio, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathComercioPub"));
            else
                theComercioDTO.LogoComercio = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenComercio, YouCom.Service.Generales.General.GetPropiedad("UploadsPathComercioPub"), 198, 118, Page);
        }

        comercios = comercios.Where(x => x.NombreComercio == theComercioDTO.NombreComercio).ToList();
        if (comercios.Any())
        {
            foreach (var item in comercios)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Comercio existe pero fue eliminado para activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Comercio ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.ComercioBLL.Insert(theComercioDTO);
        if (respuesta)
        {
            this.txtComercioNombre.Text = string.Empty;
            this.txtComercioDireccion.Text = string.Empty;
            this.txtComercioTelefono.Text = string.Empty;
            this.txtComercioURL.Text = string.Empty;

            string script = "alert('Comercio ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarComercio();
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

        ComercioDTO theComercioDTO = new ComercioDTO();
        theComercioDTO.IdComercio = decimal.Parse(this.hdnIdComercio.Value);
        theComercioDTO.NombreComercio = this.txtComercioNombre.Text.ToUpper();
        theComercioDTO.DireccionComercio = this.txtComercioDireccion.Text.ToUpper();
        theComercioDTO.TelefonoComercio = this.txtComercioTelefono.Text;
        theComercioDTO.UrlComercio = this.txtComercioURL.Text.ToUpper();
        theComercioDTO.EmailComercio = this.txtEmail.Text;
        
        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theComercioDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theComercioDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theComercioDTO.TheCategoriaDTO = myCategoriaDTO;

        theComercioDTO.UsuarioModificacion = myUsuario.Rut;

        if (this.FileImagenComercio.HasFile)
        {
            theComercioDTO.LogoComercio = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenComercio, YouCom.Service.Generales.General.GetPropiedad("UploadsPathComercioPub"), 198, 118, Page);
        }
        else
        {
            YouCom.DTO.ComercioDTO myComercioDTO = new YouCom.DTO.ComercioDTO();
            myComercioDTO = YouCom.bll.ComercioBLL.detalleComercio(decimal.Parse(hdnIdComercio.Value));

            theComercioDTO.LogoComercio = myComercioDTO.LogoComercio;
        }


        bool respuesta = YouCom.bll.ComercioBLL.Update(theComercioDTO);

        if (respuesta)
        {
            cargarComercio();
            this.txtComercioNombre.Text = string.Empty;
            this.txtComercioDireccion.Text = string.Empty;
            this.txtComercioTelefono.Text = string.Empty;
            this.txtComercioURL.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Comercio editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptComercioInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdComercio = new HiddenField();
            hdnIdComercio = (HiddenField)e.Item.FindControl("hdnIdComercio");

            ComercioDTO theComercioDTO = new ComercioDTO();
            theComercioDTO.IdComercio = decimal.Parse(hdnIdComercio.Value);
            theComercioDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.ComercioBLL.ActivaComercio(theComercioDTO);
            if (respuesta)
            {
                cargarComercioInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Comercio Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptComercio_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdComercio = new HiddenField();
            hdnIdComercio = (HiddenField)e.Item.FindControl("hdnIdComercio");

            YouCom.DTO.ComercioDTO myComercioDTO = new YouCom.DTO.ComercioDTO();
            myComercioDTO = YouCom.bll.ComercioBLL.detalleComercio(decimal.Parse(hdnIdComercio.Value));

            this.hdnIdComercio.Value = myComercioDTO.IdComercio.ToString();
            this.txtComercioNombre.Text = myComercioDTO.NombreComercio;
            this.txtComercioDireccion.Text = myComercioDTO.DireccionComercio;
            this.txtComercioTelefono.Text = myComercioDTO.TelefonoComercio;
            this.txtComercioURL.Text = myComercioDTO.UrlComercio;

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myComercioDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myComercioDTO.TheComunidadDTO.IdComunidad.ToString()));

            ddlCategoria.SelectedIndex = ddlCategoria.Items.IndexOf(ddlCategoria.Items.FindByValue(myComercioDTO.TheCategoriaDTO.IdCategoria.ToString()));

            if (!string.IsNullOrEmpty(myComercioDTO.LogoComercio))
            {
                this.lnkImagen.Visible = true;
                this.chkImagen.Visible = true;
                this.lnkImagen.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathComercioPub") + myComercioDTO.LogoComercio;
            }

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdComercio = new HiddenField();
            hdnIdComercio = (HiddenField)e.Item.FindControl("hdnIdComercio");

            ComercioDTO theComercioDTO = new ComercioDTO();
            theComercioDTO.IdComercio = decimal.Parse(hdnIdComercio.Value);
            theComercioDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.ComercioBLL.ValidaEliminacionComercio(theComercioDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un comercio con informacion asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.ComercioBLL.Delete(theComercioDTO);
                if (respuesta)
                {
                    cargarComercio();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Comercio Eliminada correctamente.');";
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
