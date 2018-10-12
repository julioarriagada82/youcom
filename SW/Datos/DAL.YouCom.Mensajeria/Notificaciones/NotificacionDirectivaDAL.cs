using System;
using System.Data;

namespace YouCom.Mensajeria.DAL.Notificaciones
{
    public class NotificacionDirectivaDAL
    {
        #region " Metodo getNotificaciones "
        public static bool getListadoNotificacion(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoNotificacionDirectiva",
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoResumenNotificacionDirectiva",
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
        public static bool Insert(YouCom.DTO.Notificaciones.NotificacionDirectivaDTO myNotificacionDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myNotificacionDirectivaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myNotificacionDirectivaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdNotificacionAccion", SqlDbType.Decimal, -1, myNotificacionDirectivaDTO.TheNotificacionAccionDTO.IdNotificacionAccion);
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, myNotificacionDirectivaDTO.TheMensajeDirectivaDTO.IdMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myNotificacionDirectivaDTO.TheMensajeDirectivaDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdDirectiva", SqlDbType.Decimal, -1, myNotificacionDirectivaDTO.TheDirectivaDTO.IdDirectiva > 0 ? myNotificacionDirectivaDTO.TheDirectivaDTO.IdDirectiva : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myNotificacionDirectivaDTO.TheFamiliaDestinoDTO.IdFamilia > 0 ? myNotificacionDirectivaDTO.TheFamiliaDestinoDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pFechaNotificacion", SqlDbType.DateTime, -1, myNotificacionDirectivaDTO.FechaNotificacion);
                wobjSQLHelper.SetParametro("@pVerNotificacion", SqlDbType.Char, 5, myNotificacionDirectivaDTO.VerNotificacion);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myNotificacionDirectivaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_NotificacionDirectiva", "YouCom"))
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
        public static bool Update(YouCom.DTO.Notificaciones.NotificacionDirectivaDTO myNotificacionDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, myNotificacionDirectivaDTO.TheMensajeDirectivaDTO.IdMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pVerNotificacion", SqlDbType.Char, 5, myNotificacionDirectivaDTO.VerNotificacion);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myNotificacionDirectivaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_NotificacionDirectiva", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Notificaciones.NotificacionDirectivaDTO theNotificacionDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdNotificacionDirectiva", SqlDbType.Decimal, -1, theNotificacionDirectivaDTO.IdNotificacionDirectiva);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, theNotificacionDirectivaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_NotificacionDirectiva", "YouCom"))
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
