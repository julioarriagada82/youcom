using System;
using System.Collections.Generic;
using System.Data;

namespace YouCom.facade.Notificaciones
{
    public class NotificacionPorteria
    {
        public static IList<YouCom.DTO.Notificaciones.NotificacionPorteriaDTO> getListadoNotificaciones()
        {
            IList<YouCom.DTO.Notificaciones.NotificacionPorteriaDTO> INotificacionPorteria = new List<YouCom.DTO.Notificaciones.NotificacionPorteriaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.getListadoNotificaciones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionPorteriaDTO notificaciones = new YouCom.DTO.Notificaciones.NotificacionPorteriaDTO();

                    notificaciones.IdNotificacionPorteria = decimal.Parse(wobjDataRow["IdNotificacionPorteria"].ToString());

                    YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO = new DTO.Mensajeria.MensajePorteriaDTO();
                    myMensajePorteriaDTO.IdMensajePorteria = decimal.Parse(wobjDataRow["IdMensajePorteria"].ToString());
                    myMensajePorteriaDTO.IdPadre = decimal.Parse(wobjDataRow["IdPadre"].ToString());
                    myMensajePorteriaDTO.MensajeDescripcion = wobjDataRow["mensajeDescripcion"].ToString();
                    myMensajePorteriaDTO.MensajeTitulo = wobjDataRow["mensajeTitulo"].ToString();
                    notificaciones.TheMensajePorteriaDTO = myMensajePorteriaDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    notificaciones.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    notificaciones.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Notificaciones.NotificacionAccionDTO myNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();
                    myNotificacionAccionDTO.IdNotificacionAccion = decimal.Parse(wobjDataRow["idNotificacionAccion"].ToString());
                    myNotificacionAccionDTO.NombreNotificacionAccion = wobjDataRow["nombreNotificacionAccion"].ToString();
                    notificaciones.TheNotificacionAccionDTO = myNotificacionAccionDTO;

                    YouCom.DTO.PorteriaDTO myPorteriaDTO = new YouCom.DTO.PorteriaDTO();
                    myPorteriaDTO.IdPorteria = decimal.Parse(wobjDataRow["idPorteria"].ToString());
                    myPorteriaDTO.NombrePorteria = wobjDataRow["nombrePorteria"].ToString();
                    myPorteriaDTO.ApellidoPaternoPorteria = wobjDataRow["apellidoPaternoPorteria"].ToString();
                    myPorteriaDTO.ApellidoMaternoPorteria = wobjDataRow["apellidoMaternoPorteria"].ToString();
                    notificaciones.ThePorteriaDTO = myPorteriaDTO;

                    if (!string.IsNullOrEmpty(wobjDataRow["idFamiliaDestino"].ToString()))
                    {
                        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                        myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaDestino"].ToString());
                        myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamiliaDestino"].ToString();
                        myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaDestino"].ToString();
                        myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaDestino"].ToString();
                        notificaciones.TheFamiliaDestinoDTO = myFamiliaDTO;
                    }

                    notificaciones.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    notificaciones.VerNotificacion = wobjDataRow["verNotificacion"].ToString();

                    notificaciones.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificaciones.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificaciones.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificaciones.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificaciones.Estado = wobjDataRow["estado"].ToString();

                    INotificacionPorteria.Add(notificaciones);
                }
            }

            return INotificacionPorteria;

        }

        public static IList<YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionPorteriaDTO> getListadoResumenNotificaciones()
        {
            IList<YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionPorteriaDTO> IResumenNotificacionPorteriaDTO = new List<YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionPorteriaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.getListadoResumenNotificacion(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionPorteriaDTO resumen = new YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionPorteriaDTO();

                    YouCom.DTO.Notificaciones.NotificacionPorteriaDTO myNotificacionPorteriaDTO = new YouCom.DTO.Notificaciones.NotificacionPorteriaDTO();
                    myNotificacionPorteriaDTO.IdNotificacionPorteria = decimal.Parse(wobjDataRow["IdNotificacionPorteria"].ToString());
                    myNotificacionPorteriaDTO.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    myNotificacionPorteriaDTO.VerNotificacion = wobjDataRow["verNotificacion"].ToString();
                    resumen.TheNotificacionPorteriaDTO = myNotificacionPorteriaDTO;

                    YouCom.DTO.Mensajeria.MensajePorteriaDTO myMensajePorteriaDTO = new DTO.Mensajeria.MensajePorteriaDTO();
                    myMensajePorteriaDTO.IdMensajePorteria = decimal.Parse(wobjDataRow["IdMensajePorteria"].ToString());
                    myMensajePorteriaDTO.IdPadre = decimal.Parse(wobjDataRow["IdPadre"].ToString());
                    myMensajePorteriaDTO.MensajeDescripcion = wobjDataRow["mensajeDescripcion"].ToString();
                    myMensajePorteriaDTO.MensajeTitulo = wobjDataRow["mensajeTitulo"].ToString();
                    resumen.TheMensajePorteriaDTO = myMensajePorteriaDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    myCondominioDTO.NombreCondominio = wobjDataRow["nombreCondominio"].ToString();
                    resumen.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    myComunidadDTO.NombreComunidad = wobjDataRow["nombreComunidad"].ToString();
                    resumen.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Notificaciones.NotificacionAccionDTO myNotificacionAccionDTO = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();
                    myNotificacionAccionDTO.IdNotificacionAccion = decimal.Parse(wobjDataRow["idNotificacionAccion"].ToString());
                    myNotificacionAccionDTO.NombreNotificacionAccion = wobjDataRow["nombreNotificacionAccion"].ToString();
                    resumen.TheNotificacionAccionDTO = myNotificacionAccionDTO;

                    if (!string.IsNullOrEmpty(wobjDataRow["idFamilia"].ToString()))
                    {
                        YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                        myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                        myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamilia"].ToString();
                        myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamilia"].ToString();
                        myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamilia"].ToString();
                        resumen.TheFamiliaDTO = myFamiliaDTO;
                    }

                    resumen.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    resumen.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    resumen.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    resumen.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    resumen.Estado = wobjDataRow["estado"].ToString();

                    IResumenNotificacionPorteriaDTO.Add(resumen);
                }
            }

            return IResumenNotificacionPorteriaDTO;

        }
    }
}
