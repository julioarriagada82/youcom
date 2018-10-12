using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Privado_Default : Intermedia.IMSystem.Navigation.Page.WebPage
{
    private const string retorno1 = "Default.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarGastosComunes();
            cargarAutorizaciones();
            cargarVacaciones();
            cargarNucleFamiliar();
            cargarMensajes();
        }
    }

    protected void cargarNucleFamiliar()
    {
        IList<YouCom.DTO.ContactoFamiliaDTO> myContactoFamiliaDTO = new List<YouCom.DTO.ContactoFamiliaDTO>();

        myContactoFamiliaDTO = YouCom.bll.ContactoFamiliaBLL.getListadoContactoFamiliaByCasa(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad, myUsuario.TheFamiliaDTO.TheCasaDTO.IdCasa);

        rptNucleoFamiliar.DataSource = myContactoFamiliaDTO;
        rptNucleoFamiliar.DataBind();
    }

    protected void cargarVacaciones()
    {
        IList<YouCom.DTO.VacacionesDTO> myVacacionesDTO = new List<YouCom.DTO.VacacionesDTO>();

        myVacacionesDTO = YouCom.bll.VacacionesBLL.getListadoVacacionesByCasa(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad, myUsuario.TheFamiliaDTO.TheCasaDTO.IdCasa);

        rptVacaciones.DataSource = myVacacionesDTO;
        rptVacaciones.DataBind();
    }

    protected void cargarAutorizaciones()
    {
        IList<YouCom.DTO.AccesoHogar.AccesoHogarDTO> myAccesoHogar = new List<YouCom.DTO.AccesoHogar.AccesoHogarDTO>();

        myAccesoHogar = YouCom.bll.AccesoHogar.AccesoHogarBLL.getListadoAccesoHogarByCasa(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad, myUsuario.TheFamiliaDTO.TheCasaDTO.IdCasa);

        rptAutorizaciones.DataSource = myAccesoHogar;
        rptAutorizaciones.DataBind();
    }

    protected void cargarGastosComunes()
    {
        IList<YouCom.DTO.GastosComunes.GastoComunDTO> myGastosComunes = new List<YouCom.DTO.GastosComunes.GastoComunDTO>();

        myGastosComunes = YouCom.bll.GastosComunes.GastoComunBLL.getListadoEventoByCasa(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad, myUsuario.TheFamiliaDTO.TheCasaDTO.IdCasa);

        rptGastosComunes.DataSource = myGastosComunes;
        rptGastosComunes.DataBind();
    }

    protected void cargarMensajes()
    {
        IList<YouCom.DTO.Mensajeria.MensajeDTO> myMensajeDTO = new List<YouCom.DTO.Mensajeria.MensajeDTO>();
        myMensajeDTO = YouCom.bll.Mensajeria.MensajeBLL.getListadoMensajeByCondominioByComunidad(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad, myUsuario.TheFamiliaDTO.IdFamilia);

        rptMensajes.DataSource = myMensajeDTO;
        rptMensajes.DataBind();
    }

    protected void rptAutorizaciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.AccesoHogar.AccesoHogarDTO)e.Item.DataItem).IdAccesoHogar.ToString()))
                {
                    Literal myLitNombreActividad = new Literal();
                    Literal myLitFrecuencia = new Literal();

                    myLitNombreActividad = (Literal)e.Item.FindControl("LitNombreActividad");
                    myLitFrecuencia = (Literal)e.Item.FindControl("LitFrecuencia");

                    YouCom.DTO.AccesoHogar.TipoVisitaDTO myTipoVisitaDTO = new YouCom.DTO.AccesoHogar.TipoVisitaDTO();
                    YouCom.DTO.AccesoHogar.FrecuenciaDTO myFrecuenciaDTO = new YouCom.DTO.AccesoHogar.FrecuenciaDTO();

                    myTipoVisitaDTO = YouCom.bll.AccesoHogar.TipoVisitaBLL.detalleTipoVisita(((YouCom.DTO.AccesoHogar.AccesoHogarDTO)e.Item.DataItem).TheTipoVisitaDTO.IdTipoVisita);
                    myFrecuenciaDTO = YouCom.bll.AccesoHogar.FrecuenciaBLL.detalleFrecuencia(((YouCom.DTO.AccesoHogar.AccesoHogarDTO)e.Item.DataItem).TheFrecuenciaDTO.IdFrecuencia);

                    myLitNombreActividad.Text = myTipoVisitaDTO.NombreTipoVisita.ToString();
                    myLitFrecuencia.Text = myFrecuenciaDTO.NombreFrecuencia.ToString();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptNucleoFamiliar_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.ContactoFamiliaDTO)e.Item.DataItem).IdContactoFamilia.ToString()))
                {
                    Literal myLitParentesco = new Literal();

                    myLitParentesco = (Literal)e.Item.FindControl("LitParentesco");

                    YouCom.DTO.Propietario.ParentescoDTO myParentescoDTO = new YouCom.DTO.Propietario.ParentescoDTO();

                    myParentescoDTO = YouCom.bll.ParentescoBLL.detalleParentesco(((YouCom.DTO.ContactoFamiliaDTO)e.Item.DataItem).TheParentescoDTO.IdParentesco);

                    myLitParentesco.Text = myParentescoDTO.NombreParentesco.ToString();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptGastosComunes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                HyperLink myHyperLink = (HyperLink)e.Item.FindControl("LnkDetalle");

                if (!string.IsNullOrEmpty(((YouCom.DTO.GastosComunes.GastoComunDTO)e.Item.DataItem).ArchivoGasto.Trim()))
                {
                    myHyperLink.NavigateUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathGastoComunPub") + ((YouCom.DTO.GastosComunes.GastoComunDTO)e.Item.DataItem).ArchivoGasto;
                    myHyperLink.Target = "_blank";
                    myHyperLink.Text = @"<span class=""glyphicon glyphicon-eye-open""></span>";
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptAutorizaciones_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Eliminar"))
            {
                HiddenField HdnIdAccesoHogar = (HiddenField)e.Item.FindControl("HdnIdAccesoHogar");

                YouCom.DTO.AccesoHogar.AccesoHogarDTO myAccesoHogarDTO = new YouCom.DTO.AccesoHogar.AccesoHogarDTO();

                myAccesoHogarDTO.IdAccesoHogar = decimal.Parse(HdnIdAccesoHogar.Value);
                myAccesoHogarDTO.UsuarioModificacion = myUsuario.Rut;

                if (YouCom.bll.AccesoHogar.AccesoHogarBLL.Delete(myAccesoHogarDTO))
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Autorización eliminada correctamente.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
            }

            if (e.CommandName.Equals("ListaNegra"))
            {
                HiddenField HdnIdAccesoHogar = (HiddenField)e.Item.FindControl("HdnIdAccesoHogar");

                YouCom.DTO.AccesoHogar.AccesoHogarDTO theAccesoHogarDTO = new YouCom.DTO.AccesoHogar.AccesoHogarDTO();
                YouCom.DTO.Propietario.FamiliaDTO theFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                theFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                theAccesoHogarDTO = YouCom.bll.AccesoHogar.AccesoHogarBLL.detalleAccesoHogar(decimal.Parse(HdnIdAccesoHogar.Value));

                YouCom.DTO.ListaNegraDTO theListaNegraDTO = new YouCom.DTO.ListaNegraDTO();
                theListaNegraDTO.RutListaNegra = YouCom.Service.Generales.Formato.LimpiarRut(theAccesoHogarDTO.RutVisita.ToUpper());
                theListaNegraDTO.NombreListaNegra = theAccesoHogarDTO.NombreVisita.ToUpper();
                theListaNegraDTO.ApellidoPaternoListaNegra = "";
                theListaNegraDTO.ApellidoMaternoListaNegra = "";
                theListaNegraDTO.MotivoListaNegra = "";
                theListaNegraDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;
                theListaNegraDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                theListaNegraDTO.TheFamiliaDTO = theFamiliaDTO;
                theListaNegraDTO.UsuarioIngreso = myUsuario.Rut;

                bool respuesta = YouCom.bll.ListaNegraBLL.Insert(theListaNegraDTO);
                if (respuesta)
                {
                    string script = "alert('Autorización agregada como lista negra correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
                else
                {
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptVacaciones_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Eliminar"))
            {
                HiddenField hdnIdVacaciones = (HiddenField)e.Item.FindControl("hdnIdVacaciones");

                YouCom.DTO.VacacionesDTO myVacacionesDTO = new YouCom.DTO.VacacionesDTO();

                myVacacionesDTO.IdVacaciones = decimal.Parse(hdnIdVacaciones.Value);
                myVacacionesDTO.UsuarioModificacion = myUsuario.Rut;

                if (YouCom.bll.VacacionesBLL.Delete(myVacacionesDTO))
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Vacación eliminada correctamente.');";
                        script += "parent.location = '" + retorno1 + "';";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
            }

            if (e.CommandName.Equals("Detalle"))
            {
                HiddenField hdnIdVacaciones = (HiddenField)e.Item.FindControl("hdnIdVacaciones");
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptNucleoFamiliar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Eliminar"))
            {
                HiddenField hdnIdContactoFamilia = (HiddenField)e.Item.FindControl("hdnIdContactoFamilia");

                YouCom.DTO.ContactoFamiliaDTO myContactoFamiliaDTO = new YouCom.DTO.ContactoFamiliaDTO();

                myContactoFamiliaDTO.IdContactoFamilia = decimal.Parse(hdnIdContactoFamilia.Value);
                myContactoFamiliaDTO.UsuarioModificacion = myUsuario.Rut;

                if (YouCom.bll.ContactoFamiliaBLL.Delete(myContactoFamiliaDTO))
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Integrante de familia eliminada correctamente.');";
                        script += "parent.location = '" + retorno1 + "';";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
            }

            if (e.CommandName.Equals("Detalle"))
            {
                HiddenField hdnIdVacaciones = (HiddenField)e.Item.FindControl("hdnIdVacaciones");
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void BtnIngresarVacaciones_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AgregarVacaciones.aspx");
        }
        catch (Exception ex)
        { 
        
        }
    }
    protected void BtnIngresarNucleoFamiliar_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AgregarNucleoFamiliar.aspx");
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptMensajes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Responder"))
            {
                YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new YouCom.DTO.Mensajeria.MensajeDTO();
                YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);

                HiddenField HdnIdMensaje = (HiddenField)e.Item.FindControl("hdnIdMensaje");

                Session.Add("MensajeId", HdnIdMensaje.Value);

                myMensajeDTO = YouCom.bll.Mensajeria.MensajeBLL.detalleMensaje(myFamiliaDTO.IdFamilia, decimal.Parse(HdnIdMensaje.Value));

                if (myMensajeDTO.TheMensajeTipoDTO.NombreMensajeTipo == "Administración")
                {
                    Response.Redirect("Contacto/MensajeAdministracion.aspx", true);
                }
                else if (myMensajeDTO.TheMensajeTipoDTO.NombreMensajeTipo == "Porteria")
                {
                    Response.Redirect("Contacto/MensajePorteria.aspx", true);
                }
                else if (myMensajeDTO.TheMensajeTipoDTO.NombreMensajeTipo == "Propietario")
                {
                    Response.Redirect("Contacto/MensajePropietario.aspx", true);
                }

            }
        }
        catch (Exception ex)
        {

        }
    }
}
