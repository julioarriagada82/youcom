using System;
using System.Data;

namespace YouCom.Mensajeria.DAL.Notificaciones
{
    public class NotificacionAccionDAL
    {
        #region " Metodo getNotificaciones "
        public static bool getListadoNotificacionAccion(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoNotificacionAccion",
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
        public static bool Insert(YouCom.DTO.Notificaciones.NotificacionAccionDTO myNotificacionAccionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myNotificacionAccionDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myNotificacionAccionDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pNombreNotificacionAccion", SqlDbType.VarChar, 500, myNotificacionAccionDTO.NombreNotificacionAccion);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myNotificacionAccionDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_NotificacionAccion", "YouCom"))
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
        public static bool Update(YouCom.DTO.Notificaciones.NotificacionAccionDTO myNotificacionAccionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myNotificacionAccionDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myNotificacionAccionDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdNotificacionAccion", SqlDbType.Decimal, -1, myNotificacionAccionDTO.IdNotificacionAccion);
                wobjSQLHelper.SetParametro("@pNombreNotificacionAccion", SqlDbType.VarChar, 500, myNotificacionAccionDTO.NombreNotificacionAccion);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myNotificacionAccionDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_NotificacionAccion", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdNotificacionAccion", SqlDbType.Decimal, -1, theNotificacionAccionDTO.IdNotificacionAccion);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, theNotificacionAccionDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_NotificacionAccion", "YouCom"))
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

        public static bool ActivaNotificaciones(YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theNotificacionAccionDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdNotificacionAccion", SqlDbType.Decimal, -1, theNotificacionAccionDTO.IdNotificacionAccion);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Notificacion", "YouCom"))
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
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }

        public static bool ValidaEliminacionNotificacionAccion(DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@pIdNotificacionAccion", SqlDbType.Decimal, -1, theNotificacionAccionDTO.IdNotificacionAccion);

            try
            {
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionNotificacionAccion", "YouCom", pobjDatatable) <= 0)
                {
                    retorno = false;
                }
                else
                {
                    retorno = true;
                }
            }
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }

    }
}
