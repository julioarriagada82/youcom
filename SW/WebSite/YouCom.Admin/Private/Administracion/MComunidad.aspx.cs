using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YouCom.Web.Private.Administracion
{
    public partial class Comunidad : Intermedia.IMSystem.Navigation.Page.WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarCondominio();
                cargarComunidad();
            }
        }

        protected void cargarCondominio()
        {
            ddlCondominio.DataSource = YouCom.Seguridad.BLL.CondominioBLL.getListadoCondominio();
            ddlCondominio.DataTextField = "NombreCondominio";
            ddlCondominio.DataValueField = "IdCondominio";
            ddlCondominio.DataBind();
            ddlCondominio.Items.Insert(0, new ListItem("Seleccione Condominio", string.Empty));
        }

        protected void cargarComunidad()
        {
            if (myUsuario.IndexCondominio.ToString() == "0")
            {
                Session["comunidad"] = YouCom.bll.ComunidadBLL.getListadoComunidad();
                rptComunidad.DataSource = YouCom.bll.ComunidadBLL.listaComunidadActivo();
                rptComunidad.DataBind();
            }
            else
            {
                Session["comunidad"] = YouCom.bll.ComunidadBLL.getListadoComunidad().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
                rptComunidad.DataSource = YouCom.bll.ComunidadBLL.listaComunidadActivo().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
                rptComunidad.DataBind();
            }
        }

        protected void lblPapeleria_OnClick(object sender, EventArgs e)
        {
            pnlPapelera.Visible = true;
            this.pnlAdministracionComunidad.Visible = false;
            cargarComunidadInactivo();
        }
        protected void cargarComunidadInactivo()
        {
            IList<YouCom.DTO.Seguridad.ComunidadDTO> comunidades = new List<YouCom.DTO.Seguridad.ComunidadDTO>();
            comunidades = YouCom.bll.ComunidadBLL.listaComunidadInactivo();
            if (comunidades.Any())
            {
                rptComunidadInactivo.DataSource = comunidades;
                rptComunidadInactivo.DataBind();
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
            List<YouCom.DTO.Seguridad.ComunidadDTO> comunidad = new List<YouCom.DTO.Seguridad.ComunidadDTO>();
            comunidad = (Session["comunidad"] as List<YouCom.DTO.Seguridad.ComunidadDTO>);

            YouCom.DTO.Seguridad.ComunidadDTO theComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
            theComunidadDTO.NombreComunidad = this.txtNombre.Text.ToUpper();
            theComunidadDTO.DireccionComunidad = this.txtDireccion.Text.ToUpper();
            theComunidadDTO.TheCondominioDTO.IdCondominio = decimal.Parse(this.ddlCondominio.SelectedValue);
            theComunidadDTO.UsuarioIngreso = myUsuario.Rut;

            comunidad = comunidad.Where(x => x.NombreComunidad == theComunidadDTO.NombreComunidad).ToList();
            if (comunidad.Any())
            {
                foreach (var item in comunidad)
                {
                    if (item.Estado == "2")
                    {
                        string script = "alert('Comunidad Existe pero fue Eliminado Para Activarlo dirigase a Papelera.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                        return;
                    }
                    else
                    {
                        string script = "alert('Comunidad ya Existe.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                        return;
                    }
                }
            }

            bool respuesta = YouCom.bll.ComunidadBLL.Insert(theComunidadDTO);
            if (respuesta)
            {
                this.txtNombre.Text = string.Empty;
                string script = "alert('Comunidad Ingresada correctamente.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                cargarComunidad();
            }
            else
            {
            }
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            btnEditar.Visible = false;
            btnGrabar.Visible = true;

            YouCom.DTO.Seguridad.ComunidadDTO theComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
            theComunidadDTO.IdComunidad = decimal.Parse(this.hdnComunidadId.Value);
            theComunidadDTO.NombreComunidad = this.txtNombre.Text;
            theComunidadDTO.DireccionComunidad = this.txtDireccion.Text;
            theComunidadDTO.TheCondominioDTO.IdCondominio = decimal.Parse(this.ddlCondominio.SelectedValue);
            theComunidadDTO.UsuarioModificacion = myUsuario.Rut;

            bool respuesta = YouCom.bll.ComunidadBLL.Update(theComunidadDTO);

            if (respuesta)
            {
                cargarComunidad();
                this.txtNombre.Text = string.Empty;

                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Comunidad editada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }

        }
        protected void rptComunidadInactivo_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Activar")
            {
                HiddenField hdnIdComunidad = new HiddenField();
                hdnIdComunidad = (HiddenField)e.Item.FindControl("hdnComunidadId");

                YouCom.DTO.Seguridad.ComunidadDTO theComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                theComunidadDTO.IdComunidad = decimal.Parse(hdnIdComunidad.Value);
                theComunidadDTO.UsuarioModificacion = myUsuario.Rut;
                bool respuesta = YouCom.bll.ComunidadBLL.ActivaComunidad(theComunidadDTO);
                if (respuesta)
                {
                    cargarComunidadInactivo();
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Comunidad Activado correctamente.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                }
                else
                {
                }
            }

        }
        protected void rptComunidad_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                HiddenField hdnIdComunidad = new HiddenField();
                hdnIdComunidad = (HiddenField)e.Item.FindControl("hdnComunidadId");

                YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                myComunidadDTO = YouCom.bll.ComunidadBLL.detalleComunidad(decimal.Parse(hdnIdComunidad.Value));

                this.hdnComunidadId.Value = myComunidadDTO.IdComunidad.ToString();
                txtNombre.Text = myComunidadDTO.NombreComunidad;
                txtDireccion.Text = myComunidadDTO.DireccionComunidad;

                ddlCondominio.SelectedIndex = ddlCondominio.Items.IndexOf(ddlCondominio.Items.FindByValue(myComunidadDTO.TheCondominioDTO.IdCondominio.ToString()));

                btnGrabar.Visible = false;
                btnEditar.Visible = true;

            }
            if (e.CommandName == "Eliminar")
            {
                HiddenField hdnIdComunidad = new HiddenField();
                hdnIdComunidad = (HiddenField)e.Item.FindControl("hdnComunidadId");

                YouCom.DTO.Seguridad.ComunidadDTO theComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                theComunidadDTO.IdComunidad = decimal.Parse(hdnIdComunidad.Value);
                theComunidadDTO.UsuarioModificacion = myUsuario.Rut;

                bool validacionIntegridad = YouCom.bll.ComunidadBLL.ValidaEliminacionComunidad(theComunidadDTO);
                if (validacionIntegridad)
                {
                    string script = "alert(' No es posible eliminar una comunidad con registros asociados.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    return;
                }
                else
                {
                    bool respuesta = YouCom.bll.ComunidadBLL.Delete(theComunidadDTO);
                    if (respuesta)
                    {
                        cargarComunidad();
                        if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                        {
                            string script = "alert('Comunidad Eliminada correctamente.');";
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
}