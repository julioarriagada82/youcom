using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class BannerDAL
    {
        #region " Metodo getBanner "
        public static bool getListadoBanner(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoBanner",
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
        public static bool Insert(YouCom.DTO.BannerDTO myBannerDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myBannerDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pBannerNombre", SqlDbType.VarChar, 200, myBannerDTO.BannerNombre);
                wobjSQLHelper.SetParametro("@pBannerDescripcion", SqlDbType.VarChar, 200, myBannerDTO.BannerDescripcion);
                wobjSQLHelper.SetParametro("@pBannerImagen", SqlDbType.VarChar, 200, myBannerDTO.BannerImagen);
                wobjSQLHelper.SetParametro("@pBannerTipoDespliegue", SqlDbType.VarChar, 20, myBannerDTO.BannerTipoDespliegue);
                wobjSQLHelper.SetParametro("@pBannerLink", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myBannerDTO.BannerLink) ? myBannerDTO.BannerLink : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pBannerTarget", SqlDbType.VarChar, 10, !string.IsNullOrEmpty(myBannerDTO.BannerTarget) ? myBannerDTO.BannerTarget : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pBannerArchivo", SqlDbType.VarChar, 20, !string.IsNullOrEmpty(myBannerDTO.BannerArchivo) ? myBannerDTO.BannerArchivo : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myBannerDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Banner", "YouCom"))
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
        public static bool Update(YouCom.DTO.BannerDTO myBannerDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pBannerId", SqlDbType.Decimal, -1, myBannerDTO.BannerId);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myBannerDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pBannerNombre", SqlDbType.VarChar, 200, myBannerDTO.BannerNombre);
                wobjSQLHelper.SetParametro("@pBannerDescripcion", SqlDbType.VarChar, 200, myBannerDTO.BannerDescripcion);
                wobjSQLHelper.SetParametro("@pBannerImagen", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myBannerDTO.BannerImagen) ? myBannerDTO.BannerImagen : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pBannerTipoDespliegue", SqlDbType.VarChar, 20, myBannerDTO.BannerTipoDespliegue);
                wobjSQLHelper.SetParametro("@pBannerLink", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myBannerDTO.BannerLink) ? myBannerDTO.BannerLink : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pBannerTarget", SqlDbType.VarChar, 10, !string.IsNullOrEmpty(myBannerDTO.BannerTarget) ? myBannerDTO.BannerTarget : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pBannerArchivo", SqlDbType.VarChar, 200, !string.IsNullOrEmpty(myBannerDTO.BannerArchivo) ? myBannerDTO.BannerArchivo : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myBannerDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Banner", "YouCom"))
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
        public static bool Delete(YouCom.DTO.BannerDTO myBannerDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pBannerId", SqlDbType.Decimal, -1, myBannerDTO.BannerId);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myBannerDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Banner", "YouCom"))
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

        public static bool ActivaBanner(YouCom.DTO.BannerDTO theBannerDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theBannerDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdBanner", SqlDbType.VarChar, 20, theBannerDTO.BannerId);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Banner", "YouCom"))
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

        public static bool ValidaEliminacionBanner(DTO.BannerDTO theBannerDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idBanner", SqlDbType.VarChar, 20, theBannerDTO.BannerId);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionBanner", "YouCom", pobjDatatable) <= 0)
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
