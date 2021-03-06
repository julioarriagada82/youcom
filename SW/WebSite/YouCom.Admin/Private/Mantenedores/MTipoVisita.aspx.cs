﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.AccesoHogar;

public partial class Admin_Mantenedores_MTipoVisita : Intermedia.IMSystem.Navigation.Page.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarTipoVisita();
        }
    }

    protected void cargarTipoVisita()
    {
        if (myUsuario.IndexCondominio.ToString() == "0")
        {
            Session["TipoVisita"] = YouCom.bll.AccesoHogar.TipoVisitaBLL.getListadoTipoVisita();
            rptTipoVisita.DataSource = YouCom.bll.AccesoHogar.TipoVisitaBLL.listaTipoVisitaActivo();
            rptTipoVisita.DataBind();
        }
        else
        {
            Session["TipoVisita"] = YouCom.bll.AccesoHogar.TipoVisitaBLL.getListadoTipoVisita().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptTipoVisita.DataSource = YouCom.bll.AccesoHogar.TipoVisitaBLL.listaTipoVisitaActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
            rptTipoVisita.DataBind();
        }
    }
    protected void lblPapeleria_OnClick(object sender, EventArgs e)
    {
        pnlPapelera.Visible = true;
        pnlAdministracionCasa.Visible = false;
        cargarTipoVisitaInactivo();
    }
    protected void cargarTipoVisitaInactivo()
    {
        IList<TipoVisitaDTO> tipo_aviso = new List<TipoVisitaDTO>();
        tipo_aviso = YouCom.bll.AccesoHogar.TipoVisitaBLL.listaTipoVisitaInactivo();
        if (tipo_aviso.Any())
        {
            rptTipoVisitaInactivo.DataSource = tipo_aviso;
            rptTipoVisitaInactivo.DataBind();
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

        List<TipoVisitaDTO> tipo_aviso = new List<TipoVisitaDTO>();
        tipo_aviso = (Session["TipoVisita"] as List<TipoVisitaDTO>);

        TipoVisitaDTO theTipoVisitaDTO = new TipoVisitaDTO();
        theTipoVisitaDTO.NombreTipoVisita = this.txtNombre.Text.ToUpper();
        theTipoVisitaDTO.UsuarioIngreso = myUsuario.Rut;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theTipoVisitaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theTipoVisitaDTO.TheComunidadDTO = myComunidadDTO;

        tipo_aviso = tipo_aviso.Where(x => x.NombreTipoVisita == theTipoVisitaDTO.NombreTipoVisita).ToList();
        if (tipo_aviso.Any())
        {
            foreach (var item in tipo_aviso)
            {
                if (item.Estado == "2")
                {
                    string script = "alert('Tipo Aviso Existe pero Fue Eliminado Para Activarlo dirigase a Papelera.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    string script = "alert('Tipo Aviso ya Existe .');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
            }


        }


        bool respuesta = YouCom.bll.AccesoHogar.TipoVisitaBLL.Insert(theTipoVisitaDTO);
        if (respuesta)
        {
            this.txtNombre.Text = string.Empty;
            string script = "alert('Tipo Aviso Ingresada correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            cargarTipoVisita();
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

        TipoVisitaDTO theTipoVisitaDTO = new TipoVisitaDTO();
        theTipoVisitaDTO.IdTipoVisita = decimal.Parse(this.hdnIdTipoVisita.Value);
        theTipoVisitaDTO.NombreTipoVisita = this.txtNombre.Text.ToUpper();
        theTipoVisitaDTO.UsuarioModificacion = myUsuario.Rut;

        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
        myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
        theTipoVisitaDTO.TheCondominioDTO = myCondominioDTO;

        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
        myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
        theTipoVisitaDTO.TheComunidadDTO = myComunidadDTO;

        bool respuesta = YouCom.bll.AccesoHogar.TipoVisitaBLL.Update(theTipoVisitaDTO);

        if (respuesta)
        {
            cargarTipoVisita();
            this.txtNombre.Text = string.Empty;

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
            {
                string script = "alert('Tipo Aviso editada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
            }
        }
        else
        {
        }

    }
    protected void rptTipoVisitaInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Activar")
        {
            HiddenField hdnIdTipoVisita = new HiddenField();
            hdnIdTipoVisita = (HiddenField)e.Item.FindControl("hdnIdTipoVisita");

            TipoVisitaDTO theTipoVisitaDTO = new TipoVisitaDTO();
            theTipoVisitaDTO.IdTipoVisita = decimal.Parse(hdnIdTipoVisita.Value);
            theTipoVisitaDTO.UsuarioModificacion = myUsuario.Rut;
            bool respuesta = YouCom.bll.AccesoHogar.TipoVisitaBLL.ActivaTipoVisita(theTipoVisitaDTO);
            if (respuesta)
            {
                cargarTipoVisitaInactivo();
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Tipo Visita activada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }
        }

    }
    protected void rptTipoVisita_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl("wucCondominio1");
        DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
        DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

        if (e.CommandName == "Editar")
        {
            HiddenField hdnIdTipoVisita = new HiddenField();
            hdnIdTipoVisita = (HiddenField)e.Item.FindControl("hdnIdTipoVisita");

            YouCom.DTO.AccesoHogar.TipoVisitaDTO theTipoVisitaDTO = new YouCom.DTO.AccesoHogar.TipoVisitaDTO();
            theTipoVisitaDTO = YouCom.bll.AccesoHogar.TipoVisitaBLL.detalleTipoVisita(decimal.Parse(hdnIdTipoVisita.Value));

            txtNombre.Text = theTipoVisitaDTO.NombreTipoVisita;
            this.hdnIdTipoVisita.Value = theTipoVisitaDTO.IdTipoVisita.ToString();

            ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(theTipoVisitaDTO.TheCondominioDTO.IdCondominio.ToString()));

            ddlComunidad.DataSource = YouCom.bll.ComunidadBLL.getListadoComunidadByCondominio(decimal.Parse(ddlCondominio.SelectedValue));
            ddlComunidad.DataTextField = "NombreComunidad";
            ddlComunidad.DataValueField = "IdComunidad";
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Seleccione Comunidad", string.Empty));

            ddlComunidad.SelectedIndex = ddlComunidad.Items.IndexOf(ddlComunidad.Items.FindByValue(theTipoVisitaDTO.TheComunidadDTO.IdComunidad.ToString()));

            btnGrabar.Visible = false;
            btnEditar.Visible = true;

        }
        if (e.CommandName == "Eliminar")
        {
            HiddenField hdnTipoSistema = new HiddenField();
            hdnTipoSistema = (HiddenField)e.Item.FindControl("HdnTipoSistema");

            HiddenField hdnDescripcion = new HiddenField();
            hdnDescripcion = (HiddenField)e.Item.FindControl("hdnDescripcion");

            TipoVisitaDTO theTipoVisitaDTO = new TipoVisitaDTO();
            theTipoVisitaDTO.IdTipoVisita = decimal.Parse(hdnTipoSistema.Value);
            theTipoVisitaDTO.UsuarioModificacion = myUsuario.Rut;

            bool validacionIntegridad = YouCom.bll.AccesoHogar.TipoVisitaBLL.ValidaEliminacionTipoVisita(theTipoVisitaDTO);
            if (validacionIntegridad)
            {
                string script = "alert(' No es posible eliminar un TipoVisita con aviso asociado.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                return;
            }
            else
            {
                bool respuesta = YouCom.bll.AccesoHogar.TipoVisitaBLL.Delete(theTipoVisitaDTO);
                if (respuesta)
                {
                    cargarTipoVisita();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Casa Eliminada correctamente.');";
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
