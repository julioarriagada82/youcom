using System;
using System.Data;

namespace YouCom.Mensajeria.DAL.Imagen
{
    public class ImagenMensajeDirectivaDAL
    {
        #region " Metodo getMensajeDirectiva "
        public static bool getListadoImagenMensajeDirectiva(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoImagenMensajeDirectiva",
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
        public static bool Insert(YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO myImagenMensajeDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, myImagenMensajeDirectivaDTO.TheMensajeDirectivaDTO.IdMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pTituloImagenMensajeDirectiva", SqlDbType.VarChar, 200, myImagenMensajeDirectivaDTO.TituloImagenMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pThumbailImagenMensajeDirectiva", SqlDbType.VarChar, 200, myImagenMensajeDirectivaDTO.ThumbailImagenMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pGrandeImagenMensajeDirectiva", SqlDbType.VarChar, 200, myImagenMensajeDirectivaDTO.GrandeImagenMensajeDirectiva);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_ImagenMensajeDirectiva", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO myImagenMensajeDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdImagenMensajeDirectiva", SqlDbType.Decimal, -1, myImagenMensajeDirectivaDTO.IdImagenMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, myImagenMensajeDirectivaDTO.TheMensajeDirectivaDTO.IdMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pTituloImagenMensajeDirectiva", SqlDbType.VarChar, 200, myImagenMensajeDirectivaDTO.TituloImagenMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pThumbailImagenMensajeDirectiva", SqlDbType.VarChar, 200, myImagenMensajeDirectivaDTO.ThumbailImagenMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pGrandeImagenMensajeDirectiva", SqlDbType.VarChar, 200, myImagenMensajeDirectivaDTO.GrandeImagenMensajeDirectiva);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_ImagenMensajeDirectiva", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.Imagen.ImagenMensajeDirectivaDTO myImagenMensajeDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, myImagenMensajeDirectivaDTO.TheMensajeDirectivaDTO.IdMensajeDirectiva);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_ImagenMensajeDirectiva", "YouCom"))
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
