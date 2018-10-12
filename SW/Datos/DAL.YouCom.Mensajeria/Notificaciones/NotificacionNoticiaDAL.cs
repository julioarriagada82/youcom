using System;
using System.Data;

namespace YouCom.Mensajeria.DAL.Notificaciones
{
    public class NotificacionNoticiaDAL
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoNotificacionNoticia",
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoResumenNotificacionNoticia",
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
        public static bool Insert(YouCom.DTO.Notificaciones.NotificacionNoticiaDTO myNotificacionNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myNotificacionNoticiaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myNotificacionNoticiaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdNotificacionAccion", SqlDbType.Decimal, -1, myNotificacionNoticiaDTO.TheNotificacionAccionDTO.IdNotificacionAccion);
                wobjSQLHelper.SetParametro("@pIdMensajeNoticia", SqlDbType.Decimal, -1, myNotificacionNoticiaDTO.TheMensajeNoticiaDTO.IdMensajeNoticia);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myNotificacionNoticiaDTO.TheMensajeNoticiaDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdCreador", SqlDbType.Decimal, -1, myNotificacionNoticiaDTO.TheFamiliaCreadorDTO.IdFamilia > 0 ? myNotificacionNoticiaDTO.TheFamiliaCreadorDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myNotificacionNoticiaDTO.TheFamiliaDestinoDTO.IdFamilia > 0 ? myNotificacionNoticiaDTO.TheFamiliaDestinoDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pFechaNotificacion", SqlDbType.DateTime, -1, myNotificacionNoticiaDTO.FechaNotificacion);
                wobjSQLHelper.SetParametro("@pVerNotificacion", SqlDbType.Char, 5, myNotificacionNoticiaDTO.VerNotificacion);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myNotificacionNoticiaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_NotificacionNoticia", "YouCom"))
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
        public static bool Update(YouCom.DTO.Notificaciones.NotificacionNoticiaDTO myNotificacionNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeNoticia", SqlDbType.Decimal, -1, myNotificacionNoticiaDTO.TheMensajeNoticiaDTO.IdMensajeNoticia);
                wobjSQLHelper.SetParametro("@pVerNotificacion", SqlDbType.Char, 5, myNotificacionNoticiaDTO.VerNotificacion);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myNotificacionNoticiaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_NotificacionNoticia", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Notificaciones.NotificacionNoticiaDTO theNotificacionesDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdNotificacionNoticia", SqlDbType.Decimal, -1, theNotificacionesDTO.IdNotificacionNoticia);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, theNotificacionesDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Notificacion", "YouCom"))
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
