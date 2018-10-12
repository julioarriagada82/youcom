using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.DAL
{
    public class PropuestaDAL
    {
        #region " Metodo getListadoPropuesta "
        public static bool getListadoPropuesta(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoPropuesta",
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
        public static bool Insert(YouCom.DTO.Propuesta.PropuestaDTO myPropuestaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myPropuestaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myPropuestaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myPropuestaDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pNombrePropuesta", SqlDbType.VarChar, 500, myPropuestaDTO.NombrePropuesta);
                wobjSQLHelper.SetParametro("@pDescripcionPropuesta", SqlDbType.Text, -1, myPropuestaDTO.DescripcionPropuesta);
                wobjSQLHelper.SetParametro("@pFechaPropuesta", SqlDbType.DateTime, -1, myPropuestaDTO.FechaPropuesta);
                wobjSQLHelper.SetParametro("@pDireccionPropuesta", SqlDbType.VarChar, 300, myPropuestaDTO.DireccionPropuesta);
                wobjSQLHelper.SetParametro("@pIdPropuestaEstado", SqlDbType.Decimal, -1, myPropuestaDTO.ThePropuestaEstadoDTO.IdPropuestaEstado);
                wobjSQLHelper.SetParametro("@pIdMotivoEstadoPropuesta", SqlDbType.Text, -1, myPropuestaDTO.MotivoEstado);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myPropuestaDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Propuesta", "YouCom"))
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
        public static bool Update(YouCom.DTO.Propuesta.PropuestaDTO myPropuestaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdPropuesta", SqlDbType.Decimal, -1, myPropuestaDTO.IdPropuesta);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myPropuestaDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myPropuestaDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pNombrePropuesta", SqlDbType.VarChar, 500, myPropuestaDTO.NombrePropuesta);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myPropuestaDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pDescripcionPropuesta", SqlDbType.Text, -1, myPropuestaDTO.DescripcionPropuesta);
                wobjSQLHelper.SetParametro("@pFechaPropuesta", SqlDbType.DateTime, -1, myPropuestaDTO.FechaPropuesta);
                wobjSQLHelper.SetParametro("@pDireccionPropuesta", SqlDbType.VarChar, 300, myPropuestaDTO.DireccionPropuesta);
                wobjSQLHelper.SetParametro("@pIdPropuestaEstado", SqlDbType.Decimal, -1, myPropuestaDTO.ThePropuestaEstadoDTO.IdPropuestaEstado);
                wobjSQLHelper.SetParametro("@pMotivoEstadoPropuesta", SqlDbType.Text, -1, myPropuestaDTO.MotivoEstado);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myPropuestaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Propuesta", "YouCom"))
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
        public static bool Delete(YouCom.DTO.Propuesta.PropuestaDTO thePropuestaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdPropuesta", SqlDbType.Decimal, -1, thePropuestaDTO.IdPropuesta);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, thePropuestaDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Propuesta", "YouCom"))
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

        public static bool ActivaPropuesta(YouCom.DTO.Propuesta.PropuestaDTO thePropuestaDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, thePropuestaDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdPropuesta", SqlDbType.VarChar, 20, thePropuestaDTO.IdPropuesta);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Propuesta", "YouCom"))
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

        public static bool ValidaEliminacionPropuesta(DTO.Propuesta.PropuestaDTO thePropuestaDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@pIdPropuesta", SqlDbType.VarChar, 20, thePropuestaDTO.IdPropuesta);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionPropuesta", "YouCom", pobjDatatable) <= 0)
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
