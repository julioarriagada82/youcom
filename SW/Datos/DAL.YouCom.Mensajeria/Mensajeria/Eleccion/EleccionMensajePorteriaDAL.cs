using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.Mensajeria.DAL
{
    public class EleccionMensajePorteriaDAL
    {
        #region " Metodo getMensajeDirectiva "
        public static bool getListadoEleccionMensajePorteria(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoEleccionMensajePorteria",
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
        public static bool Insert(YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO myEleccionMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myEleccionMensajePorteriaDTO.TheMensajePorteriaDTO.IdMensajePorteria);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myEleccionMensajePorteriaDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pEleccionMensajePorteriaMeGusta", SqlDbType.VarChar, 20, myEleccionMensajePorteriaDTO.EleccionMensajePorteriaMeGusta);
                wobjSQLHelper.SetParametro("@pEleccionMensajePorteriaFecha", SqlDbType.DateTime, -1, myEleccionMensajePorteriaDTO.EleccionMensajePorteriaFecha);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_EleccionMensajePorteria", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO myEleccionMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myEleccionMensajePorteriaDTO.TheMensajePorteriaDTO.IdMensajePorteria);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myEleccionMensajePorteriaDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pEleccionMensajePorteriaMeGusta", SqlDbType.VarChar, 20, myEleccionMensajePorteriaDTO.EleccionMensajePorteriaMeGusta);
                wobjSQLHelper.SetParametro("@pEleccionMensajePorteriaFecha", SqlDbType.DateTime, -1, myEleccionMensajePorteriaDTO.EleccionMensajePorteriaFecha);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_EleccionMensajePorteria", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.EleccionMensajePorteriaDTO myEleccionMensajePorteriaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePorteria", SqlDbType.Decimal, -1, myEleccionMensajePorteriaDTO.TheMensajePorteriaDTO.IdMensajePorteria);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myEleccionMensajePorteriaDTO.TheFamiliaDTO.IdFamilia);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_EleccionMensajePorteria", "YouCom"))
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
