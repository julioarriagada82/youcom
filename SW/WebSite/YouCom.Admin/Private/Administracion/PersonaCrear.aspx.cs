using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouCom.DTO.Seguridad;

namespace BI.Web.Private.Administracion
{
    public partial class Persona : Intermedia.IMSystem.Navigation.Page.WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SelView(0);
                cargarFuncionGrupoSistema();
                cargaUsuarios();

                cargarPerfil();
            }
        }
        void SelView(Int32 nIndex)
        {
            this.mvwEmpresa.ActiveViewIndex = nIndex;
        }

        protected void cargarPerfil()
        {
            ddlPerfil.DataSource = YouCom.Seguridad.BLL.PerfilBLL.listaPerfilActivo();
            ddlPerfil.DataTextField = "NombrePerfil";
            ddlPerfil.DataValueField = "IdPerfil";
            ddlPerfil.DataBind();
            ddlPerfil.Items.Insert(0, new ListItem("Seleccione Perfil", string.Empty));

        }

        protected void cargaUsuarios()
        {
            if (myUsuario.IndexCondominio.ToString() == "0")
            {
                IList<OperadorDTO> usuarios = new List<OperadorDTO>();
                usuarios = YouCom.Seguridad.BLL.UsuarioBLL.getListadoUsuario();
                Session["usuarios"] = usuarios;
                rptUsuario.DataSource = usuarios;
                rptUsuario.DataBind();
            }
            else
            {
                IList<OperadorDTO> usuarios = new List<OperadorDTO>();
                usuarios = YouCom.Seguridad.BLL.UsuarioBLL.getListadoUsuario().Where(x => x.TheCondominioDTO.IdCondominio == myUsuario.TheCondominioSeleccionDTO.IdCondominio).ToList();
                Session["usuarios"] = usuarios;
                rptUsuario.DataSource = usuarios;
                rptUsuario.DataBind();
            }

        }
        protected void chkFuncion_CheckedChanged(object sender, EventArgs e)
        { }
        protected void cargarFuncionGrupoSistema()
        {
            rptGrupo.DataSource = YouCom.Seguridad.BLL.FuncionGrupoBLL.ListaGruposSistema();
            rptGrupo.DataBind();


        }
        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            bool respuesta = false;
            UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl(YouCom.Service.Configuracion.Config.getPageName(false) + "1").FindControl("wucCondominio1");
            DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
            DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

            List<OperadorDTO> usuarios = new List<OperadorDTO>();
            usuarios = (Session["usuarios"] as List<OperadorDTO>);

            usuarios = usuarios.Where(x => x.Rut == YouCom.Service.Formato.Formato.limpiarRut(this.txtRut.Text)).ToList();
            if (usuarios.Any())
            {
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Usuario ya Existe');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
                OperadorDTO theUsuarioDTO = new OperadorDTO();
                theUsuarioDTO.Usuario = YouCom.Service.Formato.Formato.limpiarRut(this.txtRut.Text);
                theUsuarioDTO.Rut = YouCom.Service.Formato.Formato.limpiarRut(this.txtRut.Text);
                theUsuarioDTO.Password = this.txtpasswordInicial.Text;
                theUsuarioDTO.Nombres = this.txtNombre.Text;
                theUsuarioDTO.Paterno = this.txtPaterno.Text;
                theUsuarioDTO.Materno = this.txtMaterno.Text;
                theUsuarioDTO.Mail = this.txtMail.Text;
                theUsuarioDTO.FechaNacimiento = Convert.ToDateTime(this.TxtFechaNacimiento.Text);
                theUsuarioDTO.Password = txtpasswordInicial.Text;
                theUsuarioDTO.UsuarioIngreso = myUsuario.Rut;

                YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
                theUsuarioDTO.TheCondominioDTO = myCondominioDTO;

                YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
                theUsuarioDTO.TheComunidadDTO = myComunidadDTO;

                YouCom.DTO.Seguridad.PerfilDTO myPerfilDTO = new YouCom.DTO.Seguridad.PerfilDTO();
                myPerfilDTO.IdPerfil = decimal.Parse(ddlPerfil.SelectedValue);
                theUsuarioDTO.ThePerfilDTO = myPerfilDTO;

                respuesta = YouCom.Seguridad.BLL.UsuarioBLL.Insert(theUsuarioDTO);

                if (respuesta)
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                    {
                        string script = "alert('Usuario Insertado Exitosamente.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                    }
                    cargaUsuarios();
                    txtpasswordInicial.Text = string.Empty;
                }
                else
                { }
            }


        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl(YouCom.Service.Configuracion.Config.getPageName(false) + "1").FindControl("wucCondominio1");
            DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
            DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

            btnEditar.Visible = false;
            BtnCrear.Visible = true;

            OperadorDTO theUsuarioDTO = new OperadorDTO();
            theUsuarioDTO.Usuario = YouCom.Service.Formato.Formato.limpiarRut(this.txtRut.Text);
            theUsuarioDTO.Rut = YouCom.Service.Formato.Formato.limpiarRut(this.txtRut.Text);
            theUsuarioDTO.Password = this.txtpasswordInicial.Text;
            theUsuarioDTO.Nombres = this.txtNombre.Text;
            theUsuarioDTO.Paterno = this.txtPaterno.Text;
            theUsuarioDTO.Materno = this.txtMaterno.Text;
            theUsuarioDTO.Mail = this.txtMail.Text;
            theUsuarioDTO.FechaNacimiento = Convert.ToDateTime(this.TxtFechaNacimiento.Text);
            theUsuarioDTO.Password = txtpasswordInicial.Text;

            YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
            myCondominioDTO.IdCondominio = decimal.Parse(ddlCondominio.SelectedValue);
            theUsuarioDTO.TheCondominioDTO = myCondominioDTO;

            YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
            myComunidadDTO.IdComunidad = decimal.Parse(ddlComunidad.SelectedValue);
            theUsuarioDTO.TheComunidadDTO = myComunidadDTO;

            YouCom.DTO.Seguridad.PerfilDTO myPerfilDTO = new YouCom.DTO.Seguridad.PerfilDTO();
            myPerfilDTO.IdPerfil = decimal.Parse(ddlPerfil.SelectedValue);
            theUsuarioDTO.ThePerfilDTO = myPerfilDTO;
            theUsuarioDTO.UsuarioModificacion = myUsuario.Rut;

            bool respuesta = YouCom.Seguridad.BLL.UsuarioBLL.Update(theUsuarioDTO);

            if (respuesta)
            {
                cargaUsuarios();
                this.txtNombre.Text = string.Empty;

                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Casa editada correctamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
            }
            else
            {
            }

        }

        protected void rptGrupo_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemIndex > -1)
                {
                    if (!string.IsNullOrEmpty(((FuncionGrupoDTO)e.Item.DataItem).FuncionGrupoCod))
                    {
                        HiddenField hdnGrupoCod = new HiddenField();
                        hdnGrupoCod = (HiddenField)e.Item.FindControl("hdnFuncionGrupoCod");

                        Repeater rptFunciones = new Repeater();
                        rptFunciones = (Repeater)e.Item.FindControl("rptFuncionesGrupo");

                        List<FuncionDTO> funciones = new List<FuncionDTO>();
                        funciones = YouCom.Seguridad.BLL.FuncionBLL.listaFuncion(int.Parse(hdnGrupoCod.Value));


                        rptFunciones.DataSource = funciones;
                        rptFunciones.DataBind();


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void rptUsuario_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Activar")
            {
                HiddenField hdnRut = new HiddenField();
                hdnRut = (HiddenField)e.Item.FindControl("hdnRut");



                OperadorDTO theUsuarioDTO = new OperadorDTO();
                theUsuarioDTO.Rut = hdnRut.Value;
                theUsuarioDTO.UsuarioModificacion = myUsuario.Rut;
                theUsuarioDTO.Estado = "1";


                YouCom.Seguridad.BLL.UsuarioBLL.ActivaDesactivaUsuario(theUsuarioDTO);
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Usuario Activado Exitosamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
                cargaUsuarios();

            }
            if (e.CommandName == "Desactivar")
            {
                HiddenField hdnRut = new HiddenField();
                hdnRut = (HiddenField)e.Item.FindControl("hdnRut");

                OperadorDTO theUsuarioDTO = new OperadorDTO();
                theUsuarioDTO.Rut = hdnRut.Value;
                theUsuarioDTO.UsuarioModificacion = myUsuario.Rut;
                theUsuarioDTO.Estado = "2";


                YouCom.Seguridad.BLL.UsuarioBLL.ActivaDesactivaUsuario(theUsuarioDTO);
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Usuario Desactivado Exitosamente.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                }
                cargaUsuarios();

            }
            if (e.CommandName == "Funcionalidad")
            {
                HiddenField hdnRut = new HiddenField();
                hdnRut = (HiddenField)e.Item.FindControl("hdnRut");

                HiddenField hdnEmpresa = new HiddenField();
                hdnEmpresa = (HiddenField)e.Item.FindControl("hdnEmpresa");

                hidRut.Value = hdnRut.Value;
                this.txtRut.Text = hdnEmpresa.Value;

                SelView(1);

            }

        }
        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            int cont = 0;
            PermisoDTO thePermisoDTO = new PermisoDTO();

            foreach (RepeaterItem item in rptGrupo.Items)
            {
                if (cont == 0)
                {
                    thePermisoDTO.Usuario = hidRut.Value;
                    YouCom.Seguridad.BLL.PermisoBLL.Delete(thePermisoDTO);
                    cont++;
                }

                HiddenField hdnGrupoCod = new HiddenField();
                hdnGrupoCod = (HiddenField)item.FindControl("hdnFuncionGrupoCod");

                Repeater rptFunciones = new Repeater();
                rptFunciones = (Repeater)item.FindControl("rptFuncionesGrupo");

                foreach (RepeaterItem itemFunciones in rptFunciones.Items)
                {


                    CheckBox funcion = new CheckBox();
                    funcion = (CheckBox)itemFunciones.FindControl("chkFuncion");

                    if (funcion.Checked)
                    {
                        HiddenField hdnFuncion = new HiddenField();
                        hdnFuncion = (HiddenField)itemFunciones.FindControl("hdnFuncionGrupoCod");

                        ///Graba Permisos Generales de Acceso a las paginas

                        thePermisoDTO.Funcion = hdnFuncion.Value;
                        thePermisoDTO.Empresa = this.txtRut.Text;
                        thePermisoDTO.Usuario = hidRut.Value;

                        //elimina permisos existentes
                        //vuelve a crear permisos existentes
                        YouCom.Seguridad.BLL.PermisoBLL.Insert(thePermisoDTO);


                        if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                        {
                            string script = "alert('Permisos Asociados Exitosamente.');";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "SET", script, true);
                        }

                    }


                }
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string strClave = string.Empty;

            strClave = YouCom.Service.Generales.General.getGeneraClave(8);

            this.txtpasswordInicial.Text = strClave;
        }

        protected void ddlPerfil_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            UserControl wucCondominio = (UserControl)Page.Master.FindControl("ContentPlaceHolder1").FindControl(YouCom.Service.Configuracion.Config.getPageName(false) + "1").FindControl("wucCondominio1");
            DropDownList ddlCondominio = (DropDownList)wucCondominio.FindControl("ddlCondominio");
            DropDownList ddlComunidad = (DropDownList)wucCondominio.FindControl("ddlComunidad");

            if (ddlPerfil.SelectedValue == "1")
            {
                getPaneles(false, true, false);

                if (string.IsNullOrEmpty(ddlCondominio.SelectedValue))
                {
                    List<YouCom.DTO.DirectivaDTO> collDirectiva = new List<YouCom.DTO.DirectivaDTO>();
                    collDirectiva = YouCom.bll.DirectivaBLL.listaDirectivaActivo().Where(x => x.TheCondominioDTO.IdCondominio == decimal.Parse(ddlCondominio.SelectedValue)).ToList();

                    ddlDirectiva.DataSource = collDirectiva;
                    ddlDirectiva.DataTextField = "NombreCompleto";
                    ddlDirectiva.DataValueField = "IdDirectiva";
                    ddlDirectiva.DataBind();
                    ddlDirectiva.Items.Insert(0, new ListItem("Seleccione Directiva", string.Empty));
                }
            }
            else if (ddlPerfil.SelectedValue == "2")
            {
                getPaneles(false, false, true);

                if (string.IsNullOrEmpty(ddlCondominio.SelectedValue))
                {
                    List<YouCom.DTO.PorteriaDTO> collPorteria = new List<YouCom.DTO.PorteriaDTO>();
                    collPorteria = YouCom.bll.PorteriaBLL.listaPorteriaActivo().Where(x => x.TheCondominioDTO.IdCondominio == decimal.Parse(ddlCondominio.SelectedValue)).ToList();

                    ddlPorteria.DataSource = collPorteria;
                    ddlPorteria.DataTextField = "NombreCompleto";
                    ddlPorteria.DataValueField = "IdPorteria";
                    ddlPorteria.DataBind();
                    ddlPorteria.Items.Insert(0, new ListItem("Seleccione Porteria", string.Empty));
                }
            }
            else if (ddlPerfil.SelectedValue == "3")
            {
                getPaneles(true, false, false);

                if (string.IsNullOrEmpty(ddlCondominio.SelectedValue))
                {
                    List<YouCom.DTO.Propietario.CasaDTO> casas = new List<YouCom.DTO.Propietario.CasaDTO>();
                    casas = YouCom.bll.CasaBLL.listaCasaActivo().Where(x => x.TheCondominioDTO.IdCondominio == decimal.Parse(ddlCondominio.SelectedValue)).ToList();

                    ddlCasa.DataSource = casas;
                    ddlCasa.DataTextField = "NombreCasa";
                    ddlCasa.DataValueField = "IdCasa";
                    ddlCasa.DataBind();
                    ddlCasa.Items.Insert(0, new ListItem("Seleccione Casa", string.Empty));
                }
            }
        }

        protected void getPaneles(bool propietario, bool directiva, bool porteria)
        {
            pnlPropietario.Visible = propietario;
            pnlDirectiva.Visible = directiva;
            pnlPorteria.Visible = porteria;
        }

        protected void ddlCasa_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            List<YouCom.DTO.Propietario.FamiliaDTO> familias = new List<YouCom.DTO.Propietario.FamiliaDTO>();
            familias = YouCom.bll.FamiliaBLL.listaFamiliaActivo().Where(x => x.TheCasaDTO.IdCasa == decimal.Parse(ddlCasa.SelectedValue)).ToList();

            dllIntegrante.DataSource = familias;
            dllIntegrante.DataTextField = "NombreCompleto";
            dllIntegrante.DataValueField = "IdFamilia";
            dllIntegrante.DataBind();
            dllIntegrante.Items.Insert(0, new ListItem("Seleccione Integrante Familia", string.Empty));
        }

        protected void dllIntegrante_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            YouCom.DTO.Propietario.FamiliaDTO theFamilia = new YouCom.DTO.Propietario.FamiliaDTO();
            theFamilia = YouCom.bll.FamiliaBLL.detalleFamilia(decimal.Parse(this.dllIntegrante.SelectedValue));

            txtRut.Text = YouCom.Service.Generales.Formato.FormatoRut(theFamilia.RutFamilia);
            txtNombre.Text = theFamilia.NombreFamilia;
            txtPaterno.Text = theFamilia.ApellidoPaternoFamilia;
            txtMaterno.Text = theFamilia.ApellidoMaternoFamilia;
            TxtFechaNacimiento.Text = theFamilia.FechaNacimientoFamilia.ToShortDateString();
            txtMail.Text = theFamilia.EmailFamilia;
        }

        protected void ddlDirectiva_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            YouCom.DTO.DirectivaDTO theDirectiva = new YouCom.DTO.DirectivaDTO();
            theDirectiva = YouCom.bll.DirectivaBLL.detalleDirectiva(decimal.Parse(ddlDirectiva.SelectedValue));

            txtRut.Text = YouCom.Service.Generales.Formato.FormatoRut(theDirectiva.RutDirectiva);
            txtNombre.Text = theDirectiva.NombreDirectiva;
            txtPaterno.Text = theDirectiva.ApellidoPaternoDirectiva;
            txtMaterno.Text = theDirectiva.ApellidoMaternoDirectiva;
            TxtFechaNacimiento.Text = theDirectiva.FechaNacimientoDirectiva.ToShortDateString();
            txtMail.Text = theDirectiva.EmailDirectiva;
        }

        protected void ddlPorteria_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            YouCom.DTO.PorteriaDTO thePorteria = new YouCom.DTO.PorteriaDTO();
            thePorteria = YouCom.bll.PorteriaBLL.detallePorteria(decimal.Parse(this.ddlPorteria.SelectedValue));

            txtRut.Text = YouCom.Service.Generales.Formato.FormatoRut(thePorteria.RutPorteria);
            txtNombre.Text = thePorteria.NombrePorteria;
            txtPaterno.Text = thePorteria.ApellidoPaternoPorteria;
            txtMaterno.Text = thePorteria.ApellidoMaternoPorteria;
            TxtFechaNacimiento.Text = thePorteria.FechaNacimientoPorteria.ToShortDateString();
            txtMail.Text = thePorteria.EmailPorteria;
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
