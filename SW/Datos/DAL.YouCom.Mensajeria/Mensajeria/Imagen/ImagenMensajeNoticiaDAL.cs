using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL.Imagen
{
    public class ImagenMensajeNoticiaDAL
    {
        #region " Metodo getMensajeNoticia "
        public static bool getListadoImagenMensajeNoticia(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoImagenMensajeNoticia",
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
        public static bool Insert(YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO myImagenMensajeNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeNoticia", SqlDbType.Decimal, -1, myImagenMensajeNoticiaDTO.TheMensajeNoticiaDTO.IdMensajeNoticia);
                wobjSQLHelper.SetParametro("@pTituloImagenMensajeNoticia", SqlDbType.VarChar, 200, myImagenMensajeNoticiaDTO.TituloImagenMensajeNoticia);
                wobjSQLHelper.SetParametro("@pThumbailImagenMensajeNoticia", SqlDbType.VarChar, 200, myImagenMensajeNoticiaDTO.ThumbailImagenMensajeNoticia);
                wobjSQLHelper.SetParametro("@pGrandeImagenMensajeNoticia", SqlDbType.VarChar, 200, myImagenMensajeNoticiaDTO.GrandeImagenMensajeNoticia);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_ImagenMensajeNoticia", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO myImagenMensajeNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdImagenMensajeNoticia", SqlDbType.Decimal, -1, myImagenMensajeNoticiaDTO.IdImagenMensajeNoticia);
                wobjSQLHelper.SetParametro("@pIdMensajeNoticia", SqlDbType.Decimal, -1, myImagenMensajeNoticiaDTO.TheMensajeNoticiaDTO.IdMensajeNoticia);
                wobjSQLHelper.SetParametro("@pTituloImagenMensajeNoticia", SqlDbType.VarChar, 200, myImagenMensajeNoticiaDTO.TituloImagenMensajeNoticia);
                wobjSQLHelper.SetParametro("@pThumbailImagenMensajeNoticia", SqlDbType.VarChar, 200, myImagenMensajeNoticiaDTO.ThumbailImagenMensajeNoticia);
                wobjSQLHelper.SetParametro("@pGrandeImagenMensajeNoticia", SqlDbType.VarChar, 200, myImagenMensajeNoticiaDTO.GrandeImagenMensajeNoticia);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_ImagenMensajeNoticia", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.Imagen.ImagenMensajeNoticiaDTO myImagenMensajeNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeNoticia", SqlDbType.Decimal, -1, myImagenMensajeNoticiaDTO.TheMensajeNoticiaDTO.IdMensajeNoticia);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_ImagenMensajeNoticia", "YouCom"))
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
