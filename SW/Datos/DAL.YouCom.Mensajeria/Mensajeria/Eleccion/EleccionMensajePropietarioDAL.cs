using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Mensajeria.DAL
{
    public class EleccionMensajePropietarioDAL
    {
        #region " Metodo getMensajeDirectiva "
        public static bool getListadoEleccionMensajePropietario(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoEleccionMensajePropietario",
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
        public static bool Insert(YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO myEleccionMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, myEleccionMensajePropietarioDTO.TheMensajePropietarioDTO.IdMensajePropietario);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myEleccionMensajePropietarioDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pEleccionMensajePropietarioMeGusta", SqlDbType.VarChar, 20, myEleccionMensajePropietarioDTO.EleccionMensajePropietarioMeGusta);
                wobjSQLHelper.SetParametro("@pEleccionMensajePropietarioFecha", SqlDbType.DateTime, -1, myEleccionMensajePropietarioDTO.EleccionMensajePropietarioFecha);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_EleccionMensajePropietario", "YouCom"))
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
        public static bool Update(YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO myEleccionMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, myEleccionMensajePropietarioDTO.TheMensajePropietarioDTO.IdMensajePropietario);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myEleccionMensajePropietarioDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pEleccionMensajePropietarioMeGusta", SqlDbType.VarChar, 20, myEleccionMensajePropietarioDTO.EleccionMensajePropietarioMeGusta);
                wobjSQLHelper.SetParametro("@pEleccionMensajePropietarioFecha", SqlDbType.DateTime, -1, myEleccionMensajePropietarioDTO.EleccionMensajePropietarioFecha);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_EleccionMensajePropietario", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Mensajeria.EleccionMensajePropietarioDTO myEleccionMensajePropietarioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdMensajePropietario", SqlDbType.Decimal, -1, myEleccionMensajePropietarioDTO.TheMensajePropietarioDTO.IdMensajePropietario);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myEleccionMensajePropietarioDTO.TheFamiliaDTO.IdFamilia);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_EleccionMensajePropietario", "YouCom"))
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
