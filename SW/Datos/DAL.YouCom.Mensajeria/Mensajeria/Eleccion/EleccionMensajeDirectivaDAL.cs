using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL
{
    public class EleccionMensajeDirectivaDAL
    {
        #region " Metodo getMensajeDirectiva "
        public static bool getListadoEleccionMensajeDirectiva(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoEleccionMensajeDirectiva",
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
        public static bool Insert(YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO myEleccionMensajeDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, myEleccionMensajeDirectivaDTO.TheMensajeDirectivaDTO.IdMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myEleccionMensajeDirectivaDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pEleccionMensajeDirectivaMeGusta", SqlDbType.VarChar, 20, myEleccionMensajeDirectivaDTO.EleccionMensajeDirectivaMeGusta);
                wobjSQLHelper.SetParametro("@pEleccionMensajeDirectivaFecha", SqlDbType.DateTime, -1, myEleccionMensajeDirectivaDTO.EleccionMensajeDirectivaFecha);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_EleccionMensajeDirectiva", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO myEleccionMensajeDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, myEleccionMensajeDirectivaDTO.TheMensajeDirectivaDTO.IdMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myEleccionMensajeDirectivaDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pEleccionMensajeDirectivaMeGusta", SqlDbType.VarChar, 20, myEleccionMensajeDirectivaDTO.EleccionMensajeDirectivaMeGusta);
                wobjSQLHelper.SetParametro("@pEleccionMensajeDirectivaFecha", SqlDbType.DateTime, -1, myEleccionMensajeDirectivaDTO.EleccionMensajeDirectivaFecha);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_EleccionMensajeDirectiva", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.EleccionMensajeDirectivaDTO myEleccionMensajeDirectivaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajeDirectiva", SqlDbType.Decimal, -1, myEleccionMensajeDirectivaDTO.TheMensajeDirectivaDTO.IdMensajeDirectiva);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myEleccionMensajeDirectivaDTO.TheFamiliaDTO.IdFamilia);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_EleccionMensajeDirectiva", "YouCom"))
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
