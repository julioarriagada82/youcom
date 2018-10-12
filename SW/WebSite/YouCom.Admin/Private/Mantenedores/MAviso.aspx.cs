using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Avisos;

public partial class Admin_Mantenedores_MAviso : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarAviso();
            cargarCategoria();
            cargarTipoAviso();
            cargarEstadoAviso();
        }
    }

    protected void cargarAviso()
    {
        Session["aviso"] = YouCom.bll.Avisos.AvisoBLL.listaAvisosActivo();
        rptAviso.DataSource = YouCom.bll.Avisos.AvisoBLL.listaAvisosActivo();
        rptAviso.DataBind();
    }

    protected void cargarTipoAviso()
    {
        ddlTipoAviso.DataSource = YouCom.bll.Avisos.TipoAvisoBLL.listaTipoAvisoActivo();
        ddlTipoAviso.DataTextField = "NombreTipoAviso";
        ddlTipoAviso.DataValueField = "IdTipoAviso";
        ddlTipoAviso.DataBind();
        ddlTipoAviso.Items.Insert(0, new ListItem("Seleccione Tipo Aviso", string.Empty));
    }

    protected void cargarEstadoAviso()
    {
        ddlEstado.DataSource = YouCom.bll.Avisos.AvisoEstadoBLL.listaAvisoEstadoActivo();
        ddlEstado.DataTextField = "NombreAvisoEstado";
        ddlEstado.DataValueField = "IdAvisoEstado";
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("Seleccione Estado", string.Empty));
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
        pnlAdministracionAviso.Visible = false;
        cargarAvisosInactivo();
    }
    protected void cargarAvisosInactivo()
    {
        IList<AvisoDTO> Avisos = new List<AvisoDTO>();
        Avisos = YouCom.bll.Avisos.AvisoBLL.listaAvisosInactivo();
        if (Avisos.Any())
        {
            rptAvisoInactivo.DataSource = Avisos;
            rptAvisoInactivo.DataBind();
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

        List<AvisoDTO> Avisoss = new List<AvisoDTO>();
        Avisoss = (Session["Avisos"] as List<AvisoDTO>);

        AvisoDTO theAvisosDTO = new AvisoDTO();
        theAvisosDTO.TituloAviso = this.txtAvisoTitulo.Text.ToUpper();
        theAvisosDTO.DescripcionAviso = this.txtAvisoDescripcion.Text.ToUpper();
        theAvisosDTO.PrecioAviso = decimal.Parse(this.txtAvisoPrecio.Text);
        
        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theAvisosDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theAvisosDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theAvisosDTO.TheCategoriaDTO = myCategoriaDTO;

        YouCom.DTO.Avisos.TipoAvisoDTO myTipoAvisoDTO = new YouCom.DTO.Avisos.TipoAvisoDTO();
        myTipoAvisoDTO.IdTipoAviso = decimal.Parse(ddlTipoAviso.SelectedValue);
        theAvisosDTO.TheTipoAvisoDTO = myTipoAvisoDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO.IdFamilia = decimal.Parse(ddlFamilia.SelectedValue);
        theAvisosDTO.TheFamiliaDTO = myFamiliaDTO;

        YouCom.DTO.MonedaDTO myMonedaDTO = new YouCom.DTO.MonedaDTO();
        myMonedaDTO.IdMoneda = 1;
        theAvisosDTO.TheMonedaDTO = myMonedaDTO;

        theAvisosDTO.UsuarioIngreso = myUsuario.Rut;

        if (this.FileImagenAviso.HasFile)
        {
            if (System.IO.Path.GetExtension(FileImagenAviso.PostedFile.FileName) == ".swf")
                theAvisosDTO.ImagenAviso = this.ProcessOtherFile(FileImagenAviso, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathAvisosPub"));
            else
                theAvisosDTO.ImagenAviso = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenAviso, YouCom.Service.Generales.General.GetPropiedad("UploadsPathAvisosPub"), 198, 118, Page);
        }

        bool respuesta = YouCom.bll.Avisos.AvisoBLL.Insert(theAvisosDTO);
        if (respuesta)
        {
            this.txtAvisoDescripcion.Text = string.Empty;
            this.txtAvisoPrecio.Text = string.Empty;
            this.txtAvisoTitulo.Text = string.Empty;
            
            string script = "alert('Aviso ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarAviso();
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

        AvisoDTO theAvisosDTO = new AvisoDTO();
        theAvisosDTO.IdAviso = decimal.Parse(this.hdnIdAviso.Value);
        theAvisosDTO.TituloAviso = this.txtAvisoTitulo.Text.ToUpper();
        theAvisosDTO.DescripcionAviso = this.txtAvisoDescripcion.Text.ToUpper();
        theAvisosDTO.PrecioAviso = decimal.Parse(this.txtAvisoPrecio.Text);
        
        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theAvisosDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theAvisosDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
        myCategoriaDTO.IdCategoria = decimal.Parse(ddlCategoria.SelectedValue);
        theAvisosDTO.TheCategoriaDTO = myCategoriaDTO;

        YouCom.DTO.Avisos.TipoAvisoDTO myTipoAvisoDTO = new YouCom.DTO.Avisos.TipoAvisoDTO();
        myTipoAvisoDTO.IdTipoAviso = decimal.Parse(ddlTipoAviso.SelectedValue);
        theAvisosDTO.TheTipoAvisoDTO = myTipoAvisoDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        myFamiliaDTO.IdFamilia = decimal.Parse(ddlFamilia.SelectedValue);
        theAvisosDTO.TheFamiliaDTO = myFamiliaDTO;

        YouCom.DTO.MonedaDTO myMonedaDTO = new YouCom.DTO.MonedaDTO();
        myMonedaDTO.IdMoneda = 1;
        theAvisosDTO.TheMonedaDTO = myMonedaDTO;

        YouCom.DTO.Avisos.AvisoEstadoDTO myAvisosEstadoDTO = new YouCom.DTO.Avisos.AvisoEstadoDTO();
        myAvisosEstadoDTO.IdAvisoEstado = decimal.Parse(ddlEstado.SelectedValue);
        theAvisosDTO.TheAvisosEstadoDTO = myAvisosEstadoDTO;

        if(ddlEstado.SelectedValue == "3")
        {
            theAvisosDTO.FechaPublicacion = DateTime.Now;
            theAvisosDTO.FechaTermino = DateTime.Now.AddMonths(1);
        }

        theAvisosDTO.MotivoAvisoEstado = this.txtMotivoEstado.Text;

        theAvisosDTO.UsuarioModificacion = myUsuario.Rut;

        bool respuesta = YouCom.bll.Avisos.AvisoBLL.Update(theAvisosDTO);

        if (respuesta)
        {
            cargarAviso();
            this.txtAvisoDescripcion.Text = string.Empty;
            this.txtAvisoPrecio.Text = string.Empty;
            this.txtAvisoTitulo.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Aviso editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptAvisoInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdAvisos = new HiddenField();
            hdnIdAvisos = (HiddenField)e.Item.FindControl("hdnIdAvisos");

            AvisoDTO theAvisosDTO = new AvisoDTO();
            theAvisosDTO.IdAviso = decimal.Parse(hdnIdAvisos.Value);
            theAvisosDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.Avisos.AvisoBLL.ActivaAvisos(theAvisosDTO);
            if (respuesta)
            {
                cargarAvisosInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Avisos Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptAviso_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasaFamilia1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");
        DropDownList ddlFamilia = (DropDownList)wucCondominio.FindControl("ddlFamilia");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdAvisos = new HiddenField();
            hdnIdAvisos = (HiddenField)e.Item.FindControl("hdnIdAviso");

            YouCom.DTO.Avisos.AvisoDTO myAvisosDTO = new YouCom.DTO.Avisos.AvisoDTO();
            myAvisosDTO = YouCom.bll.Avisos.AvisoBLL.detalleAviso(decimal.Parse(hdnIdAvisos.Value));

            this.hdnIdAviso.Value = myAvisosDTO.IdAviso.ToString();
            this.txtAvisoDescripcion.Text = myAvisosDTO.DescripcionAviso;
            this.txtAvisoPrecio.Text = myAvisosDTO.PrecioAviso.ToString().Replace(".0000","");
            this.txtAvisoTitulo.Text = myAvisosDTO.TituloAviso;
            
            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myAvisosDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myAvisosDTO.TheComunidadDTO.IdComunidad.ToString()));

            YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

            myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamilia(myAvisosDTO.TheFamiliaDTO.IdFamilia);

            ddlCasa.DataSource = YouCom.bll.CasaBLL.getListadoCasaByComunidad(decimal.Parse(ddlComunidad.SelectedValue));
            ddlCasa.DataTextField = "NombreCasa";
            ddlCasa.DataValueField = "IdCasa";
            ddlCasa.DataBind();
            ddlCasa.Items.Insert(0, new ListItem("Seleccione Casa", string.Empty));

            ddlCasa.SelectedIndex = ddlCasa.Items.IndexOf(ddlCasa.Items.FindByValue(myFamiliaDTO.TheCasaDTO.IdCasa.ToString()));

            ddlFamilia.DataSource = YouCom.bll.FamiliaBLL.getListadoFamiliaByCasa(decimal.Parse(ddlCasa.SelectedValue));
            ddlFamilia.DataTextField = "NombreCompleto";
            ddlFamilia.DataValueField = "IdFamilia";
            ddlFamilia.DataBind();
            ddlFamilia.Items.Insert(0, new ListItem("Seleccione Familia", string.Empty));

            ddlFamilia.SelectedIndex = ddlFamilia.Items.IndexOf(ddlFamilia.Items.FindByValue(myAvisosDTO.TheFamiliaDTO.IdFamilia.ToString()));

            ddlEstado.SelectedIndex = ddlEstado.Items.IndexOf(ddlEstado.Items.FindByValue(myAvisosDTO.TheAvisosEstadoDTO.IdAvisoEstado.ToString()));

            ddlCategoria.SelectedIndex = ddlCategoria.Items.IndexOf(ddlCategoria.Items.FindByValue(myAvisosDTO.TheCategoriaDTO.IdCategoria.ToString()));

            ddlTipoAviso.SelectedIndex = ddlTipoAviso.Items.IndexOf(ddlTipoAviso.Items.FindByValue(myAvisosDTO.TheTipoAvisoDTO.IdTipoAviso.ToString()));

            ddlCategoria.SelectedIndex = ddlCategoria.Items.IndexOf(ddlCategoria.Items.FindByValue(myAvisosDTO.TheCategoriaDTO.IdCategoria.ToString()));

            if (!string.IsNullOrEmpty(myAvisosDTO.ImagenAviso))
            {
                this.lnkImagen.Visible = true;
                this.chkImagen.Visible = true;
                this.lnkImagen.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathAvisosPub") + myAvisosDTO.ImagenAviso;
            }

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdAvisos = new HiddenField();
            hdnIdAvisos = (HiddenField)e.Item.FindControl("hdnIdAvisos");

            AvisoDTO theAvisosDTO = new AvisoDTO();
            theAvisosDTO.IdAviso = decimal.Parse(hdnIdAvisos.Value);
            theAvisosDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.Avisos.AvisoBLL.ValidaEliminacionAvisos(theAvisosDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un Avisos con informacion asociada.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.Avisos.AvisoBLL.Delete(theAvisosDTO);
                if (respuesta)
                {
                    cargarAviso();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Avisos Eliminada correctamente.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
                else
                {
                }
            }
        }
    }

    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlEstado.SelectedValue))
        {
            pnlEstado.Visible = true;
        }
        else
        {
            pnlEstado.Visible = false;

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
