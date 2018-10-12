using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL.Video
{
    public class VideoMensajePorteriaDAL
    {
        #region " Metodo getMensajePorteria "
        public static bool getListadoVideoMensajePorteria(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoVideoMensajePorteria",
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
        public static bool Insert(YouCom.DTO.Mensajeria.Video.VideoMensajePorteriaDTO myVideoMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myVideoMensajePorteriaDTO.TheMensajePorteriaDTO.IdMensajePorteria);
                wobjSQLHelper.SetParametro("@pTituloVideoMensajePorteria", SqlDbType.VarChar, 200, myVideoMensajePorteriaDTO.TituloVideoMensajePorteria);
                wobjSQLHelper.SetParametro("@pUrlVideoMensajePorteria", SqlDbType.VarChar, 200, myVideoMensajePorteriaDTO.UrlVideoMensajePorteria);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_VideoMensajePorteria", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.Video.VideoMensajePorteriaDTO myVideoMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVideoMensajePorteria", SqlDbType.Decimal, -1, myVideoMensajePorteriaDTO.IdVideoMensajePorteria);
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myVideoMensajePorteriaDTO.TheMensajePorteriaDTO.IdMensajePorteria);
                wobjSQLHelper.SetParametro("@pTituloVideoMensajePorteria", SqlDbType.VarChar, 200, myVideoMensajePorteriaDTO.TituloVideoMensajePorteria);
                wobjSQLHelper.SetParametro("@pUrlVideoMensajePorteria", SqlDbType.VarChar, 200, myVideoMensajePorteriaDTO.UrlVideoMensajePorteria);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_VideoMensajePorteria", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.Video.VideoMensajePorteriaDTO myVideoMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myVideoMensajePorteriaDTO.TheMensajePorteriaDTO.IdMensajePorteria);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_VideoMensajePorteria", "YouCom"))
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
