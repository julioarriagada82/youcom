using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MBanner : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarBanner();
        }
    }

    protected void cargarBanner()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["banner"] = YouCom.bll.BannerBLL.listaBannerActivo();
            rptBanner.DataSource = YouCom.bll.BannerBLL.listaBannerActivo();
            rptBanner.DataBind();
        }
        else
        {
            Session["banner"] = YouCom.bll.BannerBLL.listaBannerActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptBanner.DataSource = YouCom.bll.BannerBLL.listaBannerActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptBanner.DataBind();
        }
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionBanner.Visible = false;
        cargarBannerInactivo();
    }
    protected void cargarBannerInactivo()
    {
        IList<BannerDTO> banner = new List<BannerDTO>();
        banner = YouCom.bll.BannerBLL.listaBannerInactivo();
        if (banner.Any())
        {
            rptBannerInactivo.DataSource = banner;
            rptBannerInactivo.DataBind();
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

        if (ValidaDatos())
        {
            List<BannerDTO> banners = new List<BannerDTO>();
            banners = (Session["banner"] as List<BannerDTO>);

            BannerDTO theBannerDTO = new BannerDTO();
            theBannerDTO.BannerNombre = this.txtBannerNombre.Text.ToUpper();
            theBannerDTO.BannerDescripcion = this.txtBannerDescripcion.Text.ToUpper();

            YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
            myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
            theBannerDTO.TheCondominioDTO = myCondominioDTO;

            YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
            myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
            theBannerDTO.TheComunidadDTO = myComunidadDTO;

            theBannerDTO.BannerTipoDespliegue = this.DDLBannerLink.SelectedValue;
            theBannerDTO.UsuarioIngreso = myUsuario.Rut;

            if (this.FileImagenBanner.HasFile)
            {
                if (System.IO.Path.GetExtension(FileImagenBanner.PostedFile.FileName) == ".swf")
                    theBannerDTO.BannerImagen = this.ProcessOtherFile(FileImagenBanner, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathBannerPub"));
                else
                    theBannerDTO.BannerImagen = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenBanner, YouCom.Service.Generales.General.GetPropiedad("UploadsPathBannerPub"), 198, 118, Page);
            }

            banners = banners.Where(x => x.BannerNombre == theBannerDTO.BannerNombre).ToList();
            if (banners.Any())
            {
                foreach (var item in banners)
                {
                    if (item.Estado == "2")
                    {
                        string script = "alert('Banner existe pero fue eliminado para activarlo dirigase a Papelera.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                        return;
                    }
                    else
                    {
                        string script = "alert('Banner ya Existe .');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                        return;
                    }
                }
            }

            bool respuesta = YouCom.bll.BannerBLL.Insert(theBannerDTO);
            if (respuesta)
            {
                this.txtBannerNombre.Text = string.Empty;
                this.txtBannerDescripcion.Text = string.Empty;
                ddlCondominio.ClearSelection();
                this.DDLBannerLink.ClearSelection();

                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Banner Ingresado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);

                    cargarBanner();
                }
            }
            else
            {
            }
        }
    }
    private bool ValidaDatos()
    {
        try
        {
            if (this.FileImagenBanner.HasFile)
            {
                if (this.FileImagenBanner.PostedFile.FileName != null && FileImagenBanner.PostedFile.FileName != "" && FileImagenBanner.PostedFile.ContentLength > this.GetMaxUpload())
                {
                    CVImagen.IsValid = false;
                    CVImagen.Display = ValidatorDisplay.Dynamic;
                    CVImagen.ErrorMessage = "Estimado usuario, la imagen cargada no debe pesar más de " + this.GetMaxUploadMessage();
                    return false;
                }
            }
        }
        catch (NullReferenceException e)
        {
            throw new NullReferenceException(e.Message.ToString());
        }
        catch (Exception e)
        {
            throw new Exception(e.Message.ToString());
        }
        return true;
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        BannerDTO theBannerDTO = new BannerDTO();
        theBannerDTO.BannerId = decimal.Parse(this.hdnBannerId.Value);
        theBannerDTO.BannerNombre = this.txtBannerNombre.Text.ToUpper();
        theBannerDTO.BannerDescripcion = this.txtBannerDescripcion.Text.ToUpper();
        theBannerDTO.BannerTipoDespliegue = this.DDLBannerLink.SelectedValue;
        theBannerDTO.UsuarioModificacion = myUsuario.Rut;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theBannerDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theBannerDTO.TheComunidadDTO = myComunidadDTO;

        if (this.FileImagenBanner.HasFile)
        {
            if (System.IO.Path.GetExtension(FileImagenBanner.PostedFile.FileName) == ".swf")
                theBannerDTO.BannerImagen = this.ProcessOtherFile(FileImagenBanner, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathBannerPub"));
            else
                theBannerDTO.BannerImagen = YouCom.Service.Imagenes.Imagen.ProcessFileResize(FileImagenBanner, YouCom.Service.Generales.General.GetPropiedad("UploadsPathBannerPub"), 198, 118, Page);
        }

        bool respuesta = YouCom.bll.BannerBLL.Update(theBannerDTO);

        if (respuesta)
        {
            cargarBanner();
            this.txtBannerNombre.Text = string.Empty;
            this.txtBannerDescripcion.Text = string.Empty;
            ddlCondominio.ClearSelection();
            this.DDLBannerLink.ClearSelection();

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Banner editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptBannerInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnBannerId = new HiddenField();
            hdnBannerId = (HiddenField)e.Item.FindControl("hdnBannerId");

            BannerDTO theBannerDTO = new BannerDTO();
            theBannerDTO.BannerId = decimal.Parse(hdnBannerId.Value);
            theBannerDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.BannerBLL.ActivaBanner(theBannerDTO);
            if (respuesta)
            {
                cargarBannerInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Banner activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptBanner_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnBannerId = new HiddenField();
            hdnBannerId = (HiddenField)e.Item.FindControl("hdnBannerId");

            YouCom.DTO.BannerDTO theBannerDTO = new YouCom.DTO.BannerDTO();
            theBannerDTO = YouCom.bll.BannerBLL.detalleBanner(decimal.Parse(hdnBannerId.Value));

            this.hdnBannerId.Value = theBannerDTO.BannerId.ToString();
            this.txtBannerNombre.Text = theBannerDTO.BannerNombre;
            this.txtBannerDescripcion.Text = theBannerDTO.BannerDescripcion;

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(theBannerDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(theBannerDTO.TheComunidadDTO.IdComunidad.ToString()));

            DDLBannerLink.SelectedIndex = DDLBannerLink.Items.IndexOf(DDLBannerLink.Items.FindByValue(theBannerDTO.BannerTipoDespliegue));

            if (DDLBannerLink.SelectedValue.Equals("L"))
            {
                pnlDespliegueLink.Visible = true;

                this.TxtBannerURL.Text = theBannerDTO.BannerLink;
                this.RdbBannerTarget.SelectedIndex = RdbBannerTarget.Items.IndexOf(RdbBannerTarget.Items.FindByValue(theBannerDTO.BannerTarget));
            }
            else
            {
                pnlDespliegueLink.Visible = false;
            }

            if (!string.IsNullOrEmpty(theBannerDTO.BannerImagen))
            {
                this.lnkImagen.Visible = true;
                this.chkImagen.Visible = true;
                this.lnkImagen.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathBannerPub") + theBannerDTO.BannerImagen;
            }

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnBannerId = new HiddenField();
            hdnBannerId = (HiddenField)e.Item.FindControl("hdnBannerId");

            BannerDTO theBannerDTO = new BannerDTO();
            theBannerDTO.BannerId = decimal.Parse(hdnBannerId.Value);
            theBannerDTO.UsuarioModificacion = myUsuario.Rut;
                
            bool respuesta = YouCom.bll.BannerBLL.Delete(theBannerDTO);
            if (respuesta)
            {
                cargarBanner();
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

    protected void DDLBannerLink_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (this.DDLBannerLink.SelectedValue == "L")
            {
                this.pnlDespliegueLink.Visible = true;
            }
            else
            {
                this.pnlDespliegueLink.Visible = false;
            }
        }
        catch (Exception ex)
        {
            
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
