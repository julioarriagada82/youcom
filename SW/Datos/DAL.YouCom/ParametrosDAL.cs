using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.DAL
{
    public class ParametrosDAL
    {
        #region " Metodo getListadoParametros "
        public static bool getListadoParametros(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoParametros",
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
        public static bool Insert(YouCom.DTO.ParametrosDTO myParametrosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pConcepto", SqlDbType.VarChar, 200, myParametrosDTO.Concepto);
                wobjSQLHelper.SetParametro("@pCodigo", SqlDbType.VarChar, 200, myParametrosDTO.Codigo);
                wobjSQLHelper.SetParametro("@pDescriopcion", SqlDbType.VarChar, 200, myParametrosDTO.Descripcion);
                wobjSQLHelper.SetParametro("@pDescriopcionCorta", SqlDbType.VarChar, 500, myParametrosDTO.DescripcionCorta);
                wobjSQLHelper.SetParametro("@pOrden", SqlDbType.Decimal, -1, myParametrosDTO.Orden);
                wobjSQLHelper.SetParametro("@pEstado", SqlDbType.Char, 1, myParametrosDTO.Estado);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myParametrosDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Parametros", "YouCom"))
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
        public static bool Update(YouCom.DTO.ParametrosDTO myParametrosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdParametros", SqlDbType.Decimal, -1, myParametrosDTO.IdParametro);
                wobjSQLHelper.SetParametro("@pConcepto", SqlDbType.VarChar, 200, myParametrosDTO.Concepto);
                wobjSQLHelper.SetParametro("@pCodigo", SqlDbType.VarChar, 200, myParametrosDTO.Codigo);
                wobjSQLHelper.SetParametro("@pDescriopcion", SqlDbType.VarChar, 200, myParametrosDTO.Descripcion);
                wobjSQLHelper.SetParametro("@pDescriopcionCorta", SqlDbType.VarChar, 500, myParametrosDTO.DescripcionCorta);
                wobjSQLHelper.SetParametro("@pOrden", SqlDbType.Decimal, -1, myParametrosDTO.Orden);
                wobjSQLHelper.SetParametro("@pEstado", SqlDbType.Char, 1, myParametrosDTO.Estado);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myParametrosDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Parametros", "YouCom"))
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
        public static bool Delete(YouCom.DTO.ParametrosDTO myParametrosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdParametros", SqlDbType.Decimal, -1, myParametrosDTO.IdParametro);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myParametrosDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Parametros", "YouCom"))
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

        public static bool ActivaParametros(YouCom.DTO.ParametrosDTO theParametrosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theParametrosDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdParametros", SqlDbType.VarChar, 20, theParametrosDTO.IdParametro);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Parametros", "YouCom"))
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

        public static bool ValidaEliminacionParametros(YouCom.DTO.ParametrosDTO theParametrosDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idParametros", SqlDbType.VarChar, 20, theParametrosDTO.IdParametro);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionParametros", "YouCom", pobjDatatable) <= 0)
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