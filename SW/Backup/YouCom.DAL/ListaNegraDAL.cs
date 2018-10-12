using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class ListaNegraDAL
    {
        #region " Metodo getListadoListaNegra "
        public static bool getListadoListaNegra(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoListaNegra",
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
        public static bool Insert(YouCom.DTO.ListaNegraDTO myListaNegraDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myListaNegraDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myListaNegraDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pRutListaNegra", SqlDbType.VarChar, 200, myListaNegraDTO.RutListaNegra);
                wobjSQLHelper.SetParametro("@pNombreListaNegra", SqlDbType.VarChar, 200, myListaNegraDTO.NombreListaNegra);
                wobjSQLHelper.SetParametro("@pApellidoListaNegra", SqlDbType.VarChar, 20, myListaNegraDTO.ApellidoListaNegra);
                wobjSQLHelper.SetParametro("@pMotivoListaNegra", SqlDbType.VarChar, 20, myListaNegraDTO.MotivoListaNegra);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myListaNegraDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_ListaNegra", "YouCom"))
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
        public static bool Update(YouCom.DTO.ListaNegraDTO myListaNegraDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdListaNegra", SqlDbType.Decimal, -1, myListaNegraDTO.IdListaNegra);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myListaNegraDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myListaNegraDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pRutListaNegra", SqlDbType.VarChar, 200, myListaNegraDTO.RutListaNegra);
                wobjSQLHelper.SetParametro("@pNombreListaNegra", SqlDbType.VarChar, 200, myListaNegraDTO.NombreListaNegra);
                wobjSQLHelper.SetParametro("@pApellidoListaNegra", SqlDbType.VarChar, 20, myListaNegraDTO.ApellidoListaNegra);
                wobjSQLHelper.SetParametro("@pMotivoListaNegra", SqlDbType.VarChar, 20, myListaNegraDTO.MotivoListaNegra);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myListaNegraDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_ListaNegra", "YouCom"))
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
        public static bool Delete(YouCom.DTO.ListaNegraDTO myListaNegraDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdListaNegra", SqlDbType.Decimal, -1, myListaNegraDTO.IdListaNegra);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myListaNegraDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_ListaNegra", "YouCom"))
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

        public static bool ActivaListaNegra(YouCom.DTO.ListaNegraDTO theListaNegraDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theListaNegraDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdListaNegra", SqlDbType.VarChar, 20, theListaNegraDTO.IdListaNegra);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_ListaNegra", "YouCom"))
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

        public static bool ValidaEliminacionListaNegra(DTO.ListaNegraDTO theListaNegraDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idListaNegra", SqlDbType.VarChar, 20, theListaNegraDTO.IdListaNegra);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionListaNegra", "YouCom", pobjDatatable) <= 0)
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
