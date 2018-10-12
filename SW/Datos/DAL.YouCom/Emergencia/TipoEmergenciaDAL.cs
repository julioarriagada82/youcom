using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.DAL.Emergencia
{
    public class TipoEmergenciaDAL
    {
        #region " Metodo getI "
        public static bool getListadoTipoEmergencia(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoTipoEmergencia",
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
        public static bool Insert(YouCom.DTO.Emergencia.TipoEmergenciaDTO myTipoEmergenciaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myTipoEmergenciaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myTipoEmergenciaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pNombreTipoEmergencia", SqlDbType.VarChar, 200, myTipoEmergenciaDTO.NombreTipoEmergencia);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myTipoEmergenciaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_TipoEmergencia", "YouCom"))
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
        public static bool Update(YouCom.DTO.Emergencia.TipoEmergenciaDTO myTipoEmergenciaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdTipoEmergencia", SqlDbType.Decimal, -1, myTipoEmergenciaDTO.IdTipoEmergencia);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myTipoEmergenciaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myTipoEmergenciaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pNombreTipoEmergencia", SqlDbType.VarChar, 200, myTipoEmergenciaDTO.NombreTipoEmergencia);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myTipoEmergenciaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_TipoEmergencia", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Emergencia.TipoEmergenciaDTO myTipoEmergenciaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdTipoEmergencia", SqlDbType.Decimal, -1, myTipoEmergenciaDTO.IdTipoEmergencia);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myTipoEmergenciaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_TipoEmergencia", "YouCom"))
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

        public static bool ActivaTipoEmergencia(YouCom.DTO.Emergencia.TipoEmergenciaDTO theTipoEmergenciaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theTipoEmergenciaDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdTipoEmergencia", SqlDbType.VarChar, 20, theTipoEmergenciaDTO.IdTipoEmergencia);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_TipoEmergencia", "YouCom"))
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

        public static bool ValidaEliminacionTipoEmergencia(DTO.Emergencia.TipoEmergenciaDTO theTipoEmergenciaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idTipoEmergencia", SqlDbType.VarChar, 20, theTipoEmergenciaDTO.IdTipoEmergencia);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionTipoEmergencia", "YouCom", pobjDatatable) <= 0)
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
