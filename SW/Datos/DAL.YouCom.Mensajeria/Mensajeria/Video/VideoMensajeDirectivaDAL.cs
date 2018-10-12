using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL.Video
{
    public class VideoMensajeDirectivaDAL
    {
        #region " Metodo getMensajeDirectiva "
        public static bool getListadoVideoMensajeDirectiva(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoVideoMensajeDirectiva",
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
        public static bool Insert(YouCom.DTO.Mensajeria.Video.VideoMensajeDirectivaDTO myVideoMensajeDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, myVideoMensajeDirectivaDTO.TheMensajeDirectivaDTO.IdMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pTituloVideoMensajeDirectiva", SqlDbType.VarChar, 200, myVideoMensajeDirectivaDTO.TituloVideoMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pUrlVideoMensajeDirectiva", SqlDbType.VarChar, 200, myVideoMensajeDirectivaDTO.UrlVideoMensajeDirectiva);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_VideoMensajeDirectiva", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.Video.VideoMensajeDirectivaDTO myVideoMensajeDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVideoMensajeDirectiva", SqlDbType.Decimal, -1, myVideoMensajeDirectivaDTO.IdVideoMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, myVideoMensajeDirectivaDTO.TheMensajeDirectivaDTO.IdMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pTituloVideoMensajeDirectiva", SqlDbType.VarChar, 200, myVideoMensajeDirectivaDTO.TituloVideoMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pUrlVideoMensajeDirectiva", SqlDbType.VarChar, 200, myVideoMensajeDirectivaDTO.UrlVideoMensajeDirectiva);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_VideoMensajeDirectiva", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.Video.VideoMensajeDirectivaDTO myVideoMensajeDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, myVideoMensajeDirectivaDTO.TheMensajeDirectivaDTO.IdMensajeDirectiva);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_VideoMensajeDirectiva", "YouCom"))
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
