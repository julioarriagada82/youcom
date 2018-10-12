using System;
using System.Data;

namespace YouCom.Mensajeria.DAL.Notificaciones
{
    public class NotificacionPorteriaDAL
    {
        #region " Metodo getNotificaciones "
        public static bool getListadoNotificaciones(ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_ListadoNotificacionPorteria",
                                           "YouCom",
                                           pobjDataTable) <= 0)
                {
                    retorno = false;
                }
                else
                {
                    retorno = true;
                }
                //====================================================================================
            }

            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion

            return retorno;
        }
        #endregion // ElementsPersistence

        #region " Metodo getResumenNotificaciones "
        public static bool getListadoResumenNotificacion(ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_ListadoResumenNotificacionPorteria",
                                           "YouCom",
                                           pobjDataTable) <= 0)
                {
                    retorno = false;
                }
                else
                {
                    retorno = true;
                }
                //====================================================================================
            }

            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion

            return retorno;
        }
        #endregion // ElementsPersistence

        #region " Metodo Insert "
        public static bool Insert(YouCom.DTO.Notificaciones.NotificacionPorteriaDTO myNotificacionPorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myNotificacionPorteriaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myNotificacionPorteriaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdNotificacionAccion", SqlDbType.Decimal, -1, myNotificacionPorteriaDTO.TheNotificacionAccionDTO.IdNotificacionAccion);
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myNotificacionPorteriaDTO.TheMensajePorteriaDTO.IdMensajePorteria);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myNotificacionPorteriaDTO.TheMensajePorteriaDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdPorteria", SqlDbType.Decimal, -1, myNotificacionPorteriaDTO.ThePorteriaDTO.IdPorteria > 0 ? myNotificacionPorteriaDTO.ThePorteriaDTO.IdPorteria : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myNotificacionPorteriaDTO.TheFamiliaDestinoDTO.IdFamilia > 0 ? myNotificacionPorteriaDTO.TheFamiliaDestinoDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pFechaNotificacion", SqlDbType.DateTime, -1, myNotificacionPorteriaDTO.FechaNotificacion);
                wobjSQLHelper.SetParametro("@pVerNotificacion", SqlDbType.Char, 5, myNotificacionPorteriaDTO.VerNotificacion);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myNotificacionPorteriaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_NotificacionPorteria", "YouCom"))
                {
                    case 0:
                        throw new Exception("No se pudo grabar.");
                    case -1:
                        throw new Exception("Hubo un error.");
                    case -2:
                        throw new Exception("Hubo un error.");
                }
                //====================================================================================

                retorno = true;
            }

            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion

            return retorno;
        }
        #endregion // Metodo SaveOrUpdatePersistence

        #region " Metodo Update "
        public static bool Update(YouCom.DTO.Notificaciones.NotificacionPorteriaDTO myNotificacionPorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myNotificacionPorteriaDTO.TheMensajePorteriaDTO.IdMensajePorteria);
                wobjSQLHelper.SetParametro("@pVerNotificacion", SqlDbType.Char, 5, myNotificacionPorteriaDTO.VerNotificacion);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myNotificacionPorteriaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_NotificacionPorteria", "YouCom"))
                {
                    case 0:
                        throw new Exception("No se pudo grabar.");
                    case -1:
                        throw new Exception("Hubo un error.");
                    case -2:
                        throw new Exception("Hubo un error.");
                }
                //====================================================================================

                retorno = true;
            }

            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion

            return retorno;
        }
        #endregion // Metodo SaveOrUpdatePersistence

        #region " Metodo Delete "
        public static bool Delete(YouCom.DTO.Notificaciones.NotificacionPorteriaDTO theNotificacionesDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdNotificacionPorteria", SqlDbType.Decimal, -1, theNotificacionesDTO.IdNotificacionPorteria);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, theNotificacionesDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_NotificacionPorteria", "YouCom"))
                {
                    case 0:
                        throw new Exception("No se pudo grabar.");
                    case -1:
                        throw new Exception("Hubo un error.");
                    case -2:
                        throw new Exception("Hubo un error.");
                }
                //====================================================================================

                retorno = true;
            }

            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion

            return retorno;
        }
        #endregion // Metodo SaveOrUpdatePersistence
    }
}
