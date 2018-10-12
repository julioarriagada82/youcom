using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Inicio : Intermedia.IMSystem.Navigation.Page.WebPage
{
    private const string retorno1 = "Inicio.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SelView(0);

            cargarGastosComunes();

            getCargaVideo();

            cargarCategorias();

            IList<YouCom.DTO.Mensajeria.MensajeDTO> myMensajePropietarioDTO = new List<YouCom.DTO.Mensajeria.MensajeDTO>();
            myMensajePropietarioDTO = YouCom.bll.Mensajeria.MensajeBLL.getListadoMensajesPropietarios();

            IList<YouCom.DTO.Mensajeria.MensajeDTO> myMensajeInternosDTO = new List<YouCom.DTO.Mensajeria.MensajeDTO>();
            myMensajeInternosDTO = YouCom.bll.Mensajeria.MensajeBLL.getListadoMensajesInternos();

            rptMensajes.DataSource = myMensajePropietarioDTO;
            rptMensajes.DataBind();

            rptIndicadorCarrusel.DataSource = myMensajeInternosDTO.Take(6);
            rptIndicadorCarrusel.DataBind();

            rptMensajesInternos.DataSource = myMensajeInternosDTO;
            rptMensajesInternos.DataBind();

            cargarAviso();

            cargarServicio();

            IList<YouCom.DTO.AccesoHogar.AccesoHogarDTO> myAccesoHogar = new List<YouCom.DTO.AccesoHogar.AccesoHogarDTO>();

            myAccesoHogar = YouCom.bll.AccesoHogar.AccesoHogarBLL.getListadoAccesoHogarByCasa(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad, myUsuario.TheFamiliaDTO.TheCasaDTO.IdCasa);

            if(myAccesoHogar.Any())
            {
                rptAutorizaciones.DataSource = myAccesoHogar.Take(5);
                rptAutorizaciones.DataBind();
            }

            IList<YouCom.DTO.DirectivaDTO> myDirectiva = new List<YouCom.DTO.DirectivaDTO>();

            myDirectiva = YouCom.bll.DirectivaBLL.getListadoDirectivaByCondominioByComunidad(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad);

            if(myDirectiva.Any())
            {
                rptContacto.DataSource = myDirectiva.Where(x => x.TheCargoDTO.IdCargo == 1).ToList();
                rptContacto.DataBind();
            }
        }
    }

    protected void cargarServicio()
    {
        IList<YouCom.DTO.Servicio.ServiciosDTO> myServicioDTO = new List<YouCom.DTO.Servicio.ServiciosDTO>();

        myServicioDTO = YouCom.bll.ServiciosBLL.getListadoServiciosByCondominioByComunidad(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad);
        
        rptServicio.DataSource = myServicioDTO.Take(5);
        rptServicio.DataBind();
    }

    protected void cargarAviso()
    {
        IList<YouCom.DTO.Avisos.AvisoDTO> myAvisosDTO = new List<YouCom.DTO.Avisos.AvisoDTO>();

        myAvisosDTO = YouCom.bll.Avisos.AvisoBLL.getListadoAvisoByCondominioByComunidadVigentes(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad);

        rptAviso.DataSource = myAvisosDTO.Take(5);
        rptAviso.DataBind();

        Session.Remove("CategoriaAviso");
    }

    protected void cargarGastosComunes()
    {
        IList<YouCom.DTO.GastosComunes.GastoComunDTO> myGastosComunes = new List<YouCom.DTO.GastosComunes.GastoComunDTO>();
        YouCom.DTO.GastosComunes.GastoComunDTO theGastosComunes = new YouCom.DTO.GastosComunes.GastoComunDTO();

        myGastosComunes = YouCom.bll.GastosComunes.GastoComunBLL.getListadoEventoByCasa(myUsuario.TheCondominioSeleccionDTO.IdCondominio, myUsuario.TheComunidadSeleccionDTO.IdComunidad, myUsuario.TheFamiliaDTO.TheCasaDTO.IdCasa);

        if(myGastosComunes.Any())
        {
            theGastosComunes = myGastosComunes.Where(x => x.TheGastoComunEstadoDTO.IdGastoComunEstado == 1).OrderByDescending(x => x.FechaGasto).First();

            litMontoPendiente.Text = YouCom.Service.Generales.Formato.FormatoMontoPesoSinReplace(theGastosComunes.MontoGasto.ToString(), true);
            litFechaVencimiento.Text = theGastosComunes.FechaGasto.ToShortDateString();
        }
        
    }

    protected void cargarCategorias()
    {
        IList<YouCom.DTO.CategoriaDTO> collCategoria = new List<YouCom.DTO.CategoriaDTO>();

        collCategoria = YouCom.bll.CategoriaBLL.getListadoCategoria().Where(x => x.TheTipoCategoriaDTO.IdTipoCategoria == 12).ToList();

        ddlCategoria.DataSource = collCategoria;
        ddlCategoria.DataTextField = "NombreCategoria";
        ddlCategoria.DataValueField = "IdCategoria";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, new ListItem("Seleccione Categoría", string.Empty));

        ddlBuscadorCategoria.DataSource = collCategoria;
        ddlBuscadorCategoria.DataTextField = "NombreCategoria";
        ddlBuscadorCategoria.DataValueField = "IdCategoria";
        ddlBuscadorCategoria.DataBind();
        ddlBuscadorCategoria.Items.Insert(0, new ListItem("Seleccione Categoría", string.Empty));
    }

    protected void rptAutorizaciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.AccesoHogar.AccesoHogarDTO)e.Item.DataItem).IdAccesoHogar.ToString()))
                {

                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptAviso_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                Image img = (Image)e.Item.FindControl("imgLogo");

                if (!string.IsNullOrEmpty(((YouCom.DTO.Avisos.AvisoDTO)e.Item.DataItem).ImagenAviso) && ((YouCom.DTO.Avisos.AvisoDTO)e.Item.DataItem).ImagenAviso.Trim() != "")
                {
                    img.ImageUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathAvisoPub") + ((YouCom.DTO.Avisos.AvisoDTO)e.Item.DataItem).ImagenAviso;
                    img.AlternateText = ((YouCom.DTO.Avisos.AvisoDTO)e.Item.DataItem).TituloAviso;
                    img.ToolTip = ((YouCom.DTO.Avisos.AvisoDTO)e.Item.DataItem).TituloAviso;
                }
                else
                {
                    img.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    void SelView(Int32 nIndex)
    {
        this.mvwMensaje.ActiveViewIndex = nIndex;
    }


    protected void rptRespuestas_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                Literal myLitQuienEnvia = new Literal();
                myLitQuienEnvia = (Literal)e.Item.FindControl("LitQuienEnvia");

                HiddenField myHdnQuienEnvia = new HiddenField();
                myHdnQuienEnvia = (HiddenField)e.Item.Parent.Parent.FindControl("hdnQuienEnvia");

                if (myHdnQuienEnvia.Value == "Noticia")
                {
                    myLitQuienEnvia.Text = ((YouCom.DTO.Mensajeria.MensajeNoticiaDTO)e.Item.DataItem).TheFamiliaDestinoDTO.NombreCompleto + " (" + ((YouCom.DTO.Mensajeria.MensajeNoticiaDTO)e.Item.DataItem).TheCondominioDTO.NombreCondominio + ")";
                }
                else if (myHdnQuienEnvia.Value == "Directiva")
                {
                    myLitQuienEnvia.Text = ((YouCom.DTO.Mensajeria.MensajeDirectivaDTO)e.Item.DataItem).TheFamiliaDTO.NombreCompleto + " (" + ((YouCom.DTO.Mensajeria.MensajeDirectivaDTO)e.Item.DataItem).TheCondominioDTO.NombreCondominio + ")";
                }
                else if (myHdnQuienEnvia.Value == "Porteria")
                {
                    myLitQuienEnvia.Text = ((YouCom.DTO.Mensajeria.MensajePorteriaDTO)e.Item.DataItem).TheFamiliaDTO.NombreCompleto + " (" + ((YouCom.DTO.Mensajeria.MensajePorteriaDTO)e.Item.DataItem).TheCondominioDTO.NombreCondominio + ")";
                }
                else if (myHdnQuienEnvia.Value == "Propietario")
                {
                    myLitQuienEnvia.Text = ((YouCom.DTO.Mensajeria.MensajePropietarioDTO)e.Item.DataItem).TheFamiliaDestinoDTO.NombreCompleto + " (" + ((YouCom.DTO.Mensajeria.MensajePropietarioDTO)e.Item.DataItem).TheCondominioDTO.NombreCondominio + ")";
                }
            }
        }
        catch (Exception ex)
        { }
    }

    protected void rptMensajes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje.ToString()))
                {
                    string ruta = string.Empty;

                    Image imgCategoria = (Image)e.Item.FindControl("imgCategoria");

                    //HtmlGenericControl div_contenedor = new HtmlGenericControl();
                    //div_contenedor = (HtmlGenericControl)e.Item.FindControl("div_contenedor");

                    if(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCategoriaDTO.IdCategoria == 25)
                    {
                        //div_contenedor.Attributes.Add("style", "border-style:solid;border-width:5px; border-color:red; ");

                        ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathMensajePub");

                        imgCategoria.ImageUrl = "~/images/seguridad.jpg";
                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCategoriaDTO.IdCategoria == 26)
                    {
                        imgCategoria.ImageUrl = "~/images/avisos.jpg";

                        //div_contenedor.Attributes.Add("style", "border-style:solid;border-width:5px; border-color:blue; ");

                        ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathMensajePub");
                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCategoriaDTO.IdCategoria == 27)
                    {
                        //div_contenedor.Attributes.Add("style", "border-style:solid;border-width:5px; border-color:yellow; ");

                        imgCategoria.ImageUrl = "~/images/General.jpg";

                        ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathMensajePub");
                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCategoriaDTO.IdCategoria == 13)
                    {
                        //div_contenedor.Attributes.Add("style", "border-style:solid;border-width:5px; border-color:gray; ");

                        ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathNoticiaPub");
                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCategoriaDTO.IdCategoria == 14)
                    {
                        //div_contenedor.Attributes.Add("style", "border-style:solid;border-width:5px; border-color:gray; ");

                        ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathNoticiaPub");
                    }


                    Literal myLitQuienEnvia = new Literal();
                    myLitQuienEnvia = (Literal)e.Item.FindControl("LitQuienEnvia");

                    Literal myLitMensajeDescripcion = new Literal();
                    myLitMensajeDescripcion = (Literal)e.Item.FindControl("LitMensajeDescripcion");

                    LinkButton myLnkBtnVerMas = (LinkButton)e.Item.FindControl("LnkBtnVerMas");

                    LinkButton myLnkBtnVer = (LinkButton)e.Item.FindControl("LnkBtnVer");
                    LinkButton myLnkBtnMeGusta = (LinkButton)e.Item.FindControl("LnkBtnMeGusta");
                    LinkButton myLnkBtnNoMeGusta = (LinkButton)e.Item.FindControl("LnkBtnNoMeGusta");

                    if(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).MensajeDescripcion.Length < 200)
                    {
                        myLitMensajeDescripcion.Text = ((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).MensajeDescripcion;
                        myLnkBtnVerMas.Visible = false;
                    }
                    else
                    {
                        myLitMensajeDescripcion.Text = YouCom.Service.Generales.General.truncaTitulo(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).MensajeDescripcion, 200);
                        myLnkBtnVerMas.Visible = true;
                    }

                    myLnkBtnVerMas.Visible = true;

                    Literal myLitTiempo = (Literal)e.Item.FindControl("LitTiempo");

                    Image img = (Image)e.Item.FindControl("imgMensaje");

                    System.TimeSpan diffResultFecha = DateTime.Now - ((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).MensajeFecha;


                    if (diffResultFecha.Days > 0)
                    {
                        myLitTiempo.Text = "Hace " + diffResultFecha.Days + " días y " + diffResultFecha.Hours + " horas y " + diffResultFecha.Minutes + " minutos";
                    }
                    else
                    {
                        if (diffResultFecha.Hours > 0)
                        {
                            myLitTiempo.Text = "Hace " + diffResultFecha.Hours + " horas y " + diffResultFecha.Minutes + " minutos";
                        }
                        else
                        {
                            myLitTiempo.Text = "Hace " + diffResultFecha.Minutes + " minutos";
                        }
                    }

                    if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheMensajeTipoDTO.NombreMensajeTipo == "Noticia")
                    {
                        IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO> collImagenMensajeNoticiaDTO = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO>();

                        collImagenMensajeNoticiaDTO = YouCom.bll.Mensajeria.Imagen.ImagenMensajeNoticiaBLL.getListadoImagenMensajeNoticiaByIdMensaje(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);

                        if (collImagenMensajeNoticiaDTO.Any())
                        {
                            if(collImagenMensajeNoticiaDTO.Count > 1)
                            {
                                myLnkBtnVerMas.Visible = true;
                            }

                            if (!string.IsNullOrEmpty(collImagenMensajeNoticiaDTO.First().GrandeImagenMensajeNoticia) && collImagenMensajeNoticiaDTO.First().GrandeImagenMensajeNoticia.Trim() != "")
                            {
                                img.ImageUrl = ruta + collImagenMensajeNoticiaDTO.First().GrandeImagenMensajeNoticia;
                                img.AlternateText = collImagenMensajeNoticiaDTO.First().TituloImagenMensajeNoticia;
                                img.ToolTip = collImagenMensajeNoticiaDTO.First().TituloImagenMensajeNoticia;
                            }
                            else
                            {
                                img.Visible = false;
                            }
                        }

                        IList<YouCom.DTO.Mensajeria.MensajeNoticiaDTO> myMensajeNoticiaDTO = new List<YouCom.DTO.Mensajeria.MensajeNoticiaDTO>();
                        myMensajeNoticiaDTO = YouCom.bll.Mensajeria.MensajeNoticiaBLL.getListadoMensajeNoticiaByPadre(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);
                        myLnkBtnVer.Text = "<span class=\"glyphicon glyphicon-comment\"></span> (" + myMensajeNoticiaDTO.Count().ToString() + ")";

                        IList<YouCom.DTO.Mensajeria.EleccionNoticiaDTO> myEleccionNoticiaDTO = new List<YouCom.DTO.Mensajeria.EleccionNoticiaDTO>();
                        myEleccionNoticiaDTO = YouCom.bll.Mensajeria.EleccionNoticiaBLL.getListadoEleccionNoticiaByIdNoticia(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);

                        if (myEleccionNoticiaDTO.Count > 0)
                        {
                            myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (" + myEleccionNoticiaDTO.Where(x => x.EleccionNoticiaMeGusta == "SI").Count() + ")";
                            myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> " + myEleccionNoticiaDTO.Where(x => x.EleccionNoticiaMeGusta == "NO").Count() + ")";
                        }
                        else
                        {
                            myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (0)";
                            myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> (0)";
                        }

                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheMensajeTipoDTO.NombreMensajeTipo == "Propietario")
                    {
                        IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO> collImagenMensajePropietarioDTO = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO>();

                        collImagenMensajePropietarioDTO = YouCom.bll.Mensajeria.Imagen.ImagenMensajePropietarioBLL.getListadoImagenMensajePropietarioByIdMensaje(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);

                        if (collImagenMensajePropietarioDTO.Any())
                        {
                            if (collImagenMensajePropietarioDTO.Count > 1)
                            {
                                myLnkBtnVerMas.Visible = true;
                            }

                            if (!string.IsNullOrEmpty(collImagenMensajePropietarioDTO.First().GrandeImagenMensajePropietario) && collImagenMensajePropietarioDTO.First().GrandeImagenMensajePropietario.Trim() != "")
                            {
                                img.ImageUrl = ruta + collImagenMensajePropietarioDTO.First().GrandeImagenMensajePropietario;
                                img.AlternateText = collImagenMensajePropietarioDTO.First().TituloImagenMensajePropietario;
                                img.ToolTip = collImagenMensajePropietarioDTO.First().TituloImagenMensajePropietario;
                            }
                            else
                            {
                                img.Visible = false;
                            }
                        }

                        myLitQuienEnvia.Text = ((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheFamiliaDTO.NombreCompleto + " (" + ((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCondominioDTO.NombreCondominio + ")";

                        IList<YouCom.DTO.Mensajeria.MensajePropietarioDTO> myMensajePropietarioDTO = new List<YouCom.DTO.Mensajeria.MensajePropietarioDTO>();
                        myMensajePropietarioDTO = YouCom.bll.Mensajeria.MensajePropietarioBLL.getListadoMensajePropietarioByPadre(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);
                        myLnkBtnVer.Text = "<span class=\"glyphicon glyphicon-comment\"></span> (" + myMensajePropietarioDTO.Count().ToString() + ")";

                        IList<YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO> myEleccionMensajePropietarioDTO = new List<YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO>();
                        myEleccionMensajePropietarioDTO = YouCom.bll.Mensajeria.EleccionMensajePropietarioBLL.getListadoEleccionMensajePropietarioByIdMensaje(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);
                        
                        if(myEleccionMensajePropietarioDTO.Count > 0)
                        {
                            myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (" + myEleccionMensajePropietarioDTO.Where(x => x.EleccionMensajePropietarioMeGusta == "SI").Count() + ")";
                            myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> " + myEleccionMensajePropietarioDTO.Where(x => x.EleccionMensajePropietarioMeGusta == "NO").Count() + ")";
                        }
                        else
                        {
                            myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (0)";
                            myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> (0)";
                        }

                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheMensajeTipoDTO.NombreMensajeTipo == "Porteria")
                    {
                        IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO> collImagenMensajePorteriaDTO = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO>();

                        collImagenMensajePorteriaDTO = YouCom.bll.Mensajeria.Imagen.ImagenMensajePorteriaBLL.getListadoImagenMensajePorteriaByIdMensaje(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);

                        if (collImagenMensajePorteriaDTO.Any())
                        {
                            if (collImagenMensajePorteriaDTO.Count > 1)
                            {
                                myLnkBtnVerMas.Visible = true;
                            }

                            if (!string.IsNullOrEmpty(collImagenMensajePorteriaDTO.First().GrandeImagenMensajePorteria) && collImagenMensajePorteriaDTO.First().GrandeImagenMensajePorteria.Trim() != "")
                            {
                                img.ImageUrl = ruta + collImagenMensajePorteriaDTO.First().GrandeImagenMensajePorteria;
                                img.AlternateText = collImagenMensajePorteriaDTO.First().TituloImagenMensajePorteria;
                                img.ToolTip = collImagenMensajePorteriaDTO.First().TituloImagenMensajePorteria;
                            }
                            else
                            {
                                img.Visible = false;
                            }
                        }

                        myLitQuienEnvia.Text = ((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).ThePorteriaDTO.NombreCompleto + " (" + ((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCondominioDTO.NombreCondominio + ")";

                        IList<YouCom.DTO.Mensajeria.MensajePorteriaDTO> myMensajePorteriaDTO = new List<YouCom.DTO.Mensajeria.MensajePorteriaDTO>();
                        myMensajePorteriaDTO = YouCom.bll.Mensajeria.MensajePorteriaBLL.getListadoMensajePorteriaByPadre(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);
                        myLnkBtnVer.Text = "<span class=\"glyphicon glyphicon-comment\"></span> (" + myMensajePorteriaDTO.Count().ToString() + ")";

                        IList<YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO> myEleccionMensajePorteriaDTO = new List<YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO>();
                        myEleccionMensajePorteriaDTO = YouCom.bll.Mensajeria.EleccionMensajePorteriaBLL.getListadoEleccionMensajePorteriaByIdMensaje(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);

                        if (myEleccionMensajePorteriaDTO.Count > 0)
                        {
                            myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (" + myEleccionMensajePorteriaDTO.Where(x => x.EleccionMensajePorteriaMeGusta == "SI").Count() + ")";
                            myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> " + myEleccionMensajePorteriaDTO.Where(x => x.EleccionMensajePorteriaMeGusta == "NO").Count() + ")";
                        }
                        else
                        {
                            myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (0)";
                            myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> (0)";
                        }
                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheMensajeTipoDTO.NombreMensajeTipo == "Administración")
                    {
                        IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO> collImagenMensajeDirectivaDTO = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO>();

                        collImagenMensajeDirectivaDTO = YouCom.bll.Mensajeria.Imagen.ImagenMensajeDirectivaBLL.getListadoImagenMensajeDirectivaByIdMensaje(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);

                        if (collImagenMensajeDirectivaDTO.Any())
                        {
                            if (collImagenMensajeDirectivaDTO.Count > 1)
                            {
                                myLnkBtnVerMas.Visible = true;
                            }

                            if (!string.IsNullOrEmpty(collImagenMensajeDirectivaDTO.First().GrandeImagenMensajeDirectiva) && collImagenMensajeDirectivaDTO.First().GrandeImagenMensajeDirectiva.Trim() != "")
                            {
                                img.ImageUrl = ruta + collImagenMensajeDirectivaDTO.First().GrandeImagenMensajeDirectiva;
                                img.AlternateText = collImagenMensajeDirectivaDTO.First().TituloImagenMensajeDirectiva;
                                img.ToolTip = collImagenMensajeDirectivaDTO.First().TituloImagenMensajeDirectiva;
                            }
                            else
                            {
                                img.Visible = false;
                            }
                        }

                        myLitQuienEnvia.Text = ((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheDirectivaDTO.NombreCompleto + " (" + ((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCondominioDTO.NombreCondominio + ")";

                        IList<YouCom.DTO.Mensajeria.MensajeDirectivaDTO> myMensajeDirectivaDTO = new List<YouCom.DTO.Mensajeria.MensajeDirectivaDTO>();
                        myMensajeDirectivaDTO = YouCom.bll.Mensajeria.MensajeDirectivaBLL.getListadoMensajeDirectivaByPadre(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);
                        myLnkBtnVer.Text = "<span class=\"glyphicon glyphicon-eye-open\"></span> (" + myMensajeDirectivaDTO.Count().ToString() + ")";

                        IList<YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO> myEleccionMensajeDirectivaDTO = new List<YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO>();
                        myEleccionMensajeDirectivaDTO = YouCom.bll.Mensajeria.EleccionMensajeDirectivaBLL.getListadoEleccionMensajeDirectivaByIdMensaje(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);

                        if (myEleccionMensajeDirectivaDTO.Count > 0)
                        {
                            myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (" + myEleccionMensajeDirectivaDTO.Where(x => x.EleccionMensajeDirectivaMeGusta == "SI").Count() + ")";
                            myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> " + myEleccionMensajeDirectivaDTO.Where(x => x.EleccionMensajeDirectivaMeGusta == "NO").Count() + ")";
                        }
                        else
                        {
                            myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (0)";
                            myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> (0)";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptMensajes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            HiddenField myHdnIdMensaje = (HiddenField)e.Item.FindControl("hdnIdMensaje");
            HiddenField myHdnQuienEnvia = (HiddenField)e.Item.FindControl("hdnQuienEnvia");
            
            TextBox myTxtMensaje = (TextBox)e.Item.FindControl("txtMensaje");
            
            Repeater myRptRespuestas = (Repeater)e.Item.FindControl("rptRespuestas");
            
            LinkButton myLnkBtnMeGusta = (LinkButton)e.Item.FindControl("LnkBtnMeGusta");
            LinkButton myLnkBtnNoMeGusta = (LinkButton)e.Item.FindControl("LnkBtnNoMeGusta");
            LinkButton myLnkBtnAgregarComentario = (LinkButton)e.Item.FindControl("LnkBtnAgregarComentario");
            
            Panel PnlResultado = (Panel)e.Item.FindControl("pnlResultado");
            Panel PnlComentar = (Panel)e.Item.FindControl("pnlComentar");
            Panel pnlMensajes = (Panel)e.Item.FindControl("pnlMensajes");

            Literal LitMensaje = (Literal)e.Item.FindControl("litMensaje");

            if (e.CommandName.Equals("EnviarComentario"))
            {
                if (myHdnQuienEnvia.Value == "Noticia")
                {
                    YouCom.DTO.Mensajeria.MensajeNoticiaDTO theMensajeNoticiaDTO = new YouCom.DTO.Mensajeria.MensajeNoticiaDTO();
                    YouCom.DTO.NoticiaDTO myNoticiaDTO = new YouCom.DTO.NoticiaDTO();
                    YouCom.DTO.Mensajeria.MensajeNoticiaDTO myMensajeNoticiaDTO = new YouCom.DTO.Mensajeria.MensajeNoticiaDTO();

                    myMensajeNoticiaDTO = YouCom.bll.Mensajeria.MensajeNoticiaBLL.detalleMensajeNoticia(decimal.Parse(myHdnIdMensaje.Value));
                    myNoticiaDTO = YouCom.bll.NoticiaBLL.detalleNoticia(decimal.Parse(myHdnIdMensaje.Value));

                    theMensajeNoticiaDTO.MensajeTitulo = myNoticiaDTO.NotiTitulo;
                    theMensajeNoticiaDTO.MensajeDescripcion = myTxtMensaje.Text;
                    theMensajeNoticiaDTO.MensajeFecha = DateTime.Now;

                    theMensajeNoticiaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theMensajeNoticiaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theMensajeNoticiaDTO.TheCategoriaDTO = myNoticiaDTO.TheCategoriaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                    theMensajeNoticiaDTO.TheFamiliaDestinoDTO = myFamiliaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaOrigenDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    theMensajeNoticiaDTO.TheFamiliaOrigenDTO = myFamiliaOrigenDTO;

                    theMensajeNoticiaDTO.IdPadre = decimal.Parse(myHdnIdMensaje.Value);

                    theMensajeNoticiaDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Mensajeria.MensajeNoticiaBLL.Insert(theMensajeNoticiaDTO);

                    #region Insertar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionNoticiaDTO theNotificacionNoticiaDTO = new YouCom.DTO.Notificaciones.NotificacionNoticiaDTO();
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    theNotificacionNoticiaDTO.FechaNotificacion = DateTime.Now;

                    theNotificacionNoticiaDTO.VerNotificacion = "NO";

                    theNotificacionNoticiaDTO.TheMensajeNoticiaDTO = theMensajeNoticiaDTO;

                    theNotificacionAccionDTO.IdNotificacionAccion = 1;
                    theNotificacionNoticiaDTO.TheNotificacionAccionDTO = theNotificacionAccionDTO;

                    theNotificacionNoticiaDTO.TheFamiliaCreadorDTO = theMensajeNoticiaDTO.TheFamiliaOrigenDTO;

                    theNotificacionNoticiaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theNotificacionNoticiaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theNotificacionNoticiaDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionNoticiaBLL.Insert(theNotificacionNoticiaDTO);

                    #endregion Inserta Notificacion

                }
                else if (myHdnQuienEnvia.Value == "Propietario")
                {
                    YouCom.DTO.Mensajeria.MensajePropietarioDTO theMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();
                    YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();

                    myMensajePropietarioDTO = YouCom.bll.Mensajeria.MensajePropietarioBLL.detalleMensajePropietario(decimal.Parse(myHdnIdMensaje.Value));

                    theMensajePropietarioDTO.MensajeTitulo = myMensajePropietarioDTO.MensajeTitulo;
                    theMensajePropietarioDTO.MensajeDescripcion = myTxtMensaje.Text;
                    theMensajePropietarioDTO.MensajeFecha = DateTime.Now;

                    theMensajePropietarioDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theMensajePropietarioDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theMensajePropietarioDTO.TheCategoriaDTO = myMensajePropietarioDTO.TheCategoriaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                    theMensajePropietarioDTO.TheFamiliaDestinoDTO = myFamiliaDTO;

                    theMensajePropietarioDTO.TheFamiliaOrigenDTO = myMensajePropietarioDTO.TheFamiliaOrigenDTO;

                    theMensajePropietarioDTO.IdPadre = myMensajePropietarioDTO.IdMensajePropietario;

                    theMensajePropietarioDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Mensajeria.MensajePropietarioBLL.Insert(theMensajePropietarioDTO);

                    #region Insertar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionPropietarioDTO theNotificacionPropietarioDTO = new YouCom.DTO.Notificaciones.NotificacionPropietarioDTO();
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    theNotificacionPropietarioDTO.FechaNotificacion = DateTime.Now;

                    theNotificacionPropietarioDTO.VerNotificacion = "NO";

                    theNotificacionPropietarioDTO.TheMensajePropietarioDTO = myMensajePropietarioDTO;

                    theNotificacionAccionDTO.IdNotificacionAccion = 1;
                    theNotificacionPropietarioDTO.TheNotificacionAccionDTO = theNotificacionAccionDTO;

                    theNotificacionPropietarioDTO.TheFamiliaCreadorDTO = theMensajePropietarioDTO.TheFamiliaOrigenDTO;
                    theNotificacionPropietarioDTO.TheFamiliaDestinoDTO = theMensajePropietarioDTO.TheFamiliaDestinoDTO;

                    theNotificacionPropietarioDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theNotificacionPropietarioDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theNotificacionPropietarioDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionPropietarioBLL.Insert(theNotificacionPropietarioDTO);

                    #endregion Inserta Notificacion
                }
                else if (myHdnQuienEnvia.Value == "Porteria")
                {
                    YouCom.DTO.Mensajeria.MensajePorteriaDTO theMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();
                    YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();

                    myMensajePorteriaDTO = YouCom.bll.Mensajeria.MensajePorteriaBLL.detalleMensajePorteria(decimal.Parse(myHdnIdMensaje.Value));

                    theMensajePorteriaDTO.MensajeTitulo = myMensajePorteriaDTO.MensajeTitulo;
                    theMensajePorteriaDTO.MensajeDescripcion = myTxtMensaje.Text;
                    theMensajePorteriaDTO.MensajeFecha = DateTime.Now;

                    theMensajePorteriaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theMensajePorteriaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theMensajePorteriaDTO.TheCategoriaDTO = myMensajePorteriaDTO.TheCategoriaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                    theMensajePorteriaDTO.TheFamiliaDTO = myFamiliaDTO;

                    theMensajePorteriaDTO.IdPadre = myMensajePorteriaDTO.IdMensajePorteria;

                    theMensajePorteriaDTO.ThePorteriaDTO = myMensajePorteriaDTO.ThePorteriaDTO;

                    theMensajePorteriaDTO.TheMensajeTipoEnvioDTO = myMensajePorteriaDTO.TheMensajeTipoEnvioDTO;

                    theMensajePorteriaDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Mensajeria.MensajePorteriaBLL.Insert(theMensajePorteriaDTO);

                    #region Insertar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionPorteriaDTO theNotificacionPorteriaDTO = new YouCom.DTO.Notificaciones.NotificacionPorteriaDTO();
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    theNotificacionPorteriaDTO.FechaNotificacion = DateTime.Now;

                    theNotificacionPorteriaDTO.VerNotificacion = "NO";

                    theNotificacionPorteriaDTO.TheMensajePorteriaDTO = myMensajePorteriaDTO;

                    theNotificacionAccionDTO.IdNotificacionAccion = 1;
                    theNotificacionPorteriaDTO.TheNotificacionAccionDTO = theNotificacionAccionDTO;

                    theNotificacionPorteriaDTO.ThePorteriaDTO = theMensajePorteriaDTO.ThePorteriaDTO;

                    theNotificacionPorteriaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theNotificacionPorteriaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theNotificacionPorteriaDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionPorteriaBLL.Insert(theNotificacionPorteriaDTO);

                    #endregion Inserta Notificacion
                }
                else if (myHdnQuienEnvia.Value == "Administración")
                {
                    YouCom.DTO.Mensajeria.MensajeDirectivaDTO theMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();
                    YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();

                    myMensajeDirectivaDTO = YouCom.bll.Mensajeria.MensajeDirectivaBLL.detalleMensajeDirectiva(decimal.Parse(myHdnIdMensaje.Value));

                    theMensajeDirectivaDTO.MensajeTitulo = myMensajeDirectivaDTO.MensajeTitulo;
                    theMensajeDirectivaDTO.MensajeDescripcion = myTxtMensaje.Text;
                    theMensajeDirectivaDTO.MensajeFecha = DateTime.Now;

                    theMensajeDirectivaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theMensajeDirectivaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theMensajeDirectivaDTO.TheCategoriaDTO = myMensajeDirectivaDTO.TheCategoriaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                    theMensajeDirectivaDTO.TheFamiliaDTO = myFamiliaDTO;

                    theMensajeDirectivaDTO.TheDirectivaDTO = myMensajeDirectivaDTO.TheDirectivaDTO;

                    theMensajeDirectivaDTO.IdPadre = myMensajeDirectivaDTO.IdMensajeDirectiva;

                    theMensajeDirectivaDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Mensajeria.MensajeDirectivaBLL.Insert(theMensajeDirectivaDTO);

                    #region Insertar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionDirectivaDTO theNotificacionDirectivaDTO = new YouCom.DTO.Notificaciones.NotificacionDirectivaDTO();
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    theNotificacionDirectivaDTO.FechaNotificacion = DateTime.Now;

                    theNotificacionDirectivaDTO.VerNotificacion = "NO";

                    theNotificacionDirectivaDTO.TheMensajeDirectivaDTO = myMensajeDirectivaDTO;

                    theNotificacionAccionDTO.IdNotificacionAccion = 1;
                    theNotificacionDirectivaDTO.TheNotificacionAccionDTO = theNotificacionAccionDTO;

                    theNotificacionDirectivaDTO.TheDirectivaDTO = theMensajeDirectivaDTO.TheDirectivaDTO;

                    theNotificacionDirectivaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theNotificacionDirectivaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theNotificacionDirectivaDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionDirectivaBLL.Insert(theNotificacionDirectivaDTO);

                    #endregion Inserta Notificacion
                }

                PnlComentar.Visible = false;
                PnlResultado.Visible = true;
                myTxtMensaje.Text = string.Empty;

                LitMensaje.Text = "<strong>Estimado Usuario,</strong> El comentario ha sido enviado correctamente.";

                getVerComentarios(decimal.Parse(myHdnIdMensaje.Value), myHdnQuienEnvia.Value, pnlMensajes, myRptRespuestas, myLnkBtnAgregarComentario, true);
            }

            if (e.CommandName.Equals("AgregarComentario"))
            {
                if(PnlComentar.Visible)
                {
                    PnlResultado.Visible = false;
                    PnlComentar.Visible = false;
                    myLnkBtnAgregarComentario.Text = "<span class=\"glyphicon glyphicon-pencil\"></span> Agregar Comentario";
                }
                else
                {
                    PnlResultado.Visible = false;
                    PnlComentar.Visible = true;
                    myLnkBtnAgregarComentario.Text = "<span class=\"glyphicon glyphicon-pencil\"></span> Ocultar Comentario";
                }
            }
            if(e.CommandName.Equals("VerDescripcion"))
            {
                Panel myPnlGaleriaImagenes = new Panel();
                myPnlGaleriaImagenes = (Panel)e.Item.FindControl("pnlGaleriaImagenes");

                Panel myPnlGaleriaVideos = new Panel();
                myPnlGaleriaVideos = (Panel)e.Item.FindControl("pnlGaleriaVideos");

                Repeater myRepeater = new Repeater();
                myRepeater = (Repeater)e.Item.FindControl("rptGaleriaImagenes");

                Repeater myRptGaleriaVideos = new Repeater();
                myRptGaleriaVideos = (Repeater)e.Item.FindControl("rptGaleriaVideos");

                Literal myLitMensajeDescripcion = new Literal();
                myLitMensajeDescripcion = (Literal)e.Item.FindControl("LitMensajeDescripcion");

                LinkButton myLnkBtnVerMas = (LinkButton)e.Item.FindControl("LnkBtnVerMas");

                if (myHdnQuienEnvia.Value == "Noticia")
                {
                    IList<YouCom.DTO.Mensajeria.Video.VideoMensajeNoticiaDTO> collVideoMensajeNoticiaDTO = new List<YouCom.DTO.Mensajeria.Video.VideoMensajeNoticiaDTO>();
                    IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO> collImagenMensajeNoticiaDTO = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO>();

                    collImagenMensajeNoticiaDTO = YouCom.bll.Mensajeria.Imagen.ImagenMensajeNoticiaBLL.getListadoImagenMensajeNoticiaByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (collImagenMensajeNoticiaDTO.Count >= 1)
                    {
                        myRepeater.DataSource = collImagenMensajeNoticiaDTO;
                        myRepeater.DataBind();

                        myPnlGaleriaImagenes.Visible = true;
                    }
                    else
                    {
                        myPnlGaleriaImagenes.Visible = false;
                    }

                    collVideoMensajeNoticiaDTO = YouCom.bll.Mensajeria.Video.VideoMensajeNoticiaBLL.getListadoVideoMensajeNoticiaByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (collVideoMensajeNoticiaDTO.Count >= 1)
                    {
                        myRptGaleriaVideos.DataSource = collVideoMensajeNoticiaDTO;
                        myRptGaleriaVideos.DataBind();

                        myPnlGaleriaVideos.Visible = true;
                    }
                    else
                    {
                        myPnlGaleriaVideos.Visible = false;
                    }

                    YouCom.DTO.Mensajeria.MensajeNoticiaDTO myMensajeNoticiaDTO = new YouCom.DTO.Mensajeria.MensajeNoticiaDTO();
                    myMensajeNoticiaDTO = YouCom.bll.Mensajeria.MensajeNoticiaBLL.detalleMensajeNoticia(decimal.Parse(myHdnIdMensaje.Value));

                    myLitMensajeDescripcion.Text = myMensajeNoticiaDTO.MensajeDescripcion;
                    myLnkBtnVerMas.Visible = false;


                }
                else if (myHdnQuienEnvia.Value == "Propietario")
                {
                    IList<YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO> collVideoMensajePropietarioDTO = new List<YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO>();
                    IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO> collImagenMensajePropietarioDTO = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO>();

                    collImagenMensajePropietarioDTO = YouCom.bll.Mensajeria.Imagen.ImagenMensajePropietarioBLL.getListadoImagenMensajePropietarioByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (collImagenMensajePropietarioDTO.Count >= 1)
                    {
                        myRepeater.DataSource = collImagenMensajePropietarioDTO;
                        myRepeater.DataBind();

                        myPnlGaleriaImagenes.Visible = true;
                    }
                    else
                    {
                        myPnlGaleriaImagenes.Visible = false;
                    }

                    collVideoMensajePropietarioDTO = YouCom.bll.Mensajeria.Video.VideoMensajePropietarioBLL.getListadoVideoMensajePropietarioByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (collVideoMensajePropietarioDTO.Count >= 1)
                    {
                        myRptGaleriaVideos.DataSource = collVideoMensajePropietarioDTO;
                        myRptGaleriaVideos.DataBind();

                        myPnlGaleriaVideos.Visible = true;
                    }
                    else
                    {
                        myPnlGaleriaVideos.Visible = false;
                    }

                    YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();
                    myMensajePropietarioDTO = YouCom.bll.Mensajeria.MensajePropietarioBLL.detalleMensajePropietario(decimal.Parse(myHdnIdMensaje.Value));

                    myLitMensajeDescripcion.Text = myMensajePropietarioDTO.MensajeDescripcion;
                    myLnkBtnVerMas.Visible = false;
                }
                else if (myHdnQuienEnvia.Value == "Porteria")
                {
                    IList<YouCom.DTO.Mensajeria.Video.VideoMensajePorteriaDTO> collVideoMensajePorteriaDTO = new List<YouCom.DTO.Mensajeria.Video.VideoMensajePorteriaDTO>();
                    IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO> collImagenMensajePorteriaDTO = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO>();

                    collImagenMensajePorteriaDTO = YouCom.bll.Mensajeria.Imagen.ImagenMensajePorteriaBLL.getListadoImagenMensajePorteriaByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (collImagenMensajePorteriaDTO.Count >= 1)
                    {
                        myRepeater.DataSource = collImagenMensajePorteriaDTO;
                        myRepeater.DataBind();

                        myPnlGaleriaImagenes.Visible = true;
                    }
                    else
                    {
                        myPnlGaleriaImagenes.Visible = false;
                    }

                    collVideoMensajePorteriaDTO = YouCom.bll.Mensajeria.Video.VideoMensajePorteriaBLL.getListadoVideoMensajePorteriaByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (collVideoMensajePorteriaDTO.Count >= 1)
                    {
                        myRptGaleriaVideos.DataSource = collVideoMensajePorteriaDTO;
                        myRptGaleriaVideos.DataBind();

                        myPnlGaleriaVideos.Visible = true;
                    }
                    else
                    {
                        myPnlGaleriaVideos.Visible = false;
                    }

                    YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();
                    myMensajePorteriaDTO = YouCom.bll.Mensajeria.MensajePorteriaBLL.detalleMensajePorteria(decimal.Parse(myHdnIdMensaje.Value));

                    myLitMensajeDescripcion.Text = myMensajePorteriaDTO.MensajeDescripcion;
                    myLnkBtnVerMas.Visible = false;
                }
                else if (myHdnQuienEnvia.Value == "Administración")
                {
                    IList<YouCom.DTO.Mensajeria.Video.VideoMensajeDirectivaDTO> collVideoMensajeDirectivaDTO = new List<YouCom.DTO.Mensajeria.Video.VideoMensajeDirectivaDTO>();
                    IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO> collImagenMensajeDirectivaDTO = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO>();

                    collImagenMensajeDirectivaDTO = YouCom.bll.Mensajeria.Imagen.ImagenMensajeDirectivaBLL.getListadoImagenMensajeDirectivaByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (collImagenMensajeDirectivaDTO.Count >= 1)
                    {
                        myRepeater.DataSource = collImagenMensajeDirectivaDTO;
                        myRepeater.DataBind();

                        myPnlGaleriaImagenes.Visible = true;
                    }
                    else
                    {
                        myPnlGaleriaImagenes.Visible = false;
                    }

                    collVideoMensajeDirectivaDTO = YouCom.bll.Mensajeria.Video.VideoMensajeDirectivaBLL.getListadoVideoMensajeDirectivaByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (collVideoMensajeDirectivaDTO.Count >= 1)
                    {
                        myRptGaleriaVideos.DataSource = collVideoMensajeDirectivaDTO;
                        myRptGaleriaVideos.DataBind();

                        myPnlGaleriaVideos.Visible = true;
                    }
                    else
                    {
                        myPnlGaleriaVideos.Visible = true;
                    }

                    YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();
                    myMensajeDirectivaDTO = YouCom.bll.Mensajeria.MensajeDirectivaBLL.detalleMensajeDirectiva(decimal.Parse(myHdnIdMensaje.Value));

                    myLitMensajeDescripcion.Text = myMensajeDirectivaDTO.MensajeDescripcion;
                    myLnkBtnVerMas.Visible = false;

                }
            }

            if (e.CommandName.Equals("VerComentarios"))
            {
                getVerComentarios(decimal.Parse(myHdnIdMensaje.Value), myHdnQuienEnvia.Value, pnlMensajes, myRptRespuestas, myLnkBtnAgregarComentario, false);
            }

            if (e.CommandName.Equals("MeGusta"))
            {
                if (myHdnQuienEnvia.Value == "Noticia")
                {
                    YouCom.DTO.Mensajeria.EleccionNoticiaDTO theEleccionNoticiaDTO = new YouCom.DTO.Mensajeria.EleccionNoticiaDTO();

                    YouCom.DTO.Mensajeria.MensajeNoticiaDTO theMensajeNoticiaDTO = new YouCom.DTO.Mensajeria.MensajeNoticiaDTO();

                    theMensajeNoticiaDTO = YouCom.bll.Mensajeria.MensajeNoticiaBLL.detalleMensajeNoticia(decimal.Parse(myHdnIdMensaje.Value));

                    YouCom.DTO.NoticiaDTO myNoticiaDTO = new YouCom.DTO.NoticiaDTO();
                    myNoticiaDTO.NoticiaId = decimal.Parse(myHdnIdMensaje.Value);
                    theEleccionNoticiaDTO.TheNoticiaDTO = myNoticiaDTO;

                    theEleccionNoticiaDTO.EleccionNoticiaMeGusta = "SI";
                    theEleccionNoticiaDTO.EleccionNoticiaFecha = DateTime.Now;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                    theEleccionNoticiaDTO.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.Mensajeria.EleccionNoticiaDTO theEleccionNoticiaDTO1 = new YouCom.DTO.Mensajeria.EleccionNoticiaDTO();

                    theEleccionNoticiaDTO1 = YouCom.bll.Mensajeria.EleccionNoticiaBLL.getListadoEleccionNoticiaByIdFamilia(decimal.Parse(myHdnIdMensaje.Value), myFamiliaDTO.IdFamilia);

                    if (theEleccionNoticiaDTO1 != null)
                    {
                        YouCom.bll.Mensajeria.EleccionNoticiaBLL.Delete(theEleccionNoticiaDTO);
                    }

                    YouCom.bll.Mensajeria.EleccionNoticiaBLL.Insert(theEleccionNoticiaDTO);

                    #region Insertar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionNoticiaDTO theNotificacionNoticiaDTO = new YouCom.DTO.Notificaciones.NotificacionNoticiaDTO();
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    theNotificacionNoticiaDTO.TheMensajeNoticiaDTO = theMensajeNoticiaDTO;

                    theNotificacionNoticiaDTO.VerNotificacion = "NO";

                    theNotificacionNoticiaDTO.FechaNotificacion = DateTime.Now;
                    
                    theNotificacionAccionDTO.IdNotificacionAccion = 2;
                    theNotificacionNoticiaDTO.TheNotificacionAccionDTO = theNotificacionAccionDTO;

                    theNotificacionNoticiaDTO.TheFamiliaDestinoDTO = theEleccionNoticiaDTO.TheFamiliaDTO;

                    theNotificacionNoticiaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theNotificacionNoticiaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theNotificacionNoticiaDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionNoticiaBLL.Insert(theNotificacionNoticiaDTO);

                    #endregion Inserta Notificacion

                    IList<YouCom.DTO.Mensajeria.EleccionNoticiaDTO> myEleccionNoticiaDTO = new List<YouCom.DTO.Mensajeria.EleccionNoticiaDTO>();
                    myEleccionNoticiaDTO = YouCom.bll.Mensajeria.EleccionNoticiaBLL.getListadoEleccionNoticiaByIdNoticia(decimal.Parse(myHdnIdMensaje.Value));

                    if (myEleccionNoticiaDTO.Count > 0)
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (" + myEleccionNoticiaDTO.Where(x => x.EleccionNoticiaMeGusta == "SI").Count() + ")";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> " + myEleccionNoticiaDTO.Where(x => x.EleccionNoticiaMeGusta == "NO").Count() + ")";
                    }
                    else
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (0)";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> (0)";
                    }
                }
                else if (myHdnQuienEnvia.Value == "Propietario")
                {
                    YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO theEleccionMensajePropietarioDTO = new YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO();

                    YouCom.DTO.Mensajeria.MensajePropietarioDTO theMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();

                    theMensajePropietarioDTO = YouCom.bll.Mensajeria.MensajePropietarioBLL.detalleMensajePropietario(decimal.Parse(myHdnIdMensaje.Value));

                    theEleccionMensajePropietarioDTO.TheMensajePropietarioDTO = theMensajePropietarioDTO;

                    theEleccionMensajePropietarioDTO.EleccionMensajePropietarioMeGusta = "SI";
                    theEleccionMensajePropietarioDTO.EleccionMensajePropietarioFecha = DateTime.Now;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                    theEleccionMensajePropietarioDTO.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO theEleccionMensajePropietarioDTO1 = new YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO();

                    theEleccionMensajePropietarioDTO1 = YouCom.bll.Mensajeria.EleccionMensajePropietarioBLL.getListadoEleccionMensajePropietarioByIdFamilia(decimal.Parse(myHdnIdMensaje.Value), myFamiliaDTO.IdFamilia);

                    if(theEleccionMensajePropietarioDTO1 != null)
                    {
                        YouCom.bll.Mensajeria.EleccionMensajePropietarioBLL.Delete(theEleccionMensajePropietarioDTO);
                    }

                    YouCom.bll.Mensajeria.EleccionMensajePropietarioBLL.Insert(theEleccionMensajePropietarioDTO);

                    #region Insertar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionPropietarioDTO theNotificacionPropietarioDTO = new YouCom.DTO.Notificaciones.NotificacionPropietarioDTO();
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    theNotificacionPropietarioDTO.TheMensajePropietarioDTO = theMensajePropietarioDTO;

                    theNotificacionPropietarioDTO.VerNotificacion = "NO";
                    theNotificacionPropietarioDTO.FechaNotificacion = DateTime.Now;

                    theNotificacionPropietarioDTO.TheFamiliaCreadorDTO = theMensajePropietarioDTO.TheFamiliaOrigenDTO;

                    theNotificacionAccionDTO.IdNotificacionAccion = 2;
                    theNotificacionPropietarioDTO.TheNotificacionAccionDTO = theNotificacionAccionDTO;

                    theNotificacionPropietarioDTO.TheFamiliaDestinoDTO = theEleccionMensajePropietarioDTO.TheFamiliaDTO;

                    theNotificacionPropietarioDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theNotificacionPropietarioDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theNotificacionPropietarioDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionPropietarioBLL.Insert(theNotificacionPropietarioDTO);

                    #endregion Inserta Notificacion

                    IList<YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO> myEleccionMensajePropietarioDTO = new List<YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO>();
                    myEleccionMensajePropietarioDTO = YouCom.bll.Mensajeria.EleccionMensajePropietarioBLL.getListadoEleccionMensajePropietarioByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (myEleccionMensajePropietarioDTO.Count > 0)
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (" + myEleccionMensajePropietarioDTO.Where(x => x.EleccionMensajePropietarioMeGusta == "SI").Count() + ")";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> " + myEleccionMensajePropietarioDTO.Where(x => x.EleccionMensajePropietarioMeGusta == "NO").Count() + ")";
                    }
                    else
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (0)";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> (0)";
                    }
                }
                else if (myHdnQuienEnvia.Value == "Porteria")
                {
                    YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO theEleccionMensajePorteriaDTO = new YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO();
                    YouCom.DTO.Mensajeria.MensajePorteriaDTO theMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();

                    theMensajePorteriaDTO = YouCom.bll.Mensajeria.MensajePorteriaBLL.detalleMensajePorteria(decimal.Parse(myHdnIdMensaje.Value));

                    theEleccionMensajePorteriaDTO.TheMensajePorteriaDTO = theMensajePorteriaDTO;

                    theEleccionMensajePorteriaDTO.EleccionMensajePorteriaMeGusta = "SI";
                    theEleccionMensajePorteriaDTO.EleccionMensajePorteriaFecha = DateTime.Now;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                    theEleccionMensajePorteriaDTO.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO theEleccionMensajePorteriaDTO1 = new YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO();

                    theEleccionMensajePorteriaDTO1 = YouCom.bll.Mensajeria.EleccionMensajePorteriaBLL.getListadoEleccionMensajePorteriaByIdFamilia(decimal.Parse(myHdnIdMensaje.Value), myFamiliaDTO.IdFamilia);

                    if (theEleccionMensajePorteriaDTO1 != null)
                    {
                        YouCom.bll.Mensajeria.EleccionMensajePorteriaBLL.Delete(theEleccionMensajePorteriaDTO);
                    }

                    YouCom.bll.Mensajeria.EleccionMensajePorteriaBLL.Insert(theEleccionMensajePorteriaDTO);

                    #region Insertar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionPorteriaDTO theNotificacionPorteriaDTO = new YouCom.DTO.Notificaciones.NotificacionPorteriaDTO();
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    theNotificacionPorteriaDTO.TheMensajePorteriaDTO = theMensajePorteriaDTO;

                    theNotificacionPorteriaDTO.VerNotificacion = "NO";
                    theNotificacionPorteriaDTO.FechaNotificacion = DateTime.Now;

                    theNotificacionPorteriaDTO.TheFamiliaDestinoDTO = theEleccionMensajePorteriaDTO.TheFamiliaDTO;

                    theNotificacionAccionDTO.IdNotificacionAccion = 1;
                    theNotificacionPorteriaDTO.TheNotificacionAccionDTO = theNotificacionAccionDTO;

                    theNotificacionPorteriaDTO.ThePorteriaDTO = theMensajePorteriaDTO.ThePorteriaDTO;

                    theNotificacionPorteriaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theNotificacionPorteriaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theNotificacionPorteriaDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionPorteriaBLL.Insert(theNotificacionPorteriaDTO);

                    #endregion Inserta Notificacion

                    IList<YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO> myEleccionMensajePorteriaDTO = new List<YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO>();
                    myEleccionMensajePorteriaDTO = YouCom.bll.Mensajeria.EleccionMensajePorteriaBLL.getListadoEleccionMensajePorteriaByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (myEleccionMensajePorteriaDTO.Count > 0)
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (" + myEleccionMensajePorteriaDTO.Where(x => x.EleccionMensajePorteriaMeGusta == "SI").Count() + ")";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> " + myEleccionMensajePorteriaDTO.Where(x => x.EleccionMensajePorteriaMeGusta == "NO").Count() + ")";
                    }
                    else
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (0)";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> (0)";
                    }
                }
                else if (myHdnQuienEnvia.Value == "Administración")
                {
                    YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO theEleccionMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO();

                    YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();
                    myMensajeDirectivaDTO = YouCom.bll.Mensajeria.MensajeDirectivaBLL.detalleMensajeDirectiva(decimal.Parse(myHdnIdMensaje.Value));

                    theEleccionMensajeDirectivaDTO.TheMensajeDirectivaDTO = myMensajeDirectivaDTO;

                    theEleccionMensajeDirectivaDTO.EleccionMensajeDirectivaMeGusta = "SI";
                    theEleccionMensajeDirectivaDTO.EleccionMensajeDirectivaFecha = DateTime.Now;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                    theEleccionMensajeDirectivaDTO.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO theEleccionMensajeDirectivaDTO1 = new YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO();

                    theEleccionMensajeDirectivaDTO1 = YouCom.bll.Mensajeria.EleccionMensajeDirectivaBLL.getListadoEleccionMensajeDirectivaByIdFamilia(decimal.Parse(myHdnIdMensaje.Value), myFamiliaDTO.IdFamilia);

                    if (theEleccionMensajeDirectivaDTO1 != null)
                    {
                        YouCom.bll.Mensajeria.EleccionMensajeDirectivaBLL.Delete(theEleccionMensajeDirectivaDTO);
                    }

                    YouCom.bll.Mensajeria.EleccionMensajeDirectivaBLL.Insert(theEleccionMensajeDirectivaDTO);

                    #region Insertar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionDirectivaDTO theNotificacionDirectivaDTO = new YouCom.DTO.Notificaciones.NotificacionDirectivaDTO();
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    theNotificacionDirectivaDTO.VerNotificacion = "NO";

                    theNotificacionDirectivaDTO.FechaNotificacion = DateTime.Now;

                    theNotificacionDirectivaDTO.TheMensajeDirectivaDTO = myMensajeDirectivaDTO;

                    theNotificacionAccionDTO.IdNotificacionAccion = 1;
                    theNotificacionDirectivaDTO.TheNotificacionAccionDTO = theNotificacionAccionDTO;

                    theNotificacionDirectivaDTO.TheDirectivaDTO = myMensajeDirectivaDTO.TheDirectivaDTO;

                    theNotificacionDirectivaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theNotificacionDirectivaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theNotificacionDirectivaDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionDirectivaBLL.Insert(theNotificacionDirectivaDTO);

                    #endregion Inserta Notificacion

                    IList<YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO> myEleccionMensajeDirectivaDTO = new List<YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO>();
                    myEleccionMensajeDirectivaDTO = YouCom.bll.Mensajeria.EleccionMensajeDirectivaBLL.getListadoEleccionMensajeDirectivaByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (myEleccionMensajeDirectivaDTO.Count > 0)
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (" + myEleccionMensajeDirectivaDTO.Where(x => x.EleccionMensajeDirectivaMeGusta == "SI").Count() + ")";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> " + myEleccionMensajeDirectivaDTO.Where(x => x.EleccionMensajeDirectivaMeGusta == "NO").Count() + ")";
                    }
                    else
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (0)";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> (0)";
                    }
                }
            }

            if (e.CommandName.Equals("NoMeGusta"))
            {
                if (myHdnQuienEnvia.Value == "Noticia")
                {
                    YouCom.DTO.Mensajeria.EleccionNoticiaDTO theEleccionNoticiaDTO = new YouCom.DTO.Mensajeria.EleccionNoticiaDTO();

                    YouCom.DTO.Mensajeria.MensajeNoticiaDTO theMensajeNoticiaDTO = new YouCom.DTO.Mensajeria.MensajeNoticiaDTO();

                    theMensajeNoticiaDTO = YouCom.bll.Mensajeria.MensajeNoticiaBLL.detalleMensajeNoticia(decimal.Parse(myHdnIdMensaje.Value));

                    YouCom.DTO.NoticiaDTO myNoticiaDTO = new YouCom.DTO.NoticiaDTO();
                    myNoticiaDTO.NoticiaId = decimal.Parse(myHdnIdMensaje.Value);
                    theEleccionNoticiaDTO.TheNoticiaDTO = myNoticiaDTO;

                    theEleccionNoticiaDTO.EleccionNoticiaMeGusta = "NO";
                    theEleccionNoticiaDTO.EleccionNoticiaFecha = DateTime.Now;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                    theEleccionNoticiaDTO.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.Mensajeria.EleccionNoticiaDTO theEleccionNoticiaDTO1 = new YouCom.DTO.Mensajeria.EleccionNoticiaDTO();

                    theEleccionNoticiaDTO1 = YouCom.bll.Mensajeria.EleccionNoticiaBLL.getListadoEleccionNoticiaByIdFamilia(decimal.Parse(myHdnIdMensaje.Value), myFamiliaDTO.IdFamilia);

                    if (theEleccionNoticiaDTO1 != null)
                    {
                        YouCom.bll.Mensajeria.EleccionNoticiaBLL.Delete(theEleccionNoticiaDTO);
                    }

                    YouCom.bll.Mensajeria.EleccionNoticiaBLL.Insert(theEleccionNoticiaDTO);

                    #region Insertar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionNoticiaDTO theNotificacionNoticiaDTO = new YouCom.DTO.Notificaciones.NotificacionNoticiaDTO();
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    theNotificacionNoticiaDTO.TheMensajeNoticiaDTO = theMensajeNoticiaDTO;

                    theNotificacionNoticiaDTO.VerNotificacion = "NO";

                    theNotificacionNoticiaDTO.FechaNotificacion = DateTime.Now;

                    theNotificacionAccionDTO.IdNotificacionAccion = 3;
                    theNotificacionNoticiaDTO.TheNotificacionAccionDTO = theNotificacionAccionDTO;

                    theNotificacionNoticiaDTO.TheFamiliaDestinoDTO = theEleccionNoticiaDTO.TheFamiliaDTO;

                    theNotificacionNoticiaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theNotificacionNoticiaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theNotificacionNoticiaDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionNoticiaBLL.Insert(theNotificacionNoticiaDTO);

                    #endregion Inserta Notificacion

                    IList<YouCom.DTO.Mensajeria.EleccionNoticiaDTO> myEleccionNoticiaDTO = new List<YouCom.DTO.Mensajeria.EleccionNoticiaDTO>();
                    myEleccionNoticiaDTO = YouCom.bll.Mensajeria.EleccionNoticiaBLL.getListadoEleccionNoticiaByIdNoticia(decimal.Parse(myHdnIdMensaje.Value));

                    if (myEleccionNoticiaDTO.Count > 0)
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (" + myEleccionNoticiaDTO.Where(x => x.EleccionNoticiaMeGusta == "SI").Count() + ")";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> " + myEleccionNoticiaDTO.Where(x => x.EleccionNoticiaMeGusta == "NO").Count() + ")";
                    }
                    else
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (0)";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> (0)";
                    }
                }
                else if (myHdnQuienEnvia.Value == "Propietario")
                {
                    YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO theEleccionMensajePropietarioDTO = new YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO();

                    YouCom.DTO.Mensajeria.MensajePropietarioDTO theMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();

                    theMensajePropietarioDTO = YouCom.bll.Mensajeria.MensajePropietarioBLL.detalleMensajePropietario(decimal.Parse(myHdnIdMensaje.Value));

                    theEleccionMensajePropietarioDTO.TheMensajePropietarioDTO = theMensajePropietarioDTO;

                    theEleccionMensajePropietarioDTO.EleccionMensajePropietarioMeGusta = "NO";
                    theEleccionMensajePropietarioDTO.EleccionMensajePropietarioFecha = DateTime.Now;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                    theEleccionMensajePropietarioDTO.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO theEleccionMensajePropietarioDTO1 = new YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO();

                    theEleccionMensajePropietarioDTO1 = YouCom.bll.Mensajeria.EleccionMensajePropietarioBLL.getListadoEleccionMensajePropietarioByIdFamilia(decimal.Parse(myHdnIdMensaje.Value), myFamiliaDTO.IdFamilia);

                    if (theEleccionMensajePropietarioDTO1 != null)
                    {
                        YouCom.bll.Mensajeria.EleccionMensajePropietarioBLL.Delete(theEleccionMensajePropietarioDTO);
                    }

                    YouCom.bll.Mensajeria.EleccionMensajePropietarioBLL.Insert(theEleccionMensajePropietarioDTO);

                    #region Insertar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionPropietarioDTO theNotificacionPropietarioDTO = new YouCom.DTO.Notificaciones.NotificacionPropietarioDTO();
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    theNotificacionPropietarioDTO.TheMensajePropietarioDTO = theMensajePropietarioDTO;

                    theNotificacionPropietarioDTO.VerNotificacion = "NO";

                    theNotificacionPropietarioDTO.FechaNotificacion = DateTime.Now;

                    theNotificacionPropietarioDTO.TheFamiliaCreadorDTO = theMensajePropietarioDTO.TheFamiliaOrigenDTO;

                    theNotificacionAccionDTO.IdNotificacionAccion = 3;
                    theNotificacionPropietarioDTO.TheNotificacionAccionDTO = theNotificacionAccionDTO;

                    theNotificacionPropietarioDTO.TheFamiliaDestinoDTO = theEleccionMensajePropietarioDTO.TheFamiliaDTO;

                    theNotificacionPropietarioDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theNotificacionPropietarioDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theNotificacionPropietarioDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionPropietarioBLL.Insert(theNotificacionPropietarioDTO);

                    #endregion Inserta Notificacion

                    IList<YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO> myEleccionMensajePropietarioDTO = new List<YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO>();
                    myEleccionMensajePropietarioDTO = YouCom.bll.Mensajeria.EleccionMensajePropietarioBLL.getListadoEleccionMensajePropietarioByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (myEleccionMensajePropietarioDTO.Count > 0)
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (" + myEleccionMensajePropietarioDTO.Where(x => x.EleccionMensajePropietarioMeGusta == "SI").Count() + ")";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> " + myEleccionMensajePropietarioDTO.Where(x => x.EleccionMensajePropietarioMeGusta == "NO").Count() + ")";
                    }
                    else
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (0)";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> (0)";
                    }
                }
                else if (myHdnQuienEnvia.Value == "Porteria")
                {
                    YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO theEleccionMensajePorteriaDTO = new YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO();
                    YouCom.DTO.Mensajeria.MensajePorteriaDTO theMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();

                    theMensajePorteriaDTO = YouCom.bll.Mensajeria.MensajePorteriaBLL.detalleMensajePorteria(decimal.Parse(myHdnIdMensaje.Value));

                    theEleccionMensajePorteriaDTO.TheMensajePorteriaDTO = theMensajePorteriaDTO;

                    theEleccionMensajePorteriaDTO.EleccionMensajePorteriaMeGusta = "NO";
                    theEleccionMensajePorteriaDTO.EleccionMensajePorteriaFecha = DateTime.Now;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                    theEleccionMensajePorteriaDTO.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO theEleccionMensajePorteriaDTO1 = new YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO();

                    theEleccionMensajePorteriaDTO1 = YouCom.bll.Mensajeria.EleccionMensajePorteriaBLL.getListadoEleccionMensajePorteriaByIdFamilia(decimal.Parse(myHdnIdMensaje.Value), myFamiliaDTO.IdFamilia);

                    if (theEleccionMensajePorteriaDTO1 != null)
                    {
                        YouCom.bll.Mensajeria.EleccionMensajePorteriaBLL.Delete(theEleccionMensajePorteriaDTO);
                    }

                    YouCom.bll.Mensajeria.EleccionMensajePorteriaBLL.Insert(theEleccionMensajePorteriaDTO);

                    #region Insertar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionPorteriaDTO theNotificacionPorteriaDTO = new YouCom.DTO.Notificaciones.NotificacionPorteriaDTO();
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    theNotificacionPorteriaDTO.TheMensajePorteriaDTO = theMensajePorteriaDTO;

                    theNotificacionPorteriaDTO.VerNotificacion = "NO";

                    theNotificacionPorteriaDTO.FechaNotificacion = DateTime.Now;

                    theNotificacionPorteriaDTO.TheFamiliaDestinoDTO = theEleccionMensajePorteriaDTO.TheFamiliaDTO;

                    theNotificacionAccionDTO.IdNotificacionAccion = 3;
                    theNotificacionPorteriaDTO.TheNotificacionAccionDTO = theNotificacionAccionDTO;

                    theNotificacionPorteriaDTO.ThePorteriaDTO = theMensajePorteriaDTO.ThePorteriaDTO;

                    theNotificacionPorteriaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theNotificacionPorteriaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theNotificacionPorteriaDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionPorteriaBLL.Insert(theNotificacionPorteriaDTO);

                    #endregion Inserta Notificacion

                    IList<YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO> myEleccionMensajePorteriaDTO = new List<YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO>();
                    myEleccionMensajePorteriaDTO = YouCom.bll.Mensajeria.EleccionMensajePorteriaBLL.getListadoEleccionMensajePorteriaByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (myEleccionMensajePorteriaDTO.Count > 0)
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (" + myEleccionMensajePorteriaDTO.Where(x => x.EleccionMensajePorteriaMeGusta == "SI").Count() + ")";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> " + myEleccionMensajePorteriaDTO.Where(x => x.EleccionMensajePorteriaMeGusta == "NO").Count() + ")";
                    }
                    else
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (0)";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> (0)";
                    }
                }
                else if (myHdnQuienEnvia.Value == "Administración")
                {
                    YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO theEleccionMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO();

                    YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();

                    myMensajeDirectivaDTO = YouCom.bll.Mensajeria.MensajeDirectivaBLL.detalleMensajeDirectiva(decimal.Parse(myHdnIdMensaje.Value));

                    myMensajeDirectivaDTO.IdMensajeDirectiva = decimal.Parse(myHdnIdMensaje.Value);
                    theEleccionMensajeDirectivaDTO.TheMensajeDirectivaDTO = myMensajeDirectivaDTO;

                    theEleccionMensajeDirectivaDTO.EleccionMensajeDirectivaMeGusta = "NO";
                    theEleccionMensajeDirectivaDTO.EleccionMensajeDirectivaFecha = DateTime.Now;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

                    myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
                    theEleccionMensajeDirectivaDTO.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO theEleccionMensajeDirectivaDTO1 = new YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO();

                    theEleccionMensajeDirectivaDTO1 = YouCom.bll.Mensajeria.EleccionMensajeDirectivaBLL.getListadoEleccionMensajeDirectivaByIdFamilia(decimal.Parse(myHdnIdMensaje.Value), myFamiliaDTO.IdFamilia);

                    if (theEleccionMensajeDirectivaDTO1 != null)
                    {
                        YouCom.bll.Mensajeria.EleccionMensajeDirectivaBLL.Delete(theEleccionMensajeDirectivaDTO);
                    }

                    YouCom.bll.Mensajeria.EleccionMensajeDirectivaBLL.Insert(theEleccionMensajeDirectivaDTO);

                    #region Insertar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionDirectivaDTO theNotificacionDirectivaDTO = new YouCom.DTO.Notificaciones.NotificacionDirectivaDTO();
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    theNotificacionDirectivaDTO.VerNotificacion = "NO";

                    theNotificacionDirectivaDTO.FechaNotificacion = DateTime.Now;

                    theNotificacionDirectivaDTO.TheMensajeDirectivaDTO = myMensajeDirectivaDTO;

                    theNotificacionAccionDTO.IdNotificacionAccion = 3;
                    theNotificacionDirectivaDTO.TheNotificacionAccionDTO = theNotificacionAccionDTO;

                    theNotificacionDirectivaDTO.TheDirectivaDTO = myMensajeDirectivaDTO.TheDirectivaDTO;

                    theNotificacionDirectivaDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
                    theNotificacionDirectivaDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

                    theNotificacionDirectivaDTO.UsuarioIngreso = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionDirectivaBLL.Insert(theNotificacionDirectivaDTO);

                    #endregion Inserta Notificacion

                    IList<YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO> myEleccionMensajeDirectivaDTO = new List<YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO>();
                    myEleccionMensajeDirectivaDTO = YouCom.bll.Mensajeria.EleccionMensajeDirectivaBLL.getListadoEleccionMensajeDirectivaByIdMensaje(decimal.Parse(myHdnIdMensaje.Value));

                    if (myEleccionMensajeDirectivaDTO.Count > 0)
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (" + myEleccionMensajeDirectivaDTO.Where(x => x.EleccionMensajeDirectivaMeGusta == "SI").Count() + ")";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> " + myEleccionMensajeDirectivaDTO.Where(x => x.EleccionMensajeDirectivaMeGusta == "NO").Count() + ")";
                    }
                    else
                    {
                        myLnkBtnMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-up\"></span> (0)";
                        myLnkBtnNoMeGusta.Text = "<span class=\"glyphicon glyphicon-thumbs-down\"></span> (0)";
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void getVerComentarios(decimal pIdMensaje, string pQuienEnvia, Panel pnlMensajes, Repeater myRptRespuestas, LinkButton myLnkBtnAgregarComentario, bool ver_mensaje)
    { 
        try
        {
            if (pQuienEnvia == "Noticia")
            {
                if (ver_mensaje)
                {
                    myRptRespuestas.Visible = true;
                    pnlMensajes.Visible = true;

                    IList<YouCom.DTO.Mensajeria.MensajeNoticiaDTO> myMensajeNoticiaDTO = new List<YouCom.DTO.Mensajeria.MensajeNoticiaDTO>();
                    myMensajeNoticiaDTO = YouCom.bll.Mensajeria.MensajeNoticiaBLL.getListadoMensajeNoticiaByPadre(pIdMensaje);
                    myRptRespuestas.DataSource = myMensajeNoticiaDTO;
                    myRptRespuestas.DataBind();

                    myLnkBtnAgregarComentario.Text = "<span class=\"glyphicon glyphicon-pencil\"></span> Agregar Comentario";
                }
                else
                {
                    if (!myRptRespuestas.Visible)
                    {
                        myRptRespuestas.Visible = true;
                        pnlMensajes.Visible = true;

                        IList<YouCom.DTO.Mensajeria.MensajeNoticiaDTO> myMensajeNoticiaDTO = new List<YouCom.DTO.Mensajeria.MensajeNoticiaDTO>();
                        myMensajeNoticiaDTO = YouCom.bll.Mensajeria.MensajeNoticiaBLL.getListadoMensajeNoticiaByPadre(pIdMensaje);
                        myRptRespuestas.DataSource = myMensajeNoticiaDTO;
                        myRptRespuestas.DataBind();

                        myLnkBtnAgregarComentario.Text = "<span class=\"glyphicon glyphicon-pencil\"></span> Agregar Comentario";
                    }
                    else
                    {
                        myRptRespuestas.Visible = false;
                        pnlMensajes.Visible = false;
                    }
                }
            }
            else if (pQuienEnvia == "Propietario")
            {
                if (ver_mensaje)
                {
                    myRptRespuestas.Visible = true;
                    pnlMensajes.Visible = true;

                    IList<YouCom.DTO.Mensajeria.MensajePropietarioDTO> myMensajePropietarioDTO = new List<YouCom.DTO.Mensajeria.MensajePropietarioDTO>();
                    myMensajePropietarioDTO = YouCom.bll.Mensajeria.MensajePropietarioBLL.getListadoMensajePropietarioByPadre(pIdMensaje);
                    myRptRespuestas.DataSource = myMensajePropietarioDTO;
                    myRptRespuestas.DataBind();
                    myLnkBtnAgregarComentario.Text = "<span class=\"glyphicon glyphicon-pencil\"></span> Agregar Comentario";
                }
                else
                {
                    if (!myRptRespuestas.Visible)
                    {
                        myRptRespuestas.Visible = true;
                        pnlMensajes.Visible = true;

                        IList<YouCom.DTO.Mensajeria.MensajePropietarioDTO> myMensajePropietarioDTO = new List<YouCom.DTO.Mensajeria.MensajePropietarioDTO>();
                        myMensajePropietarioDTO = YouCom.bll.Mensajeria.MensajePropietarioBLL.getListadoMensajePropietarioByPadre(pIdMensaje);
                        myRptRespuestas.DataSource = myMensajePropietarioDTO;
                        myRptRespuestas.DataBind();
                        myLnkBtnAgregarComentario.Text = "<span class=\"glyphicon glyphicon-pencil\"></span> Agregar Comentario";
                    }
                    else
                    {
                        myRptRespuestas.Visible = false;
                        pnlMensajes.Visible = false;
                    }
                }
                
            }
            else if (pQuienEnvia == "Porteria")
            {
                if (ver_mensaje)
                {
                    myRptRespuestas.Visible = true;
                    pnlMensajes.Visible = true;

                    IList<YouCom.DTO.Mensajeria.MensajePorteriaDTO> myMensajePorteriaDTO = new List<YouCom.DTO.Mensajeria.MensajePorteriaDTO>();
                    myMensajePorteriaDTO = YouCom.bll.Mensajeria.MensajePorteriaBLL.getListadoMensajePorteriaByPadre(pIdMensaje);
                    myRptRespuestas.DataSource = myMensajePorteriaDTO;
                    myRptRespuestas.DataBind();
                }
                else
                {
                    if (!myRptRespuestas.Visible)
                    {
                        myRptRespuestas.Visible = true;
                        pnlMensajes.Visible = true;

                        IList<YouCom.DTO.Mensajeria.MensajePorteriaDTO> myMensajePorteriaDTO = new List<YouCom.DTO.Mensajeria.MensajePorteriaDTO>();
                        myMensajePorteriaDTO = YouCom.bll.Mensajeria.MensajePorteriaBLL.getListadoMensajePorteriaByPadre(pIdMensaje);
                        myRptRespuestas.DataSource = myMensajePorteriaDTO;
                        myRptRespuestas.DataBind();
                    }
                    else
                    {
                        myRptRespuestas.Visible = false;
                        pnlMensajes.Visible = false;
                    }
                }
            }
            else if (pQuienEnvia == "Administración")
            {
                if (ver_mensaje)
                {
                    myRptRespuestas.Visible = true;
                    pnlMensajes.Visible = true;

                    IList<YouCom.DTO.Mensajeria.MensajeDirectivaDTO> myMensajeDirectivaDTO = new List<YouCom.DTO.Mensajeria.MensajeDirectivaDTO>();
                    myMensajeDirectivaDTO = YouCom.bll.Mensajeria.MensajeDirectivaBLL.getListadoMensajeDirectivaByPadre(pIdMensaje);
                    myRptRespuestas.DataSource = myMensajeDirectivaDTO;
                    myRptRespuestas.DataBind();
                }
                else
                {
                    if (!myRptRespuestas.Visible)
                    {
                        myRptRespuestas.Visible = true;
                        pnlMensajes.Visible = true;

                        IList<YouCom.DTO.Mensajeria.MensajeDirectivaDTO> myMensajeDirectivaDTO = new List<YouCom.DTO.Mensajeria.MensajeDirectivaDTO>();
                        myMensajeDirectivaDTO = YouCom.bll.Mensajeria.MensajeDirectivaBLL.getListadoMensajeDirectivaByPadre(pIdMensaje);
                        myRptRespuestas.DataSource = myMensajeDirectivaDTO;
                        myRptRespuestas.DataBind();
                    }
                    else
                    {
                        myRptRespuestas.Visible = false;
                        pnlMensajes.Visible = false;
                    }
                }
            }
        }
        catch(Exception ex)
        {

        }
    }

    protected void BtnPublicarMensaje_Click(object sender, EventArgs e)
    {
        try
        {
            if (setEnviaMensaje())
            {
                if (!Page.ClientScript.IsClientScriptBlockRegistered("SET"))
                {
                    string script = "alert('Estimado Cliente, se ha publicado su mensaje exitosamente.');";
                    script += "parent.location = '" + retorno1 + "';";
                    ScriptManager.RegisterStartupScript(updPanel, updPanel.GetType(), "alert", script, true);
                }
            }
            else
            {
                string script = "alert('A ocurrido un error. Favor envíe su solicitud al mail contacto@youcom.cl intente más tarde.');";
                script += "parent.location = '" + retorno1 + "';";
                ScriptManager.RegisterStartupScript(updPanel, updPanel.GetType(), "alert", script, true);

            }
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
        }
    }

    protected void BtnVolver_Click(object sender, EventArgs e)
    {
        this.SelView(this.mvwMensaje.ActiveViewIndex - 1);
    }

    protected bool setEnviaMensaje()
    {
        bool retorno = false;
        bool salida = false;

        YouCom.DTO.Mensajeria.MensajePropietarioDTO theMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();

        theMensajePropietarioDTO.MensajeTitulo = TxtAsunto.Text;
        theMensajePropietarioDTO.MensajeDescripcion = TxtComentarios.Text;
        theMensajePropietarioDTO.MensajeFecha = DateTime.Now;

        theMensajePropietarioDTO.TheComunidadDTO = myUsuario.TheComunidadSeleccionDTO;
        theMensajePropietarioDTO.TheCondominioDTO = myUsuario.TheCondominioSeleccionDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();

        myFamiliaDTO = YouCom.bll.FamiliaBLL.detalleFamiliabyRut(myUsuario.Rut);
        theMensajePropietarioDTO.TheFamiliaOrigenDTO = myFamiliaDTO;

        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDestinoDTO = new YouCom.DTO.Propietario.FamiliaDTO();
        theMensajePropietarioDTO.TheFamiliaDestinoDTO = myFamiliaDestinoDTO;

        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();

        myCategoriaDTO.IdCategoria = decimal.Parse(this.ddlCategoria.SelectedValue);

        theMensajePropietarioDTO.TheCategoriaDTO = myCategoriaDTO;

        theMensajePropietarioDTO.UsuarioIngreso = myUsuario.Rut;

        retorno = YouCom.bll.Mensajeria.MensajePropietarioBLL.Insert(theMensajePropietarioDTO);

        if(retorno)
        {
            string ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathMensajePub");
            string valor_retorno = string.Empty;
            foreach (var file in FileImagenMensaje.PostedFiles)
            {
                YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO myImagenMensajePropietarioDTO = new YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO();

                Random myRandom = new Random();
                string xName = myRandom.Next(1, 1000000).ToString();

                if (Intermedia.IMSystem.IMFile.IMFile.GetNameFile(file.FileName).Length > 16)
                    valor_retorno = xName + "_" + Intermedia.IMSystem.IMFile.IMFile.GetNameFile(file.FileName).Substring(0, 16) + Intermedia.IMSystem.IMFile.IMFile.GetExtensionFile(file.FileName);
                else
                    valor_retorno = xName + "_" + Intermedia.IMSystem.IMFile.IMFile.GetNameFile(file.FileName).Substring(0, Intermedia.IMSystem.IMFile.IMFile.GetNameFile(file.FileName).Length) + Intermedia.IMSystem.IMFile.IMFile.GetExtensionFile(file.FileName);

                myImagenMensajePropietarioDTO.ThumbailImagenMensajePropietario = valor_retorno;
                myImagenMensajePropietarioDTO.GrandeImagenMensajePropietario = valor_retorno;
                myImagenMensajePropietarioDTO.TituloImagenMensajePropietario = this.TxtAsunto.Text;

                YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();
                myMensajePropietarioDTO.IdMensajePropietario = YouCom.bll.Mensajeria.MensajePropietarioBLL.getObtenerUltimoMensaje().IdMensajePropietario;
                myImagenMensajePropietarioDTO.TheMensajePropietarioDTO = myMensajePropietarioDTO;

                YouCom.bll.Mensajeria.Imagen.ImagenMensajePropietarioBLL.Insert(myImagenMensajePropietarioDTO);

                file.SaveAs(Server.MapPath(ruta + valor_retorno));
            }
            
            foreach (RepeaterItem item in this.rptVideosYoutube.Items)
            {
                TextBox myTxtUrl = (TextBox)item.FindControl("TxtUrl");
                TextBox myTxtTitulo = (TextBox)item.FindControl("TxtTitulo");

                YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO myVideoMensajePropietarioDTO = new YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO();

                myVideoMensajePropietarioDTO.UrlVideoMensajePropietario = myTxtUrl.Text;
                myVideoMensajePropietarioDTO.TituloVideoMensajePropietario = myTxtTitulo.Text;

                YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();
                myMensajePropietarioDTO.IdMensajePropietario = YouCom.bll.Mensajeria.MensajePropietarioBLL.getObtenerUltimoMensaje().IdMensajePropietario;
                myVideoMensajePropietarioDTO.TheMensajePropietarioDTO = myMensajePropietarioDTO;

                YouCom.bll.Mensajeria.Video.VideoMensajePropietarioBLL.Insert(myVideoMensajePropietarioDTO);

            }

            salida = true;
        }

        return salida;
    }

    protected void LnkBtnMensaje_Click(object sender, EventArgs e)
    {
        IList<YouCom.DTO.DirectivaDTO> myDirectiva = new List<YouCom.DTO.DirectivaDTO>();
        //myDirectiva = YouCom.bll.DirectivaBLL.getListadoDirectivaByCondominioByComunidad(myUsuario.IndexCondominio.ToString(), myUsuario.IndexComunidad);

        if(myDirectiva.Any())
        {
            Session.Add("DirectivaId", myDirectiva.First().IdDirectiva.ToString());
            Response.Redirect("~/Privado/Contacto/MensajeAdministracion.aspx", false);
        }
    }

    protected void rptIndicadorCarrusel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                HtmlGenericControl li_mensaje = new HtmlGenericControl();
                li_mensaje = (HtmlGenericControl)e.Item.FindControl("li_mensaje");

                if (e.Item.ItemIndex == 0)
                {
                    li_mensaje.Attributes.Add("class", "active");
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptGaleriaImagenes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                Image img = (Image)e.Item.FindControl("imgMensaje");

                HiddenField myHdnQuienEnvia = (HiddenField)e.Item.Parent.Parent.FindControl("hdnQuienEnvia");

                string ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathMensajePub");

                if (myHdnQuienEnvia.Value == "Noticia")
                {
                    if (!string.IsNullOrEmpty(((YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO)e.Item.DataItem).GrandeImagenMensajeNoticia) && ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO)e.Item.DataItem).GrandeImagenMensajeNoticia.Trim() != "")
                    {
                        img.ImageUrl = ruta + ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO)e.Item.DataItem).GrandeImagenMensajeNoticia;
                        img.AlternateText = ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO)e.Item.DataItem).TituloImagenMensajeNoticia;
                        img.ToolTip = ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO)e.Item.DataItem).TituloImagenMensajeNoticia;
                    }
                    else
                    {
                        img.Visible = false;
                    }
                }
                else if (myHdnQuienEnvia.Value == "Propietario")
                {
                    if (!string.IsNullOrEmpty(((YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO)e.Item.DataItem).GrandeImagenMensajePropietario) && ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO)e.Item.DataItem).GrandeImagenMensajePropietario.Trim() != "")
                    {
                        img.ImageUrl = ruta + ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO)e.Item.DataItem).GrandeImagenMensajePropietario;
                        img.AlternateText = ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO)e.Item.DataItem).TituloImagenMensajePropietario;
                        img.ToolTip = ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO)e.Item.DataItem).TituloImagenMensajePropietario;
                    }
                    else
                    {
                        img.Visible = false;
                    }
                }
                else if (myHdnQuienEnvia.Value == "Porteria")
                {
                    if (!string.IsNullOrEmpty(((YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO)e.Item.DataItem).GrandeImagenMensajePorteria) && ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO)e.Item.DataItem).GrandeImagenMensajePorteria.Trim() != "")
                    {
                        img.ImageUrl = ruta + ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO)e.Item.DataItem).GrandeImagenMensajePorteria;
                        img.AlternateText = ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO)e.Item.DataItem).TituloImagenMensajePorteria;
                        img.ToolTip = ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO)e.Item.DataItem).TituloImagenMensajePorteria;
                    }
                    else
                    {
                        img.Visible = false;
                    }
                }
                else if (myHdnQuienEnvia.Value == "Administración")
                {
                    if (!string.IsNullOrEmpty(((YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO)e.Item.DataItem).GrandeImagenMensajeDirectiva) && ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO)e.Item.DataItem).GrandeImagenMensajeDirectiva.Trim() != "")
                    {
                        img.ImageUrl = ruta + ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO)e.Item.DataItem).GrandeImagenMensajeDirectiva;
                        img.AlternateText = ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO)e.Item.DataItem).TituloImagenMensajeDirectiva;
                        img.ToolTip = ((YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO)e.Item.DataItem).TituloImagenMensajeDirectiva;
                    }
                    else
                    {
                        img.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptMensajesInternos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {

                HtmlGenericControl div_mensaje = new HtmlGenericControl();
                div_mensaje = (HtmlGenericControl)e.Item.FindControl("div_mensaje");

                if (e.Item.ItemIndex == 0)
                {
                    div_mensaje.Attributes.Add("class", "item active");
                }
                else
                {
                    div_mensaje.Attributes.Add("class", "item");
                }

                if (!string.IsNullOrEmpty(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje.ToString()))
                {
                    string ruta = string.Empty;

                    if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCategoriaDTO.IdCategoria == 25)
                    {
                        ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathMensajePub");
                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCategoriaDTO.IdCategoria == 26)
                    {
                        ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathMensajePub");
                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCategoriaDTO.IdCategoria == 27)
                    {
                        ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathMensajePub");
                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCategoriaDTO.IdCategoria == 13)
                    {
                        ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathNoticiaPub");
                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheCategoriaDTO.IdCategoria == 14)
                    {
                        ruta = YouCom.Service.Generales.General.GetPropiedad("UploadsPathNoticiaPub");
                    }

                    ImageButton img = (ImageButton)e.Item.FindControl("imgMensaje");

                    if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheMensajeTipoDTO.NombreMensajeTipo == "Noticia")
                    {
                        IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO> collImagenMensajeNoticiaDTO = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO>();

                        collImagenMensajeNoticiaDTO = YouCom.bll.Mensajeria.Imagen.ImagenMensajeNoticiaBLL.getListadoImagenMensajeNoticiaByIdMensaje(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);

                        if (collImagenMensajeNoticiaDTO.Any())
                        {
                            if (!string.IsNullOrEmpty(collImagenMensajeNoticiaDTO.First().GrandeImagenMensajeNoticia) && collImagenMensajeNoticiaDTO.First().GrandeImagenMensajeNoticia.Trim() != "")
                            {
                                img.ImageUrl = ruta + collImagenMensajeNoticiaDTO.First().GrandeImagenMensajeNoticia;
                                img.AlternateText = collImagenMensajeNoticiaDTO.First().TituloImagenMensajeNoticia;
                                img.ToolTip = collImagenMensajeNoticiaDTO.First().TituloImagenMensajeNoticia;
                            }
                            else
                            {
                                img.Visible = false;
                            }
                        }
                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheMensajeTipoDTO.NombreMensajeTipo == "Propietario")
                    {
                        IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO> collImagenMensajePropietarioDTO = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO>();

                        collImagenMensajePropietarioDTO = YouCom.bll.Mensajeria.Imagen.ImagenMensajePropietarioBLL.getListadoImagenMensajePropietarioByIdMensaje(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);

                        if (collImagenMensajePropietarioDTO.Any())
                        {
                            if (!string.IsNullOrEmpty(collImagenMensajePropietarioDTO.First().GrandeImagenMensajePropietario) && collImagenMensajePropietarioDTO.First().GrandeImagenMensajePropietario.Trim() != "")
                            {
                                img.ImageUrl = ruta + collImagenMensajePropietarioDTO.First().GrandeImagenMensajePropietario;
                                img.AlternateText = collImagenMensajePropietarioDTO.First().TituloImagenMensajePropietario;
                                img.ToolTip = collImagenMensajePropietarioDTO.First().TituloImagenMensajePropietario;
                            }
                            else
                            {
                                img.Visible = false;
                            }
                        }
                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheMensajeTipoDTO.NombreMensajeTipo == "Porteria")
                    {
                        IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO> collImagenMensajePorteriaDTO = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO>();

                        collImagenMensajePorteriaDTO = YouCom.bll.Mensajeria.Imagen.ImagenMensajePorteriaBLL.getListadoImagenMensajePorteriaByIdMensaje(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);

                        if (collImagenMensajePorteriaDTO.Any())
                        {
                            if (!string.IsNullOrEmpty(collImagenMensajePorteriaDTO.First().GrandeImagenMensajePorteria) && collImagenMensajePorteriaDTO.First().GrandeImagenMensajePorteria.Trim() != "")
                            {
                                img.ImageUrl = ruta + collImagenMensajePorteriaDTO.First().GrandeImagenMensajePorteria;
                                img.AlternateText = collImagenMensajePorteriaDTO.First().TituloImagenMensajePorteria;
                                img.ToolTip = collImagenMensajePorteriaDTO.First().TituloImagenMensajePorteria;
                            }
                            else
                            {
                                img.Visible = false;
                            }
                        }
                    }
                    else if (((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).TheMensajeTipoDTO.NombreMensajeTipo == "Administración")
                    {
                        IList<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO> collImagenMensajeDirectivaDTO = new List<YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO>();

                        collImagenMensajeDirectivaDTO = YouCom.bll.Mensajeria.Imagen.ImagenMensajeDirectivaBLL.getListadoImagenMensajeDirectivaByIdMensaje(((YouCom.DTO.Mensajeria.MensajeDTO)e.Item.DataItem).IdMensaje);

                        if (collImagenMensajeDirectivaDTO.Any())
                        {
                            if (!string.IsNullOrEmpty(collImagenMensajeDirectivaDTO.First().GrandeImagenMensajeDirectiva) && collImagenMensajeDirectivaDTO.First().GrandeImagenMensajeDirectiva.Trim() != "")
                            {
                                img.ImageUrl = ruta + collImagenMensajeDirectivaDTO.First().GrandeImagenMensajeDirectiva;
                                img.AlternateText = collImagenMensajeDirectivaDTO.First().TituloImagenMensajeDirectiva;
                                img.ToolTip = collImagenMensajeDirectivaDTO.First().TituloImagenMensajeDirectiva;
                            }
                            else
                            {
                                img.Visible = false;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptMensajesInternos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            HiddenField myHdnIdMensaje = (HiddenField)e.Item.FindControl("hdnIdMensaje");
            HiddenField myHdnQuienEnvia = (HiddenField)e.Item.FindControl("hdnQuienEnvia");

            if (e.CommandName.Equals("Detalle"))
            {
                IList<YouCom.DTO.Mensajeria.MensajeDTO> myMensajeDTO = new List<YouCom.DTO.Mensajeria.MensajeDTO>();
                myMensajeDTO = YouCom.bll.Mensajeria.MensajeBLL.getListadoMensajesByIdMensaje(decimal.Parse(myHdnIdMensaje.Value), myHdnQuienEnvia.Value);

                rptMensajes.DataSource = myMensajeDTO;
                rptMensajes.DataBind();

                pnlCarrusel.Visible = false;
            }
            if (e.CommandName.Equals("VerTodos"))
            {
                if (myHdnQuienEnvia.Value == "Noticia")
                {
                    IList<YouCom.DTO.Mensajeria.MensajeDTO> myMensajeDTO = new List<YouCom.DTO.Mensajeria.MensajeDTO>();
                    YouCom.DTO.Mensajeria.MensajeNoticiaDTO myMensajeNoticiaDTO = new YouCom.DTO.Mensajeria.MensajeNoticiaDTO();

                    myMensajeNoticiaDTO = YouCom.bll.Mensajeria.MensajeNoticiaBLL.detalleMensajeNoticia(decimal.Parse(myHdnIdMensaje.Value));
                    myMensajeDTO = YouCom.bll.Mensajeria.MensajeBLL.getListadoMensajesByCategoria(myMensajeNoticiaDTO.TheCategoriaDTO.IdCategoria);

                    rptMensajes.DataSource = myMensajeDTO;
                    rptMensajes.DataBind();

                    pnlCarrusel.Visible = false;

                }
                else if (myHdnQuienEnvia.Value == "Propietario")
                {
                    IList<YouCom.DTO.Mensajeria.MensajeDTO> myMensajeDTO = new List<YouCom.DTO.Mensajeria.MensajeDTO>();
                    YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();

                    myMensajePropietarioDTO = YouCom.bll.Mensajeria.MensajePropietarioBLL.detalleMensajePropietario(decimal.Parse(myHdnIdMensaje.Value));
                    myMensajeDTO = YouCom.bll.Mensajeria.MensajeBLL.getListadoMensajesByCategoria(myMensajePropietarioDTO.TheCategoriaDTO.IdCategoria);

                    rptMensajes.DataSource = myMensajeDTO;
                    rptMensajes.DataBind();

                    pnlCarrusel.Visible = false;
                }
                else if (myHdnQuienEnvia.Value == "Porteria")
                {
                    IList<YouCom.DTO.Mensajeria.MensajeDTO> myMensajeDTO = new List<YouCom.DTO.Mensajeria.MensajeDTO>();
                    YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();

                    myMensajePorteriaDTO = YouCom.bll.Mensajeria.MensajePorteriaBLL.detalleMensajePorteria(decimal.Parse(myHdnIdMensaje.Value));
                    myMensajeDTO = YouCom.bll.Mensajeria.MensajeBLL.getListadoMensajesByCategoria(myMensajePorteriaDTO.TheCategoriaDTO.IdCategoria);

                    rptMensajes.DataSource = myMensajeDTO;
                    rptMensajes.DataBind();

                    pnlCarrusel.Visible = false;
                }
                else if (myHdnQuienEnvia.Value == "Administración")
                {
                    IList<YouCom.DTO.Mensajeria.MensajeDTO> myMensajeDTO = new List<YouCom.DTO.Mensajeria.MensajeDTO>();
                    YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();

                    myMensajeDirectivaDTO = YouCom.bll.Mensajeria.MensajeDirectivaBLL.detalleMensajeDirectiva(decimal.Parse(myHdnIdMensaje.Value));
                    myMensajeDTO = YouCom.bll.Mensajeria.MensajeBLL.getListadoMensajesByCategoria(myMensajeDirectivaDTO.TheCategoriaDTO.IdCategoria);

                    rptMensajes.DataSource = myMensajeDTO;
                    rptMensajes.DataBind();

                    pnlCarrusel.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rdbListFiltros_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(rdbListFiltros.SelectedValue == "C")
        {
            form_categoria.Visible = true;
            form_usuario.Visible = false;
            form_titulo.Visible = false;
        }
        else if (rdbListFiltros.SelectedValue == "U")
        {
            form_categoria.Visible = false;
            form_usuario.Visible = true;
            form_titulo.Visible = false;
        }
        else if (rdbListFiltros.SelectedValue == "T")
        {
            form_categoria.Visible = false;
            form_usuario.Visible = false;
            form_titulo.Visible = true;
        }
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            IList<YouCom.DTO.Mensajeria.MensajeDTO> myMensajeDTO = new List<YouCom.DTO.Mensajeria.MensajeDTO>();

            if (rdbListFiltros.SelectedValue == "C")
            {
                myMensajeDTO = YouCom.bll.Mensajeria.MensajeBLL.getListadoMensajesByCategoria(decimal.Parse(ddlBuscadorCategoria.SelectedValue));

                rptMensajes.DataSource = myMensajeDTO;
                rptMensajes.DataBind();

                pnlCarrusel.Visible = false;
            }
            else if (rdbListFiltros.SelectedValue == "U")
            {
                myMensajeDTO = YouCom.bll.Mensajeria.MensajeBLL.getListadoMensajesByUsuario(this.TxtUsuarioBusqueda.Text);

                rptMensajes.DataSource = myMensajeDTO;
                rptMensajes.DataBind();

                pnlCarrusel.Visible = false;
            }
            else if (rdbListFiltros.SelectedValue == "T")
            {
                myMensajeDTO = YouCom.bll.Mensajeria.MensajeBLL.getListadoMensajesByTitulo(this.TxtTituloBusqueda.Text);

                rptMensajes.DataSource = myMensajeDTO;
                rptMensajes.DataBind();

                pnlCarrusel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
        }
    }

    protected void BtnAgregarVideo_Click(object sender, EventArgs e)
    {
        try
        {

            IList<YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO> collVideoTemporal = new List<YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO>();
            YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO theVideoMensajePropietarioDTO;
            foreach (RepeaterItem itemSel in this.rptVideosYoutube.Items)
            {
                theVideoMensajePropietarioDTO = new YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO();

                TextBox TxtUrl = (TextBox)itemSel.FindControl("TxtUrl");
                TextBox TxtTitulo = (TextBox)itemSel.FindControl("TxtTitulo");

                theVideoMensajePropietarioDTO.IdVideoMensajePropietario = itemSel.ItemIndex + 1;
                theVideoMensajePropietarioDTO.TituloVideoMensajePropietario = TxtTitulo.Text;
                theVideoMensajePropietarioDTO.UrlVideoMensajePropietario = TxtUrl.Text;

                YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();
                myMensajePropietarioDTO.IdMensajePropietario = YouCom.bll.Mensajeria.MensajePropietarioBLL.getObtenerUltimoMensaje().IdMensajePropietario;

                theVideoMensajePropietarioDTO.TheMensajePropietarioDTO = myMensajePropietarioDTO;

                collVideoTemporal.Add(theVideoMensajePropietarioDTO);
            }

            theVideoMensajePropietarioDTO = new YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO();

            theVideoMensajePropietarioDTO.IdVideoMensajePropietario = collVideoTemporal.Count + 1;
            theVideoMensajePropietarioDTO.TituloVideoMensajePropietario = "";
            theVideoMensajePropietarioDTO.UrlVideoMensajePropietario = "";

            YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO1 = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();
            myMensajePropietarioDTO1.IdMensajePropietario = YouCom.bll.Mensajeria.MensajePropietarioBLL.getObtenerUltimoMensaje().IdMensajePropietario;

            theVideoMensajePropietarioDTO.TheMensajePropietarioDTO = myMensajePropietarioDTO1;

            collVideoTemporal.Add(theVideoMensajePropietarioDTO);

            Session["CargaVideoTemporal"] = collVideoTemporal;

            rptVideosYoutube.DataSource = collVideoTemporal;
            rptVideosYoutube.DataBind();
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
        }
    }

    protected void getCargaVideo()
    {
        IList<YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO> collVideoMensajePropietarioDTO = new List<YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO>();
        YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO myVideoMensajePropietarioDTO = new YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO();

        myVideoMensajePropietarioDTO.IdVideoMensajePropietario = 0;
        myVideoMensajePropietarioDTO.TituloVideoMensajePropietario = "";
        myVideoMensajePropietarioDTO.UrlVideoMensajePropietario = "";

        YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();
        myMensajePropietarioDTO.IdMensajePropietario = YouCom.bll.Mensajeria.MensajePropietarioBLL.getObtenerUltimoMensaje().IdMensajePropietario;

        myVideoMensajePropietarioDTO.TheMensajePropietarioDTO = myMensajePropietarioDTO;

        collVideoMensajePropietarioDTO.Add(myVideoMensajePropietarioDTO);

        rptVideosYoutube.DataSource = collVideoMensajePropietarioDTO;
        rptVideosYoutube.DataBind();
    }

    protected void rptVideosYoutube_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO)e.Item.DataItem).IdVideoMensajePropietario.ToString()))
                {
                    TextBox TxtUrl = (TextBox)e.Item.FindControl("TxtUrl");
                    TextBox TxtTitulo = (TextBox)e.Item.FindControl("TxtTitulo");

                    if (Session["CargaVideoTemporal"] != null)
                    {
                        YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO myVideoMensajePropietarioDTO = new YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO();

                        IList<YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO> collVideoMensajePropietarioDTO;
                        collVideoMensajePropietarioDTO = (Session["CargaVideoTemporal"] as IList<YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO>).ToList();

                        myVideoMensajePropietarioDTO = collVideoMensajePropietarioDTO.Where(x => x.IdVideoMensajePropietario == ((YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO)e.Item.DataItem).IdVideoMensajePropietario).SingleOrDefault();

                        TxtUrl.Text = myVideoMensajePropietarioDTO.UrlVideoMensajePropietario;
                        TxtTitulo.Text = myVideoMensajePropietarioDTO.TituloVideoMensajePropietario;
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptNotificaciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemIndex > -1)
            {
                if (!string.IsNullOrEmpty(((YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO)e.Item.DataItem).IdResumenNotificacion.ToString()))
                {
                    LinkButton lnkBtnDetalle = (LinkButton)e.Item.FindControl("lnkBtnDetalle");

                    string mensaje = string.Empty;
                    if (((YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO)e.Item.DataItem).IdCantidad == 1)
                    {
                        mensaje = ((YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO)e.Item.DataItem).IdCantidad + " persona ha opinado sobre tu publicación " + ((YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO)e.Item.DataItem).TheMensajeDTO.MensajeTitulo;
                    }
                    else
                    {
                        mensaje = ((YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO)e.Item.DataItem).IdCantidad + " personas han opinado sobre tu publicación " + ((YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO)e.Item.DataItem).TheMensajeDTO.MensajeTitulo;
                    }

                    lnkBtnDetalle.Text = mensaje;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptNotificaciones_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            HiddenField myHdnIdMensaje = (HiddenField)e.Item.FindControl("hdnIdMensaje");
            HiddenField myHdnQuienEnvia = (HiddenField)e.Item.FindControl("hdnQuienEnvia");

            if (e.CommandName.Equals("VerDetalle"))
            {
                IList<YouCom.DTO.Mensajeria.MensajeDTO> myMensajeDTO = new List<YouCom.DTO.Mensajeria.MensajeDTO>();

                if (myHdnQuienEnvia.Value == "Noticia")
                {
                    #region Modificar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionNoticiaDTO theNotificacionNoticiaDTO = new YouCom.DTO.Notificaciones.NotificacionNoticiaDTO();
                    
                    theNotificacionNoticiaDTO.VerNotificacion = "SI";

                    YouCom.DTO.Mensajeria.MensajeNoticiaDTO myMensajeNoticiaDTO = new YouCom.DTO.Mensajeria.MensajeNoticiaDTO();

                    myMensajeNoticiaDTO.IdMensajeNoticia = decimal.Parse(myHdnIdMensaje.Value);

                    theNotificacionNoticiaDTO.TheMensajeNoticiaDTO = myMensajeNoticiaDTO;
                    theNotificacionNoticiaDTO.UsuarioModificacion = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionNoticiaBLL.Update(theNotificacionNoticiaDTO);

                    #endregion Modificar Notificacion

                }
                else if (myHdnQuienEnvia.Value == "Propietario")
                {
                    #region Modificar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionPropietarioDTO theNotificacionPropietarioDTO = new YouCom.DTO.Notificaciones.NotificacionPropietarioDTO();
                    
                    theNotificacionPropietarioDTO.VerNotificacion = "SI";

                    YouCom.DTO.Mensajeria.MensajePropietarioDTO myMensajePropietarioDTO = new YouCom.DTO.Mensajeria.MensajePropietarioDTO();

                    myMensajePropietarioDTO.IdMensajePropietario = decimal.Parse(myHdnIdMensaje.Value);

                    theNotificacionPropietarioDTO.TheMensajePropietarioDTO = myMensajePropietarioDTO;

                    theNotificacionPropietarioDTO.UsuarioModificacion = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionPropietarioBLL.Update(theNotificacionPropietarioDTO);

                    #endregion Modificar Notificacion
                }
                else if (myHdnQuienEnvia.Value == "Porteria")
                {
                    #region Modificar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionPorteriaDTO theNotificacionPorteriaDTO = new YouCom.DTO.Notificaciones.NotificacionPorteriaDTO();

                    theNotificacionPorteriaDTO.VerNotificacion = "SI";

                    YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO = new YouCom.DTO.Mensajeria.MensajePorteriaDTO();

                    myMensajePorteriaDTO.IdMensajePorteria = decimal.Parse(myHdnIdMensaje.Value);

                    theNotificacionPorteriaDTO.TheMensajePorteriaDTO = myMensajePorteriaDTO;

                    theNotificacionPorteriaDTO.UsuarioModificacion = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionPorteriaBLL.Update(theNotificacionPorteriaDTO);

                    #endregion Modificar Notificacion
                }
                else if (myHdnQuienEnvia.Value == "Administración")
                {
                    #region Modificar Notificacion

                    YouCom.DTO.Notificaciones.NotificacionDirectivaDTO theNotificacionDirectivaDTO = new YouCom.DTO.Notificaciones.NotificacionDirectivaDTO();
                    
                    theNotificacionDirectivaDTO.VerNotificacion = "SI";

                    YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new YouCom.DTO.Mensajeria.MensajeDirectivaDTO();

                    myMensajeDirectivaDTO.IdMensajeDirectiva = decimal.Parse(myHdnIdMensaje.Value);

                    theNotificacionDirectivaDTO.TheMensajeDirectivaDTO = myMensajeDirectivaDTO;

                    theNotificacionDirectivaDTO.UsuarioModificacion = myUsuario.Rut;

                    YouCom.bll.Notificaciones.NotificacionDirectivaBLL.Update(theNotificacionDirectivaDTO);

                    #endregion Modificar Notificacion
                }


                myMensajeDTO = YouCom.bll.Mensajeria.MensajeBLL.getListadoMensajesByIdMensaje(decimal.Parse(myHdnIdMensaje.Value), myHdnQuienEnvia.Value);

                if(myMensajeDTO.Any())
                {
                    rptMensajes.DataSource = myMensajeDTO;
                    rptMensajes.DataBind();

                    pnlCarrusel.Visible = false;
                    pnlBuscador.Visible = false;
                    pnlNotificaciones.Visible = false;
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

    protected void rptAviso_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Detalle"))
            {
                HiddenField myHidIdAviso = (HiddenField)e.Item.FindControl("HidIdAviso");

                Session.Add("idAviso", myHidIdAviso.Value);

                Response.Redirect("http://" + Request.Url.Authority + "/privado/Avisos/Avisos.aspx", true);
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
            if (e.CommandName.Equals("Detalle"))
            {
                HiddenField myHdnIdAccesoHogar = (HiddenField)e.Item.FindControl("HdnIdAccesoHogar");

                YouCom.DTO.AccesoHogar.AccesoHogarDTO myAccesoHogar = new YouCom.DTO.AccesoHogar.AccesoHogarDTO();

                myAccesoHogar = YouCom.bll.AccesoHogar.AccesoHogarBLL.detalleAccesoHogar(decimal.Parse(myHdnIdAccesoHogar.Value));

                if(myAccesoHogar.TheFrecuenciaDTO.IdFrecuencia == 1)
                {
                    Session.Add("idAccesoHabitual", myHdnIdAccesoHogar.Value);

                    Response.Redirect("http://" + Request.Url.Authority + "/privado/accesos/IngresosHabilituales.aspx", true);
                }
                else
                {
                    Session.Add("idInvitacionVisita", myHdnIdAccesoHogar.Value);

                    Response.Redirect("http://" + Request.Url.Authority + "/privado/accesos/InvitacionVisitas.aspx", true);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptContacto_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("EnviarMensaje"))
            {
                HiddenField myHdnIdDirectiva = (HiddenField)e.Item.FindControl("hdnIdDirectiva");

                Session.Add("idDirectiva", myHdnIdDirectiva.Value);

                Response.Redirect("http://" + Request.Url.Authority + "/privado/contacto/MensajeAdministracion.aspx", true);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptServicio_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Detalle"))
            {
                HiddenField myHidIdServicio = (HiddenField)e.Item.FindControl("HidIdServicio");

                Session.Add("idServicio", myHidIdServicio.Value);

                Response.Redirect("http://" + Request.Url.Authority + "/privado/Servicios.aspx", true);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptServicio_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem != null)
            {
                Image img = (Image)e.Item.FindControl("imgLogo");

                if (!string.IsNullOrEmpty(((YouCom.DTO.Servicio.ServiciosDTO)e.Item.DataItem).ImagenServicio) && ((YouCom.DTO.Servicio.ServiciosDTO)e.Item.DataItem).ImagenServicio.Trim() != "")
                {
                    img.ImageUrl = YouCom.Service.Generales.General.GetPropiedad("UploadsPathServicioPub") + ((YouCom.DTO.Servicio.ServiciosDTO)e.Item.DataItem).ImagenServicio;
                    img.AlternateText = ((YouCom.DTO.Servicio.ServiciosDTO)e.Item.DataItem).NombreServicio;
                    img.ToolTip = ((YouCom.DTO.Servicio.ServiciosDTO)e.Item.DataItem).NombreServicio;
                }
                else
                {
                    img.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}