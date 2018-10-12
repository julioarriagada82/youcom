using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Notificaciones
{
    public class Notificacion
    {
        public static IList<YouCom.DTO.Notificaciones.NotificacionDTO> getListadoNotificaciones()
        {
            IList<YouCom.DTO.Notificaciones.NotificacionDTO> INotificacion = new List<YouCom.DTO.Notificaciones.NotificacionDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionDirectivaDAL.getListadoNotificacion(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionDTO notificacion = new YouCom.DTO.Notificaciones.NotificacionDTO();

                    notificacion.IdNotificacion = decimal.Parse(wobjDataRow["IdNotificacionDirectiva"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new YouCom.DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = decimal.Parse(wobjDataRow["IdMensajeDirectiva"].ToString());
                    myMensajeDTO.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    myMensajeDTO.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaOrigenDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaOrigenDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaOrigenDTO.RutFamilia = wobjDataRow["rutFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();

                    myMensajeDTO.TheFamiliaDTO = myFamiliaOrigenDTO;

                    notificacion.TheMensajeDTO = myMensajeDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    notificacion.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    notificacion.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
                    myDirectivaDTO.IdDirectiva = decimal.Parse(wobjDataRow["idDirectiva"].ToString());
                    notificacion.TheDirectivaDTO = myDirectivaDTO;

                    notificacion.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    notificacion.VerNotificacion = wobjDataRow["verNotificacion"].ToString().Trim();
                    
                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 2;
                    myMensajeTipoDTO.NombreMensajeTipo = "Administración";
                    notificacion.TheMensajeTipoDTO = myMensajeTipoDTO;

                    notificacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificacion.Estado = wobjDataRow["estado"].ToString();

                    INotificacion.Add(notificacion);
                }
            }

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPorteriaDAL.getListadoNotificaciones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionDTO notificacion = new YouCom.DTO.Notificaciones.NotificacionDTO();

                    notificacion.IdNotificacion = decimal.Parse(wobjDataRow["IdNotificacionPorteria"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new YouCom.DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = decimal.Parse(wobjDataRow["IdMensajePorteria"].ToString());
                    myMensajeDTO.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    myMensajeDTO.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaOrigenDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaOrigenDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaOrigenDTO.RutFamilia = wobjDataRow["rutFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();

                    myMensajeDTO.TheFamiliaDTO = myFamiliaOrigenDTO;

                    notificacion.TheMensajeDTO = myMensajeDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    notificacion.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    notificacion.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
                    myPorteriaDTO.IdPorteria = decimal.Parse(wobjDataRow["idPorteria"].ToString());
                    notificacion.ThePorteriaDTO = myPorteriaDTO;

                    notificacion.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    notificacion.VerNotificacion = wobjDataRow["verNotificacion"].ToString().Trim();
                    
                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 3;
                    myMensajeTipoDTO.NombreMensajeTipo = "Porteria";
                    notificacion.TheMensajeTipoDTO = myMensajeTipoDTO;

                    notificacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificacion.Estado = wobjDataRow["estado"].ToString();

                    INotificacion.Add(notificacion);
                }
            }

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.getListadoNotificaciones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionDTO notificacion = new YouCom.DTO.Notificaciones.NotificacionDTO();

                    notificacion.IdNotificacion = decimal.Parse(wobjDataRow["IdNotificacionPropietario"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new YouCom.DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = decimal.Parse(wobjDataRow["IdMensajePropietario"].ToString());
                    myMensajeDTO.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    myMensajeDTO.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaOrigenDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaOrigenDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaOrigenDTO.RutFamilia = wobjDataRow["rutFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();

                    myMensajeDTO.TheFamiliaDTO = myFamiliaOrigenDTO;

                    notificacion.TheMensajeDTO = myMensajeDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    notificacion.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    notificacion.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    notificacion.TheFamiliaDTO = myFamiliaDTO;

                    notificacion.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    notificacion.VerNotificacion = wobjDataRow["verNotificacion"].ToString().Trim();

                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 1;
                    myMensajeTipoDTO.NombreMensajeTipo = "Propietario";
                    notificacion.TheMensajeTipoDTO = myMensajeTipoDTO;

                    notificacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificacion.Estado = wobjDataRow["estado"].ToString();

                    INotificacion.Add(notificacion);
                }
            }

            return INotificacion;

        }

        public static IList<YouCom.DTO.Notificaciones.NotificacionDTO> getListadoTodasNotificaciones()
        {
            IList<YouCom.DTO.Notificaciones.NotificacionDTO> INotificacion = new List<YouCom.DTO.Notificaciones.NotificacionDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionDirectivaDAL.getListadoNotificacion(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionDTO notificacion = new YouCom.DTO.Notificaciones.NotificacionDTO();

                    notificacion.IdNotificacion = decimal.Parse(wobjDataRow["IdNotificacionDirectiva"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new YouCom.DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = decimal.Parse(wobjDataRow["IdMensajeDirectiva"].ToString());
                    myMensajeDTO.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    myMensajeDTO.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaOrigenDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaOrigenDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaOrigenDTO.RutFamilia = wobjDataRow["rutFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();

                    myMensajeDTO.TheFamiliaDTO = myFamiliaOrigenDTO;

                    notificacion.TheMensajeDTO = myMensajeDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    notificacion.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    notificacion.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
                    myDirectivaDTO.IdDirectiva = decimal.Parse(wobjDataRow["idDirectiva"].ToString());
                    myDirectivaDTO.NombreDirectiva = wobjDataRow["nombreDirectiva"].ToString();
                    myDirectivaDTO.ApellidoPaternoDirectiva = wobjDataRow["apellidoPaternoDirectiva"].ToString();
                    myDirectivaDTO.ApellidoMaternoDirectiva = wobjDataRow["apellidoMaternoDirectiva"].ToString();
                    myDirectivaDTO.RutDirectiva = wobjDataRow["rutDirectiva"].ToString();
                    notificacion.TheDirectivaDTO = myDirectivaDTO;

                    notificacion.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    notificacion.VerNotificacion = wobjDataRow["verNotificacion"].ToString();

                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 2;
                    myMensajeTipoDTO.NombreMensajeTipo = "Administración";
                    notificacion.TheMensajeTipoDTO = myMensajeTipoDTO;

                    notificacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificacion.Estado = wobjDataRow["estado"].ToString();

                    INotificacion.Add(notificacion);
                }
            }

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPorteriaDAL.getListadoNotificaciones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionDTO notificacion = new YouCom.DTO.Notificaciones.NotificacionDTO();

                    notificacion.IdNotificacion = decimal.Parse(wobjDataRow["IdNotificacionPorteria"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new YouCom.DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = decimal.Parse(wobjDataRow["IdMensajePorteria"].ToString());
                    myMensajeDTO.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    myMensajeDTO.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaOrigenDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaOrigenDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaOrigenDTO.RutFamilia = wobjDataRow["rutFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();

                    myMensajeDTO.TheFamiliaDTO = myFamiliaOrigenDTO;

                    notificacion.TheMensajeDTO = myMensajeDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    notificacion.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    notificacion.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
                    myPorteriaDTO.IdPorteria = decimal.Parse(wobjDataRow["idPorteria"].ToString());
                    myPorteriaDTO.NombrePorteria = wobjDataRow["nombrePorteria"].ToString();
                    myPorteriaDTO.RutPorteria = wobjDataRow["rutPorteria"].ToString();
                    notificacion.ThePorteriaDTO = myPorteriaDTO;

                    notificacion.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    notificacion.VerNotificacion = wobjDataRow["verNotificacion"].ToString();

                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 3;
                    myMensajeTipoDTO.NombreMensajeTipo = "Porteria";
                    notificacion.TheMensajeTipoDTO = myMensajeTipoDTO;

                    notificacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificacion.Estado = wobjDataRow["estado"].ToString();

                    INotificacion.Add(notificacion);
                }
            }

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.getListadoNotificaciones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionDTO notificacion = new YouCom.DTO.Notificaciones.NotificacionDTO();

                    notificacion.IdNotificacion = decimal.Parse(wobjDataRow["IdNotificacionPropietario"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new YouCom.DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = decimal.Parse(wobjDataRow["IdMensajePropietario"].ToString());
                    myMensajeDTO.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    myMensajeDTO.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaOrigenDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaOrigenDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaOrigenDTO.RutFamilia = wobjDataRow["rutFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();

                    myMensajeDTO.TheFamiliaDTO = myFamiliaOrigenDTO;

                    notificacion.TheMensajeDTO = myMensajeDTO;


                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    notificacion.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    notificacion.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaDestino"].ToString());
                    myFamiliaDTO.RutFamilia = wobjDataRow["rutFamiliaDestino"].ToString();
                    myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamiliaDestino"].ToString();
                    myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaDestino"].ToString();
                    myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();
                    notificacion.TheFamiliaDTO = myFamiliaDTO;

                    notificacion.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    notificacion.VerNotificacion = wobjDataRow["verNotificacion"].ToString();

                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 1;
                    myMensajeTipoDTO.NombreMensajeTipo = "Propietario";
                    notificacion.TheMensajeTipoDTO = myMensajeTipoDTO;

                    notificacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificacion.Estado = wobjDataRow["estado"].ToString();

                    INotificacion.Add(notificacion);
                }
            }

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionNoticiaDAL.getListadoNotificaciones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionDTO notificacion = new YouCom.DTO.Notificaciones.NotificacionDTO();

                    notificacion.IdNotificacion = decimal.Parse(wobjDataRow["IdNotificacionNoticia"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new YouCom.DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = decimal.Parse(wobjDataRow["IdMensajeNoticia"].ToString());
                    myMensajeDTO.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    myMensajeDTO.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaOrigenDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaOrigenDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaOrigenDTO.RutFamilia = wobjDataRow["rutFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();

                    myMensajeDTO.TheFamiliaDTO = myFamiliaOrigenDTO;
                    notificacion.TheMensajeDTO = myMensajeDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    notificacion.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    notificacion.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    notificacion.TheFamiliaDTO = myFamiliaDTO;

                    notificacion.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    notificacion.VerNotificacion = wobjDataRow["verNotificacion"].ToString();

                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 4;
                    myMensajeTipoDTO.NombreMensajeTipo = "Noticia";
                    notificacion.TheMensajeTipoDTO = myMensajeTipoDTO;

                    notificacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificacion.Estado = wobjDataRow["estado"].ToString();

                    INotificacion.Add(notificacion);
                }
            }

            return INotificacion;

        }

        public static IList<YouCom.DTO.Notificaciones.NotificacionDTO> getListadoNotificacionesInternas()
        {
            IList<YouCom.DTO.Notificaciones.NotificacionDTO> INotificacion = new List<YouCom.DTO.Notificaciones.NotificacionDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionDirectivaDAL.getListadoNotificacion(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionDTO notificacion = new YouCom.DTO.Notificaciones.NotificacionDTO();

                    notificacion.IdNotificacion = decimal.Parse(wobjDataRow["IdNotificacionDirectiva"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new YouCom.DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = decimal.Parse(wobjDataRow["IdMensajeDirectiva"].ToString());
                    myMensajeDTO.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    myMensajeDTO.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaOrigenDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaOrigenDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaOrigenDTO.RutFamilia = wobjDataRow["rutFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();

                    myMensajeDTO.TheFamiliaDTO = myFamiliaOrigenDTO;

                    notificacion.TheMensajeDTO = myMensajeDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    notificacion.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    notificacion.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
                    myDirectivaDTO.IdDirectiva = decimal.Parse(wobjDataRow["idDirectiva"].ToString());
                    notificacion.TheDirectivaDTO = myDirectivaDTO;

                    notificacion.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    notificacion.VerNotificacion = wobjDataRow["verNotificacion"].ToString();

                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 2;
                    myMensajeTipoDTO.NombreMensajeTipo = "Administración";
                    notificacion.TheMensajeTipoDTO = myMensajeTipoDTO;

                    notificacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificacion.Estado = wobjDataRow["estado"].ToString();

                    INotificacion.Add(notificacion);
                }
            }

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPorteriaDAL.getListadoNotificaciones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionDTO notificacion = new YouCom.DTO.Notificaciones.NotificacionDTO();

                    notificacion.IdNotificacion = decimal.Parse(wobjDataRow["IdNotificacionPorteria"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new YouCom.DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = decimal.Parse(wobjDataRow["IdMensajePorteria"].ToString());
                    myMensajeDTO.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    myMensajeDTO.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaOrigenDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaOrigenDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaOrigenDTO.RutFamilia = wobjDataRow["rutFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();

                    myMensajeDTO.TheFamiliaDTO = myFamiliaOrigenDTO;

                    notificacion.TheMensajeDTO = myMensajeDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    notificacion.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    notificacion.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
                    myPorteriaDTO.IdPorteria = decimal.Parse(wobjDataRow["idPorteria"].ToString());
                    notificacion.ThePorteriaDTO = myPorteriaDTO;

                    notificacion.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    notificacion.VerNotificacion = wobjDataRow["verNotificacion"].ToString();

                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 3;
                    myMensajeTipoDTO.NombreMensajeTipo = "Porteria";
                    notificacion.TheMensajeTipoDTO = myMensajeTipoDTO;

                    notificacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificacion.Estado = wobjDataRow["estado"].ToString();

                    INotificacion.Add(notificacion);
                }
            }

            //if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.getListadoNotificaciones(ref pobjDataTable))
            //{
            //    foreach (DataRow wobjDataRow in pobjDataTable.Rows)
            //    {
            //        YouCom.DTO.Notificaciones.NotificacionDTO notificacion = new YouCom.DTO.Notificaciones.NotificacionDTO();

            //        notificacion.IdNotificacion = decimal.Parse(wobjDataRow["IdNotificacionPropietario"].ToString());
            //        notificacion.IdMensaje = decimal.Parse(wobjDataRow["IdMensajePropietario"].ToString());

            //        YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
            //        myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
            //        notificacion.TheCondominioDTO = myCondominioDTO;

            //        YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
            //        myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
            //        notificacion.TheComunidadDTO = myComunidadDTO;

            //        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
            //        myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
            //        notificacion.TheFamiliaDTO = myFamiliaDTO;

            //        notificacion.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
            //        notificacion.VerNotificacion = wobjDataRow["verNotificacion"].ToString();

            //        YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
            //        myMensajeTipoDTO.IdMensajeTipo = 1;
            //        myMensajeTipoDTO.NombreMensajeTipo = "Propietario";
            //        notificacion.TheMensajeTipoDTO = myMensajeTipoDTO;

            //        notificacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
            //        notificacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
            //        notificacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
            //        notificacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

            //        notificacion.Estado = wobjDataRow["estado"].ToString();

            //        INotificacion.Add(notificacion);
            //    }
            //}

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionNoticiaDAL.getListadoNotificaciones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionDTO notificacion = new YouCom.DTO.Notificaciones.NotificacionDTO();

                    notificacion.IdNotificacion = decimal.Parse(wobjDataRow["IdNotificacionNoticia"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new YouCom.DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = decimal.Parse(wobjDataRow["IdMensajeNoticia"].ToString());
                    myMensajeDTO.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    myMensajeDTO.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaOrigenDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaOrigenDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaOrigenDTO.RutFamilia = wobjDataRow["rutFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();

                    myMensajeDTO.TheFamiliaDTO = myFamiliaOrigenDTO;

                    notificacion.TheMensajeDTO = myMensajeDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    notificacion.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    notificacion.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    notificacion.TheFamiliaDTO = myFamiliaDTO;

                    notificacion.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    notificacion.VerNotificacion = wobjDataRow["verNotificacion"].ToString();

                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 4;
                    myMensajeTipoDTO.NombreMensajeTipo = "Noticia";
                    notificacion.TheMensajeTipoDTO = myMensajeTipoDTO;

                    notificacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificacion.Estado = wobjDataRow["estado"].ToString();

                    INotificacion.Add(notificacion);
                }
            }

            return INotificacion;

        }

        public static IList<YouCom.DTO.Notificaciones.NotificacionDTO> getListadoNotificacionesPropietarios()
        {
            IList<YouCom.DTO.Notificaciones.NotificacionDTO> INotificacion = new List<YouCom.DTO.Notificaciones.NotificacionDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.getListadoNotificaciones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionDTO notificacion = new YouCom.DTO.Notificaciones.NotificacionDTO();

                    notificacion.IdNotificacion = decimal.Parse(wobjDataRow["IdNotificacionPropietario"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new YouCom.DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = decimal.Parse(wobjDataRow["IdMensajePropietario"].ToString());
                    myMensajeDTO.MensajeTitulo = wobjDataRow["tituloMensaje"].ToString();
                    myMensajeDTO.MensajeDescripcion = wobjDataRow["descripcionMensaje"].ToString();

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaOrigenDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaOrigenDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaOrigenDTO.RutFamilia = wobjDataRow["rutFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    myFamiliaOrigenDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();

                    myMensajeDTO.TheFamiliaDTO = myFamiliaOrigenDTO;

                    notificacion.TheMensajeDTO = myMensajeDTO;
                    
                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    notificacion.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    notificacion.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    notificacion.TheFamiliaDTO = myFamiliaDTO;

                    notificacion.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    notificacion.VerNotificacion = wobjDataRow["verNotificacion"].ToString();

                    YouCom.DTO.Mensajeria.MensajeTipoDTO myMensajeTipoDTO = new YouCom.DTO.Mensajeria.MensajeTipoDTO();
                    myMensajeTipoDTO.IdMensajeTipo = 1;
                    myMensajeTipoDTO.NombreMensajeTipo = "Propietario";
                    notificacion.TheMensajeTipoDTO = myMensajeTipoDTO;

                    notificacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificacion.Estado = wobjDataRow["estado"].ToString();

                    INotificacion.Add(notificacion);
                }
            }

            return INotificacion;

        }
    }
}
