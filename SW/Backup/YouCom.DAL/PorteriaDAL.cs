using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class PorteriaDAL
    {
        #region " Metodo getPorteria "
        public static bool getListadoPorteria(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoPorteria",
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
        public static bool Insert(YouCom.DTO.PorteriaDTO myPorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pNombrePorteria", SqlDbType.VarChar, 200, myPorteriaDTO.NombrePorteria);
                wobjSQLHelper.SetParametro("@pApellidoPorteria", SqlDbType.VarChar, 200, myPorteriaDTO.ApellidoPorteria);
                wobjSQLHelper.SetParametro("@pRutPorteria", SqlDbType.VarChar, 200, myPorteriaDTO.RutPorteria);
                wobjSQLHelper.SetParametro("@pTelefonoPorteria", SqlDbType.VarChar, 200, myPorteriaDTO.TelefonoPorteria);
                wobjSQLHelper.SetParametro("@pEmailPorteria", SqlDbType.VarChar, 200, myPorteriaDTO.EmailPorteria);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myPorteriaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Porteria", "YouCom"))
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
        public static bool Update(YouCom.DTO.PorteriaDTO myPorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdPorteria", SqlDbType.Decimal, -1, myPorteriaDTO.IdPorteria);
                wobjSQLHelper.SetParametro("@pNombrePorteria", SqlDbType.VarChar, 200, myPorteriaDTO.NombrePorteria);
                wobjSQLHelper.SetParametro("@pApellidoPorteria", SqlDbType.VarChar, 200, myPorteriaDTO.ApellidoPorteria);
                wobjSQLHelper.SetParametro("@pRutPorteria", SqlDbType.VarChar, 200, myPorteriaDTO.RutPorteria);
                wobjSQLHelper.SetParametro("@pTelefonoPorteria", SqlDbType.VarChar, 200, myPorteriaDTO.TelefonoPorteria);
                wobjSQLHelper.SetParametro("@pEmailPorteria", SqlDbType.VarChar, 200, myPorteriaDTO.EmailPorteria);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myPorteriaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Porteria", "YouCom"))
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
        public static bool Delete(YouCom.DTO.PorteriaDTO myPorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdPorteria", SqlDbType.Decimal, -1, myPorteriaDTO.IdPorteria);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myPorteriaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Porteria", "YouCom"))
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

        public static bool ActivaPorteria(YouCom.DTO.PorteriaDTO thePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, thePorteriaDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdPorteria", SqlDbType.VarChar, 20, thePorteriaDTO.IdPorteria);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Porteria", "YouCom"))
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

        public static bool ValidaEliminacionPorteria(DTO.PorteriaDTO thePorteriaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idPorteria", SqlDbType.VarChar, 20, thePorteriaDTO.IdPorteria);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionPorteria", "YouCom", pobjDatatable) <= 0)
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
