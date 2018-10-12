using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MArchivo : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarArchivo();
            cargarCategoria();
        }
    }

    protected void cargarArchivo()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["archivo"] = YouCom.bll.ArchivoBLL.listaArchivoActivo();
            rptArchivo.DataSource = YouCom.bll.ArchivoBLL.listaArchivoActivo();
            rptArchivo.DataBind();
        }
        else
        {
            Session["archivo"] = YouCom.bll.ArchivoBLL.listaArchivoActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptArchivo.DataSource = YouCom.bll.ArchivoBLL.listaArchivoActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptArchivo.DataBind();
        }
    }

    protected void cargarCategoria()
    {
        IList<YouCom.DTO.CategoriaDTO> myCategoria = new List<YouCom.DTO.CategoriaDTO>();

        myCategoria = YouCom.bll.CategoriaBLL.listaCategoriaActivo();

        myCategoria = myCategoria.Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 7).ToList();

        ddlCategoria.DataSource = myCategoria;
        ddlCategoria.DataTextField = "NombreCategoria";
        ddlCategoria.DataValueField = "IdCategoria";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, new ListItem("Seleccione Categoria", string.Empty));
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionArchivo.Visible = false;
        cargarArchivoInactivo();
    }
    protected void cargarArchivoInactivo()
    {
        IList<ArchivoDTO> Archivo = new List<ArchivoDTO>();
        Archivo = YouCom.bll.ArchivoBLL.listaArchivoInactivo();
        if (Archivo.Any())
        {
            rptArchivoInactivo.DataSource = Archivo;
            rptArchivoInactivo.DataBind();
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

        List<ArchivoDTO> archivos = new List<ArchivoDTO>();
        archivos = (Session["archivo"] as List<ArchivoDTO>);

        ArchivoDTO theArchivoDTO = new ArchivoDTO();
        theArchivoDTO.ArchivoTitulo = this.txtArchivoTitulo.Text.ToUpper();
        theArchivoDTO.ArchivoDescripcion = this.txtArchivoDescripcion.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theArchivoDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theArchivoDTO.TheComunidadDTO = myComunidadDTO;

        CategoriaDTO myCategoria = new CategoriaDTO();

        myCategoria.IdCategoria = decimal.Parse(this.ddlCategoria.SelectedValue);
        theArchivoDTO.TheCategoriaDTO = myCategoria;

        theArchivoDTO.UsuarioIngreso = myUsuario.Rut;

        if (this.FileArchivo.HasFile)
        {
            theArchivoDTO.ArchivoNombre = this.ProcessOtherFile(FileArchivo, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathArchivoPub"));
        }

        archivos = archivos.Where(x => x.ArchivoTitulo == theArchivoDTO.ArchivoTitulo).ToList();
        if (archivos.Any())
        {
            foreach (var item in archivos)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Archivo existe pero fue eliminado para activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Archivo ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.ArchivoBLL.Insert(theArchivoDTO);
        if (respuesta)
        {
            this.txtArchivoTitulo.Text = string.Empty;
            this.txtArchivoDescripcion.Text = string.Empty;
            string script = "alert('Archivo ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarArchivo();
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

        ArchivoDTO theArchivoDTO = new ArchivoDTO();
        theArchivoDTO.ArchivoId = decimal.Parse(this.hdnArchivoId.Value);
        theArchivoDTO.ArchivoTitulo = this.txtArchivoTitulo.Text.ToUpper();
        theArchivoDTO.ArchivoDescripcion = this.txtArchivoDescripcion.Text.ToUpper();

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theArchivoDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theArchivoDTO.TheComunidadDTO = myComunidadDTO;
        
        CategoriaDTO myCategoria = new CategoriaDTO();

        myCategoria.IdCategoria = decimal.Parse(this.ddlCategoria.SelectedValue);
        theArchivoDTO.TheCategoriaDTO = myCategoria;

        theArchivoDTO.UsuarioModificacion = myUsuario.Rut;

        if (this.FileArchivo.HasFile)
        {
            theArchivoDTO.ArchivoNombre = this.ProcessOtherFile(FileArchivo, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathBann"));
        }
        else
        {
            YouCom.DTO.ArchivoDTO myArchivoDTO = new YouCom.DTO.ArchivoDTO();
            myArchivoDTO = YouCom.bll.ArchivoBLL.detalleArchivo(decimal.Parse(hdnArchivoId.Value));

            theArchivoDTO.ArchivoNombre = myArchivoDTO.ArchivoNombre;
        }

        bool respuesta = YouCom.bll.ArchivoBLL.Update(theArchivoDTO);

        if (respuesta)
        {
            cargarArchivo();
            this.txtArchivoTitulo.Text = string.Empty;
            this.txtArchivoDescripcion.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Archivo editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptArchivoInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnArchivoId = new HiddenField();
            hdnArchivoId = (HiddenField)e.Item.FindControl("hdnArchivoId");

            ArchivoDTO theArchivoDTO = new ArchivoDTO();
            theArchivoDTO.ArchivoId = decimal.Parse(hdnArchivoId.Value);
            theArchivoDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.ArchivoBLL.ActivaArchivo(theArchivoDTO);
            if (respuesta)
            {
                cargarArchivoInactivo();
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
    protected void rptArchivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnArchivoId = new HiddenField();
            hdnArchivoId = (HiddenField)e.Item.FindControl("hdnArchivoId");

            YouCom.DTO.ArchivoDTO theArchivoDTO = new YouCom.DTO.ArchivoDTO();
            theArchivoDTO = YouCom.bll.ArchivoBLL.detalleArchivo(decimal.Parse(hdnArchivoId.Value));

            this.hdnArchivoId.Value = theArchivoDTO.ArchivoId.ToString();
            this.txtArchivoTitulo.Text = theArchivoDTO.ArchivoTitulo;
            this.txtArchivoDescripcion.Text = theArchivoDTO.ArchivoDescripcion;

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(theArchivoDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(theArchivoDTO.TheComunidadDTO.IdComunidad.ToString()));

            ddlCategoria.SelectedIndex = ddlCategoria.Items.IndexOf(ddlCategoria.Items.FindByValue(theArchivoDTO.TheCategoriaDTO.IdCategoria.ToString()));

            if (!string.IsNullOrEmpty(theArchivoDTO.ArchivoNombre))
            {
                this.lnkImagen.Visible = true;
                this.chkImagen.Visible = true;
                this.lnkImagen.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathArchivoPub") + theArchivoDTO.ArchivoNombre;
            }

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnArchivoId = new HiddenField();
            hdnArchivoId = (HiddenField)e.Item.FindControl("hdnArchivoId");

            ArchivoDTO theArchivoDTO = new ArchivoDTO();
            theArchivoDTO.ArchivoId = decimal.Parse(hdnArchivoId.Value);
            theArchivoDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.ArchivoBLL.ValidaEliminacionArchivo(theArchivoDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un archivo con informacion asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.ArchivoBLL.Delete(theArchivoDTO);
                if (respuesta)
                {
                    cargarArchivo();
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
