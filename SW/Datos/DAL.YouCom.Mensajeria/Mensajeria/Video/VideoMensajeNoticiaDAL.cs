﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL.Video
{
    public class VideoMensajeNoticiaDAL
    {
        #region " Metodo getMensajeNoticia "
        public static bool getListadoVideoMensajeNoticia(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoVideoMensajeNoticia",
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
        public static bool Insert(YouCom.DTO.Mensajeria.Video.VideoMensajeNoticiaDTO myVideoMensajeNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeNoticia", SqlDbType.Decimal, -1, myVideoMensajeNoticiaDTO.TheMensajeNoticiaDTO.IdMensajeNoticia);
                wobjSQLHelper.SetParametro("@pTituloVideoMensajeNoticia", SqlDbType.VarChar, 200, myVideoMensajeNoticiaDTO.TituloVideoMensajeNoticia);
                wobjSQLHelper.SetParametro("@pUrlVideoMensajeNoticia", SqlDbType.VarChar, 200, myVideoMensajeNoticiaDTO.UrlVideoMensajeNoticia);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_VideoMensajeNoticia", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.Video.VideoMensajeNoticiaDTO myVideoMensajeNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVideoMensajeNoticia", SqlDbType.Decimal, -1, myVideoMensajeNoticiaDTO.IdVideoMensajeNoticia);
                wobjSQLHelper.SetParametro("@pIdMensajeNoticia", SqlDbType.Decimal, -1, myVideoMensajeNoticiaDTO.TheMensajeNoticiaDTO.IdMensajeNoticia);
                wobjSQLHelper.SetParametro("@pTituloVideoMensajeNoticia", SqlDbType.VarChar, 200, myVideoMensajeNoticiaDTO.TituloVideoMensajeNoticia);
                wobjSQLHelper.SetParametro("@pUrlVideoMensajeNoticia", SqlDbType.VarChar, 200, myVideoMensajeNoticiaDTO.UrlVideoMensajeNoticia);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_VideoMensajeNoticia", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.Video.VideoMensajeNoticiaDTO myVideoMensajeNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeNoticia", SqlDbType.Decimal, -1, myVideoMensajeNoticiaDTO.TheMensajeNoticiaDTO.IdMensajeNoticia);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_VideoMensajeNoticia", "YouCom"))
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