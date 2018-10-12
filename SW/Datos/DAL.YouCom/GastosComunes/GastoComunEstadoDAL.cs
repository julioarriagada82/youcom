using System;
using System.Data;

namespace YouCom.DAL.GastosComunes
{
    public class GastoComunEstadoDAL
    {
        #region " Metodo getGastoComunEstado "
        public static bool getListadoGastoComunEstado(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoGastoComunEstado",
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
        public static bool Insert(YouCom.DTO.GastosComunes.GastoComunEstadoDTO myGastoComunEstadoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pNombreGastoComunEstado", SqlDbType.VarChar, 200, myGastoComunEstadoDTO.NombreGastoComunEstado);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.VarChar, -1, myGastoComunEstadoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myGastoComunEstadoDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_GastoComunEstado", "YouCom"))
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
        public static bool Update(YouCom.DTO.GastosComunes.GastoComunEstadoDTO myGastoComunEstadoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdGastoComunEstado", SqlDbType.Decimal, -1, myGastoComunEstadoDTO.IdGastoComunEstado);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.VarChar, -1, myGastoComunEstadoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pNombreGastoComunEstado", SqlDbType.VarChar, 200, myGastoComunEstadoDTO.NombreGastoComunEstado);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myGastoComunEstadoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_GastoComunEstado", "YouCom"))
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
        public static bool Delete(YouCom.DTO.GastosComunes.GastoComunEstadoDTO myGastoComunEstadoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdGastoComunEstado", SqlDbType.Decimal, -1, myGastoComunEstadoDTO.IdGastoComunEstado);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myGastoComunEstadoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_GastoComunEstado", "YouCom"))
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

        public static bool ActivaGastoComunEstado(YouCom.DTO.GastosComunes.GastoComunEstadoDTO theGastoComunEstadoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theGastoComunEstadoDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdGastoComunEstado", SqlDbType.VarChar, 20, theGastoComunEstadoDTO.IdGastoComunEstado);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_GastoComunEstado", "YouCom"))
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

        public static bool ValidaEliminacionGastoComunEstado(DTO.GastosComunes.GastoComunEstadoDTO theGastoComunEstadoDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idGastoComunEstado", SqlDbType.VarChar, 20, theGastoComunEstadoDTO.IdGastoComunEstado);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionGastoComunEstado", "YouCom", pobjDatatable) <= 0)
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
