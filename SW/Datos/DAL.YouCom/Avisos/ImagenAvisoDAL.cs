using System;
using System.Data;

namespace YouCom.DAL.Avisos
{
    public class ImagenAvisoDAL
    {
        #region " Metodo getMensajeDirectiva "
        public static bool getListadoImagenAviso(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoImagenAviso",
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
        public static bool Insert(YouCom.DTO.Avisos.ImagenAvisoDTO myImagenAvisoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdAviso", SqlDbType.Decimal, -1, myImagenAvisoDTO.TheAvisosDTO.IdAviso);
                wobjSQLHelper.SetParametro("@pTituloImagenAviso", SqlDbType.VarChar, 200, myImagenAvisoDTO.TituloImagenAviso);
                wobjSQLHelper.SetParametro("@pThumbailImagenAviso", SqlDbType.VarChar, 200, myImagenAvisoDTO.ThumbailImagenAviso);
                wobjSQLHelper.SetParametro("@pGrandeImagenAviso", SqlDbType.VarChar, 200, myImagenAvisoDTO.GrandeImagenAviso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_ImagenAviso", "YouCom"))
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
        public static bool Update(YouCom.DTO.Avisos.ImagenAvisoDTO myImagenAvisoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdImagenAviso", SqlDbType.Decimal, -1, myImagenAvisoDTO.IdImagenAviso);
                wobjSQLHelper.SetParametro("@pIdAviso", SqlDbType.Decimal, -1, myImagenAvisoDTO.TheAvisosDTO.IdAviso);
                wobjSQLHelper.SetParametro("@pTituloImagenAviso", SqlDbType.VarChar, 200, myImagenAvisoDTO.TituloImagenAviso);
                wobjSQLHelper.SetParametro("@pThumbailImagenAviso", SqlDbType.VarChar, 200, myImagenAvisoDTO.ThumbailImagenAviso);
                wobjSQLHelper.SetParametro("@pGrandeImagenAviso", SqlDbType.VarChar, 200, myImagenAvisoDTO.GrandeImagenAviso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_ImagenAviso", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Avisos.ImagenAvisoDTO myImagenAvisoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdImagenAviso", SqlDbType.Decimal, -1, myImagenAvisoDTO.IdImagenAviso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_ImagenAviso", "YouCom"))
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
