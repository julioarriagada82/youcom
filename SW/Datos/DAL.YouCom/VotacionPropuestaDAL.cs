using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.DAL
{
    public class VotacionPropuestaDAL
    {
        #region " Metodo getListadoVotacionPropuesta "
        public static bool getListadoVotacionPropuesta(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoVotacionPropuesta",
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
        public static bool Insert(YouCom.DTO.Propuesta.VotacionPropuestaDTO myVotacionPropuestaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myVotacionPropuestaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myVotacionPropuestaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPropuesta", SqlDbType.Decimal, -1, myVotacionPropuestaDTO.ThePropuestaDTO.IdPropuesta);
                wobjSQLHelper.SetParametro("@pFechaInicioVotacionPropuesta", SqlDbType.DateTime, -1, myVotacionPropuestaDTO.FechaInicioVotacionPropuesta);
                wobjSQLHelper.SetParametro("@pFechaTerminoVotacionPropuesta", SqlDbType.DateTime, -1, myVotacionPropuestaDTO.FechaTerminoVotacionPropuesta);
                wobjSQLHelper.SetParametro("@pIdVotacionPropuestaEstado", SqlDbType.Decimal, -1, myVotacionPropuestaDTO.TheVotacionPropuestaEstadoDTO.IdVotacionPropuestaEstado);
                wobjSQLHelper.SetParametro("@pMotivoEstadoVotacionPropuesta", SqlDbType.Text, -1, myVotacionPropuestaDTO.MotivoEstado);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myVotacionPropuestaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_VotacionPropuesta", "YouCom"))
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
        public static bool Update(YouCom.DTO.Propuesta.VotacionPropuestaDTO myVotacionPropuestaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVotacionPropuesta", SqlDbType.Decimal, -1, myVotacionPropuestaDTO.IdVotacionPropuesta);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myVotacionPropuestaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myVotacionPropuestaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPropuesta", SqlDbType.Decimal, -1, myVotacionPropuestaDTO.ThePropuestaDTO.IdPropuesta);
                wobjSQLHelper.SetParametro("@pFechaInicioVotacionPropuesta", SqlDbType.DateTime, -1, myVotacionPropuestaDTO.FechaInicioVotacionPropuesta);
                wobjSQLHelper.SetParametro("@pFechaTerminoVotacionPropuesta", SqlDbType.DateTime, -1, myVotacionPropuestaDTO.FechaTerminoVotacionPropuesta);
                wobjSQLHelper.SetParametro("@pIdVotacionPropuestaEstado", SqlDbType.Decimal, -1, myVotacionPropuestaDTO.TheVotacionPropuestaEstadoDTO.IdVotacionPropuestaEstado);
                wobjSQLHelper.SetParametro("@pMotivoEstadoVotacionPropuesta", SqlDbType.Text, -1, myVotacionPropuestaDTO.MotivoEstado);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myVotacionPropuestaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_VotacionPropuesta", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Propuesta.VotacionPropuestaDTO theVotacionPropuestaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVotacionPropuesta", SqlDbType.Decimal, -1, theVotacionPropuestaDTO.IdVotacionPropuesta);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, theVotacionPropuestaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_VotacionPropuesta", "YouCom"))
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

        public static bool ActivaVotacionPropuesta(YouCom.DTO.Propuesta.VotacionPropuestaDTO theVotacionPropuestaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theVotacionPropuestaDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdVotacionPropuesta", SqlDbType.VarChar, 20, theVotacionPropuestaDTO.IdVotacionPropuesta);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_VotacionPropuesta", "YouCom"))
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

        public static bool ValidaEliminacionVotacionPropuesta(DTO.Propuesta.VotacionPropuestaDTO theVotacionPropuestaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@pIdVotacionPropuesta", SqlDbType.VarChar, 20, theVotacionPropuestaDTO.IdVotacionPropuesta);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionVotacionPropuesta", "YouCom", pobjDatatable) <= 0)
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
