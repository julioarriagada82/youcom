using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Mensajeria
{
    public class Mensaje
    {
        public static IList<YouCom.DTO.Mensajeria.MensajeDTO> getListadoMensajes(decimal idFamilia)
        {
            IList<YouCom.DTO.Mensajeria.MensajeDTO> IMensaje = new List<YouCom.DTO.Mensajeria.MensajeDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.MensajeDirectivaDAL.getListadoMensajeDirectiva(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

                    mensaje.IdMensaje = decimal.Parse(wobjDataRow["IdMensajeDirectiva"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    mensaje.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    mensaje.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje.TheCategoriaDTO = myCategoriaDTO;

                    YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
                    myDirectivaDTO.IdDirectiva = decimal.Parse(wobjDataRow["idDirectiva"].ToString());
                    mensaje.TheDirectivaDTO = myDirectivaDTO;

                    mensaje.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    mensaje.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    mensaje.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 2;
                    myMensajeTipoDTO.NombreMensajeTipo = "Administración";
                    mensaje.TheMensajeTipoDTO = myMensajeTipoDTO;

                    mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje.Estado = wobjDataRow["estado"].ToString();

                    IMensaje.Add(mensaje);
                }
            }

            if (YouCom.Mensajeria.DAL.MensajePorteriaDAL.getListadoMensajePorteria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

                    mensaje.IdMensaje = decimal.Parse(wobjDataRow["IdMensajePorteria"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    mensaje.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    mensaje.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje.TheCategoriaDTO = myCategoriaDTO;

                    YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
                    myPorteriaDTO.IdPorteria = decimal.Parse(wobjDataRow["idPorteria"].ToString());
                    mensaje.ThePorteriaDTO = myPorteriaDTO;

                    mensaje.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    mensaje.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    mensaje.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 3;
                    myMensajeTipoDTO.NombreMensajeTipo = "Porteria";
                    mensaje.TheMensajeTipoDTO = myMensajeTipoDTO;

                    mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje.Estado = wobjDataRow["estado"].ToString();

                    IMensaje.Add(mensaje);
                }
            }

            if (YouCom.Mensajeria.DAL.MensajePropietarioDAL.getListadoMensajePropietario(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    if(decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString()) == idFamilia)
                    {
                        YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

                        mensaje.IdMensaje = decimal.Parse(wobjDataRow["IdMensajeDirectiva"].ToString());

                        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                        myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                        mensaje.TheCondominioDTO = myCondominioDTO;

                        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                        myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                        mensaje.TheComunidadDTO = myComunidadDTO;

                        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                        myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                        myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                        mensaje.TheCategoriaDTO = myCategoriaDTO;

                        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                        myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                        mensaje.TheFamiliaDTO = myFamiliaDTO;

                        mensaje.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                        mensaje.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                        mensaje.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                        YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                        myMensajeTipoDTO.IdMensajeTipo = 1;
                        myMensajeTipoDTO.NombreMensajeTipo = "Propietario";
                        mensaje.TheMensajeTipoDTO = myMensajeTipoDTO;

                        mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                        mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                        mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                        mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                        mensaje.Estado = wobjDataRow["estado"].ToString();

                        IMensaje.Add(mensaje);
                    }
                }
            }

            return IMensaje;

        }

        public static IList<YouCom.DTO.Mensajeria.MensajeDTO> getListadoTodosMensajes()
        {
            IList<YouCom.DTO.Mensajeria.MensajeDTO> IMensaje = new List<YouCom.DTO.Mensajeria.MensajeDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.MensajeDirectivaDAL.getListadoMensajeDirectiva(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

                    mensaje.IdMensaje = decimal.Parse(wobjDataRow["IdMensajeDirectiva"].ToString());

                    mensaje.IdPadre = !string.IsNullOrEmpty(wobjDataRow["IdPadre"].ToString()) ? decimal.Parse(wobjDataRow["IdPadre"].ToString()): 0;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    mensaje.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    mensaje.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
                    myDirectivaDTO.IdDirectiva = decimal.Parse(wobjDataRow["idDirectiva"].ToString());
                    myDirectivaDTO.NombreDirectiva = wobjDataRow["nombreDirectiva"].ToString();
                    myDirectivaDTO.ApellidoPaternoDirectiva = wobjDataRow["apellidoPaternoDirectiva"].ToString();
                    myDirectivaDTO.ApellidoMaternoDirectiva = wobjDataRow["apellidoMaternoDirectiva"].ToString();
                    mensaje.TheDirectivaDTO = myDirectivaDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje.TheCategoriaDTO = myCategoriaDTO;

                    mensaje.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    mensaje.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    mensaje.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();
                    
                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 2;
                    myMensajeTipoDTO.NombreMensajeTipo = "Administración";
                    mensaje.TheMensajeTipoDTO = myMensajeTipoDTO;

                    mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje.Estado = wobjDataRow["estado"].ToString();

                    IMensaje.Add(mensaje);
                }
            }

            if (YouCom.Mensajeria.DAL.MensajePorteriaDAL.getListadoMensajePorteria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

                    mensaje.IdMensaje = decimal.Parse(wobjDataRow["IdMensajePorteria"].ToString());

                    mensaje.IdPadre = !string.IsNullOrEmpty(wobjDataRow["IdPadre"].ToString()) ? decimal.Parse(wobjDataRow["IdPadre"].ToString()) : 0;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    mensaje.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    mensaje.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje.TheCategoriaDTO = myCategoriaDTO;

                    YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
                    myPorteriaDTO.IdPorteria = decimal.Parse(wobjDataRow["idPorteria"].ToString());
                    myPorteriaDTO.NombrePorteria = wobjDataRow["nombrePorteria"].ToString();
                    myPorteriaDTO.ApellidoPaternoPorteria = wobjDataRow["apellidoPaternoPorteria"].ToString();
                    myPorteriaDTO.ApellidoMaternoPorteria = wobjDataRow["apellidoMaternoPorteria"].ToString();
                    mensaje.ThePorteriaDTO = myPorteriaDTO;

                    mensaje.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    mensaje.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    mensaje.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();
                    
                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 3;
                    myMensajeTipoDTO.NombreMensajeTipo = "Porteria";
                    mensaje.TheMensajeTipoDTO = myMensajeTipoDTO;

                    mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje.Estado = wobjDataRow["estado"].ToString();

                    IMensaje.Add(mensaje);
                }
            }

            if (YouCom.Mensajeria.DAL.MensajePropietarioDAL.getListadoMensajePropietario(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

                    mensaje.IdMensaje = decimal.Parse(wobjDataRow["idMensajePropietario"].ToString());

                    mensaje.IdPadre = !string.IsNullOrEmpty(wobjDataRow["IdPadre"].ToString()) ? decimal.Parse(wobjDataRow["IdPadre"].ToString()) : 0;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    mensaje.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    mensaje.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();
                    myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    mensaje.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje.TheCategoriaDTO = myCategoriaDTO;

                    mensaje.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    mensaje.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    mensaje.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();
                    
                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 1;
                    myMensajeTipoDTO.NombreMensajeTipo = "Propietario";
                    mensaje.TheMensajeTipoDTO = myMensajeTipoDTO;

                    mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje.Estado = wobjDataRow["estado"].ToString();

                    IMensaje.Add(mensaje);
                }
            }

            if (YouCom.DAL.NoticiaDAL.getListadoNoticia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

                    mensaje.IdMensaje = decimal.Parse(wobjDataRow["noticia_id"].ToString());

                    mensaje.IdPadre = !string.IsNullOrEmpty(wobjDataRow["IdPadre"].ToString()) ? decimal.Parse(wobjDataRow["IdPadre"].ToString()) : 0;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    mensaje.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    mensaje.TheComunidadDTO = myComunidadDTO;

                    mensaje.MensajeTitulo = wobjDataRow["noticia_titulo"].ToString();
                    mensaje.MensajeDescripcion = wobjDataRow["noticia_resumen"].ToString();

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje.TheCategoriaDTO = myCategoriaDTO;

                    mensaje.MensajeFecha = Convert.ToDateTime(wobjDataRow["noticia_publicacion"].ToString());
                    
                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 4;
                    myMensajeTipoDTO.NombreMensajeTipo = "Noticia";
                    mensaje.TheMensajeTipoDTO = myMensajeTipoDTO;

                    mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje.Estado = wobjDataRow["estado"].ToString();

                    IMensaje.Add(mensaje);
                }
            }

            return IMensaje;

        }

        public static IList<YouCom.DTO.Mensajeria.MensajeDTO> getListadoMensajesInternos()
        {
            IList<YouCom.DTO.Mensajeria.MensajeDTO> IMensaje = new List<YouCom.DTO.Mensajeria.MensajeDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.MensajeDirectivaDAL.getListadoMensajeDirectiva(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

                    mensaje.IdMensaje = decimal.Parse(wobjDataRow["IdMensajeDirectiva"].ToString());

                    mensaje.IdPadre = !string.IsNullOrEmpty(wobjDataRow["IdPadre"].ToString()) ? decimal.Parse(wobjDataRow["IdPadre"].ToString()) : 0;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    mensaje.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    mensaje.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
                    myDirectivaDTO.IdDirectiva = decimal.Parse(wobjDataRow["idDirectiva"].ToString());
                    myDirectivaDTO.NombreDirectiva = wobjDataRow["nombreDirectiva"].ToString();
                    myDirectivaDTO.ApellidoPaternoDirectiva = wobjDataRow["apellidoPaternoDirectiva"].ToString();
                    myDirectivaDTO.ApellidoMaternoDirectiva = wobjDataRow["apellidoMaternoDirectiva"].ToString();
                    mensaje.TheDirectivaDTO = myDirectivaDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje.TheCategoriaDTO = myCategoriaDTO;

                    mensaje.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    mensaje.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    mensaje.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();
                    
                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 2;
                    myMensajeTipoDTO.NombreMensajeTipo = "Administración";
                    mensaje.TheMensajeTipoDTO = myMensajeTipoDTO;

                    mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje.Estado = wobjDataRow["estado"].ToString();

                    IMensaje.Add(mensaje);
                }
            }

            if (YouCom.Mensajeria.DAL.MensajePorteriaDAL.getListadoMensajePorteria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

                    mensaje.IdMensaje = decimal.Parse(wobjDataRow["IdMensajePorteria"].ToString());

                    mensaje.IdPadre = !string.IsNullOrEmpty(wobjDataRow["IdPadre"].ToString()) ? decimal.Parse(wobjDataRow["IdPadre"].ToString()) : 0;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    mensaje.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    mensaje.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje.TheCategoriaDTO = myCategoriaDTO;

                    YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
                    myPorteriaDTO.IdPorteria = decimal.Parse(wobjDataRow["idPorteria"].ToString());
                    myPorteriaDTO.NombrePorteria = wobjDataRow["nombrePorteria"].ToString();
                    myPorteriaDTO.ApellidoPaternoPorteria = wobjDataRow["apellidoPaternoPorteria"].ToString();
                    myPorteriaDTO.ApellidoMaternoPorteria = wobjDataRow["apellidoMaternoPorteria"].ToString();
                    mensaje.ThePorteriaDTO = myPorteriaDTO;

                    mensaje.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    mensaje.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    mensaje.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();
                    
                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 3;
                    myMensajeTipoDTO.NombreMensajeTipo = "Porteria";
                    mensaje.TheMensajeTipoDTO = myMensajeTipoDTO;

                    mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje.Estado = wobjDataRow["estado"].ToString();

                    IMensaje.Add(mensaje);
                }
            }

            //if (YouCom.Mensajeria.DAL.MensajePropietarioDAL.getListadoMensajePropietario(ref pobjDataTable))
            //{
            //    foreach (DataRow wobjDataRow in pobjDataTable.Rows)
            //    {
            //        YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

            //        mensaje.IdMensaje = decimal.Parse(wobjDataRow["idMensajePropietario"].ToString());

            //        mensaje.IdPadre = !string.IsNullOrEmpty(wobjDataRow["IdPadre"].ToString()) ? decimal.Parse(wobjDataRow["IdPadre"].ToString()) : 0;

            //        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
            //        myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
            //        myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
            //        mensaje.TheCondominioDTO = myCondominioDTO;

            //        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
            //        myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
            //        myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
            //        mensaje.TheComunidadDTO = myComunidadDTO;

            //        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
            //        myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
            //        myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
            //        myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();
            //        myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
            //        mensaje.TheFamiliaDTO = myFamiliaDTO;

            //        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
            //        myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
            //        myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
            //        mensaje.TheCategoriaDTO = myCategoriaDTO;

            //        mensaje.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
            //        mensaje.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
            //        mensaje.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();
            //        mensaje.MensajeImagen = wobjDataRow["imagenMensaje"].ToString();

            //        mensaje.QuienEnvia = "Propietario";

            //        mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
            //        mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
            //        mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
            //        mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

            //        mensaje.Estado = wobjDataRow["estado"].ToString();

            //        IMensaje.Add(mensaje);
            //    }
            //}

            if (YouCom.DAL.NoticiaDAL.getListadoNoticia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

                    mensaje.IdMensaje = decimal.Parse(wobjDataRow["noticia_id"].ToString());

                    mensaje.IdPadre = !string.IsNullOrEmpty(wobjDataRow["IdPadre"].ToString()) ? decimal.Parse(wobjDataRow["IdPadre"].ToString()) : 0;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    mensaje.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    mensaje.TheComunidadDTO = myComunidadDTO;

                    mensaje.MensajeTitulo = wobjDataRow["noticia_titulo"].ToString();
                    mensaje.MensajeDescripcion = wobjDataRow["noticia_resumen"].ToString();

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje.TheCategoriaDTO = myCategoriaDTO;

                    mensaje.MensajeFecha = Convert.ToDateTime(wobjDataRow["noticia_publicacion"].ToString());
                    
                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 4;
                    myMensajeTipoDTO.NombreMensajeTipo = "Noticia";
                    mensaje.TheMensajeTipoDTO = myMensajeTipoDTO;

                    mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje.Estado = wobjDataRow["estado"].ToString();

                    IMensaje.Add(mensaje);
                }
            }

            return IMensaje;

        }

        public static IList<YouCom.DTO.Mensajeria.MensajeDTO> getListadoMensajesPropietarios()
        {
            IList<YouCom.DTO.Mensajeria.MensajeDTO> IMensaje = new List<YouCom.DTO.Mensajeria.MensajeDTO>();

            DataTable pobjDataTable = new DataTable();

            //if (YouCom.Mensajeria.DAL.MensajeDirectivaDAL.getListadoMensajeDirectiva(ref pobjDataTable))
            //{
            //    foreach (DataRow wobjDataRow in pobjDataTable.Rows)
            //    {
            //        YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

            //        mensaje.IdMensaje = decimal.Parse(wobjDataRow["IdMensajeDirectiva"].ToString());

            //        mensaje.IdPadre = !string.IsNullOrEmpty(wobjDataRow["IdPadre"].ToString()) ? decimal.Parse(wobjDataRow["IdPadre"].ToString()) : 0;

            //        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
            //        myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
            //        myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
            //        mensaje.TheCondominioDTO = myCondominioDTO;

            //        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
            //        myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
            //        myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
            //        mensaje.TheComunidadDTO = myComunidadDTO;

            //        YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
            //        myDirectivaDTO.IdDirectiva = decimal.Parse(wobjDataRow["idDirectiva"].ToString());
            //        myDirectivaDTO.NombreDirectiva = wobjDataRow["nombreDirectiva"].ToString();
            //        myDirectivaDTO.ApellidoPaternoDirectiva = wobjDataRow["apellidoPaternoDirectiva"].ToString();
            //        myDirectivaDTO.ApellidoMaternoDirectiva = wobjDataRow["apellidoMaternoDirectiva"].ToString();
            //        mensaje.TheDirectivaDTO = myDirectivaDTO;

            //        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
            //        myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
            //        myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
            //        mensaje.TheCategoriaDTO = myCategoriaDTO;

            //        mensaje.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
            //        mensaje.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
            //        mensaje.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();
            //        mensaje.MensajeImagen = wobjDataRow["imagenMensaje"].ToString();

            //        mensaje.QuienEnvia = "Administración";

            //        mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
            //        mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
            //        mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
            //        mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

            //        mensaje.Estado = wobjDataRow["estado"].ToString();

            //        IMensaje.Add(mensaje);
            //    }
            //}

            //if (YouCom.Mensajeria.DAL.MensajePorteriaDAL.getListadoMensajePorteria(ref pobjDataTable))
            //{
            //    foreach (DataRow wobjDataRow in pobjDataTable.Rows)
            //    {
            //        YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

            //        mensaje.IdMensaje = decimal.Parse(wobjDataRow["IdMensajePorteria"].ToString());

            //        mensaje.IdPadre = !string.IsNullOrEmpty(wobjDataRow["IdPadre"].ToString()) ? decimal.Parse(wobjDataRow["IdPadre"].ToString()) : 0;

            //        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
            //        myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
            //        myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
            //        mensaje.TheCondominioDTO = myCondominioDTO;

            //        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
            //        myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
            //        myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
            //        mensaje.TheComunidadDTO = myComunidadDTO;

            //        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
            //        myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
            //        myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
            //        mensaje.TheCategoriaDTO = myCategoriaDTO;

            //        YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
            //        myPorteriaDTO.IdPorteria = decimal.Parse(wobjDataRow["idPorteria"].ToString());
            //        myPorteriaDTO.NombrePorteria = wobjDataRow["nombrePorteria"].ToString();
            //        myPorteriaDTO.ApellidoPaternoPorteria = wobjDataRow["apellidoPaternoPorteria"].ToString();
            //        myPorteriaDTO.ApellidoMaternoPorteria = wobjDataRow["apellidoMaternoPorteria"].ToString();
            //        mensaje.ThePorteriaDTO = myPorteriaDTO;

            //        mensaje.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
            //        mensaje.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
            //        mensaje.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();
            //        mensaje.MensajeImagen = wobjDataRow["imagenMensaje"].ToString();

            //        mensaje.QuienEnvia = "Porteria";

            //        mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
            //        mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
            //        mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
            //        mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

            //        mensaje.Estado = wobjDataRow["estado"].ToString();

            //        IMensaje.Add(mensaje);
            //    }
            //}

            if (YouCom.Mensajeria.DAL.MensajePropietarioDAL.getListadoMensajePropietario(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

                    mensaje.IdMensaje = decimal.Parse(wobjDataRow["idMensajePropietario"].ToString());

                    mensaje.IdPadre = !string.IsNullOrEmpty(wobjDataRow["IdPadre"].ToString()) ? decimal.Parse(wobjDataRow["IdPadre"].ToString()) : 0;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    mensaje.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    mensaje.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();
                    myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    mensaje.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
                    mensaje.TheCategoriaDTO = myCategoriaDTO;

                    mensaje.MensajeFecha = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    mensaje.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    mensaje.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();
                    
                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 1;
                    myMensajeTipoDTO.NombreMensajeTipo = "Propietario";
                    mensaje.TheMensajeTipoDTO = myMensajeTipoDTO;

                    mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    mensaje.Estado = wobjDataRow["estado"].ToString();

                    IMensaje.Add(mensaje);
                }
            }

            //if (YouCom.DAL.NoticiaDAL.getListadoNoticia(ref pobjDataTable))
            //{
            //    foreach (DataRow wobjDataRow in pobjDataTable.Rows)
            //    {
            //        YouCom.DTO.Mensajeria.MensajeDTO mensaje = new YouCom.DTO.Mensajeria.MensajeDTO();

            //        mensaje.IdMensaje = decimal.Parse(wobjDataRow["noticia_id"].ToString());

            //        mensaje.IdPadre = !string.IsNullOrEmpty(wobjDataRow["IdPadre"].ToString()) ? decimal.Parse(wobjDataRow["IdPadre"].ToString()) : 0;

            //        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
            //        myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
            //        myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
            //        mensaje.TheCondominioDTO = myCondominioDTO;

            //        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
            //        myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
            //        myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
            //        mensaje.TheComunidadDTO = myComunidadDTO;

            //        mensaje.MensajeTitulo = wobjDataRow["noticia_titulo"].ToString();
            //        mensaje.MensajeDescripcion = wobjDataRow["noticia_resumen"].ToString();

            //        YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
            //        myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
            //        myCategoriaDTO.NombreCategoria = wobjDataRow["nombreCategoria"].ToString();
            //        mensaje.TheCategoriaDTO = myCategoriaDTO;

            //        mensaje.MensajeFecha = Convert.ToDateTime(wobjDataRow["noticia_publicacion"].ToString());
            //        mensaje.MensajeImagen = wobjDataRow["noticia_imagen"].ToString();

            //        mensaje.QuienEnvia = "Noticia";

            //        mensaje.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
            //        mensaje.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
            //        mensaje.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
            //        mensaje.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

            //        mensaje.Estado = wobjDataRow["estado"].ToString();

            //        IMensaje.Add(mensaje);
            //    }
            //}

            return IMensaje;

        }
    }
}
