using System;
using System.Collections.Generic;
using System.Data;

namespace YouCom.facade.Notificaciones
{
    public class NotificacionDirectiva
    {
        public static IList<YouCom.DTO.Notificaciones.NotificacionDirectivaDTO> getListadoNotificaciones()
        {
            IList<YouCom.DTO.Notificaciones.NotificacionDirectivaDTO> INotificacionDirectiva = new List<YouCom.DTO.Notificaciones.NotificacionDirectivaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.getListadoNotificaciones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionDirectivaDTO notificaciones = new YouCom.DTO.Notificaciones.NotificacionDirectivaDTO();

                    notificaciones.IdNotificacionDirectiva = decimal.Parse(wobjDataRow["IdNotificacionDirectiva"].ToString());

                    YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new DTO.Mensajeria.MensajeDirectivaDTO();
                    myMensajeDirectivaDTO.IdMensajeDirectiva = decimal.Parse(wobjDataRow["IdMensajeDirectiva"].ToString());
                    myMensajeDirectivaDTO.IdPadre = decimal.Parse(wobjDataRow["IdPadre"].ToString());
                    myMensajeDirectivaDTO.MensajeDescripcion = wobjDataRow["mensajeDescripcion"].ToString();
                    myMensajeDirectivaDTO.MensajeTitulo = wobjDataRow["mensajeTitulo"].ToString();
                    notificaciones.TheMensajeDirectivaDTO = myMensajeDirectivaDTO;

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

                    YouCom.DTO.DirectivaDTO myDirectivaDTO = new YouCom.DTO.DirectivaDTO();
                    myDirectivaDTO.IdDirectiva = decimal.Parse(wobjDataRow["idDirectiva"].ToString());
                    myDirectivaDTO.NombreDirectiva = wobjDataRow["nombreDirectiva"].ToString();
                    myDirectivaDTO.ApellidoPaternoDirectiva = wobjDataRow["apellidoPaternoDirectiva"].ToString();
                    myDirectivaDTO.ApellidoMaternoDirectiva = wobjDataRow["apellidoMaternoDirectiva"].ToString();
                    notificaciones.TheDirectivaDTO = myDirectivaDTO;

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

                    INotificacionDirectiva.Add(notificaciones);
                }
            }

            return INotificacionDirectiva;

        }

        public static IList<YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDirectivaDTO> getListadoResumenNotificaciones()
        {
            IList<YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDirectivaDTO> IResumenNotificacionDirectivaDTO = new List<YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDirectivaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.getListadoResumenNotificacion(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDirectivaDTO resumen = new YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDirectivaDTO();

                    YouCom.DTO.Notificaciones.NotificacionDirectivaDTO myNotificacionDirectivaDTO = new YouCom.DTO.Notificaciones.NotificacionDirectivaDTO();
                    myNotificacionDirectivaDTO.IdNotificacionDirectiva = decimal.Parse(wobjDataRow["IdNotificacionDirectiva"].ToString());
                    myNotificacionDirectivaDTO.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    myNotificacionDirectivaDTO.VerNotificacion = wobjDataRow["verNotificacion"].ToString();
                    resumen.TheNotificacionDirectivaDTO = myNotificacionDirectivaDTO;

                    YouCom.DTO.Mensajeria.MensajeDirectivaDTO myMensajeDirectivaDTO = new DTO.Mensajeria.MensajeDirectivaDTO();
                    myMensajeDirectivaDTO.IdMensajeDirectiva = decimal.Parse(wobjDataRow["IdMensajeDirectiva"].ToString());
                    myMensajeDirectivaDTO.IdPadre = decimal.Parse(wobjDataRow["IdPadre"].ToString());
                    myMensajeDirectivaDTO.MensajeDescripcion = wobjDataRow["mensajeDescripcion"].ToString();
                    myMensajeDirectivaDTO.MensajeTitulo = wobjDataRow["mensajeTitulo"].ToString();
                    resumen.TheMensajeDirectivaDTO = myMensajeDirectivaDTO;

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

                    IResumenNotificacionDirectivaDTO.Add(resumen);
                }
            }

            return IResumenNotificacionDirectivaDTO;

        }
    }
}
