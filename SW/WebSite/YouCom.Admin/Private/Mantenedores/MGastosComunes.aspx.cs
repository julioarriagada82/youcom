using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO;

public partial class Admin_Mantenedores_MGastosComunes : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarGastoComun();
            cargarEstado();
        }
    }

    protected void ddlEstado_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEstado.SelectedValue.Equals("1"))
        {
            pnlEstado.Visible = true;
        }
        else
        {
            pnlEstado.Visible = false;
        }
    }

    protected void cargarGastoComun()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["gastoComun"] = YouCom.bll.GastosComunes.GastoComunBLL.listaGastosComunesActivo();
            rptGastoComun.DataSource = YouCom.bll.GastosComunes.GastoComunBLL.listaGastosComunesActivo();
            rptGastoComun.DataBind();

        }
        else
        {
            Session["gastoComun"] = YouCom.bll.GastosComunes.GastoComunBLL.listaGastosComunesActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptGastoComun.DataSource = YouCom.bll.GastosComunes.GastoComunBLL.listaGastosComunesActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptGastoComun.DataBind();
        }

    }

    protected void cargarEstado()
    {
        ddlEstado.DataSource = YouCom.bll.GastosComunes.GastoComunEstadoBLL.listaGastoComunEstadoActivo();
        ddlEstado.DataTextField = "NombreGastoComunEstado";
        ddlEstado.DataValueField = "IdGastoComunEstado";
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("Seleccione Estado", string.Empty));
    }

    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionGastoComun.Visible = false;
        cargarGastoComunInactivo();
    }
    protected void cargarGastoComunInactivo()
    {
        IList<YouCom.DTO.GastosComunes.GastoComunDTO> gastoComun = new List<YouCom.DTO.GastosComunes.GastoComunDTO>();
        gastoComun = YouCom.bll.GastosComunes.GastoComunBLL.listaGastosComunesInactivo();
        if (gastoComun.Any())
        {
            rptGastoComunInactivo.DataSource = gastoComun;
            rptGastoComunInactivo.DataBind();
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
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasa1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");

        IList<YouCom.DTO.GastosComunes.GastoComunDTO> gastoComun = new List<YouCom.DTO.GastosComunes.GastoComunDTO>();
        gastoComun = (Session["gastoComun"] as List<YouCom.DTO.GastosComunes.GastoComunDTO>);

        YouCom.DTO.GastosComunes.GastoComunDTO theGastosComunesDTO = new YouCom.DTO.GastosComunes.GastoComunDTO();
        theGastosComunesDTO.DescripcionGasto = this.txtDescripcion.Text.ToUpper();
        theGastosComunesDTO.MontoGasto = decimal.Parse(this.txtMonto.Text);
        theGastosComunesDTO.FechaGasto = DateTime.ParseExact(this.FechaGasto.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theGastosComunesDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theGastosComunesDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propietario.CasaDTO myCasa = new YouCom.DTO.Propietario.CasaDTO();
        myCasa.IdCasa = decimal.Parse(ddlCasa.SelectedValue);
        theGastosComunesDTO.TheCasaDTO = myCasa;

        YouCom.DTO.GastosComunes.GastoComunEstadoDTO myGastoComunEstadoDTO = new YouCom.DTO.GastosComunes.GastoComunEstadoDTO();
        myGastoComunEstadoDTO.IdGastoComunEstado = decimal.Parse(this.ddlEstado.SelectedValue);
        theGastosComunesDTO.TheGastoComunEstadoDTO = myGastoComunEstadoDTO;

        theGastosComunesDTO.FechaPagoGasto = DateTime.MaxValue;
        theGastosComunesDTO.UsuarioIngreso = myUsuario.Rut;

        if (this.FileArchivo.HasFile)
        {
            theGastosComunesDTO.ArchivoGasto = this.ProcessOtherFile(FileArchivo, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathGastoComunPub"));
        }

        gastoComun = gastoComun.Where(x => x.DescripcionGasto == theGastosComunesDTO.DescripcionGasto).ToList();
        if (gastoComun.Any())
        {
            foreach (var item in gastoComun)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Gasto Común existe pero fue eliminado para activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Gasto Común ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }
        }

        bool respuesta = YouCom.bll.GastosComunes.GastoComunBLL.Insert(theGastosComunesDTO);
        if (respuesta)
        {
            this.txtComentario.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtMonto.Text = string.Empty;
            this.ddlEstado.ClearSelection();
            ddlCondominio.ClearSelection();
            ddlCasa.ClearSelection();

            string script = "alert('Gasto Común ingresado correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarGastoComun();
        }
        else
        {
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasa1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");

        btnEditar.Visible = false;
        btnGrabar.Visible = true;

        YouCom.DTO.GastosComunes.GastoComunDTO theGastosComunesDTO = new YouCom.DTO.GastosComunes.GastoComunDTO();
        theGastosComunesDTO.IdGastoComun = decimal.Parse(this.hdnIdGastoComun.Value);
        theGastosComunesDTO.DescripcionGasto = this.txtDescripcion.Text.ToUpper();
        theGastosComunesDTO.MontoGasto = decimal.Parse(this.txtMonto.Text);
        theGastosComunesDTO.FechaGasto = DateTime.ParseExact(this.FechaGasto.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theGastosComunesDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theGastosComunesDTO.TheComunidadDTO = myComunidadDTO;

        YouCom.DTO.Propietario.CasaDTO myCasa = new YouCom.DTO.Propietario.CasaDTO();
        myCasa.IdCasa = decimal.Parse(ddlCasa.SelectedValue);
        theGastosComunesDTO.TheCasaDTO = myCasa;

        YouCom.DTO.GastosComunes.GastoComunEstadoDTO myGastoComunEstadoDTO = new YouCom.DTO.GastosComunes.GastoComunEstadoDTO();
        myGastoComunEstadoDTO.IdGastoComunEstado = decimal.Parse(this.ddlEstado.SelectedValue);
        theGastosComunesDTO.TheGastoComunEstadoDTO = myGastoComunEstadoDTO;

        theGastosComunesDTO.FechaPagoGasto = DateTime.ParseExact(this.FechaPago.Text + " " + DateTime.Now.ToString("HH:mm"), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        theGastosComunesDTO.ComentarioGasto = this.txtComentario.Text;
        theGastosComunesDTO.UsuarioModificacion = myUsuario.Rut;

        if (this.FileArchivo.HasFile)
        {
            theGastosComunesDTO.ArchivoGasto = this.ProcessOtherFile(FileArchivo, null, YouCom.Service.Generales.General.GetPropiedad("UploadsPathGastoComunPub"));
        }
        else
        {
            YouCom.DTO.GastosComunes.GastoComunDTO myGastosComunesDTO = new YouCom.DTO.GastosComunes.GastoComunDTO();
            myGastosComunesDTO = YouCom.bll.GastosComunes.GastoComunBLL.detalleGastosComunes(decimal.Parse(hdnIdGastoComun.Value));

            theGastosComunesDTO.ArchivoGasto = myGastosComunesDTO.ArchivoGasto;
        }

        bool respuesta = YouCom.bll.GastosComunes.GastoComunBLL.Update(theGastosComunesDTO);

        if (respuesta)
        {
            cargarGastoComun();
            this.txtComentario.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtMonto.Text = string.Empty;
            this.ddlEstado.ClearSelection();
            ddlCondominio.ClearSelection();
            ddlCasa.ClearSelection();

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Gasto Común editado correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptGastoComunInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdGastoComun = new HiddenField();
            hdnIdGastoComun = (HiddenField)e.Item.FindControl("hdnIdGastoComun");

            YouCom.DTO.GastosComunes.GastoComunDTO myGastosComunesDTO = new YouCom.DTO.GastosComunes.GastoComunDTO();
            myGastosComunesDTO.IdGastoComun = decimal.Parse(hdnIdGastoComun.Value);
            myGastosComunesDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.GastosComunes.GastoComunBLL.ActivaGastoComun(myGastosComunesDTO);
            if (respuesta)
            {
                cargarGastoComun();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Gasto Común Activado correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptGastoComun_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominioCasa1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");
        DropDownList ddlCasa = (DropDownList)wucCondominio.FindControl("ddlCasa");


        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdGastoComun = new HiddenField();
            hdnIdGastoComun = (HiddenField)e.Item.FindControl("hdnIdGastoComun");

            YouCom.DTO.GastosComunes.GastoComunDTO myGastosComunesDTO = new YouCom.DTO.GastosComunes.GastoComunDTO();
            myGastosComunesDTO = YouCom.bll.GastosComunes.GastoComunBLL.detalleGastosComunes(decimal.Parse(hdnIdGastoComun.Value));

            this.hdnIdGastoComun.Value = myGastosComunesDTO.IdGastoComun.ToString();
            this.txtDescripcion.Text = myGastosComunesDTO.DescripcionGasto;
            this.txtComentario.Text = myGastosComunesDTO.ComentarioGasto;
            this.txtMonto.Text = myGastosComunesDTO.MontoGasto.ToString();
            this.FechaPago.Text = myGastosComunesDTO.FechaPagoGasto.ToShortDateString();
            this.FechaGasto.Text = myGastosComunesDTO.FechaGasto.ToShortDateString();

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myGastosComunesDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(myGastosComunesDTO.TheComunidadDTO.IdComunidad.ToString()));

            ddlCasa.DataSource = YouCom.bll.CasaBLL.getListadoCasaByComunidad(decimal.Parse(ddlComunidad.SelectedValue));
            ddlCasa.DataTextField = "NombreCasa";
            ddlCasa.DataValueField = "IdCasa";
            ddlCasa.DataBind();
            ddlCasa.Items.Insert(0, new ListItem("Seleccione Casa", string.Empty));

            ddlCasa.SelectedIndex = ddlCasa.Items.IndexOf(ddlCasa.Items.FindByValue(myGastosComunesDTO.TheCasaDTO.IdCasa.ToString()));

            ddlEstado.SelectedIndex = ddlEstado.Items.IndexOf(ddlEstado.Items.FindByValue(myGastosComunesDTO.TheGastoComunEstadoDTO.IdGastoComunEstado.ToString()));


            if (!string.IsNullOrEmpty(myGastosComunesDTO.ArchivoGasto))
            {
                this.lnkImagen.Visible = true;
                this.chkImagen.Visible = true;
                this.lnkImagen.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathGastoComunPub") + myGastosComunesDTO.ArchivoGasto;
            }

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnIdGastoComun = new HiddenField();
            hdnIdGastoComun = (HiddenField)e.Item.FindControl("hdnIdGastoComun");

            YouCom.DTO.GastosComunes.GastoComunDTO theGastosComunesDTO = new YouCom.DTO.GastosComunes.GastoComunDTO();
            theGastosComunesDTO.IdGastoComun = decimal.Parse(hdnIdGastoComun.Value);
            theGastosComunesDTO.UsuarioModificacion = myUsuario.Rut;

            bool respuesta = YouCom.bll.GastosComunes.GastoComunBLL.Delete(theGastosComunesDTO);
            if (respuesta)
            {
                cargarGastoComun();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Gasto Común eliminado correctamente.');";
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
