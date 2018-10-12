using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL.Imagen
{
    public class ImagenMensajePropietarioDAL
    {
        #region " Metodo getMensajePropietario "
        public static bool getListadoImagenMensajePropietario(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoImagenMensajePropietario",
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
        public static bool Insert(YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO myImagenMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, myImagenMensajePropietarioDTO.TheMensajePropietarioDTO.IdMensajePropietario);
                wobjSQLHelper.SetParametro("@pTituloImagenMensajePropietario", SqlDbType.VarChar, 200, myImagenMensajePropietarioDTO.TituloImagenMensajePropietario);
                wobjSQLHelper.SetParametro("@pThumbailImagenMensajePropietario", SqlDbType.VarChar, 200, myImagenMensajePropietarioDTO.ThumbailImagenMensajePropietario);
                wobjSQLHelper.SetParametro("@pGrandeImagenMensajePropietario", SqlDbType.VarChar, 200, myImagenMensajePropietarioDTO.GrandeImagenMensajePropietario);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_ImagenMensajePropietario", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO myImagenMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdImagenMensajePropietario", SqlDbType.Decimal, -1, myImagenMensajePropietarioDTO.IdImagenMensajePropietario);
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, myImagenMensajePropietarioDTO.TheMensajePropietarioDTO.IdMensajePropietario);
                wobjSQLHelper.SetParametro("@pTituloImagenMensajePropietario", SqlDbType.VarChar, 200, myImagenMensajePropietarioDTO.TituloImagenMensajePropietario);
                wobjSQLHelper.SetParametro("@pThumbailImagenMensajePropietario", SqlDbType.VarChar, 200, myImagenMensajePropietarioDTO.ThumbailImagenMensajePropietario);
                wobjSQLHelper.SetParametro("@pGrandeImagenMensajePropietario", SqlDbType.VarChar, 200, myImagenMensajePropietarioDTO.GrandeImagenMensajePropietario);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_ImagenMensajePropietario", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.Imagen.ImagenMensajePropietarioDTO myImagenMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, myImagenMensajePropietarioDTO.TheMensajePropietarioDTO.IdMensajePropietario);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_ImagenMensajePropietario", "YouCom"))
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
