using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.DAL
{
    public class VotacionPropuestaEstadoDAL
    {
        #region " Metodo getVotacionPropuestaEstado "
        public static bool getListadoVotacionPropuestaEstado(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoVotacionPropuestaEstado",
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
        public static bool Insert(YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO myVotacionPropuestaEstadoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pNombreVotacionPropuestaEstado", SqlDbType.VarChar, 200, myVotacionPropuestaEstadoDTO.NombreVotacionPropuestaEstado);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.VarChar, -1, myVotacionPropuestaEstadoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myVotacionPropuestaEstadoDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_VotacionPropuestaEstado", "YouCom"))
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
        public static bool Update(YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO myVotacionPropuestaEstadoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVotacionPropuestaEstado", SqlDbType.Decimal, -1, myVotacionPropuestaEstadoDTO.IdVotacionPropuestaEstado);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.VarChar, -1, myVotacionPropuestaEstadoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pNombreVotacionPropuestaEstado", SqlDbType.VarChar, 200, myVotacionPropuestaEstadoDTO.NombreVotacionPropuestaEstado);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myVotacionPropuestaEstadoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_VotacionPropuestaEstado", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO myVotacionPropuestaEstadoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdVotacionPropuestaEstado", SqlDbType.Decimal, -1, myVotacionPropuestaEstadoDTO.IdVotacionPropuestaEstado);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myVotacionPropuestaEstadoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_VotacionPropuestaEstado", "YouCom"))
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

        public static bool ActivaVotacionPropuestaEstado(YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO theVotacionPropuestaEstadoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theVotacionPropuestaEstadoDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdVotacionPropuestaEstado", SqlDbType.VarChar, 20, theVotacionPropuestaEstadoDTO.IdVotacionPropuestaEstado);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_VotacionPropuestaEstado", "YouCom"))
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

        public static bool ValidaEliminacionVotacionPropuestaEstado(YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO theVotacionPropuestaEstadoDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idVotacionPropuestaEstado", SqlDbType.VarChar, 20, theVotacionPropuestaEstadoDTO.IdVotacionPropuestaEstado);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionVotacionPropuestaEstado", "YouCom", pobjDatatable) <= 0)
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
