using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class ServiciosDAL
    {
        #region " Metodo getListadoServicios "
        public static bool getListadoServicios(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoServicios",
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
        public static bool Insert(YouCom.DTO.ServiciosDTO myServiciosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdRespServicio", SqlDbType.Decimal, -1, myServiciosDTO.IdRespServicio);
                wobjSQLHelper.SetParametro("@pNombreServicio", SqlDbType.VarChar, 200, myServiciosDTO.NombreServicio);
                wobjSQLHelper.SetParametro("@pDescripcionServicio", SqlDbType.Text, -1, myServiciosDTO.DescripcionServicio);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myServiciosDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pFechaInicio", SqlDbType.DateTime, -1, myServiciosDTO.FechaInicio);
                wobjSQLHelper.SetParametro("@pFechaTermino", SqlDbType.DateTime, -1, myServiciosDTO.FechaTermino);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myServiciosDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Servicio", "YouCom"))
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
        public static bool Update(YouCom.DTO.ServiciosDTO myServiciosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdServicio", SqlDbType.Decimal, -1, myServiciosDTO.IdServicio);
                wobjSQLHelper.SetParametro("@pIdRespServicio", SqlDbType.Decimal, -1, myServiciosDTO.IdRespServicio);
                wobjSQLHelper.SetParametro("@pNombreServicio", SqlDbType.VarChar, 200, myServiciosDTO.NombreServicio);
                wobjSQLHelper.SetParametro("@pDescripcionServicio", SqlDbType.Text, -1, myServiciosDTO.DescripcionServicio);
                wobjSQLHelper.SetParametro("@pIdCategoria", SqlDbType.Decimal, -1, myServiciosDTO.IdCategoria);
                wobjSQLHelper.SetParametro("@pFechaInicio", SqlDbType.DateTime, -1, myServiciosDTO.FechaInicio);
                wobjSQLHelper.SetParametro("@pFechaTermino", SqlDbType.DateTime, -1, myServiciosDTO.FechaTermino);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, myServiciosDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UPD_Servicio", "YouCom"))
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
        public static bool Delete(YouCom.DTO.ServiciosDTO theServiciosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdServicio", SqlDbType.Decimal, -1, theServiciosDTO.IdServicio);
                wobjSQLHelper.SetParametro("@pUsuarioModificacion", SqlDbType.VarChar, 20, theServiciosDTO.UsuarioModificacion);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("DEL_Servicio", "YouCom"))
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

        public static bool ActivaServicio(YouCom.DTO.ServiciosDTO theServiciosDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 50, theServiciosDTO.UsuarioModificacion);
            wobjSQLHelper.SetParametro("@pIdServicio", SqlDbType.VarChar, 20, theServiciosDTO.IdServicio);

            try
            {


                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Servicio", "YouCom"))
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

        public static bool ValidaEliminacionServicio(YouCom.DTO.ServiciosDTO theServiciosDTO, ref DataTable pobjDatatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();
            wobjSQLHelper.SetParametro("@idServicio", SqlDbType.VarChar, 20, theServiciosDTO.IdServicio);

            try
            {

                //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionServicio", "YouCom", pobjDatatable) <= 0)
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
