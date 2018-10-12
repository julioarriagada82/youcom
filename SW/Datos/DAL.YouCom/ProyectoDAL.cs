using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.DAL
{
    public class ProyectoDAL
    {
        #region " Metodo getListadoProyecto "
        public static bool getListadoProyecto(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoProyecto",
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
        public static bool Insert(YouCom.DTO.ProyectoDTO myProyectoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myProyectoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myProyectoDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPropuesta", SqlDbType.Decimal, -1, myProyectoDTO.ThePropuestaDTO.IdPropuesta);
                wobjSQLHelper.SetParametro("@pNombreProyecto", SqlDbType.VarChar, 500, myProyectoDTO.NombreProyecto);
                wobjSQLHelper.SetParametro("@pDescripcionProyecto", SqlDbType.Text, -1, myProyectoDTO.DescripcionProyecto);
                wobjSQLHelper.SetParametro("@pFechaInicioProyecto", SqlDbType.DateTime, -1, myProyectoDTO.FechaInicioProyecto);
                wobjSQLHelper.SetParametro("@pFechaTerminoProyecto", SqlDbType.DateTime, -1, myProyectoDTO.FechaTerminoProyecto);
                wobjSQLHelper.SetParametro("@pFechaEntregaProyecto", SqlDbType.DateTime, -1, myProyectoDTO.FechaEntregaProyecto);
                wobjSQLHelper.SetParametro("@pPresupuestoProyecto", SqlDbType.Decimal, -1, myProyectoDTO.PresupuestoProyecto);
                wobjSQLHelper.SetParametro("@pDireccionProyecto", SqlDbType.VarChar, 300, myProyectoDTO.DireccionProyecto);
                wobjSQLHelper.SetParametro("@pIdEmpresaContratista", SqlDbType.Decimal, -1, myProyectoDTO.TheEmpresaContratistaDTO.IdEmpresaContratista);
                wobjSQLHelper.SetParametro("@pIdProyectoEstado", SqlDbType.Decimal, -1, myProyectoDTO.TheProyectoEstadoDTO.IdProyectoEstado);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myProyectoDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Proyecto", "YouCom"))
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
        public static bool Update(YouCom.DTO.ProyectoDTO myProyectoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdProyecto", SqlDbType.Decimal, -1, myProyectoDTO.IdProyecto);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myProyectoDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myProyectoDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdPropuesta", SqlDbType.Decimal, -1, myProyectoDTO.ThePropuestaDTO.IdPropuesta);
                wobjSQLHelper.SetParametro("@pNombreProyecto", SqlDbType.VarChar, 500, myProyectoDTO.NombreProyecto);
                wobjSQLHelper.SetParametro("@pDescripcionProyecto", SqlDbType.Text, -1, myProyectoDTO.DescripcionProyecto);
                wobjSQLHelper.SetParametro("@pFechaInicioProyecto", SqlDbType.DateTime, -1, myProyectoDTO.FechaInicioProyecto);
                wobjSQLHelper.SetParametro("@pFechaTerminoProyecto", SqlDbType.DateTime, -1, myProyectoDTO.FechaTerminoProyecto);
                wobjSQLHelper.SetParametro("@pFechaEntregaProyecto", SqlDbType.DateTime, -1, myProyectoDTO.FechaEntregaProyecto);
                wobjSQLHelper.SetParametro("@pPresupuestoProyecto", SqlDbType.Decimal, -1, myProyectoDTO.PresupuestoProyecto);
                wobjSQLHelper.SetParametro("@pDireccionProyecto", SqlDbType.VarChar, 300, myProyectoDTO.DireccionProyecto);
                wobjSQLHelper.SetParametro("@pIdEmpresaContratista", SqlDbType.Decimal, -1, myProyectoDTO.TheEmpresaContratistaDTO.IdEmpresaContratista);
                wobjSQLHelper.SetParametro("@pIdProyectoEstado", SqlDbType.Decimal, -1, myProyectoDTO.TheProyectoEstadoDTO.IdProyectoEstado);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myProyectoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Proyecto", "YouCom"))
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
        public static bool Delete(YouCom.DTO.ProyectoDTO theProyectoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdProyecto", SqlDbType.Decimal, -1, theProyectoDTO.IdProyecto);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, theProyectoDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Proyecto", "YouCom"))
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

        public static bool ActivaProyecto(YouCom.DTO.ProyectoDTO theProyectoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theProyectoDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdProyecto", SqlDbType.VarChar, 20, theProyectoDTO.IdProyecto);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Proyecto", "YouCom"))
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

        public static bool ValidaEliminacionProyecto(DTO.ProyectoDTO theProyectoDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@pIdProyecto", SqlDbType.VarChar, 20, theProyectoDTO.IdProyecto);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionProyecto", "YouCom", pobjDatatable) <= 0)
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
