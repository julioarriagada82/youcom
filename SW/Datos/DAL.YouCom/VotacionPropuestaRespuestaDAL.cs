using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.DAL
{
    public class VotacionPropuestaRespuestaDAL
    {
        #region " Metodo getListadoVotacionPropuestaRespuesta "
        public static bool getListadoVotacionPropuestaRespuesta(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoVotacionPropuestaRespuesta",
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
        public static bool Insert(YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO myVotacionPropuestaRespuestaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVotacionPropuesta", SqlDbType.Decimal, -1, myVotacionPropuestaRespuestaDTO.TheVotacionPropuestaDTO.IdVotacionPropuesta);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myVotacionPropuestaRespuestaDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pFechaVotacion", SqlDbType.DateTime, -1, myVotacionPropuestaRespuestaDTO.FechaVotacion);
                wobjSQLHelper.SetParametro("@pEleccionVotacion", SqlDbType.Char, 1, myVotacionPropuestaRespuestaDTO.EleccionVotacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_VotacionPropuestaRespuesta", "YouCom"))
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
        public static bool Update(YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO myVotacionPropuestaRespuestaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVotacionPropuesta", SqlDbType.Decimal, -1, myVotacionPropuestaRespuestaDTO.TheVotacionPropuestaDTO.IdVotacionPropuesta);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.VarChar, 500, myVotacionPropuestaRespuestaDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pFechaVotacion", SqlDbType.DateTime, -1, myVotacionPropuestaRespuestaDTO.FechaVotacion);
                wobjSQLHelper.SetParametro("@pRespuestaVotacion", SqlDbType.DateTime, -1, myVotacionPropuestaRespuestaDTO.EleccionVotacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_VotacionPropuestaRespuesta", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO theVotacionPropuestaRespuestaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVotacionPropuestaRespuesta", SqlDbType.Decimal, -1, theVotacionPropuestaRespuestaDTO.TheVotacionPropuestaDTO.IdVotacionPropuesta);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_VotacionPropuestaRespuesta", "YouCom"))
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

        public static bool ActivaVotacionPropuestaRespuesta(YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO theVotacionPropuestaRespuestaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@pIdVotacionPropuestaRespuesta", SqlDbType.VarChar, 20, theVotacionPropuestaRespuestaDTO.TheVotacionPropuestaDTO.IdVotacionPropuesta);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_VotacionPropuestaRespuesta", "YouCom"))
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
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }

        public static bool ValidaEliminacionVotacionPropuestaRespuesta(DTO.Propuesta.VotacionPropuestaRespuestaDTO theVotacionPropuestaRespuestaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@pIdVotacionPropuestaRespuesta", SqlDbType.VarChar, 20, theVotacionPropuestaRespuestaDTO.TheVotacionPropuestaDTO.IdVotacionPropuesta);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionVotacionPropuestaRespuesta", "YouCom", pobjDatatable) <= 0)
                {
                    retorno = false;
                }
                else
                {
                    retorno = true;
                }
            }
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }

    }
}
