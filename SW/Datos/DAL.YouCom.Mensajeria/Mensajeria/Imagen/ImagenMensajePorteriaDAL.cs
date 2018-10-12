using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL.Imagen
{
    public class ImagenMensajePorteriaDAL
    {
        #region " Metodo getMensajePorteria "
        public static bool getListadoImagenMensajePorteria(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoImagenMensajePorteria",
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
        public static bool Insert(YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO myImagenMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myImagenMensajePorteriaDTO.TheMensajePorteriaDTO.IdMensajePorteria);
                wobjSQLHelper.SetParametro("@pTituloImagenMensajePorteria", SqlDbType.VarChar, 200, myImagenMensajePorteriaDTO.TituloImagenMensajePorteria);
                wobjSQLHelper.SetParametro("@pThumbailImagenMensajePorteria", SqlDbType.VarChar, 200, myImagenMensajePorteriaDTO.ThumbailImagenMensajePorteria);
                wobjSQLHelper.SetParametro("@pGrandeImagenMensajePorteria", SqlDbType.VarChar, 200, myImagenMensajePorteriaDTO.GrandeImagenMensajePorteria);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_ImagenMensajePorteria", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO myImagenMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdImagenMensajePorteria", SqlDbType.Decimal, -1, myImagenMensajePorteriaDTO.IdImagenMensajePorteria);
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myImagenMensajePorteriaDTO.TheMensajePorteriaDTO.IdMensajePorteria);
                wobjSQLHelper.SetParametro("@pTituloImagenMensajePorteria", SqlDbType.VarChar, 200, myImagenMensajePorteriaDTO.TituloImagenMensajePorteria);
                wobjSQLHelper.SetParametro("@pThumbailImagenMensajePorteria", SqlDbType.VarChar, 200, myImagenMensajePorteriaDTO.ThumbailImagenMensajePorteria);
                wobjSQLHelper.SetParametro("@pGrandeImagenMensajePorteria", SqlDbType.VarChar, 200, myImagenMensajePorteriaDTO.GrandeImagenMensajePorteria);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_ImagenMensajePorteria", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.Imagen.ImagenMensajePorteriaDTO myImagenMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myImagenMensajePorteriaDTO.TheMensajePorteriaDTO.IdMensajePorteria);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_ImagenMensajePorteria", "YouCom"))
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
