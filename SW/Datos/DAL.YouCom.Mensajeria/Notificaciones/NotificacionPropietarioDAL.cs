using System;
using System.Data;

namespace YouCom.Mensajeria.DAL.Notificaciones
{
    public class NotificacionPropietarioDAL
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoNotificacionPropietario",
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoResumenNotificacionPropietario",
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
        public static bool Insert(YouCom.DTO.Notificaciones.NotificacionPropietarioDTO myNotificacionPropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myNotificacionPropietarioDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myNotificacionPropietarioDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdNotificacionAccion", SqlDbType.Decimal, -1, myNotificacionPropietarioDTO.TheNotificacionAccionDTO.IdNotificacionAccion);
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, myNotificacionPropietarioDTO.TheMensajePropietarioDTO.IdMensajePropietario);
                wobjSQLHelper.SetParametro("@pIdPadre", SqlDbType.Decimal, -1, myNotificacionPropietarioDTO.TheMensajePropietarioDTO.IdPadre);
                wobjSQLHelper.SetParametro("@pIdFamiliaOrigen", SqlDbType.Decimal, -1, myNotificacionPropietarioDTO.TheFamiliaCreadorDTO.IdFamilia > 0 ? myNotificacionPropietarioDTO.TheFamiliaCreadorDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myNotificacionPropietarioDTO.TheFamiliaDestinoDTO.IdFamilia > 0 ? myNotificacionPropietarioDTO.TheFamiliaDestinoDTO.IdFamilia : System.Data.SqlTypes.SqlDecimal.Null);
                wobjSQLHelper.SetParametro("@pFechaNotificacion", SqlDbType.DateTime, -1, myNotificacionPropietarioDTO.FechaNotificacion);
                wobjSQLHelper.SetParametro("@pVerNotificacion", SqlDbType.Char, 5, myNotificacionPropietarioDTO.VerNotificacion);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myNotificacionPropietarioDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_NotificacionPropietario", "YouCom"))
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
        public static bool Update(YouCom.DTO.Notificaciones.NotificacionPropietarioDTO myNotificacionPropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, myNotificacionPropietarioDTO.TheMensajePropietarioDTO.IdMensajePropietario);
                wobjSQLHelper.SetParametro("@pVerNotificacion", SqlDbType.Char, 5, myNotificacionPropietarioDTO.VerNotificacion);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myNotificacionPropietarioDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_NotificacionPropietario", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Notificaciones.NotificacionPropietarioDTO theNotificacionesDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdNotificacionPropietario", SqlDbType.Decimal, -1, theNotificacionesDTO.IdNotificacionPropietario);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, theNotificacionesDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_NotificacionPropietario", "YouCom"))
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
