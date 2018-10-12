using System;
using System.Collections.Generic;
using System.Data;

namespace YouCom.facade.Notificaciones
{
    public class NotificacionNoticia
    {
        public static IList<YouCom.DTO.Notificaciones.NotificacionNoticiaDTO> getListadoNotificaciones()
        {
            IList<YouCom.DTO.Notificaciones.NotificacionNoticiaDTO> INotificacionNoticia = new List<YouCom.DTO.Notificaciones.NotificacionNoticiaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.getListadoNotificaciones(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionNoticiaDTO notificaciones = new YouCom.DTO.Notificaciones.NotificacionNoticiaDTO();

                    notificaciones.IdNotificacionNoticia = decimal.Parse(wobjDataRow["IdNotificacionNoticia"].ToString());

                    YouCom.DTO.Mensajeria.MensajeNoticiaDTO myMensajeNoticiaDTO = new DTO.Mensajeria.MensajeNoticiaDTO();
                    myMensajeNoticiaDTO.IdMensajeNoticia = decimal.Parse(wobjDataRow["IdMensajeNoticia"].ToString());
                    myMensajeNoticiaDTO.IdPadre = decimal.Parse(wobjDataRow["IdPadre"].ToString());
                    myMensajeNoticiaDTO.MensajeDescripcion = wobjDataRow["mensajeDescripcion"].ToString();
                    myMensajeNoticiaDTO.MensajeTitulo = wobjDataRow["mensajeTitulo"].ToString();
                    notificaciones.TheMensajeNoticiaDTO = myMensajeNoticiaDTO;

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

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamiliaOrigen"].ToString());
                    myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamiliaOrigen"].ToString();
                    myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamiliaOrigen"].ToString();
                    myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamiliaOrigen"].ToString();
                    notificaciones.TheFamiliaCreadorDTO = myFamiliaDTO;

                    if (!string.IsNullOrEmpty(wobjDataRow["idFamiliaDestino"].ToString()))
                    {
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

                    INotificacionNoticia.Add(notificaciones);
                }
            }

            return INotificacionNoticia;

        }

        public static IList<YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionNoticiaDTO> getListadoResumenNotificaciones()
        {
            IList<YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionNoticiaDTO> IResumenNotificacionNoticiaDTO = new List<YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionNoticiaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.getListadoResumenNotificacion(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionNoticiaDTO resumen = new YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionNoticiaDTO();

                    YouCom.DTO.Notificaciones.NotificacionNoticiaDTO myNotificacionNoticiaDTO = new YouCom.DTO.Notificaciones.NotificacionNoticiaDTO();
                    myNotificacionNoticiaDTO.IdNotificacionNoticia = decimal.Parse(wobjDataRow["IdNotificacionNoticia"].ToString());
                    myNotificacionNoticiaDTO.FechaNotificacion = DateTime.Parse(wobjDataRow["fechaNotificacion"].ToString());
                    myNotificacionNoticiaDTO.VerNotificacion = wobjDataRow["verNotificacion"].ToString();
                    resumen.TheNotificacionNoticiaDTO = myNotificacionNoticiaDTO;

                    YouCom.DTO.Mensajeria.MensajeNoticiaDTO myMensajeNoticiaDTO = new DTO.Mensajeria.MensajeNoticiaDTO();
                    myMensajeNoticiaDTO.IdMensajeNoticia = decimal.Parse(wobjDataRow["IdMensajeNoticia"].ToString());
                    myMensajeNoticiaDTO.IdPadre = decimal.Parse(wobjDataRow["IdPadre"].ToString());
                    myMensajeNoticiaDTO.MensajeDescripcion = wobjDataRow["mensajeDescripcion"].ToString();
                    myMensajeNoticiaDTO.MensajeTitulo = wobjDataRow["mensajeTitulo"].ToString();
                    resumen.TheMensajeNoticiaDTO = myMensajeNoticiaDTO;

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

                    IResumenNotificacionNoticiaDTO.Add(resumen);
                }
            }

            return IResumenNotificacionNoticiaDTO;

        }
    }
}
