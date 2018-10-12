using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL
{
    public class EleccionNoticiaDAL
    {
        #region " Metodo getMensajeDirectiva "
        public static bool getListadoEleccionNoticia(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoEleccionNoticia",
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
        public static bool Insert(YouCom.DTO.Mensajeria.EleccionNoticiaDTO myEleccionNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdNoticia", SqlDbType.Decimal, -1, myEleccionNoticiaDTO.TheNoticiaDTO.NoticiaId);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myEleccionNoticiaDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pEleccionNoticiaMeGusta", SqlDbType.VarChar, 20, myEleccionNoticiaDTO.EleccionNoticiaMeGusta);
                wobjSQLHelper.SetParametro("@pEleccionNoticiaFecha", SqlDbType.DateTime, -1, myEleccionNoticiaDTO.EleccionNoticiaFecha);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_EleccionNoticia", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.EleccionNoticiaDTO myEleccionNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdNoticia", SqlDbType.Decimal, -1, myEleccionNoticiaDTO.TheNoticiaDTO.NoticiaId);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myEleccionNoticiaDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pEleccionNoticiaMeGusta", SqlDbType.VarChar, 20, myEleccionNoticiaDTO.EleccionNoticiaMeGusta);
                wobjSQLHelper.SetParametro("@pEleccionNoticiaFecha", SqlDbType.DateTime, -1, myEleccionNoticiaDTO.EleccionNoticiaFecha);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_EleccionNoticia", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.EleccionNoticiaDTO myEleccionNoticiaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdNoticia", SqlDbType.Decimal, -1, myEleccionNoticiaDTO.TheNoticiaDTO.NoticiaId);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myEleccionNoticiaDTO.TheFamiliaDTO.IdFamilia);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_EleccionNoticia", "YouCom"))
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
