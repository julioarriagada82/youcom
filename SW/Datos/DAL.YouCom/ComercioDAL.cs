using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class ComercioDAL
    {
        #region " Metodo getListadoComercio "
        public static bool getListadoComercio(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoComercio",
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
        public static bool Insert(YouCom.DTO.ComercioDTO myComercioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myComercioDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myComercioDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myComercioDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pNombreComercio", SqlDbType.VarChar, 500, myComercioDTO.NombreComercio);
                wobjSQLHelper.SetParametro("@pDireccionComercio", SqlDbType.VarChar, 500, myComercioDTO.DireccionComercio);
                wobjSQLHelper.SetParametro("@pTelefonoComercio", SqlDbType.VarChar, 20, myComercioDTO.TelefonoComercio);
                wobjSQLHelper.SetParametro("@pUrlComercio", SqlDbType.VarChar, 200, myComercioDTO.UrlComercio);
                wobjSQLHelper.SetParametro("@pEmailComercio", SqlDbType.VarChar, 200, myComercioDTO.EmailComercio);
                wobjSQLHelper.SetParametro("@pLogoComercio", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myComercioDTO.LogoComercio) ? myComercioDTO.LogoComercio : System.Data.SqlTypes.SqlString.Null);

                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myComercioDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Comercio", "YouCom"))
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
        public static bool Update(YouCom.DTO.ComercioDTO myComercioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdComercio", SqlDbType.Decimal, -1, myComercioDTO.IdComercio);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myComercioDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myComercioDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myComercioDTO.TheCategoriaDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pNombreComercio", SqlDbType.VarChar, 500, myComercioDTO.NombreComercio);
                wobjSQLHelper.SetParametro("@pDireccionComercio", SqlDbType.VarChar, 500, myComercioDTO.DireccionComercio);
                wobjSQLHelper.SetParametro("@pTelefonoComercio", SqlDbType.VarChar, 20, myComercioDTO.TelefonoComercio);
                wobjSQLHelper.SetParametro("@pUrlComercio", SqlDbType.VarChar, 200, myComercioDTO.UrlComercio);
                wobjSQLHelper.SetParametro("@pEmailComercio", SqlDbType.VarChar, 200, myComercioDTO.EmailComercio);
                wobjSQLHelper.SetParametro("@pLogoComercio", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myComercioDTO.LogoComercio) ? myComercioDTO.LogoComercio : System.Data.SqlTypes.SqlString.Null);

                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myComercioDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Comercio", "YouCom"))
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
        public static bool Delete(YouCom.DTO.ComercioDTO myComercioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdComercio", SqlDbType.Decimal, -1, myComercioDTO.IdComercio);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myComercioDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Comercio", "YouCom"))
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

        public static bool ActivaComercio(YouCom.DTO.ComercioDTO theComercioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theComercioDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdComercio", SqlDbType.VarChar, 20, theComercioDTO.IdComercio);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Comercio", "YouCom"))
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

        public static bool ValidaEliminacionComercio(YouCom.DTO.ComercioDTO theComercioDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idComercio", SqlDbType.VarChar, 20, theComercioDTO.IdComercio);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionComercio", "YouCom", pobjDatatable) <= 0)
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
