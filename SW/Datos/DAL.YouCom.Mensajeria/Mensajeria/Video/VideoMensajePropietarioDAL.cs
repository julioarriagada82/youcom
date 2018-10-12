using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL.Video
{
    public class VideoMensajePropietarioDAL
    {
        #region " Metodo getMensajePropietario "
        public static bool getListadoVideoMensajePropietario(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoVideoMensajePropietario",
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
        public static bool Insert(YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO myVideoMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, myVideoMensajePropietarioDTO.TheMensajePropietarioDTO.IdMensajePropietario);
                wobjSQLHelper.SetParametro("@pTituloVideoMensajePropietario", SqlDbType.VarChar, 200, myVideoMensajePropietarioDTO.TituloVideoMensajePropietario);
                wobjSQLHelper.SetParametro("@pUrlVideoMensajePropietario", SqlDbType.VarChar, 200, myVideoMensajePropietarioDTO.UrlVideoMensajePropietario);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_VideoMensajePropietario", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO myVideoMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVideoMensajePropietario", SqlDbType.Decimal, -1, myVideoMensajePropietarioDTO.IdVideoMensajePropietario);
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, myVideoMensajePropietarioDTO.TheMensajePropietarioDTO.IdMensajePropietario);
                wobjSQLHelper.SetParametro("@pTituloVideoMensajePropietario", SqlDbType.VarChar, 200, myVideoMensajePropietarioDTO.TituloVideoMensajePropietario);
                wobjSQLHelper.SetParametro("@pUrlVideoMensajePropietario", SqlDbType.VarChar, 200, myVideoMensajePropietarioDTO.UrlVideoMensajePropietario);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_VideoMensajePropietario", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.Video.VideoMensajePropietarioDTO myVideoMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, myVideoMensajePropietarioDTO.TheMensajePropietarioDTO.IdMensajePropietario);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_VideoMensajePropietario", "YouCom"))
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
